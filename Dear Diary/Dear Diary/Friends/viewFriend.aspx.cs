using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Dear_Diary.Friends
{
    public partial class viewFriend : System.Web.UI.Page
    {
        public static String FriendEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["email"] = "lrh@gmail.com";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FriendEmail = GridView1.SelectedRow.Cells[0].Text;
            Response.Redirect("viewFriendRedir.aspx");
        }
    }
}