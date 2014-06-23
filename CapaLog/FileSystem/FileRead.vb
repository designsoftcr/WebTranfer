Option Strict On
Option Explicit On

Imports System
Imports System.IO

Public Class FileRead

    Public Function GetFileContent(ByVal fileCompletePath As String) As String
        Dim objStreamReader As StreamReader
        Dim contents As String
        objStreamReader = Nothing
        Try
            If Not File.Exists(fileCompletePath) Then Return String.Empty
            objStreamReader = File.OpenText(fileCompletePath)
            contents = objStreamReader.ReadToEnd()
        Catch ex As Exception
            Log.appendToLog(Log.LEVEL_WARN, "This resource is not available: " & fileCompletePath)
            contents = String.Empty
        Finally
            If Not objStreamReader Is Nothing Then objStreamReader.Close()
            objStreamReader = Nothing
        End Try
        If contents Is Nothing Then
            contents = String.Empty
        End If
        Return contents
    End Function

    ' ''Public Function GetExistingFile(ByVal strFilePath As String, ByVal strFileName As String, ByVal strExtension As String, Optional ByVal boolAddLang As Boolean = True) As String
    ' ''    Dim strLangBase As String = String.Empty
    ' ''    Dim strFile As String = strFileName & strExtension
    ' ''    Dim strLang As String = LngMisc.GetLang
    ' ''    Dim strResult As String = String.Empty
    ' ''    Dim strLangFile As String = strFileName & "_" & strLang & strExtension
    ' ''    Dim strPre As String = String.Empty
    ' ''    If strLang = CashierInterface.LngMisc.LANG_EN_US Then Return strFile

    ' ''    strPre = Left(strLang, 2)
    ' ''    Select Case strPre
    ' ''        Case "es"
    ' ''            strLangBase = "es-ES"
    ' ''        Case "en"
    ' ''            strLangBase = "en-US"
    ' ''        Case "zh"
    ' ''            strLangBase = "zh-CN"
    ' ''        Case "ar"
    ' ''            strLangBase = "ar-SA"
    ' ''    End Select

    ' ''    strResult = strFile
    ' ''    If File.Exists(strFilePath & strLangFile) And boolAddLang Then
    ' ''        strResult = strLangFile
    ' ''    ElseIf strLangBase <> Nothing Then
    ' ''        strLangBase = strFileName & "_" & strLangBase & strExtension
    ' ''        If File.Exists(strFilePath & strLangBase) And boolAddLang Then
    ' ''            strResult = strLangBase
    ' ''        End If
    ' ''    End If
    ' ''    Return strResult
    ' ''End Function

    ' ''Public Function GetContentText(ByVal strCacheLabel As String, Optional ByVal strExtension As String = ".html", Optional ByRef oParseObject As ParseInfo = Nothing, Optional ByVal boolParseKeys As Boolean = True, Optional ByVal strDir As String = "", Optional ByVal boolUseAppSession As Boolean = False, Optional ByVal boolAddLang As Boolean = True) As String
    ' ''    'strDir Examples:   "Methods", "Methods\temp"
    ' ''    Dim oFileCache As New FileCache
    ' ''    Dim strFilePath As String
    ' ''    Dim oContent As Object
    ' ''    Dim strFileName As String = String.Empty
    ' ''    Dim strReset As String
    ' ''    Dim strContent As String
    ' ''    Try
    ' ''        If Not InStr(strDir, ":\") > 0 Then
    ' ''            strFilePath = SessionManager.GetHtmlsPath
    ' ''        End If
    ' ''        If Trim(strDir) <> Nothing Then
    ' ''            strFilePath &= strDir & "\"
    ' ''        End If
    ' ''        strFileName = Me.GetExistingFile(strFilePath, strCacheLabel, strExtension, boolAddLang)
    ' ''        strFilePath = strFilePath & strFileName
    ' ''        oContent = oFileCache.GetCacheContent(strFileName)
    ' ''        strReset = Trim(String.Format("{0}", System.Web.HttpContext.Current.Session("RESET")))
    ' ''        If UCase(strReset) <> "TRUE" And UCase(strReset) <> "FALSE" Then strReset = "False"
    ' ''        If oContent Is Nothing _
    ' ''            Or Boolean.Parse(strReset) _
    ' ''            Then
    ' ''            oContent = Me.GetFileContent(strFilePath)
    ' ''            oFileCache.SetCacheContent(strCacheLabel, oContent)
    ' ''        End If

    ' ''        If Not oContent Is Nothing Then
    ' ''            If boolParseKeys Then
    ' ''                strContent = oContent.ToString
    ' ''                Dim objOParseObject As Object = CObj(oParseObject)
    ' ''                CashierInterface.WebAppTools.ParseKeywords(strContent, objOParseObject)
    ' ''                oParseObject = CType(objOParseObject, CashierInterface.ParseInfo)
    ' ''                objOParseObject = Nothing
    ' ''            Else
    ' ''                strContent = oContent.ToString()
    ' ''            End If
    ' ''        End If
    ' ''    Catch ex As Exception
    ' ''        CashierInterface.Log.appendToLog(ex)
    ' ''    End Try
    ' ''    If strContent Is Nothing Then strContent = String.Empty
    ' ''    Return strContent
    ' ''End Function

    Public Shared Sub WriteFile(ByVal line As String, ByVal strFileName As String)
        'Dim path As String = HttpContext.Current.Request.PhysicalApplicationPath & "transCashierInterface.Log.txt"
        Dim FileStream As FileStream = Nothing
        Dim StreamWriter As StreamWriter = Nothing

        Try
            FileStream = New FileStream(Path:=strFileName, _
               mode:=FileMode.OpenOrCreate, access:=FileAccess.Write)

            'create an instance of a character writer 
            StreamWriter = New StreamWriter(Stream:=FileStream)
            StreamWriter.AutoFlush = True

            'set the file pointer to the end of the file 
            StreamWriter.BaseStream.Seek(offset:=0, origin:=SeekOrigin.End)
            StreamWriter.Write(value:=line)
        Catch ex As Exception
            'do nothing
        Finally
            If Not StreamWriter Is Nothing Then
                StreamWriter.Flush()
                StreamWriter.Close()
                StreamWriter = Nothing
            End If
            If Not FileStream Is Nothing Then
                FileStream.Close()
                FileStream = Nothing
            End If
        End Try
    End Sub

    ' ''Public Shared Sub WriteFilefromBegin(ByVal line As String, ByVal strFileName As String)
    ' ''    'Dim path As String = HttpContext.Current.Request.PhysicalApplicationPath & "transCashierInterface.Log.txt"
    ' ''    Dim FileStream As FileStream
    ' ''    Dim StreamWriter As StreamWriter

    ' ''    Try
    ' ''        FileStream = New FileStream(Path:=strFileName, _
    ' ''           mode:=FileMode.Create, access:=FileAccess.Write)

    ' ''        'create an instance of a character writer 
    ' ''        StreamWriter = New StreamWriter(Stream:=FileStream)
    ' ''        StreamWriter.AutoFlush = True

    ' ''        'set the file pointer to the end of the file 
    ' ''        StreamWriter.BaseStream.Seek(offset:=0, origin:=SeekOrigin.Begin)
    ' ''        StreamWriter.Write(value:=line)
    ' ''    Catch ex As Exception
    ' ''        'do nothing
    ' ''    Finally
    ' ''        If Not StreamWriter Is Nothing Then
    ' ''            StreamWriter.Flush()
    ' ''            StreamWriter.Close()
    ' ''            StreamWriter = Nothing
    ' ''        End If
    ' ''        If Not FileStream Is Nothing Then
    ' ''            FileStream.Close()
    ' ''            FileStream = Nothing
    ' ''        End If
    ' ''    End Try
    ' ''End Sub

    '' ''Copy all resources files from folder to folder
    ' ''Public Shared Sub CopyFiles()
    ' ''    Dim SessionManag As SessionManager = New SessionManager
    ' ''    Dim server As String = SessionManag.GetConfigValue("LangServer")
    ' ''    Dim User As String
    ' ''    Dim Pass As String
    ' ''    Dim strLantPath As String = SessionManag.GetConfigValue("LangPath")
    ' ''    User = New wConfigBase_CTRL().CFG_NetUsr
    ' ''    Pass = New wConfigBase_CTRL().CFG_NetPwd
    ' ''    User = New Encryption_Routines().DecryptString128Bit(User, New wConfigBase_CTRL().CFG_EncryptionKey)
    ' ''    Pass = New Encryption_Routines().DecryptString128Bit(Pass, New wConfigBase_CTRL().CFG_EncryptionKey)

    ' ''    If Not CashierInterface.FileRead.MapDrive("P:", server, User, Pass) Or strLantPath = Nothing Then
    ' ''        CashierInterface.Log.appendToLog(CashierInterface.Log.LEVEL_DEBUG, vbCrLf & "Email Resources not configured properly for Email copying")
    ' ''        Exit Sub
    ' ''    End If
    ' ''    Dim DirOrigen As String = "P:\" + strLantPath
    ' ''    Dim Destino As String = SessionManager.GetHtmlsPath
    ' ''    Dim FileNmae As String = Nothing
    ' ''    Dim boolOver As Boolean = True
    ' ''    Try
    ' ''        For Each f As String In Directory.GetFiles(DirOrigen)
    ' ''            Dim i As Integer = f.Length - 1
    ' ''            While i > 0
    ' ''                If f.Chars(i) = "\" Then
    ' ''                    Exit While
    ' ''                End If
    ' ''                FileNmae = f.Chars(i) & FileNmae
    ' ''                i = i - 1
    ' ''            End While
    ' ''            Dim DirDestino As String = Destino & FileNmae
    ' ''            'Dim DirDestino As String = "P:\Program Files\GraphicomSoluciones\Resources\temp\" & FileNmae
    ' ''            FileNmae = Nothing
    ' ''            File.Copy(f, DirDestino, boolOver)
    ' ''        Next
    ' ''    Catch ex As Exception
    ' ''        CashierInterface.Log.appendToLog(ex)
    ' ''    End Try
    ' ''End Sub

    ' ''Public Declare Function WNetAddConnection2 Lib "mpr.dll" Alias "WNetAddConnection2A" (ByVal netResource As NETRESOURCE, _
    ' ''ByVal password As [String], ByVal Username As [String], _
    ' ''ByVal Flag As Integer) As Integer

    ' ''Public Shared Function MapDrive(ByVal pLocalName As String, ByVal pRemoteName As String, ByVal pUsername As String, ByVal pPassword As String) As Boolean
    ' ''    If Trim(pLocalName) = Nothing Or Trim(pRemoteName) = Nothing Or Trim(pUsername) = Nothing Or Trim(pPassword) = Nothing Then
    ' ''        Return False
    ' ''    End If
    ' ''    Dim myNetResource As New NETRESOURCE
    ' ''    Dim ret As Integer
    ' ''    Try
    ' ''        myNetResource.dwScope = 2 'RESOURCE_GLOBALNET
    ' ''        myNetResource.dwType = 1 'RESOURCETYPE_DISK
    ' ''        myNetResource.dwDisplayType = 3 'RESOURCEDISPLAYTYPE_SHARE
    ' ''        myNetResource.dwUsage = 1 'RESOURCEUSAGE_CONNECTABLE
    ' ''        myNetResource.LocalName = pLocalName
    ' ''        myNetResource.RemoteName = pRemoteName
    ' ''        myNetResource.Provider = Nothing
    ' ''        ret = WNetAddConnection2(myNetResource, pPassword, pUsername, 0)
    ' ''    Catch ex As Exception
    ' ''        Return False
    ' ''    End Try
    ' ''    Return True
    ' ''End Function
End Class
