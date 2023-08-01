$(document).ready(async function () {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    ids = urlParams.get('UserId');

    if (ids != null) {
        getData(ids);
        function getData(ids) {
            var data = { "name": ids };
            $.ajax({
                type: "POST",
                data: JSON.stringify(data),
                url: "WebForm1.aspx/sendData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    loadData2(responce.d)
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })
        }
    } else {
        async function initiate() {

            fetchdata("country", "countries", "", "GetCountry");
            $("#country").change(function () {
                $(`#${$(`#state`).attr("errorId")}`)
                    .text("State requried")
                    .css("visibility", "visible");
                fetchdata("state", "states", country.value, "state_name");
            });
            /*$("#state").change(function () {
                $(`#${$(`#city`).attr("errorId")}`)
                    .text("city requried")
                    .css("visibility", "visible");
                fetchdata("city", "cities", state.value, "city_name");
            });*/

            fetchdata("presentCountry", "countries", "", "GetCountry");
            $("#presentCountry").change(function () {
                $(`#${$(`#presentState`).attr("errorId")}`)
                    .text("State requried")
                    .css("visibility", "visible");
                fetchdata("presentState", "states", presentCountry.value, "state_name");
            });
            /* $("#presentState").change(function () {
                 $(`#${$(`#presentCity`).attr("errorId")}`)
                     .text("city requried")
                     .css("visibility", "visible");
                 fetchdata("presentCity", "cities", presentState.value, "city_name");
             });*/
        }
        await initiate();

    }
  

    

   
    
    function loadData2(datas) {
        if (datas.length != 0) {
            $("#firstnameinp").val(datas["userFirstName"]);
            $("#emailinp").val(datas["userEmail"]);

            $("#lastnameinp").val(datas["userLastName"]);
            $("#dobinp").val(datas["userDob"]);
            $("#genderinp").val(datas["userGender"]);

            fetchdata("country", "countries", "", "GetCountry");
            $("#country").val(datas["userPermanentCountry"]);

            fetchdata("state", "states", country.value, "state_name");
            $("#state").val(datas["userPermanentState"]);

            fetchdata("presentCountry", "countries", "", "GetCountry");
            $("#presentCountry").val(datas["userPresentCountry"]);

            fetchdata("presentState", "states", presentCountry.value, "state_name");
            $("#presentState").val(datas["userPresentState"]);

            $("#AddressLine1").val(datas["userPermanentAddress1"]);
            $("#AddressLine2").val(datas["userPermanentAddress2"]);
            $("#postal").val(datas["userPermanentPostal"]);
            $("#city").val(datas["userPermanentCity"]);

            $("#presentAddressLine1").val(datas["userPresentAddress1"]);
            $("#presentAddressLine2").val(datas["userPresentAddress2"]);
            $("#present-postal").val(datas["userPresentPostal"]);
            $("#presentCity").val(datas["userPresentCity"]);

            
            
        }
    }

    $("#state").click(function () {
        checkforEmpty("state", "country");
    });
    $("#presentState").click(function () {
        checkforEmpty("presentState", "presentCountry");
    });
    $("#presentCity").click(function () {
        checkforEmpty("presentCity", "presentState");
    });
    $("#city").click(function () {
        checkforEmpty("city", "state");
    });

    function checkforEmpty(child, parent) {
        if ($(`#${parent}`).val() == null) {
            $(`#${$(`#${child}`).attr("errorId")}`)
                .text(`select ${parent} first`)
                .css("visibility", "visible");
        }
    }

    $("input").on("input", function () {
        let val = checkforEmptyData($(this), $(this).val() == 0);
    });
    $("select").on("input", function () {
        let val = checkforEmptyData($(this), $(this).val() == null);
    });

    async function fetchdata(child, url, parent, name) {
        $(`#${child}`).text("");
        $("<option/>", { selected: true, disabled: true, hidden: true })
            .text(`Tap To Select ${url}`)
            .appendTo(`#${child}`);

        if (name == "GetCountry") {
            getCountry();
        } else if (name == "state_name") {
            getState();
        }

       function getCountry() {
            $.ajax({
                type: "POST",
                url: "WebForm1.aspx/GetCountry",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async:false,
                success: function (responce) {
                    console.log("succes " + responce.d);
                    LoadData(responce.d);
                },
                failure: function (response) {
                    console("failure" + response.d);
                }

            });
        }
        function getState() {
            var data = { "name": parent };
            $.ajax({
                type: "POST",
                data: JSON.stringify(data),
                url: "WebForm1.aspx/GetState",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (responce) {
                    console.log("succes " + responce.d);
                    LoadData(responce.d);

                },
                failure: function (response) {
                    console("failure" + response.d);
                }

            });
        }
       

        function LoadData(datas) {
            if (datas.length == 0) {
                 $("<option/>", { value: parent }).text(parent).appendTo(`#${child}`);
            }
            else {
               for (let data of datas) {
                   $("<option/>", { value: data }).text(data).appendTo(`#${child}`);
               }
            }
        }
        
    }

    $("#copydataCheckbox").click(async function () {
        if ($("#copydataCheckbox")[0].checked) {
            let flag = checkforError("permanent-details");
            if (flag) {
                $("#presentAddressLine1").val($("#AddressLine1").val());
                $("#presentAddressLine2").val($("#AddressLine2").val());
                $("#present-postal").val($("#postal").val());
                $("#presentCountry").val($("#country").val());

                await fetchdata("presentState", "states", country.value, "state_name");
                $("#presentState").val($("#state").val());
                await fetchdata("presentCity", "cities", state.value, "city_name");
                $("#presentCity").val($("#city").val());
                checkforError("present-details");
            } else {
                $("#copydataCheckbox")[0].checked = false
            }
        }
        else {
            $("#presentAddressLine1").val("");
            $("#presentAddressLine2").val("");
            $("#present-postal").val("");
            fetchdata("presentCountry", "countries", "", "country_name");
            fetchdata("presentState", "states", country.value, "state_name");
            fetchdata("presentCity", "cities", state.value, "city_name");
            console.log($("#copydataCheckbox")[0].checked)

        }
    });
    function checkforError(id) {
        let flag = 1;
        let cnt = 0;
        $(`#${id} input `).each(function () {
            if ($(this).attr("errorId")) {
                flag = checkforEmptyData($(this), $(this).val().length === 0);
                if (cnt == 0 && flag == 0) {
                    $(`#${$(this).attr("errorId")}`)[0].scrollIntoView(false);
                    cnt++;
                }
            }
        });
        $(`#${id} select `).each(function () {
            if ($(this).attr("errorId")) {
                flag = checkforEmptyData($(this), $(this).val() == null);
                if (cnt == 0 && flag == 0) {
                    $(`#${$(this).attr("errorId")}`)[0].scrollIntoView(false);
                    cnt++;
                }
            }
        });
        return flag;
    }
    function checkforEmptyData(id, flag) {
        if (flag) {
            $(`#${$(id).attr("errorId")}`).css("visibility", "visible");
            return 0;
        } else {
            $(`#${$(id).attr("errorId")}`).css({ "visibility": "hidden" });
            return 1;
        }
    }

    $("#hobby").click(function (e) {
        e.preventDefault();
        $("#hobbiesDiv").toggleClass("hobbiesVisible");
    });

    $("#profileimg").on("change", function (e) {
        let newsrc = URL.createObjectURL(e.target.files[0]);
        $("#photo").attr("src", newsrc);
    });

    $("#submitButton").click(function (e)
    {
        e.preventDefault();
       //let flag = checkforError("userProfile");
        // email
        let flag = 1;
        if (flag==1)
        {
            $("#userHobbies").text("");
            let objectData = {}
            $("#userProfile input").each(function () {
                if ($(this).attr("data_id")) {
                    $(`#${$(this).attr("data_id")}`).text(
                        $(this).val() ? $(this).val() : "NA"
                    );
                    //console.log("sadas- ",$(`#${$(this).attr("data_id")}`)[0].id)
                    //console.log("sadas- ",$(this).attr("data_id") )
                    let x = $(this).attr("data_id")
                    objectData[x] = $(this).val()
                    //console.log(objectData[x])
                }
                if ($(this).attr("attrChk")) {
                    $("#userSubcription").text(this.checked ? "Yes" : "No");
                    objectData["userSubcription"] = $("#userSubcription").html()
                }
            });
             var Roles = "";
            $("#hobbiesDiv input").each(function () {
                if (this.checked) {
                    console.log($(this).val());
                    Roles += $(this).val() + ",";
                }
            })
            Roles.substring(0, Roles.length - 1);
            objectData.Roles = Roles;
            objectData["userHobbies"] = $("#userHobbies").html()
            $("#userProfile select").each(function () {
                if ($(this).attr("data_id")) {
                    $(`#${$(this).attr("data_id")}`).text($(this).val());
                    let x = $(this).attr("data_id");
                    objectData[x] = $(this).val()
                }
            });

            pushData();
           
          
            window.location.href = "webform2"

            function pushData() {
                $.ajax({
                    type: "POST",
                    url: "WebForm1.aspx/GetData",
                    data: JSON.stringify({ data: objectData }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    success: function (responce) {
                        console.log("succes " + responce.d);
                    },
                    failure: function (response) {
                        console.log("failure" + response.d);
                    }

                })
            }
        }
    });
});
