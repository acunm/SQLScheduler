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
using System.Data.Sql;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.ServiceProcess;

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
                fileSystemWatcher = new FileSystemWatcher();

                fileSystemWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\SQLScheduler\";
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
            var item = (TreeNode)((TreeView)sender).SelectedNode;
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

            TreeNode node = listDatabase.SelectedNode;

            Server server = null;
            
            foreach(Server x in serverList)
            {
                if (x.ip.Equals(node.Text.Split(':')[0]) && x.port.Equals(node.Text.Split(':')[1]))
                    server = x;
            }

            Form3 form3 = new Form3(server, sqlConnection, this);
            form3.Show();

        }

        private void editServerClick(object sender, EventArgs e)
        {
            Console.WriteLine(listDatabase.SelectedNode.Text);
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
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += @"\SQLScheduler\" + name;

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

        private void getSavedData() {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            connect = new Connect(this);

            if (File.Exists(path + @"\SQLScheduler\databases.json")) {
                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path + @"\SQLScheduler\databases.json"));
                
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

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string ip = ipAndPort.Split(':')[0];
            string port = ipAndPort.Split(':')[1];

            if (File.Exists(path + @"\SQLScheduler\databases.json")) {

                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path + @"\SQLScheduler\databases.json"));
                List<Server> newServers = new List<Server>();

                foreach(Server x in servers)
                {

                    if (!(x.ip.Equals(ip) && x.port.Equals(port)))
                    {
                        newServers.Add(x);
                    }

                }

                System.IO.File.WriteAllText(path + @"\SQLScheduler\databases.json", JsonConvert.SerializeObject(newServers, Formatting.Indented));
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