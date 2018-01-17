using _4fitter.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _4fitter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public Thread emailSender = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            emailSender = new Thread(new ThreadStart(RunEmailSender));
            emailSender.Start();
        }

        private void RunEmailSender()
        {
            // Always keep running.
            while (true)
            {
                Thread.Sleep(6000);
                try
                {
                    SendEmails();
                }
                catch (Exception ex)
                {
                    // Log any exceptions here
                    Console.WriteLine("Something bad happened");
                }
            }
        }

        private void SendEmails()
        {
            var fromaddr = "4fitter.app@gmail.com";
            var toaddr = "x@gmail.com";

            MailMessage mail = new MailMessage();
            mail.Subject = "Test";
            mail.Body = "blah";
            mail.To.Add(toaddr);
            mail.From = new MailAddress(fromaddr);

            //var smtpHost = ConfigurationManager.AppSettings["smtphost"];
            //var port = Convert.ToUInt32(ConfigurationManager.AppSettings["port"]);
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                var nc = new NetworkCredential(fromaddr, "4fitter_pass");
                client.Credentials = nc;

                try
                {
                    client.Send(mail);
                }
                catch (SmtpException smtpEx)
                {
                    //write logging code here and capture smtpEx.Message
                    Console.WriteLine("Something bad happened");
                }
            }
        }
    }
}
