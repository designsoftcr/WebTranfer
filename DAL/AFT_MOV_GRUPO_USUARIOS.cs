using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_GRUPO_USUARIOS")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_GRUPO_USUARIOS : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_GRUPO_USUARIOS object.
        /// </summary>
        /// <param name="iD_EMPLEADO">Initial value of the ID_EMPLEADO property.</param>
        /// <param name="iD_GRUPO">Initial value of the ID_GRUPO property.</param>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        public static AFT_MOV_GRUPO_USUARIOS CreateAFT_MOV_GRUPO_USUARIOS(global::System.String iD_EMPLEADO, global::System.Int32 iD_GRUPO, global::System.String cOD_COMPANIA)
        {
            AFT_MOV_GRUPO_USUARIOS aFT_MOV_GRUPO_USUARIOS = new AFT_MOV_GRUPO_USUARIOS();
            aFT_MOV_GRUPO_USUARIOS.ID_EMPLEADO = iD_EMPLEADO;
            aFT_MOV_GRUPO_USUARIOS.ID_GRUPO = iD_GRUPO;
            aFT_MOV_GRUPO_USUARIOS.COD_COMPANIA = cOD_COMPANIA;
            return aFT_MOV_GRUPO_USUARIOS;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String ID_EMPLEADO
        {
            get
            {
                return _ID_EMPLEADO;
            }
            set
            {
                if (_ID_EMPLEADO != value)
                {
                    OnID_EMPLEADOChanging(value);
                    ReportPropertyChanging("ID_EMPLEADO");
                    _ID_EMPLEADO = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ID_EMPLEADO");
                    OnID_EMPLEADOChanged();
                }
            }
        }
        private global::System.String _ID_EMPLEADO;
        partial void OnID_EMPLEADOChanging(global::System.String value);
        partial void OnID_EMPLEADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID_GRUPO
        {
            get
            {
                return _ID_GRUPO;
            }
            set
            {
                if (_ID_GRUPO != value)
                {
                    OnID_GRUPOChanging(value);
                    ReportPropertyChanging("ID_GRUPO");
                    _ID_GRUPO = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID_GRUPO");
                    OnID_GRUPOChanged();
                }
            }
        }
        private global::System.Int32 _ID_GRUPO;
        partial void OnID_GRUPOChanging(global::System.Int32 value);
        partial void OnID_GRUPOChanged();

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> ESTADO
        {
            get
            {
                return _ESTADO;
            }
            set
            {
                OnESTADOChanging(value);
                ReportPropertyChanging("ESTADO");
                _ESTADO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ESTADO");
                OnESTADOChanged();
            }
        }
        private Nullable<global::System.Boolean> _ESTADO;
        partial void OnESTADOChanging(Nullable<global::System.Boolean> value);
        partial void OnESTADOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String USUARIO
        {
            get
            {
                return _USUARIO;
            }
            set
            {
                OnUSUARIOChanging(value);
                ReportPropertyChanging("USUARIO");
                _USUARIO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("USUARIO");
                OnUSUARIOChanged();
            }
        }
        private global::System.String _USUARIO;
        partial void OnUSUARIOChanging(global::System.String value);
        partial void OnUSUARIOChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE")]
        public AFM_CATAL_EMPLE AFM_CATAL_EMPLE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFM_CATAL_EMPLE>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AFM_CATAL_EMPLE", "AFM_CATAL_EMPLE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS")]
        public AFT_MOV_GRUPOS_ACCESOS AFT_MOV_GRUPOS_ACCESOS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<AFT_MOV_GRUPOS_ACCESOS> AFT_MOV_GRUPOS_ACCESOSReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<AFT_MOV_GRUPOS_ACCESOS>("BostonModel.FK_AssetsWEB_MOV_GRUPO_USUARIOS_AssetsWEB_MOV_GRUPOS_ACCESOS", "AFT_MOV_GRUPOS_ACCESOS", value);
                }
            }
        }

        #endregion
    }

}
