<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="wbfrm_traslado_activo.aspx.cs" Inherits="Modulo_Boston.Pages.wbfrm_donacion_activo" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"
        type="text/css" />
    <link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css"
        media="screen" />
    <!-- Add jQuery library -->
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>    
    <!-- Add fancyBox -->
    <script type="text/javascript" src="../fancybox/source/jquery.fancybox.pack.js?v=2.1.4"></script>      
    <script type="text/javascript">
        $(function () {
            $(document).tooltip();
        });
        $(document).ready(function () {
            //De esta forma controlamos el evento blur, el cual se refiere
            //a que el control perdió el focon nos sirve para qeu al precionar TAB cuando estabamso en los campos de introducir filtros
            // no cargue el metodo de filtrado
            $('[id*="txt_cod_centro_costo"]').blur(function () {
                $("[id*='btn_cargar_centro_costo']").click();
                return false;
            });
            $('[id*="txt_cod_solicitante"]').blur(function () {
                $("[id*='btn_cargar_solicitante']").click();
                return false;
            });
            $('[id*="txt_codigo_centro_costo_destino"]').blur(function () {
                $("[id*='btn_cargar_centro_costo_destino']").click();
                return false;
            });
            $('[id*="txt_cod_responsable_destino"]').blur(function () {
                $("[id*='btn_cargar_responsable_destino']").click();
                return false;
            });
            //Campos de fechas            
            $('[id*="txt_fecha_reingreso_mantenimiento"]').datepicker({ dateFormat: 'dd-mm-yy' }).val();
            $("input[id$=txt_fecha_aprox_reingreso]").datepicker({ dateFormat: 'dd-mm-yy' }).val();
            $('.fancybox').fancybox();
        });

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

        function bitacora_popup() {
            //Funcion para abrir el iframe en el pop up de fancybox para mostar y buscar la bitacora
            $.fancybox.open({
                href: 'wbfrm_bitacora.aspx',
                type: 'iframe',
                margin: [150, 200, 150, 200], // Increase left/right
                padding: 5
            });
        }

        function movimiento_maestro_popup() {
            //Funcion para abrir el iframe en el pop up de fancybox para mostar y buscar la bitacora
            $.fancybox.open({
                href: 'wbfrm_movimiento_maestro.aspx',
                type: 'iframe',
                margin: [150, 30, 150, 30], // Increase left/right
                padding: 5
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Contenedor o Sección  de los Filtros --%>
    <div id="div_mensaje" runat="server">
    </div>
    <%--Contenedor o Sección  de Donación--%>
    <div id="filtros">
       <asp:ImageButton ID="img_btn_nuevo" runat="server"  ImageUrl="~/Images/addrow.png" ToolTip="Crear Nueva Solicitud" 
        onclick="img_btn_nuevo_Click" />
        <asp:Button ID="btn_grupos_de_acceso" runat="server" Text="Grupos de Acceso" onclick="btn_grupos_de_acceso_Click" 
                      Visible="False"  />
         <asp:Button ID="btn_usuarios_por_grupo_de_acceso" runat="server" 
            Text="Usuarios por Grupo de Acceso" onclick="btn_usuarios_por_grupo_de_acceso_Click" 
                       Visible="False"  />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="tb_encabezado">
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_centro_costo" runat="server" Text="<%$ Resources:pages_names_es, lb_centro_costo%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td class="td_encabezado_col2">
                    <asp:Button ID="btn_cargar_centro_costo" runat="server" Text="" OnClick="btn_cargar_centro_costo_Click"
                        CssClass="button_filtrar" />
                    <asp:TextBox ID="txt_cod_centro_costo" onKeyPress="return centro_costo_key_press(event)"
                        runat="server" CssClass="txt_filtro_input"></asp:TextBox>
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
                    <asp:TextBox ID="txt_responsable" runat="server" CssClass="txt_ancho" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_id_solicitante" runat="server" Text="<%$ Resources:pages_names_es, lb_id_solicitante%>"
                        CssClass="ancho"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td class="td_encabezado_col2">
                    <asp:TextBox ID="txt_cod_solicitante" onKeyPress="return solicitante_key_press(event)"
                        runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                    <asp:Button ID="btn_cargar_solicitante" runat="server" Text="" OnClick="btn_cargar_solicitante_Click"
                         CssClass="button_filtrar" />
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_nombre_solicitante" runat="server" CssClass="txt_detalle"></asp:TextBox>
                    <input id="btn_buscar_solicitante" title="Buscar Información de Solicitante" runat="server" class="button_buscar" onclick="javascript:filtro('solicitante','txt_cod_solicitante','txt_nombre_solicitante', 'txt_responsable');"
                        type="button" value="" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="lb_fecha" runat="server" Text="<%$ Resources:pages_names_es, lb_fecha%>"></asp:Label>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox_fecha" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:Label ID="lb_solicitud" runat="server" Text="<%$ Resources:pages_names_es, lb_solicitud%>"></asp:Label>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="txt_num_solicitud" runat="server" CssClass="txt_regular" 
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="ancho">
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_tipo_movimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_tipo_movimiento%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td class="td_encabezado_txt">
                    <asp:DropDownList ID="ddl_tipo_movimiento" EnableViewState="true" runat="server"
                        AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddl_tipo_movimiento_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:pages_names_es, lb_planta %>"
                        Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txt_regular" Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="td_encabesado_centrado" colspan="7">
                    <asp:Button ID="btn_aplicar_solicitud" runat="server" Text="Aplicar Solicitud" OnClick="btn_aplicar_solicitud_Click"
                        CssClass="button_aplicar" />
                    <asp:Button ID="btn_aceptar" runat="server" CssClass="button_aplicar" 
                        Text="Aprobar" onclick="btn_aceptar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" CssClass="button_aplicar" 
					                     Text="No aprobar" onclick="btn_cancelar_Click" />
	<a><input id="btn_abrir_bitacora" runat="server" title="Revisar estado de Solicitud"  class ="button_bitacora" onclick="javascript:bitacora_popup();" type="button" value="Ver Solicitudes" /></a>
    <%--<a href="wbfrm_bitacora.aspx"><input id="btn_abrir_bitacora" runat="server" title="Revisar estado de Solicitud"  class ="button_bitacora" type="button" value="Ver Solicitudes" /></a>--%>
    
<a><input id="btn_abrir_movimiento_maestro" runat="server" title="Revisar Movimiento Activo" 
                        class ="button_movimiento" onclick="javascript:movimiento_maestro_popup();" 
                        type="button" value="Ver Movimiento" visible="False" /></a>
            </td>
        </tr>
	   <tr>
            <td class="td_encabesado_centrado">
                <asp:Label ID="lb_observaciones_solicitud" runat="server" Text="<%$Resources:pages_names_es, lb_observaciones_solicitud%>"></asp:Label>
            </td>
            <td class="td_encabesado_centrado" colspan="6">
                <asp:TextBox ID="txt_observaciones_solicitud" runat="server" CssClass="txt_ancho" 
                    TextMode="MultiLine"></asp:TextBox>
					
                </td>
            </tr>
        </table>
    </div>
    <div id="secciones">
        <%--Contenedor o Sección  de Area Destino--%>
        <div id="seccion_donacion" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_donacion" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_donacion%>"></asp:Label>
                </legend>
                <asp:Label ID="lb_observaciones" runat="server" Text="<%$ Resources:pages_names_es, lb_observaciones%>"></asp:Label>
                <br />
                <asp:TextBox ID="txt_observaciones_donacion" runat="server" CssClass="txt_ancho"
                    TextMode="MultiLine"></asp:TextBox>
            </fieldset>
        </div>
        <%--Contenedor o Sección  de Denuncia--%>
        <div id="seccion_area_destino" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_area_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_area_destino%>"></asp:Label>
                </legend>
                <br />
                <table class="ancho">
                    <tr>
                        <td class="td_encabezado_col3">
                            <asp:Label ID="lb_centro_costo_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_centro_costo_destino%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_codigo_centro_costo_destino" onKeyPress="return centro_costo_destino_key_press(event)"
                                runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                            <asp:Button ID="btn_cargar_centro_costo_destino" runat="server" Text="" OnClick="btn_cargar_centro_costo_destino_Click"
                                CssClass="button_filtrar" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nombre_centro_costo_destino" runat="server" CssClass="txt_detalle_area_destino"></asp:TextBox>
                            <input id="btn_buscar_centro_costo_destino" title="Buscar Información de Centro de Costo Destino" runat="server" class ="button_buscar" onclick="javascript:filtro('centro_costo','txt_codigo_centro_costo_destino','txt_nombre_centro_costo_destino', 'txt_cargo_responsable_costo_destino');" type="button" value="" />
                        </td>
                        <td>
                            <asp:Label ID="lb_responsable_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_responsable_destino%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cargo_responsable_costo_destino" runat="server" 
                                CssClass="txt_ancho" Width="152px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_encabezado_col3">
                            <asp:Label ID="lb_id_responsable_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_id_responsable_destino%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cod_responsable_destino" onKeyPress="return responsable_destino_key_press(event)"
                                runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                            <asp:Button ID="btn_cargar_responsable_destino" runat="server" Text="" OnClick="btn_cargar_responsable_destino_Click"
                                CssClass="button_filtrar" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nombre_responsable_destino" runat="server" CssClass="txt_detalle_area_destino"></asp:TextBox>
                            <input id="btn_buscar_resposable_destino" title="Buscar Información de Responsable Destino" class="button_buscar" runat="server" onclick="javascript:filtro('responsable','txt_cod_responsable_destino','txt_nombre_responsable_destino');"
                                type="button" value="" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                          <table class="tabla_ubicacion">
            <tr>               
                <td>
                    <asp:Label ID="lb_localizacion_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_localizacion_destino%>"></asp:Label>
                    <span class="campo_obligatotio">*</span>
                </td>
                <td>
                    <asp:Label ID="lb_seccion_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_seccion_destino%>"></asp:Label>
                    <span class="campo_obligatotio">*</span>
                </td>
                <td>
                    <asp:Label ID="lb_ubicacion_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_ubicacion_destino%>"></asp:Label>
                    <span class="campo_obligatotio">*</span>
                </td>
                 <td>
                    <asp:Label ID="lb_planta_destino" runat="server" 
                         Text="<%$ Resources:pages_names_es, lb_planta_destino %>" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>               
                <td>
                    <asp:DropDownList ID="ddl_localizacion_destino" runat="server"  AppendDataBoundItems="True" 
                        DataTextField="DES_LOCALIZACION_ACTVO" DataValueField="COD_LOCALIZACION_ACTIVO"
                        OnSelectedIndexChanged="ddl_localizacion_destino_SelectedIndexChanged" 
                        AutoPostBack="True">
                    <asp:ListItem Value="0">Seleccione la Localización</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txt_localizacion_solicitud" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_seccion_destino" runat="server" AutoPostBack="True" DataTextField="DES_SECCION_LOC" DataValueField="COD_SECCION_LOC"
                        onselectedindexchanged="ddl_seccion_destino_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    <asp:TextBox ID="txt_seccion_solicitud" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_ubicacion_destino" DataTextField="DES_UBICACION_ACTIVO" DataValueField="COD_UBICACION_ACTIVO" runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="txt_ubicacion_solicitud" runat="server"></asp:TextBox>
                </td>
                 <td>
                    <asp:DropDownList ID="ddl_planta_destino" runat="server" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </fieldset>
        </div>
        <%--Contenedor o Sección  de Calibración de Activos--%>
        <div id="seccion_denuncia" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_denuncia" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_denuncia%>"></asp:Label>
                </legend>
                <asp:Label ID="lb_numero_proceso" runat="server" Text="<%$ Resources:pages_names_es, lb_numero_proceso%>"></asp:Label>
                <span class="campo_obligatotio">*</span>
                &nbsp;<asp:TextBox ID="txt_num_proceso" runat="server" CssClass="txt_regular"></asp:TextBox>
                <br />
                <asp:Label ID="lb_observaciones_denuncia" runat="server" Text="<%$ Resources:pages_names_es, lb_observaciones_denuncia%>"></asp:Label>
                <br />
                <asp:TextBox ID="txt_observaciones_denuncia" runat="server" CssClass="txt_ancho"
                    TextMode="MultiLine"></asp:TextBox>
            </fieldset>
        </div>
        <%--Contenedor o Sección  de Destrucción--%>
        <div id="seccion_calibracion_activos" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_calibracion_mantenimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_calibracion %>"
                        CssClass="textbox"></asp:Label>
                </legend>
                <table class="ancho">
                    <tr>
                        <td class="td_col_1_calibracion">
                            <asp:Label ID="lb_proveedor" runat="server" Text="<%$ Resources:pages_names_es, lb_proveedor%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_proveedor" runat="server" CssClass="txt_regular"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lb_telefono" runat="server" Text="<%$ Resources:pages_names_es, lb_telefono%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_telefono_proveedor" runat="server" CssClass="txt_regular"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lb_fecha_aprox_reingreso" runat="server" Text="<%$ Resources:pages_names_es, lb_fecha_aprox_reingreso%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_fecha_aprox_reingreso" runat="server" CssClass="textbox_fecha"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lb_cedula_juridica" runat="server" Text="<%$ Resources:pages_names_es, lb_cedula_juridica%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cedula_juridica" runat="server" CssClass="txt_regular"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lb_contacto" runat="server" Text="<%$ Resources:pages_names_es, lb_contacto%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_nombre_contacto" runat="server" CssClass="txt_ancho"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lb_direccion_exacta_proveedor" runat="server" Text="<%$ Resources:pages_names_es, lb_direccion_exacta_proveedor%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="txt_direccion_proveedor" runat="server" CssClass="txt_ancho" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lb_observaciones_calibracion" runat="server" Text="<%$ Resources:pages_names_es, lb_observaciones_calibracion%>"></asp:Label>
                <asp:TextBox ID="txt_observaciones_calibracion" runat="server" CssClass="txt_ancho"
                    TextMode="MultiLine"></asp:TextBox>
                <br />
            </fieldset>
        </div>
        <%--Contenedor o Sección  Destrucción--%>
        <div id="seccion_destruccion" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_destruccion_activos" runat="server" Text="<%$ Resources:pages_names_es, lb_destruccion_activos%>"></asp:Label>
                </legend>
                <asp:Label ID="lb_observacion_destruccion" runat="server" Text="<%$ Resources:pages_names_es, lb_observacion_destruccion%>"></asp:Label>
                <br />
                <asp:TextBox ID="txt_observaciones_destruccion" runat="server" CssClass="txt_ancho"
                    TextMode="MultiLine"></asp:TextBox>
            </fieldset>
        </div>
    </div>
    <%--Grid o Lista de Activos--%>
    <%--Asset SAP--%>
    <div id="containt_grid" runat="server">
        <asp:GridView AutoGenerateColumns="False" ID="gv_activos" DataKeyNames="REF_NUM_ACT"
            runat="server" CssClass="ancho" ShowHeaderWhenEmpty="True" OnRowCommand="gv_activo_RowCommand"
            OnRowDeleting="gv_activo_RowDeleting">
            <PagerStyle CssClass="PagerStyleGrid" HorizontalAlign="Center" />
            <FooterStyle CssClass="FooterStyleGrid" />
            <SelectedRowStyle CssClass="SelectedRowStyleGrid" />
            <HeaderStyle CssClass="HeaderStyleGrid" />
            <AlternatingRowStyle CssClass="AlternatingRowStyleGrid" />
            <RowStyle CssClass="RowStyleGrid" />
            <Columns>
                <asp:CommandField ButtonType="Image" ShowDeleteButton="True" DeleteImageUrl="~/Images/delete.png">
                    <HeaderStyle CssClass="Header_botones" />
                    <ItemStyle CssClass="button_select_grid" />
                </asp:CommandField>
                <asp:ButtonField ButtonType="Image" CommandName="buscarClick" ImageUrl="~/Images/search.png">
                    <HeaderStyle CssClass="Header_botones" />
                    <ItemStyle CssClass="button_select_grid" />
                </asp:ButtonField>
                <asp:TemplateField HeaderText="Placa">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_entrada_placa" runat="server" Width="150" Text='<%# Bind("PLA_ACTIVO") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Asset SAP--%>
                <asp:TemplateField HeaderText="Asset SAP">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ref_activo" runat="server" Text='<%# Bind("REF_NUM_ACT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Descripcion del activo--%>
                <asp:TemplateField HeaderText="Descripcion del activo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_descripcion_activo" runat="server" Text='<%# Bind("DES_ACTIVO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Marca--%>
                <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate>
                        <asp:Label ID="lbl_marca" runat="server" Text='<%# Bind("DES_MARCA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Modelo--%>
                <asp:TemplateField HeaderText="Modelo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_modelo" runat="server" Text='<%# Bind("NOM_MODELO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Serie--%>
                <asp:TemplateField HeaderText="Serie">
                    <ItemTemplate>
                        <asp:Label ID="lbl_serie" runat="server" Text='<%# Bind("SER_ACTIVO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Valor en libros--%>
                <asp:TemplateField HeaderText="Valor en Libros">
                    <ItemTemplate>
                        <asp:Label ID="lbl_libros" runat="server" Text='<%# Bind("VAL_LIBROS" , "{0:N2}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
