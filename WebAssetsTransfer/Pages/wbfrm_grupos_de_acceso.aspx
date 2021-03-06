﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
CodeBehind="wbfrm_grupos_de_acceso.aspx.cs" Inherits=" Modulo_Boston.Pages.wbfm_grupos_de_acceso" %>

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
    <%--<script type="text/javascript" src="../Scripts/grupos_de_acceso.js"></script> --%>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/grupos_de_acceso.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="topfall" style="padding-top:40px;"></div>
 <fieldset>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text="Grupos de Acceso"></asp:Label>
        </legend>
    <div id="div_mensaje" class="div_mensaje_class" runat="server">
    </div>

    <div id="filtros">
        <table class="tb_encabezado">
         <tr align="right">
         <td colspan="3">
          
       <input ID="img_btn_select" title="Buscar"  class="img_btn_select" type="button" value="" runat="server" onclick="javascript:filtro('grupos_de_acceso','txt_cod_solicitante','txt_nombre_solicitante', 'txt_responsable');" />

       <!--<input ID="img_btn_edit" title="Editar" class="img_btn_edit" type="button" value="" runat="server" onclick="javascript:EnableControls();" />-->

<%--       <input ID="img_btn_back" title="Cerrar" class="img_btn_back" type="button" value="" runat="server" onclick="window.location='/Pages/wbfrm_traslado_activo.aspx';" />--%>
            
                 <asp:ImageButton ID="img_btn_back_new" runat="server" CssClass="img_btn_back_new"  ImageUrl="~/Images/icons/btn_back_new.png" 
                  ToolTip ="Cerrar" OnClick="img_btn_back_new_Click" />  
           
         </td>
           </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lbl_compania" runat="server" Text="Compañía"></asp:Label></td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="tb_compania" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lblPropCompany" runat="server" Text="Compañía Propietaria"></asp:Label></td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="tb_propcompania" runat="server" CssClass="txt_detalle"></asp:TextBox>
                    <%--<input id="btn_select_propcompania" runat="server" class="button_buscar" onclick="javascript: filtro('propcompania_upgde', 'txt_cod_centro_costo', 'txt_des_centro_costo', 'txt_responsable');"
                        type="button" value="" />--%>
                </td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lbl_grupo" runat="server" Text="Grupo"></asp:Label>
                </td>
                <td class="td_encabezado_col2">
                    <asp:TextBox ID="tb_grupo" runat="server" CssClass="txt_filtro_input"></asp:TextBox>   
                     &nbsp;&nbsp;   
                     <asp:TextBox ID="tb_description" runat="server" CssClass="txt_detalle"></asp:TextBox>                 
                </td>
            </tr>
             <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="tb_email" runat="server" CssClass="txt_detalle"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
            <td>
            <asp:Label ID="lbl_estado" runat="server" Text="Estado"></asp:Label>
            </td>
            <td>
            <asp:RadioButtonList ID="rb_estado" runat="server" 
                    RepeatDirection="Horizontal">
                <asp:ListItem>activado</asp:ListItem>
                <asp:ListItem>desactivado</asp:ListItem>
            </asp:RadioButtonList>
            </td>
           </tr>
            
            <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_excepto" runat="server" Text="Salvar" CssClass = "btn_excepto_gda"
                    onclick="btn_excepto_Click" />
            </td>
           </tr>
        </table>       
    </div>   
     </fieldset>
</asp:Content>