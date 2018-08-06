using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace SQLScheduler
{
    partial class SQLService : ServiceBase
    {

        private Timer timer = new Timer();
        private Connect connect = new Connect();
        private List<Job> jobs;

        public SQLService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string path = @"C:\SQLScheduler\";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] files = directoryInfo.GetFiles("*-jobs.json");

            foreach(FileInfo file in files)
            {
                
                DateTime now = DateTime.Now;
                jobs = JsonConvert.DeserializeObject<List<Job>>(System.IO.File.ReadAllText(path + file.Name));
                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path + "databases.json"));

                Server server = getServer(servers, file.Name.Split('-')[0]);

                foreach (Job j in jobs)
                {

                    if(j.nextExecute.CompareTo(now) < 0)
                    {

                        using (SqlConnection connection = new SqlConnection(server.buildConnString())) {

                            try
                            {
                                connection.Open();

                                using (SqlCommand cmd = new SqlCommand(j.getSqlQuery(), connection)) {

                                    cmd.CommandType = System.Data.CommandType.Text;
                                    int result = cmd.ExecuteNonQuery();

                                    LoggingService.writeLog("Succeed", server.ip, "finished");
                                    LoggingService.sendMail("Success", "backed up", j.getRecipients());

                                    if (j.getRecurringPeriod().Equals("Daily")) {
                                        updateLastandNext(path + file.Name, j.getName(), DateTime.Now.AddHours(24 / j.getRecurringTime()));
                                    } else if (j.getRecurringPeriod().Equals("Weekly"))
                                    {
                                        updateLastandNext(path + file.Name, j.getName(), DateTime.Now.AddDays(7 / j.getRecurringTime()));
                                    } else if (j.getRecurringPeriod().Equals("Monthly"))
                                    {
                                        updateLastandNext(path + file.Name, j.getName(), DateTime.Now.AddDays(30 / j.getRecurringTime()));
                                    }

                                    eventLog1.WriteEntry("result = " + result);
                                }
                            }
                            catch (SqlException ex)
                            {
                                LoggingService.writeLog(ex.Message, server.ip, "Failed");
                                LoggingService.sendMail("Failed", ex.Message, j.getRecipients());
                                eventLog1.WriteEntry("Exception = " + ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }

                        }
                        
                    }

                }

            }

        }

        private Server getServer(List<Server> servers, string ip) {

            Server server = null;

            foreach(Server s in servers)
            {
                if (s.ip == ip)
                    server = s;
            }

            return server;

        }

        private void updateLastandNext(string path, string name, DateTime next) {

            List<Job> newJobs = new List<Job>();

            foreach(Job j in jobs)
            {

                if (j.getName().Equals(name))
                {

                    j.setLastExecute(DateTime.Now);
                    j.setNextExecute(next);
                    newJobs.Add(j);
                }
                else
                {
                    newJobs.Add(j);
                }

            }

            System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(newJobs, Formatting.Indented));

        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            timer.Stop();
        }
    }
}
