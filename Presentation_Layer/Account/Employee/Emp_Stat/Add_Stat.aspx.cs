using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Stat
{
    public partial class Add_Stat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Stat t = new Stat();
                Id i = new Id();

                t.TeamName = ddlTeamName.SelectedValue;
                t.Played = int.Parse(txtPlayed.Text);
                t.Won = int.Parse(txtWon.Text);
                t.Lost = int.Parse(txtLost.Text);
                t.Tied = int.Parse(txtTied.Text);
                t.NR = int.Parse(txtNR.Text);
                t.NetRR = decimal.Parse(txtNetRR.Text);
                t.Pts = int.Parse(txtPoints.Text);
                t.FromPoints = int.Parse(txtFromPoints.Text);

                BLL obj = new BLL();
                obj.insert_Statistics(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");


            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblFromPoints.Text = "";
            lblLost.Text = "";
            lblNetRR.Text = "";
            lblNR.Text = "";
            lblPlayed.Text = "";
            lblPoints.Text = "";
            lblTeamName.Text = "";
            lblTied.Text = "";
            lblWon.Text = "";
        }
    }
}