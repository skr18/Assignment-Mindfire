$(document).ready(async function () {
            $.ajax({
                type: "GET",
                url: "UserListTabularPage.aspx/GetAllUserData",
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
               <div class="details">
                   <div>${item.UserId}</div>
                    <div>${item.userFirstName}</div>
                    <div>${item.userEmail}</div>
                    <div>${item.Roles}</div>               
                    <button id="editBtn">Edit</button>
                    <button id="deleteBtn">Delete</button>
               </div>
        `;
        return template;

    }
    function loadNewData(data) {

        for (var item of data) {
            console.log(item.userFirstName);
          /* template.replace[] = item.UserId;
            template.replace[] = item.UserId;
            template.replace[2] = item.UserId;
            template.replace[3] = item.UserId;*/

          /*  document.getElementById("userId").innerHTML= item.UserId
            $("name").val(item.userFirstName);
            $("email").val(item.userEmail)
            $("role").val(item.Roles)*/
            //$("details").

          
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
        var userId = parent.firstElementChild.innerHTML;

        if (node.id == "editBtn") {
            window.location.href = `registrationpage?UserId=${userId}`
        } else {
            $.ajax({
                type: "POST",
                data: JSON.stringify({ Id: userId }),
                url: "UserListTabularPage.aspx/deleteData",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (responce) {
                    console.log("hurray",responce.d)
                    location.reload();
                },
                failure: function (response) {
                    alert("failure" + response.d);
                }

            })
        }

    })
    
});