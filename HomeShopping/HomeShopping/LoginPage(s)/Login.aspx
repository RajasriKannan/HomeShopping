<%@ Page Title="" Language="C#" MasterPageFile="~/LoginPage(s)/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HomeShopping.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <asp:Label ID="lblLogin" ForeColor="Red"  runat="server"></asp:Label>
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
                        <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnLogin" 
                            runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="font-style: italic">
                        <a href="../UserRegistration/UserRegistration.aspx">New User?</a>
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-4">
        </div>
    </div>
</asp:Content>
