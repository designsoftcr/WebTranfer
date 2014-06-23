using System;
using System.CodeDom.Compiler;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
namespace DAL
{
    /*
    [EdmEntityType(NamespaceName = "BostonModel", Name = "AFM_MAEST_ACTIV"), DataContract(IsReference = true)]
    [Serializable]
    public partial class AFM_MAEST_ACTIV : EntityObject
    {
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_COMPANIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CIA_PRO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _PLA_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_ACTIVO_ANT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _PLA_ANTERIOR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _PLA_INICIAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _COD_ACT_AUX;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DES_UBI_PLACA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_TIPO_PLACA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _SER_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MARCA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MODELO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_TIP_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CLA_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_SUB_CLA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_ACT_BAS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_LOC_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_SEC_LOC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_UBI_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_EMPLEADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _IND_MOV_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CEN_CST;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _BIN_TIE_COM;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_COMPRA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_ULT_TOMA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ORD_COMPRA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_CAPITAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_CONSEC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_RETIRO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_DEC_ADU;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_DEC_ADU_SAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_DEC_ADU_SAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _IND_ACT_EXC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_ACT_EXC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_APROPI;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_COMPRA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_COMPRA_COL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_LIBROS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_LIBROS_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_DEPACU;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_DEPACU_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_CAPITAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_COMPRA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _OBS_ACTIVO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_FACTUR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_LICITA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private short? _NUM_AMPLIA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_DEPACU;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_GASDEP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_DEPACU_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_GASDEP_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MET_DEP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_POLIZA;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_POLIZA_SAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_ADU_DOL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_INI_DEP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_INI_DEP_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_ULT_DEP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_ULT_DEP_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_RESIDUAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_RESIDUAL_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_VID_UTL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_VID_UTL_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_CHEQUE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_TIP_CAM;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_PROVEE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_EST_ADU;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_TIP_OPE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _REF_NUM_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_ASI_CON;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _IND_DEPREC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FEC_EXP_GAR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_ORI_STS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_EST_ORI;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_ESTADO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private short? _CAMPO62;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MON_COM;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _IND_REG_SER;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _CAN_ACT_NUE;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private byte[] _TIMESTAMP;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_DEPREC_MEN;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_DEPREC_MEN_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_VID_UTL_ACUM;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_VID_UTL_ACUM_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_RES_VID_UTL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_RES_VID_UTL_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_LIB_ACT;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal? _VAL_DEPREC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private DateTime? _FYH_FIN_DEPREC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private short? _NUM_MES_DEPREC;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_DEP_REVAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_GASDEP_REVAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal _VAL_REVALS;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal _VAL_DEPACU_REVAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private decimal _VAL_GASDEPACU_REVAL;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_patrimonio;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_provincia;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_canton;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_distrito;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int? _anno_presupuesto;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_acta;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_folio;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_prog_presupuestario;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _cod_subprog_presupuestario;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _ind_exportado;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool? _ind_act_grupo;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_CTA_COSTO;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _COD_MON_COM_COR;
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _NUM_BLOQUE;
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string PLA_ACTIVO
        {
            get
            {
                return this._PLA_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("PLA_ACTIVO");
                this._PLA_ACTIVO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("PLA_ACTIVO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_ACTIVO
        {
            get
            {
                return this._DES_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("DES_ACTIVO");
                this._DES_ACTIVO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_ACTIVO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_ACTIVO_ANT
        {
            get
            {
                return this._DES_ACTIVO_ANT;
            }
            set
            {
                this.ReportPropertyChanging("DES_ACTIVO_ANT");
                this._DES_ACTIVO_ANT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_ACTIVO_ANT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string PLA_ANTERIOR
        {
            get
            {
                return this._PLA_ANTERIOR;
            }
            set
            {
                this.ReportPropertyChanging("PLA_ANTERIOR");
                this._PLA_ANTERIOR = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("PLA_ANTERIOR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string PLA_INICIAL
        {
            get
            {
                return this._PLA_INICIAL;
            }
            set
            {
                this.ReportPropertyChanging("PLA_INICIAL");
                this._PLA_INICIAL = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("PLA_INICIAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? COD_ACT_AUX
        {
            get
            {
                return this._COD_ACT_AUX;
            }
            set
            {
                this.ReportPropertyChanging("COD_ACT_AUX");
                this._COD_ACT_AUX = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("COD_ACT_AUX");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string DES_UBI_PLACA
        {
            get
            {
                return this._DES_UBI_PLACA;
            }
            set
            {
                this.ReportPropertyChanging("DES_UBI_PLACA");
                this._DES_UBI_PLACA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("DES_UBI_PLACA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_TIPO_PLACA
        {
            get
            {
                return this._COD_TIPO_PLACA;
            }
            set
            {
                this.ReportPropertyChanging("COD_TIPO_PLACA");
                this._COD_TIPO_PLACA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_TIPO_PLACA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string SER_ACTIVO
        {
            get
            {
                return this._SER_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("SER_ACTIVO");
                this._SER_ACTIVO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("SER_ACTIVO");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_TIP_ACT
        {
            get
            {
                return this._COD_TIP_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_TIP_ACT");
                this._COD_TIP_ACT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_TIP_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CLA_ACT
        {
            get
            {
                return this._COD_CLA_ACT;
            }
            set
            {
                this.ReportPropertyChanging("COD_CLA_ACT");
                this._COD_CLA_ACT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CLA_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_SUB_CLA
        {
            get
            {
                return this._COD_SUB_CLA;
            }
            set
            {
                this.ReportPropertyChanging("COD_SUB_CLA");
                this._COD_SUB_CLA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_SUB_CLA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_ACT_BAS
        {
            get
            {
                return this._COD_ACT_BAS;
            }
            set
            {
                this.ReportPropertyChanging("COD_ACT_BAS");
                this._COD_ACT_BAS = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_ACT_BAS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? IND_MOV_ACT
        {
            get
            {
                return this._IND_MOV_ACT;
            }
            set
            {
                this.ReportPropertyChanging("IND_MOV_ACT");
                this._IND_MOV_ACT = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IND_MOV_ACT");
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
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string BIN_TIE_COM
        {
            get
            {
                return this._BIN_TIE_COM;
            }
            set
            {
                this.ReportPropertyChanging("BIN_TIE_COM");
                this._BIN_TIE_COM = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("BIN_TIE_COM");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_COMPRA
        {
            get
            {
                return this._FEC_COMPRA;
            }
            set
            {
                this.ReportPropertyChanging("FEC_COMPRA");
                this._FEC_COMPRA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_COMPRA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_ULT_TOMA
        {
            get
            {
                return this._FYH_ULT_TOMA;
            }
            set
            {
                this.ReportPropertyChanging("FYH_ULT_TOMA");
                this._FYH_ULT_TOMA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_ULT_TOMA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string ORD_COMPRA
        {
            get
            {
                return this._ORD_COMPRA;
            }
            set
            {
                this.ReportPropertyChanging("ORD_COMPRA");
                this._ORD_COMPRA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ORD_COMPRA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_CAPITAL
        {
            get
            {
                return this._NUM_CAPITAL;
            }
            set
            {
                this.ReportPropertyChanging("NUM_CAPITAL");
                this._NUM_CAPITAL = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_CAPITAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_CONSEC
        {
            get
            {
                return this._NUM_CONSEC;
            }
            set
            {
                this.ReportPropertyChanging("NUM_CONSEC");
                this._NUM_CONSEC = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_CONSEC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_RETIRO
        {
            get
            {
                return this._FYH_RETIRO;
            }
            set
            {
                this.ReportPropertyChanging("FYH_RETIRO");
                this._FYH_RETIRO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_RETIRO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_DEC_ADU
        {
            get
            {
                return this._NUM_DEC_ADU;
            }
            set
            {
                this.ReportPropertyChanging("NUM_DEC_ADU");
                this._NUM_DEC_ADU = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_DEC_ADU");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_DEC_ADU_SAL
        {
            get
            {
                return this._NUM_DEC_ADU_SAL;
            }
            set
            {
                this.ReportPropertyChanging("NUM_DEC_ADU_SAL");
                this._NUM_DEC_ADU_SAL = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_DEC_ADU_SAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_DEC_ADU_SAL
        {
            get
            {
                return this._FYH_DEC_ADU_SAL;
            }
            set
            {
                this.ReportPropertyChanging("FYH_DEC_ADU_SAL");
                this._FYH_DEC_ADU_SAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_DEC_ADU_SAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? IND_ACT_EXC
        {
            get
            {
                return this._IND_ACT_EXC;
            }
            set
            {
                this.ReportPropertyChanging("IND_ACT_EXC");
                this._IND_ACT_EXC = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IND_ACT_EXC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_ACT_EXC
        {
            get
            {
                return this._FYH_ACT_EXC;
            }
            set
            {
                this.ReportPropertyChanging("FYH_ACT_EXC");
                this._FYH_ACT_EXC = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_ACT_EXC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_APROPI
        {
            get
            {
                return this._COD_APROPI;
            }
            set
            {
                this.ReportPropertyChanging("COD_APROPI");
                this._COD_APROPI = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_APROPI");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_COMPRA
        {
            get
            {
                return this._VAL_COMPRA;
            }
            set
            {
                this.ReportPropertyChanging("VAL_COMPRA");
                this._VAL_COMPRA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_COMPRA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_COMPRA_COL
        {
            get
            {
                return this._VAL_COMPRA_COL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_COMPRA_COL");
                this._VAL_COMPRA_COL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_COMPRA_COL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_LIBROS
        {
            get
            {
                return this._VAL_LIBROS;
            }
            set
            {
                this.ReportPropertyChanging("VAL_LIBROS");
                this._VAL_LIBROS = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_LIBROS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_LIBROS_COR
        {
            get
            {
                return this._VAL_LIBROS_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_LIBROS_COR");
                this._VAL_LIBROS_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_LIBROS_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_DEPACU
        {
            get
            {
                return this._VAL_DEPACU;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPACU");
                this._VAL_DEPACU = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPACU");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_DEPACU_COR
        {
            get
            {
                return this._VAL_DEPACU_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPACU_COR");
                this._VAL_DEPACU_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPACU_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_CAPITAL
        {
            get
            {
                return this._FYH_CAPITAL;
            }
            set
            {
                this.ReportPropertyChanging("FYH_CAPITAL");
                this._FYH_CAPITAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_CAPITAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_COMPRA
        {
            get
            {
                return this._FYH_COMPRA;
            }
            set
            {
                this.ReportPropertyChanging("FYH_COMPRA");
                this._FYH_COMPRA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_COMPRA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string OBS_ACTIVO
        {
            get
            {
                return this._OBS_ACTIVO;
            }
            set
            {
                this.ReportPropertyChanging("OBS_ACTIVO");
                this._OBS_ACTIVO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("OBS_ACTIVO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_FACTUR
        {
            get
            {
                return this._NUM_FACTUR;
            }
            set
            {
                this.ReportPropertyChanging("NUM_FACTUR");
                this._NUM_FACTUR = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_FACTUR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_LICITA
        {
            get
            {
                return this._NUM_LICITA;
            }
            set
            {
                this.ReportPropertyChanging("NUM_LICITA");
                this._NUM_LICITA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_LICITA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public short? NUM_AMPLIA
        {
            get
            {
                return this._NUM_AMPLIA;
            }
            set
            {
                this.ReportPropertyChanging("NUM_AMPLIA");
                this._NUM_AMPLIA = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("NUM_AMPLIA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CTA_DEPACU
        {
            get
            {
                return this._COD_CTA_DEPACU;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_DEPACU");
                this._COD_CTA_DEPACU = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CTA_DEPACU");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CTA_GASDEP
        {
            get
            {
                return this._COD_CTA_GASDEP;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_GASDEP");
                this._COD_CTA_GASDEP = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CTA_GASDEP");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CTA_DEPACU_COR
        {
            get
            {
                return this._COD_CTA_DEPACU_COR;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_DEPACU_COR");
                this._COD_CTA_DEPACU_COR = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CTA_DEPACU_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CTA_GASDEP_COR
        {
            get
            {
                return this._COD_CTA_GASDEP_COR;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_GASDEP_COR");
                this._COD_CTA_GASDEP_COR = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CTA_GASDEP_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_MET_DEP
        {
            get
            {
                return this._COD_MET_DEP;
            }
            set
            {
                this.ReportPropertyChanging("COD_MET_DEP");
                this._COD_MET_DEP = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_MET_DEP");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_POLIZA
        {
            get
            {
                return this._NUM_POLIZA;
            }
            set
            {
                this.ReportPropertyChanging("NUM_POLIZA");
                this._NUM_POLIZA = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_POLIZA");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_POLIZA_SAL
        {
            get
            {
                return this._NUM_POLIZA_SAL;
            }
            set
            {
                this.ReportPropertyChanging("NUM_POLIZA_SAL");
                this._NUM_POLIZA_SAL = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_POLIZA_SAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_ADU_DOL
        {
            get
            {
                return this._VAL_ADU_DOL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_ADU_DOL");
                this._VAL_ADU_DOL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_ADU_DOL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_INI_DEP
        {
            get
            {
                return this._FEC_INI_DEP;
            }
            set
            {
                this.ReportPropertyChanging("FEC_INI_DEP");
                this._FEC_INI_DEP = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_INI_DEP");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_INI_DEP_COR
        {
            get
            {
                return this._FEC_INI_DEP_COR;
            }
            set
            {
                this.ReportPropertyChanging("FEC_INI_DEP_COR");
                this._FEC_INI_DEP_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_INI_DEP_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_ULT_DEP
        {
            get
            {
                return this._FEC_ULT_DEP;
            }
            set
            {
                this.ReportPropertyChanging("FEC_ULT_DEP");
                this._FEC_ULT_DEP = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_ULT_DEP");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_ULT_DEP_COR
        {
            get
            {
                return this._FEC_ULT_DEP_COR;
            }
            set
            {
                this.ReportPropertyChanging("FEC_ULT_DEP_COR");
                this._FEC_ULT_DEP_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_ULT_DEP_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_RESIDUAL
        {
            get
            {
                return this._VAL_RESIDUAL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_RESIDUAL");
                this._VAL_RESIDUAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_RESIDUAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_RESIDUAL_COR
        {
            get
            {
                return this._VAL_RESIDUAL_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_RESIDUAL_COR");
                this._VAL_RESIDUAL_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_RESIDUAL_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_VID_UTL
        {
            get
            {
                return this._VAL_VID_UTL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_VID_UTL");
                this._VAL_VID_UTL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_VID_UTL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_VID_UTL_COR
        {
            get
            {
                return this._VAL_VID_UTL_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_VID_UTL_COR");
                this._VAL_VID_UTL_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_VID_UTL_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_CHEQUE
        {
            get
            {
                return this._NUM_CHEQUE;
            }
            set
            {
                this.ReportPropertyChanging("NUM_CHEQUE");
                this._NUM_CHEQUE = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_CHEQUE");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_TIP_CAM
        {
            get
            {
                return this._VAL_TIP_CAM;
            }
            set
            {
                this.ReportPropertyChanging("VAL_TIP_CAM");
                this._VAL_TIP_CAM = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_TIP_CAM");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_PROVEE
        {
            get
            {
                return this._COD_PROVEE;
            }
            set
            {
                this.ReportPropertyChanging("COD_PROVEE");
                this._COD_PROVEE = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_PROVEE");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_EST_ADU
        {
            get
            {
                return this._COD_EST_ADU;
            }
            set
            {
                this.ReportPropertyChanging("COD_EST_ADU");
                this._COD_EST_ADU = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_EST_ADU");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_TIP_OPE
        {
            get
            {
                return this._COD_TIP_OPE;
            }
            set
            {
                this.ReportPropertyChanging("COD_TIP_OPE");
                this._COD_TIP_OPE = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_TIP_OPE");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string REF_NUM_ACT
        {
            get
            {
                return this._REF_NUM_ACT;
            }
            set
            {
                this.ReportPropertyChanging("REF_NUM_ACT");
                this._REF_NUM_ACT = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("REF_NUM_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_ASI_CON
        {
            get
            {
                return this._NUM_ASI_CON;
            }
            set
            {
                this.ReportPropertyChanging("NUM_ASI_CON");
                this._NUM_ASI_CON = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_ASI_CON");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string IND_DEPREC
        {
            get
            {
                return this._IND_DEPREC;
            }
            set
            {
                this.ReportPropertyChanging("IND_DEPREC");
                this._IND_DEPREC = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("IND_DEPREC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FEC_EXP_GAR
        {
            get
            {
                return this._FEC_EXP_GAR;
            }
            set
            {
                this.ReportPropertyChanging("FEC_EXP_GAR");
                this._FEC_EXP_GAR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FEC_EXP_GAR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string COD_ORI_STS
        {
            get
            {
                return this._COD_ORI_STS;
            }
            set
            {
                this.ReportPropertyChanging("COD_ORI_STS");
                this._COD_ORI_STS = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_ORI_STS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_EST_ORI
        {
            get
            {
                return this._COD_EST_ORI;
            }
            set
            {
                this.ReportPropertyChanging("COD_EST_ORI");
                this._COD_EST_ORI = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_EST_ORI");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_ESTADO
        {
            get
            {
                return this._FYH_ESTADO;
            }
            set
            {
                this.ReportPropertyChanging("FYH_ESTADO");
                this._FYH_ESTADO = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_ESTADO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public short? CAMPO62
        {
            get
            {
                return this._CAMPO62;
            }
            set
            {
                this.ReportPropertyChanging("CAMPO62");
                this._CAMPO62 = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CAMPO62");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_MON_COM
        {
            get
            {
                return this._COD_MON_COM;
            }
            set
            {
                this.ReportPropertyChanging("COD_MON_COM");
                this._COD_MON_COM = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_MON_COM");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? IND_REG_SER
        {
            get
            {
                return this._IND_REG_SER;
            }
            set
            {
                this.ReportPropertyChanging("IND_REG_SER");
                this._IND_REG_SER = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IND_REG_SER");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? CAN_ACT_NUE
        {
            get
            {
                return this._CAN_ACT_NUE;
            }
            set
            {
                this.ReportPropertyChanging("CAN_ACT_NUE");
                this._CAN_ACT_NUE = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CAN_ACT_NUE");
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
        public decimal? VAL_DEPREC_MEN
        {
            get
            {
                return this._VAL_DEPREC_MEN;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPREC_MEN");
                this._VAL_DEPREC_MEN = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPREC_MEN");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_DEPREC_MEN_COR
        {
            get
            {
                return this._VAL_DEPREC_MEN_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPREC_MEN_COR");
                this._VAL_DEPREC_MEN_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPREC_MEN_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_VID_UTL_ACUM
        {
            get
            {
                return this._VAL_VID_UTL_ACUM;
            }
            set
            {
                this.ReportPropertyChanging("VAL_VID_UTL_ACUM");
                this._VAL_VID_UTL_ACUM = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_VID_UTL_ACUM");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_VID_UTL_ACUM_COR
        {
            get
            {
                return this._VAL_VID_UTL_ACUM_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_VID_UTL_ACUM_COR");
                this._VAL_VID_UTL_ACUM_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_VID_UTL_ACUM_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_RES_VID_UTL
        {
            get
            {
                return this._VAL_RES_VID_UTL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_RES_VID_UTL");
                this._VAL_RES_VID_UTL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_RES_VID_UTL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_RES_VID_UTL_COR
        {
            get
            {
                return this._VAL_RES_VID_UTL_COR;
            }
            set
            {
                this.ReportPropertyChanging("VAL_RES_VID_UTL_COR");
                this._VAL_RES_VID_UTL_COR = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_RES_VID_UTL_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_LIB_ACT
        {
            get
            {
                return this._VAL_LIB_ACT;
            }
            set
            {
                this.ReportPropertyChanging("VAL_LIB_ACT");
                this._VAL_LIB_ACT = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_LIB_ACT");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public decimal? VAL_DEPREC
        {
            get
            {
                return this._VAL_DEPREC;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPREC");
                this._VAL_DEPREC = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPREC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public DateTime? FYH_FIN_DEPREC
        {
            get
            {
                return this._FYH_FIN_DEPREC;
            }
            set
            {
                this.ReportPropertyChanging("FYH_FIN_DEPREC");
                this._FYH_FIN_DEPREC = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("FYH_FIN_DEPREC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public short? NUM_MES_DEPREC
        {
            get
            {
                return this._NUM_MES_DEPREC;
            }
            set
            {
                this.ReportPropertyChanging("NUM_MES_DEPREC");
                this._NUM_MES_DEPREC = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("NUM_MES_DEPREC");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string COD_CTA_DEP_REVAL
        {
            get
            {
                return this._COD_CTA_DEP_REVAL;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_DEP_REVAL");
                this._COD_CTA_DEP_REVAL = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_CTA_DEP_REVAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public string COD_CTA_GASDEP_REVAL
        {
            get
            {
                return this._COD_CTA_GASDEP_REVAL;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_GASDEP_REVAL");
                this._COD_CTA_GASDEP_REVAL = StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("COD_CTA_GASDEP_REVAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public decimal VAL_REVALS
        {
            get
            {
                return this._VAL_REVALS;
            }
            set
            {
                this.ReportPropertyChanging("VAL_REVALS");
                this._VAL_REVALS = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_REVALS");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public decimal VAL_DEPACU_REVAL
        {
            get
            {
                return this._VAL_DEPACU_REVAL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_DEPACU_REVAL");
                this._VAL_DEPACU_REVAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_DEPACU_REVAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public decimal VAL_GASDEPACU_REVAL
        {
            get
            {
                return this._VAL_GASDEPACU_REVAL;
            }
            set
            {
                this.ReportPropertyChanging("VAL_GASDEPACU_REVAL");
                this._VAL_GASDEPACU_REVAL = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("VAL_GASDEPACU_REVAL");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_patrimonio
        {
            get
            {
                return this._cod_patrimonio;
            }
            set
            {
                this.ReportPropertyChanging("cod_patrimonio");
                this._cod_patrimonio = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_patrimonio");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_provincia
        {
            get
            {
                return this._cod_provincia;
            }
            set
            {
                this.ReportPropertyChanging("cod_provincia");
                this._cod_provincia = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_provincia");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_canton
        {
            get
            {
                return this._cod_canton;
            }
            set
            {
                this.ReportPropertyChanging("cod_canton");
                this._cod_canton = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_canton");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_distrito
        {
            get
            {
                return this._cod_distrito;
            }
            set
            {
                this.ReportPropertyChanging("cod_distrito");
                this._cod_distrito = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_distrito");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public int? anno_presupuesto
        {
            get
            {
                return this._anno_presupuesto;
            }
            set
            {
                this.ReportPropertyChanging("anno_presupuesto");
                this._anno_presupuesto = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("anno_presupuesto");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_acta
        {
            get
            {
                return this._cod_acta;
            }
            set
            {
                this.ReportPropertyChanging("cod_acta");
                this._cod_acta = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_acta");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_folio
        {
            get
            {
                return this._cod_folio;
            }
            set
            {
                this.ReportPropertyChanging("cod_folio");
                this._cod_folio = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_folio");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_prog_presupuestario
        {
            get
            {
                return this._cod_prog_presupuestario;
            }
            set
            {
                this.ReportPropertyChanging("cod_prog_presupuestario");
                this._cod_prog_presupuestario = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_prog_presupuestario");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string cod_subprog_presupuestario
        {
            get
            {
                return this._cod_subprog_presupuestario;
            }
            set
            {
                this.ReportPropertyChanging("cod_subprog_presupuestario");
                this._cod_subprog_presupuestario = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("cod_subprog_presupuestario");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty(IsNullable = false), DataMember]
        public bool ind_exportado
        {
            get
            {
                return this._ind_exportado;
            }
            set
            {
                this.ReportPropertyChanging("ind_exportado");
                this._ind_exportado = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ind_exportado");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public bool? ind_act_grupo
        {
            get
            {
                return this._ind_act_grupo;
            }
            set
            {
                this.ReportPropertyChanging("ind_act_grupo");
                this._ind_act_grupo = StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ind_act_grupo");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_CTA_COSTO
        {
            get
            {
                return this._COD_CTA_COSTO;
            }
            set
            {
                this.ReportPropertyChanging("COD_CTA_COSTO");
                this._COD_CTA_COSTO = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_CTA_COSTO");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string COD_MON_COM_COR
        {
            get
            {
                return this._COD_MON_COM_COR;
            }
            set
            {
                this.ReportPropertyChanging("COD_MON_COM_COR");
                this._COD_MON_COM_COR = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("COD_MON_COM_COR");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0"), EdmScalarProperty, DataMember]
        public string NUM_BLOQUE
        {
            get
            {
                return this._NUM_BLOQUE;
            }
            set
            {
                this.ReportPropertyChanging("NUM_BLOQUE");
                this._NUM_BLOQUE = StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("NUM_BLOQUE");
            }
        }
        [GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static AFM_MAEST_ACTIV CreateAFM_MAEST_ACTIV(string cOD_COMPANIA, string nUM_ACTIVO, string cOD_LOC_ACT, string cOD_SEC_LOC, string cOD_UBI_ACT, string cOD_ORI_STS, string cOD_CTA_DEP_REVAL, string cOD_CTA_GASDEP_REVAL, decimal vAL_REVALS, decimal vAL_DEPACU_REVAL, decimal vAL_GASDEPACU_REVAL, bool ind_exportado)
        {
            return new AFM_MAEST_ACTIV
            {
                COD_COMPANIA = cOD_COMPANIA,
                NUM_ACTIVO = nUM_ACTIVO,
                COD_LOC_ACT = cOD_LOC_ACT,
                COD_SEC_LOC = cOD_SEC_LOC,
                COD_UBI_ACT = cOD_UBI_ACT,
                COD_ORI_STS = cOD_ORI_STS,
                COD_CTA_DEP_REVAL = cOD_CTA_DEP_REVAL,
                COD_CTA_GASDEP_REVAL = cOD_CTA_GASDEP_REVAL,
                VAL_REVALS = vAL_REVALS,
                VAL_DEPACU_REVAL = vAL_DEPACU_REVAL,
                VAL_GASDEPACU_REVAL = vAL_GASDEPACU_REVAL,
                ind_exportado = ind_exportado
            };
        }
    }
     */
    [EdmEntityTypeAttribute(NamespaceName = "BostonModel", Name = "AFM_MAEST_ACTIV")]
    [Serializable()]
    [DataContractAttribute(IsReference = true)]
    public partial class AFM_MAEST_ACTIV : EntityObject
    {
        #region Factory Method

        /// <summary>
        /// Create a new AFM_MAEST_ACTIV object.
        /// </summary>
        /// <param name="cOD_COMPANIA">Initial value of the COD_COMPANIA property.</param>
        /// <param name="nUM_ACTIVO">Initial value of the NUM_ACTIVO property.</param>
        /// <param name="cOD_LOC_ACT">Initial value of the COD_LOC_ACT property.</param>
        /// <param name="cOD_SEC_LOC">Initial value of the COD_SEC_LOC property.</param>
        /// <param name="cOD_UBI_ACT">Initial value of the COD_UBI_ACT property.</param>
        /// <param name="cOD_ORI_STS">Initial value of the COD_ORI_STS property.</param>
        /// <param name="cOD_CTA_DEP_REVAL">Initial value of the COD_CTA_DEP_REVAL property.</param>
        /// <param name="cOD_CTA_GASDEP_REVAL">Initial value of the COD_CTA_GASDEP_REVAL property.</param>
        /// <param name="vAL_REVALS">Initial value of the VAL_REVALS property.</param>
        /// <param name="vAL_DEPACU_REVAL">Initial value of the VAL_DEPACU_REVAL property.</param>
        /// <param name="vAL_GASDEPACU_REVAL">Initial value of the VAL_GASDEPACU_REVAL property.</param>
        /// <param name="ind_exportado">Initial value of the ind_exportado property.</param>
        public static AFM_MAEST_ACTIV CreateAFM_MAEST_ACTIV(global::System.String cOD_COMPANIA, global::System.String nUM_ACTIVO, global::System.String cOD_LOC_ACT, global::System.String cOD_SEC_LOC, global::System.String cOD_UBI_ACT, global::System.String cOD_ORI_STS, global::System.String cOD_CTA_DEP_REVAL, global::System.String cOD_CTA_GASDEP_REVAL, global::System.Decimal vAL_REVALS, global::System.Decimal vAL_DEPACU_REVAL, global::System.Decimal vAL_GASDEPACU_REVAL, global::System.Boolean ind_exportado)
        {
            AFM_MAEST_ACTIV aFM_MAEST_ACTIV = new AFM_MAEST_ACTIV();
            aFM_MAEST_ACTIV.COD_COMPANIA = cOD_COMPANIA;
            aFM_MAEST_ACTIV.NUM_ACTIVO = nUM_ACTIVO;
            aFM_MAEST_ACTIV.COD_LOC_ACT = cOD_LOC_ACT;
            aFM_MAEST_ACTIV.COD_SEC_LOC = cOD_SEC_LOC;
            aFM_MAEST_ACTIV.COD_UBI_ACT = cOD_UBI_ACT;
            aFM_MAEST_ACTIV.COD_ORI_STS = cOD_ORI_STS;
            aFM_MAEST_ACTIV.COD_CTA_DEP_REVAL = cOD_CTA_DEP_REVAL;
            aFM_MAEST_ACTIV.COD_CTA_GASDEP_REVAL = cOD_CTA_GASDEP_REVAL;
            aFM_MAEST_ACTIV.VAL_REVALS = vAL_REVALS;
            aFM_MAEST_ACTIV.VAL_DEPACU_REVAL = vAL_DEPACU_REVAL;
            aFM_MAEST_ACTIV.VAL_GASDEPACU_REVAL = vAL_GASDEPACU_REVAL;
            aFM_MAEST_ACTIV.ind_exportado = ind_exportado;
            return aFM_MAEST_ACTIV;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String PLA_ACTIVO
        {
            get
            {
                return _PLA_ACTIVO;
            }
            set
            {
                OnPLA_ACTIVOChanging(value);
                ReportPropertyChanging("PLA_ACTIVO");
                _PLA_ACTIVO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PLA_ACTIVO");
                OnPLA_ACTIVOChanged();
            }
        }
        private global::System.String _PLA_ACTIVO;
        partial void OnPLA_ACTIVOChanging(global::System.String value);
        partial void OnPLA_ACTIVOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DES_ACTIVO
        {
            get
            {
                return _DES_ACTIVO;
            }
            set
            {
                OnDES_ACTIVOChanging(value);
                ReportPropertyChanging("DES_ACTIVO");
                _DES_ACTIVO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_ACTIVO");
                OnDES_ACTIVOChanged();
            }
        }
        private global::System.String _DES_ACTIVO;
        partial void OnDES_ACTIVOChanging(global::System.String value);
        partial void OnDES_ACTIVOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DES_ACTIVO_ANT
        {
            get
            {
                return _DES_ACTIVO_ANT;
            }
            set
            {
                OnDES_ACTIVO_ANTChanging(value);
                ReportPropertyChanging("DES_ACTIVO_ANT");
                _DES_ACTIVO_ANT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_ACTIVO_ANT");
                OnDES_ACTIVO_ANTChanged();
            }
        }
        private global::System.String _DES_ACTIVO_ANT;
        partial void OnDES_ACTIVO_ANTChanging(global::System.String value);
        partial void OnDES_ACTIVO_ANTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String PLA_ANTERIOR
        {
            get
            {
                return _PLA_ANTERIOR;
            }
            set
            {
                OnPLA_ANTERIORChanging(value);
                ReportPropertyChanging("PLA_ANTERIOR");
                _PLA_ANTERIOR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PLA_ANTERIOR");
                OnPLA_ANTERIORChanged();
            }
        }
        private global::System.String _PLA_ANTERIOR;
        partial void OnPLA_ANTERIORChanging(global::System.String value);
        partial void OnPLA_ANTERIORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String PLA_INICIAL
        {
            get
            {
                return _PLA_INICIAL;
            }
            set
            {
                OnPLA_INICIALChanging(value);
                ReportPropertyChanging("PLA_INICIAL");
                _PLA_INICIAL = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PLA_INICIAL");
                OnPLA_INICIALChanged();
            }
        }
        private global::System.String _PLA_INICIAL;
        partial void OnPLA_INICIALChanging(global::System.String value);
        partial void OnPLA_INICIALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> COD_ACT_AUX
        {
            get
            {
                return _COD_ACT_AUX;
            }
            set
            {
                OnCOD_ACT_AUXChanging(value);
                ReportPropertyChanging("COD_ACT_AUX");
                _COD_ACT_AUX = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("COD_ACT_AUX");
                OnCOD_ACT_AUXChanged();
            }
        }
        private Nullable<global::System.Decimal> _COD_ACT_AUX;
        partial void OnCOD_ACT_AUXChanging(Nullable<global::System.Decimal> value);
        partial void OnCOD_ACT_AUXChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String DES_UBI_PLACA
        {
            get
            {
                return _DES_UBI_PLACA;
            }
            set
            {
                OnDES_UBI_PLACAChanging(value);
                ReportPropertyChanging("DES_UBI_PLACA");
                _DES_UBI_PLACA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("DES_UBI_PLACA");
                OnDES_UBI_PLACAChanged();
            }
        }
        private global::System.String _DES_UBI_PLACA;
        partial void OnDES_UBI_PLACAChanging(global::System.String value);
        partial void OnDES_UBI_PLACAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_TIPO_PLACA
        {
            get
            {
                return _COD_TIPO_PLACA;
            }
            set
            {
                OnCOD_TIPO_PLACAChanging(value);
                ReportPropertyChanging("COD_TIPO_PLACA");
                _COD_TIPO_PLACA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_TIPO_PLACA");
                OnCOD_TIPO_PLACAChanged();
            }
        }
        private global::System.String _COD_TIPO_PLACA;
        partial void OnCOD_TIPO_PLACAChanging(global::System.String value);
        partial void OnCOD_TIPO_PLACAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String SER_ACTIVO
        {
            get
            {
                return _SER_ACTIVO;
            }
            set
            {
                OnSER_ACTIVOChanging(value);
                ReportPropertyChanging("SER_ACTIVO");
                _SER_ACTIVO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SER_ACTIVO");
                OnSER_ACTIVOChanged();
            }
        }
        private global::System.String _SER_ACTIVO;
        partial void OnSER_ACTIVOChanging(global::System.String value);
        partial void OnSER_ACTIVOChanged();

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
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_TIP_ACT
        {
            get
            {
                return _COD_TIP_ACT;
            }
            set
            {
                OnCOD_TIP_ACTChanging(value);
                ReportPropertyChanging("COD_TIP_ACT");
                _COD_TIP_ACT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_TIP_ACT");
                OnCOD_TIP_ACTChanged();
            }
        }
        private global::System.String _COD_TIP_ACT;
        partial void OnCOD_TIP_ACTChanging(global::System.String value);
        partial void OnCOD_TIP_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CLA_ACT
        {
            get
            {
                return _COD_CLA_ACT;
            }
            set
            {
                OnCOD_CLA_ACTChanging(value);
                ReportPropertyChanging("COD_CLA_ACT");
                _COD_CLA_ACT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CLA_ACT");
                OnCOD_CLA_ACTChanged();
            }
        }
        private global::System.String _COD_CLA_ACT;
        partial void OnCOD_CLA_ACTChanging(global::System.String value);
        partial void OnCOD_CLA_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_SUB_CLA
        {
            get
            {
                return _COD_SUB_CLA;
            }
            set
            {
                OnCOD_SUB_CLAChanging(value);
                ReportPropertyChanging("COD_SUB_CLA");
                _COD_SUB_CLA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_SUB_CLA");
                OnCOD_SUB_CLAChanged();
            }
        }
        private global::System.String _COD_SUB_CLA;
        partial void OnCOD_SUB_CLAChanging(global::System.String value);
        partial void OnCOD_SUB_CLAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_ACT_BAS
        {
            get
            {
                return _COD_ACT_BAS;
            }
            set
            {
                OnCOD_ACT_BASChanging(value);
                ReportPropertyChanging("COD_ACT_BAS");
                _COD_ACT_BAS = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_ACT_BAS");
                OnCOD_ACT_BASChanged();
            }
        }
        private global::System.String _COD_ACT_BAS;
        partial void OnCOD_ACT_BASChanging(global::System.String value);
        partial void OnCOD_ACT_BASChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
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
                _COD_LOC_ACT = StructuralObject.SetValidValue(value, false);
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
                _COD_SEC_LOC = StructuralObject.SetValidValue(value, false);
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
                _COD_UBI_ACT = StructuralObject.SetValidValue(value, false);
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

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IND_MOV_ACT
        {
            get
            {
                return _IND_MOV_ACT;
            }
            set
            {
                OnIND_MOV_ACTChanging(value);
                ReportPropertyChanging("IND_MOV_ACT");
                _IND_MOV_ACT = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IND_MOV_ACT");
                OnIND_MOV_ACTChanged();
            }
        }
        private Nullable<global::System.Boolean> _IND_MOV_ACT;
        partial void OnIND_MOV_ACTChanging(Nullable<global::System.Boolean> value);
        partial void OnIND_MOV_ACTChanged();

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
        public global::System.String BIN_TIE_COM
        {
            get
            {
                return _BIN_TIE_COM;
            }
            set
            {
                OnBIN_TIE_COMChanging(value);
                ReportPropertyChanging("BIN_TIE_COM");
                _BIN_TIE_COM = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BIN_TIE_COM");
                OnBIN_TIE_COMChanged();
            }
        }
        private global::System.String _BIN_TIE_COM;
        partial void OnBIN_TIE_COMChanging(global::System.String value);
        partial void OnBIN_TIE_COMChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_COMPRA
        {
            get
            {
                return _FEC_COMPRA;
            }
            set
            {
                OnFEC_COMPRAChanging(value);
                ReportPropertyChanging("FEC_COMPRA");
                _FEC_COMPRA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_COMPRA");
                OnFEC_COMPRAChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_COMPRA;
        partial void OnFEC_COMPRAChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_COMPRAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_ULT_TOMA
        {
            get
            {
                return _FYH_ULT_TOMA;
            }
            set
            {
                OnFYH_ULT_TOMAChanging(value);
                ReportPropertyChanging("FYH_ULT_TOMA");
                _FYH_ULT_TOMA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_ULT_TOMA");
                OnFYH_ULT_TOMAChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_ULT_TOMA;
        partial void OnFYH_ULT_TOMAChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_ULT_TOMAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String ORD_COMPRA
        {
            get
            {
                return _ORD_COMPRA;
            }
            set
            {
                OnORD_COMPRAChanging(value);
                ReportPropertyChanging("ORD_COMPRA");
                _ORD_COMPRA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ORD_COMPRA");
                OnORD_COMPRAChanged();
            }
        }
        private global::System.String _ORD_COMPRA;
        partial void OnORD_COMPRAChanging(global::System.String value);
        partial void OnORD_COMPRAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_CAPITAL
        {
            get
            {
                return _NUM_CAPITAL;
            }
            set
            {
                OnNUM_CAPITALChanging(value);
                ReportPropertyChanging("NUM_CAPITAL");
                _NUM_CAPITAL = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_CAPITAL");
                OnNUM_CAPITALChanged();
            }
        }
        private global::System.String _NUM_CAPITAL;
        partial void OnNUM_CAPITALChanging(global::System.String value);
        partial void OnNUM_CAPITALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_CONSEC
        {
            get
            {
                return _NUM_CONSEC;
            }
            set
            {
                OnNUM_CONSECChanging(value);
                ReportPropertyChanging("NUM_CONSEC");
                _NUM_CONSEC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_CONSEC");
                OnNUM_CONSECChanged();
            }
        }
        private global::System.String _NUM_CONSEC;
        partial void OnNUM_CONSECChanging(global::System.String value);
        partial void OnNUM_CONSECChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_RETIRO
        {
            get
            {
                return _FYH_RETIRO;
            }
            set
            {
                OnFYH_RETIROChanging(value);
                ReportPropertyChanging("FYH_RETIRO");
                _FYH_RETIRO = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_RETIRO");
                OnFYH_RETIROChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_RETIRO;
        partial void OnFYH_RETIROChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_RETIROChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_DEC_ADU
        {
            get
            {
                return _NUM_DEC_ADU;
            }
            set
            {
                OnNUM_DEC_ADUChanging(value);
                ReportPropertyChanging("NUM_DEC_ADU");
                _NUM_DEC_ADU = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_DEC_ADU");
                OnNUM_DEC_ADUChanged();
            }
        }
        private global::System.String _NUM_DEC_ADU;
        partial void OnNUM_DEC_ADUChanging(global::System.String value);
        partial void OnNUM_DEC_ADUChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_DEC_ADU_SAL
        {
            get
            {
                return _NUM_DEC_ADU_SAL;
            }
            set
            {
                OnNUM_DEC_ADU_SALChanging(value);
                ReportPropertyChanging("NUM_DEC_ADU_SAL");
                _NUM_DEC_ADU_SAL = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_DEC_ADU_SAL");
                OnNUM_DEC_ADU_SALChanged();
            }
        }
        private global::System.String _NUM_DEC_ADU_SAL;
        partial void OnNUM_DEC_ADU_SALChanging(global::System.String value);
        partial void OnNUM_DEC_ADU_SALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_DEC_ADU_SAL
        {
            get
            {
                return _FYH_DEC_ADU_SAL;
            }
            set
            {
                OnFYH_DEC_ADU_SALChanging(value);
                ReportPropertyChanging("FYH_DEC_ADU_SAL");
                _FYH_DEC_ADU_SAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_DEC_ADU_SAL");
                OnFYH_DEC_ADU_SALChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_DEC_ADU_SAL;
        partial void OnFYH_DEC_ADU_SALChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_DEC_ADU_SALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IND_ACT_EXC
        {
            get
            {
                return _IND_ACT_EXC;
            }
            set
            {
                OnIND_ACT_EXCChanging(value);
                ReportPropertyChanging("IND_ACT_EXC");
                _IND_ACT_EXC = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IND_ACT_EXC");
                OnIND_ACT_EXCChanged();
            }
        }
        private Nullable<global::System.Boolean> _IND_ACT_EXC;
        partial void OnIND_ACT_EXCChanging(Nullable<global::System.Boolean> value);
        partial void OnIND_ACT_EXCChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_ACT_EXC
        {
            get
            {
                return _FYH_ACT_EXC;
            }
            set
            {
                OnFYH_ACT_EXCChanging(value);
                ReportPropertyChanging("FYH_ACT_EXC");
                _FYH_ACT_EXC = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_ACT_EXC");
                OnFYH_ACT_EXCChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_ACT_EXC;
        partial void OnFYH_ACT_EXCChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_ACT_EXCChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_APROPI
        {
            get
            {
                return _COD_APROPI;
            }
            set
            {
                OnCOD_APROPIChanging(value);
                ReportPropertyChanging("COD_APROPI");
                _COD_APROPI = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_APROPI");
                OnCOD_APROPIChanged();
            }
        }
        private global::System.String _COD_APROPI;
        partial void OnCOD_APROPIChanging(global::System.String value);
        partial void OnCOD_APROPIChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_COMPRA
        {
            get
            {
                return _VAL_COMPRA;
            }
            set
            {
                OnVAL_COMPRAChanging(value);
                ReportPropertyChanging("VAL_COMPRA");
                _VAL_COMPRA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_COMPRA");
                OnVAL_COMPRAChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_COMPRA;
        partial void OnVAL_COMPRAChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_COMPRAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_COMPRA_COL
        {
            get
            {
                return _VAL_COMPRA_COL;
            }
            set
            {
                OnVAL_COMPRA_COLChanging(value);
                ReportPropertyChanging("VAL_COMPRA_COL");
                _VAL_COMPRA_COL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_COMPRA_COL");
                OnVAL_COMPRA_COLChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_COMPRA_COL;
        partial void OnVAL_COMPRA_COLChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_COMPRA_COLChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_LIBROS
        {
            get
            {
                return _VAL_LIBROS;
            }
            set
            {
                OnVAL_LIBROSChanging(value);
                ReportPropertyChanging("VAL_LIBROS");
                _VAL_LIBROS = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_LIBROS");
                OnVAL_LIBROSChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_LIBROS;
        partial void OnVAL_LIBROSChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_LIBROSChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_LIBROS_COR
        {
            get
            {
                return _VAL_LIBROS_COR;
            }
            set
            {
                OnVAL_LIBROS_CORChanging(value);
                ReportPropertyChanging("VAL_LIBROS_COR");
                _VAL_LIBROS_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_LIBROS_COR");
                OnVAL_LIBROS_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_LIBROS_COR;
        partial void OnVAL_LIBROS_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_LIBROS_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_DEPACU
        {
            get
            {
                return _VAL_DEPACU;
            }
            set
            {
                OnVAL_DEPACUChanging(value);
                ReportPropertyChanging("VAL_DEPACU");
                _VAL_DEPACU = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPACU");
                OnVAL_DEPACUChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_DEPACU;
        partial void OnVAL_DEPACUChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_DEPACUChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_DEPACU_COR
        {
            get
            {
                return _VAL_DEPACU_COR;
            }
            set
            {
                OnVAL_DEPACU_CORChanging(value);
                ReportPropertyChanging("VAL_DEPACU_COR");
                _VAL_DEPACU_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPACU_COR");
                OnVAL_DEPACU_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_DEPACU_COR;
        partial void OnVAL_DEPACU_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_DEPACU_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_CAPITAL
        {
            get
            {
                return _FYH_CAPITAL;
            }
            set
            {
                OnFYH_CAPITALChanging(value);
                ReportPropertyChanging("FYH_CAPITAL");
                _FYH_CAPITAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_CAPITAL");
                OnFYH_CAPITALChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_CAPITAL;
        partial void OnFYH_CAPITALChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_CAPITALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_COMPRA
        {
            get
            {
                return _FYH_COMPRA;
            }
            set
            {
                OnFYH_COMPRAChanging(value);
                ReportPropertyChanging("FYH_COMPRA");
                _FYH_COMPRA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_COMPRA");
                OnFYH_COMPRAChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_COMPRA;
        partial void OnFYH_COMPRAChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_COMPRAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String OBS_ACTIVO
        {
            get
            {
                return _OBS_ACTIVO;
            }
            set
            {
                OnOBS_ACTIVOChanging(value);
                ReportPropertyChanging("OBS_ACTIVO");
                _OBS_ACTIVO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("OBS_ACTIVO");
                OnOBS_ACTIVOChanged();
            }
        }
        private global::System.String _OBS_ACTIVO;
        partial void OnOBS_ACTIVOChanging(global::System.String value);
        partial void OnOBS_ACTIVOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_FACTUR
        {
            get
            {
                return _NUM_FACTUR;
            }
            set
            {
                OnNUM_FACTURChanging(value);
                ReportPropertyChanging("NUM_FACTUR");
                _NUM_FACTUR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_FACTUR");
                OnNUM_FACTURChanged();
            }
        }
        private global::System.String _NUM_FACTUR;
        partial void OnNUM_FACTURChanging(global::System.String value);
        partial void OnNUM_FACTURChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_LICITA
        {
            get
            {
                return _NUM_LICITA;
            }
            set
            {
                OnNUM_LICITAChanging(value);
                ReportPropertyChanging("NUM_LICITA");
                _NUM_LICITA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_LICITA");
                OnNUM_LICITAChanged();
            }
        }
        private global::System.String _NUM_LICITA;
        partial void OnNUM_LICITAChanging(global::System.String value);
        partial void OnNUM_LICITAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> NUM_AMPLIA
        {
            get
            {
                return _NUM_AMPLIA;
            }
            set
            {
                OnNUM_AMPLIAChanging(value);
                ReportPropertyChanging("NUM_AMPLIA");
                _NUM_AMPLIA = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NUM_AMPLIA");
                OnNUM_AMPLIAChanged();
            }
        }
        private Nullable<global::System.Int16> _NUM_AMPLIA;
        partial void OnNUM_AMPLIAChanging(Nullable<global::System.Int16> value);
        partial void OnNUM_AMPLIAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_DEPACU
        {
            get
            {
                return _COD_CTA_DEPACU;
            }
            set
            {
                OnCOD_CTA_DEPACUChanging(value);
                ReportPropertyChanging("COD_CTA_DEPACU");
                _COD_CTA_DEPACU = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CTA_DEPACU");
                OnCOD_CTA_DEPACUChanged();
            }
        }
        private global::System.String _COD_CTA_DEPACU;
        partial void OnCOD_CTA_DEPACUChanging(global::System.String value);
        partial void OnCOD_CTA_DEPACUChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_GASDEP
        {
            get
            {
                return _COD_CTA_GASDEP;
            }
            set
            {
                OnCOD_CTA_GASDEPChanging(value);
                ReportPropertyChanging("COD_CTA_GASDEP");
                _COD_CTA_GASDEP = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CTA_GASDEP");
                OnCOD_CTA_GASDEPChanged();
            }
        }
        private global::System.String _COD_CTA_GASDEP;
        partial void OnCOD_CTA_GASDEPChanging(global::System.String value);
        partial void OnCOD_CTA_GASDEPChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_DEPACU_COR
        {
            get
            {
                return _COD_CTA_DEPACU_COR;
            }
            set
            {
                OnCOD_CTA_DEPACU_CORChanging(value);
                ReportPropertyChanging("COD_CTA_DEPACU_COR");
                _COD_CTA_DEPACU_COR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CTA_DEPACU_COR");
                OnCOD_CTA_DEPACU_CORChanged();
            }
        }
        private global::System.String _COD_CTA_DEPACU_COR;
        partial void OnCOD_CTA_DEPACU_CORChanging(global::System.String value);
        partial void OnCOD_CTA_DEPACU_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_GASDEP_COR
        {
            get
            {
                return _COD_CTA_GASDEP_COR;
            }
            set
            {
                OnCOD_CTA_GASDEP_CORChanging(value);
                ReportPropertyChanging("COD_CTA_GASDEP_COR");
                _COD_CTA_GASDEP_COR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CTA_GASDEP_COR");
                OnCOD_CTA_GASDEP_CORChanged();
            }
        }
        private global::System.String _COD_CTA_GASDEP_COR;
        partial void OnCOD_CTA_GASDEP_CORChanging(global::System.String value);
        partial void OnCOD_CTA_GASDEP_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_MET_DEP
        {
            get
            {
                return _COD_MET_DEP;
            }
            set
            {
                OnCOD_MET_DEPChanging(value);
                ReportPropertyChanging("COD_MET_DEP");
                _COD_MET_DEP = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_MET_DEP");
                OnCOD_MET_DEPChanged();
            }
        }
        private global::System.String _COD_MET_DEP;
        partial void OnCOD_MET_DEPChanging(global::System.String value);
        partial void OnCOD_MET_DEPChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_POLIZA
        {
            get
            {
                return _NUM_POLIZA;
            }
            set
            {
                OnNUM_POLIZAChanging(value);
                ReportPropertyChanging("NUM_POLIZA");
                _NUM_POLIZA = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_POLIZA");
                OnNUM_POLIZAChanged();
            }
        }
        private global::System.String _NUM_POLIZA;
        partial void OnNUM_POLIZAChanging(global::System.String value);
        partial void OnNUM_POLIZAChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_POLIZA_SAL
        {
            get
            {
                return _NUM_POLIZA_SAL;
            }
            set
            {
                OnNUM_POLIZA_SALChanging(value);
                ReportPropertyChanging("NUM_POLIZA_SAL");
                _NUM_POLIZA_SAL = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_POLIZA_SAL");
                OnNUM_POLIZA_SALChanged();
            }
        }
        private global::System.String _NUM_POLIZA_SAL;
        partial void OnNUM_POLIZA_SALChanging(global::System.String value);
        partial void OnNUM_POLIZA_SALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_ADU_DOL
        {
            get
            {
                return _VAL_ADU_DOL;
            }
            set
            {
                OnVAL_ADU_DOLChanging(value);
                ReportPropertyChanging("VAL_ADU_DOL");
                _VAL_ADU_DOL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_ADU_DOL");
                OnVAL_ADU_DOLChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_ADU_DOL;
        partial void OnVAL_ADU_DOLChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_ADU_DOLChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_INI_DEP
        {
            get
            {
                return _FEC_INI_DEP;
            }
            set
            {
                OnFEC_INI_DEPChanging(value);
                ReportPropertyChanging("FEC_INI_DEP");
                _FEC_INI_DEP = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_INI_DEP");
                OnFEC_INI_DEPChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_INI_DEP;
        partial void OnFEC_INI_DEPChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_INI_DEPChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_INI_DEP_COR
        {
            get
            {
                return _FEC_INI_DEP_COR;
            }
            set
            {
                OnFEC_INI_DEP_CORChanging(value);
                ReportPropertyChanging("FEC_INI_DEP_COR");
                _FEC_INI_DEP_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_INI_DEP_COR");
                OnFEC_INI_DEP_CORChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_INI_DEP_COR;
        partial void OnFEC_INI_DEP_CORChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_INI_DEP_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_ULT_DEP
        {
            get
            {
                return _FEC_ULT_DEP;
            }
            set
            {
                OnFEC_ULT_DEPChanging(value);
                ReportPropertyChanging("FEC_ULT_DEP");
                _FEC_ULT_DEP = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_ULT_DEP");
                OnFEC_ULT_DEPChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_ULT_DEP;
        partial void OnFEC_ULT_DEPChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_ULT_DEPChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_ULT_DEP_COR
        {
            get
            {
                return _FEC_ULT_DEP_COR;
            }
            set
            {
                OnFEC_ULT_DEP_CORChanging(value);
                ReportPropertyChanging("FEC_ULT_DEP_COR");
                _FEC_ULT_DEP_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_ULT_DEP_COR");
                OnFEC_ULT_DEP_CORChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_ULT_DEP_COR;
        partial void OnFEC_ULT_DEP_CORChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_ULT_DEP_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_RESIDUAL
        {
            get
            {
                return _VAL_RESIDUAL;
            }
            set
            {
                OnVAL_RESIDUALChanging(value);
                ReportPropertyChanging("VAL_RESIDUAL");
                _VAL_RESIDUAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_RESIDUAL");
                OnVAL_RESIDUALChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_RESIDUAL;
        partial void OnVAL_RESIDUALChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_RESIDUALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_RESIDUAL_COR
        {
            get
            {
                return _VAL_RESIDUAL_COR;
            }
            set
            {
                OnVAL_RESIDUAL_CORChanging(value);
                ReportPropertyChanging("VAL_RESIDUAL_COR");
                _VAL_RESIDUAL_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_RESIDUAL_COR");
                OnVAL_RESIDUAL_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_RESIDUAL_COR;
        partial void OnVAL_RESIDUAL_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_RESIDUAL_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_VID_UTL
        {
            get
            {
                return _VAL_VID_UTL;
            }
            set
            {
                OnVAL_VID_UTLChanging(value);
                ReportPropertyChanging("VAL_VID_UTL");
                _VAL_VID_UTL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_VID_UTL");
                OnVAL_VID_UTLChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_VID_UTL;
        partial void OnVAL_VID_UTLChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_VID_UTLChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_VID_UTL_COR
        {
            get
            {
                return _VAL_VID_UTL_COR;
            }
            set
            {
                OnVAL_VID_UTL_CORChanging(value);
                ReportPropertyChanging("VAL_VID_UTL_COR");
                _VAL_VID_UTL_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_VID_UTL_COR");
                OnVAL_VID_UTL_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_VID_UTL_COR;
        partial void OnVAL_VID_UTL_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_VID_UTL_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_CHEQUE
        {
            get
            {
                return _NUM_CHEQUE;
            }
            set
            {
                OnNUM_CHEQUEChanging(value);
                ReportPropertyChanging("NUM_CHEQUE");
                _NUM_CHEQUE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_CHEQUE");
                OnNUM_CHEQUEChanged();
            }
        }
        private global::System.String _NUM_CHEQUE;
        partial void OnNUM_CHEQUEChanging(global::System.String value);
        partial void OnNUM_CHEQUEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_TIP_CAM
        {
            get
            {
                return _VAL_TIP_CAM;
            }
            set
            {
                OnVAL_TIP_CAMChanging(value);
                ReportPropertyChanging("VAL_TIP_CAM");
                _VAL_TIP_CAM = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_TIP_CAM");
                OnVAL_TIP_CAMChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_TIP_CAM;
        partial void OnVAL_TIP_CAMChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_TIP_CAMChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_PROVEE
        {
            get
            {
                return _COD_PROVEE;
            }
            set
            {
                OnCOD_PROVEEChanging(value);
                ReportPropertyChanging("COD_PROVEE");
                _COD_PROVEE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_PROVEE");
                OnCOD_PROVEEChanged();
            }
        }
        private global::System.String _COD_PROVEE;
        partial void OnCOD_PROVEEChanging(global::System.String value);
        partial void OnCOD_PROVEEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_EST_ADU
        {
            get
            {
                return _COD_EST_ADU;
            }
            set
            {
                OnCOD_EST_ADUChanging(value);
                ReportPropertyChanging("COD_EST_ADU");
                _COD_EST_ADU = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_EST_ADU");
                OnCOD_EST_ADUChanged();
            }
        }
        private global::System.String _COD_EST_ADU;
        partial void OnCOD_EST_ADUChanging(global::System.String value);
        partial void OnCOD_EST_ADUChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_TIP_OPE
        {
            get
            {
                return _COD_TIP_OPE;
            }
            set
            {
                OnCOD_TIP_OPEChanging(value);
                ReportPropertyChanging("COD_TIP_OPE");
                _COD_TIP_OPE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_TIP_OPE");
                OnCOD_TIP_OPEChanged();
            }
        }
        private global::System.String _COD_TIP_OPE;
        partial void OnCOD_TIP_OPEChanging(global::System.String value);
        partial void OnCOD_TIP_OPEChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String REF_NUM_ACT
        {
            get
            {
                return _REF_NUM_ACT;
            }
            set
            {
                OnREF_NUM_ACTChanging(value);
                ReportPropertyChanging("REF_NUM_ACT");
                _REF_NUM_ACT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("REF_NUM_ACT");
                OnREF_NUM_ACTChanged();
            }
        }
        private global::System.String _REF_NUM_ACT;
        partial void OnREF_NUM_ACTChanging(global::System.String value);
        partial void OnREF_NUM_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_ASI_CON
        {
            get
            {
                return _NUM_ASI_CON;
            }
            set
            {
                OnNUM_ASI_CONChanging(value);
                ReportPropertyChanging("NUM_ASI_CON");
                _NUM_ASI_CON = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_ASI_CON");
                OnNUM_ASI_CONChanged();
            }
        }
        private global::System.String _NUM_ASI_CON;
        partial void OnNUM_ASI_CONChanging(global::System.String value);
        partial void OnNUM_ASI_CONChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String IND_DEPREC
        {
            get
            {
                return _IND_DEPREC;
            }
            set
            {
                OnIND_DEPRECChanging(value);
                ReportPropertyChanging("IND_DEPREC");
                _IND_DEPREC = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IND_DEPREC");
                OnIND_DEPRECChanged();
            }
        }
        private global::System.String _IND_DEPREC;
        partial void OnIND_DEPRECChanging(global::System.String value);
        partial void OnIND_DEPRECChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FEC_EXP_GAR
        {
            get
            {
                return _FEC_EXP_GAR;
            }
            set
            {
                OnFEC_EXP_GARChanging(value);
                ReportPropertyChanging("FEC_EXP_GAR");
                _FEC_EXP_GAR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FEC_EXP_GAR");
                OnFEC_EXP_GARChanged();
            }
        }
        private Nullable<global::System.DateTime> _FEC_EXP_GAR;
        partial void OnFEC_EXP_GARChanging(Nullable<global::System.DateTime> value);
        partial void OnFEC_EXP_GARChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
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
                _COD_ORI_STS = StructuralObject.SetValidValue(value, false);
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
        public global::System.String COD_MON_COM
        {
            get
            {
                return _COD_MON_COM;
            }
            set
            {
                OnCOD_MON_COMChanging(value);
                ReportPropertyChanging("COD_MON_COM");
                _COD_MON_COM = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_MON_COM");
                OnCOD_MON_COMChanged();
            }
        }
        private global::System.String _COD_MON_COM;
        partial void OnCOD_MON_COMChanging(global::System.String value);
        partial void OnCOD_MON_COMChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IND_REG_SER
        {
            get
            {
                return _IND_REG_SER;
            }
            set
            {
                OnIND_REG_SERChanging(value);
                ReportPropertyChanging("IND_REG_SER");
                _IND_REG_SER = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IND_REG_SER");
                OnIND_REG_SERChanged();
            }
        }
        private Nullable<global::System.Boolean> _IND_REG_SER;
        partial void OnIND_REG_SERChanging(Nullable<global::System.Boolean> value);
        partial void OnIND_REG_SERChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> CAN_ACT_NUE
        {
            get
            {
                return _CAN_ACT_NUE;
            }
            set
            {
                OnCAN_ACT_NUEChanging(value);
                ReportPropertyChanging("CAN_ACT_NUE");
                _CAN_ACT_NUE = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CAN_ACT_NUE");
                OnCAN_ACT_NUEChanged();
            }
        }
        private Nullable<global::System.Decimal> _CAN_ACT_NUE;
        partial void OnCAN_ACT_NUEChanging(Nullable<global::System.Decimal> value);
        partial void OnCAN_ACT_NUEChanged();

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
        public Nullable<global::System.Decimal> VAL_DEPREC_MEN
        {
            get
            {
                return _VAL_DEPREC_MEN;
            }
            set
            {
                OnVAL_DEPREC_MENChanging(value);
                ReportPropertyChanging("VAL_DEPREC_MEN");
                _VAL_DEPREC_MEN = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPREC_MEN");
                OnVAL_DEPREC_MENChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_DEPREC_MEN;
        partial void OnVAL_DEPREC_MENChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_DEPREC_MENChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_DEPREC_MEN_COR
        {
            get
            {
                return _VAL_DEPREC_MEN_COR;
            }
            set
            {
                OnVAL_DEPREC_MEN_CORChanging(value);
                ReportPropertyChanging("VAL_DEPREC_MEN_COR");
                _VAL_DEPREC_MEN_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPREC_MEN_COR");
                OnVAL_DEPREC_MEN_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_DEPREC_MEN_COR;
        partial void OnVAL_DEPREC_MEN_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_DEPREC_MEN_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_VID_UTL_ACUM
        {
            get
            {
                return _VAL_VID_UTL_ACUM;
            }
            set
            {
                OnVAL_VID_UTL_ACUMChanging(value);
                ReportPropertyChanging("VAL_VID_UTL_ACUM");
                _VAL_VID_UTL_ACUM = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_VID_UTL_ACUM");
                OnVAL_VID_UTL_ACUMChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_VID_UTL_ACUM;
        partial void OnVAL_VID_UTL_ACUMChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_VID_UTL_ACUMChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_VID_UTL_ACUM_COR
        {
            get
            {
                return _VAL_VID_UTL_ACUM_COR;
            }
            set
            {
                OnVAL_VID_UTL_ACUM_CORChanging(value);
                ReportPropertyChanging("VAL_VID_UTL_ACUM_COR");
                _VAL_VID_UTL_ACUM_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_VID_UTL_ACUM_COR");
                OnVAL_VID_UTL_ACUM_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_VID_UTL_ACUM_COR;
        partial void OnVAL_VID_UTL_ACUM_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_VID_UTL_ACUM_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_RES_VID_UTL
        {
            get
            {
                return _VAL_RES_VID_UTL;
            }
            set
            {
                OnVAL_RES_VID_UTLChanging(value);
                ReportPropertyChanging("VAL_RES_VID_UTL");
                _VAL_RES_VID_UTL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_RES_VID_UTL");
                OnVAL_RES_VID_UTLChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_RES_VID_UTL;
        partial void OnVAL_RES_VID_UTLChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_RES_VID_UTLChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_RES_VID_UTL_COR
        {
            get
            {
                return _VAL_RES_VID_UTL_COR;
            }
            set
            {
                OnVAL_RES_VID_UTL_CORChanging(value);
                ReportPropertyChanging("VAL_RES_VID_UTL_COR");
                _VAL_RES_VID_UTL_COR = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_RES_VID_UTL_COR");
                OnVAL_RES_VID_UTL_CORChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_RES_VID_UTL_COR;
        partial void OnVAL_RES_VID_UTL_CORChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_RES_VID_UTL_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_LIB_ACT
        {
            get
            {
                return _VAL_LIB_ACT;
            }
            set
            {
                OnVAL_LIB_ACTChanging(value);
                ReportPropertyChanging("VAL_LIB_ACT");
                _VAL_LIB_ACT = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_LIB_ACT");
                OnVAL_LIB_ACTChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_LIB_ACT;
        partial void OnVAL_LIB_ACTChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_LIB_ACTChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> VAL_DEPREC
        {
            get
            {
                return _VAL_DEPREC;
            }
            set
            {
                OnVAL_DEPRECChanging(value);
                ReportPropertyChanging("VAL_DEPREC");
                _VAL_DEPREC = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPREC");
                OnVAL_DEPRECChanged();
            }
        }
        private Nullable<global::System.Decimal> _VAL_DEPREC;
        partial void OnVAL_DEPRECChanging(Nullable<global::System.Decimal> value);
        partial void OnVAL_DEPRECChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> FYH_FIN_DEPREC
        {
            get
            {
                return _FYH_FIN_DEPREC;
            }
            set
            {
                OnFYH_FIN_DEPRECChanging(value);
                ReportPropertyChanging("FYH_FIN_DEPREC");
                _FYH_FIN_DEPREC = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FYH_FIN_DEPREC");
                OnFYH_FIN_DEPRECChanged();
            }
        }
        private Nullable<global::System.DateTime> _FYH_FIN_DEPREC;
        partial void OnFYH_FIN_DEPRECChanging(Nullable<global::System.DateTime> value);
        partial void OnFYH_FIN_DEPRECChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int16> NUM_MES_DEPREC
        {
            get
            {
                return _NUM_MES_DEPREC;
            }
            set
            {
                OnNUM_MES_DEPRECChanging(value);
                ReportPropertyChanging("NUM_MES_DEPREC");
                _NUM_MES_DEPREC = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NUM_MES_DEPREC");
                OnNUM_MES_DEPRECChanged();
            }
        }
        private Nullable<global::System.Int16> _NUM_MES_DEPREC;
        partial void OnNUM_MES_DEPRECChanging(Nullable<global::System.Int16> value);
        partial void OnNUM_MES_DEPRECChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_DEP_REVAL
        {
            get
            {
                return _COD_CTA_DEP_REVAL;
            }
            set
            {
                OnCOD_CTA_DEP_REVALChanging(value);
                ReportPropertyChanging("COD_CTA_DEP_REVAL");
                _COD_CTA_DEP_REVAL = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("COD_CTA_DEP_REVAL");
                OnCOD_CTA_DEP_REVALChanged();
            }
        }
        private global::System.String _COD_CTA_DEP_REVAL;
        partial void OnCOD_CTA_DEP_REVALChanging(global::System.String value);
        partial void OnCOD_CTA_DEP_REVALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_GASDEP_REVAL
        {
            get
            {
                return _COD_CTA_GASDEP_REVAL;
            }
            set
            {
                OnCOD_CTA_GASDEP_REVALChanging(value);
                ReportPropertyChanging("COD_CTA_GASDEP_REVAL");
                _COD_CTA_GASDEP_REVAL = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("COD_CTA_GASDEP_REVAL");
                OnCOD_CTA_GASDEP_REVALChanged();
            }
        }
        private global::System.String _COD_CTA_GASDEP_REVAL;
        partial void OnCOD_CTA_GASDEP_REVALChanging(global::System.String value);
        partial void OnCOD_CTA_GASDEP_REVALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Decimal VAL_REVALS
        {
            get
            {
                return _VAL_REVALS;
            }
            set
            {
                OnVAL_REVALSChanging(value);
                ReportPropertyChanging("VAL_REVALS");
                _VAL_REVALS = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_REVALS");
                OnVAL_REVALSChanged();
            }
        }
        private global::System.Decimal _VAL_REVALS;
        partial void OnVAL_REVALSChanging(global::System.Decimal value);
        partial void OnVAL_REVALSChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Decimal VAL_DEPACU_REVAL
        {
            get
            {
                return _VAL_DEPACU_REVAL;
            }
            set
            {
                OnVAL_DEPACU_REVALChanging(value);
                ReportPropertyChanging("VAL_DEPACU_REVAL");
                _VAL_DEPACU_REVAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_DEPACU_REVAL");
                OnVAL_DEPACU_REVALChanged();
            }
        }
        private global::System.Decimal _VAL_DEPACU_REVAL;
        partial void OnVAL_DEPACU_REVALChanging(global::System.Decimal value);
        partial void OnVAL_DEPACU_REVALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Decimal VAL_GASDEPACU_REVAL
        {
            get
            {
                return _VAL_GASDEPACU_REVAL;
            }
            set
            {
                OnVAL_GASDEPACU_REVALChanging(value);
                ReportPropertyChanging("VAL_GASDEPACU_REVAL");
                _VAL_GASDEPACU_REVAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VAL_GASDEPACU_REVAL");
                OnVAL_GASDEPACU_REVALChanged();
            }
        }
        private global::System.Decimal _VAL_GASDEPACU_REVAL;
        partial void OnVAL_GASDEPACU_REVALChanging(global::System.Decimal value);
        partial void OnVAL_GASDEPACU_REVALChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_patrimonio
        {
            get
            {
                return _cod_patrimonio;
            }
            set
            {
                Oncod_patrimonioChanging(value);
                ReportPropertyChanging("cod_patrimonio");
                _cod_patrimonio = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_patrimonio");
                Oncod_patrimonioChanged();
            }
        }
        private global::System.String _cod_patrimonio;
        partial void Oncod_patrimonioChanging(global::System.String value);
        partial void Oncod_patrimonioChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_provincia
        {
            get
            {
                return _cod_provincia;
            }
            set
            {
                Oncod_provinciaChanging(value);
                ReportPropertyChanging("cod_provincia");
                _cod_provincia = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_provincia");
                Oncod_provinciaChanged();
            }
        }
        private global::System.String _cod_provincia;
        partial void Oncod_provinciaChanging(global::System.String value);
        partial void Oncod_provinciaChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_canton
        {
            get
            {
                return _cod_canton;
            }
            set
            {
                Oncod_cantonChanging(value);
                ReportPropertyChanging("cod_canton");
                _cod_canton = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_canton");
                Oncod_cantonChanged();
            }
        }
        private global::System.String _cod_canton;
        partial void Oncod_cantonChanging(global::System.String value);
        partial void Oncod_cantonChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_distrito
        {
            get
            {
                return _cod_distrito;
            }
            set
            {
                Oncod_distritoChanging(value);
                ReportPropertyChanging("cod_distrito");
                _cod_distrito = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_distrito");
                Oncod_distritoChanged();
            }
        }
        private global::System.String _cod_distrito;
        partial void Oncod_distritoChanging(global::System.String value);
        partial void Oncod_distritoChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> anno_presupuesto
        {
            get
            {
                return _anno_presupuesto;
            }
            set
            {
                Onanno_presupuestoChanging(value);
                ReportPropertyChanging("anno_presupuesto");
                _anno_presupuesto = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("anno_presupuesto");
                Onanno_presupuestoChanged();
            }
        }
        private Nullable<global::System.Int32> _anno_presupuesto;
        partial void Onanno_presupuestoChanging(Nullable<global::System.Int32> value);
        partial void Onanno_presupuestoChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_acta
        {
            get
            {
                return _cod_acta;
            }
            set
            {
                Oncod_actaChanging(value);
                ReportPropertyChanging("cod_acta");
                _cod_acta = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_acta");
                Oncod_actaChanged();
            }
        }
        private global::System.String _cod_acta;
        partial void Oncod_actaChanging(global::System.String value);
        partial void Oncod_actaChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_folio
        {
            get
            {
                return _cod_folio;
            }
            set
            {
                Oncod_folioChanging(value);
                ReportPropertyChanging("cod_folio");
                _cod_folio = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_folio");
                Oncod_folioChanged();
            }
        }
        private global::System.String _cod_folio;
        partial void Oncod_folioChanging(global::System.String value);
        partial void Oncod_folioChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_prog_presupuestario
        {
            get
            {
                return _cod_prog_presupuestario;
            }
            set
            {
                Oncod_prog_presupuestarioChanging(value);
                ReportPropertyChanging("cod_prog_presupuestario");
                _cod_prog_presupuestario = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_prog_presupuestario");
                Oncod_prog_presupuestarioChanged();
            }
        }
        private global::System.String _cod_prog_presupuestario;
        partial void Oncod_prog_presupuestarioChanging(global::System.String value);
        partial void Oncod_prog_presupuestarioChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String cod_subprog_presupuestario
        {
            get
            {
                return _cod_subprog_presupuestario;
            }
            set
            {
                Oncod_subprog_presupuestarioChanging(value);
                ReportPropertyChanging("cod_subprog_presupuestario");
                _cod_subprog_presupuestario = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cod_subprog_presupuestario");
                Oncod_subprog_presupuestarioChanged();
            }
        }
        private global::System.String _cod_subprog_presupuestario;
        partial void Oncod_subprog_presupuestarioChanging(global::System.String value);
        partial void Oncod_subprog_presupuestarioChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
        [DataMemberAttribute()]
        public global::System.Boolean ind_exportado
        {
            get
            {
                return _ind_exportado;
            }
            set
            {
                Onind_exportadoChanging(value);
                ReportPropertyChanging("ind_exportado");
                _ind_exportado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ind_exportado");
                Onind_exportadoChanged();
            }
        }
        private global::System.Boolean _ind_exportado;
        partial void Onind_exportadoChanging(global::System.Boolean value);
        partial void Onind_exportadoChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> ind_act_grupo
        {
            get
            {
                return _ind_act_grupo;
            }
            set
            {
                Onind_act_grupoChanging(value);
                ReportPropertyChanging("ind_act_grupo");
                _ind_act_grupo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ind_act_grupo");
                Onind_act_grupoChanged();
            }
        }
        private Nullable<global::System.Boolean> _ind_act_grupo;
        partial void Onind_act_grupoChanging(Nullable<global::System.Boolean> value);
        partial void Onind_act_grupoChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_CTA_COSTO
        {
            get
            {
                return _COD_CTA_COSTO;
            }
            set
            {
                OnCOD_CTA_COSTOChanging(value);
                ReportPropertyChanging("COD_CTA_COSTO");
                _COD_CTA_COSTO = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_CTA_COSTO");
                OnCOD_CTA_COSTOChanged();
            }
        }
        private global::System.String _COD_CTA_COSTO;
        partial void OnCOD_CTA_COSTOChanging(global::System.String value);
        partial void OnCOD_CTA_COSTOChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String COD_MON_COM_COR
        {
            get
            {
                return _COD_MON_COM_COR;
            }
            set
            {
                OnCOD_MON_COM_CORChanging(value);
                ReportPropertyChanging("COD_MON_COM_COR");
                _COD_MON_COM_COR = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("COD_MON_COM_COR");
                OnCOD_MON_COM_CORChanged();
            }
        }
        private global::System.String _COD_MON_COM_COR;
        partial void OnCOD_MON_COM_CORChanging(global::System.String value);
        partial void OnCOD_MON_COM_CORChanged();

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = true)]
        [DataMemberAttribute()]
        public global::System.String NUM_BLOQUE
        {
            get
            {
                return _NUM_BLOQUE;
            }
            set
            {
                OnNUM_BLOQUEChanging(value);
                ReportPropertyChanging("NUM_BLOQUE");
                _NUM_BLOQUE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NUM_BLOQUE");
                OnNUM_BLOQUEChanged();
            }
        }
        private global::System.String _NUM_BLOQUE;
        partial void OnNUM_BLOQUEChanging(global::System.String value);
        partial void OnNUM_BLOQUEChanged();

        #endregion

        #region Navigation Properties

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_ACTIV_MOVIL_AFM_MAEST_ACTIV", "AFM_ACTIV_MOVIL")]
        public EntityCollection<AFM_ACTIV_MOVIL> AFM_ACTIV_MOVIL
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_ACTIV_MOVIL>("BostonModel.FK_AFM_ACTIV_MOVIL_AFM_MAEST_ACTIV", "AFM_ACTIV_MOVIL");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_ACTIV_MOVIL>("BostonModel.FK_AFM_ACTIV_MOVIL_AFM_MAEST_ACTIV", "AFM_ACTIV_MOVIL", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV1", "AFM_COMPO_ACTIV")]
        public EntityCollection<AFM_COMPO_ACTIV> AFM_COMPO_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_COMPO_ACTIV>("BostonModel.FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV1", "AFM_COMPO_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_COMPO_ACTIV>("BostonModel.FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV1", "AFM_COMPO_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV2", "AFM_COMPO_ACTIV")]
        public EntityCollection<AFM_COMPO_ACTIV> AFM_COMPO_ACTIV1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_COMPO_ACTIV>("BostonModel.FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV2", "AFM_COMPO_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_COMPO_ACTIV>("BostonModel.FK_AFM_COMPO_ACTIV_AFM_MAEST_ACTIV2", "AFM_COMPO_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_MOVIM_DEPRE_AFM_MAEST_ACTIV", "AFM_DEPRE_ACTIV")]
        public EntityCollection<AFM_DEPRE_ACTIV> AFM_DEPRE_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DEPRE_ACTIV>("BostonModel.FK_AFM_MOVIM_DEPRE_AFM_MAEST_ACTIV", "AFM_DEPRE_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DEPRE_ACTIV>("BostonModel.FK_AFM_MOVIM_DEPRE_AFM_MAEST_ACTIV", "AFM_DEPRE_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETA_REF_699_AFM_MAES", "AFM_DETAL_MOVFI")]
        public EntityCollection<AFM_DETAL_MOVFI> AFM_DETAL_MOVFI
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETAL_MOVFI>("BostonModel.FK_AFM_DETA_REF_699_AFM_MAES", "AFM_DETAL_MOVFI");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETAL_MOVFI>("BostonModel.FK_AFM_DETA_REF_699_AFM_MAES", "AFM_DETAL_MOVFI", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETAL_TOMAF_AFM_MAEST_ACTIV", "AFM_DETAL_TOMAF")]
        public EntityCollection<AFM_DETAL_TOMAF> AFM_DETAL_TOMAF
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_MAEST_ACTIV", "AFM_DETAL_TOMAF");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETAL_TOMAF>("BostonModel.FK_AFM_DETAL_TOMAF_AFM_MAEST_ACTIV", "AFM_DETAL_TOMAF", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETCIE_DEPRE_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE")]
        public EntityCollection<AFM_DETCIE_DEPRE> AFM_DETCIE_DEPRE
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETCIE_DEPRE>("BostonModel.FK_AFM_DETCIE_DEPRE_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETCIE_DEPRE>("BostonModel.FK_AFM_DETCIE_DEPRE_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DETCIE_DEPRE_COR_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE_COR")]
        public EntityCollection<AFM_DETCIE_DEPRE_COR> AFM_DETCIE_DEPRE_COR
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DETCIE_DEPRE_COR>("BostonModel.FK_AFM_DETCIE_DEPRE_COR_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE_COR");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DETCIE_DEPRE_COR>("BostonModel.FK_AFM_DETCIE_DEPRE_COR_AFM_MAEST_ACTIV", "AFM_DETCIE_DEPRE_COR", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_DOCADJ_ACTIV_AFM_MAEST_ACTIV", "AFM_DOCADJ_ACTIV")]
        public EntityCollection<AFM_DOCADJ_ACTIV> AFM_DOCADJ_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_DOCADJ_ACTIV>("BostonModel.FK_AFM_DOCADJ_ACTIV_AFM_MAEST_ACTIV", "AFM_DOCADJ_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_DOCADJ_ACTIV>("BostonModel.FK_AFM_DOCADJ_ACTIV_AFM_MAEST_ACTIV", "AFM_DOCADJ_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_EMPLE_ACTIV_AFM_MAEST_ACTIV", "AFM_EMPLE_ACTIV")]
        public EntityCollection<AFM_EMPLE_ACTIV> AFM_EMPLE_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_EMPLE_ACTIV>("BostonModel.FK_AFM_EMPLE_ACTIV_AFM_MAEST_ACTIV", "AFM_EMPLE_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_EMPLE_ACTIV>("BostonModel.FK_AFM_EMPLE_ACTIV_AFM_MAEST_ACTIV", "AFM_EMPLE_ACTIV", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFM_IMPRE_PLACAS_AFM_MAEST_ACTIV", "AFM_IMPRE_PLACAS")]
        public EntityCollection<AFM_IMPRE_PLACAS> AFM_IMPRE_PLACAS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFM_IMPRE_PLACAS>("BostonModel.FK_AFM_IMPRE_PLACAS_AFM_MAEST_ACTIV", "AFM_IMPRE_PLACAS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFM_IMPRE_PLACAS>("BostonModel.FK_AFM_IMPRE_PLACAS_AFM_MAEST_ACTIV", "AFM_IMPRE_PLACAS", value);
                }
            }
        }

        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BostonModel", "FK_AFR_VALOR_ACTIV_AFM_MAEST_ACTIV", "AFR_VALOR_ACTIV")]
        public EntityCollection<AFR_VALOR_ACTIV> AFR_VALOR_ACTIV
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<AFR_VALOR_ACTIV>("BostonModel.FK_AFR_VALOR_ACTIV_AFM_MAEST_ACTIV", "AFR_VALOR_ACTIV");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<AFR_VALOR_ACTIV>("BostonModel.FK_AFR_VALOR_ACTIV_AFM_MAEST_ACTIV", "AFR_VALOR_ACTIV", value);
                }
            }
        }

        #endregion
    }
}
