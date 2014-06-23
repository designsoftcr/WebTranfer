using CapaLog;
using DAL;
using Entidades;
using Sykes.Web.Data;
using System;
using System.Data;
using System.Linq;
using System.Transactions;
namespace BLL
{
    public class cls_movimiento_maestro
    {
        private BostonEntities db = new BostonEntities();
        public DataTable cargar_movimientos_maestro(string estado)
        {
            int[] tipo_movimiento = new int[]
			{
				1,
				2
			};
            var movimientos =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                from d in this.db.AFT_MOV_TIPOS_MOVIMIENTOS
                where c.ID_TIPO_MOVIMIENTO == d.ID_TIPO_MOVIMIENTO && tipo_movimiento.Contains(c.ID_TIPO_MOVIMIENTO) && c.ESTADO == "A"
                select new
                {
                    ID_MOVIMIENTO = c.ID_MOVIMIENTO,
                    ACTA = c.ACTA,
                    CENTRO_COSTO = c.CENTRO_COSTO,
                    ID_EMPLEADO = c.ID_EMPLEADO,
                    FECHA_MOVIMIENTO = c.FECHA_MOVIMIENTO,
                    DESCRIPCION_CENTRO_COSTOS = c.DESCRIPCION_CENTRO_COSTOS,
                    EMPLEADO_RESPONSABLE_CC = c.EMPLEADO_RESPONSABLE_CC,
                    ID_TIPO_MOVIMIENTO = d.DESCRIPCION_TIPO_MOVIMIENTO,
                    ESTADO = c.ESTADO
                };
            return movimientos.AsDataTable();
        }

        //Add BY GPE 3/13/2013 point.2 doc. After my visit -- USED
        public DataTable cargar_movimientos_maestro_filtrar(int id_movimiento, string cod_centro_costo, string cod_solicitante, string fetcha, int tipo_movimiento)
        {
            //GPE 3/31/2014 show all types of movimientos   add: 3,4,5,6,7
            int[] tipo_movimiento_list = new int[]
			{
				1,
				2,
                3,
                4,
                5,
                6,
                7
			};
            var allList =
                from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                from d in this.db.AFT_MOV_TIPOS_MOVIMIENTOS
                where c.ID_TIPO_MOVIMIENTO == d.ID_TIPO_MOVIMIENTO && tipo_movimiento_list.Contains(c.ID_TIPO_MOVIMIENTO) && c.ESTADO == "A"
                select new
                {
                    AFT_MOV_MAESTRO_MOVIMIENTOS = c,
                    AFT_MOV_TIPOS_MOVIMIENTOS = d
                };
          

            if (id_movimiento > 0)
                allList = allList.Where(a => a.AFT_MOV_MAESTRO_MOVIMIENTOS.ID_MOVIMIENTO == id_movimiento);

            if (!string.IsNullOrEmpty(fetcha))
            {
                DateTime date = DateTime.ParseExact(fetcha, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture);
                //DateTime date = Convert.ToDateTime(fetcha);
                DateTime date1 = date.AddDays(1);
                allList = allList.Where(a => a.AFT_MOV_MAESTRO_MOVIMIENTOS.FECHA_MOVIMIENTO > date && a.AFT_MOV_MAESTRO_MOVIMIENTOS.FECHA_MOVIMIENTO < date1);
            }

            //GPE 3/31/2014 show all types of movimientos
            //if (tipo_movimiento == 1 || tipo_movimiento == 2 )
            if (tipo_movimiento != 0 && (tipo_movimiento > 0 && tipo_movimiento < 8)  )
                allList = allList.Where(a => a.AFT_MOV_MAESTRO_MOVIMIENTOS.ID_TIPO_MOVIMIENTO == tipo_movimiento);

            if (!string.IsNullOrEmpty(cod_centro_costo) && cod_centro_costo != "NULL")
                allList = allList.Where(a => a.AFT_MOV_MAESTRO_MOVIMIENTOS.CENTRO_COSTO == cod_centro_costo);

            if (!string.IsNullOrEmpty(cod_solicitante) && cod_solicitante != "NULL")
                allList = allList.Where(a => a.AFT_MOV_MAESTRO_MOVIMIENTOS.ID_EMPLEADO == cod_solicitante);


            var movimientos =
                from r in allList
                select new
                {
                    ID_MOVIMIENTO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.ID_MOVIMIENTO,
                    ACTA = r.AFT_MOV_MAESTRO_MOVIMIENTOS.ACTA,
                    CENTRO_COSTO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.CENTRO_COSTO,
                    ID_EMPLEADO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.ID_EMPLEADO,
                    FECHA_MOVIMIENTO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.FECHA_MOVIMIENTO,
                    DESCRIPCION_CENTRO_COSTOS = r.AFT_MOV_MAESTRO_MOVIMIENTOS.DESCRIPCION_CENTRO_COSTOS,
                    EMPLEADO_RESPONSABLE_CC = r.AFT_MOV_MAESTRO_MOVIMIENTOS.EMPLEADO_RESPONSABLE_CC,
                    ID_TIPO_MOVIMIENTO = r.AFT_MOV_TIPOS_MOVIMIENTOS.DESCRIPCION_TIPO_MOVIMIENTO,
                    ESTADO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.ESTADO,
                    ID_TIPO_MOVIMIENTO_NUMBER = r.AFT_MOV_TIPOS_MOVIMIENTOS.ID_TIPO_MOVIMIENTO
                };


            return movimientos.AsDataTable();
        }
        public bool actualizar_movimiento_maestro(ent_traslado entidad,string strCOD_EST_ORI)
		{
			bool result;
			try
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					AFT_MOV_MAESTRO_MOVIMIENTOS movimiento_maestro = new AFT_MOV_MAESTRO_MOVIMIENTOS();
					movimiento_maestro = this.db.AFT_MOV_MAESTRO_MOVIMIENTOS.First((AFT_MOV_MAESTRO_MOVIMIENTOS c) => c.COD_COMPANIA == entidad.codigo_compania && c.ID_MOVIMIENTO == entidad.id_movimiento);
					movimiento_maestro.ACTA = entidad.acta;
					var movimiento_detalle = 
						from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
						where c.COD_COMPANIA == entidad.codigo_compania && c.ID_MOVIMIENTO == entidad.id_movimiento
						select new
						{
							c.NUM_ACTIVO
						};
                    //GPE Commented
					//foreach (<>f__AnonymousType1<string> item in movimiento_detalle)
                    foreach (var item in movimiento_detalle)
					{
                        //ExecuteScript objES = new ExecuteScript();
                        //objES.executeQuertyAndReturnNothing("sp_UpdateCOD_EST_ORI", new object[] { entidad.codigo_compania.Trim(), item.NUM_ACTIVO.Trim(), strCOD_EST_ORI, entidad.acta.Trim() });
                        AFM_MAEST_ACTIV maestro_activo = new AFM_MAEST_ACTIV();
                        maestro_activo = this.db.AFM_MAEST_ACTIV.Single(d => d.COD_COMPANIA == entidad.codigo_compania.Trim() && d.NUM_ACTIVO == item.NUM_ACTIVO.Trim());
                        maestro_activo.cod_acta = entidad.acta;
                        maestro_activo.IND_ACT_EXC = new bool?(true);
                        switch (movimiento_maestro.ID_TIPO_MOVIMIENTO)
                        {
                            case 1:
                                maestro_activo.COD_EST_ORI = "10";
                                break;
                            case 2:
                                maestro_activo.COD_EST_ORI = "07";
                                break;
                            case 3: {
                                if (!string.IsNullOrEmpty(strCOD_EST_ORI))
                                {
                                    maestro_activo.COD_EST_ORI = "01";
                                }
                                break;
                            }
                            case 4: {
                                if (!string.IsNullOrEmpty(strCOD_EST_ORI))
                                {
                                    maestro_activo.COD_EST_ORI = "01";
                                }
                                break;
                            }
                        }
                        this.db.SaveChanges();
                    }
                    transaction.Complete();
				}
			}
			catch (Exception ex)
			{
                Log.appendToLog(Log.LEVEL_WARN, ex.ToString());
				result = false;
				return result;
			}
			result = true;
			return result;
		}

        //GPE 4/8/2014 WAT-04052014 Point 2
        public bool checkCodMovID_isDonacionOrRetirado(int CodMovID)
        {
            bool result = false;
            try
            {

               var typeMov =
               (from c in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
               where c.ID_MOVIMIENTO == CodMovID
               select new
                {
                   ID_TIPO_MOVIMIENTO =  c.ID_TIPO_MOVIMIENTO
                }).FirstOrDefault();

               if (typeMov != null)
                   if (typeMov.ID_TIPO_MOVIMIENTO == 1 || typeMov.ID_TIPO_MOVIMIENTO == 2)
                       result = true;
              
            }
            catch (Exception)
            {
                result = false;
                return result;
            }
 
            return result;
        }
    }
}
