using IPL_Entity;
using Login_User_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Login_User_BLL
{
    /// <summary>
    /// Login Validations are created 
    /// </summary>
    public class Login_BLL
    {
        #region Validate User
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
                    builderObj.AppendLine("Password Should be Provided.....");
                    validUser = false;
                }
                else if (!Regex.IsMatch(user.Pass, @"[A-Za-z0-9]{8,16}$"))
                {
                    builderObj.AppendLine("Password must contain Alphabets and numbers and start with capital Letter..");
                    validUser = false;
                }
                if (validUser == false)
                {
                    throw new Exception(builderObj.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

            return validUser;
        }
        #endregion

        #region Add User
        public void add_user(User login)
        {
            try
            {
                login_dal obj = new login_dal();
                obj.add_user(login);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region LOg User

        public int log_user(User user)
        {
            int val;
            login_dal obj = new login_dal();
            val = obj.log_user(user);
            return val;
        }
        #endregion
    }
}
