<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebFinal._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="idUsuario" runat="server" />
    <asp:HiddenField ID="ClaveHasheada" runat="server" />
    <asp:HiddenField ID="token" runat="server" />
    <link href="../../Content/Usuarios.css" rel="stylesheet" />
    <link href="../../Content/jquery-ui.css" rel="stylesheet" />
    <div class="panel panel-default" style="margin-top: 50px">
        <div class="panel-heading">Usuarios</div>
        <div class="panel-body">
            <a id="btnNuevoUsuario" class="btn btn-primary" style="margin: 25px 0px;">Nuevo Usuario</a>
            <table id="Usuarios" class="display" width="100%" cellspacing="0">
            </table>
        </div>
    </div>

    <!-- Modal Guardar Editar -->
    <div class="modal fade" id="UsuariosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Alta/Edicion Usuarios</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="NombreText" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <asp:Label ID="Apellido" runat="server" Text="Apellido"></asp:Label>
                            <asp:TextBox ID="ApellidoText" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Clave" runat="server" Text="Clave"></asp:Label>
                            <asp:TextBox ID="ClaveText" type="password" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <asp:Label ID="Mail" runat="server" Text="Mail"></asp:Label>
                            <asp:TextBox ID="MailText" class="form-control" runat="server" ControlToValidate="txtNumberos" ErrorMessage="Ingrese Numeros" ValidationExpression="\d+"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Rol" runat="server" Text="Rol"></asp:Label>
                            <asp:DropDownList ID="RolDrop" class="form-control"  runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Fecha_Nacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
                            <asp:TextBox ID="FechaNacimientDate" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 form-check">
                            <asp:Label ID="Activo" runat="server" Text="Activo" class="form-check-label"></asp:Label>
                            <asp:CheckBox ID="ActivoCheck" runat="server" class="form-check-input" />
                        </div>
                    </div>


                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnEditar" class="btn btn-warning" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Elimiar -->
    <div class="modal fade" id="eliminarUsuariosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalEliminar">Eliminar Usuario</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Desea Eliminar el usuario?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnEliminar" class="btn btn-warning" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js" integrity="sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <script src="../../Scripts/moment.js"></script>
    <script src="../../Scripts/Usuarios/Usuarios.js"></script>
</asp:Content>


