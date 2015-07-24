using MailgunSender.MailSenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Factories
{
    public interface IMailFactory
    {
        IMailSender CreateSender();
    }
}
