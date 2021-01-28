using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestVersion.DataControl.Controllers;
using TestVersion.Model;
using TestVersion.Utilities;
using System.Net;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

namespace TestVersion
{
    public partial class frmTestVersion : Form
    {
        #region Private Properties
        private VersionSettingController versionSettingController;
        List<VersionSettingDto> versionSettings;
        GetUpdate.WSUpdate wSUpdate;
        string UserID;
        string AppVersionCode;
        string UpdatePath;
        int UpdateType;

        Thread threadCheckUpdate;
        #endregion

        #region Method

        public frmTestVersion()
        {
            InitializeComponent();
            versionSettingController = new VersionSettingController();
            wSUpdate = new GetUpdate.WSUpdate();
        }

        private void FillData()
        {
            versionSettings = versionSettingController.GetAll();
            FillSettings();
        }

        private void FillSettings()
        {
            cmbUpdateType.SelectedIndex = UpdateType = GetSettingValue("UpdateType").ToInteger(0);
            txtUpdatePath.Text = UpdatePath = GetSettingValue("UpdatePath");
            txtFileBackupPath.Text = GetSettingValue("FileBackupPath");
            txtDatabaseBackupPath.Text = GetSettingValue("DatabaseBackupPath");
            UserID = GetSettingValue("UserID");
            AppVersionCode = GetSettingValue("AppVersionCode");
        }

        private string GetSettingValue(string key)
        {
            string result = "";

            if (versionSettings != null && versionSettings.Count > 0)
            {
                result = versionSettings.Find(x => x.SettingKey == key) != null ? versionSettings.Find(x => x.SettingKey == key).SettingValue : "";
            }

            return result;
        }

        //private void SetTimer_Update()
        //{
        //    if (cmbUpdateType.SelectedIndex == 1)
        //    {
        //        tmr_GetUpdate.Enabled = true;
        //        tmr_GetUpdate_Tick(null, null);
        //    }
        //}

        private void CheckExistUpdate()
        {
            try
            {
                //Thread.Sleep(3000);
                int Result = wSUpdate.UpdateExist(UserID, AppVersionCode);

                if (Result == -2)
                {
                    MessageBox.Show("خطا در ارتباط با سرور بروزرسانی");
                    return;
                }

                if (Result > 0)
                {
                    if (MessageBox.Show(string.Format("نسخه جدیدی از نرم افزار در دسترس است ،آیا تمایل به بروزرسانی دارید ؟{0} نسخه نرم افزار : {1} {0} نسخه موجود : {2}", Environment.NewLine, AppVersionCode, Result), "نسخه جدید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //فراخوانی دانلود از طریق ترد
                        //اضافه کردن پراگرس بار برای نمایش پروسه دانلود
                        if (DownloadUpdate())
                        {
                            //«نمایش پیغام تکمیل دانلود
                            //به کاربر اعلام می شود که همه کاربران باید از سیستم خارج شوند
                            //درصورت تایید به فرم آپدیتر می رود
                            if (MessageBox.Show(string.Format("فایل بروزرسانی نرم افزار با موفقیت دانلود شد{0}برای ادامه بروزرسانی ابتدا باید تمامی کاربران از نرم افزار خارج شوند{0}ادامه می دهید ؟", Environment.NewLine), "بروزرسانی نرم افزار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Process.Start(string.Format("{0}\\Updater.exe", Application.StartupPath));
                                Application.Exit();
                            }
                        }
                    }
                }

            }
            catch
            {

            }
        }

        private bool DownloadUpdate()
        {
            try
            {
                //Thread.Sleep(3000);
                string UpdateFileName = wSUpdate.GetUpdate(UserID, AppVersionCode);
                string ZipFilePath = string.Format(@"{0}\Update.zip", UpdatePath);
                string RemoteUri = ConfigurationManager.AppSettings.Get("VersionDownloadAddress");
                string DownloadFileName = UpdateFileName;
                string WebResource = RemoteUri + DownloadFileName;

                //WebClient myWebClient = new WebClient();
                //myWebClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("VersionDownloadUser"),
                //                                                ConfigurationManager.AppSettings.Get("VersionDownloadPassword"));

                //myWebClient.DownloadFile(WebResource, ZipFilePath);
                FTPDownload(ZipFilePath, WebResource, ConfigurationManager.AppSettings.Get("VersionDownloadUser"),
                                                     ConfigurationManager.AppSettings.Get("VersionDownloadPassword"));

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return false;
        }

        private NetworkCredential CreateNetworkCredentials(string ftpUserID, string ftpPassword)
        {
            return new NetworkCredential(ftpUserID, ftpPassword);
        }

        private FtpWebRequest CreateFTPRequest(string fullFtpPath)
        {
            return (FtpWebRequest)FtpWebRequest.Create(new Uri(fullFtpPath));
        }

        private void FTPDownload(string path, string fullFtpPath,
            string ftpUserID, string ftpPassword)
        {
            FileStream outputStream;
            FtpWebRequest ftpWebRequest = GetDownloadFTPWebRequest(path, fullFtpPath, ftpUserID, ftpPassword, out outputStream);
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            FtpWebResponse response = (FtpWebResponse)ftpWebRequest.GetResponse();
            PassFileStreamDataToStream(response, outputStream);
        }

        private FtpWebRequest GetDownloadFTPWebRequest(string path, string fullFtpPath,
           string ftpUserID, string ftpPassword, out FileStream fs)
        {
            fs = new FileStream(path, FileMode.Create);
            FtpWebRequest reqFTP = CreateFTPRequest(fullFtpPath);
            reqFTP.Credentials = CreateNetworkCredentials(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
            reqFTP.UseBinary = true;
            reqFTP.EnableSsl = true;
            reqFTP.ContentLength = fs.Length;
            return reqFTP;
        }

        private void PassFileStreamDataToStream(FtpWebResponse response, FileStream outputStream)
        {
            try
            {
                Stream ftpStream = response.GetResponseStream();
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region Event
        private void frmTestVersion_Load(object sender, EventArgs e)
        {
            //تنظیمات
            FillData();
            //SetTimer_Update();

            //اگر تنظیمات روی آپدیت خودکار است
            //thread 
            if (UpdateType == 0)
            {
                threadCheckUpdate = new Thread(CheckExistUpdate);
                threadCheckUpdate.Start();
            }
            //
        }

        private void btnUpdatePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtUpdatePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnFileBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileBackupPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnDatabaseBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtDatabaseBackupPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            List<VersionSettingDto> versionSettingDtos = new List<VersionSettingDto>();
            versionSettingDtos.Add(new VersionSettingDto()
            {
                SettingKey = "UpdateType",
                SettingValue = cmbUpdateType.SelectedIndex.ToString()
            });
            versionSettingDtos.Add(new VersionSettingDto()
            {
                SettingKey = "UpdatePath",
                SettingValue = txtUpdatePath.Text
            });
            versionSettingDtos.Add(new VersionSettingDto()
            {
                SettingKey = "FileBackupPath",
                SettingValue = txtFileBackupPath.Text
            });
            versionSettingDtos.Add(new VersionSettingDto()
            {
                SettingKey = "DatabaseBackupPath",
                SettingValue = txtDatabaseBackupPath.Text
            });
            versionSettingController.SaveList(DataStructure.FormAction.Edit, versionSettingDtos);
            MessageBox.Show("ذخیره تنظیمات با موفقیت انجام شد");
        }

        private void tmr_GetUpdate_Tick(object sender, EventArgs e)
        {
            string strResult = "";

            strResult = wSUpdate.GetUpdate("", "");

            if (strResult != "0" && strResult != "-2" && strResult != "-1")
            {

            }
        }
        #endregion

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            string strRemoteUri = "ftp://localhost:2121/";
            string strDownloadFileName = wSUpdate.GetUpdate("1122", "0");
            string strWebResource = strRemoteUri + strDownloadFileName;
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(strWebResource, string.Format(@"{0}\Update.zip", txtUpdatePath.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("آیا مایل به بروزرسانی برنامه هستید ؟", "بروزرسانی نرم افزار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    Process.Start(string.Format("{0}\\Updater.exe", Application.StartupPath));
            //    Application.Exit();
            //}

            //thread
            CheckExistUpdate();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            var folderName = "Debug";
            var targetDir = Application.StartupPath;
            var process = new Process();

            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C net share {folderName}=\"{targetDir}\" "
            };

            process.Start();
            process.WaitForExit();
        }

        private void btnStopSharing_Click(object sender, EventArgs e)
        {
            var folderName = "Debug";
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C net share \"{folderName}\" /delete"
            };

            process.Start();
            process.WaitForExit();
        }

        private void btnUpdateManual_Click(object sender, EventArgs e)
        {
            frmPrepareUpdate frmPrepareUpdate = new frmPrepareUpdate(UserID, AppVersionCode, UpdatePath);
            frmPrepareUpdate.ShowDialog();
        }
    }
}
