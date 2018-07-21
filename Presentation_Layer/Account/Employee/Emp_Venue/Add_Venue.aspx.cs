using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Venue
{
    public partial class Add_Venue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Venue t = new Venue();
                Id i = new Id();

                //t.VenueName = txtVenueName.Text;
                //t.Location = txtLocation.Text;
                //t.VenueDescription = txtDescription.Text;
               

                BLL obj = new BLL();
                //obj.insert_Venue(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

          

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            lblLocation.Text = "";
        }
    }
}