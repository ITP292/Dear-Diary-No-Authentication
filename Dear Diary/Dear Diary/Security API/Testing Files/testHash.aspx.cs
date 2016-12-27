using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Security_API.Testing_Files
{
    public partial class testHash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void runencrypt(object sender, EventArgs e)
        {
            String plain = plaintext.Text;
            String hashoutput = Hash.ComputeHash(plain, "SHA512", new Byte[8]);
            hash.Text = hashoutput;
        }

        protected void rundecrypt(object sender, EventArgs e)
        {
            String plaininput = plaintextinput.Text;
            String hashuserinput = hashinput.Text;
            String result = Hash.VerifyHash(plaininput, "SHA512", hashuserinput).ToString();

            if (result.Equals("true") || result.Equals("True"))
            {
                Label3.Text = "Hash Match";
            }
            else if (result.Equals("false") || result.Equals("False"))
            {
                Label3.Text = "Hash Does Not Match";
            }
        }
    }
}