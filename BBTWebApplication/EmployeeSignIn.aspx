<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSignIn.aspx.cs" Inherits="BBTWebApplication.EmployeeSignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #e6faff; text-align: center; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/bbtemployee.jpg" Width="500px" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Employee Sign In"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please sign into your employee account below:"></asp:Label>
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
            <asp:Label ID="askManagerLabel" runat="server" Font-Italic="True" Text="Please ask your manager to set up your account."></asp:Label>
            <br />
            <br />
            <asp:Button ID="loginButton" runat="server" BackColor="#FFE7B3" OnClick="loginButton_Click" Text="Login" Width="200px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="newEmployeeButton" runat="server" BackColor="#FFE7B3" OnClick="newEmployeeButton_Click" Text="New Employee?" Width="200px" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" BackColor="#FFE7B3" Text="Back" Width="200
                px" OnClick="backButton_Click" />
            <br />
            <br />
            <asp:Label ID="sqlErrorLabel" runat="server" Font-Italic="True" Text="Opps, something went wrong. Please try again."></asp:Label>
        </div>
    </form>
</body>
</html>
