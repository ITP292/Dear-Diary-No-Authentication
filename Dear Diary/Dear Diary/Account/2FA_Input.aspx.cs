using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class _2FA_Input : System.Web.UI.Page
    {
        public static int timeCounter = 0;
        //Timer countdown for 2FA code

        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            timeCounter = 0;
        }

        //Confirm Code
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string inputCode = TextBox1.Text;
                string inputemail = Session["email"].ToString(); //need help, how to get the input email from login page previously? Is it session?

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                string dbRandomNo = "";

                if (reader.Read())
                {
                    dbRandomNo = reader["randomNo"].ToString();
                }

                if (inputCode.Equals(dbRandomNo))
                {
                    String url = "www.google.com";
                    System.Diagnostics.Process.Start(url);
                    Timer1.Enabled = false;
                    //if Correct code, stop timer. 
                    Response.Redirect("/Account/AccountPage.aspx");

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
            Timer1.Enabled = true;
            timeCounter = 0;
            //False because new code means new timer start countdown
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                string inputemail = Session["email"].ToString(); 

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

                if (reader.Read())
                {
                    dbPhone = reader["Phone_Number"].ToString();
                    dbRandomNo = reader["randomNo"].ToString();
                }

                //Send new message
                //String url = "http://172.20.128.62/SMSWebService/sms.asmx/sendMessage?MobileNo=" + dbPhone + "&Message=" + "Your OTP is: " + dbRandomNo + ". Please enter within 2 minutes. Do not reply to this message." + "&SMSAccount=NSP10&SMSPassword=220867";
                String url = "www.google.com.sg";
                System.Diagnostics.Process.Start(url);


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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            timeCounter++;
            if (timeCounter >= 1)
            {
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    string inputemail = Session["email"].ToString();
                    string randomNo = "1";
                    myConnection.Open();
                    string query1 = "UPDATE [dbo].[User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                    myCommand1.CommandType = CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
                    myConnection.Close();
                }
                    Timer1.Enabled = false;

                
            }
        }
    }
}