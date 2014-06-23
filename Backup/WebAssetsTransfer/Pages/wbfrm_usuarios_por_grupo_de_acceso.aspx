<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true"
CodeBehind="wbfrm_usuarios_por_grupo_de_acceso.aspx.cs" Inherits=" Modulo_Boston.Pages.wbfrm_usuarios_por_grupo_de_acceso" %>

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
           // $("[id*=btn_excepto]").hide();
           // DisableControls();
           // radioStatus = false;
            $.fancybox.open({
                href: 'wbfrm_popup.aspx?tipo_filtro=' + filtro + '&id_control_codigo=' + id_control_codigo + '&id_control_descripcion=' + id_control_descripcion + '&id_responsable=' + id_responsable,
                type: 'iframe',
                margin: [50, 60, 50, 60], // Increase left/right
                padding: 5
            });
        }

        function cargar_usuarios_por_grupo_de_acceso(cod_compania, code_grupo, grupo, code_empleado, empleado, id_usuario, estado) {
            $.fancybox.close();

            $("[id*=tb_compania]").val(cod_compania);
            $("[id*=tb_code_grupo]").val(code_grupo);
            $("[id*=tb_grupo]").val(grupo);
            $("[id*=tb_empeado_code]").val(code_empleado);
            $("[id*=tb_empleado]").val(empleado);
            $("[id*=tb_id_usuario]").val(id_usuario);

            $("[id*=empleado_code_old]").val(code_empleado);
          
            if (estado == "True") {
                $('input:radio[value=activado]')[0].checked = true;
            }
            else {
                $('input:radio[value=desactivado]')[0].checked = true;
            }
            $(".div_mensaje_class").remove();
            $("[id*=btn_excepto]").hide();
            radioStatus = false;
            DisableControls();
        }

        function EnableControls() {
            if (CheckPopulateControls() == "True" &&  $("[id*=status_control]").val() != "Create") {               
                $("[id*=tb_compania]").prop('readOnly', false);
                $("[id*=tb_id_usuario]").prop('readOnly', false);
                
                $("[id*=btn_select_empleado]").removeAttr('disabled');
                $("[id*=btn_select_grupo]").removeAttr('disabled');

                radioStatus = true;

                $("[id*=status_control]").val("Edit");
                $("[id*=btn_excepto]").show();
                
                alert("Now you can edit!!!");
            }
        }

        function DisableControls() {
            $("[id*=tb_grupo]").prop('readOnly', true);
            $("[id*=tb_code_grupo]").prop('readOnly', true);
            $("[id*=tb_compania]").prop('readOnly', true);
            $("[id*=tb_id_usuario]").prop('readOnly', true);
            $("[id*=tb_empeado_code]").prop('readOnly', true);
            $("[id*=tb_empleado]").prop('readOnly', true);

            $("[id*=btn_select_empleado]").attr('disabled', 'disabled');
            $("[id*=btn_select_grupo]").attr('disabled', 'disabled');

        }

        function CheckPopulateControls() {
            if ($("[id*=tb_grupo]").val() != "" &&
            $("[id*=tb_code_grupo]").val() != "" &&
            $("[id*=tb_compania]").val() != "" &&
            $("[id*=tb_id_usuario]").val() != "" &&
            $("[id*=tb_empeado_code]").val() != "" &&
            $("[id*=tb_empleado]").val() != "" && 
            $("[id*=empleado_code_old]").val() != ""
            )
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

        function CreateNew() {
            $("[id*=tb_grupo]").val("");
            $("[id*=tb_code_grupo]").val("");
            $("[id*=tb_compania]").val("");
            $("[id*=tb_id_usuario]").val("");
            $("[id*=tb_empeado_code]").val("");
            $("[id*=tb_empleado]").val("");
            $("[id*=empleado_code_old]").val("");

            $("[id*=tb_compania]").prop('readOnly', false);
            $("[id*=tb_id_usuario]").prop('readOnly', false);
            $("[id*=btn_select_empleado]").removeAttr('disabled');
            $("[id*=btn_select_grupo]").removeAttr('disabled');

            radioStatus = true;

            $("[id*=status_control]").val("Create");
            $("[id*=btn_excepto]").show();

            alert("Now you can Create NEW!!!");
        }

        function cargar_grupo(id_grupo, grupo) {
            $.fancybox.close();
            $("[id*=tb_code_grupo]").val(id_grupo);
            $("[id*=tb_grupo]").val(grupo);
        }

        function cargar_empleado(id_empleado, empleado) {
            $.fancybox.close();
            $("[id*=tb_empeado_code]").val(id_empleado);
            $("[id*=tb_empleado]").val(empleado);
        }

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
       <asp:HiddenField ID="status_control" runat="server" />
       <asp:HiddenField ID="empleado_code_old" runat="server" />
        
       <input ID="img_btn_new" class="img_btn_new" type="button" value="" runat="server" onclick="javascript:CreateNew();"/>
       <input ID="img_btn_select" class="img_btn_select" type="button" value="" runat="server" onclick="javascript:filtro('usuarios_por_grupo_de_acceso','txt_cod_solicitante','txt_nombre_solicitante', 'txt_responsable');" />
       <input ID="img_btn_edit" class="img_btn_edit" type="button" value="" runat="server" onclick="javascript:EnableControls();" />
<%--       <input ID="img_btn_delete" class="img_btn_delete" type="button" value="" runat="server" onclick="img_btn_delete_Click" />--%>
       <asp:Button ID="img_btn_delete" CssClass="img_btn_delete"  runat="server" OnClientClick="javascript:alert('Are you sure for deleting this employee?');" OnClick="img_btn_delete_Click" />
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
                     <asp:TextBox ID="tb_code_grupo" runat="server" CssClass="txt_filtro_input"></asp:TextBox>  
                     &nbsp;&nbsp;   
                     <asp:TextBox ID="tb_grupo" runat="server" CssClass="txt_detalle"></asp:TextBox>                 
                    <input id="btn_select_grupo" runat="server" class="button_buscar" onclick="javascript:filtro('grupo_upgde','txt_cod_centro_costo','txt_des_centro_costo', 'txt_responsable');"
                        type="button" value="" /></td>
            </tr>
            <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lbl_empleado" runat="server" Text="Empleado"></asp:Label>
                </td>
                <td class="td_encabezado_col2">
                    <asp:TextBox ID="tb_empeado_code" runat="server" CssClass="txt_filtro_input"></asp:TextBox>   
                     &nbsp;&nbsp;   
                     <asp:TextBox ID="tb_empleado" runat="server" CssClass="txt_detalle"></asp:TextBox>                 
                    <input id="btn_select_empleado" runat="server" 
                       class="button_buscar" onclick="javascript:filtro('empleado_upgde','txt_cod_centro_costo','txt_des_centro_costo', 'txt_responsable');"
                        type="button" value="" /></td>
            </tr>
             <tr>
                <td class="td_encabezado_col1">
                    <asp:Label ID="lbl_id_usuario" runat="server" Text="Id Usuario"></asp:Label>
                </td>
                <td class="td_encabezado_txt">
                    <asp:TextBox ID="tb_id_usuario" runat="server" CssClass="txt_detalle"></asp:TextBox>
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
                <asp:Button ID="btn_excepto" runat="server" CssClass="btn_excepto_upgde" Text="Excepto" 
                    onclick="btn_excepto_Click" />
            </td>
           </tr>
        </table>       
    </div>   

</asp:Content>