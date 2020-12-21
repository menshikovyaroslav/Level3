using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Support
{
    [Obsolete]
    public class Mail
    {
        private string Description { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [Obsolete]
        public void SendMail(string sender, string recipient, string subject, string body)
        {
            try
            {
                using (MailMessage mail = new MailMessage(sender, recipient))
                {
                    mail.From = new MailAddress(sender); // Адрес отправителя
                    mail.To.Add(new MailAddress(recipient)); // Адрес получателя
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpClient client = new SmtpClient();
                    client.Host = Server;
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

        public Mail(string text)
        {

        }

        public Mail(string server, int port)
        {
            Description = "standard";
            Server = server;
            Port = port;
        }

        public Mail()
        {

        }

    }
}
