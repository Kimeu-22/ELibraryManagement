using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibraryManagement
{
    public partial class UserLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //user login

        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
            {
                //create a connection object
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //query statement stored as a string variable
                string command = "select * from member_master_tbl where member_id='"+TextBox1.Text.Trim()+"' AND password='"+TextBox2.Text.Trim()+"' ";

                //a code to write a query to the database
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataReader dr = cmd.ExecuteReader();

                //checking if the entry made in the textboxes matches what is there in the database
                if (dr.HasRows)
                {
                    //reading all the data in the database
                    while(dr.Read())
                    {
                        Response.Write("<script>alert('Login successfull')</script>");

                        //creating session variables, they are global variables
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["password"] = dr.GetValue(9).ToString();
                        Session["role"] = "user";
                        Session["status"] = dr.GetValue(10).ToString();
                    }
                    //after a successfull login
                    //redirect it to the homepage
                    Response.Redirect("Homepage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
            //Response.Write("<script>alert('Button click');</script>");
        }

        //user-defined functions
    }
}