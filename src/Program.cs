using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hob_BRB_Player
{
    static class Program
    {
        private static ApplicationState appState;
        public static ApplicationState AppState
        {
            get { return appState; }
        }

        private static FormMain mainForm;
        public static FormMain MainForm
        {
            get { return mainForm; }
            private set { mainForm = value; }
        }
        private static FormPlayer playerForm;
        public static FormPlayer PlayerForm
        {
            get { return playerForm; }
            private set { playerForm = value; }
        }

        private static Screen lastPlayerFormScreen = null;

        // Auxiliary methods, since Cursor.Hide() and Cursor.Show() actually stack if called multiple times, which we want to do sometimes
        private static bool cursorVisible = true;
        public static bool CursorVisible
        {
            get { return cursorVisible; }
            set
            {
                if (cursorVisible != value)
                {
                    if (value == true)
                    {
                        Cursor.Show();
                    }
                    else
                    {
                        Cursor.Hide();
                    }
                    cursorVisible = value;
                }
            }
        }
        public static void HideCursor()
        {
            CursorVisible = false;
        }
        public static void ShowCursor()
        {
            CursorVisible = true;
        }

        public static LibVLC VLC { get; private set; }
        public static MediaPlayer VLCPlayer { get; private set; }

    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Core.Initialize(); // Initialize VLC libraries
            VLC = new LibVLC();
            VLCPlayer = new MediaPlayer(VLC);
            VLCPlayer.EnableKeyInput = false; // Make VLC player resistant to involuntary disruption
            VLCPlayer.EnableMouseInput = false;
            try
            {
                VLC.SetLogFile("VLC.log");
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot set the file VLC.log as the VLC log file. Ensure the application has write permissions in its directory.", "Error setting the log file for VLC",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (VLCException)
            {
                MessageBox.Show("Cannot set the file VLC.log as the VLC log file. Ensure the application has write permissions in its directory.", "Error setting the log file for VLC",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            VLCPlayer.EndReached += new EventHandler<EventArgs>(OnMediaEndReached);
            VLCPlayer.EncounteredError += new EventHandler<EventArgs>(OnMediaError);

            if (!IsApplicationSetup())
            {
                appState = ApplicationState.InitialSetup;
                FormInitialSetup initialSetupForm = new FormInitialSetup();
                initialSetupForm.Show();
            }
            else
            {
                if (Config.LoadConfig())
                {
                    if (BRBManager.LoadEpisodes())
                    {
                        appState = ApplicationState.Idle;
                        mainForm = new FormMain();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Could not properly load file brbepisodes.json. The application cannot retrieve saved data about BRB episodes and will exit.\r\n\r\n"
                                        + "It is recommended you verify the integrity of the file as soon as possible, since playback data is difficult to replace if lost.",
                                        "Failed loading BRB episodes and playback data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Could not properly load file config.json. The application cannot retrieve its configuration and will exit.\r\n\r\n"
                                    + "Ensure the application has read permissions in its directory and try again. If this does not resolve the error, the configuration file might be corrupted.",
                                    "Failed loading the configuration file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.Run();
        }

        private static bool IsApplicationSetup()
        {
            return File.Exists("config.json");
        }

        public static void OnInitialSetupCompleted()
        {
            if (Config.GenerateAndSaveStandardConfig())
            {
                if (BRBManager.LoadEpisodes())
                {
                    appState = ApplicationState.Idle;
                    mainForm = new FormMain();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Could not properly load file brbepisodes.json. The application cannot retrieve the provided data about BRB episodes and will exit.\r\n\r\n"
                                    + "If you think you made a mistake during Initial Setup, try reinstalling the application. Otherwise, please contact MetagonTL for assistance.",
                                    "Failed loading BRB episodes and playback data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ExitApplication();
                }
            }
            else
            {
                MessageBox.Show("Could not write to file config.json. Initial Setup could not be completed.\r\n\r\nEnsure the application has write permissions in its directory and try again.",
                                "No write access in application directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitApplication();
            }
        }

        // Called by control form when "Start BRB player" is clicked
        public static void BeginBRBPlayback(List<BRBEpisode> brbPlaylist)
        {
            appState = ApplicationState.PlayerActive;
            PlayerForm = new FormPlayer(brbPlaylist);

            Screen mainFormScreen = Screen.FromControl(MainForm);
            Screen playerFormScreen;

            // Restore last used screen of player form, if possible
            if (lastPlayerFormScreen != null && !lastPlayerFormScreen.Equals(mainFormScreen))
            {
                PlayerForm.WindowState = FormWindowState.Normal;
                PlayerForm.Location = lastPlayerFormScreen.WorkingArea.Location;
                PlayerForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (Config.StartPlayerOnDifferentScreen && Screen.AllScreens.Length > 1)
                {
                    // Try to position the player form on the non-primary screen, if several screens are present
                    if (Screen.AllScreens.Length > 1)
                    {
                        PlayerForm.WindowState = FormWindowState.Normal;
                        playerFormScreen = Screen.AllScreens.First(s => !s.Equals(mainFormScreen));
                        PlayerForm.Location = playerFormScreen.WorkingArea.Location;
                        lastPlayerFormScreen = playerFormScreen;
                        PlayerForm.WindowState = FormWindowState.Maximized;
                    }
                }
                else
                {
                    // Otherwise, place on screen of control form
                    PlayerForm.WindowState = FormWindowState.Normal;
                    PlayerForm.Location = mainFormScreen.WorkingArea.Location;
                    lastPlayerFormScreen = mainFormScreen;
                    PlayerForm.WindowState = FormWindowState.Maximized;
                }
            }

            PlayerForm.Show();
            MainForm.OnBeginBRBPlayback();
        }

        // Called if the respective button is clicked in the player form
        public static void SwitchPlaybackScreen()
        {
            Screen mainFormScreen = Screen.FromControl(MainForm);
            Screen playerFormScreen = Screen.FromControl(PlayerForm);
            int oldIndex = 0;
            int newIndex = 0;

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (Screen.AllScreens[i].Equals(playerFormScreen))
                {
                    oldIndex = i;
                    newIndex = i == Screen.AllScreens.Length - 1 ? 0 : i + 1;
                    break;
                }
            }

            PlayerForm.WindowState = FormWindowState.Normal;
            PlayerForm.Location = Screen.AllScreens[newIndex].WorkingArea.Location;
            PlayerForm.WindowState = FormWindowState.Maximized;
            lastPlayerFormScreen = Screen.AllScreens[newIndex];

            if (Screen.AllScreens[newIndex].Equals(mainFormScreen))
            {
                int dx = MainForm.Location.X - mainFormScreen.WorkingArea.X;
                int dy = MainForm.Location.Y - mainFormScreen.WorkingArea.Y;

                MainForm.Location = Screen.AllScreens[oldIndex].WorkingArea.Location;
                MainForm.Location = new Point(MainForm.Location.X + dx, MainForm.Location.Y + dy);
            }

            PlayerForm.ReCenterControls();
        }

        // Called by control form when "Abort BRB player" is clicked
        public static void AbortBRBPlayback()
        {
            appState = ApplicationState.Idle;
            PlayerForm.CloseGracefully();
            MainForm.OnEndBRBPlayback();
        }

        // Called by player form when the user tells it to close after playback has ended
        public static void FinishBRBPlayback()
        {
            appState = ApplicationState.Idle;
            PlayerForm.CloseGracefully();
            MainForm.OnEndBRBPlayback();
        }

        // Since a new PlayerForm is instantiated for every break, place these listeners here and forward the message
        // Invoke is necessary since VLC uses its own thread
        public static void OnMediaEndReached(object sender, EventArgs e)
        {
            if (PlayerForm != null && PlayerForm.IsDisposed == false)
            {
                PlayerForm.Invoke(new Action(() => { PlayerForm.OnMediaEndReached(sender, e); }));
            }
        }

        public static void OnMediaError(object sender, EventArgs e)
        {
            if (PlayerForm != null && PlayerForm.IsDisposed == false)
            {
                PlayerForm.Invoke(new Action(() => { PlayerForm.OnMediaError(sender, e); }));
            }
        }

        public static void ExitApplication()
        {
            appState = ApplicationState.Exiting;
            Application.Exit();
        }
    }
}
