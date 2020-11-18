namespace TestVersion
{
    partial class frmTestVersion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.btnDatabaseBackupPath = new System.Windows.Forms.Button();
            this.btnFileBackupPath = new System.Windows.Forms.Button();
            this.btnUpdatePath = new System.Windows.Forms.Button();
            this.txtDatabaseBackupPath = new System.Windows.Forms.TextBox();
            this.txtFileBackupPath = new System.Windows.Forms.TextBox();
            this.txtUpdatePath = new System.Windows.Forms.TextBox();
            this.cmbUpdateType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmr_GetUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnDownloadFile = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnStopSharing = new System.Windows.Forms.Button();
            this.btnUpdateManual = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveSetting);
            this.groupBox1.Controls.Add(this.btnDatabaseBackupPath);
            this.groupBox1.Controls.Add(this.btnFileBackupPath);
            this.groupBox1.Controls.Add(this.btnUpdatePath);
            this.groupBox1.Controls.Add(this.txtDatabaseBackupPath);
            this.groupBox1.Controls.Add(this.txtFileBackupPath);
            this.groupBox1.Controls.Add(this.txtUpdatePath);
            this.groupBox1.Controls.Add(this.cmbUpdateType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تنظیمات";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(12, 145);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(89, 23);
            this.btnSaveSetting.TabIndex = 11;
            this.btnSaveSetting.Text = "ذخیره تنظیمات";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // btnDatabaseBackupPath
            // 
            this.btnDatabaseBackupPath.Location = new System.Drawing.Point(56, 104);
            this.btnDatabaseBackupPath.Name = "btnDatabaseBackupPath";
            this.btnDatabaseBackupPath.Size = new System.Drawing.Size(45, 23);
            this.btnDatabaseBackupPath.TabIndex = 10;
            this.btnDatabaseBackupPath.Text = "...";
            this.btnDatabaseBackupPath.UseVisualStyleBackColor = true;
            this.btnDatabaseBackupPath.Click += new System.EventHandler(this.btnDatabaseBackupPath_Click);
            // 
            // btnFileBackupPath
            // 
            this.btnFileBackupPath.Location = new System.Drawing.Point(56, 76);
            this.btnFileBackupPath.Name = "btnFileBackupPath";
            this.btnFileBackupPath.Size = new System.Drawing.Size(45, 23);
            this.btnFileBackupPath.TabIndex = 9;
            this.btnFileBackupPath.Text = "...";
            this.btnFileBackupPath.UseVisualStyleBackColor = true;
            this.btnFileBackupPath.Click += new System.EventHandler(this.btnFileBackupPath_Click);
            // 
            // btnUpdatePath
            // 
            this.btnUpdatePath.Location = new System.Drawing.Point(56, 48);
            this.btnUpdatePath.Name = "btnUpdatePath";
            this.btnUpdatePath.Size = new System.Drawing.Size(45, 23);
            this.btnUpdatePath.TabIndex = 8;
            this.btnUpdatePath.Text = "...";
            this.btnUpdatePath.UseVisualStyleBackColor = true;
            this.btnUpdatePath.Click += new System.EventHandler(this.btnUpdatePath_Click);
            // 
            // txtDatabaseBackupPath
            // 
            this.txtDatabaseBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseBackupPath.Location = new System.Drawing.Point(107, 105);
            this.txtDatabaseBackupPath.Name = "txtDatabaseBackupPath";
            this.txtDatabaseBackupPath.Size = new System.Drawing.Size(664, 22);
            this.txtDatabaseBackupPath.TabIndex = 7;
            // 
            // txtFileBackupPath
            // 
            this.txtFileBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileBackupPath.Location = new System.Drawing.Point(107, 77);
            this.txtFileBackupPath.Name = "txtFileBackupPath";
            this.txtFileBackupPath.Size = new System.Drawing.Size(664, 22);
            this.txtFileBackupPath.TabIndex = 6;
            // 
            // txtUpdatePath
            // 
            this.txtUpdatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdatePath.Location = new System.Drawing.Point(107, 49);
            this.txtUpdatePath.Name = "txtUpdatePath";
            this.txtUpdatePath.Size = new System.Drawing.Size(664, 22);
            this.txtUpdatePath.TabIndex = 5;
            // 
            // cmbUpdateType
            // 
            this.cmbUpdateType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUpdateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateType.FormattingEnabled = true;
            this.cmbUpdateType.Items.AddRange(new object[] {
            "خودکار",
            "دستی"});
            this.cmbUpdateType.Location = new System.Drawing.Point(601, 21);
            this.cmbUpdateType.Name = "cmbUpdateType";
            this.cmbUpdateType.Size = new System.Drawing.Size(170, 22);
            this.cmbUpdateType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(777, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "مسیر بکاپ دیتابیس :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "مسیر کپی اطلاعات قبل از آپدیت :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(777, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "مسیر فایل آپدیت :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "شیوه بروزرسانی :";
            // 
            // tmr_GetUpdate
            // 
            this.tmr_GetUpdate.Interval = 36000;
            this.tmr_GetUpdate.Tick += new System.EventHandler(this.tmr_GetUpdate_Tick);
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Location = new System.Drawing.Point(12, 282);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(162, 23);
            this.btnDownloadFile.TabIndex = 1;
            this.btnDownloadFile.Text = "دانلود فایل آپدیت";
            this.btnDownloadFile.UseVisualStyleBackColor = true;
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(413, 184);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(162, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "بروزرسانی نرم افزار";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(413, 242);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(162, 23);
            this.btnShare.TabIndex = 3;
            this.btnShare.Text = "Share";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // btnStopSharing
            // 
            this.btnStopSharing.Location = new System.Drawing.Point(413, 271);
            this.btnStopSharing.Name = "btnStopSharing";
            this.btnStopSharing.Size = new System.Drawing.Size(162, 23);
            this.btnStopSharing.TabIndex = 4;
            this.btnStopSharing.Text = "StopSharing";
            this.btnStopSharing.UseVisualStyleBackColor = true;
            this.btnStopSharing.Click += new System.EventHandler(this.btnStopSharing_Click);
            // 
            // btnUpdateManual
            // 
            this.btnUpdateManual.Location = new System.Drawing.Point(380, 213);
            this.btnUpdateManual.Name = "btnUpdateManual";
            this.btnUpdateManual.Size = new System.Drawing.Size(215, 23);
            this.btnUpdateManual.TabIndex = 2;
            this.btnUpdateManual.Text = "بروزرسانی نرم افزار از طریق فایل";
            this.btnUpdateManual.UseVisualStyleBackColor = true;
            this.btnUpdateManual.Click += new System.EventHandler(this.btnUpdateManual_Click);
            // 
            // frmTestVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 317);
            this.Controls.Add(this.btnStopSharing);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnUpdateManual);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDownloadFile);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestVersion";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "برنامه تست آپدیت";
            this.Load += new System.EventHandler(this.frmTestVersion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDatabaseBackupPath;
        private System.Windows.Forms.TextBox txtFileBackupPath;
        private System.Windows.Forms.TextBox txtUpdatePath;
        private System.Windows.Forms.ComboBox cmbUpdateType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDatabaseBackupPath;
        private System.Windows.Forms.Button btnFileBackupPath;
        private System.Windows.Forms.Button btnUpdatePath;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Timer tmr_GetUpdate;
        private System.Windows.Forms.Button btnDownloadFile;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnStopSharing;
        private System.Windows.Forms.Button btnUpdateManual;
    }
}

