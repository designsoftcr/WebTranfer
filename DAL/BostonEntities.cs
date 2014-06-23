using System;
using System.CodeDom.Compiler;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;

namespace DAL
{
    public partial class BostonEntities : ObjectContext
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_CATAL_EMPLE> _AFM_CATAL_EMPLE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_CENTRO_COSTO> _AFM_CENTRO_COSTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> _AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_BITACORA> _AFT_MOV_BITACORA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO> _AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_GRUPO_USUARIOS> _AFT_MOV_GRUPO_USUARIOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_GRUPOS_ACCESOS> _AFT_MOV_GRUPOS_ACCESOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_MAESTRO_MOVIMIENTOS> _AFT_MOV_MAESTRO_MOVIMIENTOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_MOVIMIENTOS_APROBACIONES> _AFT_MOV_MOVIMIENTOS_APROBACIONES;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFT_MOV_TIPOS_MOVIMIENTOS> _AFT_MOV_TIPOS_MOVIMIENTOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_CATAL_LOCAL> _AFM_CATAL_LOCAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_MAEST_ACTIV> _AFM_MAEST_ACTIV;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_SECCI_LOCAL> _AFM_SECCI_LOCAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_UBICA_ACTIV> _AFM_UBICA_ACTIV;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_MARCA_ACTIV> _AFM_MARCA_ACTIV;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private ObjectQuery<AFM_MODEL_ACTIV> _AFM_MODEL_ACTIV;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_CATAL_EMPLE> AFM_CATAL_EMPLE
        {
            get
            {
                if (this._AFM_CATAL_EMPLE == null)
                {
                    this._AFM_CATAL_EMPLE = base.CreateQuery<AFM_CATAL_EMPLE>("[AFM_CATAL_EMPLE]", new ObjectParameter[0]);
                }
                return this._AFM_CATAL_EMPLE;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_CENTRO_COSTO> AFM_CENTRO_COSTO
        {
            get
            {
                if (this._AFM_CENTRO_COSTO == null)
                {
                    this._AFM_CENTRO_COSTO = base.CreateQuery<AFM_CENTRO_COSTO>("[AFM_CENTRO_COSTO]", new ObjectParameter[0]);
                }
                return this._AFM_CENTRO_COSTO;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                if (this._AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS == null)
                {
                    this._AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS = base.CreateQuery<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("[AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_BITACORA> AFT_MOV_BITACORA
        {
            get
            {
                if (this._AFT_MOV_BITACORA == null)
                {
                    this._AFT_MOV_BITACORA = base.CreateQuery<AFT_MOV_BITACORA>("[AFT_MOV_BITACORA]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_BITACORA;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO> AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
        {
            get
            {
                if (this._AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO == null)
                {
                    this._AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO = base.CreateQuery<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>("[AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_GRUPO_USUARIOS> AFT_MOV_GRUPO_USUARIOS
        {
            get
            {
                if (this._AFT_MOV_GRUPO_USUARIOS == null)
                {
                    this._AFT_MOV_GRUPO_USUARIOS = base.CreateQuery<AFT_MOV_GRUPO_USUARIOS>("[AFT_MOV_GRUPO_USUARIOS]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_GRUPO_USUARIOS;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_GRUPOS_ACCESOS> AFT_MOV_GRUPOS_ACCESOS
        {
            get
            {
                if (this._AFT_MOV_GRUPOS_ACCESOS == null)
                {
                    this._AFT_MOV_GRUPOS_ACCESOS = base.CreateQuery<AFT_MOV_GRUPOS_ACCESOS>("[AFT_MOV_GRUPOS_ACCESOS]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_GRUPOS_ACCESOS;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_MAESTRO_MOVIMIENTOS> AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                if (this._AFT_MOV_MAESTRO_MOVIMIENTOS == null)
                {
                    this._AFT_MOV_MAESTRO_MOVIMIENTOS = base.CreateQuery<AFT_MOV_MAESTRO_MOVIMIENTOS>("[AFT_MOV_MAESTRO_MOVIMIENTOS]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_MAESTRO_MOVIMIENTOS;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_MOVIMIENTOS_APROBACIONES> AFT_MOV_MOVIMIENTOS_APROBACIONES
        {
            get
            {
                if (this._AFT_MOV_MOVIMIENTOS_APROBACIONES == null)
                {
                    this._AFT_MOV_MOVIMIENTOS_APROBACIONES = base.CreateQuery<AFT_MOV_MOVIMIENTOS_APROBACIONES>("[AFT_MOV_MOVIMIENTOS_APROBACIONES]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_MOVIMIENTOS_APROBACIONES;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFT_MOV_TIPOS_MOVIMIENTOS> AFT_MOV_TIPOS_MOVIMIENTOS
        {
            get
            {
                if (this._AFT_MOV_TIPOS_MOVIMIENTOS == null)
                {
                    this._AFT_MOV_TIPOS_MOVIMIENTOS = base.CreateQuery<AFT_MOV_TIPOS_MOVIMIENTOS>("[AFT_MOV_TIPOS_MOVIMIENTOS]", new ObjectParameter[0]);
                }
                return this._AFT_MOV_TIPOS_MOVIMIENTOS;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_CATAL_LOCAL> AFM_CATAL_LOCAL
        {
            get
            {
                if (this._AFM_CATAL_LOCAL == null)
                {
                    this._AFM_CATAL_LOCAL = base.CreateQuery<AFM_CATAL_LOCAL>("[AFM_CATAL_LOCAL]", new ObjectParameter[0]);
                }
                return this._AFM_CATAL_LOCAL;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_MAEST_ACTIV> AFM_MAEST_ACTIV
        {
            get
            {
                if (this._AFM_MAEST_ACTIV == null)
                {
                    this._AFM_MAEST_ACTIV = base.CreateQuery<AFM_MAEST_ACTIV>("[AFM_MAEST_ACTIV]", new ObjectParameter[0]);
                }
                return this._AFM_MAEST_ACTIV;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_SECCI_LOCAL> AFM_SECCI_LOCAL
        {
            get
            {
                if (this._AFM_SECCI_LOCAL == null)
                {
                    this._AFM_SECCI_LOCAL = base.CreateQuery<AFM_SECCI_LOCAL>("[AFM_SECCI_LOCAL]", new ObjectParameter[0]);
                }
                return this._AFM_SECCI_LOCAL;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_UBICA_ACTIV> AFM_UBICA_ACTIV
        {
            get
            {
                if (this._AFM_UBICA_ACTIV == null)
                {
                    this._AFM_UBICA_ACTIV = base.CreateQuery<AFM_UBICA_ACTIV>("[AFM_UBICA_ACTIV]", new ObjectParameter[0]);
                }
                return this._AFM_UBICA_ACTIV;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_MARCA_ACTIV> AFM_MARCA_ACTIV
        {
            get
            {
                if (this._AFM_MARCA_ACTIV == null)
                {
                    this._AFM_MARCA_ACTIV = base.CreateQuery<AFM_MARCA_ACTIV>("[AFM_MARCA_ACTIV]", new ObjectParameter[0]);
                }
                return this._AFM_MARCA_ACTIV;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public ObjectQuery<AFM_MODEL_ACTIV> AFM_MODEL_ACTIV
        {
            get
            {
                if (this._AFM_MODEL_ACTIV == null)
                {
                    this._AFM_MODEL_ACTIV = base.CreateQuery<AFM_MODEL_ACTIV>("[AFM_MODEL_ACTIV]", new ObjectParameter[0]);
                }
                return this._AFM_MODEL_ACTIV;
            }
        }
        public BostonEntities()
            : base("name=BostonEntities", "BostonEntities")
        {
        }
        public BostonEntities(string connectionString)
            : base(connectionString, "BostonEntities")
        {
        }
        public BostonEntities(EntityConnection connection)
            : base(connection, "BostonEntities")
        {
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_CATAL_EMPLE(AFM_CATAL_EMPLE aFM_CATAL_EMPLE)
        {
            base.AddObject("AFM_CATAL_EMPLE", aFM_CATAL_EMPLE);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_CENTRO_COSTO(AFM_CENTRO_COSTO aFM_CENTRO_COSTO)
        {
            base.AddObject("AFM_CENTRO_COSTO", aFM_CENTRO_COSTO);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS(AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS)
        {
            base.AddObject("AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_BITACORA(AFT_MOV_BITACORA aFT_MOV_BITACORA)
        {
            base.AddObject("AFT_MOV_BITACORA", aFT_MOV_BITACORA);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO(AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO)
        {
            base.AddObject("AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO", aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_GRUPO_USUARIOS(AFT_MOV_GRUPO_USUARIOS aFT_MOV_GRUPO_USUARIOS)
        {
            base.AddObject("AFT_MOV_GRUPO_USUARIOS", aFT_MOV_GRUPO_USUARIOS);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_GRUPOS_ACCESOS(AFT_MOV_GRUPOS_ACCESOS aFT_MOV_GRUPOS_ACCESOS)
        {
            base.AddObject("AFT_MOV_GRUPOS_ACCESOS", aFT_MOV_GRUPOS_ACCESOS);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_MAESTRO_MOVIMIENTOS(AFT_MOV_MAESTRO_MOVIMIENTOS aFT_MOV_MAESTRO_MOVIMIENTOS)
        {
            base.AddObject("AFT_MOV_MAESTRO_MOVIMIENTOS", aFT_MOV_MAESTRO_MOVIMIENTOS);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_MOVIMIENTOS_APROBACIONES(AFT_MOV_MOVIMIENTOS_APROBACIONES aFT_MOV_MOVIMIENTOS_APROBACIONES)
        {
            base.AddObject("AFT_MOV_MOVIMIENTOS_APROBACIONES", aFT_MOV_MOVIMIENTOS_APROBACIONES);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFT_MOV_TIPOS_MOVIMIENTOS(AFT_MOV_TIPOS_MOVIMIENTOS aFT_MOV_TIPOS_MOVIMIENTOS)
        {
            base.AddObject("AFT_MOV_TIPOS_MOVIMIENTOS", aFT_MOV_TIPOS_MOVIMIENTOS);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_CATAL_LOCAL(AFM_CATAL_LOCAL aFM_CATAL_LOCAL)
        {
            base.AddObject("AFM_CATAL_LOCAL", aFM_CATAL_LOCAL);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_MAEST_ACTIV(AFM_MAEST_ACTIV aFM_MAEST_ACTIV)
        {
            base.AddObject("AFM_MAEST_ACTIV", aFM_MAEST_ACTIV);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_SECCI_LOCAL(AFM_SECCI_LOCAL aFM_SECCI_LOCAL)
        {
            base.AddObject("AFM_SECCI_LOCAL", aFM_SECCI_LOCAL);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_UBICA_ACTIV(AFM_UBICA_ACTIV aFM_UBICA_ACTIV)
        {
            base.AddObject("AFM_UBICA_ACTIV", aFM_UBICA_ACTIV);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_MARCA_ACTIV(AFM_MARCA_ACTIV aFM_MARCA_ACTIV)
        {
            base.AddObject("AFM_MARCA_ACTIV", aFM_MARCA_ACTIV);
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToAFM_MODEL_ACTIV(AFM_MODEL_ACTIV aFM_MODEL_ACTIV)
        {
            base.AddObject("AFM_MODEL_ACTIV", aFM_MODEL_ACTIV);
        }
    }
}
