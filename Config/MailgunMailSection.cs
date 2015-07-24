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

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("smtp")]
        public MailgunSmtpElement Smtp
        {
            get { return (MailgunSmtpElement)this["smtp"]; }
            set { this["smtp"] = value; }
        }

        [ConfigurationProperty("http")]
        public MailgunHttpElement Http
        {
            get { return (MailgunHttpElement)this["http"]; }
            set { this["http"] = value; }
        }
    }
}
