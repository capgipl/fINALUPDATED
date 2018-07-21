using Admin_Bal;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Admin
{
    public partial class Employee_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed9_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                User t = new User();
                t.UserName = UserName.Text;
                t.FirstName = FirstName.Text;
                t.LastName = LastName.Text;
                t.Pass = Password.Text;

                Admin_BAL obj = new Admin_BAL();
                obj.insert_Employee(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

                UserName.Text = "";
                FirstName.Text = "";
                LastName.Text = "";
                Password.Text = "";
                
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        protected void Unnamed10_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Password.Text = "";
        }
    }
    }
