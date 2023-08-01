<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RegistrationPageAsp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <style>
        * {
            padding: 0px;
            margin: 0px;
        }

        .container {
            width: 60%;
            background-color: rgb(228 235 234);
            border-radius: 18px;
            margin: auto;
        }

        .heading {
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: center;
        }

            .heading h1 {
                /* font-size: xx-large; */
                color: #ff0097;
                position: absolute;
                margin: auto;
                font-weight: 900;
            }

        .title {
            color: #001dff;
            text-align: center;
        }

        #dobinp {
            width: 35%;
        }

        #genderinp {
            float: left;
            width: 35%;
        }

        #photo {
            width: 80px;
        }

        .p-details {
            display: flex;
            flex-direction: row;
        }

        .container span {
            position: absolute;
            color: red;
            font-size: smaller;
            visibility: hidden;
        }

        .col1 {
            margin-left: 10px;
            width: 50%;
        }

            .col1 label {
                float: left;
                width: 27%;
            }

            .col1 input {
                float: left;
                width: 47%;
            }

            .col1 select {
                float: left;
                width: 55%;
            }

        .box {
            border: 1px solid grey;
            width: 97%;
            margin: auto;
            border-radius: 35px;
            border: none;
            background-color: #cfdcdd;
        }

            .box label {
                float: left;
                margin-right: 10px;
            }

            .box select {
                float: left;
            }

        .submit {
            border-radius: 8px;
            font-size: medium;
            color: white;
            background-color: #85205e;
            width: 100px;
            height: 30px;
        }

        .noborder {
            border: none;
        }

        .lableCheckbox {
            color: #5e5838;
            margin-left: 10px;
            font-weight: 600;
        }

        .permanentTitle {
            display: flex;
            align-items: center
        }

        .logo {
            position: relative;
            margin-left: auto;
            margin-right: 6px;
        }

        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        .userContainer {
            margin-top: 20px !important;
            background-color: rgb(192 214 219);
            margin: auto;
            width: 60%;
            border-radius: 18px;
            margin-bottom: 10px;
            display: none;
        }

            .userContainer h1 {
                color: #045643;
                text-align: center;
                font-weight: 900;
            }

        .userData {
            display: flex;
            flex-direction: row;
        }

        #hobby {
            text-decoration: none;
            border: none;
            background-color: rgb(228 235 234);
            border-bottom: 2px solid black;
            margin-bottom: 5px;
            cursor: pointer;
        }

        .hobbies {
            flex-direction: column;
            display: none;
            background-color: rgb(228 235 234);
            width: 120px;
        }

        .hobbiesVisible {
            flex-direction: column;
            display: flex;
            background-color: rgb(228 235 234);
            width: 120px;
        }

        .lastSection {
            margin-left: 25px;
        }

        @media(max-width:868px) {
            .container span {
                font-size: xx-small;
            }

            .logo {
                position: relative;
                margin-left: auto;
            }

            #photo {
                width: 35px;
            }

            .heading h1 {
                color: #ff0097;
                position: absolute;
                margin: auto;
                font-size: x-large;
                margin-right: 4px;
            }

            .p-details {
                flex-direction: column;
                margin: auto;
            }

            .col1 {
                margin-left: 10px;
                width: 85%;
            }

                .col1 label {
                    float: left;
                    width: 35%;
                }

                .col1 input {
                    float: left;
                    width: 60%;
                }

            .container {
                width: 96%;
            }

            .lableCheckbox {
                font-size: small;
            }

            .userData {
                flex-direction: column;
            }

            .userContainer {
                width: 80%;
            }

            .userData label {
                width: 45%;
            }
        }

        @media (max-width: 1164px) and (min-width: 869px) {
            .container span {
                font-size: x-small;
            }

            .logo {
                position: relative;
                margin-left: auto;
                font-size: 30px
            }

            .heading h1 {
                color: #ff0097;
                position: absolute;
                margin: auto;
                font-size: xx-large;
            }

            .p-details {
                flex-direction: column;
                margin: auto;
            }

            .box {
                border: 1px solid grey;
                width: 80%;
                margin: auto;
                border-radius: 12px;
            }

            .col1 {
                margin-left: 10px;
                width: 80%
            }

                .col1 input {
                    float: left;
                    width: 61%;
                }

            .lableCheckbox {
                font-size: medium;
            }
        }

        /* User Details */
    </style>
</head>
<body>
    
    <form runat="server">
        <div class="container" id="userProfile">
            <br>
            <div class="heading">
                <h1>REGISTRATION FORM</h1>
                <div class="logo">
                    <img src="./content/demo.jpg" id="photo" alt="">
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
                            <input id="profileimg" type="file" accept="image/png, image/gif, image/jpeg" name=""><br>
                            <br>
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
                       
                    <div class="hobbies" id="hobbiesDiv">
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

              
                <br>
            </div>

        </div>
    </form>
</body>
<script src="./Scripts/index.js"></script>
</html>
