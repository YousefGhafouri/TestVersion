using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.DataAccess
{
    public class UpdateManager
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn1"].ConnectionString);


        public void ExecuteCommand()
        {

        }
    }
}
