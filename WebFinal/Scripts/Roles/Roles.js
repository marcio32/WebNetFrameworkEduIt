$(document).ready(function () {
    const token = $('[id$=token]').val();
    $('#Roles').DataTable({
        ajax: {
            url: 'https://localhost:44343/api/Roles/ObtenerRoles',
            dataSrc: '',
            headers: { "Authorization": token }
        },
        columns: [
            { data: 'Id', title: 'Id' },
            { data: 'Nombre', title: 'Nombre' },
            {
                data: function (row) {
                    return row.Activo == true ? "Si" : "No";

                },
                title: 'Activo'
            },
            {
                data: function (row) {
                    var buttons =
                        `<td><a href='javascript:EditarRol(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarRol"></td>` +
                        `<td><a href='javascript:EliminarRol(${JSON.stringify(row.Id)})'<i class="fa-solid fa-trash eliminarRol"></i></td>`;
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


function EditarRol(row) {
    $("#RolesModal").modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');
    $('[id$=idRol]').val(row.Id);
    $('[id$=NombreText]').val(row.Nombre);
    $('[id$=ActivoRolCheck]').prop("checked", row.Activo);
}

function EliminarRol(id) {
    $("#eliminarRolesModal").modal();
    $('[id$=idRol]').val(id);
}

$('#btnNuevoRol').on('click', function () {
    clearRoles();
    $("#RolesModal").modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');

});


function clearRoles() {
    $('[id$=idRol]').val("");
    $('[id$=NombreText]').val("");
    $('[id$=ActivoRolCheck]').prop("checked", false);
}