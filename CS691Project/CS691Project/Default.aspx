<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS691Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="Scripts/styleAnimation.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="Content/Site.css" type="text/css" />
    <center>
       <div runat="server" style="padding:10px">
            <asp:Label runat="server" ForeColor="LawnGreen" Text="Choose the Restaraunt: "></asp:Label>
            <asp:DropDownList id="restarauntDropDown" runat="server" BackColor="Black" ForeColor="LawnGreen" AutoPostBack="true">
            <asp:ListItem Value="0" Text="Developer's Dwelling"></asp:ListItem>
            <asp:ListItem Value="1" Text="The Local Cuisine"></asp:ListItem>
            <asp:ListItem Value="2" Text="Grandma's Cooking"></asp:ListItem>
        </asp:DropDownList>
        </div>
    <asp:Panel style="background-color:#676565" Width="60%" HorizontalAlign="Center" runat="server">
        <div id="dynamicTitle" runat="server">

        </div>
        <asp:Image src="Images/codePhoto.jpg" Width="60%" runat="server"/>
        <div id="dynamicContent" runat="server">

        </div>
    </asp:Panel>
    </center>
</asp:Content>
