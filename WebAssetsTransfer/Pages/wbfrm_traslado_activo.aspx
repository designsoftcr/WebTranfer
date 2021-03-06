﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="wbfrm_traslado_activo.aspx.cs" Inherits="Modulo_Boston.Pages.wbfrm_donacion_activo" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
     <%--<link href="../Styles/layout.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/layout.css") %>" type="text/css" />
   
   <%-- <link href="../Styles/style.css"  rel="stylesheet" type="text/css"/> --%> 
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/style.css") %>" type="text/css" />

     <%--<link rel="stylesheet" href="../Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css" type="text/css" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css") %>" type="text/css" />
    <%--<link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css" media="screen" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.4") %>" type="text/css" media="screen" />
 
       <!-- Add jQuery library -->
   <%-- <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3/jquery-1.9.1.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/jquery-1.9.1.js") %>"></script>
   <%-- <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3/ui/jquery-ui.js"></script>   --%> 
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/ui/jquery-ui.js") %>"></script>
    
    <!-- Add fancyBox -->
    <%--<script type="text/javascript" src="../fancybox/source/jquery.fancybox.pack.js?v=2.1.4"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.pack.js?v=2.1.4") %>"></script>
 
    <!-- GPE 1/22/2014 IE Problems -->     
    <%--<script type="text/javascript" src="../Scripts/traslado.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/traslado.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="filtros" style="width:100%;">
        <div style="width:100%;float:left;background:#8D829A; height:30px;">
            <asp:Button ID="img_btn_nuevo" runat="server" Text="Nueva Solicitud" CssClass="btn_funcion btn_nuevo"
                    onclick="img_btn_nuevo_Click" />
 
                    <asp:Button ID="btn_usuarios_por_grupo_de_acceso" runat="server" 
             CssClass="btn_funcion btn_aprobadores" onclick="btn_usuarios_por_grupo_de_acceso_Click" 
                    Visible="False" Text="Aprobadores" />

                    <asp:Button ID="btn_grupos_de_acceso" runat="server" onclick="btn_grupos_de_acceso_Click" 
                    Visible="False" CssClass="btn_funcion btn_grupos"  Text="Grupos de Acceso" />

              <asp:Button ID="btnSolicitudePendientes" runat="server"  CssClass="btn_funcion btn_pendientes"
                        Text="Pendientes" OnClick="btnSolicitudePendientes_Click" />

                <a><input id="btn_abrir_bitacora" runat="server" title="Revisar estado de Solicitud"  class ="btn_funcion btn_movimientos" onclick="javascript: bitacora_popup();" type="button" value="Solicitudes" /></a>
                <%--<a href="wbfrm_bitacora.aspx"><input id="btn_abrir_bitacora" runat="server" title="Revisar estado de Solicitud"  class ="button_bitacora" type="button" value="Ver Solicitudes" /></a>--%>

                <a><input id="btn_abrir_movimiento_maestro" runat="server" title="Revisar Movimiento Activo" 
                        class ="btn_funcion btn_movimientos" onclick="javascript: movimiento_maestro_popup();" 
                        type="button" value="Movimientos" visible="False" /></a>

        </div>
        <div id="div_mensaje" runat="server">
        </div>
        <div style="width:100%;float:left;"><br />
            <fieldset>
            <table>
            <tr>
                <td class="td1">
                    <asp:Label ID="lb_centro_costo" runat="server" Text="<%$ Resources:pages_names_es, lb_centro_costo%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td>
                      <asp:TextBox ID="txt_cod_centro_costo" AutoComplete="off" runat="server" ReadOnly="true" CssClass="txt_filtro_input"></asp:TextBox>
                      <asp:DropDownList ID="ddl_centro_costo" runat="server" AutoPostBack="true" AppendDataBoundItems="True" CssClass="txt_filtro_input" OnSelectedIndexChanged="ddl_centro_costo_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Centro de Costo</asp:ListItem>
                      </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txt_des_centro_costo" runat="server" ReadOnly="true" CssClass="txt_detalle"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lb_responsable" CssClass="lbl_entrada" runat="server" Text="<%$ Resources:pages_names_es, lb_responsable%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txt_responsable" runat="server" style="width:200px;"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            </table>
            <table>
            <tr>
                <td class="td1">
                    <asp:Label ID="lb_id_solicitante" runat="server" Text="<%$ Resources:pages_names_es, lb_id_solicitante%>"
                        CssClass="ancho"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td>
                     <asp:TextBox ID="txt_cod_solicitante"  runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                     <asp:Button ID="btn_cargar_solicitante" runat="server" Text="" OnClick="btn_cargar_solicitante_Click"
                         CssClass="button_filtrar" />
                </td>
                <td>
                    <asp:TextBox ID="txt_nombre_solicitante" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                        <asp:Label ID="lb_fecha" runat="server" Text="<%$ Resources:pages_names_es, lb_fecha%>"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_fecha" runat="server" CssClass="textbox_fecha" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td class="style7">
                        <asp:Label ID="lb_solicitud" runat="server" Text="<%$ Resources:pages_names_es, lb_solicitud%>"></asp:Label>
                    </td>
                    <td class="td_encabezado_txt">
                        <asp:TextBox ID="txt_num_solicitud" runat="server" CssClass="txt_regular" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
                <table>
            <tr>
                <td class="td1">
                    <asp:Label ID="lb_tipo_movimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_tipo_movimiento%>"></asp:Label><span class="campo_obligatotio">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_tipo_movimiento" EnableViewState="true" runat="server"
                        AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddl_tipo_movimiento_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            </table>
        <table class="ancho">
            <tr>
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
                    <asp:Button ID="btn_aceptar" runat="server" CssClass="button_aplicar" 
                        Text="Aprobar" onclick="btn_aceptar_Click" />
                    <asp:Button ID="btn_cancelar" runat="server" CssClass="button_aplicar" 
					                     Text="No aprobar" onclick="btn_cancelar_Click" />
            </td>
        </tr>
       <%-- Add BY GPE 3/18/2014 point.5 doc. After my visit add tdObservaciones --%>
	   <!--<tr id="trObservaciones" runat="server">
            <td class="td_encabesado_centrado ">              
                     <asp:Label ID="lb_observaciones_solicitud" runat="server" Text="<%$Resources:pages_names_es, lb_observaciones_solicitud%>"></asp:Label>
           </td>
            <td class="td_encabesado_centrado" colspan="6">
                <asp:TextBox ID="txt_observaciones_solicitud" Visible="false" runat="server" CssClass="txt_ancho" 
                    TextMode="MultiLine"></asp:TextBox>
					
                </td>
            </tr>-->
        </table>
    <div id="secciones" style="width:100%; float:left;">
        <%--Contenedor o Sección  de Area Destino--%>
        <div id="seccion_donacion" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_donacion" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_donacion%>"></asp:Label>
                </legend>
                <asp:Label ID="lb_observaciones" runat="server" Text="<%$ Resources:pages_names_es, lb_observaciones%>"></asp:Label><span id="div_observaciones_obligatory" runat="server" class="campo_obligatotio">*</span>
                <br />
                <asp:TextBox ID="txt_observaciones_donacion" runat="server" CssClass="txt_ancho"
                    TextMode="MultiLine"></asp:TextBox>
                <br /><br />
                <asp:GridView ID="GridObservacionesDonacion" runat="server" style="padding-left:2%;width:96%;" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
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
                            <asp:TextBox ID="txt_codigo_centro_costo_destino" onKeyUp="return centro_costo_destino_key_press(event)"
                                runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                            <asp:Button ID="btn_cargar_centro_costo_destino" runat="server" Text="" OnClick="btn_cargar_centro_costo_destino_Click"
                                CssClass="button_filtrar"  />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nombre_centro_costo_destino" runat="server" ReadOnly="true" CssClass="txt_detalle_area_destino"></asp:TextBox>
                            <input id="btn_buscar_centro_costo_destino" title="Buscar Información de Centro de Costo Destino" runat="server" class ="button_buscar" 
                                onclick="javascript: filtro('centro_costo', 'txt_codigo_centro_costo_destino', 'txt_nombre_centro_costo_destino', 'txt_cargo_responsable_costo_destino');" type="button" value="" />
                        </td>
                        <td>
                            <asp:Label ID="lb_responsable_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_responsable_destino%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cargo_responsable_costo_destino" runat="server" 
                                CssClass="txt_detalle_area_destino"  ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_encabezado_col3">
                            <asp:Label ID="lb_id_responsable_destino" runat="server" Text="<%$ Resources:pages_names_es, lb_id_responsable_destino%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cod_responsable_destino" onKeyUp="return responsable_destino_key_press(event)"
                                runat="server" CssClass="txt_filtro_input"></asp:TextBox>
                            <asp:Button ID="btn_cargar_responsable_destino" runat="server" Text="" OnClick="btn_cargar_responsable_destino_Click"
                                CssClass="button_filtrar" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nombre_responsable_destino" runat="server" ReadOnly="true" CssClass="txt_detalle_area_destino"></asp:TextBox>
                            <input id="btn_buscar_resposable_destino" title="Buscar Información de Responsable Destino" class="button_buscar" runat="server" 
                                onclick="javascript: filtro('responsable', 'txt_cod_responsable_destino', 'txt_nombre_responsable_destino');"
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
                    <asp:TextBox ID="txt_localizacion_solicitud" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_seccion_destino" runat="server" AutoPostBack="True" DataTextField="DES_SECCION_LOC" DataValueField="COD_SECCION_LOC"
                        onselectedindexchanged="ddl_seccion_destino_SelectedIndexChanged">
                    </asp:DropDownList>
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
                <br /><br />
                <asp:GridView ID="GridObservacionesDenuncia" runat="server" style="padding-left:2%;width:96%;" CellPadding="4" ForeColor="#333333" GridLines="None" BorderStyle="Solid" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </fieldset>
        </div>
        <%--Contenedor o Sección  de Destrucción--%>
        <div id="seccion_calibracion_activos" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="lb_fieldset_calibracion_mantenimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_fieldset_calibracion %>"
                        CssClass="textbox"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="td1">
                            <asp:Label ID="lb_proveedor" runat="server" Text="<%$ Resources:pages_names_es, lb_proveedor%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_proveedor" runat="server" CssClass="txt_detalle"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lb_cedula_juridica" runat="server" Text="<%$ Resources:pages_names_es, lb_cedula_juridica%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cedula_juridica" runat="server" CssClass="txt_detalle"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lb_contacto" runat="server" Text="<%$ Resources:pages_names_es, lb_contacto%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_nombre_contacto" runat="server" CssClass="txt_detalle"></asp:TextBox>
                        </td>
                        </tr>
                    </table>
                <table>
                    </table>
                <table>
                    <tr>
                        <td class="td1">
                            <asp:Label ID="lb_telefono" runat="server" Text="<%$ Resources:pages_names_es, lb_telefono%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_telefono_proveedor" runat="server" CssClass="txt_detalle"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lb_fecha_aprox_reingreso" runat="server" Text="<%$ Resources:pages_names_es, lb_fecha_aprox_reingreso%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_fecha_aprox_reingreso" runat="server" CssClass="textbox_fecha"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td style="width:49%;">
                            <asp:Label ID="lb_direccion_exacta_proveedor" runat="server" Text="<%$ Resources:pages_names_es, lb_direccion_exacta_proveedor%>"></asp:Label>
                            <span class="campo_obligatotio">*</span>
                            <asp:TextBox ID="txt_direccion_proveedor" CssClass="txt_ancho" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lb_observaciones_calibracion" runat="server" Text="<%$ Resources:pages_names_es, lb_observaciones_calibracion%>"></asp:Label>
                            <asp:TextBox ID="txt_observaciones_calibracion" runat="server" CssClass="txt_ancho"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridObservacionesCalibracion" runat="server" style="padding-left:2%;width:96%;" CellPadding="4" ForeColor="#333333" GridLines="None" BorderStyle="Solid" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
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
                <br /><br />
                <asp:CheckBox Text="Activos sin placa" ID="chkSinPlaca" OnCheckedChanged="chkSinPlaca_CheckedChange" runat="server" AutoPostBack="true" />
                <br /><br />
                <asp:GridView ID="GridObservacionesDestruccion" runat="server" style="width:96%;padding-left:2%;" CellPadding="4" ForeColor="#333333" GridLines="None" BorderStyle="Solid" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </fieldset>
        </div>
    </div>
    <%--Grid o Lista de Activos--%>
    <%--Asset SAP--%>
    <br /><div id="containt_grid" runat="server" style="width:100%;float:left;">
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
                <asp:TemplateField >
                    <HeaderTemplate><asp:Label ToolTip="Debe marcar el Check si es desecho electrónico, por ejemplo computadoras, teclados, monitores" runat="server">¿Electrónico?</asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chbDesecho" runat="server" />
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Placa">
                    <ItemTemplate>
                        <asp:TextBox AutoPostBack="true" ID="txt_entrada_placa" runat="server" Width="150" Text='<%# Bind("PLA_ACTIVO") %>' AccessKey='<%# Convert.ToInt32(DataBinder.Eval(Container, "RowIndex")) %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Asset SAP--%>
                <asp:TemplateField HeaderText="Activo SAP">
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
        <asp:GridView AutoGenerateColumns="False" ID="gv_SinPlaca"
            runat="server" CssClass="ancho" ShowHeaderWhenEmpty="True" 
            OnRowCommand="gv_SinPlaca_RowCommand" 
            OnRowDeleting="gv_SinPlaca_RowDeleting" 
            >
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
                <asp:ButtonField ButtonType="Image" CommandName="buscarClick" ImageUrl="~/Images/search.png" >
                    <HeaderStyle CssClass="Header_botones" />
                    <ItemStyle CssClass="button_select_grid" />
                </asp:ButtonField>
                <asp:TemplateField >
                    <HeaderTemplate><asp:Label ToolTip="Debe marcar el Check si es desecho electrónico, por ejemplo computadoras, teclados, monitores" runat="server">¿Electrónico?</asp:Label></HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chbDesecho" runat="server" />
                        </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion del activo">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_descripcion_activo" runat="server"  Text='<%# Bind("DES_ACTIVO") %>' Width="150"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Marca--%>
                <asp:TemplateField HeaderText="Marca">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_marca" runat="server"  Text='<%# Bind("DES_MARCA") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Modelo--%>
                <asp:TemplateField HeaderText="Modelo">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_modelo" runat="server" Text='<%# Bind("NOM_MODELO") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Serie--%>
                <asp:TemplateField HeaderText="Serie">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_serie" runat="server" Text='<%# Bind("SER_ACTIVO") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--Valor en libros--%>
                <asp:TemplateField HeaderText="Valor en Libros">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_valor_libros" runat="server" Text='<%# Bind("VAL_LIBROS") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
           </Columns>
        </asp:GridView>
    </div>
    <div style="text-align:right;">
        <br />
        <asp:Button ID="btn_aplicar_solicitud" runat="server" Text="Aplicar Solicitud" OnClick="btn_aplicar_solicitud_Click"
                       style="margin-top:10px;height:30px;" CssClass="button_aplicar" />
        <asp:Button ID="btn_aplicar_solicitud_sin_placa" runat="server" Text="Aplicar Solicitud"
                       style="margin-top:10px;height:30px;" CssClass="button_aplicar" OnClick="btn_aplicar_solicitud_sin_placa_Click" />
    </div>
        </fieldset>
        </div>
    </div>
</asp:Content>
