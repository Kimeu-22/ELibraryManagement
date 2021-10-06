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
        //create global variable to hold values
        static string globalFilePath;
        static int globalActualStock, globalCurrentStock, globalIssuedBook;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorPublisherDetails();
            }
           
            GridView1.DataBind();

        }
        
        //add button click
        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book already exists'</script>");
            }
            else
            {
                AddBook();
            }
        }

        //update button click
        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                UpdateBookDetails();
            }
            else Response.Write("<script>alert('Book is not in the library. Try E-books')</script>");
            
        }

        //delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                DeleteEntries();
            }
            else
            {
                Response.Write("<script>alert('Invalid book id')</script>");
            }

        }

        // GO button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetDetailsByBookId();
        }
        //user defined methods
        void GetDetailsByBookId()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //writing the select query
                string selectQuery = "select * from book_master_tbl where book_id='" +TextBox1.Text.Trim()+ "' ";
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    TextBox3.Text = dt.Rows[0]["publisher_date"].ToString();

                    ListBox1.ClearSelection();
                    //stores the selected items in an array of strings
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i<genre.Length; i++)
                    {
                        for(int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                       }
                    }
                    TextBox4.Text = dt.Rows[0]["edition"].ToString();
                    TextBox5.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox9.Text = ""+ (int.Parse(dt.Rows[0]["actual_stock"].ToString()) - int.Parse(dt.Rows[0]["current_stock"].ToString()));
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();

                    globalActualStock = int.Parse(dt.Rows[0]["actual_stock"].ToString().Trim());
                    globalCurrentStock = int.Parse(dt.Rows[0]["current_stock"].ToString().Trim());
                    globalIssuedBook = globalActualStock - globalCurrentStock;
                    globalFilePath = dt.Rows[0]["book_img_link"].ToString().Trim();

                }
                else
                {
                    Response.Write("<script>alert('Invalid book id')</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')</script>");
            }
        }
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
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='"+TextBox1.Text.Trim()+"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                { return false; }
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
        void DeleteEntries()
        {
            try
            {
                //open connection to the database
                var con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book deleted successfully')</script>");
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
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
                con.Close();
                Response.Write("<script>alert('Book details added successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')</script>");
            }
        }     
        void UpdateBookDetails()
        { 
            try
            {
                //when we are trying to update the filepath name
                string filePath = "~/bookInventory/books1.png";
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (fileName == "" || fileName == null)
                {
                    filePath = globalFilePath;
                }
                else
                {
                    //get the filename of the updated image
                    FileUpload1.SaveAs(Server.MapPath("bookInventory/" + fileName));
                    filePath = "~/bookInventory/" + fileName;
                }

                //performing inventory modification 
                int actualStock = int.Parse(TextBox7.Text.Trim());
                int currentStock = int.Parse(TextBox8.Text.Trim());
                if (globalActualStock == actualStock)
                {

                }
                else
                {
                    if (actualStock < globalIssuedBook)
                    {
                        Response.Write("<script> alert('Actual stock cannot be less than the issued books')</script>");
                    }
                    else
                    {
                        currentStock = actualStock - globalIssuedBook;
                        //update the read-only field
                        //one can concantenate a string and integer
                        TextBox8.Text = "" + currentStock;
                    }

                }
                //create an array of strings to hold the selected picks to update the genre list
                string genre = " ";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genre = genre + ListBox1.Items[i] + ",";
                }
                genre = genre.Remove(genre.Length - 1);

                //create an open connection to the database
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string updateQuery = "update book_master_tbl set book_name=@book_name, @genre=genre, author_name=@author_name," +
                    "publisher_name=@publisher_name, publisher_date=@publisher_date, language=@language, edition=@edition, book_cost=@book_cost, " +
                    "no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock," +
                    " book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(updateQuery, con);

                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedValue);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@publisher_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actualStock.ToString());
                cmd.Parameters.AddWithValue("@current_stock", currentStock.ToString());
                cmd.Parameters.AddWithValue("@book_img_link", filePath);

                cmd.ExecuteNonQuery();  //executes a transact-sql statement against the connection
                con.Close();
                Response.Write("<script>alert('Book updated successfully')</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(' " + ex.Message + " ')</script>");
            }
        }
    }
}