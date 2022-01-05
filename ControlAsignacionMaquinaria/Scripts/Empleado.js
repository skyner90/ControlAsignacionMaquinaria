$(document).ready(function () { initEmpleado(); });

function initEmpleado() {
    console.log("initEmpleado");
    document.title = 'Asignacion - Empleado';
    //#region Botones Cerrar Modales
    $("#btnCerrarModalNuevo").click(function () {
        limpiarCampos();
    });
    $("#btnCerrarModalEditar").click(function () {
        limpiarCampos();
    });
    $("#btnCerrarModalEliminar").click(function () {
        limpiarCampos();
    });
    $("#modalNuevoEmpleado").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    $("#modalEditarEmpleado").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    $("#modalEliminarEmpleado").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    //#endregion
    $("#tblEmpleado").DataTable({
    });
}

//#region Nuevo Empleado

$("#btnNuevoEmpleadoModal").click(function () {
    var nombre = $('#txtNombreNuevo').val();
    var descripcion = $('#txtDescripcionNuevo').val();

    if (nombre == 0 || nombre == " " || nombre === "") {
        toastr.warning('Ingrese el Nombre', { positionClass: "toast-bottom-right" });
    } else {
        agregarEmpleado();
    }
});

function agregarEmpleado() {
    var objModel = "{empNombre:'" + $("#txtNombreNuevo").val() + "',empCargo:'" + $("#txtCargoNuevo").val() +
        "',empCedula:'" + $("#txtCedulaNuevo").val() + "',empArea:'" + $("#txtAreaNuevo").val() +
        "'} ";
    var json = eval("(" + objModel + ')');
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Empleado/nuevoEmpleado',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == true) {
                toastr.success('Registro guardado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalNuevoEmpleado').modal('hide');
                limpiarCampos();
                location.reload();
            } else {
                toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
            }
        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });
}
//#endregion

//#region Editar Empleado
$(".btnSeleccionEditar").click(function () {
    seleccionEditarEmpleado(this);
});

function seleccionEditarEmpleado(boton) {
    var idEmpleado = $(boton).attr('data-idEmpleado');
    var objModel = "{empId:'" + idEmpleado + "'}";
    var json = eval("(" + objModel + ')');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Empleado/consultarEmpleado',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            $("#IdEmpleadoEditar").val(data.empId);
            $("#txtNombreEditar").val(data.empNombre);
            $("#txtCargoEditar").val(data.empCargo);
            $("#txtCedulaEditar").val(data.empCedula);
            $("#txtAreaEditar").val(data.empArea);

            if (data.empEstado == true) {
                $("#slcEstadoEditar").val("true");
                $("#divEstado").hide();
            } else {
                $("#slcEstadoEditar").val("false");
                $("#divEstado").show();
            }
        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });
}

$("#btnEditarEmpleadoModal").click(function () {
    var nombre = $('#txtNombreEditar').val();
    var descripcion = $('#txtDescripcionEditar').val();


    if (nombre == 0 || nombre == " " || nombre === "") {
        toastr.warning('Ingrese el Nombre', { positionClass: "toast-bottom-right" });
    } else {
        editarEmpleado();
    }
});

function editarEmpleado() {
    var objModel = "{empId:'" + $("#IdEmpleadoEditar").val() + "',empNombre:'" + $("#txtNombreEditar").val() +
        "',empCargo:'" + $("#txtCargoEditar").val() + "',empCedula:'" + $("#txtCedulaEditar").val() +
        "',empArea:'" + $("#txtAreaEditar").val() + "',empEstado:'" + $("#slcEstadoEditar").val() +
        "'}";
    var json = eval("(" + objModel + ')');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Empleado/editarEmpleado',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if (data == true) {
                toastr.success('Registro guardado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalEditarEmpleado').modal('hide');
                limpiarCampos();
                location.reload();
            } else {
                toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
            }

        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });
}
//#endregion

//#region Eliminar Empleado
$(".btnSeleccionEliminar").click(function () {
    seleccionEliminarEmpleado(this);
});

function seleccionEliminarEmpleado(boton) {
    var idEmpleado = $(boton).attr('data-idEmpleado');
    $('#IdEmpleadoEliminar').val(idEmpleado);
}

$("#btnEliminarEmpleadoModal").click(function () {
    eliminarEmpleado();
});

function eliminarEmpleado() {
    var objModel = "{empId:'" + $("#IdEmpleadoEliminar").val() + "'}";
    var json = eval("(" + objModel + ')');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Empleado/eliminarEmpleado',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if (data == true) {
                toastr.success('Registro Eliminado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalEliminarEmpleado').modal('hide');
                limpiarCampos();
                location.reload();
            } else {
                toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
            }

        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });
}
//#endregion

//#region Limpiar Campos

function limpiarCampos() {

    //campos modal contactos
    $("#txtNombreNuevo").val("");
    $("#txtCargoNuevo").val("");
    $("#txtCedulaNuevo").val("");
    $("#txtAreaNuevo").val("");

    $("#txtNombreEditar").val("");
    $("#txtCargoEditar").val("");
    $("#txtCedulaEditar").val("");
    $("#txtAreaEditar").val("");

    $("#IdEmpleadoEditar").val("");
    $("#IdEmpleadoEliminar").val("");
}
//#endregion