<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="FuelManagementSystem.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="./Content/LoginPage.css"><link  />
</head>
<body>
    <form id="form1" runat="server">
        <div id="heading">
            <h1>Fly high.</h1>
            <h1>above the sky.</h1>
            <h4>comfortable, secure, your way ***</h4>

        </div>
       <div class="container">
            <h1>Skr Travel's</h1>
            <div>
                <label class="mr-40">Name:</label>
                <asp:TextBox runat="server" ID="nameInp" ></asp:TextBox><br /><br /><br />
            </div>
            <div>

                <label>Password:</label>
                <asp:TextBox TextMode="Password" runat="server" ID="passwordInp"></asp:TextBox><br /><br /><br />
            </div>
            <div>
                <asp:Button runat="server" CssClass="btn" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" />
                
            </div>
        </div>
    </form>
</body>
</html>
