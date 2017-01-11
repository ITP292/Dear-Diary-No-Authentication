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
    public partial class viewFriendRedir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Use global variable from previous page and modify the header and textbox
            String friendemail = viewFriend.FriendEmail;

            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String query = "SELECT * FROM [User] WHERE Email_Address = @email";
                String dbEmail = "";
                String dbFName = "";
                String dbLName = "";
                String Name = "";

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
                    Name = dbFName + " " + dbLName;
                }

                Header.Text = Name;
                FriendEmail.Text = dbEmail;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewFriend.aspx");
        }
    }
}