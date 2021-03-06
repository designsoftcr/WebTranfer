﻿using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_MARCA_ACTIV"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_MARCA_ACTIV : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MARCA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_MARCA;
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_MARCA
        {
            get
            {
                return this._DES_MARCA;
            }
            set
            {
                this.ReportPropertyChanging("DES_MARCA");
                this._DES_MARCA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_MARCA");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmRelationshipNavigationProperty("BostonModel", "FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV"), DataMember, SoapIgnore, XmlIgnore]
        public EntityCollection<AFM_MODEL_ACTIV> AFM_MODEL_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MODEL_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV");
            }
            set
            {
                if (value != null)
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MODEL_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV", value);
                }
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_MARCA_ACTIV CreateAFM_MARCA_ACTIV(string cOD_MARCA)
        {
            return new AFM_MARCA_ACTIV
            {
                COD_MARCA = cOD_MARCA
            };
        }
    }
     * */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_MARCA_ACTIV")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_MARCA_ACTIV : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_MARCA_ACTIV object.
        /// </summary>
        /// <param name="cOD_MARCA">Initial value of the COD_MARCA property.</param>
        public static AFM_MARCA_ACTIV CreateAFM_MARCA_ACTIV(global::System.String cOD_MARCA)
        {
            AFM_MARCA_ACTIV aFM_MARCA_ACTIV = new AFM_MARCA_ACTIV();
            aFM_MARCA_ACTIV.COD_MARCA = cOD_MARCA;
            return aFM_MARCA_ACTIV;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DES_MARCA
        {
            get
            {
                return _DES_MARCA;
            }
            set
            {
                OnDES_MARCAChanging(value);
                ReportPropertyChanging("DES_MARCA");
                _DES_MARCA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_MARCA");
                OnDES_MARCAChanged();
            }
        }
        private global::System.String _DES_MARCA;
        partial void OnDES_MARCAChanging(global::System.String value);
        partial void OnDES_MARCAChanged();

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
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EQUIP_TERCE_AFM_MARCA_ACTIV", "AFM_EQUIP_TERCE")]
        public EntityCollection<AFM_EQUIP_TERCE> AFM_EQUIP_TERCE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EQUIP_TERCE>("BostonModel.FK_AFM_EQUIP_TERCE_AFM_MARCA_ACTIV", "AFM_EQUIP_TERCE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EQUIP_TERCE>("BostonModel.FK_AFM_EQUIP_TERCE_AFM_MARCA_ACTIV", "AFM_EQUIP_TERCE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MARCA_SESIO_AFM_MARCA_ACTIV", "AFM_MARCA_SESIO")]
        public EntityCollection<AFM_MARCA_SESIO> AFM_MARCA_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MARCA_SESIO>("BostonModel.FK_AFM_MARCA_SESIO_AFM_MARCA_ACTIV", "AFM_MARCA_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MARCA_SESIO>("BostonModel.FK_AFM_MARCA_SESIO_AFM_MARCA_ACTIV", "AFM_MARCA_SESIO", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV")]
        public EntityCollection<AFM_MODEL_ACTIV> AFM_MODEL_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MODEL_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MODEL_ACTIV>("BostonModel.FK_AFM_MODEL_ACTIV_AFM_MARCA_ACTIV", "AFM_MODEL_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MODEL_SESIO_AFM_MARCA_ACTIV", "AFM_MODEL_SESIO")]
        public EntityCollection<AFM_MODEL_SESIO> AFM_MODEL_SESIO
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_MODEL_SESIO>("BostonModel.FK_AFM_MODEL_SESIO_AFM_MARCA_ACTIV", "AFM_MODEL_SESIO");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_MODEL_SESIO>("BostonModel.FK_AFM_MODEL_SESIO_AFM_MARCA_ACTIV", "AFM_MODEL_SESIO", value);
                }
            }
        }

        #endregion
    }
}
