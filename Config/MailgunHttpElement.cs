using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Config
{
    public class MailgunHttpElement : ConfigurationElement
    {
        [ConfigurationProperty("domain", IsRequired=true)]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("key", IsRequired = true)]
        public string ApiKey
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

    }
}
