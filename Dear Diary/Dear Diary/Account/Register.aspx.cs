using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Dear_Diary.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            //Captcha?
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                Byte[] salt = new byte[8];

                string fname = TextBox1.Text;
                string lname = TextBox2.Text;
                string email = TextBox3.Text;
                string password = TextBox4.Text;
                //string passwordhash = SimpleHash.ComputeHash(password, "SHA512", salt);
                string passwordhash = ""; //after confirmation, delete this
                string confirmpassword = TextBox5.Text;
                string phonenumber = TextBox6.Text;
                //change string phone number to integer to store in database
                //string randomNo = "";

                myConnection.Open();

                string query1 = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email OR Phone_Number = @phonenumber";
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myCommand1.Parameters.AddWithValue("@Email", email);
                myCommand1.Parameters.AddWithValue("@phonenumber", phonenumber);

                SqlDataReader reader = myCommand1.ExecuteReader();

                bool result = IsValid(password);

                Label11.Text = result.ToString();
                //TRUE/FALSE shown

                //Checking - cannot use same email or phone number to register
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dbemail = reader["Email_Address"].ToString();
                        string dbphone = reader["Phone_Number"].ToString();

                        //If user uses same email and phone number to register again
                        if (email == dbemail && phonenumber == dbphone && result == false)
                        {
                            Label12.Text = "This account exists.";
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                        }

                        //If user uses same email to register again
                        else if (email == dbemail && phonenumber != dbphone && result == false)
                        {
                            Label12.Text = "This email has an account already.";
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                        }

                        //If user uses same phone number to register again
                        else if (phonenumber == dbphone && email != dbemail && result == false)
                        {
                            Label9.Text = "This phone number has been used.";
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                        }

                        else if (email == dbemail && phonenumber == dbphone || result == true)
                        {
                            Label12.Text = "This account exists.";
                        }

                        //If user uses same email to register again
                        else if (email == dbemail && phonenumber != dbphone || result == true)
                        {
                            Label12.Text = "This email has an account already.";
                        }

                        //If user uses same phone number to register again
                        else if (phonenumber == dbphone && email != dbemail || result == true)
                        {
                            Label9.Text = "This phone number has been used.";
                        }
                    }
                }

                //else, create the new account
                else
                {
                    reader.Close();

                    if (result == false)
                    {
                        Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                    }
                    else
                    {
                        string query = "INSERT INTO [dbo].[User](Email_Address, FName, LName, Password, Phone_Number)";
                        query += " VALUES (@Email, @FName, @LName, @Password, @PhoneNumber)";
                        SqlCommand myCommand = new SqlCommand(query, myConnection);

                        //To prevent sql injection
                        myCommand.Parameters.AddWithValue("Email", email);
                        myCommand.Parameters.AddWithValue("FName", fname);
                        myCommand.Parameters.AddWithValue("LName", lname);
                        //myCommand.Parameters.AddWithValue("@Picture", null);
                        myCommand.Parameters.AddWithValue("Password", password);
                        //myCommand.Parameters.AddWithValue("@Password", passwordhash);
                        myCommand.Parameters.AddWithValue("PhoneNumber", phonenumber);
                        //myCommand.Parameters.AddWithValue("randomNo", randomNo);

                        myCommand.ExecuteNonQuery();
                        Response.Redirect("/Account/SuccessfulRegistration");
                    }
                }
                //Add codes to redirect to message Successful Registration Page
                //Telling them that their account has been successfully made and click HERE (link) to login
                //HERE hyperlink redirects to Login Page
            }
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