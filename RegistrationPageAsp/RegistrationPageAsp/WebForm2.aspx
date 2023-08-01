<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="RegistrationPageAsp.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Users Data</h2>
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridview" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
                 OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" EmptyDataText="No Records To Show" DataKeyNames="UserId">
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-Width="150">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id" Text='<%# Eval("UserId") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note" Text='<%# Eval("FirstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note2" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Roles" Text='<%# Eval("Roles") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
