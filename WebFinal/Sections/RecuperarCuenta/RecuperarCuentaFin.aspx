<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCuentaFin.aspx.cs" Inherits="WebFinal.RecuperarCuentaFin" %>

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

                <asp:Label ID="Clave" runat="server" Text="Ingresa la nueva contraseña" Style="font-size:15px"></asp:Label>
                <asp:TextBox ID="ClaveText" class="form-control" type="password" placeHolder="Ingresar Contraseña" runat="server" Style="margin-bottom:15px"></asp:TextBox>

                <asp:Label ID="Clave2" runat="server" Text="Vuelve a Ingresarla" Style="font-size:15px"></asp:Label>
                <asp:TextBox ID="ClaveText2" class="form-control" type="password" placeHolder="Ingresar Contraseña" runat="server"></asp:TextBox>
                
                 <asp:Label ID="ErrClave" runat="server" Text="Las contraseñas no son iguales" Style="font-size:15px; color:red" Visible="false"></asp:Label>
                
                 <%//<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contraseñas no son iguales" ControlToCompare="ClaveText" ControlToValidate="ClaveText2" Operator="Equal" Type="String" ></asp:CompareValidator> %>

                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="CambiarClave" runat="server" Text="Cambiar Contraseña" Style="margin-top:15px" OnClick="CambiarClave_Click"/>
            </form>
        </div>
    </div>
</body>
</html>
<script src="../../Scripts/jquery-3.4.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
