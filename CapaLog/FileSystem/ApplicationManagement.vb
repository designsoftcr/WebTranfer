
Public Class ApplicationManagement

    Public Sub New()
        'do nothing for now
    End Sub

    Public Function GetConfigBase() As ConfigBaseType
        Dim objConfigBase As Object = System.Configuration.ConfigurationManager.AppSettings.Item("ConfigBase")
        If Not objConfigBase Is Nothing Then Return CType(objConfigBase, ConfigBaseType)
        Return Nothing
    End Function

    Public Shared Function EncryptionKey() As String
        Try

            Return New wConfigBase_CTRL().CFG_EncryptionKey

        Catch ex As Exception
            Log.appendToLog(Log.LEVEL_DEBUG, "error getting EncryptionKey from application")
            Return String.Empty
        End Try
    End Function

End Class