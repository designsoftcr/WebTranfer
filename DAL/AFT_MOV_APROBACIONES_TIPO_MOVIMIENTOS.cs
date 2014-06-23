using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_APROBACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int? _ID_GRUPO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _REQUIERE_APROBACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _ESTADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ID_APROBACION
        {
            get
            {
                return this._ID_APROBACION;
            }
            set
            {
                this.ReportPropertyChanging("ID_APROBACION");
                this._ID_APROBACION = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID_APROBACION");
            }
        }
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
        public int? ID_GRUPO
        {
            get
            {
                return this._ID_GRUPO;
            }
            set
            {
                this.ReportPropertyChanging("ID_GRUPO");
                this._ID_GRUPO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID_GRUPO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? REQUIERE_APROBACION
        {
            get
            {
                return this._REQUIERE_APROBACION;
            }
            set
            {
                this.ReportPropertyChanging("REQUIERE_APROBACION");
                this._REQUIERE_APROBACION = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("REQUIERE_APROBACION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? ESTADO
        {
            get
            {
                return this._ESTADO;
            }
            set
            {
                this.ReportPropertyChanging("ESTADO");
                this._ESTADO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ESTADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS"), DataMember, SoapIgnore, XmlIgnore]
        public AFT_MOV_TIPOS_MOVIMIENTOS AFT_MOV_TIPOS_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFT_MOV_TIPOS_MOVIMIENTOS> AFT_MOV_TIPOS_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES> AFT_MOV_MOVIMIENTOS_APROBACIONES
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS CreateAFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS(int iD_APROBACION, string cOD_COMPANIA, int iD_TIPO_MOVIMIENTO)
        {
            return new AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
            {
                ID_APROBACION = iD_APROBACION,
                COD_COMPANIA = cOD_COMPANIA,
                ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO
            };
        }
    }
     * */

    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS object.
        /// </summary>
        /// <param name="iD_APROBACION">Initial value of the ID_APROBACION property.</param>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="iD_TIPO_MOVIMIENTO">Initial value of the ID_TIPO_MOVIMIENTO property.</param>
        public static AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS CreateAFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS(global::System.Int32 iD_APROBACION, global::System.String cOD_COMPANIA, global::System.Int32 iD_TIPO_MOVIMIENTO)
        {
            AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS = new AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS();
            aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS.ID_APROBACION = iD_APROBACION;
            aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS.ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO;
            return aFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_APROBACION
        {
            get
            {
                return _ID_APROBACION;
            }
            set
            {
                if (_ID_APROBACION != value)
                {
                    OnID_APROBACIONChanging(value);
                    ReportPropertyChanging("ID_APROBACION");
                    _ID_APROBACION = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_APROBACION");
                    OnID_APROBACIONChanged();
                }
            }
        }
        private global::System.Int32 _ID_APROBACION;
        partial void OnID_APROBACIONChanging(global::System.Int32 value);
        partial void OnID_APROBACIONChanged();

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
        public Nullable<global::System.Int32> ID_GRUPO
        {
            get
            {
                return _ID_GRUPO;
            }
            set
            {
                OnID_GRUPOChanging(value);
                ReportPropertyChanging("ID_GRUPO");
                _ID_GRUPO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_GRUPO");
                OnID_GRUPOChanged();
            }
        }
        private Nullable<global::System.Int32> _ID_GRUPO;
        partial void OnID_GRUPOChanging(Nullable<global::System.Int32> value);
        partial void OnID_GRUPOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> REQUIERE_APROBACION
        {
            get
            {
                return _REQUIERE_APROBACION;
            }
            set
            {
                OnREQUIERE_APROBACIONChanging(value);
                ReportPropertyChanging("REQUIERE_APROBACION");
                _REQUIERE_APROBACION = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("REQUIERE_APROBACION");
                OnREQUIERE_APROBACIONChanged();
            }
        }
        private Nullable<global::System.Boolean> _REQUIERE_APROBACION;
        partial void OnREQUIERE_APROBACIONChanging(Nullable<global::System.Boolean> value);
        partial void OnREQUIERE_APROBACIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> ESTADO
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
        private Nullable<global::System.Boolean> _ESTADO;
        partial void OnESTADOChanging(Nullable<global::System.Boolean> value);
        partial void OnESTADOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS")]
        public AFT_MOV_GRUPOS_ACCESOS AFT_MOV_GRUPOS_ACCESOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFT_MOV_GRUPOS_ACCESOS> AFT_MOV_GRUPOS_ACCESOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS")]
        public AFT_MOV_TIPOS_MOVIMIENTOS AFT_MOV_TIPOS_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFT_MOV_TIPOS_MOVIMIENTOS> AFT_MOV_TIPOS_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES")]
        public EntityCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES> AFT_MOV_MOVIMIENTOS_APROBACIONES
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES", value);
                }
            }
        }

        #endregion
    }
}
