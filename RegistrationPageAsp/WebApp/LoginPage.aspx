<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RegistrationPageAsp.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="./Content/LoginPage.css"><link  />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Login</h1>
            <div>

                <label>Name:</label>
                <asp:TextBox runat="server" ID="nameInp" ></asp:TextBox><br /><br /><br />
            </div>
            <div>

                <label>Password:</label>
                <asp:TextBox TextMode="Password" runat="server" ID="passwordInp"></asp:TextBox><br /><br /><br />
            </div>
            <div>
                <asp:Button runat="server" CssClass="btn" ID="loginBtn" Text="Login" OnClick="loginBtn_Click" />
                <asp:Button runat="server" CssClass="btn" ID="signupBtn" Text="SignUp" OnClick="signupBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
