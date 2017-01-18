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
        /// <summary>
        /// page load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                img.Visible = false;

                //check any query string available or not, 
                //if query string available then get id from query string and fill data and load page
                //other wise display blank form 

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


        /// <summary>
        /// for click of draft button , data will save or update in draft mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDraft_Click(object sender, EventArgs e)
        {
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";
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

        /// <summary>
        /// For post button -> click for i'm done button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPost_Click(object sender, EventArgs e)
        {
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";
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


        /// <summary>
        /// its work when click on draft list button, when click on it then redirect it to draft list page and 
        /// display all draft list of post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDraftList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewEntry/PostDraftList.aspx");
        }

        /// <summary>
        /// this is for upload images
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// this is function for save post, its call from above code
        /// </summary>
        /// <param name="loginEmail"></param>
        /// <param name="post_text"></param>
        /// <param name="picture"></param>
        /// <param name="permissionStatus"></param>
        /// <param name="isPostEntry"></param>
        public void SavePost(string loginEmail, string post_text, string picture, string permissionStatus, bool isPostEntry)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "INSERT INTO [dbo].[Post](Author_Email, Date_Added, Picture, Post_Text, Permission_Status, IsPostEntry, Seen)";
                query += " VALUES (@Author_Email, @Date_Added, @Picture, @Post_Text, @Permission_Status, @IsPostEntry, @seen)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@Author_Email", loginEmail);
                myCommand.Parameters.AddWithValue("@Date_Added", DateTime.Now.Date);
                myCommand.Parameters.AddWithValue("@Picture", picture);
                myCommand.Parameters.AddWithValue("@Post_Text", post_text);
                myCommand.Parameters.AddWithValue("@Permission_Status", permissionStatus);
                myCommand.Parameters.AddWithValue("@IsPostEntry", isPostEntry);
                myCommand.Parameters.AddWithValue("@seen", "false");

                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// this is update post from , this is call from others
        /// </summary>
        /// <param name="Post_Id"></param>
        /// <param name="post_text"></param>
        /// <param name="picture"></param>
        /// <param name="permissionStatus"></param>
        /// <param name="isPostEntry"></param>
        public void UpdatePost(int Post_Id, string post_text, string picture, string permissionStatus, bool isPostEntry)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                var qPicture = "";

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

        /// <summary>
        /// IsPostEntry = 1 then its post entry and IsPostEntry = 0 means this is draft entry
        /// this is for get post details using its post entry or not
        /// </summary>
        /// <param name="IsPosted"></param>
        /// <returns></returns>
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

        /// <summary>
        /// get post details using post_id
        /// </summary>
        /// <param name="post_Id"></param>
        /// <returns></returns>
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