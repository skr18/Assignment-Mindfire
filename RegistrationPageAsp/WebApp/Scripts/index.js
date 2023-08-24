$(document).ready(async function () {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    id = urlParams.get('UserId');

    if (id != null) {
        getData(id);
        function getData(ids) {
            var data = { "UserId": id };
            $.ajax({
                type: "POST",
                data: JSON.stringify(data),
                url: "RegistrationPage.aspx/sendUserData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    loadNewData(responce.d)
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })
        }
    } else {
        async function initiate() {

            fetchdata("country", "countries", "", "GetCountry");


            fetchdata("presentCountry", "countries", "", "GetCountry");

        }
        await initiate();

    }

    var isAdmin;
    checkIfAdmin();

    function checkIfAdmin() {
        $.ajax({
            type: "GET",
            url: "RegistrationPage.aspx/checkIsAdmin",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                isAdmin = responce.d;
                console.log("yes " + responce.d)

                if (isAdmin == true) {
                    addCheckBox();
                    
                   // $("#logout").set("Back To UsersList")
                }
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
    }
   
    function addCheckBox() {
        $("#privateCheckboxDiv").removeClass();
    }
    $("#privateMsgCheckbox").click(function () {
        var data = { "isChecked": "true" };
        $.ajax({
            type: "POST",
            data: JSON.stringify(data),
            url: "RegistrationPage.aspx/sendDataToUserControl",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                console.log("done")
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
        

    });


    $("#country").change(function () {
        $(`#${$(`#state`).attr("errorId")}`)
            .text("State requried")
            .css("visibility", "visible");
        fetchdata("state", "states", country.value, "state_name");
    });
    $("#presentCountry").change(function () {
        $(`#${$(`#presentState`).attr("errorId")}`)
            .text("State requried")
            .css("visibility", "visible");
        fetchdata("presentState", "states", presentCountry.value, "state_name");
    });
    
    function loadNewData(datas) {
        if (datas.length != 0) {
            $("#firstnameinp").val(datas["userFirstName"]);
            $("#emailinp").val(datas["userEmail"]);
            $("#passinp").val(datas["userPassword"]);

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

            AllRoles = datas.Roles.split(",");
            $("#rolesDiv input").each(function () {
                if (AllRoles.includes($(this).val())) {
                    this.checked = true;
                }
            })
            if (datas["userSubcription"] == "True") {
                $("#userProfile input").each(function () {
                    if ($(this).attr("attrChk")) {
                        this.checked = true;
                    }
                });
            }
           // $("#<%=submitButton.ClientID%>").val('InActivate');
            //document.getElementById("submitButton").innerHTML = "Update";
            $("#submitButton").attr('value', 'Update');
            $("#BackButton").attr('value', 'Cancel');
            $("#UserNotes").css('display', 'block');
        }
    }

    $("#home").click(function () {
        setHomeTab();
    });
    function setHomeTab() {

        $("#document").removeClass();
        $("#note").removeClass();
        $("#home").addClass("active");
       // Cookies.set('activeTab', 'home');
       // document.cookie = "activeTab=home"
        $("#userProfile").removeClass();
        $("#userProfile").addClass("container");
        $("#userNotes").addClass("hide");
        $("#userDocuments").addClass("hide");
    }

    $("#note").click(function () {
        if (id == null) {
            alert("First You Need to Register to acces these feature")
        } else {
            
            setNoteTab();
        }

    });
    $("#logout").click(function () {
        if (id == null) {
            alert("First You Need to Register to acces these feature")
        } else {
            window.location.href = "loginpage";
        }

    });
    function setNoteTab() {
        $("#home").removeClass();
        $("#document").removeClass();
        $("#note").addClass("active");
       // document.cookie = "activeTab=note"
        //Cookies.set('activeTab', 'note');
        $("#userNotes").removeClass();
        $("#userNotes").addClass("container");
        $("#userProfile").addClass("hide");
        $("#userDocuments").addClass("hide");
    }

    $("#document").click(function () {

        if (id == null) {
            alert("First You Need to Register to acces these feature")
        } else {
            setDocTab();
        }

    });
    function setDocTab() {
        $("#home").removeClass();
        $("#note").removeClass();
        $("#document").addClass("active");
       // document.cookie = "activeTab=doc"
        $("#userDocuments").removeClass();
        $("#userDocuments").addClass("container");
        $("#userNotes").addClass("hide");
        $("#userProfile").addClass("hide");
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
                type: "GET",
                url: "RegistrationPage.aspx/GetCountry",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async:false,
                success: function (responce) {
                    console.log("succes " + responce.d);
                    LoadData(responce.d);
                },
                failure: function (response) {
                    console("failure to load country" + response.d);
                }

            });
        }
        function getState() {
            var data = { "name": parent };
            $.ajax({
                type: "POST",
                data: JSON.stringify(data),
                url: "RegistrationPage.aspx/GetState",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (responce) {
                    console.log("succes " + responce.d);
                    LoadData(responce.d);
                },
                failure: function (response) {
                    alert("failure to load state" + response.d);
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
        let flag = 0;
        let cnt = 0;
        let ans = 1;
        $(`#${id} input `).each(function () {
            if ($(this).attr("errorId")) {
                flag = checkforEmptyData($(this), $(this).val().length === 0);
                if (cnt == 0 && flag == 0) {
                    ans=0
                    $(`#${$(this).attr("errorId")}`)[0].scrollIntoView(false);
                    cnt++;
                }
            }
        });
        $(`#${id} select `).each(function () {
            if ($(this).attr("errorId")) {
                flag = checkforEmptyData($(this), $(this).val() == null);
                if (cnt == 0 && flag == 0) {
                    ans = 0;
                    $(`#${$(this).attr("errorId")}`)[0].scrollIntoView(false);
                    cnt++;
                }
            }
        });
        return ans;
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
        $("#rolesDiv").toggleClass("hobbiesVisible");
    });

    var newsrc;
    $("#profileimg").on("change", function (e) {
        newsrc = URL.createObjectURL(e.target.files[0]);
        $("#photo").attr("src", newsrc);
        newsrc = $("#profileimg").get(0).files[0].name;
        imgData = $("#profileimg").get(0).files[0]
        console.log(newsrc)
        console.log(imgData)
        const formData = new FormData();
        formData.append(newsrc,imgData);
        console.log(formData)
        
        $.ajax({
            type: "POST",
            data: formData,
            url: "ImageHandler.ashx",
            processData: false,
            contentType: false,
            success: function (responce) {
                console.log("done")
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
    });
    $("#BackButton").click(function (e) {
        e.preventDefault();
       
        if (isAdmin == true) {
            window.location.href = "userslistpage";
        } else {
            window.location.href = "loginpage";
        }
    });

    


    //Notess

    getnotes();
    function getnotes(){
        $.ajax({
            type: "GET",
            url: "RegistrationPage.aspx/GetAllUserNoteData",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                loadNoteData(responce.d)
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
    }



    function addDataToTemplate(item) {

        var template = `
               <div class="details_notes">
                    <div style="display:none">${item.NoteId}</div>  
                    <div >${item.Note}</div>           
                    <div>${item.AddedBy}</div>           
                    <div>${item.Date}</div>           
                    <button style="background-color: blue;color: white;margin-left:25px;">Edit</button>
                    <button style="background-color: red;" >Delete</button>
               </div>
        `;
        return template;

    }
    function loadNoteData(data) {
       $("#container_note").html("");  
        for (var item of data) {
            var template = addDataToTemplate(item)
            $("#container_note").append(template)       
            //document.getElementById("container").appendChild(template)
        }
    }

    $("#btnAdd").on("click", function (e) {
        e.preventDefault();
        console.log("text -- ", $("#txtNote").val());
        var textNote = $("#txtNote").val();
        $.ajax({
            type: "POST",
            data: JSON.stringify({ text: textNote }),
            url: "RegistrationPage.aspx/InsertsNote",
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (responce) {
                //console.log("hurray", responce.d)
                $("#txtNote").val("");
                //document.getElementById("txtNote").innerHTML = "";
                getnotes();
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
    })
   
    $("#container_note").on("click", 'button', function (e) {
        e.preventDefault();
        console.log("i am called ", this);
        var node = this
        var parent = node.parentElement;
        var NoteId = parent.firstElementChild.innerHTML;
        console.log("noteID", node.innerHTML)
        var noteInp = parent.firstElementChild.nextElementSibling;

        console.log(noteInp);
        let text = noteInp.innerHTML;
        console.log("asd - ", text);
       

        if (node.innerHTML == "Update") {
            let text = noteInp.firstElementChild.value;
            console.log("update called", NoteId, text);

            $.ajax({
                type: "POST",
                data: JSON.stringify({ Id: NoteId , Text:text}),
                url: "RegistrationPage.aspx/updateNoteData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    console.log("note updated", responce.d)
                    getnotes();
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })

        }
        else if (node.innerHTML == "Cancel") {
            let cancelBtn = node; 
            let updateBtnp = node.previousElementSibling;

            updateBtnp.innerHTML = "Edit"
            cancelBtn.innerHTML = "Delete"
            
            getnotes();
        }

        else if (node.innerHTML == "Edit") {
           
            let updateBtn = node;
             let cancelBtn = node.nextElementSibling; 
            updateBtn.innerHTML = "Update"
            cancelBtn.innerHTML = "Cancel"
           noteInp.innerHTML = '<input style="width:85%" value="' + noteInp.innerText + '">';
          
        }
       else if (node.innerHTML == "Delete") {
            console.log("node-id", node.innerHTML)
            $.ajax({
                type: "POST",
                data: JSON.stringify({ Id: NoteId }),
                url: "RegistrationPage.aspx/deleteNoteData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    console.log("note deleted", responce.d)
                    getnotes();
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })
        }
        
    })




    //Documents

    $.ajax({
        type: "GET",
        url: "RegistrationPage.aspx/GetAllUserDocuments",
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (responce) {
            //console.log("Ajax")
            loadDocuments(responce.d)
        },
        failure: function (response) {
            alert("failure" + response.d);
        }

    })

    var Img;
    function addDocumentsToTemplate(item) {

        var template = `
               <div class="details_doc">
                    <div style="display:none;">${item.DocumentID}</div>  
                    <div>
                        <img src="${Img}" width="60" height="60" style="mix-blend-mode: darken;">
                    </div>
                    <div id="docInfo">
                        <div>${item.DocumentUrl}</div> 
                         <div>Size:</div> 
                         <div>Uploaded By: ${item.AddedBy}</div> 
                         <div>On: ${item.Date}</div> 
                    </div>          
                    <div> 
                        <button>
                             <img src="https://w7.pngwing.com/pngs/596/75/png-transparent-download-now-download-icon-download-button-download-logo-flat-icon-flat-logo-flat-image-button-flat-round-thumbnail.png"
                             width="60" height="60">
                        </button>
                    </div>              
               </div>
        `;
        return template;

    }
    function loadDocuments(data) {
        for (var item of data) {
            var ext = item.DocumentUrl.split(".");
            ext = ext[1];
            console.log(ext);
            if (ext == 'jpg' || ext == 'jpeg' || ext == "png" || ext == 'JPEG') {
                Img = "/Content/jpg.png"
            }
            else if (ext == "pdf") {
                Img = "../Content/pdf.jpg"
            } else if (ext == "txt") {
                Img = "../Content/txt.jpg"
            } else {
                Img="../Content/unknown"
            }
            var template = addDocumentsToTemplate(item)
            $("#containerDoc").append(template)
            
        }
    }



    $("#userDocuments button").on("click", function (e) {
        e.preventDefault();
        console.log("btn", this);
        var node = this
        var parent = node.parentElement.parentElement;
        console.log("node", parent)
        var NoteId = parent.firstElementChild.innerHTML;
        console.log("doc-id", NoteId)
       /* var NoteId = parent.firstElementChild.innerHTML;
        console.log("note-id", NoteId)
        console.log("node-id    ", node.innerHTML)*/
        const formData2 = new FormData();
        formData2.append("Id",NoteId);
        $.ajax({
            type: "POST",
            data: formData2,
            url: "FileDownloadHandler.ashx",
            processData: false,
            contentType: false,
            success: function (responce) {
                console.log("done")
            },
            failure: function (response) {
                alert("failure" + response.d);
            }

        })
       

    })


    $("#submitButton").click(function (e)
    {
        e.preventDefault();
       let flag = checkforError("userProfile");
        // email
        //let flag = 1;
        if (flag==1)
        {
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
                    var ischecked = this.checked;
                    console.log("ajj -- ", ischecked);
                    objectData["userSubcription"] = ischecked;
                }
            });
             var Roles = "";
            $("#rolesDiv input").each(function () {
                if (this.checked) {
                    console.log($(this).val());
                    Roles += $(this).val() + ",";
                }
            })
            Roles.substring(0, Roles.length - 1);
            objectData.Roles = Roles;

            $("#userProfile select").each(function () {
                if ($(this).attr("data_id")) {
                    $(`#${$(this).attr("data_id")}`).text($(this).val());
                    let x = $(this).attr("data_id");
                    objectData[x] = $(this).val()
                    
                }
            });
            objectData["UserPhoto"] = newsrc;
            console.log("abc -- ",newsrc);

            SendData();
           
            
            //window.location.href = "userlisttabularpage";

            function SendData() {
                $.ajax({
                    type: "POST",
                    url: "RegistrationPage.aspx/GetUserData",
                    data: JSON.stringify({ data: objectData }),
                    contentType: "application/json; charset=utf-8",
                    async: false,
                    dataType: "json",
                    success: function (responce) {
                        if (isAdmin == true) {
                            alert("User created sucessfully")
                        }
                        else if (id == null && isAdmin == false) {
                            alert("Registration Completed Now you need to login")
                            window.location.href = "loginpage"
                        } else {
                            alert("Data updated sucessfully")
                        }
                        console.log("succes " + responce.d);
                    },
                    failure: function (response) {
                        alert.log("failed to upload data" + response.d);
                    }

                })
            }
        }
    });
});
