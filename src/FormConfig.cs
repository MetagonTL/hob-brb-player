using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hob_BRB_Player
{
    public partial class FormConfig : Form
    {
        private bool changed = false;
        private bool changedSuspended = false;
        private bool closing = false;

        public FormConfig()
        {
            changedSuspended = true;

            InitializeComponent();

            // Fetch and fill config info

            numChapter.Value = Config.Chapter;
            if (Config.StartPlayerOnDifferentScreen)
            {
                rdoPlayerOnDifferentScreen.Checked = true;
            }
            else
            {
                rdoPlayerOnSameScreen.Checked = true;
            }
            chkMakePlayerTopMost.Checked = Config.MakePlayerTopMost;
            chkTestMode.Checked = Config.TestMode;

            numChapter.Minimum = Config.CurrentReleaseChapter;

            numPermittedOvertime.Value = Config.PermittedOvertimeMinutes;
            numPermittedUntertime.Value = Config.PermittedUndertimePercent;
            numChapterHistory.Value = Config.ChapterHistoryConsidered;
            numReplayAvoidance.Value = Config.AvoidForChaptersAfterPlay;
            trkMultiplierFavourites100.Value = (int)Math.Round(Config.FavouriteMultiplier * 100.0);
            txtFavouritesMultiplier.Text = Config.FavouriteMultiplier.ToString("0.00");
            drpSortingMode.SelectedIndex = (int)Config.SortingMode;
            numReservedChanceForPrio.Value = Config.ReservedChanceForPriorityBRBs;
            numPreferredAfter.Value = Config.PreferredPlayAfterChapters;
            numAutoGuaranteed.Value = Config.AutoGuaranteedPlaysForNewBRBs;
            numAutoPriority.Value = Config.AutoPriorityPlaysForNewBRBs;

            numStandardPlayerVolume.Value = Config.StandardPlayerVolume;
            numInterBRBCountdown.Value = Config.InterBRBCountdown;
            numTimeUntilHobbVLC.Value = Config.TimeUntilHobbVLC;
            numHobbVLCMaxDuration.Value = Config.HobbVLCMaxDuration;
            numHobbVLCCountdown.Value = Config.HobbVLCCountdown;
            numHobbVLCIgnoreDurAfterTries.Value = Config.HobbVLCIgnoreMaxDurationAfterTries;

            changedSuspended = false;
        }

        private void OnSettingChanged(object sender, EventArgs e)
        {
            if (!changedSuspended)
            {
                changed = true;
            }
        }

        private void trkMultiplierFavourites10_Scroll(object sender, EventArgs e)
        {
            txtFavouritesMultiplier.Text = (trkMultiplierFavourites100.Value / 100.0).ToString("0.00");
            OnSettingChanged(sender, e);
        }

        // Ask for confirmation to change this setting
        private void chkMakePlayerTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMakePlayerTopMost.Checked)
            {
                if (MessageBox.Show("You are about to allow other applications to be displayed in front of the player window. Please confirm you want to apply this change.",
                                    "Stream critical configuration option warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    OnSettingChanged(sender, e);
                }
                else
                {
                    chkMakePlayerTopMost.Checked = true; // Undo the change
                }
            }
            else
            {
                OnSettingChanged(sender, e);
            }
        }

        // Checks user settings for being in bounds and for consistency. If both are fulfilled, saves new config
        private bool CheckAndSaveSettings()
        {
            if (numChapter.Value < Config.CurrentReleaseChapter)
            {
                MessageBox.Show("Could not apply your new settings. Reason: You specified a chapter smaller than " + Config.CurrentReleaseChapter +
                                ", which cannot be correct since this app was released after " + Config.CurrentReleaseChapter + ".",
                                "Consistency error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numChapter.Value < Config.Chapter - 1)
            {
                if (MessageBox.Show("You entered a chapter number that is at least 2 lower than in the current config. If this is intended, make sure you have not played any BRBs " +
                                    "with the old, larger chapter number (except for Test Mode). Otherwise, the generator might stop working properly, the app might crash, " +
                                    "or other unintended consequences might arise. If you did play BRBs, you can contact MetagonTL for assistance.\r\n\r\n" +
                                    "Do you want to continue saving?",
                                    "Critical consistency warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }

            if (numReplayAvoidance.Value >= numPreferredAfter.Value)
            {
                MessageBox.Show("Could not apply your new settings. Reason: \"Preferred After\" should be strictly larger than \"Replay Avoidance\".", "Consistency error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPreferredAfter.Value > numChapterHistory.Value)
            {
                MessageBox.Show("Could not apply your new settings. Reason: \"Chapter History\" should be larger than \"Preferred After\".", "Consistency error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numChapter.Value - numChapterHistory.Value < 1412)
            {
                MessageBox.Show("Could not apply your new settings. Reason: Your settings for chapter and chapter history mean the app should consider BRB playback data from chapter " +
                                (int)(numChapter.Value - numChapterHistory.Value) + " and onwards, but this is not possible since no data exists for chapters earlier than 1412.",
                                "Consistency error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Looks good, save new config info
            Config.Chapter = (int)Math.Round(numChapter.Value);
            if (rdoPlayerOnDifferentScreen.Checked)
            {
                Config.StartPlayerOnDifferentScreen = true;
            }
            else
            {
                Config.StartPlayerOnDifferentScreen = false;
            }
            Config.MakePlayerTopMost = chkMakePlayerTopMost.Checked;
            Config.TestMode = chkTestMode.Checked;

            Config.PermittedOvertimeMinutes = (int)Math.Round(numPermittedOvertime.Value);
            Config.PermittedUndertimePercent = (int)Math.Round(numPermittedUntertime.Value);
            Config.ChapterHistoryConsidered = (int)Math.Round(numChapterHistory.Value);
            Config.AvoidForChaptersAfterPlay = (int)Math.Round(numReplayAvoidance.Value);
            Config.FavouriteMultiplier = trkMultiplierFavourites100.Value / 100.0;
            Config.SortingMode = (BRBPlaylistSortingMode)drpSortingMode.SelectedIndex;
            Config.ReservedChanceForPriorityBRBs = (int)Math.Round(numReservedChanceForPrio.Value);
            Config.PreferredPlayAfterChapters = (int)Math.Round(numPreferredAfter.Value);
            Config.AutoGuaranteedPlaysForNewBRBs = (int)Math.Round(numAutoGuaranteed.Value);
            Config.AutoPriorityPlaysForNewBRBs = (int)Math.Round(numAutoPriority.Value);

            Config.StandardPlayerVolume = (int)Math.Round(numStandardPlayerVolume.Value);
            Config.InterBRBCountdown = (int)Math.Round(numInterBRBCountdown.Value);
            Config.TimeUntilHobbVLC = (int)Math.Round(numTimeUntilHobbVLC.Value);
            Config.HobbVLCMaxDuration = (int)Math.Round(numHobbVLCMaxDuration.Value);
            Config.HobbVLCCountdown = (int)Math.Round(numHobbVLCCountdown.Value);
            Config.HobbVLCIgnoreMaxDurationAfterTries = (int)Math.Round(numHobbVLCIgnoreDurAfterTries.Value);

            if (!Config.SaveConfig())
            {
                MessageBox.Show("Could not write to file config.json. Your changes are active in the app but could not be saved to disk.\r\n\r\n" +
                                "Ensure the application has write permissions in its directory and try again.",
                                "No write access in application directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnCloseWithoutSaving_Click(object sender, EventArgs e)
        {
            // Set closing to true so the close event handler knows to just close
            closing = true;
            this.Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            // Only close if settings look good
            if (CheckAndSaveSettings())
            {
                closing = true;
                this.Close();
            }
        }

        // If the reason for closing is not one of the two Close buttons, ask user whether settings should be saved
        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !closing && changed)
            {
                if (MessageBox.Show("Would you like to save your new configuration?", "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    == DialogResult.Yes)
                {
                    // Save changes. If that doesn't work, the user needs to correct out-of-bounds settings, so keep the form open
                    if (!CheckAndSaveSettings())
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void btnShowOrUpdateDirectory_Click(object sender, EventArgs e)
        {
            FormUpdateBRBDirectory updateDirectoryForm = new FormUpdateBRBDirectory();
            updateDirectoryForm.ShowDialog(this);
        }
    }
}
