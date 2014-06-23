<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_popup.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style.css"  rel="stylesheet" type="text/css"/>     
     <script type="text/javascript">
         $(document).ready(function () {

         });
         function enviar_datos(id_control_codigo, id_control_descripcion, codigo, descripcion) {
             parent.cargar_controles(id_control_codigo, id_control_descripcion, codigo, descripcion)
         }
       
    </script> 
</head>
<body>
      <form id="form1" runat="server">
    
    
    <%--Pop Up--%>
<div id="dialog_popup">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" ViewStateMode="Inherit" UpdateMode="Conditional">
    <ContentTemplate>
   
    <fieldset>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text=""></asp:Label>
        </legend>

        <table class="ancho">
            <tr>
                <td class="td_encabezado_filtro">
                    <asp:Label ID="lb_filtrado_codigo" runat="server" Text="Código"></asp:Label>
                </td>
                <td class="td_encabezado_filtro_col2">
                    <asp:TextBox ID="txt_filtro_codigo" runat="server" ReadOnly="True" 
                        CssClass="txt_regular"></asp:TextBox>
                </td>
                <td class="td_encabezado_filtro_col3">
                    <asp:Label ID="lb_filtrado_descripcion" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txt_filtro_descripcion" runat="server" CssClass="txt_ancho"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td colspan="3">
                    <asp:Button ID="btn_realizar_filtrado" runat="server" CssClass="button_generic" 
                        onclick="btn_realizar_filtrado_Click" Text="Buscar por Descripción" />
                    <asp:Button ID="btn_limpiar" runat="server" CssClass="button_generic" 
                        onclick="btn_limpiar_Click" Text="Limpiar Filtro" />
                    <asp:Button ID="Aceptar" runat="server" CssClass="button_generic" 
                        onclick="btn_aceptar_Click" Text="Aceptar" />
                    <input id="btn_cancelar" type="button" value="Cancelar" 
                        onclick="javascript:parent.jQuery.fancybox.close();" 
                        class="button_generic"/>
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
            <Columns>  
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/select.png" 
                    SelectText="" ShowSelectButton="True" >                            
                <ItemStyle CssClass="button_select_grid" />
                </asp:CommandField>                                                        
            </Columns>
        </asp:GridView> 
        </ContentTemplate>            
</asp:UpdatePanel>
</div>
<div id="div_mensaje" runat="server"></div>
    </form>
</body>
</html>
