using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace SQLScheduler
{
    static class Program
    {
        public static object Service { get; private set; }

        [STAThread]
        static void Main()
        {
        
            ServiceBase[] serviceBases = new ServiceBase[] { new SQLService() };
            ServiceBase.Run(serviceBases);  
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }
}
