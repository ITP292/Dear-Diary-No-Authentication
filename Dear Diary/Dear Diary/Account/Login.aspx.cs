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
using System.Threading;
using System.Diagnostics;
using Dear_Diary.ServiceReference1;

namespace Dear_Diary.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public static int count = 0;
        public static int timeCounter = 0; //Timer countdown for lockout

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Dear_Diary.ServiceReference1.SMSSoapClient sms = new SMSSoapClient();

            //DATABASE
            //Pull out and compare
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };


                //get email and password input
                string inputemail = TextBox1.Text;
                string inputpassword = TextBox2.Text;
                string randomNo = GenerateRandomOTP(6, saAllowedCharacters);

                String dbEmail = "";
                String dbPassword = "";
                String dbrandomNo = "";
                String dbMobile = "";
                String dbCount = "";
                String dbSalt = "";

                myConnection.Open();

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);


                SqlDataReader reader = myCommand.ExecuteReader();

                //read data from db
                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbPassword = reader["Password"].ToString();
                    //dbrandomNo = reader["randomNo"].ToString();
                    dbMobile = reader["Phone_Number"].ToString();
                    dbCount = reader["counter"].ToString();
                    dbSalt = reader["salt"].ToString();

                }

                string passwordHash = ComputeHash(inputpassword, new SHA512CryptoServiceProvider(), Convert.FromBase64String(dbSalt));

                myConnection.Close();


                if (dbEmail.Equals(inputemail) && dbPassword.Equals(passwordHash))
                {

                    Session["email"] = TextBox1.Text;

                    //When successful login, counter reset to 0
                    myConnection.Open();
                    count=0;
                    string query3 = "UPDATE [dbo].[User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand3 = new SqlCommand(query3, myConnection);
                    myCommand3.CommandType = CommandType.Text;
                    myCommand3.Parameters.AddWithValue("@counter", count);
                    myCommand3.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand3.ExecuteNonQuery();
                    myConnection.Close();

                    //Generate a random no (2FA code) and update the database
                    myConnection.Open();
                    string query1 = "UPDATE [dbo].[User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                    myCommand1.CommandType = CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
                    myCommand1.ExecuteNonQuery();
                    myConnection.Close();

                    string message = "Your OTP is: " + randomNo + ". Please enter within 2 minutes. Do not reply to this message.";
                    sms.sendMessage("AS1", "637337", dbMobile, message);

                    //String url = "http://172.20.128.62/SMSWebService/sms.asmx/sendMessage?MobileNo=" + dbMobile + "&Message=" + "Your OTP is: " + dbrandomNo + ". Please enter within 2 minutes. Do not reply to this message." + "&SMSAccount=NSP10&SMSPassword=220867";
                    //System.Diagnostics.Process.Start(url);

                    DateTime startTime = DateTime.Now;
                    myConnection.Open();
                    string query4 = "UPDATE [dbo].[User] SET [TimeGenerateCode] = @start WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand4 = new SqlCommand(query4, myConnection);
                    myCommand4.CommandType = CommandType.Text;
                    myCommand4.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand4.Parameters.AddWithValue("@start", startTime);
                    myCommand4.ExecuteNonQuery();

                    Response.Redirect("/Account/2FA_Input.aspx");
                }

                //Either email/password wrong, shows this
                else if (dbEmail.Equals(inputemail) && !dbPassword.Equals(passwordHash))
                {
                    if (Convert.ToInt32(dbCount) >= 0 && Convert.ToInt32(dbCount) < 5)
                    {
                        myConnection.Open();
                        count++;
                        string query2 = "UPDATE [dbo].[User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                        SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                        myCommand2.CommandType = CommandType.Text;
                        myCommand2.Parameters.AddWithValue("@counter", count);
                        myCommand2.Parameters.AddWithValue("@inputemail", inputemail);
                        myCommand2.ExecuteNonQuery();
                        //Label1.Text = count.ToString();
                        Label7.Text = (5 - count).ToString() + " tries left.";


                    }

                    //Read counter from database, check if its 5. If 5, then don't allow login. 
                    else if (Convert.ToInt32(dbCount) == 5)
                    {
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        //Label1.Text = count.ToString();                        
                        Label8.Text = "Your account has been locked. Please try again 5 minutes later.";
                        Timer1.Enabled = true;
                        timeCounter = 0;

                    }
                    else if (Convert.ToInt32(dbCount)<5)
                    {
                        count++;
                        string query2 = "UPDATE [User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                        SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                        myCommand2.Parameters.AddWithValue("@inputemail", inputemail);
                        myCommand2.Parameters.AddWithValue("@counter", count);
                        Label5.Text = "Invalid credentials. Please try again.";
                        myConnection.Close();
                    }
                    Label5.Text = "Invalid credentials. Please try again.";

                }

                else if (!dbEmail.Equals(inputemail) || !dbPassword.Equals(passwordHash))
                {
                    Label5.Text = "Invalid credentials. Please try again.";
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            timeCounter++;
            if (timeCounter >= 1)
            {
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                Timer1.Enabled = false;
                Label5.Text = "";
                Label8.Text = "";
            }
        }

        //protected void Timer2_Tick(object sender, EventArgs e)
        //{
        //    timeCounter1++;
        //    if (timeCounter1 >= 1)
        //    {
        //        SqlConnection myConnection;
        //        using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
        //        {
        //            string inputemail = TextBox1.Text;
        //            string randomNo = null;
        //            //set randomNo to null once time is up
        //            myConnection.Open();
        //            string query1 = "UPDATE [dbo].[User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
        //            SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
        //            myCommand1.CommandType = CommandType.Text;
        //            myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
        //            myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
        //            myCommand1.ExecuteNonQuery();
        //            myConnection.Close();
        //        }
        //            Timer2.Enabled = false;
        //    }
        //}

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
        public static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Combine salt and input bytes
            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

            return BitConverter.ToString(hashedBytes);
        }
    }
}