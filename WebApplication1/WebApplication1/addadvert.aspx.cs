using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class addadvert : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindadvertData();
        }

        private void BindadvertData()
        {
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbladvert";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Create a DataTable
            DataTable dt = new DataTable();
            using (da)
            {
                //Populate the DataTable
                da.Fill(dt);
            }

            //Set the DataTable as the DataSource

        }

        protected void btnAdvert_Click(object sender, EventArgs e)
        {
            String filen = "avatar.jpg";
            String fileshe = "avatar2.jpg";
            //check if the fileupload contains a file before uploading
            if (picture.HasFile)
            {
                filen = Path.GetFileName(picture.PostedFile.FileName);
                picture.PostedFile.SaveAs(Server.MapPath("~/images/") + filen);
            }

            //check if the fileupload contains a file before uploading
            /*if (fuschedule.HasFile)
            {
                fileshe = Path.GetFileName(fuschedule.PostedFile.FileName);
                fuschedule.PostedFile.SaveAs(Server.MapPath("~/images/") +
                fileshe);
            }*/
            Boolean IsAdded = false;
            SqlConnection con = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //add INSERT statement to create new movie
            cmd.CommandText = "insert into tbladvert (advert_name,brand_photo,status,user_id) values (@aname,@bphoto,@status,@uid)";
            //create Parameterized query to prevent sql injection by
          
            cmd.Parameters.AddWithValue("@aname", txtadvertname.Text.Trim());
           
            cmd.Parameters.AddWithValue("@bphoto", filen);
           
            cmd.Parameters.AddWithValue("@status", 0);
            cmd.Parameters.AddWithValue("@uid", Session["userid"]);

            cmd.Connection = con;
            con.Open();
            //use Command method to execute INSERT statement and return
            //Boolean true if number of records inserted is greater than zero
            IsAdded = cmd.ExecuteNonQuery() > 0;
            con.Close();
            if (IsAdded)
            {
                lblMsg.Text = txtadvertname.Text + " product added successfully!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                //Refresh the GridView by calling the BindMovieData()
                BindadvertData();
            }
            else
            {
                lblMsg.Text = "Error while adding product " + txtadvertname.Text;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    }
