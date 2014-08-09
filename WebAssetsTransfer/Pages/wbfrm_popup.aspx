<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_popup.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbfrm_popup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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

    <!-- GPE 1/22/2014 IE Problems -->    
    <%--<script type="text/javascript" src="../Scripts/popup.js"></script>--%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/popup.js") %>"></script>
 
       <%--GPE 1/26/2014 IE Fixing Issues--%>
<%--       Add BY GPE 3/7/2013 point.1 doc. After my visit --%>
<%--    <style type="text/css">
          body {
        overflow-y: scroll;
        }
    </style>--%>
</head>
<body class="force_overflow">
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

        <table>
            <tr>
                <td>
                    <asp:Label ID="lb_filtrado_codigo" runat="server" Text="Código"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_filtro_codigo" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lb_filtrado_descripcion" runat="server" Text="Descripción" ></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txt_filtro_descripcion" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                    <td>
                        <asp:Button ID="btn_realizar_filtrado" runat="server" CssClass="button_generic" onclick="btn_realizar_filtrado_Click" Text="Buscar"/>
                    </td>
                    <td>
                        <asp:Button ID="Aceptar" runat="server" CssClass="button_generic" onclick="btn_aceptar_Click" Text="Editar" style="display:none;" />
                    </td>
            </tr>
         </table>
            <!--<table>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="btn_limpiar" runat="server" CssClass="button_generic" onclick="btn_limpiar_Click" Text="Limpiar Filtro" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <input id="btn_cancelar" type="button" value="Cancelar" 
                            onclick="javascript:parent.jQuery.fancybox.close();" 
                            class="button_generic"/>
                    </td>
                </tr>
            </table>-->
        <br /><br /><br />
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
