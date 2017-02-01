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

namespace Dear_Diary.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                Byte[] salt = new byte[8];
                salt = GenerateSalt(salt);

                string fname = TextBox1.Text;
                string lname = TextBox2.Text;
                string email = TextBox3.Text;
                string password = TextBox4.Text;
                string passwordhash = ComputeHash(password, new SHA512CryptoServiceProvider(), salt);
                string confirmpassword = TextBox5.Text;
                string phonenumber = TextBox6.Text;
                //change string phone number to integer to store in database

                //For PHONENUMBER
                string firstDigit = phonenumber.Substring(0, 1);
                bool phoneresult = IsAllDigits(phonenumber);


                myConnection.Open();

                string query1 = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email OR Phone_Number = @phonenumber";
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myCommand1.Parameters.AddWithValue("@Email", email);
                myCommand1.Parameters.AddWithValue("@phonenumber", phonenumber);

                SqlDataReader reader = myCommand1.ExecuteReader();

                bool result = IsValid(password);

                //Label11.Text = "(PASSWORD REQUIREMENT) " + result.ToString() + ", (PHONE ALL DIGITS?) " + phoneresult.ToString();
                //TRUE/FALSE shown - if fulfill password requirements = TRUE, if never = FALSE

                //Checking - cannot use same email or phone number to register
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dbemail = reader["Email_Address"].ToString();
                        string dbphone = reader["Phone_Number"].ToString();

                        //If user uses same email or phone number to register again
                        if ((email == dbemail || phonenumber == dbphone) && result == false)
                        {
                            Label12.Text = "This account exists. Phone Number/Email has been registered before.";
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                        }

                        else if ((email == dbemail || phonenumber == dbphone) && result == true)
                        {
                            Label10.Text = "";
                            Label12.Text = "This account exists. Phone Number/Email has been registered before.";
                        }
                    }
                }

                //else (if there is no existing same account), create the new account
                else
                {
                    reader.Close();

                    if (result == true && (phoneresult == true && phonenumber.Length == 8 && (firstDigit == "9" || firstDigit == "8")))
                    {
                        Label10.Text = "";

                        string query = "INSERT INTO [dbo].[User](Email_Address, FName, LName, Password, Phone_Number, salt, counter)";
                        query += " VALUES (@Email, @FName, @LName, @Password, @PhoneNumber, @Salt, @Counter)";
                        SqlCommand myCommand = new SqlCommand(query, myConnection);

                        //To prevent sql injection
                        myCommand.Parameters.AddWithValue("Email", email);
                        myCommand.Parameters.AddWithValue("FName", fname);
                        myCommand.Parameters.AddWithValue("LName", lname);
                        myCommand.Parameters.AddWithValue("Password", passwordhash);
                        myCommand.Parameters.AddWithValue("PhoneNumber", phonenumber);
                        myCommand.Parameters.AddWithValue("Salt", Convert.ToBase64String(salt));
                        myCommand.Parameters.AddWithValue("Counter", 0);

                        myCommand.ExecuteNonQuery();
                        Response.Redirect("/Account/SuccessfulRegistration");
                    }

                    else
                    {
                        if (result == true && (phoneresult == false || firstDigit != "9" || firstDigit != "8" || phonenumber.Length != 8))
                        {
                            Label9.Text = "Phone Number must be 8 digits";
                            Label10.Text = "";
                        }

                        else if (result == false && phoneresult == true && phonenumber.Length == 8 && (firstDigit == "9" || firstDigit == "8"))
                        {
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                            Label12.Text = "";
                            Label9.Text = "";
                        }

                        else if (result == false && phoneresult == false || firstDigit != "9" || firstDigit != "8" || phonenumber.Length != 8)
                        {
                            Label9.Text = "Phone Number must be 8 digits";
                            Label10.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                        }

                    }
                }
            }
        }

        private static int Minimum_Length = 8;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
        private static int NonAlpha_length = 1;
        //private static int Numeric_length = 1;

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

        //to check if phone string is fully digits, no alphabets or special characters.
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
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

        //private static byte[] GetSalt(int maximumSaltLength)
        //{
        //    var salt = new byte[maximumSaltLength];
        //    using (var random = new RNGCryptoServiceProvider())
        //    {
        //        random.GetNonZeroBytes(salt);
        //    }

        //    return salt;
        //}

        public static byte[] GenerateSalt(byte[] salt)
        {
            RNGCryptoServiceProvider rncCsp = new RNGCryptoServiceProvider();
            rncCsp.GetBytes(salt);

            return salt;
        }

    }
}