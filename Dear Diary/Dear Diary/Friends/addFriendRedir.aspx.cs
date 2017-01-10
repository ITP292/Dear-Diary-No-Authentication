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
    public partial class addFriendRedir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FriendEmail.Text = addFriend.dbEmail;
            Header.Text = addFriend.Name;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                //String UserEmail = Session["email"].ToString();
                String UserEmail = "lrh@gmail.com";
                DateTime today = DateTime.Today;
                String Date = today.ToString("dd/MM/yyyy");
                String query = "INSERT INTO Friendship VALUES (@UserEmail, @FriendEmail, @Date, @Status, @Read)";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@UserEmail", UserEmail);
                myCommand.Parameters.AddWithValue("@FriendEmail", FriendEmail.Text);
                myCommand.Parameters.AddWithValue("@Date", Date);
                myCommand.Parameters.AddWithValue("@Status", "Pending");
                myCommand.Parameters.AddWithValue("@Read", "false");
                myCommand.ExecuteNonQuery();

                Response.Redirect("addFriend.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addFriend.aspx");
        }
    }
}