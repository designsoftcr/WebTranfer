using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_SECCI_LOCAL"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_SECCI_LOCAL : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_LOC_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_SEC_LOC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_SEC_LOC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _IND_ACTIVA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private byte[] _TIMESTAMP;
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string DES_SEC_LOC
        {
            get
            {
                return this._DES_SEC_LOC;
            }
            set
            {
                this.ReportPropertyChanging("DES_SEC_LOC");
                this._DES_SEC_LOC = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DES_SEC_LOC");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL"), DataMember, SoapIgnore, XmlIgnore]
        public AFM_CATAL_LOCAL AFM_CATAL_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFM_CATAL_LOCAL> AFM_CATAL_LOCALReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_SECCI_LOCAL CreateAFM_SECCI_LOCAL(string cOD_COMPANIA, string cOD_LOC_ACT, string cOD_SEC_LOC, string dES_SEC_LOC, string iND_ACTIVA)
        {
            return new AFM_SECCI_LOCAL
            {
                COD_COMPANIA = cOD_COMPANIA,
                COD_LOC_ACT = cOD_LOC_ACT,
                COD_SEC_LOC = cOD_SEC_LOC,
                DES_SEC_LOC = dES_SEC_LOC,
                IND_ACTIVA = iND_ACTIVA
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_SECCI_LOCAL")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_SECCI_LOCAL : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_SECCI_LOCAL object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cOD_LOC_ACT">Initial value of the COD_LOC_ACT property.</param>
        /// <param name="cOD_SEC_LOC">Initial value of the COD_SEC_LOC property.</param>
        /// <param name="dES_SEC_LOC">Initial value of the DES_SEC_LOC property.</param>
        /// <param name="iND_ACTIVA">Initial value of the IND_ACTIVA property.</param>
        public static AFM_SECCI_LOCAL CreateAFM_SECCI_LOCAL(global::System.String cOD_COMPANIA, global::System.String cOD_LOC_ACT, global::System.String cOD_SEC_LOC, global::System.String dES_SEC_LOC, global::System.String iND_ACTIVA)
        {
            AFM_SECCI_LOCAL aFM_SECCI_LOCAL = new AFM_SECCI_LOCAL();
            aFM_SECCI_LOCAL.COD_COMPANIA = cOD_COMPANIA;
            aFM_SECCI_LOCAL.COD_LOC_ACT = cOD_LOC_ACT;
            aFM_SECCI_LOCAL.COD_SEC_LOC = cOD_SEC_LOC;
            aFM_SECCI_LOCAL.DES_SEC_LOC = dES_SEC_LOC;
            aFM_SECCI_LOCAL.IND_ACTIVA = iND_ACTIVA;
            return aFM_SECCI_LOCAL;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String DES_SEC_LOC
        {
            get
            {
                return _DES_SEC_LOC;
            }
            set
            {
                OnDES_SEC_LOCChanging(value);
                ReportPropertyChanging("DES_SEC_LOC");
                _DES_SEC_LOC = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DES_SEC_LOC");
                OnDES_SEC_LOCChanged();
            }
        }
        private global::System.String _DES_SEC_LOC;
        partial void OnDES_SEC_LOCChanging(global::System.String value);
        partial void OnDES_SEC_LOCChanged();

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

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL")]
        public AFM_CATAL_LOCAL AFM_CATAL_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_CATAL_LOCAL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETAL_TOMAF_AFM_SECCI_LOCAL", "AFM_DETAL_TOMAF")]
        public EntityCollection<AFM_DETAL_TOMAF> AFM_DETAL_TOMAF
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_SECCI_LOCAL", "AFM_DETAL_TOMAF");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_SECCI_LOCAL", "AFM_DETAL_TOMAF", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_UBICA_ACTIV")]
        public EntityCollection<AFM_UBICA_ACTIV> AFM_UBICA_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_UBICA_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_SECCI_LOCAL", "AFM_UBICA_ACTIV", value);
                }
            }
        }

        #endregion
    }
}
