using BMS_WPF.Model;
using BMS_WPF.ViewModel;
using BMS_WPF.ViewModel.Commands;
using BMS_WPF.ViewModel.Helpers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSWPFF
{
    [TestFixture]
    public class ApplyLoanVM_Tests
    {
        private ApplyLoanVM applyLoanVM;
        private Mock<IApplyLoanHelper> mockApplyLoanHelper;
        private ApplyLoanCommand applyLoanCommand;

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
            applyLoanVM = new ApplyLoanVM();
            mockApplyLoanHelper = new Mock<IApplyLoanHelper>();
            mockApplyLoanHelper.Setup(x => x.CreateLoan(It.IsAny<LoanDetail>()))
                .ReturnsAsync("Added Succesfully");


                            

            //setup variables
            GlobalVariables.USERNAME = LoanDetail.UserName;
            applyLoanVM.LoanAmount = "987123";
            applyLoanVM.LoanDate = DateTime.Now.ToString("MM/dd/yyyy");
            applyLoanVM.LoanDuration = "24";
            applyLoanVM.LoanType = "System.Windows.Controls.ComboBoxItem: Car";
        }

        [Test]
        public void CreateNewLoan_Test()
        {
            applyLoanCommand = new ApplyLoanCommand(applyLoanVM);
            applyLoanCommand.CanExecute(null);
            applyLoanCommand.Execute(null);

            Assert.NotNull(applyLoanVM.ROI);
        }

        [Test]
        public void CreateNewLoan_Error_Test()
        {
            applyLoanVM.LoanAmount = "test";
            applyLoanVM.LoanDate = "02/02/2029";
            applyLoanVM.LoanDuration = "5.0";
            applyLoanVM.LoanDuration = "0test";
            applyLoanVM.LoanDuration = "9&";
        }

     

        [Test]
        public void CreateNewLoan_LoanDuration_Errors_Test()
        {
            applyLoanVM.LoanDuration = "";
            applyLoanVM.CreateNewLoan();

            Assert.IsEmpty(applyLoanVM.LoanDuration);
        }

        [Test]
        public void CreateNewLoan_LoanDuration_WithValue_Errors_Test()
        {
            applyLoanVM.LoanDuration = "0.0";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDuration);
        }

        [Test]
        public void CreateNewLoan_LoanAmount_Errors_Test()
        {
            applyLoanVM.LoanAmount = "test";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanAmount);
        }

        [Test]
        public void CreateNewLoan_LoanDate_Errors_Test()
        {
            applyLoanVM.LoanDate = "02/02/2029";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Dash_LoanDate_Test()
        {
            applyLoanVM.LoanDate = "02-02-2020";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }

        [Test]
        public void CreateNewLoan_Shlash_LoanDate_Test()
        {
            applyLoanVM.LoanDate = "02/02/2020";
            applyLoanVM.CreateNewLoan();

            Assert.IsNotNull(applyLoanVM.LoanDate);
        }


    }
}