using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFT_MOV_BITACORA"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFT_MOV_BITACORA : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _CODIGO_BITACORA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _ID_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DESCRIPCION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime _FECHA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DESCRIPCION_TIPO_MOVIMIENTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _USUARIO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _PASO_APROBACION;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int CODIGO_BITACORA
        {
            get
            {
                return this._CODIGO_BITACORA;
            }
            set
            {
                this.ReportPropertyChanging("CODIGO_BITACORA");
                this._CODIGO_BITACORA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CODIGO_BITACORA");
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
        public string DESCRIPCION
        {
            get
            {
                return this._DESCRIPCION;
            }
            set
            {
                this.ReportPropertyChanging("DESCRIPCION");
                this._DESCRIPCION = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DESCRIPCION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public DateTime FECHA
        {
            get
            {
                return this._FECHA;
            }
            set
            {
                this.ReportPropertyChanging("FECHA");
                this._FECHA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FECHA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string DESCRIPCION_TIPO_MOVIMIENTO
        {
            get
            {
                return this._DESCRIPCION_TIPO_MOVIMIENTO;
            }
            set
            {
                this.ReportPropertyChanging("DESCRIPCION_TIPO_MOVIMIENTO");
                this._DESCRIPCION_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DESCRIPCION_TIPO_MOVIMIENTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string USUARIO
        {
            get
            {
                return this._USUARIO;
            }
            set
            {
                this.ReportPropertyChanging("USUARIO");
                this._USUARIO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("USUARIO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string PASO_APROBACION
        {
            get
            {
                return this._PASO_APROBACION;
            }
            set
            {
                this.ReportPropertyChanging("PASO_APROBACION");
                this._PASO_APROBACION = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("PASO_APROBACION");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFT_MOV_BITACORA CreateAFT_MOV_BITACORA(int cODIGO_BITACORA, int iD_MOVIMIENTO, string cOD_COMPANIA, string dESCRIPCION, DateTime fECHA, string dESCRIPCION_TIPO_MOVIMIENTO, string pASO_APROBACION)
        {
            return new AFT_MOV_BITACORA
            {
                CODIGO_BITACORA = cODIGO_BITACORA,
                ID_MOVIMIENTO = iD_MOVIMIENTO,
                COD_COMPANIA = cOD_COMPANIA,
                DESCRIPCION = dESCRIPCION,
                FECHA = fECHA,
                DESCRIPCION_TIPO_MOVIMIENTO = dESCRIPCION_TIPO_MOVIMIENTO,
                PASO_APROBACION = pASO_APROBACION
            };
        }
    }
    */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFT_MOV_BITACORA")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFT_MOV_BITACORA : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFT_MOV_BITACORA object.
        /// </summary>
        /// <param name="cODIGO_BITACORA">Initial value of the CODIGO_BITACORA property.</param>
        /// <param name="iD_MOVIMIENTO">Initial value of the ID_MOVIMIENTO property.</param>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="dESCRIPCION">Initial value of the DESCRIPCION property.</param>
        /// <param name="fECHA">Initial value of the FECHA property.</param>
        /// <param name="dESCRIPCION_TIPO_MOVIMIENTO">Initial value of the DESCRIPCION_TIPO_MOVIMIENTO property.</param>
        /// <param name="pASO_APROBACION">Initial value of the PASO_APROBACION property.</param>
        public static AFT_MOV_BITACORA CreateAFT_MOV_BITACORA(global::System.Int32 cODIGO_BITACORA, global::System.Int32 iD_MOVIMIENTO, global::System.String cOD_COMPANIA, global::System.String dESCRIPCION, global::System.DateTime fECHA, global::System.String dESCRIPCION_TIPO_MOVIMIENTO, global::System.String pASO_APROBACION)
        {
            AFT_MOV_BITACORA aFT_MOV_BITACORA = new AFT_MOV_BITACORA();
            aFT_MOV_BITACORA.CODIGO_BITACORA = cODIGO_BITACORA;
            aFT_MOV_BITACORA.ID_MOVIMIENTO = iD_MOVIMIENTO;
            aFT_MOV_BITACORA.COD_COMPANIA = cOD_COMPANIA;
            aFT_MOV_BITACORA.DESCRIPCION = dESCRIPCION;
            aFT_MOV_BITACORA.FECHA = fECHA;
            aFT_MOV_BITACORA.DESCRIPCION_TIPO_MOVIMIENTO = dESCRIPCION_TIPO_MOVIMIENTO;
            aFT_MOV_BITACORA.PASO_APROBACION = pASO_APROBACION;
            return aFT_MOV_BITACORA;
        }

        #endregion
        #region Primitive Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = true, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Int32 CODIGO_BITACORA
        {
            get
            {
                return _CODIGO_BITACORA;
            }
            set
            {
                if (_CODIGO_BITACORA != value)
                {
                    OnCODIGO_BITACORAChanging(value);
                    ReportPropertyChanging("CODIGO_BITACORA");
                    _CODIGO_BITACORA = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CODIGO_BITACORA");
                    OnCODIGO_BITACORAChanged();
                }
            }
        }
        private global::System.Int32 _CODIGO_BITACORA;
        partial void OnCODIGO_BITACORAChanging(global::System.Int32 value);
        partial void OnCODIGO_BITACORAChanged();

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
                _DESCRIPCION = StructuralObject.SetValidValue(value, false);
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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.DateTime FECHA
        {
            get
            {
                return _FECHA;
            }
            set
            {
                OnFECHAChanging(value);
                ReportPropertyChanging("FECHA");
                _FECHA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FECHA");
                OnFECHAChanged();
            }
        }
        private global::System.DateTime _FECHA;
        partial void OnFECHAChanging(global::System.DateTime value);
        partial void OnFECHAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String DESCRIPCION_TIPO_MOVIMIENTO
        {
            get
            {
                return _DESCRIPCION_TIPO_MOVIMIENTO;
            }
            set
            {
                OnDESCRIPCION_TIPO_MOVIMIENTOChanging(value);
                ReportPropertyChanging("DESCRIPCION_TIPO_MOVIMIENTO");
                _DESCRIPCION_TIPO_MOVIMIENTO = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DESCRIPCION_TIPO_MOVIMIENTO");
                OnDESCRIPCION_TIPO_MOVIMIENTOChanged();
            }
        }
        private global::System.String _DESCRIPCION_TIPO_MOVIMIENTO;
        partial void OnDESCRIPCION_TIPO_MOVIMIENTOChanging(global::System.String value);
        partial void OnDESCRIPCION_TIPO_MOVIMIENTOChanged();

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

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String PASO_APROBACION
        {
            get
            {
                return _PASO_APROBACION;
            }
            set
            {
                OnPASO_APROBACIONChanging(value);
                ReportPropertyChanging("PASO_APROBACION");
                _PASO_APROBACION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PASO_APROBACION");
                OnPASO_APROBACIONChanged();
            }
        }
        private global::System.String _PASO_APROBACION;
        partial void OnPASO_APROBACIONChanging(global::System.String value);
        partial void OnPASO_APROBACIONChanged();

        #endregion

    }

}
