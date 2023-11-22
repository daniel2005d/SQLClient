using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClient
{
    internal class DBClient
    {
        private Options _options;
        internal DBClient(Options options)
        {
            this._options = options;
        }

        internal DataTable Run()
        {
            if (this._options.Command.ToLower().StartsWith("select"))
            {
                return this.Select();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Result");
                using (SqlConnection oConnect = new SqlConnection(this.ConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand(this._options.Command, oConnect))
                    {
                        oConnect.Open();

                        int affected = cmd.ExecuteNonQuery();
                        dt.Rows.Add(affected);
                    }
                }

                return dt;
            }
        }


        internal DataTable Select()
        {
            DataSet ds = new DataSet();
            using (SqlConnection oConnect = new SqlConnection(this.ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(this._options.Command, oConnect))
                {
                    adapter.Fill(ds);
                }
            }

            return ds.Tables[0];
        }

        private string ConnectionString
        {
            get
            {
                string connectionString = string.Empty;
                if (this._options.UserName == null && this._options.Password == null)
                {
                    connectionString = $"Server={this._options.Server};Database={this._options.Database};Trusted_Connection=True;";
                }
                else
                {
                    connectionString = $"Server={this._options.Server};Database={this._options.Database};User Id={this._options.UserName};Password={this._options.Password};";
                }

                return connectionString;
            }
        }


    }
}

