// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelector(".search-bar button").addEventListener("click", function () {
	document.getElementById("searchInput").focus();
});


$(document).ready(function () {
    $("#SelectedYear").change(function () {
        var selectedYear = $(this).val();
        $.get(`/CarInfo/GetBrandsByYear?year=${selectedYear}`, function (data) {
            $("#Brand").empty();
            $("#Brand").append(new Option("Select Brand", ""));
            $.each(data, function (index, brand) {
                $("#Brand").append(new Option(brand.name, brand.id));
            });
        });
    });
});



