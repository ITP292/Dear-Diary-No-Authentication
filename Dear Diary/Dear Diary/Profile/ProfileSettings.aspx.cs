/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dear_Diary.Security_API;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Dear_Diary.Profile
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        public static String Name = "";
        public static String dbEmail = "";
        public static String dbProfilePic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
  
            if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    SqlConnection myConnection;
                    using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                    {
                        String dbFName = "";
                        String dbLName = "";
                        String sessionEmail = Session["email"].ToString();
                        String query = "SELECT [FName], [LName], [Email_Address], [displayPic] FROM [User] WHERE [Email_Address] = @email";
                        SqlCommand myCommand = new SqlCommand(query, myConnection);

                        myConnection.Open();
                        //myCommand.CommandType = CommandType.Text;
                        myCommand.Parameters.AddWithValue("@email", sessionEmail);

                        SqlDataReader reader = myCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            dbEmail = reader["Email_Address"].ToString();
                            dbFName = reader["FName"].ToString();
                            dbLName = reader["LName"].ToString();
                            dbProfilePic = reader["displayPic"].ToString();

                        }

                        Image1.ImageUrl = dbProfilePic;
                        editFName.Text = dbFName;
                        editLName.Text = dbLName;

                        myConnection.Close();


                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Pictures/") + fileName);
                Session["imagePath"] = "~/Pictures/" + fileName;
                Image1.ImageUrl = "~/Pictures/" + fileName;
                Image1.Visible = true;
            }

            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {



                // update user profile photo based on email
                string query = "UPDATE [User] SET [displayPic] = @picture WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@picture", Session["imagePath"].ToString());
                myCommand.Parameters.AddWithValue("@email", Session["email"].ToString());

                myCommand.ExecuteNonQuery();


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {


                String newFName = editFName.Text;
                String newLName = editLName.Text;

                myConnection.Open();



                // update user data based on text typed in textbox
                string query3 = "UPDATE [User] SET [FName]=@FName, [LName]=@LName WHERE [Email_Address]=@email";
                SqlCommand myCommand3 = new SqlCommand(query3, myConnection);



                myCommand3.Parameters.AddWithValue("@FName", newFName);
                myCommand3.Parameters.AddWithValue("@LName", newLName);
                myCommand3.Parameters.AddWithValue("@email", Session["email"].ToString());
                myCommand3.ExecuteNonQuery();

                //PASSWORD RESET
                Byte[] salt = new byte[8];

                string inputpassword = txtPassword.Text;

                    myConnection.Open();
                    string query1 = "SELECT * FROM [dbo].[User] WHERE Email_Address = @Email";
                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                    myCommand1.Parameters.AddWithValue("@Email", Session["email"].ToString());

                    SqlDataReader reader1 = myCommand1.ExecuteReader();

                    string dbPassword = "";
                    string dbSalt = "";

                    if (reader1.Read())
                    {
                        dbPassword = reader1["Password"].ToString();
                        dbSalt = reader1["salt"].ToString();
                    }

                    myConnection.Close();
                    string hashpassword = ComputeHash(inputpassword, new SHA512CryptoServiceProvider(), Convert.FromBase64String(dbSalt));

                    //Checking if the new password is the same as the old password


                    //if (dbPassword.Equals(inputpassword))
                    if (dbPassword.Equals(hashpassword))
                    {
                        Label5.Text = "You cannot use the same password again. Please change your password.";
                    }

                    //if hashresult == false, then means the new password is different from the old password, hence can change password
                    else if (!dbPassword.Equals(hashpassword))
                    {

                        bool result = IsValid(inputpassword);
                        Label5.Text = "";

                        if (result == false)
                        {
                            Label5.Text = "Weak Password. Your password should be at least 8 characters in length: 1 uppercase, 1 lowercase, 1 digit and 1 special character.";
                            //Label5.Text = "";
                        }
                        else
                        {
                            Label5.Text = "";
                            //Byte[] salt = new byte[8];
                            //string pwdHash = SimpleHash.ComputeHash(inputpassword, "SHA512", salt);
                            /*string email = "limruoqijoanne54@gmail.com";*/ //test only - actual is when clicked on link, application should know which EMAIL it is from. 
                                                                             //ASK: i don't know how to do link 

                            myConnection.Open();

                            string query = "UPDATE [dbo].[User] SET Password=@Password WHERE Email_Address ='" + Session["email"].ToString() + "'";
                            SqlCommand myCommand = new SqlCommand(query, myConnection);

                            myCommand.Parameters.AddWithValue("@Password", hashpassword);

                            myCommand.ExecuteNonQuery();
                            myConnection.Close();

                        }
                    }
                }

        }

        public static string ComputeHash(string input, HashAlgorithm algorithm, Byte[] salt)
        {
            Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            // Combine salt and input bytes
            Byte[] saltedInput = new Byte[salt.Length + inputBytes.Length];
            salt.CopyTo(saltedInput, 0);
            inputBytes.CopyTo(saltedInput, salt.Length);

            Byte[] hashedBytes = algorithm.ComputeHash(saltedInput);

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
            return System.Text.RegularExpressions.Regex.Matches(Password, "[A-Z]").Count;
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