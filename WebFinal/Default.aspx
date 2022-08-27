<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFinal.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/Login.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
 
    <div class="container" >
        <div class="card card-container">
            <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" />
            <form class="form-signin" runat="server">

                <asp:TextBox ID="txtEmail" type="email" class="form-control" placeHolder="Direccion Mail" runat="server" required></asp:TextBox>
                <asp:TextBox ID="txtClave" type="password" class="form-control" placeHolder="Contraseña" runat="server" required></asp:TextBox>
                <asp:Label ID="lblError" runat="server" Text="Error: la contraseña o el mail es incorrecta" Style="color:red;font-size:15px" Visible="false"></asp:Label>
                <div id="remember" class="checkbox">
                    <label>
                        <asp:CheckBox ID="RecuerdameCheck" runat="server" />Recuerdame
                    </label>
                </div>
                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="Button1" runat="server" Text="Iniciar Sesion" OnClick="Button1_Click" />
            </form>
            <div style="margin-top:15px; text-align:center">
                 <a href="Sections/RecuperarCuenta/RecuperarCuenta.aspx" class="forgot-password" >Olvidaste la contraseña?   </a>
            </div>
        </div>
    </div>
</body>
</html>
<script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
