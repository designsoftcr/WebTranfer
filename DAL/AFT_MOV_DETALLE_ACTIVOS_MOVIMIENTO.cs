using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _PLACA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DESCRIPCION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _SERIE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VALOR_LIBROS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MARCA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _MARCA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MODELO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _MODELO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_LOC_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _LOCALIZACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_SEC_LOC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _SECCION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_UBI_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _UBICACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CEN_CST;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CENTRO_COSTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _RESPONSABLE_CC;
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
        public string NUM_ACTIVO
        {
            get
            {
                return this._NUM_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("NUM_ACTIVO");
                this._NUM_ACTIVO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("NUM_ACTIVO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string PLACA
        {
            get
            {
                return this._PLACA;
            }
            set
            {
                this.ReportPropertyChanging("PLACA");
                this._PLACA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("PLACA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DESCRIPCION
        {
            get
            {
                return this._DESCRIPCION;
            }
            set
            {
                this.ReportPropertyChanging("DESCRIPCION");
                this._DESCRIPCION = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DESCRIPCION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string SERIE
        {
            get
            {
                return this._SERIE;
            }
            set
            {
                this.ReportPropertyChanging("SERIE");
                this._SERIE = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("SERIE");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VALOR_LIBROS
        {
            get
            {
                return this._VALOR_LIBROS;
            }
            set
            {
                this.ReportPropertyChanging("VALOR_LIBROS");
                this._VALOR_LIBROS = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VALOR_LIBROS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_MARCA
        {
            get
            {
                return this._COD_MARCA;
            }
            set
            {
                this.ReportPropertyChanging("COD_MARCA");
                this._COD_MARCA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_MARCA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string MARCA
        {
            get
            {
                return this._MARCA;
            }
            set
            {
                this.ReportPropertyChanging("MARCA");
                this._MARCA = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("MARCA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_MODELO
        {
            get
            {
                return this._COD_MODELO;
            }
            set
            {
                this.ReportPropertyChanging("COD_MODELO");
                this._COD_MODELO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_MODELO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string MODELO
        {
            get
            {
                return this._MODELO;
            }
            set
            {
                this.ReportPropertyChanging("MODELO");
                this._MODELO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("MODELO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_LOC_ACT
        {
            get
            {
                return this._COD_LOC_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_LOC_ACT");
                this._COD_LOC_ACT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_LOC_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string LOCALIZACION
        {
            get
            {
                return this._LOCALIZACION;
            }
            set
            {
                this.ReportPropertyChanging("LOCALIZACION");
                this._LOCALIZACION = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("LOCALIZACION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_SEC_LOC
        {
            get
            {
                return this._COD_SEC_LOC;
            }
            set
            {
                this.ReportPropertyChanging("COD_SEC_LOC");
                this._COD_SEC_LOC = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_SEC_LOC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string SECCION
        {
            get
            {
                return this._SECCION;
            }
            set
            {
                this.ReportPropertyChanging("SECCION");
                this._SECCION = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("SECCION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_UBI_ACT
        {
            get
            {
                return this._COD_UBI_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_UBI_ACT");
                this._COD_UBI_ACT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_UBI_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string UBICACION
        {
            get
            {
                return this._UBICACION;
            }
            set
            {
                this.ReportPropertyChanging("UBICACION");
                this._UBICACION = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("UBICACION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CEN_CST
        {
            get
            {
                return this._COD_CEN_CST;
            }
            set
            {
                this.ReportPropertyChanging("COD_CEN_CST");
                this._COD_CEN_CST = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CEN_CST");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string RESPONSABLE_CC
        {
            get
            {
                return this._RESPONSABLE_CC;
            }
            set
            {
                this.ReportPropertyChanging("RESPONSABLE_CC");
                this._RESPONSABLE_CC = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("RESPONSABLE_CC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS"), DataMember, SoapIgnore, XmlIgnore]
        public AFT_MOV_MAESTRO_MOVIMIENTOS AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFT_MOV_MAESTRO_MOVIMIENTOS> AFT_MOV_MAESTRO_MOVIMIENTOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO CreateAFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO(string cOD_COMPANIA, int iD_MOVIMIENTO, string nUM_ACTIVO, string mARCA, string mODELO, string lOCALIZACION, string sECCION, string uBICACION, string cENTRO_COSTO)
        {
            return new AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO
            {
                COD_COMPANIA = cOD_COMPANIA,
                ID_MOVIMIENTO = iD_MOVIMIENTO,
                NUM_ACTIVO = nUM_ACTIVO,
                MARCA = mARCA,
                MODELO = mODELO,
                LOCALIZACION = lOCALIZACION,
                SECCION = sECCION,
                UBICACION = uBICACION,
                CENTRO_COSTO = cENTRO_COSTO
            };
        }
    }
     * */

    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="iD_MOVIMIENTO">Initial value of the ID_MOVIMIENTO property.</param>
        /// <param name="nUM_ACTIVO">Initial value of the NUM_ACTIVO property.</param>
        /// <param name="mARCA">Initial value of the MARCA property.</param>
        /// <param name="mODELO">Initial value of the MODELO property.</param>
        /// <param name="lOCALIZACION">Initial value of the LOCALIZACION property.</param>
        /// <param name="sECCION">Initial value of the SECCION property.</param>
        /// <param name="uBICACION">Initial value of the UBICACION property.</param>
        /// <param name="cENTRO_COSTO">Initial value of the CENTRO_COSTO property.</param>
        public static AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO CreateAFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO(global::System.String cOD_COMPANIA, global::System.Int32 iD_MOVIMIENTO, global::System.String nUM_ACTIVO, global::System.String mARCA, global::System.String mODELO, global::System.String lOCALIZACION, global::System.String sECCION, global::System.String uBICACION, global::System.String cENTRO_COSTO)
        {
            AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO = new AFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO();
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.ID_MOVIMIENTO = iD_MOVIMIENTO;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.NUM_ACTIVO = nUM_ACTIVO;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.MARCA = mARCA;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.MODELO = mODELO;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.LOCALIZACION = lOCALIZACION;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.SECCION = sECCION;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.UBICACION = uBICACION;
            aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO.CENTRO_COSTO = cENTRO_COSTO;
            return aFT_MOV_DETALLE_ACTIVOS_MOVIMIENTO;
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
        public global::System.String NUM_ACTIVO
        {
            get
            {
                return _NUM_ACTIVO;
            }
            set
            {
                if (_NUM_ACTIVO != value)
                {
                    OnNUM_ACTIVOChanging(value);
                    ReportPropertyChanging("NUM_ACTIVO");
                    _NUM_ACTIVO = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("NUM_ACTIVO");
                    OnNUM_ACTIVOChanged();
                }
            }
        }
        private global::System.String _NUM_ACTIVO;
        partial void OnNUM_ACTIVOChanging(global::System.String value);
        partial void OnNUM_ACTIVOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String PLACA
        {
            get
            {
                return _PLACA;
            }
            set
            {
                OnPLACAChanging(value);
                ReportPropertyChanging("PLACA");
                _PLACA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PLACA");
                OnPLACAChanged();
            }
        }
        private global::System.String _PLACA;
        partial void OnPLACAChanging(global::System.String value);
        partial void OnPLACAChanged();

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
        public global::System.String SERIE
        {
            get
            {
                return _SERIE;
            }
            set
            {
                OnSERIEChanging(value);
                ReportPropertyChanging("SERIE");
                _SERIE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SERIE");
                OnSERIEChanged();
            }
        }
        private global::System.String _SERIE;
        partial void OnSERIEChanging(global::System.String value);
        partial void OnSERIEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VALOR_LIBROS
        {
            get
            {
                return _VALOR_LIBROS;
            }
            set
            {
                OnVALOR_LIBROSChanging(value);
                ReportPropertyChanging("VALOR_LIBROS");
                _VALOR_LIBROS = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VALOR_LIBROS");
                OnVALOR_LIBROSChanged();
            }
        }
        private Nullable<global::System.Decimal> _VALOR_LIBROS;
        partial void OnVALOR_LIBROSChanging(Nullable<global::System.Decimal> value);
        partial void OnVALOR_LIBROSChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_MARCA
        {
            get
            {
                return _COD_MARCA;
            }
            set
            {
                OnCOD_MARCAChanging(value);
                ReportPropertyChanging("COD_MARCA");
                _COD_MARCA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_MARCA");
                OnCOD_MARCAChanged();
            }
        }
        private global::System.String _COD_MARCA;
        partial void OnCOD_MARCAChanging(global::System.String value);
        partial void OnCOD_MARCAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String MARCA
        {
            get
            {
                return _MARCA;
            }
            set
            {
                OnMARCAChanging(value);
                ReportPropertyChanging("MARCA");
                _MARCA = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MARCA");
                OnMARCAChanged();
            }
        }
        private global::System.String _MARCA;
        partial void OnMARCAChanging(global::System.String value);
        partial void OnMARCAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_MODELO
        {
            get
            {
                return _COD_MODELO;
            }
            set
            {
                OnCOD_MODELOChanging(value);
                ReportPropertyChanging("COD_MODELO");
                _COD_MODELO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_MODELO");
                OnCOD_MODELOChanged();
            }
        }
        private global::System.String _COD_MODELO;
        partial void OnCOD_MODELOChanging(global::System.String value);
        partial void OnCOD_MODELOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String MODELO
        {
            get
            {
                return _MODELO;
            }
            set
            {
                OnMODELOChanging(value);
                ReportPropertyChanging("MODELO");
                _MODELO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MODELO");
                OnMODELOChanged();
            }
        }
        private global::System.String _MODELO;
        partial void OnMODELOChanging(global::System.String value);
        partial void OnMODELOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_LOC_ACT
        {
            get
            {
                return _COD_LOC_ACT;
            }
            set
            {
                OnCOD_LOC_ACTChanging(value);
                ReportPropertyChanging("COD_LOC_ACT");
                _COD_LOC_ACT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_LOC_ACT");
                OnCOD_LOC_ACTChanged();
            }
        }
        private global::System.String _COD_LOC_ACT;
        partial void OnCOD_LOC_ACTChanging(global::System.String value);
        partial void OnCOD_LOC_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String LOCALIZACION
        {
            get
            {
                return _LOCALIZACION;
            }
            set
            {
                OnLOCALIZACIONChanging(value);
                ReportPropertyChanging("LOCALIZACION");
                _LOCALIZACION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LOCALIZACION");
                OnLOCALIZACIONChanged();
            }
        }
        private global::System.String _LOCALIZACION;
        partial void OnLOCALIZACIONChanging(global::System.String value);
        partial void OnLOCALIZACIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_SEC_LOC
        {
            get
            {
                return _COD_SEC_LOC;
            }
            set
            {
                OnCOD_SEC_LOCChanging(value);
                ReportPropertyChanging("COD_SEC_LOC");
                _COD_SEC_LOC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_SEC_LOC");
                OnCOD_SEC_LOCChanged();
            }
        }
        private global::System.String _COD_SEC_LOC;
        partial void OnCOD_SEC_LOCChanging(global::System.String value);
        partial void OnCOD_SEC_LOCChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String SECCION
        {
            get
            {
                return _SECCION;
            }
            set
            {
                OnSECCIONChanging(value);
                ReportPropertyChanging("SECCION");
                _SECCION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("SECCION");
                OnSECCIONChanged();
            }
        }
        private global::System.String _SECCION;
        partial void OnSECCIONChanging(global::System.String value);
        partial void OnSECCIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_UBI_ACT
        {
            get
            {
                return _COD_UBI_ACT;
            }
            set
            {
                OnCOD_UBI_ACTChanging(value);
                ReportPropertyChanging("COD_UBI_ACT");
                _COD_UBI_ACT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_UBI_ACT");
                OnCOD_UBI_ACTChanged();
            }
        }
        private global::System.String _COD_UBI_ACT;
        partial void OnCOD_UBI_ACTChanging(global::System.String value);
        partial void OnCOD_UBI_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String UBICACION
        {
            get
            {
                return _UBICACION;
            }
            set
            {
                OnUBICACIONChanging(value);
                ReportPropertyChanging("UBICACION");
                _UBICACION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UBICACION");
                OnUBICACIONChanged();
            }
        }
        private global::System.String _UBICACION;
        partial void OnUBICACIONChanging(global::System.String value);
        partial void OnUBICACIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CEN_CST
        {
            get
            {
                return _COD_CEN_CST;
            }
            set
            {
                OnCOD_CEN_CSTChanging(value);
                ReportPropertyChanging("COD_CEN_CST");
                _COD_CEN_CST = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CEN_CST");
                OnCOD_CEN_CSTChanged();
            }
        }
        private global::System.String _COD_CEN_CST;
        partial void OnCOD_CEN_CSTChanging(global::System.String value);
        partial void OnCOD_CEN_CSTChanged();

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String RESPONSABLE_CC
        {
            get
            {
                return _RESPONSABLE_CC;
            }
            set
            {
                OnRESPONSABLE_CCChanging(value);
                ReportPropertyChanging("RESPONSABLE_CC");
                _RESPONSABLE_CC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("RESPONSABLE_CC");
                OnRESPONSABLE_CCChanged();
            }
        }
        private global::System.String _RESPONSABLE_CC;
        partial void OnRESPONSABLE_CCChanging(global::System.String value);
        partial void OnRESPONSABLE_CCChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS")]
        public AFT_MOV_MAESTRO_MOVIMIENTOS AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_DETALLE_ACTIVOS_MOVIMIENTO_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS", "AFT_MOV_MAESTRO_MOVIMIENTOS", value);
                }
            }
        }

        #endregion
    }
}
