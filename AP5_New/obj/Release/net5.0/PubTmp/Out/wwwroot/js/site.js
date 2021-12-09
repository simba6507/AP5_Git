// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ShowDateTime() {
    var d = new Date();
    var date = d.getDate();
    var month = d.getUTCMonth() + 1;
    var year = d.getFullYear();
    var h = d.getHours();
    var m = d.getMinutes();
    var s = d.getSeconds();
    var time = year + "/" + month + "/" + date + "      ";
    time += ((h > 12) ? h - 12 : h);
    time += ((m < 10) ? ":0" : ":") + m;
    time += ((s < 10) ? ":0" : ":") + s;
    time += (h >= 12) ? " PM." : " AM.";
    showDateTime.innerHTML = time;
    setTimeout('ShowDateTime()', 1);
}