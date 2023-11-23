using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                ParserArguments arguments = new ParserArguments();
                Options opt = arguments.GetArgs(args);
                if (opt.PrintHelp)
                {
                    ConsoleExtension.WriteLine(Options.Help());
                    Console.WriteLine("\nBuilt-in Commands:");
                    foreach(DictionaryEntry k in arguments.GetCommands())
                    {
                        ConsoleExtension.WriteLine($"[+] {k.Key.ToString()}");
                    }
                    Console.WriteLine();
                    ConsoleExtension.WriteLine("> SQLClient.exe arguments command\n");
                }
                else
                {
                    DBClient client = new DBClient(opt);
                    DataSet ds = client.Run();
                    foreach (DataTable dt in ds.Tables)
                    {
                        ConsoleExtension.WriteLine(new string('=', 40));
                        PrintDataTable(dt);
                        ConsoleExtension.WriteLine(new string('=', 40));
                    }
                }
                
                
            }
            catch (ArgumentException ax)
            {
                ConsoleExtension.WriteLine(Options.Help());
                ConsoleExtension.WriteLine(ax.Message);
            }
            catch (Exception ex)
            {
                ConsoleExtension.WriteLine($"[red]{ex.Message}[end]");
            }

            if (Debugger.IsAttached)
            {
                Console.ReadLine();
            }
        }

        static void PrintDataTable(DataTable dataTable)
        {

            ConsoleExtension.WriteLine($"[green]Table:[white]{dataTable.TableName}[end]");
            // Print column headers
            foreach (DataColumn column in dataTable.Columns)
            {
                ConsoleExtension.Write($"{column.ColumnName,-15} | ");
            }

            Console.WriteLine();

            // Print separator line
            ConsoleExtension.WriteLine(new string('-', 40));

            // Print data
            int odd = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                string color = "";
                if (odd % 2 == 0)
                {
                    color = "[cyan]";
                }
                

                foreach (var item in row.ItemArray)
                {
                    ConsoleExtension.Write($"{color}{item,-15} | [end]");
                }

                Console.WriteLine( );
                odd++;
            }
        }
    }
}
