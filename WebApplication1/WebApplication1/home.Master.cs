using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.IO;

namespace WebApplication1
{
    public partial class home : System.Web.UI.MasterPage
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


            //getuserproductdetails();

            if (Session["username"] != null)
            {
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-black";
                //add the session name
                lbllgged.Text = "Welcome " + Session["username"];
                btnlgout.Visible = true;
                pnlprofile.Visible = true;
                add.Visible = true;
                xx.Visible = true;
                a3.Visible = true;
                A6.Visible = true;
                a8.Visible = true;
                hyregister.Visible = false;
       
                //Retrieve the User Id Session
                //int user_id = Convert.ToInt32( );
                //hyuser.Attributes["href"]=ResolveUrl("~/tutorials/week5/updateprofile?id="+user_id + "");

            }

            else
            {
                add.Visible = false;
                xx.Visible = false;
                A6.Visible = false;
                a8.Visible = false;
                a3.Visible = false;


            }


            if (!IsPostBack)
            {
                if (Request.Cookies["Admin_name"] != null &&
                Request.Cookies["password"] != null)
                {
                    adminlogin.Username = Request.Cookies["Admin_name"].Value;
                    adminlogin.Password = Request.Cookies["password"].Value;
                }

                else {
                    //string ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\videgrenier.mdf;Integrated Security=True";
                    string query = "SELECT advert_name, brand_photo from tbladvert where status = 1 ORDER BY NEWID()";

                    using (SqlConnection connection = new SqlConnection(_conString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            ImageRepeater.DataSource = reader;
                            ImageRepeater.DataBind();
                        }


                        reader.Close();
                    }

                }
            }

            //Disable/Enable some menu items
            if (Session["Admin_name"] != null)
            {
                hyregister.Visible = false;
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-black";
                lbllgged.Text = "Welcome " + Session["Admin_name"];
                btnlgout.Visible = true;
              
                mprod.Visible = true;
                muser.Visible = true;
                a1.Visible = true; 
                a2.Visible = true;
               a11.Visible = true;
                a4.Visible = true; 
                a5.Visible= true;   
                A7.Visible= true;
                A12.Visible = true;
                Pane.Visible = true;
               

                Page.Controls.Remove(pnlprofile);
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
            }
         else 
            {

                mprod.Visible = false;
                muser.Visible = false;
                a1.Visible=false;
                a11.Visible=false;  
                A12.Visible=false;  
                a2.Visible=false;
                Pane.Visible = false;   
                  
            }







            if (Session["org_name"] != null)
            {
                hyregister.Visible = false;
                lgregis.CssClass = "nav navbar-nav navbar-right";
                lbllgged.CssClass = "btn btn-outline-success text-black";
                lbllgged.Text = "Welcome " + Session["org_name"];
                btnlgout.Visible = true;

                mprod.Visible = true;
                muser.Visible = true;
                a10.Visible= true;
               

                Page.Controls.Remove(pnlprofile);
                pnllog.Style.Add("visibility", "hidden");
                Page.Controls.Remove(pnllog);
            }
            else
            {

              a10.Visible= false;
            }

         





        }

        protected void txtmovieid_TextChanged(object sender, EventArgs e)
        {

            //Add the following codes in a TextChanged event
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //create the movieid parameter
            cmd.Parameters.AddWithValue("@mid", txtmovieid.Text.Trim());
            //assign the parameter to the sql statement
            cmd.CommandText = "SELECT product_name, status,pictures brand FROM tblproduct where product_name=@mid";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }
            //Set the DataTable as the DataSource
            gvs.DataSource = dt;
            gvs.DataBind();

        }

        protected void btnlgout_Click(object sender, EventArgs e)
        {

            lgout();
           

        }

        void lgout()
        {
            if (Session["username"] != null || Session["admin_name"] != null || Session["org_name"] != null)
            {
                //Remove all session
                Session.Clear();
                //Destroy all Session objects
                Session.Abandon();
                //Redirect to homepage or login page
                Response.Redirect("login");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //admin login form
            string username = adminlogin.Username;
            string password = adminlogin.Password;
            bool chk = adminlogin.Chk;
            SqlConnection con = new SqlConnection(_conString);
            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            //searching for a record containing matching username & password with
            //an active status
            cmd.CommandText = " select * from tbladmin where Admin_name=@Aname and password=@pass";
            //create two parameterized query for the above select statement
            //use above variables
            cmd.Parameters.AddWithValue("@Aname", username);
            cmd.Parameters.AddWithValue("@pass", password);
          
            //Create DataReader
            SqlDataReader dr;
            con.Open();
            dr = cmd.ExecuteReader();
            // check if the DataReader contains a record
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    //create a memory cookie to store username and pwd
                    Response.Cookies["Aname"].Value = username;
                    Response.Cookies["pass"].Value = password;

                    if (chk)
                    {
                        //if checkbox is checked, make cookies persistent
                        Response.Cookies["Aname"].Expires = DateTime.Now.AddDays(100);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(100);
                    }
                    else
                    {
                        //delete the cookies if checkbox is unchecked
                        //delete content of password field
                        Response.Cookies["Aname"].Expires = DateTime.Now.AddDays(-100);
                        Response.Cookies["pass"].Expires = DateTime.Now.AddDays(-100);
                    }
                    //create and save adminuname in a session variable
                    //create and save username in a session variable
                    Session["Admin_name"] = username;
                    //create and save userid in a session variable
                    Session["Admin_id"] = dr["Admin_id"].ToString();
                    //redirect to the corresponding page
                    Response.Redirect("home.aspx");
                    //redirect to the dashboard page
                }
                con.Close();
            }
            else
            {
                //delete content of password field
                lblmsg.Style.Add("margin-left", "10%");
                lblmsg.ForeColor = System.Drawing.Color.Red;
                username = "Admin_name";
                password = "password";
                lblmsg.Text = "You are not registered or your account has been suspended!";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop",
"adminModal();", true);
            }
        

    }


        //private DataTable LoadAdsFromDatabase()
        //{
        //    // Replace "YourConnectionString" with your actual connection string
        //    string connectionString =_conString;
        //    string query = "SELECT advert_name, brand_photo, advert_id FROM tbladvert WHERE status = 1";

        //    DataTable adsTable = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                adsTable.Load(reader);
        //            }
        //        }
        //    }

        //    // Replace the "brand_photo" column with the "ImageUrl" column required by the AdRotator control
        //    adsTable.Columns["brand_photo"].ColumnName = "ImageUrl";

        //    return adsTable;
        //}


        //void getuserproductdetails()
        //{
        //    SqlConnection con = new SqlConnection(_conString);

        //    SqlCommand ccmd = con.CreateCommand();
        //    ccmd.CommandType = CommandType.Text;
        //    ccmd.CommandText = "SELECT * FROM tbladvert where status = 1";


        //    SqlDataReader dr;
        //    //open connection
        //    con.Open();
        //    //execute sql statememt
        //    dr = ccmd.ExecuteReader();
        //    //Bind the reader to the repeater control
        //    Repeater1.DataSource = dr;
        //    Repeater1.DataBind();
        //    con.Close();


        //}




        //private List<string> GetSlideshowImages()
        //{
        //    List<string> images = new List<string>();
        //    string connectionString = _conString;
        //    string query = "SELECT brand_photo FROM tbladvert WHERE status = 1";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            images.Add(reader["brand_photo"].ToString());
        //        }
        //        reader.Close();
        //    }

        //    return images;
        //}





        


    }
}