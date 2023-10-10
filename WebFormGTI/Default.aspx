<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormGTI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <h1>Formulário GTI Solution</h1>
            <p>Preencha o formulário abaixo para cadastro</p>
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
            <div class="col-6">
                <div class="mb-3">
                    <asp:Button ID="btnAlterar" runat="server" Text="Cadastrar" OnClick="btnInclusao_Click" CssClass="btn btn-primary" />
                </div>
            </div>  
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
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnmodal_Click " data-id='<%# Eval("ID") %>' />
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Excluir" CssClass="btn btn-danger" OnClick="btnExclusao_Click" data-id='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="container">
        <div class="modal fade" id="mymodal" data-backdrop="false" role="dialog">
            <div class=" modal-dialog modal-dailog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Alterar dados</h4>
                        <asp:Label ID="lblmsg" Text="" runat="server" />
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label>Id</label>
                        <asp:TextBox ID="modalId" CssClass="form-control" placeholder="Id" runat="server" Enabled="false"/>
                        <label>Nome</label>
                        <asp:TextBox ID="modalName" CssClass="form-control" placeholder="Name" runat="server" />
                        <label>Email</label>
                        <asp:TextBox ID="modalEmail" CssClass="form-control" placeholder="Email" runat="server" />
                        <label>CPF/CNPJ</label>
                        <asp:TextBox ID="modalCpfCnpj" CssClass="form-control" placeholder="Contact" runat="server" />                    
                        <asp:HiddenField ID="hdid" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnsave" CssClass="btn btn-primary" OnClick="btnAlteracao_Click" Text="Salvar" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

