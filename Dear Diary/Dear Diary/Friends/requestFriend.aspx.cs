using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Friends
{
    public partial class requestFriend : System.Web.UI.Page
    {
        private String dbEmail;
        private String dbFName;
        private String dbLName;
        private String Name;
        private String dbProfilePic;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                //On page load, I will get data from Aidil's notification page and modify the header and the email Textbox
                using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String requestEmail = Request.QueryString["User2Email"];
                    String query = "SELECT * FROM [User] WHERE [Email_Address] = @user2email";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@user2email", requestEmail);

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        dbEmail = reader["Email_Address"].ToString();
                        dbFName = reader["FName"].ToString();
                        dbLName = reader["LName"].ToString();
                        dbProfilePic = reader["displayPic"].ToString();
                        Name = dbFName + " " + dbLName;
                    }

                    Header.Text = HttpUtility.HtmlEncode(Name);
                    FriendEmail.Text = HttpUtility.HtmlEncode(dbEmail);
                    Image1.ImageUrl = HttpUtility.HtmlEncode(dbProfilePic);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                //Modify the row in the sql database such that the status is accepted
                String query = "UPDATE [Friendship] SET [Seen] = @seen, [Status] = @status WHERE [User2_Email] = @email";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@seen", "true");
                myCommand.Parameters.AddWithValue("@status", "Accepted");
                myCommand.Parameters.AddWithValue("@email", Session["email"].ToString());
                myCommand.ExecuteNonQuery();

                SqlCommand myCommand1 = new SqlCommand(query, myConnection);
                myCommand1.CommandType = CommandType.Text;
                myCommand1.Parameters.AddWithValue("@seen", "true");
                myCommand1.Parameters.AddWithValue("@status", "Accepted");
                myCommand1.Parameters.AddWithValue("@email", dbEmail);
                myCommand1.ExecuteNonQuery();
            }

            Response.Redirect("/Notification.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                //Modify the row in the sql database such that the status is declined
                String query2 = "UPDATE [Friendship] SET [Seen] = @seen, [Status] = @status WHERE [User2_Email] = @email";

                SqlCommand myCommand2 = new SqlCommand(query2, myConnection2);
                myConnection2.Open();
                myCommand2.CommandType = CommandType.Text;
                myCommand2.Parameters.AddWithValue("@seen", "true");
                myCommand2.Parameters.AddWithValue("@status", "Declined");
                myCommand2.Parameters.AddWithValue("@email", Session["email"].ToString());

                myCommand2.ExecuteNonQuery();

                SqlCommand myCommand1 = new SqlCommand(query2, myConnection2);
                myCommand1.CommandType = CommandType.Text;
                myCommand1.Parameters.AddWithValue("@seen", "true");
                myCommand1.Parameters.AddWithValue("@status", "Accepted");
                myCommand1.Parameters.AddWithValue("@email", dbEmail);
                myCommand1.ExecuteNonQuery();
            }

            Response.Redirect("/Notification.aspx");
        }
    }
}