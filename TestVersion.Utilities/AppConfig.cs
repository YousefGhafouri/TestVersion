using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVersion.Utilities
{
    public static class AppConfig
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Conn1"].ConnectionString;
    }
}
