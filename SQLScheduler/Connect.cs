using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLScheduler
{
    class Connect
    {
        
        private Form1 form1;
        private TreeNode node;
        private SqlConnection sqlConnection;

        public Connect(Form form) {
            form1 = (Form1)form;
        }


        public Boolean connectDB(string connectionString) {

            Console.WriteLine("alsdalskjdalksjd" + connectionString);

            string name = getIpFromString(connectionString);

            using (sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    form1.setSqlConnection(sqlConnection);

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM sys.databases WHERE database_id > 4", sqlConnection))
                    {

                        SqlDataReader sqlDataReader = null;

                        try
                        {
                            sqlDataReader = cmd.ExecuteReader();

                            int counter = 1;

                            node = new TreeNode(name);

                            while (sqlDataReader.Read())
                            {
                                TreeNode item = new TreeNode(sqlDataReader[0].ToString());
                                node.Nodes.Add(item);
                                counter++;
                            }

                            form1.fillDatabase(node);
                            return true;

                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show("SQL Reader error.", "Error = " + ex.Message, MessageBoxButtons.OK);
                        }

                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("While Connecting -> " + name + "\nError = " + ex.Message, "Error", MessageBoxButtons.OK);
                }

            }

            return false;

        }

        private string getIpFromString(string connectionString)
        {
            string[] necessary = connectionString.Split(';');
            return necessary[0].Substring(7, necessary[0].Length - 7).Replace(',', ':');
        }

    }
}
