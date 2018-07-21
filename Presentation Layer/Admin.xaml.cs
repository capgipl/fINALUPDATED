using Admin_Bal;
using IPL_Entity;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        string id;
        public Admin()
        {

            InitializeComponent();
            btnempuupdate.IsEnabled = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //loadEmp();
        }
        #region Load Employee 
        public void loademp()
        {
            try
            {
                Entities1 entity = new Entities1();
                var query = from p in entity.Users
                            from q in entity.UserRoles
                            where p.UserId == (q.UserId)
                               && q.RoleId == 1
                            select new
                            {
                                p.UserId,
                                p.UserName,
                                p.FirstName,
                                p.LastName
                            };

                dtgrid.ItemsSource = query.ToList();
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
           "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Employee Details
        private void UempInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                User t = new User();
                t.UserName = txtname.Text;
                t.FirstName = txtfirstname.Text;
                t.LastName = txtlastname.Text;
                t.Pass = txtpassword.Password;

                Admin_BAL obj = new Admin_BAL();
                obj.insert_Employee(t);
                MessageBoxResult result = MessageBox.Show(this, "Employee " + t.UserName + " Registered Successfully",
               "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                loademp();
                txtname.Clear();
                txtfirstname.Clear();
                txtlastname.Clear();
                txtpassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Reset
        private void btnempreset_Click(object sender, RoutedEventArgs e)
        {
            txtname.Clear();
            txtfirstname.Clear();
            txtlastname.Clear();
            txtpassword.Clear();
        }
        #endregion


        #region Update Employee
        private void btnempuUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dtgrid.SelectedItem;
                if (item != null)
                {
                    id = (dtgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    User t = new User();
                    t.UserId = int.Parse(id);
                    t.UserName = txtname.Text;
                    t.FirstName = txtfirstname.Text;
                    t.LastName = txtlastname.Text;
                    t.Pass = txtpassword.Password;

                    Admin_BAL obj = new Admin_BAL();
                    int x = obj.update_Employee(t);
                    if (x == 1)
                    {
                        MessageBoxResult result = MessageBox.Show(this, "Employee " + t.UserName + " Updated Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        UempInsert.IsEnabled = true;
                        tbuser.IsSelected = true;
                        loademp();
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to update",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion


        #region Employee View
        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            btnempUpdate.IsEnabled = true;
            loademp();
        }
        #endregion

        #region Customer Details
        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnempUpdate.IsEnabled = false;
                Entities1 entity = new Entities1();
                var query = from p in entity.Users
                            from q in entity.UserRoles
                            where p.UserId == (q.UserId)
                               && q.RoleId == 2
                            select new
                            {
                                p.UserId,
                                p.UserName,
                                p.FirstName,
                                p.LastName
                            };

                dtgrid.ItemsSource = query.ToList();
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
           "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Employee Update in User Details
        private void btnempUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnempuupdate.IsEnabled = true;
                tbemp.IsSelected = true;
                UempInsert.IsEnabled = false;
                User p = new User();
                var obje = new List<User>();
                object item = dtgrid.SelectedItem;
                if (item != null)
                {
                    id = (dtgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    Admin_BAL obj = new Admin_BAL();
                    p = obj.view_Employee(int.Parse(id));
                    txtname.Text = p.UserName;
                    txtfirstname.Text = p.FirstName;
                    txtlastname.Text = p.LastName;
                    txtpassword.Password = p.Pass;
                }

                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to Update",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    tbuser.IsSelected = true;
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion


        #region Employee Delete
        private void btnempDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dtgrid.SelectedItem;
                if (item != null)
                {
                    MessageBoxResult result = MessageBox.Show(this, "Do you want to Remove",
                     "warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        id = (dtgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                        int obje;
                        Admin_BAL obj = new Admin_BAL();
                        obje = obj.delete_Employee(int.Parse(id));
                        if (obje == 1)
                        {
                            MessageBoxResult res = MessageBox.Show(this, "Data Removed Successfully",
                          "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            loademp();
                        }
                        else
                        {
                            MessageBoxResult res = MessageBox.Show(this, "Deletion Failed",
                         "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to delete",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
           "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        #endregion

        #region Unhandled Click Events
        private void tcSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion

        #region Signout
        private void TabItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string message = "Do you want to SignOut?";
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
            {
                Login_User lu = new Login_User();
                lu.Show();
                this.Hide();
            }
            else
            {
                tbsout.IsSelected = false;
            }
        }
        #endregion
    }
}
