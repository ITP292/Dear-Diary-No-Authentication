using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dear_Diary.Security_API;

namespace Dear_Diary.Profile
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var loginEmail = Session["email"] != null ? Session["email"].ToString() : "stupid@idiot.com";
            //string loginEmail = "stupid@idiot.com";
            
            if (Session["email"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                String loginEmail = Session["email"].ToString();
                Repeater1.DataSource = GetPostDetails(1, loginEmail);
                Repeater1.DataBind();
            }
        }

        // to get post details
        public DataTable GetPostDetails(int IsPosted, string loginEmail)
        {
            String FriendEmail = "";

            using (SqlConnection myConnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String query1 = "SELECT * FROM [Friendship] Where [User1_Email] = @email";

                SqlCommand myCommand1 = new SqlCommand(query1, myConnection1);
                myConnection1.Open();
                myCommand1.CommandType = CommandType.Text;
                myCommand1.Parameters.AddWithValue("@email", loginEmail);

                SqlDataReader reader = myCommand1.ExecuteReader();

                if (reader.Read())
                {
                   FriendEmail = reader["User2_Email"].ToString();
                }
            }

            
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String encrypted_post;
                String plain_post;
                DataTable dt = new DataTable();
                String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = @posted AND [Author_Email] = @email AND Permission_Status = @Permission";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@Permission", "Public");
                myCommand.Parameters.AddWithValue("@email", FriendEmail);
                myCommand.Parameters.AddWithValue("@posted", 1);
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