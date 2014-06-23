<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_bitacora.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_bitacora" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bitacora</title>
    <%--<link href="../Styles/layout.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/layout.css") %>" type="text/css" />
   
   <%-- <link href="../Styles/style.css"  rel="stylesheet" type="text/css"/> --%> 
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/style.css") %>" type="text/css" />
   
      <%--<link rel="stylesheet" href="../Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css" type="text/css" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css") %>" type="text/css" />
    <%--<link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css" media="screen" />--%>
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.4") %>"type="text/css" media="screen" />
 
       <!-- Add jQuery library -->
   <%-- <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3/jquery-1.9.1.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/jquery-1.9.1.js") %>"></script>
   <%-- <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3/ui/jquery-ui.js"></script>   --%> 
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/ui/jquery-ui.js") %>"></script>
    
    <!-- Add fancyBox -->
    <%--<script type="text/javascript" src="../fancybox/source/jquery.fancybox.pack.js?v=2.1.4"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.pack.js?v=2.1.4") %>"></script>
    
    <style type="text/css">
        div.ui-datepicker{
         font-size:10px;
            }
           /*GPE 1/26/2014 IE Fixing Issues*/
              /*Add BY GPE 3/7/2013 point.1 doc. After my visit */
        /*body {
        overflow-y: scroll;
        }*/
    </style>  
  
    <style type="text/css">
        .txt_detalle {
        width: 160px;
        }
    </style>

     <!-- GPE 1/22/2014 IE Problems -->
    <%--<script type="text/javascript" src="../Scripts/bitacora.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/bitacora.js") %>"></script>

</head>
<body class="force_overflow">
     
    <form id="form1" runat="server">
        <div class="formClass" id="formClass">       
    <div id="div_mensaje" runat="server"></div>
    <%--Pop Up--%>

<div id="dialog_popup">
  
   <div id="hidePrint" class="hidePrint">
    <fieldset>
        
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text=""></asp:Label>
        </legend>

        <asp:Label ID="lb_mensaje" runat="server"></asp:Label>
        <div class="print" style="float:right">
             <input id="btnPrintImprimir" runat="server" title="Imprimir Reporte" class="btnPrintImprimir"  type="button" value="Imprimir Reporte" onclick="javascript: ImprimirReportePrint();"/>
            &nbsp;
             <asp:Button ID="btnExportImprimir"  CssClass="btnPrintImprimir" runat="server" Text="Imprimir Reporte Exportación" OnClick="btnExportImprimir_Click" /> 
        </div>
        

        <table class="ancho">
             <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_tipo_movimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_tipo_movimiento%>"></asp:Label>&nbsp;</td>
                <td class="td_encabezado_txt">
                    <asp:DropDownList ID="ddl_tipo_movimiento" EnableViewState="true" runat="server"
                         AppendDataBoundItems="True">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
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
        </table>
            <table class="ancho">
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="btn_realizar_filtrado" runat="server" CssClass="button_generic" 
                        onclick="btn_realizar_filtrado_Click" Text="Buscar" />
                    <input id="btn_limpiar" class="button_generic" type="button" value="Limpiar Filtro" name="btn_limpiar" onclick="javascript:ClearFilters();"/>
                    <input id="btn_cancelar" type="button" value="Cerrar" 
                        onclick="javascript:parent.jQuery.fancybox.close();" 
                        class="button_generic"/>
                    <asp:Button ID="btn_completar" runat="server" CssClass="button_generic" 
                        onclick="btn_completar_Click" Text="Completar" Visible="False" />
                </td>
            </tr>
        </table>
    </fieldset>
    </div>
        <asp:GridView ID="gv_datos" runat="server" CellPadding="3"  
        GridLines="Vertical" AutoGenerateColumns="False"  
        BorderStyle="None"                               
        Width="100%" OnRowCommand="gv_datos_RowCommand">
        <FooterStyle CssClass="FooterStyleGrid" />
        <HeaderStyle CssClass="HeaderStyleGrid" />
        <AlternatingRowStyle CssClass="AlternatingRowStyleGrid" />
        <RowStyle CssClass="RowStyleGrid" />
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="first" ItemStyle-CssClass ="first">
                    <ItemTemplate>
                        <asp:Button ID="btnPrint" CssClass="btnPrintClass" runat="server"
                             CommandName="PrintReport" CommandArgument='<%# Bind("CODIGO_BITACORA") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="first" ItemStyle-CssClass ="first">
                    <ItemTemplate>
                        <asp:Button ID="btnExport" CssClass="btnExportClass" runat="server" CommandName="ExportReport" 
                            CommandArgument='<%# Bind("CODIGO_BITACORA") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView> 
     
</div>
</div>
    </form>
</body>
</html>
