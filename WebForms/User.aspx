<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebForm.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Bootstrap JavaScript (opcional, dependendo das funcionalidades que você deseja) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
</head>
<body>
    <%--<form id="form1" runat="server">
        <div>
            <h1>Teste</h1>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCpfCnpj" runat="server"></asp:TextBox>
            <asp:Button ID="btnAcao" runat="server" Text="Clique para Incluir" OnClick="btnInclusao_Click" />
            <asp:Button ID="Button1" runat="server" Text="Clique para Alterar" OnClick="btnAlteracao_Click" />
            <asp:Button ID="Button2" runat="server" Text="Clique para Excluir" OnClick="btnExclusao_Click" />
        </div>
    </form>--%>

    <div class="container">
        <h1>Formulário GTI Solution</h1>
        <p>Preencha os dados abaixo para realizar cadastro</p>
        <form id="form1" runat="server">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtNome" class="form-label">Nome</label>
                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtCpfCnpj" class="form-label">CPF/CNPJ</label>
                    <asp:TextBox ID="txtCpfCnpj" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <button type="submit" class="btn btn-primary">Enviar</button>

            <div class="mt-5">
                <h3>Tabela dos usuários cadastrados</h3>
                <p>Nesta parte você pode alterar ou exluir os dados</p>
                <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="CpfCnpj" HeaderText="CPF/CNPJ" />
                        <asp:TemplateField HeaderText="Ações">
                            <ItemTemplate>
                                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" OnClick="btnAlteracao_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExclusao_Click" CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
