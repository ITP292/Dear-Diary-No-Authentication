using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dear_Diary.Account;

namespace Dear_Diary
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NotLoggedIn.Visible = false;
            LoggedIn.Visible = false;

                if (Session["email"].ToString().Equals(""))
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