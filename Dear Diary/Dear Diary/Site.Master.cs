using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NotLoggedIn.Visible = false;
            LoggedIn.Visible = false;

            String user = Session["email"].ToString();

            if (String.IsNullOrEmpty(user) == true)
            {
                NotLoggedIn.Visible = true;
            }
            else
            {
                LoggedIn.Visible = true;
            }
        }
    }
}