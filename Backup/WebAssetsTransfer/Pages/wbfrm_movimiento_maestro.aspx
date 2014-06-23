<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_movimiento_maestro.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_movimiento_maestro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>Movimientos Maestros</title>

    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style.css"  rel="stylesheet" type="text/css"/>  
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" type="text/css"/>    
    <!-- Add jQuery library -->
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script> 
        
</head>
<body>
    <form id="form1" runat="server">

      <div id="div_mensaje" runat="server"></div>
       <%--Pop Up--%>
   
   <div id="dialog_popup">
  
   
    <fieldset>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text="Movimiento De Activo"></asp:Label>
        </legend>

        <asp:Label ID="lb_mensaje" runat="server"></asp:Label>

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
                  
                      <asp:TemplateField HeaderText="Código Movimiento">
                        <ItemTemplate>
                            <asp:Label ID="lb_codigo_movimiento" runat="server" Text='<%# Bind("ID_MOVIMIENTO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Acta">
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
