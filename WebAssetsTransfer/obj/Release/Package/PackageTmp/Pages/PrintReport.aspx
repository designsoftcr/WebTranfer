<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintReport.aspx.cs" Inherits="WebAssetsTransfer.Pages.PrintReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
       
        .main_table
        {
            width: 800px;
            padding: 20px;           
        }
        p.footer
        {
            padding:50px 10px 0px 10px;
            color:#1F497D;    
            font-size:.80em;
            text-align:center;
            width:780px;
        }
        .title
        {
            padding-left: 10px;
            color: #1F497D;
            font-size: 1em;
            text-align: left;
            font-weight: bold;            
        }
         .subtitle
        {
            padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;
        }
         .label
        {
            padding: 0px 10px;
            color: #000000;
            font-size: 0.8em;
            text-align: left;
            font-weight: normal;
        }
        .label_tabla
        {
            padding: 0px 10px;
            color: #000000;
            font-size: 0.7em;
            text-align: left;
            font-weight: normal;
        }
       
        .link
        {
            text-decoration: underline;
            font-size: 1.3em;
            color: #0033CC;
            text-align: center;
        }
       
        .left_content
        {
            width: 540px;
            padding:20px 0px;
        }
       
        a
        {
            color: #3366CC;
            font-size: 1.2em;
            text-decoration: underline;
        }
       
        .tablas_lista
        {
            width: 700px;border: 1px solid #000;border-collapse: collapse;
        }
 
        .tablas_lista th, .tablas_lista td {
          border: 1px solid #000;
        }
       
    </style>
</head>
<body>

    <table style=" width: 800px; padding : 20px; " align="center">
       <tr>
            <td colspan="2"><img src="cid:img_header"/></td>
        </tr>
        <tr>
            <td style="width:560px;">
                <span style="padding-left: 10px; color: #1F497D; font-size: 1em; text-align: left; font-weight: bold; ">Solicitud de Aprobación de Movimiento de Activos Fijos<br /></span>                            
                <img alt="" src="cid:line_up_mail" /><br />
                <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Solicitud Número: </span><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[ID_MOVIMIENTO]</span><br />
                <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Planta:</span><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[PLANTA_1], [PLANTA_2]</span><br />
                <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Solicitante:</span><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[NOMBRE_SOLICITANTE]</span><br />
                <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Tipo de Movimiento:</span> <span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[NOMBRE_TIPO_MOVIMIENTO]</span>
                <br />
                <table style="width: 540px;padding:20px 0px;">
                    <tr>
                        <td>
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">
                            Ubicación Actual</span><br /><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal"></span>
                            <span 
                                style="color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[UBICACION_ACTUAL]</span></td>
                        <td>
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Departamento Receptor</span><br /><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">
                            [DEPARTAMENTO_RECEPTOR]</span></td>
                    </tr>
                    <tr>
                        <td>
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Centro de Costo Actual:</span><br />
                            <span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[CENTRO_COSTO_ACTUAL]</span></td>
                        <td>
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Centro de Costo Receptor:</span><br />
                            <span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[CENTRO_COSTO_RECEPTOR]</span></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center;">
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">
                            Total Valor en Libros : </span><span style="padding: 0px 10px;color: #000000;font-size: 0.9em;text-align: left;font-weight: normal">[VALOR_LIBROS]</span></td>
                    </tr>
                </table>
            </td>
            <td style="width:240px;">
                 <img align="middle" alt="Control Integrida Responsabilidad" 
                     src="cid:bg_content_mail" />
            </td>
        </tr>
        <tr>
            <td style="text-align:left;" colspan="2">
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Lista de Activos : </span>
                <br />
                [LISTA_ACTIVOS]               
                <br />
            &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align:left;" colspan="2"> 
                            <span style="padding:0px 10px;color:#000000;font-size:0.9em;text-align:left;font-weight:bold;">Historico de Movimientos : </span>
                <br />
                [HISTORICO]<br />               
                <br />
                &nbsp;
           </td>
        </tr>       
        <tr>
            <td colspan="2">
                <p style="padding:50px 10px 0px 10px;color:#1F497D;font-size:0.87em;text-align:center;width:780px;">Recordar la importancia de tramitar todo movimiento de activos mediante este sistema ya que permite tener los reportes de depreciaciones actualizados en los Centros de Costo correspondientes y el cumplimiento de los requerimientos solicitados por parte de Procomer y Corporación.</p></td>
        </tr>
    </table>    
</body>
</html>