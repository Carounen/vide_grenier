﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebApplication1
{
    public partial class approvereserve : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                getuserproductdetails();
            }
        }

        void getuserproductdetails()
        {
            SqlConnection con = new SqlConnection(_conString);
         
            SqlCommand ccmd = con.CreateCommand();
            ccmd.CommandType = CommandType.Text;
            ccmd.CommandText = "SELECT * FROM tblproductUser INNER JOIN tblproduct ON tblproductUser.product_id = tblproduct.product_id INNER JOIN tbluser ON tblproductUser.user_id = tbluser.user_id WHERE tblproductUser.user_id != " + Session["userid"] + " and tblproduct.user_id = " + Session["userid"];
            //ccmd.CommandText += "tu.f_name as fname, ";
            //ccmd.CommandText += "tu.l_name as lname, ";
            //ccmd.CommandText += "tu.username as uname, ";
            //ccmd.CommandText += "tu.profile_image as image, ";
            //ccmd.CommandText += "tu.status as ustatus, ";
            //ccmd.CommandText += "tum.product_id as pid, ";
            //ccmd.CommandText += "tum.AccessDate as accdate, ";
            //ccmd.CommandText += "tum.Status as tumstatus, ";
            //ccmd.CommandText += "tm.product_name as pname, ";
            //ccmd.CommandText += "tm.status as mstatus ";
            //ccmd.CommandText += "from tbluser tu, tblproductUser tum, tblproduct tm ";
            //ccmd.CommandText += "where tu.user_id = tum.user_id ";
            //ccmd.CommandText += "and tum.product_id = tm.product_id ";
            //ccmd.CommandText += "and tu.status = '1' ";
            //ccmd.CommandText += "and tm.status = '1' ";


            //SqlDataAdapter sqlda = new SqlDataAdapter(ccmd.CommandText, con);
            //DataTable dta = new DataTable();
            //sqlda.Fill(dta);
            //con.Close();

            SqlDataReader dr;
            //open connection
            con.Open();
            //execute sql statememt
            dr = ccmd.ExecuteReader();
            //Bind the reader to the repeater control
            Repeater1.DataSource = dr;
            Repeater1.DataBind();
            con.Close();


        }
           

        protected void lnkdeny_Click1(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            HiddenField hf = item.FindControl("hidmov") as HiddenField;
            int mov_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblproductUser set status='0' Where user_id ='"
            + user_id + "' and product_id ='" + mov_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
        }

        protected void lnkgrant_Click1(object sender, EventArgs e)
        {

            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            HiddenField hf = item.FindControl("hidmov") as HiddenField;
            int mov_id = Convert.ToInt32(hf.Value);
            int user_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlConnection con = new SqlConnection(_conString);
            con.Open();
            SqlCommand ucmd = con.CreateCommand();
            ucmd.CommandType = CommandType.Text;
            ucmd.CommandText = "update tblproductUser set Status='1' Where user_id ='"
            + user_id + "' and product_id ='" + mov_id + "'";
            ucmd.ExecuteNonQuery();
            con.Close();
            getuserproductdetails();
        }
    }
}