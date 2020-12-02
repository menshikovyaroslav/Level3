using Clearmvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clearmvvm.ViewModel
{
    public class OptionsVm
    {
        public ICommand ChangeCommand { get; set; }
        public void ChangeCommand_Execute()
        {
            // Что делать сейчас ? Как передать в MainVm о том что что-то изменилось ?
        }

        public bool ChangeCommand_CanExecute()
        {
            return true;
        }
        public OptionsVm()
        {
            ChangeCommand = new Command(ChangeCommand_Execute, ChangeCommand_CanExecute);
        }
    }
}
