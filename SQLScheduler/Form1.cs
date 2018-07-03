using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Data Source='DESKTOP-HPQ1QQU\\ACUN'; Integrated Security=True;";
            List<string> databaseNames = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try{
                    sqlConnection.Open();
                }
                catch (SqlException ex) {
                    MessageBox.Show("Sql connection error", "Error = " + ex.Message, MessageBoxButtons.OK);
                }

                 using (SqlCommand cmd = new SqlCommand("SELECT * FROM sys.databases WHERE database_id > 4", sqlConnection))
                 {

                    SqlDataReader sqlDataReader = null;
                    
                    try
                     {
                         sqlDataReader = cmd.ExecuteReader();
                     }
                     catch (InvalidOperationException ex) {
                         MessageBox.Show("SQL Reader error.", "Error = " + ex.Message, MessageBoxButtons.OK);
                     }

                     while (sqlDataReader.Read())
                     {

                        Console.WriteLine(sqlDataReader[0].ToString());

                        ListViewItem item = new ListViewItem(sqlDataReader[0].ToString());
                        listDatabase.Items.Add(item);
                     
                     }
                 }
              
            }

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("deneme", "deneme baslik?", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
