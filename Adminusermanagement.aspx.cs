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
    public partial class Adminusermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetUserByID();
        }

        //Pending button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateStatusByID("pending");
        }

        //Active button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateStatusByID("active");
        }

        //Deactivate button click
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateStatusByID("deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteDetails();
        }
        //user defined methods
        void GetUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //query statement
                string querySelect = "select * from member_master_tbl where member_id='" + TextBox10.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(querySelect, con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox1.Text = dr.GetValue(0).ToString();
                        TextBox2.Text = dr.GetValue(10).ToString();
                        TextBox6.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox3.Text = dr.GetValue(3).ToString();
                        TextBoxState.Text = dr.GetValue(4).ToString();
                        TextBox7.Text = dr.GetValue(5).ToString();
                        TextBox8.Text = dr.GetValue(6).ToString();
                        TextBox9.Text = dr.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid member id')</script>");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void UpdateStatusByID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //query statement
                string querySelect = "update member_master_tbl set account_status='" +status+ "' where member_id='" + TextBox10.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(querySelect, con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Member status updated')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
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

                string deleteStatement = "delete from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(deleteStatement, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member deleted')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+ "')</script>");
            }

        }
    }
}