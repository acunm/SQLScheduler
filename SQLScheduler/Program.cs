using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLScheduler
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            try
            {
                ServiceBase[] serviceBases = new ServiceBase[] { new SQLSchedulerService() };
                ServiceBase.Run(serviceBases);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }
}
