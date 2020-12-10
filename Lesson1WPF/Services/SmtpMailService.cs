using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class SmtpMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool IsSSL)
        {
            return new SmtpMailSender(Server, Port, IsSSL);
        }
    }

    public class SmtpMailSender : IMailSender
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }

        public SmtpMailSender(string address, int port, bool isSSL)
        {
            Address = address;
            Port = port;
            IsSSL = isSSL;
        }

        public void Send(string from, string recipient, string subject, string body, string login, string password)
        {
            try
            {
                using (MailMessage mail = new MailMessage(from, recipient))
                {
                    mail.From = new MailAddress(from); // Адрес отправителя
                    mail.To.Add(new MailAddress(recipient)); // Адрес получателя
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpClient client = new SmtpClient();
                    client.Host = "Address";
                    client.Port = Port;
                    client.Timeout = 5000;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(login, password); // Ваши логин и пароль
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
            }
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
            await Task.Run(() =>
            {
                Send(from, recipient, subject, body, login, password);
            });
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
