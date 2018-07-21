using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Match
{
    public partial class Add_Match : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Match t = new Match();
                Id i = new Id();

                t.MatchName = txtMatchName.Text;
                t.TeamOneName = dlteam1.SelectedValue;
                t.TeamTwoName = dlteam2.SelectedValue;
                t.VenueName = dlvenue.SelectedValue;

                BLL obj = new BLL();
                obj.insert_Match(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

                txtMatchName.Text = "";

            }
            catch (Exception ex)
            {
                throw ex;

            }




        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblMatchName.Text = "";
            lblTeamOne.Text = "";
            lblTeamTwo.Text = "";
            lblVenue.Text = "";
        }
    }
}
