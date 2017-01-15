using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace Dear_Diary
{
    public partial class Notification : System.Web.UI.Page
    {
        private ArrayList cList = new ArrayList();
        private ArrayList pList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            makeList(retrieveFriends());
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
            makeList(retrieveFriends());
        }

        protected void makeList(ArrayList s)
        {
            //Remove existing list on the page and replace it with the new one
            tabs.Controls.Clear();
            foreach (var item in s)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                tabs.Controls.Add(li);
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "#");
                //anchor.InnerText = item.ToString();
                anchor.InnerText = Server.HtmlEncode(item.ToString());
                li.Controls.Add(anchor);
            }
            //Things that need to be solved, count the number of notifications pulled from the database and use that number
            //to make the list.
        }

        protected ArrayList retrieveFriends()
        {
            try
            {
                //fList stores information retrieved from Friends table
                ArrayList fList = new ArrayList();
                using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String User2_Email;
                    //String User1_Email = Session["email"].ToString();
                    String User1_Email = "lrh@gmail.com";
                    String query = "SELECT * FROM Friendship WHERE Seen = @seen AND User1_Email = @user1email";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@seen", "false");
                    myCommand.Parameters.AddWithValue("@user1email", User1_Email);

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        User2_Email = reader["User2_Email"].ToString();
                        fList.Add(User2_Email + " wants to add you as a friend!");
                    }
                    return fList;
                }
            }
            catch (Exception)
            {
                Label3.Text = "Database Error";
            }
            return null;
        }
    }
}