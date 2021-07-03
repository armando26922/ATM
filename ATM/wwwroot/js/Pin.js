var pinSend = "";
var contador = 0;
$(document).ready(function () {
    $('#campo').val("Ingrese el PIN");

    $('.table_teclado tr td').click(function () {
        var number = $(this).text();
        if (contador == 0) {
            $('#campo').val("");
            contador = 1;
        }
        if (number != "") {

            if (number == "Salir") {

                window.location.href = '/Home/Index';

            }

            if (number == "Limpiar") {
    
                $('#campo').val("Ingrese el PIN");
                contador = 0;
                pinSend = "";

            }
            else if (number == "Aceptar") {
                //$.ajax({
                //    url: "Home/VerificarTarjeta", data: { NroTarjeta: $('#campo').val() }
                //}).done(function (data) {
                //    alert(data);
                //});
                window.location.href = '/Home/VerifyPin?pin=' + pinSend + '&NumberCard=' + $('#NumberCard').text();

            }
            else {
 
                if (number == '') {
                    $('#campo').val($('#campo').val().substr(0, $('#campo').val().length - 1)).focus();
                }
                else {
                      pinSend = pinSend + number;
                    $('#campo').val($('#campo').val() + "*").focus();
                }
            }
        }

    });
});