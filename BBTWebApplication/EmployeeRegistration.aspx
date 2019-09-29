<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="BBTWebApplication.EmployeeRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: #e6faff; text-align: center; padding-top: 150px; font-family: arial;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="BBT New Employee Registration"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please fill out all of the fields. Click &quot;Submit&quot; to finalize the employee registration."></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernameBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter a username." ControlToValidate="usernameBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passwordBox" type="password" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter a password." ControlToValidate="passwordBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="confirmPasswordBox" type="password" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="You must enter a password." ControlToValidate="confirmPasswordBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="You must confirm your password" ControlToValidate="confirmPasswordBox" ControlToCompare="passwordBox" EnableClientScript="False" Font-Italic="True"></asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="nameBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter a name." ControlToValidate="nameBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Address: "></asp:Label>
            <asp:TextBox ID="addressBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter an address." ControlToValidate="addressBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Postal Code: "></asp:Label>
            <asp:TextBox ID="postalcodeBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter a postal code." ControlToValidate="postalcodeBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Postal code format 1A1B2B." ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$" ControlToValidate="postalcodeBox" EnableClientScript="False" Font-Italic="True"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Phone: "></asp:Label>
            <asp:TextBox ID="phoneBox" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must enter a phone number." ControlToValidate="phoneBox" EnableClientScript="False" Font-Italic="True"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Phone format 416XXXXXXX." ValidationExpression="^\d{10}$" ControlToValidate="phoneBox" EnableClientScript="False" Font-Italic="True"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Label ID="successLabel" runat="server" Text="Successfully registered!"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:Button ID="submitButton" runat="server" Text="Submit" Width="200px" BackColor="#FFE7B3" OnClick="submitButton_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
