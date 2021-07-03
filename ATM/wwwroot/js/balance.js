$(document).ready(function () {

    $('.table_teclado tr td').click(function () {
        var number = $(this).text();

        if (number != "") {

            if (number == "Atras") {

                window.location.href = '/Home/PageOperations?NumberCard=' + $("#NumberCard").text();

            }
            if (number == "Salir") {

                window.location.href = '/Home/Index';

            }


        }

    });
});