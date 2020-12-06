using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool IsSSL)
        {
            return new DebugMailSender(Server, Port, IsSSL);
        }
    }

    public class DebugMailSender : IMailSender
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public DebugMailSender(string address, int port, bool isSSL)
        {
            Address = address;
            Port = port;
            IsSSL = isSSL;
        }

        public void Send(string from, string recipient, string subject, string body, string login, string password)
        {
            Debug.WriteLine($"Send from={from} to={recipient}");
            Debug.WriteLine($"Subject={subject}");
            Debug.WriteLine($"Body={body}");
        }
    }
}
