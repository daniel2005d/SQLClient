using System;
using System.Collections.Generic;
using System.Data;
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
                DBClient client = new DBClient(opt);
                DataTable dtvalues = client.Run();
                PrintDataTable(dtvalues);
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
                Console.WriteLine(Options.Help());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintDataTable(DataTable dataTable)
        {
            // Print column headers
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write($"{column.ColumnName,-15} | ");
            }

            Console.WriteLine();

            // Print separator line
            Console.WriteLine(new string('-', 33));

            // Print data
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15} | ");
                }

                Console.WriteLine();
            }
        }
    }
}
