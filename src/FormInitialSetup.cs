using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hob_BRB_Player
{
    public partial class FormInitialSetup : Form
    {
        private bool setupDone = false;
        private InitialSetupState setupState;

        FormPlayerTest playerTest = new FormPlayerTest(); // A black form with a red border that has the same title as the player form, for OBS setup

        public FormInitialSetup()
        {
            InitializeComponent();

            DockPanels();

            LoadIcons();
        }

        // Panels are not docked prior to runtime in order to allow easier editing in Designer
        private void DockPanels()
        {
            pnlInitialSetupInfo.Dock = DockStyle.Fill;
            pnlBRBDirectory.Dock = DockStyle.Fill;
            pnlUnknownBRBImportPre.Dock = DockStyle.Fill;
            pnlUnknownBRBImport.Dock = DockStyle.Fill;
            pnlUnknownBRBImportPost.Dock = DockStyle.Fill;
            pnlPlayerAndChapter.Dock = DockStyle.Fill;
            pnlOBSSetup.Dock = DockStyle.Fill;
            pnlSavingConfig.Dock = DockStyle.Fill;
        }

        private void LoadIcons()
        {
            btnCancel.Image = Image.FromFile("icons\\cancel.png");
            btnNext.Image = Image.FromFile("icons\\next.png");

            picHobbHi.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\hobbHi.png"), 72, 72);
            picHobbNotes.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\hobbNotes.png"), 72, 72);
            picHob3MSub.Image = new Bitmap(Image.FromFile("icons\\hobSubIcon.png"), 72, 72);
            picHobbKet.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\hobbKet.png"), 72, 72);
            picHob3YSub.Image = new Bitmap(Image.FromFile("icons\\hobSubIcon3.png"), 72, 72);
        }

        private void FormInitialSetup_Shown(object sender, EventArgs e)
        {
            ChangeSetupState(InitialSetupState.Welcome);
        }


        // BRB Directory

        private void btnBrowseForBRBDir_Click(object sender, EventArgs e)
        {
            brbDirectoryBrowser‌.ShowDialog();

            if (chkUseWorkingDirRoot‌.Checked)
            {
                if (Path.GetPathRoot(brbDirectoryBrowser.SelectedPath) == Path.GetPathRoot(Application.ExecutablePath))
                {
                    txtBRBDirectory.Text = brbDirectoryBrowser.SelectedPath.Substring(2); // Purge drive letter from path
                }
                else
                {
                    txtBRBDirectory.Text = brbDirectoryBrowser.SelectedPath;
                    chkUseWorkingDirRoot.Checked = false;
                }
            }
            else
            {
                txtBRBDirectory.Text = brbDirectoryBrowser.SelectedPath;
            }
        }

        private void txtBRBDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtBRBDirectory.Text == "")
            {
                btnNext.Enabled = false;
                chkUseWorkingDirRoot.Enabled = false;
                dispFilesInBRBDir.Text = "The application will automatically analyze the files in your directory and compile your list of BRB videos.";
            }
            else if (Directory.Exists(txtBRBDirectory.Text))
            {
                btnNext.Enabled = true;
                chkUseWorkingDirRoot.Enabled = true;

                List<string> paths = new List<string>(Directory.GetFiles(txtBRBDirectory.Text));
                
                dispFilesInBRBDir.Text = "The directory you specified contains " + paths.Count + " file" + (paths.Count == 1 ? "" : "s") + ".\r\n" + 
                                         "They will be analyzed and added to the system once you click \"Next\". This might take a few seconds.";
            }
            else
            {
                btnNext.Enabled = false;
                chkUseWorkingDirRoot.Enabled = false;
                dispFilesInBRBDir.Text = "The provided path could not be found. Please select your desired BRB directory again.";
            }
        }

        private void chkUseWorkingDirRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseWorkingDirRoot.Checked)
            {
                if (Path.GetPathRoot(brbDirectoryBrowser.SelectedPath) == Path.GetPathRoot(Application.ExecutablePath))
                {
                    txtBRBDirectory.Text = brbDirectoryBrowser.SelectedPath.Substring(2); // Purge drive letter from path
                }
                else
                {
                    MessageBox.Show("The application and your selected BRB directory are not currently on the same drive. This is necessary to enable the option " +
                                    "\"Always use drive of application directory\".", "Application and videos not on same drive", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkUseWorkingDirRoot.Checked = false;
                }
            }

            else
            {
                txtBRBDirectory.Text = Path.GetFullPath(brbDirectoryBrowser.SelectedPath); // Add drive letter back in if necessary
            }
        }

        // Set up the BRB manager and analyze all files in the BRB directory
        private void AnalyzeBRBFiles()
        {
            // BRBManager.BRBEpisodes should be an empty list right now, even if brbepisodes.json already exists, since it shouldn't get loaded if Initial Setup is triggered

            List<string> paths = new List<string>(Directory.GetFiles(txtBRBDirectory.Text));
            BRBEpisode episode;

            foreach (string path in paths)
            {
                episode = new BRBEpisode(Path.GetFileName(path), false); // Create BRB episode, but do not treat as a new episode
                if (episode.Duration.Ticks == 0) // Make sure the app understands all BRB files
                {
                    MessageBox.Show("Could not register the BRB file \"" + Path.GetFileName(path) + "\". Make sure it is a valid video file (in a format compatible with VLC) " +
                                    "and the application has read permissions on it. If it is not supposed to be a BRB episode, please move it out of the BRB directory.",
                                    "Registering BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    BRBManager.BRBEpisodes.Add(episode);
                }
            }

            BRBManager.BRBEpisodes.Sort();
            BRBManager.RefreshAvailableList();

            // Try saving BRB data to disk. If this fails, do not proceed
            if (!BRBManager.SaveEpisodes())
            {
                MessageBox.Show("Could not write to file brbepisodes.json. BRB data could not be created; the application will now exit.\r\n\r\n" +
                                "Please make sure the application has write permissions in its directory and try again.",
                                "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.ExitApplication();
            }
        }


        // OBS Setup

        private void btnToggleTestForm_Click(object sender, EventArgs e)
        {
            playerTest.Visible = !playerTest.Visible;
            this.Focus();
        }

        private void btnSwitchScreen_Click(object sender, EventArgs e)
        {
            Screen playerFormScreen = Screen.FromControl(playerTest);
            int newIndex = 0;

            for (int i = 0; i < Screen.AllScreens.Length; i++) // In particular, if only one screen is available, newIndex will remain at 0
            {
                if (Screen.AllScreens[i].Equals(playerFormScreen))
                {
                    newIndex = (i == Screen.AllScreens.Length - 1 ? 0 : i + 1);
                    break;
                }
            }

            playerTest.WindowState = FormWindowState.Normal;
            playerTest.Location = Screen.AllScreens[newIndex].Bounds.Location;
            playerTest.WindowState = FormWindowState.Maximized;
            playerTest.Refresh();

            this.Focus();
        }


        // Finishing and saving config

        private void btnSaveWithTestMode_Click(object sender, EventArgs e)
        {
            Config.TestMode = true;
            setupDone = true;
            Program.OnInitialSetupCompleted(); // This generates the standard config, saves it to file and displays the main form
            this.Close();
        }

        private void btnSaveWithoutTestMode_Click(object sender, EventArgs e)
        {
            Config.TestMode = false;
            setupDone = true;
            Program.OnInitialSetupCompleted();
            this.Close();
        }



        // Handling the "Next" button

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (setupState)
            {
                case InitialSetupState.Welcome:
                default:
                    ChangeSetupState(InitialSetupState.BRBDirectory);
                    break;

                case InitialSetupState.BRBDirectory:
                    Config.BRBDirectory = txtBRBDirectory.Text;
                    AnalyzeBRBFiles();
                    ChangeSetupState(InitialSetupState.PlayerAndChapter);
                    break;

                case InitialSetupState.PlayerAndChapter:
                    Config.StartPlayerOnDifferentScreen = rdoOpenPlayerOnDifferentScreen.Checked;
                    Config.MakePlayerTopMost = chkMakePlayerTopMost.Checked;
                    Config.Chapter = (int)Math.Round(numChapter.Value);
                    ChangeSetupState(InitialSetupState.OBSSetup);
                    this.TopMost = true;
                    break;

                case InitialSetupState.OBSSetup:
                    playerTest.Hide();
                    ChangeSetupState(InitialSetupState.SavingConfig);
                    this.TopMost = false;
                    break;
            }
        }


        // Updates the controls of the form according to the step switched to

        private void ChangeSetupState(InitialSetupState newState)
        {
            pnlInitialSetupInfo.Visible = false;
            pnlBRBDirectory.Visible = false;
            pnlUnknownBRBImportPre.Visible = false;
            pnlUnknownBRBImport.Visible = false;
            pnlUnknownBRBImportPost.Visible = false;
            pnlPlayerAndChapter.Visible = false;
            pnlOBSSetup.Visible = false;
            pnlSavingConfig.Visible = false;

            btnNext.Enabled = true;
            btnNext.Text = "Next";

            switch (newState)
            {
                case InitialSetupState.Welcome:
                default:
                    lblStep.Text = "Step 1 / 5";
                    prgStep.Value = 0;

                    pnlInitialSetupInfo.Visible = true;
                    btnNext.Text = "Ready";
                    break;

                case InitialSetupState.BRBDirectory:
                    lblStep.Text = "Step 2 / 5";
                    prgStep.Value = 35;

                    pnlBRBDirectory.Visible = true;

                    if (txtBRBDirectory.Text == "")
                    {
                        btnNext.Enabled = false;
                    }

                    break;

                case InitialSetupState.PlayerAndChapter:
                    lblStep.Text = "Step 3 / 5";
                    prgStep.Value = 50;

                    numChapter.Minimum = Config.CurrentReleaseChapter;
                    numChapter.Value = Config.CurrentReleaseChapter;

                    // Determine whether the player being topmost is unnecessary
                    if (MessageBox.Show("Please open your OBS and check the following: When creating a Window Capture source and selecting \"Windows Graphics Capture\" (not BitBlt!) as the " +
                                        "Capture Method, do you see a checkbox \"Capture Cursor\"?\r\n\r\n(This needs Windows 10 version 2004 or higher, and an up-to-date version of OBS.)",
                                        "Necessity of Topmost", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {
                        lblWhyTopmost.Text = "This will keep the player window in front of everything else.";
                    }

                    pnlPlayerAndChapter.Visible = true;
                    break;

                case InitialSetupState.OBSSetup:
                    lblStep.Text = "Step 4 / 5";
                    prgStep.Value = 75;

                    pnlOBSSetup.Visible = true;
                    btnNext.Text = "Done";
                    break;

                case InitialSetupState.SavingConfig:
                    lblStep.Text = "Step 5 / 5";
                    prgStep.Value = 100;

                    playerTest.ConfirmClose(); // Release and close the player test form (it has its own protection from accidental Alt-F4)
                    pnlSavingConfig.Visible = true;
                    btnCancel.Enabled = false;
                    btnNext.Enabled = false;
                    break;
            }

            setupState = newState;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to cancel Initial Setup and exit the application. Any preferences already set will be lost and you will have to start again next time.\r\n\r\n" +
                                "Do you want to close the application?", "Aborting Initial Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                Program.ExitApplication();
            }
        }

        private void FormInitialSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!setupDone)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (MessageBox.Show("You are about to cancel Initial Setup and exit the application. Any preferences already set will be lost and you will have to " +
                                        "start again next time.\r\n\r\nDo you want to close the application?", "Aborting Initial Setup",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        == DialogResult.Yes)
                    {
                        Program.ExitApplication();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (Program.AppState != ApplicationState.Exiting) // Seems like a Task Manager or Windows Shutdown close
                {
                    Program.ExitApplication();
                }
            }
            else
            {
                // Program.OnInitialSetupCompleted(); Unnecessary, already called by Yes/No buttons in last step
            }
        }
    }
}
