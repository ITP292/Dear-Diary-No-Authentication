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
                myConnection.Open();

                string query = "INSERT INTO [Test] VALUES (@picture)";
                SqlCommand myCommand = new SqlCommand(query, myConnection);

                myCommand.Parameters.AddWithValue("@picture", Session["imagePath"].ToString());

                myCommand.ExecuteNonQuery();
            }
        }
    }
}