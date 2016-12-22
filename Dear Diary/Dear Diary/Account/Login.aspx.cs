using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Dear_Diary.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
                //string passwordHash = SimpleHash.ComputeHash(inputpassword, "SHA512", salt);
                string randomNo = GenerateRandomOTP(6, saAllowedCharacters);
                string OTPinput = ""; //input the TextBox.Text here after creating 2FA place to input

                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                string query1 = "UPDATE [User] SET [randomNo] = @randomNo WHERE [Email_Address] = @inputemail";
                //CHECK THESE 2 QUERIES AGAIN

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand1.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                

                SqlDataReader reader = myCommand.ExecuteReader();

                String dbEmail = "";
                String dbPassword = "";
                String dbrandomNo = "";
                String dbMobile = "";

                //read data from db
                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbPassword = reader["Password"].ToString();
                    dbrandomNo = reader["randomNo"].ToString();
                    dbMobile = reader["Phone_Number"].ToString();

                }

                myConnection.Close();
                myConnection.Open();

                myCommand1.Parameters.AddWithValue("@randomNo", randomNo);
                myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                myCommand1.ExecuteNonQuery();

                //bool hashresult = SimpleHash.VerifyHash(inputpassword, "SHA512", dbPassword);

                //Session
                
                if (dbEmail.Equals(inputemail) && dbPassword.Equals(inputpassword))
                {
                    String url = "www.google.com";
                    System.Diagnostics.Process.Start(url);
                    
                    //Response.Redirect("/Account/AccountPage.aspx");
                }
                else
                {
                    Label4.Text = "No such user. Please try again.";
                }

                //Stop here

            }

                //Add in codes to redirect to 2FA first
                //Then redirect to account page 
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