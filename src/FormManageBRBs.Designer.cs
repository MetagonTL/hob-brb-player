namespace Hob_BRB_Player
{
    partial class FormManageBRBs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageBRBs));
            this.tooltipsManager = new System.Windows.Forms.ToolTip(this.components);
            this.btnReloadBRBList = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkFavourite = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthors = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOpenBRB = new System.Windows.Forms.Button();
            this.txtPlaybackData = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.btnReplaceBRB = new System.Windows.Forms.Button();
            this.btnRenameBRB = new System.Windows.Forms.Button();
            this.numGuaranteedPlays = new System.Windows.Forms.NumericUpDown();
            this.numPriorityPlays = new System.Windows.Forms.NumericUpDown();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.drpSearchWhere = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthors = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPlaybackData = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblGuaranteedPlays = new System.Windows.Forms.Label();
            this.lblPriorityPlays = new System.Windows.Forms.Label();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.lblFilterBRBs = new System.Windows.Forms.Label();
            this.lblFilterWhere = new System.Windows.Forms.Label();
            this.lblAvailableBRBs = new System.Windows.Forms.Label();
            this.lstAllBRBs = new System.Windows.Forms.ListView();
            this.tmrResetSaveButton = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numGuaranteedPlays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriorityPlays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReloadBRBList
            // 
            this.btnReloadBRBList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadBRBList.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadBRBList.Location = new System.Drawing.Point(12, 12);
            this.btnReloadBRBList.Name = "btnReloadBRBList";
            this.btnReloadBRBList.Size = new System.Drawing.Size(173, 40);
            this.btnReloadBRBList.TabIndex = 0;
            this.btnReloadBRBList.Text = " Reload BRB List";
            this.btnReloadBRBList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReloadBRBList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnReloadBRBList, "Reloads the episode list from disk and shows prompts for any changes. Is performe" +
        "d automatically on application start");
            this.btnReloadBRBList.UseVisualStyleBackColor = true;
            this.btnReloadBRBList.Click += new System.EventHandler(this.btnReloadBRBList_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(754, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = " Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tooltipsManager.SetToolTip(this.btnSave, "Manually save any changes to BRB data (they will also be saved upon closing this " +
        "window)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkFavourite
            // 
            this.chkFavourite.AutoSize = true;
            this.chkFavourite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFavourite.Location = new System.Drawing.Point(355, 142);
            this.chkFavourite.Name = "chkFavourite";
            this.chkFavourite.Size = new System.Drawing.Size(102, 20);
            this.chkFavourite.TabIndex = 4;
            this.chkFavourite.Text = "Favourite (★)";
            this.tooltipsManager.SetToolTip(this.chkFavourite, "BRBs marked Favourite will be displayed with a star in the main window. By defaul" +
        "t, they will also be selected more often in random playlists.");
            this.chkFavourite.UseVisualStyleBackColor = true;
            this.chkFavourite.CheckedChanged += new System.EventHandler(this.chkFavourite_CheckedChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(426, 177);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(438, 22);
            this.txtTitle.TabIndex = 6;
            this.tooltipsManager.SetToolTip(this.txtTitle, "This title will be shown to viewers during the InterBRB screen. If empty, the fil" +
        "ename is displayed instead.");
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtAuthors
            // 
            this.txtAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthors.Location = new System.Drawing.Point(426, 213);
            this.txtAuthors.MaxLength = 50;
            this.txtAuthors.Name = "txtAuthors";
            this.txtAuthors.Size = new System.Drawing.Size(438, 22);
            this.txtAuthors.TabIndex = 7;
            this.tooltipsManager.SetToolTip(this.txtAuthors, "If the authors of the BRB are entered here, they will be displayed to viewers dur" +
        "ing the InterBRB screen.");
            this.txtAuthors.TextChanged += new System.EventHandler(this.txtAuthors_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(355, 268);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(509, 149);
            this.txtDescription.TabIndex = 8;
            this.tooltipsManager.SetToolTip(this.txtDescription, "A description for the BRB where any additional information can be entered. This w" +
        "ill not be displayed in the BRB player.");
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // btnOpenBRB
            // 
            this.btnOpenBRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenBRB.Location = new System.Drawing.Point(355, 96);
            this.btnOpenBRB.Name = "btnOpenBRB";
            this.btnOpenBRB.Size = new System.Drawing.Size(219, 30);
            this.btnOpenBRB.TabIndex = 3;
            this.btnOpenBRB.Text = "Open with standard program";
            this.tooltipsManager.SetToolTip(this.btnOpenBRB, "Opens the selected video file with the standard program as set in Windows");
            this.btnOpenBRB.UseVisualStyleBackColor = true;
            this.btnOpenBRB.Click += new System.EventHandler(this.btnOpenBRB_Click);
            // 
            // txtPlaybackData
            // 
            this.txtPlaybackData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaybackData.Location = new System.Drawing.Point(355, 497);
            this.txtPlaybackData.Multiline = true;
            this.txtPlaybackData.Name = "txtPlaybackData";
            this.txtPlaybackData.ReadOnly = true;
            this.txtPlaybackData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlaybackData.Size = new System.Drawing.Size(509, 72);
            this.txtPlaybackData.TabIndex = 11;
            this.tooltipsManager.SetToolTip(this.txtPlaybackData, "Information about playbacks of the BRB video (from chapter 1412 onwards). This is" +
        " updated automatically whenever the BRB player finishes playing the video file.");
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(784, 140);
            this.txtDuration.MaxLength = 100;
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(80, 22);
            this.txtDuration.TabIndex = 5;
            this.txtDuration.Text = "00:00";
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltipsManager.SetToolTip(this.txtDuration, "The playtime of the BRB video file");
            // 
            // btnReplaceBRB
            // 
            this.btnReplaceBRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplaceBRB.Location = new System.Drawing.Point(355, 590);
            this.btnReplaceBRB.Name = "btnReplaceBRB";
            this.btnReplaceBRB.Size = new System.Drawing.Size(178, 30);
            this.btnReplaceBRB.TabIndex = 12;
            this.btnReplaceBRB.Text = "Replace with new version";
            this.tooltipsManager.SetToolTip(this.btnReplaceBRB, "Use this to tell the application a BRB file has changed (whether under the same o" +
        "r a different filename).");
            this.btnReplaceBRB.UseVisualStyleBackColor = true;
            this.btnReplaceBRB.Click += new System.EventHandler(this.btnReplaceBRB_Click);
            // 
            // btnRenameBRB
            // 
            this.btnRenameBRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameBRB.Location = new System.Drawing.Point(686, 590);
            this.btnRenameBRB.Name = "btnRenameBRB";
            this.btnRenameBRB.Size = new System.Drawing.Size(178, 30);
            this.btnRenameBRB.TabIndex = 13;
            this.btnRenameBRB.Text = "Rename BRB file";
            this.tooltipsManager.SetToolTip(this.btnRenameBRB, "Use this to rename the BRB file on disk. If the file has already been renamed out" +
        "side of this application, use the button \"Replace with new version\".");
            this.btnRenameBRB.UseVisualStyleBackColor = true;
            this.btnRenameBRB.Click += new System.EventHandler(this.btnRenameBRB_Click);
            // 
            // numGuaranteedPlays
            // 
            this.numGuaranteedPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGuaranteedPlays.Location = new System.Drawing.Point(497, 433);
            this.numGuaranteedPlays.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGuaranteedPlays.Name = "numGuaranteedPlays";
            this.numGuaranteedPlays.Size = new System.Drawing.Size(46, 22);
            this.numGuaranteedPlays.TabIndex = 9;
            this.tooltipsManager.SetToolTip(this.numGuaranteedPlays, resources.GetString("numGuaranteedPlays.ToolTip"));
            this.numGuaranteedPlays.ValueChanged += new System.EventHandler(this.numGuaranteedPlays_ValueChanged);
            // 
            // numPriorityPlays
            // 
            this.numPriorityPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPriorityPlays.Location = new System.Drawing.Point(773, 433);
            this.numPriorityPlays.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriorityPlays.Name = "numPriorityPlays";
            this.numPriorityPlays.Size = new System.Drawing.Size(46, 22);
            this.numPriorityPlays.TabIndex = 10;
            this.tooltipsManager.SetToolTip(this.numPriorityPlays, resources.GetString("numPriorityPlays.ToolTip"));
            this.numPriorityPlays.ValueChanged += new System.EventHandler(this.numPriorityPlays_ValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(261, 664);
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(361, 22);
            this.txtSearch.TabIndex = 14;
            this.tooltipsManager.SetToolTip(this.txtSearch, "Enter some text to only display BRB videos that contain this text somewhere.");
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // drpSearchWhere
            // 
            this.drpSearchWhere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.drpSearchWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSearchWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpSearchWhere.FormattingEnabled = true;
            this.drpSearchWhere.Items.AddRange(new object[] {
            "(any field)",
            "Filename",
            "Title",
            "Authors",
            "Description"});
            this.drpSearchWhere.Location = new System.Drawing.Point(701, 663);
            this.drpSearchWhere.Name = "drpSearchWhere";
            this.drpSearchWhere.Size = new System.Drawing.Size(163, 24);
            this.drpSearchWhere.TabIndex = 15;
            this.tooltipsManager.SetToolTip(this.drpSearchWhere, "Select where the text you gave should be looked for");
            this.drpSearchWhere.SelectedIndexChanged += new System.EventHandler(this.drpSearchWhere_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(352, 180);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(68, 16);
            this.lblTitle.TabIndex = 18;
            this.lblTitle.Text = "BRB Title:";
            this.tooltipsManager.SetToolTip(this.lblTitle, "This title will be shown to viewers during the InterBRB screen. If empty, the fil" +
        "ename is displayed instead.");
            // 
            // lblAuthors
            // 
            this.lblAuthors.AutoSize = true;
            this.lblAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthors.Location = new System.Drawing.Point(352, 216);
            this.lblAuthors.Name = "lblAuthors";
            this.lblAuthors.Size = new System.Drawing.Size(56, 16);
            this.lblAuthors.TabIndex = 19;
            this.lblAuthors.Text = "Authors:";
            this.tooltipsManager.SetToolTip(this.lblAuthors, "If the authors of the BRB are entered here, they will be displayed to viewers dur" +
        "ing the InterBRB screen.");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(352, 248);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 16);
            this.lblDescription.TabIndex = 20;
            this.lblDescription.Text = "Description:";
            this.tooltipsManager.SetToolTip(this.lblDescription, "A description for the BRB where any additional information can be entered. This w" +
        "ill not be displayed in the BRB player.");
            // 
            // lblPlaybackData
            // 
            this.lblPlaybackData.AutoSize = true;
            this.lblPlaybackData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaybackData.Location = new System.Drawing.Point(352, 477);
            this.lblPlaybackData.Name = "lblPlaybackData";
            this.lblPlaybackData.Size = new System.Drawing.Size(98, 16);
            this.lblPlaybackData.TabIndex = 23;
            this.lblPlaybackData.Text = "Playback data:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(717, 143);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(61, 16);
            this.lblDuration.TabIndex = 17;
            this.lblDuration.Text = "Duration:";
            // 
            // lblGuaranteedPlays
            // 
            this.lblGuaranteedPlays.AutoSize = true;
            this.lblGuaranteedPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuaranteedPlays.Location = new System.Drawing.Point(352, 435);
            this.lblGuaranteedPlays.Name = "lblGuaranteedPlays";
            this.lblGuaranteedPlays.Size = new System.Drawing.Size(139, 16);
            this.lblGuaranteedPlays.TabIndex = 21;
            this.lblGuaranteedPlays.Text = "Guaranteed Plays left:";
            // 
            // lblPriorityPlays
            // 
            this.lblPriorityPlays.AutoSize = true;
            this.lblPriorityPlays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityPlays.Location = new System.Drawing.Point(601, 435);
            this.lblPriorityPlays.Name = "lblPriorityPlays";
            this.lblPriorityPlays.Size = new System.Drawing.Size(166, 16);
            this.lblPriorityPlays.TabIndex = 22;
            this.lblPriorityPlays.Text = "After that, Priority Plays left:";
            // 
            // picSearch
            // 
            this.picSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSearch.Location = new System.Drawing.Point(12, 663);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(24, 24);
            this.picSearch.TabIndex = 43;
            this.picSearch.TabStop = false;
            // 
            // lblFilterBRBs
            // 
            this.lblFilterBRBs.AutoSize = true;
            this.lblFilterBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterBRBs.Location = new System.Drawing.Point(42, 667);
            this.lblFilterBRBs.Name = "lblFilterBRBs";
            this.lblFilterBRBs.Size = new System.Drawing.Size(213, 16);
            this.lblFilterBRBs.TabIndex = 24;
            this.lblFilterBRBs.Text = "Filter BRBs: Should contain the text";
            // 
            // lblFilterWhere
            // 
            this.lblFilterWhere.AutoSize = true;
            this.lblFilterWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterWhere.Location = new System.Drawing.Point(628, 667);
            this.lblFilterWhere.Name = "lblFilterWhere";
            this.lblFilterWhere.Size = new System.Drawing.Size(67, 16);
            this.lblFilterWhere.TabIndex = 25;
            this.lblFilterWhere.Text = "in the field";
            // 
            // lblAvailableBRBs
            // 
            this.lblAvailableBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableBRBs.AutoSize = true;
            this.lblAvailableBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBRBs.Location = new System.Drawing.Point(12, 72);
            this.lblAvailableBRBs.Name = "lblAvailableBRBs";
            this.lblAvailableBRBs.Size = new System.Drawing.Size(100, 16);
            this.lblAvailableBRBs.TabIndex = 16;
            this.lblAvailableBRBs.Text = "BRB Episodes:";
            // 
            // lstAllBRBs
            // 
            this.lstAllBRBs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllBRBs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAllBRBs.FullRowSelect = true;
            this.lstAllBRBs.GridLines = true;
            this.lstAllBRBs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstAllBRBs.HideSelection = false;
            this.lstAllBRBs.LabelWrap = false;
            this.lstAllBRBs.Location = new System.Drawing.Point(12, 96);
            this.lstAllBRBs.MultiSelect = false;
            this.lstAllBRBs.Name = "lstAllBRBs";
            this.lstAllBRBs.ShowItemToolTips = true;
            this.lstAllBRBs.Size = new System.Drawing.Size(328, 524);
            this.lstAllBRBs.TabIndex = 2;
            this.lstAllBRBs.UseCompatibleStateImageBehavior = false;
            this.lstAllBRBs.View = System.Windows.Forms.View.Details;
            this.lstAllBRBs.SelectedIndexChanged += new System.EventHandler(this.lstAllBRBs_SelectedIndexChanged);
            // 
            // tmrResetSaveButton
            // 
            this.tmrResetSaveButton.Interval = 5000;
            this.tmrResetSaveButton.Tick += new System.EventHandler(this.tmrResetSaveButton_Tick);
            // 
            // FormManageBRBs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 735);
            this.Controls.Add(this.lstAllBRBs);
            this.Controls.Add(this.lblAvailableBRBs);
            this.Controls.Add(this.drpSearchWhere);
            this.Controls.Add(this.lblFilterWhere);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblFilterBRBs);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.numPriorityPlays);
            this.Controls.Add(this.numGuaranteedPlays);
            this.Controls.Add(this.lblPriorityPlays);
            this.Controls.Add(this.lblGuaranteedPlays);
            this.Controls.Add(this.btnRenameBRB);
            this.Controls.Add(this.btnReplaceBRB);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.txtPlaybackData);
            this.Controls.Add(this.lblPlaybackData);
            this.Controls.Add(this.btnOpenBRB);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtAuthors);
            this.Controls.Add(this.lblAuthors);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.chkFavourite);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReloadBRBList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManageBRBs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage BRB Episodes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManageBRBs_FormClosing);
            this.Shown += new System.EventHandler(this.FormManageBRBs_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numGuaranteedPlays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriorityPlays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tooltipsManager;
        private System.Windows.Forms.Button btnReloadBRBList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkFavourite;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthors;
        private System.Windows.Forms.Label lblAuthors;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOpenBRB;
        private System.Windows.Forms.TextBox txtPlaybackData;
        private System.Windows.Forms.Label lblPlaybackData;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnReplaceBRB;
        private System.Windows.Forms.Button btnRenameBRB;
        private System.Windows.Forms.Label lblGuaranteedPlays;
        private System.Windows.Forms.Label lblPriorityPlays;
        private System.Windows.Forms.NumericUpDown numGuaranteedPlays;
        private System.Windows.Forms.NumericUpDown numPriorityPlays;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Label lblFilterBRBs;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterWhere;
        private System.Windows.Forms.ComboBox drpSearchWhere;
        private System.Windows.Forms.Label lblAvailableBRBs;
        private System.Windows.Forms.ListView lstAllBRBs;
        private System.Windows.Forms.Timer tmrResetSaveButton;
    }
}