"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/letsChatHub").build();
console.log(connection);

connection.on("ReceiveConnectionUpdated", function (resp) {
    $("#connectionId").val(resp)
    
});
$.when($.ready).done(function () {
    start();
  
    //GetNotifications();   
});

async function start() {
    try {
        
        await connection.start().then(function (res) {
            console.log(res);            
            connection.invoke("UpdateConnectionId").catch(function (err) {
                return console.error(err.toString());
            });
           
        });
    } catch (err) {
        start();
    }
};


connection.onclose(async () => {
    debugger
    await start();
});
function currentTime() {
    return new Date().toLocaleString('en-GB', {
        day: 'numeric',
        month: 'short',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit'
    });
}
$("#broadcastGroupMessage").click(function () {
 
   
        var dataGroupName = $('#joinedGroup').text();
        //IF SAME CHAT GROUP THEN DONT CREATE NEW CHAT ROOM OTHERWISE CREATE NEW CHAT ROOM
        console.log(connection);
        //connection.invoke('JoinGroup');
        // Save data to sessionStorage
        //sessionStorage.setItem('GroupName', $('#txtGroupName').val());

        //$('#messagesGroup').append('<div class="bubble-right">' + $('#txtName').val() + " : " + $('#txtMessage').val() + '<br>' + currentTime() + '</div>');
    $('#messagesGroup').append(` <li class="user-avatar rightside user1">
                <div class="msg-area status available ">
                    <img src="/assets/images/user-34.jpg" alt="Anas Lyle" title="Anas Lyle"
                         class="circle userpic">
                    <p class="msg">${$('#txtMessage').val()}</p>
                </div>
                <span class="time">${currentTime()}</span>
            </li>`);
        // Call the chatGroup method on the server
        connection.invoke('sendGroupMessage', { Message: $('#txtMessage').val() });
        $('#txtMessage').val('');
        
});
connection.on("addNewGroupMessageToPage", function (response) {
    console.log(response);
    if (response.connectionId != $("#connectionId").val()) {
        $('#messagesGroup').append(` <li class="user-avatar leftside user1">
                <div class="msg-area status available ">
                    <img src="/assets/images/user-34.jpg" alt="Anas Lyle" title="${response.name}"
                         class="circle userpic">
                    <p class="msg">${response.message}</p>
                </div>
                <span class="time">${currentTime()}</span>
            </li>`);
    }
    
});

connection.on("ReceiveNotification", function () {
    GetNotifications();
});
function GetNotifications() {
    //$('#NotificationPanel').load("/Notifications/GetNotifications", function () {
    //    $.get("/Notifications/GetUnReadNotificationCount", function (data) {
    //         $('.notificationCount').text(data);
    //    })
        //AjaxGenericCalls.ajaxRequest(paramObj).then(function (resp) {
        //    $('.notificationCount').text(resp);
        //    Notifications.GenerateNotification("Request Notifications:", "You have received " + resp + " notification", "warning");
        //});
    //});
}


function getMaxOfMessagesArray(numArray, existingArray) {
    var maxValue = Math.max.apply(null, numArray);
    if (existingArray.filter(x => x == maxValue).length > 0) {
        numArray.pop(maxValue);
        getMaxOfMessagesArray(numArray, existingArray);
    } else {
        return maxValue;
    }
}
function MarkRead(Id, IsMsgRead, elem) {
    //   console.log("here");
    if (IsMsgRead == false) {
        var paramObj = {
            url: '/Approvals/MarkRead',
            type: 'GET',
            dataType: "json",
            data: { "Id": Id }
        };
        AjaxGenericCalls.ajaxRequest(paramObj).then(function (resp) {
            GetMessages();
        });
    } else {

    }
    $('body').on('click', function (e) {
        $('.msgPopOver').each(function () {
            //the 'is' for buttons that trigger popups
            //the 'has' for icons within a button that triggers a popup
            if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
                $(this).popover('hide');
            }
        });
    });
    $(elem).popover('toggle');
}


function GoToApplication(url) {
    window.location.href = url;
}

