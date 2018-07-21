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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Employee_Exceptions;
using System.Text.RegularExpressions;

namespace Presentation_Layer
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        string id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;
                pUpdate.IsEnabled = false;
                pDelete.IsEnabled = false;
                LoadTeamList();
                LoadPlayerList();
                LoadVenueList();
                LoadMatchList();
                LoadScheduleList();
                LoadStat();
                LoadNewsList();
                LoadTCatList();

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #region Unhandled Click Events
        private void button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {


        }
        #endregion


        #region Team Methods
        private void TeamClearBox()
        {

            cbteid.Text = string.Empty;
            txtname.Clear();
            txthg.Clear();
            txtowner.Clear();
        }
        private void LoadTeamList()
        {
            try
            {
                tInsert.IsEnabled = true;
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;
                tview.IsEnabled = true;
                BLL obj = new BLL();
                List<Team> t = new List<Team>();
                    t = obj.GetAll_Team();
                tgrid.ItemsSource = t;
                cbtid.ItemsSource = t;
                cbtid.DisplayMemberPath = "TeamId";
                cbteid.ItemsSource = t;
                cbteid.DisplayMemberPath = "TeamId";
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tInsert.IsEnabled = true;
                tview.IsEnabled = true;
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;
            }

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;

                int id = int.Parse(cbteid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Team(id);
                if (obje == 1)
                {
                    MessageBoxResult result = MessageBox.Show(this, " Team Removed Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    TeamClearBox();
                    tDelete.IsEnabled = false;
                    tUpdate.IsEnabled = false;
                    tInsert.IsEnabled = true;
                    LoadTeamList();
                    cbteid.IsEnabled = false;
                    txtname.IsEnabled = false;
                    txthg.IsEnabled = false;
                    txtowner.IsEnabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tInsert.IsEnabled = true;
                tview.IsEnabled = true;
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;
                cbteid.IsEnabled = false;
                txtname.IsEnabled = false;
                txthg.IsEnabled = false;
                txtowner.IsEnabled = false;

            }
        }
        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Team t = new Team();
                Team lb = (Team)cbteid.SelectedItem;
                t.TeamId = lb.TeamId;
                t.TeamName = txtname.Text;
                t.HomeGround = txthg.Text;
                t.Owners = txtowner.Text;
                BLL obj = new BLL();
                obj.update_Team(t);
                MessageBoxResult result = MessageBox.Show(this, "Team " + t.TeamName + " Updated Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TeamClearBox();              
                tDelete.IsEnabled = false;
                tUpdate.IsEnabled = false;
                tInsert.IsEnabled = true;
                LoadTeamList();
                cbteid.IsEnabled = false;
                txtname.IsEnabled = false;
                txthg.IsEnabled = false;
                txtowner.IsEnabled = false;


            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tInsert.IsEnabled = true;
                tview.IsEnabled = true;
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;

                cbteid.IsEnabled = false;
                txtname.IsEnabled = false;
                txthg.IsEnabled = false;
                txtowner.IsEnabled = false;
            }
        }
        private void tInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            Team t = new Team();
            try
            {
                if (tInsert.Content.ToString() == "Add New Team")
                {
                    TeamClearBox();
                    cbteid.IsEnabled = true;
                    txtname.IsEnabled = true;
                    txthg.IsEnabled = true;
                    txtowner.IsEnabled = true;
                    tUpdate.IsEnabled = false;
                    tDelete.IsEnabled = false;
                    tview.IsEnabled = true;
                    cbteid.IsEditable = true;
                    cbteid.Text = string.Empty;
                    tInsert.Content = "Insert Team";
                }
                else if (tInsert.Content.ToString() == "Insert Team")
                {
                    if (cbteid.Text == string.Empty)
                    {
                        MessageBox.Show("Team ID should not be empty");
                        Environment.Exit(0);
                    }
                    else if (!Regex.IsMatch(cbteid.Text, "[0-9]+"))
                    {

                        MessageBox.Show("team ID should contain  only numbers");
                        Environment.Exit(0);
                    }
                    tview.IsEnabled = true;
                    t.TeamId = int.Parse(cbteid.Text.ToString());
                    t.TeamName = txtname.Text;
                    t.HomeGround = txthg.Text;
                    t.Owners = txtowner.Text;
                    BLL obj = new BLL();
                    obj.insert_Team(t);
                    MessageBoxResult result = MessageBox.Show(this, "Team " + t.TeamName + " Added Successfully",
                         "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    tInsert.Content = "Add New Team";
                    TeamClearBox();
                    LoadTeamList();
                    cbteid.IsEditable = false;

                    cbteid.IsEnabled = false;
                    txtname.IsEnabled = false;
                    txthg.IsEnabled = false;
                    txtowner.IsEnabled = false;

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
                "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tInsert.IsEnabled = true;
                tview.IsEnabled = true;
                tUpdate.IsEnabled = false;
                tDelete.IsEnabled = false;

                

            }

        }
        private void tview_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                tInsert.Content = "Add New Team";
                tUpdate.IsEnabled = true;
                tDelete.IsEnabled = true;
                tInsert.IsEnabled = false;
                cbteid.IsEditable = true;
                var obje = new List<Team>();
                object item = tgrid.SelectedItem;
                if (item != null)
                {
                    id = (tgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    BLL obj = new BLL();

                    cbmid.IsEditable = true;
                    int search = int.Parse(id);
                    obje = obj.view_Team(search);
                    cbteid.Text = obje[0].TeamId.ToString();
                    txtname.Text = obje[0].TeamName;
                    txthg.Text = obje[0].HomeGround.ToString();
                    txtowner.Text = obje[0].Owners.ToString();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Team",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    tInsert.IsEnabled = true;
                    tview.IsEnabled = true;
                    tUpdate.IsEnabled = false;
                    tDelete.IsEnabled = false;

                }
                cbteid.IsEnabled = true;
                txtname.IsEnabled = true;
                txthg.IsEnabled = true;
                txtowner.IsEnabled = true;

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbteid.IsEnabled = true;
                txtname.IsEnabled = true;
                txthg.IsEnabled = true;
                txtowner.IsEnabled = true;
            }
        }
        #endregion

        #region Player Methods
        private void PlayerClearBox()
        {
            cbtid.Text = string.Empty;
            txtpname.Clear();
            txtage.Clear();
            cbpid.Text = string.Empty;
        }
        private void LoadPlayerList()
        {
            pInsert.IsEnabled = true;
            pUpdate.IsEnabled = false;
            pDelete.IsEnabled = false;
            tview.IsEnabled = true;
            BLL obj = new BLL();
            List<Player> pl = new List<Player>();
             pl = obj.GetAll_Player();
            pgrid.ItemsSource = pl;
            cbpid.ItemsSource = pl;
            cbpid.DisplayMemberPath = "PlayerId";

        }
        private void pInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                if (pInsert.Content.ToString() == "Add New Player")
                {
                    cbpid.IsEnabled = true;
                    txtpname.IsEnabled = true;
                    txtage.IsEnabled = true;
                    cbtid.IsEnabled = true;
                    PlayerClearBox();
                    LoadPlayerList();
                    LoadTeamList();
                    cbpid.IsEditable = true;
                    pview.IsEnabled = true;
                    pUpdate.IsEnabled = false;
                    pDelete.IsEnabled = false;
                    pInsert.Content = "Insert Player";
                }
                else if (pInsert.Content.ToString() == "Insert Player")
                {
                    if (cbpid.Text == string.Empty)
                    {
                        MessageBox.Show("Player ID should not be empty");
                        Environment.Exit(0);
                    }
                    else if (!Regex.IsMatch(cbpid.Text, "[0-9]+"))
                    {

                        MessageBox.Show("Player ID should contain  only numbers");
                        Environment.Exit(0);
                    }
                    Player p = new Player();
                    p.PlayerId = int.Parse(cbpid.Text.ToString());
                    p.TeamId = int.Parse(cbtid.Text.ToString());
                    p.PlayerName = txtpname.Text;
                    p.Age = int.Parse(txtage.Text);
                    BLL obj = new BLL();
                    obj.insert_Player(p);
                    MessageBoxResult result = MessageBox.Show(this, "Player " + p.PlayerName + " Added Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    pInsert.Content = "Add New Player";
                    LoadTeamList();
                    LoadPlayerList();
                    PlayerClearBox();
                    pUpdate.IsEnabled = false;
                    pDelete.IsEnabled = false;
                    pview.IsEnabled = true;
                    cbpid.IsEditable = false;

                    cbpid.IsEnabled = false;
                    txtpname.IsEnabled = false;
                    txtage.IsEnabled = false;
                    cbtid.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                pInsert.IsEnabled = true;
                pview.IsEnabled = true;
                pUpdate.IsEnabled = false;
                pDelete.IsEnabled = false;

             
            }
        }
        private void pUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Player p = new Player();
                Player lb = (Player)cbpid.SelectedItem;
                p.PlayerId = lb.PlayerId;
                Team tb = (Team)cbtid.SelectedItem;
                p.TeamId = tb.TeamId;
                p.PlayerName = txtpname.Text;
                p.Age = int.Parse(txtage.Text);
                BLL obj = new BLL();
                obj.update_Player(p);
                MessageBoxResult result = MessageBox.Show(this, "Player " + p.PlayerName + " Updated Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadTeamList();
                LoadPlayerList();
                PlayerClearBox();
                cbpid.IsEditable = false;
                pUpdate.IsEnabled = false;
                pDelete.IsEnabled = false;
                pUpdate.IsEnabled = false;
                pInsert.IsEnabled = true;

                cbpid.IsEnabled = false;
                txtpname.IsEnabled = false;
                txtage.IsEnabled = false;
                cbtid.IsEnabled = false;
                LoadPlayerList();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                pInsert.IsEnabled = true;
                pview.IsEnabled = true;
                pUpdate.IsEnabled = false;
                pDelete.IsEnabled = false;

                cbpid.IsEnabled = false;
                txtpname.IsEnabled = false;
                txtage.IsEnabled = false;
                cbtid.IsEnabled = false;
            }
        }
        private void pDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;
                int id = int.Parse(cbpid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Player(id);
                if (obje == 1)
                {
                    MessageBoxResult result = MessageBox.Show(this, "Player Removed Successfully",
                           "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadTeamList();
                    LoadPlayerList();
                    PlayerClearBox();
                    cbpid.IsEditable = false;
                    pDelete.IsEnabled = false;
                    pDelete.IsEnabled = false;
                    pUpdate.IsEnabled = false;
                    pInsert.IsEnabled = true;

                    cbpid.IsEnabled = false;
                    txtpname.IsEnabled = false;
                    txtage.IsEnabled = false;
                    cbtid.IsEnabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                pInsert.IsEnabled = true;
                pview.IsEnabled = true;
                pUpdate.IsEnabled = false;
                pDelete.IsEnabled = false;

                cbpid.IsEnabled = false;
                txtpname.IsEnabled = false;
                txtage.IsEnabled = false;
                cbtid.IsEnabled = false;
            }
        }

        private void pview_Click(object sender, RoutedEventArgs e)
        {

            try
            {
               
                pUpdate.IsEnabled = true;
                pDelete.IsEnabled = true;
                pInsert.IsEnabled = false;
                cbpid.IsEditable = true;
                var obje = new List<Player>();
                object item = pgrid.SelectedItem;
                if (item != null)
                {
                    id = (pgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    BLL obj = new BLL();
                  
                    cbpid.IsEditable = true;
                    int search = int.Parse(id);
                    obje = obj.view_Player(search);
                    cbpid.Text = obje[0].PlayerId.ToString();
                    txtpname.Text = obje[0].PlayerName;
                    cbtid.Text = obje[0].TeamId.ToString();
                    txtage.Text = obje[0].Age.ToString();
                    cbpid.IsEnabled = true;
                    txtpname.IsEnabled = true;
                    txtage.IsEnabled = true;
                    cbtid.IsEnabled = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Players",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    pInsert.IsEnabled = true;
                    pview.IsEnabled = true;
                    pUpdate.IsEnabled = false;
                    pDelete.IsEnabled = false;
                    cbpid.IsEnabled = true;
                    txtpname.IsEnabled = true;
                    txtage.IsEnabled = true;
                    cbtid.IsEnabled = true;

                }

                }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region Match Methods
        private void MatchClearBox()
        {
            cbmid.Text = string.Empty;
            txtteamoneid.Clear();
            txtteamtwoid.Clear();
            cbvenueid.Text = string.Empty;
        }
        private void LoadMatchList()
        {
            mInsert.IsEnabled = true;
            mUpdate.IsEnabled = false;
            mDelete.IsEnabled = false;
            mview.IsEnabled = true;
            BLL obj = new BLL();
            List<IPL_Entity.Match> pl = obj.GetAll_Match().ToList();
            mgrid.ItemsSource = pl;
            cbmid.ItemsSource = pl;
            cbmid.DisplayMemberPath = "MatchId";
            cbmaid.ItemsSource = pl;
            cbmaid.DisplayMemberPath = "MatchId";
            cbnmid.ItemsSource = pl;
            cbnmid.DisplayMemberPath = "MatchId";
            cbvenueid.IsEditable = false;

        }
        private void mInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                if (mInsert.Content.ToString() == "Add New Match")
                {
                    MatchClearBox();
                    LoadMatchList();
                    LoadVenueList();
                    cbmid.IsEnabled = true;
                    
                    txtteamoneid.IsEnabled = true;
                    cbvenueid.IsEnabled = true;
                    txtteamtwoid.IsEnabled = true;
                    cbmid.IsEditable = true;
                    mUpdate.IsEnabled = false;
                    mDelete.IsEnabled = false;
                    mview.IsEnabled = true;
                    mInsert.Content = "Insert Match";
                }
                else if (mInsert.Content.ToString() == "Insert Match")
                {
                    Venue v = new Venue();
                    BLL obj = new BLL();
                    IPL_Entity.Match m = new IPL_Entity.Match();
                    obj.check(cbmid.Text);
                    m.MatchId = int.Parse(cbmid.Text.ToString());
                    obj.check(txtteamoneid.Text);
                    m.TeamOneId = int.Parse(txtteamoneid.Text);
                    obj.check(txtteamtwoid.Text);
                    m.TeamTwoId = int.Parse(txtteamtwoid.Text);

                    Venue lb = (Venue)(cbvenueid.SelectedItem);
                    m.VenueId = lb.VenueId;
                  
                    obj.insert_Match(m);
                    MessageBoxResult result = MessageBox.Show(this, "Match " + m.MatchId + " Added Successfully",
                       "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadMatchList();
                    LoadVenueList();
                    MatchClearBox();
                    mInsert.Content = "Add New Match";
                    cbmid.IsEditable = false;
                    mUpdate.IsEnabled = false;
                    mDelete.IsEnabled = false;
                    mview.IsEnabled = true;

                    cbmid.IsEnabled = false;

                    txtteamoneid.IsEnabled = false;
                    cbvenueid.IsEnabled = false;
                    txtteamtwoid.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                mInsert.IsEnabled = true;
                mview.IsEnabled = true;
                mUpdate.IsEnabled = false;
                mDelete.IsEnabled = false;

              
            }
        }

        private void mUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                IPL_Entity.Match m = new IPL_Entity.Match();
                IPL_Entity.Match mb = (IPL_Entity.Match)cbmid.SelectedItem;                
                obj.check(cbmid.Text);
                m.MatchId = int.Parse(cbmid.Text.ToString());
                obj.check(txtteamoneid.Text);
                m.TeamOneId = int.Parse(txtteamoneid.Text);
                obj.check(txtteamtwoid.Text);
                m.TeamTwoId = int.Parse(txtteamtwoid.Text);
                Venue lb = (Venue)(cbvenueid.SelectedItem);
                m.VenueId = lb.VenueId;
              
                obj.update_Match(m);
                MessageBoxResult result = MessageBox.Show(this, "Match " + m.MatchId + " Updated Successfully",
                     "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadVenueList();
                LoadMatchList();
                MatchClearBox();
                cbmid.IsEditable = false;
                mDelete.IsEnabled = false;
                mUpdate.IsEnabled = false;
                mInsert.IsEnabled = true;

                cbmid.IsEnabled = false;

                txtteamoneid.IsEnabled = false;
                cbvenueid.IsEnabled = false;
                txtteamtwoid.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                mInsert.IsEnabled = true;
                mview.IsEnabled = true;
                mUpdate.IsEnabled = false;
                mDelete.IsEnabled = false;

                cbmid.IsEnabled = false;

                txtteamoneid.IsEnabled = false;
                cbvenueid.IsEnabled = false;
                txtteamtwoid.IsEnabled = false;
            }
        }
        private void mDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;

                int id = int.Parse(cbmid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Match(id);
                MessageBoxResult result = MessageBox.Show(this, "Match Removed Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadVenueList();
                LoadMatchList();
                MatchClearBox();
                cbmid.IsEditable = false;
                mDelete.IsEnabled = false;
                mUpdate.IsEnabled = false;
                mInsert.IsEnabled = true;
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                mInsert.IsEnabled = true;
                mview.IsEnabled = true;
                mUpdate.IsEnabled = false;
                mDelete.IsEnabled = false;

                cbmid.IsEnabled = false;

                txtteamoneid.IsEnabled = false;
                cbvenueid.IsEnabled = false;
                txtteamtwoid.IsEnabled = false;
            }
        }
        private void mview_Click(object sender, RoutedEventArgs e)
        {
            try {
               
                mUpdate.IsEnabled = true;
            mDelete.IsEnabled = true;
            mInsert.IsEnabled = false;
            cbmid.IsEditable = true;
         
            var obje = new List<IPL_Entity.Match>();
            object item = mgrid.SelectedItem;
            if (item != null)
            {
                id = (mgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                BLL obj = new BLL();
             
                cbmid.IsEditable = true;
                int search = int.Parse(id);
                obje = obj.view_Match(search);
                cbmid.Text = obje[0].MatchId.ToString();             
                txtteamoneid.Text = obje[0].TeamOneId.ToString();
                txtteamtwoid.Text = obje[0].TeamTwoId.ToString();
                    cbvenueid.Text = obje[0].VenueId.ToString();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Match Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    mInsert.IsEnabled = true;
                    mview.IsEnabled = true;
                    mUpdate.IsEnabled = false;
                    mDelete.IsEnabled = false;

                }
                cbmid.IsEnabled = true;

                txtteamoneid.IsEnabled = true;
                cbvenueid.IsEnabled = true;
                txtteamtwoid.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                mInsert.IsEnabled = true;
                mview.IsEnabled = true;
                mUpdate.IsEnabled = false;
                mDelete.IsEnabled = false;
                cbmid.IsEnabled = true;

                txtteamoneid.IsEnabled = true;
                cbvenueid.IsEnabled = true;
                txtteamtwoid.IsEnabled = true;
            }
        }

        #endregion


        #region Schedule Methods
        private void ScheduleClearBox()
        {
            cbmaid.Text = string.Empty;
            cbschid.Text = string.Empty;
            dpschdate.SelectedDate = null;
            txtstarttime.Clear();
            txtendtime.Clear();
            
        }
        private void LoadScheduleList()
        {
            sInsert.IsEnabled = true;
            sUpdate.IsEnabled = false;
            sDelete.IsEnabled = false;
            sview.IsEnabled = true;
            BLL obj = new BLL();
            List<Schedule> sc = obj.GetAll_Schedule().ToList();
            sgrid.ItemsSource = sc;
            cbschid.ItemsSource = sc;
            cbschid.DisplayMemberPath = "ScheduleId";
            cbmaid.IsEditable = false;
         

        }
        private void sInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                if (sInsert.Content.ToString() == "Add New Schedule")
                {
                    ScheduleClearBox();
                    cbschid.IsEnabled = true;
                    cbmaid.IsEnabled = true;
                    dpschdate.IsEnabled = true;
                    txtstarttime.IsEnabled = true;
                    txtendtime.IsEnabled = true;
                    cbschid.IsEditable = true;
                    sInsert.Content = "Insert Schedule";
                    sUpdate.IsEnabled = false;
                    sDelete.IsEnabled = false;
                    sview.IsEnabled = true;
                }
                else if (sInsert.Content.ToString() == "Insert Schedule")
                {
                    Schedule s = new Schedule();
                    if (cbschid.Text == string.Empty)
                    {
                        MessageBox.Show("Schedule ID should not be empty");
                       
                    }
                    else if (!Regex.IsMatch(cbschid.Text, "[0-9]+"))
                    {

                        MessageBox.Show("Schedule ID should contain  only numbers");
                       
                    }
                    s.ScheduleId = int.Parse(cbschid.Text.ToString());
                    IPL_Entity.Match mb = (IPL_Entity.Match)(cbmaid.SelectedItem);
                    s.MatchId = mb.MatchId;
                    //  Venue lb = (Venue)(cbvid.SelectedItem);
                  
                    s.Schedule_VenueId = mb.VenueId;
                    s.ScheduleDate = DateTime.Parse(dpschdate.Text);
                    s.StartTime = txtstarttime.Text;
                    s.EndTime = txtendtime.Text;
                    BLL obj = new BLL();
                    obj.insert_Schedule(s);
                    MessageBoxResult result = MessageBox.Show(this, "Schedule " + s.ScheduleId + " Added Successfully",
                      "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadMatchList();
                    LoadVenueList();
                    LoadScheduleList();
                    ScheduleClearBox();
                    sInsert.Content = "Add New Schedule";
                   
                    sUpdate.IsEnabled = false;
                    sDelete.IsEnabled = false;
                    sview.IsEnabled = true;

                    cbschid.IsEnabled = false;
                    cbmaid.IsEnabled = false;
                    dpschdate.IsEnabled = false;
                    txtstarttime.IsEnabled = false;
                    txtendtime.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                sInsert.IsEnabled = true;
                sview.IsEnabled = true;
                sUpdate.IsEnabled = false;
                sDelete.IsEnabled = false;
               
            }
        }

        private void sUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Schedule s = new Schedule();
                Schedule sb = (Schedule)cbschid.SelectedItem;
                s.ScheduleId = sb.ScheduleId;
                IPL_Entity.Match mb = (IPL_Entity.Match)(cbmaid.SelectedItem);
                s.MatchId = mb.MatchId;
                     
                s.ScheduleDate = DateTime.Parse(dpschdate.Text);
                s.StartTime = txtstarttime.Text;
                s.EndTime = txtendtime.Text;
                BLL obj = new BLL();
                obj.update_Schedule(s);
                MessageBoxResult result = MessageBox.Show(this, "Schedule " + s.ScheduleId + " Updated Successfully",
                     "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadVenueList();
                LoadMatchList();
                LoadScheduleList();
                ScheduleClearBox();
               
                sDelete.IsEnabled = false;
                sUpdate.IsEnabled = false;
                sInsert.IsEnabled = true;

                cbschid.IsEnabled = false;
                cbmaid.IsEnabled = false;
                dpschdate.IsEnabled = false;
                txtstarttime.IsEnabled = false;
                txtendtime.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                sInsert.IsEnabled = true;
                sview.IsEnabled = true;
                sUpdate.IsEnabled = false;
                sDelete.IsEnabled = false;

                cbschid.IsEnabled = false;
                cbmaid.IsEnabled = false;
                dpschdate.IsEnabled = false;
                txtstarttime.IsEnabled = false;
                txtendtime.IsEnabled = false;
            }
        }
        private void sDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;

                int id = int.Parse(cbschid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Schedule(id);
                if (obje == 1)
                {
                    MessageBoxResult result = MessageBox.Show(this, "Schedule Removed Successfully",
                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadVenueList();
                    LoadMatchList();
                    LoadScheduleList();
                    ScheduleClearBox();
                  
                    sDelete.IsEnabled = false;
                    sUpdate.IsEnabled = false;
                    sInsert.IsEnabled = true;

                    cbschid.IsEnabled = false;
                    cbmaid.IsEnabled = false;
                    dpschdate.IsEnabled = false;
                    txtstarttime.IsEnabled = false;
                    txtendtime.IsEnabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                sInsert.IsEnabled = true;
                sview.IsEnabled = true;
                sUpdate.IsEnabled = false;
                sDelete.IsEnabled = false;
                cbschid.IsEnabled = false;
                cbmaid.IsEnabled = false;
                dpschdate.IsEnabled = false;
                txtstarttime.IsEnabled = false;
                txtendtime.IsEnabled = false;
            }
        }
        private void sview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                sUpdate.IsEnabled = true;
                sDelete.IsEnabled = true;
                sInsert.IsEnabled = false;
                cbschid.IsEditable = true;
                var obje = new List<Schedule>();
                object item = sgrid.SelectedItem;
                if (item != null)
                {
                    id = (sgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    BLL obj = new BLL();
                 
                    cbschid.IsEditable = true;
                    int search = int.Parse(id);
           
                obje = obj.view_Schedule(search);
                    cbschid.Text = obje[0].ScheduleId.ToString();
               
                cbmaid.Text = obje[0].MatchId.ToString();
                dpschdate.SelectedDate = obje[0].ScheduleDate;
                txtstarttime.Text = obje[0].StartTime.ToString();
                txtendtime.Text = obje[0].EndTime.ToString();

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Schedule Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    sInsert.IsEnabled = true;
                    sview.IsEnabled = true;
                    sUpdate.IsEnabled = false;
                    sDelete.IsEnabled = false;

                }
                cbschid.IsEnabled = true;
                cbmaid.IsEnabled = true;
                dpschdate.IsEnabled = true;
                txtstarttime.IsEnabled = true;
                txtendtime.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                sInsert.IsEnabled = true;
                sview.IsEnabled = true;
                sUpdate.IsEnabled = false;
                sDelete.IsEnabled = false;
                cbschid.IsEnabled = true;
                cbmaid.IsEnabled = true;
                dpschdate.IsEnabled = true;
                txtstarttime.IsEnabled = true;
                txtendtime.IsEnabled = true;
            }
        }
        #endregion

        #region Venue Methods
        private void VenueClearBox()
        {
            cbvenid.Text = string.Empty;
            txtloc.Clear();
            txtdes.Clear();
        }
        private void LoadVenueList()
        {
            vInsert.IsEnabled = true;
            vUpdate.IsEnabled = false;
            vDelete.IsEnabled = false;
            vview.IsEnabled = true;
            BLL obj = new BLL();
            List<Venue> v = obj.GetAll_venue().ToList();
            vgrid.ItemsSource = v;          
            cbvenueid.ItemsSource = v;
            cbvenueid.DisplayMemberPath = "VenueId";
            cbvenid.ItemsSource = v;
            cbvenid.DisplayMemberPath = "VenueId";
        }
        private void vInsert_Click(object sender, RoutedEventArgs e)
        {

            Entities1 entity = new Entities1();
            try
            {
                if (vInsert.Content.ToString() == "Add New Venue")
                {
                    cbvenid.IsEnabled = true;
                    txtloc.IsEnabled = true;
                    txtdes.IsEnabled = true;
                    VenueClearBox();
                    vInsert.Content = "Insert Venue";
                    vUpdate.IsEnabled = false;
                    vDelete.IsEnabled = false;
                    vview.IsEnabled = true;
                }
                else if (vInsert.Content.ToString() == "Insert Venue")
                {
                    if (cbvenid.Text == string.Empty)
                    {
                        MessageBox.Show("Venue ID should not be empty");
                        
                    }
                    else if (!Regex.IsMatch(cbvenid.Text, "[0-9]+"))
                    {

                        MessageBox.Show("Venue ID should contain  only numbers");
                      
                    }
                    Venue v = new Venue();
                    v.VenueId = int.Parse(cbvenid.Text.ToString());
                    v.Location = txtloc.Text;
                    v.VenueDescription = txtdes.Text;
                    BLL obj = new BLL();
                    obj.insert_Venue(v);
                    MessageBoxResult result = MessageBox.Show(this, "Venue " + v.VenueId + " Added Successfully",
                      "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadVenueList();
                    VenueClearBox();
                    vInsert.Content = "Add New Venue";
                    cbvenid.IsEditable = false;
                    vUpdate.IsEnabled = false;
                    vDelete.IsEnabled = false;
                    vview.IsEnabled = true;
                    cbvenid.IsEnabled = false;
                    txtloc.IsEnabled = false;
                    txtdes.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                vInsert.IsEnabled = true;
                vview.IsEnabled = true;
                vUpdate.IsEnabled = false;
                vDelete.IsEnabled = false;
               
            }
        }

        private void vUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Venue v = new Venue();
                Venue sb = (Venue)cbvenid.SelectedItem;
                v.VenueId = sb.VenueId;
                v.Location = txtloc.Text;
                v.VenueDescription = txtdes.Text;
                BLL obj = new BLL();
                obj.update_Venue(v);
                MessageBoxResult result = MessageBox.Show(this, "Venue " + v.VenueId + " Updated Successfully",
                 "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadVenueList();
                VenueClearBox();
                vDelete.IsEnabled = false;
                vUpdate.IsEnabled = false;
                vInsert.IsEnabled = true;
                cbvenid.IsEnabled = false;
                txtloc.IsEnabled = false;
                txtdes.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                vInsert.IsEnabled = true;
                vview.IsEnabled = true;
                vUpdate.IsEnabled = false;
                vDelete.IsEnabled = false;
                cbvenid.IsEnabled = false;
                txtloc.IsEnabled = false;
                txtdes.IsEnabled = false;
            }
        }

        private void vDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;

                int id = int.Parse(cbvenid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Venue(id);
                MessageBoxResult result = MessageBox.Show(this, "Venue Removed Successfully",
                   "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadVenueList();
                VenueClearBox();
                vDelete.IsEnabled = false;
                vUpdate.IsEnabled = false;
                vInsert.IsEnabled = true;
                cbvenid.IsEnabled = false;
                txtloc.IsEnabled = false;
                txtdes.IsEnabled = false;
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                vInsert.IsEnabled = true;
                vview.IsEnabled = true;
                vUpdate.IsEnabled = false;
                vDelete.IsEnabled = false;
                cbvenid.IsEnabled = false;
                txtloc.IsEnabled = false;
                txtdes.IsEnabled = false;
            }
        }

        private void vview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                vUpdate.IsEnabled = true;
                vDelete.IsEnabled = true;
                vInsert.IsEnabled = false;
                cbvenid.IsEditable = true;
                var obje = new List<Venue>();
                object item = vgrid.SelectedItem;
                if (item != null)
                {
                    id = (vgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    BLL obj = new BLL();
                
                    cbvenid.IsEditable = true;                   
                    int search = int.Parse(id);                   
                    obje = obj.view_Venue(search);
                    cbvenid.Text = obje[0].VenueId.ToString();
                    txtloc.Text = obje[0].Location;
                    txtdes.Text = obje[0].VenueDescription.ToString();
                    cbvenid.IsEnabled = true;
                    txtloc.IsEnabled = true;
                    txtdes.IsEnabled = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Venue Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    vInsert.IsEnabled = true;
                    vview.IsEnabled = true;
                    vUpdate.IsEnabled = false;
                    vDelete.IsEnabled = false;
                    cbvenid.IsEnabled = true;
                    txtloc.IsEnabled = true;
                    txtdes.IsEnabled = true;

                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                vInsert.IsEnabled = true;
                vview.IsEnabled = true;
                vUpdate.IsEnabled = false;
                vDelete.IsEnabled = false;
            }
        }
        #endregion


        #region Statistics Methods
        private void StatisticsClearBox()
        {
            cbtmid.Text = string.Empty;
            txtplayed.Clear();
            txtwon.Clear();
            txtlost.Clear();
            txttied.Clear();
            txtnr.Clear();
            txtnetrr.Clear();
            txtpts.Clear();
            txtfpts.Clear();
        }
        private void LoadStat()
        {
            stInsert.IsEnabled = true;
            stUpdate.IsEnabled = false;
            stDelete.IsEnabled = false;
            tview.IsEnabled = true;
            BLL obj = new BLL();
            List<Stat> st = obj.GetAll_Stat().ToList();
            stgrid.ItemsSource = st;
            cbtmid.ItemsSource = st;
            cbtmid.DisplayMemberPath = "TeamId";

        }
        private void stInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                if (stInsert.Content.ToString() == "Add New Statistics")
                {
                    StatisticsClearBox();
                    cbtmid.IsEnabled = true;
                    txtplayed.IsEnabled = true;
                    txtwon.IsEnabled = true;
                    txtlost.IsEnabled = true;
                    txttied.IsEnabled = true;
                    txtnr.IsEnabled = true;
                    txtnetrr.IsEnabled = true;
                    txtpts.IsEnabled = true;
                    txtfpts.IsEnabled = true;
                    cbtmid.IsEditable = true;
                    stUpdate.IsEnabled = false;
                    stDelete.IsEnabled = false;
                    stview.IsEnabled = true;
                    BLL obj = new BLL();
                    List<Team> t = obj.GetAll_Team().ToList();
                    stInsert.Content = "Insert Statistics";
                    cbtmid.ItemsSource = t;
                    cbtmid.DisplayMemberPath = "TeamId";
                }
                else if (stInsert.Content.ToString() == "Insert Statistics")
                {
                    Stat st = new Stat();
                   
                    BLL obj = new BLL();
                    obj.check(cbtmid.Text);
                    st.TeamId = int.Parse(cbtmid.Text.ToString());
                    obj.check(txtplayed.Text);
                    st.Played = int.Parse(txtplayed.Text);
                    obj.check(txtwon.Text);
                    st.Won = int.Parse(txtwon.Text);
                    obj.check(txtlost.Text);
                    st.Lost = int.Parse(txtlost.Text);
                    obj.check(txttied.Text);
                    st.Tied = int.Parse(txttied.Text);
                    obj.check(txtnr.Text);
                    st.NR = int.Parse(txtnr.Text);
                    obj.check(txtnetrr.Text);
                    st.NetRR = int.Parse(txtnetrr.Text);
                    obj.check(txtpts.Text);
                    st.Pts = int.Parse(txtpts.Text);
                    obj.check(txtfpts.Text);
                    st.FromPoints = int.Parse(txtfpts.Text);

                    obj.insert_Statistics(st);
                    MessageBoxResult result = MessageBox.Show(this, "Statistics Added Successfully",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    StatisticsClearBox();
                    LoadStat();
                    stInsert.Content = "Add New Statistics";
                   stUpdate.IsEnabled = false;
                    stDelete.IsEnabled = false;
                    stview.IsEnabled = true;
                    cbtmid.IsEnabled = false;
                    txtplayed.IsEnabled = false;
                    txtwon.IsEnabled = false;
                    txtlost.IsEnabled = false;
                    txttied.IsEnabled = false;
                    txtnr.IsEnabled = false;
                    txtnetrr.IsEnabled = false;
                    txtpts.IsEnabled = false;
                    txtfpts.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                stInsert.IsEnabled = true;
                stview.IsEnabled = true;
                stUpdate.IsEnabled = false;
                stDelete.IsEnabled = false;
              
            }
        }

        private void stUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                Stat st = new Stat();

                obj.check(cbtmid.Text);
                st.TeamId = int.Parse(cbtmid.Text.ToString());
                obj.check(txtplayed.Text);
                st.Played = int.Parse(txtplayed.Text);
                obj.check(txtwon.Text);
                st.Won = int.Parse(txtwon.Text);
                obj.check(txtlost.Text);
                st.Lost = int.Parse(txtlost.Text);
                obj.check(txttied.Text);
                st.Tied = int.Parse(txttied.Text);
                obj.check(txtnr.Text);
                st.NR = int.Parse(txtnr.Text);
                obj.check(txtnetrr.Text);
                st.NetRR = int.Parse(txtnetrr.Text);
                obj.check(txtpts.Text);
                st.Pts = int.Parse(txtpts.Text);
                obj.check(txtfpts.Text);
                st.FromPoints = int.Parse(txtfpts.Text);

               
                obj.update_Statistics(st);
                MessageBoxResult result = MessageBox.Show(this, "Statistics Updated Successfully",
             "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadStat();
                StatisticsClearBox();
                stDelete.IsEnabled = false;
                stUpdate.IsEnabled = false;
                stInsert.IsEnabled = true;
                cbtmid.IsEnabled = false;
                txtplayed.IsEnabled = false;
                txtwon.IsEnabled = false;
                txtlost.IsEnabled = false;
                txttied.IsEnabled = false;
                txtnr.IsEnabled = false;
                txtnetrr.IsEnabled = false;
                txtpts.IsEnabled = false;
                txtfpts.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                stInsert.IsEnabled = true;
                stview.IsEnabled = true;
                stUpdate.IsEnabled = false;
                stDelete.IsEnabled = false;
                cbtmid.IsEnabled = false;
                txtplayed.IsEnabled = false;
                txtwon.IsEnabled = false;
                txtlost.IsEnabled = false;
                txttied.IsEnabled = false;
                txtnr.IsEnabled = false;
                txtnetrr.IsEnabled = false;
                txtpts.IsEnabled = false;
                txtfpts.IsEnabled = false;
            }
        }
        private void stDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;
                int id = int.Parse(cbtmid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Statistics(id);
                if (obje == 1)
                {
                    MessageBoxResult result = MessageBox.Show(this, "Statistics Removed Successfully",
             "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    StatisticsClearBox();
                    LoadStat();
                    stDelete.IsEnabled = false;
                    stUpdate.IsEnabled = false;
                    stInsert.IsEnabled = true;
                    cbtmid.IsEnabled = false;
                    txtplayed.IsEnabled = false;
                    txtwon.IsEnabled = false;
                    txtlost.IsEnabled = false;
                    txttied.IsEnabled = false;
                    txtnr.IsEnabled = false;
                    txtnetrr.IsEnabled = false;
                    txtpts.IsEnabled = false;
                    txtfpts.IsEnabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                stInsert.IsEnabled = true;
                stview.IsEnabled = true;
                stUpdate.IsEnabled = false;
                stDelete.IsEnabled = false;
            }
        }
        private void stview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                  
                var obje = new List<Stat>();
                object item = stgrid.SelectedItem;
                stUpdate.IsEnabled = true;
                stDelete.IsEnabled = true;
                stInsert.IsEnabled = false;
                if (item != null)
                {
                    id = (stgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    BLL obj = new BLL();
                                 
                  
               
                int search = int.Parse(id);
              
                obje = obj.view_Statistics(search);
                    cbtmid.Text = obje[0].TeamId.ToString();
                txtplayed.Text = obje[0].Played.ToString();
                txtwon.Text = obje[0].Won.ToString();
                txtlost.Text = obje[0].Lost.ToString();
                txttied.Text = obje[0].Tied.ToString();
                txtnr.Text = obje[0].NR.ToString();
                txtnetrr.Text = obje[0].NetRR.ToString();
                txtpts.Text = obje[0].Pts.ToString();
                txtfpts.Text = obje[0].FromPoints.ToString();
                    cbtmid.IsEnabled = true;
                    txtplayed.IsEnabled = true;
                    txtwon.IsEnabled = true;
                    txtlost.IsEnabled = true;
                    txttied.IsEnabled = true;
                    txtnr.IsEnabled = true;
                    txtnetrr.IsEnabled = true;
                    txtpts.IsEnabled = true;
                    txtfpts.IsEnabled = true;
                }
                 else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to View Statistics Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    stInsert.IsEnabled = true;
                    stview.IsEnabled = true;
                    stUpdate.IsEnabled = false;
                    stDelete.IsEnabled = false;
                    cbtmid.IsEnabled = true;
                    txtplayed.IsEnabled = true;
                    txtwon.IsEnabled = true;
                    txtlost.IsEnabled = true;
                    txttied.IsEnabled = true;
                    txtnr.IsEnabled = true;
                    txtnetrr.IsEnabled = true;
                    txtpts.IsEnabled = true;
                    txtfpts.IsEnabled = true;

                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                stInsert.IsEnabled = true;
                stview.IsEnabled = true;
                stUpdate.IsEnabled = false;
                stDelete.IsEnabled = false;
            }
        }
        #endregion


        #region Ticket category
        private void TcatClearBox()
        {
            cbtcid.Text = string.Empty;
            txttcname.Clear();
            txttcdes.Clear();
        }
        private void LoadTCatList()
        {
            BLL obj = new BLL();
            List<TicketCategory> t = obj.GetAll_Tc().ToList();
            tcgrid.ItemsSource = t;
            cbtcid.ItemsSource = t;
            cbtcid.DisplayMemberPath = "TicketCategoryId";
            tcInsert.IsEnabled = true;
            tcUpdate.IsEnabled = false;
            tcDelete.IsEnabled = false;
            tcview.IsEnabled = true;

        }
        private void tcDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;
                int id = int.Parse(cbtcid.Text);
                BLL obj = new BLL();
                obje = obj.delete_Tc(id);
                MessageBoxResult result = MessageBox.Show(this, "Ticket Category is Removed Successfully",
             "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TcatClearBox();
                LoadTCatList();
                tcDelete.IsEnabled = false;
                tcUpdate.IsEnabled = false;
                tcInsert.IsEnabled = true;
                cbtcid.IsEnabled = false;
                txttcname.IsEnabled = false;
                txttcdes.IsEnabled = false;
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tcInsert.IsEnabled = true;
                tcview.IsEnabled = true;
                tcUpdate.IsEnabled = false;
                tcDelete.IsEnabled = false;
                cbtcid.IsEnabled = false;
                txttcname.IsEnabled = false;
                txttcdes.IsEnabled = false;
            }
        }
        private void tcUpd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TicketCategory t = new TicketCategory();
                t.TicketCategoryId = int.Parse(cbtcid.Text.ToString());
                t.TicketCategoryName = txttcname.Text;
                t.TicketDescription = txttcdes.Text;
                BLL obj = new BLL();
                obj.update_Tc(t);
                MessageBoxResult result = MessageBox.Show(this, "Ticket Category is Updated Successfully",
              "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TcatClearBox();
                LoadTCatList();
                tcDelete.IsEnabled = false;
                tcUpdate.IsEnabled = false;
                tcInsert.IsEnabled = true;
                cbtcid.IsEnabled = false;
                txttcname.IsEnabled = false;
                txttcdes.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tcInsert.IsEnabled = true;
                tcview.IsEnabled = true;
                tcUpdate.IsEnabled = false;
                tcDelete.IsEnabled = false;
                cbtcid.IsEnabled = false;
                txttcname.IsEnabled = false;
                txttcdes.IsEnabled = false;
            }
        }
        private void tcInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            TicketCategory t = new TicketCategory();
            try
            {
                if (tcInsert.Content.ToString() == "Add New Category")
                {
                    TcatClearBox();
                    cbtcid.IsEnabled = true;
                    txttcname.IsEnabled = true;
                    txttcdes.IsEnabled = true;
                    cbtcid.IsEditable = true;
                    cbtcid.Text = string.Empty;
                    tcUpdate.IsEnabled = false;
                    tcDelete.IsEnabled = false;
                    tcview.IsEnabled = true;
                    tcInsert.Content = "Insert Category";
                }
                else if (tcInsert.Content.ToString() == "Insert Category")
                {
                    if (cbtcid.Text == string.Empty)
                    {
                        MessageBox.Show("TicketCategory ID should not be empty");

                    }
                    else if (!Regex.IsMatch(cbtcid.Text, "[0-9]+"))
                    {

                        MessageBox.Show("TicketCategory ID should contain  only numbers");

                    }
                    t.TicketCategoryId = int.Parse(cbtcid.Text.ToString());
                    t.TicketCategoryName = txttcname.Text;
                    t.TicketDescription = txttcdes.Text;
                    BLL obj = new BLL();
                   int x= obj.insert_Tc(t);
                    if (x == 1)
                    {
                        MessageBoxResult result = MessageBox.Show(this, "Ticket Category is Inserted Successfully",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        tcInsert.Content = "Add New category";
                        TcatClearBox();
                        LoadTCatList();
                        tcUpdate.IsEnabled = false;
                        tcDelete.IsEnabled = false;
                        tcview.IsEnabled = true;
                        cbtcid.IsEditable = false;
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show(this, "Error Found while inserting",
           "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tcInsert.IsEnabled = true;
                        tcview.IsEnabled = true;
                        tcUpdate.IsEnabled = false;
                        tcDelete.IsEnabled = false;
                    }
                    cbtcid.IsEnabled = false;
                    txttcname.IsEnabled = false;
                    txttcdes.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tcInsert.IsEnabled = true;
                tcview.IsEnabled = true;
                tcUpdate.IsEnabled = false;
                tcDelete.IsEnabled = false;
               
            }

        }
        private void tcview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                tcUpdate.IsEnabled = true;
                tcDelete.IsEnabled = true;
                tcInsert.IsEnabled = false;
                cbtcid.IsEditable = true;
                var obje = new List<TicketCategory>();
                object item = tcgrid.SelectedItem;
                if (item != null)
                {
                    id = (tcgrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    BLL obj = new BLL();
                   
                    cbtcid.IsEditable = true;
                  

                    obje = obj.view_Tc(int.Parse(id));
                    cbtcid.Text = obje[0].TicketCategoryId.ToString();
                    txttcname.Text = obje[0].TicketCategoryName;
                    txttcdes.Text = obje[0].TicketDescription;
                    cbtcid.IsEnabled = true;
                    txttcname.IsEnabled = true;
                    txttcdes.IsEnabled = true;

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to view category Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    tcInsert.IsEnabled = true;
                    tcview.IsEnabled = true;
                    tcUpdate.IsEnabled = false;
                    tcDelete.IsEnabled = false;

                }
            }

            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                tcInsert.IsEnabled = true;
                tcview.IsEnabled = true;
                tcUpdate.IsEnabled = false;
                tcDelete.IsEnabled = false;
            }

        }
        #endregion

        #region News Methods

        private void NewsClearBox()
        {
            cbnmid.Text = string.Empty;
            txtnewsdes.Clear();

        }
        private void LoadNewsList()
        {
            nwInsert.IsEnabled = true;
            nwUpdate.IsEnabled = false;
            nwDelete.IsEnabled = false;
            nwview.IsEnabled = true;
            BLL bl = new BLL();
            List<News> t = new List<News>();
            t = bl.GetAll_News().ToList();
            Entities1 entity = new Entities1();
            var query = from p in entity.News                        
                        select new
                        {
                           p.MatchId,
                           p.NewsDescription
                        };

            ngrid.ItemsSource = query.ToList();
            cbnmid.ItemsSource = t;
            cbnmid.DisplayMemberPath = "MatchId";

        }
        private void nwInsert_Click(object sender, RoutedEventArgs e)
        {
            Entities1 entity = new Entities1();
            News n = new News();
            try
            {
                if (nwInsert.Content.ToString() == "Add New News")
                {
                    NewsClearBox();
                    cbnmid.IsEnabled = true;
                    txtnewsdes.IsEnabled = true;
                    nwInsert.Content = "Insert News";
                    BLL obj = new BLL();
                    List<IPL_Entity.Match> t = obj.GetAll_Match().ToList();
                    nwUpdate.IsEnabled = false;
                    nwDelete.IsEnabled = false;
                    nwview.IsEnabled = true;
                    cbnmid.ItemsSource = t;
                    cbnmid.DisplayMemberPath = "MatchId";
                }
                else if (nwInsert.Content.ToString() == "Insert News")
                {
                    IPL_Entity.Match nb = (IPL_Entity.Match)cbnmid.SelectedItem;
                    n.MatchId = nb.MatchId;
                    n.NewsDescription = txtnewsdes.Text;
                    BLL obj = new BLL();
                    obj.insert_News(n);
                    MessageBoxResult result = MessageBox.Show(this, "News is Added Successfully",
              "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    nwInsert.Content = "Add New News";
                    LoadNewsList();
                    nwUpdate.IsEnabled = false;
                    nwDelete.IsEnabled = false;
                    nwview.IsEnabled = true;
                    NewsClearBox();
                    cbnmid.IsEnabled = false;
                    txtnewsdes.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                nwInsert.IsEnabled = true;
                nwview.IsEnabled = true;
                nwUpdate.IsEnabled = false;
                nwDelete.IsEnabled = false;
          
                nwInsert.Content = "Add New News";
            }
        }

        private void nwUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                News n = new News();

                n.MatchId = int.Parse(cbnmid.Text.ToString());
                n.NewsDescription = txtnewsdes.Text;
                BLL obj = new BLL();
                obj.update_News(n);
                MessageBoxResult result = MessageBox.Show(this, "News is Updated Successfully",
               "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                NewsClearBox();
                LoadNewsList();
                nwDelete.IsEnabled = false;
                nwUpdate.IsEnabled = false;
                nwInsert.IsEnabled = true;
                cbnmid.IsEnabled = false;
                txtnewsdes.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
             "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                nwInsert.IsEnabled = true;
                nwview.IsEnabled = true;
                nwUpdate.IsEnabled = false;
                nwDelete.IsEnabled = false;
              
            }
        }

        private void nwDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int obje;
                int id = int.Parse(cbnmid.Text);
                BLL obj = new BLL();
                obje = obj.delete_News(id);
                MessageBoxResult result = MessageBox.Show(this, "News is Removed Successfully",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                NewsClearBox();
                LoadNewsList();
                nwDelete.IsEnabled = false;
                nwUpdate.IsEnabled = false;
                nwInsert.IsEnabled = true;
                cbnmid.IsEnabled = false;
                txtnewsdes.IsEnabled = false;
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                nwInsert.IsEnabled = true;
                nwview.IsEnabled = true;
                nwUpdate.IsEnabled = false;
                nwDelete.IsEnabled = false;
               
            }
        }

        private void nwview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                nwInsert.IsEnabled = false;
                nwUpdate.IsEnabled = true;
                nwDelete.IsEnabled = true;
                cbnmid.IsEditable = true;
                var obje = new List<News>();
                object item = ngrid.SelectedItem;
                if (item != null)
                {
                    id = (ngrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    BLL obj = new BLL();

                
                  
                    int search = int.Parse(id);

                    obje = obj.view_News(search);
                    cbnmid.Text = obje[0].MatchId.ToString();
                    txtnewsdes.Text = obje[0].NewsDescription;
                    cbnmid.IsEnabled = true;
                    txtnewsdes.IsEnabled = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show(this, "Please Select a Row to view News Details",
                  "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    nwInsert.IsEnabled = true;
                    nwview.IsEnabled = true;
                    nwUpdate.IsEnabled = false;
                    nwDelete.IsEnabled = false;

                }
            }
            catch(Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(this, "" + ex.Message + "",
            "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                nwInsert.IsEnabled = true;
                nwview.IsEnabled = true;
                nwUpdate.IsEnabled = false;
                nwDelete.IsEnabled = false;
            }

        }
        #endregion

        #region Signout Method
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
