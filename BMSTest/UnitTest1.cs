using AutoMapper;
using BMS_API.Data;
using BMS_API.Controllers;
using BMS_API.Models.Domains;
using BMS_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSTest
{

    [TestFixture]
    public class Test
    {
        private LoanDetail loanDetail_one;
        private UserDetail userDetail_one;
        private Mock<IApplyLoanRepositry> _loanRepoMock;
        private Mock<IMapper> mapper;
        private LoanController LoanController;

        public Test()
        {
            loanDetail_one = new LoanDetail()
            {
                LoanId = 1001,
                LoanAmount = 100000,
                LoanDate = new DateTime(2022, 1, 1),
                LoanDuration = 6,
                LoanType = "Car",
                RateOfInterest = 10,
                Status = "Pending",
                UserName = "test"
            };

            userDetail_one = new UserDetail()
            {
                UserName= "ABC",
                Name="ABC",
                Password="ABC@13",
                Address="Karad",
                State="MP",
                Country="India",
                PAN=9876543212,
                Contact=9876543213,
                Email="ABC@gmail.com",
                DOB= new DateTime(2022, 1, 1),
                AccountType = "Saving"
            };

        }
        //Apply loan
        [Test]
        public void SaveLoanDeatilAsync_Success_CheckValueFromDb()
        {
            //arrange
            var options = new DbContextOptionsBuilder<BankManagementDbContext>()
                .UseInMemoryDatabase("tempLoan").Options;



            //act
            using (var context = new BankManagementDbContext(options))
            {
                var repo = new ApplyLoanRepositry(context);
                _ = repo.SaveLoanDeatilAsync(loanDetail_one);
            }



            //assert
            using (var context = new BankManagementDbContext(options))
            {
                var loanFromDb = context.LoanDetails.FirstOrDefault(x => x.LoanId == loanDetail_one.LoanId);
                Assert.AreEqual(loanDetail_one.LoanId, loanFromDb.LoanId);
                Assert.AreEqual(loanDetail_one.LoanAmount, loanFromDb.LoanAmount);
                Assert.AreEqual(loanDetail_one.LoanDate, loanFromDb.LoanDate);
                Assert.AreEqual(loanDetail_one.LoanDuration, loanFromDb.LoanDuration);
                Assert.AreEqual(loanDetail_one.LoanType, loanFromDb.LoanType);
                Assert.AreEqual(loanDetail_one.UserName, loanFromDb.UserName);
            }
        }

        //[Test]
        //public void GetLoanByID_Success_CheckValueFromDb()
        //{
        //    //arrange
        //    var options = new DbContextOptionsBuilder<BankManagementDbContext>()
        //        .UseInMemoryDatabase("tempLoan").Options;



        //    //act
        //    using (var context = new BankManagementDbContext(options))
        //    {
              
        //        var repo = new ApplyLoanRepositry(context);
        //        _ = repo.GetLoanAsync(loanDetail_one.LoanId);
        //    }



        //    //assert
        //    using (var context = new BankManagementDbContext(options))
        //    {
        //        var loanFromDb = context.LoanDetails.FirstOrDefault(x => x.LoanId == loanDetail_one.LoanId);
               
        //        Assert.AreEqual(loanDetail_one.UserName, loanFromDb.UserName);
                
        //    }
        //}


        //UpdateLoanStatus
        [Test]
        public void UpdateLoanStatusAsync_Success_CheckValueFromDb()
        {
            //arrange
            var options = new DbContextOptionsBuilder<BankManagementDbContext>()
                .UseInMemoryDatabase("tempLoan").Options;



            //act
            using (var context = new BankManagementDbContext(options))
            {
                loanDetail_one.Status="Approved";
                var repo = new ApplyLoanRepositry(context);
                _ = repo.UpdateStatusAsync(loanDetail_one.LoanId,loanDetail_one.Status);
            }



            //assert
            using (var context = new BankManagementDbContext(options))
            {
                var loanFromDb = context.LoanDetails.FirstOrDefault(x => x.LoanId == loanDetail_one.LoanId);
                Assert.AreEqual(loanDetail_one.LoanId, loanFromDb.LoanId);
                Assert.AreEqual(loanDetail_one.Status, loanFromDb.Status);
            }
        }

        //Add New User
        [Test]
        public void AddUserDetailAsync_Success_CheckValueFromDb()
        {
            //arrange
            var options = new DbContextOptionsBuilder<BankManagementDbContext>()
                .UseInMemoryDatabase("tempLoan").Options;



            //act
            using (var context = new BankManagementDbContext(options))
            {
                var repo = new UserRepository(context);
                _ = repo.SaveUserDeatilAsync(userDetail_one);
            }

            //assert
            using (var context = new BankManagementDbContext(options))
            {
                var userFromDb = context.UserDetails.FirstOrDefault(x => x.UserName == userDetail_one.UserName);
              
                Assert.AreEqual(userDetail_one.Name, userFromDb.Name);
                Assert.AreEqual(userDetail_one.Password, userFromDb.Password);
                Assert.AreEqual(userDetail_one.Address, userFromDb.Address);
                Assert.AreEqual(userDetail_one.Country, userFromDb.Country);
                Assert.AreEqual(userDetail_one.State, userFromDb.State);
                Assert.AreEqual(userDetail_one.PAN, userFromDb.PAN);
                Assert.AreEqual(userDetail_one.Contact, userFromDb.Contact);
                Assert.AreEqual(userDetail_one.Email, userFromDb.Email);
                Assert.AreEqual(userDetail_one.DOB, userFromDb.DOB);
                Assert.AreEqual(userDetail_one.AccountType, userFromDb.AccountType);
            }
        }

        //Update User Details

        [Test]
        public void UpdateUserDetailAsync_Success_CheckValueFromDb()
        {
            //arrange
            var options = new DbContextOptionsBuilder<BankManagementDbContext>()
                .UseInMemoryDatabase("tempLoan").Options;



            //act
            using (var context = new BankManagementDbContext(options))
            {
                userDetail_one.Name = "XYZ";
                userDetail_one.Password = "XYS@1325";
                userDetail_one.Address = "Pune";
                userDetail_one.State = "UP";
                userDetail_one.Country = "India";
                userDetail_one.PAN = 9878763212;
                userDetail_one.Contact = 8765678543;
                userDetail_one.Email = "XYZ@gmail.com";
                userDetail_one.DOB = new DateTime(2022, 1, 1);
                userDetail_one.AccountType = "Current";

                var repo = new UserRepository(context);
                _ = repo.UpdateUserAsync(userDetail_one.UserName, userDetail_one);
            }

            //assert
            using (var context = new BankManagementDbContext(options))
            {
                var userFromDb = context.UserDetails.FirstOrDefault(x => x.UserName == userDetail_one.UserName);

                Assert.AreEqual(userDetail_one.Name, userFromDb.Name);
                Assert.AreEqual(userDetail_one.Password, userFromDb.Password);
                Assert.AreEqual(userDetail_one.Address, userFromDb.Address);
                Assert.AreEqual(userDetail_one.Country, userFromDb.Country);
                Assert.AreEqual(userDetail_one.State, userFromDb.State);
                Assert.AreEqual(userDetail_one.PAN, userFromDb.PAN);
                Assert.AreEqual(userDetail_one.Contact, userFromDb.Contact);
                Assert.AreEqual(userDetail_one.Email, userFromDb.Email);
                Assert.AreEqual(userDetail_one.DOB, userFromDb.DOB);
                Assert.AreEqual(userDetail_one.AccountType, userFromDb.AccountType);
            }
        }




        [SetUp]
        public void SetUp()
        {
            _loanRepoMock = new Mock<IApplyLoanRepositry>();
        }

        [Test]
        public void GetAllLoan_CheckIfRepoIsCalled()
        {
            _loanRepoMock.Verify(x => x.GetAllAsync(), Times.Never);
        }

        //[Test]
        //public void CallRequest_VerifyPost_Success()
        //{
        //    _loanRepoMock.Setup(x => x.SaveLoanDeatilAsync(It.IsAny<LoanDetail>()))
        //        .ReturnsAsync(true);

        //    var res = LoanController.Post(loanDetail_one);

        //    Assert.AreEqual(true, res.IsCompleted);

        //}
    }
}
