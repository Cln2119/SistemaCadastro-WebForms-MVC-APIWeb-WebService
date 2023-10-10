$(document).ready(function () {
    $("#btnEditar").click(function () {     
        var userId = $(this).data("id");
        // Faça a chamada AJAX para buscar e carregar a PartialView
        $.ajax({
            url: '/Home/EditarUsuario',
            type: "POST",
            data: { id: userId },
            success: function (data) {
                $('#myModalEditar').modal('show');   
            },
            error: function () {
                console.log("Erro na chamada AJAX.");
            }
        });
    });
});

$(function () {
    $("#tblCustomers").dataTable();
    $('[id*=btnEdit]').on('click', function () {
        var tds = $(this).closest('tr').find('td');
        $('#hfId').val($(tds).eq(0).html());
        $('#txtName').val($(tds).eq(1).html());
        $('#txtCountry').val($(tds).eq(2).html());
        $('#myModal').modal('show');
    });
});
$(function () {
    $("#tblCustomers").dataTable();
    $('[id*=btnEdit]').on('click', function () {
        var tds = $(this).closest('tr').find('td');
        $('#hfId').val($(tds).eq(0).html());
        $('#txtName').val($(tds).eq(1).html());
        $('#txtCountry').val($(tds).eq(2).html());
        $('#myModalEditar').modal('show');
    });
});


