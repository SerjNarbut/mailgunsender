using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.MailSenders
{
    public class HttpMailSender : IMailSender
    {
        protected RestClient client;
        public RestClient Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        public string Domain { get; set; }

        public void SendMail(Models.BaseMail mail)
        {
            client.Execute(CreateMessage(mail));
        }

        protected virtual RestRequest CreateMessage(Models.BaseMail mail)
        {
            RestRequest request = new RestRequest();
            request.AddParameter("domain", Domain, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            if (!String.IsNullOrEmpty(mail.From))
            {
                request.AddParameter("from", mail.From);
            }
            if (!String.IsNullOrEmpty(mail.To))
            {
                request.AddParameter("to", mail.To);
            }
            if (!String.IsNullOrEmpty(mail.Bcc))
            {
                request.AddParameter("bcc", mail.Bcc);
            }
            if (!String.IsNullOrEmpty(mail.Subject))
            {
                request.AddParameter("subject", mail.Subject);
            }
            if (mail.IsHtml)
            {
                request.AddParameter("html", mail.GetBody());
            }
            else
            {
                request.AddParameter("text", mail.GetBody());
            }
            request.Method = Method.POST;
            return request;
        }
    }
}
