$(document).ready(function () { initAsignacion(); });

function initAsignacion() {
    console.log("initAsignacion");
    document.title = 'Asignacion - Empleado';
   
    //#region Formato Select y carga de Data
    $("#slcEmpleado").select2({
        placeholder: 'Seleccione',
        allowClear: true
    });
    cargarEmpleado();
    //#endregion 

    $('#slcEmpleado').on('change', function () {
        var data = $(this).val();
        if (data != 0) {
            consultarAsignaciones(data);
        }
    });
}

//#region Consultar Maquinaria Asignada por Empleado
function consultarAsignaciones(data) {

    var objModel = "{empId:'" + data + "'}";
    var json = eval("(" + objModel + ')');

    $.ajax({
        async: true,
        type: 'POST',
        url: '/Maquinaria/consultarMaquinariaEmpleado',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.length > 0) {
                llenarTablaAsignacion(data);
            } else {
                $('#tblAsignacion').empty();
            }
        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });

}
//#endregion

//#region llenar tabla Asignacion Maquinaria
function llenarTablaAsignacion(data) {
    var trHTML =
        '<thead>' +
        '<tr>' +
        '<th>Serie</th>' +
        '<th>Descripción</th>' +
        '<th>Estado</th>' +
        '<th></th>' + //fila vacia donde va el boton de editar
        '</tr > ' +
        '</thead> ' +
        '<tbody> ';
    $.each(data, function (i, item) {
        trHTML +=
            '<tr>' +
            '<td > ' + item.maqSerie + '</td>' +
            '<td > ' + item.maqDescripcion + '</td>';

        if (item.maqDisponible == false) {
            trHTML +=
                '<td >Asignado</td>';
            if (item.maqAsignadaEstado == false) {
                trHTML += '<td > ' +

                    '</td>';
            } else {
                trHTML +=
                    '<td >' +
                    '<div class="form-check mb-2">' +
                    '<input class="form-check-input checkMaquinaria" name="checkMaquinaria" type="checkbox" id="autoSizingCheck" value="' + item.maqId + '" style="width:15px; height:15px; border-color:#D3D6E4;position:relative;"checked >' +
                    '</div>' +
                    '</td>';
            }


        } else {
            trHTML +=
                '<td >Disponible</td>' +
                '<td >' +
                '<div class="form-check mb-2">' +
                '<input class="form-check-input checkMaquinaria" name="checkMaquinaria" type="checkbox" id="autoSizingCheck" value="' + item.maqId + '" style="width:15px; height:15px; border-color:#D3D6E4;position:relative;" >' +
                '</div>' +
                '</td > ';
        };
    });
    trHTML +=
        '</tr>' +
        '</tbody>';
    $('#tblAsignacion').html('');
    $('#tblAsignacion').append(trHTML);

}
//#endregion

//#region Nuevo Asignacion

$("#btnGuardarAsignacion").click(function () {
    var empleado = $('#slcEmpleado').val();
    var arr = $('[name="checkMaquinaria"]:checked').map(function () {
        return this.value;
    }).get();



    var arr = $('[name="checkMaquinaria"]:checked').map(function () {
        return this.value;
    }).get();
    if (arr.length == 0) {
        var objModel = "{empId:'" + empleado + "'} ";
    } else {
        var objModel = "{empId:'" + empleado +
            "',";
        var a = 0;
        if (arr.length > 0) {
            $.each(arr, function (index, data) {
                if (a == 0) {
                    objModel += "ListaMaquinaria:[{maqId:'" + data +
                        "'}";
                } else {
                    objModel += ",{maqId:'" + data +
                        "'}";
                }
                a = 1;
            });
            objModel += "]}";
        } else {
            var objModel = "{}";
        }
    }

    var json = eval("(" + objModel + ')');
    console.log(json);
    $.ajax({
        async: true,
        type: 'POST',
        url: '/Asignacion/nuevaAsignacion',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            location.reload();
        },
        error: function () {
            toastr.warning('Error al generar el reporte', { positionClass: "toast-bottom-right" });
        }
    });

});
//#endregion


//#region Cargar Select 
//Empleado
function cargarEmpleado() {
    $.ajax({
        async: true,
        type: 'POST',
        dataType: "JSON",
        url: '/Empleado/consultarEmpleadoJSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var slcEmpleado = "";
            slcEmpleado += '<option></option>';
            $.each(data, function (i, obj) {
                slcEmpleado += '<option value="' + obj.empId + '">' + obj.empNombre + '</option>';
            });
            $("#slcEmpleado").html(slcEmpleado);
        },
        error: function () {
            console.log("No se cargo la información");

        }
    });
}

//#endregion