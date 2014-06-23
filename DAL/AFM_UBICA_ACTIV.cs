using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_UBICA_ACTIV"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_UBICA_ACTIV : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CIA_PRT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_LOC_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_SEC_LOC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_UBI_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_UBI_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_UBI_ACT2;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_BAR_UBI;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _IND_ACTIVA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private byte[] _TIMESTAMP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CEN_CST;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CIA_PRT
        {
            get
            {
                return this._COD_CIA_PRT;
            }
            set
            {
                this.ReportPropertyChanging("COD_CIA_PRT");
                this._COD_CIA_PRT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CIA_PRT");
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
        public string COD_LOC_ACT
        {
            get
            {
                return this._COD_LOC_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_LOC_ACT");
                this._COD_LOC_ACT = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_LOC_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string COD_SEC_LOC
        {
            get
            {
                return this._COD_SEC_LOC;
            }
            set
            {
                this.ReportPropertyChanging("COD_SEC_LOC");
                this._COD_SEC_LOC = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_SEC_LOC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string COD_UBI_ACT
        {
            get
            {
                return this._COD_UBI_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_UBI_ACT");
                this._COD_UBI_ACT = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_UBI_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string DES_UBI_ACT
        {
            get
            {
                return this._DES_UBI_ACT;
            }
            set
            {
                this.ReportPropertyChanging("DES_UBI_ACT");
                this._DES_UBI_ACT = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DES_UBI_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_UBI_ACT2
        {
            get
            {
                return this._DES_UBI_ACT2;
            }
            set
            {
                this.ReportPropertyChanging("DES_UBI_ACT2");
                this._DES_UBI_ACT2 = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_UBI_ACT2");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_BAR_UBI
        {
            get
            {
                return this._COD_BAR_UBI;
            }
            set
            {
                this.ReportPropertyChanging("COD_BAR_UBI");
                this._COD_BAR_UBI = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_BAR_UBI");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string IND_ACTIVA
        {
            get
            {
                return this._IND_ACTIVA;
            }
            set
            {
                this.ReportPropertyChanging("IND_ACTIVA");
                this._IND_ACTIVA = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("IND_ACTIVA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public byte[] TIMESTAMP
        {
            get
            {
                return StructuralObject.GetValidValue(this._TIMESTAMP);
            }
            set
            {
                this.ReportPropertyChanging("TIMESTAMP");
                this._TIMESTAMP = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("TIMESTAMP");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL"), DataMember, SoapIgnore, XmlIgnore]
        public AFM_CATAL_LOCAL AFM_CATAL_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFM_CATAL_LOCAL> AFM_CATAL_LOCALReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_UBICA_ACTIV CreateAFM_UBICA_ACTIV(string cOD_COMPANIA, string cOD_LOC_ACT, string cOD_SEC_LOC, string cOD_UBI_ACT, string dES_UBI_ACT, string iND_ACTIVA)
        {
            return new AFM_UBICA_ACTIV
            {
                COD_COMPANIA = cOD_COMPANIA,
                COD_LOC_ACT = cOD_LOC_ACT,
                COD_SEC_LOC = cOD_SEC_LOC,
                COD_UBI_ACT = cOD_UBI_ACT,
                DES_UBI_ACT = dES_UBI_ACT,
                IND_ACTIVA = iND_ACTIVA
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_UBICA_ACTIV")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_UBICA_ACTIV : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_UBICA_ACTIV object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cOD_LOC_ACT">Initial value of the COD_LOC_ACT property.</param>
        /// <param name="cOD_SEC_LOC">Initial value of the COD_SEC_LOC property.</param>
        /// <param name="cOD_UBI_ACT">Initial value of the COD_UBI_ACT property.</param>
        /// <param name="dES_UBI_ACT">Initial value of the DES_UBI_ACT property.</param>
        /// <param name="iND_ACTIVA">Initial value of the IND_ACTIVA property.</param>
        public static AFM_UBICA_ACTIV CreateAFM_UBICA_ACTIV(global::System.String cOD_COMPANIA, global::System.String cOD_LOC_ACT, global::System.String cOD_SEC_LOC, global::System.String cOD_UBI_ACT, global::System.String dES_UBI_ACT, global::System.String iND_ACTIVA)
        {
            AFM_UBICA_ACTIV aFM_UBICA_ACTIV = new AFM_UBICA_ACTIV();
            aFM_UBICA_ACTIV.COD_COMPANIA = cOD_COMPANIA;
            aFM_UBICA_ACTIV.COD_LOC_ACT = cOD_LOC_ACT;
            aFM_UBICA_ACTIV.COD_SEC_LOC = cOD_SEC_LOC;
            aFM_UBICA_ACTIV.COD_UBI_ACT = cOD_UBI_ACT;
            aFM_UBICA_ACTIV.DES_UBI_ACT = dES_UBI_ACT;
            aFM_UBICA_ACTIV.IND_ACTIVA = iND_ACTIVA;
            return aFM_UBICA_ACTIV;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CIA_PRT
        {
            get
            {
                return _COD_CIA_PRT;
            }
            set
            {
                OnCOD_CIA_PRTChanging(value);
                ReportPropertyChanging("COD_CIA_PRT");
                _COD_CIA_PRT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CIA_PRT");
                OnCOD_CIA_PRTChanged();
            }
        }
        private global::System.String _COD_CIA_PRT;
        partial void OnCOD_CIA_PRTChanging(global::System.String value);
        partial void OnCOD_CIA_PRTChanged();

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
        public global::System.String COD_LOC_ACT
        {
            get
            {
                return _COD_LOC_ACT;
            }
            set
            {
                if (_COD_LOC_ACT != value)
                {
                    OnCOD_LOC_ACTChanging(value);
                    ReportPropertyChanging("COD_LOC_ACT");
                    _COD_LOC_ACT = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_LOC_ACT");
                    OnCOD_LOC_ACTChanged();
                }
            }
        }
        private global::System.String _COD_LOC_ACT;
        partial void OnCOD_LOC_ACTChanging(global::System.String value);
        partial void OnCOD_LOC_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_SEC_LOC
        {
            get
            {
                return _COD_SEC_LOC;
            }
            set
            {
                if (_COD_SEC_LOC != value)
                {
                    OnCOD_SEC_LOCChanging(value);
                    ReportPropertyChanging("COD_SEC_LOC");
                    _COD_SEC_LOC = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_SEC_LOC");
                    OnCOD_SEC_LOCChanged();
                }
            }
        }
        private global::System.String _COD_SEC_LOC;
        partial void OnCOD_SEC_LOCChanging(global::System.String value);
        partial void OnCOD_SEC_LOCChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_UBI_ACT
        {
            get
            {
                return _COD_UBI_ACT;
            }
            set
            {
                if (_COD_UBI_ACT != value)
                {
                    OnCOD_UBI_ACTChanging(value);
                    ReportPropertyChanging("COD_UBI_ACT");
                    _COD_UBI_ACT = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_UBI_ACT");
                    OnCOD_UBI_ACTChanged();
                }
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
        public global::System.String DES_UBI_ACT
        {
            get
            {
                return _DES_UBI_ACT;
            }
            set
            {
                OnDES_UBI_ACTChanging(value);
                ReportPropertyChanging("DES_UBI_ACT");
                _DES_UBI_ACT = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DES_UBI_ACT");
                OnDES_UBI_ACTChanged();
            }
        }
        private global::System.String _DES_UBI_ACT;
        partial void OnDES_UBI_ACTChanging(global::System.String value);
        partial void OnDES_UBI_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DES_UBI_ACT2
        {
            get
            {
                return _DES_UBI_ACT2;
            }
            set
            {
                OnDES_UBI_ACT2Changing(value);
                ReportPropertyChanging("DES_UBI_ACT2");
                _DES_UBI_ACT2 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_UBI_ACT2");
                OnDES_UBI_ACT2Changed();
            }
        }
        private global::System.String _DES_UBI_ACT2;
        partial void OnDES_UBI_ACT2Changing(global::System.String value);
        partial void OnDES_UBI_ACT2Changed();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_BAR_UBI
        {
            get
            {
                return _COD_BAR_UBI;
            }
            set
            {
                OnCOD_BAR_UBIChanging(value);
                ReportPropertyChanging("COD_BAR_UBI");
                _COD_BAR_UBI = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_BAR_UBI");
                OnCOD_BAR_UBIChanged();
            }
        }
        private global::System.String _COD_BAR_UBI;
        partial void OnCOD_BAR_UBIChanging(global::System.String value);
        partial void OnCOD_BAR_UBIChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String IND_ACTIVA
        {
            get
            {
                return _IND_ACTIVA;
            }
            set
            {
                OnIND_ACTIVAChanging(value);
                ReportPropertyChanging("IND_ACTIVA");
                _IND_ACTIVA = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("IND_ACTIVA");
                OnIND_ACTIVAChanged();
            }
        }
        private global::System.String _IND_ACTIVA;
        partial void OnIND_ACTIVAChanging(global::System.String value);
        partial void OnIND_ACTIVAChanged();

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

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL")]
        public AFM_CATAL_LOCAL AFM_CATAL_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CATAL_LOCAL> AFM_CATAL_LOCALReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETAL_TOMAF_AFM_UBICA_ACTIV", "AFM_DETAL_TOMAF")]
        public EntityCollection<AFM_DETAL_TOMAF> AFM_DETAL_TOMAF
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_UBICA_ACTIV", "AFM_DETAL_TOMAF");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_UBICA_ACTIV", "AFM_DETAL_TOMAF", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_IMPRE_PLACAS_UBICA_AFM_UBICA_ACTIV", "AFM_IMPRE_PLACAS_UBICA")]
        public EntityCollection<AFM_IMPRE_PLACAS_UBICA> AFM_IMPRE_PLACAS_UBICA
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_IMPRE_PLACAS_UBICA>("BostonModel.FK_AFM_IMPRE_PLACAS_UBICA_AFM_UBICA_ACTIV", "AFM_IMPRE_PLACAS_UBICA");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_IMPRE_PLACAS_UBICA>("BostonModel.FK_AFM_IMPRE_PLACAS_UBICA_AFM_UBICA_ACTIV", "AFM_IMPRE_PLACAS_UBICA", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MOVI_REF_774_AFM_UBIC", "AFM_MOVIM_VALOR")]
        public EntityCollection<AFM_MOVIM_VALOR> AFM_MOVIM_VALOR
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MOVIM_VALOR>("BostonModel.FK_AFM_MOVI_REF_774_AFM_UBIC", "AFM_MOVIM_VALOR");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MOVIM_VALOR>("BostonModel.FK_AFM_MOVI_REF_774_AFM_UBIC", "AFM_MOVIM_VALOR", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_OPERA_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_OPERA_UBICA_SESIO")]
        public EntityCollection<AFM_OPERA_UBICA_SESIO> AFM_OPERA_UBICA_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_OPERA_UBICA_SESIO>("BostonModel.FK_AFM_OPERA_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_OPERA_UBICA_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_OPERA_UBICA_SESIO>("BostonModel.FK_AFM_OPERA_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_OPERA_UBICA_SESIO", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_SECCI_LOCAL")]
        public AFM_SECCI_LOCAL AFM_SECCI_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_SECCI_LOCAL").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_SECCI_LOCAL").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_SECCI_LOCAL> AFM_SECCI_LOCALReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_SECCI_LOCAL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_SECCI_LOCAL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_UBICA_SESIO")]
        public EntityCollection<AFM_UBICA_SESIO> AFM_UBICA_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_UBICA_SESIO>("BostonModel.FK_AFM_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_UBICA_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_UBICA_SESIO>("BostonModel.FK_AFM_UBICA_SESIO_AFM_UBICA_ACTIV", "AFM_UBICA_SESIO", value);
                }
            }
        }

        #endregion
    }
}
