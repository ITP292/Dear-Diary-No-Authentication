using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Timers;

namespace Dear_Diary.Account
{
    public partial class Testing2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["StartTime"] = t1;
                Session["EndTime"] = t2;
            }
        }
        //Enter 2FA input and check if the input and number in database is the same
        //Pulling from database and check with user input
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            string inputemail = "xjt@gmail.com";
            string dbRandomNo = "";


            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT randomNo FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbRandomNo = reader["randomNo"].ToString();
                }

                string inputNo = TextBox1.Text;

                if (inputNo.Equals(dbRandomNo))
                {
                    Label2.Text = "Success";
                }
                else if (!inputNo.Equals(dbRandomNo))
                {
                    Label2.Text = "Failed";
                }
            }
        }


        //Getting the current time
        protected void Button2_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            Label3.Text = time;

        }



        private DateTime t1;
        private DateTime t2;
        
        //Button - Generate Code
        protected void Button3_Click(object sender, EventArgs e)
        {
            //Test - time when click to generate code 
            //timeA = DateTime.Now.ToString("h:mm:ss tt");
            //t1 = Convert.ToDateTime(timeA);
            t1 = DateTime.Now;
            Label5.Text = t1.ToString();
        }
        //Button - Confirm Code
        protected void Button4_Click(object sender, EventArgs e)
        {
            //Test - time when click to confirm code
            //timeB = DateTime.Now.ToString("h:mm:ss tt");
            //t2 = Convert.ToDateTime(timeB);
            t2 = DateTime.Now;
            Label6.Text = t2.ToString();
        }
        //Button - See time difference
        protected void Button5_Click(object sender, EventArgs e)
        {
            TimeSpan difference = t2.Subtract(t1);
            Label4.Text = difference.Seconds.ToString();        //The difference i keep getting 0 :(
        }

        //Concept:
        //user enters email, system checks accountStatus, if accountStatus = locked, then disables the textbox until time's up then enabled again

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection;
            string inputemail = TextBox2.Text;
            string dbStatus = "";

            System.Timers.Timer Timer1 = new System.Timers.Timer();
            Timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            Timer1.Interval = 5000; //5 seconds
            Timer1.Enabled = true;

            using (myConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["localdbConnectionString1"].ConnectionString))
            {
                string query = "SELECT accountStatus FROM [User] WHERE [Email_Address] = @email";
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.CommandType = CommandType.Text;
                myCommand.Parameters.AddWithValue("@email", inputemail);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.Read())
                {
                    dbStatus = reader["accountStatus"].ToString();
                }

                if (dbStatus.Equals("locked"))
                {
                    TextBox2.Enabled = false;
                }
                else
                {
                    TextBox2.Text = "Good";
                }
            }
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Specify what you want to happen when the Elapsed event is raised.
        }

    }
}