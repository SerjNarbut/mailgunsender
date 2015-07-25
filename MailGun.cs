using MailgunSender.Config;
using MailgunSender.Errors;
using MailgunSender.Factories;
using MailgunSender.MailSenders;
using MailgunSender.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender
{
    public static class MailGun
    {
        private static MailgunMailSection Config { get; set; }

        public static FactoryType Type { get; private set; }

        public static IMailFactory Factory { get; private set; }

        public static void Configure()
        {
            Config = ConfigurationManager.GetSection("mailgun") as MailgunMailSection;
            if (Config.Type.ToLower().Equals("smtp"))
            {
                Type = FactoryType.Smtp;
            }
            else if (Config.Type.ToLower().Equals("http"))
            {
                Type = FactoryType.Http;
            }
            else
            {
                throw new UnknowMessengerType(Config.Type);
            }


            if (Type == FactoryType.Smtp)
            {
                SmtpMailFactory factory = new SmtpMailFactory();
                factory.Host = Config.Smtp.Host;
                factory.Port = Config.Smtp.Port;
                factory.Login = Config.Smtp.Login;
                factory.Password = Config.Smtp.Password;
                Factory = factory;
            }
            else if (Type == FactoryType.Http)
            {
                HttpMailFactory factory = new HttpMailFactory();
                factory.ApiKey = Config.Http.ApiKey;
                factory.Domain = Config.Http.Domain;
                factory.Url = Config.Http.Url;
                Factory = factory;
            }

        }

        public static IMailSender GetSender()
        {
            return Factory.CreateSender();
        }
    }
}
