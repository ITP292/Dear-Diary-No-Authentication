using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Dear_Diary.Friends
{
    public partial class viewFriend : System.Web.UI.Page
    {
        String dbUser1Email;
        String dbUser2Email;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String query = "SELECT * FROM [Friendship] WHERE [User1_Email] = @email || [User2_Email] = @email";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;

                SqlDataReader reader = myCommand.ExecuteReader();
                SqlDataAdapter sda = new SqlDataAdapter(myCommand);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                rptTable.DataSource = ds;
                rptTable.DataBind();

                if (reader.Read())
                {
                    dbUser1Email = reader["User1_Email"].ToString();
                    dbUser2Email = reader["User2_Email"].ToString();

                }

                Response.Redirect("addFriendRedir");
            }
        }
    }
}