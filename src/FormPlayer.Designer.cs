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
            this.pnlUIInterBRB = new System.Windows.Forms.Panel();
            this.dispNextBRBName = new System.Windows.Forms.Label();
            this.dispCountdown = new System.Windows.Forms.Label();
            this.dispCurrentChapterNumber = new System.Windows.Forms.Label();
            this.lblRandomHobEmote = new System.Windows.Forms.Label();
            this.dispMoreInfoOnBRB = new System.Windows.Forms.Label();
            this.lblNextUp = new System.Windows.Forms.Label();
            this.picRandomHobEmote = new System.Windows.Forms.PictureBox();
            this.dispHobIsTakingABreak = new System.Windows.Forms.Label();
            this.lblBRBManagerCreditsInter = new System.Windows.Forms.Label();
            this.pnlUIPreBRB = new System.Windows.Forms.Panel();
            this.btnSwitchScreen = new System.Windows.Forms.Button();
            this.btnConfirmBRBPlayback = new System.Windows.Forms.Button();
            this.lblChecklistForHob = new System.Windows.Forms.Label();
            this.dispWelcomeToBRBBreak = new System.Windows.Forms.Label();
            this.lblBRBManagerCreditsPre = new System.Windows.Forms.Label();
            this.pnlUIError = new System.Windows.Forms.Panel();
            this.lblWhatThisCriticalErrorMeans = new System.Windows.Forms.Label();
            this.lblCriticalMediaErrorOccurred = new System.Windows.Forms.Label();
            this.lblBRBManagerCreditsError = new System.Windows.Forms.Label();
            this.pnlPaused = new System.Windows.Forms.Panel();
            this.lblPaused = new System.Windows.Forms.Label();
            this.pnlUIHobbVLC = new System.Windows.Forms.Panel();
            this.lblHobbVLCEmote = new System.Windows.Forms.Label();
            this.dispCountdownHobbVLC = new System.Windows.Forms.Label();
            this.dispCurrentChapterNumberHobbVLC = new System.Windows.Forms.Label();
            this.dispMoreInfoOnBRBHobbVLC = new System.Windows.Forms.Label();
            this.dispNextBRBNameHobbVLC = new System.Windows.Forms.Label();
            this.lblNextUpHobbVLC = new System.Windows.Forms.Label();
            this.picHobbVLC = new System.Windows.Forms.PictureBox();
            this.dispWelcomeToHobbVLC = new System.Windows.Forms.Label();
            this.lblBRBManagerCreditsHobbVLC = new System.Windows.Forms.Label();
            this.pnlUIPostBRB = new System.Windows.Forms.Panel();
            this.btnFinishBRBPlayback = new System.Windows.Forms.Button();
            this.lblChecklistForHobPostBRB = new System.Windows.Forms.Label();
            this.lblThanksForWatching = new System.Windows.Forms.Label();
            this.lblBRBManagerCreditsPost = new System.Windows.Forms.Label();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.tooltipManager = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTestMode = new System.Windows.Forms.Panel();
            this.lblScreamAtHobForTestMode = new System.Windows.Forms.Label();
            this.lblTestMode = new System.Windows.Forms.Label();
            this.tmrUpdateVolume = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateScrub = new System.Windows.Forms.Timer(this.components);
            this.pnlUIInterBRB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandomHobEmote)).BeginInit();
            this.pnlUIPreBRB.SuspendLayout();
            this.pnlUIError.SuspendLayout();
            this.pnlPaused.SuspendLayout();
            this.pnlUIHobbVLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHobbVLC)).BeginInit();
            this.pnlUIPostBRB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            this.pnlTestMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTenthSecond
            // 
            this.tmrTenthSecond.Enabled = true;
            this.tmrTenthSecond.Tick += new System.EventHandler(this.tmrTenthSecond_Tick);
            // 
            // pnlUIInterBRB
            // 
            this.pnlUIInterBRB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlUIInterBRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIInterBRB.Controls.Add(this.dispNextBRBName);
            this.pnlUIInterBRB.Controls.Add(this.dispCountdown);
            this.pnlUIInterBRB.Controls.Add(this.dispCurrentChapterNumber);
            this.pnlUIInterBRB.Controls.Add(this.lblRandomHobEmote);
            this.pnlUIInterBRB.Controls.Add(this.dispMoreInfoOnBRB);
            this.pnlUIInterBRB.Controls.Add(this.lblNextUp);
            this.pnlUIInterBRB.Controls.Add(this.picRandomHobEmote);
            this.pnlUIInterBRB.Controls.Add(this.dispHobIsTakingABreak);
            this.pnlUIInterBRB.Controls.Add(this.lblBRBManagerCreditsInter);
            this.pnlUIInterBRB.Location = new System.Drawing.Point(0, 114);
            this.pnlUIInterBRB.Name = "pnlUIInterBRB";
            this.pnlUIInterBRB.Size = new System.Drawing.Size(1920, 169);
            this.pnlUIInterBRB.TabIndex = 1;
            this.pnlUIInterBRB.Visible = false;
            // 
            // dispNextBRBName
            // 
            this.dispNextBRBName.AutoSize = true;
            this.dispNextBRBName.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispNextBRBName.Location = new System.Drawing.Point(119, 68);
            this.dispNextBRBName.Name = "dispNextBRBName";
            this.dispNextBRBName.Size = new System.Drawing.Size(121, 25);
            this.dispNextBRBName.TabIndex = 4;
            this.dispNextBRBName.Text = "None.mp4";
            // 
            // dispCountdown
            // 
            this.dispCountdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dispCountdown.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispCountdown.ForeColor = System.Drawing.Color.MediumBlue;
            this.dispCountdown.Location = new System.Drawing.Point(880, 81);
            this.dispCountdown.Name = "dispCountdown";
            this.dispCountdown.Size = new System.Drawing.Size(161, 75);
            this.dispCountdown.TabIndex = 7;
            this.dispCountdown.Text = "0";
            this.dispCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dispCurrentChapterNumber
            // 
            this.dispCurrentChapterNumber.AutoSize = true;
            this.dispCurrentChapterNumber.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispCurrentChapterNumber.Location = new System.Drawing.Point(10, 141);
            this.dispCurrentChapterNumber.Name = "dispCurrentChapterNumber";
            this.dispCurrentChapterNumber.Size = new System.Drawing.Size(578, 18);
            this.dispCurrentChapterNumber.TabIndex = 8;
            this.dispCurrentChapterNumber.Text = "The current chapter is 0000. If this is wrong, please remind Hob to update it.";
            // 
            // lblRandomHobEmote
            // 
            this.lblRandomHobEmote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRandomHobEmote.AutoSize = true;
            this.lblRandomHobEmote.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRandomHobEmote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRandomHobEmote.Location = new System.Drawing.Point(1612, 19);
            this.lblRandomHobEmote.Name = "lblRandomHobEmote";
            this.lblRandomHobEmote.Size = new System.Drawing.Size(186, 36);
            this.lblRandomHobEmote.TabIndex = 6;
            this.lblRandomHobEmote.Text = "Random Hob Emote –\r\nCommon";
            // 
            // dispMoreInfoOnBRB
            // 
            this.dispMoreInfoOnBRB.AutoSize = true;
            this.dispMoreInfoOnBRB.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispMoreInfoOnBRB.Location = new System.Drawing.Point(12, 98);
            this.dispMoreInfoOnBRB.Name = "dispMoreInfoOnBRB";
            this.dispMoreInfoOnBRB.Size = new System.Drawing.Size(327, 18);
            this.dispMoreInfoOnBRB.TabIndex = 5;
            this.dispMoreInfoOnBRB.Text = "Filename: None.mp4  –  Authors: Kitty";
            // 
            // lblNextUp
            // 
            this.lblNextUp.AutoSize = true;
            this.lblNextUp.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextUp.Location = new System.Drawing.Point(10, 68);
            this.lblNextUp.Name = "lblNextUp";
            this.lblNextUp.Size = new System.Drawing.Size(106, 25);
            this.lblNextUp.TabIndex = 3;
            this.lblNextUp.Text = "Next Up:";
            // 
            // picRandomHobEmote
            // 
            this.picRandomHobEmote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picRandomHobEmote.Location = new System.Drawing.Point(1804, 9);
            this.picRandomHobEmote.Name = "picRandomHobEmote";
            this.picRandomHobEmote.Size = new System.Drawing.Size(100, 100);
            this.picRandomHobEmote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRandomHobEmote.TabIndex = 2;
            this.picRandomHobEmote.TabStop = false;
            // 
            // dispHobIsTakingABreak
            // 
            this.dispHobIsTakingABreak.AutoSize = true;
            this.dispHobIsTakingABreak.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispHobIsTakingABreak.Location = new System.Drawing.Point(10, 18);
            this.dispHobIsTakingABreak.Name = "dispHobIsTakingABreak";
            this.dispHobIsTakingABreak.Size = new System.Drawing.Size(1088, 25);
            this.dispHobIsTakingABreak.TabIndex = 1;
            this.dispHobIsTakingABreak.Text = "Hob is taking a break. He will be back in about 0 minutes. In the meantime, pleas" +
    "e enjoy the memes.";
            // 
            // lblBRBManagerCreditsInter
            // 
            this.lblBRBManagerCreditsInter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCreditsInter.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCreditsInter.Location = new System.Drawing.Point(1193, 137);
            this.lblBRBManagerCreditsInter.Name = "lblBRBManagerCreditsInter";
            this.lblBRBManagerCreditsInter.Size = new System.Drawing.Size(720, 23);
            this.lblBRBManagerCreditsInter.TabIndex = 0;
            this.lblBRBManagerCreditsInter.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version n/a";
            this.lblBRBManagerCreditsInter.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlUIPreBRB
            // 
            this.pnlUIPreBRB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUIPreBRB.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUIPreBRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIPreBRB.Controls.Add(this.btnSwitchScreen);
            this.pnlUIPreBRB.Controls.Add(this.btnConfirmBRBPlayback);
            this.pnlUIPreBRB.Controls.Add(this.lblChecklistForHob);
            this.pnlUIPreBRB.Controls.Add(this.dispWelcomeToBRBBreak);
            this.pnlUIPreBRB.Controls.Add(this.lblBRBManagerCreditsPre);
            this.pnlUIPreBRB.Location = new System.Drawing.Point(0, 304);
            this.pnlUIPreBRB.Name = "pnlUIPreBRB";
            this.pnlUIPreBRB.Size = new System.Drawing.Size(1920, 190);
            this.pnlUIPreBRB.TabIndex = 7;
            this.pnlUIPreBRB.Visible = false;
            // 
            // btnSwitchScreen
            // 
            this.btnSwitchScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchScreen.Location = new System.Drawing.Point(1117, 133);
            this.btnSwitchScreen.Name = "btnSwitchScreen";
            this.btnSwitchScreen.Size = new System.Drawing.Size(40, 40);
            this.btnSwitchScreen.TabIndex = 1;
            this.tooltipManager.SetToolTip(this.btnSwitchScreen, "Move player to a different screen");
            this.btnSwitchScreen.UseVisualStyleBackColor = true;
            this.btnSwitchScreen.Click += new System.EventHandler(this.btnSwitchScreen_Click);
            // 
            // btnConfirmBRBPlayback
            // 
            this.btnConfirmBRBPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmBRBPlayback.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmBRBPlayback.Location = new System.Drawing.Point(827, 133);
            this.btnConfirmBRBPlayback.Name = "btnConfirmBRBPlayback";
            this.btnConfirmBRBPlayback.Size = new System.Drawing.Size(266, 40);
            this.btnConfirmBRBPlayback.TabIndex = 0;
            this.btnConfirmBRBPlayback.Text = " All done, start BRB playback";
            this.btnConfirmBRBPlayback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmBRBPlayback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmBRBPlayback.UseVisualStyleBackColor = true;
            this.btnConfirmBRBPlayback.Click += new System.EventHandler(this.btnConfirmBRBPlayback_Click);
            // 
            // lblChecklistForHob
            // 
            this.lblChecklistForHob.AutoSize = true;
            this.lblChecklistForHob.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistForHob.Location = new System.Drawing.Point(12, 58);
            this.lblChecklistForHob.Name = "lblChecklistForHob";
            this.lblChecklistForHob.Size = new System.Drawing.Size(505, 108);
            this.lblChecklistForHob.TabIndex = 6;
            this.lblChecklistForHob.Text = "Checklist for Hob:\r\n– Say Goodbye to Chat (optional)\r\n– Mute microphone\r\n– Mute g" +
    "ame sounds\r\n– Change OBS scene\r\nOnce Hob has done all that, he should click the " +
    "button on the right.";
            // 
            // dispWelcomeToBRBBreak
            // 
            this.dispWelcomeToBRBBreak.AutoSize = true;
            this.dispWelcomeToBRBBreak.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispWelcomeToBRBBreak.Location = new System.Drawing.Point(10, 17);
            this.dispWelcomeToBRBBreak.Name = "dispWelcomeToBRBBreak";
            this.dispWelcomeToBRBBreak.Size = new System.Drawing.Size(1201, 25);
            this.dispWelcomeToBRBBreak.TabIndex = 1;
            this.dispWelcomeToBRBBreak.Text = "Welcome to the best part of the stream. Hob will now take a break for about 0 min" +
    "utes and BRB videos will play.";
            // 
            // lblBRBManagerCreditsPre
            // 
            this.lblBRBManagerCreditsPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCreditsPre.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCreditsPre.Location = new System.Drawing.Point(1196, 158);
            this.lblBRBManagerCreditsPre.Name = "lblBRBManagerCreditsPre";
            this.lblBRBManagerCreditsPre.Size = new System.Drawing.Size(717, 23);
            this.lblBRBManagerCreditsPre.TabIndex = 0;
            this.lblBRBManagerCreditsPre.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version n/a";
            this.lblBRBManagerCreditsPre.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlUIError
            // 
            this.pnlUIError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUIError.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUIError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIError.Controls.Add(this.lblWhatThisCriticalErrorMeans);
            this.pnlUIError.Controls.Add(this.lblCriticalMediaErrorOccurred);
            this.pnlUIError.Controls.Add(this.lblBRBManagerCreditsError);
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
            // lblBRBManagerCreditsError
            // 
            this.lblBRBManagerCreditsError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCreditsError.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCreditsError.Location = new System.Drawing.Point(1196, 98);
            this.lblBRBManagerCreditsError.Name = "lblBRBManagerCreditsError";
            this.lblBRBManagerCreditsError.Size = new System.Drawing.Size(717, 23);
            this.lblBRBManagerCreditsError.TabIndex = 0;
            this.lblBRBManagerCreditsError.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version n/a";
            this.lblBRBManagerCreditsError.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            // pnlUIHobbVLC
            // 
            this.pnlUIHobbVLC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUIHobbVLC.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlUIHobbVLC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIHobbVLC.Controls.Add(this.lblHobbVLCEmote);
            this.pnlUIHobbVLC.Controls.Add(this.dispCountdownHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.dispCurrentChapterNumberHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.dispMoreInfoOnBRBHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.dispNextBRBNameHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.lblNextUpHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.picHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.dispWelcomeToHobbVLC);
            this.pnlUIHobbVLC.Controls.Add(this.lblBRBManagerCreditsHobbVLC);
            this.pnlUIHobbVLC.Location = new System.Drawing.Point(0, 851);
            this.pnlUIHobbVLC.Name = "pnlUIHobbVLC";
            this.pnlUIHobbVLC.Size = new System.Drawing.Size(1920, 169);
            this.pnlUIHobbVLC.TabIndex = 9;
            this.pnlUIHobbVLC.Visible = false;
            // 
            // lblHobbVLCEmote
            // 
            this.lblHobbVLCEmote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHobbVLCEmote.AutoSize = true;
            this.lblHobbVLCEmote.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHobbVLCEmote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHobbVLCEmote.Location = new System.Drawing.Point(1645, 18);
            this.lblHobbVLCEmote.Name = "lblHobbVLCEmote";
            this.lblHobbVLCEmote.Size = new System.Drawing.Size(153, 36);
            this.lblHobbVLCEmote.TabIndex = 9;
            this.lblHobbVLCEmote.Text = "hobbVLC Emote –\r\nToo Common?";
            // 
            // dispCountdownHobbVLC
            // 
            this.dispCountdownHobbVLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dispCountdownHobbVLC.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispCountdownHobbVLC.ForeColor = System.Drawing.Color.MediumBlue;
            this.dispCountdownHobbVLC.Location = new System.Drawing.Point(880, 79);
            this.dispCountdownHobbVLC.Name = "dispCountdownHobbVLC";
            this.dispCountdownHobbVLC.Size = new System.Drawing.Size(161, 75);
            this.dispCountdownHobbVLC.TabIndex = 7;
            this.dispCountdownHobbVLC.Text = "0";
            this.dispCountdownHobbVLC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dispCurrentChapterNumberHobbVLC
            // 
            this.dispCurrentChapterNumberHobbVLC.AutoSize = true;
            this.dispCurrentChapterNumberHobbVLC.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispCurrentChapterNumberHobbVLC.Location = new System.Drawing.Point(10, 141);
            this.dispCurrentChapterNumberHobbVLC.Name = "dispCurrentChapterNumberHobbVLC";
            this.dispCurrentChapterNumberHobbVLC.Size = new System.Drawing.Size(578, 18);
            this.dispCurrentChapterNumberHobbVLC.TabIndex = 8;
            this.dispCurrentChapterNumberHobbVLC.Text = "The current chapter is 0000. If this is wrong, please remind Hob to update it.";
            // 
            // dispMoreInfoOnBRBHobbVLC
            // 
            this.dispMoreInfoOnBRBHobbVLC.AutoSize = true;
            this.dispMoreInfoOnBRBHobbVLC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispMoreInfoOnBRBHobbVLC.Location = new System.Drawing.Point(12, 98);
            this.dispMoreInfoOnBRBHobbVLC.Name = "dispMoreInfoOnBRBHobbVLC";
            this.dispMoreInfoOnBRBHobbVLC.Size = new System.Drawing.Size(327, 18);
            this.dispMoreInfoOnBRBHobbVLC.TabIndex = 5;
            this.dispMoreInfoOnBRBHobbVLC.Text = "Filename: None.mp4  –  Authors: Kitty";
            // 
            // dispNextBRBNameHobbVLC
            // 
            this.dispNextBRBNameHobbVLC.AutoSize = true;
            this.dispNextBRBNameHobbVLC.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispNextBRBNameHobbVLC.Location = new System.Drawing.Point(119, 68);
            this.dispNextBRBNameHobbVLC.Name = "dispNextBRBNameHobbVLC";
            this.dispNextBRBNameHobbVLC.Size = new System.Drawing.Size(121, 25);
            this.dispNextBRBNameHobbVLC.TabIndex = 4;
            this.dispNextBRBNameHobbVLC.Text = "None.mp4";
            // 
            // lblNextUpHobbVLC
            // 
            this.lblNextUpHobbVLC.AutoSize = true;
            this.lblNextUpHobbVLC.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextUpHobbVLC.Location = new System.Drawing.Point(10, 68);
            this.lblNextUpHobbVLC.Name = "lblNextUpHobbVLC";
            this.lblNextUpHobbVLC.Size = new System.Drawing.Size(106, 25);
            this.lblNextUpHobbVLC.TabIndex = 3;
            this.lblNextUpHobbVLC.Text = "Next Up:";
            // 
            // picHobbVLC
            // 
            this.picHobbVLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHobbVLC.Location = new System.Drawing.Point(1804, 9);
            this.picHobbVLC.Name = "picHobbVLC";
            this.picHobbVLC.Size = new System.Drawing.Size(100, 100);
            this.picHobbVLC.TabIndex = 2;
            this.picHobbVLC.TabStop = false;
            // 
            // dispWelcomeToHobbVLC
            // 
            this.dispWelcomeToHobbVLC.AutoSize = true;
            this.dispWelcomeToHobbVLC.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispWelcomeToHobbVLC.Location = new System.Drawing.Point(10, 18);
            this.dispWelcomeToHobbVLC.Name = "dispWelcomeToHobbVLC";
            this.dispWelcomeToHobbVLC.Size = new System.Drawing.Size(1280, 25);
            this.dispWelcomeToHobbVLC.TabIndex = 1;
            this.dispWelcomeToHobbVLC.Text = "Maybe not – it seems we have a hobbVLC situation on our hands. Please enjoy one m" +
    "ore BRB video of about 0 minutes.";
            // 
            // lblBRBManagerCreditsHobbVLC
            // 
            this.lblBRBManagerCreditsHobbVLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCreditsHobbVLC.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCreditsHobbVLC.Location = new System.Drawing.Point(1196, 137);
            this.lblBRBManagerCreditsHobbVLC.Name = "lblBRBManagerCreditsHobbVLC";
            this.lblBRBManagerCreditsHobbVLC.Size = new System.Drawing.Size(717, 23);
            this.lblBRBManagerCreditsHobbVLC.TabIndex = 0;
            this.lblBRBManagerCreditsHobbVLC.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version n/a";
            this.lblBRBManagerCreditsHobbVLC.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlUIPostBRB
            // 
            this.pnlUIPostBRB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUIPostBRB.BackColor = System.Drawing.SystemColors.Control;
            this.pnlUIPostBRB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlUIPostBRB.Controls.Add(this.btnFinishBRBPlayback);
            this.pnlUIPostBRB.Controls.Add(this.lblChecklistForHobPostBRB);
            this.pnlUIPostBRB.Controls.Add(this.lblThanksForWatching);
            this.pnlUIPostBRB.Controls.Add(this.lblBRBManagerCreditsPost);
            this.pnlUIPostBRB.Location = new System.Drawing.Point(0, 678);
            this.pnlUIPostBRB.Name = "pnlUIPostBRB";
            this.pnlUIPostBRB.Size = new System.Drawing.Size(1920, 153);
            this.pnlUIPostBRB.TabIndex = 8;
            this.pnlUIPostBRB.Visible = false;
            // 
            // btnFinishBRBPlayback
            // 
            this.btnFinishBRBPlayback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinishBRBPlayback.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFinishBRBPlayback.Location = new System.Drawing.Point(827, 95);
            this.btnFinishBRBPlayback.Name = "btnFinishBRBPlayback";
            this.btnFinishBRBPlayback.Size = new System.Drawing.Size(266, 40);
            this.btnFinishBRBPlayback.TabIndex = 0;
            this.btnFinishBRBPlayback.Text = " Close player and save statistics";
            this.btnFinishBRBPlayback.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinishBRBPlayback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinishBRBPlayback.UseVisualStyleBackColor = true;
            this.btnFinishBRBPlayback.Click += new System.EventHandler(this.btnFinishBRBPlayback_Click);
            // 
            // lblChecklistForHobPostBRB
            // 
            this.lblChecklistForHobPostBRB.AutoSize = true;
            this.lblChecklistForHobPostBRB.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistForHobPostBRB.Location = new System.Drawing.Point(12, 58);
            this.lblChecklistForHobPostBRB.Name = "lblChecklistForHobPostBRB";
            this.lblChecklistForHobPostBRB.Size = new System.Drawing.Size(689, 72);
            this.lblChecklistForHobPostBRB.TabIndex = 6;
            this.lblChecklistForHobPostBRB.Text = "Checklist for Hob:\r\n– Unmute microphone and game sounds\r\n– Change OBS scene\r\nOnce" +
    " Hob has done that, he should click the button on the right to close the player " +
    "window.";
            // 
            // lblThanksForWatching
            // 
            this.lblThanksForWatching.AutoSize = true;
            this.lblThanksForWatching.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanksForWatching.Location = new System.Drawing.Point(10, 17);
            this.lblThanksForWatching.Name = "lblThanksForWatching";
            this.lblThanksForWatching.Size = new System.Drawing.Size(1147, 25);
            this.lblThanksForWatching.TabIndex = 1;
            this.lblThanksForWatching.Text = "This was the last BRB video of the playlist. Thank you for watching! Hob will be " +
    "back from his break shortly.";
            // 
            // lblBRBManagerCreditsPost
            // 
            this.lblBRBManagerCreditsPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBRBManagerCreditsPost.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBManagerCreditsPost.Location = new System.Drawing.Point(1199, 121);
            this.lblBRBManagerCreditsPost.Name = "lblBRBManagerCreditsPost";
            this.lblBRBManagerCreditsPost.Size = new System.Drawing.Size(714, 23);
            this.lblBRBManagerCreditsPost.TabIndex = 0;
            this.lblBRBManagerCreditsPost.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version n/a";
            this.lblBRBManagerCreditsPost.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            // FormPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnlTestMode);
            this.Controls.Add(this.pnlUIPostBRB);
            this.Controls.Add(this.pnlUIHobbVLC);
            this.Controls.Add(this.pnlPaused);
            this.Controls.Add(this.pnlUIError);
            this.Controls.Add(this.pnlUIPreBRB);
            this.Controls.Add(this.pnlUIInterBRB);
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
            this.pnlUIInterBRB.ResumeLayout(false);
            this.pnlUIInterBRB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRandomHobEmote)).EndInit();
            this.pnlUIPreBRB.ResumeLayout(false);
            this.pnlUIPreBRB.PerformLayout();
            this.pnlUIError.ResumeLayout(false);
            this.pnlUIError.PerformLayout();
            this.pnlPaused.ResumeLayout(false);
            this.pnlUIHobbVLC.ResumeLayout(false);
            this.pnlUIHobbVLC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHobbVLC)).EndInit();
            this.pnlUIPostBRB.ResumeLayout(false);
            this.pnlUIPostBRB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            this.pnlTestMode.ResumeLayout(false);
            this.pnlTestMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrTenthSecond;
        private System.Windows.Forms.Panel pnlUIInterBRB;
        private System.Windows.Forms.PictureBox picRandomHobEmote;
        private System.Windows.Forms.Label dispHobIsTakingABreak;
        private System.Windows.Forms.Label lblBRBManagerCreditsInter;
        private System.Windows.Forms.Label dispNextBRBName;
        private System.Windows.Forms.Label lblNextUp;
        private System.Windows.Forms.Label lblRandomHobEmote;
        private System.Windows.Forms.Label dispMoreInfoOnBRB;
        private System.Windows.Forms.Panel pnlUIPreBRB;
        private System.Windows.Forms.Label lblChecklistForHob;
        private System.Windows.Forms.Label dispWelcomeToBRBBreak;
        private System.Windows.Forms.Label lblBRBManagerCreditsPre;
        private System.Windows.Forms.Button btnConfirmBRBPlayback;
        private System.Windows.Forms.Panel pnlUIError;
        private System.Windows.Forms.Label lblWhatThisCriticalErrorMeans;
        private System.Windows.Forms.Label lblCriticalMediaErrorOccurred;
        private System.Windows.Forms.Label lblBRBManagerCreditsError;
        private System.Windows.Forms.Label dispCountdown;
        private System.Windows.Forms.Panel pnlPaused;
        private System.Windows.Forms.Label lblPaused;
        private System.Windows.Forms.Label dispCurrentChapterNumber;
        private System.Windows.Forms.Panel pnlUIHobbVLC;
        private System.Windows.Forms.Label lblHobbVLCEmote;
        private System.Windows.Forms.Label dispCountdownHobbVLC;
        private System.Windows.Forms.Label dispCurrentChapterNumberHobbVLC;
        private System.Windows.Forms.Label dispMoreInfoOnBRBHobbVLC;
        private System.Windows.Forms.Label dispNextBRBNameHobbVLC;
        private System.Windows.Forms.Label lblNextUpHobbVLC;
        private System.Windows.Forms.PictureBox picHobbVLC;
        private System.Windows.Forms.Label dispWelcomeToHobbVLC;
        private System.Windows.Forms.Label lblBRBManagerCreditsHobbVLC;
        private System.Windows.Forms.Panel pnlUIPostBRB;
        private System.Windows.Forms.Button btnFinishBRBPlayback;
        private System.Windows.Forms.Label lblChecklistForHobPostBRB;
        private System.Windows.Forms.Label lblThanksForWatching;
        private System.Windows.Forms.Label lblBRBManagerCreditsPost;
        private LibVLCSharp.WinForms.VideoView videoView;
        private System.Windows.Forms.Button btnSwitchScreen;
        private System.Windows.Forms.ToolTip tooltipManager;
        private System.Windows.Forms.Panel pnlTestMode;
        private System.Windows.Forms.Label lblScreamAtHobForTestMode;
        private System.Windows.Forms.Label lblTestMode;
        private System.Windows.Forms.Timer tmrUpdateVolume;
        private System.Windows.Forms.Timer tmrUpdateScrub;
    }
}

