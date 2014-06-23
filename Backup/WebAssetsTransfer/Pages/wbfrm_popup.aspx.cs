using BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAssetsTransfer.Functions;
namespace WebAssetsTransfer.Pages
{
    //GPE add partial
    public partial class wbfrm_popup : Page
    {
        protected HtmlForm form1;
        protected ScriptManager ScriptManager1;
        protected UpdatePanel UpdatePanel1;
        protected Label lb_titulo_filtro;
        protected Label lb_filtrado_codigo;
        protected TextBox txt_filtro_codigo;
        protected Label lb_filtrado_descripcion;
        protected TextBox txt_filtro_descripcion;
        protected Button btn_realizar_filtrado;
        protected Button btn_limpiar;
        protected Button Aceptar;
        protected GridView gv_datos;
        protected HtmlGenericControl div_mensaje;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (string.IsNullOrEmpty(base.Request.QueryString["tipo_filtro"]) || string.IsNullOrEmpty(base.Request.QueryString["id_control_codigo"]) || string.IsNullOrEmpty(base.Request.QueryString["id_control_descripcion"]))
                {
                    base.Response.Redirect("~../wbfrm_traslado_activo.aspx");
                }
                else
                {
                    this.Session["TIPO_BUSQUEDA"] = base.Request.QueryString["tipo_filtro"];
                    this.Session["ID_CONTROL_CODIGO"] = base.Request.QueryString["id_control_codigo"];
                    this.Session["ID_CONTROL_DESCRIPCION"] = base.Request.QueryString["id_control_descripcion"];
                    if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("centro_costo"))
                    {
                        this.Session["RESPONSABLE"] = base.Request.QueryString["id_responsable"];
                    }
                    this.Session["DESCRIPCION"] = null;
                    this.Session["CODIGO"] = null;
                    this.Session["FILTRO"] = "todo";
                    this.crear_columnas_grid(this.Session["TIPO_BUSQUEDA"].ToString());
                }
            }
        }
        private void crear_columnas_grid(string tipo_busqueda)
        {
            if (tipo_busqueda == "centro_costo")
            {
                this.lb_titulo_filtro.Text = "Busqueda de Centro de Costo";
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_CENTRO_COSTO", "Código Centro Costo", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("CENTRO_COSTO", "Descripción", true));
            }
            if (tipo_busqueda == "solicitante" || tipo_busqueda == "responsable")
            {
                if (tipo_busqueda != null)
                {
                    if (!(tipo_busqueda == "solicitante"))
                    {
                        if (tipo_busqueda == "responsable")
                        {
                            this.lb_titulo_filtro.Text = "Busqueda de Responsable Destino";
                        }
                    }
                    else
                    {
                        this.lb_titulo_filtro.Text = "Busqueda de Solicitante";
                    }
                }
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_EMPLEADO", "Código", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOMBRE_EMPLEADO", "Nombre", true));
            }

            if (tipo_busqueda == "grupos_de_acceso")
            {
                this.lb_titulo_filtro.Text = "Pick a group from list";
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID of Group", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripción", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Code of Compania", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("EMAIL_GRUPO", "Email de Grupo", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ESTADO", "Estado", true));
            }


            if (tipo_busqueda == "usuarios_por_grupo_de_acceso")
            {
                this.lb_titulo_filtro.Text = "Pick a user from list";
                this.lb_filtrado_codigo.Text = "Empleado Code";
                this.lb_filtrado_descripcion.Text = "Empleado Name";
                
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_EMPLEADO", "Code Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOM_EMPLEADO", "Nom Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID of Group", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Group Descrtiption", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Code of Compania", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("USUARIO", "Usuario", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ESTADO", "Estado", true));
            }

            if (tipo_busqueda == "grupo_upgde")
            {
                this.lb_titulo_filtro.Text = "Pick a group from list";
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID of Group", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "DESCRIPCION", true));
            }

            if (tipo_busqueda == "empleado_upgde")
            {
                this.lb_titulo_filtro.Text = "Pick a employee from list";
                this.lb_filtrado_codigo.Text = "Empleado Code";
                this.lb_filtrado_descripcion.Text = "Empleado Name";

                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_EMPLEADO", "Code Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOM_EMPLEADO", "Nom Empleado", true));
            }
            
            this.cargar_grid(tipo_busqueda, this.Session["FILTRO"].ToString());
        }
        private void cargar_grid(string tipo_busqueda, string filtro)
        {
            try
            {
                if (tipo_busqueda == "centro_costo")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup centro_costo = new cls_popup();
                    System.Data.DataTable dt = centro_costo.cargar_centros_costo_filtro(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                if (tipo_busqueda == "solicitante" || tipo_busqueda == "responsable")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup solicitante = new cls_popup();
                    System.Data.DataTable dt = solicitante.cargar_empleado_filtro(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                
                if (tipo_busqueda == "grupos_de_acceso")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_grupos_de_acceso(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

                if (tipo_busqueda == "usuarios_por_grupo_de_acceso")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                if (tipo_busqueda == "grupo_upgde")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso_id_grupo(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

                if (tipo_busqueda == "empleado_upgde")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso_empleado(filtro);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void gv_datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.gv_datos.PageIndex = e.NewPageIndex;
                this.cargar_grid(this.Session["TIPO_BUSQUEDA"].ToString(), this.Session["FILTRO"].ToString());
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void gv_datos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Session["CODIGO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[1].Text.ToString();
            this.Session["DESCRIPCION"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[2].Text.ToString();
            this.txt_filtro_descripcion.Text = this.Session["DESCRIPCION"].ToString();
            this.txt_filtro_codigo.Text = this.Session["CODIGO"].ToString();
            //add by GPE 14.09.2013
            if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("grupos_de_acceso"))
            {
                this.Session["COD_COMPANIA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[3].Text.ToString();
                this.Session["EMAIL_GRUPO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[4].Text.ToString();
                this.Session["ESTADO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[5].Text.ToString(); 
            }
            //add by GPE 16.09.2013
            if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("usuarios_por_grupo_de_acceso"))
            {                              
                this.Session["ID_GRUPO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[3].Text.ToString();
                this.Session["DESCRIPCION_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[4].Text.ToString();
                this.Session["COD_COMPANIA_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[5].Text.ToString();
                this.Session["USUARIO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[6].Text.ToString();
                this.Session["ESTADO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[7].Text.ToString();
            }



        }
        protected void btn_realizar_filtrado_Click(object sender, System.EventArgs e)
        {
            this.Session["FILTRO"] = this.txt_filtro_descripcion.Text;
            this.cargar_grid(this.Session["TIPO_BUSQUEDA"].ToString(), this.Session["FILTRO"].ToString());
        }
        protected void btn_limpiar_Click(object sender, System.EventArgs e)
        {
            this.Session["FILTRO"] = "todo";
            this.txt_filtro_codigo.Text = string.Empty;
            this.txt_filtro_descripcion.Text = string.Empty;
            this.cargar_grid(this.Session["TIPO_BUSQUEDA"].ToString(), this.Session["FILTRO"].ToString());
        }
        protected void btn_aceptar_Click(object sender, System.EventArgs e)
        {
            if (this.Session["DESCRIPCION"] == null || this.Session["CODIGO"] == null)
            {
                string script = "alert('Seleccione un registro de la lista, o Presione el boton Cancelar');";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", script, true);
            }
            else
            {
                string descripcion = this.Session["DESCRIPCION"].ToString();
                string codigo = this.Session["CODIGO"].ToString();
                string id_control_descripcion = this.Session["ID_CONTROL_DESCRIPCION"].ToString();
                string id_control_codigo = this.Session["ID_CONTROL_CODIGO"].ToString();


                if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("solicitante") || this.Session["TIPO_BUSQUEDA"].ToString().Equals("responsable"))
                {
                    string scriptSolicitante = string.Concat(new string[]
					{
						"parent.cargar_solicitante('",
						id_control_codigo,
						"','",
						id_control_descripcion,
						"','",
						codigo,
						"','",
						descripcion,
						"');"
					});
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", scriptSolicitante, true);
                }

                if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("centro_costo"))
                {
                    string id_responsable = this.Session["RESPONSABLE"].ToString();
                    string responsable = new cls_traslado().nombre_responsable(codigo);
                    string script = string.Concat(new string[]
					{
						"parent.cargar_controles('",
						id_control_codigo,
						"','",
						id_control_descripcion,
						"','",
						id_responsable,
						"','",
						codigo,
						"','",
						descripcion,
						"','",
						responsable,
						"');"
					});
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", script, true);
                }

                if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("grupos_de_acceso"))
                {
                    string cod_compania = this.Session["COD_COMPANIA"].ToString();
                    string email_grupo = this.Session["EMAIL_GRUPO"].ToString();
                    string estado = this.Session["ESTADO"].ToString();
                    string script = string.Concat(new string[]
					{
						"parent.cargar_grupos_de_acceso('",
						codigo,
						"','",
						descripcion,
						"','",
						cod_compania,
						"','",
						email_grupo,
						"','",
						estado,
						"');"
					});

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", script, true);
                }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("usuarios_por_grupo_de_acceso"))
                {     
                string ID_GRUPO_UGA = this.Session["ID_GRUPO_UGA"].ToString();
                string DESCRIPCION_UGA = this.Session["DESCRIPCION_UGA"].ToString();
                string COD_COMPANIA_UGA = this.Session["COD_COMPANIA_UGA"].ToString();
                string USUARIO_UGA = this.Session["USUARIO_UGA"].ToString();
                string ESTADO_UGA = this.Session["ESTADO_UGA"].ToString();
                 
                   
                   string script = string.Concat(new string[]
					{
						"parent.cargar_usuarios_por_grupo_de_acceso('",
						COD_COMPANIA_UGA,
						"','",
						ID_GRUPO_UGA,
						"','",
						DESCRIPCION_UGA,
						"','",
						codigo,
						"','",
						descripcion,
                        "','",
                        USUARIO_UGA,
						"','",
						ESTADO_UGA,
						"');"
					});

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", script, true);
                }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("grupo_upgde"))
               {
                   string grupo = string.Concat(new string[]
					{
						"parent.cargar_grupo('",						
						codigo,
						"','",
						descripcion,
						"');"
					});
                   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", grupo, true);
               }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("empleado_upgde"))
               {
                   string empleado = string.Concat(new string[]
					{
						"parent.cargar_empleado('",					
						codigo,
						"','",
						descripcion,
						"');"
					});
                   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", empleado, true);
               }


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
