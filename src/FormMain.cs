using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hob_BRB_Player
{
    public partial class FormMain : Form
    {
        private Image iconStartPlayer = Image.FromFile("icons\\brbplayer.png");
        private Image iconAbortPlayer = Image.FromFile("icons\\abortbrbplayer.png");
        private Image iconPlay = Image.FromFile("icons\\play.png");
        private Image iconPause = Image.FromFile("icons\\pause.png");
        private Image iconVolume = Image.FromFile("icons\\volume.png");
        private Image iconVolumeMuted = Image.FromFile("icons\\volumemuted.png");

        private string durationOfCurrentBRBFormatted;
        private int currentBRBListSortColumn = 1;
        private bool currentBRBListSortInverted = false; // At the beginning, sort by filename ascending

        public FormMain()
        {
            InitializeComponent();

            LoadIcons();

            FillInConfigAndBRBData();
        }

        private void LoadIcons()
        {
            btnManageBRBs.Image = Image.FromFile("icons\\brblist.png");
            btnSettings.Image = Image.FromFile("icons\\settings.png");
            btnGenerate.Image = Image.FromFile("icons\\generate.png");
            btnStartOrAbortPlayer.Image = iconStartPlayer;
            //btnStartPlayer.Image = new Bitmap(Image.FromFile("icons\\hobbVLC.ico"), 24, 24);
            btnCreditsAndSupport.Image = Image.FromFile("icons\\credits.png");
            btnExit.Image = Image.FromFile("icons\\exit.png");
            btnMoveUp.Image = Image.FromFile("icons\\up.png");
            btnMoveDown.Image = Image.FromFile("icons\\down.png");
            btnAddBRB.Image = Image.FromFile("icons\\addbrb.png");
            btnRemoveBRB.Image = Image.FromFile("icons\\removebrb.png");
            btnResetBRBs.Image = Image.FromFile("icons\\removeall.png");
            btnPlayPause.Image = iconPlay;
            btnPreviousBRB.Image = Image.FromFile("icons\\previousbrb.png");
            btnReplayBRB.Image = Image.FromFile("icons\\replaybrb.png");
            btnNextBRB.Image = Image.FromFile("icons\\nextbrb.png");
            chkMuted.Image = iconVolume;
            picSearch.Image = Image.FromFile("icons\\search.png");
        }

        private void FillInConfigAndBRBData()
        {
            UpdateConfigValues();
            // Since this method is only called on startup, enable the Chapter Increment link
            lnkChapterNumber.LinkColor = Color.Blue;
            lnkChapterNumber.LinkBehavior = LinkBehavior.AlwaysUnderline;

            lstAllBRBs.Columns.Add("Fv", 25);
            lstAllBRBs.Columns.Add("Filename", 180);
            lstAllBRBs.Columns.Add("Dur", 40);
            lstAllBRBs.Columns.Add("Description", 240);
            lstAllBRBs.Columns.Add("Last", 40);
            lstAllBRBs.Columns.Add("Wt", 30);
            lstAllBRBs.Columns.Add("Prio", 30);

            lstBRBPlaylist.Columns.Add("Filename", 180);
            lstBRBPlaylist.Columns.Add("Dur", 44);
            lstBRBPlaylist.Columns.Add("Wt", 40);
            lstBRBPlaylist.Columns.Add("Add Reason", 90);

            drpSearchWhere.SelectedIndex = 0;

            UpdateBRBData();
        }

        private void UpdateConfigValues()
        {
            // Set Volume to standard value
            trkVolume.Value = Config.StandardPlayerVolume;
            txtVolume.Text = trkVolume.Value.ToString();
            Program.VLCPlayer.Volume = trkVolume.Value;

            lnkChapterNumber.Text = Config.Chapter.ToString();
            lnkChapterNumber.LinkColor = Color.Black;
            lnkChapterNumber.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            CheckAndAddNewFiles();
        }

        public void UpdateBRBData()
        {
            lstAllBRBs.BeginUpdate();
            lstAllBRBs.Items.Clear();

            List<ListViewItem> newItems = new List<ListViewItem>(BRBManager.AvailableBRBEpisodes.Count);

            foreach (BRBEpisode episode in BRBManager.AvailableBRBEpisodes)
            {
                if (txtSearch.Text == "" || episode.ContainsTextAtField(txtSearch.Text, drpSearchWhere.SelectedIndex))
                {
                    int weight = episode.GetWeight();
                    ListViewItem item = new ListViewItem(new string[] { episode.Favourite ? "\u2605" : "", episode.Filename, BRBManager.TimeSpanToMMSS(episode.Duration), episode.Description,
                                                                    episode.LatestPlaybackChapter.ToString(), weight.ToString(), episode.PriorityChar.ToString() });
                    item.UseItemStyleForSubItems = false;
                    item.SubItems[0].Font = new Font(item.SubItems[0].Font, FontStyle.Bold);
                    item.SubItems[0].ForeColor = Color.Gold;
                    item.SubItems[5].Font = new Font(item.SubItems[5].Font, FontStyle.Bold);
                    item.SubItems[5].ForeColor = weight <= 4 ? Color.DarkGreen : (weight <= 9 ? Color.Orange : Color.Red);
                    if (item.SubItems[6].Text != "N")
                    {
                        item.SubItems[6].Font = new Font(item.SubItems[6].Font, FontStyle.Bold);
                    }
                    newItems.Add(item);
                }
            }

            lstAllBRBs.Items.AddRange(newItems.ToArray());

            lstAllBRBs.ListViewItemSorter = new BRBListComparer(currentBRBListSortColumn, currentBRBListSortInverted);
            lstAllBRBs.Sort();
            lstAllBRBs.ListViewItemSorter = null; // This is supposed to improve performance

            lstAllBRBs.EndUpdate();

            if (txtSearch.Text == "")
            {
                lblAvailableBRBs.Text = "Available BRBs (" + BRBManager.AvailableBRBEpisodes.Count + "):";
            }
            else
            {
                lblAvailableBRBs.Text = "Available BRBs (filtered, " + lstAllBRBs.Items.Count + " / " + BRBManager.AvailableBRBEpisodes.Count + "):";
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
                                        "If this is a renamed or updated BRB file, please select \"No\" and use the \"Replace with new version\" button in \"Manage BRBs\".",
                                        "New BRB found", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (!BRBManager.RegisterNewBRB(Path.GetFileName(diskPath)))
                        {
                            MessageBox.Show("Could not register the new BRB file. Make sure it is a valid video file (in a format compatible with VLC) " +
                                            "and the application has read permissions on it.",
                                            "Adding new BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!BRBManager‌.SaveEpisodes())
                        {
                            MessageBox.Show("Could not write to file brbepisodes.json. The new BRB is available for playback, but its existence could not be saved to disk.\r\n\r\n" +
                                            "It is recommended you investigate this problem as soon as possible, since playback data is difficult to replace if lost.",
                                            "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            UpdateBRBData();
        }

        // The chapter increment link will activate to be clickable on every app restart, and also daily at 07:00 UTC (which is 07:00 GMT and 08:00 BST)
        private void lnkChapterNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Only allow clicking while no BRB is playing
            if (Program.AppState == ApplicationState.Idle && lnkChapterNumber.LinkBehavior == LinkBehavior.AlwaysUnderline)
            {
                Config.Chapter++;
                Config.SaveConfig();
                UpdateConfigValues(); // This also disables the link
                UpdateBRBData();

                // Activate the timer for 07:00
                StartLinkReactivateTimer();
            }
        }

        private void StartLinkReactivateTimer()
        {
            DateTime utcNow = DateTime.UtcNow;
            long currentTickOfDay = utcNow.Hour * TimeSpan.TicksPerHour + utcNow.Minute * TimeSpan.TicksPerMinute + utcNow.Second * TimeSpan.TicksPerSecond;
            long activationTickOfDay = 7 * TimeSpan.TicksPerHour;

            // Only take the next 07:00 if it is at least 1 hour away. Otherwise, go to the next day
            if (currentTickOfDay <= activationTickOfDay - TimeSpan.TicksPerHour)
            {
                tmrAllowChapterIncrement.Interval = (int)((activationTickOfDay - currentTickOfDay) / TimeSpan.TicksPerMillisecond);
            }
            else
            {
                tmrAllowChapterIncrement.Interval = (int)((activationTickOfDay - currentTickOfDay) / TimeSpan.TicksPerMillisecond + 1000 * 60 * 60 * 24);
            }
            tmrAllowChapterIncrement.Enabled = true;
        }

        private void tmrAllowChapterIncrement_Tick(object sender, EventArgs e)
        {
            tmrAllowChapterIncrement.Enabled = false;

            lnkChapterNumber.LinkColor = Color.Blue;
            lnkChapterNumber.LinkBehavior = LinkBehavior.AlwaysUnderline;
        }

        private class BRBListComparer : IComparer
        {
            private int subItemIndex;
            private bool inverted;

            public BRBListComparer(int subitem, bool inverted)
            {
                subItemIndex = subitem;
                this.inverted = inverted;
            }

            public int NonInvertedCompare(object x, object y)
            {
                if (subItemIndex > 6 || subItemIndex < 0)
                {
                    return 0;
                }
                if (((ListViewItem)x).SubItems[subItemIndex].Text == ((ListViewItem)y).SubItems[subItemIndex].Text)
                {
                    return 0;
                }
                switch (subItemIndex)
                {
                    case 0: // Favourite
                        return ((ListViewItem)x).SubItems[subItemIndex].Text == "" ? 1 : -1;
                    // If string is not empty, then item has priority
                    case 1: // Filename
                    case 2: // Duration (can be sorted by String just fine)
                    case 3: // Description
                        return String.Compare(((ListViewItem)x).SubItems[subItemIndex].Text, ((ListViewItem)y).SubItems[subItemIndex].Text);

                    case 4: // Last play
                        return Convert.ToInt32(((ListViewItem)x).SubItems[subItemIndex].Text) < Convert.ToInt32(((ListViewItem)y).SubItems[subItemIndex].Text) ? -1 : 1;
                    // "<" since smaller means it has been longer since playing, so higher priority

                    case 5: // Weight
                        return Convert.ToInt32(((ListViewItem)x).SubItems[subItemIndex].Text) > Convert.ToInt32(((ListViewItem)y).SubItems[subItemIndex].Text) ? -1 : 1;
                    // ">" since bigger means higher priority

                    case 6: // Priority
                    default:
                        switch (((ListViewItem)x).SubItems[subItemIndex].Text)
                        {
                            case "G":
                                return -1;
                            case "P":
                                return ((ListViewItem)y).SubItems[subItemIndex].Text == "G" ? 1 : -1;
                            case "N":
                            default:
                                return 1;
                        }
                }
            }

            public int Compare(object x, object y)
            {
                return inverted ? -NonInvertedCompare(x, y) : NonInvertedCompare(x, y);
            }
        }

        private void lstAllBRBs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (currentBRBListSortColumn == e.Column)
            {
                currentBRBListSortInverted = !currentBRBListSortInverted;
            }
            else
            {
                currentBRBListSortColumn = e.Column;
                currentBRBListSortInverted = false;
            }
            lstAllBRBs.ListViewItemSorter = new BRBListComparer(currentBRBListSortColumn, currentBRBListSortInverted);
            lstAllBRBs.Sort();
            lstAllBRBs.ListViewItemSorter = null; // This is supposed to improve performance
        }

        // Automatically update BRB data if the search text changes
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateBRBData();
        }

        private void drpSearchWhere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                UpdateBRBData();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            lstBRBPlaylist.Items.Clear();
            UpdateBRBPlaylistRunningTime();

            if (numMinutes.Value <= 0)
            {
                MessageBox.Show("The target running time should be positive.", "Cannot generate playlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long targetDurationTicks = (int)numMinutes.Value * TimeSpan.TicksPerMinute;
            TimeSpan targetDuration = new TimeSpan(targetDurationTicks);
            TimeSpan minDuration = new TimeSpan(targetDurationTicks / 100 * (100 - Config.PermittedUndertimePercent));
            TimeSpan maxDuration = new TimeSpan(targetDurationTicks + Config.PermittedOvertimeMinutes * TimeSpan.TicksPerMinute + TimeSpan.TicksPerMinute / 2);

            List<string> addReason = new List<string>();

            List<BRBEpisode> playlist = BRBManager.GeneratePlaylist(minDuration, targetDuration, maxDuration, ref addReason);

            if (playlist == null)
            {
                MessageBox.Show("The playlist generator failed compiling a BRB playlist with the given restrictions.\r\n\r\n"
                                + "You can try the following steps:\r\n"
                                + "– Try generating a playlist again. If there are only few possible options, the generator can sometimes manoeuvre itself into a dead end.\r\n"
                                + "– Change the target running time of your break‌.\r\n"
                                + "– Configure permitted over- and undertime to be more lenient.\r\n"
                                + "– If you have many BRB episodes marked as \"Guaranteed\", unmark some of them.", "Not enough BRB episodes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BRBEpisode ep;
            for (int i = 0; i < playlist.Count; i++)
            {
                ep = playlist[i];
                ListViewItem item = new ListViewItem(new string[] { ep.Filename, BRBManager.TimeSpanToMMSS(ep.Duration), ep.GetWeight().ToString(), addReason[i] });
                lstBRBPlaylist.Items.Add(item);
            }

            UpdateBRBPlaylistRunningTime();
        }

        // Buttons for managing the playlist. The user can still do this while BRBs are playing, but only in places that haven't yet been reached by the player
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBRBPlaylist.SelectedItems.Count != 1)
            {
                return;
            }
            int index = lstBRBPlaylist.SelectedIndices[0];

            if (Program.AppState == ApplicationState.Idle)
            {
                if (index >= 1)
                {
                    ListViewItem temp = lstBRBPlaylist.Items[index];
                    lstBRBPlaylist.Items.Remove(temp);
                    lstBRBPlaylist.Items.Insert(index - 1, temp);
                }
            }
            else if (Program.AppState == ApplicationState.PlayerActive)
            {
                if (index >= Program.PlayerForm.NextOrCurrentBRBIndex + 2)
                {
                    ListViewItem temp = lstBRBPlaylist.Items[index];
                    lstBRBPlaylist.Items.Remove(temp);
                    lstBRBPlaylist.Items.Insert(index - 1, temp);
                    Program.PlayerForm.UpdateBRBPlaylist(GetCurrentPlaylist());
                }
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBRBPlaylist.SelectedItems.Count != 1)
            {
                return;
            }
            int index = lstBRBPlaylist.SelectedIndices[0];

            if (Program.AppState == ApplicationState.Idle)
            {
                if (index <= lstBRBPlaylist.Items.Count - 2)
                {
                    ListViewItem temp = lstBRBPlaylist.Items[index];
                    lstBRBPlaylist.Items.Remove(temp);
                    lstBRBPlaylist.Items.Insert(index + 1, temp);
                }
            }
            else if (Program.AppState == ApplicationState.PlayerActive)
            {
                if (index >= Program.PlayerForm.NextOrCurrentBRBIndex + 1 && index <= lstBRBPlaylist.Items.Count - 2)
                {
                    ListViewItem temp = lstBRBPlaylist.Items[index];
                    lstBRBPlaylist.Items.Remove(temp);
                    lstBRBPlaylist.Items.Insert(index + 1, temp);
                    Program.PlayerForm.UpdateBRBPlaylist(GetCurrentPlaylist());
                }
            }
        }

        private void btnAddBRB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstAllBRBs.SelectedItems)
            {
                bool alreadyAdded = false;
                foreach (ListViewItem playlistItem in lstBRBPlaylist.Items)
                {
                    if (item.SubItems[1].Text == playlistItem.Text)
                    {
                        alreadyAdded = true;
                    }
                }

                if (!alreadyAdded || MessageBox.Show("The BRB \"" + item.SubItems[1].Text + "\" is already present on the playlist. Would you like to add it again?",
                                                     "Please confirm: Playing a BRB video multiple times", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                     == DialogResult.Yes)
                {
                    lstBRBPlaylist.Items.Add(new ListViewItem(new string[] { item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[5].Text, "Manual" }));

                    if (Program.AppState == ApplicationState.PlayerActive)
                    {
                        Program.PlayerForm.AppendBRB(BRBManager.GetEpisode(item.SubItems[1].Text));
                    }
                }
            }

            UpdateBRBPlaylistRunningTime();
        }

        private void btnRemoveBRB_Click(object sender, EventArgs e)
        {
            if (lstBRBPlaylist.SelectedItems.Count != 1)
            {
                return;
            }
            int index = lstBRBPlaylist.SelectedIndices[0];

            if (lstBRBPlaylist.SelectedItems.Count == 1)
            {
                if (Program.AppState == ApplicationState.Idle)
                {
                    lstBRBPlaylist.Items.RemoveAt(index);
                }
                else if (Program.AppState == ApplicationState.PlayerActive)
                {
                    if (index >= Program.PlayerForm.NextOrCurrentBRBIndex + 1)
                    {
                        lstBRBPlaylist.Items.RemoveAt(index);
                        Program.PlayerForm.UpdateBRBPlaylist(GetCurrentPlaylist());
                    }
                }
            }

            UpdateBRBPlaylistRunningTime();
        }

        private void btnResetBRBs_Click(object sender, EventArgs e)
        {
            if (Program.AppState == ApplicationState.Idle)
            {
                lstBRBPlaylist.Items.Clear();
                UpdateBRBPlaylistRunningTime();
            }
        }

        // Called every time the playlist is updated
        private void UpdateBRBPlaylistRunningTime()
        {
            TimeSpan runningTime = new TimeSpan(0);
            foreach (ListViewItem playlistItem in lstBRBPlaylist.Items)
            {
                BRBEpisode ep = BRBManager.GetEpisode(playlistItem.Text);
                if (ep != null)
                {
                    runningTime += new TimeSpan(Config.InterBRBCountdown * TimeSpan.TicksPerSecond);
                    runningTime += ep.Duration;
                }
            }
            // The end screen is not counted here, since it happens after the last actual "playback"

            dispTotalBRBRunningTime.Text = BRBManager.TimeSpanToMMSS(runningTime);
        }

        private List<BRBEpisode> GetCurrentPlaylist()
        {
            List<BRBEpisode> playlist = new List<BRBEpisode>();
            foreach (ListViewItem playlistItem in lstBRBPlaylist.Items)
            {
                BRBEpisode ep = BRBManager.GetEpisode(playlistItem.Text);
                if (ep != null)
                {
                    playlist.Add(ep);
                }
            }
            return playlist;
        }

        private void btnStartOrAbortPlayer_Click(object sender, EventArgs e)
        {
            if (lstBRBPlaylist.Items.Count == 0)
            {
                MessageBox.Show("Please add some BRB videos to your playlist (or generate one) before you start playback.",
                                "No videos in playlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // TODO: More logic, checking playlist for bad stuff etc.
            if (Program.AppState == ApplicationState.Idle)
            {
                Program.BeginBRBPlayback(GetCurrentPlaylist());
            }
            else if (Program.AppState == ApplicationState.PlayerActive)
            {
                if (MessageBox.Show("Do you want to abort BRB playback now? You may want to make sure to switch scenes in OBS first.",
                                    "Aborting BRB playback", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Program.AbortBRBPlayback();
                }
            }
        }

        // The following two methods are called by Program
        public void OnBeginBRBPlayback()
        {
            // Disable / enable controls as is appropriate
            btnManageBRBs.Enabled = false;
            btnSettings.Enabled = false;
            numMinutes.Enabled = false;
            btnGenerate.Enabled = false;
            btnResetBRBs.Enabled = false;

            btnPlayPause.Enabled = true;
            btnReplayBRB.Enabled = true;
            btnPreviousBRB.Enabled = true;
            btnNextBRB.Enabled = true;
            trkVolume.Enabled = true;
            chkMuted.Enabled = true;
            txtVolume.Enabled = true;
            trkScrubber.Enabled = true;

            dispPlayerStatus.Visible = true;
            dispPlayingOrNextUp.Visible = true;
            lblRemainingBreakTime.Visible = true;
            dispRemainingBreakTime.Visible = true;

            // Change out BRB player button
            btnStartOrAbortPlayer.Text = "Abort BRB Playback";
            btnStartOrAbortPlayer.Image = iconAbortPlayer;
            tooltipsManager.SetToolTip(btnStartOrAbortPlayer, "Cancels the currently running break and BRB playback and closes the BRB player window");

            // Make sure "Pause" button is displayed
            btnPlayPause.Image = iconPause;

            // Activate timers
            tmrEnsureCursorVisibility.Enabled = true;
            tmrUpdateBRBPlaybackData.Enabled = true;
            tmrEnsureCursorVisibility.Start();
            tmrUpdateBRBPlaybackData.Start();
        }

        public void OnEndBRBPlayback()
        {
            // Disable / enable controls as is appropriate
            btnManageBRBs.Enabled = true;
            btnSettings.Enabled = true;
            numMinutes.Enabled = true;
            btnGenerate.Enabled = true;
            btnResetBRBs.Enabled = true;

            btnPlayPause.Enabled = false;
            btnReplayBRB.Enabled = false;
            btnPreviousBRB.Enabled = false;
            btnNextBRB.Enabled = false;
            trkVolume.Enabled = false;
            chkMuted.Enabled = false;
            txtVolume.Enabled = false;
            trkScrubber.Enabled = false;

            dispPlayerStatus.Visible = false;
            dispPlayingOrNextUp.Visible = false;
            lblRemainingBreakTime.Visible = false;
            dispRemainingBreakTime.Visible = false;

            // Change out BRB player button
            btnStartOrAbortPlayer.Text = "Start BRB Player";
            btnStartOrAbortPlayer.Image = iconStartPlayer;
            tooltipsManager.SetToolTip(btnStartOrAbortPlayer, "Opens the player window. You will be able to confirm one last time before BRBs start playing");

            // Make sure "Play" button is displayed
            btnPlayPause.Image = iconPlay;

            // Reset play controls to standards
            trkScrubber.Value = 0;
            dispRunningTime.Text = "00:00 / 00:00";

            // Stop timers
            tmrEnsureCursorVisibility.Enabled = false;
            tmrUpdateBRBPlaybackData.Enabled = false;

            // In case playback was aborted from a paused player state
            this.TopMost = false;

            // Try saving BRB playback data (again)
            if (!BRBManager.SaveEpisodes())
            {
                MessageBox.Show("Could not write to file brbepisodes.json. The playback data of your break could not be saved.\r\n\r\n" +
                                "It is recommended you investigate this problem as soon as possible, since playback data is difficult to replace if lost.",
                                "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (Program.PlayerForm.Paused)
            {
                Program.PlayerForm.UnpauseAndHideControls();
            }
            else
            {
                Program.PlayerForm.PauseAndShowControls();
            }
        }

        // The following three methods are called by the player form
        public void OnBRBPause()
        {
            // Switch out play/pause button
            btnPlayPause.Image = iconPlay;

            // Give focus to form
            if (Config.MakePlayerTopMost)
            {
                this.TopMost = true;
            }
            this.Focus();
        }

        public void OnBRBUnpause()
        {
            // Switch out play/pause button
            btnPlayPause.Image = iconPause;

            // Give up focus back to the player form
            this.TopMost = false;
            Program.PlayerForm.Focus();
        }

        public bool AppendHobbVLCEpisode()
        {
            BRBEpisode episode = BRBManager.GetRandomBRBEpisode(Config.HobbVLCIgnoreMaxDurationAfterTries == -1 || Program.PlayerForm.HobbVLCsTriggered < Config.HobbVLCIgnoreMaxDurationAfterTries ?
                                                                new TimeSpan(Config.HobbVLCMaxDuration * TimeSpan.TicksPerMinute + TimeSpan.TicksPerMinute / 2) : (TimeSpan?)null,
                                                                true, Program.PlayerForm.BRBPlaylist);
            if (episode == null)
            {
                episode = BRBManager.GetRandomBRBEpisode(Config.HobbVLCIgnoreMaxDurationAfterTries == -1 || Program.PlayerForm.HobbVLCsTriggered < Config.HobbVLCIgnoreMaxDurationAfterTries ?
                                                         new TimeSpan(Config.HobbVLCMaxDuration * TimeSpan.TicksPerMinute + TimeSpan.TicksPerMinute / 2) : (TimeSpan?)null,
                                                         false, Program.PlayerForm.BRBPlaylist);
            }
            if (episode == null)
            {
                episode = BRBManager.GetRandomBRBEpisode(Config.HobbVLCIgnoreMaxDurationAfterTries == -1 || Program.PlayerForm.HobbVLCsTriggered < Config.HobbVLCIgnoreMaxDurationAfterTries ?
                                                         new TimeSpan(Config.HobbVLCMaxDuration * TimeSpan.TicksPerMinute + TimeSpan.TicksPerMinute / 2) : (TimeSpan?)null,
                                                         false);
            }

            if (episode != null)
            {
                ListViewItem item = new ListViewItem(new string[] { episode.Filename, BRBManager.TimeSpanToMMSS(episode.Duration),
                                                                    episode.GetWeight().ToString(), "hobbVLC" });
                lstBRBPlaylist.Items.Add(item);
                UpdateBRBPlaylistRunningTime();
                Program.PlayerForm.AppendBRB(episode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void trkScrubber_Scroll(object sender, EventArgs e)
        {
            Program.PlayerForm.PauseAndShowControls();
            Program.PlayerForm.ScrubTo(trkScrubber.Value / 30.0d);
        }

        private void trkVolume_Scroll(object sender, EventArgs e)
        {
            Program.PlayerForm.SetVolume(trkVolume.Value);
            txtVolume.Text = trkVolume.Value.ToString();
        }

        private void chkMuted_CheckedChanged(object sender, EventArgs e)
        {
            Program.PlayerForm.SetMuted(chkMuted.Checked);
            chkMuted.Image = chkMuted.Checked ? iconVolumeMuted : iconVolume;
        }

        public void OnBRBPlayerStateChanged()
        {
            // Update displays

            BRBEpisode episode;

            switch (Program.PlayerForm.PlayerState)
            {
                case BRBPlayerState.BeginningOfBreak:
                case BRBPlayerState.InBetweenBRBs:
                case BRBPlayerState.HobbVLC:
                    // trkVolume.Value = Program.PlayerForm.WMPlayer.settings.volume;
                    // txtVolume.Text = Program.PlayerForm.WMPlayer.settings.volume.ToString();
                    // chkMuted.Checked = Program.PlayerForm.WMPlayer.settings.mute;

                    for (int i = 0; i < Program.PlayerForm.NextOrCurrentBRBIndex; i++)
                    {
                        lstBRBPlaylist.Items[i].ForeColor = Color.DarkGray;
                        lstBRBPlaylist.Items[i].Font = new Font(lstBRBPlaylist.Items[i].Font, FontStyle‌.Regular);
                    }
                    lstBRBPlaylist.Items[Program.PlayerForm.NextOrCurrentBRBIndex].Font = new Font(lstBRBPlaylist.Items[Program.PlayerForm.NextOrCurrentBRBIndex].Font, FontStyle‌.Bold);
                    lstBRBPlaylist.Items[Program.PlayerForm.NextOrCurrentBRBIndex].ForeColor = SystemColors.ControlText;
                    for (int i = Program.PlayerForm.NextOrCurrentBRBIndex + 1; i < lstBRBPlaylist.Items.Count; i++)
                    {
                        lstBRBPlaylist.Items[i].ForeColor = SystemColors.ControlText;
                        lstBRBPlaylist.Items[i].Font = new Font(lstBRBPlaylist.Items[i].Font, FontStyle‌.Regular);
                    }

                    episode = Program.PlayerForm.NextOrCurrentBRB;
                    dispPlayerStatus.Text = "Next up:";
                    dispPlayingOrNextUp.Text = episode.Filename;
                    durationOfCurrentBRBFormatted = BRBManager.TimeSpanToMMSS(episode.Duration);
                    dispRunningTime.Text = "00:00 / " + durationOfCurrentBRBFormatted;
                    trkScrubber.Maximum = (int)(episode.Duration.TotalSeconds * 30); // The scrubber shall be based on 1/30 seconds internally
                    trkScrubber.Value = 0;
                    trkScrubber.Enabled = false;
                    break;

                case BRBPlayerState.Playback: // Always occurs after one of the above three states, so not much is to be done
                    Program.PlayerForm.SetVolume(trkVolume.Value);
                    Program.PlayerForm.SetMuted(chkMuted.Checked);

                    dispPlayerStatus.Text = "Now playing:";
                    trkScrubber.Enabled = true;
                    break;

                case BRBPlayerState.EndOfBreak:
                    for (int i = 0; i < lstBRBPlaylist.Items.Count; i++)
                    {
                        lstBRBPlaylist.Items[i].ForeColor = Color.DarkGray;
                        lstBRBPlaylist.Items[i].Font = new Font(lstBRBPlaylist.Items[i].Font, FontStyle‌.Regular);
                    }

                    dispPlayerStatus.Text = "Finished. Waiting for user...";
                    dispPlayingOrNextUp.Text = "";
                    dispRunningTime.Text = "00:00 / 00:00";
                    trkScrubber.Value = 0;
                    trkScrubber.Enabled = false;
                    break;

                case BRBPlayerState.ErrorOccurred:
                    // Disable pretty much everything aside from "Abort BRB playback"; it is likely the occurring error requires fixing something, so continuing the playback wouldn't make sense
                    btnPlayPause.Enabled = false;
                    btnReplayBRB.Enabled = false;
                    btnPreviousBRB.Enabled = false;
                    btnNextBRB.Enabled = false;
                    trkVolume.Enabled = false;
                    chkMuted.Enabled = false;
                    txtVolume.Enabled = false;
                    trkScrubber.Enabled = false;
                    // Stop timers
                    tmrEnsureCursorVisibility.Enabled = false;
                    tmrUpdateBRBPlaybackData.Enabled = false;
                    break;
            }
        }

        private void btnReplayBRB_Click(object sender, EventArgs e)
        {
            Program.PlayerForm.ReplayCurrentBRB();
        }

        private void btnPreviousBRB_Click(object sender, EventArgs e)
        {
            Program.PlayerForm.SkipToPreviousBRB();
        }

        private void btnNextBRB_Click(object sender, EventArgs e)
        {
            Program.PlayerForm.SkipToNextBRB();
        }

        // While BRB playback is active, update all displays concerning the break or the currently playing BRB
        private void tmrUpdateBRBPlaybackData_Tick(object sender, EventArgs e)
        {
            if (Program.PlayerForm.PlayerState == BRBPlayerState.Playback)
            {
                TimeSpan playbackPosition = new TimeSpan((long)(Program.PlayerForm.VLCPlayer.Position * Program.PlayerForm.VLCPlayer.Length * TimeSpan.TicksPerMillisecond));
                dispRunningTime.Text = BRBManager.TimeSpanToMMSS(playbackPosition) + " / " + durationOfCurrentBRBFormatted;
                if (!Program.PlayerForm.Paused)
                {
                    trkScrubber.Value = Math.Min(Math.Max((int)(playbackPosition.TotalSeconds * 30), trkScrubber.Minimum), trkScrubber.Maximum);
                }
            }
            if (Program.PlayerForm.PlayerState != BRBPlayerState.ErrorOccurred)
            {
                TimeSpan remainingBreakTime = Program.PlayerForm.GetRemainingBreakTime();
                dispRemainingBreakTime.Text = BRBManager.TimeSpanToMMSS(remainingBreakTime);
                if (remainingBreakTime.TotalSeconds < 120)
                {
                    dispRemainingBreakTime.ForeColor = Color.Red;
                }
                else
                {
                    dispRemainingBreakTime.ForeColor = SystemColors.ControlText;
                }
            }
        }

        // If mouse is over the control form while playback is in progress, show the cursor. If it leaves the form, it can be hidden again.
        private void tmrEnsureCursorVisibility_Tick(object sender, EventArgs e)
        {
            if (Program.AppState == ApplicationState.PlayerActive && !Program.PlayerForm.Paused)
            {
                if (this.DesktopBounds.Contains(Cursor.Position) && !Program.PlayerForm.DesktopBounds.Contains(Cursor.Position))
                {
                    Program.ShowCursor();
                }
                else
                {
                    Program.HideCursor();
                }
            }
        }

        private void btnManageBRBs_Click(object sender, EventArgs e)
        {
            FormManageBRBs manageForm = new FormManageBRBs();
            manageForm.ShowDialog(this);

            UpdateBRBData();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormConfig configForm = new FormConfig();
            configForm.ShowDialog(this);

            UpdateConfigValues();
            UpdateBRBData();
            StartLinkReactivateTimer();
        }

        private void btnCreditsAndSupport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The current app version is " + Config.Version + ".\r\n\r\n" +
                            "App design and coding by MetagonTL, https://www.twitch.tv/metagontl . For any technical issues, questions or suggestions, MetagonTL can be reached on Twitch. " +
                            "For longer messages or emergencies, contact MetagonTL via e-mail.\r\n\r\n" +
                            "General app feedback, InterBRB screen design and graphics by KaufLive, https://www.twitch.tv/kauflive . " +
                            "MetagonTL is very grateful to Kauf for his invaluable help while boosting the app to a stream-ready state.\r\n\r\n" +
                            "Icons for the various app buttons provided by Boxicons, https://boxicons.com , under the CC-BY 4.0 licence, https://creativecommons.org/licenses/by/4.0/ .\r\n\r\n" +
                            "Made for the stream of The_Happy_Hob. MetagonTL thanks Hob himself, Megatron, LadyZoe, KaufLive, KittyPurrFace, all past and present mods and cycle mods, " +
                            "and Chat for innumerable hours of entertainment. He also especially thanks the authors of all BRB videos for creating the \"Best Part Of The Stream\", " +
                            "eventually inspiring him to develop this application.",
                            "Application Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // If control form is closed by user (unless via Task Manager etc.) while BRBs are playing, ask for confirmation before closing
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.AppState == ApplicationState.PlayerActive && e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Do you want to exit the application?\r\n\r\nThis will also cancel BRB playback and close the player. You may want to make sure to switch scenes in OBS first.",
                                    "Closing down and aborting BRB playback", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
    }
}
