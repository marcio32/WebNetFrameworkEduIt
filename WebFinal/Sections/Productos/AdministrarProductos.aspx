<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarProductos.aspx.cs" Inherits="WebFinal.AdministrarProductos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="idProducto" runat="server" />
    <asp:HiddenField ID="ClaveHasheada" runat="server" />
    <asp:HiddenField ID="token" runat="server" />
    <asp:HiddenField ID="imagenEditar" runat="server" />
    <link href="../../Content/Productos.css" rel="stylesheet" />
    <link href="../../Content/jquery-ui.css" rel="stylesheet" />
    <div class="panel panel-default" style="margin-top: 50px">
        <div class="panel-heading">Productos</div>
        <div class="panel-body">
            <a id="btnNuevoProducto" class="btn btn-primary" style="margin: 25px 0px;">Nuevo Producto</a>
            <table id="Productos" class="display" width="100%" cellspacing="0">
            </table>
        </div>
    </div>

    <!-- Modal Guardar Editar -->
    <div class="modal fade" id="ProductosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Alta/Edicion Productos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Descripcion" runat="server" Text="Descripcion"></asp:Label>
                            <asp:TextBox ID="DescripcionText" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <asp:Label ID="Precio" runat="server" Text="Precio"></asp:Label>
                            <asp:TextBox ID="PrecioText" type="number" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6 form-group">
                            <asp:Label ID="Stock" runat="server" Text="Stock"></asp:Label>
                            <asp:TextBox ID="StockText" type="number" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-6 form-group">
                            <asp:Label ID="Imagen" runat="server" Text="Imagen"></asp:Label>
                            <asp:FileUpload ID="ImagenUpload" runat="server" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 form-check">
                            <asp:Label ID="Activo" runat="server" Text="Activo" class="form-check-label"></asp:Label>
                            <asp:CheckBox ID="ActivoProductoCheck" runat="server" class="form-check-input" />
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
    <div class="modal fade" id="eliminarProductosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalEliminar">Eliminar Producto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Desea Eliminar el Producto?
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
    <script src="../../Scripts/Productos/Productos.js"></script>
</asp:Content>


