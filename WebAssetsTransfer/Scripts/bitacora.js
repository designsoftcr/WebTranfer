//GPE 1/22/2014 IE Problems

$(function () {
    $("#txt_fecha").datepicker({ dateFormat: 'dd-mm-yy' }).val();
});

$(document).ready(function () {
    DisableControls();

    $('[id*="txt_cod_centro_costo"]').blur(function () {
        $("[id*='btn_cargar_centro_costo']").click();
        //alert("Se salió del contro de centro de costo");
        return false;
    });
    $('[id*="txt_cod_solicitante"]').blur(function () {
        $("[id*='btn_cargar_solicitante']").click();
        return false;
    });
});

$(document).keypress(function (e) {
    var keyCode = (window.event) ? e.which : e.keyCode;
    if (keyCode && keyCode == 13) {
        e.preventDefault();
        return false;
    }
});

function DisableControls() {
    //$("[id*=txt_cod_centro_costo]").prop('readOnly', true);
    $("[id*=txt_des_centro_costo]").prop('readOnly', true);
    //$("[id*=txt_cod_solicitante]").prop('readOnly', true);
    $("[id*=txt_nombre_solicitante]").prop('readOnly', true);
}


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

function centro_costo_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_centro_costo']").click();
        //alert("Presionó ENTER Centro de costo");
        return false; // 
    }
}

function solicitante_key_press(event) {
    if (event.keyCode == 13) {
        $("[id*='btn_cargar_solicitante']").click();
        return false; // 
    }
}

function realizar_busqueda(event) {
    if (event.keyCode == 13) {
        //alert("Presionó ENTER");
        $("[id*='btn_realizar_filtrado']").click();
        return false; // 
    }
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


function ImprimirReportePrint() {
    var form = document.getElementById("formClass");

    //var allRows = form.getElementById('gv_datos').rows;
    // for (var i=0; i< allRows.length; i++) {
    //  	  if (allRows[i].cells.length > 3) {
    //         allRows[i].deleteCell(-1); //delete the cell
    //         } 
    //         }

    var disp_setting = "toolbar=yes,location=no,directories=yes,menubar=yes,";
    //disp_setting += "scrollbars=yes,width=1000, height=780, left=100, top=25";
    disp_setting += "scrollbars=yes,width=100%, height=780, left=100, top=25";
    var docprint = window.open("about:blank", "_blank", disp_setting);
    docprint.document.open();
    docprint.document.write('<html>');
    docprint.document.write('<head>');
    docprint.document.write(' <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />');
    docprint.document.write(' <link href="../Styles/style.css" media="print" rel="stylesheet" type="text/css"/>');
    // docprint.document.write('<link rel="stylesheet" href="../Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css" type="text/css"/>');
    // docprint.document.write(' <link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css" media="screen" /> ');
    docprint.document.write('<style type="text/css"> .hidePrint{display:none;} table td.first { display: none; }  table th.first { display: none; } </style>  ');
    docprint.document.write('</head>');
    docprint.document.write('<body>');
    docprint.document.write('<div id="container"> ');
    docprint.document.write('<div id="header_container"> ');
    docprint.document.write('<div class="logo_company">Boston Scientific</div> ');
    // docprint.document.write('<div style="top:10px;" class="logo_fontsistemas">Font Sistemas</div>  ');
    docprint.document.write('<div class="page_title"> ');
    docprint.document.write('<h1><span id="page_title">Formulario para movimiento de Activo Fijo</span></h1>  </div></div> ');

    docprint.document.write('<div id="content">');
    docprint.document.write('<div id="message_content" style="margin-bottom:20px;"><p class="message"><span class="asterisco">* </span>');
    docprint.document.write('<span id="lb_aviso">Es la responsabilidad del Gerente de cada Dpto. asegurar que los activos fijos de su area de responsabilidad sean debidamente controlados, asi como de informar cualquier movimineto importante en los mismos al Dpto de Finanzas.</span>');
    docprint.document.write('<span class="asterisco">* </span> </p> </div>');
    docprint.document.write('  <div id="main_content"> ');

    docprint.document.write(form.innerHTML);
    docprint.document.write('</div></div></div>');

    //docprint.document.write('		<div id="container">');
    //docprint.document.write('		<div id="header_container">');
    //docprint.document.write('			<div class="logo_company">Boston Scientific</div>');
    //docprint.document.write('			<div class="logo_fontsistemas">Font Sistemas</div>');
    //docprint.document.write('			<div class="page_title">');

    //docprint.document.write('				<h1>');
    //docprint.document.write('				<span id="lb_page_title">Sistemas de aprobación de movimientos para Activos Fijos</span>');
    //docprint.document.write('				</h1>');
    //docprint.document.write('			</div> ');

    //docprint.document.write('		</div>');
    //docprint.document.write('		<div id="content"> ');
    //docprint.document.write('		tes test');
    //docprint.document.write('	  </div>');
    //docprint.document.write('		<div class="clear"></div>');
    //docprint.document.write('		<div id="footer">');
    //docprint.document.write('			 <div id="footer_content">  ');
    //docprint.document.write('				 <span class="importante"><span id="ctl00_lb_titulo_declaracion_jurada">Declaracion Jurada</span>  </span>');
    //docprint.document.write('			 <br>');
    //docprint.document.write('				 <p class="footer"><span id="ctl00_lb_declaracion_jurada">Declaro</span></p>');
    //docprint.document.write('			 </div>  ');
    //docprint.document.write('			</div>');
    //docprint.document.write('		</div>  ');

    docprint.document.write('</body></html>');
    docprint.document.close();
    docprint.print();
    docprint.close();
}

function bitacora_popup(valor) {
    //Funcion para abrir el iframe en el pop up de fancybox para mostar y buscar la bitacora
    $.fancybox.open({
        href: 'wbfrm_bitacora_detalle.aspx?id=' + valor,
        type: 'iframe',
        //margin: [15, 20, 15, 20], // Increase left/right
        //padding: 5,
        //Add BY GPE 3/7/2013 point.3 doc. After my visit
        width: "100%"//1000
    });
}