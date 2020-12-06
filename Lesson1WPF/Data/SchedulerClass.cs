using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.Data
{
    class SchedulerClass
    {
        DispatcherTimer timer = new DispatcherTimer(); // таймер
        IMailService emailSender; // экземпляр класса, отвечающего за отправку писем
        ObservableCollection<Message> emails; // коллекция email-ов адресатов

        public SchedulerClass(IMailService emailSender, ObservableCollection<Message> emails)
        {
            this.emailSender = emailSender; // Экземпляр класса, отвечающего за отправку писем присваиваем
            this.emails = emails;

            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;



            var readyEmails = (from mail in emails where !mail.Sended && mail.DateTime.Year == now.Year && mail.DateTime.Month == now.Month && mail.DateTime.Day == now.Day select mail).DefaultIfEmpty();
            foreach (var mail in readyEmails)
            {
                //var service = emailSender.GetSender("server", 555, true);
                //service.Send(mail.sender.Address, mail.recipient.Address, mail.message.Subject, mail.message.Body, mail.sender.Address, mail.sender.Password);
                //mail.isSended = true;
            }
        }
    }
}
