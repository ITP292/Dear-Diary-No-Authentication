using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//2FA testing
namespace Dear_Diary.Account
{
    public partial class Testing1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //In 2FA pop-up test
        protected void Button_Confirm(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            string inputemail = "xjt@gmail.com";
            string dbRandomNo = "";

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT randomNo FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbRandomNo = reader["randomNo"].ToString();
                }

                string inputNo = TextBox1.Text;

                if (inputNo.Equals(dbRandomNo))
                {
                    Label1.Text = "Success";
                }
                else if (!inputNo.Equals(dbRandomNo))
                {
                    Label1.Text = "Failed";
                }
            }
        }

        //OUTSIDE OF 2FA pop-up test
        //Confirming the 2FA input is same as the 2FA code in database
        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            string inputemail = "xjt@gmail.com";
            string dbRandomNo = "";

            //Click on button, retrieve random number of xjt@gmail.com and compare it with user's input
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT randomNo FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbRandomNo = reader["randomNo"].ToString();
                }

                string inputNo = TextBox2.Text;

                if (inputNo.Equals(dbRandomNo))
                {
                    Label3.Text = "Success";
                }
                else if (!inputNo.Equals(dbRandomNo))
                {
                    Label3.Text = "Failed";
                }
            }
        }
    }
}