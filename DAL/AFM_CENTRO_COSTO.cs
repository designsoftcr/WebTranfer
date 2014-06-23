using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_CENTRO_COSTO"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_CENTRO_COSTO : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CIA_PRO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CEN_CST;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_CEN_CST;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private byte[] _TIMESTAMP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_EMPLEADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CIA_PRO
        {
            get
            {
                return this._COD_CIA_PRO;
            }
            set
            {
                this.ReportPropertyChanging("COD_CIA_PRO");
                this._COD_CIA_PRO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CIA_PRO");
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
        public string COD_CEN_CST
        {
            get
            {
                return this._COD_CEN_CST;
            }
            set
            {
                this.ReportPropertyChanging("COD_CEN_CST");
                this._COD_CEN_CST = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_CEN_CST");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_CEN_CST
        {
            get
            {
                return this._DES_CEN_CST;
            }
            set
            {
                this.ReportPropertyChanging("DES_CEN_CST");
                this._DES_CEN_CST = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_CEN_CST");
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
        public string COD_EMPLEADO
        {
            get
            {
                return this._COD_EMPLEADO;
            }
            set
            {
                this.ReportPropertyChanging("COD_EMPLEADO");
                this._COD_EMPLEADO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_EMPLEADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_CENTRO_COSTO CreateAFM_CENTRO_COSTO(string cOD_COMPANIA, string cOD_CEN_CST)
        {
            return new AFM_CENTRO_COSTO
            {
                COD_COMPANIA = cOD_COMPANIA,
                COD_CEN_CST = cOD_CEN_CST
            };
        }
    }
     */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_CENTRO_COSTO")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_CENTRO_COSTO : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_CENTRO_COSTO object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="cOD_CEN_CST">Initial value of the COD_CEN_CST property.</param>
        public static AFM_CENTRO_COSTO CreateAFM_CENTRO_COSTO(global::System.String cOD_COMPANIA, global::System.String cOD_CEN_CST)
        {
            AFM_CENTRO_COSTO aFM_CENTRO_COSTO = new AFM_CENTRO_COSTO();
            aFM_CENTRO_COSTO.COD_COMPANIA = cOD_COMPANIA;
            aFM_CENTRO_COSTO.COD_CEN_CST = cOD_CEN_CST;
            return aFM_CENTRO_COSTO;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CIA_PRO
        {
            get
            {
                return _COD_CIA_PRO;
            }
            set
            {
                OnCOD_CIA_PROChanging(value);
                ReportPropertyChanging("COD_CIA_PRO");
                _COD_CIA_PRO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CIA_PRO");
                OnCOD_CIA_PROChanged();
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
        public global::System.String COD_CEN_CST
        {
            get
            {
                return _COD_CEN_CST;
            }
            set
            {
                if (_COD_CEN_CST != value)
                {
                    OnCOD_CEN_CSTChanging(value);
                    ReportPropertyChanging("COD_CEN_CST");
                    _COD_CEN_CST = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_CEN_CST");
                    OnCOD_CEN_CSTChanged();
                }
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
        public global::System.String DES_CEN_CST
        {
            get
            {
                return _DES_CEN_CST;
            }
            set
            {
                OnDES_CEN_CSTChanging(value);
                ReportPropertyChanging("DES_CEN_CST");
                _DES_CEN_CST = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_CEN_CST");
                OnDES_CEN_CSTChanged();
            }
        }
        private global::System.String _DES_CEN_CST;
        partial void OnDES_CEN_CSTChanging(global::System.String value);
        partial void OnDES_CEN_CSTChanged();

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
        public global::System.String COD_EMPLEADO
        {
            get
            {
                return _COD_EMPLEADO;
            }
            set
            {
                OnCOD_EMPLEADOChanging(value);
                ReportPropertyChanging("COD_EMPLEADO");
                _COD_EMPLEADO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_EMPLEADO");
                OnCOD_EMPLEADOChanged();
            }
        }
        private global::System.String _COD_EMPLEADO;
        partial void OnCOD_EMPLEADOChanging(global::System.String value);
        partial void OnCOD_EMPLEADOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ACTI_REF_1444_AFM_CENT", "AFM_ACTIV_AUXIL")]
        public EntityCollection<AFM_ACTIV_AUXIL> AFM_ACTIV_AUXIL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ACTIV_AUXIL>("BostonModel.FK_AFM_ACTI_REF_1444_AFM_CENT", "AFM_ACTIV_AUXIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ACTIV_AUXIL>("BostonModel.FK_AFM_ACTI_REF_1444_AFM_CENT", "AFM_ACTIV_AUXIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CATAL_EMPLE")]
        public EntityCollection<AFM_CATAL_EMPLE> AFM_CATAL_EMPLE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_CATAL_EMPLE>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CATAL_EMPLE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_CATAL_EMPLE>("BostonModel.FK_AFM_CATAL_EMPLE_AFM_CENTRO_COSTO", "AFM_CATAL_EMPLE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CENTRO_COSTO_AFM_CIAS", "AFM_CIAS")]
        public AFM_CIAS AFM_CIAS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS", "AFM_CIAS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS", "AFM_CIAS").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS", "AFM_CIAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS", "AFM_CIAS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CENTRO_COSTO_AFM_CIAS1", "AFM_CIAS")]
        public AFM_CIAS AFM_CIAS1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS1", "AFM_CIAS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS1", "AFM_CIAS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CIAS> AFM_CIAS1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS1", "AFM_CIAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS1", "AFM_CIAS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_CENTRO_COSTO_AFM_CIAS2", "AFM_CIAS")]
        public AFM_CIAS AFM_CIAS2
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS2", "AFM_CIAS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS2", "AFM_CIAS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_CIAS> AFM_CIAS2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS2", "AFM_CIAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CIAS>("BostonModel.FK_AFM_CENTRO_COSTO_AFM_CIAS2", "AFM_CIAS", value);
                }
            }
        }

        #endregion
    }
}
