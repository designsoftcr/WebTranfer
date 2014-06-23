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
           if (!Page.IsPostBack)
           {
              id_movimiento = Convert.ToInt32(base.Request.QueryString["id"]);
              cod_centro_costo = base.Request.QueryString["cod_centro_costo"];
              cod_solicitante = base.Request.QueryString["cod_solicitante"];
              fetcha = base.Request.QueryString["fetcha"];
              tipo_movimiento = base.Request.QueryString["tipo_movimiento"];
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