using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailgunSender.Errors
{
    public class UnknowMessengerType : Exception
    {
        public UnknowMessengerType(string wrongType, string types) :  base(String.Format("Unknow messenger type: {0}. Supports only {1}", wrongType, types))
        {
           
        }
    }
}
