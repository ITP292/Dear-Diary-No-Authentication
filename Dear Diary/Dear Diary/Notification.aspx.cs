﻿using System;
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
        //sfList stores related notification information about friends
        private ArrayList sfList;
        private ArrayList cList = new ArrayList();
        private ArrayList pList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
            makeList(displayList());
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
            makeList(displayList());
        }

        protected void makeList(ArrayList s)
        {
            for(int i = 0; i <= s.Count; i++)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                tabs.Controls.Add(li);
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "#");
                anchor.InnerText = s[i].ToString();
                li.Controls.Add(anchor);
            }
            //Things that need to be solved, count the number of notifications pulled from the database and use that number
            //to make the list.
        }

        protected ArrayList displayList()
        {
            sfList = new ArrayList();
            try
            {
                sfList = retrieveFriends();
            }
            catch (Exception)
            {
                Label3.Text = "There was something wrong with the database";
            }
            return sfList;
        }

        protected ArrayList retrieveFriends()
        {
            //fList stores information retrieved from Friends table
            ArrayList fList = new ArrayList();
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String User2_Email;
                String query = "SELECT * FROM [Friendship] WHERE read = @read";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@read", "false");

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    User2_Email = reader["User2_Email"].ToString();
                    fList.Add(User2_Email);
                }
            }
                return fList;
        }
    }
}