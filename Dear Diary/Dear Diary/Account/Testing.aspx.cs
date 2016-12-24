using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Account
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string phoneNo = TextBox1.Text;
            string firstDigit = phoneNo.Substring(0, 1);
            bool result = IsAllDigits(phoneNo);

            
            if (phoneNo.Length == 8 && (firstDigit == "9" || firstDigit == "8") && result == true)
            {
                Label2.Text = "Good phone number";
            }
            else
            {
                //if phone number length is not 8 and does not start with 8 or 9
                
                //if phone number length is not 8, say this
                if (phoneNo.Length != 8 && result == true)
                {
                    Label2.Text = "Phone Number must be 8 digits.";
                }
                //if phone number length is 8, see if digit is 8 or 9. 
                else if (firstDigit != "9" || firstDigit != "8" || result == false)
                {
                    Label2.Text = "Invalid phone number";
                }
            }
        }
        
        //to check if phone string is fully digits, no alphabets or special characters.
        bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

    }
}