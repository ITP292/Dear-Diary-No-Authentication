using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dear_Diary.Security_API.Testing_Files
{
    public partial class testAES : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void runencrypt(object sender, EventArgs e)
        {
            String plain = plaintext.Text;
            String cipher = AES.Encrypt(plain);
            encryptedtext.Text = cipher;
        }

        protected void rundecrypt(object sender, EventArgs e)
        {
            String cipher = encryptedtextinput.Text;
            String plain = AES.Decrypt(cipher);
            plaintextoutput.Text = plain;
        }
    }
}