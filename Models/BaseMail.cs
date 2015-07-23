using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Models
{
    public abstract class BaseMail
    {
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual string Bcc { get; set; }
        public virtual string Subject { get; set; }
        public virtual bool IsHtml { get; set; }

        public abstract string GetBody();
    }
}
