/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dear_Diary.Security_API;

namespace Dear_Diary.Profile
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static String email = "stupid@idiot.com";
        public static String Name = "";
        public static String dbEmail = "";
        public static String dbProfilePic = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["email"] = "stupid@idiot.com";

            if (!IsPostBack)
            {
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                {
                    String dbFName = "";
                    String dbLName = "";
                    String query = "SELECT [FName], [LName], [Email_Address], [displayPic] FROM [User] WHERE [Email_Address] = @email";
                    SqlCommand myCommand = new SqlCommand(query, myConnection);

                    myConnection.Open();
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Parameters.AddWithValue("@email", "stupid@idiot.com");

                    SqlDataReader reader = myCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        dbEmail = reader["Email_Address"].ToString();
                        dbFName = reader["FName"].ToString();
                        dbLName = reader["LName"].ToString();
                        dbProfilePic = reader["displayPic"].ToString();

                    }

                    Image1.ImageUrl = dbProfilePic;
                    editFName.Text = dbFName;
                    editLName.Text = dbLName;

                    myConnection.Close();
                }
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

             

                // update user profile photo based on email
                string query = "UPDATE [User] SET [displayPic] = @picture WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@picture", Session["imagePath"].ToString());
                myCommand.Parameters.AddWithValue("@email", email);

                myCommand.ExecuteNonQuery();


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {

             
                String newFName = editFName.Text;
                String newLName = editLName.Text;
                myConnection.Open();



                // update user data based on text typed in textbox
                string query3 = "UPDATE [User] SET [FName]=@FName, [LName]=@LName WHERE [Email_Address]=@email";
                SqlCommand myCommand3 = new SqlCommand(query3, myConnection);



                myCommand3.Parameters.AddWithValue("@FName", newFName);
                myCommand3.Parameters.AddWithValue("@LName", newLName);
                myCommand3.Parameters.AddWithValue("@email", "stupid@idiot.com");
                myCommand3.ExecuteNonQuery();

               

            }
        }
    }
}