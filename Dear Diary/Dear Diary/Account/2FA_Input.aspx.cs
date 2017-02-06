using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dear_Diary.ServiceReference1;
using System.Net;

namespace Dear_Diary.Account
{
    public partial class _2FA_Input : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }*/
        }

        //Confirm Code
        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string inputCode = TextBox1.Text;
                //string inputemail = Session["email"].ToString(); 

                String inputemail = Login.globalinputemail;
                if (inputemail == null || inputemail == "")
                {
                    //inputemail = 
                }
                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                string dbRandomNo = "";
                DateTime dbstartTime;
                String dbTime = "";

                if (reader.Read())
                {
                    dbRandomNo = reader["randomNo"].ToString();
                    dbTime = reader["TimeGenerateCode"].ToString();

                }

                if (inputCode.Equals(dbRandomNo))
                {
                    DateTime endTime = DateTime.Now;
                    dbstartTime = Convert.ToDateTime(dbTime);

                    TimeSpan difference = endTime.Subtract(dbstartTime);

                    if (difference.TotalSeconds < 30) //30 seconds for testing
                    {
                        Session["email"] = Login.globalinputemail;
                  
                        Response.Redirect("/Profile/UserProfile.aspx");
                    }
                    else
                        Label5.Text = "Your code has expired. Please request for another code.";
                    
                }
                else if (!inputCode.Equals(dbRandomNo))
                {
                    Label4.Text = "Invalid Code. Please re-enter code.";
                }

            }

        }

        //Resending Code
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label5.Text = "A new code has been sent. Please check your phone.";
            Dear_Diary.ServiceReference1.SMSSoapClient sms = new SMSSoapClient();
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                //string inputemail = Session["email"].ToString(); 
                string inputemail = Login.globalinputemail;

                string randomNo = GenerateRandomOTP(6, saAllowedCharacters);
                //Once resend code, need to update randomNo
                string query = "UPDATE [User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                string query1 = "SELECT * FROM [User] WHERE [Email_Address] = @email";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand1.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@inputemail", inputemail);
                myCommand.Parameters.AddWithValue("@randomNo", randomNo);
                myCommand1.Parameters.AddWithValue("@email", inputemail);
                myCommand.ExecuteNonQuery();

                SqlDataReader reader = myCommand1.ExecuteReader();

                string dbPhone = "";
                string dbRandomNo = "";
                string dbMobile = "";
                if (reader.Read())
                {
                    dbPhone = reader["Phone_Number"].ToString();
                    dbRandomNo = reader["randomNo"].ToString();
                    dbMobile = reader["Phone_Number"].ToString();
                }

                //Send new message
                string message = "Your OTP is: " + randomNo + ". Please enter within 2 minutes. Do not reply to this message.";
                //sms.sendMessage("AS1", "637337", dbMobile, message);
                myConnection.Close();

                DateTime startTime = DateTime.Now;
                myConnection.Open();
                string query2 = "UPDATE [dbo].[User] SET [TimeGenerateCode] = @start WHERE [Email_Address] = @inputemail";
                SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                myCommand2.CommandType = CommandType.Text;
                myCommand2.Parameters.AddWithValue("@inputemail", inputemail);
                myCommand2.Parameters.AddWithValue("@start", startTime);
                myCommand2.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        //generate otp code method
        private string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {
            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            //DateTime time = DateTime.Now;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }

            return sOTP;
        }

        }
    }
