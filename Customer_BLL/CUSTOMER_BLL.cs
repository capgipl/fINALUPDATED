using Customer_DAL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customer_BLL
{
    public class CUSTOMER_BLL
    {
        #region Validate Customer
        private static bool Validate(Ticket t)
        {
            bool isValid = true;
            StringBuilder sb = new StringBuilder();
           
            if (t.NumberOfTickets == string.Empty)
            {
                sb.AppendLine("Number of Tickets Should be Provided..");
                isValid = false;
            }
            else if (!Regex.IsMatch(t.NumberOfTickets, "[0-9]+"))
            {
                sb.AppendLine(" Number of Tickets Should contain numbers..");
                isValid = false;
            }

            if (isValid == false)
            {
                throw new Exception(sb.ToString());
            }
            return isValid;
        }
        #endregion

        #region Insert Customer Ticket
        public void insert_Customer_Ticket(Ticket t)
        {
            try
            {
                if (Validate(t))
                {
                    CUSTOMER_DAL obj = new CUSTOMER_DAL();

                    obj.insert_Customer_Ticket(t);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion

        #region View Result
        public List<Stat> view_stat(string id)
        {
            var obje = new List<Stat>();
            try
            {
                CUSTOMER_DAL obj = new CUSTOMER_DAL();

                obje = obj.Search_Stat(id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region View News
        public List<News> view_news(int id)
        {
            var obje = new List<News>();
            try
            {
                CUSTOMER_DAL obj = new CUSTOMER_DAL();
                obje = obj.Search_News(id);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return obje;

        }
        #endregion

        #region Get All statistics
        public List<Stat> GetAll_Stat()
        {
            var obje = new List<Stat>();
            try
            {
                CUSTOMER_DAL obj = new CUSTOMER_DAL();
                obje = obj.SelectAll_Statistics();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion

        #region GetAll Ticket Details
        public List<IPL_Entity.Match> GetAll_Ticket()
        {

            try
            {
                CUSTOMER_DAL obj = new CUSTOMER_DAL();
                return obj.SelectAll_Ticket();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
