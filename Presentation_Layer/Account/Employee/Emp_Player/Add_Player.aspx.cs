using IPL_BLL;
using IPL_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation_Layer.Account.Employee.Emp_Player
{
    public partial class Add_Player : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Entities1 entity = new Entities1();
            try
            {
                Player t = new Player();
                Id i = new Id();

                t.PlayerName = txtPlayerName.Text;
                t.TeamName= txtTeamName.SelectedValue;
                t.Age = int.Parse(txtAge.Text);
                t.BirthPlace = txtBirthPlace.Text;
                t.Role = txtRole.Text;
                t.BattingStyle = txtBattingStyle.Text;
                t.BowlingStyle = txtBowlingStyle.Text;
             
                BLL obj = new BLL();
               obj.insert_Player(t);

                Response.Write("<script type = 'text/javascript'>alert('Inserted successfully')</script>");

               



            }
            catch (Exception ex)
            {
                throw ex;

            }



        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            lblAge.Text = "";
            lblBattingStyle.Text = "";
            lblBirthPlace.Text = "";
            lblBowlingStyle.Text = "";
            lblPlayerName.Text = "";
            lblRole.Text = "";
            lblTeamName.Text = "";
        }
    }
}