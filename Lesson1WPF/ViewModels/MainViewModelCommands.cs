using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.ViewModels
{
    public partial class MainViewModel
    {
        #region Commands

        public ICommand SendMessageCommand { get; set; }
        public ICommand DialogCommand { get; set; }
        public ICommand AddServerCommand { get; set; }
        public ICommand EditServerCommand { get; set; }
        public ICommand DelServerCommand { get; set; }

        public void AddServerCommand_Execute()
        {
            MessageBox.Show("add");
        }

        public bool AddServerCommand_CanExecute()
        {
            return true;
        }

        public void EditServerCommand_Execute()
        {
            MessageBox.Show("edit");
        }

        public bool EditServerCommand_CanExecute()
        {
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

        public void SendMessageCommand_Execute()
        {
            var mailSender = _mailService.GetSender(SelectedServer.Address, SelectedServer.Port, SelectedServer.IsSSL, SelectedServer.Login, SelectedServer.Password);
            mailSender.Send(SelectedSender.Address, SelectedRecipient.Address, SelectedMessage.Subject, SelectedMessage.Body);
        }

        public bool SendMessageCommand_CanExecute()
        {
            if (SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null) return true;

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
