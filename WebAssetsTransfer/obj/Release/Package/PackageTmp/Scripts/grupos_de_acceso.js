//GPE 1/22/2014 IE Problems

var radioStatus;
var status_btn_excepto;

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

function filtro(filtro, id_control_codigo, id_control_descripcion, id_responsable, id_propcompania) {
    $(".div_mensaje_class").remove();
    $("[id*=btn_excepto]").hide();
    DisableControls();
    radioStatus = false;

    $.fancybox.open({
        href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable + '&id_propcompania=' + id_propcompania,
        type: 'iframe',
        //margin: [50, 60, 50, 60], // Increase left/right
        //padding: 5
        //Add BY GPE 3/7/2013 point.3 doc. After my visit
        width: 1000
    });
}

function cargar_grupos_de_acceso(codigo, descripcion, cod_compania, email_grupo, estado, propcompania) {
    $(".div_mensaje_class").remove();
    $.fancybox.close();

    $("[id*=tb_grupo]").val(codigo);
    $("[id*=tb_description]").val(descripcion);
    $("[id*=tb_compania]").val(cod_compania);
    $("[id*=tb_email]").val(email_grupo);
    $("[id*=tb_propcompania]").val(propcompania);

    if (estado == "True") {
        $('input:radio[value=activado]')[0].checked = true;
    }
    else {
        $('input:radio[value=desactivado]')[0].checked = true;
    }
    DisableControls();
}

function EnableControls() {
    $(".div_mensaje_class").remove();
    if (CheckPopulateControls() == "True") {
        $("[id*=tb_email]").prop('readOnly', false);
        radioStatus = true;
        //$("[id*=btn_select_propcompania]").removeAttr('disabled');
        $("[id*=btn_excepto]").show();
        alert("Ahora puede editar el control electrónico y el estado!!!");
    }
}

function DisableControls() {
    $("[id*=tb_grupo]").prop('readOnly', true);
    $("[id*=tb_description]").prop('readOnly', true);
    $("[id*=tb_compania]").prop('readOnly', true);
    $("[id*=tb_email]").prop('readOnly', true);
    $("[id*=tb_propcompania]").prop('readOnly', true);
   // $("[id*=btn_select_propcompania]").attr('disabled', 'disabled');

}

function CheckPopulateControls() {
    if ($("[id*=tb_grupo]").val() != "" &&
       $("[id*=tb_description]").val() != "" &&
       $("[id*=tb_compania]").val() != "" &&
       $("[id*=tb_propcompania]").val() != "" &&
       $("[id*=tb_email]").val() != "")
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


function cargar_propcompania(id_propcompany, name_propcompany) {
    $.fancybox.close();
    $("[id*=tb_propcompania]").val(id_propcompany);
    $("[id*=tb_email]").prop('readOnly', false);
    radioStatus = true;
   // $("[id*=btn_select_propcompania]").removeAttr('disabled');
    $("[id*=btn_excepto]").show();
}