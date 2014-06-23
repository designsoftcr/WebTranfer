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
    public partial class wbfm_grupos_de_acceso : Page
    {

        protected global::System.Web.UI.HtmlControls.HtmlGenericControl div_mensaje;
        protected global::System.Web.UI.ScriptManager ScriptManager1;     
        protected global::System.Web.UI.WebControls.Label lbl_compania;      
        protected global::System.Web.UI.WebControls.TextBox tb_compania;        
        protected global::System.Web.UI.WebControls.Label lbl_grupo;      
        protected global::System.Web.UI.WebControls.TextBox tb_grupo;
        protected global::System.Web.UI.WebControls.TextBox tb_description;    
        protected global::System.Web.UI.WebControls.Label lbl_email;       
        protected global::System.Web.UI.WebControls.TextBox tb_email;
        protected global::System.Web.UI.WebControls.Label lbl_estado;
        protected global::System.Web.UI.WebControls.RadioButtonList rb_estado;       
        protected global::System.Web.UI.WebControls.Button btn_excepto;

        protected HtmlInputButton img_btn_select;
        protected HtmlInputButton img_btn_edit;
        protected HtmlInputButton img_btn_back;
        

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
            if (CheckPopulateControls())
            {
                bool estado = false;
                if(rb_estado.SelectedValue == "activado")
                    estado = true;

                bool transaction = new cls_grupos_de_acceso().update_grupos_de_acceso(Convert.ToInt32(this.tb_grupo.Text), this.tb_email.Text, estado,this.tb_propcompania.Text);
                if(transaction)
                    this.crear_mensajes("success", "Los cambios se actualizaron correctamente!");
                else
                    this.crear_mensajes("error", "Los cambios no pudieron ser salvados!");

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

             if(!string.IsNullOrEmpty(this.tb_description.Text) 
                 && !string.IsNullOrEmpty(this.tb_compania.Text)
                 && !string.IsNullOrEmpty(this.tb_email.Text)
                 && !string.IsNullOrEmpty(this.tb_grupo.Text)
                 && !string.IsNullOrEmpty(this.tb_propcompania.Text))
                 return true;

            return false;
         }

        private void ClearControls()
        {
           this.tb_description.Text = string.Empty;
           this.tb_compania.Text = string.Empty;
           this.tb_email.Text = string.Empty;
           this.tb_grupo.Text = string.Empty;
           this.tb_propcompania.Text = string.Empty;
           this.rb_estado.ClearSelection();
        }

        protected void img_btn_back_Click(object sender, EventArgs e)
        {
            string url = "~/Pages/wbrfm_solicitudes_pendientes.aspx";
            base.Response.Redirect(url, false);
        }

        protected void img_btn_back_new_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Pages/wbfrm_traslado_activo.aspx";
            base.Response.Redirect(url, false);
        }

    #endregion



      


    }
}