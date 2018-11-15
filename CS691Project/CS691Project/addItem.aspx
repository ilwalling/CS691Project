<%@ Page Title="Add Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="CS691Project.addItem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1 style="color:lawngreen">Add an Item</h1>
    <asp:Panel Width="80%" BackColor="#676565" runat="server" HorizontalAlign="Center">
        <div width="60%">
            <asp:Label ForeColor="black" runat="server">Menu Item: </asp:Label>
            <asp:TextBox id="itemTextBox" BackColor="Black" ForeColor="LawnGreen" Width="60%" runat="server"></asp:TextBox>
        </div>
        <br />
        <div width="60%">
            <asp:Label ForeColor="black" runat="server">Menu Price: </asp:Label>
            <asp:TextBox id="itemPrice" BackColor="Black" ForeColor="LawnGreen" Width="60%" runat="server"></asp:TextBox>
        </div>
        <br />
        <div width="60%">
            <asp:Label ForeColor="black" runat="server">Menu Description: </asp:Label>
            <textarea id="itemDescriptionTextArea" style="background-color:black; color:lawngreen; max-width:60%"></textarea>
        </div>
        <br />
        <asp:Button id="submitButton" BackColor="Black" ForeColor="LawnGreen" Text="Submit" OnClick="submitButton_Click" runat="server"/>
        <asp:Button id="cancelButton" Text="Cancel" BackColor="Black" ForeColor="LawnGreen" OnClick="cancelButton_Click" runat="server"/>
    </asp:Panel>
        <hr />
        <br />
        <br />
        <h1 style="color:lawngreen">Modify/Delete Item</h1>
        <asp:Panel Width="80%" BackColor="#676565" runat="server" HorizontalAlign="Center">
            <div style="width:50%; float:left">
                <asp:ListBox runat="server" BackColor="Black" ForeColor="LawnGreen" Width="80%">
                    <asp:ListItem>The Team lead item</asp:ListItem>
                    <asp:ListItem>The client item</asp:ListItem>
                </asp:ListBox>
            </div>
            <div>
                <ul style="list-style:none">
                    <li>
                        <asp:Button id="EditButton" BackColor="Black" ForeColor="LawnGreen" Text="Edit" OnClick="EditButton_Click" runat="server"/>
                    </li>
                    <li>
                        <br />
                    </li>
                    <li>
                        <asp:Button id="DeleteButton" BackColor="Black" ForeColor="LawnGreen" Text="Delete" OnClick="DeleteButton_Click" runat="server"/>
                    </li>
                </ul>
            </div>
            <br />
            <br />
        </asp:Panel>
    </center>
</asp:Content>
