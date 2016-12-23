using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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

                string inputpassword = TextBox1.Text;

                //Byte[] salt = new byte[8];
                //string pwdHash = SimpleHash.ComputeHash(inputpassword, "SHA512", salt);
                string email = "limruoqijoanne54@gmail.com"; //test only - actual is when clicked on link, application should know which EMAIL it is from. 
                //ASK: i don't know how to do link 

                myConnection.Open();

                string query = "UPDATE [dbo].[User] SET Password=@Password WHERE Email_Address ='" + email + "'";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@Password", inputpassword);
                //delete above because password should be replaced with HASHED password
                //myCommand.Parameters.AddWithValue("@Password", pwdHash);

                myCommand.ExecuteNonQuery();
                myConnection.Close();

            }

            //IDEA: 
            //take input password and dbpassword and compare
            //First, take input password and hash it using the same hash that we used to hash the password when it was first created
            //Next pull the password from database to compare
        }
    }
}