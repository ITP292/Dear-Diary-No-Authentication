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
                userName.Text =  Name;
                userEmail.Text = "(" + dbEmail + ")";
                
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
    }

}
