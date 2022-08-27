$(document).ready(function () {
    const token = $('[id$=token]').val();
    $('#Usuarios').DataTable({
        ajax: {
            url: 'https://localhost:44343/api/Usuarios/ObtenerUsuarios',
            dataSrc: '',
            headers: { "Authorization": token }
        },
        columns: [
            { data: 'Id', title: 'Id' },
            { data: 'Nombre', title: 'Nombre' },
            { data: 'Apellido', title: 'Apellido' },
            { data: function (row) { return moment(row.Fecha_Nacimiento).format("DD/MM/YYYY") }, title: 'Fecha de nacimiento' },
            { data: 'Mail', title: 'Mail' },
            {
                data: function (row) {
                    return row.Activo == true ? "Si" : "No";

                },
                title: 'Activo'
            },
            { data: 'Roles.Nombre', title: 'Activo' },
            {
                data: function (row) {
                    var buttons =
                        `<td><a href='javascript:EditarUsuario(${JSON.stringify(row)})'<i class="fa-solid fa-pen-to-square editarUsuario"></td>` +
                        `<td><a href='javascript:EliminarUsuario(${JSON.stringify(row.Id)})'<i class="fa-solid fa-trash eliminarUsuario"></i></td>`;
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


function EditarUsuario(row) {

    $("#UsuariosModal").modal();
    $('[id$=btnGuardar]').css('display', 'none');
    $('[id$=btnEditar]').css('display', '');
    $('[id$=idUsuario]').val(row.Id);
    $('[id$=NombreText]').val(row.Nombre);
    $('[id$=ApellidoText]').val(row.Apellido);
    $('[id$=ClaveText]').val(row.Clave);
    $('[id$=ClaveHasheada]').val(row.Clave);
    $('[id$=MailText]').val(row.Mail);
    $('[id$=FechaNacimientDate]').val(moment(row.Fecha_Nacimiento).format("DD/MM/YYYY"));
    $('[id$=ActivoCheck]').prop("checked", row.Activo);
    $('[id$=RolDrop]').val(row.Id_Rol);

}

function EliminarUsuario(id) {
    $("#eliminarUsuariosModal").modal();
    $('[id$=idUsuario]').val(id);
}

$('#btnNuevoUsuario').on('click', function () {
    clearUsuarios();
    $("#UsuariosModal").modal();
    $('[id$=btnGuardar]').css('display', '');
    $('[id$=btnEditar]').css('display', 'none');

});


function clearUsuarios() {
    $('[id$=idUsuario]').val("");
    $('[id$=NombreText]').val("");
    $('[id$=ApellidoText]').val("");
    $('[id$=ClaveText]').val("");
    $('[id$=ClaveHasheada]').val("");
    $('[id$=MailText]').val("");
    $('[id$=FechaNacimientDate]').val("");
    $('[id$=ActivoCheck]').prop("checked", false);
    $('[id$=RolDrop]').val("");
}