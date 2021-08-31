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
    public partial class Adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillAuthorPublisherDetails();
        }
        
        //add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            //create a new connection to the database
            SqlConnection con = new SqlConnection(strcon);
            if(con.State== ConnectionState.Closed)
            {
                con.Open();
            }

            string insertQuery = "insert into book_master_tbl values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publisher_date,@language,@edition," +
                "book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link,)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);

            cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@bool_name", TextBox2.Text.Trim());
            //cmd.Parameters.AddWithValue("@genre", );
        }

        //update button click
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        //delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        // GO button click
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        //user defined methods
        void FillAuthorPublisherDetails()
        {
            //create a SqlConnection object
            SqlConnection con = new SqlConnection(strcon);
            
            //open connection to the database
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select author_name from author_master_tbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = "author_name";
            DropDownList3.DataBind();

        }
    }
}