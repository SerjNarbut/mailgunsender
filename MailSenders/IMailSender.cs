using MailgunSender.Models;
using System;
namespace MailgunSender.MailSenders
{
    public interface IMailSender
    {
        void SendMail(BaseMail mail);
    }
}
