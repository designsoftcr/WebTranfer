﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_movimiento_maestro.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_movimiento_maestro" %>

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
    <%--<script type="text/javascript" src="../Scripts/bitacora.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/movimiento_maestro.js") %>"></script>


        
</head>
<body class="force_overflow">
    <form id="form1" runat="server">

      <div id="div_mensaje" runat="server"></div>
       <%--Pop Up--%>
   
   <div id="dialog_popup">
  
   
    <fieldset>
        <div class="print" style="float:left;width:100%;text-align:right;" >
            <asp:Button ID="btnExportMovimiento"  CssClass="btnPrintImprimir" runat="server" Text="Movimiento De Activo Reporte Exportación" OnClick="btnExportMovimiento_Click" /> 
        </div>
            <asp:Button ID="btn_consulta_filtrada" runat="server" Text="" OnClick="btn_consulta_filtrada_Click"
                        CssClass="button_filtrar" style="display:none;" />
        <table>
            <tr>
            <td>Tipo de movimiento</td>
            <td>Número de Solicitud</td>
            <td>Centro de Costo</td>
            <td>Solicitante</td>
            </tr>
            <tr>
            <td><asp:DropDownList ID="ddl_tipo_movimiento" onKeyPress="return realizar_busqueda(event)" EnableViewState="true" runat="server"
                         AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddl_tipo_movimiento_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Tipo de Movimiento</asp:ListItem>
                    </asp:DropDownList></td>
            <td><asp:TextBox ID="txt_codigo_movimiento" onKeyPress="return realizar_busqueda(event)" runat="server"></asp:TextBox></td>
            <td><asp:TextBox ID="txt_cod_centro_costo"  onKeyUp="return realizar_busqueda(event)" runat="server"></asp:TextBox></td>
            <td><asp:TextBox ID="txt_cod_solicitante" onKeyUp="return realizar_busqueda(event)" runat="server" CssClass="txt_detalle"></asp:TextBox></td>
            </tr>

        </table>
    </fieldset>

    <%--Grid donde se carga la informacion de los movimientos maestros basados en el combo dee estado--%>
    <br /><div id="grid_movimiento">
        
        <asp:GridView AutoGenerateColumns="False" ID="gv_movimiento_maestro" AllowPaging="True"
                ShowFooter="True" runat="server" BorderStyle="None"
                 GridLines="Vertical" CellPadding="3"
             OnSelectedIndexChanged="gv_movimiento_maestro_SelectedIndexChanged"   
            OnPageIndexChanging="gv_movimiento_maestro_PageIndexChanging"             
            Width="100%" onrowediting="gv_movimiento_maestro_Editing" 
               onrowupdating="gv_movimiento_maestro_Updating" 
               onrowcancelingedit="gv_movimiento_maestro_CancelEditing">
            <PagerStyle CssClass="PagerStyleGrid" HorizontalAlign="Center" />
            <HeaderStyle CssClass="HeaderStyleGrid" />
            <FooterStyle CssClass="FooterStyleGrid" />
            <SelectedRowStyle CssClass="SelectedRowStyleGrid" />
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
                  
                      <asp:TemplateField HeaderText="Número de Solicitud">
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

                     <asp:TemplateField HeaderText="ID Solicitante">
                        <ItemTemplate>
                            <asp:Label ID="lb_codigo_empleado" runat="server" Text='<%# Bind("ID_EMPLEADO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Nombre Solicitante">
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
