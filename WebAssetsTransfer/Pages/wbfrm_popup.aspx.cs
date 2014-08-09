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
                this.lb_titulo_filtro.Text = "Elige a un grupo de la lista";
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID GRUPO", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripción", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Código de Compañia", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_CIA_PRO", "Código de Compañia Propietaria", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("EMAIL_GRUPO", "Email de Grupo", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ESTADO", "Estado", true));
            }


            if (tipo_busqueda == "usuarios_por_grupo_de_acceso")
            {
                this.lb_titulo_filtro.Text = "Escoja un usuario de la lista";
                this.lb_filtrado_codigo.Text = "Code Empleado";
                this.lb_filtrado_descripcion.Text = "Nombre Empleado";
                
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_EMPLEADO", "Code Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOM_EMPLEADO", "Nombre Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID GRUPO", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripcion", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Code Compania", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA_PROP", "Code Compañía Propietaria", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("USUARIO", "Usuario", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ESTADO", "Estado", true));
            }

            if (tipo_busqueda == "grupo_upgde")
            {
                this.lb_titulo_filtro.Text = "Elige a un grupo de la lista";
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_GRUPO", "ID GRUPO", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripcion", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Code Compañía Propietaria", true));
            }

            if (tipo_busqueda == "empleado_upgde")
            {
                this.lb_titulo_filtro.Text = "Elige un empleado de la lista";
                this.lb_filtrado_codigo.Text = "Code Empleado";
                this.lb_filtrado_descripcion.Text = "Nombre Empleado";

                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_EMPLEADO", "Code Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOM_EMPLEADO", "Nombre Empleado", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOMBRE_USUARIO", "Usuario Empleado", true));
            }

            if (tipo_busqueda == "propcompania_upgde")
            {
                this.lb_titulo_filtro.Text = "Elige Compañía Propietaria de la lista";
                this.lb_filtrado_codigo.Text = "Code Compañía Propietaria";
                this.lb_filtrado_descripcion.Text = "Nombre Compañía Propietaria";

                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("COD_COMPANIA", "Code Compañía Propietaria", true));
                this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("NOM_COMPANIA", "Nombre Compañía Propietaria", true));
            }
            
            
            this.cargar_grid(tipo_busqueda, this.Session["FILTRO"].ToString());
        }

        private void cargar_grid(string tipo_busqueda, string codigo, string descripcion)
        {
            try
            {
                if (tipo_busqueda == "grupos_de_acceso")
                {
                    int lCodigo = 0;
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }

                    try
                    {
                        lCodigo = int.Parse(codigo);
                    }catch(Exception e)
                    {
                        System.Console.WriteLine(e);
                    }

                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_grupos_de_acceso(lCodigo, descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                if (tipo_busqueda == "centro_costo")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }
                    cls_popup centro_costo = new cls_popup();
                    if (Session["SES_COD_CIA_PRO"] == null || string.IsNullOrEmpty(Session["SES_COD_CIA_PRO"].ToString()))
                    {
                        Session["SES_COD_CIA_PRO"] = string.Empty;
                    }
                    if (Session["SES_Movimenent_Type"] == null || string.IsNullOrEmpty(Session["SES_Movimenent_Type"].ToString()))
                    {
                        Session["SES_Movimenent_Type"] = string.Empty;
                    }
                    string strMovementType = Session["SES_Movimenent_Type"].ToString().Trim();
                    string strCOD_CIA_PRO = Session["SES_COD_CIA_PRO"].ToString().Trim();
                    DataTable dt = new DataTable();
                    if ((strMovementType == "5" || strMovementType == "7") && !string.IsNullOrEmpty(strCOD_CIA_PRO))
                    {
                        dt = centro_costo.cargar_centros_costo_filtro(descripcion, strCOD_CIA_PRO, this.txt_filtro_codigo.Text, strMovementType);
                    }
                    else
                    {
                        dt = centro_costo.cargar_centros_costo_filtro(descripcion, this.txt_filtro_codigo.Text);
                    }
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                if (tipo_busqueda == "solicitante" || tipo_busqueda == "responsable")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }
                    cls_popup solicitante = new cls_popup();
                    System.Data.DataTable dt = solicitante.cargar_empleado_filtro(codigo, descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

                if (tipo_busqueda == "usuarios_por_grupo_de_acceso")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }

                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso(codigo,descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                if (tipo_busqueda == "grupo_upgde")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }

                    int lCodigo = 0;
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }

                    try
                    {
                        lCodigo = int.Parse(codigo);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e);
                    }

                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso_id_grupo(lCodigo, descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

                if (tipo_busqueda == "empleado_upgde")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_acceso_empleado(codigo,descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }

                if (tipo_busqueda == "propcompania_upgde")
                {
                    if (string.IsNullOrEmpty(descripcion))
                    {
                        descripcion = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_propetary_company(descripcion);
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
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
                    if (Session["SES_COD_CIA_PRO"] == null || string.IsNullOrEmpty(Session["SES_COD_CIA_PRO"].ToString())) {
                        Session["SES_COD_CIA_PRO"] = string.Empty;
                    }
                    if (Session["SES_Movimenent_Type"] == null || string.IsNullOrEmpty(Session["SES_Movimenent_Type"].ToString()))
                    {
                        Session["SES_Movimenent_Type"] = string.Empty;
                    }
                    string strMovementType = Session["SES_Movimenent_Type"].ToString().Trim();
                    string strCOD_CIA_PRO = Session["SES_COD_CIA_PRO"].ToString().Trim();
                    DataTable dt = new DataTable();
                    if ((strMovementType == "5" || strMovementType=="7") && !string.IsNullOrEmpty(strCOD_CIA_PRO))
                    {
                        dt = centro_costo.cargar_centros_costo_filtro(filtro, strCOD_CIA_PRO, this.txt_filtro_codigo.Text, strMovementType);
                    }
                    else
                    {
                        dt = centro_costo.cargar_centros_costo_filtro(filtro, this.txt_filtro_codigo.Text);
                    }
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

                if (tipo_busqueda == "propcompania_upgde")
                {
                    if (string.IsNullOrEmpty(filtro))
                    {
                        filtro = "todo";
                    }
                    cls_popup groupos = new cls_popup();
                    System.Data.DataTable dt = groupos.cargar_usuarios_por_grupo_de_propetary_company(filtro);
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
                this.Session["COD_PROP_COMPANIA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[4].Text.ToString();
                this.Session["EMAIL_GRUPO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[5].Text.ToString();
                this.Session["ESTADO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[6].Text.ToString(); 
            }
            //add by GPE 16.09.2013
            if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("usuarios_por_grupo_de_acceso"))
            {                              
                this.Session["ID_GRUPO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[3].Text.ToString();
                this.Session["DESCRIPCION_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[4].Text.ToString();
                this.Session["COD_COMPANIA_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[5].Text.ToString();
                this.Session["COD_PROP_COMPANIA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[6].Text.ToString();
                this.Session["USUARIO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[7].Text.ToString();
                this.Session["ESTADO_UGA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[8].Text.ToString();
            }
            //add by GPE 23.02.2014
            if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("grupo_upgde"))
            {
                this.Session["COD_PROP_COMPANIA"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[3].Text.ToString();
            }

            if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("empleado_upgde"))
            {
                this.Session["NOMBRE_USUARIO"] = this.gv_datos.Rows[System.Convert.ToInt32(this.gv_datos.SelectedIndex)].Cells[3].Text.ToString();
            }

            this.btn_aceptar_Click(sender, e);

        }
        protected void btn_realizar_filtrado_Click(object sender, System.EventArgs e)
        {
            string lcodigo = "";
            this.Session["FILTRO"] = this.txt_filtro_descripcion.Text;
            if (!string.IsNullOrEmpty(this.txt_filtro_codigo.Text))
                lcodigo = txt_filtro_codigo.Text;

            this.cargar_grid(this.Session["TIPO_BUSQUEDA"].ToString(),lcodigo, this.Session["FILTRO"].ToString());
            //this.cargar_grid(this.Session["TIPO_BUSQUEDA"].ToString(), this.Session["FILTRO"].ToString());
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
                    string cod_propcompania = this.Session["COD_PROP_COMPANIA"].ToString();
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
                        "','",
                        cod_propcompania,
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
                string COD_COMPANIA_PROP = this.Session["COD_PROP_COMPANIA"].ToString(); 
                 
                   
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
                        "','",
						COD_COMPANIA_PROP,
						"');"
					});

                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", script, true);
                }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("grupo_upgde"))
               {
                   string codpropcompania = this.Session["COD_PROP_COMPANIA"].ToString();
                   string grupo = string.Concat(new string[]
					{
						"parent.cargar_grupo('",						
						codigo,
						"','",
						descripcion,
                        "','",
						codpropcompania,
						"');"
					});
                   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", grupo, true);
               }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("empleado_upgde"))
               {
                   string nombre_usuario = this.Session["NOMBRE_USUARIO"].ToString();
                   string empleado = string.Concat(new string[]
					{
						"parent.cargar_empleado('",					
						codigo,
						"','",
						descripcion,
                        "','",
						nombre_usuario,
						"');"
					});
                   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", empleado, true);
               }

               if (this.Session["TIPO_BUSQUEDA"].ToString().Equals("propcompania_upgde"))
               {
                   string propcompania = string.Concat(new string[]
					{
						"parent.cargar_propcompania('",					
						codigo,
						"','",
						descripcion,
						"');"
					});
                   ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "registerevent", propcompania, true);
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
