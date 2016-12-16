using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            //Testing - redirect AccountPage
            Response.Redirect("/Account/AccountPage.aspx");
            //DATABASE
            //Pull out and compare

            //Add in codes to redirect to 2FA first
            //Then redirect to account page 
            //Take USERNAME put at top right hand corner (Hello _____) 
        }
    }
}