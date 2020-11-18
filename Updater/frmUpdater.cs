using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using TestVersion.Utilities;
using Updater.DataControl.Controllers;
using Updater.Model;
using static TestVersion.Utilities.DataStructure;
using static TestVersion.Utilities.ExtentionMethod;

namespace Updater
{
    public partial class frmUpdater : Form
    {
        #region Variable
        private VersionSettingController versionSettingController;
        List<VersionSettingDto> versionSettings;
        GetUpdate.WSUpdate WSUpdate = new GetUpdate.WSUpdate();

        SqlConnection sqlConnection;
        DataAccess.DataAccess dataAccess;

        string UserID;
        string AppVersionCode;
        string UpdatePath;
        string FileBackupPath;
        string DatabaseBackupPath;

        bool AutoUpdateStats = false;
        bool AutoUpdateStatsAsync = false;
        #endregion
        public frmUpdater()
        {
            InitializeComponent();
            versionSettingController = new VersionSettingController();
            WSUpdate = new GetUpdate.WSUpdate();
            dataAccess = new DataAccess.DataAccess();
        }

        public frmUpdater(bool updateDownloaded)
        {
            InitializeComponent();
            versionSettingController = new VersionSettingController();
            WSUpdate = new GetUpdate.WSUpdate();
            //آغاز پروسه بروز رسانی نرم افزار
        }

        #region Method
        private bool CheckConnection()
        {
            try
            {
                if (WSUpdate.CheckConnection() == "1")
                {
                    lblConnection.Text = "اتصال با سرور برقرار شد";
                    lblConnection.ForeColor = Color.Green;
                    return true;
                }
                else
                {
                    lblConnection.Text = "اتصال با سرور برقرار نیست";
                    lblConnection.ForeColor = Color.Red;
                    return false;
                }
            }
            catch
            {
                lblConnection.Text = "اتصال با سرور برقرار نیست";
                lblConnection.ForeColor = Color.Red;
                return false;
            }
        }

        private void FillData()
        {
            versionSettings = versionSettingController.GetAll();
            UserID = GetSettingValue("UserID");
            AppVersionCode = GetSettingValue("AppVersionCode");
            UpdatePath = GetSettingValue("UpdatePath");
            FileBackupPath = GetSettingValue("FileBackupPath");
            DatabaseBackupPath = GetSettingValue("DatabaseBackupPath");
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

        private void CreateLog(string log)
        {
            txtLog.Invoke(new Action(() => txtLog.AppendText(string.Format("{0}{1}", Environment.NewLine, log))));
        }

        private void ShareFolder(string folderName, string targetDir)
        {
            Process process = new Process();

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

        private void StopSharing(string folderName)
        {
            Process process = new Process();
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

        private void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                try
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
                catch
                {
                    CreateLog(string.Format("فایل {0} کپی نشد", fi.Name));
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }

        }
        #endregion

        private void frmUpdater_Load(object sender, EventArgs e)
        {
            FillData();
            CheckConnection();
        }

        private void btnAutoUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void frmUpdater_Shown(object sender, EventArgs e)
        {
            try
            {
                btnExit.Enabled = false;
                sqlConnection = new SqlConnection(TestVersion.Utilities.AppConfig.ConnectionString);
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(TestVersion.Utilities.AppConfig.ConnectionString);
                string UpdateDateTime;
                UpdateDateTime = string.Format("BackupFiles_{0}-{1}", DateTime.Now.ToPersianDate().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", "-"));
                string BackupDateTime = string.Format("BackupDatabase_{0}-{1}", DateTime.Now.ToPersianDate().Replace("/", "-"), DateTime.Now.ToShortTimeString().Replace(":", "-"));
                //string Result = WSUpdate.GetUpdate(UserID, AppVersionCode);
                string ZipFilePath = string.Format(@"{0}\Update.zip", UpdatePath);

                //if (!CheckConnection())
                //{
                //    CreateLog("اتصال با سرور برقرار نیست.");
                //    return;
                //}
                //if (Result == "-2")
                //{
                //    CreateLog("خطا در دریافت اطلاعات از سرور.لطفا مجددا تلاش نمایید.");
                //    return;
                //}
                //if (Result == "-1")
                //{
                //    CreateLog("شما در حال استفاده از آخرین نسخه نرم افزار هستید");
                //    return;
                //}

                if (!File.Exists(ZipFilePath))
                {
                    CreateLog("فایل بروزرسانی یافت نشد.");
                    return;
                }

                //DialogResult ExitAllUser;
                //ExitAllUser = MessageBox.Show(string.Format("قبل از شروع بروزرسانی همه کاربران باید از برنامه خارج شده باشند.{0}ادامه می دهید ؟", Environment.NewLine), "بروزرسانی نرم افزار", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (ExitAllUser == DialogResult.No)
                //    return;
                string AppPath = Application.StartupPath.Substring(Application.StartupPath.LastIndexOf("\\"), Application.StartupPath.Length - Application.StartupPath.LastIndexOf("\\"));
                StopSharing("Debug");
                CreateLog("از دسترس خارج کردن فایلهای برنامه");//f:\newfolder\reportbuilder

                //SingleUserDatabase
                DataTable dataTableAuto = dataAccess.MakeDatabaseSingle();

                AutoUpdateStats = dataTableAuto.Rows[0]["AutoUpdateStats"].ToBoolean();
                AutoUpdateStatsAsync = dataTableAuto.Rows[0]["AutoUpdateStatsAsync"].ToBoolean();

                //CreateLog("در حال دریافت فایل بروزرسانی از سرور.");
                //string RemoteUri = ConfigurationManager.AppSettings.Get("VersionDownloadAddress");
                //string DownloadFileName = Result;
                //string WebResource = RemoteUri + DownloadFileName;
                //WebClient myWebClient = new WebClient();
                //myWebClient.DownloadFile(WebResource, ZipFilePath);
                //CreateLog("دانلود فایل با موفقیت انجام شد.");

                string ExtractPath = Regex.Replace(ZipFilePath, ".zip", "");
                if (Directory.Exists(ExtractPath))
                    Directory.Delete(ExtractPath, true);//f:\newfolder\UpdateFiles\update.zip

                ZipFile.ExtractToDirectory(ZipFilePath, ExtractPath);
                CreateLog("آماده سازی فایلهای بروزرسانی.");

                if (!File.Exists(string.Format(@"{0}\VersionInfo.ini", ExtractPath)))
                {
                    CreateLog("فایل اطلاعات نسخه جدید یافت نشد.");
                    return;
                }
                StreamReader streamReaderINI = new StreamReader(string.Format(@"{0}\VersionInfo.ini", ExtractPath));
                string VersionInfoINI = streamReaderINI.ReadToEnd();
                streamReaderINI.Close();
                VersionInfo versionInfo = new VersionInfo();
                versionInfo = JsonConvert.DeserializeObject<VersionInfo>(VersionInfoINI);
                if (versionInfo == null
                    || versionInfo.AppVersioCode != AppVersionCode
                    || versionInfo.AppVersioCode.ToInteger() < AppVersionCode.ToInteger()
                    || versionInfo.UserId != UserID)
                {
                    CreateLog("محتویات فایل بروزرسانی با نرم افزار شما همخوانی ندارد.");
                    return;
                }

                ZipFile.CreateFromDirectory(Application.StartupPath, string.Format(@"{0}\{1}.Zip", FileBackupPath, UpdateDateTime));
                CreateLog("ایجاد نسخه پشتیبان از فایلهای برنامه با موفقیت انجام شد.");

                //BackupDatabase
                dataAccess.CreateDatabaseBackup("TestVersion", string.Format(@"{0}\{1}.bak", DatabaseBackupPath, BackupDateTime));
                CreateLog("ایجاد نسخه پشتیبان از بانک اطلاعاتی با موفقیت انجام شد.");

                //UpdateDatabase
                string StructureScript = "";
                string AlterScript = "";
                if (File.Exists(string.Format(@"{0}\Scripts\__Struct.sql", ExtractPath)))
                {
                    Server sqlServerInstance = new Server(new ServerConnection(sqlConnectionStringBuilder.DataSource, sqlConnectionStringBuilder.UserID, sqlConnectionStringBuilder.Password));

                    StreamReader srStructure = new StreamReader(string.Format(@"{0}\Scripts\__Struct.sql", ExtractPath));
                    StructureScript = srStructure.ReadToEnd();
                    srStructure.Close();

                    sqlServerInstance.ConnectionContext.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql;
                    sqlServerInstance.ConnectionContext.StatementTimeout = 0;

                    sqlServerInstance.ConnectionContext.Connect();
                    sqlServerInstance.ConnectionContext.SqlConnectionObject.EnlistTransaction(Transaction.Current);
                    sqlServerInstance.Databases[sqlConnectionStringBuilder.InitialCatalog].ExecuteNonQuery(StructureScript);
                }
                if (File.Exists(string.Format(@"{0}\Scripts\__Alter.sql", ExtractPath)))
                {

                    Server sqlServerInstance = new Server(new ServerConnection(sqlConnectionStringBuilder.DataSource, sqlConnectionStringBuilder.UserID, sqlConnectionStringBuilder.Password));

                    StreamReader srAlter = new StreamReader(string.Format(@"{0}\Scripts\__Alter.sql", ExtractPath));
                    AlterScript = srAlter.ReadToEnd();
                    srAlter.Close();

                    sqlServerInstance.ConnectionContext.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql;
                    sqlServerInstance.ConnectionContext.StatementTimeout = 0;

                    sqlServerInstance.ConnectionContext.Connect();
                    sqlServerInstance.ConnectionContext.SqlConnectionObject.EnlistTransaction(Transaction.Current);
                    sqlServerInstance.Databases[sqlConnectionStringBuilder.InitialCatalog].ExecuteNonQuery(AlterScript);

                }
                CreateLog("بروزرسانی بانک اطلاعاتی با موفقیت انجام شد.");

                CreateLog("در حال کپی فایل های جدید.");
                Copy(string.Format(@"{0}\Dlls", ExtractPath), Application.StartupPath);
                CreateLog("کپی فایلهای جدید با موفقیت انجام شد.");


                File.Delete(ZipFilePath);
                File.Delete(string.Format(@"{0}\{1}.Zip", FileBackupPath, UpdateDateTime));
                Directory.Delete(ExtractPath, true);
                File.Delete(string.Format(@"{0}\{1}.bak", DatabaseBackupPath, BackupDateTime));

                List<VersionSettingDto> versionSettingDtos = new List<VersionSettingDto>();
                versionSettingDtos.Add(new VersionSettingDto()
                {
                    SettingKey = "AppVersionCode",
                    SettingValue = versionInfo.AppVersioCode
                });
                versionSettingDtos.Add(new VersionSettingDto()
                {
                    SettingKey = "UpdateDate",
                    SettingValue = string.Format("BackupFiles_{0}-{1}", DateTime.Now.ToPersianDate(), DateTime.Now.ToShortTimeString())
                });
                versionSettingDtos.Add(new VersionSettingDto()
                {
                    SettingKey = "UpdateStatus",
                    SettingValue = "1"
                }) ;
                versionSettingController.SaveList(DataStructure.FormAction.Edit, versionSettingDtos);

                //Start app
            }
            catch (Exception ex)
            {
                CreateLog(string.Format("خطا در دریافت اطلاعات از سرور.لطفا مجددا تلاش نمایید.{0}{1}", Environment.NewLine, ex.Message));
                List<VersionSettingDto> versionSettingDtos = new List<VersionSettingDto>();
                versionSettingDtos.Add(new VersionSettingDto()
                {
                    SettingKey = "UpdateStatus",
                    SettingValue = "0"
                });
                versionSettingController.SaveList(DataStructure.FormAction.Edit, versionSettingDtos);
            }
            finally
            {
                ShareFolder("Debug", Application.StartupPath);
                CreateLog("فایلهای برنامه در دسترس قرار گرفت.");
                //database multiple user
                dataAccess.MakeDtatabaseMulti(AutoUpdateStats, AutoUpdateStatsAsync);
                btnExit.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
