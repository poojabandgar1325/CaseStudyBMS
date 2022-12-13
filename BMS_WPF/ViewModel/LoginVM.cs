using BMS_WPF.Model;
using BMS_WPF.View;
using BMS_WPF.View.Admin;
using BMS_WPF.ViewModel.Commands;
using BMS_WPF.ViewModel.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BMS_WPF.ViewModel
{
   public class LoginVM : INotifyPropertyChanged
        //INotifyDataErrorInfo
    {
       private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }   
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set 
            {
                passWord = value;
                OnPropertyChanged("PassWord");
            }
        }

        private string warning;

        public string Warning
        {
            get { return warning; }
            set 
            { 
                warning = value;
                OnPropertyChanged("Warning");
            }
        }


       public  LoginCommand LoginSecurityCommand { get; set; }
        public CreateNewUserCommand SignupCommand { get; set; }



        public LoginVM()
        {
            LoginSecurityCommand = new LoginCommand(this);
            SignupCommand = new CreateNewUserCommand(this);
        }

        public async void MakeQuery()
        {
            
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
                return;
            try
            {
                string agent = await LoginHelper.LoginAgent(new LoginDetail {UserName = UserName, Password = PassWord });

                if (agent == "User")
                {
                    
                    GlobalVariables.USERNAME = UserName;
                    UserDashboard dashboard = new UserDashboard();
                    dashboard.Show();
                    LoginWindow obj = new LoginWindow();
                    obj.Close();
                    
                }
                else if (agent == "Admin")
                {
                    AdminDashboardWindow obj = new AdminDashboardWindow();
                    obj.Show();
                    LoginWindow obj1 = new LoginWindow();
                    obj1.Close();
                }
                else
                {
                    Warning = "Incorrect Username/Password";
                }
            }
            catch(Exception)
            {
                Warning = "Incorrect Data";
            }

        }

        public void OpenSignupWindow()
        {
            CreateNewUser createNewUser = new CreateNewUser();
            createNewUser.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
