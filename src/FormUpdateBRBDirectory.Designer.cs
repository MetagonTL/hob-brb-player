namespace Hob_BRB_Player
{
    partial class FormUpdateBRBDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateBRBDirectory));
            this.chkUseWorkingDirRoot = new System.Windows.Forms.CheckBox();
            this.btnBrowseForBRBDir = new System.Windows.Forms.Button();
            this.txtBRBDirectory = new System.Windows.Forms.TextBox();
            this.lblPointToBRBDirectory = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.brbDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // chkUseWorkingDirRoot
            // 
            this.chkUseWorkingDirRoot.AutoSize = true;
            this.chkUseWorkingDirRoot.Location = new System.Drawing.Point(12, 93);
            this.chkUseWorkingDirRoot.Name = "chkUseWorkingDirRoot";
            this.chkUseWorkingDirRoot.Size = new System.Drawing.Size(214, 17);
            this.chkUseWorkingDirRoot.TabIndex = 2;
            this.chkUseWorkingDirRoot.Text = "Always use drive of application directory";
            this.chkUseWorkingDirRoot.UseVisualStyleBackColor = true;
            this.chkUseWorkingDirRoot.CheckedChanged += new System.EventHandler(this.chkUseWorkingDirRoot_CheckedChanged);
            // 
            // btnBrowseForBRBDir
            // 
            this.btnBrowseForBRBDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseForBRBDir.Location = new System.Drawing.Point(412, 58);
            this.btnBrowseForBRBDir.Name = "btnBrowseForBRBDir";
            this.btnBrowseForBRBDir.Size = new System.Drawing.Size(88, 22);
            this.btnBrowseForBRBDir.TabIndex = 1;
            this.btnBrowseForBRBDir.Text = "Browse...";
            this.btnBrowseForBRBDir.UseVisualStyleBackColor = true;
            this.btnBrowseForBRBDir.Click += new System.EventHandler(this.btnBrowseForBRBDir_Click);
            // 
            // txtBRBDirectory
            // 
            this.txtBRBDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBRBDirectory.Location = new System.Drawing.Point(12, 59);
            this.txtBRBDirectory.Name = "txtBRBDirectory";
            this.txtBRBDirectory.ReadOnly = true;
            this.txtBRBDirectory.Size = new System.Drawing.Size(394, 20);
            this.txtBRBDirectory.TabIndex = 0;
            // 
            // lblPointToBRBDirectory
            // 
            this.lblPointToBRBDirectory.AutoSize = true;
            this.lblPointToBRBDirectory.Location = new System.Drawing.Point(12, 16);
            this.lblPointToBRBDirectory.Name = "lblPointToBRBDirectory";
            this.lblPointToBRBDirectory.Size = new System.Drawing.Size(487, 26);
            this.lblPointToBRBDirectory.TabIndex = 5;
            this.lblPointToBRBDirectory.Text = "Please point the application to the directory containing your BRB videos.\r\nIf you" +
    " want to physically move your files, do this outside of the app first, then upda" +
    "te the directory here.";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(412, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(319, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormUpdateBRBDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 145);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkUseWorkingDirRoot);
            this.Controls.Add(this.btnBrowseForBRBDir);
            this.Controls.Add(this.txtBRBDirectory);
            this.Controls.Add(this.lblPointToBRBDirectory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateBRBDirectory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update BRB Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkUseWorkingDirRoot;
        private System.Windows.Forms.Button btnBrowseForBRBDir;
        private System.Windows.Forms.TextBox txtBRBDirectory;
        private System.Windows.Forms.Label lblPointToBRBDirectory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog brbDirectoryBrowser;
    }
}