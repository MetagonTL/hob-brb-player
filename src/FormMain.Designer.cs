namespace Hob_BRB_Player
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnManageBRBs = new System.Windows.Forms.Button();
            this.lblGeneratePlaylist = new System.Windows.Forms.Label();
            this.lblOfApproxDuration = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblHorDiv1 = new System.Windows.Forms.Label();
            this.lblHorDiv2 = new System.Windows.Forms.Label();
            this.btnStartOrAbortPlayer = new System.Windows.Forms.Button();
            this.lblRunningTimeIncludingInterBRBs = new System.Windows.Forms.Label();
            this.dispTotalBRBRunningTime = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblManuallyBuildOrAdjustPlaylist = new System.Windows.Forms.Label();
            this.lstBRBPlaylist = new System.Windows.Forms.ListView();
            this.lstAllBRBs = new System.Windows.Forms.ListView();
            this.btnAddBRB = new System.Windows.Forms.Button();
            this.btnRemoveBRB = new System.Windows.Forms.Button();
            this.lblBRBsToPlay = new System.Windows.Forms.Label();
            this.lblAvailableBRBs = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreditsAndSupport = new System.Windows.Forms.Button();
            this.btnResetBRBs = new System.Windows.Forms.Button();
            this.lblCurrentlyOnChapter = new System.Windows.Forms.Label();
            this.lnkChapterNumber = new System.Windows.Forms.LinkLabel();
            this.tooltipsManager = new System.Windows.Forms.ToolTip(this.components);
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnReplayBRB = new System.Windows.Forms.Button();
            this.btnNextBRB = new System.Windows.Forms.Button();
            this.btnPreviousBRB = new System.Windows.Forms.Button();
            this.trkScrubber = new System.Windows.Forms.TrackBar();
            this.trkVolume = new System.Windows.Forms.TrackBar();
            this.chkMuted = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.drpSearchWhere = new System.Windows.Forms.ComboBox();
            this.lblManagerShouldSuggestPlaylist = new System.Windows.Forms.Label();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.lblVerDiv1 = new System.Windows.Forms.Label();
            this.dispPlayerStatus = new System.Windows.Forms.Label();
            this.dispPlayingOrNextUp = new System.Windows.Forms.Label();
            this.dispRunningTime = new System.Windows.Forms.Label();
            this.tmrEnsureCursorVisibility = new System.Windows.Forms.Timer(this.components);
            this.lblRemainingBreakTime = new System.Windows.Forms.Label();
            this.dispRemainingBreakTime = new System.Windows.Forms.Label();
            this.tmrUpdateBRBPlaybackData = new System.Windows.Forms.Timer(this.components);
            this.tmrAllowChapterIncrement = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScrubber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.Location = new System.Drawing.Point(180, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(125, 40);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = " Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnSettings, "Change various aspects of playlist generation and the media player, including Int" +
        "erBRBs and how to deal with hobbVLC situations");
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnManageBRBs
            // 
            this.btnManageBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBRBs.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageBRBs.Location = new System.Drawing.Point(12, 12);
            this.btnManageBRBs.Name = "btnManageBRBs";
            this.btnManageBRBs.Size = new System.Drawing.Size(162, 40);
            this.btnManageBRBs.TabIndex = 0;
            this.btnManageBRBs.Text = " Manage BRBs";
            this.btnManageBRBs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageBRBs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnManageBRBs, "Edit information of your BRB videos, mark them as \"Priority\" or \"Guaranteed Plays" +
        "\"");
            this.btnManageBRBs.UseVisualStyleBackColor = true;
            this.btnManageBRBs.Click += new System.EventHandler(this.btnManageBRBs_Click);
            // 
            // lblGeneratePlaylist
            // 
            this.lblGeneratePlaylist.AutoSize = true;
            this.lblGeneratePlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratePlaylist.Location = new System.Drawing.Point(12, 94);
            this.lblGeneratePlaylist.Name = "lblGeneratePlaylist";
            this.lblGeneratePlaylist.Size = new System.Drawing.Size(248, 16);
            this.lblGeneratePlaylist.TabIndex = 28;
            this.lblGeneratePlaylist.Text = "Let mathematics do the work here below:";
            // 
            // lblOfApproxDuration
            // 
            this.lblOfApproxDuration.AutoSize = true;
            this.lblOfApproxDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfApproxDuration.Location = new System.Drawing.Point(12, 228);
            this.lblOfApproxDuration.Name = "lblOfApproxDuration";
            this.lblOfApproxDuration.Size = new System.Drawing.Size(149, 16);
            this.lblOfApproxDuration.TabIndex = 30;
            this.lblOfApproxDuration.Text = "It should contain at least";
            this.tooltipsManager.SetToolTip(this.lblOfApproxDuration, "By default, a small overtime is permitted. Visit Settings to change");
            // 
            // numMinutes
            // 
            this.numMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinutes.Location = new System.Drawing.Point(167, 226);
            this.numMinutes.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(40, 22);
            this.numMinutes.TabIndex = 5;
            this.tooltipsManager.SetToolTip(this.numMinutes, "By default, a small overtime is permitted. Visit Settings to change");
            this.numMinutes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(213, 228);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(57, 16);
            this.lblMinutes.TabIndex = 31;
            this.lblMinutes.Text = "minutes.";
            this.tooltipsManager.SetToolTip(this.lblMinutes, "By default, a small overtime is permitted. Visit Settings to change");
            // 
            // lblHorDiv1
            // 
            this.lblHorDiv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorDiv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorDiv1.Location = new System.Drawing.Point(0, 73);
            this.lblHorDiv1.Name = "lblHorDiv1";
            this.lblHorDiv1.Size = new System.Drawing.Size(1352, 2);
            this.lblHorDiv1.TabIndex = 26;
            // 
            // lblHorDiv2
            // 
            this.lblHorDiv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHorDiv2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHorDiv2.Location = new System.Drawing.Point(0, 523);
            this.lblHorDiv2.Name = "lblHorDiv2";
            this.lblHorDiv2.Size = new System.Drawing.Size(1352, 2);
            this.lblHorDiv2.TabIndex = 39;
            // 
            // btnStartOrAbortPlayer
            // 
            this.btnStartOrAbortPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartOrAbortPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartOrAbortPlayer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOrAbortPlayer.Location = new System.Drawing.Point(305, 470);
            this.btnStartOrAbortPlayer.Name = "btnStartOrAbortPlayer";
            this.btnStartOrAbortPlayer.Size = new System.Drawing.Size(364, 40);
            this.btnStartOrAbortPlayer.TabIndex = 16;
            this.btnStartOrAbortPlayer.Text = " Start BRB Player";
            this.btnStartOrAbortPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOrAbortPlayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnStartOrAbortPlayer, "Opens the player window. You will be able to confirm one last time before BRBs st" +
        "art playing");
            this.btnStartOrAbortPlayer.UseVisualStyleBackColor = true;
            this.btnStartOrAbortPlayer.Click += new System.EventHandler(this.btnStartOrAbortPlayer_Click);
            // 
            // lblRunningTimeIncludingInterBRBs
            // 
            this.lblRunningTimeIncludingInterBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRunningTimeIncludingInterBRBs.AutoSize = true;
            this.lblRunningTimeIncludingInterBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunningTimeIncludingInterBRBs.Location = new System.Drawing.Point(308, 440);
            this.lblRunningTimeIncludingInterBRBs.Name = "lblRunningTimeIncludingInterBRBs";
            this.lblRunningTimeIncludingInterBRBs.Size = new System.Drawing.Size(207, 16);
            this.lblRunningTimeIncludingInterBRBs.TabIndex = 35;
            this.lblRunningTimeIncludingInterBRBs.Text = "Running time including InterBRBs:";
            // 
            // dispTotalBRBRunningTime
            // 
            this.dispTotalBRBRunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dispTotalBRBRunningTime.AutoSize = true;
            this.dispTotalBRBRunningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispTotalBRBRunningTime.Location = new System.Drawing.Point(521, 440);
            this.dispTotalBRBRunningTime.Name = "dispTotalBRBRunningTime";
            this.dispTotalBRBRunningTime.Size = new System.Drawing.Size(44, 16);
            this.dispTotalBRBRunningTime.TabIndex = 36;
            this.dispTotalBRBRunningTime.Text = "00:00";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Location = new System.Drawing.Point(675, 147);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(30, 30);
            this.btnMoveUp.TabIndex = 8;
            this.tooltipsManager.SetToolTip(this.btnMoveUp, "Move BRB up in playlist");
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Location = new System.Drawing.Point(675, 183);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(30, 30);
            this.btnMoveDown.TabIndex = 9;
            this.tooltipsManager.SetToolTip(this.btnMoveDown, "Move BRB down in playlist");
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(43, 269);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(200, 40);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tooltipsManager.SetToolTip(this.btnGenerate, "Suggests some BRBs, overwriting any current playlist");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblManuallyBuildOrAdjustPlaylist
            // 
            this.lblManuallyBuildOrAdjustPlaylist.AutoSize = true;
            this.lblManuallyBuildOrAdjustPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManuallyBuildOrAdjustPlaylist.Location = new System.Drawing.Point(308, 94);
            this.lblManuallyBuildOrAdjustPlaylist.Name = "lblManuallyBuildOrAdjustPlaylist";
            this.lblManuallyBuildOrAdjustPlaylist.Size = new System.Drawing.Size(410, 16);
            this.lblManuallyBuildOrAdjustPlaylist.TabIndex = 32;
            this.lblManuallyBuildOrAdjustPlaylist.Text = "Manually build or adjust the playlist by using the controls here below:";
            // 
            // lstBRBPlaylist
            // 
            this.lstBRBPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBRBPlaylist.FullRowSelect = true;
            this.lstBRBPlaylist.GridLines = true;
            this.lstBRBPlaylist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstBRBPlaylist.HideSelection = false;
            this.lstBRBPlaylist.LabelWrap = false;
            this.lstBRBPlaylist.Location = new System.Drawing.Point(305, 147);
            this.lstBRBPlaylist.MultiSelect = false;
            this.lstBRBPlaylist.Name = "lstBRBPlaylist";
            this.lstBRBPlaylist.ShowItemToolTips = true;
            this.lstBRBPlaylist.Size = new System.Drawing.Size(364, 277);
            this.lstBRBPlaylist.TabIndex = 7;
            this.lstBRBPlaylist.UseCompatibleStateImageBehavior = false;
            this.lstBRBPlaylist.View = System.Windows.Forms.View.Details;
            // 
            // lstAllBRBs
            // 
            this.lstAllBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllBRBs.FullRowSelect = true;
            this.lstAllBRBs.GridLines = true;
            this.lstAllBRBs.HideSelection = false;
            this.lstAllBRBs.LabelWrap = false;
            this.lstAllBRBs.Location = new System.Drawing.Point(730, 147);
            this.lstAllBRBs.Name = "lstAllBRBs";
            this.lstAllBRBs.ShowItemToolTips = true;
            this.lstAllBRBs.Size = new System.Drawing.Size(610, 278);
            this.lstAllBRBs.TabIndex = 15;
            this.lstAllBRBs.UseCompatibleStateImageBehavior = false;
            this.lstAllBRBs.View = System.Windows.Forms.View.Details;
            this.lstAllBRBs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstAllBRBs_ColumnClick);
            this.lstAllBRBs.DoubleClick += new System.EventHandler(this.btnAddBRB_Click);
            // 
            // btnAddBRB
            // 
            this.btnAddBRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBRB.Location = new System.Drawing.Point(675, 243);
            this.btnAddBRB.Name = "btnAddBRB";
            this.btnAddBRB.Size = new System.Drawing.Size(49, 30);
            this.btnAddBRB.TabIndex = 10;
            this.tooltipsManager.SetToolTip(this.btnAddBRB, "Add selected BRB(s) to end of playlist. Double clicking the BRB on the right has " +
        "the same effect");
            this.btnAddBRB.UseVisualStyleBackColor = true;
            this.btnAddBRB.Click += new System.EventHandler(this.btnAddBRB_Click);
            // 
            // btnRemoveBRB
            // 
            this.btnRemoveBRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBRB.Location = new System.Drawing.Point(675, 279);
            this.btnRemoveBRB.Name = "btnRemoveBRB";
            this.btnRemoveBRB.Size = new System.Drawing.Size(30, 30);
            this.btnRemoveBRB.TabIndex = 11;
            this.tooltipsManager.SetToolTip(this.btnRemoveBRB, "Remove selected BRB from playlist");
            this.btnRemoveBRB.UseVisualStyleBackColor = true;
            this.btnRemoveBRB.Click += new System.EventHandler(this.btnRemoveBRB_Click);
            // 
            // lblBRBsToPlay
            // 
            this.lblBRBsToPlay.AutoSize = true;
            this.lblBRBsToPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRBsToPlay.Location = new System.Drawing.Point(308, 123);
            this.lblBRBsToPlay.Name = "lblBRBsToPlay";
            this.lblBRBsToPlay.Size = new System.Drawing.Size(89, 16);
            this.lblBRBsToPlay.TabIndex = 33;
            this.lblBRBsToPlay.Text = "BRBs to play:";
            // 
            // lblAvailableBRBs
            // 
            this.lblAvailableBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableBRBs.AutoSize = true;
            this.lblAvailableBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBRBs.Location = new System.Drawing.Point(736, 123);
            this.lblAvailableBRBs.Name = "lblAvailableBRBs";
            this.lblAvailableBRBs.Size = new System.Drawing.Size(106, 16);
            this.lblAvailableBRBs.TabIndex = 34;
            this.lblAvailableBRBs.Text = "Available BRBs:";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(1230, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = " Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnExit, "Close the application");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreditsAndSupport
            // 
            this.btnCreditsAndSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreditsAndSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditsAndSupport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreditsAndSupport.Location = new System.Drawing.Point(1029, 12);
            this.btnCreditsAndSupport.Name = "btnCreditsAndSupport";
            this.btnCreditsAndSupport.Size = new System.Drawing.Size(195, 40);
            this.btnCreditsAndSupport.TabIndex = 3;
            this.btnCreditsAndSupport.Text = " Credits and Contact";
            this.btnCreditsAndSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreditsAndSupport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnCreditsAndSupport, "Displays information about the software and how to contact MetagonTL if you have " +
        "questions/feedback or if something goes wrong");
            this.btnCreditsAndSupport.UseVisualStyleBackColor = true;
            this.btnCreditsAndSupport.Click += new System.EventHandler(this.btnCreditsAndSupport_Click);
            // 
            // btnResetBRBs
            // 
            this.btnResetBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetBRBs.Location = new System.Drawing.Point(675, 339);
            this.btnResetBRBs.Name = "btnResetBRBs";
            this.btnResetBRBs.Size = new System.Drawing.Size(30, 30);
            this.btnResetBRBs.TabIndex = 12;
            this.tooltipsManager.SetToolTip(this.btnResetBRBs, "Reset playlist");
            this.btnResetBRBs.UseVisualStyleBackColor = true;
            this.btnResetBRBs.Click += new System.EventHandler(this.btnResetBRBs_Click);
            // 
            // lblCurrentlyOnChapter
            // 
            this.lblCurrentlyOnChapter.AutoSize = true;
            this.lblCurrentlyOnChapter.Location = new System.Drawing.Point(638, 4);
            this.lblCurrentlyOnChapter.Name = "lblCurrentlyOnChapter";
            this.lblCurrentlyOnChapter.Size = new System.Drawing.Size(102, 13);
            this.lblCurrentlyOnChapter.TabIndex = 25;
            this.lblCurrentlyOnChapter.Text = "Currently on chapter";
            // 
            // lnkChapterNumber
            // 
            this.lnkChapterNumber.ActiveLinkColor = System.Drawing.Color.Red;
            this.lnkChapterNumber.AutoSize = true;
            this.lnkChapterNumber.DisabledLinkColor = System.Drawing.Color.Black;
            this.lnkChapterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChapterNumber.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkChapterNumber.LinkColor = System.Drawing.Color.Blue;
            this.lnkChapterNumber.Location = new System.Drawing.Point(623, 18);
            this.lnkChapterNumber.Name = "lnkChapterNumber";
            this.lnkChapterNumber.Size = new System.Drawing.Size(132, 55);
            this.lnkChapterNumber.TabIndex = 2;
            this.lnkChapterNumber.TabStop = true;
            this.lnkChapterNumber.Text = "9999";
            this.tooltipsManager.SetToolTip(this.lnkChapterNumber, "Click to increment when blue. Visit Settings to manually readjust");
            this.lnkChapterNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChapterNumber_LinkClicked);
            // 
            // tooltipsManager
            // 
            this.tooltipsManager.AutoPopDelay = 30000;
            this.tooltipsManager.InitialDelay = 500;
            this.tooltipsManager.ReshowDelay = 100;
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Enabled = false;
            this.btnPlayPause.Location = new System.Drawing.Point(11, 549);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(40, 40);
            this.btnPlayPause.TabIndex = 17;
            this.tooltipsManager.SetToolTip(this.btnPlayPause, "Pause/Resume");
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnReplayBRB
            // 
            this.btnReplayBRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplayBRB.Enabled = false;
            this.btnReplayBRB.Location = new System.Drawing.Point(57, 559);
            this.btnReplayBRB.Name = "btnReplayBRB";
            this.btnReplayBRB.Size = new System.Drawing.Size(30, 30);
            this.btnReplayBRB.TabIndex = 18;
            this.tooltipsManager.SetToolTip(this.btnReplayBRB, "Play BRB again from beginning");
            this.btnReplayBRB.UseVisualStyleBackColor = true;
            this.btnReplayBRB.Click += new System.EventHandler(this.btnReplayBRB_Click);
            // 
            // btnNextBRB
            // 
            this.btnNextBRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextBRB.Enabled = false;
            this.btnNextBRB.Location = new System.Drawing.Point(129, 559);
            this.btnNextBRB.Name = "btnNextBRB";
            this.btnNextBRB.Size = new System.Drawing.Size(30, 30);
            this.btnNextBRB.TabIndex = 20;
            this.tooltipsManager.SetToolTip(this.btnNextBRB, "Skip to next BRB");
            this.btnNextBRB.UseVisualStyleBackColor = true;
            this.btnNextBRB.Click += new System.EventHandler(this.btnNextBRB_Click);
            // 
            // btnPreviousBRB
            // 
            this.btnPreviousBRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousBRB.Enabled = false;
            this.btnPreviousBRB.Location = new System.Drawing.Point(93, 559);
            this.btnPreviousBRB.Name = "btnPreviousBRB";
            this.btnPreviousBRB.Size = new System.Drawing.Size(30, 30);
            this.btnPreviousBRB.TabIndex = 19;
            this.tooltipsManager.SetToolTip(this.btnPreviousBRB, "Go back to previous BRB");
            this.btnPreviousBRB.UseVisualStyleBackColor = true;
            this.btnPreviousBRB.Click += new System.EventHandler(this.btnPreviousBRB_Click);
            // 
            // trkScrubber
            // 
            this.trkScrubber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trkScrubber.Enabled = false;
            this.trkScrubber.LargeChange = 30;
            this.trkScrubber.Location = new System.Drawing.Point(0, 613);
            this.trkScrubber.Name = "trkScrubber";
            this.trkScrubber.Size = new System.Drawing.Size(1352, 45);
            this.trkScrubber.TabIndex = 21;
            this.trkScrubber.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tooltipsManager.SetToolTip(this.trkScrubber, "Scrub bar for the currently playing BRB");
            this.trkScrubber.Scroll += new System.EventHandler(this.trkScrubber_Scroll);
            // 
            // trkVolume
            // 
            this.trkVolume.Enabled = false;
            this.trkVolume.Location = new System.Drawing.Point(1269, 523);
            this.trkVolume.Maximum = 200;
            this.trkVolume.Name = "trkVolume";
            this.trkVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trkVolume.Size = new System.Drawing.Size(45, 97);
            this.trkVolume.TabIndex = 22;
            this.trkVolume.TickFrequency = 20;
            this.tooltipsManager.SetToolTip(this.trkVolume, "Volume slider");
            this.trkVolume.Value = 50;
            this.trkVolume.Scroll += new System.EventHandler(this.trkVolume_Scroll);
            // 
            // chkMuted
            // 
            this.chkMuted.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMuted.Enabled = false;
            this.chkMuted.Location = new System.Drawing.Point(1310, 535);
            this.chkMuted.Name = "chkMuted";
            this.chkMuted.Size = new System.Drawing.Size(30, 30);
            this.chkMuted.TabIndex = 23;
            this.tooltipsManager.SetToolTip(this.chkMuted, "Mute/Unmute");
            this.chkMuted.UseVisualStyleBackColor = true;
            this.chkMuted.CheckedChanged += new System.EventHandler(this.chkMuted_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(992, 122);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(252, 20);
            this.txtSearch.TabIndex = 13;
            this.tooltipsManager.SetToolTip(this.txtSearch, "Enter some text to filter the BRBs displayed below");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // drpSearchWhere
            // 
            this.drpSearchWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpSearchWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSearchWhere.FormattingEnabled = true;
            this.drpSearchWhere.Items.AddRange(new object[] {
            "(any field)",
            "Filename",
            "Title",
            "Authors",
            "Description"});
            this.drpSearchWhere.Location = new System.Drawing.Point(1250, 121);
            this.drpSearchWhere.Name = "drpSearchWhere";
            this.drpSearchWhere.Size = new System.Drawing.Size(90, 21);
            this.drpSearchWhere.TabIndex = 14;
            this.tooltipsManager.SetToolTip(this.drpSearchWhere, "Select where the text you gave should be looked for");
            this.drpSearchWhere.SelectedIndexChanged += new System.EventHandler(this.drpSearchWhere_SelectedIndexChanged);
            // 
            // lblManagerShouldSuggestPlaylist
            // 
            this.lblManagerShouldSuggestPlaylist.AutoSize = true;
            this.lblManagerShouldSuggestPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerShouldSuggestPlaylist.Location = new System.Drawing.Point(12, 207);
            this.lblManagerShouldSuggestPlaylist.Name = "lblManagerShouldSuggestPlaylist";
            this.lblManagerShouldSuggestPlaylist.Size = new System.Drawing.Size(265, 16);
            this.lblManagerShouldSuggestPlaylist.TabIndex = 29;
            this.lblManagerShouldSuggestPlaylist.Text = "Automatically suggest a playlist for a break.";
            this.tooltipsManager.SetToolTip(this.lblManagerShouldSuggestPlaylist, "By default, a small overtime is permitted. Visit Settings to change");
            // 
            // picSearch
            // 
            this.picSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSearch.Location = new System.Drawing.Point(962, 120);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(24, 24);
            this.picSearch.TabIndex = 42;
            this.picSearch.TabStop = false;
            this.tooltipsManager.SetToolTip(this.picSearch, "Enter some text to filter the BRBs displayed below");
            // 
            // txtVolume
            // 
            this.txtVolume.Enabled = false;
            this.txtVolume.Location = new System.Drawing.Point(1310, 587);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.ReadOnly = true;
            this.txtVolume.Size = new System.Drawing.Size(30, 20);
            this.txtVolume.TabIndex = 24;
            this.txtVolume.Text = "50";
            // 
            // lblVerDiv1
            // 
            this.lblVerDiv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerDiv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVerDiv1.Location = new System.Drawing.Point(293, 75);
            this.lblVerDiv1.Name = "lblVerDiv1";
            this.lblVerDiv1.Size = new System.Drawing.Size(2, 448);
            this.lblVerDiv1.TabIndex = 27;
            // 
            // dispPlayerStatus
            // 
            this.dispPlayerStatus.AutoSize = true;
            this.dispPlayerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispPlayerStatus.Location = new System.Drawing.Point(246, 566);
            this.dispPlayerStatus.Name = "dispPlayerStatus";
            this.dispPlayerStatus.Size = new System.Drawing.Size(85, 16);
            this.dispPlayerStatus.TabIndex = 40;
            this.dispPlayerStatus.Text = "Now playing:";
            this.dispPlayerStatus.Visible = false;
            // 
            // dispPlayingOrNextUp
            // 
            this.dispPlayingOrNextUp.AutoSize = true;
            this.dispPlayingOrNextUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispPlayingOrNextUp.Location = new System.Drawing.Point(339, 566);
            this.dispPlayingOrNextUp.Name = "dispPlayingOrNextUp";
            this.dispPlayingOrNextUp.Size = new System.Drawing.Size(70, 16);
            this.dispPlayingOrNextUp.TabIndex = 41;
            this.dispPlayingOrNextUp.Text = "None.mp4";
            this.dispPlayingOrNextUp.Visible = false;
            // 
            // dispRunningTime
            // 
            this.dispRunningTime.AutoSize = true;
            this.dispRunningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispRunningTime.Location = new System.Drawing.Point(1154, 594);
            this.dispRunningTime.Name = "dispRunningTime";
            this.dispRunningTime.Size = new System.Drawing.Size(80, 16);
            this.dispRunningTime.TabIndex = 42;
            this.dispRunningTime.Text = "00:00 / 00:00";
            // 
            // tmrEnsureCursorVisibility
            // 
            this.tmrEnsureCursorVisibility.Tick += new System.EventHandler(this.tmrEnsureCursorVisibility_Tick);
            // 
            // lblRemainingBreakTime
            // 
            this.lblRemainingBreakTime.AutoSize = true;
            this.lblRemainingBreakTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingBreakTime.Location = new System.Drawing.Point(726, 479);
            this.lblRemainingBreakTime.Name = "lblRemainingBreakTime";
            this.lblRemainingBreakTime.Size = new System.Drawing.Size(167, 20);
            this.lblRemainingBreakTime.TabIndex = 37;
            this.lblRemainingBreakTime.Text = "Remaining break time:";
            this.lblRemainingBreakTime.Visible = false;
            // 
            // dispRemainingBreakTime
            // 
            this.dispRemainingBreakTime.AutoSize = true;
            this.dispRemainingBreakTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispRemainingBreakTime.Location = new System.Drawing.Point(899, 479);
            this.dispRemainingBreakTime.Name = "dispRemainingBreakTime";
            this.dispRemainingBreakTime.Size = new System.Drawing.Size(54, 20);
            this.dispRemainingBreakTime.TabIndex = 38;
            this.dispRemainingBreakTime.Text = "20:00";
            this.dispRemainingBreakTime.Visible = false;
            // 
            // tmrUpdateBRBPlaybackData
            // 
            this.tmrUpdateBRBPlaybackData.Interval = 250;
            this.tmrUpdateBRBPlaybackData.Tick += new System.EventHandler(this.tmrUpdateBRBPlaybackData_Tick);
            // 
            // tmrAllowChapterIncrement
            // 
            this.tmrAllowChapterIncrement.Interval = 1000000;
            this.tmrAllowChapterIncrement.Tick += new System.EventHandler(this.tmrAllowChapterIncrement_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 642);
            this.Controls.Add(this.drpSearchWhere);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.dispRemainingBreakTime);
            this.Controls.Add(this.lblRemainingBreakTime);
            this.Controls.Add(this.dispRunningTime);
            this.Controls.Add(this.dispPlayerStatus);
            this.Controls.Add(this.dispPlayingOrNextUp);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.chkMuted);
            this.Controls.Add(this.btnPreviousBRB);
            this.Controls.Add(this.btnNextBRB);
            this.Controls.Add(this.btnReplayBRB);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.trkScrubber);
            this.Controls.Add(this.lblVerDiv1);
            this.Controls.Add(this.lblManagerShouldSuggestPlaylist);
            this.Controls.Add(this.lnkChapterNumber);
            this.Controls.Add(this.lblCurrentlyOnChapter);
            this.Controls.Add(this.btnResetBRBs);
            this.Controls.Add(this.btnCreditsAndSupport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblAvailableBRBs);
            this.Controls.Add(this.lblBRBsToPlay);
            this.Controls.Add(this.btnRemoveBRB);
            this.Controls.Add(this.btnAddBRB);
            this.Controls.Add(this.lstAllBRBs);
            this.Controls.Add(this.lstBRBPlaylist);
            this.Controls.Add(this.lblManuallyBuildOrAdjustPlaylist);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.dispTotalBRBRunningTime);
            this.Controls.Add(this.lblRunningTimeIncludingInterBRBs);
            this.Controls.Add(this.btnStartOrAbortPlayer);
            this.Controls.Add(this.lblHorDiv2);
            this.Controls.Add(this.lblHorDiv1);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.numMinutes);
            this.Controls.Add(this.lblOfApproxDuration);
            this.Controls.Add(this.lblGeneratePlaylist);
            this.Controls.Add(this.btnManageBRBs);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.trkVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScrubber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnManageBRBs;
        private System.Windows.Forms.Label lblGeneratePlaylist;
        private System.Windows.Forms.Label lblOfApproxDuration;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHorDiv1;
        private System.Windows.Forms.Label lblHorDiv2;
        private System.Windows.Forms.Button btnStartOrAbortPlayer;
        private System.Windows.Forms.Label lblRunningTimeIncludingInterBRBs;
        private System.Windows.Forms.Label dispTotalBRBRunningTime;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblManuallyBuildOrAdjustPlaylist;
        private System.Windows.Forms.ListView lstBRBPlaylist;
        private System.Windows.Forms.ListView lstAllBRBs;
        private System.Windows.Forms.Button btnAddBRB;
        private System.Windows.Forms.Button btnRemoveBRB;
        private System.Windows.Forms.Label lblBRBsToPlay;
        private System.Windows.Forms.Label lblAvailableBRBs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreditsAndSupport;
        private System.Windows.Forms.Button btnResetBRBs;
        private System.Windows.Forms.Label lblCurrentlyOnChapter;
        private System.Windows.Forms.LinkLabel lnkChapterNumber;
        private System.Windows.Forms.ToolTip tooltipsManager;
        private System.Windows.Forms.Label lblManagerShouldSuggestPlaylist;
        private System.Windows.Forms.Label lblVerDiv1;
        private System.Windows.Forms.TrackBar trkScrubber;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnReplayBRB;
        private System.Windows.Forms.Button btnNextBRB;
        private System.Windows.Forms.Button btnPreviousBRB;
        private System.Windows.Forms.TrackBar trkVolume;
        private System.Windows.Forms.CheckBox chkMuted;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Label dispPlayerStatus;
        private System.Windows.Forms.Label dispPlayingOrNextUp;
        private System.Windows.Forms.Label dispRunningTime;
        private System.Windows.Forms.Timer tmrEnsureCursorVisibility;
        private System.Windows.Forms.Label lblRemainingBreakTime;
        private System.Windows.Forms.Label dispRemainingBreakTime;
        private System.Windows.Forms.Timer tmrUpdateBRBPlaybackData;
        private System.Windows.Forms.Timer tmrAllowChapterIncrement;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox drpSearchWhere;
    }
}