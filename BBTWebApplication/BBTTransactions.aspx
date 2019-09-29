<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BBTTransactions.aspx.cs" Inherits="BBTWebApplication.BBTTransactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #e6faff; text-align: center; padding-top: 150px; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="BBT Transactions"></asp:Label>
            <br />
            <br />
            <div style="text-align: left; margin-left: 400px;">
                <asp:Label ID="employeeDataLabel" runat="server" Text="Label"></asp:Label>
            </div>
            
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Click &quot;Show All&quot; to show all receipts to date. Click &quot;Edit&quot; to edit a receipt or &quot;Delete&quot; to delete a receipt."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="ReceiptId: "></asp:Label>
            <asp:Label ID="receiptIdLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Date: "></asp:Label>
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
            <asp:Label ID="Label8" runat="server" Text="Total Price: $"></asp:Label>
            <asp:TextBox ID="totalPriceBox" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter the total price." ControlToValidate="totalPriceBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="totalPriceBox" EnableClientScript="False" ErrorMessage="Incorrect format. Please type in a dollar amount." ValidationExpression="\d+[.]{0,1}\d+" Font-Italic="True"></asp:RegularExpressionValidator>
            <br />
            <br />
            <br />
            <br />
            <asp:ListBox ID="outputBox" runat="server" Height="300px" Width="500px" OnSelectedIndexChanged="outputBox_SelectedIndexChanged"></asp:ListBox>
            <br />
            <asp:Label ID="pleaseSelectLabel" runat="server" Font-Italic="True" Text="Please select a record to continue."></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="showAllButton" runat="server" Text="Show All" Width="200px" BackColor="#FFE7B3" OnClick="showAllButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="editButton" runat="server" Text="Edit" Width="200px" BackColor="#FFE7B3" OnClick="editButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="deleteButton" runat="server" Text="Delete" Width="200px" BackColor="#FFE7B3" OnClick="deleteButton_Click" />
            <br />
            <br />
            <asp:Button ID="backButton" runat="server" BackColor="#FFE7B3" Text="Back" Width="200
                px" OnClick="backButton_Click" />
            <br />
            <br />
            <asp:Label ID="sqlErrorLabel" runat="server" Font-Italic="True" Text="Opps, something went wrong. Please try again."></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
