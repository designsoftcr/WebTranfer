Imports System
Imports System.Text.RegularExpressions

Public Class RegularExpressionParser

#Region "VARIABLES"
    Private strSrc As String
    Private strReg As String
#End Region

#Region "CONSTRUCTOR"
    Public Sub New(ByVal strSource As String, ByVal strRegExp As String)
        strSrc = strSource
        strReg = strRegExp
    End Sub
#End Region

#Region "PARSE REGULAR RESPONSE"
    Public Function ParseRegularResponse() As Hashtable
        Dim myMatch As Match
        Dim oHash As New Hashtable
        Try
            myMatch = Regex.Match(strSrc, strReg)
            For i As Short = 0 To myMatch.Groups.Count - 1
                oHash.Add(i.ToString, myMatch.Groups.Item(i).Value.ToString)
            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return oHash
    End Function
#End Region

#Region "PARSE STR RESPONSE"
    Public Function ParseStrResponse() As String
        Try            
            Dim myMatch As Match
            Dim myMatches As MatchCollection
            Dim resultado As String = String.Empty
            myMatches = Regex.Matches(strSrc, strReg)

            For Each myMatch In myMatches
                resultado = resultado & myMatch.Value
            Next

            Return resultado
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
#End Region

#Region "SHARED FUNCTIONS"
    Public Shared Function ParseToNumber(ByVal myValue As String) As String
        Try
            If myValue = Nothing Then Return ""
            Dim oParser As New RegularExpressionParser(myValue.Trim, "[0-9]*")
            Return oParser.ParseStrResponse
        Catch ex As Exception
            Return myValue
        End Try
    End Function
    Public Shared Function ParseToAlpha(ByVal myValue As String) As String
        Try
            If myValue = Nothing Then Return ""
            Dim oParser As New RegularExpressionParser(myValue.Trim, "[A-Za-z]*")
            Return oParser.ParseStrResponse
        Catch ex As Exception
            Return myValue
        End Try
    End Function
    Public Shared Function ParseToAlphaNumeric(ByVal strValue As String) As String
        Dim regexstr As String = Nothing
        Dim oParser As RegularExpressionParser = Nothing
        Try
            If strValue = Nothing Then Return Nothing
            regexstr = "[A-Za-z0-9]*"
            oParser = New RegularExpressionParser(strValue, regexstr)
            strValue = oParser.ParseStrResponse
        Catch ex As Exception
            strValue = Nothing
        End Try
        Return strValue
    End Function

    Public Shared Function MatchAlfaNumeric(ByVal strValue As String) As Boolean
        If strValue = Nothing Then Return False
        Dim regexstr As String = "^[A-Za-z0-9]+$"
        strValue = strValue.Trim()
        Dim pattern As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(regexstr)
        Return pattern.IsMatch(strValue)
    End Function

    Public Shared Function MatchChars(ByRef strValue As String) As Boolean
        If strValue = Nothing Then Return False
        Dim regexstr As String = "^[A-Za-z]+$"
        strValue = strValue.Trim()
        Dim pattern As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(regexstr)
        Return pattern.IsMatch(strValue)
    End Function

    Public Shared Function MatchNumber(ByRef strValue As String) As Boolean
        If strValue = Nothing Then Return False
        Dim regexstr As String = "^[0-9]+$"
        Dim pattern As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(regexstr)
        Return pattern.IsMatch(strValue)
    End Function

    Public Shared Function MatchExprMulti(ByVal strValue As String, ByVal strExpr() As String) As Boolean
        Dim pattern As System.Text.RegularExpressions.Regex
        Dim boolMatches As Boolean
        If strValue = Nothing Or strExpr Is Nothing Then Return False
        If Not strExpr.Length > 0 Then Return False
        For Each strItem As String In strExpr
            pattern = New System.Text.RegularExpressions.Regex(strItem)
            If Not pattern.IsMatch(strValue) Then
                boolMatches = False
                Exit For
            End If
        Next
        Return boolMatches
    End Function

    Public Shared Function MatchExpr(ByVal strValue As String, ByVal strExpr As String) As Boolean
        If strValue = Nothing Or strExpr = Nothing Then Return False
        Dim pattern As New System.Text.RegularExpressions.Regex(strExpr)
        Return pattern.IsMatch(strValue)
    End Function

    Public Shared Function TextStripNullCharsToChar(ByRef strText As String, ByVal strReplaceChar As String) As String
        If strText = Nothing Then Return strText
        Return System.Text.RegularExpressions.Regex.Replace(strText, "(\s+)", strReplaceChar)
    End Function

    Public Shared Function TextStripNullCharsButSpace(ByRef strText As String) As String
        If strText = Nothing Then Return strText
        strText = strText.Replace(" ", "[{s}]")
        strText = System.Text.RegularExpressions.Regex.Replace(strText, "(\s+)", "")
        strText = strText.Replace("[{s}]", " ")
        Return strText
    End Function

    Public Shared Function TextStripNullChars(ByRef strText As String) As String
        If Trim(strText) = Nothing Then Return Nothing
        Return System.Text.RegularExpressions.Regex.Replace(strText, "(\s+)", "")
    End Function

    Public Shared Function TextReplaceExprWithConstant(ByVal strText As String, ByVal strExpr As String, ByVal strRepl As String) As String
        If strText = Nothing Then Return strText
        Return System.Text.RegularExpressions.Regex.Replace(strText, strExpr, strRepl)
        ' Ejemplo: RegularExpressionParser.TextReplaceExprWithConstant("10,20,30,40", "\d+", "0")
    End Function

    Public Shared Function TextStripNonAlphaButSpace(ByVal strText As String) As String
        If strText = Nothing Then Return strText
        Return TextReplaceExprWithConstant(strText, "[^\w ]", "")
    End Function

    Public Shared Function TextQueryStringMaskPlus(ByVal strText As String, Optional ByVal boolEQ As Boolean = True) As String
        If strText = Nothing Then Return strText
        strText = TextQueryStringMask(strText, boolEQ)
        strText = strText.Replace("+", "_mas_")
        Return strText
    End Function

    Public Shared Function TextQueryStringUnMaskPlus(ByVal strText As String) As String
        If strText = Nothing Then Return strText
        strText = TextQueryStringUnMask(strText)
        strText = strText.Replace("_mas_", "+")
        Return strText
    End Function

    Public Shared Function TextQueryStringMask(ByVal strText As String, Optional ByVal boolEQ As Boolean = True) As String
        If strText = Nothing Then Return strText
        strText = strText.Replace("&", "_A.N.D._")
        If boolEQ Then strText = strText.Replace("=", "_E.Q._")
        Return strText
    End Function

    Public Shared Function TextQueryStringUnMask(ByVal strText As String) As String
        If strText = Nothing Then Return strText
        Return strText.Replace("_A.N.D._", "&").Replace("_E.Q._", "=")
    End Function

    Public Shared Function TextCsvCleanup(ByVal strText As String) As String
        strText = RegularExpressionParser.TextReplaceExprWithConstant(strText, "\""", "`")
        strText = RegularExpressionParser.TextReplaceExprWithConstant(strText, "~", "-")
        strText = RegularExpressionParser.TextReplaceExprWithConstant(strText, "(\s+)", " ")
        Return strText
    End Function

    Public Shared Function TextGetIntegerPartFromString(ByVal strText As String) As String
        If strText Is Nothing Then Return "0"
        '........
        Dim iCount As Short
        Dim arrChars As Char() = strText
        Dim chrChar As Char
        Dim strResult As String = String.Empty
        For iCount = 0 To arrChars.Length - 1 Step 1
            chrChar = arrChars(iCount)
            If IsNumeric(chrChar) Then
                strResult &= chrChar
            Else
                Exit For
            End If
        Next
        If strResult = Nothing Then
            strResult = "0"
        End If
        Return strResult
    End Function

    Public Shared Function DateStringUStoDate(ByVal strDate As String) As Date
        If strDate = Nothing Then Return Nothing
        Dim arrDateStr As String()
        Try
            arrDateStr = strDate.Split("/")
            'validate
            For Each strItem As String In arrDateStr
                If strItem = Nothing Or Not IsNumeric(strItem) Then
                    Return Nothing
                End If
            Next
            'just year
            If arrDateStr.Length = 1 Then
                Return New Date(arrDateStr(0), 12, System.DateTime.DaysInMonth(arrDateStr(0), 12))
            ElseIf arrDateStr.Length = 2 Then
                Return New Date(arrDateStr(1), arrDateStr(0), System.DateTime.DaysInMonth(arrDateStr(1), arrDateStr(0)))
            ElseIf arrDateStr.Length = 3 Then
                Return New Date(arrDateStr(2), arrDateStr(0), arrDateStr(1))
            End If
        Catch ex As Exception
            'Return Nothing
        End Try
        Return Nothing
    End Function

#End Region

End Class
