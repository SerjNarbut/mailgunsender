using MailgunSender.Models;
using System;
namespace MailgunSender
{
    public interface IMailSender
    {
        void SendMail(BaseMail mail);
    }
}
