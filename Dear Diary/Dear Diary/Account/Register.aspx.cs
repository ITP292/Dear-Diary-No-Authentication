using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Dear_Diary.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            //Testing - redirect to SuccessfulRegistration Page
            //Response.Redirect("/Account/SuccessfulRegistration.aspx");


            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                Byte[] sale = new byte[8];

                string fname = TextBox1.Text;
                string lname = TextBox2.Text;
                string email = TextBox3.Text;
                string password = TextBox4.Text;
                //string passwordhash = SimpleHash.ComputeHash(password, "SHA512", salt);
                string passwordhash = ""; //after confirmation, delete this
                string confirmpassword = TextBox5.Text;
                string phonenumber = TextBox6.Text;
                //change string phone number to integer to store in database

                myConnection.Open();
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
                myCommand.ExecuteNonQuery();

            }

            //Add codes to redirect to message Successful Registration Page
            //Telling them that their account has been successfully made and click HERE (link) to login
            //HERE hyperlink redirects to Login Page
        }
    }
}