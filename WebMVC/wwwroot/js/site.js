﻿$(document).ready(function () {
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

function formatarCPF(input) {
    const cpf = input.value.replace(/\D/g, "");

    if (cpf.length >= 4 && cpf.length <= 6) {
        input.value = cpf.substr(0, 3) + "." + cpf.substr(3);
    } else if (cpf.length >= 7 && cpf.length <= 9) {
        input.value = cpf.substr(0, 3) + "." + cpf.substr(3, 3) + "." + cpf.substr(6);
    } else if (cpf.length >= 10 && cpf.length <= 11) {
        input.value = cpf.substr(0, 3) + "." + cpf.substr(3, 3) + "." + cpf.substr(6, 3) + "-" + cpf.substr(9);
    }

    if (cpf.length > 10) {
        var result = validarDigitosVerificadores(cpf);

        if (!result) {
            cpfValidationStatus.textContent = "CPF Inválido";
        }
    }
}

function validarDigitosVerificadores(cpf) {
    // Verifica o primeiro dígito verificador
    const primeiroDigitoVerificador = calcularPrimeiroDigitoVerificador(cpf);
    if (cpf.charAt(9) !== primeiroDigitoVerificador) {
        return false;
    }

    // Verifica o segundo dígito verificador
    const segundoDigitoVerificador = calcularSegundoDigitoVerificador(cpf);
    if (cpf.charAt(10) !== segundoDigitoVerificador) {
        return false;
    }

    return true; // CPF válido
}

function calcularPrimeiroDigitoVerificador(cpfParcial) {
    let soma = 0;
    for (let i = 0; i < 9; i++) {
        soma += parseInt(cpfParcial.charAt(i)) * (10 - i);
    }
    const resto = soma % 11;
    return (resto < 2) ? '0' : String(11 - resto);
}

function calcularSegundoDigitoVerificador(cpfParcial) {
    let soma = 0;
    for (let i = 0; i < 10; i++) {
        soma += parseInt(cpfParcial.charAt(i)) * (11 - i);
    }
    const resto = soma % 11;
    return (resto < 2) ? '0' : String(11 - resto);
}

function exibirMensagem(mensagem) {
    const cpfValidationStatus = document.getElementById("cpfValidationStatus");
    cpfValidationStatus.textContent = mensagem;
}

//Validar dataNascimento

function validarDataNascimento() {
    const dataNascimentoInput = document.getElementById("dataNascimento");
    const mensagemErro = document.getElementById("mensagemErro");

    const dataNascimento = new Date(dataNascimentoInput.value);
    const dataAtual = new Date();

    const idade = dataAtual.getFullYear() - dataNascimento.getFullYear();
    const mesAtual = dataAtual.getMonth() + 1;
    const diaAtual = dataAtual.getDate();

    const mesNascimento = dataNascimento.getMonth() + 1;
    const diaNascimento = dataNascimento.getDate();

    if (idade > 100) {
        validaDataNascimento.textContent = "A pessoa não pode ter mais de 100 anos.";
    } else if (idade < 18) {
        validaDataNascimento.textContent = "A pessoa deve ser maior de 18 anos.";
    } else if (mesNascimento > 12 || diaNascimento > 31) {
        validaDataNascimento.textContent = "Data de nascimento inválida.";
    } else {
        validaDataNascimento.textContent = "";
    }
}



