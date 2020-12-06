using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

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

        public void AddServer(Server server)
        {
            var record = new Servers
            {
                Address = server.Address,
                Id = server.Id,
                Port = server.Port,
                IsSSL = server.IsSSL
            };

            emails.Servers.InsertOnSubmit(record);
            emails.SubmitChanges();
        }

        public void EditServer(Server server)
        {
            var record = (from _server in emails.Servers
                       where _server.Id == server.Id
                       select _server).FirstOrDefault();
            if (record != null)
            {
                record.Address = server.Address;
                record.Port = server.Port;
                record.IsSSL = server.IsSSL;
            }

            emails.SubmitChanges();
        }

        public void AddSender(Sender sender)
        {
            var record = new Senders
            {
                Address = sender.Address,
                Id = sender.Id,
                Password = sender.Password,
                Name = sender.Name
            };

            emails.Senders.InsertOnSubmit(record);
            emails.SubmitChanges();
        }

        public void EditSender(Sender sender)
        {
            var record = (from _sender in emails.Senders
                          where _sender.Id == sender.Id
                          select _sender).FirstOrDefault();
            if (record != null)
            {
                record.Address = sender.Address;
                record.Password = sender.Password;
                record.Name = sender.Name;
            }

            emails.SubmitChanges();
        }
    }
}
