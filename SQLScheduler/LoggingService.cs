using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace SQLScheduler
{
    static class LoggingService
    {

        static string path = @"C:\SQLScheduler\";

        public static void writeLog(string text, string database, string result) {

            if (createFile())
                System.IO.File.AppendAllText(path + "logs.txt", DateTime.Now.ToString("dd-MM-yyyy_HH:mm")
                    + "\tDatabase Name: " + database
                    + "\tresult = " + result + " => " + text + "\n");

        }

        public static void sendMail(string sub, string body, List<string> to) {

            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            NetworkCredential credentials = new NetworkCredential("", "");
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {

                var mail = new MailMessage();

                foreach (var address in to)
                {
                    mail.To.Add(address);
                }

                mail.From = new MailAddress("ronsqlscheduler@outlook.com");

                mail.Subject = sub;
                mail.Body = body;
                client.Send(mail);
            }
            catch (Exception ex)
            {
            }


        }


        public static Boolean createFile()
        {

            if(File.Exists(path + "logs.txt"))
            {
                return true;
            }
            else
            {
                File.Create(path + "logs.txt");
                return true;
            }

        }

    }
}
