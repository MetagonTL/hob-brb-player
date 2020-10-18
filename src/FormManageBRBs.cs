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
    public partial class FormManageBRBs : Form
    {
        private BRBEpisode selectedBRB;

        public FormManageBRBs()
        {
            InitializeComponent();

            drpSearchWhere.SelectedIndex = 0;

            LoadIcons();

            lstAllBRBs.Columns.Add("Filename", lstAllBRBs.Width - 4);
        }

        private void FormManageBRBs_Shown(object sender, EventArgs e)
        {
            BRBManager.RefreshAvailableList();
            UpdateBRBList(false); // Not checking for new files on form show anymore, since that defeats the purpose of the "Reload BRB list" button
        }

        private void LoadIcons()
        {
            btnReloadBRBList.Image = Image.FromFile("icons\\reload.png");
            btnSave.Image = Image.FromFile("icons\\save.png");
            picSearch.Image = Image.FromFile("icons\\search.png");
        }

        // This just fetches data from the BRB Manager (and checks for new files)
        private void UpdateBRBList(bool considerNewFiles)
        {
            selectedBRB = null;

            if (considerNewFiles)
            {
                CheckAndAddNewFiles();
            }

            lstAllBRBs.BeginUpdate();
            lstAllBRBs.Items.Clear();

            List<ListViewItem> newItems = new List<ListViewItem>(BRBManager.BRBEpisodes.Count);

            foreach (BRBEpisode episode in BRBManager.BRBEpisodes)
            {
                if (txtSearch.Text == "" || episode.ContainsTextAtField(txtSearch.Text, drpSearchWhere.SelectedIndex))
                {
                    ListViewItem item = new ListViewItem(episode.Filename);
                    if (!BRBManager.AvailableBRBEpisodes.Contains(episode))
                    {
                        item.ForeColor = Color.Red;
                    }
                    else if (episode.IsNew)
                    {
                        item.ForeColor = Color.Blue;
                    }
                    if (episode.Favourite)
                    {
                        item.Font = new Font(item.Font.FontFamily, 9.75f, FontStyle.Bold);
                    }
                    newItems.Add(item);
                }
            }

            lstAllBRBs.Items.AddRange(newItems.ToArray());

            lstAllBRBs.EndUpdate();

            if (txtSearch.Text == "")
            {
                lblAvailableBRBs.Text = "BRB Episodes (" + BRBManager.BRBEpisodes.Count + "):";
            }
            else
            {
                lblAvailableBRBs.Text = "BRB Episodes (filtered, " + lstAllBRBs.Items.Count + " / " + BRBManager.BRBEpisodes.Count + "):";
            }

            UpdateBRBData();

            if (lstAllBRBs.Items.Count > 0)
            {
                lstAllBRBs.Items[0].Selected = true;
            }
        }

        // Look for new BRB files that are yet unknown to the manager's list
        private void CheckAndAddNewFiles()
        {
            List<string> knownFilenames = BRBManager.GetBRBFilenameList();

            foreach (string diskPath in Directory.GetFiles(Config.BRBDirectory))
            {
                if (!knownFilenames.Contains(Path.GetFileName(diskPath)))
                {
                    if (MessageBox.Show("A new file has been found in the BRB directory. Would you like to add \"" + Path.GetFileName(diskPath) + "\" to the BRB list now?\r\n\r\n" +
                                        "Note: The new BRB will automatically receive " + Config.AutoGuaranteedPlaysForNewBRBs +
                                        " \"Guaranteed\" and " + Config.AutoPriorityPlaysForNewBRBs + " \"Priority\" plays.\r\n\r\n" +
                                        "If this is a renamed or updated BRB file, please select \"No\" and use the \"Replace with new version\" button.",
                                        "New BRB found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!BRBManager.RegisterNewBRB(Path.GetFileName(diskPath)))
                        {
                            MessageBox.Show("Could not register the new BRB file. Make sure it is a valid video file (in a format compatible with VLC) and the application has read permissions on it.",
                                            "Adding new BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // BRB Data means the information the user can change on the right hand side of the form
        private void UpdateBRBData()
        {
            if (selectedBRB == null)
            {
                btnOpenBRB.Enabled = false;
                btnReplaceBRB.Enabled = false;
                btnRenameBRB.Enabled = false;

                chkFavourite.Checked = false;
                txtDuration.Text = "";
                txtTitle.Text = "";
                txtAuthors.Text = "";
                txtDescription.Text = "";
                numGuaranteedPlays.Value = 0;
                numPriorityPlays.Value = 0;
                txtPlaybackData.Text = "";
            }
            else
            {
                btnOpenBRB.Enabled = BRBManager.AvailableBRBEpisodes.Contains(selectedBRB);
                btnReplaceBRB.Enabled = true;
                btnRenameBRB.Enabled = true;

                chkFavourite.Checked = selectedBRB.Favourite;
                txtDuration.Text = BRBManager.TimeSpanToMMSS(selectedBRB.Duration);
                txtTitle.Text = selectedBRB.Title;
                txtAuthors.Text = selectedBRB.Credits;
                txtDescription.Text = selectedBRB.Description;
                numGuaranteedPlays.Value = selectedBRB.GuaranteedPlays;
                numPriorityPlays.Value = selectedBRB.PriorityPlays;

                txtPlaybackData.Text = "Last played in " + selectedBRB.LatestPlaybackChapter + " – Played " + selectedBRB.RecentPlaybacks + " time" + (selectedBRB.RecentPlaybacks != 1 ? "s" : "") +
                                        " since " + (Config.Chapter - Config.ChapterHistoryConsidered) + " – Urgency score " + selectedBRB.GetUrgencyScore() + "\r\n";
                if (selectedBRB.PlaybackChapters.Count == 0)
                {
                    txtPlaybackData.Text += "No playbacks on file.";
                }
                else
                {
                    txtPlaybackData.Text += "All playbacks: [" + selectedBRB.PlaybackChapters[0];
                    for (int i = 1; i < selectedBRB.PlaybackChapters.Count; i++)
                    {
                        txtPlaybackData.Text += ", " + selectedBRB.PlaybackChapters[i];
                    }
                    txtPlaybackData.Text += "]";
                }
            }
        }

        private void btnReloadBRBList_Click(object sender, EventArgs e)
        {
            BRBManager.RefreshAvailableList();
            UpdateBRBList(true);
        }

        private void lstAllBRBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAllBRBs.SelectedItems.Count == 0)
            {
                selectedBRB = null;
            }
            else
            {
                selectedBRB = BRBManager.GetEpisode(lstAllBRBs.SelectedItems[0].Text);
            }
            UpdateBRBData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateBRBList(false);
        }

        private void drpSearchWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                UpdateBRBList(false);
            }
        }

        // Opens the video file outside of the application (i.e. with the standard program as set in the user's OS)
        private void btnOpenBRB_Click(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                System.Diagnostics.Process.Start(Path.Combine(Config.BRBDirectory, selectedBRB.Filename));
            }
        }

        // Replaces the selected BRB file with a new version.
        private void btnReplaceBRB_Click(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                FormUpdateBRB updateBRBForm = new FormUpdateBRB(selectedBRB);
                updateBRBForm.ShowDialog(this);
                UpdateBRBList(false);
            }
        }

        // Renames the selected BRB file in the system. If it also currently exists on disk, it renames it on disk as well.
        private void btnRenameBRB_Click(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                FormRenameBRB renameBRBForm = new FormRenameBRB(selectedBRB);
                renameBRBForm.ShowDialog(this);
                UpdateBRBList(false);
            }
        }

        // Changes are immediately transported to BRBs, but only saved to disk on form close

        private void chkFavourite_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.Favourite = chkFavourite.Checked;

                // Do a selective update of the BRB list (and playback data)
                ListViewItem item = lstAllBRBs.SelectedItems[0];
                item.Font = new Font(item.Font.FontFamily, 9.75f, chkFavourite.Checked ? FontStyle.Bold : FontStyle.Regular);

                txtPlaybackData.Text = "Last played in " + selectedBRB.LatestPlaybackChapter + " – Played " + selectedBRB.RecentPlaybacks + " time" + (selectedBRB.RecentPlaybacks != 1 ? "s" : "") +
                                        " since " + (Config.Chapter - Config.ChapterHistoryConsidered) + " – Urgency score " + selectedBRB.GetUrgencyScore() + "\r\n";
                if (selectedBRB.PlaybackChapters.Count == 0)
                {
                    txtPlaybackData.Text += "No playbacks on file.";
                }
                else
                {
                    txtPlaybackData.Text += "All playbacks: [" + selectedBRB.PlaybackChapters[0];
                    for (int i = 1; i < selectedBRB.PlaybackChapters.Count; i++)
                    {
                        txtPlaybackData.Text += ", " + selectedBRB.PlaybackChapters[i];
                    }
                    txtPlaybackData.Text += "]";
                }
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.Title = txtTitle.Text;
            }
        }

        private void txtAuthors_TextChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.Credits = txtAuthors.Text;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.Description = txtDescription.Text;
            }
        }

        private void numGuaranteedPlays_ValueChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.GuaranteedPlays = (int)Math.Round(numGuaranteedPlays‌.Value);
            }
        }

        private void numPriorityPlays_ValueChanged(object sender, EventArgs e)
        {
            if (selectedBRB != null)
            {
                selectedBRB.PriorityPlays = (int)Math.Round(numPriorityPlays.Value);
            }
        }

        // BRB data is saved automatically once the form is closed. However, allow the user to save manually at any time without closing the form
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BRBManager‌.SaveEpisodes())
            {
                btnSave.Text = "Saved!";
                btnSave.Enabled = false;
                tmrResetSaveButton.Start();
            }
            else
            {
                MessageBox.Show("Could not write to file brbepisodes.json. Any changes you made in this window are active in the app but could not be saved to disk.\r\n\r\n" +
                                "It is recommended you investigate this problem as soon as possible, since playback data is difficult to replace if lost.",
                                "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrResetSaveButton_Tick(object sender, EventArgs e)
        {
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            tmrResetSaveButton.Stop();
        }

        private void FormManageBRBs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!BRBManager.SaveEpisodes() && e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Could not write to file brbepisodes.json. Any changes you made in this window are active in the app but could not be saved to disk.\r\n\r\n" +
                                    "It is recommended you investigate this problem as soon as possible, since playback data is difficult to replace if lost.\r\n\r\n" + 
                                    "Would you like to close this window anyway?",
                                    "Writing BRB data to disk failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
