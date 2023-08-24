$(document).ready(async function () {


    //Logout
    $("#logout").click(function (e) {
        e.preventDefault();
        window.location.href = "loginpage";
        cookieStore.getAll().then(cookies => cookies.forEach(cookie => {
            console.log('Cookie deleted:', cookie);
            cookieStore.delete(cookie.name);
        }));
    })

    var loading = document.getElementById("loading")
    loading.style.display = "block";
    setTimeout(hideLoader, 1 * 1000);
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
    
    var DashboardAirportSelectTag = document.getElementById("AllAirportSelectTag");
    var TransactionAirportSelectTag = document.getElementById("AirportTransactionSelectTag");

    /*Fill All Airports And Aircraft*/
    getAllAirport(DashboardAirportSelectTag);
    let airportName = $("#airportName").html()
    getAllAircraft(airportName, null);

    getAllAirport(TransactionAirportSelectTag);
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
    $("#AllAirportSelectTag").change(function () {
        let airportName = $("#AllAirportSelectTag").val();
        $("#airportName").html(airportName);
        let node = null;
        getAllAircraft(airportName,node);
    })
    $("#AirportTransactionSelectTag").change(function () {
        let airportName = $("#AirportTransactionSelectTag").val();
        let node = $("#TransactionAircraftSelectTag");
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
                  <div class="resp-table-row">
                            <div class="table-body-cell">
                                 <img class="airlinrLogo" src="../Content/${airline}-Logo.jpg">
                                
                            </div>
                            <div class="table-body-cell">
                                ${aircraftName}
                            </div>
                            <div class="table-body-cell">
                                ${source}
                            </div>
                            <div class="table-body-cell">
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
                $("<option/>", { value: "parent" }).text("No data to show").appendTo(node);
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
    var DestinationSelectTag = document.getElementById("DestinationSelectTag")
    getStates(sourceSelectTag,"Source")
    getStates(DestinationSelectTag,"Destination")
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
                console.log("data base initialized")
                getAllAirport(DashboardAirportSelectTag);
                getAllAirport(TransactionAirportSelectTag);
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

                    getAllAirport(DashboardAirportSelectTag);
                    getAllAirport(TransactionAirportSelectTag);
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
        if (checkforEmptyData($("#DestinationSelectTag")) == 0) {
            flag = 0;
        }

        if (flag == 1) {

            let aircraftName = $("#newAircraftTextBox").val();
            let aircraftSource = $("#sourceSelectTag").val();
            let aircraftDestination = $("#DestinationSelectTag").val();
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
                    $("#DestinationSelectTag").val("");
                    getStates(sourceSelectTag, "Source")
                    getStates(DestinationSelectTag, "Destination")
                    let airportName = $("#airportName").html()
                    getAllAircraft(airportName, null);
                    let node = $("#TransactionAircraftSelectTag");
                    getAllAircraft(airportName, node);
                    $(".userModal").css("display", "block")
                    $(".userModal-body").text("Aircraft Added Sucessfully!, Thank For Choosing Skr Travel's")
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

    $("#transaction").click(function (e) {
        e.preventDefault();
        $("#container").css("display", "none");
        $("#reportContainer").css("display", "none");

        $("#transactionContainer").css("display", "block");
        $("#home").removeClass();
        $("#report").removeClass();
        $("#transaction").addClass("active");

        let loading = document.getElementById("loading")
        loading.style.display = "block";
        setTimeout(hideLoader, 0.5 * 1000);

    })

    $("#report").click(function (e) {
        e.preventDefault();

        $("#container").css("display", "none");
        $("#transactionContainer").css("display", "none");
        $("#reportContainer").css("display", "flex");

        $("#home").removeClass();
        $("#transaction").removeClass();
        $("#report").addClass("active");

        loading.style.display = "block";
        setTimeout(hideLoader, 0.5 * 1000);

    })
    $("#home").click(function (e) {
        e.preventDefault();

        $("#container").css("display", "block");
        $("#reportContainer").css("display", "none");
        $("#transactionContainer").css("display", "none");
        $("#transaction").removeClass();
        $("#report").removeClass();
        $("#home").addClass("active");

        loading.style.display = "block";
        setTimeout(hideLoader, 0.5 * 1000);

    })


    /*Transaction Page*/

    $("#transactionTypeSelectTag").change(function (e) {
        e.preventDefault();
       
        if ($("#transactionTypeSelectTag").val() == "In") {
            $("#InTypeTransactionDiv").css("display", "flex");
            $("#TransactionInOutAircraftDiv").css("display", "none");
            $("#oilTransactionBtn").val("Fill Fuel Container")
        }
        else {
            let labletext = "Choose The Aircraft In which You Want Fill Oil";
            $("#TransactionInOutAircrafLabel").text(labletext);
            $("#oilTransactionBtn").val("Fill In Aircraft")
            $("#InTypeTransactionDiv").css("display","none")
            $("#TransactionInOutAircraftDiv").css("display","flex")
        }
    })

    $("#OilFillTypeSelectTag").change(function (e) {
        e.preventDefault();
        
        if ($("#OilFillTypeSelectTag").val() == "From Suplier") {
            $("#TransactionInOutAircraftDiv").css("display", "none");
        }
        else {
            let labletext = "Choose The Aircraft From which You Want To Extract Oil";
            
            $("#TransactionInOutAircrafLabel").text(labletext);
            $("#TransactionInOutAircraftDiv").css("display","flex")
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
                //console.log($(`#${node.attr("errorId")}`));
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
        if (checkforEmptyData($("#AirportTransactionSelectTag")) == 0) {
            flag = 0;
        }else{
            $.ajax({
                type: "POST",
                data: JSON.stringify({ airportName: $("#AirportTransactionSelectTag").val() }),
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
            if ($("#OilFillTypeSelectTag").val() == "From An Aircraft") {
                let res = checkforEmptyData($("#TransactionAircraftSelectTag"))
                if (res == 0) {
                    flag = 0;
                }
            }
        }
        if ($("#transactionTypeSelectTag").val() == "Out") {
            
            let res = checkforEmptyData($("#TransactionAircraftSelectTag"))
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
            if ($("#OilFillTypeSelectTag").val() == "From An Aircraft" || $("#transactionTypeSelectTag").val() == "Out") {
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
            let airportname = $("#AirportTransactionSelectTag").val();
            let aircraftname = "";
            if ($("#OilFillTypeSelectTag").val() == "From An Aircraft" ||  $("#transactionTypeSelectTag").val() == "Out"){
                aircraftname = $("#TransactionAircraftSelectTag").val();
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
                    console.log(responce.d)
                    if (responce.d == true) {
                        
                        $(".userModal").css("display", "block")
                        $(".userModal-header").css("background-color", "#04aa6d");
                        $(".userModal-body").text("Transaction Sucessful!, Thank For Choosing Skr Travel's")
                    } else {
                       
                        $(".userModal").css("display", "block")
                        $(".userModal-header").css("background-color", "#F44336");
                        $(".userModal-body").text("Insuficient Fuel To Make The Transaction")
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
                 <div class="resp-table-row">
                    <div class="table-body-cell">
                        ${airportName}
                    </div>
                    <div class="table-body-cell" >
                            ${fuelAvailable}
                    </div>  

                </div>
           
            `
            return summaryTemplate;

        }

        let headingTemplate = `
            <div id = "resp-table" >
                <div id="resp-table-header">
                      <div class="table-header-cell">
                        Airport Name
                     </div>
                    <div class="table-header-cell">
                        Fuel Available
                    </div>      
                </div>
                <div id="resp-table-body">
                               
                </div>
            </div >
            
        `
        
        $(".content").html("");
        $(".content").append(headingTemplate);
        for (data of datas) {

            let template = fillSummaryTemplateData(data.AirportName, data.FuelAvailability)
            $(".content #resp-table-body").append(template);
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
                console.log("Fuel Report Done", responce.d)
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
             <div class="flex-column">
                <div class="flex-row marginBottom-5" >
                    <label class="width-10" >From</label>
                    <input type="date" class="padding-5" id="reportStartingDate" value=${startDate}>
                    
                </div>
                <div class="flex-row marginBottom-5">
                    <label class="width-10">To</label>
                    <input type="date" id="reportEndingDate" value="${endDate}" class="marginRight-10 padding-5">
                    
                    <button id="searchFuelReportBtn" class="marginRight-10 width-10">Find</button>

                    
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
                 <div id = "resp-table" >
                    <div id="resp-table-header">
                        <div class="table-header-cell">
                               Date
                        </div>
                        <div class="table-header-cell">
                                Type
                        </div>
                        <div class="table-header-cell">
                                Fuel
                        </div>
                        <div class="table-header-cell">
                             Aircraft No
                        </div>     
                    </div>
                    <div id="resp-table-body" class="airport${airportId}Data">
                               
                    </div>
                 </div >
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
                      <div class="resp-table-row">
                            <div class="table-body-cell">
                                ${date}
                            </div>
                            <div class="table-body-cell" >
                                ${type}
                            </div>
                            <div class="table-body-cell">
                                ${fuelQuantity}
                            </div>
                            <div class="table-body-cell">
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