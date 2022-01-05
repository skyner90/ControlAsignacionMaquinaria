$(document).ready(function () { initMaquinaria(); });

function initMaquinaria() {
    console.log("initMaquinaria");
    document.title = 'Asignacion - Maquinaria';
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
    $("#modalNuevoMaquinaria").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    $("#modalEditarMaquinaria").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    $("#modalEliminarMaquinaria").on("hidden.bs.modal", function () {
        limpiarCampos();
    });
    //#endregion
    $("#tblMaquinaria").DataTable({
    });
}

//#region Nuevo Maquinaria

$("#btnNuevoMaquinariaModal").click(function () {
    var nombre = $('#txtNombreNuevo').val();
    var descripcion = $('#txtDescripcionNuevo').val();

    if (nombre == 0 || nombre == " " || nombre === "") {
        toastr.warning('Ingrese el Nombre', { positionClass: "toast-bottom-right" });
    } else {
        agregarMaquinaria();
    }
});

function agregarMaquinaria() {
    var objModel = "{maqSerie:'" + $("#txtSerieNuevo").val() + "',maqDescripcion:'" + $("#txtDescripcionNuevo").val() +
        "'} ";
    var json = eval("(" + objModel + ')');
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Maquinaria/nuevoMaquinaria',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data == true) {
                toastr.success('Registro guardado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalNuevoMaquinaria').modal('hide');
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

//#region Editar Maquinaria
$(".btnSeleccionEditar").click(function () {
    seleccionEditarMaquinaria(this);
});

function seleccionEditarMaquinaria(boton) {
    var idMaquinaria = $(boton).attr('data-idMaquinaria');
    var objModel = "{maqId:'" + idMaquinaria + "'}";
    var json = eval("(" + objModel + ')');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Maquinaria/consultarMaquinaria',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            $("#IdMaquinariaEditar").val(data.maqId);
            $("#txtSerieEditar").val(data.maqSerie);
            $("#txtDescripcionEditar").val(data.maqDescripcion);
            if (data.maqEstado == true) {
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

$("#btnEditarMaquinariaModal").click(function () {
    var nombre = $('#txtNombreEditar').val();
    var descripcion = $('#txtDescripcionEditar').val();


    if (nombre == 0 || nombre == " " || nombre === "") {
        toastr.warning('Ingrese el Nombre', { positionClass: "toast-bottom-right" });
    } else {
        editarMaquinaria();
    }
});

function editarMaquinaria() {
    var objModel = "{maqId:'" + $("#IdMaquinariaEditar").val() + "',maqSerie:'" + $("#txtSerieEditar").val() +
        "',maqDescripcion:'" + $("#txtDescripcionEditar").val() + "',maqEstado:'" + $("#slcEstadoEditar").val() +
        "'}";
    var json = eval("(" + objModel + ')');
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Maquinaria/editarMaquinaria',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if (data == true) {
                toastr.success('Registro guardado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalEditarMaquinaria').modal('hide');
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

//#region Eliminar Maquinaria
$(".btnSeleccionEliminar").click(function () {
    seleccionEliminarMaquinaria(this);
});

function seleccionEliminarMaquinaria(boton) {
    var idMaquinaria = $(boton).attr('data-idMaquinaria');
    $('#IdMaquinariaEliminar').val(idMaquinaria);
}

$("#btnEliminarMaquinariaModal").click(function () {
    eliminarMaquinaria();
});

function eliminarMaquinaria() {
    var objModel = "{maqId:'" + $("#IdMaquinariaEliminar").val() + "'}";
    var json = eval("(" + objModel + ')');
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Maquinaria/eliminarMaquinaria',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if (data == true) {
                toastr.success('Registro Eliminado con éxito', { positionClass: "toast-bottom-right" });
                $('#modalEliminarMaquinaria').modal('hide');
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
    $("#txtSerieNuevo").val("");
    $("#txtDescripcionNuevo").val("");

    $("#txtSerieEditar").val("");
    $("#txtDescripcionEditar").val("");

    $("#IdMaquinariaEditar").val("");
    $("#IdMaquinariaEliminar").val("");
}
//#endregion