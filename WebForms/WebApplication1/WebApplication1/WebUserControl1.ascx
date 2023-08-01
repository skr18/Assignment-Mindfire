<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebApplication1.WebUserControl1" %>


 <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridview" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
                 OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" EmptyDataText="No Records To Show" DataKeyNames="NoteId">
                <Columns>
                    <asp:TemplateField HeaderText="NoteId" ItemStyle-Width="150">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id" Text='<%# Eval("NoteId") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Note" ItemStyle-Width="150">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note" Text='<%# Eval("Note") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="EditNote" Text='<%# Eval("Note") %>'  ></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                </Columns>
            </asp:GridView>

                <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse" >
                    <tr>
                        <td style="width: 150px">
                            Note:<br />
                            <asp:TextBox ID="txtNote" runat="server" Width="140" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" Enabled="false" />
                        </td>
                   </tr>
              </table>
<br />
<asp:Label ID="Label1" runat="server" ForeColor="White" Text=" "></asp:Label>
