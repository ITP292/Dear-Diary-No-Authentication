using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;

namespace Dear_Diary.Account
{
    public partial class Testing4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Timers.Timer t1 = new System.Timers.Timer();
            t1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            t1.Interval = 1000; //1 second
            t1.Enabled = true;
            t1.Start();

        }
        protected void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Label1.Text = "Success, end of timer";
            Label1.Visible = true;
        }

        protected void Tick (object source, ElapsedEventArgs e)
        {
            Label1.Visible = true;

        }
    }
}