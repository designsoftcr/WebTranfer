using BLL;
using CapaLog;
using Entidades;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace WebAssetsTransfer.Pages
{
    //GPE add partial
    public partial class wbfrm_movimiento_maestro : Page
    {
        protected HtmlForm form1;
        protected HtmlGenericControl div_mensaje;
        protected Label lb_titulo_filtro;
        protected Label lb_mensaje;
        protected Label lb_movimiento_maestro_estado;
        protected DropDownList DDL_ESTADO;
        protected Button btn_consulta_filtrada;
        protected GridView gv_movimiento_maestro;

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
                //GPE 3/31/2014 show all types of movimientos  
                this.gv_movimiento_maestro.Columns[1].Visible = false;
                this.cargar_combo_tipo_movimiento();
            }
        }
        //GPE 3/31/2014 show all types of movimientos   
        protected void cargar_combo_tipo_movimiento()
        {
            try
            {
                System.Data.DataTable dt = null;
                cls_traslado tipo_movimiento = new cls_traslado();
                cls_usuarios_por_grupo_de_acceso usuario_grupo = new cls_usuarios_por_grupo_de_acceso();
                if (new cls_traslado().is_admin(this.Session["USUARIO"].ToString()) || usuario_grupo.select_usuario_por_grupo_de_acceso(2, this.Session["USUARIO"].ToString()).Rows.Count > 0)
                {
                    dt = tipo_movimiento.cargar_tipo_movimiento();
                }
                else
                {
                    DataTable dtUsuarios = usuario_grupo.select_usuario_por_grupo_de_acceso(6, this.Session["USUARIO"].ToString());
                    if (dtUsuarios.Rows.Count > 0)
                    {
                        dt = tipo_movimiento.cargar_tipo_movimiento(3);
                    }
                }
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
        //Add BY GPE 3/13/2013 point.2 doc. After my visit -- NOT USE
        //private void cargar_grid(string estado)
        //  {
        //    try
        //    {
        //        cls_movimiento_maestro movimiento_maestro = new cls_movimiento_maestro();
        //        System.Data.DataTable dt = movimiento_maestro.cargar_movimientos_maestro(estado);
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string text = dt.Rows[i]["ESTADO"].ToString();
        //                if (text != null)
        //                {
        //                    if (!(text == "A"))
        //                    {
        //                        if (!(text == "P"))
        //                        {
        //                            if (text == "C")
        //                            {
        //                                dt.Rows[i]["ESTADO"] = "Cancelado";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            dt.Rows[i]["ESTADO"] = "Pendiente";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        dt.Rows[i]["ESTADO"] = "Aceptado";
        //                    }
        //                }
        //            }
        //            this.gv_movimiento_maestro.DataSource = dt;
        //            this.gv_movimiento_maestro.DataBind();
        //            this.gv_movimiento_maestro.Visible = true;
        //        }
        //        else
        //        {
        //            this.crear_mensajes("info", "Registro No Encontrado");
        //            this.gv_movimiento_maestro.Visible = false;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        this.crear_mensajes("error", ex.ToString());
        //    }
        //}

        //Add BY GPE 3/13/2013 point.2 doc. After my visit -- USED
        private void cargar_grid(string estado)
        {


            string cod_centro_costo = this.Session["G_CENTRO_COSTO"].ToString(); 
            string cod_solicitante = this.Session["G_ID_SOLICITANTE"].ToString(); 
            //string fetcha = this.Session["G_FETCHA"].ToString();
            string fetcha = "";
            int tipo_movimiento = 0;
            int id_movimiento = 0;

            if(!string.IsNullOrEmpty(this.Session["G_TIPO_MOVIENTO"].ToString()))
               tipo_movimiento = Convert.ToInt32(this.Session["G_TIPO_MOVIENTO"].ToString());
             if(!string.IsNullOrEmpty(this.Session["G_CODIGO_MOVIMIENTO"].ToString()))
                 id_movimiento = Convert.ToInt32(this.Session["G_CODIGO_MOVIMIENTO"].ToString()); 
           
            try
            {
                System.Data.DataTable dt = null;
                cls_movimiento_maestro movimiento_maestro = new cls_movimiento_maestro();
                if (new cls_traslado().is_admin(this.Session["USUARIO"].ToString()))
                {
                    dt = movimiento_maestro.cargar_movimientos_maestro_filtrar(id_movimiento, cod_centro_costo, cod_solicitante, fetcha, tipo_movimiento);
                }
                else
                {
                    DataTable dtUsuarios = new cls_usuarios_por_grupo_de_acceso().select_usuario_por_grupo_de_acceso(6, this.Session["USUARIO"].ToString());
                    if(dtUsuarios.Rows.Count == 1){
                        dt = movimiento_maestro.cargar_movimientos_maestro_filtrar(id_movimiento, cod_centro_costo, cod_solicitante, fetcha, tipo_movimiento, dtUsuarios.Rows[0][2].ToString());
                        }
                    if (dtUsuarios.Rows.Count == 2) {
                        dt = movimiento_maestro.cargar_movimientos_maestro_filtrar(id_movimiento, cod_centro_costo, cod_solicitante, fetcha, tipo_movimiento);
                    }
                }
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
                                    if ((text == "C"))
                                    {
                                        dt.Rows[i]["ESTADO"] = "Cancelado";
                                    }
                                    else {
                                        dt.Rows[i]["ESTADO"] = "Pendiente";
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

                        if (dt.Rows[i]["ID_TIPO_MOVIMIENTO_NUMBER"].ToString().Trim() == "3" || dt.Rows[i]["ID_TIPO_MOVIMIENTO_NUMBER"].ToString().Trim() == "4")
                        {
                            dt.Rows[i]["ACTA"] = "";//"Validacion de Movimiento";
                        }
                    }
                    this.gv_movimiento_maestro.DataSource = dt;
                    this.gv_movimiento_maestro.DataBind();
                    this.gv_movimiento_maestro.Visible = true;
                }
                else
                {
                    this.crear_mensajes("info", "Registro No Encontrado");
                    this.gv_movimiento_maestro.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void gv_movimiento_maestro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.gv_movimiento_maestro.PageIndex = e.NewPageIndex;
                this.cargar_grid(this.ddl_tipo_movimiento.SelectedValue);//this.DDL_ESTADO.SelectedValue);
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }
        protected void gv_movimiento_maestro_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }
        protected void gv_movimiento_maestro_Editing(object sender, GridViewEditEventArgs e)
        {
            //GPE 4/8/2014 WAT-04052014 Point 2
            //this.gv_movimiento_maestro.EditIndex = e.NewEditIndex;
            //this.cargar_grid(this.DDL_ESTADO.SelectedValue);
            int ID_MOV =  Convert.ToInt32((gv_movimiento_maestro.Rows[e.NewEditIndex].FindControl("lb_codigo_movimiento") as Label).Text);
            if (new cls_movimiento_maestro().checkCodMovID_isDonacionOrRetirado(ID_MOV))
            {
                this.gv_movimiento_maestro.EditIndex = e.NewEditIndex;
                this.cargar_grid(this.ddl_tipo_movimiento.SelectedValue);//this.DDL_ESTADO.SelectedValue);
            }


        }
        protected void gv_movimiento_maestro_CancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.gv_movimiento_maestro.EditIndex = -1;
            this.cargar_grid(this.ddl_tipo_movimiento.SelectedValue);//this.DDL_ESTADO.SelectedValue);
        }
        protected void gv_movimiento_maestro_Updating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
            int index = e.RowIndex;
            ent_traslado movimiento_traslado = new ent_traslado();
            movimiento_traslado.acta = ((TextBox)this.gv_movimiento_maestro.Rows[index].FindControl("txt_acta")).Text.Trim();
            string strCOD_EST_ORI = string.Empty;
            if (this.ddl_tipo_movimiento.SelectedValue == "3" || this.ddl_tipo_movimiento.SelectedValue == "4")
            {
                if (((CheckBox)this.gv_movimiento_maestro.Rows[index].FindControl("chbVigente")).Checked == true) {
                    strCOD_EST_ORI = "01";
                }
            }
            movimiento_traslado.codigo_compania = this.Session["CODIGO_COMPANIA"].ToString();
            movimiento_traslado.id_movimiento = System.Convert.ToInt32(((Label)this.gv_movimiento_maestro.Rows[index].FindControl("lb_codigo_movimiento")).Text.Trim());
            if (this.ddl_tipo_movimiento.SelectedValue == "1") {
                strCOD_EST_ORI = "10";
            }else if(this.ddl_tipo_movimiento.SelectedValue=="2"){
                strCOD_EST_ORI = "07";
            }
            if (new cls_movimiento_maestro().actualizar_movimiento_maestro(movimiento_traslado, strCOD_EST_ORI))
            {
                this.crear_mensajes("success", "Movimiento maestro actualizado correctamente");
            }
            else
            {
                this.crear_mensajes("error", "No se ha podido actualizar el movimiento maestro");
            }
            this.gv_movimiento_maestro.EditIndex = -1;
            this.cargar_grid(this.ddl_tipo_movimiento.SelectedValue);//this.DDL_ESTADO.SelectedValue);
            }
            catch (Exception ex)
            {
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
                throw;
            }
        }
        protected void btn_consulta_filtrada_Click(object sender, System.EventArgs e)
        {
            if (this.ddl_tipo_movimiento.SelectedValue == "3" || this.ddl_tipo_movimiento.SelectedValue == "4")
            {
                this.gv_movimiento_maestro.Columns[1].Visible = true;
            }
            else
            {
                this.gv_movimiento_maestro.Columns[1].Visible = false;
            }
            this.Session["G_TIPO_MOVIENTO"] = this.ddl_tipo_movimiento.SelectedValue;
            this.Session["G_CODIGO_MOVIMIENTO"] = this.txt_codigo_movimiento.Text;
            this.Session["G_CENTRO_COSTO"] = this.txt_cod_centro_costo.Text;
            //this.Session["G_FETCHA"] = this.txt_fecha.Text;
            this.Session["G_ID_SOLICITANTE"] = this.txt_cod_solicitante.Text;

             
            this.cargar_grid(this.ddl_tipo_movimiento.SelectedValue);//DDL_ESTADO.SelectedValue);
        }
        public void crear_mensajes(string class_mensaje, string texto_mensaje)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDiv.Attributes["class"] = class_mensaje;
            createDiv.InnerHtml = texto_mensaje;
            this.div_mensaje.Controls.Add(createDiv);
        }

        protected void btnExportMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                string cod_centro_costo = this.Session["G_CENTRO_COSTO"].ToString();
                string cod_solicitante = this.Session["G_ID_SOLICITANTE"].ToString();
                //string fetcha = this.Session["G_FETCHA"].ToString();
                string fetcha = "";
                int tipo_movimiento = 0;
                int id_movimiento = 0;

                if (!string.IsNullOrEmpty(this.Session["G_TIPO_MOVIENTO"].ToString()))
                    tipo_movimiento = Convert.ToInt32(this.Session["G_TIPO_MOVIENTO"].ToString());
                if (!string.IsNullOrEmpty(this.Session["G_CODIGO_MOVIMIENTO"].ToString()))
                    id_movimiento = Convert.ToInt32(this.Session["G_CODIGO_MOVIMIENTO"].ToString());


                string url = "ExportReportMovimiento.aspx?id_movimiento=" + id_movimiento.ToString()
                    + "&cod_centro_costo=" + cod_centro_costo + "&cod_solicitante=" + cod_solicitante
                    + "&fetcha=" + fetcha + "&tipo_movimiento=" + tipo_movimiento.ToString();
                Response.Write("<script type='text/javascript'>window.open('" + url + "','_blank');</script>");
            }
            catch (Exception ex)
            {
                this.crear_mensajes("info", "Registro No Encontrado");
            }
        }

        protected void ddl_tipo_movimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_tipo_movimiento.SelectedValue == "3" || this.ddl_tipo_movimiento.SelectedValue == "4")
            {
                this.gv_movimiento_maestro.Columns[1].Visible = true;
            }
            else
            {
                this.gv_movimiento_maestro.Columns[1].Visible = false;
            }
            btn_consulta_filtrada_Click(sender, e);
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
                        //this.Session["COD_CENTRO_COSTO_B"] = dt.Rows[0]["COD_CENTRO_COSTO"].ToString();
                        //this.txt_des_centro_costo.Text = dt.Rows[0]["CENTRO_COSTO"].ToString();
                    }
                    else
                    {
                        //this.Session["COD_CENTRO_COSTO_B"] = "";
                       // this.txt_des_centro_costo.Text = "No se encontraron resultados";
                    }
                    /*string script = "$(\"[id*='txt_des_centro_costo']\").val('{0}');";
                    script = string.Format(script, this.txt_des_centro_costo.Text);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "filterinfo", script, true);*/
                }
                else 
                {
                   // this.txt_des_centro_costo.Text = "";
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
                       // this.txt_nombre_solicitante.Text = dt.Rows[0]["NOMBRE_EMPLEADO"].ToString();
                    }
                    else
                    {
                       // this.txt_nombre_solicitante.Text = "No se encontraron resultados";
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
