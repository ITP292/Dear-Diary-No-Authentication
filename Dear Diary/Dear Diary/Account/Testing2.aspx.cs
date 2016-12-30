using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Dear_Diary.Account
{
    public partial class Testing2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Enter 2FA input and check if the input and number in database is the same
        //Pulling from database and check with user input
        protected void Button1_Click(object sender, EventArgs e)
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
                    Label2.Text = "Success";
                }
                else if (!inputNo.Equals(dbRandomNo))
                {
                    Label2.Text = "Failed";
                }
            }
        }


        //Getting the current time
        protected void Button2_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            Label3.Text = time;
        }
    }
}