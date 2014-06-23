using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_MOVIMIENTOS_APROBACIONES"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_MOVIMIENTOS_APROBACIONES : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_APROBACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FECHA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _APROBADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ID_EMPLEADO;
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
        public int ID_MOVIMIENTO
        {
            get
            {
                return this._ID_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("ID_MOVIMIENTO");
                this._ID_MOVIMIENTO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID_MOVIMIENTO");
            }
        }
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
        public DateTime? FECHA
        {
            get
            {
                return this._FECHA;
            }
            set
            {
                this.ReportPropertyChanging("FECHA");
                this._FECHA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FECHA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? APROBADO
        {
            get
            {
                return this._APROBADO;
            }
            set
            {
                this.ReportPropertyChanging("APROBADO");
                this._APROBADO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("APROBADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string ID_EMPLEADO
        {
            get
            {
                return this._ID_EMPLEADO;
            }
            set
            {
                this.ReportPropertyChanging("ID_EMPLEADO");
                this._ID_EMPLEADO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("ID_EMPLEADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS"), DataMember, SoapIgnore, XmlIgnore]
        public AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_MOVIMIENTOS_APROBACIONES CreateAFT_MOV_MOVIMIENTOS_APROBACIONES(string cOD_COMPANIA, int iD_MOVIMIENTO, int iD_APROBACION, int iD_TIPO_MOVIMIENTO, string iD_EMPLEADO)
        {
            return new AFT_MOV_MOVIMIENTOS_APROBACIONES
            {
                COD_COMPANIA = cOD_COMPANIA,
                ID_MOVIMIENTO = iD_MOVIMIENTO,
                ID_APROBACION = iD_APROBACION,
                ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO,
                ID_EMPLEADO = iD_EMPLEADO
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_MOVIMIENTOS_APROBACIONES")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_MOVIMIENTOS_APROBACIONES : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_MOVIMIENTOS_APROBACIONES object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="iD_MOVIMIENTO">Initial value of the ID_MOVIMIENTO property.</param>
        /// <param name="iD_APROBACION">Initial value of the ID_APROBACION property.</param>
        /// <param name="iD_TIPO_MOVIMIENTO">Initial value of the ID_TIPO_MOVIMIENTO property.</param>
        /// <param name="iD_EMPLEADO">Initial value of the ID_EMPLEADO property.</param>
        public static AFT_MOV_MOVIMIENTOS_APROBACIONES CreateAFT_MOV_MOVIMIENTOS_APROBACIONES(global::System.String cOD_COMPANIA, global::System.Int32 iD_MOVIMIENTO, global::System.Int32 iD_APROBACION, global::System.Int32 iD_TIPO_MOVIMIENTO, global::System.String iD_EMPLEADO)
        {
            AFT_MOV_MOVIMIENTOS_APROBACIONES aFT_MOV_MOVIMIENTOS_APROBACIONES = new AFT_MOV_MOVIMIENTOS_APROBACIONES();
            aFT_MOV_MOVIMIENTOS_APROBACIONES.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_MOVIMIENTOS_APROBACIONES.ID_MOVIMIENTO = iD_MOVIMIENTO;
            aFT_MOV_MOVIMIENTOS_APROBACIONES.ID_APROBACION = iD_APROBACION;
            aFT_MOV_MOVIMIENTOS_APROBACIONES.ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO;
            aFT_MOV_MOVIMIENTOS_APROBACIONES.ID_EMPLEADO = iD_EMPLEADO;
            return aFT_MOV_MOVIMIENTOS_APROBACIONES;
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
        public global::System.Int32 ID_MOVIMIENTO
        {
            get
            {
                return _ID_MOVIMIENTO;
            }
            set
            {
                if (_ID_MOVIMIENTO != value)
                {
                    OnID_MOVIMIENTOChanging(value);
                    ReportPropertyChanging("ID_MOVIMIENTO");
                    _ID_MOVIMIENTO = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_MOVIMIENTO");
                    OnID_MOVIMIENTOChanged();
                }
            }
        }
        private global::System.Int32 _ID_MOVIMIENTO;
        partial void OnID_MOVIMIENTOChanging(global::System.Int32 value);
        partial void OnID_MOVIMIENTOChanged();

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
        public Nullable<global::System.DateTime> FECHA
        {
            get
            {
                return _FECHA;
            }
            set
            {
                OnFECHAChanging(value);
                ReportPropertyChanging("FECHA");
                _FECHA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FECHA");
                OnFECHAChanged();
            }
        }
        private Nullable<global::System.DateTime> _FECHA;
        partial void OnFECHAChanging(Nullable<global::System.DateTime> value);
        partial void OnFECHAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> APROBADO
        {
            get
            {
                return _APROBADO;
            }
            set
            {
                OnAPROBADOChanging(value);
                ReportPropertyChanging("APROBADO");
                _APROBADO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("APROBADO");
                OnAPROBADOChanged();
            }
        }
        private Nullable<global::System.Boolean> _APROBADO;
        partial void OnAPROBADOChanging(Nullable<global::System.Boolean> value);
        partial void OnAPROBADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String ID_EMPLEADO
        {
            get
            {
                return _ID_EMPLEADO;
            }
            set
            {
                OnID_EMPLEADOChanging(value);
                ReportPropertyChanging("ID_EMPLEADO");
                _ID_EMPLEADO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ID_EMPLEADO");
                OnID_EMPLEADOChanged();
            }
        }
        private global::System.String _ID_EMPLEADO;
        partial void OnID_EMPLEADOChanging(global::System.String value);
        partial void OnID_EMPLEADOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE")]
        public AFM_CATAL_EMPLE AFM_CATAL_EMPLE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CATAL_EMPLE> AFM_CATAL_EMPLEReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS")]
        public AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS> AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_APROBACIONES_TIPO_MOVIMIENTOS", "AFT_MOV_APROBACIONES_TIPO_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS")]
        public AFT_MOV_MAESTRO_MOVIMIENTOS AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFT_MOV_MAESTRO_MOVIMIENTOS> AFT_MOV_MAESTRO_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS", value);
                }
            }
        }

        #endregion
    }
}
