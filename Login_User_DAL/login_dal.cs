using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_User_DAL
{
    /// <summary>
    /// Login Operations are created in this file
    /// </summary>
    public class login_dal
    {
        #region Add user
        public void add_user(User login)
        {
            try
            {
                Entities1 entity = new Entities1();
                //Login data = new Login()
                //{
                //    username= login.username,
                //    Password=login.Password,
                //    role=login.role
                //};
                entity.Users.Add(login);
                UserRole data = new UserRole()
                {
                    UserId=login.UserId,
                    RoleId=2
                };
                entity.UserRoles.Add(data);
                entity.SaveChanges();


            }
            catch (Exception e)
            {
                throw (e);

            }
        }
        #endregion

        #region Log User
        public int log_user(User user)
        {
            User obj = new User();
          
            int i = 0;
            
            Entities1 ent = new Entities1();
            var value = (from data in ent.Users
                  where data.UserName == user.UserName &&
                  data.Pass == user.Pass
                  select data);
            foreach(var k in value)
            {
                i = k.UserId;
            }

            var d = (from x in ent.UserRoles
                     where x.UserId == i
                     select x);
            int j = 0;
            foreach (var l in d)
            {
                j = (int)l.RoleId;
            }

            return j;
        }
        #endregion
    }
}
