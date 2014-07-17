using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAssetsTransfer.Functions;
using WebAssetsTransfer.Helper;

namespace WebAssetsTransfer.Pages
{
    public partial class wbrfm_solicitudes_pendientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["CODIGO_COMPANIA"] == null)
            {
                base.Response.Redirect("../wbfrm_login.aspx");
            }

            if (!base.IsPostBack)
            {
                string usuario = this.Session["USUARIO"].ToString();

                PopulateInformation(usuario);
                
               
            }
        }

        private void PopulateInformation(string usuario)
        {
            List<ent_bitacora> list_bitacora = new List<ent_bitacora>();
            
            StringBuilder sb = new StringBuilder();


            try
            {
                var all_pendingrequest = new cls_solicitudes_pendientes().get_pending_request_by_ID(this.Session["CODIGO_COMPANIA"].ToString());
                if (all_pendingrequest.Rows.Count > 0)
                {
                    foreach (DataRow row in all_pendingrequest.Rows)
                    {
                        if(this.estado_link(Convert.ToInt32(row["ID_MOVIMIENTO"]), usuario))
                        {
                          ent_bitacora bitacora = new cls_solicitudes_pendientes().get_pending_last_from_bitacora(Convert.ToInt32(row["ID_MOVIMIENTO"]));

                          if (bitacora != null)
                              list_bitacora.Add(bitacora);
                        }
                    }

                    if (list_bitacora.Count > 0)
                    {
                        int i = 0;
                      
                        foreach (ent_bitacora bit in list_bitacora)
                        {
                            //GPE 4/6/2014 WAT-04052014 Point 1
                            string navigate_url = string.Format("{0}/Pages/wbfrm_traslado_activo.aspx?codigo_compania={1}&id_movimiento={2}", HttpTools.HttpUrlPath, bit.COD_COMPANIA.ToString().Trim(), bit.ID_MOVIMIENTO.ToString().Trim()); //cls_configuracion.NavigateURL
                               // + "//WebAssetsTransfer"
                              //  + "/Pages/wbfrm_traslado_activo.aspx?codigo_compania="
                              //  + bit.COD_COMPANIA.ToString().Trim()
                              //  + "&id_movimiento=" + bit.ID_MOVIMIENTO.ToString().Trim();
                            if(i%2 == 0)
                                sb.Append("<TR class=\"RowStyleGrid\">\n");
                            else
                                sb.Append("<TR class=\"AlternatingRowStyleGrid\">\n");
                            //Código Movimiento
                            sb.Append("<TD>");
                            sb.Append(bit.ID_MOVIMIENTO.ToString());
                            sb.Append("</TD>");
                            //Usuario
                            sb.Append("<TD>");
                            sb.Append(bit.USUARIO);
                            sb.Append("</TD>");
                            //Descripcion Paso aprobación
                            sb.Append("<TD>");
                            sb.Append(bit.DESCRIPCION_TIPO_MOVIMIENTO);
                            sb.Append("</TD>");
                            //Paso aprobación
                            sb.Append("<TD>");
                            sb.Append(bit.PASO_APROBACION);
                            sb.Append("</TD>");
                            //LINK
                            sb.Append("<TD>");
                            sb.Append("<a href=\"");
                            sb.Append(navigate_url);
                            //sb.Append("\" target=\"_blank\">Aprobar</a>");
                            sb.Append("\">Aprobar</a>");

                            sb.Append("</TD>");

                            sb.Append("</TR>\n");
                            i++;
                        }
                        
                        tbodyPendingRequest.InnerHtml = sb.ToString();
                    }
                    else
                    {
                        this.crear_mensajes("info", "No hay solicitudes pendientes");    
                    }

                }
                else
                {
                    this.crear_mensajes("info", "No hay solicitudes pendientes");
                }
            }
            catch (System.Exception ex)
            {
                this.crear_mensajes("error", ex.ToString());
            }
        }

        protected bool estado_link(int id_movimiento, string usuario)
        {
            /*cls_bitacora datos = new cls_bitacora();
            System.Data.DataTable dt = datos.cargar_bitacora_por_usuario(id_movimiento, usuario);
            return dt.Rows.Count <= 0;*/
            bool resultado = false;
            int id_grupo = 0;
            string centro_costo = "nulo";
            int tipo_movimiento = 0;

            cls_movimiento_maestro movimientos = new cls_movimiento_maestro();
            DataTable dtMovimientos = movimientos.cargar_movimientos_maestro(id_movimiento);

            if (dtMovimientos.Rows.Count > 0)
            {
                tipo_movimiento = (int)dtMovimientos.Rows[0][2];
                int paso_aprobacion_actual = (int)dtMovimientos.Rows[0][1];
                centro_costo = (string)dtMovimientos.Rows[0][3];
                id_grupo = obtenerIdGrupo(tipo_movimiento, paso_aprobacion_actual);
            }

            if (id_grupo == 0)
            {
                //Falta una verificacion de si el usuario en el caso de ser calibración tiene los permisos para ejecutar el paso de movimiento
                if (tipo_movimiento == 3)
                {
                    cls_usuarios_por_grupo_de_acceso usuario_grupo = new cls_usuarios_por_grupo_de_acceso();
                    DataTable dt = usuario_grupo.select_usuario_por_grupo_de_acceso(6, this.Session["CODIGO_COMPANIA"].ToString(), usuario);
                    if (dt.Rows.Count > 0)
                    {
                        return dt.Rows.Count > 0;
                    }
                }


                //Verifica si es el dueño del centro de costo
                cls_traslado centroCosto = new cls_traslado();
                DataTable dtCentroCosto = centroCosto.obtener_responsable(this.Session["USUARIO"].ToString(), centro_costo);
                return dtCentroCosto.Rows.Count > 0;

            }
            else if (id_grupo > 0)
            {
                cls_usuarios_por_grupo_de_acceso usuario_grupo = new cls_usuarios_por_grupo_de_acceso();
                DataTable dt = usuario_grupo.select_usuario_por_grupo_de_acceso(id_grupo, this.Session["CODIGO_COMPANIA"].ToString(), usuario);
                return dt.Rows.Count > 0;
            }

            return resultado;
        }

        private int obtenerIdGrupo(int tipo_movimiento, int paso_aprobacion_actual)
        {
            switch (tipo_movimiento)
            {
                case 1:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0; //Le toca al centro de costos aprobar
                        case 1:
                            return 1;//Le toca aprobar a Recursos humanos
                        case 2:
                            return 2;//Le toca aprobar a finanzas
                        case 3:
                            return -1;//Ya se finalizó el ciclo se retorna menos 1 para que se revise la bitacora
                    }
                    break;
                case 2:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//Le toca al centro de costos aprobar
                        case 1:
                            return 2;//Le toca aprobar a finanzas
                        case 2:
                            return -1;//Finaliza ciclo
                    }
                    break;
                case 3:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//puede aprobar el centro de costo
                        case 1:
                            return 2;//Aprueba finanzas
                        case 2:
                            return -1;//Finaliza ciclo
                    }
                    break;
                case 4:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//Aprueba centro de costo
                        case 1:
                            return 2;//Aprueba finanzas
                        case 2:
                            return -1;//Finaliza ciclo
                    }
                    break;
                case 5:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//Aprueba centro de costos origen
                        case 1:
                            return 0;//Aprueba centro costos destino
                        case 2:
                            return 2;//Aprueba finanzas
                        case 3:
                            return -1;//Finaliza ciclo
                    }
                    break;
                case 6:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//Aprueba centro de costos origen
                        case 1:
                            return 2;//Aprueba finanzas
                        case 2:
                            return -1;//Finaliza ciclo
                    }
                    break;
                case 7:
                    switch (paso_aprobacion_actual)
                    {
                        case 0:
                            return 0;//Aprueba centro de costos origen
                        case 1:
                            return 0;//Aprueba centro costos destino
                        case 2:
                            return 2;//Aprueba finanzas origen
                        case 3:
                            return -1;//Finaliza el ciclo
                    }
                    break;
                default:
                    return -1;
            }
            return -1;
        }

        public void crear_mensajes(string class_mensaje, string texto_mensaje)
        {
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";
            createDiv.Attributes["class"] = class_mensaje;
            createDiv.InnerHtml = texto_mensaje;
            this.div_mensaje.Controls.Add(createDiv);
        }

        protected void img_btn_back_new_Click(object sender, ImageClickEventArgs e)
        {
            string url = "~/Pages/wbfrm_traslado_activo.aspx";
            base.Response.Redirect(url, false);
        }
    }
}