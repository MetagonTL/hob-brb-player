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
    public partial class FormUpdateBRBDirectory : Form
    {
        public FormUpdateBRBDirectory()
        {
            InitializeComponent();

            txtBRBDirectory.Text = Config.BRBDirectory;
            brbDirectoryBrowser.SelectedPath = Path.GetFullPath(Config.BRBDirectory);
            chkUseWorkingDirRoot.Checked = (Config.BRBDirectory[0] == '\\');
        }

        // Basically same code as in Initial Setup

        private void btnBrowseForBRBDir_Click(object sender, EventArgs e)
        {
            brbDirectoryBrowser‌.ShowDialog();

            if (brbDirectoryBrowser.SelectedPath != "")
            {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.BRBDirectory = txtBRBDirectory.Text;
            BRBManager.RefreshAvailableList();
            MessageBox.Show("Your BRB directory has been updated. The app found " + BRBManager.AvailableBRBEpisodes.Count + " out of " + BRBManager.BRBEpisodes.Count +
                            " registered BRB episodes in the new directory.", "BRB directory updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
