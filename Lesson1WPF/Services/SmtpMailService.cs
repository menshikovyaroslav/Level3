using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Services
{
    public class SmtpMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool IsSSL, string Login, string Password)
        {
            return new SmtpMailSender(Server, Port, IsSSL, Login, Password);
        }
    }

    public class SmtpMailSender : IMailSender
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public SmtpMailSender(string address, int port, bool isSSL, string login, string password)
        {
            Address = address;
            Port = port;
            IsSSL = isSSL;
            Login = login;
            Password = password;
        }

        public void Send(string from, string recipient, string subject, string body)
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
                    client.Credentials = new NetworkCredential(Login, Password); // Ваши логин и пароль
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
