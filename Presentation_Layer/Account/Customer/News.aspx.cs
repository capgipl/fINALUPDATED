using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Customer
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
        }
        protected void searchtxt_TextChanged(object sender, EventArgs e)
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