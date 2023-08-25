$(document).ready(async function () {


    //Logout
    $("#logout").click(function (e) {
        e.preventDefault();
        var cookies = Request.Cookies.AllKeys;
        foreach(cookie in cookies)
        {
            Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        }
        window.location.href = "loginpage";
    })

    var loading = document.getElementById("loading")
    loading.style.display = "block";
    
    var req = await fetch(
        "https://www.universal-tutorial.com/api/getaccesstoken",
        {
            headers: {
                Accept: "application/json",
                "api-token":
                    "QXbOD1ZwyZV2sxx8mcbeKOhKAe5ve9m1I8mJIoJ1O4UCHSNHWamKU2QjZNT0mFpt5bQ",
                "user-email": "sujeetrath48@gmail.com",
            },
        }
    );
    authtoken = await req.json();


    var spanClose = document.getElementsByClassName("close")[0];
    var modal = document.getElementById("myModal");
    
    var dashboardAirportSelectTag = document.getElementById("allAirportSelectTag");
    var transactionAirportSelectTag = document.getElementById("airportTransactionSelectTag");

    /*Fill All Airports And Aircraft*/
    getAllAirport(dashboardAirportSelectTag);
    let airportName = $("#airportName").html()
    getAllAircraft(airportName, null);

    getAllAirport(transactionAirportSelectTag);
    function getAllAirport(node) {
        $.ajax({
            type: "GET",
            url: "Dashboard.aspx/GetAllAirports",
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (responce) {
                loadAirportData(responce.d,node);
            },
            failure: function (response) {
                alert("failure, to initialize data base");
            }
        })
    }
    function loadAirportData(datas,node) {
        if (datas.length == 0) {
            $("<option/>", { value: "parent" }).text("No data to show").appendTo(node);
        }
        else {
            $(node).text("");
            $("<option/>", { selected: true, disabled: true, hidden: true })
                .text(`Choose Airport`)
                .appendTo(node);
            let cnt = 0;
            for (let data of datas) {
                if (cnt == 0) {
                    $("#airportName").text(data);
                    cnt++;
                }
                $("<option/>", { value: data }).text(data).appendTo(node);
            }
        }
    }
    $("#allAirportSelectTag").change(function () {
        let airportName = $("#allAirportSelectTag").val();
        $("#airportName").html(airportName);
        let node = null;
        getAllAircraft(airportName,node);
    })
    $("#airportTransactionSelectTag").change(function () {
        let airportName = $("#airportTransactionSelectTag").val();
        let node = $("#transactionAircraftSelectTag");
        getAllAircraft(airportName,node);
    })


    function getAllAircraft(airportName,node) {
        var data = { "airportName": airportName };
        $.ajax({
            type: "POST",
            data: JSON.stringify(data),
            url: "Dashboard.aspx/GetAllAircraft",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                if (node == null) {
                    loadAircraftInDashboard(responce.d);
                } else {
                    loadAircraftData(responce.d,node);
                }
            },
            failure: function (response) {
                alert("failed ");
            }
        })
    }

    function loadAircraftInDashboard(datas) {
        function getAllAircraftTemplate(airline, aircraftName, source, destination) {

            let AircraftTemplate = `
                  <div class="respTableRow">
                            <div class="tableBodyCell">
                                 <img class="airlinrLogo" src="../Content/${airline}-Logo.jpg">
                                
                            </div>
                            <div class="tableBodyCell">
                                ${aircraftName}
                            </div>
                            <div class="tableBodyCell">
                                ${source}
                            </div>
                            <div class="tableBodyCell">
                                ${destination}
                            </div>               
                      </div>          
            
            `
            return AircraftTemplate;
        }
        $(".allAircraft").html("");
        if (datas == null) {
            let template = `
                <div class="aircraftNullMessage">
                    <h1>No Aircraft Available</h1>
                    <h1>Add Aircraft From Below Menu</h1>
                </div>
            `
            $(".allAircraft").append(template);
        } else {
            for (data of datas) {
                let template = getAllAircraftTemplate(data.Airline, data.AircraftName, data.Source, data.Destination)
                $(".allAircraft").append(template);
            }
        }
        
    }
    function loadAircraftData(datas, node) {
        if (node != null) {
            if (datas.length == 0) {
                $("<option/>", { value: "no data" }).text("No airport data to show").appendTo(node);
            }
            else {
                $(node).text("");
                $("<option/>", { selected: true, disabled: true, hidden: true })
                    .text(`Choose Aircraft`)
                    .appendTo(node);
                for (let data of datas) {
                    $("<option/>", { value: data.AircraftName }).text(data.AircraftName + ", " + data.Airline + ", " + data.Source + ", " + data.Destination ).appendTo(node);
                }
            }
        }
    }


    /*Load States For Aircraft Source and destination*/
    
    var sourceSelectTag = document.getElementById("sourceSelectTag")
    var destinationSelectTag = document.getElementById("destinationSelectTag")
    getStates(sourceSelectTag,"Source")
    getStates(destinationSelectTag, "Destination")
    setTimeout(hideLoader, 1 * 1000);
    async function getStates(node,text) {
        const responce = await fetch(
            `https://www.universal-tutorial.com/api/states/India`,
            {
                headers: {
                    Authorization: `Bearer ${authtoken.auth_token}`,
                    Accept: "application/json",
                },
            }
        );

        let datas = await responce.json();
        if (datas.length == 0) {
            $("<option/>", { value: "No States" }).text("No States").appendTo(node);
        } else {
            $(node).text("");
            $("<option/>", { selected: true, disabled: true, hidden: true })
                .text(`${text} State`)
                .appendTo(node);
            for (let data of datas) {
                $("<option/>", { value: data.state_name }).text(data.state_name).appendTo(node);
            }
        }
    }
    $("#initializeBtn").click(function (e) {
        e.preventDefault();
        modal.style.display = "block";
    });
    spanClose.onclick = function () {
        modal.style.display = "none";
    }

    $("#modalConfirmBtn").click(function (e) {
        e.preventDefault();
        modal.style.display = "none";
        
        $.ajax({
            type: "POST",
            url: "Dashboard.aspx/InitializeData",
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (responce) {
                
                getAllAirport(dashboardAirportSelectTag);
                getAllAirport(transactionAirportSelectTag);
            },
            failure: function (response) {
                alert("failure, to initialize data base");
            }
        })
    });

    $("#modalCancelBtn").click(function (e) {
        e.preventDefault();
        modal.style.display = "none";
    });

    function hideLoader() {
        loading.style.display = "none";
    }


    /*Adding An Airport */

    $("#addAirportBtn").click(function (e) {
        e.preventDefault();
        flag = 1;
        if (checkforEmptyData($("#airportNameInp"))==0 ) {
            flag = 0;
        } 
        if (checkforEmptyData($("#fuelCapacityInp")) == 0) {
            flag = 0;
        }
        
        if (flag == 1) {
            let airportName = $("#airportNameInp").val();
            let fuelCapacity = $("#fuelCapacityInp").val();

            let data = {};
            data["AirplaneName"] = airportName;
            data["FuelCapacity"] = fuelCapacity;

            loading.style.display = "block";
            
            $.ajax({
                type: "POST",
                data: JSON.stringify({ airportData: data }),
                url: "Dashboard.aspx/InsertNewAirport",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    $("#airportNameInp").val("");
                    $("#fuelCapacityInp").val("");
                    $(".userModal").css("display", "block")
                    $(".userModal-body").text("Airport Added Sucessfully!, Thank For Choosing Skr Travel's")

                    getAllAirport(dashboardAirportSelectTag);
                    getAllAirport(transactionAirportSelectTag);
                    hideLoader();
                    //loadAircraftData(responce.d);
                },
                failure: function (response) {
                    alert("failure, to initialize data base");
                }
            })
        }
    });

    $("#addAircraftBtn").click(function (e) {
        e.preventDefault();
        flag=1;
        if (checkforEmptyData($("#newAircraftTextBox")) == 0) {
            flag = 0;
        }
        if (checkforEmptyData($("#sourceSelectTag")) == 0) {
            flag = 0;
        }
        if (checkforEmptyData($("#destinationSelectTag")) == 0) {
            flag = 0;
        }

        if (flag == 1) {

            let aircraftName = $("#newAircraftTextBox").val();
            let aircraftSource = $("#sourceSelectTag").val();
            let aircraftDestination = $("#destinationSelectTag").val();
            let airlineName = $("#airlineSelectTag").val();

            let data = {};
            data["AircraftName"] = aircraftName;
            data["Source"] = aircraftSource;
            data["Destination"] = aircraftDestination;
            data["Airline"] = airlineName;
            loading.style.display = "block";
            $.ajax({
                type: "POST",
                data: JSON.stringify({ aircraftData: data }),
                url: "Dashboard.aspx/InsertNewAircraft",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    $("#newAircraftTextBox").val("");
                    $("#sourceSelectTag").val("")
                    $("#destinationSelectTag").val("");
                    getStates(sourceSelectTag, "Source")
                    getStates(destinationSelectTag, "Destination")
                    let airportName = $("#airportName").html()
                    getAllAircraft(airportName, null);
                    let node = $("#transactionAircraftSelectTag");
                    getAllAircraft(airportName, node);
                    $(".userModal").css("display", "block")
                    $(".userModalBody").text("Aircraft Added Sucessfully!, Thank For Choosing Skr Travel's")
                    hideLoader();
                    //loadAircraftData(responce.d);
                },
                failure: function (response) {
                    alert("failure, to initialize data base");
                }
            })
        }
    });


    /*Transaction Between Pages*/
    const queryString = window.location.search;
    const currentTab = queryString.split("?")[1]

    let allNavbarElement = ["home", "report", "transaction"];
    
    function loadCurrentTab(currentTab) {
        let loading = document.getElementById("loading")
   
        for (i = 0; i < allNavbarElement.length; i++) {
            let childNode = $(`#${allNavbarElement[i]}`).attr("childelement");
            if (allNavbarElement[i] == currentTab) {
                $(`#${allNavbarElement[i]}`).addClass("active");
         
                $(`#${childNode}`).css("display", "block");
            }
            else {
                $(`#${allNavbarElement[i]}`).removeClass();
                $(`#${childNode}`).css("display", "none");
            }
        }
        loading.style.display = "block";
        setTimeout(hideLoader, 0.5 * 1000);
    }
    loadCurrentTab(currentTab);
    

    $("#transaction").click(function (e) {
        e.preventDefault();
        document.location = "?transaction";

    })

    $("#report").click(function (e) {
        e.preventDefault();
        document.location = "?report";
    })
    $("#home").click(function (e) {
        e.preventDefault();

        document.location = "?home";
       
    })


    /*Transaction Page*/

    $("#transactionTypeSelectTag").change(function (e) {
        e.preventDefault();
       
        if ($("#transactionTypeSelectTag").val() == "In") {
            $("#inTypeTransactionDiv").css("display", "flex");
            $("#transactionInOutAircraftDiv").css("display", "none");
            $("#oilTransactionBtn").val("Fill Fuel Container")
        }
        else {
            let labletext = "Choose The Aircraft In which You Want Fill Oil";
            $("#transactionInOutAircrafLabel").text(labletext);
            $("#oilTransactionBtn").val("Fill In Aircraft")
            $("#inTypeTransactionDiv").css("display","none")
            $("#transactionInOutAircraftDiv").css("display","flex")
        }
    })

    $("#oilFillTypeSelectTag").change(function (e) {
        e.preventDefault();
        
        if ($("#oilFillTypeSelectTag").val() == "From Suplier") {
            $("#transactionInOutAircraftDiv").css("display", "none");
        }
        else {
            let labletext = "Choose The Aircraft From which You Want To Extract Oil";
            
            $("#transactionInOutAircrafLabel").text(labletext);
            $("#transactionInOutAircraftDiv").css("display","flex")
        }
    })


    $("input").on("input", function () {
        checkforEmptyData($(this));
    });
    $("select").on("input", function () {
        checkforEmptyData($(this));
    });

    function checkforEmptyData(node) {
        let flag = 1;
        if (node.is("select")) {
            if (node.val() == null) {
                $(`#${node.attr("errorId")}`).css("display", "block");
                
                flag = 0;
            }
            else {
                $(`#${node.attr("errorId")}`).css("display", "none");
            }
        }
        if (node.is("input")) {
            if (node.val()=="") {
                $(`#${node.attr("errorId")}`).css("display", "block");
                flag = 0;
            }
            else {
                $(`#${node.attr("errorId")}`).css("display", "none");
            }
        }
        return flag;
    }
    
    $("#oilTransactionBtn").click(function (e) {
        e.preventDefault();
        flag = 1;
        var currentFuelCapacity;
        if (checkforEmptyData($("#airportTransactionSelectTag")) == 0) {
            flag = 0;
        }else{
            $.ajax({
                type: "POST",
                data: JSON.stringify({ airportName: $("#airportTransactionSelectTag").val() }),
                url: "Dashboard.aspx/GetFuelCapacity",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                   
                    currentFuelCapacity = responce.d;
                   
                },
                failure: function (response) {
                    alert("failure, to get Fuel Capacity");
                }
            })
        }
        if ($("#transactionTypeSelectTag").val() == "In") {
            if ($("#oilFillTypeSelectTag").val() == "From An Aircraft") {
                let res = checkforEmptyData($("#transactionAircraftSelectTag"))
                if (res == 0) {
                    flag = 0;
                }
            }
        }
        if ($("#transactionTypeSelectTag").val() == "Out") {
            
            let res = checkforEmptyData($("#transactionAircraftSelectTag"))
            if (res == 0) {
                flag = 0;
            }
        }
        let res = checkforEmptyData($("#oilQuantityInp"));
        if (res == 0) {
            flag = 0;
        }
        if ( res == 1) {
            let val = parseInt($("#oilQuantityInp").val());
            if ($("#oilFillTypeSelectTag").val() == "From An Aircraft" || $("#transactionTypeSelectTag").val() == "Out") {
                if (val < 300 || val > 1400) {
                    $("#oilTransactionSpan").val("Enter Valid Quantity( Range 300 - 1400 liter)")
                    var node = $("#oilQuantityInp");
                    $(`#${node.attr("errorId")}`).css("display", "block");
                    flag = 0;
                }
            } else {
                if(val > currentFuelCapacity) {
                    var node = $("#oilQuantityInp");
                    $("#oilTransactionSpan").text("Max Fuel Capacity " + currentFuelCapacity);
                    $(`#${node.attr("errorId")}`).css("display", "block");
                    flag = 0;
                } 
            }
        }

        if (flag == 1) {
            let airportname = $("#airportTransactionSelectTag").val();
            let aircraftname = "";
            if ($("#oilFillTypeSelectTag").val() == "From An Aircraft" ||  $("#transactionTypeSelectTag").val() == "Out"){
                aircraftname = $("#transactionAircraftSelectTag").val();
            }
            let quantity = parseInt($("#oilQuantityInp").val());
            let transactionData = {};

            transactionData["airportName"] = airportname;
            transactionData["aircraftname"] = aircraftname;
            transactionData["quantity"] = quantity;
            transactionData["TransactionType"] = $("#transactionTypeSelectTag").val();
            
            loading.style.display = "block";
            
            $.ajax({
                type: "POST",
                data: JSON.stringify({ transactionDatas: transactionData }),
                url: "Dashboard.aspx/Transaction",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    $("#oilQuantityInp").val("");
                   
                    if (responce.d == true) {
                        
                        $(".userModal").css("display", "block")
                        $(".userModalHeader").css("background-color", "#04aa6d");
                        $(".userModalBody").text("Transaction Sucessful!, Thank For Choosing Skr Travel's")
                    } else {
                       
                        $(".userModal").css("display", "block")
                        $(".userModalHeader").css("background-color", "#F44336");
                        $(".userModalBody").text("Insuficient Fuel To Make The Transaction")
                    }
                    hideLoader();
                    
                },
                failure: function (response) {
                    alert("failure, to make your transaction");
                }
            })

        }

    })
    $(".userModal").on("click", ".userModalClose", function (e) {
        e.preventDefault();
        $(".userModal").css("display", "none")
    })


    /*Report Section*/

    getSummaryReport()
    function getSummaryReport() {
        $.ajax({
            type: "GET",
            url: "Dashboard.aspx/GetSummaryReport",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
              
                loadSummaryData(responce.d)
            },
            failure: function (response) {
                alert("failure, to make your transaction");
            }
        })
    }
    function loadSummaryData(datas) {

        function fillSummaryTemplateData(airportName,fuelAvailable) {
            let summaryTemplate = ` 
                 <div class="respTableRow">
                    <div class="tableBodyCell">
                        ${airportName}
                    </div>
                    <div class="tableBodyCell" >
                            ${fuelAvailable}
                    </div>  

                </div>
           
            `
            return summaryTemplate;

        }

        let headingTemplate = `
            <div id = "respTable" >
                <div id="respTableHeader">
                      <div class="tableHeaderCell">
                        Airport Name
                     </div>
                    <div class="tableHeaderCell">
                        Fuel Available<br/>(in liters)

                    </div>      
                </div>
                <div id="respTableBody">
                               
                </div>
            </div >
            
        `
        
        $(".content").html("");
        $(".content").append(headingTemplate);
        for (data of datas) {

            let template = fillSummaryTemplateData(data.AirportName, data.FuelAvailability)
            $(".content #respTableBody").append(template);
        }
        let downloadBtnTemplate = `
            <div>
                <img id="downloadBtnImg" src="https://amritfoundationofindia.in/wp-content/uploads/2018/08/download-logo.png" 
                    alt="Download Btn" title="Download Airport Summary Report">    
            </div>
        `;
       // $(".content").append(downloadBtnTemplate);

    }

    function getFuelReport(startDate,endDate) {

        $.ajax({
            type: "POST",
            data: JSON.stringify({ "startDate": startDate, "endDate": endDate }),
            url: "Dashboard.aspx/GetFuelReport",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                
                loadFuelReportData(responce.d, startDate, endDate)
            },
            failure: function (response) {
                alert("failure, to make your transaction");
            }
        })
    }

    function loadFuelReportData(datas, startDate, endDate) {

        var previousAirportId = -1;
        $(".content").html("");
        
        let datePickerTemplate = `
             <div class="flexColumn">
                <div class="flexRow marginBottomSmall" >
                    <label class="widthSmall" >From</label>
                    <input type="date" class="paddingSmall" id="reportStartingDate" value=${startDate}>
                    
                </div>
                <div class="flexRow marginBottomSmall">
                    <label class="widthSmall">To</label>
                    <input type="date" id="reportEndingDate" value="${endDate}" class="marginRightSmall paddingSmall">
                    
                    <button id="searchFuelReportBtn" class="marginRightSmall widthSmall">Find</button>

                    
                </div>
            </div>  
        `
        $(".content").append(datePickerTemplate);

        if (datas.length == 0) {
            let template = `
                <div>
                    <h1>No Datas To Show</h1>
                </div>
            `
        }
        else
        {
            for (data of datas){

                //heading content
                let flag = 0;
                if (previousAirportId == -1 || previousAirportId != data.AirportId) {
                    previousAirportId = data.AirportId;
                    let headingTemplate = getHeadingTemplate(data.AirportName, data.AirportId)
                    $(".content").append(headingTemplate);
                    flag = 1;
                }

                //body content
                let aircraftName = "";
                if (data.AircraftName != null) {
                    aircraftName = data.AircraftName;
                }
                let contentTemplate = getFuelReportTemplate(data.TransactionDate, data.TransactionType, data.Quantity, aircraftName)
                $(`.airport${data.AirportId}Data`).append(contentTemplate);

                //footer content
                if (flag == 1) {
                    previousAirportId = data.AirportId;
                    let footerTemplate = getFooterTemplate(data.FuelAvailability)
                    $(".content").append(footerTemplate);
                }
            }
        }

        let downloadBtnTemplate = `
             <div>
                <img id="downloadBtnImg" src="https://amritfoundationofindia.in/wp-content/uploads/2018/08/download-logo.png" 
                    alt="Download Btn" title="Download Fuel Report">
            </div>
           
        `;
       // $(".content").append(downloadBtnTemplate);


        function getHeadingTemplate(airportName,airportId) {

            let headingTemplate = `
                <div class="fuelReportName">
                    <div>Airport:&nbsp&nbsp</div>
                    <div>${airportName}</div>
                </div>
                <div class="fuelReportDataContainer">
                 <div id = "respTable" >
                    <div id="respTableHeader">
                        <div class="tableHeaderCell">
                               Date
                        </div>
                        <div class="tableHeaderCell">
                                Type
                        </div>
                        <div class="tableHeaderCell">
                                Fuel
                        </div>
                        <div class="tableHeaderCell">
                             Aircraft No
                        </div>     
                    </div>
                    <div id="respTableBody" class="airport${airportId}Data">
                               
                    </div>
                 </div >
                 </div>
            `
            return headingTemplate;

        }
        function getFooterTemplate(fuelAvailable) {

            let footerTemplate = `
                <div class="fuelReportName">
                    <div>Fuel Available:&nbsp&nbsp</div>
                    <div>${fuelAvailable}</div>
                </div>
                    <br/>
                    <div>--------*********----------</div><br/>
                <br/>
            `
            return footerTemplate;

        }
        function getFuelReportTemplate(date, type, fuelQuantity, aircraftName)
        {
            let tableTemplate = `
                      <div class="respTableRow">
                            <div class="tableBodyCell">
                                ${date}
                            </div>
                            <div class="tableBodyCell" >
                                ${type}
                            </div>
                            <div class="tableBodyCell">
                                ${fuelQuantity}
                            </div>
                            <div class="tableBodyCell">
                                ${aircraftName}
                            </div>               
                      </div>          
            `
            return tableTemplate;
        }
        
    }
    $("#summaryTitle").click(function (e) {
        e.preventDefault();
        $("#summaryTitle").addClass("active")
        $("#fuelReport").removeClass();
        getSummaryReport();

        $("#summaryReportImageButton").css("display", "block");
        $("#fuelReportImageButton").css("display", "none");
    })
    $("#fuelReport").click(function (e) {
        e.preventDefault();

        $("#fuelReport").addClass("active")
        $("#summaryTitle").removeClass();

        $("#fuelReportImageButton").css("display", "block");
        $("#summaryReportImageButton").css("display", "none");


        var today = new Date();
        var dd = today.getDate();
        var tenDaysBack = today.getDate()-10;

        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }
        startDate = yyyy + '-' + mm + '-' + tenDaysBack;
       
        endDate = yyyy + '-' + mm + '-' + dd;

        getFuelReport(startDate, endDate);

       /* $("#startDateUserHandle").text(startDate);
        $("#endDateUserHandle").text(endDate);*/
        document.getElementById("startDateUserHandle").value = startDate
        document.getElementById("endDateUserHandle").value = endDate

        
        $(".content").on("click", "#searchFuelReportBtn", function (e) {
            e.preventDefault();
            var startDate = $("#reportStartingDate").val();
            var endDate = $("#reportEndingDate").val();
            document.getElementById("startDateUserHandle").value = startDate
            document.getElementById("endDateUserHandle").value = endDate

            flag = checkDate(startDate, endDate);
            if (flag) {
                getFuelReport(startDate, endDate);
            }
        })
    })

    function checkDate(startDate, endDate) {
        if (startDate > endDate) {
            alert("Invalid End Date: End Date Can Not Be Smaller Then Starting Date");
            return 0;
        }
        return 1;
    }


    /*Report Download*/


    //summary Download
    $(".content").on("click", "#searchFuelReportBtn", function (e) {
        e.preventDefault();
        var startDate = $("#reportStartingDate").val();
        var endDate = $("#reportEndingDate").val();
        flag = checkDate(startDate, endDate);
        if (flag) {
            getFuelReport(startDate, endDate);
        }
    })


    //fuel trasaction
    $(".content").on("click", "#fuelReportDownloadBtn", function (e) {
        e.preventDefault();
        var startDate = $("#reportStartingDate").val();
        var endDate = $("#reportEndingDate").val();
        flag = checkDate(startDate, endDate);
        if (flag) {
            getFuelReport(startDate, endDate);
        }
    })

});