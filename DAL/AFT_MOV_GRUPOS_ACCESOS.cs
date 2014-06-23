using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_GRUPOS_ACCESOS")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_GRUPOS_ACCESOS : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_GRUPOS_ACCESOS object.
        /// </summary>
        /// <param name="iD_GRUPO">Initial value of the ID_GRUPO property.</param>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="eSTADO">Initial value of the ESTADO property.</param>
        public static AFT_MOV_GRUPOS_ACCESOS CreateAFT_MOV_GRUPOS_ACCESOS(global::System.Int32 iD_GRUPO, global::System.String cOD_COMPANIA, global::System.Boolean eSTADO, global::System.String cOD_CIA_PRO)
        {
            AFT_MOV_GRUPOS_ACCESOS aFT_MOV_GRUPOS_ACCESOS = new AFT_MOV_GRUPOS_ACCESOS();
            aFT_MOV_GRUPOS_ACCESOS.ID_GRUPO = iD_GRUPO;
            aFT_MOV_GRUPOS_ACCESOS.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_GRUPOS_ACCESOS.ESTADO = eSTADO;
            aFT_MOV_GRUPOS_ACCESOS.COD_CIA_PRO = cOD_CIA_PRO;
            return aFT_MOV_GRUPOS_ACCESOS;
        }

        #endregion
        #region Primitive Properties


        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_CIA_PRO
        {
            get
            {
                return _COD_CIA_PRO;
            }
            set
            {
                if (_COD_CIA_PRO != value)
                {
                    OnCOD_CIA_PROChanging(value);
                    ReportPropertyChanging("COD_CIA_PRO");
                    _COD_CIA_PRO = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_CIA_PRO");
                    OnCOD_CIA_PROChanged();
                }
            }
        }
        private global::System.String _COD_CIA_PRO;
        partial void OnCOD_CIA_PROChanging(global::System.String value);
        partial void OnCOD_CIA_PROChanged();


        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_GRUPO
        {
            get
            {
                return _ID_GRUPO;
            }
            set
            {
                if (_ID_GRUPO != value)
                {
                    OnID_GRUPOChanging(value);
                    ReportPropertyChanging("ID_GRUPO");
                    _ID_GRUPO = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_GRUPO");
                    OnID_GRUPOChanged();
                }
            }
        }
        private global::System.Int32 _ID_GRUPO;
        partial void OnID_GRUPOChanging(global::System.Int32 value);
        partial void OnID_GRUPOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_COMPANIA
        {
            get
            {
                return _COD_COMPANIA;
            }
            set
            {
                if (_COD_COMPANIA != value)
                {
                    OnCOD_COMPANIAChanging(value);
                    ReportPropertyChanging("COD_COMPANIA");
                    _COD_COMPANIA = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_COMPANIA");
                    OnCOD_COMPANIAChanged();
                }
            }
        }
        private global::System.String _COD_COMPANIA;
        partial void OnCOD_COMPANIAChanging(global::System.String value);
        partial void OnCOD_COMPANIAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DESCRIPCION
        {
            get
            {
                return _DESCRIPCION;
            }
            set
            {
                OnDESCRIPCIONChanging(value);
                ReportPropertyChanging("DESCRIPCION");
                _DESCRIPCION = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DESCRIPCION");
                OnDESCRIPCIONChanged();
            }
        }
        private global::System.String _DESCRIPCION;
        partial void OnDESCRIPCIONChanging(global::System.String value);
        partial void OnDESCRIPCIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String EMAIL_GRUPO
        {
            get
            {
                return _EMAIL_GRUPO;
            }
            set
            {
                OnEMAIL_GRUPOChanging(value);
                ReportPropertyChanging("EMAIL_GRUPO");
                _EMAIL_GRUPO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EMAIL_GRUPO");
                OnEMAIL_GRUPOChanged();
            }
        }
        private global::System.String _EMAIL_GRUPO;
        partial void OnEMAIL_GRUPOChanging(global::System.String value);
        partial void OnEMAIL_GRUPOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Boolean ESTADO
        {
            get
            {
                return _ESTADO;
            }
            set
            {
                OnESTADOChanging(value);
                ReportPropertyChanging("ESTADO");
                _ESTADO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ESTADO");
                OnESTADOChanged();
            }
        }
        private global::System.Boolean _ESTADO;
        partial void OnESTADOChanging(global::System.Boolean value);
        partial void OnESTADOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS")]
        public EntityCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPO_USUARIOS")]
        public EntityCollection<AFT_MOV_GRUPO_USUARIOS> AFT_MOV_GRUPO_USUARIOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_GRUPO_USUARIOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPO_USUARIOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_GRUPO_USUARIOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPO_USUARIOS", value);
                }
            }
        }

        #endregion
    }
}
