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
    public partial class AdminLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //test the connection to the database and open the connection
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //write a query statement and assign it to a variable
                string command = "select * from admin_login_tbl where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "' ";

                SqlCommand cmd = new SqlCommand(command, con);

                //reading data from the database and populates a SqlReader object
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login successfull')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["password"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    //after a successful login
                    //redirect to the homepage
                    Response.Redirect("Homepage.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }           
        }
    }
}