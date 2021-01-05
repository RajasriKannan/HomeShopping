<%@ Page Title="" Language="C#" MasterPageFile="~/LoginPage(s)/Login.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="HomeShopping.LoginPage_s_.WebForm1" %>

<asp:Content ID="UserRegistrationContent" ContentPlaceHolderID="LoginContentPlaceHolder" runat="server">
    <style>
        .UserRegistrationValidation {
            color: red;
            font-size: small;
        }
        /*.UserRegistrationValidation td{
            width: auto;
        }*/
    </style>
    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <table class="login">
                <tr>
                    <td colspan="2">
                        <b>NEW USER REGISTRATION</b>
                    </td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="UserRegistrationValidation" ID="RequiredFieldValidatorName"
                            runat="server" ControlToValidate="txtName" ErrorMessage="*Please enter the name"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>User Name:</td>
                    <td>
                        <asp:TextBox ID="txtNewUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="UserRegistrationValidation" ID="RequiredFieldValidatorUserName"
                            runat="server" ControlToValidate="txtNewUserName" ErrorMessage="*Please enter valid user name"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>New Password:</td>
                    <td>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNewPassword" CssClass="UserRegistrationValidation" runat="server"
                            ErrorMessage="*Please enter a password" ControlToValidate="txtNewPassword">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="UserRegistrationValidation" ID="RequiredFieldValidatorConfirmPassword"
                            runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*Please enter valid confirm password"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server" Display="Dynamic"
                            ErrorMessage="*Password does not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword" 
                            CssClass="UserRegistrationValidation">*</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>email id:</td>
                    <td>
                        <asp:TextBox ID="txtemailID" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                            ValidationExpression="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"
                            ErrorMessage="*Please enter valid email" ControlToValidate="txtemailID" Display="Dynamic" CssClass="UserRegistrationValidation">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator CssClass="UserRegistrationValidation" ID="RequiredFieldValidatorEmail"
                            runat="server" ControlToValidate="txtemailID" ErrorMessage="*Please enter a email"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contact Number:</td>
                    <td>
                        <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="UserRegistrationValidation" ID="RequiredFieldValidatorContactNumber"
                            runat="server" ControlToValidate="txtContactNumber" ErrorMessage="*Please enter Contact Number"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorContactNumber" runat="server"
                            ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$"
                            ErrorMessage="*Please enter valid Contact Number" ControlToValidate="txtContactNumber" Display="Dynamic" CssClass="UserRegistrationValidation">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnRegister"
                            runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </td>
                </tr>
                <tr>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                    <asp:Label ID="lblRegistrationMessage" runat="server" ></asp:Label>
                    <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/LoginPage(s)/Login.aspx"><i>Login Now</i></asp:HyperLink>
                </tr>
            </table>
        </div>
        <div class="col-4">
        </div>
    </div>
</asp:Content>
