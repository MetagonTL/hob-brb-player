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
        private int brbToMatchIndex = -1;

        private List<BRBEpisode> importedBRBData = new List<BRBEpisode>(); // Raw data from JSON file by MetagonTL
        private List<BRBEpisode> epWithPreviouslyUnknFilenames = new List<BRBEpisode>(); // Raw data from JSON file by MetagonTL
        private List<BRBEpisode> brbsToMatch = new List<BRBEpisode>(); // Static list that contains BRBs with unknown filename or such BRBs that cannot be found in the directory
        private List<string> filesNotCovered = new List<string>(); // Dynamic list that contains all files in the BRB directory that have not yet been matched to a BRB in the system

        FormPlayerTest playerTest = new FormPlayerTest(); // A black form with a red border that has the same title as the player form, for OBS setup

        public FormInitialSetup()
        {
            InitializeComponent();

            DockPanels();

            LoadIcons();
        }

        // Panels are not docked to allow easy editing in Designer
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
                dispFilesInBRBDir.Text = "The application will automatically compare the videos in that directory with the data known to and provided by MetagonTL.\r\n\r\n" +
                                         "You will be able to amend this data in the next step.";
            }
            else if (Directory.Exists(txtBRBDirectory.Text))
            {
                btnNext.Enabled = true;
                chkUseWorkingDirRoot.Enabled = true;

                // Load raw data from MetagonTL
                if (importedBRBData.Count == 0) // If JSON data is already loaded, no need to load it again
                {
                    try
                    {
                        string serImportedBRBList = File.ReadAllText("legacydata.json");
                        importedBRBData = JsonConvert.DeserializeObject<List<BRBEpisode>>(serImportedBRBList);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Could not properly load file legacydata.json. The application cannot retrieve the BRB data provided by MetagonTL and will exit.\r\n\r\n" +
                                        "Ensure you have extracted everything from the .zip file provided to you and that the application has read permissions in its directory. " +
                                        "If the error persists, please contact MetagonTL for assistance.",
                                        "Failed importing BRB data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                        return;
                    }
                    catch (JsonException)
                    {
                        MessageBox.Show("Could not parse file legacydata.json. The application cannot retrieve the BRB data provided by MetagonTL and will exit.\r\n\r\n" +
                                        "If you see this error, MetagonTL might have provided a faulty JSON file. Please contact him for assistance if the problem persists.",
                                        "Failed importing BRB data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                        return;
                    }
                }
                if (epWithPreviouslyUnknFilenames.Count == 0) // If JSON data is already loaded, no need to load it again
                {
                    try
                    {
                        string serImportedUnknBRBList = File.ReadAllText("legacynamelessdata.json");
                        epWithPreviouslyUnknFilenames = JsonConvert.DeserializeObject<List<BRBEpisode>>(serImportedUnknBRBList);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Could not properly load file legacynamelessdata.json. The application cannot retrieve the BRB data provided by MetagonTL and will exit.\r\n\r\n" +
                                        "Ensure you have extracted everything from the .zip file provided to you and that the application has read permissions in its directory. " +
                                        "If the error persists, please contact MetagonTL for assistance.",
                                        "Failed importing BRB data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                        return;
                    }
                    catch (JsonException)
                    {
                        MessageBox.Show("Could not parse file legacynamelessdata.json. The application cannot retrieve the BRB data provided by MetagonTL and will exit.\r\n\r\n" +
                                        "If you see this error, MetagonTL might have provided a faulty JSON file. Please contact him for assistance if the problem persists.",
                                        "Failed importing BRB data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                        return;
                    }
                }

                List<string> paths = new List<string>(Directory.GetFiles(txtBRBDirectory.Text));
                List<string> filenames = new List<string>(); // Better to only work with filenames instead of paths, since their exact format is more reliable
                foreach (string path in paths)
                {
                    filenames.Add(Path.GetFileName(path));
                }
                int importedBRBsFound = 0;
                List<BRBEpisode> brbsNotFound = new List<BRBEpisode>(importedBRBData); // BRBs that MetagonTL thinks should exist, but were not found in the directory
                filesNotCovered = new List<string>(filenames); // Files in the directory that are neither in MetagonTL's list, nor could the user match them

                foreach (BRBEpisode episode in importedBRBData)
                {
                    if (File.Exists(Path.Combine(txtBRBDirectory.Text, episode.Filename)))
                    {
                        importedBRBsFound++;
                        brbsNotFound.Remove(episode);
                        filesNotCovered.Remove(episode.Filename);
                    }
                }

                brbsToMatch = new List<BRBEpisode>(epWithPreviouslyUnknFilenames); // Contains BRBs that were not found on disk, or where MetagonTL did not know the filename in the first place
                brbsToMatch.AddRange(brbsNotFound);

                dispFilesInBRBDir.Text = "Of the " + importedBRBData.Count + " BRB episodes known to MetagonTL by filename, " + importedBRBsFound + " " +
                                         (importedBRBsFound == 1 ? "was" : "were") + " found in your directory.\r\n" +
                                         "Furthermore, the directory contains " + filesNotCovered.Count + " file" + (filesNotCovered.Count == 1 ? "" : "s") +
                                         " with names unknown to MetagonTL.\r\n" + 
                                         "Some of them might belong to the " + brbsToMatch.Count + " episode" + (brbsToMatch.Count == 1 ? "" : "s") +
                                         " where MetagonTL has playback data but not the filename.\r\n\r\n" +
                                         "You will be able to amend this data in the next step.";
            }
            else
            {
                btnNext.Enabled = false;
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


        // Legacy data import

        // "Begin matching" also sets up the BRB manager and imports all the episodes that are "clear" to import
        private void btnBeginMatching_Click(object sender, EventArgs e)
        {
            // BRBManager.BRBEpisodes should be an empty list right now, even if brbepisodes.json already exists, since it shouldn't get loaded if Initial Setup is triggered

            foreach (BRBEpisode episode in importedBRBData)
            {
                if (File.Exists(Path.Combine(txtBRBDirectory.Text, episode.Filename)))
                {
                    episode.RefreshDuration(); // Fetch the actual duration

                    if (episode.Duration.Ticks == 0) // Make sure the app understands all BRB files
                    {
                        MessageBox.Show("Could not register the BRB file \"" + episode.Filename + "\". Make sure it is a valid video file (in a format compatible with VLC) " +
                                        "and the application has read permissions on it. If you are certain this is the case, please contact MetagonTL for assistance.\r\n\r\n" +
                                        "The application will now exit.",
                                        "Importing BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                    }

                    BRBManager.BRBEpisodes.Add(episode);
                }
            }

            BRBManager.BRBEpisodes.Sort();

            // Try saving BRB data to disk preliminarily. If this fails, do not proceed
            if (!BRBManager.SaveEpisodes())
            {
                MessageBox.Show("Could not write to file brbepisodes.json. BRB data could not be imported; the application will now exit.\r\n\r\n" +
                                "Make sure the application has write permissions in its directory and try again.",
                                "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.ExitApplication();
            }

            if (brbsToMatch.Count > 0)
            {
                brbToMatchIndex = 0;
                pnlUnknownBRBImportPre.Visible = false;
                pnlUnknownBRBImport.Visible = true;

                UpdateImportPanel();
            }
            else
            {
                // Show post-panel
                prgStep.Value = 80;

                pnlUnknownBRBImportPre.Visible = false;
                pnlUnknownBRBImportPost.Visible = true;

                btnNext.Enabled = true;
            }
        }

        private void UpdateImportPanel()
        {
            prgStep.Value = 20 + (60 * brbToMatchIndex) / brbsToMatch.Count;

            BRBEpisode episodeToMatch = brbsToMatch[brbToMatchIndex];

            txtLastKnownFilename.Text = episodeToMatch.Filename;
            txtDuration.Text = BRBManager.TimeSpanToMMSS(episodeToMatch.Duration);
            txtDescription.Text = episodeToMatch.Description;
            drpCurrentFilename.Items.Clear();
            drpCurrentFilename.Items.AddRange(filesNotCovered.ToArray());
            drpCurrentFilename.SelectedIndex = -1;
            btnPlayWithStdProgram.Enabled = false;
            btnConfirmMatch.Enabled = false;
        }

        private void drpCurrentFilename_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpCurrentFilename.SelectedIndex != -1)
            {
                btnPlayWithStdProgram.Enabled = true;
                btnConfirmMatch.Enabled = true;
            }
        }

        private void btnPlayWithStdProgram_Click(object sender, EventArgs e)
        {
            if (drpCurrentFilename.SelectedIndex != -1)
            {
                System.Diagnostics.Process.Start(Path.Combine(Config.BRBDirectory, (string)drpCurrentFilename.SelectedItem));
            }
        }

        private void btnSkipMatch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm you cannot match this BRB to any filename, and hence want to discard all data about this BRB. This action cannot be undone.",
                                "Discarding all data about this BRB", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                brbToMatchIndex++;
                if (brbToMatchIndex < brbsToMatch.Count)
                {
                    // Do nothing with the BRB list, just update import panel to the next BRB, this effectively discards the data
                    UpdateImportPanel();
                }
                else
                {
                    // Show post-panel
                    prgStep.Value = 80;

                    pnlUnknownBRBImport.Visible = false;
                    pnlUnknownBRBImportPost.Visible = true;

                    btnNext.Enabled = true;
                }
            }
        }

        private void btnConfirmMatch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to assign this BRB to the currently selected filename?",
                                "Confirm BRB match", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                BRBEpisode episodeToMatch = brbsToMatch[brbToMatchIndex];

                // Copy data over to the actual filename. If successful, add it to the BRB manager and save immediately
                // Since the BRB could not be found on disk, it is not in the BRB list, so no need to remove it
                if (!BRBManager.TransferToNewFilename(episodeToMatch, (string)drpCurrentFilename.SelectedItem, false))
                {
                    MessageBox.Show("Could not register the BRB file you selected. Make sure it is a valid video file (in a format compatible with VLC) " +
                                    "and the application has read permissions on it.",
                                    "Matching BRB episode failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!BRBManager.SaveEpisodes())
                {
                    MessageBox.Show("Could not write to file brbepisodes.json. The match could not be completed; the application will now exit.\r\n\r\n" +
                                    "Make sure the application has write permissions in its directory and try again.",
                                    "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.ExitApplication();
                }

                filesNotCovered.Remove((string)drpCurrentFilename.SelectedItem);

                brbToMatchIndex++;
                if (brbToMatchIndex < brbsToMatch.Count)
                {
                    UpdateImportPanel();
                }
                else
                {
                    // Show post-panel
                    prgStep.Value = 80;

                    pnlUnknownBRBImport.Visible = false;
                    pnlUnknownBRBImportPost.Visible = true;

                    btnNext.Enabled = true;
                }
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
                    ChangeSetupState(InitialSetupState.UnknownBRBImport);
                    break;

                case InitialSetupState.UnknownBRBImport:
                    foreach (string filename in filesNotCovered)
                    {
                        if (!BRBManager.RegisterNewBRB(filename))
                        {
                            MessageBox.Show("Could not register the BRB file \"" + filename + "\". Make sure it is a valid video file (in a format compatible with VLC) " +
                                            "and the application has read permissions on it. If it is not supposed to be a BRB episode, please move it out of the BRB directory.",
                                            "Registering new/unknown BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    if (!BRBManager.SaveEpisodes())
                    {
                        MessageBox.Show("Could not write to file brbepisodes.json. The match could not be completed; the application will now exit.\r\n\r\n" +
                                        "Make sure the application has write permissions in its directory and try again.",
                                        "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Program.ExitApplication();
                    }
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
                    lblStep.Text = "Step 1 / 6";
                    prgStep.Value = 0;

                    pnlInitialSetupInfo.Visible = true;
                    btnNext.Text = "Ready";
                    break;

                case InitialSetupState.BRBDirectory:
                    lblStep.Text = "Step 2 / 6";
                    prgStep.Value = 15;

                    pnlBRBDirectory.Visible = true;

                    if (txtBRBDirectory.Text == "")
                    {
                        btnNext.Enabled = false;
                    }

                    break;

                case InitialSetupState.UnknownBRBImport:
                    lblStep.Text = "Step 3 / 6";
                    prgStep.Value = 20;

                    pnlUnknownBRBImportPre.Visible = true;
                    btnNext.Enabled = false;
                    break;

                case InitialSetupState.PlayerAndChapter:
                    lblStep.Text = "Step 4 / 6";
                    prgStep.Value = 80;

                    numChapter.Minimum = Config.CurrentReleaseChapter;
                    numChapter.Value = Config.CurrentReleaseChapter;

                    pnlPlayerAndChapter.Visible = true;
                    break;

                case InitialSetupState.OBSSetup:
                    lblStep.Text = "Step 5 / 6";
                    prgStep.Value = 90;

                    pnlOBSSetup.Visible = true;
                    btnNext.Text = "Done";
                    break;

                case InitialSetupState.SavingConfig:
                    lblStep.Text = "Step 6 / 6";
                    prgStep.Value = 100;

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
                Program.OnInitialSetupCompleted();
            }
        }
    }
}
