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
    public partial class Adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //on page load, display the data from the database
            GridView1.DataBind();
        }

        //GO button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetNameById();
        }
        
        //ADD button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                Response.Write("<script>alert('User already exist')</script>");
            }
            else
            {             
                AddPublisher();
            }

        }

        //UPDATE button click 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                UpdateAuthorDetails();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist, cannot be changed')");
            }

        }

        //DELETE button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                DeleteDetails();
            }
            else
            {
                Response.Write("<script>alert('Ghost publisher')</script>");
            }
        }

        //user defined method

        //go button code
        void GetNameById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string getQuery = "select * from publisher_master_tbl where publisher_id='" + TextBox2.Text.Trim() + "' ";
                
                SqlCommand cmd = new SqlCommand(getQuery, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Ghost Member')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')");
            }

        }

        //check if author exists
        bool CheckIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string querySelect = "select * from publisher_master_tbl where publisher_id='" +TextBox2.Text.Trim()+ "' ";
                SqlCommand cmd = new SqlCommand(querySelect, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        //add method
        void AddPublisher()
        {
            try
            {
                //create a connection string 
                SqlConnection con = new SqlConnection(strcon);

                //open connection to the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string queryStatement = "insert into publisher_master_tbl (publisher_id,publisher_name) values(@publisher_id,@publisher_name) ";
                SqlCommand cmd = new SqlCommand(queryStatement, con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Details successfully added')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        //update method
        void UpdateAuthorDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string queryUpdate = "update publisher_master_tbl set publisher_name = @publisher_name where publisher_id='" + TextBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(queryUpdate, con);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Details have been updated')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }

        //delete method
        void DeleteDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string deleteQuery = "delete from publisher_master_tbl where publisher_id='" + TextBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Details have been deleted')</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }

        void ClearForm()
        {
            TextBox1.Text = null;
            TextBox2.Text = null;
        }
    }
}