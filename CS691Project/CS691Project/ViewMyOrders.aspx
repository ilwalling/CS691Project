<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMyOrders.aspx.cs" Inherits="CS691Project.ViewMyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <h1 style="color:lawngreen">View Orders</h1>
        <div style="width:50%; padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:Label runat="server" ForeColor="LawnGreen" Text="Open Orders"></asp:Label>
                <br />
                <asp:ListBox  ID="orderListBox" runat="server" ForeColor="LawnGreen" BackColor="Black" OnSelectedIndexChanged="orderListBox_SelectedIndexChanged" AutoPostBack="true">

                </asp:ListBox>
                </asp:Panel>
            </div>
        <div style="width:50%; padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <div>
                    <asp:Label runat="server" ForeColor="LawnGreen" Text="Customer Name"></asp:Label>
                    <asp:TextBox runat="server" ID="customerIdTextbox" Enabled="false" ForeColor="LawnGreen" BackColor="Black"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="LawnGreen" Text="Menu Items"></asp:Label>
                    <asp:TextBox runat="server" ID="menuItemsTextBox" Enabled="false" ForeColor="LawnGreen" BackColor="Black"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="LawnGreen" Text="Waiter Name"></asp:Label>
                    <asp:TextBox runat="server" ID="waiterNameTextBox" Enabled="false" ForeColor="LawnGreen" BackColor="Black"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="LawnGreen" Text="Tip:"></asp:Label>
                    <asp:TextBox runat="server" ID="tipTextBox" Enabled="false" ForeColor="LawnGreen" BackColor="Black"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ForeColor="LawnGreen" Text="Order Status"></asp:Label>
                     <asp:DropDownList  ID="orderStatusDropDownStatus" runat="server" ForeColor="LawnGreen" BackColor="Black" Enabled="false" >

                </asp:DropDownList>
                </div>
                </asp:Panel>
            </div>
    </center>
</asp:Content>
