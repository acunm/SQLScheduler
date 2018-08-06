using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SQLScheduler
{
    public partial class Form3 : Form
    {
        private Server server;
        private SqlCommand cmd = new SqlCommand();
        private SqlConnection sqlConnection;
        private Form1 form;
        private DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
        

        public Form3(Server server, SqlConnection sqlConnection, Form1 form, Job job)
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

            buttonColumn.Name = "Delete";
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Text = "Delete";

            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(1, buttonColumn);

            for (int i = 0; i < 24; i++)
            {
                hourBox.Items.Add(i.ToString("00"));
            }

            if (job != null) {
                sqlcommand.Text = job.getSqlQuery();
                descriptionBox.Text = job.getDescription();
                nameBox.Text = job.getName();

                if (job.getOneTime())
                {
                    onetime.Checked = true;
                }
                else
                {
                    recurrent.Checked = true;
                    timeupanddown.Value = job.getRecurringTime();
                    timeBox.SelectedItem = job.getRecurringPeriod();
                    startDate.Value = job.getStartingTime();
                    endDate.Value = job.getEndingTime();
                    
                    foreach(string x in job.getRecipients())
                    {
                        dataGridView1.Rows.Add(x);
                    }

                    string[] lines = System.IO.File.ReadAllLines(@"C:\SQLScheduler\logs.txt");

                    foreach(string x in lines)
                    {
                        if (x.Contains(job.getIp()))
                            logBox.AppendText(x + "\n");
                    }
                    
                    
                }
                
            }

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
                        job.setIp(server.ip);
                        job.setPort(server.port);

                        List<string> recipients = new List<string>();

                        foreach(DataGridViewRow x in dataGridView1.Rows)
                        {
                            if (x.Cells[0].Value != null)
                                if(!recipients.Contains(x.Cells[0].Value as string))
                                    recipients.Add(x.Cells[0].Value as string);
                        }
                        

                        if(recipients.Count > 0)
                            job.setRecipients(recipients);

                        if (string.IsNullOrEmpty(sqlcommand.Text))
                            job.setSqlQuery(sqlcommand.Text);

                        createTask(job, server.ip);
                        this.Dispose();
                    }

                }
                else
                {
                    job.setOneTime(false);

                    if (timeBox.SelectedItem.ToString().Equals("Daily")) {

                        if ((int)timeupanddown.Value >= 25 || (int)timeupanddown.Value <= 0) {
                            MessageBox.Show("Must be between 0-24");
                            timeupanddown.Focus();
                        } else
                        {
                            job.setRecurringTime((int)timeupanddown.Value);
                            job.setNextExecute(DateTime.Now.AddHours(24 / (int)timeupanddown.Value));
                            job.setLastExecute(DateTime.Now);
                            job.setRecurringPeriod(timeBox.Text);

                        }

                    } else if (timeBox.SelectedItem.ToString().Equals("Weekly"))
                    {

                        if((int)timeupanddown.Value <= 0 || (int)timeupanddown.Value >= 8)
                        {
                            MessageBox.Show("Must be between 0-7");
                            timeupanddown.Focus();
                        } else
                        {
                            job.setRecurringTime((int)timeupanddown.Value);
                            job.setNextExecute(DateTime.Now.AddDays(7 / (int) timeupanddown.Value));
                            job.setLastExecute(DateTime.Now);
                            job.setRecurringPeriod(timeBox.Text);

                        }

                    } else if (timeBox.SelectedItem.ToString().Equals("Monthly"))
                    {

                        if((int)timeupanddown.Value <= 0 || (int)timeupanddown.Value >= 31)
                        {
                            MessageBox.Show("Must be between 0-30");
                            timeupanddown.Focus();
                        }
                        else
                        {
                            job.setRecurringTime((int)timeupanddown.Value);
                            job.setNextExecute(DateTime.Now.AddDays(30 / (int)timeupanddown.Value));
                            job.setLastExecute(DateTime.Now);
                            job.setRecurringPeriod(timeBox.Text);
                        }

                    } else
                    {
                        MessageBox.Show("Error with timebox");
                    }

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
                        job.setIp(server.ip);
                        job.setPort(server.port);

                        List<string> recipients = new List<string>();

                        foreach (DataGridViewRow x in dataGridView1.Rows)
                        {
                            if(x.Cells[0].Value != null)
                                if (!recipients.Contains(x.Cells[0].Value as string))
                                    recipients.Add(x.Cells[0].Value as string);
                        }

                        if (recipients.Count > 0)
                            job.setRecipients(recipients);

                        if (string.IsNullOrEmpty(sqlcommand.Text))
                            job.setSqlQuery(sqlcommand.Text);

                        createTask(job, server.ip);
                        this.Dispose();
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Name shouldn't be empty!", "Missing field");
            }

        }

        private void createTask(Job job, string serverName)
        {
            string path = @"C:\SQLScheduler\" + serverName + "-jobs.json";

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
                List<Job> newJobList = new List<Job>();

                foreach (Job j in jobList)
                {
                    if (j.getName().Equals(job.getName()))
                        Console.WriteLine("hello");
                    else
                        newJobList.Add(j);
                }

                if (save)
                {
                    newJobList.Add(job);
                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(newJobList, Formatting.Indented));
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
