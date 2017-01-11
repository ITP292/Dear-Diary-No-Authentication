using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Friends
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addFriend.aspx");
        }
    }
}