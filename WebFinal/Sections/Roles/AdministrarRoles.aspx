<%@ Page Title="Roles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarRoles.aspx.cs" Inherits="WebFinal.AdministrarRoles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="idRol" runat="server" />
    <asp:HiddenField ID="ClaveHasheada" runat="server" />
    <asp:HiddenField ID="token" runat="server" />
    <link href="../../Content/Roles.css" rel="stylesheet" />
    <link href="../../Content/jquery-ui.css" rel="stylesheet" />
    <div class="panel panel-default" style="margin-top: 50px">
        <div class="panel-heading">Roles</div>
        <div class="panel-body">
            <a id="btnNuevoRol" class="btn btn-primary" style="margin: 25px 0px;">Nuevo Rol</a>
            <table id="Roles" class="display" width="100%" cellspacing="0">
            </table>
        </div>
    </div>

    <!-- Modal Guardar Editar -->
    <div class="modal fade" id="RolesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Alta/Edicion Roles</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Descripcion" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="NombreText" class="form-control" runat="server"></asp:TextBox>
                        </div>

                          <div class="col-md-12 form-check">
                            <asp:Label ID="Activo" runat="server" Text="Activo" class="form-check-label"></asp:Label>
                            <asp:CheckBox ID="ActivoRolCheck" runat="server" class="form-check-input" />
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
    <div class="modal fade" id="eliminarRolesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalEliminar">Eliminar Rol</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Desea Eliminar el Rol?
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
    <script src="../../Scripts/Roles/Roles.js"></script>
</asp:Content>


