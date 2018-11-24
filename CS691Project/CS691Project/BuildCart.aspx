<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuildCart.aspx.cs" Inherits="CS691Project.BuildCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1 style="color:lawngreen">Build your Cart</h1>
        <div runat="server" style="padding:10px">
            <asp:Label runat="server" ForeColor="LawnGreen" Text="Choose the Restaraunt: "></asp:Label>
            <asp:DropDownList id="restarauntDropDown" runat="server" BackColor="Black" ForeColor="LawnGreen" AutoPostBack="true" OnSelectedIndexChanged="restarauntDropDown_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="Developer's Dwelling"></asp:ListItem>
            <asp:ListItem Value="1" Text="The Local Cuisine"></asp:ListItem>
            <asp:ListItem Value="2" Text="Grandma's Cooking"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <div style="width:50%; float:left; padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:CheckBoxList runat="server" ID="checkBoxMenuItems" ForeColor="LawnGreen">

                </asp:CheckBoxList>
                </asp:Panel>
            </div>
        <div style="width:50%;padding:10px">
            <asp:Panel BackColor="#676565" runat="server" Width="100%">
                <asp:Button ID="submitButton" runat="server" BackColor="Black" ForeColor="LawnGreen" Text="Submit" OnClick="submitButton_Click" />
                <asp:Button ID="cancelButton" runat="server" BackColor="Black" ForeColor="LawnGreen" Text="Cancel" OnClick="cancelButton_Click" />
            </asp:Panel>
        </div>
    </center>
</asp:Content>
