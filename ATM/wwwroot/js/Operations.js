 
 $(document).ready(function () {
 
    $('.table_teclado tr td').click(function () {
        var option = $(this).text();
     
        if (option != "") {
            if (option != "Salir") {
                var ViewName = "";
                switch (option) {
                    case "Balance":
                        ViewName = "CheckBalance";
                        break;

                    case "Retiro":
                        ViewName = "PageExtractMoney";
                        break;
                    case "Salir":
                        ViewName = "ExtractMoney";
                        break;
                }
                window.location.href = '/Operations/' + ViewName + '?NumberCard=' + $("#numberCard").text();
            }
            
            else 
                window.location.href = '/Home/Index';

        }

    });
});