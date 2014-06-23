using DAL;
using System;
using System.Data;
using System.Linq;
namespace BLL
{
    public class cls_procedimientos
    {
        private BostonEntities db = new BostonEntities();
        public DataTable carga_procedimiento_activo_solicitado(string placa_activo)
        {
            var maestro_Activos =
                from maestro in this.db.AFM_MAEST_ACTIV
                where maestro.PLA_ACTIVO == placa_activo
                join marca in this.db.AFM_MARCA_ACTIV on maestro.COD_MARCA equals marca.COD_MARCA
                join model in this.db.AFM_MODEL_ACTIV on new
                {
                    maestro.COD_MODELO,
                    maestro.COD_MARCA
                } equals new
                {
                    model.COD_MODELO,
                    model.COD_MARCA
                }
                join localizacion in this.db.AFM_CATAL_LOCAL on new
                {
                    maestro.COD_LOC_ACT,
                    maestro.COD_COMPANIA
                } equals new
                {
                    localizacion.COD_LOC_ACT,
                    localizacion.COD_COMPANIA
                }
                join seccion in this.db.AFM_SECCI_LOCAL on new
                {
                    maestro.COD_COMPANIA,
                    maestro.COD_LOC_ACT,
                    maestro.COD_SEC_LOC
                } equals new
                {
                    seccion.COD_COMPANIA,
                    seccion.COD_LOC_ACT,
                    seccion.COD_SEC_LOC
                }
                join ubicacion in this.db.AFM_UBICA_ACTIV on new
                {
                    maestro.COD_COMPANIA,
                    maestro.COD_LOC_ACT,
                    maestro.COD_SEC_LOC,
                    maestro.COD_UBI_ACT
                } equals new
                {
                    ubicacion.COD_COMPANIA,
                    ubicacion.COD_LOC_ACT,
                    ubicacion.COD_SEC_LOC,
                    ubicacion.COD_UBI_ACT
                }
                join centroCosto in this.db.AFM_CENTRO_COSTO on new
                {
                    maestro.COD_CEN_CST,
                    maestro.COD_COMPANIA
                } equals new
                {
                    centroCosto.COD_CEN_CST,
                    centroCosto.COD_COMPANIA
                }
                select new
                {
                    COD_COMPANIA = maestro.COD_COMPANIA,
                    NUM_ACTIVO = maestro.NUM_ACTIVO,
                    PLA_ACTIVO = maestro.PLA_ACTIVO,
                    DES_ACTIVO = maestro.DES_ACTIVO,
                    SER_ACTIVO = maestro.SER_ACTIVO,
                    VAL_LIBROS = maestro.VAL_LIBROS ?? 0m,
                    COD_MARCA = maestro.COD_MARCA,
                    DES_MARCA = marca.DES_MARCA,
                    COD_MODELO = maestro.COD_MODELO,
                    NOM_MODELO = model.NOM_MODELO,
                    COD_LOC_ACT = maestro.COD_LOC_ACT,
                    DES_LOC_ACT = localizacion.DES_LOC_ACT,
                    COD_SEC_LOC = maestro.COD_SEC_LOC,
                    DES_SEC_LOC = seccion.DES_SEC_LOC,
                    COD_UBI_ACT = maestro.COD_UBI_ACT,
                    DES_UBI_ACT = ubicacion.DES_UBI_ACT,
                    COD_CEN_CST = maestro.COD_CEN_CST,
                    DES_CEN_CST = centroCosto.DES_CEN_CST,
                    COD_EMPLEADO = centroCosto.COD_EMPLEADO ?? ""
                };
            return maestro_Activos.AsDataTable();
        }
    }
}
