<%@ Page Title="Add Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addItem.aspx.cs" Inherits="CS691Project.addItem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <h1 style="color:lawngreen">Add an Item</h1>
        <div runat="server" style="padding:10px">
            <asp:Label runat="server" ForeColor="LawnGreen" Text="Choose the Restaraunt: "></asp:Label>
            <asp:DropDownList id="restarauntDropDown" runat="server" BackColor="Black" ForeColor="LawnGreen" AutoPostBack="true" OnSelectedIndexChanged="restarauntDropDown_SelectedIndexChanged">
            <asp:ListItem Value="0" Text="Developer's Dwelling"></asp:ListItem>
            <asp:ListItem Value="1" Text="The Local Cuisine"></asp:ListItem>
            <asp:ListItem Value="2" Text="Grandma's Cooking"></asp:ListItem>
        </asp:DropDownList>
        </div>
    <asp:Panel Width="80%" BackColor="#676565" runat="server" HorizontalAlign="Center">
        <div width="60%" style="padding:10px">
            <asp:Label ForeColor="black" runat="server">Menu Photo: </asp:Label>
            <asp:DropDownList id="photoDropDown" runat="server" BackColor="Black" ForeColor="LawnGreen">
                <asp:ListItem Text="Pizza" Value="Images/pizza.jpg">Pizza</asp:ListItem>
                <asp:ListItem Text="Unknown Food" Value="Images/badFood.jpg">Unknown Food</asp:ListItem>
                <asp:ListItem Text="Burger" Value="Images/burger.jpg">Burger</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div width="60%" style="padding:10px">
            <asp:Label ForeColor="black" runat="server">Menu Item: </asp:Label>
            <asp:TextBox id="itemTextBox" BackColor="Black" ForeColor="LawnGreen" Width="60%" runat="server"></asp:TextBox>
        </div>
        <div width="60%" style="padding:10px">
            <asp:Label ForeColor="black" runat="server">Menu Price: </asp:Label>
            <asp:TextBox id="itemPrice" BackColor="Black" ForeColor="LawnGreen" Width="60%" runat="server"></asp:TextBox>
        </div>
        <div width="60%" style="padding:10px">
            <asp:Label ForeColor="black" runat="server">Menu Description: </asp:Label>
            <textarea id="itemDescriptionTextArea" style="background-color:black; color:lawngreen; max-width:60%" runat="server"></textarea>
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
            <div style="width:50%; float:left; padding:10px">
                <asp:ListBox id="listboxItems" runat="server" BackColor="Black" ForeColor="LawnGreen" Width="80%">
                    
                </asp:ListBox>
            </div>
            <div style="padding:10px">
                <ul style="list-style:none">
                    <li>
                        <asp:Button id="EditButton" BackColor="Black" ForeColor="LawnGreen" Text="Edit" OnClick="EditButton_Click" runat="server"/>
                    </li>
                    <li>
                        <br />
                    </li>
                    <li>
                        <asp:Button id="DeleteButton" BackColor="Black" ForeColor="LawnGreen" Text="Delete" OnClick="DeleteButton_Click" runat="server" autopostback="true"/>
                    </li>
                </ul>
            </div> 
        </asp:Panel>
            <hr />
            <br />
            <br />
        <h1 style="color:lawngreen">Modify Welcome Message</h1>
        <asp:Panel Width="80%" BackColor="#676565" runat="server" HorizontalAlign="Center">
            <div width="60%" style="padding:10px">
            <asp:Label ForeColor="black" runat="server">Welcome Message: </asp:Label>
            <textarea id="welcomeTextArea" style="background-color:black; color:lawngreen; max-width:60%" runat="server"></textarea>
            </div>
            <br />
            <asp:Button id="updateWelcome" BackColor="Black" ForeColor="LawnGreen" Text="Update" OnClick="updateWelcome_Click" runat="server"/>
        
            
        </asp:Panel>

    </center>
</asp:Content>
