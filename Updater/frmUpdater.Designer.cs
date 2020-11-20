namespace Updater
{
    partial class frmUpdater
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
            this.btnAutoUpdate = new System.Windows.Forms.Button();
            this.btnManualUpdate = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCheckConnection = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAutoUpdate
            // 
            this.btnAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoUpdate.Location = new System.Drawing.Point(588, 231);
            this.btnAutoUpdate.Name = "btnAutoUpdate";
            this.btnAutoUpdate.Size = new System.Drawing.Size(149, 25);
            this.btnAutoUpdate.TabIndex = 0;
            this.btnAutoUpdate.Text = "بروزرسانی نرم افزار";
            this.btnAutoUpdate.UseVisualStyleBackColor = true;
            this.btnAutoUpdate.Visible = false;
            this.btnAutoUpdate.Click += new System.EventHandler(this.btnAutoUpdate_Click);
            // 
            // btnManualUpdate
            // 
            this.btnManualUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualUpdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnManualUpdate.Location = new System.Drawing.Point(433, 231);
            this.btnManualUpdate.Name = "btnManualUpdate";
            this.btnManualUpdate.Size = new System.Drawing.Size(149, 25);
            this.btnManualUpdate.TabIndex = 1;
            this.btnManualUpdate.Text = "بروزرسانی از طریق فایل";
            this.btnManualUpdate.UseVisualStyleBackColor = false;
            this.btnManualUpdate.Visible = false;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(727, 184);
            this.txtLog.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 231);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "انصراف و خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCheckConnection
            // 
            this.btnCheckConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckConnection.Location = new System.Drawing.Point(152, 231);
            this.btnCheckConnection.Name = "btnCheckConnection";
            this.btnCheckConnection.Size = new System.Drawing.Size(112, 25);
            this.btnCheckConnection.TabIndex = 5;
            this.btnCheckConnection.Text = "بررسی اتصال";
            this.btnCheckConnection.UseVisualStyleBackColor = true;
            this.btnCheckConnection.Visible = false;
            this.btnCheckConnection.Click += new System.EventHandler(this.btnCheckConnection_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.ForeColor = System.Drawing.Color.Red;
            this.lblConnection.Location = new System.Drawing.Point(12, 199);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(727, 29);
            this.lblConnection.TabIndex = 6;
            this.lblConnection.Text = "اتصال با سرور برقرار نیست";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 269);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnCheckConnection);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnManualUpdate);
            this.Controls.Add(this.btnAutoUpdate);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdater";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بروزرسانی برنامه";
            this.Load += new System.EventHandler(this.frmUpdater_Load);
            this.Shown += new System.EventHandler(this.frmUpdater_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutoUpdate;
        private System.Windows.Forms.Button btnManualUpdate;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCheckConnection;
        private System.Windows.Forms.Label lblConnection;
    }
}

