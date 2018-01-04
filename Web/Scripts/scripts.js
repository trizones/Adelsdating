$(function() {
    $.ajax({
        type: "POST",
        success: function (result) {
            var url = "https://d30y9cdsu7xlg0.cloudfront.net/png/38220-200.png";
            if (result.HasRequests) {
                document.getElementById("hasRequests").src = url;
            }
        }
    });
});