<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="HomeShopping.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HouseHold Shopping</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" type="text/css" href="~\Stylesheets\Parent.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <link rel="stylesheet" type="text/css" href="~\Stylesheets\Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Household Shopping</h1>
        </div>
        <div class="row">
            <h2 class="welcome">
                Welcome to Home Shopping, to begin Please enter your credentials!!
            </h2>
            
            <div class="col-s-12 col-6 ">
               <div >
                   <table class="login">
                       <tr>
                           <td colspan="2"><b>USER CREDENTIALS</b></td>
                       </tr>
                       <tr>
                           <td>User Name :</td>
                           <td>
                               <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td>Password :</td>
                           <td>
                               <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                       </tr>
                       <tr>
                           <td colspan="2">
                               <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnLogin" runat="server" Text="Login" />
                           </td>
                       </tr>
                       <tr>
                           <td style="font-style:italic">New User?</td>
                       </tr>
                   </table>
               </div>
            </div>
            <div class="col-s-12 col-6">
                <table class="login">
                    <tr>
                        <td colspan="2">
                            <b>NEW USER REGISTRATION</b>
                        </td>
                    </tr>
                    <tr>
                        <td>Name :</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>User Name :</td>
                        <td><asp:TextBox ID="txtNewUserName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>New Password :</td>
                        <td><asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Confirm Password :</td>
                        <td><asp:TextBox ID="txtConfirmPassword" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>email id :</td>
                        <td><asp:TextBox ID="txtemailID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Contact Number :</td>
                        <td><asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnRegister" runat="server" Text="Register" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="footer">
            <p>All Rights Reserved.Powered by RajiVenkat.</p>
        </div>
    </form>
</body>
</html>
