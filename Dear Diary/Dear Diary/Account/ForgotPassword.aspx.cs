using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Dear_Diary.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmailMe_Click(object sender, EventArgs e)
        {
            string dbemail = "";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string inputemail = TextBox1.Text;

                myConnection.Open();

                string query = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.Parameters.AddWithValue("@Email", inputemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    dbemail = reader["Email_Address"].ToString();

                    if (inputemail == dbemail)
                    {
                        string link = "www.google.com.sg";
                        //generate link here to be sent to email to reset password

                        var smtp = new System.Net.Mail.SmtpClient();
                        {
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential("joanne855902@gmail.com", "testing855902");
                            smtp.EnableSsl = true;
                            smtp.Timeout = 20000;
                        }
                        smtp.Send("joanne855902@gmail.com", inputemail, "Reset your password", 
                            "Dear User, \n \n Please Reset your password by following the instructions. " + 
                            "\n Click on this link below to reset your password. \n " + link + "\n \n Thank You.");
                        //format - From, To, Subject, Body

                        Response.Redirect("/Account/ForgetPasswordEmailSent.aspx");
                    }
                }

                if (!inputemail.Equals(dbemail))
                {
                    Label4.Text = "This account does not exist.";

                }
            }
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            string userId = TextBox1.Text;
            string message = string.Empty;
            SendActivationEmail(userId);
 
        }

        private void SendActivationEmail(string userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            using (MailMessage mm = new MailMessage("sender@gmail.com", txtEmail.Text))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + txtUsername.Text.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "<password>");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
        }


    }
}