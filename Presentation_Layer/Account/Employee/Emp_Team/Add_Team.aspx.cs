using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Team
{
    public partial class Add_Team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Team t = new Team();
                Id i = new Id();

                t.TeamName = txtteamname.Text;
                t.HomeGround = txthg.Text;
                t.Owners = txtowner.Text;
          

                BLL obj = new BLL();
                obj.insert_Team(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblhg.Text = "";
            lblowner.Text = "";
            Lblteamname.Text = "";
        }
    }
}