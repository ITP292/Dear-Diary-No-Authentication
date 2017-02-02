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
        public static String email = "stupid@idiot.com";

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
                // var loginEmail = Session["email"] != null ? Session["email"].ToString() : "stupid@idiot.com";

                //String email = "stupid@idiot.com";

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

                    //String email2 = "stupid@idiot.com";
                    String dbUser2Email;

                    String query2 = "SELECT [User2_Email] FROM [Friendship] WHERE [User1_Email] = @email";
                    SqlCommand myCommand2 = new SqlCommand(query2, myConnection);
                    myConnection.Open();
                    myCommand2.CommandType = CommandType.Text;
                    myCommand2.Parameters.AddWithValue("@email", email);

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
                    myCommand3.Parameters.AddWithValue("@email", email);
                    //myCommand3.Parameters.AddWithValue("@permission", "public");

                    SqlDataReader reader3 = myCommand3.ExecuteReader();
                    /*
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
                            */
                    myConnection.Close();
                }
                //}
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        public DataTable GetPostDetails(int IsPosted, string loginEmail)
        {
            String permission = "";
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = " + IsPosted + " and Author_Email = '" + loginEmail + "' AND Permission_Status = @Permission ";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String encrypted_post;
                String plain_post;

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@Permission", "public");
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    encrypted_post = row[4].ToString();
                    plain_post = AES.Decrypt(encrypted_post);
                    row.SetField(4, plain_post);
                }

                return dt;
            }
        }


        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var id = e.CommandArgument.ToString();
                string query = "Delete FROM [Comment] WHERE [Post_Id] = " + id;
                var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                }

                string query1 = "Delete FROM [Post] WHERE [Post_Id] = " + id;

                SqlConnection myConnection1;
                using (myConnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection1);
                    myConnection1.Open();
                    myCommand1.CommandType = CommandType.Text;
                    myCommand1.ExecuteNonQuery();
                }

                Repeater1.DataSource = GetPostDetails(1, loginEmail);
                Repeater1.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post Entry deleted successfully.');", true);
            }
        }
    }

}
