using LibVLCSharp.Shared;
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
    public partial class FormUpdateBRB : Form
    {
        BRBEpisode episodeToUpdate;

        public FormUpdateBRB(BRBEpisode episode)
        {
            InitializeComponent();

            txtOldFilename.Text = episode.Filename;
            episodeToUpdate = episode;

            List<string> availableFilenames = new List<string>();
            BRBEpisode dirEpisode;

            foreach (string path in Directory.GetFiles(Config.BRBDirectory))
            {
                // Only allow files that aren't yet in the system or at least haven't been played yet, since their data will be overwritten if they are in the system
                dirEpisode = BRBManager.GetEpisode(Path.GetFileName(path));
                if (dirEpisode == null || dirEpisode.PlaybackChapters.Count == 0)
                {
                    availableFilenames.Add(Path.GetFileName(path));
                }
            }

            drpUpdatedFilename.Items.AddRange(availableFilenames.ToArray());

            if (drpUpdatedFilename.Items.Count == 0)
            {
                drpUpdatedFilename.Items.Add("(No filenames available)");
                btnReplace.Enabled = false;
            }

            drpUpdatedFilename.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            string newFilename = (string)drpUpdatedFilename.SelectedItem;

            BRBEpisode newVersionEpisode = BRBManager.GetEpisode(newFilename);
                        
            // Old file doesn't exist anymore. Possible scenario: User has renamed or replaced a BRB file outside of the application
            if (!BRBManager.AvailableBRBEpisodes.Contains(episodeToUpdate))
            {
                if (newVersionEpisode != null)
                {
                    if (MessageBox.Show("All BRB data from the old file will be copied over to the new video version in the system. This will overwrite any existing data of the new video.\r\n\r\n" +
                                        "Since the old file cannot be found on disk anymore, it will subsequently be removed from the system.\r\n\r\n" +
                                        "Do you want to proceed?", "Please confirm BRB video update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                    BRBManager.BRBEpisodes.Remove(newVersionEpisode);
                }
                else
                {
                    if (MessageBox.Show("The video file you specified is not registered in the system yet. This will be done now and all BRB data from the old file will be copied over.\r\n\r\n" +
                                        "Since the old file cannot be found on disk anymore, it will subsequently be removed from the system.\r\n\r\n" +
                                        "Do you want to proceed?", "Please confirm BRB video update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                }

                // Copy data over and remove old BRB
                if (!BRBManager.TransferToNewFilename(episodeToUpdate, newFilename, true))
                {
                    MessageBox.Show("Could not register the new BRB file. Make sure it is a valid video file (in a format compatible with VLC) and the application has read permissions on it." +
                                    "\r\n\r\nThe updating process was aborted. If the new file was already in the system, it has been removed. No other data was changed.",
                                    "Adding new BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Old file still exists. Possible scenario: User has added a newer version of the BRB and did not remove the old version from the directory
            else
            {
                if (newVersionEpisode != null)
                {
                    if (MessageBox.Show("All BRB data from the old file will be copied over to the new video version in the system. This will overwrite any existing data of the new video.\r\n\r\n" +
                                        "Note that since the old video file is still present on disk, it will remain in the system. " +
                                        "If you do not wish this, please cancel the operation and remove it from the directory on disk first.\r\n\r\n" +
                                        "Do you want to proceed?", "Please confirm BRB video update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                    BRBManager.BRBEpisodes.Remove(newVersionEpisode);
                }
                else
                {
                    if (MessageBox.Show("The video file you specified is not registered in the system yet. This will be done now and all BRB data from the old file will be copied over.\r\n\r\n" +
                                        "Note that since the old video file is still present on disk, it will remain in the system. " +
                                        "If you do not wish this, please cancel the operation and remove it from the directory on disk first.\r\n\r\n" +
                                        "Do you want to proceed?", "Please confirm BRB video update", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                }

                // Copy data over, but do not remove old BRB
                if (!BRBManager.TransferToNewFilename(episodeToUpdate, newFilename, false))
                {
                    MessageBox.Show("Could not register the new BRB file. Make sure it is a valid video file (in a format compatible with VLC) and the application has read permissions on it." +
                                    "\r\n\r\nThe updating process was aborted. If the new file was already in the system, it has been removed. No other data was changed.",
                                    "Adding new BRB failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            BRBManager.RefreshAvailableList();

            if (!BRBManager.SaveEpisodes())
            {
                MessageBox.Show("Could not write to file brbepisodes.json. Replacing the BRB file with a new version was successful, but this could not be saved to disk.\r\n\r\n" +
                                "It is recommended you investigate this problem as soon as possible, since playback data is difficult to replace if lost.",
                                "Writing BRB data to disk failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
