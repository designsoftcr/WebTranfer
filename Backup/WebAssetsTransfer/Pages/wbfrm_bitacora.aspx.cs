using BLL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAssetsTransfer.Functions;
namespace WebAssetsTransfer.Pages
{
    //GPE added partial
    public partial class wbfrm_bitacora : Page
    {
        protected HtmlForm form1;
        protected HtmlGenericControl div_mensaje;
        protected Label lb_titulo_filtro;
        protected Label lb_mensaje;
        protected Label lb_codigo_movimiento;
        protected TextBox txt_codigo_movimiento;
        protected Button btn_realizar_filtrado;
        protected Button btn_completar;
        protected GridView gv_datos;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (this.Session["CODIGO_COMPANIA"] == null)
            {
                base.Response.Redirect("../wbfrm_login.aspx");
            }
            if (!base.IsPostBack)
            {
                this.btn_completar.Visible = false;
                this.crear_columnas_grid();
                this.cargar_combo_tipo_movimiento();
            }
        }
        private void crear_columnas_grid()
        {
            this.lb_titulo_filtro.Text = "Histórico";
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_MOVIMIENTO", "Código Movimiento", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ID_CODIGO_COMPANIA", "Código Compañia", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripción", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("FECHA", "Fecha", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("PASO_APROVACION_ACTUAL", "Paso aprobación", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION_TIPO_MOVIMIENTO", "Tipo de Movimiento", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("USUARIO", "Usuario", true));
        }
        private void cargar_grid(int id_movimiento)
        {
            try
            {
                cls_bitacora bitacora = new cls_bitacora();
                System.Data.DataTable dt = bitacora.cargar_bitacora(id_movimiento);
                if (dt.Rows.Count > 0)
                {
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                else
                {
                    this.crear_mensajes("info", "Registro No Encontrado");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        //add by GPE 18.09.2013
        private void cargar_grid_filtro(int id_movimiento, int cod_centro_costo, int cod_solicitante, string fetcha, string tipo_movimiento)
        {
            try
            {                
                cls_bitacora bitacora = new cls_bitacora();
                System.Data.DataTable dt = bitacora.cargar_bitacora_filtro(id_movimiento, cod_centro_costo, cod_solicitante, fetcha, tipo_movimiento);
                if (dt.Rows.Count > 0)
                {
                    this.gv_datos.DataSource = dt;
                    this.gv_datos.DataBind();
                }
                else
                {
                    this.crear_mensajes("info", "Registro No Encontrado");
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
                this.cargar_grid(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"]));
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void gv_datos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
        protected void btn_completar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.gv_datos.Rows.Count > 0)
                {
                    if (this.validar_datos())
                    {
                        if (this.validar_mantenimiento_aprobado())
                        {
                            new cls_bitacora().completar_mantenimiento(System.Convert.ToInt32(this.txt_codigo_movimiento.Text), this.Session["CODIGO_COMPANIA"].ToString());
                            this.crear_mensajes("success", "El Movimiento ha sido completado");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
            finally
            {
                this.btn_completar.Visible = false;
            }
        }
        private bool validar_mantenimiento_aprobado()
        {
            return new cls_bitacora().mantenimiento_aprobado(System.Convert.ToInt32(this.txt_codigo_movimiento.Text), this.Session["CODIGO_COMPANIA"].ToString());
        }
        protected void btn_realizar_filtrado_Click(object sender, System.EventArgs e)
        {
            if (this.validar_datos())
            {
                //this.Session["ID_MOVIMIENTO"] = this.txt_codigo_movimiento.Text;
                //this.Session["COD_CENTRO_COSTO"] = this.txt_cod_centro_costo.Text;
                //this.Session["COD_SOLICITANTE"] = this.txt_cod_solicitante.Text;
                //this.Session["FETCHA"] = this.txt_fecha.Text;
                //if (this.ddl_tipo_movimiento.SelectedIndex == 0)
                //    this.Session["TIPO_MOVIMIENTO"] = "NULL";
                //else
                //    this.Session["TIPO_MOVIMIENTO"] = this.ddl_tipo_movimiento.SelectedItem;


                string tipo_movimiento = "NULL";
                if (this.ddl_tipo_movimiento.SelectedIndex != 0)
                   tipo_movimiento = this.ddl_tipo_movimiento.SelectedItem.ToString();
             
                //this.cargar_grid(System.Convert.ToInt32(this.Session["ID_MOVIMIENTO"]));
                this.cargar_grid_filtro(Convert.ToInt32(this.txt_codigo_movimiento.Text), 
                    Convert.ToInt32(this.txt_cod_centro_costo.Text),
                    Convert.ToInt32(this.txt_cod_solicitante.Text),
                    this.txt_fecha.Text,
                    tipo_movimiento
                    );
                
                if (this.validar_mantenimiento_aprobado())
                {
                    this.btn_completar.Visible = true;
                }
                else
                {
                    this.btn_completar.Visible = false;
                }
            }
        }
        protected bool validar_datos()
        {
            bool result;
            if (string.IsNullOrEmpty(this.txt_codigo_movimiento.Text))
            {
                this.crear_mensajes("validation", "Numero de Registro es requerido");
                result = false;
            }
            else
            {
                decimal numero;
                if (!decimal.TryParse(this.txt_codigo_movimiento.Text, out numero))
                {
                    this.crear_mensajes("validation", "Formato de Número de Solicitud Incorrecto.");
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
        public void crear_mensajes(string class_mensaje, string texto_mensaje)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDiv.Attributes["class"] = class_mensaje;
            createDiv.InnerHtml = texto_mensaje;
            this.div_mensaje.Controls.Add(createDiv);
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
    }
}
