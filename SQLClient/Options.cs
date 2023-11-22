using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class Options
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string Command { get; set; }

        internal static string Help()
        {
            string help = 
                "Version\t0.1\n\n" +
                "SQlClient could be used to connect with MSSQL Databases\n\n\n" +
                "USAGE\n" +
                "SQLClient.exe --server 127.0.0.1 --database master 'select @@version'\n" +
                "SQLClient.exe --server 127.0.0.1 --database master --username sa --password 'select @@version'\n\n" +
                "--server\tThe IP Address or Hostname\n" +
                "--database\tThe database name\n"+
                "[--username]\tUsername used to connect to Microsoft SQL Server (MSSQL)\n"+
                "[--password]\tPassword used to connect to Microsoft SQL Server (MSSQL)\n"+
                "query positional argument\n\n"+
                "If the username and password are not set, it connects using Windows Credentials.";
            
            return help;
        }

    }
}
