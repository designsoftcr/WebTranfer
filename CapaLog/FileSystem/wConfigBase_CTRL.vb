Imports System.Web.Caching

Public Class wConfigBase_CTRL
    Public Const STRID As String = "wConfigBase.xml"
    Private Const STRNAME = "wConfigBase"
    Private _oConfig As ConfigBaseType

#Region "ConfigBaseType properties"
    Public ReadOnly Property CFG_ConnectionString() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            Return GetConfig.CFG_ConnectionString
        End Get
    End Property

    Public ReadOnly Property CFG_ConnectionString2() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            Return GetConfig.CFG_ConnectionString2
        End Get
    End Property

    Public ReadOnly Property CFG_ConnectionString3() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            Return GetConfig.CFG_ConnectionString3
        End Get
    End Property

    Public ReadOnly Property CFG_HttpPostTimeLong() As Integer
        Get
            If GetConfig() Is Nothing Then Return 120000
            If GetConfig.CFG_HttpPostTimeLong Is Nothing Then Return 120000
            If GetConfig.CFG_HttpPostTimeLong.Equals(String.Empty) Then Return 120000
            Return Integer.Parse(GetConfig.CFG_HttpPostTimeLong)
        End Get
    End Property

    Public ReadOnly Property CFG_HttpPostTimeNormal() As Integer
        Get
            If GetConfig() Is Nothing Then Return 100000
            If GetConfig.CFG_HttpPostTimeLong Is Nothing Then Return 100000
            If GetConfig.CFG_HttpPostTimeLong.Equals(String.Empty) Then Return 100000
            Return Integer.Parse(GetConfig.CFG_HttpPostTimeLong)
        End Get
    End Property

    Public ReadOnly Property CFG_HttpPostTimeShort() As Integer
        Get
            If GetConfig() Is Nothing Then Return 80000
            If GetConfig.CFG_HttpPostTimeLong Is Nothing Then Return 80000
            If GetConfig.CFG_HttpPostTimeLong.Equals(String.Empty) Then Return 80000
            Return Integer.Parse(GetConfig.CFG_HttpPostTimeLong)
        End Get
    End Property

    Public ReadOnly Property CFG_HttpPostTimeMin() As Integer
        Get
            If GetConfig() Is Nothing Then Return 150000
            If GetConfig.CFG_HttpPostTimeLong Is Nothing Then Return 15000
            If GetConfig.CFG_HttpPostTimeLong.Equals(String.Empty) Then Return 15000
            Return Integer.Parse(GetConfig.CFG_HttpPostTimeLong)
        End Get
    End Property

    Public ReadOnly Property CFG_SmtpServer() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_SmtpServer Is Nothing Then Return Nothing
            If GetConfig.CFG_SmtpServer.Equals(String.Empty) Then Return Nothing
            Return GetConfig.CFG_SmtpServer
        End Get
    End Property

    Public ReadOnly Property CFG_SqlExecutionTimeout() As Integer
        Get
            If GetConfig() Is Nothing Then Return 30
            If GetConfig.CFG_SqlExecutionTimeout Is Nothing Then Return 30
            If GetConfig.CFG_SqlExecutionTimeout.Equals(String.Empty) Then Return 30
            Return Integer.Parse(GetConfig.CFG_SqlExecutionTimeout)
        End Get
    End Property

    Public ReadOnly Property CFG_LogsPath() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_LogsPath Is Nothing Then Return Nothing
            If GetConfig.CFG_LogsPath.Equals(String.Empty) Then Return Nothing
            Return GetConfig.CFG_LogsPath
        End Get
    End Property

    Public ReadOnly Property CFG_AddToTextFile() As Boolean
        Get
            If GetConfig() Is Nothing Then Return True
            If GetConfig.CFG_AddToTextFile Is Nothing Then Return True
            If Not GetConfig.CFG_AddToTextFile.ToUpper.Equals("FALSE") Then Return True Else Return False
        End Get
    End Property

    Public ReadOnly Property CFG_EncryptionKey() As String
        Get
            Dim strKey As String = "Aratours Amidala Skywalker"
            If GetConfig() Is Nothing Then Return strKey
            If GetConfig.CFG_EncryptionKey Is Nothing Then Return strKey
            If GetConfig.CFG_EncryptionKey.Equals(String.Empty) Then Return strKey
            Return GetConfig.CFG_EncryptionKey
        End Get
    End Property

    Public ReadOnly Property CFG_EncryptionAux() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_EncryptionKeyAux Is Nothing Then Return Nothing
            Return GetConfig.CFG_EncryptionKeyAux
        End Get
    End Property

    Public ReadOnly Property CFG_EncryptionNum() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_EncryptionKeyNum Is Nothing Then Return Nothing
            Return GetConfig.CFG_EncryptionKeyNum
        End Get
    End Property

    'days
    Public ReadOnly Property CFG_ExpiresLong() As Integer
        Get
            If GetConfig() Is Nothing Then Return 7
            If GetConfig.CFG_ExpiresLong Is Nothing Then Return 7
            If GetConfig.CFG_ExpiresLong.Equals(String.Empty) Then Return 7
            Return Integer.Parse(GetConfig.CFG_ExpiresLong)
        End Get
    End Property

    'days
    Public ReadOnly Property CFG_ExpiresShort() As Integer
        Get
            If GetConfig() Is Nothing Then Return 2
            If GetConfig.CFG_ExpiresShort Is Nothing Then Return 2
            If GetConfig.CFG_ExpiresShort.Equals(String.Empty) Then Return 2
            Return Integer.Parse(GetConfig.CFG_ExpiresShort)
        End Get
    End Property

    'days
    Public ReadOnly Property CFG_DaysReport() As Integer
        Get
            If GetConfig() Is Nothing Then Return 1
            If GetConfig.CFG_DaysReport Is Nothing Then Return 1
            If GetConfig.CFG_DaysReport.Equals(String.Empty) Then Return 1
            Return Integer.Parse(GetConfig.CFG_DaysReport)
        End Get
    End Property

    Public ReadOnly Property CFG_BannedAccounts() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_BannedAccounts Is Nothing Then Return Nothing
            Return GetConfig.CFG_BannedAccounts
        End Get
    End Property

    Private _arrBannedCountries As String()

    Public ReadOnly Property CFG_BannedCountries() As String()
        Get
            If Not Me._arrBannedCountries Is Nothing Then
                Return Me._arrBannedCountries
            End If
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_BannedCountries = Nothing Then Return Nothing
            Return Me._arrBannedCountries
        End Get
    End Property

    Public ReadOnly Property CFG_Credentials() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_Credentials Is Nothing Then Return Nothing
            Return GetConfig.CFG_Credentials
        End Get
    End Property

    Public ReadOnly Property CFG_CheckAccess() As Boolean
        Get
            If GetConfig() Is Nothing Then Return True
            If GetConfig.CFG_CheckAccess Is Nothing Then Return True
            Return UCase(GetConfig.CFG_CheckAccess) = "TRUE"
        End Get
    End Property
    Public ReadOnly Property CFG_IdUser() As Integer
        Get
            If GetConfig() Is Nothing Then Return 0
            If GetConfig.CFG_IdUser Is Nothing Then Return 0
            If Not IsNumeric(GetConfig.CFG_IdUser) Then Return 0
            Return CInt(GetConfig.CFG_IdUser)
        End Get
    End Property

    Public ReadOnly Property CFG_DeferredDaysBack() As Integer
        Get
            If GetConfig() Is Nothing Then Return 15
            If GetConfig.CFG_DeferredDaysBack Is Nothing Then Return 15
            If Not IsNumeric(GetConfig.CFG_DeferredDaysBack) Then Return 15
            Return CInt(GetConfig.CFG_DeferredDaysBack)
        End Get
    End Property

    Public ReadOnly Property CFG_PromoCodes() As Boolean
        Get
            If GetConfig() Is Nothing Then Return False
            If GetConfig.CFG_PromoCodes Is Nothing Then Return False
            Return Boolean.Parse(GetConfig.CFG_PromoCodes)
        End Get
    End Property


    Public ReadOnly Property CFG_PublicProfiles() As Boolean
        Get
            If GetConfig() Is Nothing Then Return False
            If GetConfig.CFG_PublicProfiles Is Nothing Then Return False
            Return GetConfig.CFG_PublicProfiles.ToUpper.Equals("TRUE")
        End Get
    End Property
    Public ReadOnly Property CFG_AutoMenu() As Boolean
        Get
            If GetConfig() Is Nothing Then Return False
            If GetConfig.CFG_AutoMenu Is Nothing Then Return False
            Return GetConfig.CFG_AutoMenu.ToUpper.Equals("TRUE")
        End Get
    End Property
    Public ReadOnly Property CFG_PublicKey() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_PublicKey Is Nothing Then Return Nothing
            Return GetConfig.CFG_PublicKey
        End Get
    End Property
    Public ReadOnly Property CFG_PublicUsername() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_PublicUsername Is Nothing Then Return Nothing
            Return GetConfig.CFG_PublicUsername
        End Get
    End Property
    Public ReadOnly Property CFG_PublicPassword() As String
        Get
            If GetConfig() Is Nothing Then Return Nothing
            If GetConfig.CFG_PublicPassword Is Nothing Then Return Nothing
            Return GetConfig.CFG_PublicPassword
        End Get
    End Property

    Public ReadOnly Property CFG_PubExtOutIp() As String
        Get
            If GetConfig() Is Nothing Then Return "190.7.195.66"
            If GetConfig.CFG_PubExtOutIp = Nothing Then Return "190.7.195.66"
            Return GetConfig.CFG_PubExtOutIp
        End Get
    End Property
    Public ReadOnly Property CFG_NetUsr() As String
        Get
            If GetConfig() Is Nothing Then Return String.Empty
            If GetConfig.CFG_NetUsr = Nothing Then Return String.Empty
            Return GetConfig.CFG_NetUsr
        End Get
    End Property
    Public ReadOnly Property CFG_NetPwd() As String
        Get
            If GetConfig() Is Nothing Then Return String.Empty
            If GetConfig.CFG_NetPwd = Nothing Then Return String.Empty
            Return GetConfig.CFG_NetPwd
        End Get
    End Property
#End Region

    Public Sub New()
        Me._oConfig = New ApplicationManagement().GetConfigBase()
    End Sub

    Public Function IsCountryBanned(ByVal strCtry As String) As Boolean
        Dim arrBannedCountries As String() = Me.CFG_BannedCountries
        If Not strCtry Is Nothing Then strCtry = Trim(strCtry)
        If arrBannedCountries Is Nothing Then Return False
        If arrBannedCountries.Length = 0 Then Return False
        Return (Array.IndexOf(arrBannedCountries, strCtry) >= 0 And strCtry <> Nothing)
    End Function

    Private Function GetConfig() As ConfigBaseType
        Return _oConfig
    End Function

End Class