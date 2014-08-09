using System;
using System.Data;
using System.Xml.Linq;
namespace Entidades
{
    public class ent_traslado
    {
        public string codigo_compania
        {
            get;
            set; 
        }
        public string centro_costo
        {
            get;
            set;
        }
        public string codigo_empleado
        {
            get;
            set;
        }
        public string descripcion_centro_costo
        {
            get;
            set;
        }
        public string empleado_responsable_cc
        {
            get;
            set;
        }
        public int codigo_tipo_movimiento
        {
            get;
            set;
        }
        public string estado
        {
            get;
            set;
        }
        public DateTime fecha_movimiento
        {
            get;
            set;
        }
        public int codigo_paso_aprobacion_actual
        {
            get;
            set;
        }
        public XDocument detalle_destino_movimiento
        {
            get;
            set;
        }
        public string codigo_localizacion_activo
        {
            get;
            set;
        }
        public string codigo_seccion_activo
        {
            get;
            set;
        }
        public string codigo_ubicacion_activo
        {
            get;
            set;
        }
        public string numero_activo
        {
            get;
            set;
        }
        public string placa
        {
            get;
            set;
        }
        public DataTable activo_solicitado
        {
            get;
            set;
        }
        public int codigo_bitacora
        {
            get;
            set;
        }
        public int id_movimiento
        {
            get;
            set;
        }
        public string descripcion
        {
            get;
            set;
        }
        public DateTime fecha
        {
            get;
            set;
        }
        public string paso_aprobacion_actual
        {
            get;
            set;
        }
        public string descripcion_tipo_movimiento
        {
            get;
            set;
        }
        public string usuario
        {
            get;
            set;
        }
        public string acta
        {
            get;
            set;
        }

        public bool posee_placas
        {
            get;
            set;
        }

        /*public string codigo_localizacion_activo_dest
        {
            get;
            set;
        }
        public string codigo_seccion_activo_dest
        {
            get;
            set;
        }
        public string codigo_ubicacion_activo_dest
        {
            get;
            set;
        }
        public string cod_usuario_responsable_destino
        {
            get;
            set;
        }
        public string centro_costo_destino
        {
            get;
            set;
        }*/

    }
}
