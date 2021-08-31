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
    public partial class UserSignUp : System.Web.UI.Page
    {
        //passing the connection as strcon variable
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        //sign up button click event method
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if statement checks whether a member with a similar id exists or not 
            if (CheckIfMemberExist())
            {
                Response.Write("<script>alert('Member with a similar id already exists, try another id')</script>");
            }
            else
            {
                SignUpNewmember();
            }
            
        }

        //user defined method
        //create a method which checks if a user with a member_id has been added
        bool CheckIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //write a query
                string sqlSelect = "SELECT * from member_master_tbl where member_id='" + TextBox9.Text.Trim() + "';";

                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //creates a new record i.e. a dataset
                DataTable dt = new DataTable();

                da.Fill(dt);
                if(dt.Rows.Count >= 1) 
                {
                    return true;
                }
                else
                {
                    return false;
                }

                //con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

            
        }
        //pass the block of code to another method
        void SignUpNewmember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            //we use the try catch block to display most of the exceptions to aid in correction of errors
            try
            {

                //creating a new object to be referred as the database
                SqlConnection con = new SqlConnection(strcon);

                //opening a connection to the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl " +
                    "(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status)" +
                    " VALUES (@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);

                //AddWithValue is evil, search for another way to store textbox values to the database
                //Trim() is used to remove any whitespaces before and after the text
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                //the line of code gets infor from the form controls
                //and stores them in the selected database table
                cmd.ExecuteNonQuery();

                //close the connection to the database
                con.Close();

                //message displayed after the process is successful
                Response.Write("<script>alert('Sign up successful. Go to User login');</script>");
                Response.Redirect("UserLogin.aspx");
            }
            catch (Exception ex)
            {
                //this prints out the error message dynamically onto the screen
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}