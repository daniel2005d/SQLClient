using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class ParserArguments
    {
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
                    switch(option){
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
                            errormessage += $"The argument {option} is not a valid option.\n";
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
                errormessage+=$"[-] The server argument is required.\n";
            }
            if (options.Database == null)
            {
                errormessage += $"[-] The database argument is required.\n";
            }
            if (options.Command == null)
            {
                errormessage += $"[-] The command argument is required.\n";
            }

            if (!string.IsNullOrEmpty(errormessage))
            {
                throw new ArgumentException(errormessage+"\n");
            }

            return options;
        }
    }
}
