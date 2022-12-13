using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_WPF.ViewModel
{
    public class LogoutVM: ICloseWindow
    {
        private DelegateCommand _logoutCommand;

        public DelegateCommand LogoutCommand =>
            _logoutCommand ?? (_logoutCommand = new DelegateCommand(CloseWindow));

        public Action Close { get; set; }

        void CloseWindow()
        {
            Close?.Invoke();
        }
    }

    interface ICloseWindow
        {
            Action Close { get; set; }
        }

}
