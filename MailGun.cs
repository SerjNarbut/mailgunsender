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

        public static IMailFactory Factory { get; private set; }

        private static Dictionary<string, Func<MailgunMailSection, IMailFactory>> types
            = new Dictionary<string, Func<MailgunMailSection, IMailFactory>>();

        public static void RegisterFactory(string name, Func<MailgunMailSection, IMailFactory> builder)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Factory name cannot be null");
            }
            if (builder == null)
            {
                throw new ArgumentNullException("builder for Factory canntp be null");
            }
            var key = name.ToLower();
            if (types.ContainsKey(key))
            {
                types[key] = builder;
            }
            else
            {
                types.Add(name.ToLower(), builder);
            }
        }

        public static void Configure()
        {

            RegisterFactory("smtp", c => 
            {
                SmtpMailFactory factory = new SmtpMailFactory();
                factory.Host = c.Smtp.Host;
                factory.Port = c.Smtp.Port;
                factory.Login = c.Smtp.Login;
                factory.Password = c.Smtp.Password;
                return factory;
            });

            RegisterFactory("http", c =>
            {
                HttpMailFactory factory = new HttpMailFactory();
                factory.ApiKey = c.Http.ApiKey;
                factory.Domain = c.Http.Domain;
                factory.Url = c.Http.Url;
                return factory;
            });

            Config = ConfigurationManager.GetSection("mailgun") as MailgunMailSection;

            var type = Config.Type.ToLower();

            if (!types.ContainsKey(type))
            {
                throw new UnknowMessengerType(type, String.Join(" or ", types.Keys.ToArray()));
            }

            Factory = types[Config.Type.ToLower()].Invoke(Config);
        }

        public static IMailSender GetSender()
        {
            return Factory.CreateSender();
        }
    }
}
