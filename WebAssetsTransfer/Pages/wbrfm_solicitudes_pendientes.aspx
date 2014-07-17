<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
     CodeBehind="wbrfm_solicitudes_pendientes.aspx.cs" Inherits="WebAssetsTransfer.Pages.wbrfm_solicitudes_pendientes" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/layout.css") %>" type="text/css" />
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Styles/style.css") %>" type="text/css" />
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-themes-1.10.3/themes/smoothness/jquery-ui.css") %>" type="text/css" />
    <link rel="stylesheet" href="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.css?v=2.1.4") %>" type="text/css" media="screen" />
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/jquery-1.9.1.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/Scripts/jquery-ui-1.10.3/ui/jquery-ui.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveClientUrl("~/fancybox/source/jquery.fancybox.pack.js?v=2.1.4") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="topfall" style="padding-top:40px;"></div>
  <fieldset>  
          <div style="float:right">
              <asp:ImageButton ID="img_btn_back_new" runat="server"   ImageUrl="~/Images/icons/btn_back_new.png" 
                  ToolTip ="Cerrar" OnClick="img_btn_back_new_Click" />  
          </div>
        <legend>
            <asp:Label ID="lb_titulo_filtro" runat="server" Text="Solicitudes Pendientes"></asp:Label>
        </legend>
    <div id="div_mensaje" class="div_mensaje_class" runat="server">
    </div>

<table  cellspacing="0" cellpadding="3" border="1" style="border-style:None;width:100%;border-collapse:collapse;"  rules="cols">
	<thead>
            <tr class="HeaderStyleGrid">
			    <th scope="col">Código Movimiento</th>
                <th scope="col">Usuario</th>
                <th scope="col">Descripcion Paso aprobación</th>
                <th scope="col">Paso aprobación</th>
                <th scope="col">Acción</th>
    	    </tr>
   </thead>	
    <tbody  id="tbodyPendingRequest" runat="server">
	</tbody></table>

</fieldset>
</asp:Content>