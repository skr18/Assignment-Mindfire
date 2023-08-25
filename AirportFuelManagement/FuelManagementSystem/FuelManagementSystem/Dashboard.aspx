<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FuelManagementSystem.AirportFuelManagementSystem" %>

<!DOCTYPE html>
<%@ Register Src="~/AirportSummaryDownload.ascx" TagName="report" TagPrefix="sujeet" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="./Content/Dashboard.css" asp-append-version="true"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="" />
    <link href="https://fonts.googleapis.com/css2?family=Merriweather:wght@700&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="airportPage" runat="server">
        <div>
             <ul id="navbar">
              <li><a class="active" id="home" childelement="container">Home</a></li>
              <li><a id="transaction" childelement="transactionContainer">Transaction</a></li>
              <li><a id="report" childelement="reportContainer">Report</a></li>
              <li id="initialize"><a id="initializeBtn">Initialize</a></li>  
              <li><a id="logout">Logout</a></li>  
              
           </ul>
        </div>

        <div id="loading"></div>
        <div id="container">
            <div class="travelName">
                <h1>Skr Travel's </h1> 
            </div>
            <div class="flightDetailsContainer">

                <div class="airportContainer">
                    <div class="airportNameDiv">
                        <label id="airportName">Indira Gandhi International Airport, Delhi</label>
                        <select id="allAirportSelectTag">
                            <option selected="selected" disabled="disabled" hidden="hidden">Choose Airport</option>
                        </select>
                    </div>
                   
                </div>

                <div class="aircraftContainer">
                    <div id="aircraftDiv">
                         <div id = "respTable" >
                            <div id="respTableHeader">
                                <div class="tableHeaderCell">
                                       Airline
                                </div>
                                <div class="tableHeaderCell">
                                        Aircraft Name
                                </div>
                                <div class="tableHeaderCell">
                                        Source
                                </div>
                                <div class="tableHeaderCell">
                                     Destination
                                </div>     
                            </div>
                            <div id="respTableBody" class="allAircraft">
                               
                            </div>
                       </div >
                    </div>
                   
                </div>
                <div class="newItemsAddDiv">
                     <div class="newItemsAddContainer addAirportDiv">
                        <h2 class="marginTopSmall"><u>Add New Airport</u></h2>
                        <div class="marginTopLarge widthLarge">
                            <div class="flexRow marginBottomMedium">

                                <label>Airport Name:</label>
                                <div class="flexColumn">
                                    <asp:TextBox runat="server" ID="airportNameInp" errorid="airportNameSpan" ClientIDMode="Static" 
                                        placeholder="Indira Gandhi Airport, Delhi" ></asp:TextBox>
                                     <span id="airportNameSpan">Airport Name is requried</span>
                                </div>
                            </div>

                            <div class="flexRow marginBottomMedium">
                                 <label>Fuel Capacity:</label>
                                <div class="flexColumn">
                                     <asp:TextBox runat="server" TextMode="Number" ID="fuelCapacityInp" 
                                         ClientIDMode="Static" placeholder="35400 litters" errorid="airportFuelSpan"></asp:TextBox>
                                     <span id="airportFuelSpan">Airport Fuel Capacity is requried</span>
                                </div>

                            </div>
                            <div class="addBtn marginBottomMedium">

                                <asp:Button runat="server" ID="addAirportBtn" ClientIDMode="Static" Text="Add"/>
                            </div>
                           
                        </div>
                     </div>
                    <div class="newItemsAddContainer addAircraftDiv">
                         <h2 class="marginTopSmall" > <u>Add New Aircraft</u></h2>

                        <div class="widthLarge">
                            <div class="flexRow marginBottomMedium marginTopMedium">
                                <label>Aircraft Name:</label>
                                <div class="flexColumn">
                                     <asp:TextBox runat="server" ID="newAircraftTextBox" ClientIDMode="Static" 
                                        placeholder="DH647" errorid="aircraftNameSpan" ></asp:TextBox>
                                     <span id="aircraftNameSpan">Aircraft Name is requried</span>
                                </div>
                            </div>
                            
                            <div class="flexRow marginBottomMedium">
                                <label >Airline Name:</label>
                               

                                    <select runat="server" id="airlineSelectTag">
                                        <option selected="selected" value="Go Air">Go Air</option>
                                        <option value="IndiGo">IndiGo</option>
                                        <option value="Spice Jet">Spice Jet</option>
                                        <option value="Air India">Air India</option>
                                        <option value="kingfisher">kingfisher</option>
                                    </select>
                                
                            </div>

                            <div class="flexRow marginBottomMedium">
                                 <label >Aircrft Source:</label>
                                <div class="flexColumn">

                                    <select id="sourceSelectTag" errorid="sourceSpan">
                                        <option selected="selected" disabled="disabled" hidden="hidden" value="Source State">Source State</option>
                                    </select>
                                     <span id="sourceSpan">Choose Source</span>
                                </div>
                            </div>

                            <div class="flexRow marginBottomMedium">
         
                                 <label >Destination:</label>
                                <div class="flexColumn">

                                     <select id="destinationSelectTag" errorid="destinationSpan">
                                        <option selected="selected" disabled="disabled" hidden="hidden">Choose Destination</option>
                                    </select>
                                     <span id="destinationSpan">Choose Destination State</span>
                                </div>
                            </div>
                            <div class="addBtn marginBottomMedium">
                                <asp:Button runat="server" ID="addAircraftBtn" ClientIDMode="Static" Text="Add"/>
                            </div>

                        </div>
                    </div>
                </div>
               

            </div>
            
        </div>

        <div id="transactionContainer">
            <h1 class="transactionTitle">Transaction</h1>
            <div class="trasactionDiv">
                <div class="transactionTypeDiv">

                    <div class="trasactionControls">
                         <label id="airportNameLable">Airport</label>
                         <select id="airportTransactionSelectTag" errorid="transactionAirportSpan">
                            <option selected="selected" disabled="disabled" hidden="hidden">Choose Airport</option>
                        </select>

                        <span id="transactionAirportSpan">Choose Airport</span>
                    </div>
                     
                    <div class="trasactionControls">

                        <label>Transaction Type</label>
                         <select id="transactionTypeSelectTag">
                            <option selected="selected">In</option>
                            <option >Out</option>
                         </select>
                    </div>
                </div>
                <div class="trasactionControls" id="inTypeTransactionDiv">
                    <label>Choose A Way To Fill The Container</label>
                     <select id="oilFillTypeSelectTag">
                        <option selected="selected">From Suplier</option>
                        <option >From An Aircraft</option>
                     </select>
                </div>
                <div class="trasactionControls" id="transactionInOutAircraftDiv">
                    <label id="transactionInOutAircrafLabel"></label>
                    <div class="transactionAircraftDiv">
                         <select id="transactionAircraftSelectTag" errorid="transactionAircraftSpan">
                            <option selected="selected" disabled="disabled" hidden="hidden">Choose Aircraft</option>
                        </select>
                        <span id="transactionAircraftSpan">Choose Aircraft</span>
                    </div>
                </div>
                <div class="trasactionControls">
                    <label>Enter The Amount</label>
                    <asp:TextBox ID="oilQuantityInp" errorid="oilTransactionSpan" runat="server" placeholder="Eg: 34243 liter"/>
                     <span id="oilTransactionSpan">Enter Valid Quantity( Range 300 - 1400 liter)</span>
                </div>
                <div class="trasactionControls">
                    <asp:Button ID="oilTransactionBtn" ClientIDMode="Static" runat="server" Text="Fill Fuel Container" />
                </div>
            </div>
            
            
        </div>



        <div id="reportContainer">
            <h1 class="reportHeadingTitle">Report</h1>
            <div class="reportHeading">
                <ul>
                    <li><a class="active" id="summaryTitle">Airport Summary Report</a></li>
                    <li><a id="fuelReport">Fuel Consumtion Report</a></li>
                </ul>
                
            </div>
            <div class="reportContainer">
                <div class="reportContent">
                    <div class="content">
                       
                       
                    </div>
                    <sujeet:report runat="server" id="reportUserControler"/>
                     
                 </div>
              </div>
           </div>
        

        <!-- Sucess And Error Model-->


        <div class="userModal">
=
              <div class="userModalContent">
      
                <div class="userModalHeader">
                  <h4 class="userModalTitle">Popup Message</h4>
                  <button type="button" class="userModalClose">&times;</button>
                </div>

                <div class="userModalBody">
                 
                </div>
              </div>
          </div>


       <!-- Intitialize Model -->
        <div>
            <div id="myModal" class="modal">
              <div class="modalContent">
                <div class="modalHeader">
                  <span class="close">&times;</span>
                  <h2>Confermation Dialog</h2>
                </div>
                <div class="modalBody">
                  <p>All of your newly added airports, aircraft's and all your transaction will be deleted. Are you Sure</p>
                 
                </div>
                <div class="modalFooter">
                    <asp:Button ID="modalConfirmBtn" runat="server" ClientIDMode="Static" Text="Yes" />
                    <asp:Button ID="modalCancelBtn" runat="server" ClientIDMode="Static" Text="No" />
                </div>
              </div>

            </div>
        </div>
        
      
    </form>

</body>
  
    <script src="./Scripts/Dashboard.js" asp-append-version="true"></script>
</html>
