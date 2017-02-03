using Dear_Diary.Security_API;
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
    public partial class PostEntryRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptPostEntryList.DataSource = getPostRedir();
            rptPostEntryList.DataBind();
        }
        protected DataTable getPostRedir()
        {
            DataTable dt = new DataTable();
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String q = Request.QueryString["Post_Id"];
                String encrypted_post;
                String plain_post;
                String query = "SELECT * FROM Post WHERE Post_Id = @post_id";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = System.Data.CommandType.Text;
                myCommand.Parameters.AddWithValue("@post_id", q);

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

                rptPostEntryList.DataSource = getPostRedir();
                rptPostEntryList.DataBind();

                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Post Entry deleted successfully.');", true);
            }
        }
    }
}