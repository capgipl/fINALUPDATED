using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_TicketCategory
{
    public partial class Add_TicketCategpry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                TicketCategory t = new TicketCategory();
                Id i = new Id();

                t.TicketCategoryName = txtTicketCategoryName.Text;
                t.TicketDescription = txtTicketDesc.Text;
                

                BLL obj = new BLL();
                obj.insert_Tc(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

               

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblTicketCategoryName.Text = "";
            lblTicketDesc.Text = "";
        }
    }
}