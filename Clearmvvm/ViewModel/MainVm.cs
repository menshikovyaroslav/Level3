using Clearmvvm.Commands;
using Clearmvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clearmvvm.ViewModel
{
    public class MainVm
    {
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
            OptionsCommand = new Command(OptionsCommand_Execute, OptionsCommand_CanExecute);
        }
    }
}
