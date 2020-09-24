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
    public partial class FormRenameBRB : Form
    {
        BRBEpisode episodeToRename;

        public FormRenameBRB(BRBEpisode episode)
        {
            InitializeComponent();

            txtOldFilename.Text = episode.Filename;
            episodeToRename = episode;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            foreach (BRBEpisode ep in BRBManager.BRBEpisodes)
            {
                if (ep.Filename == txtNewFilename.Text)
                {
                    MessageBox.Show("Cannot rename the BRB file to the name you chose: The new filename already exists in the BRB Manager's system.\r\n\r\n" +
                                    "If you want to proceed, you need to free up the name by renaming the respective BRB first, regardless of whether it still exists on disk or not.\r\n\r\n" +
                                    "If you have renamed the BRB file to this name outside of the application, use \"Replace with new version\" instead of \"Rename BRB file\".",
                                    "Desired new filename already in system", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (File.Exists(Path.Combine(Config.BRBDirectory, txtNewFilename.Text)))
            {
                MessageBox.Show("Cannot rename the BRB file to the name you chose: A video file of the same name already exists on disk.",
                                "Desired new filename already taken on disk", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (File.Exists(Path.Combine(Config.BRBDirectory, episodeToRename.Filename)))
            {
                if (!episodeToRename.Rename(txtNewFilename.Text, true))
                {
                    MessageBox.Show("Failed renaming the BRB file. Please check the application has write permissions in the BRB folder and no file with the desired new filename already exists.",
                                    "Unexpectedly failed renaming BRB file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Renaming successful
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("You chose to rename a BRB file that does not exist on disk. This will transport the BRB data to the new name without changing anything on disk.",
                                "Renaming file in the manager's system only", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!episodeToRename.Rename(txtNewFilename.Text, false))
                {
                    MessageBox.Show("Failed renaming the BRB file. This is a logical error in the application and should never have happened. Please contact MetagonTL if you see this error.",
                                    "Unexpectedly failed renaming BRB file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Renaming successful
                    this.Close();
                }
            }
        }
    }
}
