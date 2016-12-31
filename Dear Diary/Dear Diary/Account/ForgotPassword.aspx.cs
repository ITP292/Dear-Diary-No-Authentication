using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Dear_Diary.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmailMe_Click(object sender, EventArgs e)
        {
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
                    string dbemail = reader["Email_Address"].ToString();

                    if (!inputemail.Equals(dbemail))
                    {
                        //Label4.Text = "This account does not exist.";
                        Label5.Text = "This account does not exist.";
                    }
                    else if (inputemail == dbemail)
                    {
                        string link = "test";
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
                        smtp.Send("joanne855902@gmail.com", inputemail, "Reset your password", "Click on this link below to reset your password " + link);
                        //format - From, To, Subject, Body

                        myConnection.Close();

                    }
                }


            }


        }
    }
}