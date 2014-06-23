using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_MODEL_ACTIV"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_MODEL_ACTIV : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MARCA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MODELO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NOM_MODELO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private byte[] _TIMESTAMP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string COD_MARCA
        {
            get
            {
                return this._COD_MARCA;
            }
            set
            {
                this.ReportPropertyChanging("COD_MARCA");
                this._COD_MARCA = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_MARCA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string COD_MODELO
        {
            get
            {
                return this._COD_MODELO;
            }
            set
            {
                this.ReportPropertyChanging("COD_MODELO");
                this._COD_MODELO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_MODELO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string NOM_MODELO
        {
            get
            {
                return this._NOM_MODELO;
            }
            set
            {
                this.ReportPropertyChanging("NOM_MODELO");
                this._NOM_MODELO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("NOM_MODELO");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV"), DataMember, SoapIgnore, XmlIgnore]
        public AFM_MARCA_ACTIV AFM_MARCA_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV").Value = value;
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), Browsable(false), DataMember]
        public EntityReference<AFM_MARCA_ACTIV> AFM_MARCA_ACTIVReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_MODEL_ACTIV CreateAFM_MODEL_ACTIV(string cOD_MARCA, string cOD_MODELO, string nOM_MODELO)
        {
            return new AFM_MODEL_ACTIV
            {
                COD_MARCA = cOD_MARCA,
                COD_MODELO = cOD_MODELO,
                NOM_MODELO = nOM_MODELO
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_MODEL_ACTIV")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_MODEL_ACTIV : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_MODEL_ACTIV object.
        /// </summary>
        /// <param name="cOD_MARCA">Initial value of the COD_MARCA property.</param>
        /// <param name="cOD_MODELO">Initial value of the COD_MODELO property.</param>
        /// <param name="nOM_MODELO">Initial value of the NOM_MODELO property.</param>
        public static AFM_MODEL_ACTIV CreateAFM_MODEL_ACTIV(global::System.String cOD_MARCA, global::System.String cOD_MODELO, global::System.String nOM_MODELO)
        {
            AFM_MODEL_ACTIV aFM_MODEL_ACTIV = new AFM_MODEL_ACTIV();
            aFM_MODEL_ACTIV.COD_MARCA = cOD_MARCA;
            aFM_MODEL_ACTIV.COD_MODELO = cOD_MODELO;
            aFM_MODEL_ACTIV.NOM_MODELO = nOM_MODELO;
            return aFM_MODEL_ACTIV;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_MARCA
        {
            get
            {
                return _COD_MARCA;
            }
            set
            {
                if (_COD_MARCA != value)
                {
                    OnCOD_MARCAChanging(value);
                    ReportPropertyChanging("COD_MARCA");
                    _COD_MARCA = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_MARCA");
                    OnCOD_MARCAChanged();
                }
            }
        }
        private global::System.String _COD_MARCA;
        partial void OnCOD_MARCAChanging(global::System.String value);
        partial void OnCOD_MARCAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_MODELO
        {
            get
            {
                return _COD_MODELO;
            }
            set
            {
                if (_COD_MODELO != value)
                {
                    OnCOD_MODELOChanging(value);
                    ReportPropertyChanging("COD_MODELO");
                    _COD_MODELO = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("COD_MODELO");
                    OnCOD_MODELOChanged();
                }
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
        public global::System.String NOM_MODELO
        {
            get
            {
                return _NOM_MODELO;
            }
            set
            {
                OnNOM_MODELOChanging(value);
                ReportPropertyChanging("NOM_MODELO");
                _NOM_MODELO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NOM_MODELO");
                OnNOM_MODELOChanged();
            }
        }
        private global::System.String _NOM_MODELO;
        partial void OnNOM_MODELOChanging(global::System.String value);
        partial void OnNOM_MODELOChanged();

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
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EQUIP_TERCE_AFM_MODEL_ACTIV", "AFM_EQUIP_TERCE")]
        public EntityCollection<AFM_EQUIP_TERCE> AFM_EQUIP_TERCE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EQUIP_TERCE>("BostonModel.FK_AFM_EQUIP_TERCE_AFM_MODEL_ACTIV", "AFM_EQUIP_TERCE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EQUIP_TERCE>("BostonModel.FK_AFM_EQUIP_TERCE_AFM_MODEL_ACTIV", "AFM_EQUIP_TERCE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV")]
        public AFM_MARCA_ACTIV AFM_MARCA_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFM_MARCA_ACTIV> AFM_MARCA_ACTIVReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_MARCA_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MARCA_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MODEL_SESIO_AFM_MODEL_ACTIV", "AFM_MODEL_SESIO")]
        public EntityCollection<AFM_MODEL_SESIO> AFM_MODEL_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MODEL_SESIO>("BostonModel.FK_AFM_MODEL_SESIO_AFM_MODEL_ACTIV", "AFM_MODEL_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MODEL_SESIO>("BostonModel.FK_AFM_MODEL_SESIO_AFM_MODEL_ACTIV", "AFM_MODEL_SESIO", value);
                }
            }
        }

        #endregion
    }
}
