using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HomeShopping.BLL;
using HomeShopping.DAL;
using HomeShopping.BLL.LoginPages;
using HomeShopping.DAL.LoginPages;

namespace HomeShopping
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != null && txtPassword != null)
            {
                string LoginName = txtUserName.Text;
                string LoginPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");

                int result = UserRegistrationLogicsBLL.ValidateLoginDetails(LoginName, LoginPassword);
                if(result < 0)
                {
                    lblLogin.Text = Messages.LOGINERROR;
                }
                else
                {
                    Session["UserName"] = LoginName;
                    Response.Redirect("~/Home.aspx");
                }
            }
            else
            {
                lblLogin.Text = Messages.LOGINERROR;
            }
        }
    }
}