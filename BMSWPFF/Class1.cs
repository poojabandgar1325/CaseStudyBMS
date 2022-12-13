using System;
using System.Collections.Generic;
using BMS_WPF.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BMS_WPF.ViewModel.Commands;
using System.Threading;

namespace BMSWPFF
{
    [TestFixture]
    public class Class1
    {

        [TestFixture]
        class LoginSecurityVM_Tests
        {
            private LoginVM loginSecurityVM;
            private LoginCommand loginSecurityCommand;
            private CreateNewUserCommand signupCommand;

            [SetUp]
            public void Setup()
            {
                loginSecurityVM = new LoginVM();
                loginSecurityCommand = new LoginCommand(loginSecurityVM);
                signupCommand = new CreateNewUserCommand(loginSecurityVM);
            }

            [Test]
            public void SignupWindow_Test()
            {
                // create a thread  
                Thread newWindowThread = new Thread(new ThreadStart(() =>
                {
                    // create and show the window
                    // your code
                    signupCommand.CanExecute(null);
                    signupCommand.Execute(null);

                    // start the Dispatcher processing  
                    System.Windows.Threading.Dispatcher.Run();
                }));

                // set the apartment state  
                newWindowThread.SetApartmentState(ApartmentState.STA);

                // make the thread a background thread  
                newWindowThread.IsBackground = true;

                // start the thread  
                newWindowThread.Start();


                Assert.IsNull(loginSecurityVM.UserName);
            }

            [Test]
            [TestCase("pooja")]
            [TestCase("123456")]
            public void LoginSecurityVM_UserNameValidation_Pass_Test(string username)
            {
                loginSecurityVM.UserName = username;
                Assert.AreEqual(username, loginSecurityVM.UserName);
            }

            [Test]
            [TestCase("pooja%")]
            [TestCase("!@#$%^*")]
            public void LoginSecurityVM_UserNameValidation_Fail_Test(string username)
            {
                loginSecurityVM.UserName = username;
                Assert.AreEqual(username, loginSecurityVM.UserName);
            }

            [Test]
            [TestCase("Pooja@13")]
            [TestCase("Pooja&004")]
            public void LoginSecurityVM_PasswordValidation_Pass_Test(string password)
            {
                loginSecurityVM.PassWord = password;
                Assert.AreEqual(password, loginSecurityVM.PassWord);
            }

            [Test]
            [TestCase("Pooja")]
            [TestCase("Pooja#12")]
            [TestCase("12")]
            [TestCase("&%^&!")]
            public void LoginSecurityVM_PasswordValidation_Fail_Test(string password)
            {
                loginSecurityVM.PassWord = password;
                Assert.AreEqual(password, loginSecurityVM.PassWord);
            }

            [Test]
            public void LoginSecurityQuery_Test()
            {
                loginSecurityVM.UserName = "test";
                loginSecurityVM.PassWord = "Test@121";

                loginSecurityCommand.CanExecute(null);
                loginSecurityCommand.Execute(null);

                Assert.IsNull(loginSecurityVM.Warning);

            }

            [Test]
            public void LoginSecurityQuery_UserName_Fail_Test()
            {
                loginSecurityVM.PassWord = "Test@121";

                loginSecurityCommand.CanExecute(null);
                loginSecurityCommand.Execute(null);

                Assert.IsNull(loginSecurityVM.UserName);

            }

            [Test]
            public void LoginSecurityQuery_Password_Fail_Test()
            {
                loginSecurityVM.UserName = "test";

                loginSecurityCommand.CanExecute(null);
                loginSecurityCommand.Execute(null);

                Assert.IsNull(loginSecurityVM.PassWord);

            }

            [Test]
            public void LoginSecurityVM_Warning_Test()
            {
                loginSecurityVM.Warning = "Something Went Wrong";
                Assert.NotNull(loginSecurityVM.Warning);
            }




        }
    }
}