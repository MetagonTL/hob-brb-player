namespace Hob_BRB_Player
{
    partial class FormRenameBRB
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
            this.lblRenameBRB = new System.Windows.Forms.Label();
            this.lblOldFilename = new System.Windows.Forms.Label();
            this.txtOldFilename = new System.Windows.Forms.TextBox();
            this.txtNewFilename = new System.Windows.Forms.TextBox();
            this.lblNewFilename = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRenameBRB
            // 
            this.lblRenameBRB.AutoSize = true;
            this.lblRenameBRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenameBRB.Location = new System.Drawing.Point(12, 18);
            this.lblRenameBRB.Name = "lblRenameBRB";
            this.lblRenameBRB.Size = new System.Drawing.Size(444, 32);
            this.lblRenameBRB.TabIndex = 0;
            this.lblRenameBRB.Text = "Rename your selected BRB file on disk by entering a new filename below.\r\nBRB data" +
    " will automatically be transferred to the new name.";
            // 
            // lblOldFilename
            // 
            this.lblOldFilename.AutoSize = true;
            this.lblOldFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldFilename.Location = new System.Drawing.Point(12, 71);
            this.lblOldFilename.Name = "lblOldFilename";
            this.lblOldFilename.Size = new System.Drawing.Size(86, 16);
            this.lblOldFilename.TabIndex = 1;
            this.lblOldFilename.Text = "Old filename:";
            // 
            // txtOldFilename
            // 
            this.txtOldFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldFilename.Location = new System.Drawing.Point(110, 68);
            this.txtOldFilename.Name = "txtOldFilename";
            this.txtOldFilename.ReadOnly = true;
            this.txtOldFilename.Size = new System.Drawing.Size(352, 22);
            this.txtOldFilename.TabIndex = 2;
            // 
            // txtNewFilename
            // 
            this.txtNewFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewFilename.Location = new System.Drawing.Point(110, 96);
            this.txtNewFilename.Name = "txtNewFilename";
            this.txtNewFilename.Size = new System.Drawing.Size(352, 22);
            this.txtNewFilename.TabIndex = 4;
            // 
            // lblNewFilename
            // 
            this.lblNewFilename.AutoSize = true;
            this.lblNewFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewFilename.Location = new System.Drawing.Point(12, 99);
            this.lblNewFilename.Name = "lblNewFilename";
            this.lblNewFilename.Size = new System.Drawing.Size(92, 16);
            this.lblNewFilename.TabIndex = 3;
            this.lblNewFilename.Text = "New filename:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(234, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRename
            // 
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.Location = new System.Drawing.Point(351, 140);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(111, 30);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // FormRenameBRB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 187);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNewFilename);
            this.Controls.Add(this.lblNewFilename);
            this.Controls.Add(this.txtOldFilename);
            this.Controls.Add(this.lblOldFilename);
            this.Controls.Add(this.lblRenameBRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRenameBRB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename BRB file on disk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRenameBRB;
        private System.Windows.Forms.Label lblOldFilename;
        private System.Windows.Forms.TextBox txtOldFilename;
        private System.Windows.Forms.TextBox txtNewFilename;
        private System.Windows.Forms.Label lblNewFilename;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRename;
    }
}