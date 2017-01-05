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

namespace Dear_Diary.Account
{
    public partial class Login : System.Web.UI.Page
    {
        public static int count = 0;
        public static int timeCounter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection myConnection;
            //using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            //{
            //}
        }

        protected void Login_Click(object sender, EventArgs e)
        {             
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

                //-ADDED THIS FOR LOCKOUT- 
                //int counter = 0;

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
                    dbrandomNo = reader["randomNo"].ToString();
                    dbMobile = reader["Phone_Number"].ToString();
                    dbCount = reader["counter"].ToString();
                    dbSalt = reader["salt"].ToString();

                }

                string passwordHash = ComputeHash(inputpassword, new SHA512CryptoServiceProvider(), Convert.FromBase64String(dbSalt));

                myConnection.Close();


                if (dbEmail.Equals(inputemail) && dbPassword.Equals(passwordHash))
                {
                    Session["email"] = TextBox1.Text;

                    myConnection.Open();
                    string query1 = "UPDATE [dbo].[User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                    myCommand1.CommandType = CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
                    myCommand1.ExecuteNonQuery();
                    myConnection.Close();
                    Response.Redirect("/Account/2FA_Input.aspx");

                    //String url = "http://172.20.128.62/SMSWebService/sms.asmx/sendMessage?MobileNo=" + dbMobile + "&Message=" + "Your OTP is: " + dbrandomNo + ". Please enter within 2 minutes. Do not reply to this message." + "&SMSAccount=NSP10&SMSPassword=220867";

                    // - NOTWORKING - 
                    myConnection.Open();
                    //count=0;
                    string query3 = "UPDATE [dbo].[User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                    SqlCommand myCommand3 = new SqlCommand(query3, myConnection);
                    myCommand3.CommandType = CommandType.Text;
                    myCommand3.Parameters.AddWithValue("@counter", 0);
                    myCommand3.Parameters.AddWithValue("@inputemail", inputemail);
                    myCommand3.ExecuteNonQuery();
                    myConnection.Close();
                    // - NOTWORKING - 
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

                    }

                    //Read counter from database, check if its 5. If 5, then don't allow login. 
                    else if (Convert.ToInt32(dbCount) == 5)
                    {
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        Label2.Text = "Your account has been locked";
                        //Label1.Text = count.ToString();
                        Timer1.Enabled = true;
                        timeCounter = 0;
                        Label5.Text = "Your account has been locked. Please try again later.";

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

        protected void Timer_Tick(object sender, EventArgs e)
        {
            timeCounter++;
            if (timeCounter >= 1)
            {
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                Timer1.Enabled = false;
                Label5.Text = "";
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