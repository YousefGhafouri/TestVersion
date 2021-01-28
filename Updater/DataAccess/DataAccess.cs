using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater.DataAccess
{
    public class DataAccess
    {
        SqlConnection sqlConnection;

        public DataAccess()
        {
            sqlConnection = new SqlConnection(TestVersion.Utilities.AppConfig.ConnectionString);
        }

        private void ExecuteCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private DataTable GetDataTable(SqlCommand cmd)
        {
            try
            {
                DataTable dataTable = new DataTable();
                cmd.Connection = sqlConnection;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        public void CreateDatabaseBackup(string databaseName, string backupPath)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.DatabaseBackup";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
            cmd.Parameters.AddWithValue("@BackupFileName", backupPath);
            ExecuteCommand(cmd);
        }

        public void RestoreDatabaseBackup(string databaseName, string backupPath)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.DatabaseRestore";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
            cmd.Parameters.AddWithValue("@BackupFileName", backupPath);
            ExecuteCommand(cmd);
        }

        public DataTable MakeDatabaseSingle()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.MakeDatabaseSingle";
            cmd.CommandType = CommandType.StoredProcedure;
            return GetDataTable(cmd);
        }

        public void MakeDtatabaseMulti(bool AutoUpdateStats,bool AutoUpdateStatsAsync)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.MakeDatabaseMulti";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AutoUpdateStats", AutoUpdateStats);
            cmd.Parameters.AddWithValue("@AutoUpdateStatsAsync", AutoUpdateStatsAsync);
            ExecuteCommand(cmd);
        }
    }
}
