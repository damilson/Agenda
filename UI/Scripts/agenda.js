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
montatabelaMvc = function () {
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
}

montaTabelaWebApi = function () {
    $("#myModalBlock").modal({ backdrop: "static" });
    $.get("http://localhost:62583/api/Pessoa",
        function (Data) {
            if (Data != null) {
                $.post("Home/RetornaTabela",
                        { model: Data },
                        function (View) {
                            $("#tabelawebapi").html(View);
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
detalhe = function (Id) {
    var url;
    if ($("#tab-mvc").hasClass("active")) {
        url = "";
        };

    $.post("http://localhost:62568/Pessoa/Details",
        { id: Id },
        function (Data) {
            if (Data != null) {
                $.post("Home/Details",
                        { model: Data },
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

detalheContato = function (Id) {
    $.post("http://localhost:62568/Contato/Details",
        { id: Id },
        function (Data) {
            if (Data != null) {
                $.post("Home/DetailsContato",
                        { model: Data },
                        function (View) {
                            $("#detalhes").html(View);
                            $("#myModalEditarContato").modal({ backdrop: "static" });
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
    var form = $("#edit-form-mvc").serialize();
    $.post("http://localhost:62568/Pessoa/Edit", form,
        function (Data) {
            alert(Data.Mensagem)
            window.location.reload();
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

deletarContato = function (Id) {
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
                $.post("http://localhost:62568/Contato/Delete", { id: Id },
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

editarFormContato = function () {
    var form = $("#form-edit-contato-mvc").serialize();
    $.post("http://localhost:62568/Contato/Edit", form,
        function (Data) {
            alert(Data.Mensagem)
            window.location.reload();
        });
}

carregaCadastro = function (Id) {
    $.post("Home/CadastroContato",
            { Id},
            function (View) {
                $("#cadastroContato").html(View);
                $("#myModalCadastroContato").modal({ backdrop: "static" });
            })
};

salvarFormContato = function (Id) {
    var form = $("#form-contato-mvc").serialize();
    $.post("http://localhost:62568/Contato/Create", form,
        function (Data) {
            alert(Data.Mensagem)
            window.location.reload();
        });
};

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