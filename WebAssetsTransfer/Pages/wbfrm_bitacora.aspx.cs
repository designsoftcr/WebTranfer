using BLL;
using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAssetsTransfer.Functions;
using WebAssetsTransfer.Helper;
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

        protected Button btn_cargar_centro_costo;
        protected Button btn_cargar_solicitante;

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
            //GPE 12/2/2013 new stuff # 15 d
            // this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION", "Descripción", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("FECHA", "Fecha", true));
            //GPE 12/2/2013 new stuff # 15 d
            // this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION_TIPO_MOVIMIENTO", "Tipo de Movimiento", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("USUARIO", "Usuario", true));

            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("DESCRIPCION_TIPO_MOVIMIENTO", "Movimiento", true));
            this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("PASO_APROVACION_ACTUAL", "Paso aprobación", true));
            //this.gv_datos.Columns.Add(new WebAssetsTransfer.Functions.cls_funciones().CreaBoundField("ESTADO", "Estado", true));
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
        private void cargar_grid_filtro(string usuario, int id_movimiento, string cod_centro_costo, string cod_solicitante, string fetcha, string tipo_movimiento)
        {
            try
            {                
                cls_bitacora bitacora = new cls_bitacora();
                System.Data.DataTable dt = bitacora.cargar_bitacora_filtro(usuario, id_movimiento, cod_centro_costo, cod_solicitante, fetcha, tipo_movimiento);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string text = dt.Rows[i]["ESTADO"].ToString();
                        if (text != null)
                        {
                            if (!(text == "A"))
                            {
                                if (!(text == "P"))
                                {
                                    if (text == "C")
                                    {
                                        dt.Rows[i]["ESTADO"] = "Cancelado";
                                    }
                                }
                                else
                                {
                                    dt.Rows[i]["ESTADO"] = "Pendiente";
                                }
                            }
                            else
                            {
                                dt.Rows[i]["ESTADO"] = "Aceptado";
                            }
                        }
                    }
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
            gv_datos.DataSource = null;
            gv_datos.DataBind();
            //GPE 19.09.2013 modified by GPE
            //if (this.validar_datos())
            if(this.validar_datos_filtro())
            {
                this.Session["ID_MOVIMIENTO"] = this.txt_codigo_movimiento.Text;
                this.Session["COD_CENTRO_COSTO_B"] = this.txt_cod_centro_costo.Text;
                this.Session["COD_SOLICITANTE_B"] = this.txt_cod_solicitante.Text;
                this.Session["FETCHA_B"] = this.txt_fecha.Text;
                if (this.ddl_tipo_movimiento.SelectedIndex == 0)
                    this.Session["TIPO_MOVIMIENTO_B"] = "NULL";
                else
                   this.Session["TIPO_MOVIMIENTO_B"] = this.ddl_tipo_movimiento.SelectedItem;

                this.cargar_grid_filtro(
                    this.Session["USUARIO"].ToString(),
                    string.IsNullOrEmpty(this.Session["ID_MOVIMIENTO"].ToString()) ? 0 : Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString()),
                    this.Session["COD_CENTRO_COSTO_B"].ToString(),
                    this.Session["COD_SOLICITANTE_B"].ToString(),
                    this.Session["FETCHA_B"].ToString(),
                    this.Session["TIPO_MOVIMIENTO_B"].ToString()
                    );
                //GPE 19.09.2013 Because there is more the one filter, check does is enter ID_MOVIMIENTO
                if (!string.IsNullOrEmpty(this.Session["ID_MOVIMIENTO"].ToString()))
                {
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
        //add by GPE 19.09.2013
        protected bool validar_datos_filtro()
        {
            bool result = true;
            if (string.IsNullOrEmpty(this.txt_codigo_movimiento.Text) &&
                string.IsNullOrEmpty(this.txt_cod_centro_costo.Text) &&
                string.IsNullOrEmpty(this.txt_cod_solicitante.Text) &&
                string.IsNullOrEmpty(this.txt_fecha.Text) &&
                this.ddl_tipo_movimiento.SelectedIndex == 0
                )
            {
                this.crear_mensajes("validation", "Por favor, filtrar!!!");
                this.gv_datos.DataSource = null;
                this.gv_datos.DataBind();
                return false;
            }

            if (!string.IsNullOrEmpty(this.txt_codigo_movimiento.Text))
            {
                decimal numero;
                if (!decimal.TryParse(this.txt_codigo_movimiento.Text, out numero))
                {
                    this.crear_mensajes("validation", "Formato de Número de Solicitud Incorrecto.");
                    return false;
                }              
            }

            if (!string.IsNullOrEmpty(this.txt_cod_centro_costo.Text))
            {
                decimal numero;
                if (!decimal.TryParse(this.txt_cod_centro_costo.Text, out numero))
                {
                    this.crear_mensajes("validation", "Formato de Número de Centro de Costo Incorrecto.");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(this.txt_cod_solicitante.Text))
            {
                decimal numero;
                if (!decimal.TryParse(this.txt_cod_solicitante.Text, out numero))
                {
                    this.crear_mensajes("validation", "Formato de Número de ID Solicitante Incorrecto.");
                    return false;
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
        //GPE 20.09.2013
        protected void gv_datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PrintReport")
            {
                int Id_Bitacora = Convert.ToInt32(e.CommandArgument);
                print_report(Id_Bitacora);

            }
            else if (e.CommandName == "ExportReport")
            {
                int Id_Bitacora = Convert.ToInt32(e.CommandArgument);
                export_report(Id_Bitacora);
            }

        }

        //GPE 21.09.2013
        public void print_report(int id_bitacora)
        {
            string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Report.htm"));
            string result = new cls_bitacora().Print_Report(id_bitacora, contenido, this.Session["CODIGO_COMPANIA"].ToString(), HttpTools.HttpUrlPath);

            result = result.Replace("\r\n", "");

            StringBuilder sb = new StringBuilder();
            sb.Append("var disp_setting = 'toolbar=yes,location=no,directories=yes,menubar=yes, scrollbars=yes,width=900, height=780, left=100, top=25';");
            sb.Append("var docprint = window.open('about:blank', '_blank', disp_setting);");
            sb.Append("docprint.document.open();");
            sb.Append("docprint.document.write('" + result + "');");          
            sb.Append("docprint.document.close();");
            sb.Append("docprint.print();");
            sb.Append("docprint.close();");

          
            ClientScript.RegisterStartupScript(typeof(Page), "PrintReportCode", "<script type='text/javascript'>"+sb.ToString()+"</script>");
        }

        //GPE 4/20/2014
        public void export_report(int id_bitacora)
        {
            //new cls_excel().CreateAndWriteExcel(cls_configuracion.ExportExcelPath);
            string url = "ExportReport.aspx?id=" + id_bitacora.ToString();
            Response.Write("<script type='text/javascript'>window.open('" + url + "','_blank');</script>");
        }

        protected void btnExportImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = this.Session["USUARIO"].ToString().Trim();
                int id_movimiento = string.IsNullOrEmpty(this.Session["ID_MOVIMIENTO"].ToString().Trim()) ? 0 : Convert.ToInt32(this.Session["ID_MOVIMIENTO"].ToString().Trim());
                string code_centro_costo_B = this.Session["COD_CENTRO_COSTO_B"].ToString().Trim();
                string code_solicitante_b = this.Session["COD_SOLICITANTE_B"].ToString();
                string fetcha_b = this.Session["FETCHA_B"].ToString().Trim();
                string tipo_movimiento = this.Session["TIPO_MOVIMIENTO_B"].ToString().Trim();


                string url = "ExportReportImprimir.aspx?usuario=" + usuario + "&id_movimiento=" + id_movimiento.ToString()
                    + "&code_centro_costo=" + code_centro_costo_B + "&code_solicitante=" + code_solicitante_b
                    + "&fetcha=" + fetcha_b + "&tipomovimiento=" + tipo_movimiento;
                Response.Write("<script type='text/javascript'>window.open('" + url + "','_blank');</script>");
            }
            catch (Exception ex)
            {
                this.crear_mensajes("info", "Registro No Encontrado");
            }
        }

        protected void btn_cargar_centro_costo_Click(object sender, System.EventArgs e)
        {
            try
            {
                //this.Session["RESPONSABLE"] = string.Empty;
                if (!string.IsNullOrEmpty(this.txt_cod_centro_costo.Text.Trim()))
                {
                    cls_traslado centro_costo = new cls_traslado();
                    DataTable dt = new DataTable();
                    dt = centro_costo.cargar_centro_costo(this.txt_cod_centro_costo.Text.Trim());

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.Session["COD_CENTRO_COSTO_B"] = dt.Rows[0]["COD_CENTRO_COSTO"].ToString();
                        this.txt_des_centro_costo.Text = dt.Rows[0]["CENTRO_COSTO"].ToString();
                    }
                    else 
                    {
                        this.Session["COD_CENTRO_COSTO_B"] = "";
                        this.txt_des_centro_costo.Text = "No se encontraron resultados";
                    }
                    /*string script = "$(\"[id*='txt_des_centro_costo']\").val('{0}');";
                    script = string.Format(script, this.txt_des_centro_costo.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);*/
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
                            this.txt_cod_solicitante.Text = dt.Rows[0]["COD_EMPLEADO"].ToString();
                            this.txt_nombre_solicitante.Text = dt.Rows[0]["NOMBRE_EMPLEADO"].ToString();
                    }
                    else 
                    {
                        this.txt_nombre_solicitante.Text = "No se encontraron resultados";
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }

    }
}
