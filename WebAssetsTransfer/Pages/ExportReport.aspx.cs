using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssetsTransfer
{
    public partial class ExportReport : System.Web.UI.Page
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.LocalReport.ReportPath = "Pages\\WAT.rdlc";
                //Page.ResolveClientUrl("~/Pages/WAT.rdlc"); //"Pages\\WAT.rdlc";
           /*if (!Page.IsPostBack)
           {*/
            if (base.Request.QueryString["id"] != null)
               id = Convert.ToInt32(base.Request.QueryString["id"]);
           //}
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["id"] = id;
            e.InputParameters["code_compania"] = this.Session["CODIGO_COMPANIA"].ToString();
        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["id"] = id;           
        }

        protected void ObjectDataSource3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["id"] = id;
            e.InputParameters["code_compania"] = this.Session["CODIGO_COMPANIA"].ToString();
        }
    }
}