using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Net;
using Antlr.Runtime.Tree;
using System.Threading.Tasks;

namespace WebApplication1
{
    public partial class orgre : System.Web.UI.Page
    {
        private string _conString =
WebConfigurationManager.ConnectionStrings["videgrenier"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     

        public string Encrypt(string clearText)
        {
            // defining encrytion key
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new
                byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65,
0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    // encoding using key
                    using (CryptoStream cs = new CryptoStream(ms,
                    encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length >= 7 && args.Value.Length <= 12)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
           
                String filen = "avatar.jpg";

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
                cmd.CommandText = "insert into tblorganisation(org_name,password,email,org_image) values (@oname,@pass,@email, @pimage)";
                //create Parameterized query to prevent sql injection by

                cmd.Parameters.AddWithValue("@oname", first.Text.Trim());

                cmd.Parameters.AddWithValue("@pass", Encrypt(txtpas.Text));

                cmd.Parameters.AddWithValue("@pimage", filen);
                cmd.Parameters.AddWithValue("@email", mail.Text.Trim());
         



                cmd.Connection = con;
                con.Open();
                //use Command method to execute INSERT statement and return
                //Boolean true if number of records inserted is greater than zero
                IsAdded = cmd.ExecuteNonQuery() > 0;

                Response.Redirect("loginord.aspx");
                con.Close();
                if (IsAdded)
                {
                    lblMsg.Text = first.Text + " Register successfully!";
                    lblMsg.ForeColor = System.Drawing.Color.Orange;


                }
                else
                {
                    lblMsg.Text = "Error while registering " + first.Text;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }

            
        
    }
}