using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_CATAL_LOCAL"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_CATAL_LOCAL : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_LOC_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_LOC_ACT;
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string DES_LOC_ACT
        {
            get
            {
                return this._DES_LOC_ACT;
            }
            set
            {
                this.ReportPropertyChanging("DES_LOC_ACT");
                this._DES_LOC_ACT = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DES_LOC_ACT");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFM_SECCI_LOCAL> AFM_SECCI_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFM_UBICA_ACTIV> AFM_UBICA_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_CATAL_LOCAL CreateAFM_CATAL_LOCAL(string cOD_COMPANIA, string cOD_LOC_ACT, string dES_LOC_ACT, string iND_ACTIVA)
        {
            return new AFM_CATAL_LOCAL
            {
                COD_COMPANIA = cOD_COMPANIA,
                COD_LOC_ACT = cOD_LOC_ACT,
                DES_LOC_ACT = dES_LOC_ACT,
                IND_ACTIVA = iND_ACTIVA
            };
        }
    }
     */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_CATAL_LOCAL")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_CATAL_LOCAL : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_CATAL_LOCAL object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cOD_LOC_ACT">Initial value of the COD_LOC_ACT property.</param>
        /// <param name="dES_LOC_ACT">Initial value of the DES_LOC_ACT property.</param>
        /// <param name="iND_ACTIVA">Initial value of the IND_ACTIVA property.</param>
        public static AFM_CATAL_LOCAL CreateAFM_CATAL_LOCAL(global::System.String cOD_COMPANIA, global::System.String cOD_LOC_ACT, global::System.String dES_LOC_ACT, global::System.String iND_ACTIVA)
        {
            AFM_CATAL_LOCAL aFM_CATAL_LOCAL = new AFM_CATAL_LOCAL();
            aFM_CATAL_LOCAL.COD_COMPANIA = cOD_COMPANIA;
            aFM_CATAL_LOCAL.COD_LOC_ACT = cOD_LOC_ACT;
            aFM_CATAL_LOCAL.DES_LOC_ACT = dES_LOC_ACT;
            aFM_CATAL_LOCAL.IND_ACTIVA = iND_ACTIVA;
            return aFM_CATAL_LOCAL;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String DES_LOC_ACT
        {
            get
            {
                return _DES_LOC_ACT;
            }
            set
            {
                OnDES_LOC_ACTChanging(value);
                ReportPropertyChanging("DES_LOC_ACT");
                _DES_LOC_ACT = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DES_LOC_ACT");
                OnDES_LOC_ACTChanged();
            }
        }
        private global::System.String _DES_LOC_ACT;
        partial void OnDES_LOC_ACTChanging(global::System.String value);
        partial void OnDES_LOC_ACTChanged();

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
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CATAL_LOCAL_AFM_CIAS", "AFM_CIAS")]
        public AFM_CIAS AFM_CIAS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_LOCAL_AFM_CIAS", "AFM_CIAS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_LOCAL_AFM_CIAS", "AFM_CIAS").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_LOCAL_AFM_CIAS", "AFM_CIAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CATAL_LOCAL_AFM_CIAS", "AFM_CIAS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETAL_TOMAF_AFM_CATAL_LOCAL", "AFM_DETAL_TOMAF")]
        public EntityCollection<AFM_DETAL_TOMAF> AFM_DETAL_TOMAF
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_CATAL_LOCAL", "AFM_DETAL_TOMAF");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_CATAL_LOCAL", "AFM_DETAL_TOMAF", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL")]
        public EntityCollection<AFM_SECCI_LOCAL> AFM_SECCI_LOCAL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_SECCI_LOCAL>("BostonModel.FK_AFM_SECCI_LOCAL_AFM_CATAL_LOCAL", "AFM_SECCI_LOCAL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV")]
        public EntityCollection<AFM_UBICA_ACTIV> AFM_UBICA_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_UBICA_ACTIV>("BostonModel.FK_AFM_UBICA_ACTIV_AFM_CATAL_LOCAL", "AFM_UBICA_ACTIV", value);
                }
            }
        }

        #endregion
    }
}
