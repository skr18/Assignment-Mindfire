<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="RegistrationPageAsp.WebUserControl1" %>

        <div class="display_note">
            <div id="container_note">
                <div class="heading_note">
                    <div>NoteId</div>
                    <div>Note</div>
                </div>
            </div>
       </div>
            
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