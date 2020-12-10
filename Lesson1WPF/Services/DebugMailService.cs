using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
            var currThread = Thread.CurrentThread;
            Debug.WriteLine($"currThreadId = {currThread.ManagedThreadId}");
            Debug.WriteLine($"Send from={from} to={recipient}");
            Debug.WriteLine($"Subject={subject}");
            Debug.WriteLine($"Body={body}");
        }

        public void Send(string from, IEnumerable<string> recipients, string subject, string body, string login, string password)
        {
            foreach (var recipient in recipients)
            {
                Send(from, recipient, subject, body, login, password);
            }
        }

        public void SendParallel(string from, IEnumerable<string> recipients, string subject, string body, string login, string password)
        {
            foreach (var recipient in recipients)
            {
                ThreadPool.QueueUserWorkItem(o => Send(from, recipient, subject, body, login, password));
            }
        }

        public async Task SendAsync(string from, string recipient, string subject, string body, string login, string password)
        {
            await Task.Run(()=>
            {
                Thread.Sleep(3000);
                Send(from, recipient, subject, body, login, password);
            });

            MessageBox.Show("Сообщение отправлено");
        }

        public async Task SendAsync(string from, IEnumerable<string> recipients, string subject, string body, string login, string password)
        {
            foreach (var recipient in recipients)
            {
                await SendAsync(from, recipient, subject, body, login, password);
            }
        }
    }
}
