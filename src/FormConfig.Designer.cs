namespace Hob_BRB_Player
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.tabSections = new System.Windows.Forms.TabControl();
            this.pgeGeneral = new System.Windows.Forms.TabPage();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.pnlBRBPlayerOpenBehaviour = new System.Windows.Forms.Panel();
            this.chkMakePlayerTopMost = new System.Windows.Forms.CheckBox();
            this.rdoPlayerOnDifferentScreen = new System.Windows.Forms.RadioButton();
            this.rdoPlayerOnSameScreen = new System.Windows.Forms.RadioButton();
            this.numChapter = new System.Windows.Forms.NumericUpDown();
            this.lblChapter = new System.Windows.Forms.Label();
            this.lblBRBDirectoryExpl = new System.Windows.Forms.Label();
            this.btnChangeDirectory = new System.Windows.Forms.Button();
            this.btnShowDirectory = new System.Windows.Forms.Button();
            this.lblBRBDirectory = new System.Windows.Forms.Label();
            this.pgeGenerator = new System.Windows.Forms.TabPage();
            this.drpSortingMode = new System.Windows.Forms.ComboBox();
            this.lblSortingMode = new System.Windows.Forms.Label();
            this.txtFavouritesMultiplier = new System.Windows.Forms.TextBox();
            this.trkMultiplierFavourites10 = new System.Windows.Forms.TrackBar();
            this.numReservedChanceForPrio = new System.Windows.Forms.NumericUpDown();
            this.lblReservedChanceForPrio = new System.Windows.Forms.Label();
            this.lblFavouriteMultiplier = new System.Windows.Forms.Label();
            this.numPreferredAfter = new System.Windows.Forms.NumericUpDown();
            this.lblPreferredAfterPre = new System.Windows.Forms.Label();
            this.numReplayAvoidance = new System.Windows.Forms.NumericUpDown();
            this.lblReplayAvoidancePre = new System.Windows.Forms.Label();
            this.numChapterHistory = new System.Windows.Forms.NumericUpDown();
            this.lblChapterHistoryPre = new System.Windows.Forms.Label();
            this.numPermittedUntertime = new System.Windows.Forms.NumericUpDown();
            this.lblPermittedUndertime = new System.Windows.Forms.Label();
            this.numPermittedOvertime = new System.Windows.Forms.NumericUpDown();
            this.lblPermittedOvertime = new System.Windows.Forms.Label();
            this.pgePlayback = new System.Windows.Forms.TabPage();
            this.numHobbVLCCountdown = new System.Windows.Forms.NumericUpDown();
            this.numHobbVLCMaxDuration = new System.Windows.Forms.NumericUpDown();
            this.lblHobbVLCCountdown = new System.Windows.Forms.Label();
            this.numHobbVLCIgnoreDurAfterTries = new System.Windows.Forms.NumericUpDown();
            this.lblHobbVLCIgnoreDurAfterTries = new System.Windows.Forms.Label();
            this.lblHobbVLCMaxDuration = new System.Windows.Forms.Label();
            this.numTimeUntilHobbVLC = new System.Windows.Forms.NumericUpDown();
            this.lblTimeUntilHobbVLC = new System.Windows.Forms.Label();
            this.numInterBRBCountdown = new System.Windows.Forms.NumericUpDown();
            this.lblInterBRBCountdown = new System.Windows.Forms.Label();
            this.numStandardPlayerVolume = new System.Windows.Forms.NumericUpDown();
            this.lblStandardPlayerVolume = new System.Windows.Forms.Label();
            this.tooltipsManager = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTabList = new System.Windows.Forms.Panel();
            this.btnCloseWithoutSaving = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.numAutoGuaranteed = new System.Windows.Forms.NumericUpDown();
            this.lblAutoGuaranteed = new System.Windows.Forms.Label();
            this.numAutoPriority = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSections.SuspendLayout();
            this.pgeGeneral.SuspendLayout();
            this.pnlBRBPlayerOpenBehaviour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChapter)).BeginInit();
            this.pgeGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMultiplierFavourites10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReservedChanceForPrio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreferredAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplayAvoidance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermittedUntertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermittedOvertime)).BeginInit();
            this.pgePlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCCountdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCMaxDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCIgnoreDurAfterTries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeUntilHobbVLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterBRBCountdown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStandardPlayerVolume)).BeginInit();
            this.pnlTabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoGuaranteed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSections
            // 
            this.tabSections.Controls.Add(this.pgeGeneral);
            this.tabSections.Controls.Add(this.pgeGenerator);
            this.tabSections.Controls.Add(this.pgePlayback);
            this.tabSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSections.Location = new System.Drawing.Point(0, 0);
            this.tabSections.Name = "tabSections";
            this.tabSections.SelectedIndex = 0;
            this.tabSections.Size = new System.Drawing.Size(584, 230);
            this.tabSections.TabIndex = 0;
            // 
            // pgeGeneral
            // 
            this.pgeGeneral.Controls.Add(this.chkTestMode);
            this.pgeGeneral.Controls.Add(this.pnlBRBPlayerOpenBehaviour);
            this.pgeGeneral.Controls.Add(this.numChapter);
            this.pgeGeneral.Controls.Add(this.lblChapter);
            this.pgeGeneral.Controls.Add(this.lblBRBDirectoryExpl);
            this.pgeGeneral.Controls.Add(this.btnChangeDirectory);
            this.pgeGeneral.Controls.Add(this.btnShowDirectory);
            this.pgeGeneral.Controls.Add(this.lblBRBDirectory);
            this.pgeGeneral.Location = new System.Drawing.Point(4, 22);
            this.pgeGeneral.Name = "pgeGeneral";
            this.pgeGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pgeGeneral.Size = new System.Drawing.Size(576, 204);
            this.pgeGeneral.TabIndex = 0;
            this.pgeGeneral.Text = "General";
            this.pgeGeneral.UseVisualStyleBackColor = true;
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Location = new System.Drawing.Point(9, 179);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(113, 17);
            this.chkTestMode.TabIndex = 9;
            this.chkTestMode.Text = "Enable Test Mode";
            this.tooltipsManager.SetToolTip(this.chkTestMode, "Perfect for testing the app and its BRB playback.\r\nBRBs played in Test Mode never" +
        " count towards any statistics. This setting automatically resets upon restarting" +
        " the application.");
            this.chkTestMode.UseVisualStyleBackColor = true;
            this.chkTestMode.CheckedChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // pnlBRBPlayerOpenBehaviour
            // 
            this.pnlBRBPlayerOpenBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBRBPlayerOpenBehaviour.Controls.Add(this.chkMakePlayerTopMost);
            this.pnlBRBPlayerOpenBehaviour.Controls.Add(this.rdoPlayerOnDifferentScreen);
            this.pnlBRBPlayerOpenBehaviour.Controls.Add(this.rdoPlayerOnSameScreen);
            this.pnlBRBPlayerOpenBehaviour.Location = new System.Drawing.Point(6, 115);
            this.pnlBRBPlayerOpenBehaviour.Name = "pnlBRBPlayerOpenBehaviour";
            this.pnlBRBPlayerOpenBehaviour.Size = new System.Drawing.Size(560, 58);
            this.pnlBRBPlayerOpenBehaviour.TabIndex = 8;
            // 
            // chkMakePlayerTopMost
            // 
            this.chkMakePlayerTopMost.AutoSize = true;
            this.chkMakePlayerTopMost.Location = new System.Drawing.Point(264, 4);
            this.chkMakePlayerTopMost.Name = "chkMakePlayerTopMost";
            this.chkMakePlayerTopMost.Size = new System.Drawing.Size(181, 17);
            this.chkMakePlayerTopMost.TabIndex = 10;
            this.chkMakePlayerTopMost.Text = "Make the player window topmost";
            this.tooltipsManager.SetToolTip(this.chkMakePlayerTopMost, resources.GetString("chkMakePlayerTopMost.ToolTip"));
            this.chkMakePlayerTopMost.UseVisualStyleBackColor = true;
            this.chkMakePlayerTopMost.CheckedChanged += new System.EventHandler(this.chkMakePlayerTopMost_CheckedChanged);
            // 
            // rdoPlayerOnDifferentScreen
            // 
            this.rdoPlayerOnDifferentScreen.AutoSize = true;
            this.rdoPlayerOnDifferentScreen.Location = new System.Drawing.Point(3, 26);
            this.rdoPlayerOnDifferentScreen.Name = "rdoPlayerOnDifferentScreen";
            this.rdoPlayerOnDifferentScreen.Size = new System.Drawing.Size(210, 17);
            this.rdoPlayerOnDifferentScreen.TabIndex = 9;
            this.rdoPlayerOnDifferentScreen.Text = "Try to open player on a different screen";
            this.rdoPlayerOnDifferentScreen.UseVisualStyleBackColor = true;
            this.rdoPlayerOnDifferentScreen.CheckedChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // rdoPlayerOnSameScreen
            // 
            this.rdoPlayerOnSameScreen.AutoSize = true;
            this.rdoPlayerOnSameScreen.Location = new System.Drawing.Point(3, 3);
            this.rdoPlayerOnSameScreen.Name = "rdoPlayerOnSameScreen";
            this.rdoPlayerOnSameScreen.Size = new System.Drawing.Size(194, 17);
            this.rdoPlayerOnSameScreen.TabIndex = 8;
            this.rdoPlayerOnSameScreen.Text = "Always open player on same screen";
            this.rdoPlayerOnSameScreen.UseVisualStyleBackColor = true;
            this.rdoPlayerOnSameScreen.CheckedChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // numChapter
            // 
            this.numChapter.Location = new System.Drawing.Point(129, 78);
            this.numChapter.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numChapter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapter.Name = "numChapter";
            this.numChapter.Size = new System.Drawing.Size(56, 20);
            this.numChapter.TabIndex = 5;
            this.tooltipsManager.SetToolTip(this.numChapter, "Please note that setting this lower than the current value might have unintended " +
        "consequences.");
            this.numChapter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapter.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblChapter
            // 
            this.lblChapter.AutoSize = true;
            this.lblChapter.Location = new System.Drawing.Point(6, 80);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(117, 13);
            this.lblChapter.TabIndex = 4;
            this.lblChapter.Text = "Current stream chapter:";
            // 
            // lblBRBDirectoryExpl
            // 
            this.lblBRBDirectoryExpl.AutoSize = true;
            this.lblBRBDirectoryExpl.Location = new System.Drawing.Point(6, 38);
            this.lblBRBDirectoryExpl.Name = "lblBRBDirectoryExpl";
            this.lblBRBDirectoryExpl.Size = new System.Drawing.Size(555, 13);
            this.lblBRBDirectoryExpl.TabIndex = 3;
            this.lblBRBDirectoryExpl.Text = "In order to physically move the BRB files, it is recommended to first click the a" +
    "bove button and follow the instructions.";
            // 
            // btnChangeDirectory
            // 
            this.btnChangeDirectory.Location = new System.Drawing.Point(170, 10);
            this.btnChangeDirectory.Name = "btnChangeDirectory";
            this.btnChangeDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnChangeDirectory.TabIndex = 2;
            this.btnChangeDirectory.Text = "Change";
            this.btnChangeDirectory.UseVisualStyleBackColor = true;
            this.btnChangeDirectory.Click += new System.EventHandler(this.OnSettingChanged);
            // 
            // btnShowDirectory
            // 
            this.btnShowDirectory.Location = new System.Drawing.Point(89, 10);
            this.btnShowDirectory.Name = "btnShowDirectory";
            this.btnShowDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnShowDirectory.TabIndex = 1;
            this.btnShowDirectory.Text = "Show";
            this.btnShowDirectory.UseVisualStyleBackColor = true;
            // 
            // lblBRBDirectory
            // 
            this.lblBRBDirectory.AutoSize = true;
            this.lblBRBDirectory.Location = new System.Drawing.Point(6, 15);
            this.lblBRBDirectory.Name = "lblBRBDirectory";
            this.lblBRBDirectory.Size = new System.Drawing.Size(77, 13);
            this.lblBRBDirectory.TabIndex = 0;
            this.lblBRBDirectory.Text = "BRB Directory:";
            // 
            // pgeGenerator
            // 
            this.pgeGenerator.Controls.Add(this.numAutoPriority);
            this.pgeGenerator.Controls.Add(this.label2);
            this.pgeGenerator.Controls.Add(this.numAutoGuaranteed);
            this.pgeGenerator.Controls.Add(this.lblAutoGuaranteed);
            this.pgeGenerator.Controls.Add(this.drpSortingMode);
            this.pgeGenerator.Controls.Add(this.lblSortingMode);
            this.pgeGenerator.Controls.Add(this.txtFavouritesMultiplier);
            this.pgeGenerator.Controls.Add(this.trkMultiplierFavourites10);
            this.pgeGenerator.Controls.Add(this.numReservedChanceForPrio);
            this.pgeGenerator.Controls.Add(this.lblReservedChanceForPrio);
            this.pgeGenerator.Controls.Add(this.lblFavouriteMultiplier);
            this.pgeGenerator.Controls.Add(this.numPreferredAfter);
            this.pgeGenerator.Controls.Add(this.lblPreferredAfterPre);
            this.pgeGenerator.Controls.Add(this.numReplayAvoidance);
            this.pgeGenerator.Controls.Add(this.lblReplayAvoidancePre);
            this.pgeGenerator.Controls.Add(this.numChapterHistory);
            this.pgeGenerator.Controls.Add(this.lblChapterHistoryPre);
            this.pgeGenerator.Controls.Add(this.numPermittedUntertime);
            this.pgeGenerator.Controls.Add(this.lblPermittedUndertime);
            this.pgeGenerator.Controls.Add(this.numPermittedOvertime);
            this.pgeGenerator.Controls.Add(this.lblPermittedOvertime);
            this.pgeGenerator.Location = new System.Drawing.Point(4, 22);
            this.pgeGenerator.Name = "pgeGenerator";
            this.pgeGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.pgeGenerator.Size = new System.Drawing.Size(576, 204);
            this.pgeGenerator.TabIndex = 1;
            this.pgeGenerator.Text = "Playlist Generator";
            this.pgeGenerator.UseVisualStyleBackColor = true;
            // 
            // drpSortingMode
            // 
            this.drpSortingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSortingMode.FormattingEnabled = true;
            this.drpSortingMode.Items.AddRange(new object[] {
            "Long to short",
            "Short to long",
            "Interwoven",
            "Random"});
            this.drpSortingMode.Location = new System.Drawing.Point(476, 45);
            this.drpSortingMode.Name = "drpSortingMode";
            this.drpSortingMode.Size = new System.Drawing.Size(90, 21);
            this.drpSortingMode.TabIndex = 23;
            this.tooltipsManager.SetToolTip(this.drpSortingMode, "How a playlist should be sorted after it has been generated. \"Interwoven\" means l" +
        "onger and shorter BRBs should alternate.");
            this.drpSortingMode.SelectedIndexChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblSortingMode
            // 
            this.lblSortingMode.AutoSize = true;
            this.lblSortingMode.Location = new System.Drawing.Point(288, 48);
            this.lblSortingMode.Name = "lblSortingMode";
            this.lblSortingMode.Size = new System.Drawing.Size(105, 13);
            this.lblSortingMode.TabIndex = 22;
            this.lblSortingMode.Text = "Playlist sorting mode:";
            // 
            // txtFavouritesMultiplier
            // 
            this.txtFavouritesMultiplier.Location = new System.Drawing.Point(540, 12);
            this.txtFavouritesMultiplier.Name = "txtFavouritesMultiplier";
            this.txtFavouritesMultiplier.ReadOnly = true;
            this.txtFavouritesMultiplier.Size = new System.Drawing.Size(26, 20);
            this.txtFavouritesMultiplier.TabIndex = 21;
            this.txtFavouritesMultiplier.Text = "1.0";
            this.txtFavouritesMultiplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltipsManager.SetToolTip(this.txtFavouritesMultiplier, resources.GetString("txtFavouritesMultiplier.ToolTip"));
            // 
            // trkMultiplierFavourites10
            // 
            this.trkMultiplierFavourites10.AutoSize = false;
            this.trkMultiplierFavourites10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.trkMultiplierFavourites10.Location = new System.Drawing.Point(472, 13);
            this.trkMultiplierFavourites10.Maximum = 20;
            this.trkMultiplierFavourites10.Minimum = 10;
            this.trkMultiplierFavourites10.Name = "trkMultiplierFavourites10";
            this.trkMultiplierFavourites10.Size = new System.Drawing.Size(65, 19);
            this.trkMultiplierFavourites10.TabIndex = 20;
            this.trkMultiplierFavourites10.TickFrequency = 5;
            this.tooltipsManager.SetToolTip(this.trkMultiplierFavourites10, resources.GetString("trkMultiplierFavourites10.ToolTip"));
            this.trkMultiplierFavourites10.Value = 10;
            this.trkMultiplierFavourites10.Scroll += new System.EventHandler(this.trkMultiplierFavourites10_Scroll);
            // 
            // numReservedChanceForPrio
            // 
            this.numReservedChanceForPrio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numReservedChanceForPrio.Location = new System.Drawing.Point(476, 79);
            this.numReservedChanceForPrio.Name = "numReservedChanceForPrio";
            this.numReservedChanceForPrio.Size = new System.Drawing.Size(50, 20);
            this.numReservedChanceForPrio.TabIndex = 19;
            this.tooltipsManager.SetToolTip(this.numReservedChanceForPrio, resources.GetString("numReservedChanceForPrio.ToolTip"));
            this.numReservedChanceForPrio.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblReservedChanceForPrio
            // 
            this.lblReservedChanceForPrio.AutoSize = true;
            this.lblReservedChanceForPrio.Location = new System.Drawing.Point(288, 81);
            this.lblReservedChanceForPrio.Name = "lblReservedChanceForPrio";
            this.lblReservedChanceForPrio.Size = new System.Drawing.Size(182, 13);
            this.lblReservedChanceForPrio.TabIndex = 18;
            this.lblReservedChanceForPrio.Text = "Chance for Priority BRBs (in percent):";
            // 
            // lblFavouriteMultiplier
            // 
            this.lblFavouriteMultiplier.AutoSize = true;
            this.lblFavouriteMultiplier.Location = new System.Drawing.Point(288, 15);
            this.lblFavouriteMultiplier.Name = "lblFavouriteMultiplier";
            this.lblFavouriteMultiplier.Size = new System.Drawing.Size(118, 13);
            this.lblFavouriteMultiplier.TabIndex = 16;
            this.lblFavouriteMultiplier.Text = "Multiplier for Favourites:";
            // 
            // numPreferredAfter
            // 
            this.numPreferredAfter.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPreferredAfter.Location = new System.Drawing.Point(476, 112);
            this.numPreferredAfter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPreferredAfter.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numPreferredAfter.Name = "numPreferredAfter";
            this.numPreferredAfter.Size = new System.Drawing.Size(50, 20);
            this.numPreferredAfter.TabIndex = 15;
            this.tooltipsManager.SetToolTip(this.numPreferredAfter, resources.GetString("numPreferredAfter.ToolTip"));
            this.numPreferredAfter.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numPreferredAfter.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblPreferredAfterPre
            // 
            this.lblPreferredAfterPre.AutoSize = true;
            this.lblPreferredAfterPre.Location = new System.Drawing.Point(288, 114);
            this.lblPreferredAfterPre.Name = "lblPreferredAfterPre";
            this.lblPreferredAfterPre.Size = new System.Drawing.Size(121, 13);
            this.lblPreferredAfterPre.TabIndex = 13;
            this.lblPreferredAfterPre.Text = "Preferred after chapters:";
            // 
            // numReplayAvoidance
            // 
            this.numReplayAvoidance.Location = new System.Drawing.Point(173, 112);
            this.numReplayAvoidance.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numReplayAvoidance.Name = "numReplayAvoidance";
            this.numReplayAvoidance.Size = new System.Drawing.Size(41, 20);
            this.numReplayAvoidance.TabIndex = 12;
            this.tooltipsManager.SetToolTip(this.numReplayAvoidance, resources.GetString("numReplayAvoidance.ToolTip"));
            this.numReplayAvoidance.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblReplayAvoidancePre
            // 
            this.lblReplayAvoidancePre.AutoSize = true;
            this.lblReplayAvoidancePre.Location = new System.Drawing.Point(6, 114);
            this.lblReplayAvoidancePre.Name = "lblReplayAvoidancePre";
            this.lblReplayAvoidancePre.Size = new System.Drawing.Size(156, 13);
            this.lblReplayAvoidancePre.TabIndex = 10;
            this.lblReplayAvoidancePre.Text = "Replay Avoidance for chapters:";
            // 
            // numChapterHistory
            // 
            this.numChapterHistory.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numChapterHistory.Location = new System.Drawing.Point(173, 79);
            this.numChapterHistory.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numChapterHistory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapterHistory.Name = "numChapterHistory";
            this.numChapterHistory.Size = new System.Drawing.Size(50, 20);
            this.numChapterHistory.TabIndex = 7;
            this.tooltipsManager.SetToolTip(this.numChapterHistory, "For instance, if this setting is at 200 and the current chapter is 1500, then the" +
        " generator does not care when and how often a BRB was played before chapter 1300" +
        ".");
            this.numChapterHistory.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChapterHistory.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblChapterHistoryPre
            // 
            this.lblChapterHistoryPre.AutoSize = true;
            this.lblChapterHistoryPre.Location = new System.Drawing.Point(6, 81);
            this.lblChapterHistoryPre.Name = "lblChapterHistoryPre";
            this.lblChapterHistoryPre.Size = new System.Drawing.Size(135, 13);
            this.lblChapterHistoryPre.TabIndex = 6;
            this.lblChapterHistoryPre.Text = "Chapter history considered:";
            // 
            // numPermittedUntertime
            // 
            this.numPermittedUntertime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPermittedUntertime.Location = new System.Drawing.Point(173, 46);
            this.numPermittedUntertime.Name = "numPermittedUntertime";
            this.numPermittedUntertime.Size = new System.Drawing.Size(41, 20);
            this.numPermittedUntertime.TabIndex = 3;
            this.tooltipsManager.SetToolTip(this.numPermittedUntertime, resources.GetString("numPermittedUntertime.ToolTip"));
            this.numPermittedUntertime.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblPermittedUndertime
            // 
            this.lblPermittedUndertime.AutoSize = true;
            this.lblPermittedUndertime.Location = new System.Drawing.Point(6, 48);
            this.lblPermittedUndertime.Name = "lblPermittedUndertime";
            this.lblPermittedUndertime.Size = new System.Drawing.Size(161, 13);
            this.lblPermittedUndertime.TabIndex = 2;
            this.lblPermittedUndertime.Text = "Permitted Undertime (in percent):";
            // 
            // numPermittedOvertime
            // 
            this.numPermittedOvertime.Location = new System.Drawing.Point(173, 13);
            this.numPermittedOvertime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPermittedOvertime.Name = "numPermittedOvertime";
            this.numPermittedOvertime.Size = new System.Drawing.Size(41, 20);
            this.numPermittedOvertime.TabIndex = 1;
            this.tooltipsManager.SetToolTip(this.numPermittedOvertime, resources.GetString("numPermittedOvertime.ToolTip"));
            this.numPermittedOvertime.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblPermittedOvertime
            // 
            this.lblPermittedOvertime.AutoSize = true;
            this.lblPermittedOvertime.Location = new System.Drawing.Point(6, 15);
            this.lblPermittedOvertime.Name = "lblPermittedOvertime";
            this.lblPermittedOvertime.Size = new System.Drawing.Size(155, 13);
            this.lblPermittedOvertime.TabIndex = 0;
            this.lblPermittedOvertime.Text = "Permitted Overtime (in minutes):";
            // 
            // pgePlayback
            // 
            this.pgePlayback.Controls.Add(this.numHobbVLCCountdown);
            this.pgePlayback.Controls.Add(this.numHobbVLCMaxDuration);
            this.pgePlayback.Controls.Add(this.lblHobbVLCCountdown);
            this.pgePlayback.Controls.Add(this.numHobbVLCIgnoreDurAfterTries);
            this.pgePlayback.Controls.Add(this.lblHobbVLCIgnoreDurAfterTries);
            this.pgePlayback.Controls.Add(this.lblHobbVLCMaxDuration);
            this.pgePlayback.Controls.Add(this.numTimeUntilHobbVLC);
            this.pgePlayback.Controls.Add(this.lblTimeUntilHobbVLC);
            this.pgePlayback.Controls.Add(this.numInterBRBCountdown);
            this.pgePlayback.Controls.Add(this.lblInterBRBCountdown);
            this.pgePlayback.Controls.Add(this.numStandardPlayerVolume);
            this.pgePlayback.Controls.Add(this.lblStandardPlayerVolume);
            this.pgePlayback.Location = new System.Drawing.Point(4, 22);
            this.pgePlayback.Name = "pgePlayback";
            this.pgePlayback.Padding = new System.Windows.Forms.Padding(3);
            this.pgePlayback.Size = new System.Drawing.Size(576, 204);
            this.pgePlayback.TabIndex = 2;
            this.pgePlayback.Text = "BRB Playback";
            this.pgePlayback.UseVisualStyleBackColor = true;
            // 
            // numHobbVLCCountdown
            // 
            this.numHobbVLCCountdown.Location = new System.Drawing.Point(476, 46);
            this.numHobbVLCCountdown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numHobbVLCCountdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHobbVLCCountdown.Name = "numHobbVLCCountdown";
            this.numHobbVLCCountdown.Size = new System.Drawing.Size(41, 20);
            this.numHobbVLCCountdown.TabIndex = 37;
            this.tooltipsManager.SetToolTip(this.numHobbVLCCountdown, "For how many seconds the hobbVLC screen is displayed before each hobbVLC BRB.");
            this.numHobbVLCCountdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHobbVLCCountdown.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // numHobbVLCMaxDuration
            // 
            this.numHobbVLCMaxDuration.InterceptArrowKeys = false;
            this.numHobbVLCMaxDuration.Location = new System.Drawing.Point(476, 13);
            this.numHobbVLCMaxDuration.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHobbVLCMaxDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHobbVLCMaxDuration.Name = "numHobbVLCMaxDuration";
            this.numHobbVLCMaxDuration.Size = new System.Drawing.Size(41, 20);
            this.numHobbVLCMaxDuration.TabIndex = 36;
            this.tooltipsManager.SetToolTip(this.numHobbVLCMaxDuration, "How many minutes long a hobbVLC BRB should be at most. This is precise to the min" +
        "ute: If this is set to 3, the longest possible duration will be 3:30.");
            this.numHobbVLCMaxDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHobbVLCMaxDuration.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblHobbVLCCountdown
            // 
            this.lblHobbVLCCountdown.AutoSize = true;
            this.lblHobbVLCCountdown.Location = new System.Drawing.Point(288, 48);
            this.lblHobbVLCCountdown.Name = "lblHobbVLCCountdown";
            this.lblHobbVLCCountdown.Size = new System.Drawing.Size(147, 13);
            this.lblHobbVLCCountdown.TabIndex = 35;
            this.lblHobbVLCCountdown.Text = "HobbVLC screen countdown:";
            // 
            // numHobbVLCIgnoreDurAfterTries
            // 
            this.numHobbVLCIgnoreDurAfterTries.Location = new System.Drawing.Point(476, 79);
            this.numHobbVLCIgnoreDurAfterTries.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHobbVLCIgnoreDurAfterTries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numHobbVLCIgnoreDurAfterTries.Name = "numHobbVLCIgnoreDurAfterTries";
            this.numHobbVLCIgnoreDurAfterTries.Size = new System.Drawing.Size(41, 20);
            this.numHobbVLCIgnoreDurAfterTries.TabIndex = 32;
            this.tooltipsManager.SetToolTip(this.numHobbVLCIgnoreDurAfterTries, resources.GetString("numHobbVLCIgnoreDurAfterTries.ToolTip"));
            this.numHobbVLCIgnoreDurAfterTries.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblHobbVLCIgnoreDurAfterTries
            // 
            this.lblHobbVLCIgnoreDurAfterTries.AutoSize = true;
            this.lblHobbVLCIgnoreDurAfterTries.Location = new System.Drawing.Point(288, 81);
            this.lblHobbVLCIgnoreDurAfterTries.Name = "lblHobbVLCIgnoreDurAfterTries";
            this.lblHobbVLCIgnoreDurAfterTries.Size = new System.Drawing.Size(177, 13);
            this.lblHobbVLCIgnoreDurAfterTries.TabIndex = 31;
            this.lblHobbVLCIgnoreDurAfterTries.Text = "Ignore hobbVLC minutes after times:";
            // 
            // lblHobbVLCMaxDuration
            // 
            this.lblHobbVLCMaxDuration.AutoSize = true;
            this.lblHobbVLCMaxDuration.Location = new System.Drawing.Point(288, 15);
            this.lblHobbVLCMaxDuration.Name = "lblHobbVLCMaxDuration";
            this.lblHobbVLCMaxDuration.Size = new System.Drawing.Size(176, 13);
            this.lblHobbVLCMaxDuration.TabIndex = 30;
            this.lblHobbVLCMaxDuration.Text = "Maximum minutes for one hobbVLC:";
            // 
            // numTimeUntilHobbVLC
            // 
            this.numTimeUntilHobbVLC.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTimeUntilHobbVLC.Location = new System.Drawing.Point(173, 79);
            this.numTimeUntilHobbVLC.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numTimeUntilHobbVLC.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeUntilHobbVLC.Name = "numTimeUntilHobbVLC";
            this.numTimeUntilHobbVLC.Size = new System.Drawing.Size(41, 20);
            this.numTimeUntilHobbVLC.TabIndex = 29;
            this.tooltipsManager.SetToolTip(this.numTimeUntilHobbVLC, "After the end screen has been displayed for this long, hobbVLC will automatically" +
        " activate and play a random BRB.");
            this.numTimeUntilHobbVLC.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeUntilHobbVLC.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblTimeUntilHobbVLC
            // 
            this.lblTimeUntilHobbVLC.AutoSize = true;
            this.lblTimeUntilHobbVLC.Location = new System.Drawing.Point(6, 81);
            this.lblTimeUntilHobbVLC.Name = "lblTimeUntilHobbVLC";
            this.lblTimeUntilHobbVLC.Size = new System.Drawing.Size(157, 13);
            this.lblTimeUntilHobbVLC.TabIndex = 28;
            this.lblTimeUntilHobbVLC.Text = "Trigger hobbVLC after seconds:";
            // 
            // numInterBRBCountdown
            // 
            this.numInterBRBCountdown.Location = new System.Drawing.Point(173, 46);
            this.numInterBRBCountdown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numInterBRBCountdown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterBRBCountdown.Name = "numInterBRBCountdown";
            this.numInterBRBCountdown.Size = new System.Drawing.Size(41, 20);
            this.numInterBRBCountdown.TabIndex = 27;
            this.tooltipsManager.SetToolTip(this.numInterBRBCountdown, "For how many seconds the InterBRB screen is displayed before each BRB.");
            this.numInterBRBCountdown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterBRBCountdown.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblInterBRBCountdown
            // 
            this.lblInterBRBCountdown.AutoSize = true;
            this.lblInterBRBCountdown.Location = new System.Drawing.Point(6, 48);
            this.lblInterBRBCountdown.Name = "lblInterBRBCountdown";
            this.lblInterBRBCountdown.Size = new System.Drawing.Size(144, 13);
            this.lblInterBRBCountdown.TabIndex = 26;
            this.lblInterBRBCountdown.Text = "InterBRB screen countdown:";
            // 
            // numStandardPlayerVolume
            // 
            this.numStandardPlayerVolume.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numStandardPlayerVolume.InterceptArrowKeys = false;
            this.numStandardPlayerVolume.Location = new System.Drawing.Point(173, 13);
            this.numStandardPlayerVolume.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numStandardPlayerVolume.Name = "numStandardPlayerVolume";
            this.numStandardPlayerVolume.Size = new System.Drawing.Size(50, 20);
            this.numStandardPlayerVolume.TabIndex = 25;
            this.tooltipsManager.SetToolTip(this.numStandardPlayerVolume, "Standard volume for the video player on application startup.");
            this.numStandardPlayerVolume.ValueChanged += new System.EventHandler(this.OnSettingChanged);
            // 
            // lblStandardPlayerVolume
            // 
            this.lblStandardPlayerVolume.AutoSize = true;
            this.lblStandardPlayerVolume.Location = new System.Drawing.Point(6, 15);
            this.lblStandardPlayerVolume.Name = "lblStandardPlayerVolume";
            this.lblStandardPlayerVolume.Size = new System.Drawing.Size(150, 13);
            this.lblStandardPlayerVolume.TabIndex = 24;
            this.lblStandardPlayerVolume.Text = "Standard video player volume:";
            // 
            // tooltipsManager
            // 
            this.tooltipsManager.AutoPopDelay = 30000;
            this.tooltipsManager.InitialDelay = 500;
            this.tooltipsManager.ReshowDelay = 100;
            // 
            // pnlTabList
            // 
            this.pnlTabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabList.Controls.Add(this.tabSections);
            this.pnlTabList.Location = new System.Drawing.Point(0, 0);
            this.pnlTabList.Name = "pnlTabList";
            this.pnlTabList.Size = new System.Drawing.Size(584, 230);
            this.pnlTabList.TabIndex = 1;
            // 
            // btnCloseWithoutSaving
            // 
            this.btnCloseWithoutSaving.Location = new System.Drawing.Point(307, 232);
            this.btnCloseWithoutSaving.Name = "btnCloseWithoutSaving";
            this.btnCloseWithoutSaving.Size = new System.Drawing.Size(133, 32);
            this.btnCloseWithoutSaving.TabIndex = 2;
            this.btnCloseWithoutSaving.Text = "Close without saving";
            this.btnCloseWithoutSaving.UseVisualStyleBackColor = true;
            this.btnCloseWithoutSaving.Click += new System.EventHandler(this.btnCloseWithoutSaving_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(446, 232);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(133, 32);
            this.btnSaveAndClose.TabIndex = 3;
            this.btnSaveAndClose.Text = "Save and close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // numAutoGuaranteed
            // 
            this.numAutoGuaranteed.Location = new System.Drawing.Point(173, 145);
            this.numAutoGuaranteed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAutoGuaranteed.Name = "numAutoGuaranteed";
            this.numAutoGuaranteed.Size = new System.Drawing.Size(41, 20);
            this.numAutoGuaranteed.TabIndex = 25;
            this.tooltipsManager.SetToolTip(this.numAutoGuaranteed, "When a new BRB is added to the system, it automatically receives this many Guaran" +
        "teed playbacks.");
            // 
            // lblAutoGuaranteed
            // 
            this.lblAutoGuaranteed.AutoSize = true;
            this.lblAutoGuaranteed.Location = new System.Drawing.Point(6, 147);
            this.lblAutoGuaranteed.Name = "lblAutoGuaranteed";
            this.lblAutoGuaranteed.Size = new System.Drawing.Size(161, 13);
            this.lblAutoGuaranteed.TabIndex = 24;
            this.lblAutoGuaranteed.Text = "Guaranteed plays for new BRBs:";
            // 
            // numAutoPriority
            // 
            this.numAutoPriority.Location = new System.Drawing.Point(476, 145);
            this.numAutoPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAutoPriority.Name = "numAutoPriority";
            this.numAutoPriority.Size = new System.Drawing.Size(41, 20);
            this.numAutoPriority.TabIndex = 27;
            this.tooltipsManager.SetToolTip(this.numAutoPriority, "When a new BRB is added to the system, it automatically receives this many Priori" +
        "ty playbacks.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Priority plays for new BRBs:";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 267);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCloseWithoutSaving);
            this.Controls.Add(this.pnlTabList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfig_FormClosing);
            this.tabSections.ResumeLayout(false);
            this.pgeGeneral.ResumeLayout(false);
            this.pgeGeneral.PerformLayout();
            this.pnlBRBPlayerOpenBehaviour.ResumeLayout(false);
            this.pnlBRBPlayerOpenBehaviour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChapter)).EndInit();
            this.pgeGenerator.ResumeLayout(false);
            this.pgeGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkMultiplierFavourites10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReservedChanceForPrio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPreferredAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReplayAvoidance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChapterHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermittedUntertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermittedOvertime)).EndInit();
            this.pgePlayback.ResumeLayout(false);
            this.pgePlayback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCCountdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCMaxDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHobbVLCIgnoreDurAfterTries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeUntilHobbVLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInterBRBCountdown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStandardPlayerVolume)).EndInit();
            this.pnlTabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAutoGuaranteed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSections;
        private System.Windows.Forms.TabPage pgeGeneral;
        private System.Windows.Forms.TabPage pgeGenerator;
        private System.Windows.Forms.Button btnChangeDirectory;
        private System.Windows.Forms.Button btnShowDirectory;
        private System.Windows.Forms.Label lblBRBDirectory;
        private System.Windows.Forms.TabPage pgePlayback;
        private System.Windows.Forms.Label lblBRBDirectoryExpl;
        private System.Windows.Forms.Label lblChapter;
        private System.Windows.Forms.NumericUpDown numChapter;
        private System.Windows.Forms.Panel pnlBRBPlayerOpenBehaviour;
        private System.Windows.Forms.RadioButton rdoPlayerOnDifferentScreen;
        private System.Windows.Forms.RadioButton rdoPlayerOnSameScreen;
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.NumericUpDown numPermittedUntertime;
        private System.Windows.Forms.Label lblPermittedUndertime;
        private System.Windows.Forms.NumericUpDown numPermittedOvertime;
        private System.Windows.Forms.Label lblPermittedOvertime;
        private System.Windows.Forms.NumericUpDown numChapterHistory;
        private System.Windows.Forms.Label lblChapterHistoryPre;
        private System.Windows.Forms.ToolTip tooltipsManager;
        private System.Windows.Forms.NumericUpDown numReplayAvoidance;
        private System.Windows.Forms.Label lblReplayAvoidancePre;
        private System.Windows.Forms.NumericUpDown numPreferredAfter;
        private System.Windows.Forms.Label lblPreferredAfterPre;
        private System.Windows.Forms.NumericUpDown numReservedChanceForPrio;
        private System.Windows.Forms.Label lblReservedChanceForPrio;
        private System.Windows.Forms.Label lblFavouriteMultiplier;
        private System.Windows.Forms.TrackBar trkMultiplierFavourites10;
        private System.Windows.Forms.TextBox txtFavouritesMultiplier;
        private System.Windows.Forms.Label lblSortingMode;
        private System.Windows.Forms.ComboBox drpSortingMode;
        private System.Windows.Forms.NumericUpDown numHobbVLCCountdown;
        private System.Windows.Forms.NumericUpDown numHobbVLCMaxDuration;
        private System.Windows.Forms.Label lblHobbVLCCountdown;
        private System.Windows.Forms.NumericUpDown numHobbVLCIgnoreDurAfterTries;
        private System.Windows.Forms.Label lblHobbVLCIgnoreDurAfterTries;
        private System.Windows.Forms.Label lblHobbVLCMaxDuration;
        private System.Windows.Forms.NumericUpDown numTimeUntilHobbVLC;
        private System.Windows.Forms.Label lblTimeUntilHobbVLC;
        private System.Windows.Forms.NumericUpDown numInterBRBCountdown;
        private System.Windows.Forms.Label lblInterBRBCountdown;
        private System.Windows.Forms.NumericUpDown numStandardPlayerVolume;
        private System.Windows.Forms.Label lblStandardPlayerVolume;
        private System.Windows.Forms.Panel pnlTabList;
        private System.Windows.Forms.Button btnCloseWithoutSaving;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.CheckBox chkMakePlayerTopMost;
        private System.Windows.Forms.NumericUpDown numAutoPriority;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAutoGuaranteed;
        private System.Windows.Forms.Label lblAutoGuaranteed;
    }
}