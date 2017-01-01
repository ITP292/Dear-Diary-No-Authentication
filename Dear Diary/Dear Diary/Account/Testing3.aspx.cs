using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Testing3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection myConnection;
        protected void Button1_Click(object sender, EventArgs e)
        {
            string dbCount = "";
            string dbEmail = "";
            string dbRandomNo = "";
            string inputemail = TextBox1.Text;
            string inputNo = TextBox2.Text;
            int counter = 0;

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT * FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbRandomNo = reader["randomNo"].ToString();
                }

                dbCount = reader["testCount"].ToString();
                myConnection.Close();

                string query1 = "UPDATE [User] SET [testCount] = @testCount WHERE [Email_Address] = @inputemail";
                SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                myConnection.Open();
                myCommand1.CommandType = CommandType.Text;
                myCommand1.Parameters.AddWithValue("@inputemail", inputemail);
                myCommand1.Parameters.AddWithValue("@testCount", counter);
                myCommand1.ExecuteNonQuery();


                if (!inputNo.Equals(dbRandomNo))
                {
                    counter += 1;
                }
                
                myCommand1.ExecuteNonQuery();


                Label3.Text = dbCount;
            }
        }
    }
}