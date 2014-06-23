using DAL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
namespace BLL
{
    public class cls_traslado
    {
        private BostonEntities db = new BostonEntities();
        public DataTable cargar_datos_generales(string codigo_compañia, int id_movimiento)
        {
            var datos =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where c.COD_COMPANIA == codigo_compañia && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    ESTADO = c.ESTADO,
                    CODIGO_CENTRO_COSTO = c.CENTRO_COSTO,
                    DESCRIPCION_CENTRO_COSTO = c.DESCRIPCION_CENTRO_COSTOS,
                    CODIGO_SOLICITANTE = c.ID_EMPLEADO,
                    NOMBRE_SOLICITANTE = c.EMPLEADO_RESPONSABLE_CC,
                    FECHA = c.FECHA_MOVIMIENTO,
                    DETALLE = c.DETALLE_DESTINO_MOVIMIENTO,
                    NUMERO_SOLICITUD = c.ID_MOVIMIENTO,
                    //GPE 12/13/2013 fixing bug with ID_PASO_APROBACION_ACTUAL
                   // ID_TIPO_APROBACION_ACTUAL = c.ID_PASO_APROBACION_ACTUAL
                    ID_PASO_APROBACION_ACTUAL = c.ID_PASO_APROBACION_ACTUAL,
                    ID_TIPO_MOVIMIENTO = c.ID_TIPO_MOVIMIENTO,
                    COD_COMPANIA = c.COD_COMPANIA,
                    ACTA = c.ACTA
                };
            return datos.AsDataTable();
        }
        public DataTable cargar_datos_detalle(string codigo_compañia, int id_movimiento)
        {
            var datos =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                from d in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                where c.ID_MOVIMIENTO == d.ID_MOVIMIENTO && c.COD_COMPANIA == codigo_compañia && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    CODIGO_CENTRO_COSTO = c.CENTRO_COSTO,
                    DESCRIPCION_CENTRO_COSTO = c.DESCRIPCION_CENTRO_COSTOS,
                    CODIGO_SOLICITANTE = c.ID_EMPLEADO,
                    NOMBRE_SOLICITANTE = c.EMPLEADO_RESPONSABLE_CC,
                    FECHA = c.FECHA_MOVIMIENTO,
                    ID_TIPO_MOVIMIENTO = c.ID_TIPO_MOVIMIENTO
                };
            return datos.AsDataTable();
        }
        public DataTable cargar_activos_grid(string codigo_compania, int id_movimiento)
        {
            var activos =
                from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                from d in this.db.AFM_MAEST_ACTIV
                where c.PLACA == d.PLA_ACTIVO && c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    PLA_ACTIVO = c.PLACA,
                    REF_NUM_ACT = d.REF_NUM_ACT,
                    DES_ACTIVO = c.DESCRIPCION,
                    DES_MARCA = c.MARCA,
                    NOM_MODELO = c.MODELO,
                    SER_ACTIVO = d.SER_ACTIVO,
                    VAL_LIBROS = c.VALOR_LIBROS
                };
            return activos.AsDataTable();
        }
        public DataTable cargar_detalle_destino_movimiento(string codigo_compania, int id_movimiento)
        {
            var activos =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    c.DETALLE_DESTINO_MOVIMIENTO
                };
            return activos.AsDataTable();
        }
        public DataTable cargar_lista_activos_por_solicitud(string codigo_compania, int id_movimiento)
        {
            var activos =
                from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    CODIGO_ACTIVO = c.NUM_ACTIVO
                };
            return activos.AsDataTable();
        }
        public void actualizar_estado_activo_por_solicitud(string numero_activo, string codigo_estado_origen)
        {
            AFM_MAEST_ACTIV activo = new AFM_MAEST_ACTIV();
            activo = this.db.AFM_MAEST_ACTIV.First((AFM_MAEST_ACTIV c) => c.NUM_ACTIVO == numero_activo);
            activo.COD_EST_ORI = codigo_estado_origen;
            this.db.SaveChanges();
        }
        public void actualizar_datos_traslado_activo_solicitud_aceptada(ent_traslado entidad)
        {
            AFM_MAEST_ACTIV activo = new AFM_MAEST_ACTIV();
            activo = this.db.AFM_MAEST_ACTIV.First((AFM_MAEST_ACTIV c) => c.NUM_ACTIVO == entidad.numero_activo);
            activo.COD_CEN_CST = entidad.centro_costo;
            activo.COD_EMPLEADO = entidad.codigo_empleado;
            activo.COD_LOC_ACT = entidad.codigo_localizacion_activo;
            activo.COD_SEC_LOC = entidad.codigo_seccion_activo;
            activo.COD_UBI_ACT = entidad.codigo_ubicacion_activo;
            activo.FYH_ESTADO = new DateTime?(DateTime.Now);
            this.db.SaveChanges();
        }
        public DataTable GetCOD_CIA_PROByCost_Center(string strCod_Cen_Cst, string strCODIGO_COMPANIA)
        {
            try
            {
                var centros_costo =
                from c in this.db.AFM_CENTRO_COSTO
                where c.COD_CEN_CST == strCod_Cen_Cst && c.COD_COMPANIA == strCODIGO_COMPANIA
                select new
                {
                     COD_CIA_PRO = c.COD_CIA_PRO,
                     DES_CEN_CST = c.DES_CEN_CST
                };
                return centros_costo.AsDataTable();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable cargar_activos(string placa_activo, string centro_costo = "")
        {
            if (!string.IsNullOrEmpty(centro_costo))
            {
                var activos =
                    from c in this.db.AFM_MAEST_ACTIV
                    from d in this.db.AFM_MARCA_ACTIV
                    from e in this.db.AFM_MODEL_ACTIV
                    where c.COD_MARCA == d.COD_MARCA && d.COD_MARCA == e.COD_MARCA && e.COD_MODELO != "0" && c.PLA_ACTIVO.Trim() == placa_activo && c.COD_CEN_CST == centro_costo
                    select new
                    {
                        PLA_ACTIVO = c.PLA_ACTIVO,
                        REF_NUM_ACT = c.REF_NUM_ACT,
                        DES_ACTIVO = c.DES_ACTIVO,
                        DES_MARCA = d.DES_MARCA,
                        NOM_MODELO = e.NOM_MODELO,
                        SER_ACTIVO = c.SER_ACTIVO,
                        VAL_LIBROS = c.VAL_LIBROS ?? 0m,
                        CENTRO_COSTO = c.COD_CEN_CST,
                        COD_CIA_PRO = c.COD_CIA_PRO
                    };
                return activos.AsDataTable();
            }
            //GPE 12/07/2013 WAT_Document new stuff # 12
            else
            {
                var activos =
                   from c in this.db.AFM_MAEST_ACTIV
                   from d in this.db.AFM_MARCA_ACTIV
                   from e in this.db.AFM_MODEL_ACTIV
                   where c.COD_MARCA == d.COD_MARCA && d.COD_MARCA == e.COD_MARCA && e.COD_MODELO != "0" && c.PLA_ACTIVO.Trim() == placa_activo && c.COD_CEN_CST != "0"
                   select new
                   {
                       PLA_ACTIVO = c.PLA_ACTIVO,
                       REF_NUM_ACT = c.REF_NUM_ACT,
                       DES_ACTIVO = c.DES_ACTIVO,
                       DES_MARCA = d.DES_MARCA,
                       NOM_MODELO = e.NOM_MODELO,
                       SER_ACTIVO = c.SER_ACTIVO,
                       VAL_LIBROS = c.VAL_LIBROS ?? 0m,
                       CENTRO_COSTO = c.COD_CEN_CST,
                       COD_CIA_PRO = c.COD_CIA_PRO
                   };
                return activos.AsDataTable();
            }
        }
        public DataTable cargar_empleado(string cod_empleado)
        {
            var empleado =
                from c in this.db.AFM_CATAL_EMPLE
                where c.COD_EMPLEADO == cod_empleado
                select new
                {
                    COD_EMPLEADO = c.COD_EMPLEADO,
                    NOMBRE_EMPLEADO = c.NOM_EMPLEADO
                };
            return empleado.AsDataTable();
        }
        public DataTable cargar_empleados()
        {
            var empleados =
                from c in this.db.AFM_CATAL_EMPLE
                select new
                {
                    COD_EMPLEADO = c.COD_EMPLEADO,
                    NOMBRE_EMPLEADO = c.NOM_EMPLEADO
                };
            return empleados.AsDataTable();
        }
        public DataTable cargar_centro_costo(string cod_centro_costo)
        {
            var centro_costo =
                from c in this.db.AFM_CENTRO_COSTO
                where c.COD_CEN_CST == cod_centro_costo
                select new
                {
                    COD_CENTRO_COSTO = c.COD_CEN_CST,
                    CENTRO_COSTO = c.DES_CEN_CST,
                    COD_CIA_PRO = c.COD_CIA_PRO
                };
            return centro_costo.AsDataTable();
        }

        public DataTable cargar_centro_costo(string cod_centro_costo, string strCod_Cia_Pro, string strMovementType)
        {
            if (strMovementType == "5")
            {
                var centro_costo =
                    from c in this.db.AFM_CENTRO_COSTO
                    where c.COD_CEN_CST == cod_centro_costo && c.COD_CIA_PRO == strCod_Cia_Pro
                    select new
                    {
                        COD_CENTRO_COSTO = c.COD_CEN_CST,
                        CENTRO_COSTO = c.DES_CEN_CST,
                        COD_CIA_PRO = c.COD_CIA_PRO
                    };
                return centro_costo.AsDataTable();
            }
            else if (strMovementType == "7") {
                var centro_costo =
                    from c in this.db.AFM_CENTRO_COSTO
                    where c.COD_CEN_CST == cod_centro_costo && c.COD_CIA_PRO != strCod_Cia_Pro //!c.COD_CIA_PRO.Contains(strCod_Cia_Pro) && c.COD_CEN_CST == cod_centro_costo
                    select new
                    {
                        COD_CENTRO_COSTO = c.COD_CEN_CST,
                        CENTRO_COSTO = c.DES_CEN_CST,
                        COD_CIA_PRO = c.COD_CIA_PRO
                    };
                DataTable dtCCTable = centro_costo.AsDataTable();
                if(dtCCTable ==null || dtCCTable.Rows.Count<=0)return null;
                for(int i=0;i<dtCCTable.Rows.Count;i++){
                    if(dtCCTable.Rows[i]["COD_CIA_PRO"].ToString()==strCod_Cia_Pro){
                        dtCCTable.Rows[i].Delete();
                        //dtNewTable.Rows.Add(dtCCTable.NewRow());
                        //dtNewTable.Rows[dtNewTable.Rows.Count-1]["COD_CENTRO_COSTO"]=dtCCTable.Rows[i]["COD_CENTRO_COSTO"].ToString();
                        //dtNewTable.Rows[dtNewTable.Rows.Count-1]["CENTRO_COSTO"]=dtCCTable.Rows[i]["CENTRO_COSTO"].ToString();
                        //dtNewTable.Rows[dtNewTable.Rows.Count-1]["COD_CIA_PRO"]=dtCCTable.Rows[i]["COD_CIA_PRO"].ToString();
                    }
                }
                return dtCCTable;
            }
            return null;
        }

        public DataTable cargar_centros_costo()
        {
            var centros_costo =
                from c in this.db.AFM_CENTRO_COSTO
                select new
                {
                    COD_CENTRO_COSTO = c.COD_CEN_CST,
                    CENTRO_COSTO = c.DES_CEN_CST
                };
            return centros_costo.AsDataTable();
        }
        //GPE 4/8/2014 WAT-04052014 Point 7
        // public DataTable cargar_localizacion_activo()
        public DataTable cargar_localizacion_activo(string cod_cia_pro)
        {
            
            if (cod_cia_pro == "2380")
            {
                var centros_costo =
                   from c in this.db.AFM_CATAL_LOCAL
                   //GPE 4/8/2014 WAT-04052014 Point 7
                   // where c.COD_LOC_ACT != "0" 
                   where c.COD_LOC_ACT != "0" 
                   select new
                   {
                       COD_LOCALIZACION_ACTIVO = c.COD_LOC_ACT,
                       DES_LOCALIZACION_ACTVO = c.DES_LOC_ACT
                   };
                return centros_costo.AsDataTable();
            }
            else
            {
                var centros_costo =
                    from c in this.db.AFM_CATAL_LOCAL
                    //GPE 4/8/2014 WAT-04052014 Point 7
                    // where c.COD_LOC_ACT != "0" 
                    where c.COD_LOC_ACT != "0" && (c.COD_LOC_ACT == cod_cia_pro || cod_cia_pro == "")
                    select new
                    {
                        COD_LOCALIZACION_ACTIVO = c.COD_LOC_ACT,
                        DES_LOCALIZACION_ACTVO = c.DES_LOC_ACT
                    };
                return centros_costo.AsDataTable();
            }
           
        }
        public DataTable cargar_seccion_localizacion_activo(string cod_localizacion_activo)
        {
            var centros_costo =
                from c in this.db.AFM_SECCI_LOCAL
                where c.COD_LOC_ACT == cod_localizacion_activo && c.COD_LOC_ACT != "0"
                select new
                {
                    COD_SECCION_LOC = c.COD_SEC_LOC,
                    DES_SECCION_LOC = c.DES_SEC_LOC
                };
            return centros_costo.AsDataTable();
        }
        public DataTable cargar_ubicacion_activo(string cod_seccion__localizacion_activo)
        {
            var centros_costo =
                from c in this.db.AFM_UBICA_ACTIV
                where c.COD_SEC_LOC == cod_seccion__localizacion_activo && c.COD_UBI_ACT != "0"
                select new
                {
                    COD_UBICACION_ACTIVO = c.COD_UBI_ACT,
                    DES_UBICACION_ACTIVO = c.DES_UBI_ACT
                };
            return centros_costo.AsDataTable();
        }
        public DataTable cargar_tipo_movimiento()
        {
            var tipo_movimiento =
                from c in this.db.AFT_MOV_TIPOS_MOVIMIENTOS
                select new
                {
                    CODIGO_TIPO_MOVIMIENTO = c.ID_TIPO_MOVIMIENTO,
                    DESCRIPCION_TIPO_MOVIMIENTO = c.DESCRIPCION_TIPO_MOVIMIENTO
                };
            return tipo_movimiento.AsDataTable();
        }
        public string codigo_localizacion(string codigo_centro_costo)
        {
            var localizacion =
                from c in this.db.AFM_MAEST_ACTIV
                where c.COD_CEN_CST == codigo_centro_costo
                join x in this.db.AFM_CATAL_LOCAL on new
                {
                    c.COD_COMPANIA,
                    c.COD_LOC_ACT
                } equals new
                {
                    x.COD_COMPANIA,
                    x.COD_LOC_ACT
                }
                select new
                {
                    x.COD_LOC_ACT
                };
            string result;
            if (localizacion.Count() > 0)
            {
                result = localizacion.First().COD_LOC_ACT;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public string nombre_localizacion(string codigo_centro_costo)
        {
            var localizacion =
                from c in this.db.AFM_MAEST_ACTIV
                where c.COD_CEN_CST == codigo_centro_costo
                join x in this.db.AFM_CATAL_LOCAL on new
                {
                    c.COD_COMPANIA,
                    c.COD_LOC_ACT
                } equals new
                {
                    x.COD_COMPANIA,
                    x.COD_LOC_ACT
                }
                select new
                {
                    x.DES_LOC_ACT
                };
            string result;
            if (localizacion.Count() > 0)
            {
                result = localizacion.First().DES_LOC_ACT;
            }
            else
            {
                result = "N/D";
            }
            return result;
        }
        public string cargar_ubicacion_actual(string codigo_compania, int id_movimiento)
        {
            var ubicacion_actual =
                from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    UBICACION_ACTUAL = c.LOCALIZACION + c.SECCION + c.UBICACION
                };
            string result;
            if (ubicacion_actual.Count() > 0)
            {
                result = ubicacion_actual.First().UBICACION_ACTUAL;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public decimal valor_libros(string codigo_compania, int id_movimiento)
        {
            int count = (
                from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                select c).Count<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>();
            decimal result;
            if (count > 0)
            {
                decimal valor = (
                    from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                    where c.COD_COMPANIA == codigo_compania && c.ID_MOVIMIENTO == id_movimiento
                    select c.VALOR_LIBROS ?? 0m).Sum();
                result = valor;
            }
            else
            {
                result = 0m;
            }
            return result;
        }
        //GPE 2/25/2014 filter by cod_cia_pro 
        public string cargar_cuenta_correo(int id_grupo, string cd_cen_cst)
        {

            var grupo =
                from c in this.db.AFT_MOV_GRUPOS_ACCESOS
                from d in this.db.AFM_CENTRO_COSTO
                where c.ID_GRUPO == id_grupo && d.COD_CEN_CST == cd_cen_cst && c.COD_CIA_PRO == d.COD_CIA_PRO
                select new
                {
                    c.EMAIL_GRUPO
                };
            string result;
            if (grupo.Count() > 0)
            {
                result = grupo.First().EMAIL_GRUPO;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public int id_tipo_movimiento(int id_movimiento, string codigo_compania)
        {
            var grupo =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where c.ID_MOVIMIENTO == id_movimiento && c.COD_COMPANIA == codigo_compania
                select new
                {
                    c.ID_TIPO_MOVIMIENTO
                };
            int result;
            if (grupo.Count() > 0)
            {
                result = grupo.First().ID_TIPO_MOVIMIENTO;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public void cambiar_estado(int id_movimiento, string codigo_compania, string codigo_estado, bool excluir)
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
                    //GPE Commented
					//foreach (<>f__AnonymousType1<string> item in movimiento_detalle)
                    foreach (var item in movimiento_detalle)
					{
						AFM_MAEST_ACTIV maestro_activo = new AFM_MAEST_ACTIV();
						maestro_activo = this.db.AFM_MAEST_ACTIV.First((AFM_MAEST_ACTIV c) => c.COD_COMPANIA == codigo_compania && c.NUM_ACTIVO == item.NUM_ACTIVO);
						maestro_activo.COD_EST_ORI = codigo_estado;
						maestro_activo.IND_ACT_EXC = new bool?(excluir);
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
        public int ingresar_traslado(ent_traslado entidad)
        {
            int id_movimiento2;
            using (TransactionScope transaction = new TransactionScope())
            {
                int id_movimiento = -1;
                try
                {
                    AFT_MOV_MAESTRO_MOVIMIENTOS maestro_movimiento = new AFT_MOV_MAESTRO_MOVIMIENTOS();
                    id_movimiento = (this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.Max((AFT_MOV_MAESTRO_MOVIMIENTOS c) => (int?)c.ID_MOVIMIENTO + (int?)1) ?? 1);
                    maestro_movimiento.ID_MOVIMIENTO = id_movimiento;
                    maestro_movimiento.COD_COMPANIA = entidad.codigo_compania;
                    maestro_movimiento.CENTRO_COSTO = entidad.centro_costo;
                    maestro_movimiento.ID_EMPLEADO = entidad.codigo_empleado;
                    maestro_movimiento.FECHA_MOVIMIENTO = entidad.fecha_movimiento;
                    maestro_movimiento.DESCRIPCION_CENTRO_COSTOS = entidad.descripcion_centro_costo;
                    maestro_movimiento.EMPLEADO_RESPONSABLE_CC = entidad.empleado_responsable_cc;
                    maestro_movimiento.ID_TIPO_MOVIMIENTO = entidad.codigo_tipo_movimiento;
                    maestro_movimiento.ESTADO = entidad.estado;
                    maestro_movimiento.ID_PASO_APROBACION_ACTUAL = entidad.codigo_paso_aprobacion_actual;
                    maestro_movimiento.DETALLE_DESTINO_MOVIMIENTO = entidad.detalle_destino_movimiento.ToString();
                    this.db.AddToAFT_MOV_MAESTRO_MOVIMIENTOS(maestro_movimiento);
                    this.db.SaveChanges();
                    id_movimiento = this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.Max((AFT_MOV_MAESTRO_MOVIMIENTOS c) => (int)c.ID_MOVIMIENTO);
                    DataTable activosSolicitados = entidad.activo_solicitado;
                    for (int i = 0; i < activosSolicitados.Rows.Count - 1; i++)
                    {
                        string activo_buscado = activosSolicitados.Rows[i]["PLA_ACTIVO"].ToString();
                        if (!string.IsNullOrEmpty(activo_buscado))
                        {
                            DataTable activo = new cls_procedimientos().carga_procedimiento_activo_solicitado(activo_buscado);
                            AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO detalle_movimiento = new AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO();
                            AFT_MOV_MAESTRO_MOVIMIENTOS maestro_mov = new AFT_MOV_MAESTRO_MOVIMIENTOS();
                            maestro_mov = this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.First((AFT_MOV_MAESTRO_MOVIMIENTOS m) => m.ID_MOVIMIENTO == id_movimiento);
                            detalle_movimiento.AFT_MOV_MAESTRO_MOVIMIENTOS = maestro_mov;
                            detalle_movimiento.COD_COMPANIA = entidad.codigo_compania;
                            detalle_movimiento.NUM_ACTIVO = activo.Rows[0]["NUM_ACTIVO"].ToString();
                            detalle_movimiento.PLACA = activo.Rows[0]["PLA_ACTIVO"].ToString();
                            detalle_movimiento.DESCRIPCION = activo.Rows[0]["DES_ACTIVO"].ToString();
                            detalle_movimiento.SERIE = activo.Rows[0]["SER_ACTIVO"].ToString();
                            if (!string.IsNullOrEmpty(activo.Rows[0]["VAL_LIBROS"].ToString()))
                            {
                                detalle_movimiento.VALOR_LIBROS = new decimal?(Convert.ToDecimal(activo.Rows[0]["VAL_LIBROS"]));
                            }
                            else
                            {
                                detalle_movimiento.VALOR_LIBROS = new decimal?(0m);
                            }
                            detalle_movimiento.COD_MARCA = activo.Rows[0]["COD_MARCA"].ToString();
                            detalle_movimiento.MARCA = activo.Rows[0]["DES_MARCA"].ToString();
                            detalle_movimiento.COD_MODELO = activo.Rows[0]["COD_MODELO"].ToString();
                            detalle_movimiento.MODELO = activo.Rows[0]["NOM_MODELO"].ToString();
                            detalle_movimiento.COD_LOC_ACT = activo.Rows[0]["COD_LOC_ACT"].ToString();
                            detalle_movimiento.LOCALIZACION = activo.Rows[0]["DES_LOC_ACT"].ToString();
                            detalle_movimiento.COD_SEC_LOC = activo.Rows[0]["COD_SEC_LOC"].ToString();
                            detalle_movimiento.SECCION = activo.Rows[0]["DES_SEC_LOC"].ToString();
                            detalle_movimiento.COD_UBI_ACT = activo.Rows[0]["COD_UBI_ACT"].ToString();
                            detalle_movimiento.UBICACION = activo.Rows[0]["DES_UBI_ACT"].ToString();
                            detalle_movimiento.COD_CEN_CST = activo.Rows[0]["COD_CEN_CST"].ToString();
                            detalle_movimiento.CENTRO_COSTO = activo.Rows[0]["DES_CEN_CST"].ToString();
                            detalle_movimiento.RESPONSABLE_CC = activo.Rows[0]["COD_EMPLEADO"].ToString();
                            this.db.AddToAFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO(detalle_movimiento);
                            this.db.SaveChanges();
                        }
                    }
                    transaction.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
                id_movimiento2 = id_movimiento;
            }
            return id_movimiento2;
        }
        public string nombre_responsable(string codigo, bool interno = false)
        {
            var responsable =
                from centroCosto in this.db.AFM_CENTRO_COSTO
                where centroCosto.COD_CEN_CST == codigo
                join catalEmpleo in this.db.AFM_CATAL_EMPLE on new
                {
                    centroCosto.COD_COMPANIA,
                    centroCosto.COD_EMPLEADO
                } equals new
                {
                    catalEmpleo.COD_COMPANIA,
                    catalEmpleo.COD_EMPLEADO
                }
                select new
                {
                    Nombre_Empleado = catalEmpleo.NOM_EMPLEADO
                };
            string result;
            if (responsable.Count() > 0)
            {
                result = responsable.First().Nombre_Empleado;
            }
            else
            {
                //GPE 4/8/2014 WAT-04052014 Point 6
                //result = "NO DEFINIDO";
                if (interno)
                    result = string.Empty;
                else
                    result = "NO DEFINIDO";

            }
            return result;
        }
        //GPE 4/3/2014 get mail for calibracion
        public string nombre_responsable_calibracion(string codigo)
        {
            var responsable =
                from centroCosto in this.db.AFM_CENTRO_COSTO
                from grupo in this.db.AFT_MOV_GRUPOS_ACCESOS
                where centroCosto.COD_CEN_CST == codigo && centroCosto.COD_CIA_PRO == grupo.COD_CIA_PRO && grupo.ID_GRUPO == 6
                select new
                {
                    Nombre_Empleado = grupo.EMAIL_GRUPO
                };
            string result;
            if (responsable.Count() > 0)
            {
                result = responsable.First().Nombre_Empleado;
            }
            else
            {
                result = "NO DEFINIDO";
            }
            return result;
        }
        public string correo_responsable(string codigo)
        {
            var responsable =
                from centroCosto in this.db.AFM_CENTRO_COSTO
                where centroCosto.COD_CEN_CST == codigo
                join catalEmpleo in this.db.AFM_CATAL_EMPLE on new
                {
                    centroCosto.COD_COMPANIA,
                    centroCosto.COD_EMPLEADO
                } equals new
                {
                    catalEmpleo.COD_COMPANIA,
                    catalEmpleo.COD_EMPLEADO
                }
                select new
                {
                    catalEmpleo.DIR_ELECTR
                };
            string result;
            if (responsable.Count() > 0)
            {
                result = responsable.First().DIR_ELECTR;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public string correo_solicitante(string codigo)
        {
            var solicitante =
                from c in this.db.AFM_CATAL_EMPLE
                where c.COD_EMPLEADO == codigo
                select new
                {
                    c.DIR_ELECTR
                };
            string result;
            if (solicitante.Count() > 0)
            {
                result = solicitante.First().DIR_ELECTR;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public bool grupo_usuario(int id_grupo, string id_compania, string usuario)
        {
            IQueryable<AFT_MOV_GRUPO_USUARIOS> usuarios =
                from c in this.db.AFT_MOV_GRUPO_USUARIOS
                where c.ID_GRUPO == id_grupo && c.COD_COMPANIA == id_compania && c.USUARIO == usuario && c.ESTADO == (bool?)true
                select c;
            return usuarios.Count<AFT_MOV_GRUPO_USUARIOS>() > 0;
        }
        public DataTable cargar_informacion_movimiento(int id_movimiento, string id_compania)
        {
            var informacion =
                from amm in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                where amm.COD_COMPANIA == id_compania && amm.ID_MOVIMIENTO == id_movimiento
                select new
                {
                    ESTADO = amm.ESTADO,
                    ID_TIPO_MOVIMIENTO = amm.ID_TIPO_MOVIMIENTO,
                    ID_PASO_APROBACION = amm.ID_PASO_APROBACION_ACTUAL
                };
            return informacion.AsDataTable();
        }
        public bool aceptar_tipo_movimiento(int id_movimiento, string id_compania)
        {
            bool result;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    AFT_MOV_MAESTRO_MOVIMIENTOS mov_maestro_movimientos = new AFT_MOV_MAESTRO_MOVIMIENTOS();
                    mov_maestro_movimientos = this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.First((AFT_MOV_MAESTRO_MOVIMIENTOS a) => a.COD_COMPANIA == id_compania && a.ID_MOVIMIENTO == id_movimiento);
                    int aprobacion_actual = mov_maestro_movimientos.ID_PASO_APROBACION_ACTUAL + 1;
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 1 && aprobacion_actual == 3)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 2 && aprobacion_actual == 2)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 3 && aprobacion_actual == 2)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 4 && aprobacion_actual == 2)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 5 && aprobacion_actual == 3)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 6 && aprobacion_actual == 2)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    if (mov_maestro_movimientos.ID_TIPO_MOVIMIENTO == 7 && aprobacion_actual == 4)
                    {
                        mov_maestro_movimientos.ESTADO = "A";
                    }
                    mov_maestro_movimientos.ID_PASO_APROBACION_ACTUAL = aprobacion_actual;
                    this.db.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
                result = true;
            }
            return result;
        }
        public bool cancelar_tipo_movimiento(int id_movimiento, string id_compania)
        {
            bool result;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    AFT_MOV_MAESTRO_MOVIMIENTOS mov_maestro_movimientos = new AFT_MOV_MAESTRO_MOVIMIENTOS();
                    mov_maestro_movimientos = this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.First((AFT_MOV_MAESTRO_MOVIMIENTOS a) => a.COD_COMPANIA == id_compania && a.ID_MOVIMIENTO == id_movimiento);
                    mov_maestro_movimientos.ESTADO = "C";
                    this.db.SaveChanges();
                    transaction.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
                result = true;
            }
            return result;
        }
        //add by GPE 13.09.2013
        public bool is_admin(string usuario_sesion)
        {
            IQueryable<AFM_CATAL_EMPLE> empleados =
                from c in this.db.AFM_CATAL_EMPLE
                where c.USUARIO_SESION == usuario_sesion && c.IND_ADM_MODULO_CONTROL_MOV == (bool?)true
                select c;
            return empleados.Count<AFM_CATAL_EMPLE>() > 0;
        }

        //add by GPE 12.02.2013 new stuff # 10
        public DataTable cargar_solicitante(string usuario)
        {
         
            
             var emple = 
                from c in this.db.AFM_CATAL_EMPLE
                where c.USUARIO_SESION == usuario
                select new
                {
                    COD_EMPLEADO = c.COD_EMPLEADO,
                    NOM_EMPLEADO = c.NOM_EMPLEADO
                };
             
            return emple.AsDataTable();
        }
        //GPE 12/07/2013 WAT_Document new stuff # 14
        public bool check_observaciones_obligatory(string empleado_code)
        {
            bool result = false;
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    //GPE ID_Grupo = 1 - Recursos humanos
                    AFT_MOV_GRUPO_USUARIOS aft_grupo = this.db.AFT_MOV_GRUPO_USUARIOS.SingleOrDefault(a => a.ID_EMPLEADO == empleado_code && a.ID_GRUPO == 1);

                    if (aft_grupo != null)
                        result = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
