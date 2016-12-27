using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Dear_Diary.Security_API;

namespace Dear_Diary.Account
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetPassword_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                Byte[] salt = new byte[8];

                string email = "limruoqijoanne54@gmail.com";
                string inputpassword = TextBox1.Text;
                //string hashpassword = Hash.ComputeHash(inputpassword, "SHA512", salt);

                myConnection.Open();
                string query1 = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email";
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myCommand1.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = myCommand1.ExecuteReader();

                string dbPassword = "";
                if(reader.Read())
                {
                    dbPassword = reader["Password"].ToString();
                }

                myConnection.Close();

                //Checking if the new password is the same as the old password

                //bool hashresult = Hash.VerifyHash(inputpassword, "SHA512", dbPassword);

                if (dbPassword.Equals(inputpassword))
                //if (hashresult == true)
                {
                    Label5.Text = "You cannot use the same password again. Please change your password.";
                }

                //if hashresult == false, then means the new password is different from the old password, hence can change password
                else
                {
                    bool result = IsValid(inputpassword);

                    if (result == false)
                    {
                        Label5.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                    }
                    else
                    {
                        Label5.Text = "";
                        //Byte[] salt = new byte[8];
                        //string pwdHash = SimpleHash.ComputeHash(inputpassword, "SHA512", salt);
                        /*string email = "limruoqijoanne54@gmail.com";*/ //test only - actual is when clicked on link, application should know which EMAIL it is from. 
                                                                         //ASK: i don't know how to do link 

                        myConnection.Open();

                        string query = "UPDATE [dbo].[User] SET Password=@Password WHERE Email_Address ='" + email + "'";
                        SqlCommand myCommand = new SqlCommand(query, myConnection);

                        myCommand.Parameters.AddWithValue("@Password", inputpassword);

                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        Response.Redirect("/Account/ResetPasswordSuccess");
                    }
                }
            }

            //IDEA: 
            //take input password and dbpassword and compare
            //First, take input password and hash it using the same hash that we used to hash the password when it was first created
            //Next pull the password from database to compare
        }

        //Hash only - without salt
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        private static int Minimum_Length = 8;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
        private static int NonAlpha_length = 1;
        private static int Numeric_length = 1;

        public static bool IsValid(string Password)
        {
            if (Password.Length < Minimum_Length)
                return false;
            if (UpperCaseCount(Password) < Upper_Case_length)
                return false;
            if (LowerCaseCount(Password) < Lower_Case_length)
                return false;
            if (NumericCount(Password) < 1)
                return false;
            if (NonAlphaCount(Password) < NonAlpha_length)
                return false;
            return true;
        }

        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
    }
}
