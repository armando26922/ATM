
$(document).ready(function () {
    var contador = 0;
    $('#campo').val("ingrese el monto a retirar");
    $('.table_teclado tr td').click(function () {
        var number = $(this).text();
        if (number != "") {
            if (contador == 0) {
                $('#campo').val("");

            }
            contador = contador + 1;

            if (number == "Limpiar") {
                $('#campo').val("");
                contador = 0;
                $('#campo').val("ingrese el monto a retirar");

            }else if (number == "Salir") {

                window.location.href = '/Home/PageOperations?NumberCard=' + $("#NumberCards").text();

            }
            else if (number == "Aceptar") {
                //$.ajax({
                //    url: "Home/VerificarTarjeta", data: { NroTarjeta: $('#campo').val() }
                //}).done(function (data) {
                //    alert(data);
                //});
                window.location.href = '/Operations/ExtractMoney?NumberCard=' + $('#NumberCards').text() + "&Amount=" + $('#campo').val();
 
            }
            else {

                if (number == '') {
                    $('#campo').val($('#campo').val().substr(0, $('#campo').val().length - 1)).focus();
                }
                else {
                    $('#campo').val($('#campo').val() + number).focus();
                }
            }
        }

    });
});