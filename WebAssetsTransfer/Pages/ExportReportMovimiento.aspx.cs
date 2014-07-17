using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssetsTransfer
{
    public partial class ExportReportMovimiento : System.Web.UI.Page
    {
        private int id_movimiento = 0;
        private string cod_centro_costo = string.Empty;
        private string cod_solicitante = string.Empty;
        private string fetcha = string.Empty;
        private string tipo_movimiento = string.Empty;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.ReportPath = "Pages\\WATMovimiento.rdlc";
                //Page.ResolveClientUrl("~/Pages/WATMovimiento.rdlc");  //"Pages\\WATMovimiento.rdlc";

            //ReportViewer1.LocalReport.DataSources =
           if (!Page.IsPostBack)
           {
               if (base.Request.QueryString["id"] != null && !string.IsNullOrEmpty(base.Request.QueryString["id"]))
               {
                   id_movimiento = int.Parse(base.Request.QueryString["id"]);
               }
               else if (base.Request.QueryString["id_movimiento"] != null && !string.IsNullOrEmpty(base.Request.QueryString["id_movimiento"]))
               {
                   id_movimiento = int.Parse(base.Request.QueryString["id_movimiento"]);
               }
               if (!string.IsNullOrEmpty(base.Request.QueryString["cod_centro_costo"])){
                cod_centro_costo = base.Request.QueryString["cod_centro_costo"];
               }
                if (!string.IsNullOrEmpty(base.Request.QueryString["cod_solicitante"])){
                cod_solicitante = base.Request.QueryString["cod_solicitante"];
               }
                if (!string.IsNullOrEmpty(base.Request.QueryString["fetcha"]))
                {
                    fetcha = base.Request.QueryString["fetcha"];
                }
                if (!string.IsNullOrEmpty(base.Request.QueryString["tipo_movimiento"]))
                {
                    tipo_movimiento = base.Request.QueryString["tipo_movimiento"];
                }             
           }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["id_movimiento"] = id_movimiento;
            e.InputParameters["cod_centro_costo"] = cod_centro_costo;
            e.InputParameters["cod_solicitante"] = cod_solicitante;
            e.InputParameters["fetcha"] = fetcha;
            e.InputParameters["tipo_movimiento"] = tipo_movimiento;
        }


    }
}