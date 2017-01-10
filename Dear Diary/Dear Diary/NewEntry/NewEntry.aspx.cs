using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
            if (Page.IsPostBack != true)
            {

                img.Visible = false;

                if (Request.QueryString.AllKeys.Contains("Post_Id"))
                {
                    var post_Id = Request.QueryString["Post_Id"].ToString();

                    if (post_Id != "")
                    {
                        DataTable dt = GetPostDetailsbyId(Convert.ToInt16(post_Id));

                        hdPostId.Value = post_Id;

                        foreach (DataRow item in dt.Rows)
                        {
                            ta.Value = item["Post_Text"].ToString();
                            img.ImageUrl = item["Picture"].ToString() == "" ? "~/Pictures/" + "default-thumbnail.jpg" : item["Picture"].ToString();
                            img.Visible = true;
                            Session["imagePath"] = item["Picture"].ToString() == "" ? "~/Pictures/" + "default-thumbnail.jpg" : item["Picture"].ToString();
                        }
                    }
                }
                else
                {
                    hdPostId.Value = "";
                    Session["imagePath"] = "";
                }
            }
        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            var loginEmail = "abc@gmail.com";
            var post_text = ta.Value;

            if (hdPostId.Value != "")
            {
                UpdatePost(Convert.ToInt16(hdPostId.Value), post_text, Session["imagePath"].ToString(), ddlSetting.SelectedValue, false);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post update successfully.');", true);
            }
            else
            {
                SavePost(loginEmail, post_text, Session["imagePath"].ToString(), ddlSetting.SelectedValue, false);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post save as draft successfully.');", true);
            }

            ta.Value = "Dear Diary, ";
            hdPostId.Value = "";
            Session["imagePath"] = "";
            img.Visible = false;
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            var loginEmail = "abc@gmail.com";
            var post_text = ta.Value;

            if (hdPostId.Value != "")
                UpdatePost(Convert.ToInt16(hdPostId.Value), post_text, Session["imagePath"].ToString(), ddlSetting.SelectedValue, true);
            else
                SavePost(loginEmail, post_text, Session["imagePath"].ToString(), ddlSetting.SelectedValue, true);

            ta.Value = "Dear Diary, ";
            hdPostId.Value = "";
            Session["imagePath"] = "";
            img.Visible = false;

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post save successfully.');", true);
        }

        protected void btnDraftList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewEntry/PostDraftList.aspx");
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Pictures/") + fileName);
                Session["imagePath"] = "~/Pictures/" + fileName;
                img.ImageUrl = "~/Pictures/" + fileName;
                img.Visible = true;
            }
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

                myCommand.Parameters.AddWithValue("@Author_Email", loginEmail);
                myCommand.Parameters.AddWithValue("@Date_Added", DateTime.Now.ToString());
                myCommand.Parameters.AddWithValue("@Picture", picture);
                myCommand.Parameters.AddWithValue("@Post_Text", post_text);
                myCommand.Parameters.AddWithValue("@Permission_Status", permissionStatus);
                myCommand.Parameters.AddWithValue("@IsPostEntry", isPostEntry);

                myCommand.ExecuteNonQuery();
            }
        }

        public void UpdatePost(int Post_Id, string post_text, string picture, string permissionStatus, bool isPostEntry)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                var qPicture= "";

                if (picture != "")
                    qPicture = ", Picture=@Picture";

                string query = "UPDATE [dbo].[Post] SET Date_Added=@Date_Added" + qPicture + " ,Post_Text=@Post_Text, Permission_Status=@Permission_Status, IsPostEntry=@IsPostEntry where Post_Id = " + Post_Id;
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@Date_Added", DateTime.Now.ToString());

                if (picture != "")
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

        public DataTable GetPostDetailsbyId(int post_Id)
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [Post_Id] = " + post_Id;

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