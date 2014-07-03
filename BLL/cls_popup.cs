using DAL;
using System;
using System.Data;
using System.Linq;
namespace BLL
{
    public class cls_popup
    {
        private BostonEntities db = new BostonEntities();
        public DataTable cargar_empleado_filtro(string nombre_empleado)
        {
            var empleado =
                from c in this.db.AFM_CATAL_EMPLE
                where nombre_empleado == "todo" || c.NOM_EMPLEADO.Contains(nombre_empleado)
                select new
                {
                    COD_EMPLEADO = c.COD_EMPLEADO,
                    NOMBRE_EMPLEADO = c.NOM_EMPLEADO
                };
            return empleado.AsDataTable();
        }
        public DataTable cargar_centros_costo_filtro(string descripcion, string strCod_Cia_Pro, string strCOD_CEN_CST, string strMovementType)
        {
            if (!string.IsNullOrEmpty(strCOD_CEN_CST))
            {
                if (strMovementType == "5")
                {
                    var centros_costo =
                    from c in this.db.AFM_CENTRO_COSTO
                    where c.COD_CIA_PRO == strCod_Cia_Pro && c.COD_CEN_CST == strCOD_CEN_CST && descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                    select new
                    {
                        COD_CENTRO_COSTO = c.COD_CEN_CST,
                        CENTRO_COSTO = c.DES_CEN_CST
                    };
                    return centros_costo.AsDataTable();
                }
                else if (strMovementType == "7") {
                    var centros_costo =
                        from c in this.db.AFM_CENTRO_COSTO
                        where c.COD_CIA_PRO != strCod_Cia_Pro && c.COD_CEN_CST == strCOD_CEN_CST && descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                        select new
                        {
                            COD_CENTRO_COSTO = c.COD_CEN_CST,
                            CENTRO_COSTO = c.DES_CEN_CST
                        };
                    return centros_costo.AsDataTable();
                }
                return null;
            }
            else {

                if (strMovementType == "5")
                {
                    var centros_costo =
                    from c in this.db.AFM_CENTRO_COSTO
                    where c.COD_CIA_PRO == strCod_Cia_Pro && descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                    select new
                    {
                        COD_CENTRO_COSTO = c.COD_CEN_CST,
                        CENTRO_COSTO = c.DES_CEN_CST
                    };
                    return centros_costo.AsDataTable();
                }
                else if (strMovementType == "7")
                {
                    var centros_costo =
                        from c in this.db.AFM_CENTRO_COSTO
                        where c.COD_CIA_PRO != strCod_Cia_Pro && descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                        select new
                        {
                            COD_CENTRO_COSTO = c.COD_CEN_CST,
                            CENTRO_COSTO = c.DES_CEN_CST
                        };
                    return centros_costo.AsDataTable();
                }
                else
                {

                    var centros_costo = from c in this.db.AFM_CENTRO_COSTO
                                        where c.COD_CIA_PRO == strCod_Cia_Pro && descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                                        select new
                                        {
                                            COD_CENTRO_COSTO = c.COD_CEN_CST,
                                            CENTRO_COSTO = c.DES_CEN_CST
                                        };
                    return centros_costo.AsDataTable();
                }
            }
            
        }


        public DataTable cargar_centros_costo_filtro(string descripcion, string strCOD_CEN_CST)
        {
            if (!string.IsNullOrEmpty(strCOD_CEN_CST))
            {
                var centros_costo =
                from c in this.db.AFM_CENTRO_COSTO
                where descripcion == "todo" && c.COD_CEN_CST == strCOD_CEN_CST || c.DES_CEN_CST.Contains(descripcion)
                select new
                {
                    COD_CENTRO_COSTO = c.COD_CEN_CST,
                    CENTRO_COSTO = c.DES_CEN_CST
                };
                return centros_costo.AsDataTable();
            }
            else {
                var centros_costo =
                from c in this.db.AFM_CENTRO_COSTO
                where descripcion == "todo" || c.DES_CEN_CST.Contains(descripcion)
                select new
                {
                    COD_CENTRO_COSTO = c.COD_CEN_CST,
                    CENTRO_COSTO = c.DES_CEN_CST
                };
                            return centros_costo.AsDataTable();
            }
        }

        //add by GPE 14.09.2013
        public DataTable cargar_grupos_de_acceso(string descripcion)
        {
            var grupos_de_acceso =
                from c in this.db.AFT_MOV_GRUPOS_ACCESOS
                where descripcion == "todo" || c.DESCRIPCION.Contains(descripcion)
                select new
                {
                    ID_GRUPO = c.ID_GRUPO,
                    DESCRIPCION = c.DESCRIPCION,
                    COD_COMPANIA = c.COD_COMPANIA,
                    EMAIL_GRUPO = c.EMAIL_GRUPO,
                    ESTADO = c.ESTADO,
                    COD_CIA_PRO = c.COD_CIA_PRO
                };
            return grupos_de_acceso.AsDataTable();
        }

        public DataTable cargar_grupos_de_acceso(int iCodigo, string descripcion)
        {
            if (iCodigo > 0)
            {
                var grupos_de_acceso =
                    from c in this.db.AFT_MOV_GRUPOS_ACCESOS
                    where c.ID_GRUPO == iCodigo
                    select new
                    {
                        ID_GRUPO = c.ID_GRUPO,
                        DESCRIPCION = c.DESCRIPCION,
                        COD_COMPANIA = c.COD_COMPANIA,
                        EMAIL_GRUPO = c.EMAIL_GRUPO,
                        ESTADO = c.ESTADO,
                        COD_CIA_PRO = c.COD_CIA_PRO
                    };
                return grupos_de_acceso.AsDataTable();
            }
            else
            {
                var grupos_de_acceso =
                    from c in this.db.AFT_MOV_GRUPOS_ACCESOS
                    where descripcion == "todo" || c.DESCRIPCION.Contains(descripcion)
                    select new
                    {
                        ID_GRUPO = c.ID_GRUPO,
                        DESCRIPCION = c.DESCRIPCION,
                        COD_COMPANIA = c.COD_COMPANIA,
                        EMAIL_GRUPO = c.EMAIL_GRUPO,
                        ESTADO = c.ESTADO,
                        COD_CIA_PRO = c.COD_CIA_PRO
                    };
                return grupos_de_acceso.AsDataTable();
            }
            
        }

        //add by GPE 16.09.2013
        public DataTable cargar_usuarios_por_grupo_de_acceso(string descripcion)
        {
            var grupos_de_acceso =
                from c in this.db.AFT_MOV_GRUPO_USUARIOS
                join d in this.db.AFM_CATAL_EMPLE                
                on c.ID_EMPLEADO equals d.COD_EMPLEADO
                join e in this.db.AFT_MOV_GRUPOS_ACCESOS
                on c.ID_GRUPO equals e.ID_GRUPO
                where descripcion == "todo" || d.NOM_EMPLEADO.Contains(descripcion)
                select new
                {
                    COD_EMPLEADO = d.COD_EMPLEADO,
                    NOM_EMPLEADO = d.NOM_EMPLEADO,
                    ID_GRUPO = c.ID_GRUPO,
                    DESCRIPCION = e.DESCRIPCION,
                    COD_COMPANIA = c.COD_COMPANIA,
                    USUARIO = c.USUARIO,
                    ESTADO = c.ESTADO,
                    COD_COMPANIA_PROP = e.COD_CIA_PRO
                };
            return grupos_de_acceso.AsDataTable();
        }

        //add by GPE 16.09.2013
        public DataTable cargar_usuarios_por_grupo_de_acceso_id_grupo(string descripcion)
        {
            var grupos_de_acceso =
                from c in this.db.AFT_MOV_GRUPOS_ACCESOS
                where descripcion == "todo" || c.DESCRIPCION.Contains(descripcion)
                select new
                {
                    ID_GRUPO = c.ID_GRUPO,
                    DESCRIPCION = c.DESCRIPCION,
                    COD_COMPANIA = c.COD_CIA_PRO
                };
            return grupos_de_acceso.AsDataTable();
        }

        //add by GPE 16.09.2013
        public DataTable cargar_usuarios_por_grupo_de_acceso_empleado(string descripcion)
        {
            var grupos_de_empleado =
                from c in this.db.AFM_CATAL_EMPLE
                where descripcion == "todo" || c.NOM_EMPLEADO.Contains(descripcion)
                select new
                {
                    COD_EMPLEADO = c.COD_EMPLEADO,
                    NOM_EMPLEADO = c.NOM_EMPLEADO
                };
            return grupos_de_empleado.AsDataTable();
        }

        //add by GPE 24.02.2014
        public DataTable cargar_usuarios_por_grupo_de_propetary_company(string descripcion)
        {
            var grupos_de_propetary_company =
                from c in this.db.AFM_CIAS
                where descripcion == "todo" || c.NOM_COMPANIA.Contains(descripcion)
                select new
                {
                    COD_COMPANIA = c.COD_COMPANIA,
                    NOM_COMPANIA = c.NOM_COMPANIA
                };
            return grupos_de_propetary_company.AsDataTable();
        }
        
    }
}
