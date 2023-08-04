<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserListTabularPage.aspx.cs" Inherits="RegistrationPageAsp.UserListPageWithoutGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="./Content/UserListTabularPage.css">
      <link  />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="display">
            <h1>User Details</h1>
            <div id="container">
                <div class="heading">
                    <div>UserId</div>
                    <div>Name</div>
                    <div>Email</div>
                    <div>Roles</div>  
                </div>
            </div>
            <asp:Button ID="AddUser" runat="server" OnClick="AddUser_Click" Text="Add User" />
       </div>
    </form>
</body>
    <script src="./Scripts/UserListTabularPage.js"></script>
</html>
