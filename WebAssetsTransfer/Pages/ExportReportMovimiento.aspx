<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportReportMovimiento.aspx.cs" Inherits="WebAssetsTransfer.ExportReportMovimiento" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; margin-left: auto; margin-right: auto ;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="10pt" style="width:95%; margin: auto;" Height="100%">
            <LocalReport ReportEmbeddedResource="WebAssetsTransfer.Pages.WATMovimiento.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />                   
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetReportMovMaestro" TypeName="BLL.CustomDS, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
         <SelectParameters>
            <asp:Parameter Name="id_movimiento" Type="Int32" />
            <asp:Parameter Name="cod_centro_costo" Type="String" />
            <asp:Parameter Name="cod_solicitante" Type="String" />
            <asp:Parameter Name="fetcha" Type="String" />
            <asp:Parameter Name="tipo_movimiento" Type="String" />
        </SelectParameters>
       </asp:ObjectDataSource>      

           <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    </div>
    </form>
</body>
</html>
