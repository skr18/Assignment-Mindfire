<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlDocuments.ascx.cs" Inherits="RegistrationPageAsp.WebUserControl2" %>

 <asp:GridView runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ID="gridview" 
      OnRowCommand="gridview_RowCommand"
     EmptyDataText="No Documents To Show" DataKeyNames="DocumentID" GridLines="Horizontal" HorizontalAlign="Center">
                <Columns>
                   
                      <asp:TemplateField HeaderText="Documents" ItemStyle-Width="180">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Note" Text='<%# Eval("DocumentUrl") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Uploaded By" ItemStyle-Width="150">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id2" Text='<%# Eval("AddedBy") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Uploaded On" ItemStyle-Width="200">
                        <ItemTemplate>    
                            <asp:Label runat="server" ID="Id1" Text='<%# Eval("Date") %>'> </asp:Label>                        
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="" ItemStyle-Width="110">
                        <ItemTemplate>
                           <asp:LinkButton runat="server" Text="Download" ControlStyle-ForeColor="blue" CommandName="download"
                        ItemStyle-Width="60" ControlStyle-Font-Underline="false" CommandArgument='<%# Eval("DocumentID") %>' />
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                   
                   
                </Columns>
            </asp:GridView><br /><br />
            <asp:FileUpload ID="FileUpload" runat="server" />     
            <asp:Button ID="fileUploadBtn" runat="server" OnClick="fileUploadBtn_Click" Text="Upload" />  

             
<br />
<br />

      