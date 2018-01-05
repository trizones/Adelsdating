
        //Skickar JSON-data om det finns en ny friendrequest
function IfNewFriendrequest() {
    $.ajax({
        type: 'GET',
        url: '/WebApi/HasRequests',
        success: function (friendrequest) {
            if (friendrequest) {
                alert(friendrequest);
            }
            error: function (error) {
                alert(error);
                $(that).remove();
                DisplayError(error.statusText);
            }
            //Refreshar sidan efter lyckat inlägg.
            location.reload();

            setTimeout(IfNewFriendrequest, 5000);
        }
    });
    
}
IfNewFriendrequest();
