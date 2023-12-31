﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersListPage.aspx.cs" Inherits="RegistrationPageAsp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="./Content/UsersListPage.css"><link  />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <h2>Users Data</h2>
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridview" OnRowEditing="OnRowEditing"  
                 OnRowDeleting="OnRowDeleting" EmptyDataText="No Users To Show" DataKeyNames="UserId" 
                GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="UserId" ItemStyle-Width="50">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id" Text='<%# Eval("UserId") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note" Text='<%# Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Email" ItemStyle-Width="170">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note2" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Roles" ItemStyle-Width="180">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Roles" Text='<%# Eval("Roles") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="45" 
                         ControlStyle-BorderStyle="None" ControlStyle-Font-Underline="false" /> 
                    <asp:ButtonField ButtonType="Link" Text="Delete" ControlStyle-ForeColor="Red" CommandName="delete" 
                        ItemStyle-Width="60" ControlStyle-Font-Underline="false" />
                </Columns>
            </asp:GridView><br /> <br />
            <asp:Button ID="AddUser" runat="server" OnClick="AddUser_Click" Text="Add User" /> 

        </div><br /><br />

    </form>
</body>
</html>
