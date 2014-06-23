using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebAssetsTransfer.Functions
{
    public class cls_funciones
    {
        public BoundField CreaBoundField(string txt_data_field, string txt_header_text, bool bl_visible_colum)
        {
            return new BoundField
            {
                DataField = txt_data_field,
                HeaderText = txt_header_text,
                SortExpression = txt_data_field,
                Visible = bl_visible_colum,
                HtmlEncode = false
            };
        }
    }
}
