using Customer_BLL;
using IPL_BLL;
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
using Employee_Exceptions;

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
       static int[,] count = new int[10, 10];
        public  Customer()
        {
            
            InitializeComponent();
            Ticket_category();
            loadTicket();
            LoadStat();


        }
        private void Window_Initialized(object sender, EventArgs e)
        {

            Entities1 entity = new Entities1();
            List<Player> Player = (from p in entity.Players select p).ToList();
            dgteam2.ItemsSource = Player;

        }
        #region TicketLoading
        public void loadTicket()
        {
            try
            {
                CUSTOMER_BLL obj = new CUSTOMER_BLL();
                List<Match> pl = obj.GetAll_Ticket().ToList();
                cbmaname.ItemsSource = pl;
                cbmaname.DisplayMemberPath = "MatchId";
                txtnews.ItemsSource = pl;
                txtnews.DisplayMemberPath = "MatchId";
            }
            catch(TicketException ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }   
            catch(Exception ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                 
    }
        #endregion

        #region Load stastistics
        private void LoadStat()
        {
           try { 
            CUSTOMER_BLL obj = new CUSTOMER_BLL();
            List<Stat> st = obj.GetAll_Stat().ToList();         
            txttmid.ItemsSource = st;
            txttmid.DisplayMemberPath = "TeamId";
            }
            catch (StatisticException ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion

        #region Ticketcalculation
        public void Ticket_category()
        {
            try { 
            Ticket t = new Ticket();
            Entities1 entity = new Entities1();
            txttcat.ItemsSource = (from p in entity.TicketCategories select p.TicketCategoryName).ToList();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    count[i, j] = 100;
                }
            }        
           
           txtcnt.Text = count[0,0].ToString();
            }
            catch (TicketException ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(Exception ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion
        

       

        #region Ticket View
        private void pview_Click(object sender, RoutedEventArgs e)
        {
            try { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Category is: " + txttcat.SelectedItem);
            sb.AppendLine("\n No. of Tickets :" + txttid.Text);
            sb.AppendLine("\n Price :" + txttpice.Text);
                MessageBoxResult result = MessageBox.Show(this, "" +sb.ToString() + "",
                         "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                pview.IsEnabled = false;
            }
            catch (TicketException ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(Exception ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region Selection changed Methods
        private void dgteam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void TabItem_ContextMenuOpening_1(object sender, ContextMenuEventArgs e)
        {

        }

        private void txttcat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void tcSample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void txttpice_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
        #endregion
        #region Ticket Booking
        private void tBook_Click(object sender, RoutedEventArgs e)
        {
           
            int index = 0, index_1 = 0;
            Entities1 entity = new Entities1();
            try
            {
                Ticket t = new Ticket();
                if (txttid.Text!="" && txttcat.SelectedIndex >= 0 && cbmaname.Text!="")
                {
                    try
                    {
                        TicketCategory tc = new TicketCategory();
                        t.TicketCategoryId = txttcat.SelectedIndex;
                        t.MatchId = int.Parse(cbmaname.Text);
                        t.NumberOfTickets = txttid.Text;
                        int x = txttcat.SelectedIndex;
                        //MessageBox.Show(x.ToString());
                        txttpice.Text = ((x + 1) * 1000 * int.Parse(txttid.Text)).ToString();



                        t.Price = int.Parse(txttpice.Text);

                        //txtcnt.Text = (int.Parse(txtcnt.Text)-int.Parse(txttid.Text)).ToString();

                        CUSTOMER_BLL obj = new CUSTOMER_BLL();
                        obj.insert_Customer_Ticket(t);
                        //int[,] count = new int[10, 10];



                        index = txttcat.SelectedIndex;
                        index_1 = int.Parse(cbmaname.Text);
                        //MessageBox.Show((count[index + 1, index_1] - int.Parse(txttid.Text)).ToString());
                        count[index + 1, index_1] = count[index + 1, index_1] - int.Parse(txttid.Text);
                        txtcnt.Text = (count[index + 1, index_1]).ToString();
                        pview.IsEnabled = true;
                        MessageBoxResult result = MessageBox.Show(this, "Ticket Booked Successfully",
                   "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                      

                    }
                    catch (Exception ex)
                    {

                        MessageBoxResult result = MessageBox.Show(this, "All Fields are Required",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion
        #region reset Methods
        private void preset_Click(object sender, RoutedEventArgs e)
        {
            txtcnt.Text = "100";
            txttid.Text = null;
            txttcat.Text = null;
            cbmaname.Text = null;
            txttpice.Text = null;

        }

        #endregion



        

        #region Submit Methods
        private void submit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = int.Parse(txtnews.Text);
                var data = new List<News>();
                BLL obje = new BLL();
                data = obje.view_News(x);
                txtnewsdes.Text = data[0].NewsDescription;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Calculate Price
        private void calculate_price_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (txttcat.SelectedIndex >= 0 && int.Parse(cbmaname.Text) > 0 && int.Parse(txttid.Text) > 0)
            {
                
                    Ticket t = new Ticket();
                    t.TicketCategoryId = txttcat.SelectedIndex;
                    t.MatchId = int.Parse(cbmaname.Text);

                    int x = txttcat.SelectedIndex;
                    //MessageBox.Show(x.ToString());
                    txttpice.Text = ((x + 1) * 1000 * int.Parse(txttid.Text)).ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter all the values");
            }
        }
        #endregion

       

        #region Result Method
        private void sub_Click(object sender, RoutedEventArgs e)
        {
            try { 

            var data = new List<Stat>();
            int search = int.Parse(txttmid.Text);
            CUSTOMER_BLL obje = new CUSTOMER_BLL();
            data = obje.view_stat(search);
            txtplayed.Text = (data[0].Played).ToString();
            txtwon.Text = (data[0].Won).ToString();
            txtlost.Text = (data[0].Lost).ToString();
            txttied.Text = (data[0].Tied).ToString();
            txtnr.Text = (data[0].NR).ToString();
            txtnetrr.Text = (data[0].NetRR).ToString();
            txtpts.Text = (data[0].Pts).ToString();
            txtfpts.Text = (data[0].FromPoints).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Signout
        private void tbsignout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                tbsignout.IsSelected = false;
            }
        }
        #endregion
    }
}
