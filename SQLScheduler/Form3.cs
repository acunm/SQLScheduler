using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLScheduler
{
    public partial class Form3 : Form
    {
        private Server server;
        private SqlCommand cmd = new SqlCommand();
        private SqlConnection sqlConnection;
        private Form1 form;

        public Form3(Server server, SqlConnection sqlConnection, Form1 form)
        {
            InitializeComponent();
            this.server = server;
            this.form = form;
            textBox1.Text = server.ip + ":" + server.port;
            textBox4.Text = server.username;
            textBox5.Text = server.password;
            timeBox.Items.Add("Daily");
            timeBox.Items.Add("Weekly");
            timeBox.Items.Add("Monthly");
            timeBox.SelectedItem = "Daily";

        }

        private void syntaxcheck_Click(object sender, EventArgs e)
        {

            string queryString = sqlcommand.Text;
            string connectionString = server.buildConnString();

            sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
            sqlConnection.Open();
            try
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                try
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader[0]);
                    }
                    MessageBox.Show("Query seems okay.", "Everything is fine!");
                }
                finally
                {
                    sqlDataReader.Close();
                }

            } catch(SqlException a)
            {
                MessageBox.Show(a.Message, "Error");
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Job job = new Job();

            if (!string.IsNullOrEmpty(nameBox.Text))
            {

                job.setName(nameBox.Text);

                if (onetime.Checked)
                {
                    job.setOneTime(true);
                    job.setRecurringTime(0);
                    job.setRecurringPeriod("");
                    job.setEnabled(true);
                    if (DateTime.Compare(DateTime.Now, endDate.Value) > 0)
                    {
                        MessageBox.Show("End date can not be in past.");
                    }
                    else
                    {
                        startDate.Value = DateTime.Now;
                        job.setEndingTime(endDate.Value);
                        job.setStartingTime(startDate.Value);
                        job.setEnabled(true);
                        job.setSqlQuery(sqlcommand.Text);
                        job.setDescription(descriptionBox.Text);

                        if (string.IsNullOrEmpty(sqlcommand.Text))
                            job.setSqlQuery(sqlcommand.Text);

                        createTask(job, server.ip);
                        this.Dispose();
                    }

                }
                else
                {
                    job.setOneTime(false);
                    job.setRecurringTime((int)timeupanddown.Value);
                    job.setLastExecute(DateTime.Now);
                    job.setNextExecute(DateTime.Now.AddSeconds(36000));
                    if (!string.IsNullOrEmpty(timeBox.Text))
                    {

                        job.setRecurringPeriod(timeBox.Text);

                        if (DateTime.Compare(DateTime.Now, endDate.Value) > 0)
                        {
                            MessageBox.Show("End date can not be in past.");
                        }
                        else {
                            startDate.Value = DateTime.Now;
                            job.setEndingTime(endDate.Value);
                            job.setStartingTime(startDate.Value);
                            job.setEnabled(true);
                            job.setSqlQuery(sqlcommand.Text);
                            job.setDescription(descriptionBox.Text);

                            if(string.IsNullOrEmpty(sqlcommand.Text))
                                job.setSqlQuery(sqlcommand.Text);

                            createTask(job, server.ip);
                            this.Dispose();
                        }

                    }
                    else
                        MessageBox.Show("Please select time period.");
                }

            }
            else
            {
                MessageBox.Show("Name shouldn't be empty!", "Missing field");
            }

        }

        private void createTask(Job job, string serverName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += @"\SQLScheduler\" + serverName + "-jobs.json";

            if (!File.Exists(path))
            {
                List<Job> jobs = new List<Job>();
                jobs.Add(job);
                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(jobs, Formatting.Indented));
            }
            else
            {
                List<Job> jobList = JsonConvert.DeserializeObject<List<Job>>(System.IO.File.ReadAllText(path));
                Boolean save = true;

                foreach (Job j in jobList)
                {
                    if (j.getName().Equals(job.getName()))
                        save = false;
                }

                if (save)
                {
                    jobList.Add(job);
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(jobList, Formatting.Indented));
                }
            }

        }

        private void recurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                timeupanddown.Enabled = true;
                timeBox.Enabled = true;
            }
            else
            {
                timeupanddown.Enabled = false;
                timeBox.Enabled = false;
            }
        }
    }
}
