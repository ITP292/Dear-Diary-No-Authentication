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

namespace Dear_Diary.Profile
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static String dbEmail = "";
        public static String dbProfilePic = "";
        public static String Name = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            // store session
            if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                string email = Session["email"].ToString();

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String dbFName;
                    String dbLName;

                    // retrieving user information on page load.
                    // Error handling; checks if session is null before executing query.
                    String query = "SELECT [FName], [LName], [Email_Address], [displayPic] FROM [User] WHERE [Email_Address] = @email";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);

                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@email", email);

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        dbEmail = reader["Email_Address"].ToString();
                        dbFName = reader["FName"].ToString();
                        dbLName = reader["LName"].ToString();
                        dbProfilePic = reader["displayPic"].ToString();
                        Name = dbFName + " " + dbLName;
                    }

                    Image1.ImageUrl = dbProfilePic;
                    userName.Text = Name;
                    userEmail.Text = "(" + dbEmail + ")";

                    myConnection.Close();

                    // counting friends, based on accept/deny status

                    String dbUser2Email;
                    String status = "Accepted";

                    String query2 = "SELECT COUNT(*) [User2_Email] FROM [Friendship] WHERE [User1_Email] = @email AND [Status] = @status";
                    SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                    myConnection.Open();
                    myCommand2.CommandType = CommandType.Text;
                    myCommand2.Parameters.AddWithValue("@email", email);
                    myCommand2.Parameters.AddWithValue("@status", status);

                    // count returns number of friends.
                    int countFriends = Convert.ToInt32(myCommand2.ExecuteScalar());
                    SqlDataReader reader2 = myCommand2.ExecuteReader();

                    if (countFriends > 0)
                    {
                        lblFriendsCount.Text = countFriends.ToString();
                    }

                    else
                    {
                        lblFriendsCount.Text = "None";
                    }
                    if (reader2.Read())
                    {
                        dbUser2Email = reader2["User2_Email"].ToString();

                    }


                    myConnection.Close();
                    // ends here

                    // counting amount of posts posted by user.
                    String query3 = "SELECT COUNT(Post_Id) FROM [Post] WHERE [Author_Email] = @email";

                    SqlCommand myCommand3 = new SqlCommand(query3, myConnection);
                    myConnection.Open();
                    Int32 countPosts = Convert.ToInt32(myCommand2.ExecuteScalar());
                    myCommand3.CommandType = CommandType.Text;
                    myCommand3.Parameters.AddWithValue("@email", email);
                    //myCommand3.Parameters.AddWithValue("@permission", "public");


                    if (countPosts > 0)
                    {
                        lblPostsCount.Text = countPosts.ToString();
                    }
                    else
                    {
                        lblPostsCount.Text = "None";
                    }
                        myConnection.Close();
                    }

                }
            }
        protected void noOfPosts_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/NewEntry/PostEntryList.aspx");
        }

        protected void noOfFriends_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Friends/viewFriend.aspx");
        }

        protected void newsFeed_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Profile/NewsFeed.aspx");
        }

    }
}


