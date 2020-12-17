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
using WpfApp1.Data;
using WpfApp1.Models;
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

        private DateTime _selectedTime;
        private Server _selectedServer;
        private Sender _selectedSender;
        private Recipient _selectedRecipient;
        private Message _selectedMessage;

        public DateTime SelectedTime
        {
            get { return _selectedTime; }
            set { _selectedTime = value; OnPropertyChanged(); }
        }

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

        private DBclass _db;
        private MailSenderDb _mailSenderDb;

        private SchedulerClass _schedulerClass; 


        public MainViewModel(IMailService mailService, MailSenderDb mailSenderDb)
        {
            _mailService = mailService;
            _db = new DBclass();
            _mailSenderDb = mailSenderDb;

            _mailSenderDb.Database.EnsureCreated();

            SendMessageCommand = new Command(SendMessageCommand_Execute, SendMessageCommand_CanExecute);
            ScheduleMessageCommand = new Command(ScheduleMessageCommand_Execute, ScheduleMessageCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            AddServerCommand = new Command(AddServerCommand_Execute, AddServerCommand_CanExecute);
            EditServerCommand = new Command(EditServerCommand_Execute, EditServerCommand_CanExecute);
            DelServerCommand = new Command(DelServerCommand_Execute, DelServerCommand_CanExecute);

            AddSenderCommand = new Command(AddSenderCommand_Execute, AddSenderCommand_CanExecute);
            EditSenderCommand = new Command(EditSenderCommand_Execute, EditSenderCommand_CanExecute);
            DelSenderCommand = new Command(DelSenderCommand_Execute, DelSenderCommand_CanExecute);

            SaveServerCommand = new Command(SaveServerCommand_Execute, SaveServerCommand_CanExecute);
            SaveSenderCommand = new Command(SaveSenderCommand_Execute, SaveSenderCommand_CanExecute);

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);

            LoadTestDataInDb();

            _schedulerClass = new SchedulerClass(_mailService, Messages);
        }

        private void LoadTestDataInDb()
        {
            var serversCount = _mailSenderDb.Servers.Count();
            if (serversCount == 0)
            {
                _mailSenderDb.Servers.AddRange(Servers);
                _mailSenderDb.SaveChanges();
            }
            var sendersCount = _mailSenderDb.Senders.Count();
            if (sendersCount == 0)
            {
                _mailSenderDb.Senders.AddRange(Senders);
                _mailSenderDb.SaveChanges();
            }
            var recipientsCount = _mailSenderDb.Recipients.Count();
            if (recipientsCount == 0)
            {
                _mailSenderDb.Recipients.AddRange(Recipients);
                _mailSenderDb.SaveChanges();
            }
            var messagesCount = _mailSenderDb.Messages.Count();
            if (messagesCount == 0)
            {
                _mailSenderDb.Messages.AddRange(Messages);
                _mailSenderDb.SaveChanges();
            }
        }
    }
}
