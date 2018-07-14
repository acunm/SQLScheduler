using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace SQLScheduler
{
    partial class SQLSchedulerService : ServiceBase
    {
        
        private System.Diagnostics.EventLog eventLog;
        private int eventId = 1;

        public SQLSchedulerService()
        {

            InitializeComponent();

            eventLog1 = new EventLog();

            if (!System.Diagnostics.EventLog.SourceExists("SQLScheduler"))
            {
                System.Diagnostics.EventLog.CreateEventSource("SQLScheduler", "SQLScheduler");
            }

            eventLog1.Source = "SQLScheduler";
            eventLog1.Log = "SQLScheduler";

        }

        protected override void OnStart(string[] args)
        {

            foreach (string arg in args)
            {
                if (arg == "WAITFORDEBUGGER")
                {
                    while (!Debugger.IsAttached)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000; // 60 seconds  
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
