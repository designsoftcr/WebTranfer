Imports System.Web
Imports System.IO


Public Class FileAppendLog
    Private Const DefaultAddToFile As Boolean = True

    Public Shared Sub AddToFile(ByVal line As String)
        Dim path As String = System.Configuration.ConfigurationManager.AppSettings.Item("LogsPath") & "transCashierInterface.Log.txt"

        ' This text is added onl once to the file.
        ' This text is always added, making the file longer over time
        ' if it is not deleted.
        Try
            FileRead.WriteFile(line, path)
        Catch ex As Exception
            'do nothing
        Finally
            'do nothing
        End Try
    End Sub
    Public Shared Sub AddToLogFile(ByVal line As String, Optional ByVal iseverity As Integer = Log.LEVEL_INFO, Optional ByVal Username As String = "")
        Dim strDirectory As String
        Dim StrFile As String
        Try
            If GetAddToFile.Equals(True) And Not (InStr(line, Log.THREAD_ABORT_EXC) > 0) Then
                strDirectory = System.Configuration.ConfigurationManager.AppSettings("LogsPath")
                Dim strDate As String = Date.Now
                If strDate <> Nothing Then
                    strDate = strDate.Replace("/", "_").Replace(":", "_").Replace(".", "_").Replace(" ", "_")
                End If
                Select Case (iseverity)
                    Case Log.LEVEL_WARN
                        StrFile = strDirectory & "logWN-" & DateString & "-Hour-" & strDate & ".txt"
                    Case Log.LEVEL_WSERVICE
                        StrFile = strDirectory & "logWService-" & DateString & "-Hour-" & strDate & ".txt"
                    Case Log.LEVEL_USER
                        StrFile = strDirectory & Username & "_" & DateString & ".txt"
                    Case Log.LEVEL_EMAIL
                        StrFile = strDirectory & "logEM-" & DateString & "-Hour-" & Hour(Now) & ".txt"
                    Case Log.LEVEL_EMAIL
                        StrFile = strDirectory & "logEMFAIL-" & DateString & ".txt"
                    Case Log.LEVEL_LYONS
                        StrFile = String.Format("{0}{1}\", strDirectory, "LYONS_LOGS")
                        StrFile = StrFile & "logLY-" & Username & "-Hour-" & strDate & ".txt"
                    Case Else
                        StrFile = strDirectory & "log-" & DateString & "-Hour-" & Hour(Now) & ".txt"
                End Select
                'First Check if the directory exist
                If DirectoryExist(strDirectory) = True Then
                    ' This text is added only once to the file.
                    FileRead.WriteFile(line, StrFile)
                End If
            End If
        Catch ex As Exception
            'do nothing
        Finally
            'do nothing
        End Try
    End Sub

    Public Shared Function DirectoryExist(ByVal strDirectory As String) As Boolean
        'Dim sw As StreamWriter
        If Directory.Exists(strDirectory) = False Then
            'Create the directory
            Try
                Directory.CreateDirectory(strDirectory)
                Return True
            Catch ex As Exception
                Return False
            End Try
        Else
            Return True
        End If
    End Function

    '' ''Public Shared Function FileExist(ByVal Path) As Boolean
    '' ''    Dim sw As StreamWriter
    '' ''    Try
    '' ''        If File.Exists(Path) = False Then
    '' ''            ' Create a file to write to.
    '' ''            sw = File.CreateText(Path)
    '' ''            'sw.WriteLine("TRANSACTION LOG" & vbCrLf & vbCrLf)
    '' ''            Return True
    '' ''        Else
    '' ''            Return True
    '' ''        End If
    '' ''    Catch ex As Exception
    '' ''        'do nothing
    '' ''        Return False
    '' ''    Finally
    '' ''        If Not sw Is Nothing Then
    '' ''            sw.Flush()
    '' ''            sw.Close()
    '' ''            sw = Nothing
    '' ''        End If
    '' ''    End Try
    '' ''End Function

    Public Shared Function GetAddToFile() As Boolean
        Dim oXmlHandler As New wConfigBase_CTRL
        'Dim oConfig As ConfigBaseType
        Try
            Return oXmlHandler.CFG_AddToTextFile
            'oConfig = oXmlHandler.GetConfig
            'If Not oConfig Is Nothing Then
            '    If Not oConfig.CFG_AddToTextFile Is Nothing Then
            '        Return Boolean.Parse(oConfig.CFG_AddToTextFile)
            '    End If
            'End If
        Catch ex As Exception
            'do nothing
        Finally
            oXmlHandler = Nothing
            'oConfig = Nothing
        End Try
        Return DefaultAddToFile
    End Function

    '' ''Public Shared Sub StreamWrite(ByRef streamR As System.IO.Stream, ByVal path As String)
    '' ''    ' si no se ha indicado el directorio, usar el actual
    '' ''    If path.Equals(String.Empty) Then path = System.Web.HttpContext.Current.Server.MapPath(".") & "file.zip"

    '' ''    Dim size As Integer = streamR.Length
    '' ''    Dim abyBuffer(Convert.ToInt32(size - 1)) As Byte
    '' ''    Dim streamWriter As FileStream

    '' ''    Try
    '' ''        streamWriter = File.Create(path)
    '' ''    Catch ex As Exception
    '' ''        'do nothing for now
    '' ''    End Try

    '' ''    'Dim data(2048) As Byte
    '' ''    'Do
    '' ''    size = streamR.Read(abyBuffer, 0, abyBuffer.Length)
    '' ''    If (size > 0) Then
    '' ''        streamWriter.Write(abyBuffer, 0, size)
    '' ''        'Else
    '' ''        '    Exit Do
    '' ''    End If
    '' ''    'Loop
    '' ''    streamWriter.Close()
    '' ''    streamR.Close()
    '' ''End Sub


    ' ''Public Shared Sub StreamWrite(ByRef streamR As System.IO.Stream, ByVal Path As String)
    ' ''    If Path.Equals(String.Empty) Then Path = System.Web.HttpContext.Current.Server.MapPath(".") & "file.zip"
    ' ''    Dim wrtr As FileStream
    ' ''    Dim inData(4096) As Byte
    ' ''    Dim bytesRead As Integer
    ' ''    Try
    ' ''        wrtr = New FileStream(Path, FileMode.Create)
    ' ''        bytesRead = streamR.Read(inData, 0, inData.Length)
    ' ''        While bytesRead > 0
    ' ''            wrtr.Write(inData, 0, bytesRead)
    ' ''            bytesRead = streamR.Read(inData, 0, inData.Length)
    ' ''        End While
    ' ''    Catch ex As Exception
    ' ''        'do nothing
    ' ''    Finally
    ' ''        If Not wrtr Is Nothing Then
    ' ''            wrtr.Close()
    ' ''            wrtr = Nothing
    ' ''        End If
    ' ''        If Not streamR Is Nothing Then
    ' ''            streamR.Close()
    ' ''            streamR = Nothing
    ' ''        End If
    ' ''    End Try
    ' ''End Sub


    ' ''Public Shared Sub UnzipFile(ByVal DirUnzip As String, _
    ' ''                            ByVal FileNameUnzip As String, _
    ' ''                            ByVal FileType As String, _
    ' ''                            ByVal Dir_NewUnzip As String, _
    ' ''                            ByVal FileName_NewUnzip As String, _
    ' ''                            ByVal FileType_NewFile As String, _
    ' ''                            Optional ByVal DeleteFile As Boolean = False)
    ' ''    Dim z As ZipInputStream
    ' ''    Dim theEntry As ZipEntry
    ' ''    Dim streamWriter As FileStream
    ' ''    Dim size As Integer
    ' ''    Dim data(2048) As Byte
    ' ''    Try
    ' ''        z = New ZipInputStream(File.OpenRead(DirUnzip & "\" & FileNameUnzip & FileType))
    ' ''        Do
    ' ''            theEntry = z.GetNextEntry()
    ' ''            If Not theEntry Is Nothing Then
    ' ''                Dim fileName As String
    ' ''                If (FileName_NewUnzip = Nothing) Then
    ' ''                    fileName = Dir_NewUnzip & "\" & Path.GetFileName(theEntry.Name)
    ' ''                Else
    ' ''                    fileName = Dir_NewUnzip & "\" & FileName_NewUnzip & FileType_NewFile
    ' ''                End If
    ' ''                streamWriter = File.Create(fileName)
    ' ''                Do
    ' ''                    size = z.Read(data, 0, data.Length)
    ' ''                    If (size > 0) Then
    ' ''                        streamWriter.Write(data, 0, size)
    ' ''                    Else
    ' ''                        Exit Do
    ' ''                    End If
    ' ''                Loop
    ' ''            Else
    ' ''                Exit Do
    ' ''            End If
    ' ''        Loop
    ' ''        If DeleteFile Then
    ' ''            File.Delete(DirUnzip & "\" & FileNameUnzip & FileType)
    ' ''        End If
    ' ''    Catch ex As DirectoryNotFoundException
    ' ''        Exit Sub
    ' ''    Catch ex As Exception
    ' ''        'do nothing
    ' ''    Finally
    ' ''        If Not z Is Nothing Then
    ' ''            z.Close()
    ' ''            z = Nothing
    ' ''        End If
    ' ''        theEntry = Nothing
    ' ''        If Not streamWriter Is Nothing Then
    ' ''            streamWriter.Close()
    ' ''            streamWriter = Nothing
    ' ''        End If
    ' ''    End Try
    ' ''End Sub

End Class