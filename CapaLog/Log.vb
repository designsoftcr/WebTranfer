Imports System.Configuration
Imports System.IO

Public Class Log

    Public Const LEVEL_WARN = 0
    Public Const LEVEL_DEBUG = 1
    Public Const LEVEL_TRACE = 2
    Public Const LEVEL_INFO = 3
    Public Const LEVEL_USER = 4
    Public Const LEVEL_EMAIL = 5
    Public Const LEVEL_LYONS = 6
    Public Const LEVEL_EMAILFAIL = 7
    Public Const LEVEL_WSERVICE = 8
    Public Const THREAD_ABORT_EXC = "System.Threading.ThreadAbortException"

    Public Enum LogType
        FileLog = 1
        EventLog = 2
    End Enum

    Private Shared Sub appendToLog(ByVal iSeverityLevel As Integer, _
                                   ByVal strMessage As String, _
                                   ByVal strStackTrace As String, _
                                   Optional ByVal intLogtype As LogType = LogType.EventLog)

        Dim strLogSource As String = "Falcon Products"
        If System.Configuration.ConfigurationManager.AppSettings("LOG_SOURCE") <> Nothing Then
            strLogSource = System.Configuration.ConfigurationManager.AppSettings("LOG_SOURCE").ToString() ' "Cashier"
        End If


        If intLogtype = LogType.EventLog _
        And iSeverityLevel <> LEVEL_INFO _
        And iSeverityLevel <> LEVEL_TRACE _
        And iSeverityLevel <> LEVEL_WARN _
        And iSeverityLevel <> LEVEL_EMAILFAIL Then
            Const LOG_NAME As String = "Application"
            Static LOG_SOURCE As String = strLogSource 'System.Configuration.ConfigurationManager.AppSettings("LOG_SOURCE").ToString() ' "Cashier"
            Dim eLog As New EventLog
            Dim FormattedMessage As String = String.Empty

            Try
                FormattedMessage &= strMessage & vbCrLf & strStackTrace & vbCrLf
                If Not (InStr(FormattedMessage, THREAD_ABORT_EXC) > 0) Then
                    'Checks that the event source exists.
                    If Not EventLog.SourceExists(LOG_SOURCE) Then
                        EventLog.CreateEventSource(LOG_SOURCE, LOG_NAME)
                        Console.WriteLine("CreatingEventSource")
                    End If
                    eLog.Log = LOG_NAME
                    eLog.Source = LOG_SOURCE
                    Select Case iSeverityLevel
                        Case LEVEL_WARN
                            eLog.WriteEntry(FormattedMessage, EventLogEntryType.Warning)
                        Case LEVEL_INFO, LEVEL_TRACE
                            eLog.WriteEntry(FormattedMessage, EventLogEntryType.Information)
                        Case LEVEL_DEBUG
                            eLog.WriteEntry(FormattedMessage, EventLogEntryType.Error)
                    End Select
                    eLog.Close()
                    eLog = Nothing
                End If
            Catch exc As System.ComponentModel.Win32Exception
                'do nothing
            Finally
                If Not eLog Is Nothing Then eLog.Dispose()
            End Try
        Else
            FileAppendLog.AddToLogFile(String.Concat("Date: ", Now(), " Message: ", strMessage, " Strack Trace: ", strStackTrace), iSeverityLevel)
        End If
    End Sub

    Public Shared Function DifferentBettwenDateTime(ByVal dFechaVencimiento As Date) As Integer

        Dim iTimeLeft As Integer = DateDiff(DateInterval.DayOfYear, Now.Date, dFechaVencimiento.Date)
        Return iTimeLeft

    End Function



    Public Shared Sub AppendToLog(ByRef sql As SqlClient.SqlCommand)

        If sql Is Nothing Then Return
        If sql.Parameters Is Nothing Then Return
        If sql.Parameters.Count = 0 Then Return

        Dim Parameters As String = String.Empty
        Dim Parameter As SqlClient.SqlParameter

        For Each Parameter In sql.Parameters
            If Not Parameter.Value Is Nothing Then Parameters &= "|" & Parameter.ParameterName & "=" & Parameter.Value
        Next

        appendToLog(Log.LEVEL_DEBUG, sql.CommandText & Parameters)
    End Sub

    Public Shared Sub appendToLog(ByVal SeverityLevel As Integer, ByVal Message As String)

        Message = " [ This is trace information only, not an exception ] " & Message
        appendToLog(SeverityLevel, Message, New StackTrace(True).ToString)
    End Sub

    Public Shared Sub appendToLog(ByVal ex As Exception)

        If Not ex Is Nothing Then
            appendToLog(Log.LEVEL_DEBUG, ex.ToString(), ex.StackTrace.ToString())
        End If

    End Sub

    Public Shared Sub appendToLog(ByVal Username As String, ByVal Location As String)

        FileAppendLog.AddToLogFile(String.Concat("Date: ", Now(), vbCrLf, "Location: ", Location), Log.LEVEL_USER, Username)

    End Sub
    Public Shared Function readLog() As String
        Return String.Empty
    End Function

End Class
