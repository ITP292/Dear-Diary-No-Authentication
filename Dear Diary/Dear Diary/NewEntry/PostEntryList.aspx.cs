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
    public partial class PostEntryList : System.Web.UI.Page
    {
        /// <summary>
        /// page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check login user session, if not found then set test login 'test123@gmail.com'
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "stupid@idiot.com";
            rptPostEntryList.DataSource = GetPostDetails(1, loginEmail);
            rptPostEntryList.DataBind();

            //String encrypted_post = lblpostEntrytext.Text;
            //String plain_post = AES.Decrypt(encrypted_post);
            //lblpostEntrytext.Text = plain_post;
        }

        /// <summary>
        /// this is for get post entry for login user , this is call from page load event
        /// </summary>
        /// <param name="IsPosted"></param>
        /// <param name="loginEmail"></param>
        /// <returns></returns>
        public DataTable GetPostDetails(int IsPosted, string loginEmail)
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = " + IsPosted + " and Author_Email = '" + loginEmail + "' ";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String encrypted_post;
                String plain_post;

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
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
        /// this is call when click on delete link on page for delete specific post entry
        /// this is First delete all comments related to post and then after delete post
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPostEntryList_ItemCommand(object source, RepeaterCommandEventArgs e)
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

                rptPostEntryList.DataSource = GetPostDetails(1, loginEmail);
                rptPostEntryList.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post Entry deleted successfully.');", true);
            }
        }

        /// <summary>
        /// this is for search, search using pasific keyword 
        /// IsPostEntry = 1 means its post entry and IsPostEntry = 0 means its save as draft entry
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void btnSearchPostEntry_Click(object source, EventArgs e)
        {
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";
            DataTable dt = new DataTable();
            
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String encrypted_post;
                String plain_post;

                String encrypted_search = AES.Encrypt(txtSearchPostEntry.Text);

                String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = 1 and Author_Email = '" + loginEmail + "' and Post_Text like '%" + encrypted_search + "%'";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    encrypted_post = row[4].ToString();
                    plain_post = AES.Decrypt(encrypted_post);
                    row.SetField(4, plain_post);
                }

                rptPostEntryList.DataSource = dt;
                rptPostEntryList.DataBind();
            }
        }
    }
}