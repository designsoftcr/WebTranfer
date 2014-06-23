using BLL;
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
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (this.Session["CODIGO_COMPANIA"] == null)
            {
                base.Response.Redirect("../wbfrm_login.aspx");
            }
        }
        private void cargar_grid(string estado)
        {
            try
            {
                cls_movimiento_maestro movimiento_maestro = new cls_movimiento_maestro();
                System.Data.DataTable dt = movimiento_maestro.cargar_movimientos_maestro(estado);
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
                this.cargar_grid(this.DDL_ESTADO.SelectedValue);
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
            this.gv_movimiento_maestro.EditIndex = e.NewEditIndex;
            this.cargar_grid(this.DDL_ESTADO.SelectedValue);
        }
        protected void gv_movimiento_maestro_CancelEditing(object sender, GridViewCancelEditEventArgs e)
        {
            this.gv_movimiento_maestro.EditIndex = -1;
            this.cargar_grid(this.DDL_ESTADO.SelectedValue);
        }
        protected void gv_movimiento_maestro_Updating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            ent_traslado movimiento_traslado = new ent_traslado();
            movimiento_traslado.acta = ((TextBox)this.gv_movimiento_maestro.Rows[index].FindControl("txt_acta")).Text.Trim();
            movimiento_traslado.codigo_compania = this.Session["CODIGO_COMPANIA"].ToString();
            movimiento_traslado.id_movimiento = System.Convert.ToInt32(((Label)this.gv_movimiento_maestro.Rows[index].FindControl("lb_codigo_movimiento")).Text.Trim());
            if (new cls_movimiento_maestro().actualizar_movimiento_maestro(movimiento_traslado))
            {
                this.crear_mensajes("success", "Movimiento maestro actualizado correctamente");
            }
            else
            {
                this.crear_mensajes("error", "No se ha podido actualizar el movimiento maestro");
            }
            this.gv_movimiento_maestro.EditIndex = -1;
            this.cargar_grid(this.DDL_ESTADO.SelectedValue);
        }
        protected void btn_consulta_filtrada_Click(object sender, System.EventArgs e)
        {
            this.cargar_grid(this.DDL_ESTADO.SelectedValue);
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
