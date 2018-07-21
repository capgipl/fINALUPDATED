using Admin_Dal;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Admin_Exceptions;

namespace Admin_Bal
{
    public class Admin_BAL
    {
        #region Validations
        public bool ValidateUser(User user)
        {
            bool validUser = true;
            StringBuilder builderObj = new StringBuilder();

            try
            {
                if (user.UserId.ToString() == null)
                {
                    builderObj.AppendLine("Employee ID  Should be Provided");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.UserId.ToString(), "[0-9]+"))
                {
                    builderObj.AppendLine("Employee ID  Should be only numbers....");
                    validUser = false;
                }
                if (user.UserName == string.Empty)
                {
                    builderObj.AppendLine("UserName Should be Provided......");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.UserName, @"[A-Z][a-z]+"))
                {
                    builderObj.AppendLine("User Name Should Start with Capital Letters.....");
                    validUser = false;
                }
                if (user.FirstName == string.Empty)
                {
                    builderObj.AppendLine("FirstName Should be Provided....");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.FirstName, @"[A-Z][a-z]+"))
                {
                    builderObj.AppendLine("First Name Should Start with Capital Letters....");
                    validUser = false;
                }
                if (user.LastName == string.Empty)
                {
                    builderObj.AppendLine("LastName Should be Provided.....");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.LastName, @"[A-Z][a-z]+"))
                {
                    builderObj.AppendLine("Last Name Should Start with Capital Letters.....");
                    validUser = false;
                }
                if (user.Pass == string.Empty)
                {
                    builderObj.AppendLine("Pass Should be Provided.....");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.Pass, @"[A-Za-z0-9]{8,16}$"))
                {
                    builderObj.AppendLine("Pass must contain Alphabets and numbers and start with capital Letter..");
                    validUser = false;
                }
                if (validUser == false)
                {
                    throw new Users_Exception(builderObj.ToString());
                }
            }
            catch (Users_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validUser;
        }
        #endregion

        #region Insert Employee
        public int insert_Employee(User u)
        {
            int x;
            try
            {
                if (ValidateUser(u))
                {
                   
                    Admin_DAL obj = new Admin_DAL(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                    x = obj.Add_Employee(u);
                    return x;
                   
                }
            }
            catch(Users_Exception ex)
            {
                throw ex;

            }
            return 1;

        }
        #endregion

        #region View Employee
        public User view_Employee(int id)
        {
            var obje = new List<User>();
            User p = new User();
            try
            {
                Admin_DAL obj = new Admin_DAL(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);

                p = obj.Search_Employee(id);

            }
            catch (Users_Exception ex)
            {
                throw (ex);
            }
            return p;

        }
        #endregion

        #region get All Employee Details
        public List<User> GetAll_emp()
        {
            var obje = new List<User>();
            try
            {
                Admin_DAL obj = new Admin_DAL(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
                obje = obj.SelectAll_Emp();
            }
            catch (Users_Exception ex)
            {
                throw ex;
            }
            return obje;
        }
        #endregion

        #region Delete Employee
        public int delete_Employee(int id)
        {
            int obje;
            try
            {

                Admin_DAL obj = new Admin_DAL(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);

                obje = obj.Delete_Employee(id);

            }
            catch (Users_Exception ex)
            {
                throw (ex);
            }
            return 1;

        }
        #endregion

        #region Update Employee
        public int update_Employee(User t)
        {
            try
            {
                Admin_DAL obj = new Admin_DAL(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);

                obj.Update_Employee(t);
                return 1;

            }
            catch (Users_Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}
