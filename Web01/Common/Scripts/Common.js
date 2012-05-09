$(function () {
//    $("#nav li").css({list-style-type: "none", display: "inline"});
//    alert('ok');
});

function hovermenu() {
    
    $("#nav li").hover(function () {
        $(this).find('ul:first').css({ visibility: "visible", display: "none" }).show(400);
    }, function () {
        $(this).find('ul:first').css({ visibility: "hidden" });
    });
}

$(document).ready(function () {
    hovermenu();
});
function getQueryStringByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.search);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}