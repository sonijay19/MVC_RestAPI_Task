function httpGet() {
    var theUrl = 'https://localhost:44372/api/v1/GetUserDetails'
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", theUrl, false); // false for synchronous request
    xmlHttp.send();
    var response = JSON.parse(xmlHttp.responseText);
    return response.userDetails;
}

function httpUpdateUserDetailsOne(item) {
    var Newurl = "https://localhost:44372/api/v1/UpdateUserDetails"
    var json = JSON.stringify(item);
    console.log(json)
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", Newurl, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onload = function () {
        var users = JSON.parse(xhr.responseText);
        console.log(users)
        if (users.success) {
            alert("User Update Successfully")
            location.reload();
        }
        else {
            alert(users.errorCode);
            location.reload();
        }
    }
    xhr.send(json);
}

function InsertUserData(item) {
    var Newurl = "https://localhost:44372/api/v1/CreateUser"
    var json = JSON.stringify(item);
    console.log(json)

    var xhr = new XMLHttpRequest();
    xhr.open("PUT", Newurl, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onload = function () {
        var users = JSON.parse(xhr.responseText);
        console.log(users)
        if (users.success) {
            alert("User Is Created Successfully")
            location.reload();
        }
        else {
            alert(users.errorCode);
            location.reload();
        }
    }
    xhr.send(json);
}

function DeleteUserData(item) {
    var Newurl = "https://localhost:44372/api/v1/DeleteUser"
    var obj = {
        "UserId": item.userId.toString()
    }
    var json = JSON.stringify(obj);
    console.log(json)

    var xhr = new XMLHttpRequest();
    xhr.open("DELETE", Newurl, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    xhr.onload = function () {
        var users = JSON.parse(xhr.responseText);
        console.log(users)
        if (users.success) {
            alert("User Is Deleted Successfully")
            location.reload();
        }
        else {
            alert(users.errorCode);
            location.reload();
        }
    }
    xhr.send(json);
}

var accessType = document.getElementById("accessType").value;
var access = ""
var Editting = true
var OnlyUpdate = { type: "control", deleteButton: false }
var UpdateDelete = {
    type: "control",
    deleteButton: true,
    editButton: false,
    itemTemplate: function (value, item) {
        var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

        var $customButton = $("<button>").attr({ class: "customGridDeletebutton jsgrid-button jsgrid-edit-button" })
            .click(function (e) {
                alert("ID: " + item.id);
                e.stopPropagation();
            });

        return $result.add($customButton);
    },
}
var GridFields = [
    { name: "userEmail", type: "text", width: 200, validate: "required" },
    { name: "firstName", type: "text", width: 180, validate: "required" },
    { name: "lastName", type: "text", width: 180, validate: "required"},
    { name: "phoneNumber", type: "text", width: 180, validate: "required" },
    { name: "userStatus", type: "text", width: 180, validate: "required"},
]
function AddElement(type) {
    if (type === "FullAccess") {
        var AddElement = {
            controller: {
                insertItem: function (value, item) {
                    console.log(item)
                },
            }
        }
        return AddElement
    }
    return false
}

var component = {
    type: "control",
    deleteButton: false,
    editButton: true,
}

var componentFull = {
    type: "control",
    deleteButton: true,
    editButton: true,
}
var UpdateButton = {
    name: "Update", width: 70,
    editing: false,
    itemTemplate: function (value, item) {
        var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

        var $customButton = $(`<button class="btn btn-primary">`)
            .text('Update')
            .click(function (e) {
                e.stopPropagation();
                console.log(item)
                httpUpdateUserDetailsOne(item)
                //var obj = JSON.stringify(item, undefined, 5)
                //alert(`Data is : ${obj}`);
            });

        return $result.add($customButton);
    }
}
var DeleteButton = {
    name: "Delete", width: 70,
    itemTemplate: function (value, item) {
        var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

        var $customButton = $(`<button class="btn btn-primary">`)
            .text('Delete')
            .click(function (e) {
                e.stopPropagation();
                DeleteUserData(item)
            });

        return $result.add($customButton);
    }
}

//GetEditting
function GetAllFields(MyaccessType) {
    if (MyaccessType === "StandardAccess") {
        GridFields.push(UpdateButton)
        GridFields.push(component)
        //GridFields.push(OnlyUpdate)
        return GridFields;
    }
    else if (MyaccessType === "ViewOnlyAccess") {
        return GridFields;

    }
    else {
        GridFields.push(UpdateButton)
        GridFields.push(DeleteButton)
        GridFields.push(componentFull)
        //GridFields.push(UpdateDelete)
        return GridFields;
    }
}

function Inserting(type) {
    if (type === "FullAccess") {
        return true
    }
    return false
}

function GetEditting(MyaccessType) {
    if (MyaccessType === "StandardAccess") {
        return false
    }
    else if (MyaccessType === "ViewOnlyAccess") {
        return false
    }
    return true
}

console.log(accessType)


$("#jsGrid").jsGrid({
        width: "100%",
        height: "100%",
    inserting: Inserting(accessType),
    onItemInserting: function (item) {
        InsertUserData(item.item);
    },
    onItemDeleting: function (item) {
        DeleteUserData(item.item);
        //location.reload();
    },
    data: httpGet(),
    editing: GetEditting(accessType),
    fields: GetAllFields(accessType)
});

var ButtonField = function (config) {
    jsGrid.Field.call(this, config);
};


ButtonField.prototype = new jsGrid.Field({
    css: "date-field",
    align: "center",
    filtering: false,
    sorting: false,
    editing: false,
    label: "Button",
    itemTemplate: function (value, item) {
        var self = this;
        var $customButton = $("<button>")
            .text(this.label)
            .click(function (e) {
                self.onClick(item);
                e.stopPropagation();
            });
        return $customButton;
    }
});

jsGrid.fields.button = ButtonField;


/*
 * 
 *  [
            { name: "userId", type: "text", width: 60 },
            { name: "userEmail", type: "text", width: 200 },
            { name: "firstName", type: "text", width: 180 },
            { name: "lastName", type: "text", width: 180 },
            { name: "PhoneNumber", type: "text", width: 180 },
            { name: "userStatus", type: "text", width: 180 },
            {
                name: "Update", width: 75,
                itemTemplate: function (value, item) {
                    var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

                    var $customButton = $(`<button ${access} class="btn btn-primary">`)
                        .text('Update')
                        .click(function (e) {
                            alert(e.data)
                            //alert($("#userId").val)
                            var obj = JSON.stringify(item, undefined, 5)
                            alert(`Data is : ${obj}`);
                            e.stopPropagation();
                        });

                    return $result.add($customButton);
                }
            },
            {
                name: "Delete", width: 70,
                itemTemplate: function (value, item) {
                    var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

                    var $customButton = $(`<button class="btn btn-primary">`)
                        .text('Delete')
                        .click(function (e) {
                            var obj = JSON.stringify(item, undefined, 5)
                            alert(`Data is : ${obj}`);
                            e.stopPropagation();
                        });

                    return $result.add($customButton);
                }
            }
        ]
 */