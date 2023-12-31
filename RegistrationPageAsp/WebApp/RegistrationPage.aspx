﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="RegistrationPageAsp.WebForm1" EnableEventValidation="true"  %>

<!DOCTYPE html>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="sujeet" TagName="code"  %>

<html xmlns="http://www.w3.org/1999/xhtml">
    

<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
     <link rel="stylesheet" href="">
      <link  />
</head>
<body>
    
    <form runat="server">
          <ul id="navbar">
              <li><a class="active" id="home" displayid="">Home</a></li>
              <li><a id="note">Notes</a></li>
              <li><a id="document">Documents</a></li>
              <li><a id="logout">Logout</a></li>
              
          </ul>

        <div class="container" id="userProfile" displayid="home">
            
            <div class="heading">
                <h1>REGISTRATION FORM</h1>
                <div class="logo">
                    <asp:Image runat="server" ImageUrl="" ID="photo" ClientIDMode="Static" />
                    
                </div>
            </div>
            <div>
                <div class="box">

                    <h3 class="title">Personal Details</h3>
                    <br>
                    <div class="p-details">

                        <div class="col1">

                            <label for="firstnameinp">
                                First Name:
                                    <br>
                                <span id="spanFirstName">*First name requried </span>
                            </label>

                            <input runat="server" id="firstnameinp" errorid="spanFirstName" data_id="userFirstName" type="text" placeholder="Enter First Name" /><br>
                            <br>

                            <label for="lastnameinp">
                                Last Name:
                                    <br>
                                <span id="spanLastName">*Last name requried </span>
                            </label>
                            <input id="lastnameinp" errorid="spanLastName" data_id="userLastName" type="text" placeholder="Enter Last Name"><br>
                            <br>

                            <label for="emailinp">
                                Email:
                                    <br>
                                <span id="spanEmail">*Email requried</span>
                            </label>
                            <input id="emailinp" errorid="spanEmail" data_id="userEmail" type="email" placeholder="Enter Email"><br>
                            <br> 

                            <label for="passinp">
                                Password:
                                    <br>
                                <span id="spanPass">*Password requried</span>
                            </label>
                            <input id="passinp" errorid="spanPass" data_id="userPassword" type="password" placeholder="Enter Password"><br>
                            <br>
                        </div>

                        <div class="col1">

                            <label for="dobinp">
                                Dob:
                                    <br>
                                <span id="spanDob">*Dob requried </span>
                            </label>
                            <input type="date" errorid="spanDob" data_id="userDob" name="" id="dobinp"><br>
                            <br>

                            <label for="genderinp">
                                Gender:
                                    <br>
                                <span id="spanGender">*Gender requried </span>
                            </label>
                            <select name="" id="genderinp" errorid="spanGender" data_id="userGender">
                                <option selected disabled hidden>Tap To Select</option>
                                <option value="Male">Male</option>
                                <option value="Female">Female</option>
                                <option value="Rather not say">Rather not say</option>
                            </select>
                            <br>
                            <br>

                            <label for="profileimg">Profile photo:</label>
                            <input id="profileimg" runat="server" type="file" accept="image/png, image/gif, image/jpeg" name="" /><br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <br>


            <div>
                <div class="box">
                    <h3 class="title">Permanent Address</h3>
                    <br>
                    <div class="p-details" id="permanent-details">

                        <div class="col1">

                            <label for="AddressLine1">
                                Address Line1:
                                <br>
                                <span id="spanAddress">*Address requried </span>
                            </label>
                            <input type="text" id="AddressLine1" placeholder="Address" data_id="userPermanentAddress1" errorid="spanAddress"><br>
                            <br>

                            <label for="AddressLine2">Address Line2:</label>
                            <input type="text" id="AddressLine2" placeholder="Address" data_id="userPermanentAddress2"><br>
                            <br>

                            <label for="postal">
                                Postal Code:
                                <br>
                                <span id="spanpostal">*postal-code requried </span>
                            </label>
                            <input type="number" errorid="spanpostal" name="" id="postal" data_id="userPermanentPostal" placeholder="postal code"><br>
                            <br>
                        </div>

                        <div class="col1">

                            <label for="country">
                                country:
                                <br>
                                <span id="spancountry">*Country requried </span>
                            </label>
                            <select name="" id="country" errorid="spancountry" data_id="userPermanentCountry">
                                <option selected disabled hidden>Tap To Select Country</option>
                            </select>
                            <br>
                            <br>

                            <label for="state">
                                State:
                                <br>
                                <span id="spanstate">*State requried </span>
                            </label>
                            <select name="" id="state" errorid="spanstate" data_id="userPermanentState">
                                <option selected disabled hidden>Tap To Select State</option>
                            </select>
                            <br>
                            <br>

                            <label for="city">
                                City:
                                <br>
                                <span id="spancity">*City requried </span>
                            </label>
                            <input type="text" placeholder="Enter City" name="" id="city" data_id="userPermanentCity">
                                
                            </input>
                            <br>
                            <br>
                        </div>

                    </div>

                </div>
                <br>
            </div>

            <div>

                <div class="box ">
                    <h3 class="title">Present Address</h3>

                    <div class="permanentTitle" id="copyDataDiv">
                        <label class="lableCheckbox" for="copydataCheckbox">If Same As Permanent Address</label>
                        <input type="checkbox" name="" id="copydataCheckbox"><br>
                        <br>
                    </div>
                    <div class="p-details" id="present-details">

                        <div class="col1">

                            <label for="presentAddressLine1">
                                Address Line1:
                                <br>
                                <span id="spanpadl1">*Address requried </span>
                            </label>
                            <input type="text" id="presentAddressLine1" errorid="spanpadl1" placeholder="Address" data_id="userPresentAddress1"><br>
                            <br>


                            <label for="presentAddressLine2">Address Line2:</label>
                            <input type="text" data_id="userPresentAddress2" id="presentAddressLine2" placeholder="Address"><br>
                            <br>


                            <label for="present-postal">
                                Postal Code:
                                <br>
                                <span id="spanp-postal">*postal-code requried </span>
                            </label>
                            <input type="text" errorid="spanp-postal" data_id="userPresentPostal" name="" id="present-postal" placeholder="postal code"><br>
                            <br>
                        </div>

                        <div class="col1">

                            <label for="presentCountry">
                                country:
                                <br>
                                <span id="spanp-country">*Country requried </span>
                            </label>
                            <select name="" id="presentCountry" errorid="spanp-country" data_id="userPresentCountry">
                                <option selected disabled hidden>Tap To Select Country </option>
                            </select>
                            <br>
                            <br>

                            <label for="presentState">
                                State:
                                <br>
                                <span id="spanp-state">*State requried </span>
                            </label>
                            <select name="" id="presentState" errorid="spanp-state" data_id="userPresentState">
                                <option selected disabled hidden>Tap To Select State</option>
                            </select>
                            <br>
                            <br>

                            <label for="presentCity">
                                City:
                                <br>
                                <span id="spanp-city">*City requried </span>
                            </label>
                            <input type="text" placeholder="Enter City" name="" id="presentCity"  data_id="userPresentCity">
                               
                            </input>
                            <br>
                            <br>
                        </div>

                    </div>

                </div>
                <br>
            </div>

            <div class="lastSection">
                <br>
                <div>
                    <button id="hobby">Select your Roles</button>                
                       
                    <div class="hobbies" id="rolesDiv">
                         <asp:CheckBoxList ID="RolesCheckBox" runat="server" ClientIDMode="Static">
                        </asp:CheckBoxList>
                    </div>
                </div>
                <br>
                <br>


                <div>
                    <label for="subcriptionCheckbox">Subcribe To News Letter</label>
                    <input type="checkbox" attrchk="userSubcription" name="" id="subcriptionCheckbox"><br>
                    <br>
                </div>
                <asp:Button runat="server" class="submit" id="submitButton" text="Submit"/>
                 <asp:Button runat="server" class="submit" id="BackButton" text="Go Back"/>
                <br>
        </div>
    </div>


       <div class="container hide" id="userNotes" >
             <h1>Your Notes</h1>
              <div id="UserNotes" class="UserNotes">
                <div class="display_note">
                     <div class="heading_note">
                            <div>Note</div>
                            <div>Created By</div>
                            <div>Created On</div>
                        </div>
                    <div id="container_note">
                       
                    </div><br /><br />
                    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse; margin-top:10px; " >
                    <tr>
                        <td style="width: 200px">
                            <asp:TextBox ClientIDMode="Static" ID="txtNote" Rows="4" Columns="40" TextMode="MultiLine" runat="server" placeholder="Enter Your Note" />
                        </td>
                        <td style="width: 170px">
                            <asp:Button ClientIDMode="Static" ID="btnAdd" runat="server" Text="Add" />
                             <div id="privateCheckboxDiv" class="hide">
                                <input type="checkbox"  name="" id="privateMsgCheckbox"/>
                                <label for="privateMsgCheckbox">Make It Private Note</label>
                              </div>
                        </td>
                   </tr>
              </table>
                </div><br /><br />
                   
               
            </div> 
            
       </div>


       <div class="container hide" id="userDocuments">
           <div class="userDocs">
                  <h1>Your Documents</h1><br /><br />
            </div>
           <div id="containerDoc">

           </div><br />
           <div class="docBtnDiv">
                <asp:FileUpload ID="FileUpload" runat="server" />     
                <asp:Button ID="fileUploadBtn" runat="server" OnClick="fileUploadBtn_Click" Text="Upload" />  <br /><br />
           </div>
           
       </div><br /><br />
        
    </form>
</body>
<script src="./Scripts/index.js"></script>
</html>
