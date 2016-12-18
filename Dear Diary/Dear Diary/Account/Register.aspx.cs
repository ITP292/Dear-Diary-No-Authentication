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
            Response.Redirect("/Account/SuccessfulRegistration.aspx");
            //DATABASE
            //Insert into database

            //Import System.Data.SqlClient
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
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
                //this part in the brackets put all the columns of database? - NEVER INSERT PHOTO AND GENDER
                string query = "INSERT INTO User (Email_Address, FName, LName, Password, Phone Number)";
                query += "VALUES (@Email, @FName, @LName, @Password, @PhoneNumber)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("@Email", email);
                myCommand.Parameters.AddWithValue("@FName", fname);
                myCommand.Parameters.AddWithValue("@LName", lname);
                myCommand.Parameters.AddWithValue("@Password", passwordhash);

            }

            //Add codes to redirect to message Successful Registration Page
            //Telling them that their account has been successfully made and click HERE (link) to login
            //HERE hyperlink redirects to Login Page
        }
    }
}