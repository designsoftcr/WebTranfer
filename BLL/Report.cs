using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class Report
    {
        public string Tipo_de_Movimiento { get; set; }
        public string Solicitud_Numero { get; set; }
        public string Planta { get; set; }
        public string Solicitante { get; set; }

        public string Ubicacion_Actual { get; set; }
        public string Centro_de_Costo_Actual { get; set; }
        public string Centro_de_Costo_Descripcion { get; set; }

        public string TotalValorLibros { get; set; }
    }

    public class Activo
    {
        public string Activo_Placa { get; set; }
        public string Activo_ActivoSAP { get; set; }
        public string Activo_Descripcion_delActivo { get; set; }
        public string Activo_Marca { get; set; }
        public string Activo_Modelo { get; set; }
        public string Activo_Serie { get; set; }
        public Decimal? Activo_ValorLibros { get; set; }
    }

    public class Imprimir
    {
        public int Imprimir_CodigoMovimiento { get; set; }
        public string Imprimir_CodigoCompania { get; set; }
        public DateTime Imprimir_Fetcha { get; set; }
        public string Imprimir_PasoAcrobacion { get; set; }
        public string Imprimir_Usuario { get; set; }
        public string Imprimir_Descripcion { get; set; }
        public string Imprimir_Descripcion_Tipo_Movimiento { get; set; }
        public string Imprimir_Estado { get; set; }
    }

    public class MovMaestro
    {
        public int MovMaestro_ID_MOVIMIENTO { get; set; }
        public string MovMaestro_ACTA { get; set; }
        public DateTime MovMaestro_FECHA_MOVIMIENTO { get; set; }
        public string MovMaestro_CENTRO_COSTO { get; set; }
        public string MovMaestro_ID_EMPLEADO { get; set; }
        public string MovMaestro_DESCRIPCION_CENTRO_COSTOS { get; set; }
        public string MovMaestro_EMPLEADO_RESPONSABLE_CC { get; set; }
        public string MovMaestro_ID_TIPO_MOVIMIENTO { get; set; }
        public string MovMaestro_ESTADO { get; set; }
    }
}
