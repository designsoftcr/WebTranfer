using BLL;
using CapaLog;
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
using WebAssetsTransfer.Helper;

namespace Modulo_Boston.Pages
{
    //GPE added partial
    public partial class wbfrm_donacion_activo : Page
    {
        #region ""VARIABLE DECLARATION"

        protected HtmlGenericControl div_mensaje;
        protected ImageButton img_btn_nuevo;
        protected ScriptManager ScriptManager1;
        protected Label lb_centro_costo;
        protected Button btn_cargar_centro_costo;
        protected TextBox txt_cod_centro_costo;
        protected TextBox txt_des_centro_costo;
        //protected HtmlInputButton btn_buscar_centro_costo;
        protected Label lb_responsable;
        protected TextBox txt_responsable;
        protected Label lb_id_solicitante;
        protected TextBox txt_cod_solicitante;
        protected Button btn_cargar_solicitante;
        protected TextBox txt_nombre_solicitante;
        //commented by GPE 12.02.2013 new stuff # 10
        //protected HtmlInputButton btn_buscar_solicitante;
        protected Label lb_fecha;
        protected TextBox txt_fecha;
        protected Label lb_solicitud;
        protected TextBox txt_num_solicitud;
        protected Label lb_tipo_movimiento;
        protected DropDownList ddl_tipo_movimiento;
        protected Label Label1;
        protected TextBox TextBox1;
        protected Button btn_aplicar_solicitud;
        protected Button btn_aceptar;
        protected Button btn_cancelar;
        protected HtmlInputButton btn_abrir_bitacora;
        protected HtmlInputButton btn_abrir_movimiento_maestro;
        protected Label lb_observaciones_solicitud;
        protected TextBox txt_observaciones_solicitud;
        protected HtmlGenericControl seccion_donacion;
        protected Label lb_fieldset_donacion;
        protected Label lb_observaciones;
        protected TextBox txt_observaciones_donacion;
        protected HtmlGenericControl seccion_area_destino;
        protected Label lb_fieldset_area_destino;
        protected Label lb_centro_costo_destino;
        protected TextBox txt_codigo_centro_costo_destino;
        protected Button btn_cargar_centro_costo_destino;
        protected TextBox txt_nombre_centro_costo_destino;
        protected HtmlInputButton btn_buscar_centro_costo_destino;
        protected Label lb_responsable_destino;
        protected TextBox txt_cargo_responsable_costo_destino;
        protected Label lb_id_responsable_destino;
        protected TextBox txt_cod_responsable_destino;
        protected Button btn_cargar_responsable_destino;
        protected TextBox txt_nombre_responsable_destino;
        protected HtmlInputButton btn_buscar_resposable_destino;
        protected UpdatePanel UpdatePanel1;
        protected Label lb_localizacion_destino;
        protected Label lb_seccion_destino;
        protected Label lb_ubicacion_destino;
        protected Label lb_planta_destino;
        protected DropDownList ddl_localizacion_destino;
        protected TextBox txt_localizacion_solicitud;
        protected DropDownList ddl_seccion_destino;
        protected TextBox txt_seccion_solicitud;
        protected DropDownList ddl_ubicacion_destino;
        protected TextBox txt_ubicacion_solicitud;
        protected DropDownList ddl_planta_destino;
        protected HtmlGenericControl seccion_denuncia;
        protected Label lb_fieldset_denuncia;
        protected Label lb_numero_proceso;
        protected TextBox txt_num_proceso;
        protected Label lb_observaciones_denuncia;
        protected TextBox txt_observaciones_denuncia;
        protected HtmlGenericControl seccion_calibracion_activos;
        protected Label lb_fieldset_calibracion_mantenimiento;
        protected Label lb_proveedor;
        protected TextBox txt_proveedor;
        protected Label lb_telefono;
        protected TextBox txt_telefono_proveedor;
        protected Label lb_fecha_aprox_reingreso;
        protected TextBox txt_fecha_aprox_reingreso;
        protected Label lb_cedula_juridica;
        protected TextBox txt_cedula_juridica;
        protected Label lb_contacto;
        protected TextBox txt_nombre_contacto;
        protected Label lb_direccion_exacta_proveedor;
        protected TextBox txt_direccion_proveedor;
        protected Label lb_observaciones_calibracion;
        protected TextBox txt_observaciones_calibracion;
        protected HtmlGenericControl seccion_destruccion;
        protected Label lb_destruccion_activos;
        protected Label lb_observacion_destruccion;
        protected TextBox txt_observaciones_destruccion;
        protected HtmlGenericControl containt_grid;
        protected GridView gv_activos;

        protected ImageButton btn_grupos_de_acceso;
        protected ImageButton btn_usuarios_por_grupo_de_acceso;

        //GPE 12/07/2013 WAT_Document new stuff # 14
        protected HtmlGenericControl div_observaciones_obligatory;

        #endregion

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.cargar_valores_defecto();
                if (!string.IsNullOrEmpty(base.Request.QueryString["codigo_compania"]) && !string.IsNullOrEmpty(base.Request.QueryString["id_movimiento"]))
                {
                    this.gv_activos.Enabled = false;
                    this.Session["CODIGO_COMPANIA"] = base.Request.QueryString["codigo_compania"];
                    this.Session["ID_MOVIMIENTO"] = System.Convert.ToInt32(base.Request.QueryString["id_movimiento"]);

                    //Aquí se debe validar a ver si es el usuario con permisos de aprobacion del paso actual y no por si el usuario ya 
                    //hizo el paso o no
                    if (this.estado_link(System.Convert.ToInt32(base.Request.QueryString["id_movimiento"]), System.Convert.ToString(this.Session["USUARIO"])))
                    {
                        this.estado_controles(this.Page, false);
                        this.estado_botones(false, true);
                        this.cargar_controles(base.Request.QueryString["codigo_compania"].ToString(), System.Convert.ToInt32(base.Request.QueryString["id_movimiento"]));
                        /*Se añadió la carga del solicitante aquí*/
                        cargarSolicitante();
                    }
                    else
                    {
                        this.estado_botones(false, false);
                        this.crear_mensajes("info", "Vinculo ya utilizado, revise el Historico");
                    }
                }
                else
                {
                    this.Session["ID_MOVIMIENTO"] = null;
                    //this.Session["CODIGO_COMPANIA"] = null;
                    this.txt_fecha.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                    this.Session["CODIGO"] = null;
                    this.estado_controles(this.Page, true);

                    /*Se añadió aqui la carga*/
                    cargarSolicitante();

                }
                if (new cls_traslado().grupo_usuario(2, this.Session["CODIGO_COMPANIA"].ToString(), this.Session["USUARIO"].ToString()))
                {
                    this.btn_abrir_movimiento_maestro.Visible = true;
                }

                if (new cls_traslado().is_admin(this.Session["USUARIO"].ToString()))
                {
                    this.btn_grupos_de_acceso.Visible = true;
                    this.btn_usuarios_por_grupo_de_acceso.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(this.txt_cod_centro_costo.Text))
            {
                //GPE 4/3/2014 get mail for calibracion
                // update By Felix 
                if (ddl_tipo_movimiento.SelectedValue == "3")
                {
                    this.txt_responsable.Text = "Aprueba Departamento de Calibraciones";
                    // this.txt_responsable.Text = new cls_traslado().nombre_responsable_calibracion(this.txt_cod_centro_costo.Text);
                }
                else
                {
                    this.txt_responsable.Text = new cls_traslado().nombre_responsable(this.txt_cod_centro_costo.Text);
                }
                if (!string.IsNullOrEmpty(this.txt_codigo_centro_costo_destino.Text))
                {
                    //GPE 4/8/2014 WAT-04052014 Point 6
                    //this.txt_cargo_responsable_costo_destino.Text = new cls_traslado().nombre_responsable(this.txt_codigo_centro_costo_destino.Text);
                    this.txt_cargo_responsable_costo_destino.Text = new cls_traslado().nombre_responsable(this.txt_codigo_centro_costo_destino.Text, true);
                }
                if (this.Session["CODIGO_COMPANIA"] == null)
                {
                    base.Response.Redirect("../wbfrm_login.aspx");
                }

                centro_costo_status(false);

                //add by GPE 12.02.2013 new stuff # 10
                if (this.Session["USUARIO"] == null)
                {
                    base.Response.Redirect("../wbfrm_login.aspx");
                }
                else
                {
                    /*Aqui iba el codigo de carga del usuario*/
                }

                TextBox tb = GetPostBackControlId(base.Page);
                if (tb != null)
                {
                    if (!string.IsNullOrEmpty(tb.Text))
                        try
                        {
                            consultar_activo(Convert.ToInt32(tb.AccessKey));
                        }
                        catch (Exception ex)
                        {
                            this.crear_mensajes("error", ex.ToString());
                        }
                }
            }
        }

        private void cargarSolicitante() 
        {
            DataTable dt = null;
            if (this.Session["ID_MOVIMIENTO"] != null && this.Session["CODIGO_COMPANIA"] != null)
            {
                dt = new cls_traslado().cargar_solicitante((int)this.Session["ID_MOVIMIENTO"]);//this.Session["USUARIO"].ToString());
            }
            else
            {
            dt = new cls_traslado().cargar_solicitante(this.Session["USUARIO"].ToString());
            }


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    this.txt_cod_solicitante.Text = dt.Rows[0]["COD_EMPLEADO"].ToString();
                    this.Session["NOMBRE_EMPLEADO"] = this.txt_nombre_solicitante.Text
                        = dt.Rows[0]["NOM_EMPLEADO"].ToString();

                    id_solicitante_status(false);
                }
            }
        }

        private void cargar_valores_defecto()
        {
            this.Session["TIPO_MOVIMIENTO"] = this.ddl_tipo_movimiento.SelectedValue;
            this.Session["TABLA_ACTIVO"] = this.ReturnEmptyDataTable();
            this.Session["DESCRIPCION"] = null;
            this.Session["CODIGO_COMPANIA"] = 2380;
            this.seccion_visible(false);
            this.cargar_combo_tipo_movimiento();
            this.cargar_combo_localizacion();
            this.cargar_activos();
        }
        protected bool estado_link(int id_movimiento, string usuario)
        {
            cls_bitacora datos = new cls_bitacora();
            System.Data.DataTable dt = datos.cargar_bitacora_por_usuario(id_movimiento, usuario);
            return dt.Rows.Count <= 0;
        }
        protected void cargar_controles(string codigo_compania, int id_movimiento)
        {
            try
            {
                cls_traslado datos = new cls_traslado();
                System.Data.DataTable dt = datos.cargar_datos_generales(codigo_compania, id_movimiento);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["ESTADO"].ToString() == "P")
                    {
                        this.Session["ID_PASO_APROBACION_ACTUAL"] = dt.Rows[0]["ID_PASO_APROBACION_ACTUAL"].ToString();
                        this.txt_cod_centro_costo.Text = dt.Rows[0]["CODIGO_CENTRO_COSTO"].ToString();
                        this.txt_des_centro_costo.Text = dt.Rows[0]["DESCRIPCION_CENTRO_COSTO"].ToString();
                        this.txt_cod_solicitante.Text = dt.Rows[0]["CODIGO_SOLICITANTE"].ToString();
                        this.txt_nombre_solicitante.Text = dt.Rows[0]["NOMBRE_SOLICITANTE"].ToString();
                        this.txt_num_solicitud.Text = dt.Rows[0]["NUMERO_SOLICITUD"].ToString();
                        this.txt_fecha.Text = dt.Rows[0]["FECHA"].ToString();
                           //GPE 4/3/2014 get mail for calibracion
                       if(ddl_tipo_movimiento.SelectedValue == "3")
                           this.txt_responsable.Text = new cls_traslado().nombre_responsable_calibracion(this.txt_cod_centro_costo.Text);
                       else
                        this.txt_responsable.Text = new cls_traslado().nombre_responsable(this.txt_cod_centro_costo.Text);
                        this.ddl_tipo_movimiento.SelectedIndex = System.Convert.ToInt32(dt.Rows[0]["ID_TIPO_MOVIMIENTO"]);
                        this.Session["TIPO_MOVIMIENTO_ACEPTACION"] = System.Convert.ToInt32(dt.Rows[0]["ID_TIPO_MOVIMIENTO"]);
                        int id_tipo_movimiento = System.Convert.ToInt32(dt.Rows[0]["ID_TIPO_MOVIMIENTO"]);
                        string cadena = dt.Rows[0]["DETALLE"].ToString();
                        string xmlcadena = "<Datos>" + cadena + "</Datos>";
                        System.Xml.Linq.XElement xmldoc = System.Xml.Linq.XElement.Parse(xmlcadena);
                        switch (id_tipo_movimiento)
                        {
                            case 1:
                                {
                                    System.Xml.Linq.XElement xml_donacion = (
                                        from item in xmldoc.XPathSelectElements("./Donacion")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_observaciones_donacion.Text = System.Convert.ToString(xml_donacion.Element("Observaciones").Value);
                                    break;
                                }
                            case 2:
                                {
                                    System.Xml.Linq.XElement xml_destruccion = (
                                        from item in xmldoc.XPathSelectElements("./Destruccion")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_observaciones_destruccion.Text = System.Convert.ToString(xml_destruccion.Element("Observaciones").Value);
                                    break;
                                }
                            case 3:
                                {
                                    System.Xml.Linq.XElement xml_calibracion = (
                                        from item in xmldoc.XPathSelectElements("./Calibracion")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_proveedor.Text = System.Convert.ToString(xml_calibracion.Element("Proveedor").Value);
                                    this.txt_cedula_juridica.Text = System.Convert.ToString(xml_calibracion.Element("CedulaJuridica").Value);
                                    this.txt_telefono_proveedor.Text = System.Convert.ToString(xml_calibracion.Element("TelefonoProveedor").Value);
                                    this.txt_fecha_aprox_reingreso.Text = System.Convert.ToString(xml_calibracion.Element("FechaAproximadaDeReingreso").Value);
                                    this.txt_nombre_contacto.Text = System.Convert.ToString(xml_calibracion.Element("NombreContacto").Value);
                                    this.txt_direccion_proveedor.Text = System.Convert.ToString(xml_calibracion.Element("DireccionProveedor").Value);
                                    this.txt_observaciones_calibracion.Text = System.Convert.ToString(xml_calibracion.Element("Observaciones").Value);
                                    break;
                                }
                            case 4:
                                {
                                    System.Xml.Linq.XElement xml_mantenimiento = (
                                        from item in xmldoc.XPathSelectElements("./Mantenimiento")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_observaciones_calibracion.Text = System.Convert.ToString(xml_mantenimiento.Element("Observaciones").Value);
                                    this.txt_proveedor.Text = System.Convert.ToString(xml_mantenimiento.Element("Proveedor").Value);
                                    this.txt_cedula_juridica.Text = System.Convert.ToString(xml_mantenimiento.Element("CedulaJuridica").Value);
                                    this.txt_telefono_proveedor.Text = System.Convert.ToString(xml_mantenimiento.Element("TelefonoProveedor").Value);
                                    this.txt_fecha_aprox_reingreso.Text = System.Convert.ToString(xml_mantenimiento.Element("FechaAproximadaDeReingreso").Value);
                                    this.txt_nombre_contacto.Text = System.Convert.ToString(xml_mantenimiento.Element("NombreContacto").Value);
                                    this.txt_direccion_proveedor.Text = System.Convert.ToString(xml_mantenimiento.Element("DireccionProveedor").Value);
                                    break;
                                }
                            case 5:
                                {
                                    System.Xml.Linq.XElement xml_movimiento_activo = (
                                        from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_codigo_centro_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo.Element("CentroCostoDestino").Value);
                                    this.txt_nombre_centro_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo.Element("NombreCentroCostoDestino").Value);
                                    this.txt_cargo_responsable_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo.Element("Responsable").Value);
                                    this.txt_cod_responsable_destino.Text = System.Convert.ToString(xml_movimiento_activo.Element("CodigoResponsableDestino").Value);
                                    this.txt_nombre_responsable_destino.Text = System.Convert.ToString(xml_movimiento_activo.Element("NombreCodigoResponsableDestino").Value);
                                    this.txt_localizacion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo.Element("Localizacion").Value);
                                    this.txt_seccion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo.Element("Ubicacion").Value);
                                    this.txt_ubicacion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo.Element("Seccion").Value);
                                    break;
                                }
                            case 6:
                                {
                                    System.Xml.Linq.XElement xml_denuncia = (
                                        from item in xmldoc.XPathSelectElements("./Denuncia")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_num_proceso.Text = System.Convert.ToString(xml_denuncia.Element("NumeroProceso").Value);
                                    this.txt_observaciones_denuncia.Text = System.Convert.ToString(xml_denuncia.Element("Observaciones").Value);
                                    break;
                                }
                            case 7:
                                {
                                    System.Xml.Linq.XElement xml_movimiento_activo_externo = (
                                        from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    this.txt_codigo_centro_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("CentroCostoDestino").Value);
                                    this.txt_nombre_centro_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("NombreCentroCostoDestino").Value);
                                    this.txt_cargo_responsable_costo_destino.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("Responsable").Value);
                                    this.txt_cod_responsable_destino.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("CodigoResponsableDestino").Value);
                                    this.txt_nombre_responsable_destino.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("NombreCodigoResponsableDestino").Value);
                                    this.txt_localizacion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("Localizacion").Value);
                                    this.txt_seccion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("Ubicacion").Value);
                                    this.txt_ubicacion_solicitud.Text = System.Convert.ToString(xml_movimiento_activo_externo.Element("Seccion").Value);
                                    break;
                                }
                        }
                        this.cargar_grid(codigo_compania, id_movimiento);
                        this.ver_seccion(id_tipo_movimiento);
                    }
                    if (dt.Rows[0]["ESTADO"].ToString() == "A")
                    {
                        this.crear_mensajes("info", "Esa Solicitud ha sido Aceptada");
                        this.estado_controles(this.Page, false);
                        this.estado_botones(false, false);
                    }
                    if (dt.Rows[0]["ESTADO"].ToString() == "C")
                    {
                        this.crear_mensajes("info", "Esa solicitud ha sido Cancelada");
                        this.estado_controles(this.Page, false);
                        this.estado_botones(false, false);
                    }
                }
                else
                {
                    this.crear_mensajes("error", "La consulta no devolvio ningún resultado, Favor revisar la consulta de la bitacora");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void cargar_grid(string codigo_compania, int id_movimiento)
        {
            try
            {
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt = activos.cargar_activos_grid(codigo_compania, id_movimiento);
                this.gv_activos.DataSource = dt;
                this.gv_activos.DataBind();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        protected void estado_botones(bool estado_aplicar, bool estado_acepta_cancelar)
        {
            this.btn_aceptar.Visible = estado_acepta_cancelar;
            this.btn_cancelar.Visible = estado_acepta_cancelar;
            this.btn_aplicar_solicitud.Visible = estado_aplicar;
            this.btn_aceptar.Enabled = estado_acepta_cancelar;
            this.btn_cancelar.Enabled = estado_acepta_cancelar;
            this.btn_aplicar_solicitud.Enabled = estado_aplicar;
        }
        protected void estado_controles(Control parent, bool estado)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DropDownList)
                {
                    ((DropDownList)c).Enabled = estado;
                }
                if (c is TextBox)
                {
                    ((TextBox)c).Enabled = estado;
                }
                if (c is Button)
                {
                    ((Button)c).Enabled = estado;
                }
                if (c is ImageButton)
                {
                    ((ImageButton)c).Enabled = estado;
                }
                this.estado_controles(c, estado);

                if (String.IsNullOrEmpty(txt_observaciones_solicitud.Text))
                    trObservaciones.Style.Add("display", "none");
                else
                    trObservaciones.Style.Add("display", "block");
            }
            //this.btn_buscar_centro_costo.Visible = estado;
            //commented by GPE 12.02.2013 new stuff # 10
            //this.btn_buscar_solicitante.Visible = estado;
            this.btn_buscar_centro_costo_destino.Visible = estado;
            this.btn_buscar_resposable_destino.Visible = estado;
            if (!estado)
            {
                this.btn_aplicar_solicitud.Visible = false;
                this.btn_aceptar.Visible = true;
                this.btn_aceptar.Enabled = true;
                this.btn_cancelar.Visible = true;
                this.btn_cancelar.Enabled = true;
                this.txt_localizacion_solicitud.Visible = true;
                this.txt_seccion_solicitud.Visible = true;
                this.txt_ubicacion_solicitud.Visible = true;
                this.ddl_localizacion_destino.Visible = false;
                this.ddl_seccion_destino.Visible = false;
                this.ddl_ubicacion_destino.Visible = false;
                this.txt_observaciones_solicitud.Visible = true;
                this.lb_observaciones_solicitud.Visible = true;
                this.txt_cod_centro_costo.CssClass = "txt_filtro_input_not_enable";
                this.txt_cod_solicitante.CssClass = "txt_filtro_input_not_enable";
            }
            else
            {
                this.btn_aplicar_solicitud.Visible = true;
                this.btn_aplicar_solicitud.Enabled = true;
                this.btn_cancelar.Visible = false;
                this.btn_aceptar.Visible = false;
                this.txt_localizacion_solicitud.Visible = false;
                this.txt_seccion_solicitud.Visible = false;
                this.txt_ubicacion_solicitud.Visible = false;
                this.ddl_localizacion_destino.Visible = true;
                this.ddl_seccion_destino.Visible = true;
                this.ddl_ubicacion_destino.Visible = true;
                this.txt_observaciones_solicitud.Visible = false;
                this.lb_observaciones_solicitud.Visible = false;
            }
            this.img_btn_nuevo.Enabled = true;
            //GPE 11/25/2013 Enable Logout Button after a request is approved
            ImageButton imgbtnLogoutMaster = (ImageButton)Master.FindControl("img_btn_salir");
            imgbtnLogoutMaster.Enabled = true;
        }
        protected void cargar_combo_tipo_movimiento()
        {
            try
            {
                cls_traslado tipo_movimiento = new cls_traslado();
                System.Data.DataTable dt = tipo_movimiento.cargar_tipo_movimiento();
                this.ddl_tipo_movimiento.DataSource = dt;
                this.ddl_tipo_movimiento.DataTextField = "DESCRIPCION_TIPO_MOVIMIENTO";
                this.ddl_tipo_movimiento.DataValueField = "CODIGO_TIPO_MOVIMIENTO";
                this.ddl_tipo_movimiento.DataBind();
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        private void seccion_visible(bool visible)
        {
            this.seccion_area_destino.Visible = visible;
            this.seccion_calibracion_activos.Visible = visible;
            this.seccion_denuncia.Visible = visible;
            this.seccion_destruccion.Visible = visible;
            this.seccion_donacion.Visible = visible;
            //GPE 12/07/2013 WAT_Document new stuff # 14
            this.div_observaciones_obligatory.Visible = visible;
        }
        protected void ver_seccion(int id_tipo_movimiento)
        {
            switch (id_tipo_movimiento)
            {
                case 1:
                    this.seccion_donacion.Visible = true;
                    //GPE 12/07/2013 WAT_Document new stuff # 14
                    this.check_observaciones_obligatory();
                    break;
                case 2:
                    this.seccion_destruccion.Visible = true;
                    break;
                case 3:
                    this.seccion_calibracion_activos.Visible = true;
                    this.lb_fieldset_calibracion_mantenimiento.Text = "Solicitud de Calibración de Activos Fijos";
                    break;
                case 4:
                    this.seccion_calibracion_activos.Visible = true;
                    this.lb_fieldset_calibracion_mantenimiento.Text = "Solicitud de Mantenimiento de Activos Fijos";
                    break;
                case 5:
                    this.seccion_area_destino.Visible = true;
                    this.lb_fieldset_area_destino.Text = "Información de Área Destino de los Activos Fíjos Internos";
                    PopulateCentroCostoDestino();
                    break;
                case 6:
                    this.seccion_denuncia.Visible = true;
                    break;
                case 7:
                    this.seccion_area_destino.Visible = true;
                    this.lb_fieldset_area_destino.Text = "Información de Área Destino de los Activos Fíjos Externos";
                    LimpiarControles();
                    break;
            }
        }
        protected void ddl_tipo_movimiento_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.seccion_visible(false);
            int codigo_tipo_movimiento = this.ddl_tipo_movimiento.SelectedIndex;
            this.Session["TIPO_MOVIMIENTO"] = codigo_tipo_movimiento;
            this.ver_seccion(codigo_tipo_movimiento);
            Session["SES_Movimenent_Type"] = this.ddl_tipo_movimiento.SelectedValue;
            EventClickSearchPlata();
        }
        private void EventClickSearchPlata() {
            try
            {
                if (this.gv_activos.Rows.Count <= 0 || this.gv_activos.Rows.Count > 1) return;
                 string placa = ((TextBox)this.gv_activos.Rows[0].FindControl("txt_entrada_placa")).Text.Trim();
                 if (!string.IsNullOrEmpty(placa)) {
                     consultar_activo(0);
                 }
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
            }
        }

        protected void btn_cargar_centro_costo_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txt_cod_centro_costo.Text.Trim()))
                {
                    if (this.validar_centro_costo(this.txt_cod_centro_costo.Text.Trim()))
                    {
                        cls_traslado centro_costo = new cls_traslado();
                        System.Data.DataTable dt = centro_costo.cargar_centro_costo(this.txt_cod_centro_costo.Text.Trim());
                        if (dt.Rows.Count > 0)
                        {
                            this.Session["NOMBRE_CENTRO_COSTO"] = dt.Rows[0]["CENTRO_COSTO"].ToString();
                            //GPE 4/3/2014 get mail for calibracion
                            if (ddl_tipo_movimiento.SelectedValue == "3")
                                this.Session["RESPONSABLE"] = new cls_traslado().nombre_responsable_calibracion(this.txt_cod_centro_costo.Text.Trim());
                            else
                                this.Session["RESPONSABLE"] = new cls_traslado().nombre_responsable(this.txt_cod_centro_costo.Text.Trim());
                        }
                        else
                        {
                            this.Session["NOMBRE_CENTRO_COSTO"] = "No encontrado";
                        }
                        string script = "$(\"[id*='txt_des_centro_costo']\").val('{0}');$(\"[id*='txt_responsable']\").val('{1}')";
                        script = string.Format(script, this.Session["NOMBRE_CENTRO_COSTO"].ToString(), this.Session["RESPONSABLE"].ToString());
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);
                    }
                }
                else
                {
                    this.txt_des_centro_costo.Text = string.Empty;
                    this.crear_mensajes("validation", "El código de centro de costo es requerido");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void btn_cargar_solicitante_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txt_cod_solicitante.Text.Trim()))
                {
                    cls_traslado centro_costo = new cls_traslado();
                    System.Data.DataTable dt = centro_costo.cargar_empleado(this.txt_cod_solicitante.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        this.Session["NOMBRE_EMPLEADO"] = dt.Rows[0]["NOMBRE_EMPLEADO"].ToString();
                    }
                    else
                    {
                        this.Session["NOMBRE_EMPLEADO"] = "No encontrado";
                    }
                    string script = "$(\"[id*='txt_nombre_solicitante']\").val('{0}');";
                    script = string.Format(script, this.Session["NOMBRE_EMPLEADO"].ToString());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);
                }
                else
                {
                    this.txt_nombre_solicitante.Text = string.Empty;
                    this.crear_mensajes("validation", "El código de solicitante es requerido");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void btn_cargar_centro_costo_destino_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Session["RESPONSABLE"] = string.Empty;
                if (!string.IsNullOrEmpty(this.txt_codigo_centro_costo_destino.Text.Trim()))
                {
                    cls_traslado centro_costo = new cls_traslado();
                    string strMovementType = Session["SES_Movimenent_Type"].ToString().Trim();
                    if (Session["SES_COD_CIA_PRO"] == null) {
                        Session["SES_COD_CIA_PRO"] = string.Empty;
                    }
                    string strCOD_CIA_PRO = Session["SES_COD_CIA_PRO"].ToString().Trim();
                    DataTable dt = new DataTable();
                    if ((strMovementType == "5" || strMovementType == "7") && !string.IsNullOrEmpty(strCOD_CIA_PRO))
                    {
                        dt = centro_costo.cargar_centro_costo(this.txt_codigo_centro_costo_destino.Text.Trim(), strCOD_CIA_PRO, strMovementType);
                    }
                    else
                    {
                        //metodo original
                        dt = centro_costo.cargar_centro_costo(this.txt_codigo_centro_costo_destino.Text.Trim());
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.Session["NOMBRE_CENTRO_COSTO_DESTINO"] = dt.Rows[0]["CENTRO_COSTO"].ToString();
                        this.txt_nombre_centro_costo_destino.Text = dt.Rows[0]["CENTRO_COSTO"].ToString();
                        string strResponsable= new cls_traslado().nombre_responsable(this.txt_codigo_centro_costo_destino.Text.Trim());
                        this.txt_cargo_responsable_costo_destino.Text = strResponsable;
                        this.Session["RESPONSABLE"] =strResponsable;
                        //GPE 4/8/2014 WAT-04052014 Point 7
                        this.cargar_combo_localizacion(dt.Rows[0]["COD_CIA_PRO"].ToString());
                    }
                    else
                    {
                        this.txt_cargo_responsable_costo_destino.Text = string.Empty;
                        this.txt_nombre_centro_costo_destino.Text = "No corresponde a la planta!";
                        this.Session["NOMBRE_CENTRO_COSTO_DESTINO"] = "No encontrado";
                        //GPE 4/8/2014 WAT-04052014 Point 7
                        this.cargar_combo_localizacion();
                    }
                    string script = "$(\"[id*='txt_nombre_centro_costo_destino']\").val('{0}');$(\"[id*='txt_cargo_responsable_costo_destino']\").val('{1}');";
                    script = string.Format(script, this.Session["NOMBRE_CENTRO_COSTO_DESTINO"].ToString(), this.Session["RESPONSABLE"].ToString());
                    //DISABLE adding additional information if the centro costo not exist
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);
                }
                else
                {
                    this.txt_cargo_responsable_costo_destino.Text = string.Empty;
                    this.txt_nombre_centro_costo_destino.Text = string.Empty;
                    this.crear_mensajes("validation", "El código de Centro de Costo de Destino es requerido");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void btn_cargar_responsable_destino_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txt_cod_responsable_destino.Text.Trim()))
                {
                    cls_traslado centro_costo = new cls_traslado();
                    System.Data.DataTable dt = centro_costo.cargar_empleado(this.txt_cod_responsable_destino.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        this.Session["NOMBRE_EMPLEADO_RESPONSABLE"] = dt.Rows[0]["NOMBRE_EMPLEADO"].ToString();
                    }
                    else
                    {
                        this.Session["NOMBRE_EMPLEADO_RESPONSABLE"] = "No encontrado";
                    }
                    string script = "$(\"[id*='txt_nombre_responsable_destino']\").val('{0}');";
                    script = string.Format(script, this.Session["NOMBRE_EMPLEADO_RESPONSABLE"].ToString());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);
                }
                else
                {
                    this.txt_nombre_responsable_destino.Text = string.Empty;
                    this.crear_mensajes("validation", "El código de Responsable Destino es requerido");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        //GPE 4/8/2014 WAT-04052014 Point 7
        //protected void cargar_combo_localizacion()
        protected void cargar_combo_localizacion(string cod_cia_pro = "")
        {
            try
            {
                cls_traslado localizacion = new cls_traslado();
                //GPE 4/8/2014 WAT-04052014 Point 7
                //System.Data.DataTable dt = localizacion.cargar_localizacion_activo();
                this.ddl_localizacion_destino.Items.Clear();
                ListItem first = new ListItem("Seleccione la Localización", "0");
                this.ddl_localizacion_destino.Items.Add(first);
                System.Data.DataTable dt = localizacion.cargar_localizacion_activo(cod_cia_pro.Trim());
                this.ddl_localizacion_destino.DataSource = dt;
                this.ddl_localizacion_destino.DataTextField = "DES_LOCALIZACION_ACTVO";
                this.ddl_localizacion_destino.DataValueField = "COD_LOCALIZACION_ACTIVO";
                this.ddl_localizacion_destino.DataBind();
                this.cargar_combo_seccion(this.ddl_localizacion_destino.SelectedValue);
                this.cargar_combo_ubicacion(this.ddl_seccion_destino.SelectedValue);
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void cargar_combo_seccion(string cod_localizacion)
        {
            try
            {
                cls_traslado seccion = new cls_traslado();
                System.Data.DataTable dt = seccion.cargar_seccion_localizacion_activo(cod_localizacion);
                this.ddl_seccion_destino.DataSource = dt;
                this.ddl_seccion_destino.DataTextField = "DES_SECCION_LOC";
                this.ddl_seccion_destino.DataValueField = "COD_SECCION_LOC";
                this.ddl_seccion_destino.DataBind();
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void cargar_combo_ubicacion(string cod_seccion)
        {
            try
            {
                cls_traslado seccion = new cls_traslado();
                System.Data.DataTable dt = seccion.cargar_ubicacion_activo(cod_seccion);
                this.ddl_ubicacion_destino.DataSource = dt;
                this.ddl_ubicacion_destino.DataTextField = "DES_UBICACION_ACTIVO";
                this.ddl_ubicacion_destino.DataValueField = "COD_UBICACION_ACTIVO";
                this.ddl_ubicacion_destino.DataBind();
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void ddl_localizacion_destino_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.cargar_combo_seccion(this.ddl_localizacion_destino.SelectedValue);
                this.cargar_combo_ubicacion(this.ddl_seccion_destino.SelectedValue);
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void ddl_seccion_destino_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.cargar_combo_ubicacion(this.ddl_seccion_destino.SelectedValue);
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
        private void cambiar_estado(int id_movimiento, string codigo_estado, bool excluir)
        {
            try
            {
                new cls_traslado().cambiar_estado(id_movimiento, this.Session["CODIGO_COMPANIA"].ToString(), codigo_estado, excluir);
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void cambio_estado_aceptado(string estado)
        {
            try
            {
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt = activos.cargar_lista_activos_por_solicitud(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        new cls_traslado().actualizar_estado_activo_por_solicitud(dt.Rows[i]["CODIGO_ACTIVO"].ToString(), estado);
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void cambio_datos_traslados_activos_aceptados(int id_tipo_movimiento)
        {
            cls_traslado detalle_traslado = new cls_traslado();
            System.Data.DataTable dt = detalle_traslado.cargar_detalle_destino_movimiento(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()));
            string cadena = dt.Rows[0]["DETALLE_DESTINO_MOVIMIENTO"].ToString();
            string xmlcadena = "<Datos>" + cadena + "</Datos>";
            System.Xml.Linq.XElement xmldoc = System.Xml.Linq.XElement.Parse(xmlcadena);
            ent_traslado entidad = new ent_traslado();
            switch (id_tipo_movimiento)
            {
                case 5:
                    {
                        System.Xml.Linq.XElement xml_movimiento_activo = (
                            from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                            select item).FirstOrDefault<System.Xml.Linq.XElement>();
                        entidad.centro_costo = System.Convert.ToString(xml_movimiento_activo.Element("CentroCostoDestino").Value);
                        entidad.codigo_empleado = System.Convert.ToString(xml_movimiento_activo.Element("CodigoResponsableDestino").Value);
                        entidad.codigo_localizacion_activo = System.Convert.ToString(xml_movimiento_activo.Element("Localizacion").Value);
                        entidad.codigo_seccion_activo = System.Convert.ToString(xml_movimiento_activo.Element("Ubicacion").Value);
                        entidad.codigo_ubicacion_activo = System.Convert.ToString(xml_movimiento_activo.Element("Seccion").Value);
                        break;
                    }
                case 7:
                    {
                        System.Xml.Linq.XElement xml_movimiento_activo_externo = (
                            from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                            select item).FirstOrDefault<System.Xml.Linq.XElement>();
                        entidad.centro_costo = System.Convert.ToString(xml_movimiento_activo_externo.Element("CentroCostoDestino").Value);
                        entidad.codigo_empleado = System.Convert.ToString(xml_movimiento_activo_externo.Element("CodigoResponsableDestino").Value);
                        entidad.codigo_localizacion_activo = System.Convert.ToString(xml_movimiento_activo_externo.Element("Localizacion").Value);
                        entidad.codigo_seccion_activo = System.Convert.ToString(xml_movimiento_activo_externo.Element("Ubicacion").Value);
                        entidad.codigo_ubicacion_activo = System.Convert.ToString(xml_movimiento_activo_externo.Element("Seccion").Value);
                        break;
                    }
            }
            entidad.codigo_compania = this.Session["CODIGO_COMPANIA"].ToString();
            entidad.id_movimiento = System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString());
            cls_traslado solicitud_traslado_aceptado = new cls_traslado();
            System.Data.DataTable dt_activos = solicitud_traslado_aceptado.cargar_lista_activos_por_solicitud(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()));
            if (dt_activos.Rows.Count > 0)
            {
                for (int i = 0; i < dt_activos.Rows.Count; i++)
                {
                    entidad.numero_activo = dt_activos.Rows[i]["CODIGO_ACTIVO"].ToString();
                    new cls_traslado().actualizar_datos_traslado_activo_solicitud_aceptada(entidad);
                }
            }
        }
        protected void img_btn_nuevo_Click(object sender, ImageClickEventArgs e)
        {
            Session["SES_COD_CIA_PRO"] = string.Empty;
            Session["SES_Movimenent_Type"] = string.Empty;
            this.cargar_valores_defecto();
            this.Session["CODIGO"] = null;
            this.estado_controles(this.Page, true);
            base.Response.Redirect("wbfrm_traslado_activo.aspx");
        }
        protected void btn_aplicar_solicitud_Click(object sender, System.EventArgs e)
        {
            try
            {
                //GPE 3/31/2014 prevent double press
                btn_aplicar_solicitud.Enabled = false;

                if (this.validar_datos(System.Convert.ToInt32(this.Session["TIPO_MOVIMIENTO"])))
                {
                    ent_traslado entidad = new ent_traslado();
                    entidad = this.asignar_valores(entidad);
                    int id_movimiento = new cls_traslado().ingresar_traslado(entidad);
                    if (id_movimiento > 0)
                    {
                        this.txt_num_solicitud.Text = id_movimiento.ToString();
                        this.enviar_solicitud_correo(id_movimiento, this.Session["CODIGO_COMPANIA"].ToString());
                        if (id_movimiento != 2)
                        {
                            this.crear_mensajes("success", "La solicitud de traslado se realizo satisfactoriamente");
                        }
                        else
                            this.crear_mensajes("success", "La solicitud se realizo satisfactoriamente");
                        this.estado_controles(this.Page, false);
                        this.estado_botones(false, false);
                    }
                    else
                    {
                        if (id_movimiento != 2)
                            this.crear_mensajes("error", "La solicitud de traslado no pudo realizarse con exito");
                        else
                            this.crear_mensajes("error", "La solicitud+- no pudo realizarse con exito");
                    }
                }
                //GPE 3/31/2014 prevent double press
                btn_aplicar_solicitud.Enabled = true;
            }
            catch (System.Exception ex)
            {
                //GPE 3/31/2014 prevent double press
                btn_aplicar_solicitud.Enabled = true;
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void btn_aceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                //GPE 3/31/2014 prevent double press
                btn_aceptar.Enabled = false;

                if (this.validar_solicitud())
                {
                    if (new cls_traslado().aceptar_tipo_movimiento(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()), this.Session["CODIGO_COMPANIA"].ToString()))
                    {
                        this.enviar_solicitud_correo(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()), this.Session["CODIGO_COMPANIA"].ToString());
                        this.crear_mensajes("success", "Tipo de movimiento aceptado exitosamente");
                        this.estado_controles(this.Page, false);
                        this.estado_botones(false, false);
                    }
                    else
                    {
                        this.crear_mensajes("error", "No se realizo tipo de movimiento con exito");
                    }
                }
                //GPE 3/31/2014 prevent double press
                btn_aceptar.Enabled = true;
            }
            catch (System.Exception ex)
            {
                //GPE 3/31/2014 prevent double press
                btn_aceptar.Enabled = true;
                this.crear_mensajes("error", ex.Message);
            }
        }
        protected void btn_cancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.validar_solicitud())
                {
                    if (new cls_traslado().cancelar_tipo_movimiento(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()), this.Session["CODIGO_COMPANIA"].ToString()))
                    {
                        this.insertar_bitacora("cancelado", this.txt_observaciones_solicitud.Text);
                        string correo_solicitante = new cls_traslado().correo_solicitante(this.txt_cod_solicitante.Text);
                        if (!string.IsNullOrEmpty(correo_solicitante))
                        {
                            this.enviar_correo(-1, correo_solicitante);
                            //GPE 4/6/2014 WAT-04052014 Point 4
                            // this.crear_mensajes("success", "Se cancelo el tipo de movimiento exitosamente");
                        }
                        else
                        {
                            //GPE 4/6/2014 WAT-04052014 Point 4
                            //this.crear_mensajes("info", "Se cancelo el tipo de movimiento exitosamente, pero no se le pudo notificar al responsable " + this.txt_responsable.Text + " ya que no se encontro ningún correo registrado");
                        }
                        this.estado_botones(false, false);
                        this.cargar_controles(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()));
                    }
                    else
                    {
                        this.crear_mensajes("error", "La cancelación del tipo de movimiento no pudo realizarse");
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.Message);
            }
        }
        protected void gv_activo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = System.Convert.ToInt32(e.RowIndex);
            System.Data.DataTable tablaActivos = this.Session["TABLA_ACTIVO"] as System.Data.DataTable;
            //GPE 1/27/2014 NEW LOGIC FOR DELETE

            if (index <= tablaActivos.Rows.Count - 1)
            {
                if (!string.IsNullOrEmpty(tablaActivos.Rows[index][0].ToString()))
                {
                    tablaActivos.Rows[index].Delete();
                }
            }
            else if (index > 0 &&  e.Values[2] == null)
            {
                System.Data.DataRow filaNueva = tablaActivos.NewRow();
                filaNueva["PLA_ACTIVO"] = null;
                filaNueva["REF_NUM_ACT"] = null;
                filaNueva["DES_ACTIVO"] = null;
                filaNueva["DES_MARCA"] = null;
                filaNueva["NOM_MODELO"] = null;
                filaNueva["SER_ACTIVO"] = null;
                tablaActivos.Rows.Add(filaNueva);
            }

            if (tablaActivos.Rows.Count <= 0)
            {
                System.Data.DataRow filaNueva = tablaActivos.NewRow();
                filaNueva["PLA_ACTIVO"] = null;
                filaNueva["REF_NUM_ACT"] = null;
                filaNueva["DES_ACTIVO"] = null;
                filaNueva["DES_MARCA"] = null;
                filaNueva["NOM_MODELO"] = null;
                filaNueva["SER_ACTIVO"] = null;
                tablaActivos.Rows.Add(filaNueva);

                //GPE 12/07/2013 WAT_Document new stuff # 12
                //centro_costo_status(true);
                centro_costo_Empty();
            }
            else
            {
                if (string.IsNullOrEmpty(tablaActivos.Rows[0][0].ToString()))
                    //centro_costo_status(true);
                    centro_costo_Empty();
                //else
                //    centro_costo_status(false);
            }


            this.Session["TABLA_ACTIVO"] = tablaActivos;
            this.gv_activos.DataSource = tablaActivos;
            this.gv_activos.DataBind();

            
            //tablaActivos.Rows[index].Delete();
            //this.Session["TABLA_ACTIVO"] = tablaActivos;
            //if (tablaActivos.Rows.Count <= 0)
            //{
            //    System.Data.DataRow filaNueva = tablaActivos.NewRow();
            //    filaNueva["PLA_ACTIVO"] = null;
            //    filaNueva["REF_NUM_ACT"] = null;
            //    filaNueva["DES_ACTIVO"] = null;
            //    filaNueva["DES_MARCA"] = null;
            //    filaNueva["NOM_MODELO"] = null;
            //    filaNueva["SER_ACTIVO"] = null;
            //    tablaActivos.Rows.Add(filaNueva);

            //    //GPE 12/07/2013 WAT_Document new stuff # 12
            //    centro_costo_status(true);
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(tablaActivos.Rows[0][0].ToString()))
            //        centro_costo_status(true);
            //    else
            //        centro_costo_status(false);
            //}
            
            //this.gv_activos.DataSource = tablaActivos;
            //this.gv_activos.DataBind();
        }
        protected void gv_activo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "buscarClick")
            {
                int index = System.Convert.ToInt32(e.CommandArgument);
                this.consultar_activo(index);
            }
        }
        private void cargar_activos()
        {
            if (this.gv_activos.Rows.Count <= 0)
            {
                this.gv_activos.DataSource = (this.Session["TABLA_ACTIVO"] as System.Data.DataTable);
                this.gv_activos.DataBind();
            }
        }
        public System.Data.DataTable ReturnEmptyDataTable()
        {
            System.Data.DataTable dtEmpty = new System.Data.DataTable();
            System.Data.DataColumn dc0 = new System.Data.DataColumn("PLA_ACTIVO", typeof(string));
            dtEmpty.Columns.Add(dc0);
            System.Data.DataColumn dc = new System.Data.DataColumn("REF_NUM_ACT", typeof(string));
            dtEmpty.Columns.Add(dc);
            System.Data.DataColumn dc2 = new System.Data.DataColumn("DES_ACTIVO", typeof(string));
            dtEmpty.Columns.Add(dc2);
            System.Data.DataColumn dc3 = new System.Data.DataColumn("DES_MARCA", typeof(string));
            dtEmpty.Columns.Add(dc3);
            System.Data.DataColumn dc4 = new System.Data.DataColumn("NOM_MODELO", typeof(string));
            dtEmpty.Columns.Add(dc4);
            System.Data.DataColumn dc5 = new System.Data.DataColumn("SER_ACTIVO", typeof(string));
            dtEmpty.Columns.Add(dc5);
            System.Data.DataColumn dc6 = new System.Data.DataColumn("VAL_LIBROS", typeof(string));
            dtEmpty.Columns.Add(dc6);
            System.Data.DataRow datatRow = dtEmpty.NewRow();
            dtEmpty.Rows.Add(datatRow);
            return dtEmpty;
        }
        private bool valida_duplicidad(System.Data.DataTable tablaActivos, System.Data.DataRow fila)
        {
            bool result;
            for (int i = 0; i < tablaActivos.Rows.Count; i++)
            {
                if (tablaActivos.Rows[i]["PLA_ACTIVO"].ToString() == fila["PLA_ACTIVO"].ToString())
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        private void consultar_activo(int index)
        {
            try
            {
                Session["SES_COD_CIA_PRO"] = string.Empty;
                //Session["SES_Movimenent_Type"] = string.Empty;
                if (this.ddl_tipo_movimiento.SelectedValue == "0")
                {
                    this.crear_mensajes("error", " Por favor, debe seleccionar un tipo de movimiento...");
                    return;
                }
                string placa = ((TextBox)this.gv_activos.Rows[index].FindControl("txt_entrada_placa")).Text.Trim();
                string centroCosto = this.txt_cod_centro_costo.Text;
                System.Data.DataTable tablaActivos = this.Session["TABLA_ACTIVO"] as System.Data.DataTable;
                //GPE 12/07/2013 WAT_Document new stuff # 12
                if (!string.IsNullOrEmpty(placa) )//&& !string.IsNullOrEmpty(centroCosto))
                {
                    System.Data.DataTable dt = new cls_traslado().cargar_activos(placa, centroCosto);

                    if (dt.Rows.Count > 0)
                    {
                        if (tablaActivos == null)
                        {
                            this.Session["TABLA_ACTIVO"] = this.ReturnEmptyDataTable();
                            tablaActivos = (this.Session["TABLA_ACTIVO"] as System.Data.DataTable);
                        }
                        System.Data.DataRow fila = tablaActivos.NewRow();
                        fila["PLA_ACTIVO"] = dt.Rows[0][0].ToString();
                        fila["REF_NUM_ACT"] = dt.Rows[0][1].ToString();
                        fila["DES_ACTIVO"] = dt.Rows[0][2].ToString();
                        fila["DES_MARCA"] = dt.Rows[0][3].ToString();
                        fila["NOM_MODELO"] = dt.Rows[0][4].ToString();
                        fila["SER_ACTIVO"] = dt.Rows[0][5].ToString();
                        fila["VAL_LIBROS"] = dt.Rows[0][6].ToString();
                        //new line
                        for (int i = 0; i < tablaActivos.Rows.Count; i++)
                        {
                            if (tablaActivos.Rows[i].IsNull(0) && tablaActivos.Rows[i].IsNull(1) && tablaActivos.Rows[i].IsNull(2) && tablaActivos.Rows[i].IsNull(3))
                            {
                                tablaActivos.Rows[i].Delete();
                            }
                        }
                        if (!this.valida_duplicidad(tablaActivos, fila))
                        {
                            tablaActivos.Rows.Add(fila);
                            if (!string.IsNullOrEmpty(placa))
                            {
                                if (!tablaActivos.Rows[index].IsNull(0) && !tablaActivos.Rows[index].IsNull(1) && !tablaActivos.Rows[index].IsNull(2))
                                {
                                    tablaActivos.Rows[index][0] = dt.Rows[0][0].ToString();
                                    tablaActivos.Rows[index][1] = dt.Rows[0][1].ToString();
                                    tablaActivos.Rows[index][2] = dt.Rows[0][2].ToString();
                                    tablaActivos.Rows[index][3] = dt.Rows[0][3].ToString();
                                    tablaActivos.Rows[index][4] = dt.Rows[0][4].ToString();
                                    tablaActivos.Rows[index][5] = dt.Rows[0][5].ToString();
                                    tablaActivos.Rows[index][6] = dt.Rows[0][6].ToString();
                                }
                            }
                            this.Session["TABLA_ACTIVO"] = tablaActivos;
                            System.Data.DataRow filaNueva = tablaActivos.NewRow();
                            filaNueva["PLA_ACTIVO"] = null;
                            filaNueva["REF_NUM_ACT"] = null;
                            filaNueva["DES_ACTIVO"] = null;
                            filaNueva["DES_MARCA"] = null;
                            filaNueva["NOM_MODELO"] = null;
                            filaNueva["SER_ACTIVO"] = null;
                            filaNueva["VAL_LIBROS"] = null;
                            tablaActivos.Rows.Add(filaNueva);
                            this.gv_activos.DataSource = tablaActivos;
                            this.gv_activos.DataBind();
                            //GPE 12/07/2013 WAT_Document new stuff # 12
                            if (string.IsNullOrEmpty(centroCosto))
                            {
                                if (this.validar_centro_costo(dt.Rows[0][7].ToString().Trim()))
                                {
                                    cls_traslado centro_costo = new cls_traslado();
                                    System.Data.DataTable dtce = centro_costo.cargar_centro_costo(dt.Rows[0][7].ToString().Trim());
                                    if (dt.Rows.Count > 0)
                                    {
                                        this.Session["NOMBRE_CENTRO_COSTO"] = dtce.Rows[0]["CENTRO_COSTO"].ToString();
                                        //GPE 4/3/2014 get mail for calibracion
                                        // Update By Felix
                                        if (ddl_tipo_movimiento.SelectedValue == "3")
                                        {
                                            this.txt_responsable.Text = "Aprueba Departamento de Calibraciones";
                                            this.Session["RESPONSABLE"] = new cls_traslado().nombre_responsable_calibracion(dt.Rows[0][7].ToString().Trim());
                                        }
                                        else
                                        {
                                            this.Session["RESPONSABLE"] = new cls_traslado().nombre_responsable(dt.Rows[0][7].ToString().Trim());
                                            this.txt_responsable.Text = this.Session["RESPONSABLE"].ToString();
                                        }
                                        this.txt_des_centro_costo.Text = this.Session["NOMBRE_CENTRO_COSTO"].ToString();
                                        
                                        this.txt_cod_centro_costo.Text = dt.Rows[0][7].ToString().Trim();

                                        if (this.ddl_tipo_movimiento.SelectedValue == "5" || this.ddl_tipo_movimiento.SelectedValue == "7")
                                        {
                                            DataTable dtCOD_CIA_PRO = new cls_traslado().GetCOD_CIA_PROByCost_Center(this.txt_cod_centro_costo.Text.Trim(),Session["CODIGO_COMPANIA"].ToString());
                                            if (dtCOD_CIA_PRO != null && dtCOD_CIA_PRO.Rows.Count > 0)
                                            {
                                                Session["SES_COD_CIA_PRO"] = dtCOD_CIA_PRO.Rows[0][0].ToString().Trim();
                                                Session["SES_Movimenent_Type"] = this.ddl_tipo_movimiento.SelectedValue;
                                            }
                                            else {
                                                Session["SES_COD_CIA_PRO"] = string.Empty;
                                            }
                                            dtCOD_CIA_PRO = null;
                                        }
                                    }
                                    else
                                    {
                                        this.Session["NOMBRE_CENTRO_COSTO"] = "No encontrado";
                                    }
                                }
                            }
                            //GPE disable centro_costo
                            //centro_costo_status(false);
                        }
                        else
                        {
                            this.crear_mensajes("validation", "El activo digitado ya existe en la presente solicitud");
                        }
                    }
                    else
                    {
                        //GPE 1/26/2014 Fixing IE Issues print message No corresponde al centro de costo
                        if (!string.IsNullOrEmpty(tablaActivos.Rows[0][0].ToString()))
                            this.crear_mensajes("validation", "No corresponde al centro de costo");
                        else
                            this.crear_mensajes("validation", "No se encontraron datos");
                    }
                }
                else
                {
                    //GPE 12/07/2013 WAT_Document new stuff # 12
                    //this.crear_mensajes("validation", "El campo de Centro de Costo y el campo de placa no pueden ser nulos");
                    this.crear_mensajes("validation", "El campo de placa no pueden ser nulos");
                }
            }
            catch (System.Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                this.crear_mensajes("error", ex.ToString());
            }
        }
        private ent_traslado asignar_valores(ent_traslado entidad)
        {
            try
            {
                entidad.codigo_compania = this.Session["CODIGO_COMPANIA"].ToString();
                entidad.centro_costo = this.txt_cod_centro_costo.Text;
                entidad.fecha_movimiento = System.DateTime.Now;
                entidad.codigo_empleado = this.txt_cod_solicitante.Text;
                entidad.descripcion_centro_costo = this.txt_des_centro_costo.Text;
                entidad.empleado_responsable_cc = this.txt_nombre_solicitante.Text;
                entidad.codigo_tipo_movimiento = System.Convert.ToInt32(this.ddl_tipo_movimiento.SelectedValue);
                entidad.estado = "P";
                entidad.codigo_paso_aprobacion_actual = 0;
                entidad.activo_solicitado = (this.Session["TABLA_ACTIVO"] as System.Data.DataTable);
                int tipo_movimiento = System.Convert.ToInt32(this.Session["TIPO_MOVIMIENTO"]);
                this.validar_datos(tipo_movimiento);
                switch (tipo_movimiento)
                {
                    case 1:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Donacion"),
						new System.Xml.Linq.XElement("Donacion", new System.Xml.Linq.XElement("Observaciones", this.txt_observaciones_donacion.Text))
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 2:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Destruccion"),
						new System.Xml.Linq.XElement("Destruccion", new System.Xml.Linq.XElement("Observaciones", this.txt_observaciones_destruccion.Text))
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 3:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Calibracion"),
						new System.Xml.Linq.XElement("Calibracion", new object[]
						{
							new System.Xml.Linq.XElement("Proveedor", this.txt_proveedor.Text),
							new System.Xml.Linq.XElement("CedulaJuridica", this.txt_cedula_juridica.Text),
							new System.Xml.Linq.XElement("TelefonoProveedor", this.txt_telefono_proveedor.Text),
							new System.Xml.Linq.XElement("FechaAproximadaDeReingreso", this.txt_fecha_aprox_reingreso.Text),
							new System.Xml.Linq.XElement("NombreContacto", this.txt_nombre_contacto.Text),
							new System.Xml.Linq.XElement("DireccionProveedor", this.txt_direccion_proveedor.Text),
							new System.Xml.Linq.XElement("Observaciones", this.txt_observaciones_calibracion.Text)
						})
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 4:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Mantenimiento"),
						new System.Xml.Linq.XElement("Mantenimiento", new object[]
						{
							new System.Xml.Linq.XElement("Observaciones", this.txt_observaciones_calibracion.Text),
							new System.Xml.Linq.XElement("Proveedor", this.txt_proveedor.Text),
							new System.Xml.Linq.XElement("CedulaJuridica", this.txt_cedula_juridica.Text),
							new System.Xml.Linq.XElement("TelefonoProveedor", this.txt_telefono_proveedor.Text),
							new System.Xml.Linq.XElement("FechaAproximadaDeReingreso", this.txt_fecha_aprox_reingreso.Text),
							new System.Xml.Linq.XElement("NombreContacto", this.txt_nombre_contacto.Text),
							new System.Xml.Linq.XElement("DireccionProveedor", this.txt_direccion_proveedor.Text)
						})
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 5:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Area de Destino"),
						new System.Xml.Linq.XElement("MovimientoActivo", new object[]
						{
							new System.Xml.Linq.XElement("CentroCostoDestino", this.txt_codigo_centro_costo_destino.Text),
							new System.Xml.Linq.XElement("NombreCentroCostoDestino", this.txt_nombre_centro_costo_destino.Text),
							new System.Xml.Linq.XElement("Responsable", this.txt_cargo_responsable_costo_destino.Text),
							new System.Xml.Linq.XElement("CodigoResponsableDestino", this.txt_cod_responsable_destino.Text),
							new System.Xml.Linq.XElement("NombreCodigoResponsableDestino", this.txt_nombre_responsable_destino.Text),
							new System.Xml.Linq.XElement("Localizacion", this.ddl_localizacion_destino.SelectedValue),
							new System.Xml.Linq.XElement("Ubicacion", this.ddl_seccion_destino.SelectedValue),
							new System.Xml.Linq.XElement("Seccion", this.ddl_ubicacion_destino.SelectedValue)
						})
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 6:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Denuncia"),
						new System.Xml.Linq.XElement("Denuncia", new object[]
						{
							new System.Xml.Linq.XElement("NumeroProceso", this.txt_num_proceso.Text),
							new System.Xml.Linq.XElement("Observaciones", this.txt_observaciones_denuncia.Text)
						})
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                    case 7:
                        {
                            System.Xml.Linq.XDocument detalle_movimiento = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "yes"), new object[]
					{
						new System.Xml.Linq.XComment("Detalle del movimiento destino - Area de Destino"),
						new System.Xml.Linq.XElement("MovimientoActivo", new object[]
						{
							new System.Xml.Linq.XElement("CentroCostoDestino", this.txt_codigo_centro_costo_destino.Text),
							new System.Xml.Linq.XElement("NombreCentroCostoDestino", this.txt_nombre_centro_costo_destino.Text),
							new System.Xml.Linq.XElement("Responsable", this.txt_cargo_responsable_costo_destino.Text),
							new System.Xml.Linq.XElement("CodigoResponsableDestino", this.txt_cod_responsable_destino.Text),
							new System.Xml.Linq.XElement("NombreCodigoResponsableDestino", this.txt_nombre_responsable_destino.Text),
							new System.Xml.Linq.XElement("Localizacion", this.ddl_localizacion_destino.SelectedValue),
							new System.Xml.Linq.XElement("Ubicacion", this.ddl_seccion_destino.SelectedValue),
							new System.Xml.Linq.XElement("Seccion", this.ddl_ubicacion_destino.SelectedValue)
						})
					});
                            entidad.detalle_destino_movimiento = detalle_movimiento;
                            break;
                        }
                }
            }
            catch (System.Exception)
            {
            }
            return entidad;
        }
        private int acceso_localizacion()
        {
            string codigo_localizacion = new cls_traslado().codigo_localizacion(this.txt_cod_centro_costo.Text);
            int result;
            if (codigo_localizacion == "M420")
            {
                result = 4;
            }
            else
            {
                result = 5;
            }
            return result;
        }
        protected bool validar_solicitud()
        {
            bool result;
            if (System.Convert.ToInt32(this.Session["ID_PASO_APROBACION_ACTUAL"]) == 1 && System.Convert.ToInt32(this.Session["TIPO_MOVIMIENTO"]) == 4 && string.IsNullOrEmpty(this.txt_observaciones_solicitud.Text))
            {
                this.crear_mensajes("validation", "El escriba las observaciones de caso.");
                this.txt_observaciones_solicitud.Focus();
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        protected bool validar_centro_costo(string cod_centro_costo)
        {
            bool result;
            try
            {
                if (cod_centro_costo == "0")
                {
                    this.crear_mensajes("validation", "Ese valor de Código de Centro de Costo no es Permitido");
                    result = false;
                    return result;
                }
                cls_traslado centro_costo = new cls_traslado();
                System.Data.DataTable dt = centro_costo.cargar_centro_costo(cod_centro_costo);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
            result = false;
            return result;
        }
        protected bool validar_solicitante(string cod_solicitante)
        {
            bool result;
            try
            {
                if (cod_solicitante == "0")
                {
                    this.crear_mensajes("validation", "Ese valor de Código de Empleado no es Permitido");
                    result = false;
                    return result;
                }
                cls_traslado centro_costo = new cls_traslado();
                System.Data.DataTable dt = centro_costo.cargar_empleado(cod_solicitante);
                if (dt.Rows.Count > 0)
                {
                    result = true;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
            result = false;
            return result;
        }
        protected bool validar_datos(int seccion)
        {
            bool result;
            if (seccion == 0)
            {
                this.crear_mensajes("validation", "Seleccione el Tipo de Movimiento de Activo");
                this.ddl_tipo_movimiento.Focus();
                result = false;
            }
            else
            {
                if (string.IsNullOrEmpty(this.txt_cod_centro_costo.Text.Trim()))
                {
                    this.crear_mensajes("validation", "El código de Centro de Costo es requerido");
                    this.txt_cod_centro_costo.Focus();
                    result = false;
                }
                else
                {
                    if (this.txt_cod_centro_costo.Text.Trim() == "0")
                    {
                        this.crear_mensajes("validation", "Ese valor de como Código de Centro de Costo no es Permitido");
                        result = false;
                    }
                    else
                    {
                        if (!this.validar_centro_costo(this.txt_cod_centro_costo.Text.Trim()))
                        {
                            this.crear_mensajes("validation", "Revisar información de Centro de Costo");
                            this.txt_cod_centro_costo.Focus();
                            result = false;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text)))
                            {
                                this.crear_mensajes("validation", "El responsable asociado al Centro de Costo no posee Dirección Electronica");
                                this.txt_cod_centro_costo.Focus();
                                result = false;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(this.txt_cod_solicitante.Text.Trim()))
                                {
                                    this.crear_mensajes("validation", "El código de Solicitante es requerido");
                                    this.txt_cod_solicitante.Focus();
                                    result = false;
                                }
                                else
                                {
                                    if (this.txt_cod_solicitante.Text.Trim() == "0")
                                    {
                                        this.crear_mensajes("validation", "Ese valor de Código de Empleado no es Permitido");
                                        result = false;
                                    }
                                    else
                                    {
                                        if (!this.validar_solicitante(this.txt_cod_solicitante.Text.Trim()))
                                        {
                                            this.crear_mensajes("validation", "Revisar información de Solicitante");
                                            this.txt_cod_solicitante.Focus();
                                            result = false;
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(new cls_traslado().correo_solicitante(this.txt_cod_solicitante.Text)))
                                            {
                                                this.txt_cod_solicitante.Focus();
                                                this.crear_mensajes("validation", "El Solicitante no tiene registrado un correo Electrónico");
                                                result = false;
                                            }
                                            else
                                            {
                                                if (string.IsNullOrEmpty(this.txt_des_centro_costo.Text.Trim()))
                                                {
                                                    this.crear_mensajes("validation", "Seleccione el Centro de Costo");
                                                    this.txt_des_centro_costo.Focus();
                                                    result = false;
                                                }
                                                else
                                                {
                                                    if (string.IsNullOrEmpty(this.txt_nombre_solicitante.Text.Trim()))
                                                    {
                                                        this.crear_mensajes("validation", "Seleccione al Solicitante");
                                                        this.txt_nombre_solicitante.Focus();
                                                        result = false;
                                                    }
                                                    else
                                                    {
                                                        if (seccion == 1)
                                                        {
                                                            //GPE 4/2/2014 Donacion observaciones should be obligatory
                                                            //GPE 12/07/2013 WAT_Document new stuff # 14 - disable only for employers in 'Recursos humanos' group 
                                                            //if (new cls_traslado().check_observaciones_obligatory(this.txt_cod_solicitante.Text.Trim()))
                                                            //{
                                                                if (string.IsNullOrEmpty(this.txt_observaciones_donacion.Text))
                                                                {
                                                                    this.crear_mensajes("validation", "Escriba las observaciones.");
                                                                    this.txt_observaciones_donacion.Focus();
                                                                    result = false;
                                                                    return result;
                                                                }
                                                            //}
                                                        }
                                                        if (seccion == 2)
                                                        {
                                                            if (string.IsNullOrEmpty(this.txt_observaciones_destruccion.Text))
                                                            {
                                                                this.crear_mensajes("validation", "Escriba las observaciones.");
                                                                this.txt_observaciones_destruccion.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                        }
                                                        if (seccion == 3)
                                                        {
                                                            if (string.IsNullOrEmpty(this.txt_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El nombre del Proveedor es requerido");
                                                                this.txt_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_cedula_juridica.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La Cédula Jurídica del Proveedor es requerida");
                                                                this.txt_cedula_juridica.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_telefono_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El número de telefono del Proveedor es requerido");
                                                                this.txt_telefono_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_nombre_contacto.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El código de Responsable de Destino es requerido");
                                                                this.txt_nombre_contacto.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_fecha_aprox_reingreso.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La fecha aproximada de reingreso es requerida");
                                                                this.txt_fecha_aprox_reingreso.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            //GPE 12/07/2013 WAT_Document new stuff # 11
                                                            else
                                                            {
                                                                try
                                                                {
                                                                    DateTime date = DateTime.ParseExact(txt_fecha_aprox_reingreso.Text.Trim(), "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);

                                                                    TimeSpan difference = date - DateTime.Now.Date;
                                                                    if (difference.TotalDays < 0)
                                                                    {
                                                                        this.crear_mensajes("validation", "La fecha aproximada de reingreso es menor que el de hoy");
                                                                        this.txt_fecha_aprox_reingreso.Focus();
                                                                        result = false;
                                                                        return result;

                                                                    }
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    this.crear_mensajes("validation", "La fecha aproximada de reingreso es menor que el de hoy");
                                                                    this.txt_fecha_aprox_reingreso.Focus();
                                                                    result = false;
                                                                    return result;
                                                                }
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_direccion_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La direccion del Proveedor es requerida");
                                                                this.txt_direccion_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            //GPE 3/31/2014 Calibración observaciones should NOT be obligatory
                                                            //if (string.IsNullOrEmpty(this.txt_observaciones_calibracion.Text))
                                                            //{
                                                            //    this.crear_mensajes("validation", "Escriba las observaciones.");
                                                            //    this.txt_observaciones_calibracion.Focus();
                                                            //    result = false;
                                                            //    return result;
                                                            //}
                                                            string codigo_localizacion = new cls_traslado().codigo_localizacion(this.txt_cod_centro_costo.Text);
                                                            if (string.IsNullOrEmpty(codigo_localizacion) || codigo_localizacion == "0")
                                                            {
                                                                this.crear_mensajes("validation", "El centro de costo no esta asociado a una localización");
                                                                this.txt_cod_centro_costo.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                        }
                                                        if (seccion == 4)
                                                        {
                                                            if (string.IsNullOrEmpty(this.txt_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El nombre del Proveedor es requerido");
                                                                this.txt_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_cedula_juridica.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La Cédula Jurídica del Proveedor es requerida");
                                                                this.txt_cedula_juridica.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_telefono_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El número de telefono del Proveedor es requerido");
                                                                this.txt_telefono_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_nombre_contacto.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El código de Responsable de Destino es requerido");
                                                                this.txt_nombre_contacto.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_fecha_aprox_reingreso.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La fecha aproximada de reingreso es requerida");
                                                                this.txt_fecha_aprox_reingreso.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_direccion_proveedor.Text))
                                                            {
                                                                this.crear_mensajes("validation", "La direccion del Proveedor es requerida");
                                                                this.txt_direccion_proveedor.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_observaciones_calibracion.Text))
                                                            {
                                                                this.crear_mensajes("validation", "Escriba las observaciones.");
                                                                this.txt_observaciones_calibracion.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            string codigo_localizacion = new cls_traslado().codigo_localizacion(this.txt_cod_centro_costo.Text);
                                                            if (string.IsNullOrEmpty(codigo_localizacion) || codigo_localizacion == "0")
                                                            {
                                                                this.crear_mensajes("validation", "El centro de costo no esta asociado a una localización");
                                                                this.txt_cod_centro_costo.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                        }
                                                        if (seccion == 5 || seccion == 7)
                                                        {
                                                            if (string.IsNullOrEmpty(this.txt_codigo_centro_costo_destino.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El código de Centro de Costo de Destino es requerido");
                                                                this.txt_codigo_centro_costo_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (!this.validar_centro_costo(this.txt_codigo_centro_costo_destino.Text.Trim()))
                                                            {
                                                                this.crear_mensajes("validation", "Revisar información de Centro de Costo de Destino");
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(new cls_traslado().correo_responsable(this.txt_codigo_centro_costo_destino.Text)))
                                                            {
                                                                this.crear_mensajes("validation", "El responsable asociado al Centro de Costo Destino no posee Dirección Electronica");
                                                                this.txt_codigo_centro_costo_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_cod_responsable_destino.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El código de Responsable de Destino es requerido");
                                                                this.txt_cod_responsable_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (!this.validar_solicitante(this.txt_cod_responsable_destino.Text.Trim()))
                                                            {
                                                                this.crear_mensajes("validation", "Revisar información de Responsable de Destino");
                                                                this.txt_cod_responsable_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_nombre_centro_costo_destino.Text))
                                                            {
                                                                this.crear_mensajes("validation", "Seleccione el Centro de Costo de Destino");
                                                                this.txt_nombre_centro_costo_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_nombre_responsable_destino.Text))
                                                            {
                                                                this.crear_mensajes("validation", "Seleccione al Responsable de Destino");
                                                                this.txt_nombre_responsable_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (this.ddl_localizacion_destino.SelectedIndex == 0)
                                                            {
                                                                this.crear_mensajes("validation", "Seleccione la Localización de Destino");
                                                                this.ddl_localizacion_destino.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                        }
                                                        if (seccion == 6)
                                                        {
                                                            if (string.IsNullOrEmpty(this.txt_num_proceso.Text))
                                                            {
                                                                this.crear_mensajes("validation", "El número de Proceso del OIJ es requerido");
                                                                this.txt_num_proceso.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                            if (string.IsNullOrEmpty(this.txt_observaciones_denuncia.Text))
                                                            {
                                                                this.crear_mensajes("validation", "Escriba las Observaciones, necesarias.");
                                                                this.txt_observaciones_denuncia.Focus();
                                                                result = false;
                                                                return result;
                                                            }
                                                        }
                                                        result = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        private void insertar_bitacora(string paso_aprobacion_actual, string descripcion)
        {
            try
            {
                new cls_bitacora().insertar_bitacora(this.asignar_valores_bitacora(paso_aprobacion_actual, descripcion));
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.Message);
            }
        }
        private ent_traslado asignar_valores_bitacora(string paso_aprobacion_actual, string descripcion)
        {
            return new ent_traslado
            {
                id_movimiento = System.Convert.ToInt32(this.txt_num_solicitud.Text),
                codigo_compania = this.Session["CODIGO_COMPANIA"].ToString(),
                usuario = this.Session["USUARIO"].ToString(),
                fecha = System.DateTime.Now,
                descripcion = descripcion,
                paso_aprobacion_actual = paso_aprobacion_actual,
                descripcion_tipo_movimiento = this.ddl_tipo_movimiento.SelectedItem.ToString()
            };
        }
        private string crear_html(int id_movimiento)
        {
            string result;
            try
            {
                string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Mail.htm"));
                contenido = contenido.Replace("[NOMBRE_TIPO_MOVIMIENTO]", this.ddl_tipo_movimiento.SelectedItem.ToString());
                contenido = contenido.Replace("[ID_MOVIMIENTO]", this.txt_num_solicitud.Text);
                contenido = contenido.Replace("[NOMBRE_SOLICITANTE]", this.txt_nombre_solicitante.Text);
                contenido = contenido.Replace("[DEPARTAMENTO_ACTUAL]", this.txt_des_centro_costo.Text);
                contenido = contenido.Replace("[CENTRO_COSTO_ACTUAL]", this.txt_cod_centro_costo.Text);
                contenido = contenido.Replace("[VALOR_LIBROS]", new cls_traslado().valor_libros(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.txt_num_solicitud.Text)).ToString("C2"));
                contenido = contenido.Replace("[PLANTA_1]", new cls_traslado().nombre_localizacion(this.txt_cod_centro_costo.Text));
                contenido = contenido.Replace("[UBICACION_ACTUAL]", new cls_traslado().cargar_ubicacion_actual(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.txt_num_solicitud.Text)));
                //GPE 12/07/2013 WAT_Document new stuff # 15 c
                System.Data.DataTable dtcentro = new cls_traslado().cargar_centro_costo(this.txt_cod_centro_costo.Text.Trim());
                if (dtcentro.Rows.Count > 0)
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", dtcentro.Rows[0]["CENTRO_COSTO"].ToString());
                else
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", string.Empty);
                
                int id_tipo_movimiento = new cls_traslado().id_tipo_movimiento(id_movimiento, this.Session["CODIGO_COMPANIA"].ToString());
                if (id_tipo_movimiento == 5 || id_tipo_movimiento == 7)
                {
                    contenido = contenido.Replace("[PLANTA_2]", this.txt_localizacion_solicitud.Text);
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", this.txt_codigo_centro_costo_destino.Text);
                    contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", string.Concat(new string[]
					{
						this.txt_localizacion_solicitud.Text,
						" ",
						this.txt_seccion_solicitud.Text,
						" ",
						this.txt_ubicacion_solicitud.Text
					}));
                }
                else
                {
                    contenido = contenido.Replace("[PLANTA_2]", "");
                    contenido = contenido.Replace("Departamento Receptor", "");
                    contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", "");
                    contenido = contenido.Replace("Centro de Costo Receptor", "");
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", "");
                }
                if (id_movimiento == -1)
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "La solicitud fue cancelada");
                    contenido = contenido.Replace("[URL]", "#");
                }
                else
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "Ingreso para Aprobación ó Cancelación");
                    //GPE 12.09.2013 change string navigate_url = "http://cylmult12//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + this.Session["CODIGO_COMPANIA"].ToString() + "&id_movimiento=" + id_movimiento.ToString();
                    string navigate_url = string.Format("{0}/wbfrm_login.aspx/?codigo_compania={1}&id_movimiento={2}", HttpTools.HttpUrlPath, this.Session["CODIGO_COMPANIA"].ToString(), id_movimiento.ToString());
                    contenido = contenido.Replace("[URL]", navigate_url);
                }
                result = contenido;
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }
        private string crear_html_shipping(int id_movimiento)
        {
            string result;
            try
            {
                string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Shipping.htm"));
                contenido = contenido.Replace("[NOMBRE_TIPO_MOVIMIENTO]", this.ddl_tipo_movimiento.SelectedItem.ToString());
                contenido = contenido.Replace("[ID_MOVIMIENTO]", this.txt_num_solicitud.Text);
                contenido = contenido.Replace("[NOMBRE_SOLICITANTE]", this.txt_nombre_solicitante.Text);
                contenido = contenido.Replace("[DEPARTAMENTO_ACTUAL]", this.txt_des_centro_costo.Text);
                contenido = contenido.Replace("[CENTRO_COSTO_ACTUAL]", this.txt_cod_centro_costo.Text);
                contenido = contenido.Replace("[VALOR_LIBROS]", new cls_traslado().valor_libros(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.txt_num_solicitud.Text)).ToString("C2"));
                contenido = contenido.Replace("[PLANTA_1]", new cls_traslado().nombre_localizacion(this.txt_cod_centro_costo.Text));
                contenido = contenido.Replace("[UBICACION_ACTUAL]", new cls_traslado().cargar_ubicacion_actual(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.txt_num_solicitud.Text)));
                //GPE 12/07/2013 WAT_Document new stuff # 15 c
                System.Data.DataTable dtcentro = new cls_traslado().cargar_centro_costo(this.txt_cod_centro_costo.Text.Trim());
                if (dtcentro.Rows.Count > 0)
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", dtcentro.Rows[0]["CENTRO_COSTO"].ToString());
                else
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]",string.Empty);
              
                
                int id_tipo_movimiento = new cls_traslado().id_tipo_movimiento(id_movimiento, this.Session["CODIGO_COMPANIA"].ToString());
                if (id_tipo_movimiento == 5 || id_tipo_movimiento == 7)
                {
                    contenido = contenido.Replace("[PLANTA_2]", this.txt_localizacion_solicitud.Text);
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", this.txt_codigo_centro_costo_destino.Text);
                    contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", string.Concat(new string[]
					{
						this.txt_localizacion_solicitud.Text,
						" ",
						this.txt_seccion_solicitud.Text,
						" ",
						this.txt_ubicacion_solicitud.Text
					}));
                }
                else
                {
                    contenido = contenido.Replace("[PLANTA_2]", "");
                    contenido = contenido.Replace("Departamento Receptor", "");
                    contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", "");
                    contenido = contenido.Replace("Centro de Costo Receptor", "");
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", "");
                }
                if (id_movimiento == -1)
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "La solicitud fue cancelada");
                    contenido = contenido.Replace("[URL]", "#");
                }
                else
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "Ingreso para Aprobación ó Cancelación");
                    //GPE 12.09.2013 change string navigate_url = "http://cylmult12//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + this.Session["CODIGO_COMPANIA"].ToString() + "&id_movimiento=" + id_movimiento.ToString();
                    string navigate_url = string.Format("{0}/wbfrm_login.aspx/?codigo_compania={1}&id_movimiento={2}", HttpTools.HttpUrlPath, this.Session["CODIGO_COMPANIA"].ToString(), id_movimiento.ToString());
                    contenido = contenido.Replace("[URL]", navigate_url);
                }
                string items_table = "<table style=\"width: 800px;border: 1px solid #000;border-collapse: collapse;\"><tr>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Placa</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Activo SAP</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción del Activo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Marca</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Modelo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Serie</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Valor Libros</span></td>\r\n                    </tr>";
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt_activos = activos.cargar_activos_grid(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"]));
                for (int x = 0; x < dt_activos.Rows.Count; x++)
                {
                    items_table = items_table + "<tr><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["PLA_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["REF_NUM_ACT"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_MARCA"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["NOM_MODELO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["SER_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["VAL_LIBROS"].ToString();
                    items_table += "</td></tr>";
                }
                //Add BY GPE 3/12/2014 point.13 doc. After my visit
                items_table = items_table + "<tr><td style=\"border: 1px solid #000;\"> &nbsp";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\"> &nbsp";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\"> &nbsp";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\"> &nbsp";
                items_table = items_table + "</td><td colspan=\"2\" style=\"border: 1px solid #000;\">Total Valor en Libros :";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + new cls_traslado().valor_libros(this.Session["CODIGO_COMPANIA"].ToString(), System.Convert.ToInt32(this.txt_num_solicitud.Text)).ToString("C2");
                items_table += "</td></tr>";
     
                items_table += "</table>";
                string items_table_historico = "<table style=\"width: 800px;border: 1px solid #000;border-collapse: collapse;\"><tr>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Fecha</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Paso Aprobación</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Usuario</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripcion Tipo de Movimiento</span></td>\r\n                    </tr>";
                cls_bitacora historico = new cls_bitacora();
                System.Data.DataTable dt_historico = historico.cargar_bitacora(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"]));
                for (int x = 0; x < dt_historico.Rows.Count; x++)
                {
                    items_table_historico = items_table_historico + "<tr><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["FECHA"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["PASO_APROVACION_ACTUAL"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["USUARIO"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION_TIPO_MOVIMIENTO"].ToString();
                    items_table_historico += "</td></tr>";
                }
                items_table_historico += "</table>";
                contenido = contenido.Replace("[LISTA_ACTIVOS]", items_table);
                contenido = contenido.Replace("[HISTORICO]", items_table_historico);
                result = contenido;
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }
        private bool enviar_correo(int id_movimiento, string to)
        {
            bool result;
            try
            {
                if (!string.IsNullOrEmpty(to))
                    result = new cls_correo().enviar_correo(to, this.crear_html(id_movimiento), true, "Correo - Activos - ", cls_configuracion.From, cls_configuracion.Host, cls_configuracion.Port, cls_configuracion.Password, cls_configuracion.SSL);
                else
                    result = false;
            }
            catch (System.Exception)
            {
                result = false;
                //throw;
            }
            //GPE 4/8/2014 WAT-04052014 Point 3
            //if(result)
            //    this.crear_mensajes("success", "Solicitud enviada con éxito");
            //else
            if (!result)
                this.crear_mensajes("error", "No se pudo enviar la solicitud");

            return result;
        }
        private bool enviar_correo_shipping(int id_movimiento, string to)
        {
            bool result;
            try
            {
                if (!string.IsNullOrEmpty(to))
                    result = new cls_correo().enviar_correo(to, this.crear_html_shipping(id_movimiento), true, "Correo - Activos - ", cls_configuracion.From, cls_configuracion.Host, cls_configuracion.Port, cls_configuracion.Password, cls_configuracion.SSL);
                else
                    result = false;
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }
        private void enviar_solicitud_correo(int id_movimiento, string id_compania)
        {
            System.Data.DataTable dt_informacion = new cls_traslado().cargar_informacion_movimiento(id_movimiento, id_compania);
            string paso_aprobacion = string.Empty;
            int id_tipo_movimiento = System.Convert.ToInt32(dt_informacion.Rows[0]["ID_TIPO_MOVIMIENTO"]);
            int paso_aprobacion_actual = System.Convert.ToInt32(dt_informacion.Rows[0]["ID_PASO_APROBACION"]);
            if (dt_informacion.Rows[0]["ESTADO"].ToString().Equals("P"))
            {
                System.Data.DataTable dt = new cls_traslado().cargar_tipo_movimiento();
                if (id_tipo_movimiento == 1)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Solicitud de Donaciòn";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(1, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Centro de Costo";
                            break;
                        case 2:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Recursos Humanos";
                            break;
                        case 3:
                            this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Fixed Asset";
                            break;
                    }
                }
                if (id_tipo_movimiento == 2)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Solicitud de Destrucciòn";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Centro de Costo";
                            break;
                        case 2:
                            this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Fixed Assets";
                            break;
                    }
                }
                if (id_tipo_movimiento == 3)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            //CHANGE BY GPE 3/16/2014 point.11 doc. After my visit
                            //this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(this.acceso_localizacion(), this.txt_cod_centro_costo.Text));
                              this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(6, this.txt_cod_centro_costo.Text));
                              paso_aprobacion = "Solicitud de Calibraciòn";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Responsable de Planta";
                            break;
                        case 2:
                            this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Fixed Asset";
                            break;
                    }
                }
                if (id_tipo_movimiento == 4)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Solicitud de Mantenimiento";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Centro de Costo";
                            break;
                        case 2:
                            this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Fixed Assets";
                            this.cambiar_estado(id_movimiento, "04", false);
                            break;
                    }
                }
                if (id_tipo_movimiento == 5)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Solicitud de Movimiento de Activos";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Responsable Centro de Costo Origen";
                            break;
                        case 2:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_codigo_centro_costo_destino.Text));
                            paso_aprobacion = "Fixed Asset";
                            break;
                    }
                }
                if (id_tipo_movimiento == 6)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Solicitud de Denuncia Robo ò Perdida";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(2, this.txt_cod_centro_costo.Text));
                            paso_aprobacion = "Centro de Costo";
                            break;
                    }
                }
                if (id_tipo_movimiento == 7)
                {
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_cod_centro_costo.Text));
                            //GPE 12/07/2013 WAT_Document new stuff # 13 Send email on ID Solicitante
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_solicitante(this.txt_cod_solicitante .Text));
                            paso_aprobacion = "Solicitud de Movimiento de Activos";
                            break;
                        case 1:
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_responsable(this.txt_codigo_centro_costo_destino.Text));
                            //GPE 12/07/2013 WAT_Document new stuff # 13 Send email on ID Solicitante
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_solicitante(this.txt_cod_solicitante.Text));
                            paso_aprobacion = "Responsable Centro de Costo Origen";
                            break;
                        case 2:
                            if (this.txt_localizacion_solicitud.Text.Trim() == "M420")
                            {
                                this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(5, this.txt_cod_centro_costo.Text));
                            }
                            else
                            {
                                if (this.txt_localizacion_solicitud.Text.Trim() == "M480")
                                {
                                    this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(4, this.txt_cod_centro_costo.Text));
                                }
                            }
                            //GPE 12/07/2013 WAT_Document new stuff # 13 Send email on ID Solicitante
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_solicitante(this.txt_cod_solicitante.Text));
                            paso_aprobacion = "Responsable Centro de Costo Destino";
                            break;
                        case 3:
                            this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                            if (this.txt_localizacion_solicitud.Text.Trim() == "M420")
                            {
                                this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(4, this.txt_cod_centro_costo.Text));
                            }
                            else
                            {
                                if (this.txt_localizacion_solicitud.Text.Trim() == "M480")
                                {
                                    this.enviar_correo(id_movimiento, new cls_traslado().cargar_cuenta_correo(5, this.txt_cod_centro_costo.Text));
                                }
                            }
                            //GPE 12/07/2013 WAT_Document new stuff # 13 Send email on ID Solicitante
                            this.enviar_correo(id_movimiento, new cls_traslado().correo_solicitante(this.txt_cod_solicitante.Text));
                            paso_aprobacion = "Fixed Asset Origen";
                            break;
                    }
                }
                this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
            }
            if (dt_informacion.Rows[0]["ESTADO"].ToString().Equals("A"))
            {
                System.Data.DataTable dt = new cls_traslado().cargar_tipo_movimiento();
                if (id_tipo_movimiento == 1)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 3)
                    {
                        paso_aprobacion = "Fixed Asset";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                    }
                }
                if (id_tipo_movimiento == 2)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 2)
                    {
                        paso_aprobacion = "Fixed Asset";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                    }
                }
                if (id_tipo_movimiento == 3)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 2)
                    {
                        paso_aprobacion = "Fixed Assets";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                    }
                }
                if (id_tipo_movimiento == 4)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 2)
                    {
                        paso_aprobacion = "Fixed Assets";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.cambiar_estado(id_movimiento, "04", false);
                        this.enviar_correo_shipping(id_movimiento, new cls_traslado().cargar_cuenta_correo(3, this.txt_cod_centro_costo.Text));
                    }
                }
                if (id_tipo_movimiento == 5)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 3)
                    {
                        paso_aprobacion = "Responsable Centro de Costo Destino";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.cambio_datos_traslados_activos_aceptados(id_tipo_movimiento);
                    }
                }
                if (id_tipo_movimiento == 6)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 2)
                    {
                        paso_aprobacion = "Fixed Asset";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.cambiar_estado(id_movimiento, "06", true);
                    }
                }
                if (id_tipo_movimiento == 7)
                {
                    int num = paso_aprobacion_actual;
                    if (num == 4)
                    {
                        paso_aprobacion = "Fixed Asset Destino";
                        this.insertar_bitacora(paso_aprobacion, this.txt_observaciones_solicitud.Text);
                        this.cambio_datos_traslados_activos_aceptados(id_tipo_movimiento);
                    }
                }
            }
        }

        protected void btn_grupos_de_acceso_Click(object sender, EventArgs e)
        {
           if(new cls_traslado().is_admin(this.Session["USUARIO"].ToString()))
            {
                    base.Response.Clear();
                    string url = "~/Pages/wbfrm_grupos_de_acceso.aspx";
                    base.Response.Redirect(url, false);
                   
            }
        }

        protected void btn_usuarios_por_grupo_de_acceso_Click(object sender, EventArgs e)
        {
            if (new cls_traslado().is_admin(this.Session["USUARIO"].ToString()))
            {
                base.Response.Clear();
                string url = "~/Pages/wbfrm_usuarios_por_grupo_de_acceso.aspx";
                base.Response.Redirect(url, false);

            }
        }

        //GPE 12/07/2013 WAT_Document new stuff # 14
        private void check_observaciones_obligatory()
        {
            if (!string.IsNullOrEmpty(this.txt_cod_solicitante.Text))
            {
                if (new cls_traslado().check_observaciones_obligatory(this.txt_cod_solicitante.Text.Trim()))
                    div_observaciones_obligatory.Visible = true;
            }
 
        }
        //GPE 12/07/2013 WAT_Document new stuff # 12
        private void centro_costo_status(bool status)
        {
            this.txt_cod_centro_costo.ReadOnly =
                this.txt_des_centro_costo.ReadOnly =
                    this.txt_responsable.ReadOnly = !status;

            //this.btn_buscar_centro_costo.Visible = status;
        }

        private void centro_costo_Empty()
        {
            this.txt_cod_centro_costo.Text =
                this.txt_des_centro_costo.Text =
                    this.txt_responsable.Text = string.Empty;
            //update Felix
            this.txt_cod_solicitante.Text = string.Empty;
            this.txt_nombre_solicitante.Text = string.Empty;

            //this.btn_buscar_centro_costo.Visible = status;
        }
        //GPE 12/07/2013 WAT_Document new stuff # 12
        private void id_solicitante_status(bool status)
        {
            this.txt_cod_solicitante.ReadOnly =
                this.txt_nombre_solicitante.ReadOnly = !status;
        }

        public TextBox GetPostBackControlId(Page page)
        {
            TextBox tb = new TextBox();


            if (!page.IsPostBack)
                return null;

            Control control = null;
            // first we will check the "__EVENTTARGET" because if post back made by the controls
            // which used "_doPostBack" function also available in Request.Form collection.
            string controlName = page.Request.Params["__EVENTTARGET"];
            if (!String.IsNullOrEmpty(controlName))
            {
                control = page.FindControl(controlName);
            }
            else
            {
                // if __EVENTTARGET is null, the control is a button type and we need to
                // iterate over the form collection to find it

                // ReSharper disable TooWideLocalVariableScope
                string controlId;
                Control foundControl;
                // ReSharper restore TooWideLocalVariableScope

                foreach (string ctl in page.Request.Form)
                {
                    // handle ImageButton they having an additional "quasi-property" 
                    // in their Id which identifies mouse x and y coordinates
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        controlId = ctl.Substring(0, ctl.Length - 2);
                        foundControl = page.FindControl(controlId);
                    }
                    else
                    {
                        foundControl = page.FindControl(ctl);
                    }

                    if (!(foundControl is Button || foundControl is ImageButton)) continue;

                    control = foundControl;
                    break;
                }
            }
            if (control.ID != "txt_entrada_placa")
                return new TextBox();

            return control == null ? null : control as TextBox;
        }

        protected void btnSolicitudePendientes_Click(object sender, EventArgs e)
        {
            string url = "~/Pages/wbrfm_solicitudes_pendientes.aspx";
            base.Response.Redirect(url, false);
        }

        protected void PopulateCentroCostoDestino()
        {           
            try
            {
                if (string.IsNullOrEmpty(txt_codigo_centro_costo_destino.Text))
                {
                    if (!string.IsNullOrEmpty(txt_cod_centro_costo.Text))
                    {
                        txt_codigo_centro_costo_destino.Text = txt_cod_centro_costo.Text;
                    }

                }

                if (!string.IsNullOrEmpty(this.txt_codigo_centro_costo_destino.Text.Trim()))
                {
                    cls_traslado centro_costo = new cls_traslado();
                    System.Data.DataTable dt = centro_costo.cargar_centro_costo(this.txt_codigo_centro_costo_destino.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        this.Session["NOMBRE_CENTRO_COSTO_DESTINO"] = dt.Rows[0]["CENTRO_COSTO"].ToString();
                        this.Session["RESPONSABLE"] = new cls_traslado().nombre_responsable(this.txt_codigo_centro_costo_destino.Text.Trim());
                        //GPE 4/8/2014 WAT-04052014 Point 7
                        this.cargar_combo_localizacion(dt.Rows[0]["COD_CIA_PRO"].ToString());
                    }
                    else
                    {
                        this.Session["NOMBRE_CENTRO_COSTO_DESTINO"] = "No encontrado";
                        //GPE 4/8/2014 WAT-04052014 Point 7
                        this.cargar_combo_localizacion();
                    }
                    string script = "$(\"[id*='txt_nombre_centro_costo_destino']\").val('{0}');$(\"[id*='txt_cargo_responsable_costo_destino']\").val('{1}');";
                    script = string.Format(script, this.Session["NOMBRE_CENTRO_COSTO_DESTINO"].ToString(), this.Session["RESPONSABLE"].ToString());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);
                }               
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }

        private void LimpiarControles()
        {
            this.ddl_localizacion_destino.Items.Clear();
            this.ddl_seccion_destino.Items.Clear();
            this.ddl_planta_destino.Items.Clear();
            ListItem first = new ListItem("Seleccione la Localización", "0");
            this.ddl_localizacion_destino.Items.Add(first);
            this.txt_codigo_centro_costo_destino.Text = "";
            this.txt_nombre_centro_costo_destino.Text = "";
        }
        
    }
}
