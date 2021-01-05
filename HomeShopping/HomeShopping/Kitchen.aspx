<%@ Page Title="" Language="C#" MasterPageFile="~/Parent.Master" AutoEventWireup="true" CodeBehind="Kitchen.aspx.cs" Inherits="HomeShopping.WebForm2" %>

<asp:Content ID="KitchenContent" ContentPlaceHolderID="ParentContentPlaceHolder" runat="server">
   <style>
       .Onhover :hover{
           box-shadow: 0 10px 50px hsl(60, 100%, 50%);
       }
   </style>

    <div class="col-4 Onhover">
        <div class="w3-card-2 w3-hover-black">
            <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
            <div class="w3-container">
                    <a href="KitchenCategory.aspx" style="text-decoration:none" >
                        <p>Dairy</p>
                    </a>
            </div>
        </div>
    </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Oils</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Veggies</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Meat</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Fruits</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Desserts</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Grocery</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Cleaning</p>
                </div>
            </div>
        </div>

        <div class="col-4 Onhover">
            <div class="w3-card-2 w3-hover-black">
                <img src="Images/Kitchen.png" alt="Kitchen" style="width: 100%" />
                <div class="w3-container">
                    <p>Oils</p>
                </div>
            </div>                       
        </div>
   
</asp:Content>
