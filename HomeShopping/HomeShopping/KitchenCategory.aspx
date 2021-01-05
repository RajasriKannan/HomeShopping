<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="KitchenCategory.aspx.cs" Inherits="HomeShopping.KitchenCategory" %>
<asp:Content ID="KitchenStocksContent" ContentPlaceHolderID="ParentContentPlaceHolder" runat="server">
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
          margin:auto;
          text-align:left;
      }
  </style>
    <div class="row">
        <div  style="max-width:100%">
            <asp:HiddenField ID="hdnUserName" runat="server" />
            <table class="CategoryTable">
               <tr>
                   <td>
                       Select Category                  
                   </td>
                   <td>
                       <asp:DropDownList CssClass="categoryDropdown w3-round-large" ID="ddlKitchenCategory" runat="server">
                       </asp:DropDownList>
                       <asp:HiddenField ID="hdnKitchenCategory" runat="server" />
                   </td>
               </tr>
                <tr>
                   <td>
                       Select Add/View Items                  
                   </td>
                   <td>
                       <asp:DropDownList CssClass="categoryDropdown w3-round-large" ID="ddlListItemsByCategory" runat="server">
                       </asp:DropDownList>
                       <asp:HiddenField ID="hdnListItemsByCategory" runat="server" />
                   </td>
               </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button CssClass="button w3-button w3-round-large w3-hover-black" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblSelectCategory" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="row">
            <asp:GridView ID="gvAddNewProducts"  CssClass="w3-border w3-hsl(120, 100%, 10%) w3-table-all" GridLines="None" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="LKKitchenProductsByCategoryID" HeaderText="" />
                    <asp:BoundField DataField="KitchenCategoryIDFK" HeaderText="" />
                    <asp:BoundField DataField="Products" HeaderText="Products" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="InStock" HeaderText="InStock" />
                    <asp:BoundField DataField="createdBy" HeaderText="" />
                    <asp:BoundField DataField="createdDate" HeaderText="" />
                    <asp:BoundField DataField="modifiedBy" HeaderText="" />
                    <asp:BoundField DataField="modifiedDate" HeaderText="" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAdd" OnClick="btnAddNewItemInList_Click" role="button"  runat="server" Text="Add" CssClass="button w3-button w3-round-large w3-hover-black"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div >
                <asp:GridView ID="gvEditProducts" CssClass="w3-border w3-hsl(120, 100%, 10%) w3-table-all" GridLines="None" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="RegistrationID" HeaderText="" />
                        <asp:BoundField DataField="lkkitchencategoryID" HeaderText="" />
                        <asp:BoundField DataField="KitchenCategory" HeaderText="" />
                        <asp:BoundField DataField="Products" HeaderText="Products" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="LKInStockIDFK" HeaderText="" />
                        <asp:BoundField DataField="InStock" HeaderText="InStock" />
                        <asp:BoundField DataField="LKAddToCartIDFK" HeaderText="" />
                        <asp:BoundField DataField="AddToCart" HeaderText="AddToCart" />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" />
                        <asp:BoundField DataField="CreatedBy" HeaderText="" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="" />
                        <asp:BoundField DataField="ModifiedBy" HeaderText="" />
                        <asp:BoundField DataField="ModifiedDate" HeaderText="" />
                        <asp:BoundField DataField="RecordStatus" HeaderText="" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" OnClick="btnEditItem_Click" role="button"  runat="server" Text="Edit / Delete" CssClass="button w3-button w3-round-large w3-hover-black"></asp:LinkButton>
                            <%--<asp:LinkButton ID="lnkDelete" OnClick="btnEditDeleteItem_Click" role="button"  runat="server" Text="Delete" CssClass="button w3-button w3-round-large w3-hover-red"></asp:LinkButton>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <asp:Button ID="btnAddNewItemsNotInList" OnClick="btnAddNewItemsNotInList_Click" runat="server" Text="Add More New Items" CssClass="w3-panel button w3-button w3-round-large w3-hover-black" />
        </div>
    </div>



    <%--Add New Items From List--%>
    <div id="AddNewItems" runat="server">
        <div class="row w3-container">
            <table class="w3-panel w3-table w3-leftbar w3-border-black">
                <tr>
                    <th colspan="2">
                        <h4>Add New Products</h4>
                    </th>
                </tr>
                <tr>
                    <td>Products</td>
                    <td>
                        <asp:TextBox ID="txtAddProduct" runat="server" ReadOnly="true"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>InStock</td>
                    <td><asp:DropDownList ID="ddlAddInStock" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>AddToCart</td>
                    <td><asp:DropDownList ID="ddlAddAddTOCart" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td><asp:TextBox ID="txtAddQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Comments</td>
                    <td><asp:TextBox ID="txtComments" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnAdd" OnClick="btnInsertProductInList_Click" runat="server" Text="Add" CssClass="button w3-button w3-round-large w3-hover-black" />
                    </td>
                    <td><asp:Button ID="btnCancel" OnClick="btnCancelNewProductInList_Click" runat="server" Text="Cancel" CssClass="button w3-button w3-round-large w3-hover-red" /></td>
                </tr>
            </table>
        </div>
    </div>

    <%--Add New Items Not In List--%>
    <div id="AddNewItemsNotInList" runat="server">
        <div class="row w3-container">
            <table class="w3-panel w3-table w3-leftbar w3-border-black">
                <tr>
                    <th colspan="2">
                        <h4>Add New Products</h4>
                    </th>
                </tr>
                <tr>
                    <td>Products</td>
                    <td>
                        <asp:TextBox ID="txtNITProduct" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>InStock</td>
                    <td><asp:DropDownList ID="ddlNITInStock" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>AddToCart</td>
                    <td><asp:DropDownList ID="ddlNITAddToCart" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td><asp:TextBox ID="txtNITQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Comments</td>
                    <td><asp:TextBox ID="txtNITComments" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnInsertProductNotInLis" OnClick="btnInsertProductNotInList_Click" runat="server" Text="Add" CssClass="button w3-button w3-round-large w3-hover-black" />
                    </td>
                    <td><asp:Button ID="btnCancelNewProductNotInList" OnClick="btnCancelNewProductNotInList_Click" runat="server" Text="Cancel" CssClass="button w3-button w3-round-large w3-hover-red" /></td>
                </tr>
            </table>
        </div>
    </div>

    <%--Edit Items --%>
    <div id="EditIems" runat="server">
        <div class="row w3-container">
            <table class="w3-panel w3-table w3-leftbar w3-border-black">
                <tr>
                    <th colspan="2">
                        <h4>Edit Products</h4>
                    </th>
                </tr>
                <tr>
                    <td>Products</td>
                    <td>
                        <asp:TextBox ID="txtEditProduct" runat="server" ReadOnly="true"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>InStock</td>
                    <td><asp:DropDownList ID="ddlEditInStock" runat="server" ></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>AddToCart</td>
                    <td><asp:DropDownList ID="ddlEditAddToCart" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Quantity</td>
                    <td><asp:TextBox ID="txtEditQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Comments</td>
                    <td><asp:TextBox ID="txtEditComments" runat="server"></asp:TextBox></td>
                </tr>
                <tr >
                    <td><asp:Button ID="btnUpdate" OnClick="btnUpdateItem_Click" runat="server" Text="Edit" CssClass="button w3-button w3-round-large w3-hover-black" PostBackUrl="~/KitchenCategory.aspx" />
                    </td>
                    <td><asp:Button ID="btnUpdateDelete" OnClick="btnUpdateDeleteItem_Click" runat="server" Text="Delete" CssClass="button w3-button w3-round-large w3-hover-black" />
                    </td>
                    <td><asp:Button ID="btnUpdateCancel" OnClick="btnUpdateCancelItem_Click" runat="server" Text="Cancel" CssClass="button w3-button w3-round-large w3-hover-red" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
