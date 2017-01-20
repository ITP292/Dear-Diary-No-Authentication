using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Dear_Diary.Profile
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static String dbEmail = "";
        public static String dbProfilePic = "";
        public static String Name = "";
        public static String email = "stupid@idiot.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["email"].ToString();

            String email = "stupid@idiot.com";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String dbFName;
                String dbLName;
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


                //{
                    //String email2 = Session["email"].ToString();

                    String email2 = "stupid@idiot.com";
                    String dbUser2Email;

                    String query2 = "SELECT [User2_Email] FROM [Friendship] WHERE [User1_Email] = @email";
                    SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                    myConnection.Open();
                    myCommand2.CommandType = CommandType.Text;
                    myCommand2.Parameters.AddWithValue("@email", email2);

                    SqlDataReader reader2 = myCommand2.ExecuteReader();

                    if (reader2.Read())
                    {
                        dbUser2Email = reader2["User2_Email"].ToString();


                    }
                    myConnection.Close();

                    //{
                        //String email2 = Session["email"].ToString();

                        String permission = "";
                        String dbPostText = "";

                        String query3 = "SELECT [Post_Text], [Permission_Status] FROM [Post] WHERE [Author_Email] = @email";
                        //AND[Permission] = @permission
                        SqlCommand myCommand3 = new SqlCommand(query3, myConnection);

                        myConnection.Open();
                        myCommand3.CommandType = CommandType.Text;
                        myCommand3.Parameters.AddWithValue("@email", email2);
                        //myCommand3.Parameters.AddWithValue("@permission", "public");

                        SqlDataReader reader3 = myCommand3.ExecuteReader();

                        if (reader3.Read())
                        {
                            permission = reader3["Permission_Status"].ToString();
                            dbPostText = reader3["Post_Text"].ToString();
                            if (permission.Equals("public"))
                            {
                                TextBox1.Text = dbPostText;
                            }
                            else if (!permission.Equals("public"))
                            {
                                Label1.Text = "No posts available";
                            }
                        }

                        myConnection.Close();
                    }
                //}
            }
        protected void noOfPosts_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/NewEntry/PostEntryList.aspx");
        }

        protected void noOfFriends_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Friends/viewFriend.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }

}
