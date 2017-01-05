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
        public static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Take this as Login Button
        //1. Once click, check if inputs are correct/wrong 
        //2. If inputs are wrong, then counter++
        //3. First, we have to SELECT and pull from database to check if counter is already 5
        //4. If counter is already 5, then don't allow login.
        //5. If counter has not reached 5, then continue to add 1

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (count >= 0 && count <5)
            {
            count++;
            Label1.Text = count.ToString();
            }
            else if (count == 5)
            {
                Label1.Text = count.ToString();
                Label2.Text = "Counter has reached 5";

            }
        }
    }
}