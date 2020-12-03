using Lesson1WPF.Data;
using Lesson1WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private string _title = "Our test window";

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Server> _servers;
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Message> _messages;

        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

        public ObservableCollection<Sender> Senders
        {
            get { return _senders; }
            set { _senders = value; }
        }

        public ObservableCollection<Recipient> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }

        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        private Server _selectedServer;
        private Sender _selectedSender;
        private Recipient _selectedRecipient;
        private Message _selectedMessage;

        public Server SelectedServer
        {
            get { return _selectedServer; }
            set { _selectedServer = value; OnPropertyChanged(); }
        }

        public Sender SelectedSender
        {
            get { return _selectedSender; }
            set { _selectedSender = value; OnPropertyChanged(); }
        }
        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set { _selectedRecipient = value; OnPropertyChanged(); }
        }
        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set { _selectedMessage = value; OnPropertyChanged(); }
        }

        private IMailService _mailService { get; set; }

        public MainViewModel(IMailService mailService)
        {
            _mailService = mailService;

            SendMessageCommand = new Command(SendMessageCommand_Execute, SendMessageCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            AddServerCommand = new Command(AddServerCommand_Execute, AddServerCommand_CanExecute);
            EditServerCommand = new Command(EditServerCommand_Execute, EditServerCommand_CanExecute);
            DelServerCommand = new Command(DelServerCommand_Execute, DelServerCommand_CanExecute);

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }
    }
}
