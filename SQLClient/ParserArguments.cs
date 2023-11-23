using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class ParserArguments
    {
        private Hashtable _commands;
        internal ParserArguments()
        {
            this._commands = new Hashtable();
            this._commands.Add("version", "Select @@version");
            this._commands.Add("tables", "Select object_id, name,create_date from sys.tables");
            this._commands.Add("username", "Select user_name()");
            this._commands.Add("linkedservers", "select name,product,provider,data_source from sys.servers");
            this._commands.Add("users", "select sp.name as login, sp.type_desc as login_type, CONVERT(varchar(MAX),sl.password_hash,2) as password_hash, sp.create_date, sp.modify_date, " +
                "case when sp.is_disabled = 1 then 'Disabled' else 'Enabled' end as status from sys.server_principals sp left join sys.sql_logins sl "+
                "on sp.principal_id = sl.principal_id where sp.type not in ('G', 'R') order by sp.name;");
            this._commands.Add("myrigths", "SELECT * FROM fn_my_permissions(NULL, 'SERVER')");
            this._commands.Add("isadmin", "SELECT IS_SRVROLEMEMBER('sysadmin') as isadmin");
            this._commands.Add("enablecmd", "exec sp_configure 'show advanced options', '1';Reconfigure;exec sp_configure 'xp_cmdshell', '1';RECONFIGURE;SELECT name,value,is_advanced FROM sys.configurations WHERE name = 'xp_cmdshell';");
            this._commands.Add("disablecmd", "exec sp_configure 'show advanced options', '0';Reconfigure;exec sp_configure 'xp_cmdshell', '0';RECONFIGURE;SELECT name,value,is_advanced FROM sys.configurations WHERE name = 'xp_cmdshell';");
        }
        public Hashtable GetCommands()
        {
            return this._commands;
        }

        public Options GetArgs(string[] args)
        {
            Options options = new Options();
            string errormessage = string.Empty;
            for (int i = 0; i < args.Length; i++)
            {
                string option = args[i].ToLower();
                if (option.StartsWith("--"))
                {
                    i++;
                    switch (option)
                    {
                        case "--help":
                            options.PrintHelp = true;
                            break;
                        case "--server":
                            options.Server = args[i];
                            break;
                        case "--username":
                            options.UserName = args[i];
                            break;
                        case "--password":
                            options.Password = args[i];
                            break;
                        case "--database":
                            options.Database = args[i];
                            break;
                        default:
                            errormessage += $"[red]The argument [blue]{option} is not a valid option.\n[end]";
                            break;
                    }
                }
                else
                {
                    options.Command = args[i];
                }
            }


            if (options.Server == null)
            {
                errormessage += $"[red][-][yellow] The server argument is required.\n[end]";
            }
            if (options.Database == null)
            {
                errormessage += $"[red][-][yellow] The database argument is required.\n[end]";
            }
            if (options.Command == null)
            {
                errormessage += $"[red][-][yellow] The command argument is required.\n[end]";
            }

            if (!string.IsNullOrEmpty(errormessage))
            {
                throw new ArgumentException(errormessage + "\n");
            }

            if (this._commands.ContainsKey(options.Command))
            {
                options.Command = this._commands[options.Command].ToString();
            }

            return options;
        }

    }
}
