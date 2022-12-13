﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BMS_WPF.ViewModel.Commands
{
    class CreateAccountCommand : ICommand
    {
        public CreateNewUserVM VM { get; set; }
        public CreateAccountCommand(CreateNewUserVM vm)
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
            VM.CreateNewAccount();
        }
    }
}
