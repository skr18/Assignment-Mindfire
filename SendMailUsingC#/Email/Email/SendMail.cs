/*using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("mfsi.sujeetr@gmail.com");
        mailMessage.To.Add("mfsi.aniket@gmail.com");
        mailMessage.Subject = "Subject";
        mailMessage.Body = "This is test email from the greate sujeet with +ifinite score";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 25;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("mfsi.sujeetr@gmail.com", "Mindfire@212");
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        try
        {
            smtpClient.Send(mailMessage);
            Console.WriteLine("Email Sent Successfully.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.ReadLine();
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("c7b5496977dcf4", "812aa415ce43e7"),
                EnableSsl = true
            };
            client.Send("mfsi.sujeetr@gmail.com", "mfsi.aniket@gmail.com", "Hello world", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
        }
    }
}