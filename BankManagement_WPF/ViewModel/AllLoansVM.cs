using BankManagement_WPF.Model;
using BankManagement_WPF.ViewModel.Helpers;
using Caliburn.Micro;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BankManagement_WPF.Validations;
using BankManagement_WPF.View;
using BankManagement_WPF.ViewModel.Commands;
using System.Windows;

namespace BankManagement_WPF.ViewModel
{
    class AllLoansVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private DelegateCommand<LoanDetail> _updateCommand;
        //public DelegateCommand<LoanDetail> oUpdateCommand =>
        //    _updateCommand ?? (_updateCommand = new DelegateCommand<LoanDetail>(ExecuteUpdateCommand));
        ////public int LOANID;
        //public void ExecuteUpdateCommand(LoanDetail obj)
        //{
        //    obj.Status = "Approve";
        //    ApproveLoan(obj);
        //}

        //public async void ApproveLoan(LoanDetail loanDetail)
        //{
        //    string statusvalue = loanDetail.Status;
        //    //string test = await UpdateUserHelper.UpdateLoanStatus(LOANID, statusvalue);
        //    //if(test != null)
        //    //{
        //    //    MessageBox.Show("Status updated successfully");

        //    //}
        //    UpdateUserHelper update = new UpdateUserHelper();
        //    await update.UpdateLoanStatus(1, statusvalue);
        //   DisplayAllAttributes();

        //}
        public AllLoansVM()
        {         
            DisplayAllAttributes();
        }
        private async void DisplayAllAttributes()
        {
            var response = await AllLoansHelper.GetLoanDetails();
            LoanDetails = new BindableCollection<LoanDetail>(response);
        }
        public async void ApproveLoan()
        {
            //string checkValue = LoanDetails[2 - 1].Status;
            //if (checkValue != "Pending")
            //{
            //    System.Windows.MessageBox.Show("Can't Change the Status");
            //    return;
            //}
            UpdateUserHelper updateUserHelper = new UpdateUserHelper();
            await updateUserHelper.UpdateLoanStatus(1, "APPROVED");
            DisplayAllAttributes();
            // GlobalVariables.COMMENT = "";
            // new CommentWindow().ShowDialog();
        }



        public async void RejectLoan()
        {
            //string UserName = GlobalVariables.USERNAME;
            //string checkValue = LoanDetails[GlobalVariables.LOANID - 1].Status;
            //if (checkValue != "Pending")
            //{
            //    System.Windows.MessageBox.Show("Can't Change the Status");
            //    return;
            //}
            UpdateUserHelper update = new UpdateUserHelper();
            await update.UpdateLoanStatus(2, "REJECTED");
            DisplayAllAttributes();
            //GlobalVariables.COMMENT = "";
            //new CommentWindow().ShowDialog();
        }



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

    }
}
