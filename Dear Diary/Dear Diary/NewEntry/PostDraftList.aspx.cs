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
    public partial class PostDraftList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptPostList.DataSource = GetPostDetails(0);
            rptPostList.DataBind();
        }

        public DataTable GetPostDetails(int IsPosted)
        {
            DataTable dt = new DataTable();
            String query = "SELECT * FROM [Post] WHERE [IsPostEntry] = @isposted";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@isposted", IsPosted);
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                da.Fill(dt);

                return dt;
            }
        }
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