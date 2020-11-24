using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public static class Mail
    {
        public static List<string> GetMail(string text)
        {
            return new List<string>();
        }

        public static void SendMail(string login, string password, string address)
        {
            try
            {
                using (MailMessage mail = new MailMessage(login, address))
                {
                    mail.From = new MailAddress(login); // Адрес отправителя
                    mail.To.Add(new MailAddress(address)); // Адрес получателя
                    mail.Subject = "Заголовок";
                    mail.Body = "Письмо........................";

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.yandex.ru";
                    client.Port = 587;
                    client.Timeout = 5000;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(login, password); // Ваши логин и пароль
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
