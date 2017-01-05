using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Dear_Diary.Security_API;
using System.Threading;
using System.Diagnostics;

namespace Dear_Diary.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static int counter = 0;

        protected void Login_Click(object sender, EventArgs e)
        {             
            //DATABASE
            //Pull out and compare
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                Byte[] salt = new byte[8];

                //get email and password input
                string inputemail = TextBox1.Text;
                string inputpassword = TextBox2.Text;
                string passwordHash = Hash.ComputeHash(inputpassword, "SHA512", salt);
                string randomNo = GenerateRandomOTP(6, saAllowedCharacters);

                String dbEmail = "";
                String dbPassword = "";
                String dbrandomNo = "";
                String dbMobile = "";
                String dbCount = "";

                //-ADDED THIS FOR LOCKOUT- 
                //int counter = 0;

                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                string query1 = "UPDATE [User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                //CHECK THESE 2 QUERIES AGAIN

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand1.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                //updating the database with the generated randomNo
                myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
                myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                myCommand1.ExecuteNonQuery();

                SqlDataReader reader = myCommand.ExecuteReader();

                //read data from db
                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbPassword = reader["Password"].ToString();
                    dbrandomNo = reader["randomNo"].ToString();
                    dbMobile = reader["Phone_Number"].ToString();
                    dbCount = reader["counter"].ToString();
                }

                myConnection.Close();

                bool hashresult = Hash.VerifyHash(inputpassword, "SHA512", dbPassword);

                if (dbEmail.Equals(inputemail) && hashresult == true)
                {
                    Session["email"] = TextBox1.Text;
                    

                    //String url = "http://172.20.128.62/SMSWebService/sms.asmx/sendMessage?MobileNo=" + dbMobile + "&Message=" + "Your OTP is: " + dbrandomNo + ". Please enter within 2 minutes. Do not reply to this message." + "&SMSAccount=NSP10&SMSPassword=220867";

                    Response.Redirect("/Account/2FA_Input.aspx");
                    //if the inputs are true, I start the countdown
                    //stopwatch.Start();
                    //Thread.Sleep(6000);
                }
                //Either email/password wrong, shows this
                else if (dbEmail.Equals(inputemail) && hashresult == false)
                {
                    myConnection.Open();

                    //Read counter from database, check if its 5. If 5, then don't allow login. 
                    if (Convert.ToInt32(dbCount)>=5)
                    {
                        //Disable TextBox
                        //Start countdown timer
                        //change status to locked
                        //Message: your account has been locked, please try again __ minutes later
                        Label5.Text = "Your account has been locked, please try again ___ minutes later. ";
                    }
                    else if (Convert.ToInt32(dbCount)<5)
                    {
                        counter++;
                        string query2 = "UPDATE [User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                        SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                        myCommand2.Parameters.AddWithValue("@inputemail", inputemail);
                        myCommand2.Parameters.AddWithValue("@counter", counter);
                        Label5.Text = "Invalid credentials. Please try again.";
                        myConnection.Close();
                    }
                }
                else if (!dbEmail.Equals(inputemail) || hashresult == false)
                {
                    Label5.Text = "Invalid credentials. Please try again.";
                }
                else if (inputemail == "" || inputpassword == "")
                {
                    //if empty
                }

            }

            //Take USERNAME put at top right hand corner (Hello _____) 
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