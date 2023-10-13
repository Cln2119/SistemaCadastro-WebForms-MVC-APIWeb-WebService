<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebFormGTI.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"/>
    <link rel="stylesheet" type="text/css" href="Content/formulario-site.css" />    
    <script type="text/javascript" src="/Scripts/formulario.js"></script>
    <title>Formulário Clientes</title>  
</head>
<body>
 <div class="container">
     <div class="row">
         <h5>Cliente</h5>
     </div>
    <div class="row">
        <div class="col-12 col-md-3 div-margin"> 
            <label>CPF*</label>
            <input type="text" id="cpf" oninput="formatarCPF(this)" class="form-control" placeholder="" maxlength="14"/>
             <div id="cpfValidationStatus"></div>
        </div>
        <div class="col-12 col-md-9"> 
            <label>Nome*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
    </div>
     <div class="row">
         <div class="col-12 col-md-3 div-margin"> 
            <label>RG</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
            <div class="col-12 col-md-3 div-margin"> 
            <label>Data Expedição</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
            <div class="col-12 col-md-4 div-margin ajuste-select"> 
            <label>Orgão Expedição</label>
            <select class="form-control" name="orgao">
                <option value="SSP-AC">Secretaria de Segurança Pública do Acre (SSP-AC)</option>
                <option value="SSP/AL">Secretaria de Segurança Pública de Alagoas (SSP/AL)</option>
                <option value="SSP/AP">Secretaria de Segurança Pública do Amapá (SSP/AP)</option>
                <option value="SSP/AM">Secretaria de Segurança Pública do Amazonas (SSP/AM)</option>
                <option value="SSPDS/CE">Secretaria da Segurança Pública e Defesa Social do Estado do Ceará (SSPDS/CE)</option>
                <option value="SSP/DF">Secretaria de Segurança Pública do Distrito Federal (SSP/DF)</option>
                <option value="SESP/ES">Secretaria de Estado da Segurança Pública e Defesa Social do Espírito Santo (SESP/ES)</option>
                <option value="SSP/GO">Secretaria de Segurança Pública do Estado de Goiás (SSP/GO)</option>
                <option value="SSP/MA">Secretaria de Segurança Pública do Estado do Maranhão (SSP/MA)</option>
                <option value="SSP-MT">Secretaria de Segurança Pública de MT (SSP-MT)</option>
                <option value="SSP/MS">Secretaria de Segurança Pública do Estado de MS (SSP/MS)</option>
                <option value="SSP/MG">Secretaria de Estado de Segurança Pública de Minas Gerais (SSP/MG)</option>
                <option value="SSP/PA">Secretaria de Estado de Segurança Pública e Defesa Social do Pará (SSP/PA)</option>
                <option value="SSP/PB">Secretaria do Estado da Segurança e da Defesa Social da Paraíba (SSP/PB)</option>
                <option value="SSP/PR">Secretaria de Estado da Segurança Pública do Paraná (SSP/PR)</option>
                <option value="SSP/PE">Secretaria de Segurança Pública do estado de Pernambuco (SSP/PE)</option>
                <option value="SSP/RJ">Secretaria de Estado da Segurança Pública do Rio de Janeiro (SSP/RJ)</option>
                <option value="SESED/RN">Secretaria da Segurança Pública e da Defesa Social (SESED/RN)</option>
                <option value="SSP/RS">Secretaria da Segurança Pública do Rio Grande do Sul (SSP/RS)</option>
                <option value="SESDEC/RO">Secretaria de Estado de Segurança, Defesa e Cidadania (SESDEC/RO)</option>
                <option value="SESP/RR">Secretaria de Estado da Segurança Pública de Roraima (SESP/RR)</option>
                <option value="SSP/SC">Secretaria de Estado de Segurança Pública de Santa Catarina (SSP/SC)</option>
                <option value="SSP/TO">Secretaria da Segurança Púbica do Estado de Tocantins (SSP/TO)</option>
            </select>
        </div>
            <div class="col-12 col-md-2 ajuste-select"> 
            <label>UF Expedição</label>
            <select class="form-control" name="estados">         
                <option value="AC">AC</option>
                <option value="AL">AL</option>
                <option value="AP">AP</option>
                <option value="AM">AM</option>
                <option value="BA">BA</option>
                <option value="CE">CE</option>
                <option value="DF">DF</option>
                <option value="ES">ES</option>
                <option value="GO">GO</option>
                <option value="MA">MA</option>
                <option value="MT">MT</option>
                <option value="MS">MS</option>
                <option value="MG">MG</option>
                <option value="PA">PA</option>
                <option value="PB">PB</option>
                <option value="PR">PR</option>
                <option value="PE">PE</option>
                <option value="PI">PI</option>
                <option value="RJ">RJ</option>
                <option value="RN">RN</option>
                <option value="RS">RS</option>
                <option value="RO">RO</option>
                <option value="RR">RR</option>
                <option value="SC">SC</option>
                <option value="SP">SP</option>
                <option value="SE">SE</option>
                <option value="TO">TO</option>
        </select>
        </div>
     </div>
     <div class="row">
         <div class="col-12 col-md-3 div-margin"> 
            <label>Data de Nascimento*</label>
            <input type="date" class="form-control" id="dataNascimento" onchange="validarDataNascimento()"/>
             <div id="validaDataNascimento"></div>
        </div>
            <div class="col-12 col-md-3 div-margin"> 
            <label>Sexo*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
            <div class="col-12 col-md-3 ajuste-select"> 
            <label>Estado Civil*</label>
                <select class="form-control" name="civil"> 
                    <option value="Solteiro(a)">Solteiro(a)</option>
                    <option value="Casado(a)">Casado(a)</option>
                    <option value="Divorciado(a)">Divorciado(a)</option>
                </select>            
        </div>
     </div>
     <div class="row ">
         <div class="hr-margin-top">
                <hr/>
         </div>      
     </div>
     <div class="row">
         <h5 class="h5-margin">Endereço</h5>
     </div>
    <div class="row">
        <div class="col-12 col-md-2 div-margin"> 
            <label>CEP*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-2 div-margin"> 
            <label>Rua*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-1 div-margin"> 
            <label>Número*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-2 div-margin"> 
            <label>Complemento*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-2 div-margin"> 
            <label>Bairro*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-2 div-margin"> 
            <label>Cidade*</label>
            <input type="text" class="form-control" placeholder=""/>
        </div>
        <div class="col-12 col-md-1 div-margin ajuste-select"> 
            <label>UF*</label>
                <select class="form-control" name="uf">         
                <option value="AC">AC</option>
                <option value="AL">AL</option>
                <option value="AP">AP</option>
                <option value="AM">AM</option>
                <option value="BA">BA</option>
                <option value="CE">CE</option>
                <option value="DF">DF</option>
                <option value="ES">ES</option>
                <option value="GO">GO</option>
                <option value="MA">MA</option>
                <option value="MT">MT</option>
                <option value="MS">MS</option>
                <option value="MG">MG</option>
                <option value="PA">PA</option>
                <option value="PB">PB</option>
                <option value="PR">PR</option>
                <option value="PE">PE</option>
                <option value="PI">PI</option>
                <option value="RJ">RJ</option>
                <option value="RN">RN</option>
                <option value="RS">RS</option>
                <option value="RO">RO</option>
                <option value="RR">RR</option>
                <option value="SC">SC</option>
                <option value="SP">SP</option>
                <option value="SE">SE</option>
                <option value="TO">TO</option>
        </select>
        </div>
    </div>
      <div class="row">
         <div class="hr-margin-top">
                <hr/>
         </div>      
     </div>
     <div class="row">
         <div class="margin-btn"> 
             <button class="btn btn-sucesso"> Atualizar <i class="fas fa-arrow-right"></i></button>
         </div>         
     </div>
</div>
</body>      
    
</html>
