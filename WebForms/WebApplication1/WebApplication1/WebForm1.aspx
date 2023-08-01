<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" MasterPageFile="~/Site.Master" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
        <style type="text/css">
         #form1{
             background-color:grey;
         }
    </style>
    <main aria-labelledby="title">
   
    <div id="form1" runat="server">
        <div style="background-color:antiquewhite; display:flex; flex-direction:row; width: 952px; height: 60px;">
            <h1 style="width: 754px; height: 49px;margin:auto ">Hello sujeet Welcome to Asp.Net :)</h1>
        </div>
        <div>
            <br />
            <asp:Label AssociatedControlID="textbox1"  Id="Label1" runat="server" ToolTip="User Name"
                Width="15%">Enter Your Name: </asp:Label>
            <asp:TextBox ID="textbox1" runat="server" ToolTip="User Name"/> <br /><br />

             <asp:Label AssociatedControlID="FileUpload1" ID="Label2" ToolTip="Upload File" 
                 runat="server" Width="15%"  >Upload File:</asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Upload File" 
                AllowMultiple="true" /> <br /><br />

            <asp:Button Id="BtnUpload" runat="server" OnClick="uploadFile" Text="upload"/><br />
            <asp:Label runat="server" ID="FileUploadStatus"></asp:Label> <br/><br />

            <asp:HyperLink ID="HyperLink1" runat="server"  Text="Just Click It" 
                NavigateUrl="https://sujeetrath-portfolio.vercel.app/" Target="_blank">
            </asp:HyperLink><br/><br/>

            
             <asp:RadioButton AccessKey="m" ID="RadioButton1" runat="server" Text="Male" GroupName="gender"/>  
             <asp:RadioButton AccessKey="f" ID="RadioButton2" runat="server" Text="Female" GroupName="gender"/><br/><br/> 
            
            <asp:Calendar ID="calender" runat="server" SelectedDate="2001-12-10"></asp:Calendar> <br /> <br />

             <asp:Button ID="Button2" runat="server" Text="Download" OnClick="DownloadFile" />  <br /> <br />
            <asp:Label AssociatedControlID="textbox1"  Id="Label3" runat="server" ToolTip="User Name" 
                Width="20%">Enter Your Name: </asp:Label><br /><br />
            
            <asp:Label Text="Hobbies: " runat="server"></asp:Label>
            <asp:CheckBox runat="server" Text="Plyaing Video Games" />
            <asp:CheckBox runat="server" Text="Watching Movies"/> <br /> <br />

                    <p>Select a City of Your Choice</p>  
                    <div>  
                        <asp:DropDownList ID="DropDownList1" runat="server" >  
                        <asp:ListItem Value="">Please Select</asp:ListItem>  
                        <asp:ListItem>New Delhi </asp:ListItem>  
                        <asp:ListItem>Greater Noida</asp:ListItem>  
                        <asp:ListItem>NewYork</asp:ListItem>  
                        <asp:ListItem>Paris</asp:ListItem>  
                        <asp:ListItem>London</asp:ListItem>  
                    </asp:DropDownList>  
                    </div>  
                    <br />  
                    <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Submit" />  
                    <br />  
                    <asp:Label ID="Label4" runat="server" EnableViewState="False"></asp:Label><br /><br />

                    <label style="width:10%" >Add New City</label>
                    <asp:TextBox ID="textbox2" runat="server" ToolTip="Enter City Name" placeholder="Enter city name" /> <br /><br />
                     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click2" Text="Add" />  <br />
                     <asp:Label ID="Label5" runat="server" EnableViewState="False"></asp:Label> <br /><br />
   

            <b>Data List Using EF</b><br />
             <label style="width:10%" >Add New Data</label><br /><br />
                    <asp:TextBox ID="textbox3" runat="server" ToolTip="Enter City Name" placeholder="Enter Name" /> <br /><br />
                    <asp:TextBox ID="textbox4" runat="server" ToolTip="Enter City Name" placeholder="Enter Age" /> <br /><br />
                     <asp:Button ID="Button4" runat="server" OnClick="Button1_Click3" Text="Add Data" />  <br />
                     <asp:Label ID="Label6" runat="server" EnableViewState="False"></asp:Label> <br /><br />

            <asp:DataList ID="DataList2" runat="server" DataKeyField="UserId23" OnEditCommand="Edit1" OnCancelCommand="Cancel1" OnUpdateCommand="update1">  
            <ItemTemplate>   
                UserId:
                <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId23") %>' /><br />
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName1") %>' />  <br />
                Age:
                <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age1") %>' /><br />
                <asp:LinkButton ID="Edt" CommandName="Edit"  runat="server" Text="Edit"></asp:LinkButton><br /><br />
            </ItemTemplate>
                <EditItemTemplate>
                      UserId:
                    <asp:TextBox ID="UserIdLabel" runat="server" Text='<%# Eval("UserId23") %>' /><br />
                    FirstName:
                    <asp:TextBox ID="FirstNameText" runat="server" Text='<%# Eval("FirstName1") %>' />  <br />
                    Age:
                    <asp:TextBox ID="AgeText" runat="server" Text='<%# Eval("Age1") %>' /><br />

                    <asp:LinkButton ID="update" runat="server" CommandName="update" Text="Update"></asp:LinkButton><br />
                    <asp:LinkButton ID="cancel" runat="server" CommandName="cancel" Text="Cancel"></asp:LinkButton><br />
                    
        
                </EditItemTemplate>
                
        </asp:DataList>  <br /><br />

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TestDBConnectionString2 %>"
                ProviderName="<%$ ConnectionStrings:TestDBConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [showDetails]">
            </asp:SqlDataSource>
           

            <b>Grid View Using EF</b><br />
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridview" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" 
                 OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" EmptyDataText="No Records To Show" DataKeyNames="UserId">
                <Columns>
                   
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                </Columns>
            </asp:GridView>
             <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                    <tr>
                        <td style="width: 150px">
                            Name:<br />
                            <asp:TextBox ID="txtName" runat="server" Width="140" />
                        </td>
                        <td style="width: 150px">
                            Age:<br />
                            <asp:TextBox ID="txtAge" runat="server" Width="140" />
                        </td>
                        <td style="width: 100px">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
                        </td>
                   </tr>
              </table>
        </div>
    </div>
</main>
</asp:Content>
