using MailgunSender.Config;
using MailgunSender.MailSenders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Factories
{
    public class SmtpMailFactory : IMailFactory
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IMailSender CreateSender()
        {
            var sender = new SmtpMailSender();
            sender.Client = new System.Net.Mail.SmtpClient(Host, Port);
            sender.Client.EnableSsl = true;
            sender.Client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            sender.Client.Credentials = new NetworkCredential(Login, Password);
            return sender;
        }
    }
}
