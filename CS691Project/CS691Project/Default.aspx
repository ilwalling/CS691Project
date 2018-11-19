<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS691Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="Script/styleAnimation.js"></script>
    <center>
    <asp:Panel style="background-color:#676565" Width="60%" HorizontalAlign="Center" runat="server">
        <h1 style='color: lawngreen'>The Developer's Dwelling</h1>
        <asp:Image src="Images/codePhoto.jpg" Width="60%" runat="server"/>
        <div id="dynamicMessage" runat="server">

        </div>
    </asp:Panel>
    </center>
</asp:Content>
