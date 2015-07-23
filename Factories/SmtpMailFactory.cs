using MailgunSender.Config;
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

        public SmtpMailFactory()
        {
            var config = ConfigurationManager.GetSection("mailgun") as MailgunMailSection;
            Host = config.Smtp.Host;
            Port = config.Smtp.Port;
            Login = config.Smtp.Login;
            Password = config.Smtp.Password;
        }

        public IMailSender CreateSender()
        {
            var sender = new MailSender();
            sender.Client = new System.Net.Mail.SmtpClient(Host, Port);
            sender.Client.EnableSsl = true;
            sender.Client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            sender.Client.Credentials = new NetworkCredential(Login, Password);
            return sender;
        }
    }
}
