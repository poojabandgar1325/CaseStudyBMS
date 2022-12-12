using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankManagement_WPF.ViewModel.Commands
{
    class RejectCommand : ICommand
    {
        public AllLoansVM VM { get; set; }
        public RejectCommand(AllLoansVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            VM.RejectLoan();
        }
    }
}
