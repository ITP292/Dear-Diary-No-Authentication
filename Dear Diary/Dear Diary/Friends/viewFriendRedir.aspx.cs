using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace Dear_Diary.Friends
{
    public partial class viewFriendRedir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"].ToString().Equals(""))
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                //Use global variable from previous page and modify the header and textbox
                String friendemail = WebUtility.HtmlEncode(viewFriend.FriendEmail);

                using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String query = "SELECT * FROM [User] WHERE Email_Address = @email";
                    String dbEmail = "";
                    String dbFName = "";
                    String dbLName = "";
                    String Name = "";
                    String dbProfilePic = "";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@email", friendemail);

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
            Response.Redirect("viewFriend.aspx");
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            //Use global variable from previous page and modify the header and textbox
            String friendemail = WebUtility.HtmlEncode(viewFriend.FriendEmail);

            using (SqlConnection myConnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String query1 = "DELETE FROM [Friendship] WHERE User2_Email = @email";

                SqlCommand myCommand1 = new SqlCommand(query1, myConnection1);
                myConnection1.Open();
                myCommand1.CommandType = CommandType.Text;
                myCommand1.Parameters.AddWithValue("@email", friendemail);
                myCommand1.ExecuteNonQuery();
            }

            Response.Redirect("viewFriend.aspx");
        }
    }
}