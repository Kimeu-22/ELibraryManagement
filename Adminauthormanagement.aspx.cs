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
    public partial class Adminauthormanagement : System.Web.UI.Page
    {
        //add a string connection to connect to a database
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //ADD button click, creates a new record into the database
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(CheckIfAuthorExists())
            {
                Response.Write("<script>alert('Author with a similar id already exists');</script>");
            }
            else
            {
                //add an author 
                AddAuthor();
            }
            
        }

        //UPDATE button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                //pass the update method
                UpdateAuthorDetails();
            }
            else
            {              
                Response.Write("<script>alert('User does not exist')</script>");
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
                Response.Write("<script>alert('Author does not exist')</script>");
            }
        }

        //GO button
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetNameById();
        }

        //user defined methods

        void GetNameById()
        {
            //when sb clicks on the go button, author's name is displayed at the textbox
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string str = "select * from author_master_tbl where author_id='" + TextBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(str, con);

                //we are passing the data into a dataset
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //creating a datatable
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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void UpdateAuthorDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string updateWord = "update author_master_tbl set author_name=@author_name where author_id ='" + TextBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(updateWord, con);

                cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Author details have been updated')</script>");
                //binding data from the data source the grid view control in real time
                GridView1.DataBind();
                ClearForm();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }

            
        }

        bool CheckIfAuthorExists()  //checks if the author exists in the database 
        {
            try
            {
                //create a new connection to the database
                SqlConnection con = new SqlConnection(strcon);

                //open connection to the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //write a sql statement to query the database
                string selectQuery = "select * from author_master_tbl where author_id='"+TextBox2.Text.Trim()+"'";

                //write an Sql command
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                //create an object and populate it with data
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //create a datatable
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
            
        }

        void AddAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertInto = "INSERT INTO author_master_tbl (author_id,author_name) values (@author_id,@author_name)";
                SqlCommand cmd = new SqlCommand(insertInto, con);

                cmd.Parameters.AddWithValue("@author_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added successfully')</script>");
                //binding data from the data source the grid view control in real time
                GridView1.DataBind();
                ClearForm();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message + "');</script>");
            }
        }

        void DeleteDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string deleteStatement = "delete from author_master_tbl where author_id='" + TextBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(deleteStatement, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author details deleted successfully')</script>");
                //binding data from the data source the grid view control in real time
                GridView1.DataBind();
                ClearForm();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        void ClearForm()
        {
            TextBox2.Text = "";
            TextBox1.Text = "";
        }
    }
}