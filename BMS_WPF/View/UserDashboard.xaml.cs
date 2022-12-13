using BMS_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BMS_WPF.View
{
    /// <summary>
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        public UserDashboard()
        {
            InitializeComponent();
            Loaded += UserDashboard_Loaded;
        }

        private void UserDashboard_Loaded(object sender, RoutedEventArgs e)
        {
           if(DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }

        private void ApplyLoan_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ApplyLoanVM();
        }
        private void UpdateUser_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new UpdateUserVM();
        }
        private void ViewUser_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new UserDetailVM();
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //UserDashboard a = new UserDashboard();
        //    //a.Close();
        //    LoginWindow obj = new LoginWindow();
        //    obj.Show();
            
        //}

        private void ViewLoan_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new PreviousAppliedLoansVM();
        }
        


    }
}
