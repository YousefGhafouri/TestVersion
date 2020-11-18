namespace TestVersion
{
    partial class frmPrepareUpdate
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
            this.btnGetKey = new System.Windows.Forms.Button();
            this.btnBrows = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetKey
            // 
            this.btnGetKey.Location = new System.Drawing.Point(12, 12);
            this.btnGetKey.Name = "btnGetKey";
            this.btnGetKey.Size = new System.Drawing.Size(605, 41);
            this.btnGetKey.TabIndex = 0;
            this.btnGetKey.Text = "دریافت فایل کلید بروزرسانی";
            this.btnGetKey.UseVisualStyleBackColor = true;
            this.btnGetKey.Click += new System.EventHandler(this.btnGetKey_Click);
            // 
            // btnBrows
            // 
            this.btnBrows.Enabled = false;
            this.btnBrows.Location = new System.Drawing.Point(19, 98);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(57, 23);
            this.btnBrows.TabIndex = 1;
            this.btnBrows.Text = "...";
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(82, 99);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(413, 22);
            this.txtFilePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "فایل دریافتی از سایت :";
            // 
            // btnStartUpdate
            // 
            this.btnStartUpdate.Enabled = false;
            this.btnStartUpdate.Location = new System.Drawing.Point(12, 153);
            this.btnStartUpdate.Name = "btnStartUpdate";
            this.btnStartUpdate.Size = new System.Drawing.Size(605, 41);
            this.btnStartUpdate.TabIndex = 4;
            this.btnStartUpdate.Text = "شروع بروزرسانی";
            this.btnStartUpdate.UseVisualStyleBackColor = true;
            this.btnStartUpdate.Click += new System.EventHandler(this.btnStartUpdate_Click);
            // 
            // frmPrepareUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 206);
            this.Controls.Add(this.btnStartUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrows);
            this.Controls.Add(this.btnGetKey);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrepareUpdate";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بروزرسانی برنامه";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetKey;
        private System.Windows.Forms.Button btnBrows;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartUpdate;
    }
}