<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
CodeBehind="wbfrm_grupos_de_acceso.aspx.cs" Inherits=" Modulo_Boston.Pages.wbfm_grupos_de_acceso" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"
        type="text/css" />
    <link rel="stylesheet" href="../fancybox/source/jquery.fancybox.css?v=2.1.4" type="text/css"
        media="screen" />
    <!-- Add jQuery library -->
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>    
    <!-- Add fancyBox -->
    <script type="text/javascript" src="../fancybox/source/jquery.fancybox.pack.js?v=2.1.4"></script>      
    <script type="text/javascript">
        var radioStatus;
        var status_btn_excepto;

        $(function () {
            $(document).tooltip();
        });
        $(document).ready(function () {
            radioStatus = false;
            DisableControls();

            $(':radio').click(function () {
                if (radioStatus)
                    return true;
                else
                    return false;
            });
        });

        function filtro(filtro, id_control_codigo, id_control_descripcion, id_responsable) {
            $(".div_mensaje_class").remove();
            $("[id*=btn_excepto]").hide();
            DisableControls();
            radioStatus = false;

            $.fancybox.open({
                href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable,
                type: 'iframe',
                margin: [50, 60, 50, 60], // Increase left/right
                padding: 5
            });
        }

        function cargar_grupos_de_acceso(codigo, descripcion, cod_compania, email_grupo, estado) {
            $(".div_mensaje_class").remove();
            $.fancybox.close();

            $("[id*=tb_grupo]").val(codigo);
            $("[id*=tb_description]").val(descripcion);
            $("[id*=tb_compania]").val(cod_compania);
            $("[id*=tb_email]").val(email_grupo);
           
            if (estado=="True") {
                $('input:radio[value=activado]')[0].checked = true;
            }
            else {
                $('input:radio[value=desactivado]')[0].checked = true;
            }
            DisableControls();
        }

        function EnableControls() {
            $(".div_mensaje_class").remove();
            if (CheckPopulateControls() == "True") {
                $("[id*=tb_email]").prop('readOnly', false);
                radioStatus = true;
                $("[id*=btn_excepto]").show(); 
                alert("Now you can edit email control and status!!!");
            }
        }

        function DisableControls() {
            $("[id*=tb_grupo]").prop('readOnly', true);
            $("[id*=tb_description]").prop('readOnly', true);
            $("[id*=tb_compania]").prop('readOnly', true);
            $("[id*=tb_email]").prop('readOnly', true);

        }

        function CheckPopulateControls() {
         if($("[id*=tb_grupo]").val() != "" &&
            $("[id*=tb_description]").val() != "" &&
            $("[id*=tb_compania]").val() != "" &&
            $("[id*=tb_email]").val() != "")
            return "True";
        else
            return "False";
        }

        $(':radio').click(function () {
            if (radioStatus)
                return true;
            else
                return false;
        });

    </script>      
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div id="div_mensaje" class="div_mensaje_class" runat="server">
    </div>

    <div id="filtros">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table class="tb_encabezado">
         <tr align="right">
         <td colspan="3">
       <input ID="img_btn_select" class="img_btn_select" type="button" value="" runat="server" onclick="javascript:filtro('grupos_de_acceso','txt_cod_solicitante','txt_nombre_solicitante', 'txt_responsable');" />

       <input ID="img_btn_edit" class="img_btn_edit" type="button" value="" runat="server" onclick="javascript:EnableControls();" />

       <input ID="img_btn_back" class="img_btn_back" type="button" value="" runat="server" onclick="window.location='/Pages/wbfrm_traslado_activo.aspx';" />
 <%-- <asp:ImageButton ID="img_btn_back" runat="server"  ImageUrl="~/Images/btn_back.png" 
            ToolTip="Back" />  --%>
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
                <asp:Button ID="btn_excepto" runat="server" Text="Excepto" CssClass = "btn_excepto_gda"
                    onclick="btn_excepto_Click" />
            </td>
           </tr>
        </table>       
    </div>   

</asp:Content>