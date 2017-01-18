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

//Author: Aidil Irfan (153297Z)
namespace Dear_Diary
{
    public partial class Notification : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            makeFriendList(retrieveFriends());
            makePostList(retrievePost());
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
            makeFriendList(retrieveFriends());
            makePostList(retrievePost());
        }

        protected void makeFriendList(ArrayList s)
        {
            //Remove existing list on the page and replace it with the new one
            tabs.Controls.Clear();
            foreach (var item in s)
            {
                //Check if fList return null
                if (!item.Equals(null))
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    tabs.Controls.Add(li);
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "/Friends/requestFriend.aspx?User2Email=" + item.ToString());
                    anchor.InnerText = Server.HtmlEncode(item.ToString() + " wants to be your friend");
                    li.Controls.Add(anchor);
                }
                else
                {
                    //If fList is null, don't do anything
                }
            }
        }

        protected void makePostList(ArrayList s)
        {
            foreach (var item in s)
            {
                //Check if pList returned null
                if (!item.Equals(null))
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    tabs.Controls.Add(li);
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "#");
                    anchor.InnerText = Server.HtmlEncode(item.ToString() + " just made a post!");
                    li.Controls.Add(anchor);
                }
                else
                {
                    //If pList is null, don't do anything
                }
            }
        }

        protected ArrayList retrieveFriends()
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
                        fList.Add(User2_Email);
                        //fList.Add(User2_Email + " wants to add you as a friend!");
                    }
                    return fList;
                }
        }

        protected ArrayList retrievePost()
        {
            //pList stores information retrieved from Post table
            ArrayList pList = new ArrayList();
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String author;
                String query = "SELECT * FROM Post WHERE Seen = @seen";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@seen", "false");

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    author = reader["Author_Email"].ToString();
                    pList.Add(author);
                }
                return pList;
            }
        }
    }
}