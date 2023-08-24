function uploadData(objectData){
    localStorage.setItem("localdata",`${JSON.stringify(objectData)}`)
    location.href="/DisplayPage.html"
}

{/* <asp:GridView runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ID="gridview" OnRowEditing="OnRowEditing" 
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
       </asp:GridView> */}