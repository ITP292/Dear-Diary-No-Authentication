using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Dear_Diary.Profile
{
    public partial class UserProfile : System.Web.UI.Page
    {
        public static String dbEmail = "";
        public static String dbProfilePic = "";
        public static String Name = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                Session["Image"] = null;
            }
            */
            string email = Session["email"].ToString();

            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                String dbFName = "";
                String dbLName = "";
                String query = "SELECT [FName, LName] FROM [User] WHERE [Email_Address] = @email";

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
            }
            }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /*Session["Image"] = FileUpload1.PostedFile;
            Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            Image1.ImageUrl = "data:image/png;base64, " + base64String;
            Panel1.Visible = true;
            */
        }

        protected void Save(object sender, EventArgs e)
        {
            /*
            SqlConnection myConnection;
            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
                if (FileUpload1.HasFile)
                {
                    string strname = FileUpload1.FileName.ToString();
                    HttpPostedFile postedFile = (HttpPostedFile)Session["Image"];
                    postedFile.SaveAs(Server.MapPath("~/upload/") + strname);
                  

                    myConnection.Open();
                    String query = "INSERT INTO Test (profilePic) VALUES (@Image)";

                    SqlCommand myCommand = new SqlCommand(query, myConnection);
                    myCommand.Parameters.AddWithValue("@Image", strname);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    SqlDataReader reader = myCommand.ExecuteReader();


            }
            */
        }


        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}