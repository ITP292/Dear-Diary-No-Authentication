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
    public partial class MainPage : System.Web.UI.Page
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // if session (login user session) not found then bedefault put 'test123@gmail.com'
            var loginEmail = Session["email"] != null ? Session["email"].ToString() : "test123@gmail.com";

            //get data from database and assign to repeater control
            rptPostList.DataSource = GetPostDetails(1, loginEmail);
            rptPostList.DataBind();
        }


        /// <summary>
        /// this is for get Post Details using email id (login users email id)
        /// </summary>
        /// <param name="IsPosted"></param>
        /// <param name="loginEmail"></param>
        /// <returns></returns>
        public DataTable GetPostDetails(int IsPosted, string loginEmail)
        {
            //get data from databse
            DataTable dt = new DataTable();
            String query = "SELECT p.*, u.FName + ' ' + u.LName as Post_By FROM [Post] p inner join [User] u on p.Author_Email = u.Email_Address WHERE p.IsPostEntry = " + IsPosted + " and (p.Permission_Status = 'Public' or Author_Email = '" + loginEmail + "' ) order by p.Post_Id Desc ";

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
        /// this is for more details button , when click on it then redirect to post details page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMoreDetails_Click(object sender, CommandEventArgs e)
        {
            var post_Id = e.CommandArgument.ToString();
            Response.Redirect("PostDetails.aspx?Post_Id=" + post_Id);
        }
    }
}