using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dear_Diary.Security_API;

namespace Dear_Diary.NewEntry
{
    public partial class PostDraftList : System.Web.UI.Page
    {
        /// <summary>
        /// page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //get all post which has save as draft
            rptPostList.DataSource = GetPostDetails(0);
            rptPostList.DataBind();
        }

        /// <summary>
        /// this is for get post details function , its call from page load
        /// </summary>
        /// <param name="IsPosted"></param>
        /// <returns></returns>
        public DataTable GetPostDetails(int IsPosted)
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = @isposted";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String encrypted_post;
                String plain_post;

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@isposted", IsPosted);
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

        /// <summary>
        /// this is call when click on delete link on draft list page (for delete post entry)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPostList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var id = e.CommandArgument.ToString();
                String query = "Delete FROM [Post] WHERE [Post_Id] = @id";

                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@id", id);
                    myCommand.ExecuteNonQuery();
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post deleted successfully.');", true);

                rptPostList.DataSource = GetPostDetails(0);
                rptPostList.DataBind();
            }
        }
    }
}