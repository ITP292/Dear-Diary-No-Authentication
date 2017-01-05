using Dear_Diary.Security_API;
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
    public partial class Testing6 : System.Web.UI.Page
    {
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Take this as Login Button
        //1. Once click, check if inputs are correct/wrong 
        //2. If inputs are wrong, then counter++
        //3. First, we have to SELECT and pull from database to check if counter is already 5
        //4. If counter is already 5, then don't allow login.
        //5. If counter has not reached 5, then continue to add 1

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                Byte[] salt = new byte[8];
                string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

                string inputemail = TextBox1.Text;
                string inputpassword = TextBox2.Text;
                string passwordHash = Hash.ComputeHash(inputpassword, "SHA512", salt);
                string randomNo = GenerateRandomOTP(6, saAllowedCharacters);

                string dbEmail = "";
                string dbPassword = "";
                string dbCount = "";

                myConnection.Open();
                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbPassword = reader["Password"].ToString();
                    dbCount = reader["counter"].ToString();
                }
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

                }
                else if (dbEmail.Equals(inputemail) && !dbPassword.Equals(passwordHash))
                {
                    if (Convert.ToInt32(dbCount)>=0 && Convert.ToInt32(dbCount)<5)
                    {
                        myConnection.Open();
                        count++;
                        string query2 = "UPDATE [dbo].[User] SET [counter] = @counter WHERE [Email_Address] = @inputemail";
                        SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                        myCommand2.CommandType = CommandType.Text;
                        myCommand2.Parameters.AddWithValue("@counter", count);
                        myCommand2.Parameters.AddWithValue("@inputemail", inputemail);
                        myCommand2.ExecuteNonQuery();
                        Label1.Text = count.ToString();


                    }
                    else if (Convert.ToInt32(dbCount)==5)
                    {
                        TextBox1.Enabled = false;
                        TextBox2.Enabled = false;
                        Label2.Text = "Your account has been locked";
                        Label1.Text = count.ToString();

                    }

                    Label1.Text = count.ToString();

                    //if (count >= 0 && count <5)
                    //{
                    //count++;
                    //Label1.Text = count.ToString();
                    //}
                    //else if (count == 5)
                    //{
                    //    Label1.Text = count.ToString();
                    //    Label2.Text = "Counter has reached 5";
                    //}
                }
                else if (!dbEmail.Equals(inputemail) || !dbPassword.Equals(passwordHash))
                {
                    Label2.Text = "Invalid inputs";
                }
            }
            
        }
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