﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CS691Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color:lawngreen">Menu</h1>
    <asp:Panel runat="server" Width="80%" BackColor="#676565" HorizontalAlign="Center">
        <asp:Table runat="server" HorizontalAlign="Center" Width="100%">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Width="80%" HorizontalAlign="Center"><h3 style="color:lawngreen">Menu Item</h3></asp:TableHeaderCell>
                <asp:TableHeaderCell HorizontalAlign="Right"><h3 style="color:lawngreen">Price (Base 2)</h3></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <hr />
        <asp:Panel runat="server" Width="90%" BackColor="#474444">
            <br />
            <div style="float:left; width:20%; overflow-y:hidden">
                <asp:Image src="pizza.jpg" width="100%" runat="server" />
            </div>
            <div style="width:70%">
                <h3 style="color:lawngreen">The 3A.M. Group Project Meeting</h3>
                <p style="color:white">A large 12" peperroni pizza made to feed a group of 3.  Enjoy this with a 2 liter of your favorite soft drink to keep the group working.</p>
            </div>
            <div style="float:right; width:10%"><p style="color:white">00010000</p></div>
            <br />
            <br />
        </asp:Panel>

        <br />
        <br />

         <asp:Panel runat="server" Width="90%" BackColor="#474444" Visible="false">
            <br />
            <div style="float:left; width:20%">
                <asp:Image src="burger.jpg" width="100%" runat="server" />
            </div>
            <div style="width:70%">
                <h3 style="color:lawngreen">The Team Lead</h3>
                <p style="color:white">This one is for the holy leader.  He/she is the one who has guided us to the light, who always seems to find our bugs, who always knows how to help.  Praise the team lead!  Serve them a genuine beef burger with cheese.</p>
            </div>
            <div style="float:right; width:10%"><p style="color:white">00001000</p></div>
            <br />
            <br />
        </asp:Panel>

        <br />
        <br />

         <asp:Panel runat="server" Width="90%" BackColor="#474444">
            <br />
            <div style="float:left; width:20%">
                <asp:Image src="badFood.jpg" width="100%" runat="server" />
            </div>
            <div style="width:70%">
                <h3 style="color:lawngreen">The Client</h3>
                <p style="color:white">We aren't even sure what came on your plate.  We know it's edible, and you came here for food.  Requirements met! </p>
            </div>
            <div style="float:right; width:10%"><p style="color:white">00000111</p></div>
            <br />
            <br />
        </asp:Panel>



        <br />
        <br />
        <footer>
            <p style="color:white">*Consuming raw or undercooked meat may result in null pointer exception.</p>
        </footer>
    </asp:Panel>
</asp:Content>