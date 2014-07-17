using System;
using System.Collections.Generic;
using System.Data;
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
               if (base.Request.QueryString["id"] != null)
               {
                   id_movimiento = Convert.ToInt32(base.Request.QueryString["id"]);
               }
               else if (base.Request.QueryString["id_movimiento"] != null) {
                   id_movimiento = Convert.ToInt32(base.Request.QueryString["id_movimiento"]);
               }
               if (base.Request.QueryString["usuario"] != null)
               {
                   usuario = base.Request.QueryString["usuario"];
               }
               if (base.Request.QueryString["code_centro_costo"] != null)
               {
                   code_centro_costo = base.Request.QueryString["code_centro_costo"];
               }
               if (base.Request.QueryString["code_solicitante"] != null)
               {
                   code_solicitante = base.Request.QueryString["code_solicitante"];
               }
               if (base.Request.QueryString["fetcha"] != null)
               {
                   fetcha = base.Request.QueryString["fetcha"];
               }
               if (base.Request.QueryString["tipomovimiento"] != null)
               {
                   tipomovimiento = base.Request.QueryString["tipomovimiento"];
               }
           }
        }

        private void LoadReport() {
            try
            {
                DataTable dt = new DataTable();
               //ObjectDataSource1.data
               // ReportViewer1.LocalReport.DataSources.Add(dt);
            }
            catch (Exception)
            {
                
                throw;
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