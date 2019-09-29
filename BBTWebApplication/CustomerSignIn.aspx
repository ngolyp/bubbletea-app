<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSignIn.aspx.cs" Inherits="BBTWebApplication.CustomerSignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #FFE7B3; text-align: center; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/bbtcustomer.jpg" Width="500px" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Customer Sign In"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please sign into your customer account below:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernameBox" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a username." ControlToValidate="usernameBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passwordBox" runat="server" type="password"></asp:TextBox>
        &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a password." ControlToValidate="passwordBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="userpassErrorLabel" runat="server" Font-Italic="True" Text="Incorrect username and/or password. Please try again."></asp:Label>
            <br />
            <br />
            <asp:Button ID="loginButton" runat="server" BackColor="#E6FAFF" OnClick="loginButton_Click" Text="Login" Width="200px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="newCustomerButton" runat="server" BackColor="#E6FAFF" Text="New Customer?" Width="200px" OnClick="newCustomerButton_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" BackColor="#E6FAFF" Text="Back" Width="200
                px" OnClick="backButton_Click" />
            <br />
            <br />
            <asp:Label ID="sqlErrorLabel" runat="server" Font-Italic="True" Text="Opps, something went wrong. Please try again."></asp:Label>
        </div>
    </form>
</body>
</html>
