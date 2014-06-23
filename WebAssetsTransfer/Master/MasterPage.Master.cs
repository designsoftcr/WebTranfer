using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace jqgridTree.UI
{
    //GPE added partial
    public partial class SiteMaster : MasterPage
    {
        protected ContentPlaceHolder head;
        protected HtmlForm form1;
        protected ImageButton img_btn_salir;
        protected Label lb_page_title;
        protected Label lb_aviso;
        protected ContentPlaceHolder ContentPlaceHolder1;
        protected Label lb_titulo_declaracion_jurada;
        protected Label lb_declaracion_jurada;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //GPE 1/26/2014 IE Fixing Issues
            //HtmlGenericControl link = new HtmlGenericControl("link");
            //link.Attributes.Add("rel", "stylesheet");
            //link.Attributes.Add("href", this.Page.ResolveClientUrl("~/Styles/Site.css"));
            //link.Attributes.Add("type", "text/css");
            //this.Page.Header.Controls.Add(link);
            this.img_btn_salir.Enabled = true;
        }
    }
}
