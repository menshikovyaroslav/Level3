using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using TestApp.Commands;

namespace TestApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region Commands

        public ICommand CloseProgramCommand { get; set; }
        public ICommand DialogCommand { get; set; }

        public void CloseProgramCommand_Execute()
        {
            Application.Current.Shutdown();
        }

        public bool CloseProgramCommand_CanExecute()
        {
            if (Title.Length < 20) return false;
            return true;
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


        public MainViewModel()
        {
            CloseProgramCommand = new Command(CloseProgramCommand_Execute, CloseProgramCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            var timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged("CurrentTime");
        }
    }
}
