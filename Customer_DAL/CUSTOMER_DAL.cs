using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_DAL
{
    public class CUSTOMER_DAL
    {
        #region Insert Customer
        public void insert_Customer_Ticket(Ticket t)
        {

            try
            {
                Entities1 entity = new Entities1();
                Ticket ticket = new Ticket()
                {
                    MatchId = t.MatchId,
                    TicketCategoryId = t.TicketCategoryId+1,
                    Price = t.Price,
                    
                    
                };
                entity.Tickets.Add(ticket);

                entity.SaveChanges();


            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        #endregion

        #region Search Statistics
        public List<Stat> Search_Stat(string name)
        {

            var obj = new List<Stat>();
            try
            {

                Entities1 PracticeEntities1 = new Entities1();
                var data = (from x in PracticeEntities1.Teams
                            where x.TeamName == name
                            select x.TeamId).FirstOrDefault();
                obj = (from t in PracticeEntities1.Stats
                       where t.TeamId == (data)
                       select t).ToList();

                PracticeEntities1.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

            return obj;
        }
        #endregion

        #region search News
        public List<News> Search_News(int id)
        {

            var obj = new List<News>();
            try
            {
                Entities1 PracticeEntities1 = new Entities1();

                obj = (from t in PracticeEntities1.News
                       where t.MatchId == id
                       select t).ToList();

                PracticeEntities1.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

            return obj;
        }
        #endregion

        #region Select All Ticket Details
        public List<Match> SelectAll_Ticket()
        {
            var obj = new List<Match>();
            try
            {

                Entities1 entity = new Entities1();

                obj = (from t in entity.Matches
                       select t).ToList();

                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

            return obj;
        }
        #endregion

        #region Select Statistics Details
        public List<Stat> SelectAll_Statistics()
        {
            var obj = new List<Stat>();
            try
            {

                Entities1 entity = new Entities1();

                obj = (from t in entity.Stats
                       select t).ToList();

                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);

            }

            return obj;
        }
        #endregion
    }
}
