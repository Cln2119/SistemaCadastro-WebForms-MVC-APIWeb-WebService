<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebForm.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Teste</h1>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtCpfCnpj" runat="server"></asp:TextBox>
            <asp:Button ID="btnAcao" runat="server" Text="Clique para Incluir" OnClick="btnInclusao_Click" />
            <asp:Button ID="Button1" runat="server" Text="Clique para Alterar" OnClick="btnAlteracao_Click" />
            <asp:Button ID="Button2" runat="server" Text="Clique para Excluir" OnClick="btnExclusao_Click" />
        </div>
    </form>
</body>
</html>
