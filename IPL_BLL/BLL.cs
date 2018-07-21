using IPL_DAL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Employee_Exceptions;

namespace IPL_BLL
{
    public class BLL
    {
        /// <summary>
        /// Employee Validations are created in this file
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        #region Check Values 
        public int check(string st)
        {
            try
            {
                int value;
                if (int.TryParse(st, out value))
                {
                    return value;
                }
                else
                {

                    throw new Exception("Please Enter integer values");

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        #endregion

        #region Validate Team
        private static bool ValidateTeam(Team team)
        {
            bool isValidteam = true;
            StringBuilder sb = new StringBuilder();
            if (team.TeamName == string.Empty)
            {
                sb.AppendLine("Team Name Should be Provided..");
                isValidteam = false;
            }
            else if (!Regex.IsMatch(team.TeamName, @"[A-Z][a-z]+"))
            {
                sb.AppendLine("Team Name Should Start with Capital Letters..");
                isValidteam = false;
            }
            if (team.HomeGround == string.Empty)
            {
                sb.AppendLine("HomeGround Should be Provided..");
                isValidteam = false;
            }
            else if (!Regex.IsMatch(team.HomeGround, @"[A-Z][a-z]+"))
            {
                sb.AppendLine(" Home Ground Should Start with Capita Letters..");
                isValidteam = false;
            }
            if (team.Owners == string.Empty)
            {
                sb.AppendLine("Owners Should be Provided..");
                isValidteam = false;
            }
            else if (!Regex.IsMatch(team.Owners, @"[A-Z][a-z]+"))
            {
                sb.AppendLine(" Owners Should Start with Capital Letters..");
                isValidteam = false;
            }

            if (isValidteam == false)
            {
                throw new TeamException(sb.ToString());
            }
            return isValidteam;
        }
        #endregion

        #region Insert Team
        public void insert_Team(Team t)
        {
            try
            {
                if (ValidateTeam(t))
                {
                    DAL obj = new DAL();
                    obj.Add_Team(t);
                }
            }
            catch(TeamException ex)
            {
                throw ex;
            }
            

        }
        #endregion

        #region View Team
        public List<Team> view_Team(int id)
        {
            var obje = new List<Team>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Team(id);

            }
            catch (TeamException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Team
        public int delete_Team(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Team(id);

            }
            catch (TeamException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Team
        public void update_Team(Team t)
        {

            try
            {
                if (ValidateTeam(t))
                {

                    DAL obj = new DAL();

                    obj.Update_Team(t);
                }

            }
            catch (TeamException ex)
            {
                throw (ex);
            }


        }
        #endregion

        #region GetAll Team Details
        public List<Team> GetAll_Team()
        {
           
            try
            {
                DAL obj = new DAL();
                return  obj.SelectAll_Team();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #region ValidatePlayer
        private static bool ValidatePlayer(Player player)
        {
            bool ValidatePlayer = true;
            StringBuilder sb = new StringBuilder();

            if (player.PlayerName == string.Empty)
            {
                sb.AppendLine("Team Name Should be Provided..");
                ValidatePlayer = false;
            }
            else if (!Regex.IsMatch(player.PlayerName, @"[A-Z][a-z]+"))
            {
                sb.AppendLine("Team Name Should Start with Capital Letters..");
                ValidatePlayer = false;
            }
            if (player.Age.ToString() == string.Empty)
            {
                sb.AppendLine(" Age Should be Provided..");
                ValidatePlayer = false;
            }
            else if (player.Age < 18)
            {
                sb.AppendLine("Age start with 18 years");
            }

            if (ValidatePlayer == false)
            {
                throw new TeamException(sb.ToString());
            }
            return ValidatePlayer;
        }
        #endregion

        #region Insert Player
        public void insert_Player(Player p)
        {
            try
            {
                if (ValidatePlayer(p))
                {
                    DAL obj = new DAL();
                    obj.Add_Player(p);
                    //   obj.Delete_Team();
                }
            }
            catch(PlayerException ex)
            {
                throw ex;
            }

        }

        #endregion

        #region View Player
        public List<Player> view_Player(int id)
        {
            var obje = new List<Player>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Player(id);

            }
            catch (PlayerException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Player
        public int delete_Player(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Player(id);

            }
            catch (PlayerException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Player
        public void update_Player(Player p)
        {

            try
            {
                if (ValidatePlayer(p))
                {
                    DAL obj = new DAL();

                    obj.Update_Player(p);
                }

            }
            catch (PlayerException ex)
            {
                throw (ex);
            }


        }
        #endregion

        #region GetAll Player
        public List<Player> GetAll_Player()
        {
           
            try
            {
                DAL obj = new DAL();
                return obj.SelectAll_Player();
            }
            catch (PlayerException ex)
            {
                throw ex;
            }
           
        }
        #endregion

        #region Validate Venue
        private static bool ValidateVenue(Venue venue)
        {
            bool Validvenue = true;
            StringBuilder sb = new StringBuilder();

            if (Validvenue == false)
            {
                throw new VenueException(sb.ToString());
            }
            if (venue.Location == string.Empty)
            {
                sb.AppendLine("Location Name Should be Provided..");
                Validvenue = false;
            }
            else if (!Regex.IsMatch(venue.Location, @"[A-Z][a-z]+"))
            {
                sb.AppendLine("Location Name Should Start with Capital Letters..");
                Validvenue = false;
            }
            if (Validvenue == false)
            {
                throw new VenueException(sb.ToString());
            }
            return Validvenue;
        }
        #endregion

        #region Insert Venue
        public void insert_Venue(Venue v)
        {
            try
            {
                if (ValidateVenue(v))
                {
                    DAL obj = new DAL();
                    obj.Add_Venue(v);
                    //   obj.Delete_Team();
                }
            }
            catch (VenueException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View Venue
        public List<Venue> view_Venue(int id)
        {
            var obje = new List<Venue>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Venue(id);

            }
            catch (VenueException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region delete Venue
        public int delete_Venue(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Venue(id);

            }
            catch (VenueException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Venue
        public void update_Venue(Venue v)
        {

            try
            {
                if (ValidateVenue(v))
                {
                    DAL obj = new DAL();

                    obj.Update_Venue(v);
                }

            }
            catch (VenueException ex)
            {
                throw (ex);
            }


        }
        #endregion

        #region GetAll Venue
        public List<Venue> GetAll_venue()
        {
            var obje = new List<Venue>();
            try
            {
                DAL obj = new DAL();
                obje = obj.SelectAll_venue();
            }
            catch (VenueException ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion


        #region Insert Match
        public void insert_Match(IPL_Entity.Match m)
        {
            try
            {

                DAL obj = new DAL();
                obj.Add_Match(m);
                //   obj.Delete_Team();
            }
            catch(MatchException ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View MAtch
        public List<IPL_Entity.Match> view_Match(int id)
        {
            var obje = new List<IPL_Entity.Match>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Match(id);

            }
            catch (MatchException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Match
        public int delete_Match(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Match(id);

            }
            catch (MatchException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Match
        public void update_Match(IPL_Entity.Match m)
        {

            try
            {

                DAL obj = new DAL();

                obj.Update_Match(m);

            }
            catch (MatchException ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region GetAll Match
        public List<IPL_Entity.Match> GetAll_Match()
        {
            var obje = new List<IPL_Entity.Match>();
            try
            {
                DAL obj = new DAL();
                obje = obj.SelectAll_Match();
            }
            catch (MatchException ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion


        #region Validate schedule

        private static bool ValidateSchedule(Schedule schedule)
        {
            bool ValidSchedule = true;
            StringBuilder sb = new StringBuilder();
            if ((schedule.ScheduleDate.ToString()) == string.Empty)
            {
                sb.AppendLine("Schedule Date Should be Provided..");
                ValidSchedule = false;
            }
            else if (schedule.ScheduleDate <= DateTime.Now)
            {
                sb.AppendLine("Enter Valid Schedule Date..");
                ValidSchedule = false;
            }
            if (schedule.StartTime == string.Empty)
            {
                sb.AppendLine("Schedule  Start Time Should be Provided..");
                ValidSchedule = false;
            }
            else if (!Regex.IsMatch(schedule.StartTime, @"^[0-2][0-9]:[0-5][0-9]$"))
            {
                sb.AppendLine("Time Format Should be in 24 hr Proper format eg:10:20");
                ValidSchedule = false;
            }
            if (schedule.EndTime == string.Empty)
            {
                sb.AppendLine("Schedule  End Time Should be Provided..");
                ValidSchedule = false;
            }
            else if (!Regex.IsMatch(schedule.EndTime, @"^[0-2][0-9]:[0-5][0-9]$"))
            {
                sb.AppendLine("Time Format Should be in 24 Proper format eg:10:20");
                ValidSchedule = false;
            }
            if (ValidSchedule == false)
            {
                throw new TeamException(sb.ToString());
            }
            return ValidSchedule;
        }
        #endregion

        #region Insert Schedule
        public void insert_Schedule(Schedule s)
        {
            try
            {
                if (ValidateSchedule(s))
                {
                    DAL obj = new DAL();
                    obj.Add_Schedule(s);
                }
            }

            catch (ScheduleException ex)
            {
                throw (ex);
            }

        }

        #endregion

        #region View Schedule
        public List<Schedule> view_Schedule(int id)
        {
            var obje = new List<Schedule>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Schedule(id);

            }
            catch (ScheduleException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Schedule
        public int delete_Schedule(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Schedule(id);

            }
            catch (ScheduleException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Schedule

        public void update_Schedule(Schedule s)
        {

            try
            {
                if (ValidateSchedule(s))
                {
                    DAL obj = new DAL();

                    obj.Update_Schedule(s);
                }

            }
            catch (ScheduleException ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region GetAll schedule
        public List<Schedule> GetAll_Schedule()
        {
            var obje = new List<Schedule>();
            try
            {
                DAL obj = new DAL();
                obje = obj.SelectAll_Schedule();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion

        #region Validate Statistics
        private static bool ValidateStat(Stat st)
        {
            bool ValidStat = true;
            StringBuilder sb = new StringBuilder();
            if (st.Won > st.Played)
            {
                sb.AppendLine("Number of matches Won should not be greater than Played matches");
                ValidStat = false;
            }

            if (st.Lost > st.Played)
            {
                sb.AppendLine("Number of matches Lost should not be greater than Played matches");
                ValidStat = false;
            }

            if (st.Tied > st.Played)
            {
                sb.AppendLine("Number of matches Tied should not be greater than Played matches");
                ValidStat = false;
            }
            if ((st.Won + st.Tied + st.Lost) != st.Played)
            {
                sb.AppendLine("Number of matches Lost,Won and Tied should be equal to Played matches");
                ValidStat = false;
            }
            if (st.Pts != (st.Won * 2) + (st.Tied * 1))
            {
                sb.AppendLine("Provide exact points according to the number of matches Won, Lost and Tied");
                ValidStat = false;
            }
            if (st.FromPoints != (st.Played * 2))
            {
                sb.AppendLine("Provide exact points according to the number of matches Played");
                ValidStat = false;
            }
            if (ValidStat == false)
            {
                throw new StatisticsException(sb.ToString());
            }
            return ValidStat;
        }
        #endregion

        #region Insert Statistics
        public void insert_Statistics(Stat s)
        {
            try
            {
                if (ValidateStat(s))
                {
                    DAL obj = new DAL();
                    obj.Add_Statistics(s);
                }
            }

            catch (StatisticException ex)
            {
                throw (ex);
            }

        }
        #endregion

        #region View Statistics
        public List<Stat> view_Statistics(int id)
        {
            var obje = new List<Stat>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Statistics(id);

            }
            catch (StatisticException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Statistics
        public int delete_Statistics(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Statistics(id);

            }
            catch (StatisticException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region update Statistics

        public void update_Statistics(Stat s)
        {

            try
            {
                if (ValidateStat(s))
                {
                    DAL obj = new DAL();

                    obj.Update_Statistics(s);
                }

            }
            catch (StatisticException ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region getAll Statistics
        public List<Stat> GetAll_Stat()
        {
            var obje = new List<Stat>();
            try
            {
                DAL obj = new DAL();
                obje = obj.SelectAll_Statistics();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obje;
        }

        #endregion

        #region Insert Ticket Category

        public int insert_Tc(TicketCategory s)
        {
            try
            {
                if (ValidateTicketCategory(s))
                {
                    DAL obj = new DAL();
                   obj.Add_Tc(s);
                }
            }

            catch (TicketCategoryException ex)
            {
                throw (ex);
            }

            return 1;
        }
        #endregion

        #region Validate Ticket Category

        private static bool ValidateTicketCategory(TicketCategory tct)
        {
            try
            {
                bool ValidTicket = true;
                StringBuilder sb = new StringBuilder();

                if (tct.TicketCategoryName == string.Empty)
                {
                    sb.AppendLine("TicketCategory Name Should be Provided..");
                    ValidTicket = false;
                }
                else if (!Regex.IsMatch(tct.TicketCategoryName, @"[A-Z][a-z]+"))
                {
                    sb.AppendLine("TicketCategoryName Should Start with Capital Letters..");
                    ValidTicket = false;
                }

                if (ValidTicket == false)
                {
                    throw new TicketCategoryException(sb.ToString());
                }
                return ValidTicket;
            }
            catch(TicketCategoryException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region View Ticket category
        public List<TicketCategory> view_Tc(int id)
        {
            var obje = new List<TicketCategory>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_Tc(id);

            }
            catch (TicketCategoryException ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete Ticket Category
        public int delete_Tc(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_Tc(id);

            }
            catch (TicketCategoryException ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Ticket category

        public void update_Tc(TicketCategory s)
        {

            try
            {if (ValidateTicketCategory(s))
                {

                    DAL obj = new DAL();

                    obj.Update_Tc(s);
                }

            }
            catch (TicketCategoryException ex)
            {
                throw (ex);
            }
        }
        #endregion

        #region Get All Ticket CAtegory Details
        public List<TicketCategory> GetAll_Tc()
        {
            var obje = new List<TicketCategory>();
            try
            {
                DAL obj = new DAL();
                obje = obj.SelectAll_Tc();
            }
            catch (TicketCategoryException ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion



        #region Inssert News
        public void insert_News(News s)
        {
            try
            {
                DAL obj = new DAL();
                obj.Add_News(s);
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #endregion

        #region View News
        public List<News> view_News(int id)
        {
            var obje = new List<News>();
            try
            {
                DAL obj = new DAL();

                obje = obj.Search_News(id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Delete News
        public int delete_News(int id)
        {
            int obje;
            try
            {

                DAL obj = new DAL();

                obje = obj.Delete_News(id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Get All News
        public List<News> GetAll_News()
        {

            try
            {
                DAL obj = new DAL();
                return obj.SelectAll_News();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region update News

        public void update_News(News s)
        {

            try
            {

                DAL obj = new DAL();

                obj.Update_News(s);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

    }
}
