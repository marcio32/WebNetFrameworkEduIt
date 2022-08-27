$(document).ready(function () {
    const token = $('[id$=token]').val();
    $('#Productos').DataTable({
        ajax: {
            url: 'https://localhost:44343/api/Productos/ObtenerProductos',
            dataSrc: '',
            headers: { "Authorization": token }
        },
        columns: [
            { data: 'Id', title: 'Id' },
            {
                data: 'Imagen',
                render: function (data) {
                    return '<img src="data:image/jpeg;base64,' + data + '"width="100px" height="100px">';
                },
                title: 'Imagen'
            },
            { data: 'Descripcion', title: 'Descripcion' },
            { data: 'Precio', title: 'Precio' },
            { data: 'Stock', title: 'Stock' },
            {
                data: function (row) {
                    return row.Activo == true ? "Si" : "No";

                },
                title: 'Activo'
            },
            {
                data: function (row) {
                    var buttons =
                        `<td><a href='javascript:EditarProducto(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarProducto"></td>` +
                        `<td><a href='javascript:EliminarProducto(${JSON.stringify(row.Id)})'<i class="fa-solid fa-trash eliminarProducto"></i></td>`;
                    return buttons

                },
                title: 'Acciones',
                ordenable: false,
                width: '0%'
            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Spanish.json"
        }
    });

    $('[id$=FechaNacimientDate]').datepicker({
        dateFormat: "dd-mm-yy",
        changeMonth: true,
        changeYear: true
    });
});


function EditarProducto(row) {
    $("#ProductosModal").modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');
    $('[id$=idProducto]').val(row.Id);
    $('[id$=DescripcionText]').val(row.Descripcion);
    $('[id$=PrecioText]').val(row.Precio);
    $('[id$=StockText]').val(row.Stock);
    $('[id$=imagenEditar]').val(row.Imagen);
    $('[id$=ActivoProductoCheck]').prop("checked", row.Activo);
}

function EliminarProducto(id) {
    $("#eliminarProductosModal").modal();
    $('[id$=idProducto]').val(id);
}

$('#btnNuevoProducto').on('click', function () {
    clearProductos();
    $("#ProductosModal").modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');

});


function clearProductos() {
    $('[id$=idProducto]').val("");
    $('[id$=DescripcionText]').val("");
    $('[id$=PrecioText]').val("");
    $('[id$=StockText]').val("");
    $('[id$=ActivoProductoCheck]').prop("checked", false);
}