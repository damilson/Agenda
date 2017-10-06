$(document).ready(function () {
    $.post("http://localhost:62568/Pessoa/Index",
        function (Data) {
            if (Data != null) {
                $.post("Home/RetornaTabela",
                        { model: Data },
                        function (View) {
                            $("#tabelamvc").html(View);
                        });
            }
            else {
                alert("Algo deu errado");
            }
        })
});