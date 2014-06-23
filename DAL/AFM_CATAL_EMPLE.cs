using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
namespace DAL
{
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_CATAL_EMPLE")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_CATAL_EMPLE : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_CATAL_EMPLE object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cOD_EMPLEADO">Initial value of the COD_EMPLEADO property.</param>
        /// <param name="cod_identificacion">Initial value of the cod_identificacion property.</param>
        public static AFM_CATAL_EMPLE CreateAFM_CATAL_EMPLE(global::System.String cOD_COMPANIA, global::System.String cOD_EMPLEADO, global::System.String cod_identificacion)
        {
            AFM_CATAL_EMPLE aFM_CATAL_EMPLE = new AFM_CATAL_EMPLE();
            aFM_CATAL_EMPLE.COD_COMPANIA = cOD_COMPANIA;
            aFM_CATAL_EMPLE.COD_EMPLEADO = cOD_EMPLEADO;
            aFM_CATAL_EMPLE.cod_identificacion = cod_identificacion;
            return aFM_CATAL_EMPLE;
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
        public global::System.String COD_EMPLEADO
        {
            get
            {
                return _COD_EMPLEADO;
            }
            set
            {
                if (_COD_EMPLEADO != value)
                {
                    OnCOD_EMPLEADOChanging(value);
                    ReportPropertyChanging("COD_EMPLEADO");
                    _COD_EMPLEADO = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_EMPLEADO");
                    OnCOD_EMPLEADOChanged();
                }
            }
        }
        private global::System.String _COD_EMPLEADO;
        partial void OnCOD_EMPLEADOChanging(global::System.String value);
        partial void OnCOD_EMPLEADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NOM_EMPLEADO
        {
            get
            {
                return _NOM_EMPLEADO;
            }
            set
            {
                OnNOM_EMPLEADOChanging(value);
                ReportPropertyChanging("NOM_EMPLEADO");
                _NOM_EMPLEADO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NOM_EMPLEADO");
                OnNOM_EMPLEADOChanged();
            }
        }
        private global::System.String _NOM_EMPLEADO;
        partial void OnNOM_EMPLEADOChanging(global::System.String value);
        partial void OnNOM_EMPLEADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_PUESTO
        {
            get
            {
                return _COD_PUESTO;
            }
            set
            {
                OnCOD_PUESTOChanging(value);
                ReportPropertyChanging("COD_PUESTO");
                _COD_PUESTO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_PUESTO");
                OnCOD_PUESTOChanged();
            }
        }
        private global::System.String _COD_PUESTO;
        partial void OnCOD_PUESTOChanging(global::System.String value);
        partial void OnCOD_PUESTOChanged();

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String TLF_CENTRA
        {
            get
            {
                return _TLF_CENTRA;
            }
            set
            {
                OnTLF_CENTRAChanging(value);
                ReportPropertyChanging("TLF_CENTRA");
                _TLF_CENTRA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TLF_CENTRA");
                OnTLF_CENTRAChanged();
            }
        }
        private global::System.String _TLF_CENTRA;
        partial void OnTLF_CENTRAChanging(global::System.String value);
        partial void OnTLF_CENTRAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String EXT_TLF_OFI
        {
            get
            {
                return _EXT_TLF_OFI;
            }
            set
            {
                OnEXT_TLF_OFIChanging(value);
                ReportPropertyChanging("EXT_TLF_OFI");
                _EXT_TLF_OFI = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EXT_TLF_OFI");
                OnEXT_TLF_OFIChanged();
            }
        }
        private global::System.String _EXT_TLF_OFI;
        partial void OnEXT_TLF_OFIChanging(global::System.String value);
        partial void OnEXT_TLF_OFIChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String TLF_OFICIN
        {
            get
            {
                return _TLF_OFICIN;
            }
            set
            {
                OnTLF_OFICINChanging(value);
                ReportPropertyChanging("TLF_OFICIN");
                _TLF_OFICIN = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TLF_OFICIN");
                OnTLF_OFICINChanged();
            }
        }
        private global::System.String _TLF_OFICIN;
        partial void OnTLF_OFICINChanging(global::System.String value);
        partial void OnTLF_OFICINChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String TLF_CELULA
        {
            get
            {
                return _TLF_CELULA;
            }
            set
            {
                OnTLF_CELULAChanging(value);
                ReportPropertyChanging("TLF_CELULA");
                _TLF_CELULA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TLF_CELULA");
                OnTLF_CELULAChanged();
            }
        }
        private global::System.String _TLF_CELULA;
        partial void OnTLF_CELULAChanging(global::System.String value);
        partial void OnTLF_CELULAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DIR_ELECTR
        {
            get
            {
                return _DIR_ELECTR;
            }
            set
            {
                OnDIR_ELECTRChanging(value);
                ReportPropertyChanging("DIR_ELECTR");
                _DIR_ELECTR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DIR_ELECTR");
                OnDIR_ELECTRChanged();
            }
        }
        private global::System.String _DIR_ELECTR;
        partial void OnDIR_ELECTRChanging(global::System.String value);
        partial void OnDIR_ELECTRChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String SITIO_WEB
        {
            get
            {
                return _SITIO_WEB;
            }
            set
            {
                OnSITIO_WEBChanging(value);
                ReportPropertyChanging("SITIO_WEB");
                _SITIO_WEB = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SITIO_WEB");
                OnSITIO_WEBChanged();
            }
        }
        private global::System.String _SITIO_WEB;
        partial void OnSITIO_WEBChanging(global::System.String value);
        partial void OnSITIO_WEBChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_BAR_IDE
        {
            get
            {
                return _COD_BAR_IDE;
            }
            set
            {
                OnCOD_BAR_IDEChanging(value);
                ReportPropertyChanging("COD_BAR_IDE");
                _COD_BAR_IDE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_BAR_IDE");
                OnCOD_BAR_IDEChanged();
            }
        }
        private global::System.String _COD_BAR_IDE;
        partial void OnCOD_BAR_IDEChanging(global::System.String value);
        partial void OnCOD_BAR_IDEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IND_SER_SEG
        {
            get
            {
                return _IND_SER_SEG;
            }
            set
            {
                OnIND_SER_SEGChanging(value);
                ReportPropertyChanging("IND_SER_SEG");
                _IND_SER_SEG = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IND_SER_SEG");
                OnIND_SER_SEGChanged();
            }
        }
        private Nullable<global::System.Boolean> _IND_SER_SEG;
        partial void OnIND_SER_SEGChanging(Nullable<global::System.Boolean> value);
        partial void OnIND_SER_SEGChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_ORI_STS
        {
            get
            {
                return _COD_ORI_STS;
            }
            set
            {
                OnCOD_ORI_STSChanging(value);
                ReportPropertyChanging("COD_ORI_STS");
                _COD_ORI_STS = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_ORI_STS");
                OnCOD_ORI_STSChanged();
            }
        }
        private global::System.String _COD_ORI_STS;
        partial void OnCOD_ORI_STSChanging(global::System.String value);
        partial void OnCOD_ORI_STSChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_EST_ORI
        {
            get
            {
                return _COD_EST_ORI;
            }
            set
            {
                OnCOD_EST_ORIChanging(value);
                ReportPropertyChanging("COD_EST_ORI");
                _COD_EST_ORI = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_EST_ORI");
                OnCOD_EST_ORIChanged();
            }
        }
        private global::System.String _COD_EST_ORI;
        partial void OnCOD_EST_ORIChanging(global::System.String value);
        partial void OnCOD_EST_ORIChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> CAMPO62
        {
            get
            {
                return _CAMPO62;
            }
            set
            {
                OnCAMPO62Changing(value);
                ReportPropertyChanging("CAMPO62");
                _CAMPO62 = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CAMPO62");
                OnCAMPO62Changed();
            }
        }
        private Nullable<global::System.Int16> _CAMPO62;
        partial void OnCAMPO62Changing(Nullable<global::System.Int16> value);
        partial void OnCAMPO62Changed();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_ESTADO
        {
            get
            {
                return _FYH_ESTADO;
            }
            set
            {
                OnFYH_ESTADOChanging(value);
                ReportPropertyChanging("FYH_ESTADO");
                _FYH_ESTADO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_ESTADO");
                OnFYH_ESTADOChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_ESTADO;
        partial void OnFYH_ESTADOChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_ESTADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.Byte[] IMG_EMPLEADO
        {
            get
            {
                return StructuralObject.GetValidValue(_IMG_EMPLEADO);
            }
            set
            {
                OnIMG_EMPLEADOChanging(value);
                ReportPropertyChanging("IMG_EMPLEADO");
                _IMG_EMPLEADO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IMG_EMPLEADO");
                OnIMG_EMPLEADOChanged();
            }
        }
        private global::System.Byte[] _IMG_EMPLEADO;
        partial void OnIMG_EMPLEADOChanging(global::System.Byte[] value);
        partial void OnIMG_EMPLEADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String IND_RES_TOMAF
        {
            get
            {
                return _IND_RES_TOMAF;
            }
            set
            {
                OnIND_RES_TOMAFChanging(value);
                ReportPropertyChanging("IND_RES_TOMAF");
                _IND_RES_TOMAF = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IND_RES_TOMAF");
                OnIND_RES_TOMAFChanged();
            }
        }
        private global::System.String _IND_RES_TOMAF;
        partial void OnIND_RES_TOMAFChanging(global::System.String value);
        partial void OnIND_RES_TOMAFChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.Byte[] TIMESTAMP
        {
            get
            {
                return StructuralObject.GetValidValue(_TIMESTAMP);
            }
            set
            {
                OnTIMESTAMPChanging(value);
                ReportPropertyChanging("TIMESTAMP");
                _TIMESTAMP = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TIMESTAMP");
                OnTIMESTAMPChanged();
            }
        }
        private global::System.Byte[] _TIMESTAMP;
        partial void OnTIMESTAMPChanging(global::System.Byte[] value);
        partial void OnTIMESTAMPChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> COD_USUARIO
        {
            get
            {
                return _COD_USUARIO;
            }
            set
            {
                OnCOD_USUARIOChanging(value);
                ReportPropertyChanging("COD_USUARIO");
                _COD_USUARIO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("COD_USUARIO");
                OnCOD_USUARIOChanged();
            }
        }
        private Nullable<global::System.Int16> _COD_USUARIO;
        partial void OnCOD_USUARIOChanging(Nullable<global::System.Int16> value);
        partial void OnCOD_USUARIOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String cod_identificacion
        {
            get
            {
                return _cod_identificacion;
            }
            set
            {
                Oncod_identificacionChanging(value);
                ReportPropertyChanging("cod_identificacion");
                _cod_identificacion = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("cod_identificacion");
                Oncod_identificacionChanged();
            }
        }
        private global::System.String _cod_identificacion;
        partial void Oncod_identificacionChanging(global::System.String value);
        partial void Oncod_identificacionChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_SUPERVISOR
        {
            get
            {
                return _COD_SUPERVISOR;
            }
            set
            {
                OnCOD_SUPERVISORChanging(value);
                ReportPropertyChanging("COD_SUPERVISOR");
                _COD_SUPERVISOR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_SUPERVISOR");
                OnCOD_SUPERVISORChanged();
            }
        }
        private global::System.String _COD_SUPERVISOR;
        partial void OnCOD_SUPERVISORChanging(global::System.String value);
        partial void OnCOD_SUPERVISORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String USUARIO_SESION
        {
            get
            {
                return _USUARIO_SESION;
            }
            set
            {
                OnUSUARIO_SESIONChanging(value);
                ReportPropertyChanging("USUARIO_SESION");
                _USUARIO_SESION = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("USUARIO_SESION");
                OnUSUARIO_SESIONChanged();
            }
        }
        private global::System.String _USUARIO_SESION;
        partial void OnUSUARIO_SESIONChanging(global::System.String value);
        partial void OnUSUARIO_SESIONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IND_ADM_MODULO_CONTROL_MOV
        {
            get
            {
                return _IND_ADM_MODULO_CONTROL_MOV;
            }
            set
            {
                OnIND_ADM_MODULO_CONTROL_MOVChanging(value);
                ReportPropertyChanging("IND_ADM_MODULO_CONTROL_MOV");
                _IND_ADM_MODULO_CONTROL_MOV = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IND_ADM_MODULO_CONTROL_MOV");
                OnIND_ADM_MODULO_CONTROL_MOVChanged();
            }
        }
        private Nullable<global::System.Boolean> _IND_ADM_MODULO_CONTROL_MOV;
        partial void OnIND_ADM_MODULO_CONTROL_MOVChanging(Nullable<global::System.Boolean> value);
        partial void OnIND_ADM_MODULO_CONTROL_MOVChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ACTIV_AUXIL_AFM_CATAL_EMPLE", "AFM_ACTIV_AUXIL")]
        public EntityCollection<AFM_ACTIV_AUXIL> AFM_ACTIV_AUXIL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ACTIV_AUXIL>("BostonModel.FK_AFM_ACTIV_AUXIL_AFM_CATAL_EMPLE", "AFM_ACTIV_AUXIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ACTIV_AUXIL>("BostonModel.FK_AFM_ACTIV_AUXIL_AFM_CATAL_EMPLE", "AFM_ACTIV_AUXIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ACTIV_MOVIL_AFM_CATAL_EMPLE", "AFM_ACTIV_MOVIL")]
        public EntityCollection<AFM_ACTIV_MOVIL> AFM_ACTIV_MOVIL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ACTIV_MOVIL>("BostonModel.FK_AFM_ACTIV_MOVIL_AFM_CATAL_EMPLE", "AFM_ACTIV_MOVIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ACTIV_MOVIL>("BostonModel.FK_AFM_ACTIV_MOVIL_AFM_CATAL_EMPLE", "AFM_ACTIV_MOVIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CENTRO_COSTO")]
        public AFM_CENTRO_COSTO AFM_CENTRO_COSTO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CENTRO_COSTO>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CENTRO_COSTO").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CENTRO_COSTO>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CENTRO_COSTO").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CENTRO_COSTO> AFM_CENTRO_COSTOReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CENTRO_COSTO>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CENTRO_COSTO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CENTRO_COSTO>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CENTRO_COSTO", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CATAL_EMPLE_AFM_CIAS", "AFM_CIAS")]
        public AFM_CIAS AFM_CIAS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CIAS", "AFM_CIAS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CIAS", "AFM_CIAS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CIAS> AFM_CIASReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CIAS", "AFM_CIAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CIAS", "AFM_CIAS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EMPLE_ACTIV_AFM_CATAL_EMPLE", "AFM_EMPLE_ACTIV")]
        public EntityCollection<AFM_EMPLE_ACTIV> AFM_EMPLE_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EMPLE_ACTIV>("BostonModel.FK_AFM_EMPLE_ACTIV_AFM_CATAL_EMPLE", "AFM_EMPLE_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EMPLE_ACTIV>("BostonModel.FK_AFM_EMPLE_ACTIV_AFM_CATAL_EMPLE", "AFM_EMPLE_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EMPLE_GRUAU_AFM_CATAL_EMPLE", "AFM_EMPLE_GRUAU")]
        public EntityCollection<AFM_EMPLE_GRUAU> AFM_EMPLE_GRUAU
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EMPLE_GRUAU>("BostonModel.FK_AFM_EMPLE_GRUAU_AFM_CATAL_EMPLE", "AFM_EMPLE_GRUAU");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EMPLE_GRUAU>("BostonModel.FK_AFM_EMPLE_GRUAU_AFM_CATAL_EMPLE", "AFM_EMPLE_GRUAU", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EMPLE_SESIO_AFM_CATAL_EMPLE", "AFM_EMPLE_SESIO")]
        public EntityCollection<AFM_EMPLE_SESIO> AFM_EMPLE_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EMPLE_SESIO>("BostonModel.FK_AFM_EMPLE_SESIO_AFM_CATAL_EMPLE", "AFM_EMPLE_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EMPLE_SESIO>("BostonModel.FK_AFM_EMPLE_SESIO_AFM_CATAL_EMPLE", "AFM_EMPLE_SESIO", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_LOTES_TOMFI_AFM_CATAL_EMPLE", "AFM_LOTES_TOMFI")]
        public EntityCollection<AFM_LOTES_TOMFI> AFM_LOTES_TOMFI
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_LOTES_TOMFI>("BostonModel.FK_AFM_LOTES_TOMFI_AFM_CATAL_EMPLE", "AFM_LOTES_TOMFI");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_LOTES_TOMFI>("BostonModel.FK_AFM_LOTES_TOMFI_AFM_CATAL_EMPLE", "AFM_LOTES_TOMFI", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MOVIL_ACTIV_AFM_CATAL_EMPLE", "AFM_MOVIL_ACTIV")]
        public EntityCollection<AFM_MOVIL_ACTIV> AFM_MOVIL_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MOVIL_ACTIV>("BostonModel.FK_AFM_MOVIL_ACTIV_AFM_CATAL_EMPLE", "AFM_MOVIL_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MOVIL_ACTIV>("BostonModel.FK_AFM_MOVIL_ACTIV_AFM_CATAL_EMPLE", "AFM_MOVIL_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE", "AFM_ORDEN_MOVIL")]
        public EntityCollection<AFM_ORDEN_MOVIL> AFM_ORDEN_MOVIL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ORDEN_MOVIL>("BostonModel.FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE", "AFM_ORDEN_MOVIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ORDEN_MOVIL>("BostonModel.FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE", "AFM_ORDEN_MOVIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE1", "AFM_ORDEN_MOVIL")]
        public EntityCollection<AFM_ORDEN_MOVIL> AFM_ORDEN_MOVIL1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ORDEN_MOVIL>("BostonModel.FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE1", "AFM_ORDEN_MOVIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ORDEN_MOVIL>("BostonModel.FK_AFM_ORDEN_MOVIL_AFM_CATAL_EMPLE1", "AFM_ORDEN_MOVIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFT_MOV_GRUPO_USUARIOS")]
        public EntityCollection<AFT_MOV_GRUPO_USUARIOS> AFT_MOV_GRUPO_USUARIOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_GRUPO_USUARIOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFT_MOV_GRUPO_USUARIOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_GRUPO_USUARIOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFT_MOV_GRUPO_USUARIOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFT_MOV_MAESTRO_MOVIMIENTOS")]
        public EntityCollection<AFT_MOV_MAESTRO_MOVIMIENTOS> AFT_MOV_MAESTRO_MOVIMIENTOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFT_MOV_MAESTRO_MOVIMIENTOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MAESTRO_MOVIMIENTOS>("BostonModel.FK_AssetsWEB_MOV_MAESTRO_MOVIMIENTOS_AFM_CATAL_EMPLE", "AFT_MOV_MAESTRO_MOVIMIENTOS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFT_MOV_MOVIMIENTOS_APROBACIONES")]
        public EntityCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES> AFT_MOV_MOVIMIENTOS_APROBACIONES
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFT_MOV_MOVIMIENTOS_APROBACIONES");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFT_MOV_MOVIMIENTOS_APROBACIONES>("BostonModel.FK_AssetsWEB_MOV_MOVIMIENTOS_APROBACIONES_AFM_CATAL_EMPLE", "AFT_MOV_MOVIMIENTOS_APROBACIONES", value);
                }
            }
        }

        #endregion
    }
}
