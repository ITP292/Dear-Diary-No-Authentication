using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Friends
{
    public partial class requestFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load, I will get data from Aidil's notification page and modify the header and the email textbox
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                //Modify the row in the sql database such that the status is accepted
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                //Modify the row in the sql database such that the status is declined
            }
        }
    }
}