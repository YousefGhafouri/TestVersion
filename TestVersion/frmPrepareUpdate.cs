using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TestVersion.Utilities;
using static TestVersion.Utilities.DataStructure;

namespace TestVersion
{
    public partial class frmPrepareUpdate : Form
    {
        string UserID;
        string AppVersionCode;
        string UpdatePath;

        public frmPrepareUpdate(string userID, string appVersionCode, string updatePath)
        {
            InitializeComponent();
            UserID = userID;
            AppVersionCode = appVersionCode;
            UpdatePath = UpdatePath;
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            VersionInfo versionInfo = new VersionInfo()
            {
                UserId = UserID,
                AppVersioCode = AppVersionCode,
                PackType = ServicePackType.UserDiffPack
            };

            string info = versionInfo.ToJSON();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "INI Files (*.ini)|*.ini";
            saveFileDialog.FileName = "VersionInfo.ini";
            saveFileDialog.Title = "ذخیره فایل کلید بروزرسانی";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriterINI = new StreamWriter(saveFileDialog.FileName);
                streamWriterINI.Write(info);
                streamWriterINI.Close();
                MessageBox.Show("فایل کلید بروزرسانی با موفقیت ذخیره شد");
                btnBrows.Enabled = txtFilePath.Enabled = btnStartUpdate.Enabled = true;
            }

        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "انتخاب فایل بروزرسانی";
            openFileDialog.Filter = "Zip Files (*.zip)|*.zip|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnStartUpdate_Click(object sender, EventArgs e)
        {
            string ZipFilePath = string.Format(@"{0}\Update.zip", UpdatePath);
            File.Copy(txtFilePath.Text, ZipFilePath, true);
            if (MessageBox.Show("آیا مایل به بروزرسانی برنامه هستید ؟", "بروزرسانی نرم افزار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(string.Format("{0}\\Updater.exe", Application.StartupPath));
                Application.Exit();
            }
        }
    }
}
