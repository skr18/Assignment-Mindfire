<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="RegistrationPageAsp.WebUserControl1" %>

 <asp:GridView runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ID="gridview" OnRowEditing="OnRowEditing" 
     OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" 
     EmptyDataText="No Notes To Show" DataKeyNames="NoteId" GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-Width="80">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id" Text='<%# Eval("NoteId") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Note" ItemStyle-Width="180">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note" Text='<%# Eval("Note") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="EditNote" Text='<%# Eval("Note") %>'  ></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ItemStyle-Width="105"
                        ControlStyle-BorderStyle="None" ControlStyle-Font-Underline="false" /> 
                    <asp:ButtonField ButtonType="Link" Text="Delete" ControlStyle-ForeColor="Red"
                        CommandName="delete" ItemStyle-Width="60" ControlStyle-Font-Underline="false" />
                </Columns>
            </asp:GridView>

                <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-top:10px; " >
                    <tr>
                        <td style="width: 200px">
                            <asp:TextBox ID="txtNote" runat="server" Width="170" placeholder="Enter Your Note" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ClientIDMode="Static" ID="btnAdd" runat="server" Text="Add" OnClick="Insert"/>
                        </td>
                   </tr>
              </table>
<br />