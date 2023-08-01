<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" MasterPageFile="~/Site.Master" Inherits="WebApplication1.UserForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            <%@ Register Src="~/WebUserControl1.ascx" TagPrefix="sujeet" TagName="code"  %>
    <main aria-labelledby="title">
        <div>
            <h1>User Form</h1>
             <asp:Label runat="server" Text="Enter-Id"></asp:Label>
                <asp:TextBox  runat="server" ID="inp" ></asp:TextBox>
                <asp:Button runat="server" ID="btn" Text="Find" OnClick="FindData" /><br /><br />


                <sujeet:code id="usercontrol" runat="server" objType="user"/>
        </div>
    </main>
</asp:Content>
