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

            //Password Requirements (1 uppercase, 1 lowercase, 1 number, 1 special character - need at least 8 characters)
            //if (password.Length<8)
            //{
            //    Label9.Text = "Weak Password. Your password should have at least 8 characters: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
            //}

            //!!!! ADDED - CHECK - can't work
            //string userpassword = password;
            //PasswordScore passwordStrengthScore = PasswordAdvisor.CheckStrength(userpassword);

            //switch (passwordStrengthScore)
            //{
            //    case PasswordScore.Blank:
            //    case PasswordScore.VeryWeak:
            //    case PasswordScore.Weak:
            //        // Show an error message to the user
            //        Label9.Text = "error";
            //        break;
            //    case PasswordScore.Medium:
            //    case PasswordScore.Strong:
            //    case PasswordScore.VeryStrong:
            //        // Password deemed strong enough, allow user to be added to database etc
            //        break;
            //}

            //Captcha?
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query1 = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email OR Phone_Number = @phonenumber";
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myCommand1.Parameters.AddWithValue("@Email", email);
                myCommand1.Parameters.AddWithValue("@phonenumber", phonenumber);

                SqlDataReader reader = myCommand1.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dbemail = reader["Email_Address"].ToString();
                        string dbphone = reader["Phone_Number"].ToString();

                        //If user uses same email and phone number to register again
                        if (email == dbemail && phonenumber == dbphone)
                        {
                            Label9.Text = "This account exists.";
                        }

                        //If user uses same email to register again
                        if (email == dbemail && phonenumber != dbphone)
                        {
                            Label9.Text = "This email has an account already.";
                        }

                        //If user uses same phone number to register again
                        if (phonenumber == dbphone && email != dbemail)
                        {
                            Label9.Text = "This phone number has been used.";
                        }
                    }
                }


                //else, create the new account
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

    //!!!! ADDED - CHECK - can't work
    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public class PasswordAdvisor
    {
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 1)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
    }
}