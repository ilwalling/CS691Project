<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CS691Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <asp:Panel Width="40%" runat="server" HorizontalAlign="Center" BackColor="#676565">
        <h1 style="color:lawngreen">The Developer's Dwelling</h1>
        <asp:Image src="codePhoto.jpg" Width="60%" runat="server"/>
        <h3 style="color:white">Welcome to Developer's Dwelling, where we all have the same SO, Stack Overflow!</h3>
    </asp:Panel>
</asp:Content>
