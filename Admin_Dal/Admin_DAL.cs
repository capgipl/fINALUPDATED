using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Admin_Dal
{
    public class Admin_DAL
    {
        SqlConnection cn = null;
        SqlConnection cn1 = null;
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;
        SqlDataReader dr = null;

        public Admin_DAL(string conString)
        {
            //cn = new SqlConnection(conString);
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
            cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
        }


        #region Add Employee
        public int Add_Employee(User Employee)
        {
            #region Linq
            //try
            //{
            //    Entities1 entity = new Entities1();
            //    User user = new User();

            //    user.UserId = Employee.UserId;
            //    user.UserName = Employee.UserName;
            //    user.FirstName = Employee.FirstName;
            //    user.LastName = Employee.LastName;
            //    user.Pass = Employee.Pass;


            //    UserRole userRole = new UserRole();
            //    userRole.UserId = Employee.UserId;
            //    userRole.RoleId = 1;
            //    entity.UserRoles.Add(userRole);


            //    entity.Users.Add(user);

            //    entity.SaveChanges();


            //}
            //catch (Exception e)
            //{
            //    throw (e);

            //}
            //return 1;
            #endregion
            #region ADO

            int no = 0;
            int noo = 0;
            try
            {
                cmd = new SqlCommand("sp_IPL_InsertUser", cn);
                cmd.Parameters.AddWithValue("@UserName", Employee.UserName);
                cmd.Parameters.AddWithValue("@Pass", Employee.Pass);
                cmd.Parameters.AddWithValue("@FirstName", Employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Employee.LastName);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cn.Open();
                no = cmd.ExecuteNonQuery();

                cn.Close();

                add_user(Employee);

            }

            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return noo;



            #endregion
        }
        #endregion

        #region Serach Employee
        public User Search_Employee(int id)
        {

            #region Linq
            //var obj = new List<User>();
            //try
            //{
            //    // not resolved
            //    Entities1 entity = new Entities1();

            //    obj = (from t in entity.Users
            //           where t.UserId == id
            //           select t).ToList();

            //    entity.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    throw (e);

            //}

            //return obj;
            #endregion
            #region ado
            User p = null;
            try
            {
                cmd = new SqlCommand("sp_IPL_ViewUsers", cn);
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        p = new User();
                        p.UserName = dr[1].ToString();
                        p.Pass = dr[2].ToString();
                        p.FirstName = dr[3].ToString();
                        p.LastName = dr[4].ToString();

                    }

                }

            }


            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return p;

            #endregion
        }
        #endregion

        #region AddUser
        public void add_user(User Employee)
        {
            try
            {
                Entities1 entity = new Entities1();
                User user = new User();
                user.UserId = Employee.UserId;
                user.UserName = Employee.UserName;
                user.FirstName = Employee.FirstName;
                user.LastName = Employee.LastName;
                user.Pass = Employee.Pass;
                UserRole userRole = new UserRole();
                userRole.UserId = Employee.UserId;
                userRole.RoleId = 1;
                entity.UserRoles.Add(userRole);
                entity.Users.Add(user);
                entity.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Select Employee Details
        public List<User> SelectAll_Emp()
        {
            User user = new User();
            var obj = new List<User>();
                #region linq
            try
            {
                //Entities1 entity = new Entities1();
                ////obj =( from p in entity.Users
                ////            from q in entity.UserRoles
                ////            where p.UserId == (q.UserId)
                ////               && q.RoleId == 1
                ////            select
                ////                p.UserId,
                ////                p.UserName,
                ////                p.FirstName,
                ////                p.LastName).
                ////            ;

                //var obj1 = (from p in entity.Users
                //            join q in entity.UserRoles on p.UserId equals q.UserId
                //            where q.RoleId == 1
                //            select new
                //            {
                //                p.UserId,
                //                p.UserName,
                //                p.FirstName,
                //                p.LastName
                //            }).ToList();
                //foreach (var up in obj1)
                //{
                //    obj.Add(new User()
                //    {
                //        UserId = up.UserId,
                //        UserName = up.UserName,
                //        FirstName = up.FirstName,
                //        LastName = up.LastName
                //    });
                //}
                //entity.SaveChanges();
                #endregion
                #region ado

                cmd = new SqlCommand("sp_IPL_ViewAllUser", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        user.UserId = (int)dr[0];
                        user.UserName = dr[1].ToString();
                        user.Pass = dr[2].ToString();
                        user.FirstName = dr[3].ToString();
                        user.LastName=dr[4].ToString();
                        obj.Add(user);
                    }
                }




                #endregion

            }
            catch (Exception e)
            {
                throw (e);

            }

            return obj;
        }
        #endregion

        #region Delete emploYee
        public int Delete_Employee(int id)
        {
            #region linq
            //var obj = new List<User>();
            //var uObj = new List<UserRole>();
            //try
            //{
            //    // not
            //    Entities1 entity = new Entities1();


            //    obj = (from t in entity.Users
            //           where t.UserId == id
            //           select t).ToList();

            //    foreach (var t in obj)
            //    {
            //        entity.Users.Remove(t);

            //    }

            //    uObj = (from r in entity.UserRoles
            //            where r.UserId == id
            //            select r).ToList();

            //    foreach (var r in uObj)
            //    {
            //        entity.UserRoles.Remove(r);

            //    }


            //    entity.SaveChanges();
            #endregion
            #region ado


            int no = 0;
            try
            {
                var uObj = new List<UserRole>();
                Entities1 entity = new Entities1();
                uObj = (from r in entity.UserRoles
                        where r.UserId == id
                        select r).ToList();

                foreach (var r in uObj)
                {
                    entity.UserRoles.Remove(r);

                }


                entity.SaveChanges();

                cmd = new SqlCommand("sp_IPL_DeleteUser", cn);
                cmd.Parameters.AddWithValue("@UserId", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                no = cmd.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception e)
            {
                throw (e);

            }


            #endregion
            return 1;
        }

        #endregion


        #region UpdateEmployee
        public void Update_Employee(User x)
        {
                  #region Linq
            var obj = new List<User>();
            //try
            //{
                ////
                //Entities1 entity = new Entities1();

                //obj = (from t in entity.Users
                //       where t.UserId == x.UserId
                //       select t).ToList();
                //obj[0].UserName = x.UserName;
                //obj[0].FirstName = x.FirstName;
                //obj[0].LastName = x.LastName;
                //obj[0].Pass = x.Pass;


                //entity.SaveChanges();


                #endregion
                 #region ado

                int no = 0;
                try
                {

                    cmd = new SqlCommand("sp_IPL_UpdateUser", cn);
                cmd.Parameters.AddWithValue("@UserId", x.UserId);
                cmd.Parameters.AddWithValue("@UserName",x.UserName);
                    cmd.Parameters.AddWithValue("@Pass",x.Pass);
                    cmd.Parameters.AddWithValue("@FirstName",x.FirstName);
                    cmd.Parameters.AddWithValue("@LastName",x.LastName);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cn.Open();
                    no = cmd.ExecuteNonQuery();
                    cn.Close();




                    #endregion
                }
            catch (Exception e)
            {
                throw (e);

            }
        }
        #endregion
    }
}

