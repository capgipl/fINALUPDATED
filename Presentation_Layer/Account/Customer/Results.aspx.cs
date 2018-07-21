using Customer_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Customer
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            panel1.Visible = true;
            panel2.Visible = false;
        }

        protected void TeamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var data = new List<Stat>();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void searchtxt1_TextChanged(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel2.Visible = true;
        }
        protected void btnrefresh(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

    } 
}