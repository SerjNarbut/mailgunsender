using MailgunSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.MailSenders
{
    public class SmtpMailSender : IMailSender
    {
        protected SmtpClient client;

        public SmtpClient Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        public virtual void SendMail(BaseMail mail)
        {
            var m = CreateMessage(mail);
            client.Send(m);
        }

        protected virtual MailMessage CreateMessage(BaseMail mailInfo)
        {
            MailMessage mail = new MailMessage();
            mail.BodyEncoding = Encoding.UTF8;
            mail.Subject = mailInfo.Subject;
            mail.IsBodyHtml = mailInfo.IsHtml;

            if (!String.IsNullOrEmpty(mailInfo.From))
            {
                mail.From = new MailAddress(mailInfo.From);
            }
            if (!String.IsNullOrEmpty(mailInfo.To))
            {
                mail.To.Add(new MailAddress(mailInfo.To));
            }
            if (!String.IsNullOrEmpty(mailInfo.Bcc))
            {
                mail.Bcc.Add(new MailAddress(mailInfo.Bcc));
            }

            mail.Body = mailInfo.GetBody();
            return mail;
        }
    }
}
