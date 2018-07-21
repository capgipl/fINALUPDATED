using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_News
{
    public partial class Add_News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                News t = new News();
                Id i = new Id();

                t.Newsdate = DateTime.Parse(txtteamid.Text);
                t.NewsDescription = txtNewsDesc.Text;
                t.MatchName = ddlMatchName.SelectedValue;
           

                BLL obj = new BLL();
                obj.insert_News(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

            }
            catch (Exception ex)
            {
                throw ex;

            }



        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblMatchName.Text = "";
            lblNewsDate.Text = "";
            lblNewsDesc.Text = "";
        }
    }
}