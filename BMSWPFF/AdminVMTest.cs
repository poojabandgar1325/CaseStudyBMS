using NUnit.Framework;
using System;
using BankManagement_WPF.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankManagement_WPF.Model;
using Caliburn.Micro;

namespace BMSWPFF
{
    
        [TestFixture]
        class AdminVMTest
        {
            private AllLoansVM allLoansVM;
        //  private ApprovedStatusCommand approveCommand;
        //private RejectCommand rejectCommand;

        private static LoanDetail loanDetail;

        public static LoanDetail LoanDetail
        {
            get
            {
                loanDetail = new LoanDetail()
                {
                    LoanId = 1,
                    LoanAmount = 100000,
                    LoanDate = new DateTime(2022, 1, 1),
                    LoanDuration = 6,
                    LoanType = "Car",
                    RateOfInterest = 10,
                    Status = "Pending",
                    UserName = "test"
                }; return loanDetail;
            }
        }
        [SetUp]
            public void Setup()
            {
                GlobalVariables.USERNAME = "admin";
                
                allLoansVM = new AllLoansVM();
            }

            [Test]
            public void BindableLoanDetails_Test()
            {
                List<LoanDetail> loanList = new List<LoanDetail>();
                loanList.Add(LoanDetail);
                allLoansVM.LoanDetails = new BindableCollection<LoanDetail>(loanList);

                Assert.IsNotNull(allLoansVM.LoanDetails);
            }

           

           
        }
    }