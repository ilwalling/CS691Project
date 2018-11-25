<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignServer.aspx.cs" Inherits="CS691Project.AssignServer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1 style="color:lawngreen">Assign Orders</h1>
        <div runat="server" style="padding:10px">
            <asp:Label runat="server" ForeColor="LawnGreen" Text="Choose the Restaraunt: "></asp:Label>
            <asp:DropDownList id="restarauntDropDown" runat="server" BackColor="Black" ForeColor="LawnGreen" AutoPostBack="true" OnSelectedIndexChanged="restarauntDropDown_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="Developer's Dwelling"></asp:ListItem>
            <asp:ListItem Value="1" Text="The Local Cuisine"></asp:ListItem>
            <asp:ListItem Value="2" Text="Grandma's Cooking"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <div style="padding:10px">
        <div style="width:50%; padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:Label runat="server" ForeColor="LawnGreen" Text="Open Orders"></asp:Label>
                <br />
                <asp:ListBox  ID="orderListBox" runat="server" ForeColor="LawnGreen" BackColor="Black" OnSelectedIndexChanged="orderListBox_SelectedIndexChanged" AutoPostBack="true">

                </asp:ListBox>
                </asp:Panel>
            </div>

        <div style="width:50%;padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:DropDownList  ID="serverDropDownList" runat="server" ForeColor="LawnGreen" BackColor="Black" >

                </asp:DropDownList>
                <asp:Button ID="assignButton" runat="server" BackColor="Black" ForeColor="LawnGreen" Text="Assign" OnClick="assignButton_Click" />
                <br />
                <br />
            </asp:Panel>
        </div>
        </div>
        <div style="width:50%; padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:Label runat="server" ForeColor="LawnGreen" Text="Assigned Orders"></asp:Label>
                <br />
                <asp:ListBox AutoPostBack="true" ID="orderAssignedListBox" runat="server" ForeColor="LawnGreen" BackColor="Black" OnSelectedIndexChanged="orderAssignedListBox_SelectedIndexChanged" >

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
                </asp:Panel>
            </div>
    </center>
</asp:Content>
