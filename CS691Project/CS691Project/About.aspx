<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CS691Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel BackColor="#676565" runat="server" Width="60%" HorizontalAlign="center">
         <h2 style="color:lawngreen">About us!</h2>
        <asp:Image src="windowsError.png" runat="server"/>
        <h3 style="color:white">Who are we? Why are we here?</h3>
        <p style="color:#2b2727">This page is being developed by a developer for developers.  Those late night bug fixes always draw us to wanting food, so why not order some here?</p>
    </asp:Panel>
   
</asp:Content>
