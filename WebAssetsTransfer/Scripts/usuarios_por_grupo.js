//GPE 1/22/2014 IE Problems 

var radioStatus;

$(function () {
    $(document).tooltip();
});
$(document).ready(function () {
    radioStatus = false;
    DisableControls();

    $(':radio').click(function () {
        if (radioStatus)
            return true;
        else
            return false;
    });
});

function filtro(filtro, id_control_codigo, id_control_descripcion, id_responsable) {
    $(".div_mensaje_class").remove();
    // $("[id*=btn_excepto]").hide();
    // DisableControls();
    // radioStatus = false;
    $.fancybox.open({
        href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable,
        type: 'iframe',
        //margin: [50, 60, 50, 60], // Increase left/right
        //padding: 5
        //Add BY GPE 3/7/2013 point.3 doc. After my visit
        //width: 1000
        width:"100%"
    });
}

function cargar_usuarios_por_grupo_de_acceso(cod_compania, code_grupo, grupo, code_empleado, empleado, id_usuario, estado, codpropcompania) {
    $.fancybox.close();

    $("[id*=tb_compania]").val(cod_compania);
    $("[id*=tb_code_grupo]").val(code_grupo);
    $("[id*=tb_grupo]").val(grupo);
    $("[id*=tb_empeado_code]").val(code_empleado);
    $("[id*=tb_empleado]").val(empleado);
    $("[id*=tb_id_usuario]").val(id_usuario);

   // $("[id*=empleado_code_old]").val(code_empleado);

    $("[id*=tb_propcompania]").val(codpropcompania);

    if (estado == "True") {
        $('input:radio[value=activado]')[0].checked = true;
    }
    else {
        $('input:radio[value=desactivado]')[0].checked = true;
    }
    $(".div_mensaje_class").remove();
    $("[id*=btn_excepto]").hide();
    radioStatus = false;
    //DisableControls();
    EnableControls();
}

function EnableControls() {
    if (CheckPopulateControls() == "True" && $("[id*=status_control]").val() != "Create") {
        $("[id*=tb_compania]").prop('readOnly', false);
        $("[id*=tb_id_usuario]").prop('readOnly', false);

        $("[id*=btn_select_empleado]").removeAttr('disabled');
        $("[id*=btn_select_grupo]").removeAttr('disabled');

        radioStatus = true;

        $("[id*=status_control]").val("Edit");
        $("[id*=btn_excepto]").show();

        //alert("Ahora se puede editar!!!");
    }
}


function EnableControlsEdit() {
    if (CheckPopulateControls() == "True" && $("[id*=status_control]").val() != "Create") {
      //  $("[id*=tb_compania]").prop('readOnly', false);
        $("[id*=tb_id_usuario]").prop('readOnly', false);

     //   $("[id*=btn_select_empleado]").removeAttr('disabled');
       // $("[id*=btn_select_grupo]").removeAttr('disabled');

        radioStatus = true;

        $("[id*=status_control]").val("Edit");
        $("[id*=btn_excepto]").show();

        alert("Ahora se puede editar!!!");
    }
}

function DisableControls() {
    $("[id*=tb_grupo]").prop('readOnly', true);
    $("[id*=tb_code_grupo]").prop('readOnly', true);
    $("[id*=tb_compania]").prop('readOnly', true);
    $("[id*=tb_id_usuario]").prop('readOnly', true);
    $("[id*=tb_empeado_code]").prop('readOnly', true);
    $("[id*=tb_empleado]").prop('readOnly', true);
    $("[id*=tb_propcompania]").prop('readOnly', true);

    $("[id*=btn_select_empleado]").attr('disabled', 'disabled');
    $("[id*=btn_select_grupo]").attr('disabled', 'disabled');

}

function CheckPopulateControls() {
    if ($("[id*=tb_grupo]").val() != "" &&
    $("[id*=tb_code_grupo]").val() != "" &&
    $("[id*=tb_compania]").val() != "" &&
    $("[id*=tb_id_usuario]").val() != "" &&
    $("[id*=tb_empeado_code]").val() != "" &&
    $("[id*=tb_empleado]").val() != "" &&
   // $("[id*=empleado_code_old]").val() != "" &&
    $("[id*=tb_propcompania]").val() != ""
    )
        return "True";
    else
        return "False";
}

$(':radio').click(function () {
    if (radioStatus)
        return true;
    else
        return false;
});

function CreateNew() {
    $("[id*=tb_grupo]").val("");
    $("[id*=tb_code_grupo]").val("");
    $("[id*=tb_compania]").val("");
    $("[id*=tb_id_usuario]").val("");
    $("[id*=tb_empeado_code]").val("");
    $("[id*=tb_empleado]").val("");
   // $("[id*=empleado_code_old]").val("");
    $("[id*=tb_propcompania]").val("");

    $("[id*=tb_compania]").prop('readOnly', false);
    $("[id*=tb_id_usuario]").prop('readOnly', false);
    $("[id*=btn_select_empleado]").removeAttr('disabled');
    $("[id*=btn_select_grupo]").removeAttr('disabled');

    radioStatus = true;

    $("[id*=status_control]").val("Create");
    $("[id*=btn_excepto]").show();

    //alert("Ahora usted puede crear nuevas usuario!!!");
}

function cargar_grupo(id_grupo, grupo, propcompania) {
    $.fancybox.close();
    $("[id*=tb_code_grupo]").val(id_grupo);
    $("[id*=tb_grupo]").val(grupo);
    $("[id*=tb_propcompania]").val(propcompania);
}

function cargar_empleado(id_empleado, empleado) {
    $.fancybox.close();
    $("[id*=tb_empeado_code]").val(id_empleado);
    $("[id*=tb_empleado]").val(empleado);
}