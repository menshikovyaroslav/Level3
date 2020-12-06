using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public partial class MainViewModel
    {
        #region Commands

        public ICommand ScheduleMessageCommand { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand DialogCommand { get; set; }
        public ICommand AddServerCommand { get; set; }
        public ICommand EditServerCommand { get; set; }
        public ICommand DelServerCommand { get; set; }
        public ICommand AddSenderCommand { get; set; }
        public ICommand EditSenderCommand { get; set; }
        public ICommand DelSenderCommand { get; set; }
        public ICommand SaveServerCommand { get; set; }
        public ICommand SaveSenderCommand { get; set; }

        public void SaveServerCommand_Execute()
        {
            var activeWindow = App.Current.Windows.OfType<ServerWindow>().SingleOrDefault();
            activeWindow?.Close();
        }

        public bool SaveServerCommand_CanExecute()
        {
            return true;
        }

        public void SaveSenderCommand_Execute()
        {
            var activeWindow = App.Current.Windows.OfType<SenderWindow>().SingleOrDefault();
            activeWindow?.Close();
        }

        public bool SaveSenderCommand_CanExecute()
        {
            return true;
        }

        public void AddServerCommand_Execute()
        {
            var random = new Random();

            var server = new Server() {Id = random.Next(1, 1000), Address = "server.ru", Port = 10000, IsSSL = true };
            Servers.Add(server);

            _db.AddServer(server);
        }

        public bool AddServerCommand_CanExecute()
        {
            return true;
        }

        public void EditServerCommand_Execute()
        {
            var serverWindow = new ServerWindow();
            serverWindow.ShowDialog();

            _db.EditServer(SelectedServer);
        }

        public bool EditServerCommand_CanExecute()
        {
            if (SelectedServer is null) return false;
            return true;
        }

        public void DelServerCommand_Execute()
        {
            Servers.Remove(SelectedServer);
            SelectedServer = Servers.FirstOrDefault();
        }

        public bool DelServerCommand_CanExecute()
        {
            if (SelectedServer is null) return false;
            return true;
        }

        public void AddSenderCommand_Execute()
        {
            var random = new Random();

            var sender = new Sender() { Id = random.Next(1, 1000), Address = "new@host.ru", Name = "New Person", Password = "" };
            Senders.Add(sender);

            _db.AddSender(sender);
        }

        public bool AddSenderCommand_CanExecute()
        {
            return true;
        }

        public void EditSenderCommand_Execute()
        {
            var senderWindow = new SenderWindow();
            senderWindow.ShowDialog();

            _db.EditSender(SelectedSender);
        }

        public bool EditSenderCommand_CanExecute()
        {
            if (SelectedSender is null) return false;
            return true;
        }

        public void DelSenderCommand_Execute()
        {
            Senders.Remove(SelectedSender);
            SelectedSender = Senders.FirstOrDefault();
        }

        public bool DelSenderCommand_CanExecute()
        {
            if (SelectedSender is null) return false;
            return true;
        }

        public void SendMessageCommand_Execute()
        {
            var mailSender = _mailService.GetSender(SelectedServer.Address, SelectedServer.Port, SelectedServer.IsSSL);
            mailSender.Send(SelectedSender.Address, SelectedRecipient.Address, SelectedMessage.Subject, SelectedMessage.Body, SelectedSender.Address, SelectedSender.Password);
        }

        public bool SendMessageCommand_CanExecute()
        {
            if (SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null) return true;

            return false;
        }

        public void ScheduleMessageCommand_Execute()
        {

        }

        public bool ScheduleMessageCommand_CanExecute()
        {
            if (SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null && SelectedTime != DateTime.Now) return true;

            return false;
        }

        public void DialogCommand_Execute(string text)
        {
            MessageBox.Show(text);
        }

        public bool DialogCommand_CanExecute(string text)
        {
            if (text is null) return false;
            return true;
        }

        #endregion
    }
}
