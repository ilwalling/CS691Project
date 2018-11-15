<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS691Project.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <center>
       <h1 style="color:lawngreen">Login</h1>
       <asp:Panel BackColor="#676565" runat="server" Width="40%" HorizontalAlign="center">
           <div style="padding:10px">
               <label style="color:white; float:left">Username</label>
               <asp:TextBox id="usernameTextBox" BackColor="Black" ForeColor="LawnGreen" Width="60%" runat="server"></asp:TextBox>
           </div>
           <div style="padding:10px">
               <label style="color:white; float:left">Password</label>
               <asp:TextBox id="passwordTextBox" BackColor="Black" ForeColor="LawnGreen" TextMode="Password" Width="60%" runat="server"></asp:TextBox>
           </div>
           <div style="padding:10px">
               <asp:Button id="LoginButton" BackColor="Black" ForeColor="LawnGreen" Text="Submit" OnClick="LoginButton_Click" runat="server"/>
               <asp:Button id="cancelButton" Text="Cancel" BackColor="Black" ForeColor="LawnGreen" OnClick="cancelButton_Click" runat="server"/>
           </div>
       </asp:Panel>
   </center>
</asp:Content>
