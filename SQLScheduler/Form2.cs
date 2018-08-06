using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQLScheduler
{
    public partial class Form2 : Form
    {
        private Connect connect;
        private Form1 form1;

        public Form2(Form form)
        {
            InitializeComponent();
            form1 = (Form1)form;
            
        }

        public Form2(string ipAndPort){

            InitializeComponent();
            hostnameBox.Text = ipAndPort.Trim();
            hostnameBox.ReadOnly = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (passwordHide.Checked)
                passwordBox.PasswordChar = '\0';
            else
                passwordBox.PasswordChar = 'x';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hostnameBox.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(usernameBox.Text) ||
                string.IsNullOrWhiteSpace(passwordBox.Text))
                {
                    MessageBox.Show("None of them can be empty.", "Error");
                }
                else
                {
                    changeSavedData(hostnameBox.Text);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(usernameBox.Text) ||
                string.IsNullOrWhiteSpace(passwordBox.Text) ||
                string.IsNullOrWhiteSpace(hostnameBox.Text))
                {
                    MessageBox.Show("None of them can be empty.", "Error");
                }
                else
                {
                    if (checkIpAndPort(hostnameBox.Text))
                    {

                        string ip = hostnameBox.Text.Split(':')[0];
                        string port = hostnameBox.Text.Split(':')[1];
                        string username = usernameBox.Text;
                        string password = passwordBox.Text;

                        Server server = new Server(ip, port, username, password);
                        string connectionString = server.buildConnString();

                        connect = new Connect(form1);

                        if (saveInfo(server))
                        {
                            if (connect.connectDB(connectionString))
                            {
                                this.Dispose();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Host may be wrong.", "Error");

                }
            }
        }

        private Boolean checkIpAndPort(string text) {

            Regex regStr = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$");

            return regStr.IsMatch(text);

        }

        private Boolean saveInfo(Server server)
        {

            string path = @"C:\";

            DirectoryInfo di = Directory.CreateDirectory(path + @"\SQLScheduler");

            if (!File.Exists(path + @"\SQLScheduler\databases.json"))
            {

                List<Server> servers = new List<Server>();
                servers.Add(server);

                System.IO.File.WriteAllText(path + @"\SQLScheduler\databases.json", JsonConvert.SerializeObject(servers, Formatting.Indented));
                return true;
            }
            else
            {

                List<Server> serv = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path + @"\SQLScheduler\databases.json"));
                Boolean save = true;

                foreach (Server x in serv)
                {

                    if (x.ip.Equals(server.ip) && x.port.Equals(server.port))
                        save = false;

                }
                if (save)
                {
                    serv.Add(server);
                    System.IO.File.WriteAllText(path + @"\SQLScheduler\databases.json", JsonConvert.SerializeObject(serv, Formatting.Indented));
                    return true;
                }
            }
            return false;
        }

        private Boolean changeSavedData(string ipAndPort)
        {

            string path = @"C:\SQLScheduler\databases.json";
            string ip = ipAndPort.Split(':')[0];
            string port = ipAndPort.Split(':')[1];

            if (File.Exists(path))
            {

                List<Server> servers = JsonConvert.DeserializeObject<List<Server>>(System.IO.File.ReadAllText(path));
                List<Server> newServers = new List<Server>();

                foreach (Server x in servers)
                {

                    if (x.ip.Equals(ip) && x.port.Equals(port))
                    {
                        Server server = new Server(ip, port, usernameBox.Text, passwordBox.Text);
                        newServers.Add(server);
                    }
                    else
                    {
                        newServers.Add(x);
                    }

                    System.IO.File.WriteAllText(path, JsonConvert.SerializeObject(newServers, Formatting.Indented));
                    this.Dispose();
                    return true;

                }

            }
                return false;
        }

    }
}
