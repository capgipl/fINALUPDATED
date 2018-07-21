using IPL_Entity;
using Login_User_BLL;
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

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for Login_User.xaml
    /// </summary>
    public partial class Login_User : Window
    {
        public Login_User()
        {
            InitializeComponent();
        }

        #region Customer Registration
        private void uregister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities1 entity = new Entities1();
                User login = new User();
                login.UserName = txtuname.Text;
                login.Pass = cbpass.Password;
                login.FirstName = txtfname.Text;
                login.LastName = txtlname.Text;
                if (cbpass.Password == cbrepass.Password)
                {
                    Login_BLL obj = new Login_BLL();
                    obj.add_user(login);
                    MessageBoxResult result = MessageBox.Show(this, "Successfully Registered",
                    "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                    signin.IsSelected = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Password is not Matching ",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
              "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Reset method
        private void urreset_Click(object sender, RoutedEventArgs e)
        {
            txtfname.Text = "";
            txtlname.Text = "";
            txtuname.Text = "";
            cbpass.Password = "";
        }
        #endregion

        #region User Login
        private void ulogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entities1 entity = new Entities1();
                User user = new User();
                user.UserName = cbteid.Text;
                user.Pass = txtname.Password;
                int val;
                Login_BLL obj = new Login_BLL();
                val = obj.log_user(user);
                if (val == 1)
                {

                    MainWindow emp = new MainWindow();

                    this.Close();
                    emp.Show();
                }
                else
                    if (val == 2)
                {
                  
                    Customer cus = new Customer();
                    this.Close();
                    cus.Show();

                }
                else
                    if (val == 3)
                {
                    Admin admin = new Admin();
                    this.Close();
                    admin.Show();
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region reset
        private void ureset_Click(object sender, RoutedEventArgs e)
        {
            cbteid.Text = "";
            txtname.Password = "";
        }
        #endregion
    }
}
