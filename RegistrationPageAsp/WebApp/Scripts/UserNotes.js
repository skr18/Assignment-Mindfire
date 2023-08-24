$(document).ready(async function () {
    $.ajax({
        type: "GET",
        url: "RegistrationPage.aspx/GetAllUserData",
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (responce) {
            console.log(responce.d)
            loadNewData(responce.d)
        },
        failure: function (response) {
            alert("failure" + response.d);
        }

    })


    function addDataToTemplate(item) {

        var template = `
               <div class="details_notes">
                   <div>${item.NoteId}</div>
                    <div>${item.Note}</div>           
                    <button id="editBtn_note">Edit</button>
                    <button id="deleteBtn_note">Delete</button>
               </div>
        `;
        return template;

    }
    function loadNewData(data) {

        for (var item of data) {
            console.log(item.userFirstName);

            var template = addDataToTemplate(item)
            $("#container").append(template)
            //document.getElementById("container").appendChild(template)
        }
    }
    $("#container button").on("click", function (e) {
        e.preventDefault();
        console.log(this.id);
        var node = this
        var parent = node.parentElement;
        var NoteId = parent.firstElementChild.innerHTML;

        if (node.id == "editBtn") {
            //window.location.href = `registrationpage?UserId=${NoteId}`
        } else {
            $.ajax({
                type: "POST",
                data: JSON.stringify({ Id: NoteId }),
                url: "RegistrationPage.aspx/deleteData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    console.log("hurray", responce.d)
                    location.reload();
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })
        }

    })

});