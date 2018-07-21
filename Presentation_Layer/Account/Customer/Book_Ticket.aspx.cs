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
    public partial class Book_Ticket : System.Web.UI.Page
    {
        static int[,] count = new int[10, 10];



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Ticket t = new Ticket();
                    Entities1 entity = new Entities1();


                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {

                            count[i, j] = 100;
                        }
                    }

                    TeamName1.Text = count[0, 0].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public enum MessageType
        {
            Success,
            Info,
            Warning,
            Danger
        }
        protected void won1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void Unnamed9_Click(object sender, EventArgs e)
        {

            int index = 0, index_1 = 0;
            Entities1 entity = new Entities1();
            try
            {
                Ticket t = new Ticket();
                if (Played.Text != "" && DropDownList1.SelectedIndex >= 0 && won1.Text != "")
                {

                    TicketCategory tc = new TicketCategory();
                    t.TicketCategoryId = DropDownList1.SelectedIndex;
                    t.MatchId = (won1.SelectedIndex) + 1;
                    t.NumberOfTickets = Played.Text;
                    int x = DropDownList1.SelectedIndex;
                    //MessageBox.Show(x.ToString());
                    Tied.Text = ((x + 1) * 1000 * int.Parse(Played.Text)).ToString();



                    t.Price = int.Parse(Tied.Text);

                    //txtcnt.Text = (int.Parse(txtcnt.Text)-int.Parse(txttid.Text)).ToString();

                    CUSTOMER_BLL obj = new CUSTOMER_BLL();
                    obj.insert_Customer_Ticket(t);
                    //int[,] count = new int[10, 10];



                    index = DropDownList1.SelectedIndex;
                    index_1 = (won1.SelectedIndex) + 1;
                    //MessageBox.Show((count[index + 1, index_1] - int.Parse(txttid.Text)).ToString());
                    count[index + 1, index_1] = count[index + 1, index_1] - int.Parse(Played.Text);
                    TeamName1.Text = (count[index + 1, index_1]).ToString();
                    Response.Write("<script type='text/javascript'>alert('Ticket Booked Successfully')</script>");
                   
                }
            }




            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void ShowMessage(string v, object error)
        {
            throw new NotImplementedException();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            won1.Text = "";
            TeamName1.Text = "";
            Played.Text = "";
        }
    }
       }
    
            


            
            
