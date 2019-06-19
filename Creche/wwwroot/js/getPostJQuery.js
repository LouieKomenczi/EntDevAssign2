$(document).ready(function () {
    var temp = 0;
    var decription = "";
    $.getJSON("http://api.openweathermap.org/data/2.5/weather?q=Sligo,Ie&units=metric&APPID=fdf7895fafa873b96a6735347df8c15c", function (data) {         
        $("#temp").html("Temperature in Sligo is " + data.Rootobject.Main.Temp + " Celsius with " + data.weather[0].description);
    })
    })
    