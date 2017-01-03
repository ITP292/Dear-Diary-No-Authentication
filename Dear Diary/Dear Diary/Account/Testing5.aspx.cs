using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Testing5aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Testing ModalPopupExtender which still does not work
        public static Boolean result = true;
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Label1.Text = result.ToString();

            if (result)
            {
                ModalPopupExtender1.Show();
                //Panel1.Visible = true; 
            }
            else
            {
                ModalPopupExtender1.Hide();
                //Panel1.Visible = false;
            }

            result = !result;
        }
    }
}