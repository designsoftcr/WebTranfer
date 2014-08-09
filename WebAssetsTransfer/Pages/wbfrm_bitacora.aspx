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
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.4") %>" type="text/css" media="screen" />
 
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

    <fieldset>
        <div style="text-align:right;">
        <input id="btnPrintImprimir" runat="server" title="Imprimir Reporte" class="btnPrintImprimir"  type="button" value="Imprimir Reporte" onclick="javascript: ImprimirReportePrint();"/>
            &nbsp;
             <asp:Button ID="btnExportImprimir"  CssClass="btnPrintImprimir" runat="server" Text="Generar Reporte Exportación" OnClick="btnExportImprimir_Click" /> 
            </div>
        <asp:Button ID="btn_realizar_filtrado" runat="server" CssClass="button_generic" 
                        onclick="btn_realizar_filtrado_Click" Text="Buscar" style="display:none;"/>
        <br /><table>
            <tr>
            <td>Tipo de movimiento</td>
            <td>Número de Solicitud</td>
            <td>Centro de Costo</td>
            <td>Solicitante</td>
            </tr>
            <tr>
            <td><asp:DropDownList ID="ddl_tipo_movimiento" onKeyPress="return realizar_busqueda(event)"   EnableViewState="true" runat="server"
                         AppendDataBoundItems="True">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="txt_codigo_movimiento" onKeyPress="return realizar_busqueda(event)"  runat="server" 
                        CssClass="txt_detalle"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txt_cod_centro_costo"  onKeyUp="return realizar_busqueda(event)" runat="server" CssClass="txt_detalle"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="txt_cod_solicitante" onKeyUp="return realizar_busqueda(event)" runat="server" CssClass="txt_detalle"></asp:TextBox>
            </td>
            </tr>

        </table>
    </fieldset>
        <br /><asp:GridView ID="gv_datos" runat="server" CellPadding="3"  
        GridLines="Vertical" AutoGenerateColumns="False"  
        BorderStyle="None"                               
        Width="100%" OnRowCommand="gv_datos_RowCommand">
        <FooterStyle CssClass="FooterStyleGrid" />
        <HeaderStyle CssClass="HeaderStyleGrid" />
        <AlternatingRowStyle CssClass="AlternatingRowStyleGrid" />
        <RowStyle CssClass="RowStyleGrid" />
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="image-print">
                    <ItemTemplate>
                        <asp:Button ID="btnPrint" CssClass="btnPrintClass" runat="server"
                             CommandName="PrintReport" CommandArgument='<%# Bind("NUMERO_SOLICITUD") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-CssClass="image-print">
                    <ItemTemplate>
                        <asp:Button ID="btnExport" CssClass="btnExportClass" runat="server" CommandName="ExportReport" 
                            CommandArgument='<%# Bind("NUMERO_SOLICITUD") %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-CssClass="image-detalle" HeaderText="Aprobaciones" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <input type="button" ID="btnDetalle" class="btnDetalleClass" value='<%# Bind("NUMERO_SOLICITUD")%>' style="font-size:0px;" runat="server" onclick="javascript: bitacora_popup(this.value);" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView> 
     
</div>
</div>
    </form>
</body>
</html>
