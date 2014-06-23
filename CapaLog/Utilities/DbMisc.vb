Public Class DbMisc

    Public Sub New()
        'MyBase.New(connString, sportsbookId)
    End Sub

    Public Function DataViewToDataSet(ByRef dv As DataView) As DataSet
        Dim dsTemp As New DataSet()
        Dim dtTemp As New DataTable()
        Try
            dtTemp = dv.Table.Clone
            dtTemp.TableName = "Row"
            For Each drv As DataRowView In dv
                dtTemp.ImportRow(drv.Row)
            Next
            dsTemp = New DataSet(dv.Table.TableName)
            dsTemp.Tables.Add(dtTemp)
            Return dsTemp
        Catch ex As Exception
            Return Nothing
        Finally
            'No descomentar por que afecta a otros reportes (Reporte ADVANCE SERARCH)
            '25-3-2010 by Falcon
            'If Not dv Is Nothing Then dv.Dispose()
            'dv = Nothing
            If Not dsTemp Is Nothing Then dsTemp.Dispose()
            dsTemp = Nothing
            If Not dtTemp Is Nothing Then dtTemp.Dispose()
            dtTemp = Nothing
        End Try
    End Function

End Class
