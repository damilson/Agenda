$(document).ready(function () {
    $("#myModalBlock").modal({ backdrop: "static" });
    $.post("http://localhost:62568/Pessoa/Index",
        function (Data) {
            if (Data != null) {
                $.post("Home/RetornaTabela",
                        { model: Data },
                        function (View) {
                            $("#tabelamvc").html(View);
                        });
                setTimeout(function () {
                    $("#myModalBlock").modal("hide");
                }, 4000);
            }
            else {
                $("#myModalBlock").modal("hide");
                alert("Algo deu errado");
            }
        });

});

detalhe = function (Id) {
    $.post("http://localhost:62568/Pessoa/Details",
        {id:Id},
        function (Data) {
            if (Data != null) {
                $.post("Home/Details",
                        { model :Data },
                        function (View) {
                            $("#detalhes").html(View);
                            $("#myModalEdit").modal({ backdrop: "static" });
                        });
                setTimeout(function () {
                    $("#myModalBlock").modal("hide");
                }, 4000);
            }
            else {
                $("#myModalBlock").modal("hide");
                alert("Algo deu errado");
            }
        });
}

editar = function (Id) {
    $.post("http://localhost:62568/Pessoa/Details",
        function (Data) {
            if (Data != null) {

            }
        });
};

deletar = function (Id) {
    BootstrapDialog.confirm({
        title: 'Atenção',
        message: 'Deseja realmente excluir?',
        type: BootstrapDialog.TYPE_WARNING,
        closable: true,
        draggable: true,
        btnCancelLabel: 'Não',
        btnOKLabel: 'Sim',
        btnCancelClass: 'btn-danger',
        btnOKClass: 'btn-success',
        callback: function (result) {
            if (result) {
                $.post("http://localhost:62568/Pessoa/Delete", { id: Id },
                    function (Data) {
                        if (Data.Sucesso) {
                            alert(Data.Mensagem)
                            window.location.reload();
                        }
                    });
            } else {
                return;
            }
        }
    });
}

salvarForm = function () {
    var form = $("#form-mvc").serialize();
    $.post("http://localhost:62568/Pessoa/Create", form,
        function (Data) {
            alert(Data.Mensagem)
            window.location.reload();
        });
};

arupador = function (Id) {
    $(".pessoa_" + Id).toggleClass("hidden");
    $(".glyphicon-plus .pessoa_" + Id).toggleClass("hidden");
    $(".glyphicon-minus .pessoa_" + Id).toggleClass("hidden");
};