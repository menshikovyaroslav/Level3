using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Email
    {
        public Server server { get; set; }
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        public Message message { get; set; }
        public DateTime time { get; set; }
        public bool isSended { get; set; }
    }
}
