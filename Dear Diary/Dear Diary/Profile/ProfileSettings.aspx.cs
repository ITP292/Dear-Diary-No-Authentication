using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Profile
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static String email = "stupid@idiot.com";
        public static String Name = "";

        protected void Page_Load(object sender, EventArgs e)
        {

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

                String dbFName;
                String dbLName;
                myConnection.Open();

                // update user profile photo based on email
                string query = "UPDATE [User] SET [displayPic] = @picture WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@picture", Session["imagePath"].ToString());
                myCommand.Parameters.AddWithValue("@email", email);

                myCommand.ExecuteNonQuery();

                // update user data based on text typed in textbox
                string query2 = "UPDATE [User] SET [FName, LName] = @Name WHERE [Email_Address] = @email";
                SqlCommand myCommand2 = new SqlCommand(query2, myConnection);

                
                myCommand.Parameters.AddWithValue("@Name", Name);
                SqlDataReader reader = myCommand2.ExecuteReader();
                if (reader.Read())
                {
                    // concatenate name
                    dbFName = reader["FName"].ToString();
                    dbLName = reader["LName"].ToString();
                    Name = dbFName + " " + dbLName;  
                }

                editFName.Text = reader["FName"].ToString();
                editLName.Text = reader["LName"].ToString();

            }
        }


    }
}