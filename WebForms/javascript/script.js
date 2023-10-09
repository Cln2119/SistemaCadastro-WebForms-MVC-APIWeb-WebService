function AbrirModal(id) {
       
        //var usuario = ObterDadosUsuario(id);
        //$("#txtNomeEditar").val(usuario.Nome);
        //$("#txtEmailEditar").val(usuario.Email);
        //$("#txtCpfCnpjEditar").val(usuario.CpfCnpj);

        //$("#modalEditar").modal("show");

    alert("Funcionando")
}

    function ObterDadosUsuario(id) {
        // Implemente a lógica para obter os dados do usuário com base no ID
        // Você pode fazer uma chamada AJAX para buscar os dados do servidor aqui.
        // Retorne um objeto com os dados do usuário.
        var usuario = {
            Nome: "Nome do Usuário",
            Email: "email@exemplo.com",
            CpfCnpj: "123.456.789-00"
        };
        return usuario;
}

function minhaFuncaoDeClique() {
    // O código que você deseja executar quando o clique for acionado.
    alert("Clique acionado!");
}