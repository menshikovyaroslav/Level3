using Lesson1WPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Data
{
    public class DBclass
    {
        private EMailsDataContext emails = new EMailsDataContext();
        public IQueryable<Message> Messages
        {
            get
            {
                Table<Message> messages = emails.GetTable<Message>();
                return messages;
            }
        }
        public IQueryable<Server> Servers
        {
            get
            {
                Table<Server> servers = emails.GetTable<Server>();
                return servers;
            }
        }

        public IQueryable<Sender> Senders
        {
            get
            {
                Table<Sender> senders = emails.GetTable<Sender>();
                return senders;
            }
        }

        public IQueryable<Recipient> Recipients
        {
            get
            {
                Table<Recipient> recipients = emails.GetTable<Recipient>();
                return recipients;
            }
        }

    }
}
