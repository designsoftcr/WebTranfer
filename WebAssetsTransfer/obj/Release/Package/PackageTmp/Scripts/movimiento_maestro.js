//GPE 1/22/2014 IE Problems
//Add BY GPE 3/13/2013 point.2 doc. After my visit -- USED

$(function () {
    $("#txt_fecha").datepicker({ dateFormat: 'dd-mm-yy' }).val();
});

$(document).ready(function () {
    DisableControls();
});

function DisableControls() {
    $("[id*=txt_cod_centro_costo]").prop('readOnly', true);
    $("[id*=txt_des_centro_costo]").prop('readOnly', true);
    $("[id*=txt_cod_solicitante]").prop('readOnly', true);
    $("[id*=txt_nombre_solicitante]").prop('readOnly', true);
}


function filtro(filtro, id_control_codigo, id_control_descripcion, id_responsable) {
    //Funcion para abrir el iframe en el pop up de fancybox los parametros de 
    $.fancybox.open({
        //href:'wbfrm_centro_costo.aspx?filtro=centro_costo&id_control_descripcion=txt_nombre_solicitante&id_control_codigo=txt_cod_solicitante';
        href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable,
        type: 'iframe',
        margin: [50, 60, 50, 60], // Increase left/right
        padding: 5
    });
}

function cargar_controles(id_control_codigo, id_control_descripcion, id_responsable, codigo, descripcion, responsable) {
    //Funcion para cargar los datos provenientes de los pop up
    $.fancybox.close();
    $("[id*='" + id_control_codigo + "']").val(codigo);
    $("[id*='" + id_control_descripcion + "']").val(descripcion);
    $("[id*='" + id_responsable + "']").val(responsable);
}

function cargar_solicitante(id_control_codigo, id_control_descripcion, codigo, descripcion) {
    //Funcion para cargar los datos provenientes de los pop up
    $.fancybox.close();
    $("[id*='" + id_control_codigo + "']").val(codigo);
    $("[id*='" + id_control_descripcion + "']").val(descripcion);
}
function ClearFilters() {
    $("[id*=txt_codigo_movimiento]").val("");
    $("[id*=txt_cod_centro_costo]").val("");
    $("[id*=txt_des_centro_costo]").val("");
    $("[id*=txt_cod_solicitante]").val("");
    $("[id*=txt_nombre_solicitante]").val("");
    $("[id*=txt_responsable]").val("");
    $("[id*=txt_fecha]").val("");
    $("select#ddl_tipo_movimiento")[0].selectedIndex = 0;
}
