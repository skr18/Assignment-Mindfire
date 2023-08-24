<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="FuelManagementSystem.AirportFuelManagementSystem" %>

<!DOCTYPE html>
<%@ Register Src="~/AirportSummaryDownload.ascx" TagName="report" TagPrefix="sujeet" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="./Content/Dashboard.css"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Merriweather:wght@700&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <ul id="navbar">
              <li><a class="active" id="home">Home</a></li>
              <li><a id="transaction">Transaction</a></li>
              <li><a id="report">Report</a></li>
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
                        <select id="AllAirportSelectTag">
                            <option selected="selected" disabled="disabled" hidden="hidden">Choose Airport</option>
                        </select>
                    </div>
                   
                </div>

                <div class="aircraftContainer">
                    <div id="aircraftDiv">
                         <div id = "resp-table" >
                            <div id="resp-table-header">
                                <div class="table-header-cell">
                                       Airline
                                </div>
                                <div class="table-header-cell">
                                        Aircraft Name
                                </div>
                                <div class="table-header-cell">
                                        Source
                                </div>
                                <div class="table-header-cell">
                                     Destination
                                </div>     
                            </div>
                            <div id="resp-table-body" class="allAircraft">
                               
                            </div>
                       </div >
                    </div>
                   
                </div>
                <div class="newItemsAddDiv">
                     <div class="newItemsAddContainer addAirportDiv">
                        <h3 class="marginTop-10"><u>Add New Airport</u></h3>
                        <div class="marginTop-30 width-86">
                            <div class="flex-row marginBottom-20">

                                <label>Airport Name:</label>
                                <div class="flex-column">
                                    <asp:TextBox runat="server" ID="airportNameInp" errorId="airportNameSpan" ClientIDMode="Static" 
                                        placeholder="Indira Gandhi Airport, Delhi" ></asp:TextBox>
                                     <span id="airportNameSpan">Airport Name is requried</span>
                                </div>
                            </div>

                            <div class="flex-row marginBottom-20">
                                 <label>Fuel Capacity:</label>
                                <div class="flex-column">
                                     <asp:TextBox runat="server" TextMode="Number" ID="fuelCapacityInp" 
                                         ClientIDMode="Static" placeholder="35400 litters" errorId="AirportFuelSpan"></asp:TextBox>
                                     <span id="AirportFuelSpan">Airport Fuel Capacity is requried</span>
                                </div>

                            </div>
                            <div class="AddBtn marginBottom-20">

                                <asp:Button runat="server" ID="addAirportBtn" ClientIDMode="Static" Text="Add"/>
                            </div>
                           
                        </div>
                     </div>
                    <div class="newItemsAddContainer addAircraftDiv">
                         <h3 class="marginTop-10" > <u>Add New Aircraft</u></h3>

                        <div class="width-86">
                            <div class="flex-row marginBottom-20 marginTop-15">
                                <label>Aircraft Name:</label>
                                <div class="flex-column">
                                     <asp:TextBox runat="server" ID="newAircraftTextBox" ClientIDMode="Static" 
                                        placeholder="DH647" errorId="aircraftNameSpan" ></asp:TextBox>
                                     <span id="aircraftNameSpan">Aircraft Name is requried</span>
                                </div>
                            </div>
                            
                            <div class="flex-row marginBottom-20">
                                <label >Airline Name:</label>
                               

                                    <select runat="server" id="airlineSelectTag">
                                        <option selected="selected" value="Go Air">Go Air</option>
                                        <option value="IndiGo">IndiGo</option>
                                        <option value="Spice Jet">Spice Jet</option>
                                        <option value="Air India">Air India</option>
                                        <option value="kingfisher">kingfisher</option>
                                    </select>
                                
                            </div>

                            <div class="flex-row marginBottom-20">
                                 <label >Aircrft Source:</label>
                                <div class="flex-column">

                                    <select id="sourceSelectTag" errorId="sourceSpan">
                                        <option selected="selected" disabled="disabled" hidden="hidden" value="Source State">Source State</option>
                                    </select>
                                     <span id="sourceSpan">Choose Source</span>
                                </div>
                            </div>

                            <div class="flex-row marginBottom-20">
         
                                 <label >Destination:</label>
                                <div class="flex-column">

                                     <select id="DestinationSelectTag" errorId="destinationSpan">
                                        <option selected="selected" disabled="disabled" hidden="hidden">Choose Destination</option>
                                    </select>
                                     <span id="destinationSpan">Choose Destination State</span>
                                </div>
                            </div>
                            <div class="AddBtn marginBottom-20">
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
                         <select id="AirportTransactionSelectTag" errorId="transactionAirportSpan">
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
                <div class="trasactionControls" id="InTypeTransactionDiv">
                    <label>Choose A Way To Fill The Container</label>
                     <select id="OilFillTypeSelectTag">
                        <option selected="selected">From Suplier</option>
                        <option >From An Aircraft</option>
                     </select>
                </div>
                <div class="trasactionControls" id="TransactionInOutAircraftDiv">
                    <label id="TransactionInOutAircrafLabel"></label>
                    <div class="TransactionAircraftDiv">
                         <select id="TransactionAircraftSelectTag" errorId="transactionAircraftSpan">
                            <option selected="selected" disabled="disabled" hidden="hidden">Choose Aircraft</option>
                        </select>
                        <span id="transactionAircraftSpan">Choose Aircraft</span>
                    </div>
                </div>
                <div class="trasactionControls">
                    <label>Enter The Amount</label>
                    <asp:TextBox ID="oilQuantityInp" errorId="oilTransactionSpan" runat="server" placeholder="Eg: 34243 liter"/>
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
              <div class="userModal-content">
      
                <div class="userModal-header">
                  <h4 class="userModal-title">Popup Message</h4>
                  <button type="button" class="userModalClose">&times;</button>
                </div>

                <div class="userModal-body">
                 
                </div>
              </div>
          </div>


       <!-- Intitialize Model -->
        <div>
            <div id="myModal" class="modal">
              <div class="modal-content">
                <div class="modal-header">
                  <span class="close">&times;</span>
                  <h2>Confermation Dialog</h2>
                </div>
                <div class="modal-body">
                  <p>All of your newly added airports, aircraft's and all your transaction will be deleted. Are you Sure</p>
                 
                </div>
                <div class="modal-footer">
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
