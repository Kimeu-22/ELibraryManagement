using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

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
        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book already exists')");
            }
            else
            {
                AddBook();
            }
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
        bool CheckIfBookExists()
        {
            try
            {
                //create a connection to the database
                var con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //query the database
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id=' "+TextBox1.Text.Trim()+"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else return false;


            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ')</script>");
                return false;
            }
        }
        void FillAuthorPublisherDetails()
        {
            //create a SqlConnection object
            SqlConnection con = new SqlConnection(strcon);
            
            //open connection to the database
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //author details
            SqlCommand cmd = new SqlCommand("select author_name from author_master_tbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataValueField = "author_name";
            DropDownList3.DataBind();

            //publisher details
            cmd = new SqlCommand("select publisher_name from publisher_master_tbl", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = "publisher_name";
            DropDownList2.DataBind();

        }
        void AddBook()
        {
            try
            {
                //adding the selected items on the listbox as a concatenated string to the database 
                string genres = "";
                //GetSelectedItems() returns an array of integers
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                //removing the trailing comma
                genres = genres.Remove(genres.Length - 1);

                //adding input from the FileUpload1 control as a string to the database 
                string filePath = "~/bookInventory/books1.png";
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("bookInventory/" + fileName));
                filePath = "~/bookInventory/" + fileName;

                //create a new connection to the database
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string insertQuery = "insert into book_master_tbl values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publisher_date,@language,@edition," +
                    "@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filePath);

                cmd.ExecuteNonQuery();
                //con.Close();
                Response.Write("<script>alert('Book details added successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')</script>");
            }
        }     
    }
}