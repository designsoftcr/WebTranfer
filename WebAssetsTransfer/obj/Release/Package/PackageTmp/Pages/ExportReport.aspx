<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportReport.aspx.cs" Inherits="WebAssetsTransfer.ExportReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%; margin-left: auto; margin-right: auto ;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="10pt" Height="100%" Width="100%">
            <LocalReport ReportEmbeddedResource="WebAssetsTransfer.Pages.WAT.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet3" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
       <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetReport" TypeName="BLL.CustomDS, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
         <SelectParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="code_compania" Type="String" />
        </SelectParameters>
       </asp:ObjectDataSource>
       <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OnSelecting="ObjectDataSource2_Selecting" SelectMethod="GetReportHistorico" TypeName="BLL.CustomDS, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
         <SelectParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </SelectParameters>
       </asp:ObjectDataSource>
               <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OnSelecting="ObjectDataSource3_Selecting" SelectMethod="GetReportActivo" TypeName="BLL.CustomDS, BLL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
         <SelectParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="code_compania" Type="String" />
        </SelectParameters>
       </asp:ObjectDataSource>

           <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    </div>
    </form>
</body>
</html>
