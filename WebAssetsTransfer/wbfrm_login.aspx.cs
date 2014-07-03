using CapaLog;
using System;
using System.Web;
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
            if (!IsPostBack) 
            {
                Session.Clear();
                getCookies();
            }
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
                        if (this.chbRememberMe.Checked == true)
                        {
                            SetCookies(this.txt_usuario.Text, this.txt_contrasena.Text);
                        }
                        else
                        {
                            RemoveCookies();
                        }
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
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                //GPE 1/26/2014 Change message to be more user friendly
                //this.crear_mensajes("error", ex.ToString());
                this.crear_mensajes("error", "Usuario o Clave Inválido");
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

        private void SetCookies(string strUserName, string strPassword)
        {
            try
            {

                HttpCookie objHC = new HttpCookie("CooKiesUserName");
                objHC.Value = strUserName;
                objHC.Expires = DateTime.MaxValue;
                Response.Cookies.Add(objHC);
                objHC = new HttpCookie("CooKiesPassword");
                objHC.Expires = DateTime.MaxValue;
                objHC.Value = strPassword;
                Response.Cookies.Add(objHC);
                objHC = new HttpCookie("CooKiesCheck");
                objHC.Expires = DateTime.MaxValue;
                objHC.Value = "1";
                Response.Cookies.Add(objHC);
            }
            catch (Exception ex)
            {
                this.crear_mensajes("error", "Error en los cookies");
            }
        }

        private void getCookies()
        {
            try
            {
                this.txt_usuario.Text = string.Empty;
                this.txt_contrasena.Text = string.Empty;
                if (Request.Cookies["CooKiesCheck"] == null)
                {
                    this.txt_contrasena.Attributes["value"] = string.Empty;
                    return;
                }
                if (Request.Cookies["CooKiesCheck"].Value != string.Empty)
                {
                    if (Request.Cookies["CooKiesCheck"].Value == "1")
                    {
                        this.chbRememberMe.Checked = true;
                    }
                    else
                    {
                        this.chbRememberMe.Checked = false;
                        return;
                    }
                }
                if (Request.Cookies["CooKiesUserName"] == null) return;
                if (Request.Cookies["CooKiesUserName"].Value != string.Empty)
                {
                    this.txt_usuario.Text = Request.Cookies["CooKiesUserName"].Value;
                    this.lblSessionUserName.Text = string.Format("<b>Bienvenido</b>, {0}!", this.txt_usuario.Text);
                }
                if (Request.Cookies["CooKiesPassword"] == null) return;
                if (Request.Cookies["CooKiesPassword"].Value != string.Empty)
                {
                    this.txt_contrasena.Attributes["value"] = Request.Cookies["CooKiesPassword"].Value;
                    this.txt_contrasena.Text = Request.Cookies["CooKiesPassword"].Value;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "setPV", "setPValue('" + Request.Cookies["CooKiesPassword"].Value + "');", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RemoveCookies()
        {
            try
            {
                if (Request.Cookies["CooKiesUserName"] != null)
                {
                    Response.Cookies["CooKiesUserName"].Value = string.Empty;
                    Request.Cookies["CooKiesUserName"].Expires = DateTime.Now;
                    Request.Cookies.Remove("CooKiesUserName");
                }
                if (Request.Cookies["CooKiesPassword"] != null)
                {
                    Response.Cookies["CooKiesPassword"].Value = string.Empty;
                    Response.Cookies["CooKiesPassword"].Expires = DateTime.Now;
                    Response.Cookies["CooKiesPassword"].Value = "";
                    Request.Cookies.Remove("CooKiesPassword");
                }
                if (Request.Cookies["CooKiesCheck"] != null)
                {
                    Response.Cookies["CooKiesCheck"].Value = string.Empty;
                    Response.Cookies["CooKiesCheck"].Expires = DateTime.Now;
                    Request.Cookies.Remove("CooKiesCheck");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
