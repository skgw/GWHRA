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