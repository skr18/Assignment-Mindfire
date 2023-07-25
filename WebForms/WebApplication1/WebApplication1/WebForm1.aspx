<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style type="text/css">
    </style>
<body>
    <form id="form1" runat="server">
        <div style="background-color:antiquewhite; display:flex; flex-direction:row; width: 952px; height: 60px;">
            <h1 style="width: 754px; height: 49px;margin:auto ">Hello sujeet Welcome to Asp.Net :)</h1>
        </div>
        <div>
            <br />
            <asp:Label AssociatedControlID="textbox1"  Id="Label1" runat="server" ToolTip="User Name" Width="10%">Enter Your Name: </asp:Label>
            <asp:TextBox ID="textbox1" runat="server" ToolTip="User Name"/> <br /><br />

             <asp:Label AssociatedControlID="FileUpload1" ID="Label2" ToolTip="Upload File"  runat="server" Width="10%"  >Upload File:</asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Upload File"/> <br /><br />

            <asp:Button Id="BtnUpload" runat="server" OnClick="uploadFile" Text="upload"/><br /><br />
            <asp:Label runat="server" ID="FileUploadStatus"></asp:Label> <br/><br />

            <asp:HyperLink ID="HyperLink1" runat="server"  Text="Just Click It" NavigateUrl="https://sujeetrath-portfolio.vercel.app/" Target="_blank"></asp:HyperLink>  <br /> <br />

            
             <asp:RadioButton AccessKey="m" ID="RadioButton1" runat="server" Text="Male" GroupName="gender"/>  
             <asp:RadioButton AccessKey="f" ID="RadioButton2" runat="server" Text="Female" GroupName="gender" /> <br /> <br /> 
            
            <asp:Calendar ID="calender" runat="server" SelectedDate="2001-12-10"></asp:Calendar> <br /> <br />

            <asp:Label Text="Hobbies: " runat="server"></asp:Label>
            <asp:CheckBox runat="server" Text="Plyaing Video Games" />
            <asp:CheckBox runat="server" Text="Watching Movies"/> <br /> <br />
            
            <asp:Button ID="Button1" runat="server" Text="Click here To Submit" />  <br /> <br />



        </div>
    </form>
</body>
</html>
