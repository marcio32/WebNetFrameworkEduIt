<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarClave.aspx.cs" Inherits="WebFinal.Sections.RecuperarClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>

    <div class="container">
        <div class="card card-container">
            <form class="form-signin" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Introduzca su email y le enviaremos un codigo para cambiar su contraseña" ></asp:Label>
                <asp:TextBox ID="EmailText" type="email" class="form-control" placeholder="Direccion Mail" runat="server" required></asp:TextBox>
                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="btnEnviar" runat="server" Text="Enviar"/>
               
                 <asp:Label ID="Label2" runat="server" Text="Introduzca su codigo" ></asp:Label>
                <asp:TextBox ID="txtCodigo" class="form-control" placeholder="Codigo" runat="server" required></asp:TextBox>
                 <asp:Label ID="lblError" runat="server" Text="Introduzca su nueva contraseña" ></asp:Label>
                <asp:TextBox ID="txtClave" type="password" class="form-control" placeholder="Contraseña" runat="server" required></asp:TextBox>
               
                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="Button1" runat="server" Text="Cambiar Contraseña"/>
            </form>
        </div>
    </div>

</body>
</html>
<script src="../../Scripts/jquery-3.4.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
