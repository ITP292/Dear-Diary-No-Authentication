using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Dear_Diary
{
    public partial class Notification : System.Web.UI.Page
    {
        //this is going to be used to store the related information for the notification
        private string s;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Page loaded at: " + DateTime.Now.ToLongTimeString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Page refreshed at: " + DateTime.Now.ToLongTimeString();
            s = "Notification";
            makeList(s);
        }

        protected void makeList(string s)
        {
            for(int i = 0; i <= 10; i++)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                tabs.Controls.Add(li);
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", "#");
                anchor.InnerText = s;
                li.Controls.Add(anchor);
            }
            //Things that need to be solved, count the number of notifications pulled from the database and use that number
            //to make the list.
        }
    }
}