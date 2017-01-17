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
    public partial class PostDetails : System.Web.UI.Page
    {
        /// <summary>
        /// page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack != true)
            {
                // this is check any query string available for not
                // if query string availble then get post_id from query string and get data using post-id and fill in form
                if (Request.QueryString.AllKeys.Contains("Post_Id"))
                {
                    var post_Id = Request.QueryString["Post_Id"].ToString();

                    if (post_Id != "")
                    {
                        DataTable dt = GetPostDetailsbyId(Convert.ToInt16(post_Id));

                        foreach (DataRow item in dt.Rows)
                        {
                            ta.InnerHtml = item["Post_Text"].ToString();
                            img.ImageUrl = item["Picture"].ToString() == "" ? "~/Pictures/" + "default-thumbnail.jpg" : item["Picture"].ToString();
                            lblPostBy.Text = item["Post_By"].ToString();
                            lblPermission.Text = item["Permission_Status"].ToString();
                            lblPostOn.Text = Convert.ToDateTime(item["Date_Added"]).ToString("dd MMM yyyy");
                        }

                        rptCommentList.DataSource = GetCommentDetailsbyPostId(Convert.ToInt16(post_Id));
                        rptCommentList.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// this is for post commnet (insert comment) on specific post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPost_Click(object sender, EventArgs e)
        {
            var post_Id = Request.QueryString["Post_Id"].ToString();
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";

            if (txtComment.Value != "")
            {
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    myConnection.Open();

                    string query = "INSERT INTO [dbo].[Comment](Post_Id, Author_Email, Comment_Text ,Date_Added)";
                    query += " VALUES (@Post_Id, @Author_Email, @Comment_Text, @Date_Added)";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);

                    myCommand.Parameters.AddWithValue("@Post_Id", post_Id);
                    myCommand.Parameters.AddWithValue("@Author_Email", loginEmail);
                    myCommand.Parameters.AddWithValue("@Comment_Text", txtComment.Value);
                    myCommand.Parameters.AddWithValue("@Date_Added", DateTime.Now.Date);
                    myCommand.ExecuteNonQuery();

                    rptCommentList.DataSource = GetCommentDetailsbyPostId(Convert.ToInt16(post_Id));
                    rptCommentList.DataBind();

                    txtComment.Value = "";
                }
            }
        }

        protected void rptCommentList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


        /// <summary>
        /// this is for delete specific comment from the post
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnDelete(object sender, EventArgs e)
        {
            var post_Id = Request.QueryString["Post_Id"].ToString();

            RepeaterItem item = (sender as ImageButton).Parent as RepeaterItem;
            int Comment_Id = int.Parse((item.FindControl("lblComment_Id") as Label).Text);

            String query = "Delete FROM [Comment] WHERE [Comment_Id] = " + Comment_Id;

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.ExecuteNonQuery();
            }

            rptCommentList.DataSource = GetCommentDetailsbyPostId(Convert.ToInt16(post_Id));
            rptCommentList.DataBind();
        }

        /// <summary>
        /// this is for get post details using post_id
        /// </summary>
        /// <param name="post_Id"></param>
        /// <returns></returns>
        public DataTable GetPostDetailsbyId(int post_Id)
        {
            DataTable dt = new DataTable();
            String query = "SELECT p.*, u.FName + ' ' + u.LName as Post_By FROM [Post] p inner join [User] u on p.Author_Email = u.Email_Address WHERE [Post_Id] = " + post_Id;

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
        /// this is for get all comments details for specific post using post_id
        /// </summary>
        /// <param name="post_Id"></param>
        /// <returns></returns>
        public DataTable GetCommentDetailsbyPostId(int post_Id)
        {
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";

            DataTable dt = new DataTable();
            String query = " SELECT c.Comment_id, c.Post_id, c.Author_Email, c.Comment_Text, c.Date_Added, u.FName, u.LName, u.FName + ' ' + u.LName as Comment_By, case c.Author_Email when '" + loginEmail + "' then 'true' else 'false' end as isMyComment FROM [Comment] c inner join [User] u on c.Author_Email = u.Email_Address WHERE [Post_Id] = " + post_Id;

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