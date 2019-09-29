<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BBTWebApplication._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #e6faff; text-align: center; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/bbt_banner.jpg" Width="500px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Welcome to Vinay's Bubble Tea Shop!" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please select an option below:"></asp:Label>
            <br />
            <br />
            <asp:Button ID="employeeButton" runat="server" Text="Employee" BackColor="#FFE7B3" OnClick="employeeButton_Click" Width="200px" />
            <br />
            <br />
            <asp:Button ID="customerButton" runat="server" Text="Customer" BackColor="#FFE7B3" OnClick="customerButton_Click" Width="200px" />
        </div>
    </form>
</body>
</html>
