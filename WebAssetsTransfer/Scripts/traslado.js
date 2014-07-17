//GPE 1/22/2014 IE Problems 

$(function () {
    $(document).tooltip();
});
$(document).ready(function () {
    //De esta forma controlamos el evento blur, el cual se refiere
    //a que el control perdió el focon nos sirve para qeu al precionar TAB cuando estabamso en los campos de introducir filtros
    // no cargue el metodo de filtrado
    //$('[id*="txt_cod_centro_costo"]').blur(function () {
    //    $("[id*='btn_cargar_centro_costo']").click();
    //    return false;
    //});
    //$('[id*="txt_cod_solicitante"]').blur(function () {
    //    $("[id*='btn_cargar_solicitante']").click();
    //    return false;
    //});
    $('[id*="txt_codigo_centro_costo_destino"]').blur(function () {
        $("[id*='btn_cargar_centro_costo_destino']").click();
        return false;
    });
    $('[id*="txt_cod_responsable_destino"]').blur(function () {
        $("[id*='btn_cargar_responsable_destino']").click();
        return false;
    });
    //Campos de fechas   
    //GPE 12/2/2013 added mindate
    $('[id*="txt_fecha_reingreso_mantenimiento"]').datepicker({ dateFormat: 'dd-mm-yy', minDate: 0 }).val();
    //GPE 12/2/2013 added mindate
    $("input[id$=txt_fecha_aprox_reingreso]").datepicker({ dateFormat: 'dd-mm-yy', minDate: 0 }).val();
    $('.fancybox').fancybox();

});

//GPE 11/25/2013 Prevent Redirect on enter
$(document).keypress(function (e) {
    var keyCode = (window.event) ? e.which : e.keyCode;
    if (keyCode && keyCode == 13) {
        e.preventDefault();
        return false;
    }
});

function filtro(filtro, id_control_codigo, id_control_descripcion, id_responsable) {
    //Funcion para abrir el iframe en el pop up de fancybox los parametros de 
    $.fancybox.open({
        //href:'wbfrm_centro_costo.aspx?filtro=centro_costo&id_control_descripcion=txt_nombre_solicitante&id_control_codigo=txt_cod_solicitante';
        href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable,
        type: 'iframe',
        //margin: [50, 60, 50, 60], // Increase left/right
        //padding: 5
        width:"100%"
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

function bitacora_popup() {
    //Funcion para abrir el iframe en el pop up de fancybox para mostar y buscar la bitacora
    $.fancybox.open({
        href: 'wbfrm_bitacora.aspx',
        type: 'iframe',
        //margin: [15, 20, 15, 20], // Increase left/right
        //padding: 5,
        //Add BY GPE 3/7/2013 point.3 doc. After my visit
        width: 1000
    });
}

function movimiento_maestro_popup() {
    //Funcion para abrir el iframe en el pop up de fancybox para mostar y buscar la bitacora
    $.fancybox.open({
        href: 'wbfrm_movimiento_maestro.aspx',
        type: 'iframe',
       // margin: [150, 30, 150, 30], // Increase left/right
        padding: 5,
        //Add BY GPE 3/7/2013 point.3 doc. After my visit
        width: 1000
    });
}

// Enter Press ----> la siguientes funciones son para disparar el evento de boton al presionar enter despues de cada insersion de los códigos
// en los textbox que son llamados en el evento onKeyPress de cada textbox
//para los siguientes controles txt_cod_centro_costo, txt_cod_solicitante, txt_cod_centro_costo_destino, txt_cod_responsable_destino
//
function centro_costo_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_centro_costo']").click(); //ejecutamos la llamada al evento click de este boton
        return false; //detenemos la acción
    }
}

function solicitante_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_solicitante']").click();
        return false; // 
    }
}

function centro_costo_destino_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_centro_costo_destino']").click();
        return false; // 
    }
}

function responsable_destino_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_responsable_destino']").click();
        return false; // 
    }
}

