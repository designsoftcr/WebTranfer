<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wbfrm_login.aspx.cs" Inherits="WebAssetsTransfer.wbfrm_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <div id="container">            
            <!-- Header -->
            <div id="header">
                    <div class="logo-fontsistemas">Font Sistemas</div>
                    <div class="logo-system">IMoERP</div>
            </div>
            <!-- content -->
            <div id="content">            
                <div class="login_content">
                    <div class="transparente"></div>
                    <div id="login_controls">
                        <div id="seccion_a" runat="server">
                            <h3> <asp:Label ID="lbl_etiqueta_usuario" runat="server" Text="<%$ Resources:pages_names_es, lbl_etiqueta_usuario%>"></asp:Label></h3>
                            <asp:TextBox ID="txt_usuario" runat="server" MaxLength="80"></asp:TextBox>
                            <h3><asp:Label ID="lbl_etiqueta_contrasena" runat="server" Text="<%$ Resources:pages_names_es, lbl_etiqueta_contrasena%>"></asp:Label></h3>
                            <asp:TextBox ID="txt_contrasena" runat="server" MaxLength="80" TextMode="Password"></asp:TextBox>
                        </div>           
                    </div> 
                    <div class="btn_login">
                        <asp:Button ID="btn_login" Text="Iniciar sesión" runat="server" 
                        CssClass="btnin" onclick="btn_login_Click" />
                    </div> 
                    <div id="div_mensaje" class="mensaje_login" runat="server"></div>                      
                </div>
            </div>
            <!-- footer -->
            <div id="footer">
                <div class="footer-containt">
                    <div class="fleft">
                        <label>©2013 Font Sistemas</label>  <span>|</span>
                        <label>Web Assets Transfer</label> <span>|</span>
                        <label>Departamento de Finanzas</label> <span>|</span>
                        <%--<asp:Label ID="lblCodMarca" runat="server" Text="<%$ Resources:general_es, lbl_version%>"></asp:Label>--%>
                    </div>
                    <!--<div class="fright">
                        <a href="#"><img alt="" src="../Images/footer_p1.jpg" /></a>
                        <a href="#"><img alt="" src="../Images/footer_p2.jpg" /></a>
                        <a href="#"><img alt="" src="../Images/footer_p3.jpg" /></a>
                        <a href="#"><img alt="" src="../images/footer_p4.jpg" /></a>
                        <a href="#"><img alt="" src="../Images/footer_p5.jpg" /></a>
                    </div>-->
                    <div class="clear">
                    </div>
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
