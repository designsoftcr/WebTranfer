using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_TIPOS_MOVIMIENTOS"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_TIPOS_MOVIMIENTOS : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DESCRIPCION_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _APLICA_CAMBIOS_SISTEMA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ESTADO_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string COD_COMPANIA
        {
            get
            {
                return this._COD_COMPANIA;
            }
            set
            {
                this.ReportPropertyChanging("COD_COMPANIA");
                this._COD_COMPANIA = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_COMPANIA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ID_TIPO_MOVIMIENTO
        {
            get
            {
                return this._ID_TIPO_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("ID_TIPO_MOVIMIENTO");
                this._ID_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID_TIPO_MOVIMIENTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DESCRIPCION_TIPO_MOVIMIENTO
        {
            get
            {
                return this._DESCRIPCION_TIPO_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("DESCRIPCION_TIPO_MOVIMIENTO");
                this._DESCRIPCION_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DESCRIPCION_TIPO_MOVIMIENTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? APLICA_CAMBIOS_SISTEMA
        {
            get
            {
                return this._APLICA_CAMBIOS_SISTEMA;
            }
            set
            {
                this.ReportPropertyChanging("APLICA_CAMBIOS_SISTEMA");
                this._APLICA_CAMBIOS_SISTEMA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("APLICA_CAMBIOS_SISTEMA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string ESTADO_ACTIVO
        {
            get
            {
                return this._ESTADO_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("ESTADO_ACTIVO");
                this._ESTADO_ACTIVO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("ESTADO_ACTIVO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_TIPOS_MOVIMIENTOS CreateAFT_MOV_TIPOS_MOVIMIENTOS(string cOD_COMPANIA, int iD_TIPO_MOVIMIENTO, string eSTADO_ACTIVO)
        {
            return new AFT_MOV_TIPOS_MOVIMIENTOS
            {
                COD_COMPANIA = cOD_COMPANIA,
                ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO,
                ESTADO_ACTIVO = eSTADO_ACTIVO
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_TIPOS_MOVIMIENTOS")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_TIPOS_MOVIMIENTOS : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_TIPOS_MOVIMIENTOS object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="iD_TIPO_MOVIMIENTO">Initial value of the ID_TIPO_MOVIMIENTO property.</param>
        /// <param name="eSTADO_ACTIVO">Initial value of the ESTADO_ACTIVO property.</param>
        public static AFT_MOV_TIPOS_MOVIMIENTOS CreateAFT_MOV_TIPOS_MOVIMIENTOS(global::System.String cOD_COMPANIA, global::System.Int32 iD_TIPO_MOVIMIENTO, global::System.String eSTADO_ACTIVO)
        {
            AFT_MOV_TIPOS_MOVIMIENTOS aFT_MOV_TIPOS_MOVIMIENTOS = new AFT_MOV_TIPOS_MOVIMIENTOS();
            aFT_MOV_TIPOS_MOVIMIENTOS.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_TIPOS_MOVIMIENTOS.ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO;
            aFT_MOV_TIPOS_MOVIMIENTOS.ESTADO_ACTIVO = eSTADO_ACTIVO;
            return aFT_MOV_TIPOS_MOVIMIENTOS;
        }

        #endregion
        #region Primitive Properties

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_TIPO_MOVIMIENTO
        {
            get
            {
                return _ID_TIPO_MOVIMIENTO;
            }
            set
            {
                if (_ID_TIPO_MOVIMIENTO != value)
                {
                    OnID_TIPO_MOVIMIENTOChanging(value);
                    ReportPropertyChanging("ID_TIPO_MOVIMIENTO");
                    _ID_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_TIPO_MOVIMIENTO");
                    OnID_TIPO_MOVIMIENTOChanged();
                }
            }
        }
        private global::System.Int32 _ID_TIPO_MOVIMIENTO;
        partial void OnID_TIPO_MOVIMIENTOChanging(global::System.Int32 value);
        partial void OnID_TIPO_MOVIMIENTOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DESCRIPCION_TIPO_MOVIMIENTO
        {
            get
            {
                return _DESCRIPCION_TIPO_MOVIMIENTO;
            }
            set
            {
                OnDESCRIPCION_TIPO_MOVIMIENTOChanging(value);
                ReportPropertyChanging("DESCRIPCION_TIPO_MOVIMIENTO");
                _DESCRIPCION_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DESCRIPCION_TIPO_MOVIMIENTO");
                OnDESCRIPCION_TIPO_MOVIMIENTOChanged();
            }
        }
        private global::System.String _DESCRIPCION_TIPO_MOVIMIENTO;
        partial void OnDESCRIPCION_TIPO_MOVIMIENTOChanging(global::System.String value);
        partial void OnDESCRIPCION_TIPO_MOVIMIENTOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> APLICA_CAMBIOS_SISTEMA
        {
            get
            {
                return _APLICA_CAMBIOS_SISTEMA;
            }
            set
            {
                OnAPLICA_CAMBIOS_SISTEMAChanging(value);
                ReportPropertyChanging("APLICA_CAMBIOS_SISTEMA");
                _APLICA_CAMBIOS_SISTEMA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("APLICA_CAMBIOS_SISTEMA");
                OnAPLICA_CAMBIOS_SISTEMAChanged();
            }
        }
        private Nullable<global::System.Boolean> _APLICA_CAMBIOS_SISTEMA;
        partial void OnAPLICA_CAMBIOS_SISTEMAChanging(Nullable<global::System.Boolean> value);
        partial void OnAPLICA_CAMBIOS_SISTEMAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String ESTADO_ACTIVO
        {
            get
            {
                return _ESTADO_ACTIVO;
            }
            set
            {
                OnESTADO_ACTIVOChanging(value);
                ReportPropertyChanging("ESTADO_ACTIVO");
                _ESTADO_ACTIVO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ESTADO_ACTIVO");
                OnESTADO_ACTIVOChanged();
            }
        }
        private global::System.String _ESTADO_ACTIVO;
        partial void OnESTADO_ACTIVOChanging(global::System.String value);
        partial void OnESTADO_ACTIVOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS")]
        public EntityCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS")]
        public EntityCollection<AFT_MOV_MAESTRO_MOVIMIENTOS> AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS", value);
                }
            }
        }

        #endregion
    }
}
