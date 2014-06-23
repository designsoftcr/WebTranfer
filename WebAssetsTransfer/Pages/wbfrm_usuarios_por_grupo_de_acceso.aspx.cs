using BLL;
using Entidades;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using WebAssetsTransfer.Functions;

namespace Modulo_Boston.Pages
{
    public partial class wbfrm_usuarios_por_grupo_de_acceso : Page
    {

        protected HtmlGenericControl div_mensaje;
        protected ScriptManager ScriptManager1;
        protected Label lbl_compania;
        protected TextBox tb_compania;
        protected Label lbl_grupo;
        protected TextBox tb_grupo;
        protected Label lbl_empleado;
        protected TextBox tb_empeado_code;
        protected TextBox tb_empleado;        
        protected Label lbl_id_usuario;
        protected TextBox tb_id_usuario;
        protected Label lbl_estado;
        protected RadioButtonList rb_estado;
        protected Button btn_excepto;

        protected HtmlInputButton img_btn_new;
        protected Button img_btn_delete;
        protected TextBox tb_code_grupo;

        protected HtmlInputButton img_btn_select;
        protected HtmlInputButton img_btn_edit;
        protected HtmlInputButton img_btn_back;

       // protected HiddenField empleado_code_old;
        protected HiddenField status_control;

        protected HtmlInputButton btn_select_grupo;      
        protected HtmlInputButton btn_select_empleado;

        protected Label lblPropCompania;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {

                if (new cls_traslado().is_admin(this.Session["USUARIO"].ToString()))
                {

                }
                else
                {
                    base.Response.Clear();
                    base.Response.Redirect("~/Pages/wbfrm_traslado_activo.aspx", false);
                }
            }

        }

        #region Methods

        protected void btn_excepto_Click(object sender, EventArgs e)
        {
            if (CheckPopulateControls() && !string.IsNullOrEmpty(status_control.Value))
            {
                if (status_control.Value == "Edit" )//&&  !string.IsNullOrEmpty(this.empleado_code_old.Value))
                {
                    bool estado = false;
                    if (rb_estado.SelectedValue == "activado")
                        estado = true;

                     bool transaction = new cls_usuarios_por_grupo_de_acceso().update_cusuarios_por_grupo_de_acceso(this.tb_empeado_code.Text, Convert.ToInt32(this.tb_code_grupo.Text), this.tb_compania.Text, this.tb_id_usuario.Text, estado, this.tb_propcompania.Text);
                     if (transaction)
                         this.crear_mensajes("success", "Los cambios se actualizaron correctamente!");
                     else
                         this.crear_mensajes("error", "Los cambios no pudieron ser salvados!");
                    ClearControls();
                }
                else if (status_control.Value == "Create")
                {
                    bool estado = false;
                    if (rb_estado.SelectedValue == "activado")
                        estado = true;

                    bool transaction = new cls_usuarios_por_grupo_de_acceso().create_cusuarios_por_grupo_de_acceso(this.tb_empeado_code.Text, Convert.ToInt32(this.tb_code_grupo.Text), this.tb_compania.Text, this.tb_id_usuario.Text, estado, this.tb_propcompania.Text);
                    if (transaction)
                        this.crear_mensajes("success", "Empleado ha sido agregado!");
                    else
                        this.crear_mensajes("error", "No se agregan Empleado!");
                    ClearControls();
                }
               

            }
        }

        protected void img_btn_delete_Click(object sender, EventArgs e)
        {
            if (CheckPopulateControls())
            {
                bool transaction = new cls_usuarios_por_grupo_de_acceso().delete_cusuarios_por_grupo_de_acceso(this.tb_empeado_code.Text, Convert.ToInt32(this.tb_code_grupo.Text), this.tb_compania.Text, this.tb_propcompania.Text);
                if (transaction)
                    this.crear_mensajes("success", "Empleado se ha eliminado correctamente!");
                else
                    this.crear_mensajes("error", "Empleado no se ha eliminado!");

                ClearControls();

            }
        }     

        #endregion


        #region Functions

        public void crear_mensajes(string class_mensaje, string texto_mensaje)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDiv.Attributes["class"] = class_mensaje;
            createDiv.InnerHtml = texto_mensaje;
            this.div_mensaje.Controls.Add(createDiv);
        }

        private bool CheckPopulateControls()
        {

            if (!string.IsNullOrEmpty(this.tb_code_grupo.Text)
                && !string.IsNullOrEmpty(this.tb_compania.Text)
                && !string.IsNullOrEmpty(this.tb_id_usuario.Text)
                && !string.IsNullOrEmpty(this.tb_grupo.Text)
                && !string.IsNullOrEmpty(this.tb_empleado.Text)
                && !string.IsNullOrEmpty(this.tb_empeado_code.Text)
                && !string.IsNullOrEmpty(this.tb_propcompania.Text)
               )
                return true;

            return false;
        }

        private void ClearControls()
        {
            this.tb_code_grupo.Text = string.Empty;
            this.tb_compania.Text = string.Empty;
            this.tb_id_usuario.Text = string.Empty;
            this.tb_grupo.Text = string.Empty;
            this.tb_empleado.Text = string.Empty;
            this.tb_empeado_code.Text = string.Empty;
            //this.empleado_code_old.Value = string.Empty;
            this.status_control.Value = string.Empty;
            this.tb_propcompania.Text = string.Empty;
            this.rb_estado.ClearSelection();
        }

        protected void img_btn_back_new_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Pages/wbfrm_traslado_activo.aspx";
            base.Response.Redirect(url, false);
        }
        #endregion
    }
}