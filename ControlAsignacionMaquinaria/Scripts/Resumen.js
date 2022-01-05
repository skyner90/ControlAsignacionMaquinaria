$(document).ready(function () { initResumen(); });

function initResumen() {
    console.log("initResumen");
    document.title = 'Asignacion - Resumen';

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
        url: '/Maquinaria/consultarMaquinariaEmpleadoId',
        data: JSON.stringify(json),
        dataType: 'JSON',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (data.length > 0) {
                llenarTablaResumen(data);
            } else {
                $('#tblResumen').empty();
            }
        },
        error: function () {
            toastr.warning('Error al realizar el registro', { positionClass: "toast-bottom-right" });
        }
    });

}
//#endregion

//#region llenar tabla Resumen
function llenarTablaResumen(data) {
    var trHTML =
        '<thead>' +
        '<tr>' +
        '<th>Serie</th>' +
        '<th>Descripción</th>' +
        '</tr > ' +
        '</thead> ' +
        '<tbody> ';
    $.each(data, function (i, item) {
        trHTML +=
            '<tr>' +
            '<td > ' + item.maqSerie + '</td>' +
            '<td > ' + item.maqDescripcion + '</td>';
                
    });
    trHTML +=
        '</tr>' +
        '</tbody>';
    $('#tblResumen').html('');
    $('#tblResumen').append(trHTML);

}
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