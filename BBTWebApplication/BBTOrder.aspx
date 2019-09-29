<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BBTOrder.aspx.cs" Inherits="BBTWebApplication.BBTOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #FFE7B3; text-align: center; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="Image1" runat="server" Height="200px" ImageUrl="~/bbtorder.jpg" Width="500px" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="BBT Order"></asp:Label>
            <br />
            <br />
            <div style="text-align: left; margin-left: 400px;">
                <asp:Label ID="customerDataLabel" runat="server" Text="Label"></asp:Label>
            </div>
            
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please fill in the following details about your order."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Date (dd/MM/20YY): "></asp:Label>
            <asp:TextBox ID="dateBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a date." ControlToValidate="dateBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="dateBox" EnableClientScript="False" ErrorMessage="Incorrect format. dd/MM/20YY format only." ValidationExpression="(0[1-9]|[1-2][0-9]|[3][0-1])[/](0[1-9]|1[0-2])[/](19[0-9][0-9]|20[0-9][0-9])" Font-Italic="True"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Flavour: "></asp:Label>
            <asp:DropDownList ID="flavourBox" runat="server" Width="200px">
                <asp:ListItem>Original Bubble Tea</asp:ListItem>
                <asp:ListItem>Fruit Bubble Tea</asp:ListItem>
                <asp:ListItem>Mango Green Tea</asp:ListItem>
                <asp:ListItem>Coffee Milk Bubble Tea</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Ice: "></asp:Label>
            <asp:DropDownList ID="iceBox" runat="server" Width="200px">
                <asp:ListItem>Extra</asp:ListItem>
                <asp:ListItem>Some</asp:ListItem>
                <asp:ListItem>Less</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Sugar: "></asp:Label>
            <asp:DropDownList ID="sugarBox" runat="server" Width="200px">
                <asp:ListItem>Extra</asp:ListItem>
                <asp:ListItem>Some</asp:ListItem>
                <asp:ListItem>Less</asp:ListItem>
                <asp:ListItem>None</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Jelly (Note:+$0.50): "></asp:Label>
            <asp:DropDownList ID="jellyBox" runat="server" Width="200px">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="submitButton" runat="server" BackColor="#E6FAFF" Text="Submit" Width="200px" OnClick="submitButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" BackColor="#E6FAFF" Text="Back" Width="200
                px" OnClick="backButton_Click" />
            <br />
            <br /><asp:Button ID="historyButton" runat="server" BackColor="#E6FAFF" Text="Order History" Width="200px" OnClick="historyButton_Click" />
            
            <br />
            <br />
            <asp:Label ID="sqlErrorLabel" runat="server" Font-Italic="True" Text="Opps, something went wrong. Please try again."></asp:Label>
            <br />
            <br />
            <asp:Label ID="receiptDataLabel" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>

