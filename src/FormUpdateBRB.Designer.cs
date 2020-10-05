namespace Hob_BRB_Player
{
    partial class FormUpdateBRB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateBRB));
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNewFilename = new System.Windows.Forms.Label();
            this.txtOldFilename = new System.Windows.Forms.TextBox();
            this.lblOldFilename = new System.Windows.Forms.Label();
            this.lblUpdateBRB = new System.Windows.Forms.Label();
            this.drpUpdatedFilename = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnReplace
            // 
            this.btnReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.Location = new System.Drawing.Point(391, 159);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(111, 30);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(274, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNewFilename
            // 
            this.lblNewFilename.AutoSize = true;
            this.lblNewFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewFilename.Location = new System.Drawing.Point(12, 114);
            this.lblNewFilename.Name = "lblNewFilename";
            this.lblNewFilename.Size = new System.Drawing.Size(111, 16);
            this.lblNewFilename.TabIndex = 6;
            this.lblNewFilename.Text = "Updated version:";
            // 
            // txtOldFilename
            // 
            this.txtOldFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldFilename.Location = new System.Drawing.Point(129, 83);
            this.txtOldFilename.Name = "txtOldFilename";
            this.txtOldFilename.ReadOnly = true;
            this.txtOldFilename.Size = new System.Drawing.Size(373, 22);
            this.txtOldFilename.TabIndex = 3;
            // 
            // lblOldFilename
            // 
            this.lblOldFilename.AutoSize = true;
            this.lblOldFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldFilename.Location = new System.Drawing.Point(12, 86);
            this.lblOldFilename.Name = "lblOldFilename";
            this.lblOldFilename.Size = new System.Drawing.Size(86, 16);
            this.lblOldFilename.TabIndex = 5;
            this.lblOldFilename.Text = "Old filename:";
            // 
            // lblUpdateBRB
            // 
            this.lblUpdateBRB.AutoSize = true;
            this.lblUpdateBRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateBRB.Location = new System.Drawing.Point(12, 18);
            this.lblUpdateBRB.Name = "lblUpdateBRB";
            this.lblUpdateBRB.Size = new System.Drawing.Size(475, 48);
            this.lblUpdateBRB.TabIndex = 4;
            this.lblUpdateBRB.Text = resources.GetString("lblUpdateBRB.Text");
            // 
            // drpUpdatedFilename
            // 
            this.drpUpdatedFilename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpUpdatedFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpUpdatedFilename.FormattingEnabled = true;
            this.drpUpdatedFilename.Location = new System.Drawing.Point(129, 111);
            this.drpUpdatedFilename.Name = "drpUpdatedFilename";
            this.drpUpdatedFilename.Size = new System.Drawing.Size(373, 24);
            this.drpUpdatedFilename.TabIndex = 0;
            // 
            // FormUpdateBRB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 208);
            this.Controls.Add(this.drpUpdatedFilename);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblNewFilename);
            this.Controls.Add(this.txtOldFilename);
            this.Controls.Add(this.lblOldFilename);
            this.Controls.Add(this.lblUpdateBRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateBRB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace BRB with updated version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNewFilename;
        private System.Windows.Forms.TextBox txtOldFilename;
        private System.Windows.Forms.Label lblOldFilename;
        private System.Windows.Forms.Label lblUpdateBRB;
        private System.Windows.Forms.ComboBox drpUpdatedFilename;
    }
}