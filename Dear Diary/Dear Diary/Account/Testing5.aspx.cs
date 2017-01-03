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

        public static Boolean result = true;
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Label1.Text = result.ToString();

            if (result)
            {
                ModalPopupExtender1.Show();
            }
            else
            {
                ModalPopupExtender1.Hide();
            }

            result = !result;
        }
    }
}