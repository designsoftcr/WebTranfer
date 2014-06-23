<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_bitacora.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_bitacora" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bitacora</title>
    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style.css"  rel="stylesheet" type="text/css"/>  
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" type="text/css"/>
        <link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css"
        media="screen" />    
    <!-- Add jQuery library -->
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>    
    <!-- Add fancyBox -->
    <script type="text/javascript" src="../fancybox/source/jquery.fancybox.pack.js?v=2.1.4"></script>      
    <script type="text/javascript">
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
    </script> 
    <style type="text/css">
        .txt_detalle {
        width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
    <div id="div_mensaje" runat="server"></div>
    <%--Pop Up--%>

<div id="dialog_popup">
  
   
    <fieldset>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text=""></asp:Label>
        </legend>

        <asp:Label ID="lb_mensaje" runat="server"></asp:Label>

        <table class="ancho">
            <tr>
                <td class="td_encabezado_filtro_bitacora">
                    <asp:Label ID="lb_codigo_movimiento" runat="server" Text="Número de Solicitud"></asp:Label>
                </td>
                <td class="td_encabezado_filtro_col2">
                    <asp:TextBox ID="txt_codigo_movimiento" runat="server" 
                        CssClass="txt_detalle"></asp:TextBox>
                </td>
                <td class="td_encabezado_filtro_col2">
                    &nbsp;</td>
                <td class="td_encabezado_filtro_col2">
                    &nbsp;</td>
                <td class="td_encabezado_filtro_col3">
                    &nbsp;</td>
                <td class="td_encabezado_filtro_col3">
                    &nbsp;</td>
            </tr>
          </table>
          <table class="tb_encabezado">
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_centro_costo" runat="server" Text="<%$ Resources:pages_names_es, lb_centro_costo%>"></asp:Label>&nbsp;</td>
                <td class="td_encabezado_col2">                    
                    <asp:TextBox ID="txt_cod_centro_costo" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_des_centro_costo" runat="server" CssClass="txt_detalle"></asp:TextBox>
                    <input id="btn_buscar_centro_costo" runat="server" title="Buscar Información de Centro de Costo" class="button_buscar" onclick="javascript:filtro('centro_costo','txt_cod_centro_costo','txt_des_centro_costo', 'txt_responsable');"
                        type="button" value="" />
                </td>
                 <td>
                    <asp:Label ID="lb_responsable" runat="server" Text="<%$ Resources:pages_names_es, lb_responsable%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txt_responsable" runat="server" CssClass="txt_detalle" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_id_solicitante" runat="server" Text="<%$ Resources:pages_names_es, lb_id_solicitante%>"
                        CssClass="ancho"></asp:Label>&nbsp;</td>
                <td class="td_encabezado_col2">
                    <asp:TextBox ID="txt_cod_solicitante" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_nombre_solicitante" runat="server" CssClass="txt_detalle"></asp:TextBox>
                    <input id="btn_buscar_solicitante" title="Buscar Información de Solicitante" runat="server" class="button_buscar" onclick="javascript:filtro('solicitante','txt_cod_solicitante','txt_nombre_solicitante', 'txt_responsable');"
                        type="button" value="" />
                </td>
                <td>
                    <asp:Label ID="lb_fecha" runat="server" Text="<%$ Resources:pages_names_es, lb_fecha%>"></asp:Label>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox_fecha" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_tipo_movimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_tipo_movimiento%>"></asp:Label>&nbsp;</td>
                <td class="td_encabezado_txt">
                    <asp:DropDownList ID="ddl_tipo_movimiento" EnableViewState="true" runat="server"
                        AutoPostBack="true" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
            <table class="ancho">
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="btn_realizar_filtrado" runat="server" CssClass="button_generic" 
                        onclick="btn_realizar_filtrado_Click" Text="Buscar" />
                    <input id="btn_limpiar" class="button_generic" type="button" value="Limpiar Filtro" name="btn_limpiar"/>
                    <input id="btn_cancelar" type="button" value="Cerrar" 
                        onclick="javascript:parent.jQuery.fancybox.close();" 
                        class="button_generic"/>
                    <asp:Button ID="btn_completar" runat="server" CssClass="button_generic" 
                        onclick="btn_completar_Click" Text="Completar" Visible="False" />
                </td>
            </tr>
        </table>

    </fieldset>
        <asp:GridView ID="gv_datos" runat="server" CellPadding="3"  
        GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="False"  
        BorderStyle="None"                
        OnPageIndexChanging="gv_datos_PageIndexChanging"  
        OnSelectedIndexChanged="gv_datos_SelectedIndexChanged"                
        Width="100%">
        <PagerStyle CssClass="PagerStyleGrid" HorizontalAlign="Center" />
        <FooterStyle CssClass="FooterStyleGrid" />
        <SelectedRowStyle CssClass="SelectedRowStyleGrid" />
        <HeaderStyle CssClass="HeaderStyleGrid" />
        <AlternatingRowStyle CssClass="AlternatingRowStyleGrid" />
        <RowStyle CssClass="RowStyleGrid" />
        </asp:GridView> 
    
</div>

    </form>
</body>
</html>
