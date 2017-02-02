using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Net;

namespace Dear_Diary.Friends
{
    public partial class addFriendRedir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                FriendEmail.Text = WebUtility.HtmlEncode(addFriend.dbEmail);
                Header.Text = WebUtility.HtmlEncode(addFriend.Name);
                Image1.ImageUrl = WebUtility.HtmlEncode(addFriend.dbProfilePic);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String UserEmail = Session["email"].ToString();
                //String UserEmail = "lrh@gmail.com";
                DateTime today = DateTime.Today;
                String Date = today.ToString("dd/MM/yyyy");
                String query = "SELECT * FROM Friendship WHERE User2_Email = @FriendEMail";
                String dbEmail = "";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@FriendEmail", FriendEmail.Text);

                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.Read())
                {
                    dbEmail = reader["User2_Email"].ToString();
                }
                reader.Close();

                if (FriendEmail.Text.Equals(dbEmail))
                {
                    Response.Redirect("error.aspx");
                }
                else
                {
                    String query1 = "INSERT INTO Friendship VALUES (@UserEmail, @FriendEmail, @Date, @Status, @Read)";

                    SqlCommand myCommand1 = new SqlCommand(query1, myConnection);
                    //myConnection.Open();
                    myCommand1.CommandType = CommandType.Text;
                    myCommand1.Parameters.AddWithValue("@UserEmail", UserEmail);
                    myCommand1.Parameters.AddWithValue("@FriendEmail", FriendEmail.Text);
                    myCommand1.Parameters.AddWithValue("@Date", Date);
                    myCommand1.Parameters.AddWithValue("@Status", "Pending");
                    myCommand1.Parameters.AddWithValue("@Read", "false");
                    myCommand1.ExecuteNonQuery();
                    //myConnection.Close();

                    Response.Redirect("addFriend.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addFriend.aspx");
        }
    }
}