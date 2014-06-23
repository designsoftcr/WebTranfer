Imports System.Web.UI.WebControls

''' <summary>
'''  Contains functions that interacts with the grid.   
''' </summary>
Public Module GridUtilities

    ''' <summary>
    '''     All the Grids in the application have a common look.
    '''     In order to make it easier to edit in the future and to mantain a good consistency
    '''     on how things should look they are being maganed by CSS.
    '''     This function applies the correct style class to the item depending of it's type:
    '''     Footer, header, etc.
    ''' </summary>
    ''' <param name="gi">The DataGridItem where the style will be applied</param>
    Public Sub ApplyStyle(ByRef gi As DataGridItem, Optional ByVal IsNewStypeHeader As Boolean = False)
        Select Case gi.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                If gi.ItemType = ListItemType.AlternatingItem Then
                    gi.Attributes.Add("class", "rowOdd")
                Else
                    gi.Attributes.Add("class", "rowEven")
                End If
                'gi.Attributes.Add("id", "rowSelected")
                gi.Attributes.Add("onmouseover", "this.id='rowSelected' ")
                gi.Attributes.Add("onmouseout", "this.id='' ")

            Case ListItemType.Footer
                gi.Attributes.Add("class", "footerStyle")
            Case ListItemType.Header
                If IsNewStypeHeader Then
                    gi.Attributes.Add("class", "headerStyle2")
                Else
                    gi.Attributes.Add("id", "headerStyle")
                End If
            Case (ListItemType.Pager)
                gi.Attributes.Add("class", "pagerStyle")

            Case (ListItemType.SelectedItem)
                gi.Attributes.Add("class", "rowSelected2")

        End Select
    End Sub

    Public Sub ApplyStyleV2(ByRef gi As DataGridItem)
        Select Case gi.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                If gi.ItemType = ListItemType.AlternatingItem Then
                    gi.Attributes.Add("class", "rowOdd")
                Else
                    gi.Attributes.Add("class", "rowEven")
                End If

                'gi.Attributes.Add("id", "rowSelected")
                gi.Attributes.Add("onmouseover", "this.id='cBankGridTestV' ")
                gi.Attributes.Add("onmouseout", "this.id='' ")

            Case ListItemType.Footer
                gi.Attributes.Add("class", "footerStyle")

            Case ListItemType.Header
                gi.Attributes.Add("id", "headerStyle")

            Case (ListItemType.Pager)
                gi.Attributes.Add("class", "pagerStyle")

            Case (ListItemType.SelectedItem)
                gi.Attributes.Add("class", "cBankGridTest")

        End Select
    End Sub

    Public Sub ApplyStyleV3(ByRef gi As DataGridItem)
        Select Case gi.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                If gi.ItemType = ListItemType.AlternatingItem Then
                    gi.Attributes.Add("class", "rowOddV2")
                Else
                    gi.Attributes.Add("class", "rowEvenV2")
                End If
                gi.Attributes.Add("onmouseover", "this.id='rowSelectedV2' ")
                gi.Attributes.Add("onmouseout", "this.id='' ")

            Case ListItemType.Footer
                gi.Attributes.Add("class", "footerStyle")

            Case ListItemType.Header
                gi.Attributes.Add("class", "headerStyle2")

            Case (ListItemType.Pager)
                gi.Attributes.Add("class", "pagerStyle")

            Case (ListItemType.SelectedItem)
                gi.Attributes.Add("class", "rowSelected2")

        End Select
    End Sub
    
    Public Sub SortGrid(ByRef grGrid As DataGrid, ByVal DsDataSet As DataSet, ByVal sortExpression As String)
        Dim dvDataView As New DataView
        Try
            If sortExpression Is Nothing Then Exit Sub
            If sortExpression.Trim.Equals(String.Empty) Then Exit Sub
            'Sorts a grid using the column indicated by the user.
            'A Sort attribute is created to the grid to know what is the next sort order.
            'Checks there's something to sort.
            If DsDataSet Is Nothing Then _
                Return
            dvDataView = New DataView(DsDataSet.Tables(0))
            'Checks if the sort attribute exists. If it does not, create one.
            If grGrid.Attributes.Item("sort") = String.Empty Then _
                grGrid.Attributes.Add("sort", " asc")

            'Tells the Expression if it is asc or desc
            sortExpression &= grGrid.Attributes.Item("sort")

            'Changes sort order for next call
            If grGrid.Attributes.Item("sort") = " desc" Then
                grGrid.Attributes.Item("sort") = " asc"
            Else
                grGrid.Attributes.Item("sort") = " desc"
            End If

            Try
                dvDataView.Sort = sortExpression
            Catch exc As System.Data.EvaluateException
                'Do nothing
                Log.appendToLog(exc)
            End Try

            DsDataSet = New DbMisc().DataViewToDataSet(dvDataView)
            grGrid.DataSource = DsDataSet
            grGrid.DataBind()
        Catch ex As Exception
            'do nothing
        Finally
            If Not DsDataSet Is Nothing Then DsDataSet.Dispose()
            DsDataSet = Nothing
            If Not dvDataView Is Nothing Then dvDataView.Dispose()
            dvDataView = Nothing
        End Try
    End Sub
End Module
