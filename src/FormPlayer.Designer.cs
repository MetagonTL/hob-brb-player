namespace Hob_BRB_Player
{
    partial class FormPlayer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPlayer));
            this.tmrTenthSecond = new System.Windows.Forms.Timer(this.components);
            this.dispNextBRBMoreInfo = new System.Windows.Forms.Label();
            this.picRandomHobEmote = new System.Windows.Forms.PictureBox();
            this.btnSwitchScreen = new System.Windows.Forms.Button();
            this.btnConfirmBRBPlayback = new System.Windows.Forms.Button();
            this.pnlUIError = new System.Windows.Forms.Panel();
            this.lblWhatThisCriticalErrorMeans = new System.Windows.Forms.Label();
            this.lblCriticalMediaErrorOccurred = new System.Windows.Forms.Label();
            this.pnlPaused = new System.Windows.Forms.Panel();
            this.lblPaused = new System.Windows.Forms.Label();
            this.lblBRBManagerCredits = new System.Windows.Forms.Label();
            this.btnFinishBRBPlayback = new System.Windows.Forms.Button();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.tooltipManager = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTestMode = new System.Windows.Forms.Panel();
            this.lblScreamAtHobForTestMode = new System.Windows.Forms.Label();
            this.lblTestMode = new System.Windows.Forms.Label();
            this.tmrUpdateVolume = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateScrub = new System.Windows.Forms.Timer(this.components);
            this.dispNextBRBInfo = new System.Windows.Forms.Label();
            this.picHobbVLC = new System.Windows.Forms.PictureBox();
            this.dispBreakInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picRandomHobEmote)).BeginInit();
            this.pnlUIError.SuspendLayout();
            this.pnlPaused.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            this.pnlTestMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHobbVLC)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrTenthSecond
            // 
            this.tmrTenthSecond.Enabled = true;
            this.tmrTenthSecond.Tick += new System.EventHandler(this.tmrTenthSecond_Tick);
            // 
            // dispNextBRBMoreInfo
            // 
            this.dispNextBRBMoreInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dispNextBRBMoreInfo.AutoSize = true;
            this.dispNextBRBMoreInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispNextBRBMoreInfo.ForeColor = System.Drawing.Color.White;
            this.dispNextBRBMoreInfo.Location = new System.Drawing.Point(9, 1051);
            this.dispNextBRBMoreInfo.Name = "dispNextBRBMoreInfo";
            this.dispNextBRBMoreInfo.Size = new System.Drawing.Size(463, 18);
            this.dispNextBRBMoreInfo.TabIndex = 5;
            this.dispNextBRBMoreInfo.Text = "Filename: None.mp4  –  Authors: Kitty  –  Starting in 0";
            // 
            // picRandomHobEmote
            // 
            this.picRandomHobEmote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRandomHobEmote.Location = new System.Drawing.Point(6, 6);
            this.picRandomHobEmote.Name = "picRandomHobEmote";
            this.picRandomHobEmote.Size = new System.Drawing.Size(90, 90);
            this.picRandomHobEmote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRandomHobEmote.TabIndex = 2;
            this.picRandomHobEmote.TabStop = false;
            // 
            // btnSwitchScreen
            // 
            this.btnSwitchScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSwitchScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchScreen.Location = new System.Drawing.Point(230, 1028);
            this.btnSwitchScreen.Name = "btnSwitchScreen";
            this.btnSwitchScreen.Size = new System.Drawing.Size(40, 40);
            this.btnSwitchScreen.TabIndex = 1;
            this.tooltipManager.SetToolTip(this.btnSwitchScreen, "Move player to a different screen");
            this.btnSwitchScreen.UseVisualStyleBackColor = true;
            this.btnSwitchScreen.Click += new System.EventHandler(this.btnSwitchScreen_Click);
            // 
            // btnConfirmBRBPlayback
            // 
            this.btnConfirmBRBPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmBRBPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmBRBPlayback.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmBRBPlayback.Location = new System.Drawing.Point(12, 1028);
            this.btnConfirmBRBPlayback.Name = "btnConfirmBRBPlayback";
            this.btnConfirmBRBPlayback.Size = new System.Drawing.Size(203, 40);
            this.btnConfirmBRBPlayback.TabIndex = 0;
            this.btnConfirmBRBPlayback.Text = "Start BRB playback";
            this.btnConfirmBRBPlayback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmBRBPlayback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmBRBPlayback.UseVisualStyleBackColor = true;
            this.btnConfirmBRBPlayback.Click += new System.EventHandler(this.btnConfirmBRBPlayback_Click);
            // 
            // pnlUIError
            // 
            this.pnlUIError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUIError.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUIError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIError.Controls.Add(this.lblWhatThisCriticalErrorMeans);
            this.pnlUIError.Controls.Add(this.lblCriticalMediaErrorOccurred);
            this.pnlUIError.Location = new System.Drawing.Point(0, 530);
            this.pnlUIError.Name = "pnlUIError";
            this.pnlUIError.Size = new System.Drawing.Size(1920, 130);
            this.pnlUIError.TabIndex = 8;
            this.pnlUIError.Visible = false;
            // 
            // lblWhatThisCriticalErrorMeans
            // 
            this.lblWhatThisCriticalErrorMeans.AutoSize = true;
            this.lblWhatThisCriticalErrorMeans.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhatThisCriticalErrorMeans.Location = new System.Drawing.Point(12, 64);
            this.lblWhatThisCriticalErrorMeans.Name = "lblWhatThisCriticalErrorMeans";
            this.lblWhatThisCriticalErrorMeans.Size = new System.Drawing.Size(1072, 36);
            this.lblWhatThisCriticalErrorMeans.TabIndex = 6;
            this.lblWhatThisCriticalErrorMeans.Text = "To avoid any potential additional damage, the BRB player has been halted. Details" +
    " about the error are available for Hob to view.\r\nThis message will close once Ho" +
    "b exits the player.";
            // 
            // lblCriticalMediaErrorOccurred
            // 
            this.lblCriticalMediaErrorOccurred.AutoSize = true;
            this.lblCriticalMediaErrorOccurred.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriticalMediaErrorOccurred.ForeColor = System.Drawing.Color.Red;
            this.lblCriticalMediaErrorOccurred.Location = new System.Drawing.Point(10, 22);
            this.lblCriticalMediaErrorOccurred.Name = "lblCriticalMediaErrorOccurred";
            this.lblCriticalMediaErrorOccurred.Size = new System.Drawing.Size(757, 25);
            this.lblCriticalMediaErrorOccurred.TabIndex = 1;
            this.lblCriticalMediaErrorOccurred.Text = "Unfortunately, the media player refuses to play one of the BRB videos.";
            // 
            // pnlPaused
            // 
            this.pnlPaused.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlPaused.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlPaused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaused.Controls.Add(this.lblPaused);
            this.pnlPaused.Location = new System.Drawing.Point(797, 0);
            this.pnlPaused.Name = "pnlPaused";
            this.pnlPaused.Size = new System.Drawing.Size(326, 66);
            this.pnlPaused.TabIndex = 9;
            this.pnlPaused.Visible = false;
            // 
            // lblPaused
            // 
            this.lblPaused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaused.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaused.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPaused.Location = new System.Drawing.Point(71, 13);
            this.lblPaused.Name = "lblPaused";
            this.lblPaused.Size = new System.Drawing.Size(183, 39);
            this.lblPaused.TabIndex = 1;
            this.lblPaused.Text = "P A U S E D";
            // 
            // lblBRBManagerCredits
            // 
            this.lblBRBManagerCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCredits.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCredits.ForeColor = System.Drawing.Color.White;
            this.lblBRBManagerCredits.Location = new System.Drawing.Point(1197, 1046);
            this.lblBRBManagerCredits.Name = "lblBRBManagerCredits";
            this.lblBRBManagerCredits.Size = new System.Drawing.Size(717, 23);
            this.lblBRBManagerCredits.TabIndex = 0;
            this.lblBRBManagerCredits.Text = "App by MetagonTL (Version n/a). Design by KaufLive.";
            this.lblBRBManagerCredits.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnFinishBRBPlayback
            // 
            this.btnFinishBRBPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishBRBPlayback.Location = new System.Drawing.Point(12, 1028);
            this.btnFinishBRBPlayback.Name = "btnFinishBRBPlayback";
            this.btnFinishBRBPlayback.Size = new System.Drawing.Size(40, 40);
            this.btnFinishBRBPlayback.TabIndex = 0;
            this.btnFinishBRBPlayback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinishBRBPlayback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinishBRBPlayback.UseVisualStyleBackColor = true;
            this.btnFinishBRBPlayback.Click += new System.EventHandler(this.btnFinishBRBPlayback_Click);
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.Black;
            this.videoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(1920, 1080);
            this.videoView.TabIndex = 10;
            this.videoView.Text = "videoView1";
            this.videoView.MouseEnter += new System.EventHandler(this.videoView_MouseEnter);
            // 
            // pnlTestMode
            // 
            this.pnlTestMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlTestMode.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlTestMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTestMode.Controls.Add(this.lblScreamAtHobForTestMode);
            this.pnlTestMode.Controls.Add(this.lblTestMode);
            this.pnlTestMode.Location = new System.Drawing.Point(682, 899);
            this.pnlTestMode.Name = "pnlTestMode";
            this.pnlTestMode.Size = new System.Drawing.Size(556, 66);
            this.pnlTestMode.TabIndex = 10;
            // 
            // lblScreamAtHobForTestMode
            // 
            this.lblScreamAtHobForTestMode.AutoSize = true;
            this.lblScreamAtHobForTestMode.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreamAtHobForTestMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblScreamAtHobForTestMode.Location = new System.Drawing.Point(25, 40);
            this.lblScreamAtHobForTestMode.Name = "lblScreamAtHobForTestMode";
            this.lblScreamAtHobForTestMode.Size = new System.Drawing.Size(500, 18);
            this.lblScreamAtHobForTestMode.TabIndex = 7;
            this.lblScreamAtHobForTestMode.Text = "If you ever see this on stream, please scream at Hob to turn it off";
            // 
            // lblTestMode
            // 
            this.lblTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestMode.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestMode.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTestMode.Location = new System.Drawing.Point(143, 6);
            this.lblTestMode.Name = "lblTestMode";
            this.lblTestMode.Size = new System.Drawing.Size(267, 39);
            this.lblTestMode.TabIndex = 1;
            this.lblTestMode.Text = "T E S T   M O D E";
            // 
            // tmrUpdateVolume
            // 
            this.tmrUpdateVolume.Enabled = true;
            this.tmrUpdateVolume.Tick += new System.EventHandler(this.tmrUpdateVolume_Tick);
            // 
            // tmrUpdateScrub
            // 
            this.tmrUpdateScrub.Interval = 250;
            this.tmrUpdateScrub.Tick += new System.EventHandler(this.tmrUpdateScrub_Tick);
            // 
            // dispNextBRBInfo
            // 
            this.dispNextBRBInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dispNextBRBInfo.AutoSize = true;
            this.dispNextBRBInfo.BackColor = System.Drawing.Color.Transparent;
            this.dispNextBRBInfo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispNextBRBInfo.ForeColor = System.Drawing.Color.White;
            this.dispNextBRBInfo.Location = new System.Drawing.Point(7, 1020);
            this.dispNextBRBInfo.Name = "dispNextBRBInfo";
            this.dispNextBRBInfo.Size = new System.Drawing.Size(241, 25);
            this.dispNextBRBInfo.TabIndex = 11;
            this.dispNextBRBInfo.Text = "Next up: None.mp4";
            // 
            // picHobbVLC
            // 
            this.picHobbVLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHobbVLC.Location = new System.Drawing.Point(7, 6);
            this.picHobbVLC.Name = "picHobbVLC";
            this.picHobbVLC.Size = new System.Drawing.Size(90, 90);
            this.picHobbVLC.TabIndex = 12;
            this.picHobbVLC.TabStop = false;
            // 
            // dispBreakInfo
            // 
            this.dispBreakInfo.AutoSize = true;
            this.dispBreakInfo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispBreakInfo.ForeColor = System.Drawing.Color.White;
            this.dispBreakInfo.Location = new System.Drawing.Point(10, 996);
            this.dispBreakInfo.Name = "dispBreakInfo";
            this.dispBreakInfo.Size = new System.Drawing.Size(363, 18);
            this.dispBreakInfo.TabIndex = 13;
            this.dispBreakInfo.Text = "Warning: High meme density for 0 minutes";
            // 
            // FormPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.dispBreakInfo);
            this.Controls.Add(this.picHobbVLC);
            this.Controls.Add(this.dispNextBRBMoreInfo);
            this.Controls.Add(this.dispNextBRBInfo);
            this.Controls.Add(this.picRandomHobEmote);
            this.Controls.Add(this.btnFinishBRBPlayback);
            this.Controls.Add(this.btnSwitchScreen);
            this.Controls.Add(this.pnlTestMode);
            this.Controls.Add(this.btnConfirmBRBPlayback);
            this.Controls.Add(this.pnlPaused);
            this.Controls.Add(this.pnlUIError);
            this.Controls.Add(this.lblBRBManagerCredits);
            this.Controls.Add(this.videoView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "The_Happy_Hob BRB Media Player";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlayer_FormClosing);
            this.Shown += new System.EventHandler(this.FormPlayer_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picRandomHobEmote)).EndInit();
            this.pnlUIError.ResumeLayout(false);
            this.pnlUIError.PerformLayout();
            this.pnlPaused.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            this.pnlTestMode.ResumeLayout(false);
            this.pnlTestMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHobbVLC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrTenthSecond;
        private System.Windows.Forms.PictureBox picRandomHobEmote;
        private System.Windows.Forms.Label dispNextBRBMoreInfo;
        private System.Windows.Forms.Button btnConfirmBRBPlayback;
        private System.Windows.Forms.Panel pnlUIError;
        private System.Windows.Forms.Label lblWhatThisCriticalErrorMeans;
        private System.Windows.Forms.Label lblCriticalMediaErrorOccurred;
        private System.Windows.Forms.Panel pnlPaused;
        private System.Windows.Forms.Label lblPaused;
        private System.Windows.Forms.Label lblBRBManagerCredits;
        private System.Windows.Forms.Button btnFinishBRBPlayback;
        private LibVLCSharp.WinForms.VideoView videoView;
        private System.Windows.Forms.Button btnSwitchScreen;
        private System.Windows.Forms.ToolTip tooltipManager;
        private System.Windows.Forms.Panel pnlTestMode;
        private System.Windows.Forms.Label lblScreamAtHobForTestMode;
        private System.Windows.Forms.Label lblTestMode;
        private System.Windows.Forms.Timer tmrUpdateVolume;
        private System.Windows.Forms.Timer tmrUpdateScrub;
        private System.Windows.Forms.Label dispNextBRBInfo;
        private System.Windows.Forms.PictureBox picHobbVLC;
        private System.Windows.Forms.Label dispBreakInfo;
    }
}

