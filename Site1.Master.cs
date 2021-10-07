using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if its a firts log in to the site
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //sign up link button

                    LinkButton3.Visible = false; //log out link button
                    LinkButton5.Visible = false; //Hello user link button

                    LinkButton6.Visible = true; //admin login link button
                    LinkButton7.Visible = false; //author_mng link button
                    LinkButton8.Visible = false; //pulisher_mng link button
                    LinkButton9.Visible = false; //book_inventory link button
                    LinkButton10.Visible = false; //book issue link button
                    LinkButton11.Visible = false; //member_mng link button
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //sign up link button

                    LinkButton3.Visible = true; //log out link button
                    LinkButton5.Visible = true; //Hello user link button
                    LinkButton5.Text ="Hello "+Session["username"].ToString();

                    LinkButton6.Visible = true; //admin login link button
                    LinkButton7.Visible = false; //author_mng link button
                    LinkButton8.Visible = false; //pulisher_mng link button
                    LinkButton9.Visible = false; //book_inventory link button
                    LinkButton10.Visible = false; //book issue link button
                    LinkButton11.Visible = false; //member_mng link button
                }
                else if(Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //sign up link button

                    LinkButton4.Visible = true;//view books button
                    LinkButton3.Visible = true; //log out link button
                    LinkButton5.Visible = true; //Hello user link button
                    LinkButton5.Text = "Hello admin";

                    LinkButton6.Visible = false; //admin login link button
                    LinkButton7.Visible = true; //author_mng link button
                    LinkButton8.Visible = true; //pulisher_mng link button
                    LinkButton9.Visible = true; //book_inventory link button
                    LinkButton10.Visible = true; //book issue link button
                    LinkButton11.Visible = true; //member_mng link button
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message +"')</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminauthormanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminpublishermanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminbookinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminbookissuing.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminusermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //making the sessions values empty, when logging out
            Session.Abandon();

            Response.Redirect("Homepage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }
    }
}