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

// Author: Aidil Irfan (153297Z)
// Constraints: Notifications are not ordered in order of date and time. This is due to the method used to perform the function [Polling].
namespace Dear_Diary
{
    public partial class Notification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            methodMain();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
            methodMain();
        }

        //This is the method that calls all the other method for the Notification page to function
        protected void methodMain()
        {
            makeFriendList(retrieveFriends());
            ArrayList acceptedFriends = checkFriends();
            ArrayList postList = checkPost();
            if(!acceptedFriends.Contains(null))
            {
                makePostList(retrievePost(acceptedFriends));
            }
            else
            {
                //Do nothing
            }

            if (!postList.Contains(null))
            {
                makeCommentList(retrieveComments(postList));
            }
            else
            {
                //Do nothing
            }
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
                    string[] a = item.ToString().Split('|');
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    tabs.Controls.Add(li);
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "/NewEntry/PostEntryList.aspx?Author_Email=" + a[0]);
                    anchor.InnerText = Server.HtmlEncode(a[1] + " just made a post!");
                    li.Controls.Add(anchor);
                }
                else
                {
                    //If pList is null, don't do anything
                }
            }
        }

        protected void makeCommentList(ArrayList s)
        {
            foreach (var item in s)
            {
                //Check if cList returned null
                if (!item.Equals(null))
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    tabs.Controls.Add(li);
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "/NewEntry/PostEntryList.aspx?Comment_Id=" + item.ToString());
                    anchor.InnerText = Server.HtmlEncode("Someone made a comment on your post!");
                    li.Controls.Add(anchor);
                }
                else
                {
                    //If cList is null, don't do anything
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
                    String User1_Email = Session["email"].ToString();
                    //String User1_Email = "lrh@gmail.com";
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

        protected ArrayList retrievePost(ArrayList s)
        {
            //pList stores the information retrieved from Post table
            ArrayList pList = new ArrayList();
            foreach (var item in s)
            {
                using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String author;
                    String postID;
                    String query = "SELECT * FROM Post WHERE Seen = @seen AND Author_Email = @author_email AND Permission_Status = @permission";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@seen", "false");
                    myCommand.Parameters.AddWithValue("@author_email", item.ToString());
                    myCommand.Parameters.AddWithValue("@permission", "Public");

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        postID = reader["Post_ID"].ToString();
                        author = reader["Author_Email"].ToString();
                        pList.Add(postID + '|' + author);
                    }
                }
            }
            return pList;
        }

        protected ArrayList retrieveComments(ArrayList s)
        {
            //cList stores the information retrieved from Comment table
            ArrayList cList = new ArrayList();
            foreach (var item in s)
            {
                using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String commentID;
                    String query = "SELECT * FROM Comment WHERE Seen = @seen AND Post_Id = @post_id";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@seen", "false");
                    myCommand.Parameters.AddWithValue("@post_id", item.ToString());

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        commentID = reader["Comment_Id"].ToString();
                        cList.Add(commentID);
                    }
                }
            }
            return cList;
        }

        protected ArrayList checkFriends()
        {
            //fList stores information retrieved from Friends table
            ArrayList fList = new ArrayList();
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String User2_Email;
                String User1_Email = Session["email"].ToString();
                //String User1_Email = "lrh@gmail.com";
                String query = "SELECT * FROM Friendship WHERE User1_Email = @user1email AND status = @status";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@user1email", User1_Email);
                myCommand.Parameters.AddWithValue("@status", "Accepted");

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

        protected ArrayList checkPost()
        {
            //store information from Post table
            ArrayList pList = new ArrayList();
            using(SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                int postID;
                String User1_Email = Session["email"].ToString();
                String query = "SELECT * FROM Post where Author_Email = @author_email AND Permission_Status = @permission";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@author_email", User1_Email);
                myCommand.Parameters.AddWithValue("@permission", "Public");

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    postID = (int) reader["Post_Id"];
                    pList.Add(postID);
                }
            }
            return pList;
        }
    }
}