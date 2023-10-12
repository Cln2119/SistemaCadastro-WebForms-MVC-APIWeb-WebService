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
            <input type="text" class="form-control" placeholder="000.000.000-00"/>
        </div>
        <div class="col-12 col-md-9"> 
            <label>Nome*</label>
            <input type="text" class="form-control" placeholder="Cleiton"/>
        </div>
    </div>
     <div class="row">
         <div class="col-12 col-md-3 div-margin"> 
            <label>RG</label>
            <input type="text" class="form-control" placeholder="00.000.000-00"/>
        </div>
            <div class="col-12 col-md-3 div-margin"> 
            <label>Data Expedição</label>
            <input type="text" class="form-control" placeholder="00/00/0000"/>
        </div>
            <div class="col-12 col-md-4 div-margin"> 
            <label>Orgão Expedição</label>
            <input type="text" class="form-control" placeholder="SSP"/>
        </div>
            <div class="col-12 col-md-2"> 
            <label>UF Expedição</label>
            <input type="text" class="form-control" placeholder="SP"/>
        </div>
     </div>
     <div class="row">
         <div class="col-12 col-md-3 div-margin"> 
            <label>Data de Nascimento*</label>
            <input type="text" class="form-control" placeholder="00/00/0000"/>
        </div>
            <div class="col-12 col-md-3 div-margin"> 
            <label>Sexo*</label>
            <input type="text" class="form-control" placeholder="Masculino"/>
        </div>
            <div class="col-12 col-md-3"> 
            <label>Estado Civil*</label>
            <input type="text" class="form-control" placeholder="Casado(a)"/>   
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
        <div class="col-12 col-md-1 div-margin"> 
            <label>UF*</label>
            <input type="text" class="form-control" placeholder=""/>
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
