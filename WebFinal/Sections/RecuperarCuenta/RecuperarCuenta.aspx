<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="WebFinal.RecuperarCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Content/Login.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
  
    <title></title>
</head>
<body>
 
    <div class="container" >
        <div class="card card-container">
            <h3>Recuperar Cuenta</h3>
            <form class="form-signin" runat="server">
               
                <asp:Label ID="Email" runat="server" Text="Ingresa tu mail y no lo borres" Style="font-size:15px"></asp:Label>
                <asp:TextBox ID="EmailText" type="email" class="form-control" placeHolder="Direccion Mail" runat="server"></asp:TextBox>

                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="Button2" runat="server" Text="Enviar" Style="margin-bottom:20px" OnClick="Button2_Click"/>

                <asp:Label ID="Codigo" runat="server" Text="Ingresa el codigo enviado a tu mail" Style="font-size:15px; margin-top:20px"></asp:Label>
                <asp:TextBox ID="CodigoText" class="form-control" placeHolder="Codigo" runat="server" Style="margin-bottom:10px"></asp:TextBox>
                
                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="BtnRecuperar" runat="server" Text="Recuperar" OnClick="BtnRecuperar_Click"/>
            </form>
        </div>
    </div>
</body>
</html>
<script src="../../Scripts/jquery-3.4.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
