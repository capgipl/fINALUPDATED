using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Schedule
{
    public partial class Add_Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Schedule t = new Schedule();
                Id i = new Id();

                t.MatchName = txtMatchName.Text;
                t.VenueName = ddlVenue.SelectedValue;
                t.ScheduleDate = DateTime.Parse(txtScheduleDate.Text);
                t.StartTime = txtStartTime.Text;
                t.EndTime = txtEndTime.Text;

                BLL obj = new BLL();
                obj.insert_Schedule(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

               

            }
            catch (Exception ex)
            {
                throw ex;

            }



        }

        protected void txtVenue_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblEndTime.Text = "";
            lblMatchName.Text = "";
            lblScheduleDate.Text = "";
            lblStartTime.Text = "";
            lblVenue.Text = "";
        }
    }
}