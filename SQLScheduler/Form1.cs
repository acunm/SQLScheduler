using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace SQLScheduler
{
    public partial class Form1 : Form
    {
        private Connect connect;
        private MenuItem newJob;
        private MenuItem editServer;
        private MenuItem delete;
        private List<Server> serverList = new List<Server>();
        private SqlConnection sqlConnection;
        private FileSystemWatcher fileSystemWatcher;
        private string jobsName;
        private TreeNode item;
        private ListViewItem selectedItem;

        public Form1()
        {
            InitializeComponent();
            getSavedData();
            setupWatcher();

        }

        private void setupWatcher()
        {
            try
            {

                Console.WriteLine("setupWatcher");

                fileSystemWatcher = new FileSystemWatcher();

                fileSystemWatcher.Path = @"C:\SQLScheduler\";
                fileSystemWatcher.Filter = "*-jobs.json";
                fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileSystemWatcher.Changed += new FileSystemEventHandler((o, e) => { FillJobs(e.Name); });
                fileSystemWatcher.EnableRaisingEvents = true;

            } catch(ArgumentException e)
            {

            }
        }

        private void listDatabase_LeftClick(object sender, TreeViewEventArgs e)
        {
            item = (TreeNode)((TreeView)sender).SelectedNode;
            if (item.Level == 0) {

                FillJobs(item.Text.Split(':')[0] + "-jobs.json");

            }
        }

        private void listDatabase_RightClick(object sender, TreeNodeMouseClickEventArgs e) {

            var item = e.Node;
            listDatabase.SelectedNode = e.Node;

            if(item.Level == 0)
            {
                if (e.Button == MouseButtons.Right)
                {


                    ContextMenu contextMenu = new ContextMenu();

                    newJob = new MenuItem();
                    newJob.Text = "New Job...";
                    contextMenu.MenuItems.Add(newJob);

                    newJob.Click += new System.EventHandler(this.newJobClick);

                    editServer = new MenuItem();
                    editServer.Text = "Edit Server...";
                    contextMenu.MenuItems.Add(editServer);

                    editServer.Click += new System.EventHandler(this.editServerClick);

                    delete = new MenuItem();
                    delete.Text = "Delete...";
                    contextMenu.MenuItems.Add(delete);

                    delete.Click += new System.EventHandler(this.deleteClick);

                    contextMenu.Show(listDatabase, e.Location);
                }
            }

        }

        private void newJobClick(object sender, EventArgs e)
        {

            Server server = null;

            foreach(Server x in serverList)
            {
                if (x.ip.Equals(item.Text.Split(':')[0]) && x.port.Equals(item.Text.Split(':')[1]))
                    server = x;
            }

            if(server != null)
            {
                Form3 form3 = new Form3(server, sqlConnection, this, null);
                form3.Show();
            }

        }

        private void editServerClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(listDatabase.SelectedNode.Text);
            form2.Show();
        }

        private void deleteClick(object sender, EventArgs e)
        {

            deleteSavedData(listDatabase.SelectedNode.Text);

        }

        private void newServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Location = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
            form2.Show();
        }

        public Boolean fillDatabase(TreeNode nodes) { 
            
            if (nodes.GetNodeCount(true) != 0)
            {
                listDatabase.Nodes.Add(nodes);
                return true;
            }
            else
                return false;

        }

        public void FillJobs(string name)
        {

            jobsName = name;

            string path = @"C:\SQLScheduler\" + name;

            if (scheduledJobs.InvokeRequired)
            {
                scheduledJobs.Invoke(new MethodInvoker(delegate { scheduledJobs.Items.Clear(); }));
            }
            else {
                scheduledJobs.Items.Clear();
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (File.Exists(path))
                {
                    Console.WriteLine(path);
                    List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(System.IO.File.ReadAllText(path));
                    if (jobs.Count > 0)
                    {

                        Console.WriteLine("jobs.count > 0");

                        foreach (Job j in jobs)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = j.getName();
                            item.SubItems.Add(j.getEnabled().ToString());
                            item.SubItems.Add(j.getLastExecute().ToString());
                            item.SubItems.Add(j.getNextExecute().ToString());

                            if (scheduledJobs.InvokeRequired)
                            {
                                scheduledJobs.Invoke(new MethodInvoker(delegate { scheduledJobs.Items.Add(item); }));
                            }
                            else
                            {
                                scheduledJobs.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public void scheduledJobs_RightClick(Object sender, MouseEventArgs args) {

            selectedItem = scheduledJobs.GetItemAt(args.X, args.Y);

            if(selectedItem != null)
            {
                if (args.Button == System.Windows.Forms.MouseButtons.Right)
                {

                    ContextMenu contextMenu = new ContextMenu();

                    editServer = new MenuItem();
                    editServer.Text = "Edit Job";
                    contextMenu.MenuItems.Add(editServer);

                    editServer.Click += new System.EventHandler(this.editJobClick);

                    delete = new MenuItem();
                    delete.Text = "Delete";
                    contextMenu.MenuItems.Add(delete);

                    delete.Click += new System.EventHandler(this.deleteJobClick);

                    contextMenu.Show(scheduledJobs, args.Location);

                }
            }

            

        }

        private void deleteJobClick(Object sender, EventArgs e) {

            string path = @"C:\SQLScheduler\" + item.Text.Split(':')[0] + "-jobs.json";

            string jobName = selectedItem.Text;

            if (File.Exists(path)) {

                List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(System.IO.File.ReadAllText(path));

                try
                {
                    foreach (Job j in jobs)
                    {
                        if (j.getName().Equals(jobName))
                        {

                            if (scheduledJobs.InvokeRequired)
                            {
                                scheduledJobs.Invoke(new MethodInvoker(delegate { jobs.Remove(j); }));
                            }
                            else
                            {
                                jobs.Remove(j);
                            }

                        }
                    }
                } catch(InvalidOperationException x)
                {

                }

                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(jobs, Formatting.Indented));

            }

        }

        private void editJobClick(Object sender, EventArgs e) {

            Server server = null;

            foreach (Server x in serverList)
            {
                if (x.ip.Equals(item.Text.Split(':')[0]) && x.port.Equals(item.Text.Split(':')[1]))
                    server = x;
            }

            Form3 form3 = new Form3(server, GetSqlConnection(), this, getJob(scheduledJobs.SelectedItems[0].Text));
            form3.Show();

            

        }

        private Job getJob(string name)
        {

            string path = @"C:\SQLScheduler\" + jobsName;
            Job job;

            if (File.Exists(path))
            {

                List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(System.IO.File.ReadAllText(path));

                foreach (Job x in jobs) {
                    if (x.getName().Equals(name))
                    {
                        job = x;
                        return job;
                    }
                }

            }
            return null;
        }

        private void getSavedData() {

            string path = @"C:\SQLScheduler\databases.json";

            connect = new Connect(this);

            if (File.Exists(path)) {
                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path));
                
                foreach(Server x in servers)
                {
                    string connString = x.buildConnString();
                    connect.connectDB(connString);
                    serverList.Add(x);
                    Thread.Sleep(2000);
                }

            }

        }

        private Boolean deleteSavedData(string ipAndPort) {

            string path = @"C:\SQLScheduler\databases.json";
            string ip = ipAndPort.Split(':')[0];
            string port = ipAndPort.Split(':')[1];
    
            if (File.Exists(path)) {

                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path));
                List<Server> newServers = new List<Server>();

                foreach(Server x in servers)
                {

                    if (!(x.ip.Equals(ip) && x.port.Equals(port)))
                    {
                        newServers.Add(x);
                    }

                }

                System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(newServers, Formatting.Indented));
                TreeNode node = listDatabase.SelectedNode;

                listDatabase.Nodes.Remove(node);

                return true;
            }

            return false;
        }

        public void setSqlConnection(SqlConnection connection)
        {
            sqlConnection = connection;
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }

    }
}