<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_movimiento_maestro.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_movimiento_maestro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>Movimientos Maestros</title>

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
  
        <!-- GPE 1/22/2014 IE Problems -->
    <%--<script type="text/javascript" src="../Scripts/bitacora.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/movimiento_maestro.js") %>"></script>


        
</head>
<body class="force_overflow">
    <form id="form1" runat="server">

      <div id="div_mensaje" runat="server"></div>
         <div class="print" style="float:right;padding-top:25px;padding-right:10px;" >
            <asp:Button ID="btnExportMovimiento"  CssClass="btnPrintImprimir" runat="server" Text="Movimiento De Activo Reporte Exportación" OnClick="btnExportMovimiento_Click" /> 
        </div>

       <%--Pop Up--%>
   
   <div id="dialog_popup">
  
   
    <fieldset>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text="Movimiento De Activo"></asp:Label>
        </legend>

        <asp:Label ID="lb_mensaje" runat="server"></asp:Label>

        <table class="ancho">
             <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lb_tipo_movimiento" runat="server" Text="<%$ Resources:pages_names_es, lb_tipo_movimiento%>"></asp:Label>&nbsp;</td>
                <td class="td_encabezado_txt">
                    <asp:DropDownList ID="ddl_tipo_movimiento" EnableViewState="true" runat="server"
                         AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipo_movimiento_SelectedIndexChanged">
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
                    <input id="btn_buscar_centro_costo" runat="server" title="Buscar Información de Centro de Costo" class="button_buscar" onclick="javascript: filtro('centro_costo', 'txt_cod_centro_costo', 'txt_des_centro_costo', 'txt_responsable');"
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
                    <input id="btn_buscar_solicitante" title="Buscar Información de Solicitante" runat="server" class="button_buscar" onclick="javascript: filtro('solicitante', 'txt_cod_solicitante', 'txt_nombre_solicitante', 'txt_responsable');"
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
                <td class="td_encabezado_filtro_bitacora">
                    <asp:Label ID="lb_movimiento_maestro_estado" runat="server" Text="Estado" 
                        Visible="False"></asp:Label>
                </td>
                <td class="td_encabezado_filtro_col2">
                    <asp:DropDownList id="DDL_ESTADO" runat="server" Visible="False">
                              <asp:ListItem Value="P">Proceso</asp:ListItem>
                              <asp:ListItem Value="A">Aceptado</asp:ListItem>
                              <asp:ListItem Value="C">Cancelado</asp:ListItem>
                    </asp:DropDownList>
                </td>
             
            </tr>
             <tr>
                <td>
                    &nbsp;</td>
                <td colspan="5">
                    <asp:Button ID="btn_consulta_filtrada" runat="server" CssClass="button_generic" 
                        onclick="btn_consulta_filtrada_Click" Text="Consultar" />
                    <input id="btn_limpiar" class="button_generic" type="button" value="Limpiar Filtro" name="btn_limpiar" onclick="javascript: ClearFilters();"/>
                    <input id="btn_cancelar" type="button" value="Cerrar" 
                        onclick="javascript:parent.jQuery.fancybox.close();" 
                        class="button_generic"/>
                </td>
            </tr>
        </table>

    </fieldset>

    <%--Grid donde se carga la informacion de los movimientos maestros basados en el combo dee estado--%>
    <div id="grid_movimiento">
        <asp:GridView AutoGenerateColumns="False" ID="gv_movimiento_maestro" AllowPaging="True"
                ShowFooter="True" runat="server" BorderStyle="None"
                 GridLines="Vertical" CellPadding="3"
             OnSelectedIndexChanged="gv_movimiento_maestro_SelectedIndexChanged"                
            Width="100%" onrowediting="gv_movimiento_maestro_Editing" 
               onrowupdating="gv_movimiento_maestro_Updating" 
               onrowcancelingedit="gv_movimiento_maestro_CancelEditing">
            <PagerStyle CssClass="PagerStyleGrid" HorizontalAlign="Center" />
            <FooterStyle CssClass="FooterStyleGrid" />
            <SelectedRowStyle CssClass="SelectedRowStyleGrid" />
            <HeaderStyle CssClass="HeaderStyleGrid" />
            <AlternatingRowStyle CssClass="AlternatingRowStyleGrid" />
            <RowStyle CssClass="RowStyleGrid" />
                <Columns>
                      <asp:CommandField ButtonType="Image" ShowEditButton="True" 
                          EditImageUrl="~/Images/editar.gif" CancelImageUrl="~/Images/cancelar.gif" 
                          UpdateImageUrl="~/Images/guardar.gif"/>
                    <asp:TemplateField HeaderText="Vigente">
                        <ItemTemplate>
                            <asp:CheckBox ID="chbVigente" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                      <asp:TemplateField HeaderText="Código Movimiento">
                        <ItemTemplate>
                            <asp:Label ID="lb_codigo_movimiento" runat="server" Text='<%# Bind("ID_MOVIMIENTO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Validación de movimiento">
                         <EditItemTemplate>
                            <asp:TextBox ID="txt_acta" runat="server" 
                                Text='<%# Bind("ACTA") %>'></asp:TextBox>
                         </EditItemTemplate>
                  
                        <ItemTemplate>
                            <asp:Label ID="lb_acta" runat="server" Text='<%# Bind("ACTA") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Centro de Costo">
                        <ItemTemplate>
                            <asp:Label ID="lb_centro_costo" runat="server" Text='<%# Bind("CENTRO_COSTO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Código de Empleado">
                        <ItemTemplate>
                            <asp:Label ID="lb_codigo_empleado" runat="server" Text='<%# Bind("ID_EMPLEADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Descripcion de Centro de Costo">
                        <ItemTemplate>
                            <asp:Label ID="lb_descripcion_centro_costo" runat="server" Text='<%# Bind("DESCRIPCION_CENTRO_COSTOS") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Empleado Responsable">
                        <ItemTemplate>
                            <asp:Label ID="lb_empleado_responsable" runat="server" Text='<%# Bind("EMPLEADO_RESPONSABLE_CC") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Tipo de Movimiento">
                        <ItemTemplate>
                            <asp:Label ID="lb_tipo_movimiento" runat="server" Text='<%# Bind("ID_TIPO_MOVIMIENTO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lb_estado" runat="server" Text='<%# Bind("ESTADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                    

                </Columns>
            
            </asp:GridView>
    </div>



       </div>

    </form>
</body>
</html>
