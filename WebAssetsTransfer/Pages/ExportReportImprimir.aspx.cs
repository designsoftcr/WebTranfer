using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssetsTransfer
{
    public partial class ExportReportImprimir : System.Web.UI.Page
    {
        private int id_movimiento = 0;
        private string usuario = string.Empty;
        private string code_centro_costo = string.Empty;
        private string code_solicitante = string.Empty;
        private string fetcha = string.Empty;
        private string tipomovimiento = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.ReportPath = "Pages\\WATImprimir.rdlc";
                //Page.ResolveClientUrl("~/Pages/WATImprimir.rdlc"); //"Pages\\WATImprimir.rdlc";
           if (!Page.IsPostBack)
           {
               id_movimiento = Convert.ToInt32(base.Request.QueryString["id"]);
               usuario = base.Request.QueryString["usuario"];
               code_centro_costo = base.Request.QueryString["code_centro_costo"];
               code_solicitante = base.Request.QueryString["code_solicitante"];
               fetcha = base.Request.QueryString["fetcha"];
               tipomovimiento = base.Request.QueryString["tipomovimiento"];
           }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["id_movimiento"] = id_movimiento;
            e.InputParameters["usuario"] = usuario;
            e.InputParameters["code_centro_costo"] = code_centro_costo;
            e.InputParameters["code_solicitante"] = code_solicitante;
            e.InputParameters["fetcha"] = fetcha;
            e.InputParameters["tipomovimiento"] = tipomovimiento;
   
        }


    }
}