using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLScheduler
{
    public class Server
    {

        public string ip { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Server(string ip, string port, string username, string password)
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
            this.password = password;
        }

        public string buildConnString()
        {
            return "Server=" + ip + "," + port + ";" + "User ID=" + username + ";" + " Password=" + password + ";";
        }

        public string ToString() {
            return "ip=" + ip + " port=" + port + " username=" + username + " password=" + password;
        }

    }
}