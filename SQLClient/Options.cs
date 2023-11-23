using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class Options
    {
        private const double VERSION = 0.2;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string Command { get; set; }
        public bool PrintHelp { get; set; }

        internal static string Help()
        {
            string help = 
                $"Version\t{VERSION}\n\n" +
                "SQlClient could be used to connect with MSSQL Databases\n\n\n" +
                "USAGE\n" +
                "> SQLClient.exe arguments query\n" +
                "> SQLClient.exe --server 127.0.0.1 --database master 'select @@version'\n" +
                "> SQLClient.exe --server 127.0.0.1 --database master --username sa --password 'select @@version'\n\n" +
                "[!] Arguments\n" +
                "[blue]--server[end]\tThe IP Address or Hostname\n" +
                "[blue]--database[end]\tThe database name\n"+
                "[orange][--username][end]\tUsername used to connect to Microsoft SQL Server (MSSQL)[end]\n"+
                "[orange][--password][end]\tPassword used to connect to Microsoft SQL Server (MSSQL)\n\n" +
                "[cyan]Query positional argument!!\n"+
                "[yellow][!][end][cyan] Alternatively, you can utilize a custom built-in command for this purpose.\n" +
                "[yellow][!][end][cyan] Refer to the command list by using the 'help' argument\n\n" +
                "[cyan]If the username and password are not set, it connects using Windows Credentials.[end]";
            
            
            return help;
        }

    }
}
