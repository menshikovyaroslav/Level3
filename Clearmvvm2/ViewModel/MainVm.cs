using Clearmvvm.Commands;
using Clearmvvm.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clearmvvm.ViewModel
{
    public class MainVm : ViewModelBase
    {
        public string Title { get; set; }
        public ICommand OptionsCommand { get; set; }
        public void OptionsCommand_Execute()
        {
            var optionsWindow = new Options();
            optionsWindow.Show();
        }

        public bool OptionsCommand_CanExecute()
        {
            return true;
        }

        public MainVm()
        {
            Title = "Test MVVM";
            OptionsCommand = new Command(OptionsCommand_Execute, OptionsCommand_CanExecute);

            Messenger.Default.Register<string>(this, "token1", message =>
            {
                Title = message; RaisePropertyChanged("Title");
            });
        }
    }
}
