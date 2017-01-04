using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Timer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //private int counter = 60;
        Stopwatch stopwatch = new Stopwatch();
        protected void Button1_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            Thread.Sleep(6000);
            Label1.Text = "Time elapsed: " + stopwatch.Elapsed.Seconds.ToString();

            //var stopwatch = new System.Diagnostics.Stopwatch();

            //int counter = 60;
            //stopwatch.Tick += new EventHandler(timer1_Tick);
            //stopwatch.Interval = 1000; // 1 second
            //stopwatch.Start();
            //Label1.Text = counter.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    counter--;
        //    if (counter == 0)

        //        timer1.Stop();
        //    label1.Text = counter.ToString();

        //}
    }
}