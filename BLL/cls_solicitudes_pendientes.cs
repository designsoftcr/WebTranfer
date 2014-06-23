using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class cls_solicitudes_pendientes
    {
        private BostonEntities db = new BostonEntities();


        public DataTable get_pending_request_by_ID(string id_compania)
        {
            var all_movientos = from d in this.db.AFT_MOV_MAESTRO_MOVIMIENTOS
                          where d.ESTADO == "P" && d.COD_COMPANIA == id_compania
                          select new
                          {
                            CENTRO_COSTO =  d.CENTRO_COSTO,
                            COD_COMPANIA =  d.COD_COMPANIA,
                            DESCRIPCION_CENTRO_COSTOS = d.DESCRIPCION_CENTRO_COSTOS,
                            EMPLEADO_RESPONSABLE_CC = d.EMPLEADO_RESPONSABLE_CC,
                            FECHA_MOVIMIENTO = d.FECHA_MOVIMIENTO,
                            ID_EMPLEADO = d.ID_EMPLEADO,
                            ID_MOVIMIENTO = d.ID_MOVIMIENTO,
                            ID_PASO_APROBACION_ACTUAL = d.ID_PASO_APROBACION_ACTUAL
                          };

            return all_movientos.AsDataTable();
        }


        public Entidades.ent_bitacora get_pending_last_from_bitacora(int id_movimiento)
        {
            var pending_request_last =
                (from d in this.db.AFT_MOV_BITACORA
                 where d.ID_MOVIMIENTO == id_movimiento
                 orderby d.CODIGO_BITACORA descending
                 select new 
                 {
                     BITACORA = d
                 }
                 ).FirstOrDefault();

            Entidades.ent_bitacora bit = new Entidades.ent_bitacora();

            if (ReferenceEquals(pending_request_last, null))
                return null;

            bit.CODIGO_BITACORA = pending_request_last.BITACORA.CODIGO_BITACORA;
            bit.ID_MOVIMIENTO = pending_request_last.BITACORA.ID_MOVIMIENTO;
            bit.COD_COMPANIA = pending_request_last.BITACORA.COD_COMPANIA;
            bit.DESCRIPCION = pending_request_last.BITACORA.DESCRIPCION;
            bit.FECHA = pending_request_last.BITACORA.FECHA;
            bit.DESCRIPCION_TIPO_MOVIMIENTO = pending_request_last.BITACORA.DESCRIPCION_TIPO_MOVIMIENTO;
            bit.USUARIO = pending_request_last.BITACORA.USUARIO;
            bit.PASO_APROBACION = pending_request_last.BITACORA.PASO_APROBACION;
            return bit;
        }
    }
}
