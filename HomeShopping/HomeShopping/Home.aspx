<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HomeShopping.Home" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="ParentContentPlaceHolder" runat="server">
    <style>
        .button {
            background-color: hsl(120, 100%, 10%);
            box-shadow: 0 10px 50px hsl(60, 100%, 50%);
            color: white;
        }

        .categoryDropdown {
            background-color: hsl(120, 100%, 10%);
            color: white;
            padding: 8px;
            margin-bottom: 8px;
            box-shadow: 0 10px 50px hsl(60, 100%, 50%);
        }

        .CategoryTable {
            margin: auto;
            text-align: left;
        }
    </style>

    <div class="row">
        <h2 class="welcome">Welcome to Household Shopping!!</h2>
        <div style="max-width: 100%">
            <asp:HiddenField ID="hdnUserName" runat="server" />
            <table class="CategoryTable">
                <tr>
                    <td>Select Category to view items in cart                 
                    </td>
                    <td>
                        <asp:DropDownList CssClass="categoryDropdown w3-round-large" ID="ddlRoomCategory" runat="server">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnRoomCategory" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblSelectRoomCategory" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="row">
            <asp:GridView ID="gvProductsByRoomCategory" CssClass="w3-border w3-hsl(120, 100%, 10%) w3-table-all" GridLines="None" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="RegistrationID" HeaderText="" />
                    <asp:BoundField DataField="LKRoomsID" HeaderText="" />
                    <asp:BoundField DataField="RoomsCategory" HeaderText="Rooms" />
                    <asp:BoundField DataField="lkkitchencategoryID" HeaderText="" />
                    <asp:BoundField DataField="KitchenCategory" HeaderText="InStock" />
                    <asp:BoundField DataField="Products" HeaderText="Products" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="LKInStockIDFK" HeaderText="" />
                    <asp:BoundField DataField="InStock" HeaderText="InStock" />
                    <asp:BoundField DataField="LKAddToCartIDFK" HeaderText="" />
                    <asp:BoundField DataField="AddToCart" HeaderText="Add To Cart" />
                    <asp:BoundField DataField="Comments" HeaderText="Comments" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="" />
                    <asp:BoundField DataField="ModifiedBy" HeaderText="" />
                    <asp:BoundField DataField="ModifiedDate" HeaderText="" />
                    <asp:BoundField DataField="RecordStatus" HeaderText="" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
