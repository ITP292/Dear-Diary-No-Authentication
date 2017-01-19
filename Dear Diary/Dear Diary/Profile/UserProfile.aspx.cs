﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Dear_Diary.Profile
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static String dbEmail = "";
        public static String dbProfilePic = "";
        public static String Name = "";
        public static String email = "stupid@idiot.com";

        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["email"].ToString();

            String email = "stupid@idiot.com";

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String dbFName;
                String dbLName;
                String query = "SELECT [FName], [LName], [Email_Address], [displayPic] FROM [User] WHERE [Email_Address] = @email";

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbEmail = reader["Email_Address"].ToString();
                    dbFName = reader["FName"].ToString();
                    dbLName = reader["LName"].ToString();
                    Name = dbFName + " " + dbLName;
                }

                
                userName.Text = Name;
                userEmail.Text = dbEmail;
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Pictures/") + fileName);
                Session["imagePath"] = "~/Pictures/" + fileName;
                Image1.ImageUrl = "~/Pictures/" + fileName;
                Image1.Visible = true;
            }

            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                myConnection.Open();

                string query = "UPDATE [User] SET [displayPic] = @picture WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@picture", Session["imagePath"].ToString());
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.ExecuteNonQuery();
            }
        }

    }

}
