using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;

namespace BLL
{
    public class cls_bitacora
    {
        private BostonEntities db = new BostonEntities();
        public void insertar_bitacora(ent_traslado entidad)
        {
            try
            {
                AFT_MOV_BITACORA movimiento = new AFT_MOV_BITACORA();
                movimiento.CODIGO_BITACORA = (this.db.AFT_MOV_BITACORA.Max((AFT_MOV_BITACORA c) => (int?)c.CODIGO_BITACORA + (int?)1) ?? 1);
                movimiento.ID_MOVIMIENTO = entidad.id_movimiento;
                movimiento.COD_COMPANIA = entidad.codigo_compania;
                movimiento.DESCRIPCION = entidad.descripcion;
                movimiento.FECHA = entidad.fecha;
                movimiento.PASO_APROBACION = entidad.paso_aprobacion_actual;
                movimiento.DESCRIPCION_TIPO_MOVIMIENTO = entidad.descripcion_tipo_movimiento;
                movimiento.USUARIO = entidad.usuario;
                this.db.AddToAFT_MOV_BITACORA(movimiento);
                this.db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable cargar_bitacora(int id_movimiento)
        {
            var movimientos =
                from c in this.db.AFT_MOV_BITACORA
                where c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    ID_CODIGO_COMPANIA = c.COD_COMPANIA,
                    DESCRIPCION = c.DESCRIPCION,
                    FECHA = c.FECHA,
                    PASO_APROVACION_ACTUAL = c.PASO_APROBACION,
                    USUARIO = c.USUARIO,
                    DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO
                };
            return movimientos.AsDataTable();
        }

        //add by GPE 04.24.2014
        public List<AFT_MOV_BITACORA> cargar_bitacora_historico(int id_movimiento)
        {
            List<AFT_MOV_BITACORA> movimientos =
                (from c in this.db.AFT_MOV_BITACORA
                 where c.ID_MOVIMIENTO == id_movimiento
                 select c).ToList();
               
            return movimientos;
        }
        //add by GPE 18.09.2013
        public DataTable cargar_bitacora_filtro(string usuario, int id_movimiento, string cod_centro_costo, string cod_solicitante, string fetcha, string tipo_movimiento)
        {
            
           
                var allList = from c in this.db.AFT_MOV_BITACORA
                          join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                          on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO
                          select new
                          {
                              BITACORA = c,
                              MOVIMIENTOS = d
                          };
                if (!new cls_traslado().is_admin(usuario))
                {
                    allList = allList.Where(a => a.BITACORA.USUARIO == usuario);
                }

            if (id_movimiento > 0)
                allList = allList.Where(a => a.BITACORA.ID_MOVIMIENTO == id_movimiento);

            if (!string.IsNullOrEmpty(fetcha))
            {
            DateTime date = DateTime.ParseExact(fetcha, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
            //DateTime date = Convert.ToDateTime(fetcha);
            DateTime date1 = date.AddDays(1);
            allList = allList.Where(a => a.BITACORA.FECHA > date && a.BITACORA.FECHA < date1);
            }

            if (!string.IsNullOrEmpty(tipo_movimiento) && tipo_movimiento != "NULL")
                allList = allList.Where(a => a.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO == tipo_movimiento);

            if (!string.IsNullOrEmpty(cod_centro_costo) && cod_centro_costo != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.CENTRO_COSTO == cod_centro_costo);

            if (!string.IsNullOrEmpty(cod_solicitante) && cod_solicitante != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.ID_EMPLEADO == cod_solicitante);


            var movimientos =
                from r in allList               
                select new
                {
                    CODIGO_BITACORA = r.BITACORA.CODIGO_BITACORA,
                    ID_MOVIMIENTO = r.BITACORA.ID_MOVIMIENTO,
                    ID_CODIGO_COMPANIA = r.BITACORA.COD_COMPANIA,
                    DESCRIPCION = r.BITACORA.DESCRIPCION,
                    FECHA = r.BITACORA.FECHA,
                    PASO_APROVACION_ACTUAL = r.BITACORA.PASO_APROBACION,
                    USUARIO = r.BITACORA.USUARIO,
                    DESCRIPCION_TIPO_MOVIMIENTO = r.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO
                };
            return movimientos.AsDataTable();
        }

        public DataTable cargar_bitacora_por_usuario(int id_movimiento, string usuario)
        {
            var movimientos =
                from c in this.db.AFT_MOV_BITACORA
                where c.ID_MOVIMIENTO == id_movimiento && c.USUARIO == usuario
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    ID_CODIGO_COMPANIA = c.COD_COMPANIA,
                    DESCRIPCION = c.DESCRIPCION,
                    FECHA = c.FECHA,
                    PASO_APROVACION_ACTUAL = c.PASO_APROBACION,
                    USUARIO = c.USUARIO,
                    DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO
                };
            return movimientos.AsDataTable();
        }
        public bool mantenimiento_aprobado(int id_movimiento, string codigo_compania)
        {
            int count = (
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento && c.ID_TIPO_MOVIMIENTO == 4 && c.ESTADO == "A"
                select c).Count<AFT_MOV_MAESTRO_MOVIMIENTOS>();
            return count > 0;
        }
        public void completar_mantenimiento(int id_movimiento, string codigo_compania)
		{
			using (TransactionScope transaction = new TransactionScope())
			{
				try
				{
					var movimiento_detalle = 
						from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
						where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
						select new
						{
							c.NUM_ACTIVO
						};
					
                    //GPE commented
                  // foreach (<>f__AnonymousType1<string> item in movimiento_detalle)
                    foreach (var item in movimiento_detalle)
					{
						AFM_MAEST_ACTIV maestro_activo = new AFM_MAEST_ACTIV();
						maestro_activo = this.db.AFM_MAEST_ACTIV.First((AFM_MAEST_ACTIV c) => c.COD_COMPANIA == codigo_compania && c.NUM_ACTIVO == item.NUM_ACTIVO);
						maestro_activo.COD_EST_ORI = "01";
						this.db.SaveChanges();
					}
					transaction.Complete();
				}
				catch (Exception)
				{
					throw;
				}
			}           
		}

        //GPE 20.09.2013
        public string Print_Report(int code_bitacora, string contenido, string codigo_compania, string nav_url)
        {
            var list = (from c in this.db.AFT_MOV_BITACORA
                          join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                          on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO
                          
                          join e in this.db.AFM_CATAL_EMPLE
                          on d.ID_EMPLEADO equals e.COD_EMPLEADO

                          join g in this.db.AFM_CENTRO_COSTO
                          on d.CENTRO_COSTO equals g.COD_CEN_CST
                          
                          where c.CODIGO_BITACORA == code_bitacora
                          select new
                          {
                              BITACORA = c,
                              MOVIMIENTOS = d,
                              CENTRO_COSTO = g,
                              CATAL_EMPLE = e
                          }).FirstOrDefault();
                          

            string result;
            try
            {
               // string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Shipping.htm"));
                contenido = contenido.Replace("[NOMBRE_TIPO_MOVIMIENTO]", list.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO);
                contenido = contenido.Replace("[ID_MOVIMIENTO]", list.BITACORA.ID_MOVIMIENTO.ToString());
                contenido = contenido.Replace("[NOMBRE_SOLICITANTE]", list.CATAL_EMPLE.NOM_EMPLEADO);
                contenido = contenido.Replace("[DEPARTAMENTO_ACTUAL]", list.CENTRO_COSTO.DES_CEN_CST);
                contenido = contenido.Replace("[CENTRO_COSTO_ACTUAL]", list.MOVIMIENTOS.CENTRO_COSTO);
                contenido = contenido.Replace("[VALOR_LIBROS]", new cls_traslado().valor_libros(codigo_compania, System.Convert.ToInt32(list.BITACORA.ID_MOVIMIENTO.ToString())).ToString("C2"));
                contenido = contenido.Replace("[PLANTA_1]", new cls_traslado().nombre_localizacion(list.CENTRO_COSTO.COD_CEN_CST));
                contenido = contenido.Replace("[UBICACION_ACTUAL]", new cls_traslado().cargar_ubicacion_actual(codigo_compania, System.Convert.ToInt32(list.BITACORA.ID_MOVIMIENTO.ToString())));
                //GPE 12/07/2013 WAT_Document new stuff # 15 c
                if (!string.IsNullOrEmpty(list.CENTRO_COSTO.DES_CEN_CST))
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", list.CENTRO_COSTO.DES_CEN_CST);
                else
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", string.Empty);
                
                int id_tipo_movimiento = new cls_traslado().id_tipo_movimiento(list.BITACORA.ID_MOVIMIENTO, codigo_compania);
                if (id_tipo_movimiento == 5 || id_tipo_movimiento == 7)
                {
                    //GPE 20.09.2013 need to code
                    //contenido = contenido.Replace("[PLANTA_2]", this.txt_localizacion_solicitud.Text);
                    //contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", this.txt_codigo_centro_costo_destino.Text);
                    //contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", string.Concat(new string[]
                    //{
                    //    this.txt_localizacion_solicitud.Text,
                    //    " ",
                    //    this.txt_seccion_solicitud.Text,
                    //    " ",
                    //    this.txt_ubicacion_solicitud.Text
                    //}));
                }
                else
                {
                    contenido = contenido.Replace("[PLANTA_2]", "");
                    contenido = contenido.Replace("Departamento Receptor", "");
                    contenido = contenido.Replace("[DEPARTAMENTO_RECEPTOR]", "");
                    contenido = contenido.Replace("Centro de Costo Receptor", "");
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", "");
                }
                if (list.BITACORA.ID_MOVIMIENTO == -1)
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "La solicitud fue cancelada");
                    contenido = contenido.Replace("[URL]", "#");
                }
                else
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "Ingreso para Aprobación ó Cancelación");
                    //GPE 12.09.2013 change string navigate_url = "http://cylmult12//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + id_movimiento.ToString();
                    string navigate_url = nav_url + "//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + list.BITACORA.ID_MOVIMIENTO.ToString();
                    contenido = contenido.Replace("[URL]", navigate_url);
                }

                string items_table = "<table style=\"width: 900px;border: 1px solid #000;border-collapse: collapse;\"><tr>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Placa</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Activo SAP</span></td>\r\n<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción del Activo</span></td>\r\n <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Marca</span></td>\r\n<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Modelo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Serie</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Valor Libros</span></td>\r\n                    </tr>";
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt_activos = activos.cargar_activos_grid(codigo_compania, list.BITACORA.ID_MOVIMIENTO);
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
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + new cls_traslado().valor_libros(codigo_compania, System.Convert.ToInt32(list.BITACORA.ID_MOVIMIENTO.ToString())).ToString("C2");
                items_table += "</td></tr>";
      
                items_table += "</table>";
                string items_table_historico = "<table style=\"width: 900px;border: 1px solid #000;border-collapse: collapse;\"><tr>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Fecha</span></td>\r\n<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Paso Aprobación</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Usuario</span></td>\r\n<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;\">Descripcion Tipo de Movimiento</span></td>\r\n</tr>";
                cls_bitacora historico = new cls_bitacora();
                System.Data.DataTable dt_historico = historico.cargar_bitacora(list.BITACORA.ID_MOVIMIENTO);
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
    }
}
