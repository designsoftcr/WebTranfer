using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAssetsTransfer.Functions;
namespace WebAssetsTransfer
{
    public partial class wbfrm_login : Page
    {
        protected HtmlForm form1;
        protected HtmlGenericControl seccion_a;
        protected Label lbl_etiqueta_usuario;
        protected TextBox txt_usuario;
        protected Label lbl_etiqueta_contrasena;
        protected TextBox txt_contrasena;
        protected Button btn_login;
        protected HtmlGenericControl div_mensaje;
        protected void Page_Load(object sender, System.EventArgs e)
        {          
        }
        private bool validar()
        {
            bool result;
            if (string.IsNullOrEmpty(this.txt_usuario.Text))
            {
                this.crear_mensajes("error", "El campo Usuario es Obligatorio");
                this.txt_usuario.Focus();
                result = false;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txt_contrasena.Text))
                {
                    this.crear_mensajes("error", "El campo Contraseña es Obligatorio");
                    this.txt_contrasena.Focus();
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
        protected void btn_login_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.validar())
                {
                    //LDAP authentication or SQL authentication
                    bool authenticate;

                    if (cls_configuracion.Authentication)
                        authenticate = new cls_sql_autentication().sql_autentificar(this.txt_usuario.Text, this.txt_contrasena.Text);
                    else
                        authenticate = new cls_active_directoy().autentificar(this.txt_usuario.Text, this.txt_contrasena.Text);
                             
                    if (authenticate)
                    {
                        this.Session["USUARIO"] = this.txt_usuario.Text;
                        if (!string.IsNullOrEmpty(base.Request.QueryString["codigo_compania"]) && !string.IsNullOrEmpty(base.Request.QueryString["id_movimiento"]))
                        {
                            base.Response.Clear();
                            string url = "~/Pages/wbfrm_traslado_activo.aspx?codigo_compania=" + base.Request.QueryString["codigo_compania"] + "&id_movimiento=" + base.Request.QueryString["id_movimiento"];
                            base.Response.Redirect(url, false);
                            this.Session["USUARIO"] = this.txt_usuario.Text;
                        }
                        else
                        {
                            base.Response.Clear();
                            base.Response.Redirect("~/Pages/wbfrm_traslado_activo.aspx", false);
                        }
                    }
                    else
                    {
                        this.crear_mensajes("error", "El usuario o Contraseña son incorrectos");
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        public void crear_mensajes(string class_mensaje, string texto_mensaje)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDiv.Attributes["class"] = class_mensaje;
            createDiv.InnerHtml = texto_mensaje;
            this.div_mensaje.Controls.Add(createDiv);
        }
    }
}
