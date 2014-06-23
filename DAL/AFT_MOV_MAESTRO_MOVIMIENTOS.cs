using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_MAESTRO_MOVIMIENTOS"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_MAESTRO_MOVIMIENTOS : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CENTRO_COSTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ID_EMPLEADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime _FECHA_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DESCRIPCION_CENTRO_COSTOS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _EMPLEADO_RESPONSABLE_CC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ESTADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_PASO_APROBACION_ACTUAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DETALLE_DESTINO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ACTA;
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string CENTRO_COSTO
        {
            get
            {
                return this._CENTRO_COSTO;
            }
            set
            {
                this.ReportPropertyChanging("CENTRO_COSTO");
                this._CENTRO_COSTO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("CENTRO_COSTO");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public DateTime FECHA_MOVIMIENTO
        {
            get
            {
                return this._FECHA_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("FECHA_MOVIMIENTO");
                this._FECHA_MOVIMIENTO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FECHA_MOVIMIENTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DESCRIPCION_CENTRO_COSTOS
        {
            get
            {
                return this._DESCRIPCION_CENTRO_COSTOS;
            }
            set
            {
                this.ReportPropertyChanging("DESCRIPCION_CENTRO_COSTOS");
                this._DESCRIPCION_CENTRO_COSTOS = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DESCRIPCION_CENTRO_COSTOS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string EMPLEADO_RESPONSABLE_CC
        {
            get
            {
                return this._EMPLEADO_RESPONSABLE_CC;
            }
            set
            {
                this.ReportPropertyChanging("EMPLEADO_RESPONSABLE_CC");
                this._EMPLEADO_RESPONSABLE_CC = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("EMPLEADO_RESPONSABLE_CC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
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
        public string ESTADO
        {
            get
            {
                return this._ESTADO;
            }
            set
            {
                this.ReportPropertyChanging("ESTADO");
                this._ESTADO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ESTADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public int ID_PASO_APROBACION_ACTUAL
        {
            get
            {
                return this._ID_PASO_APROBACION_ACTUAL;
            }
            set
            {
                this.ReportPropertyChanging("ID_PASO_APROBACION_ACTUAL");
                this._ID_PASO_APROBACION_ACTUAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ID_PASO_APROBACION_ACTUAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string DETALLE_DESTINO_MOVIMIENTO
        {
            get
            {
                return this._DETALLE_DESTINO_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("DETALLE_DESTINO_MOVIMIENTO");
                this._DETALLE_DESTINO_MOVIMIENTO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DETALLE_DESTINO_MOVIMIENTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string ACTA
        {
            get
            {
                return this._ACTA;
            }
            set
            {
                this.ReportPropertyChanging("ACTA");
                this._ACTA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ACTA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO> AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_MAESTRO_MOVIMIENTOS CreateAFT_MOV_MAESTRO_MOVIMIENTOS(int iD_MOVIMIENTO, string cOD_COMPANIA, string cENTRO_COSTO, string iD_EMPLEADO, DateTime fECHA_MOVIMIENTO, int iD_TIPO_MOVIMIENTO, int iD_PASO_APROBACION_ACTUAL, string dETALLE_DESTINO_MOVIMIENTO)
        {
            return new AFT_MOV_MAESTRO_MOVIMIENTOS
            {
                ID_MOVIMIENTO = iD_MOVIMIENTO,
                COD_COMPANIA = cOD_COMPANIA,
                CENTRO_COSTO = cENTRO_COSTO,
                ID_EMPLEADO = iD_EMPLEADO,
                FECHA_MOVIMIENTO = fECHA_MOVIMIENTO,
                ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO,
                ID_PASO_APROBACION_ACTUAL = iD_PASO_APROBACION_ACTUAL,
                DETALLE_DESTINO_MOVIMIENTO = dETALLE_DESTINO_MOVIMIENTO
            };
        }
    }
     * */

    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_MAESTRO_MOVIMIENTOS")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_MAESTRO_MOVIMIENTOS : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_MAESTRO_MOVIMIENTOS object.
        /// </summary>
        /// <param name="iD_MOVIMIENTO">Initial value of the ID_MOVIMIENTO property.</param>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cENTRO_COSTO">Initial value of the CENTRO_COSTO property.</param>
        /// <param name="iD_EMPLEADO">Initial value of the ID_EMPLEADO property.</param>
        /// <param name="fECHA_MOVIMIENTO">Initial value of the FECHA_MOVIMIENTO property.</param>
        /// <param name="iD_TIPO_MOVIMIENTO">Initial value of the ID_TIPO_MOVIMIENTO property.</param>
        /// <param name="iD_PASO_APROBACION_ACTUAL">Initial value of the ID_PASO_APROBACION_ACTUAL property.</param>
        /// <param name="dETALLE_DESTINO_MOVIMIENTO">Initial value of the DETALLE_DESTINO_MOVIMIENTO property.</param>
        public static AFT_MOV_MAESTRO_MOVIMIENTOS CreateAFT_MOV_MAESTRO_MOVIMIENTOS(global::System.Int32 iD_MOVIMIENTO, global::System.String cOD_COMPANIA, global::System.String cENTRO_COSTO, global::System.String iD_EMPLEADO, global::System.DateTime fECHA_MOVIMIENTO, global::System.Int32 iD_TIPO_MOVIMIENTO, global::System.Int32 iD_PASO_APROBACION_ACTUAL, global::System.String dETALLE_DESTINO_MOVIMIENTO)
        {
            AFT_MOV_MAESTRO_MOVIMIENTOS aFT_MOV_MAESTRO_MOVIMIENTOS = new AFT_MOV_MAESTRO_MOVIMIENTOS();
            aFT_MOV_MAESTRO_MOVIMIENTOS.ID_MOVIMIENTO = iD_MOVIMIENTO;
            aFT_MOV_MAESTRO_MOVIMIENTOS.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_MAESTRO_MOVIMIENTOS.CENTRO_COSTO = cENTRO_COSTO;
            aFT_MOV_MAESTRO_MOVIMIENTOS.ID_EMPLEADO = iD_EMPLEADO;
            aFT_MOV_MAESTRO_MOVIMIENTOS.FECHA_MOVIMIENTO = fECHA_MOVIMIENTO;
            aFT_MOV_MAESTRO_MOVIMIENTOS.ID_TIPO_MOVIMIENTO = iD_TIPO_MOVIMIENTO;
            aFT_MOV_MAESTRO_MOVIMIENTOS.ID_PASO_APROBACION_ACTUAL = iD_PASO_APROBACION_ACTUAL;
            aFT_MOV_MAESTRO_MOVIMIENTOS.DETALLE_DESTINO_MOVIMIENTO = dETALLE_DESTINO_MOVIMIENTO;
            return aFT_MOV_MAESTRO_MOVIMIENTOS;
        }

        #endregion
        #region Primitive Properties

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String CENTRO_COSTO
        {
            get
            {
                return _CENTRO_COSTO;
            }
            set
            {
                OnCENTRO_COSTOChanging(value);
                ReportPropertyChanging("CENTRO_COSTO");
                _CENTRO_COSTO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("CENTRO_COSTO");
                OnCENTRO_COSTOChanged();
            }
        }
        private global::System.String _CENTRO_COSTO;
        partial void OnCENTRO_COSTOChanging(global::System.String value);
        partial void OnCENTRO_COSTOChanged();

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

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.DateTime FECHA_MOVIMIENTO
        {
            get
            {
                return _FECHA_MOVIMIENTO;
            }
            set
            {
                OnFECHA_MOVIMIENTOChanging(value);
                ReportPropertyChanging("FECHA_MOVIMIENTO");
                _FECHA_MOVIMIENTO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FECHA_MOVIMIENTO");
                OnFECHA_MOVIMIENTOChanged();
            }
        }
        private global::System.DateTime _FECHA_MOVIMIENTO;
        partial void OnFECHA_MOVIMIENTOChanging(global::System.DateTime value);
        partial void OnFECHA_MOVIMIENTOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DESCRIPCION_CENTRO_COSTOS
        {
            get
            {
                return _DESCRIPCION_CENTRO_COSTOS;
            }
            set
            {
                OnDESCRIPCION_CENTRO_COSTOSChanging(value);
                ReportPropertyChanging("DESCRIPCION_CENTRO_COSTOS");
                _DESCRIPCION_CENTRO_COSTOS = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DESCRIPCION_CENTRO_COSTOS");
                OnDESCRIPCION_CENTRO_COSTOSChanged();
            }
        }
        private global::System.String _DESCRIPCION_CENTRO_COSTOS;
        partial void OnDESCRIPCION_CENTRO_COSTOSChanging(global::System.String value);
        partial void OnDESCRIPCION_CENTRO_COSTOSChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String EMPLEADO_RESPONSABLE_CC
        {
            get
            {
                return _EMPLEADO_RESPONSABLE_CC;
            }
            set
            {
                OnEMPLEADO_RESPONSABLE_CCChanging(value);
                ReportPropertyChanging("EMPLEADO_RESPONSABLE_CC");
                _EMPLEADO_RESPONSABLE_CC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EMPLEADO_RESPONSABLE_CC");
                OnEMPLEADO_RESPONSABLE_CCChanged();
            }
        }
        private global::System.String _EMPLEADO_RESPONSABLE_CC;
        partial void OnEMPLEADO_RESPONSABLE_CCChanging(global::System.String value);
        partial void OnEMPLEADO_RESPONSABLE_CCChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_TIPO_MOVIMIENTO
        {
            get
            {
                return _ID_TIPO_MOVIMIENTO;
            }
            set
            {
                OnID_TIPO_MOVIMIENTOChanging(value);
                ReportPropertyChanging("ID_TIPO_MOVIMIENTO");
                _ID_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_TIPO_MOVIMIENTO");
                OnID_TIPO_MOVIMIENTOChanged();
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
        public global::System.String ESTADO
        {
            get
            {
                return _ESTADO;
            }
            set
            {
                OnESTADOChanging(value);
                ReportPropertyChanging("ESTADO");
                _ESTADO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ESTADO");
                OnESTADOChanged();
            }
        }
        private global::System.String _ESTADO;
        partial void OnESTADOChanging(global::System.String value);
        partial void OnESTADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_PASO_APROBACION_ACTUAL
        {
            get
            {
                return _ID_PASO_APROBACION_ACTUAL;
            }
            set
            {
                OnID_PASO_APROBACION_ACTUALChanging(value);
                ReportPropertyChanging("ID_PASO_APROBACION_ACTUAL");
                _ID_PASO_APROBACION_ACTUAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ID_PASO_APROBACION_ACTUAL");
                OnID_PASO_APROBACION_ACTUALChanged();
            }
        }
        private global::System.Int32 _ID_PASO_APROBACION_ACTUAL;
        partial void OnID_PASO_APROBACION_ACTUALChanging(global::System.Int32 value);
        partial void OnID_PASO_APROBACION_ACTUALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String DETALLE_DESTINO_MOVIMIENTO
        {
            get
            {
                return _DETALLE_DESTINO_MOVIMIENTO;
            }
            set
            {
                OnDETALLE_DESTINO_MOVIMIENTOChanging(value);
                ReportPropertyChanging("DETALLE_DESTINO_MOVIMIENTO");
                _DETALLE_DESTINO_MOVIMIENTO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DETALLE_DESTINO_MOVIMIENTO");
                OnDETALLE_DESTINO_MOVIMIENTOChanged();
            }
        }
        private global::System.String _DETALLE_DESTINO_MOVIMIENTO;
        partial void OnDETALLE_DESTINO_MOVIMIENTOChanging(global::System.String value);
        partial void OnDETALLE_DESTINO_MOVIMIENTOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String ACTA
        {
            get
            {
                return _ACTA;
            }
            set
            {
                OnACTAChanging(value);
                ReportPropertyChanging("ACTA");
                _ACTA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ACTA");
                OnACTAChanged();
            }
        }
        private global::System.String _ACTA;
        partial void OnACTAChanging(global::System.String value);
        partial void OnACTAChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE")]
        public AFM_CATAL_EMPLE AFM_CATAL_EMPLE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO")]
        public EntityCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO> AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS")]
        public AFT_MOV_TIPOS_MOVIMIENTOS AFT_MOV_TIPOS_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_TIPOS_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AssetsWEB_MOV_TIPOS_MOVIMIENTOS", "AFT_MOV_TIPOS_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES")]
        public EntityCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES> AFT_MOV_MOVIMIENTOS_APROBACIONES
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MOVIMIENTOS_APROBACIONES", value);
                }
            }
        }

        #endregion
    }
}
