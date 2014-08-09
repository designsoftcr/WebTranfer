using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Globalization;

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

        public string getNombreUsuario(string cod_solicitante) {
            var empleado =
                from c in this.db.AFM_CATAL_EMPLE
                where c.COD_EMPLEADO == cod_solicitante
                select new
                {
                   NOMBRE = c.NOM_EMPLEADO
                };
            if (empleado.AsDataTable().Rows.Count > 0)
            {
                return empleado.AsDataTable().Rows[0]["NOMBRE"].ToString();
            }
            else {
                return "No encontrado";
            }
        }

        public DataTable cargar_movimiento(int id_movimiento)
        {
            var movimientos =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    PASO_APROVACION_ACTUAL = c.ID_PASO_APROBACION_ACTUAL,
                    COD_SOLICITANTE = c.ID_EMPLEADO,
                    TIPO_MOVIMIENTO = c.ID_TIPO_MOVIMIENTO,
                    CENTRO_COSTO = c.CENTRO_COSTO,
                    FECHA = c.FECHA_MOVIMIENTO,
                    ESTADO = c.ESTADO
                };
                
            return movimientos.AsDataTable();
        }

        public DataTable cargar_bitacora(int id_movimiento)
        {
            var movimientos =
                from c in this.db.AFT_MOV_BITACORA
                join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO
                join mv in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS on d.ID_MOVIMIENTO equals mv.ID_MOVIMIENTO
                where c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    ID_CODIGO_COMPANIA = c.COD_COMPANIA,
                    DESCRIPCION = c.DESCRIPCION,
                    FECHA = c.FECHA,
                    PASO_APROVACION_ACTUAL = c.PASO_APROBACION,
                    USUARIO = c.USUARIO,
                    CENTRO_COSTO = mv.CENTRO_COSTO,
                    DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO,
                    ESTADO = d.ESTADO,
                    TIPO_MOVIMIENTO = d.ID_TIPO_MOVIMIENTO,
                    PASO_ACTUAL = d.ID_PASO_APROBACION_ACTUAL
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
            var empleado = 
                from c in this.db.AFM_CATAL_EMPLE 
                where c.USUARIO_SESION == usuario
                select new 
                {
                    COD_EMPEADO = c.COD_EMPLEADO 
                };
            string id_empleado = "";
            if(empleado.AsDataTable().Rows.Count > 0)
            {
                id_empleado = empleado.AsDataTable().Rows[0][0].ToString();
            }

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
                    allList = allList.Where(a => a.MOVIMIENTOS.ID_EMPLEADO == id_empleado);//a => a.BITACORA.USUARIO == usuario);
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
                    DESCRIPCION_TIPO_MOVIMIENTO = r.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO,
                    CENTRO_COSTO = r.MOVIMIENTOS.CENTRO_COSTO,
                    ESTADO = r.MOVIMIENTOS.ESTADO
                };
            return movimientos.AsDataTable();
        }

        public DataTable cargar_movimiento_filtro(string usuario, int id_movimiento, string cod_centro_costo, string cod_solicitante, /*string fetcha,*/ int tipo_movimiento)
        {
            var empleado =
                from c in this.db.AFM_CATAL_EMPLE
                where c.USUARIO_SESION == usuario
                select new
                {
                    COD_EMPEADO = c.COD_EMPLEADO
                };
            string id_empleado = "";
            if (empleado.AsDataTable().Rows.Count > 0)
            {
                id_empleado = empleado.AsDataTable().Rows[0][0].ToString();
            }

            var allList = from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                          select new
                          {
                              MOVIMIENTOS = c
                          };
            if (!new cls_traslado().is_admin(usuario))
            {
                allList = allList.Where(a => a.MOVIMIENTOS.ID_EMPLEADO == id_empleado);//a => a.BITACORA.USUARIO == usuario);
            }

            if (id_movimiento > 0)
                allList = allList.Where(a => a.MOVIMIENTOS.ID_MOVIMIENTO == id_movimiento);

            /*if (!string.IsNullOrEmpty(fetcha))
            {
                DateTime date = DateTime.ParseExact(fetcha, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime date = Convert.ToDateTime(fetcha);
                DateTime date1 = date.AddDays(1);
                allList = allList.Where(a => a.MOVIMIENTOS.FECHA_MOVIMIENTO > date && a.MOVIMIENTOS.FECHA_MOVIMIENTO < date1);
            }*/

            if (tipo_movimiento != 0)
                allList = allList.Where(a => a.MOVIMIENTOS.ID_TIPO_MOVIMIENTO == tipo_movimiento);

            if (!string.IsNullOrEmpty(cod_centro_costo) && cod_centro_costo != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.CENTRO_COSTO == cod_centro_costo);

            if (!string.IsNullOrEmpty(cod_solicitante) && cod_solicitante != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.ID_EMPLEADO == cod_solicitante);


            var movimientos =
                from r in allList
                select new
                {
                    ID_MOVIMIENTO = r.MOVIMIENTOS.ID_MOVIMIENTO,
                    PASO_APROVACION_ACTUAL = r.MOVIMIENTOS.ID_PASO_APROBACION_ACTUAL,
                    COD_SOLICITANTE = r.MOVIMIENTOS.ID_EMPLEADO,
                    TIPO_MOVIMIENTO = r.MOVIMIENTOS.ID_TIPO_MOVIMIENTO,
                    CENTRO_COSTO = r.MOVIMIENTOS.CENTRO_COSTO,
                    FECHA = r.MOVIMIENTOS.FECHA_MOVIMIENTO,
                    ESTADO = r.MOVIMIENTOS.ESTADO
                };
            return movimientos.AsDataTable();
        }

        public DataTable cargar_bitacora_por_usuario(int id_movimiento, string usuario)
        {
            var movimientos =
                from c in this.db.AFT_MOV_BITACORA 
                join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO
                where c.ID_MOVIMIENTO == id_movimiento && c.USUARIO == usuario
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    ID_CODIGO_COMPANIA = c.COD_COMPANIA,
                    DESCRIPCION = c.DESCRIPCION,
                    FECHA = c.FECHA,
                    PASO_APROVACION_ACTUAL = c.PASO_APROBACION,
                    USUARIO = c.USUARIO,
                    DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO,
                    ESTADO = d.ESTADO
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
        public string Print_Report(int id_movimiento, string contenido, string codigo_compania, string nav_url)
        {
            var movimientos = from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS                          
                          where c.ID_MOVIMIENTO == id_movimiento
                          select new
                          {
                              ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                              COD_SOLICITANTE = c.ID_EMPLEADO,
                              NOMBRE_SOLICITANTE = c.EMPLEADO_RESPONSABLE_CC,
                              CENTRO_COSTO = c.CENTRO_COSTO,
                              DETALLE = c.DETALLE_DESTINO_MOVIMIENTO
                          };

            DataTable dtMovimientos = movimientos.AsDataTable();

            var bitacora = from c in this.db.AFT_MOV_BITACORA                          
                          where c.ID_MOVIMIENTO == id_movimiento
                          select new
                          {
                              DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO
                          };
            
            DataTable dtBitacora = bitacora.AsDataTable();

            string cod_centro_costo_origen = dtMovimientos.Rows[0]["CENTRO_COSTO"].ToString();

            var centroCostoOrigen = from c in this.db.AFM_CENTRO_COSTO
                                    where c.COD_CEN_CST == cod_centro_costo_origen
                                select new
                                {
                                    DESCRIPCION = c.DES_CEN_CST
                                };

            DataTable dtCentroCostoOrigen = centroCostoOrigen.AsDataTable();

            string result;
            try
            {
               // string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Shipping.htm"));
                contenido = contenido.Replace("[NOMBRE_TIPO_MOVIMIENTO]", dtBitacora.Rows[0]["DESCRIPCION_TIPO_MOVIMIENTO"].ToString());
                contenido = contenido.Replace("[ID_MOVIMIENTO]", id_movimiento.ToString());
                contenido = contenido.Replace("[NOMBRE_SOLICITANTE]", dtMovimientos.Rows[0]["NOMBRE_SOLICITANTE"].ToString());
                //contenido = contenido.Replace("[DEPARTAMENTO_ACTUAL]", dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString());
                contenido = contenido.Replace("[CENTRO_COSTO_ACTUAL]", cod_centro_costo_origen);
                contenido = contenido.Replace("[VALOR_LIBROS]", new cls_traslado().valor_libros(codigo_compania, System.Convert.ToInt32(id_movimiento.ToString())).ToString("C2"));
                //contenido = contenido.Replace("[PLANTA_1]", new cls_traslado().nombre_localizacion(dtMovimientos.Rows[0]["CENTRO_COSTO"].ToString()));
                //contenido = contenido.Replace("[UBICACION_ACTUAL]", new cls_traslado().cargar_ubicacion_actual(codigo_compania, id_movimiento));

                DataTable dtUbicacion = new cls_traslado().cargar_ubicacion_actual(System.Convert.ToInt32(id_movimiento));
                if (dtUbicacion.Rows.Count > 0)
                {
                    contenido = contenido.Replace("[LOCALIZACION]", dtUbicacion.Rows[0]["LOCALIZACION"].ToString());
                    contenido = contenido.Replace("[UBICACION]", dtUbicacion.Rows[0]["UBICACION"].ToString());
                    contenido = contenido.Replace("[SECCION]", dtUbicacion.Rows[0]["SECCION"].ToString());
                }
                
                //GPE 12/07/2013 WAT_Document new stuff # 15 c
                if (!string.IsNullOrEmpty(dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString()))
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString());
                else
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", string.Empty);
                
                int id_tipo_movimiento = new cls_traslado().id_tipo_movimiento(id_movimiento, codigo_compania);
                if (id_tipo_movimiento == 5 || id_tipo_movimiento == 7)
                {
                    string cadena = dtMovimientos.Rows[0]["DETALLE"].ToString();
                        string xmlcadena = "<Datos>" + cadena + "</Datos>";
                        System.Xml.Linq.XElement xmldoc = System.Xml.Linq.XElement.Parse(xmlcadena);
                    string localizacion = "";
                    string seccion = "";
                    string ubicacion = "";
                    string centro_costo_destino = "";
                    if(id_tipo_movimiento == 5){
                                    System.Xml.Linq.XElement xml_movimiento_activo = (
                                        from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    centro_costo_destino = System.Convert.ToString(xml_movimiento_activo.Element("CentroCostoDestino").Value);
                                    localizacion = System.Convert.ToString(xml_movimiento_activo.Element("LocalizacionDescripcion").Value);
                                    ubicacion = System.Convert.ToString(xml_movimiento_activo.Element("UbicacionDescripcion").Value);
                                    seccion = System.Convert.ToString(xml_movimiento_activo.Element("SeccionDescripcion").Value);
                                    
                                }
                    if(id_tipo_movimiento == 7){
                        System.Xml.Linq.XElement xml_movimiento_activo_externo = (
                                        from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                                    centro_costo_destino = System.Convert.ToString(xml_movimiento_activo_externo.Element("CentroCostoDestino").Value);
                                    localizacion = System.Convert.ToString(xml_movimiento_activo_externo.Element("LocalizacionDescripcion").Value);
                                    ubicacion = System.Convert.ToString(xml_movimiento_activo_externo.Element("UbicacionDescripcion").Value);
                                    seccion = System.Convert.ToString(xml_movimiento_activo_externo.Element("SeccionDescipcion").Value);

                    }
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", centro_costo_destino);
                    contenido = contenido.Replace("[LOCALIZACION_DESTINO]", localizacion);
                    contenido = contenido.Replace("[UBICACION_DESTINO]", ubicacion);
                    contenido = contenido.Replace("[SECCION_DESTINO]", seccion);
                }
                else
                {
                    contenido = contenido.Replace("<table class=\"tabla\"><tr class=\"trow\"><td colspan=\"9\"><b>Departamento Receptor </b></td></tr><tr class=\"trow\"><td><b>Localización: </b></td><td>[LOCALIZACION_DESTINO]</td><td>&nbsp;</td><td><b>Ubicación: </b></td><td>[UBICACION_DESTINO]</td><td>&nbsp;</td><td><b>Sección: </b></td><td>[SECCION_DESTINO]</td></tr></table>", "");
                    contenido = contenido.Replace("<table class=\"tabla\"><tr class=\"trow\"><td><b>Centro de Costo: </b></td><td>[CENTRO_COSTO_RECEPTOR]</td></tr></table>", "");
                }

                if (id_tipo_movimiento == 3 || id_tipo_movimiento == 4)
                {
                    string cadena = dtMovimientos.Rows[0]["DETALLE"].ToString();
                    string xmlcadena = "<Datos>" + cadena + "</Datos>";
                    System.Xml.Linq.XElement xmldoc = System.Xml.Linq.XElement.Parse(xmlcadena);

                    System.Xml.Linq.XElement xml_movimiento_activo = null;

                    if (id_tipo_movimiento == 3)
                    {
                        xml_movimiento_activo = (
                                            from item in xmldoc.XPathSelectElements("./Calibracion")
                                            select item).FirstOrDefault<System.Xml.Linq.XElement>();
                    }
                    else
                    {
                        xml_movimiento_activo = (
                                            from item in xmldoc.XPathSelectElements("./Mantenimiento")
                                            select item).FirstOrDefault<System.Xml.Linq.XElement>();
                    }
                    string proveedor = System.Convert.ToString(xml_movimiento_activo.Element("Proveedor").Value);
                    string ced_juridica = System.Convert.ToString(xml_movimiento_activo.Element("CedulaJuridica").Value);
                    string nombre_contacto = System.Convert.ToString(xml_movimiento_activo.Element("NombreContacto").Value);
                    string tel_proveedor = System.Convert.ToString(xml_movimiento_activo.Element("TelefonoProveedor").Value);
                    string fec_reingreso = System.Convert.ToString(xml_movimiento_activo.Element("FechaAproximadaDeReingreso").Value);
                    string direccion = System.Convert.ToString(xml_movimiento_activo.Element("DireccionProveedor").Value);

                    contenido = contenido.Replace("[PROVEEDOR]", proveedor);
                    contenido = contenido.Replace("[CED_JUR]", ced_juridica);
                    contenido = contenido.Replace("[CONTACTO]", nombre_contacto);
                    contenido = contenido.Replace("[TEL_PROVEE]", tel_proveedor);
                    contenido = contenido.Replace("[FEC_REINGRESO]", fec_reingreso);
                    contenido = contenido.Replace("[DIR_PROVEEDOR]", direccion);
                }
                else
                {
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Proveedor: </b></td><td>[PROVEEDOR]</td></tr></table>", "");
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Cédula Jurídica: </b></td><td>[CED_JUR]</td><td><b>Contacto: </b></td><td>[CONTACTO]</td></tr></table>", "");
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Teléfono: </b></td><td>[TEL_PROVEE]</td><td><b>Fecha de Reingreso: </b></td><td>[FEC_REINGRESO]</td></tr></table>", "");
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Dirección: </b></td><td>[DIR_PROVEEDOR]</td></tr></table>", "");
                }


                if (id_movimiento == -1)
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "La solicitud fue cancelada");
                    contenido = contenido.Replace("[URL]", "#");
                }
                else
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "Ingreso para Aprobación ó Cancelación");
                    //GPE 12.09.2013 change string navigate_url = "http://cylmult12//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + id_movimiento.ToString();
                    string navigate_url = nav_url + "//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + id_movimiento;
                    contenido = contenido.Replace("[URL]", navigate_url);
                }

                string items_table = "<table class=\"tabla_detalles\"><tr class=\"theader\" >\r\n";
                if (id_tipo_movimiento == 2)
                {
                    items_table = items_table + "<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">¿Electrónico?</span></td>\r\n";
                }
                items_table = items_table + "<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Placa</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Activo SAP</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción del Activo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Marca</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Modelo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Serie</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Valor Libros</span></td>\r\n                    </tr>";
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt_activos = null;
                DataTable movimiento = new cls_traslado().cargar_datos_generales("2380", id_movimiento);
                if (Convert.ToBoolean(movimiento.Rows[0]["POSEE_PLACAS"].ToString()))
                {
                    dt_activos = activos.cargar_activos_grid("2380", id_movimiento);
                }
                else
                {
                    dt_activos = activos.cargar_activos_grid_sin_placa("2380", id_movimiento);
                }
                for (int x = 0; x < dt_activos.Rows.Count; x++)
                {
                    string rowstyle = "";
                    if (x % 2 == 0)
                    {
                        rowstyle = "text-align:left;font-size:8pt;";
                    }
                    else
                    {
                        rowstyle = "background-color:#EDEDED;text-align:left;font-size:8pt;";
                    }
                    items_table = items_table + "<tr style=\"" + rowstyle + "\">";

                    if (id_tipo_movimiento == 2)
                    {
                        if (Convert.ToBoolean(dt_activos.Rows[x]["DESECHO"].ToString()))
                        {
                            items_table = items_table + "<td style=\"border: 1px solid #000; text-align:center;\" >X</td>";
                        }
                        else
                        {
                            items_table = items_table + "<td style=\"border: 1px solid #000;\"></td>";
                        }
                    }
                    if (Convert.ToBoolean(movimiento.Rows[0]["POSEE_PLACAS"].ToString()))
                    {
                        items_table = items_table + "<td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["PLA_ACTIVO"].ToString();
                        items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["REF_NUM_ACT"].ToString() + "</td>";
                    }
                    else
                    {
                        items_table = items_table + "<td style=\"border: 1px solid #000;\">";
                        items_table = items_table + "</td><td style=\"border: 1px solid #000;\"></td>";
                    }

                    items_table = items_table + "<td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_MARCA"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["NOM_MODELO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["SER_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + double.Parse(dt_activos.Rows[x]["VAL_LIBROS"].ToString()).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                    items_table += "</td></tr>";
                }
                //Add BY GPE 3/12/2014 point.13 doc. After my visit
                int numColsSpan = 6;
                if (id_tipo_movimiento == 2)
                {
                    numColsSpan = 7;
                }
                items_table = items_table + "<tr style\"text-align:left;font-size:8pt;\"><td colspan=\"" + numColsSpan + "\" style=\"border: 1px solid #000;\">Total Valor en Libros :";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + new cls_traslado().valor_libros("2380", id_movimiento).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                items_table += "</td></tr>";

                items_table += "</table>";
                string items_table_historico = "<br/><table class=\"tabla_detalles\">"
                    + "<tr class=\"theader\">\r\n <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Fecha</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Paso Aprobación</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Usuario</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción</span></td>\r\n                    </tr>";
                cls_bitacora historico = new cls_bitacora();
                System.Data.DataTable dt_historico = historico.cargar_bitacora(id_movimiento);
                for (int x = 0; x < dt_historico.Rows.Count; x++)
                {
                    string rowstyle = "";
                    if (x % 2 == 0)
                    {
                        rowstyle = "text-align:left;font-size:8pt;";
                    }
                    else
                    {
                        rowstyle = "background-color:#EDEDED;text-align:left;font-size:8pt;";
                    }
                    items_table_historico = items_table_historico + "<tr style=\"" + rowstyle + "\"><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["FECHA"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["PASO_APROVACION_ACTUAL"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["USUARIO"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION"].ToString();
                    //items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION_TIPO_MOVIMIENTO"].ToString();
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

        /*public string Print_Report(int id_movimiento, string contenido, string codigo_compania, string nav_url)
        {
            var movimientos = from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                              where c.ID_MOVIMIENTO == id_movimiento
                              select new
                              {
                                  ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                                  COD_SOLICITANTE = c.ID_EMPLEADO,
                                  NOMBRE_SOLICITANTE = c.EMPLEADO_RESPONSABLE_CC,
                                  CENTRO_COSTO = c.CENTRO_COSTO,
                                  DETALLE = c.DETALLE_DESTINO_MOVIMIENTO
                              };

            DataTable dtMovimientos = movimientos.AsDataTable();

            var bitacora = from c in this.db.AFT_MOV_BITACORA
                           where c.ID_MOVIMIENTO == id_movimiento
                           select new
                           {
                               DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO
                           };

            DataTable dtBitacora = bitacora.AsDataTable();

            string cod_centro_costo_origen = dtMovimientos.Rows[0]["CENTRO_COSTO"].ToString();

            var centroCostoOrigen = from c in this.db.AFM_CENTRO_COSTO
                                    where c.COD_CEN_CST == cod_centro_costo_origen
                                    select new
                                    {
                                        DESCRIPCION = c.DES_CEN_CST
                                    };

            DataTable dtCentroCostoOrigen = centroCostoOrigen.AsDataTable();

            string result;
            try
            {
                // string contenido = System.IO.File.ReadAllText(base.Server.MapPath("~/Templates/Shipping.htm"));
                contenido = contenido.Replace("[NOMBRE_TIPO_MOVIMIENTO]", dtBitacora.Rows[0]["DESCRIPCION_TIPO_MOVIMIENTO"].ToString());
                contenido = contenido.Replace("[ID_MOVIMIENTO]", id_movimiento.ToString());
                contenido = contenido.Replace("[NOMBRE_SOLICITANTE]", dtMovimientos.Rows[0]["NOMBRE_SOLICITANTE"].ToString());
                //contenido = contenido.Replace("[DEPARTAMENTO_ACTUAL]", dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString());
                contenido = contenido.Replace("[CENTRO_COSTO_ACTUAL]", cod_centro_costo_origen);
                contenido = contenido.Replace("[VALOR_LIBROS]", new cls_traslado().valor_libros(codigo_compania, System.Convert.ToInt32(id_movimiento.ToString())).ToString("C2"));
                //contenido = contenido.Replace("[PLANTA_1]", new cls_traslado().nombre_localizacion(dtMovimientos.Rows[0]["CENTRO_COSTO"].ToString()));
                //contenido = contenido.Replace("[UBICACION_ACTUAL]", new cls_traslado().cargar_ubicacion_actual(codigo_compania, id_movimiento));

                DataTable dtUbicacion = new cls_traslado().cargar_ubicacion_actual(System.Convert.ToInt32(id_movimiento));
                if (dtUbicacion.Rows.Count > 0)
                {
                    contenido = contenido.Replace("[LOCALIZACION]", dtUbicacion.Rows[0]["LOCALIZACION"].ToString());
                    contenido = contenido.Replace("[UBICACION]", dtUbicacion.Rows[0]["UBICACION"].ToString());
                    contenido = contenido.Replace("[SECCION]", dtUbicacion.Rows[0]["SECCION"].ToString());
                }

                //GPE 12/07/2013 WAT_Document new stuff # 15 c
                if (!string.IsNullOrEmpty(dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString()))
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", dtCentroCostoOrigen.Rows[0]["DESCRIPCION"].ToString());
                else
                    contenido = contenido.Replace("[CENTRO_DE_COSTO]", string.Empty);

                int id_tipo_movimiento = new cls_traslado().id_tipo_movimiento(id_movimiento, codigo_compania);
                if (id_tipo_movimiento == 5 || id_tipo_movimiento == 7)
                {
                    string cadena = dtMovimientos.Rows[0]["DETALLE"].ToString();
                    string xmlcadena = "<Datos>" + cadena + "</Datos>";
                    System.Xml.Linq.XElement xmldoc = System.Xml.Linq.XElement.Parse(xmlcadena);
                    string localizacion = "";
                    string seccion = "";
                    string ubicacion = "";
                    string centro_costo_destino = "";
                    if (id_tipo_movimiento == 5)
                    {
                        System.Xml.Linq.XElement xml_movimiento_activo = (
                            from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                            select item).FirstOrDefault<System.Xml.Linq.XElement>();
                        centro_costo_destino = System.Convert.ToString(xml_movimiento_activo.Element("CentroCostoDestino").Value);
                        localizacion = System.Convert.ToString(xml_movimiento_activo.Element("LocalizacionDescripcion").Value);
                        ubicacion = System.Convert.ToString(xml_movimiento_activo.Element("UbicacionDescripcion").Value);
                        seccion = System.Convert.ToString(xml_movimiento_activo.Element("SeccionDescripcion").Value);

                    }
                    if (id_tipo_movimiento == 7)
                    {
                        System.Xml.Linq.XElement xml_movimiento_activo_externo = (
                                        from item in xmldoc.XPathSelectElements("./MovimientoActivo")
                                        select item).FirstOrDefault<System.Xml.Linq.XElement>();
                        centro_costo_destino = System.Convert.ToString(xml_movimiento_activo_externo.Element("CentroCostoDestino").Value);
                        localizacion = System.Convert.ToString(xml_movimiento_activo_externo.Element("LocalizacionDescripcion").Value);
                        ubicacion = System.Convert.ToString(xml_movimiento_activo_externo.Element("UbicacionDescripcion").Value);
                        seccion = System.Convert.ToString(xml_movimiento_activo_externo.Element("SeccionDescipcion").Value);

                    }

                    //GPE 20.09.2013 need to code
                    //contenido = contenido.Replace("[PLANTA_2]", localizacion);
                    //contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", centro_costo_destino);
                    contenido = contenido.Replace("[CENTRO_COSTO_RECEPTOR]", centro_costo_destino);
                    contenido = contenido.Replace("[LOCALIZACION_DESTINO]", localizacion);
                    contenido = contenido.Replace("[UBICACION_DESTINO]", ubicacion);
                    contenido = contenido.Replace("[SECCION_DESTINO]", seccion);
                }
                else
                {
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td colspan=\"9\"><b>Departamento Receptor </b></td></tr><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Localización: </b></td><td>[LOCALIZACION_DESTINO]</td><td>&nbsp;</td><td><b>Ubicación: </b></td><td>[UBICACION_DESTINO]</td><td>&nbsp;</td><td><b>Sección: </b></td><td>[SECCION_DESTINO]</td></tr></table>", "");
                    contenido = contenido.Replace("<table style=\"max-width:19cm;color:#000000;\"><tr style=\"text-align:left;font-size:9pt;font-family:Arial Unicode MS;\"><td><b>Centro de Costo: </b></td><td>[CENTRO_COSTO_RECEPTOR]</td></tr></table>", "");
                    //contenido = contenido.Replace("[PLANTA_2]", "");
                    //contenido = contenido.Replace("tr><td colspan='2'><b>Centro de Costo Receptor: </b>[CENTRO_COSTO_RECEPTOR]</td></tr><tr><td colspan='2'><b>Ubicación de Destino: </b>[DEPARTAMENTO_RECEPTOR]</td></tr>", "");
                }
                if (id_movimiento == -1)
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "La solicitud fue cancelada");
                    contenido = contenido.Replace("[URL]", "#");
                }
                else
                {
                    contenido = contenido.Replace("[URL_DESCRIPCION]", "Ingreso para Aprobación ó Cancelación");
                    //GPE 12.09.2013 change string navigate_url = "http://cylmult12//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + id_movimiento.ToString();
                    string navigate_url = nav_url + "//WebAssetsTransfer/wbfrm_login.aspx/?codigo_compania=" + codigo_compania + "&id_movimiento=" + id_movimiento;
                    contenido = contenido.Replace("[URL]", navigate_url);
                }

                string items_table = "<table align=\"center\" style=\"width: 15.1cm;border: 1px solid #000;border-collapse: collapse;\"><tr style=\"background-color:#1F497D;color:White;font-size:9pt;\">\r\n";
                if (id_tipo_movimiento == 2)
                {
                    items_table = items_table + "<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">¿Electrónico?</span></td>\r\n";
                }
                items_table = items_table + "<td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Placa</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Activo SAP</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción del Activo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Marca</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Modelo</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Serie</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Valor Libros</span></td>\r\n                    </tr>";
                cls_traslado activos = new cls_traslado();
                System.Data.DataTable dt_activos = activos.cargar_activos_grid("2380", id_movimiento);
                for (int x = 0; x < dt_activos.Rows.Count; x++)
                {
                    string rowstyle = "";
                    if (x % 2 == 0)
                    {
                        rowstyle = "text-align:left;font-size:8pt;";
                    }
                    else
                    {
                        rowstyle = "background-color:#EDEDED;text-align:left;font-size:8pt;";
                    }
                    items_table = items_table + "<tr style=\"" + rowstyle + "\">";

                    if (id_tipo_movimiento == 2)
                    {
                        if (Convert.ToBoolean(dt_activos.Rows[x]["DESECHO"].ToString()))
                        {
                            items_table = items_table + "<td style=\"border: 1px solid #000; text-align:center;\" >X</td>";
                        }
                        else
                        {
                            items_table = items_table + "<td style=\"border: 1px solid #000;\"></td>";
                        }
                    }

                    items_table = items_table + "<td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["PLA_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["REF_NUM_ACT"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["DES_MARCA"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["NOM_MODELO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + dt_activos.Rows[x]["SER_ACTIVO"].ToString();
                    items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + double.Parse(dt_activos.Rows[x]["VAL_LIBROS"].ToString()).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                    items_table += "</td></tr>";
                }
                //Add BY GPE 3/12/2014 point.13 doc. After my visit
                int numColsSpan = 6;
                if (id_tipo_movimiento == 2)
                {
                    numColsSpan = 7;
                }
                items_table = items_table + "<tr style\"text-align:left;font-size:8pt;\"><td colspan=\"" + numColsSpan + "\" style=\"border: 1px solid #000;\">Total Valor en Libros :";
                items_table = items_table + "</td><td style=\"border: 1px solid #000;\">" + new cls_traslado().valor_libros("2380", id_movimiento).ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));
                items_table += "</td></tr>";

                items_table += "</table>";
                string items_table_historico = "<br/><table align=\"center\" style=\"width: 15.1cm;border: 1px solid #000;border-collapse: collapse;\">"
                    + "<tr style=\"background-color:#1F497D;color:White;font-size:9pt;\">\r\n <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Fecha</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Paso Aprobación</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Usuario</span></td>\r\n                    <td style=\"border: 1px solid #000;\"><span style=\"padding:0px 10px;color:#ffffff;font-size:0.9em;text-align:left;font-weight:bold;\">Descripción</span></td>\r\n                    </tr>";
                cls_bitacora historico = new cls_bitacora();
                System.Data.DataTable dt_historico = historico.cargar_bitacora(id_movimiento);
                for (int x = 0; x < dt_historico.Rows.Count; x++)
                {
                    string rowstyle = "";
                    if (x % 2 == 0)
                    {
                        rowstyle = "text-align:left;font-size:8pt;";
                    }
                    else
                    {
                        rowstyle = "background-color:#EDEDED;text-align:left;font-size:8pt;";
                    }
                    items_table_historico = items_table_historico + "<tr style=\"" + rowstyle + "\"><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["FECHA"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["PASO_APROVACION_ACTUAL"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["USUARIO"].ToString();
                    items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION"].ToString();
                    //items_table_historico = items_table_historico + "</td><td style=\"border: 1px solid #000;\">" + dt_historico.Rows[x]["DESCRIPCION_TIPO_MOVIMIENTO"].ToString();
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
        }*/
    }
}
