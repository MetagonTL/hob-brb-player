namespace Hob_BRB_Player
{
    partial class FormAutoMuteData
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
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAutoMuteSpanToEdit = new System.Windows.Forms.Label();
            this.drpAutoMuteTrigger = new System.Windows.Forms.ComboBox();
            this.lblBegin = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.txtBegin = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(411, 210);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(153, 30);
            this.btnSaveAndClose.TabIndex = 5;
            this.btnSaveAndClose.Text = "Save and Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(12, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblAutoMuteSpanToEdit
            // 
            this.lblAutoMuteSpanToEdit.AutoSize = true;
            this.lblAutoMuteSpanToEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoMuteSpanToEdit.Location = new System.Drawing.Point(12, 22);
            this.lblAutoMuteSpanToEdit.Name = "lblAutoMuteSpanToEdit";
            this.lblAutoMuteSpanToEdit.Size = new System.Drawing.Size(108, 16);
            this.lblAutoMuteSpanToEdit.TabIndex = 6;
            this.lblAutoMuteSpanToEdit.Text = "AutoMute trigger:";
            // 
            // drpAutoMuteTrigger
            // 
            this.drpAutoMuteTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drpAutoMuteTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpAutoMuteTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpAutoMuteTrigger.FormattingEnabled = true;
            this.drpAutoMuteTrigger.Location = new System.Drawing.Point(139, 19);
            this.drpAutoMuteTrigger.Name = "drpAutoMuteTrigger";
            this.drpAutoMuteTrigger.Size = new System.Drawing.Size(425, 24);
            this.drpAutoMuteTrigger.TabIndex = 0;
            this.drpAutoMuteTrigger.SelectedIndexChanged += new System.EventHandler(this.drpAutoMuteTrigger_SelectedIndexChanged);
            // 
            // lblBegin
            // 
            this.lblBegin.AutoSize = true;
            this.lblBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBegin.Location = new System.Drawing.Point(12, 68);
            this.lblBegin.Name = "lblBegin";
            this.lblBegin.Size = new System.Drawing.Size(46, 16);
            this.lblBegin.TabIndex = 7;
            this.lblBegin.Text = "Begin:";
            // 
            // lblEnd
            // 
            this.lblEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(313, 68);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(35, 16);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "End:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 107);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(329, 16);
            this.lblInfo.TabIndex = 9;
            this.lblInfo.Text = "Identified DMCA-relevant material / Further information:";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(12, 126);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(552, 58);
            this.txtInfo.TabIndex = 3;
            this.txtInfo.Text = "1\r\n2\r\n3\r\n4";
            // 
            // txtBegin
            // 
            this.txtBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBegin.Location = new System.Drawing.Point(64, 65);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.ReadOnly = true;
            this.txtBegin.Size = new System.Drawing.Size(210, 22);
            this.txtBegin.TabIndex = 1;
            // 
            // txtEnd
            // 
            this.txtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnd.Location = new System.Drawing.Point(354, 65);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size(210, 22);
            this.txtEnd.TabIndex = 2;
            // 
            // FormAutoMuteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 252);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtBegin);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblBegin);
            this.Controls.Add(this.drpAutoMuteTrigger);
            this.Controls.Add(this.lblAutoMuteSpanToEdit);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutoMuteData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Displaying AutoMute Data of None.mp4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAutoMuteSpanToEdit;
        private System.Windows.Forms.ComboBox drpAutoMuteTrigger;
        private System.Windows.Forms.Label lblBegin;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtBegin;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtInfo;
    }
}