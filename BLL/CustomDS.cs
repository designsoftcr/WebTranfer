using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entidades;
using System.Transactions;
using System.Data;



namespace BLL
{
    public class CustomDS
    {
        private static List<Report> _lstReport = null;
        private BostonEntities db = new BostonEntities();

        public List<Report> GetReport(int id, string code_compania)
        {
                _lstReport = new List<Report>();
                
                var list = (from c in this.db.AFT_MOV_BITACORA
                            join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                            on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO

                            join e in this.db.AFM_CATAL_EMPLE
                            on d.ID_EMPLEADO equals e.COD_EMPLEADO

                            join g in this.db.AFM_CENTRO_COSTO
                            on d.CENTRO_COSTO equals g.COD_CEN_CST

                            where c.CODIGO_BITACORA == id
                            select new
                            {
                                BITACORA = c,
                                MOVIMIENTOS = d,
                                CENTRO_COSTO = g,
                                CATAL_EMPLE = e
                            }).FirstOrDefault();

                Report report = new Report();

                report.Tipo_de_Movimiento = list.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO;
                report.Solicitud_Numero = list.BITACORA.ID_MOVIMIENTO.ToString();
                report.Planta = new cls_traslado().nombre_localizacion(list.CENTRO_COSTO.COD_CEN_CST);
                report.Solicitante = list.CATAL_EMPLE.NOM_EMPLEADO;

                if (!string.IsNullOrEmpty(list.CENTRO_COSTO.DES_CEN_CST))
                    report.Centro_de_Costo_Descripcion = list.CENTRO_COSTO.DES_CEN_CST;
                else
                    report.Centro_de_Costo_Descripcion = string.Empty;

                report.Centro_de_Costo_Actual = list.MOVIMIENTOS.CENTRO_COSTO;
               
                report.Ubicacion_Actual = new cls_traslado().cargar_ubicacion_actual(code_compania, System.Convert.ToInt32(list.BITACORA.ID_MOVIMIENTO.ToString()));
            
                report.TotalValorLibros = new cls_traslado().valor_libros(code_compania, System.Convert.ToInt32(list.BITACORA.ID_MOVIMIENTO.ToString())).ToString("C2");    

                _lstReport.Add(report);
            
            return _lstReport;
        }

        public List<AFT_MOV_BITACORA> GetReportHistorico(int id)
        {
            var list = (from c in this.db.AFT_MOV_BITACORA
                        join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                        on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO

                        join e in this.db.AFM_CATAL_EMPLE
                        on d.ID_EMPLEADO equals e.COD_EMPLEADO

                        join g in this.db.AFM_CENTRO_COSTO
                        on d.CENTRO_COSTO equals g.COD_CEN_CST

                        where c.CODIGO_BITACORA == id
                        select new
                        {
                            BITACORA = c,
                            MOVIMIENTOS = d,
                            CENTRO_COSTO = g,
                            CATAL_EMPLE = e
                        }).FirstOrDefault();
          
            List<AFT_MOV_BITACORA> historico = new cls_bitacora().cargar_bitacora_historico(list.BITACORA.ID_MOVIMIENTO);

            return historico;
        }

        public List<Activo> GetReportActivo(int id, string code_compania)
        {
            var list = (from c in this.db.AFT_MOV_BITACORA
                        join d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                        on c.ID_MOVIMIENTO equals d.ID_MOVIMIENTO

                        join e in this.db.AFM_CATAL_EMPLE
                        on d.ID_EMPLEADO equals e.COD_EMPLEADO

                        join g in this.db.AFM_CENTRO_COSTO
                        on d.CENTRO_COSTO equals g.COD_CEN_CST

                        where c.CODIGO_BITACORA == id
                        select new
                        {
                            BITACORA = c,
                            MOVIMIENTOS = d,
                            CENTRO_COSTO = g,
                            CATAL_EMPLE = e
                        }).FirstOrDefault();

            var activos =
                from c in this.db.AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
                from d in this.db.AFM_MAEST_ACTIV
                where c.PLACA == d.PLA_ACTIVO && c.COD_COMPANIA == code_compania && c.ID_MOVIMIENTO == list.BITACORA.ID_MOVIMIENTO
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
            
            List<Activo> activo = new List<Activo>();

            foreach(var a in activos)
            {
                Activo act = new Activo();
                act.Activo_Placa = a.PLA_ACTIVO;
                act.Activo_ActivoSAP = a.REF_NUM_ACT;
                act.Activo_Descripcion_delActivo = a.DES_ACTIVO;
                act.Activo_Marca = a.DES_MARCA;
                act.Activo_Modelo = a.NOM_MODELO;
                act.Activo_Serie = a.SER_ACTIVO;
                act.Activo_ValorLibros = a.VAL_LIBROS;

                activo.Add(act);
            }

           
                //new cls_traslado().cargar_activos_grid(code_compania, list.BITACORA.ID_MOVIMIENTO);

            return activo;
        }



        public List<Imprimir> GetReportImprimir(int id_movimiento, string usuario, string code_centro_costo, string code_solicitante, string fetcha, string tipomovimiento)
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

            if (!string.IsNullOrEmpty(tipomovimiento) && tipomovimiento != "NULL")
                allList = allList.Where(a => a.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO == tipomovimiento);

            if (!string.IsNullOrEmpty(code_centro_costo) && code_centro_costo != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.CENTRO_COSTO == code_centro_costo);

            if (!string.IsNullOrEmpty(code_solicitante) && code_solicitante != "NULL")
                allList = allList.Where(a => a.MOVIMIENTOS.ID_EMPLEADO == code_solicitante);


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

            List<Imprimir> imprimirreport = new List<Imprimir>();

            foreach (var a in movimientos)
            {
                Imprimir imprimir = new Imprimir();
                imprimir.Imprimir_CodigoMovimiento = a.ID_MOVIMIENTO;
                imprimir.Imprimir_CodigoCompania = a.ID_CODIGO_COMPANIA;
                imprimir.Imprimir_Descripcion = a.DESCRIPCION;
                imprimir.Imprimir_Fetcha = a.FECHA;
                imprimir.Imprimir_PasoAcrobacion = a.PASO_APROVACION_ACTUAL;
                imprimir.Imprimir_Usuario = a.USUARIO;
                imprimir.Imprimir_Descripcion_Tipo_Movimiento = a.DESCRIPCION_TIPO_MOVIMIENTO;

                imprimirreport.Add(imprimir);
            }

            return imprimirreport;
        }

        public List<MovMaestro> GetReportMovMaestro(int id_movimiento, string cod_centro_costo, string cod_solicitante, string fetcha, int tipo_movimiento)
        {
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
            if (tipo_movimiento != 0 && (tipo_movimiento > 0 && tipo_movimiento < 8))
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
                    ESTADO = r.AFT_MOV_MAESTRO_MOVIMIENTOS.ESTADO
                };

            List<MovMaestro> movmaestroreport = new List<MovMaestro>();

            foreach (var a in movimientos)
            {
                MovMaestro movmaestro = new MovMaestro();
                movmaestro.MovMaestro_ID_MOVIMIENTO = a.ID_MOVIMIENTO;
                movmaestro.MovMaestro_ACTA = a.ACTA;
                movmaestro.MovMaestro_CENTRO_COSTO = a.CENTRO_COSTO;
                movmaestro.MovMaestro_ID_EMPLEADO = a.ID_EMPLEADO;
                movmaestro.MovMaestro_FECHA_MOVIMIENTO = a.FECHA_MOVIMIENTO;
                movmaestro.MovMaestro_DESCRIPCION_CENTRO_COSTOS = a.DESCRIPCION_CENTRO_COSTOS;
                movmaestro.MovMaestro_EMPLEADO_RESPONSABLE_CC = a.EMPLEADO_RESPONSABLE_CC;
                movmaestro.MovMaestro_ID_TIPO_MOVIMIENTO = a.ID_TIPO_MOVIMIENTO;


                string text = a.ESTADO;
                if (text != null)
                {
                    if (!(text == "A"))
                    {
                        if (!(text == "P"))
                        {
                            if (text == "C")
                            {
                                movmaestro.MovMaestro_ESTADO = "Cancelado";
                            }
                        }
                        else
                        {
                            movmaestro.MovMaestro_ESTADO = "Pendiente";
                        }
                    }
                    else
                    {
                        movmaestro.MovMaestro_ESTADO = "Aceptado";
                    }
                }
                
                movmaestroreport.Add(movmaestro);
            }

            return movmaestroreport;

        }
     
    }
}
