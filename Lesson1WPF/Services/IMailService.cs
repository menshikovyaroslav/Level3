using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool IsSSL);
    }

    public interface IMailSender
    {
        void Send(string from, string recipient, string subject, string body, string login, string password);
        void Send(string from, IEnumerable<string> recipients, string subject, string body, string login, string password);
        void SendParallel(string from, IEnumerable<string> recipients, string subject, string body, string login, string password);

        Task SendAsync(string from, string recipient, string subject, string body, string login, string password);
        Task SendAsync(string from, IEnumerable<string> recipients, string subject, string body, string login, string password);
    }
}
