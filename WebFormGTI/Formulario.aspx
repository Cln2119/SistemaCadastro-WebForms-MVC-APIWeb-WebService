<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebFormGTI.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <link rel="stylesheet" type="text/css" href="Content/formulario-site.css" />
    <script type="text/javascript" src="/Scripts/formulario.js"></script>
    <title>Formulário Clientes</title>
</head>
<body>
    <div class="container">
        <form runat="server">
            <div class="row">
                <h5>Cliente</h5>
            </div>
            <div class="row">
                <div class="col-12 col-md-3 div-margin">
                    <label>CPF*</label>                    
                    <asp:TextBox ID="txtCPF" runat="server" oninput="formatarCPF(this)" class="form-control" placeholder="" maxlength="14" required ></asp:TextBox>
                    <div id="cpfValidationStatus" class="mensagem-erro"></div>
                </div>
                <div class="col-12 col-md-9">
                    <label>Nome*</label>                 
                    <asp:TextBox ID="txtNome" runat="server" class="form-control" required ></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-3 div-margin">
                    <label>RG</label>              
                    <asp:TextBox ID="txtRG" runat="server" class="form-control" MaxLength="9" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-3 div-margin">
                    <label>Data Expedição</label>          
                    <asp:TextBox ID="txtDataExpedicao" type="date" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-4 div-margin ajuste-select">
                    <label>Orgão Expedição</label>
                    <asp:DropDownList class="form-control" ID="orgao" runat="server">
                        <asp:ListItem Text="Secretaria de Segurança Pública do Acre (SSP-AC)" value="SSP-AC"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública de Alagoas (SSP/AL)" value="SSP/AL"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Amapá (SSP/AP)" value="SSP/AP"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Amazonas (SSP/AM)" value="SSP/AM"></asp:ListItem>
                        <asp:ListItem Text="Secretaria da Segurança Pública e Defesa Social do Estado do Ceará (SSPDS/CE)" value="SSPDS/CE"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Distrito Federal (SSP/DF)" value="SSP/DF"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado da Segurança Pública e Defesa Social do Espírito Santo (SESP/ES)" value="SESP/ES"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Estado de Goiás (SSP/GO)" value="SSP/GO"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Estado do Maranhão (SSP/MA)" value="SSP/MA"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública de MT (SSP-MT)" value="SSP-MT"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do Estado de MS (SSP/MS)" value="SSP/MS"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado de Segurança Pública de Minas Gerais (SSP/MG)" value="SSP/MG"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado de Segurança Pública e Defesa Social do Pará (SSP/PA)" value="SSP/PA"></asp:ListItem>
                        <asp:ListItem Text="Secretaria do Estado da Segurança e da Defesa Social da Paraíba (SSP/PB)" value="SSP/PB"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado da Segurança Pública do Paraná (SSP/PR)" value="SSP/PR"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Segurança Pública do estado de Pernambuco (SSP/PE)" value="SSP/PE"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado da Segurança Pública do Rio de Janeiro (SSP/RJ)" value="SSP/RJ"></asp:ListItem>
                        <asp:ListItem Text="Secretaria da Segurança Pública e da Defesa Social (SESED/RN)" value="SESED/RN"></asp:ListItem>
                        <asp:ListItem Text="Secretaria da Segurança Pública do Rio Grande do Sul (SSP/RS)" value="SSP/RS"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado de Segurança, Defesa e Cidadania (SESDEC/RO" value="SESDEC/RO"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado da Segurança Pública de Roraima (SESP/RR)" value="SESP/RR"></asp:ListItem>
                        <asp:ListItem Text="Secretaria de Estado de Segurança Pública de Santa Catarina (SSP/SC)" value="SSP/SC"></asp:ListItem>
                        <asp:ListItem Text="Secretaria da Segurança Púbica do Estado de Tocantins (SSP/TO)" value="SSP/TO"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-12 col-md-2 ajuste-select">
                    <label>UF Expedição</label>
                    <asp:DropDownList class="form-control" ID="estados" runat="server">
                        <asp:ListItem Text="AC" value="AC"></asp:ListItem>
                        <asp:ListItem Text="AL" value="AL"></asp:ListItem>
                        <asp:ListItem Text="AP" value="AP"></asp:ListItem>
                        <asp:ListItem Text="AM" value="AM"></asp:ListItem>
                        <asp:ListItem Text="BA" value="BA"></asp:ListItem>
                        <asp:ListItem Text="CE" value="CE"></asp:ListItem>
                        <asp:ListItem Text="DF" value="DF"></asp:ListItem>
                        <asp:ListItem Text="ES" value="ES"></asp:ListItem>
                        <asp:ListItem Text="GO" value="GO"></asp:ListItem>
                        <asp:ListItem Text="MA" value="MA"></asp:ListItem>
                        <asp:ListItem Text="MT" value="MT"></asp:ListItem>
                        <asp:ListItem Text="MS" value="MS"></asp:ListItem>
                        <asp:ListItem Text="MG" value="MG"></asp:ListItem>
                        <asp:ListItem Text="PA" value="PA"></asp:ListItem>
                        <asp:ListItem Text="PB" value="PB"></asp:ListItem>
                        <asp:ListItem Text="PR" value="PR"></asp:ListItem>
                        <asp:ListItem Text="PE" value="PE"></asp:ListItem>
                        <asp:ListItem Text="PI" value="PI"></asp:ListItem>
                        <asp:ListItem Text="RJ" value="RJ"></asp:ListItem>
                        <asp:ListItem Text="RN" value="RN"></asp:ListItem>
                        <asp:ListItem Text="RS" value="RS"></asp:ListItem>
                        <asp:ListItem Text="RO" value="RO"></asp:ListItem>
                        <asp:ListItem Text="RR" value="RR"></asp:ListItem>
                        <asp:ListItem Text="SC" value="SC"></asp:ListItem>
                        <asp:ListItem Text="SP" value="SP"></asp:ListItem>
                        <asp:ListItem Text="SE" value="SE"></asp:ListItem>
                        <asp:ListItem Text="TO" value="TO"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-3 div-margin">
                    <label>Data de Nascimento*</label>             
                    <asp:TextBox type="date" ID="txtDataNascimento" runat="server" class="form-control" onchange="validarDataNascimento()" required ></asp:TextBox>
                    <div id="validaDataNascimento" class="mensagem-erro"></div>
                </div>
                <div class="col-12 col-md-3 div-margin ajuste-select">
                    <label>Sexo*</label>    
                    <asp:DropDownList class="form-control" ID="txtSexo" runat="server">
                        <asp:ListItem Text="Masculino" value="Masculino"></asp:ListItem>
                        <asp:ListItem Text="Feminino" value="Feminino"></asp:ListItem>
                        <asp:ListItem Text="Outro" value="Outro"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-12 col-md-3 div-margin ajuste-select">
                    <label>Estado Civil*</label>
                    <asp:DropDownList class="form-control" ID="civil" runat="server">
                        <asp:ListItem Text="Solteiro(a)" value="Solteiro(a)"></asp:ListItem>
                        <asp:ListItem Text="Casado(a)" value="Casado(a)"></asp:ListItem>
                        <asp:ListItem Text="Divorciado(a)" value="Divorciado(a)"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row ">
                <div class="hr-margin-top">
                    <hr />
                </div>
            </div>
            <div class="row">
                <h5 class="h5-margin">Endereço</h5>
            </div>
            <div class="row">
                <div class="col-12 col-md-2 div-margin">
                    <label>CEP*</label>             
                     <asp:TextBox ID="txtCEP" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-2 div-margin">
                    <label>Rua*</label>               
                    <asp:TextBox ID="txtRua" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-1 div-margin">
                    <label>Número*</label>            
                    <asp:TextBox ID="txtNumero" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-2 div-margin">
                    <label>Complemento*</label>                 
                    <asp:TextBox ID="txtComplemento" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-2 div-margin">
                    <label>Bairro*</label>            
                    <asp:TextBox ID="txtBairro" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-2 div-margin">
                    <label>Cidade*</label>                  
                    <asp:TextBox ID="txtCidade" runat="server" class="form-control" required ></asp:TextBox>
                </div>
                <div class="col-12 col-md-1 div-margin ajuste-select">
                    <label>UF*</label>
                    <asp:DropDownList class="form-control" ID="uf" runat="server">
                        <asp:ListItem Text="AC" value="AC"></asp:ListItem>
                        <asp:ListItem Text="AL" value="AL"></asp:ListItem>
                        <asp:ListItem Text="AP" value="AP"></asp:ListItem>
                        <asp:ListItem Text="AM" value="AM"></asp:ListItem>
                        <asp:ListItem Text="BA" value="BA"></asp:ListItem>
                        <asp:ListItem Text="CE" value="CE"></asp:ListItem>
                        <asp:ListItem Text="DF" value="DF"></asp:ListItem>
                        <asp:ListItem Text="ES" value="ES"></asp:ListItem>
                        <asp:ListItem Text="GO" value="GO"></asp:ListItem>
                        <asp:ListItem Text="MA" value="MA"></asp:ListItem>
                        <asp:ListItem Text="MT" value="MT"></asp:ListItem>
                        <asp:ListItem Text="MS" value="MS"></asp:ListItem>
                        <asp:ListItem Text="MG" value="MG"></asp:ListItem>
                        <asp:ListItem Text="PA" value="PA"></asp:ListItem>
                        <asp:ListItem Text="PB" value="PB"></asp:ListItem>
                        <asp:ListItem Text="PR" value="PR"></asp:ListItem>
                        <asp:ListItem Text="PE" value="PE"></asp:ListItem>
                        <asp:ListItem Text="PI" value="PI"></asp:ListItem>
                        <asp:ListItem Text="RJ" value="RJ"></asp:ListItem>
                        <asp:ListItem Text="RN" value="RN"></asp:ListItem>
                        <asp:ListItem Text="RS" value="RS"></asp:ListItem>
                        <asp:ListItem Text="RO" value="RO"></asp:ListItem>
                        <asp:ListItem Text="RR" value="RR"></asp:ListItem>
                        <asp:ListItem Text="SC" value="SC"></asp:ListItem>
                        <asp:ListItem Text="SP" value="SP"></asp:ListItem>
                        <asp:ListItem Text="SE" value="SE"></asp:ListItem>
                        <asp:ListItem Text="TO" value="TO"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="hr-margin-top">
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="margin-btn">                    
                    <asp:Button runat="server" Text="Atualizar" OnClick="btnInclusao_Click" class="btn btn-sucesso button" />
                </div>
            </div>
            <div class="row">
                <div class="margin-gridview">
                    <h5 class="h5-margin">Lista de Clientes</h5>
                </div>
            </div>
            <div class="row">
                <div class="">
                    <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome" />                           
                            <asp:TemplateField HeaderText="Ações">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Editar"  data-id='<%# Eval("ID") %>' OnClick="btnAtualizarCliente_Click" />
                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Excluir" data-id='<%# Eval("ID") %>' OnClick="btnExclusao_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
