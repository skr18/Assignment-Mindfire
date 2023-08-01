<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>


<!DOCTYPE html>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="sujeet" TagName="code"  %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 26px;
        }

        .auto-style3 {
            height: 26px;
            width: 93px;
        }

        .auto-style4 {
            width: 93px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">First value</td>
                <td class="auto-style2">
                    <asp:TextBox ID="firstval" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Second value</td>
                <td>
                    <asp:TextBox ID="secondval" runat="server"></asp:TextBox>
                    It should be greater than first value</td>
            </tr>
            <tr>
                <td class="auto-style4">Third value</td>
                <td>
                    <asp:TextBox ID="secondval2" runat="server"></asp:TextBox>
                    It should be greater than 10 and less then20 value</td>
            </tr>
            <tr>
                <td class="auto-style4">Fourth value</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="save" />
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="2save" OnClick="check" CausesValidation="false" />
                </td>
            </tr>

        </table>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="secondval"
            ControlToValidate="firstval" Display="None" ErrorMessage="Enter valid value" ForeColor="Red"
            Operator="LessThan" Type="Integer"></asp:CompareValidator> 

        <asp:RangeValidator  ID="CompareValidator3" runat="server" MaximumValue="20" MinimumValue="10"
            ControlToValidate="secondval2" Display="None" ErrorMessage="Enter valid range" ForeColor="Red"
            Operator="LessThan" Type="Integer"></asp:RangeValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"   
            ErrorMessage="Please enter valid email" ForeColor="Red" Display="None"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" > 
        </asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <asp:Label ID="data" runat="server"></asp:Label>
        <!-- <sujeet:code id="usercontrol" runat="server" /> -->
        
    </form>
</body>
</html>
