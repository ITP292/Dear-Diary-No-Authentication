using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.NewEntry
{
    public partial class NewEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tblDraft_Click(object sender, EventArgs e)
        {
            var loginEmail = "abc@gmail.com";
            var post_text = ta.Value;
            SavePost(loginEmail, post_text, "", ddlSetting.SelectedValue, false);
            ta.Value = "Dear Diary, ";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post save as draft successfully.');", true);
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            var loginEmail = "abc@gmail.com";
            var post_text = ta.Value;
            SavePost(loginEmail, post_text, "", ddlSetting.SelectedValue, true);
            ta.Value = "Dear Diary, ";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post save successfully.');", true);
        }

        protected void btnDraftList_Click(object sender, EventArgs e)
        {
            DataTable dt = GetPostDetails(false);
        }

        protected void ddlSetting_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SavePost(string loginEmail, string post_text, string picture, string permissionStatus, bool isPostEntry)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "INSERT INTO [dbo].[Post](Author_Email, Date_Added, Picture, Post_Text, Permission_Status, IsPostEntry)";
                query += " VALUES (@Author_Email, @Date_Added, @Picture, @Post_Text, @Permission_Status, @IsPostEntry)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                //To prevent sql injection
                myCommand.Parameters.AddWithValue("@Author_Email", loginEmail);
                myCommand.Parameters.AddWithValue("@Date_Added", DateTime.Now.ToString());
                myCommand.Parameters.AddWithValue("@Picture", picture);
                myCommand.Parameters.AddWithValue("@Post_Text", post_text);
                myCommand.Parameters.AddWithValue("@Permission_Status", permissionStatus);
                myCommand.Parameters.AddWithValue("@IsPostEntry", isPostEntry);

                myCommand.ExecuteNonQuery();
            }
        }

        public DataTable GetPostDetails(bool IsPosted)
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = " + IsPosted;

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(dt);

                return dt;
            }
        }
    }
}