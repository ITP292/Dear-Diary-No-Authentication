using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Testing6 : System.Web.UI.Page
    {
        int count = 0;
        int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    Label1.Text = count.ToString();
        

        }

    

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (count >= 0 && count <5)
            //{
            count++;
            Label1.Text = count.ToString();

            //}
            //else if (count == 5)
            //{
            //    Label1.Text = count.ToString();
            //    Label2.Text = "Counter has reached 5";

            //}
        }
    }
}