﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Friends
{
    public partial class addFriend : System.Web.UI.Page
    {
        public static String dbEmail = "";
        public static String dbProfilePic = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            String friendemail = Email.Text;

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String query = "SELECT * FROM [User] WHERE [Email_Address] = @email";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", friendemail);

                SqlDataReader reader = myCommand.ExecuteReader();

                //FIND OUT HOW TO STORE AND RETRIEVE PICTURE

                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                }

                Response.Redirect("addFriendRedir");
            }
        }
    }
}