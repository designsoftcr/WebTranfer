<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportReportImprimir.aspx.cs" Inherits="WebAssetsTransfer.ExportReportImprimir" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; margin-left: auto; margin-right: auto ;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="10pt" Height="930px" Width="607px">
            <LocalReport ReportEmbeddedResource="WebAssetsTransfer.Pages.WATImprimir.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet4" />                   
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetReportImprimir" TypeName="BLL.CustomDS, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
         <SelectParameters>
            <asp:Parameter Name="id_movimiento" Type="Int32" />
            <asp:Parameter Name="usuario" Type="String" />
            <asp:Parameter Name="code_centro_costo" Type="String" />
            <asp:Parameter Name="code_solicitante" Type="String" />
            <asp:Parameter Name="fetcha" Type="String" />
            <asp:Parameter Name="tipomovimiento" Type="String" />
        </SelectParameters>
       </asp:ObjectDataSource>      

           <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    </div>
    </form>
</body>
</html>
