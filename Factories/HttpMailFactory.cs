using MailgunSender.MailSenders;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Factories
{
    public class HttpMailFactory : IMailFactory
    {
        public string Domain { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }

        public MailSenders.IMailSender CreateSender()
        {
            HttpMailSender sender = new HttpMailSender();
            var client = new RestClient();
            client.BaseUrl = new Uri(Url);
            client.Authenticator = new HttpBasicAuthenticator("api", ApiKey);
            sender.Client = client;
            sender.Domain = Domain;
            return sender;
        }
    }
}
