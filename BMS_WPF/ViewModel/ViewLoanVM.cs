using BMS_WPF.Model;
using BMS_WPF.Validations;
using BMS_WPF.View;
using BMS_WPF.ViewModel.Commands;
using BMS_WPF.ViewModel.Helpers;
using Caliburn.Micro;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_WPF.ViewModel
{
    class ViewLoanVM :  INotifyPropertyChanged
    {

        private BindableCollection<LoanDetail> loanDetails;

        public BindableCollection<LoanDetail> LoanDetails
        {
            get { return loanDetails; }
            set
            {
                loanDetails = value;
                OnPropertyChanged("LoanDetails");
            }
        }

        TextBlockValidation textBlockValidation;

       

        public ViewLoanVM()
        {
            textBlockValidation = new TextBlockValidation();
            DisplayAllAttributes();
        }

        private async void DisplayAllAttributes()
        {
            var response = await ViewLoanHelper.GetUserDetail(GlobalVariables.USERNAME);
            LoanDetails = new BindableCollection<LoanDetail>(response);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
