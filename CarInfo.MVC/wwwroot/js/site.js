// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelector(".search-bar button").addEventListener("click", function () {
	document.getElementById("searchInput").focus();
});



$(document).ready(function () {
    // Funkcja do ładowania danych do form-select
    function loadOptions(url, selectElement) {
        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            success: function (data) {
                selectElement.empty();
                $.each(data, function (index, item) {
                    selectElement.append('<option value="' + item + '">' + item + '</option>');
                });
                selectElement.prop("disabled", false);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    }

    // Ładujemy dane marek do pierwszego form-select przy załadowaniu strony
    loadOptions('/Vehicle/GetBrands', $('#brandSelect'));

    // Obsługa zmiany wyboru marki pojazdu
    $('#brandSelect').on('change', function () {
        var selectedBrand = $(this).val();
        var modelSelect = $('#modelSelect');
        var versionSelect = $('#versionSelect');

        // Resetujemy form-select dla modelu i wersji
        modelSelect.empty().prop("disabled", true);
        versionSelect.empty().prop("disabled", true);

        // Jeśli wybrano markę, ładujemy odpowiednie modele
        if (selectedBrand) {
            loadOptions('/Vehicle/GetModels?brand=' + selectedBrand, modelSelect);
        }
    });

    // Obsługa zmiany wyboru modelu pojazdu
    $('#modelSelect').on('change', function () {
        var selectedBrand = $('#brandSelect').val();
        var selectedModel = $(this).val();
        var versionSelect = $('#versionSelect');

        // Resetujemy form-select dla wersji
        versionSelect.empty().prop("disabled", true);

        // Jeśli wybrano markę i model, ładujemy odpowiednie wersje
        if (selectedBrand && selectedModel) {
            loadOptions('/Vehicle/GetVersions?brand=' + selectedBrand + '&model=' + selectedModel, versionSelect);
        }
    });
});