using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Config
{
    public class MailgunMailSection : ConfigurationSection
    {
        [ConfigurationProperty("enable", IsRequired=true)]
        public bool IsEnabled
        {
            get { return (bool)this["enable"]; }
            set { this["enable"] = value; }
        }

        [ConfigurationProperty("smtp")]
        public MailgunSmtpElement Smtp
        {
            get { return (MailgunSmtpElement)this["smtp"]; }
            set { this["smtp"] = value; }
        }
    }
}
