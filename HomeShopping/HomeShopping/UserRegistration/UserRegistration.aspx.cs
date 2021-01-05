using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeShopping.BLL.LoginPages;
using System.Web.Security;
using HomeShopping.DAL;
using HomeShopping.DAL.LoginPages;

namespace HomeShopping.LoginPage_s_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRegistrationMessage.Text = "";
            lnkLogin.Visible = false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string name = txtName.Text;
                    string username = txtNewUserName.Text;
                    string email = txtemailID.Text;
                    string contactnumber = txtContactNumber.Text;
                    string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtConfirmPassword.Text, "SHA1");

                    UserRegistation userRegistation = new UserRegistation()
                    {
                        RegisterName = name,
                        UserName = username,
                        Password = EncryptedPassword,
                        ContactNumber = contactnumber,
                        Email = email
                    };

                    int result = UserRegistrationLogicsBLL.AddUserRegistationDetails(userRegistation);
                    if (result > 0)
                    {
                        lblRegistrationMessage.Text = Messages.REGISTRATION_SUCCESSFUL;
                        lnkLogin.Visible = true;
                    }
                    else if (result == -1)
                    {
                        lblRegistrationMessage.Text = Messages.USER_ALREADY_REGISTERED;
                        lnkLogin.Visible = false;
                    }
                    else
                    {
                        lblRegistrationMessage.Text = Messages.ERROR;
                        lnkLogin.Visible = false;
                    }
                }
            }
            catch(Exception exception)
            {
                Log.Error(Layers.Presentation, exception);
            }
        }
    }
}