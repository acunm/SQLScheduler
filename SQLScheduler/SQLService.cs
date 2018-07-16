using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SQLScheduler
{
    partial class SQLService : ServiceBase
    {
        private int eventId = 1;

        public SQLService()
        {

            InitializeComponent();
            OnStart(new string[] { });
            eventLog1.Source = "SQLScheduler";
            eventLog1.Log = "SQLScheduler";

        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 3000; // 60 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Enabled = true;
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }
    }
}
