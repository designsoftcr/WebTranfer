Imports System.Configuration
Imports System.Web.SessionState
Imports System
<Serializable()> _
Public Class SessionUtilidades

    '**
    '<summary>
    '   Public Class SessionManager
    '   Every session variables, configuration variables, and application variables
    '   should be accesed only from this class. This should make your life easier since
    '   you will have a central place where to deal with session state, Application State and Web.Config. 
    '</summary>
    '*
    Public Const SESSION_PLAYER_CTRY = "PlayerCtry"
    Public Const SESSION_PLAYER_INSTANCE = "Player"
    Public Const SESSION_MYKEY = "Player_Key"
    Public Const SESSION_PLAYER_INSTANCE_PF = "Player_PF"
    Public Const SESSION_MYKEY_PF = "Player_Key_PF"

    Private Const SESSION_PLAYER_ID_IDENTIFIER = "PlayerID"
    Private Const SESSION_PLAYER_USERNAME_IDENTIFIER = "Username"
    Private Const SESSION_CITADEL_PLAYER_ID = "CitadelPlayerID"
    Public Const SESSION_FRONT_SETTINGS_INSTANCE = "Front Settings"
    Private Const SESSION_TRANSACTION_TYPE = "_Transaction_Types_"
    Private Const SESSION_TRANSACTION_STATUS = "Transaction Status"
    Private Const SESSION_SERIAL_REMAINING_DAYS = "Remaining Days"
    Private Const SESSION_IP = "SESSION_IP"
    Private Const SESSION_PROGRESS_COUNT_TIME = "Progress_Count_Time"
    Private Const SESSION_PROGRESS_COUNT = "Progress_iCount"
    'Private Const SESSION_DURATION_IN_MINUTES = 120

    'Administration Session Constants.
    Private Const SESSION_SYSTEM_USER_INSTANCE = "User"
    Private Const SESSION_TRANSTYPE = "TransType"

    'Types of Interfaces
    Private Const TypePublic As Char = "P"
    Private Const TypeAdmin As Char = "A"
    Private Const TypeUsers As Char = "U"
    Private Const TypeWService As Char = "W"

    Private Const GetIP_HostAddress As String = "Host"
    Private Const GetIP_X_FORWARDED As String = "X_FORWARDED"

    Private Const KEY_PROGRESS_COUNT As String = "ProgressCount"

    'Private stateSession As New System.Web.SessionState.StateRuntime

    Public Shared ReadOnly Property ServerName() As String
        Get
            Return System.Web.HttpContext.Current.Server.MachineName()
        End Get
    End Property

    'Public Shared ReadOnly Property UsesVIP() As Boolean
    '    Get
    '        Return ConfigurationManager.AppSettings.Item("UsesVIP") = "1"
    '    End Get
    'End Property

    Public Shared ReadOnly Property IsMSIEBrowser() As Boolean
        Get
            If System.Web.HttpContext.Current.Request Is Nothing Then Return False
            If System.Web.HttpContext.Current.Request.UserAgent Is Nothing Then Return False
            Return (System.Web.HttpContext.Current.Request.UserAgent.IndexOf("MSIE") >= 0)
        End Get
    End Property

    Public Shared ReadOnly Property IpIsXForward() As Boolean
        Get
            If Not System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR") Is Nothing Then Return True Else Return False
        End Get
    End Property

    Public Shared ReadOnly Property GetDomainName() As String
        Get
            Try
                If System.Web.HttpContext.Current.Request Is Nothing Then Return ""
                If System.Web.HttpContext.Current.Request.Url.AbsoluteUri Is Nothing Then Return ""
                Return System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Split("/")(2).ToString().Split(":")(0)
            Catch ex As Exception
                Return "N/A"
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property AutoMenu() As Boolean
        Get
            Return ConfigurationManager.AppSettings("AutoMenu") = "1"
            'sessionmanager.Force_IgnoreVIP
        End Get
    End Property

    Public Shared ReadOnly Property SendEmail() As Boolean
        Get
            If Not ConfigurationManager.AppSettings.HasKeys Then Return True
            If Not Array.IndexOf(ConfigurationManager.AppSettings.AllKeys, "SendEmail") >= 0 Then Return True
            Return (Not ConfigurationManager.AppSettings("SendEmail") = "0")
        End Get
    End Property


    Public Shared ReadOnly Property GetProgressCount_Time() As Integer
        Get
            Dim iCount As Integer = System.Web.HttpContext.Current.Session.Item(SESSION_PROGRESS_COUNT_TIME)
            If iCount = 0 Then
                ProgressCount_Refresh()
            End If
            If iCount = 0 Then
                iCount = CInt(System.Web.HttpContext.Current.Session.Item(SESSION_PROGRESS_COUNT_TIME))
            End If
            Return iCount
        End Get
    End Property
    Public Shared ReadOnly Property GetProgressCount() As Integer
        Get
            Dim iCount As Integer = System.Web.HttpContext.Current.Session.Item(SESSION_PROGRESS_COUNT)
            If iCount = 0 Then
                ProgressCount_Refresh()
            End If
            If iCount = 0 Then
                iCount = CInt(System.Web.HttpContext.Current.Session.Item(SESSION_PROGRESS_COUNT))
            End If
            Return iCount
        End Get
    End Property

    Public Shared ReadOnly Property CheckCountryBanned() As Boolean
        Get
            Try
                'Return New wConfig_CTRL().SITE_ChkCountryBann
                If Not ConfigurationManager.AppSettings("ChkCountryBann") Is Nothing Then
                    Return Boolean.Parse(ConfigurationManager.AppSettings("ChkCountryBann"))
                End If
            Catch ex As Exception
                CapaLog.Log.appendToLog(ex)
            End Try
            'CashierInterface.Log.appendToLog(CashierInterface.Log.LEVEL_INFO, "COUNTRYBANNING -2 b: FALSE")
            Return False
        End Get
    End Property

    Public Shared ReadOnly Property IsPopup() As Boolean
        Get
            If System.Web.HttpContext.Current.Request Is Nothing Then Return False
            If System.Web.HttpContext.Current.Request("IsPopup") Is Nothing Then Return False
            Return System.Web.HttpContext.Current.Request("IsPopup") = "1"
        End Get
    End Property

    Private ReadOnly Property ptrToPage() As System.Web.HttpContext
        Get
            'If Not _ptrToPage Is Nothing Then Return _ptrToPage
            Return System.Web.HttpContext.Current
        End Get
        'Set(ByVal Value As System.Web.UI.Page)
        '    _ptrToPage = Value
        'End Set
    End Property

    'The fllowing property will override the use of ASPX PAGES as parameters
    Public Shared ReadOnly Property HttpContextPage() As System.Web.HttpContext
        Get
            Try
                Return System.Web.HttpContext.Current
                'Return CType(System.Web.HttpContext.Current.Handler, System.Web.UI.Page)
            Catch ex As System.InvalidCastException
                Return Nothing
            Catch ex As Exception
                CapaLog.Log.appendToLog(ex)
            End Try
            Return Nothing
        End Get
    End Property
    'The fllowing property will override the use of ASPX PAGES as parameters
    Public Shared ReadOnly Property GetConfigValue(ByVal Key As String) As String
        Get
            Try
                If Not Array.IndexOf(ConfigurationManager.AppSettings.AllKeys, Key) >= 0 Then
                    Return String.Empty
                End If
                Return ConfigurationManager.AppSettings(Key)
            Catch ex As Exception
                CapaLog.Log.appendToLog(ex)
            End Try
            Return Nothing
        End Get
    End Property

    Public Shared ReadOnly Property UseApplicationPath() As Boolean
        Get
            If ConfigurationManager.AppSettings("UseApplicationPath") Is Nothing Then Return False
            Return Boolean.Parse(ConfigurationManager.AppSettings("UseApplicationPath"))
        End Get
    End Property

    Public Shared ReadOnly Property GetHttpReferer() As String
        Get
            Dim strReferer As String = String.Empty
            If Not System.Web.HttpContext.Current.Request.UrlReferrer Is Nothing Then
                strReferer = System.Web.HttpContext.Current.Request.UrlReferrer.ToString
            End If
            If System.Web.HttpContext.Current.Request("ProxyReferer") <> Nothing Then
                strReferer = System.Web.HttpContext.Current.Request("ProxyReferer")
            End If
            Return String.Format("{0}", strReferer)
        End Get
    End Property


#Region "Class constructor"
    Public Sub New(ByRef oObject As Object)
        'do nothing
    End Sub
    Public Sub New()
        '**
        '<summary>
        '   Builds a new instance of the Session Manager Class. duh :)
        '   All session variables, configuration variables, and application variables
        '   should be accesed only from here. This should make your life easier since
        '   you will have a central place where to deal with session state.
        '</summary>
        '<param name='pageReference'>A pointer to a valid system.web.ui.page object</param>
        '*
        'Assigns the pointer to the internal page object.
        'ptrToPage = CType(pageReference, System.Web.UI.Page)

        'Only changes the timeout the first time this class is instantiated.

        'ACS May 3 2006: Do not set the timeout in the code, this might lead to
        'unexpected ending of sessions
        'If HttpContextPage.Session.Timeout <> SESSION_DURATION_IN_MINUTES Then _
        '    HttpContextPage.Session.Timeout = SESSION_DURATION_IN_MINUTES
    End Sub
#End Region

#Region "Get The Configuration Settings"
    '*********************************************************************************************

    Public Shared ReadOnly Property SkipProcessorConditions() As Boolean
        '**
        '<summary>
        '   Configuration Setting.
        '   This is being initialize in Global.asax
        '   Indicates wether the public interface of the application will show the informational
        '   screen when making a transaction or will be redirected directly to the form.
        '   When True is returned, then it should skip the informational pages.
        '   Otherwise, if should show the informational pages before the form.
        '</summary>
        '<returns>
        '   True (should skip the informational pages)
        '   False (should show the informational pages before the form)
        '</returns>
        '*
        Get
            If ConfigurationManager.AppSettings("PreProcScreen") Is Nothing Then Return False
            Return Boolean.Parse(ConfigurationManager.AppSettings("PreProcScreen"))
        End Get
    End Property

    Public Shared ReadOnly Property ForceDeferredTransactions() As Boolean
        '**
        '<summary>
        '   Configuration Setting.
        '   Defines is the public interface of the application should make a real time transaction
        '   or use the deferred feature instead.
        '   When True, the application should be force to use the deferred feature.
        '   When False, the application should be processing the transactions in real time.
        '</summary>
        '<returns>
        '   True (the application should be force to use the deferred feature)
        '   False (the application should be processing the transactions in real time)
        '</returns>
        '*

        Get
            Return (UCase(ConfigurationManager.AppSettings("IsDefered")) = "TRUE")
        End Get
    End Property
    Public Shared ReadOnly Property PreloadData() As Boolean
        Get
            Try
                Return ConfigurationManager.AppSettings("AutoLoadInfo") = "1"
            Catch exc As Exception
                Return False
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property CheckIfPlayerInfo() As Boolean
        Get
            Try
                Return ConfigurationManager.AppSettings("CheckPlayerInfo") = "1"
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    'Public Shared ReadOnly Property GetTheLogFilePath() As String
    '    '**
    '    '<summary>
    '    '   Configuration Setting.
    '    '   Deprecated, no longer in use.
    '    '   Used to get the Log File location.
    '    '   Now all logs are being stored in the event viewer.
    '    '</summary>
    '    '*
    '    Get
    '        Return ConfigurationManager.AppSettings("LogFileName")
    '    End Get
    'End Property

    Public Shared ReadOnly Property GetSecretKey() As String
        Get
            If ConfigurationManager.AppSettings("SecretKey") Is Nothing Then Return String.Empty
            Return ConfigurationManager.AppSettings("SecretKey")
        End Get
    End Property

    Public Shared ReadOnly Property GetTheConnectionString() As String
        '**
        '<summary>
        '   Configuration Setting.
        '   Gets the connection string indicated in the web config of the current installation.
        '   It will be use to make the DB Connection Pool use in DatabaseEngine.
        '</summary>
        '<returns>The connection string specified in the web.config file.</returns>
        '*
        Get
            Dim boolUndefined As Boolean = False

            If System.Web.HttpContext.Current Is Nothing Then
                boolUndefined = True
                Return New CapaLog.wConfigBase_CTRL().CFG_ConnectionString
            End If
            If System.Web.HttpContext.Current.Application Is Nothing Then boolUndefined = True

            If System.Web.HttpContext.Current.Application("ConnStr") Is Nothing _
                Or System.Web.HttpContext.Current.Application("ConnStr") = "" Then
                System.Web.HttpContext.Current.Application("ConnStr") = New CapaLog.wConfigBase_CTRL().CFG_ConnectionString
            End If

            Return System.Web.HttpContext.Current.Application("ConnStr")
        End Get
    End Property

    Public Shared ReadOnly Property GetTheSMTPServer() As String
        '**
        '<summary>
        '   Configuration Setting.
        '   Gets the SMTP Server for the current installation. 
        '</summary>
        '<returns>The SMTP Server that the customer wants to use to send its emails.</returns>
        '*
        Get
            'If ConfigurationManager.AppSettings("SMTPServer") Is Nothing Then Return String.Empty
            Return String.Format("{0}", ConfigurationManager.AppSettings("SMTPServer"))
        End Get
    End Property

    Public Shared ReadOnly Property GetScreening() As String
        '**
        '<summary>
        '   Configuration Setting.
        '   Gets the string with the methods that will use screening for the current installation. 
        '</summary>
        '<returns>The SMTP Server that the customer wants to use to send its emails.</returns>
        '*
        Get
            If ConfigurationManager.AppSettings("Screening") Is Nothing Then Return ""
            Return ConfigurationManager.AppSettings("Screening")
        End Get
    End Property

    Public Shared ReadOnly Property GetSqlExecutionTimeOut() As Integer
        '**
        '<summary>
        '   Configuration Setting
        '   The customer has the ability to set up the sql execution time of an sql query.
        '   When no valid value is found in this string, it will return the default value of 30 seconds.
        '   If 0 is indicated in the web.config file, then there will not be a timeout.
        '</summary>
        '<returns>
        '   An integer value that indicates the number of seconds before the query
        '   timeout and throws an error.
        '</returns>
        '*
        Get
            If ConfigurationManager.AppSettings("sqlExecutionTimeOut") Is Nothing Then Return 30
            If Not IsNumeric(ConfigurationManager.AppSettings("sqlExecutionTimeOut")) Then Return 30
            Return ConfigurationManager.AppSettings("sqlExecutionTimeOut")
        End Get
    End Property

#End Region

#Region "Access to Session Variables"

    'When this field is different than 0 then the cashier will not let anyone to 
    'process more than the amount stored in this field.
    Public Property FixedAmount() As Double
        '**
        '<summary>
        '   When the cashier is being invoked by an ecommerce site that wants to specify
        '   the amount that's going to be processed, the application will store it here.
        '   When this property has a value <> 0 it should not let the customers to specified any
        '   other amount in the forms. At the same time, it should disable the amount field and 
        '   show the amount indicated here.
        '</summary>
        '<returns>
        '   0 if not amount is specified.
        '   > 0 if a valid amout is indicated.
        '</returns>
        '*
        Get
            'Checks that the fixed amount has a valid value.
            If System.Web.HttpContext.Current.Session("Fixed Amount") Is Nothing Then Return 0
            If Not IsNumeric(System.Web.HttpContext.Current.Session("Fixed Amount")) Then Return 0
            Return System.Web.HttpContext.Current.Session("Fixed Amount")
        End Get

        Set(ByVal Value As Double)
            'Saves the indicated value in the session state.
            System.Web.HttpContext.Current.Session("Fixed Amount") = Value
        End Set
    End Property

    Public ReadOnly Property GetTheHostIPAddress() As String
        '**
        '<summary>
        '   Gets the IP Address assigned to the customer by his ISP.
        '   Since we are behind a proxy makin all the requests, the real address is being
        '   Masked. Therefore, the HTTP_X_FORWARDED_FOR needs to be use. When that variable
        '   Is empty, then it means that the IP Address is being stored in ptrToPage.Request.UserHostAddress
        '</summary>
        '<returns>
        '   The current IP Address that the customer is using at the present session.
        '</returns>
        '*
        Get
            Return ReturnValidIpAddress(SessionUtilidades.GetTheHostIPAddressShare)
        End Get
    End Property


    Public Shared ReadOnly Property ReturnValidIpAddress(Optional ByVal strIpAddress As String = Nothing) As String
        Get
            Dim countIp As Integer = 0
            Dim address As System.Net.IPAddress
            Dim strTempIPs As String()
            If strIpAddress Is Nothing Then strIpAddress = SessionUtilidades.GetTheHostIPAddressShare
            Try
                strTempIPs = strIpAddress.Split(",")
                For i As Integer = UBound(strTempIPs) To 0 Step -1
                    address = System.Net.IPAddress.Parse(strTempIPs(i))
                    Dim strCtry As String = String.Empty
                    strCtry = New CountryLookup(System.Configuration.ConfigurationManager.AppSettings("SitesConfig") & Countries.DAT_FILE).LookupCountryCode(address)
                    If (Not strCtry = Countries.NOTFOUND And Not strCtry.ToLower.Equals(Countries.NOTAPPLIES)) Or i = 0 Then
                        strIpAddress = strTempIPs(i)
                        Exit Try
                    End If
                Next

                If strIpAddress Is Nothing Then
                    strIpAddress = "255.255.255.254"
                ElseIf strIpAddress = String.Empty Then
                    strIpAddress = "255.255.255.253"
                ElseIf UCase(strIpAddress) = "UNKNOWN" Then
                    strIpAddress = "255.255.255.251"
                End If
            Catch ex As Exception
                'strIpAddress = "255.255.255.252"
            End Try

            Return strIpAddress
        End Get
    End Property

    Public Shared ReadOnly Property GetTheHostIPAddressShare() As String
        Get
            Dim strIP As String = String.Empty
            '>>>>>>>>>>>>>>>>.try getting a session
            Try
                If Not System.Web.HttpContext.Current.Session Is Nothing Then
                    strIP = String.Format("{0}", System.Web.HttpContext.Current.Session.Item(SESSION_IP))
                End If

                If strIP <> Nothing Then
                    Exit Try
                End If

                If SessionUtilidades.IpIsXForward Then
                    strIP = System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                Else
                    strIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString()
                End If

            Catch ex As Exception
                CapaLog.Log.appendToLog(ex)
            Finally
                'do nothing
            End Try

            If Trim(strIP) = Nothing Then
                strIP = "127.0.0.1"
            End If

            '#If DEBUG Then
            '            strIP = "76.226.80.55"
            '#End If


            Return strIP
        End Get
    End Property

    Public Shared ReadOnly Property IsAdminInterface() As Boolean
        Get
            Try
                Dim strInterface As Char = CChar(System.Web.HttpContext.Current.Application("_appInterface_"))

                If strInterface.Equals(SessionUtilidades.TypeAdmin) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_DEBUG, "ERROR getting the _appInterface_ in IsAdminInterface")
                Return False
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property IsUsersInterface() As Boolean
        Get
            Try
                Dim strInterface As Char = CChar(System.Web.HttpContext.Current.Application("_appInterface_"))

                If strInterface.Equals(SessionUtilidades.TypeUsers) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_DEBUG, "ERROR getting the _appInterface_ in IsUsersInterface")
                Return False
            End Try
        End Get
    End Property
    Public Shared ReadOnly Property IsPublicInterface() As Boolean
        '**
        '<summary>
        '   Application property
        '   Indicates wether the current instance of the application is the public interface
        '</summary>
        '<returns>
        '   True if the current application is the public interface.
        '</returns>
        '*
        Get
            Try
                If System.Web.HttpContext.Current Is Nothing Then
                    Return False
                End If

                Dim strInterface As Char = CChar(System.Web.HttpContext.Current.Application("_appInterface_"))
                If strInterface.Equals(SessionUtilidades.TypePublic) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_DEBUG, "ERROR getting the _appInterface_ in IsPublicInterface")
                Return False
            End Try
            'Return System.Web.HttpContext.Current.Application("_appIsThePublicInterface_")
        End Get
    End Property
    Public Shared ReadOnly Property IsWebserviceInterface() As Boolean
        '**
        '<summary>
        '   Application property
        '   Indicates if the current instance of the application is the Webservice interface
        '  
        '</summary>
        '<returns>
        '   True if the current application is the Webservice interface.
        '   False if the current application is the administration interface.
        '</returns>
        '*

        Get
            Try
                Dim strInterface As Char = CChar(System.Web.HttpContext.Current.Application("_appInterface_"))

                Return strInterface.Equals(SessionUtilidades.TypeWService)

            Catch ex As Exception
                CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_DEBUG, "ERROR getting the _appInterface_ in IsWebserviceInterface")
                Return False
            End Try
        End Get
    End Property

    Public Property LicenseTimeLeft() As Integer
        '**
        '<summary>
        '   The system uses a serial number to verity that the current installation 
        '   belongs to a legitimate licensee.
        '   This will return the number of days left for it to expire so a warning message 
        '   can be display to the customer in the administration pages so he's aware he needs
        '   to renew it.
        '</summary>
        '<returns>
        '   Returns the amount of days left before the serial number for the current sportsbook
        '   expires
        '</returns>
        '*
        Get
            Try
                If System.Web.HttpContext.Current.Cache(SESSION_SERIAL_REMAINING_DAYS) Is Nothing Then Return -1
                Return System.Web.HttpContext.Current.Cache(SESSION_SERIAL_REMAINING_DAYS)
            Catch exc As InvalidCastException
                Return 0
            End Try
        End Get

        Set(ByVal Value As Integer)
            'if it does not exists, it creates a new cache string. If it does exists, then it updates it
            If System.Web.HttpContext.Current.Cache(SESSION_SERIAL_REMAINING_DAYS) Is Nothing Then
                System.Web.HttpContext.Current.Cache.Add(SESSION_SERIAL_REMAINING_DAYS, Value, Nothing, Date.MaxValue, _
                                 New TimeSpan(1, 0, 0), System.Web.Caching.CacheItemPriority.Normal, Nothing)
            Else
                System.Web.HttpContext.Current.Cache(SESSION_SERIAL_REMAINING_DAYS) = Value
            End If
        End Set
    End Property

    Public Shared ReadOnly Property SendIDeductPayout(ByVal boolDeductPayoutInAdvance As Boolean) As Integer
        Get
            If boolDeductPayoutInAdvance Then
                Return 1
            Else
                Return 0
            End If
        End Get
    End Property




    Public ReadOnly Property isThisProfileInSession() As Boolean
        Get
            Return Not (System.Web.HttpContext.Current.Session(SESSION_MYKEY_PF) Is Nothing)
        End Get
    End Property

    'Public ReadOnly Property TransactionStatus() As TransactionStatusCode
    '    Get
    '        If myPage.Session(SESSION_TRANSACTION_STATUS) Is Nothing Then
    '            myPage.Session(SESSION_TRANSACTION_STATUS) = New TransactionStatusCode(SessionManager.getTheConnectionString)
    '        End If

    '        Return myPage.Session(SESSION_TRANSACTION_STATUS)
    '    End Get
    'End Property


    Public Property TemporaryCitadelPlayerID() As Integer
        '**
        '<summary>
        '   For Citadel Level 1 a trip is done to their website.
        '   In Public interface there are no problems to get the customer ID because it is stored
        '   in the customer session.
        '   However, in private side, the player id is stored in session and then retrieved
        '   when citadel sends back the control.
        '</summary>
        '   A Valid player ID or 0 if an error occured.
        '<returns>
        '   
        '</returns>
        '*
        Get
            Try
                Return System.Web.HttpContext.Current.Session(SESSION_CITADEL_PLAYER_ID)
            Catch exc As Exception
                CapaLog.Log.appendToLog(exc)
                Return 0
            End Try
        End Get

        Set(ByVal Value As Integer)
            System.Web.HttpContext.Current.Session(SESSION_CITADEL_PLAYER_ID) = Value
        End Set
    End Property
    'Public Property Transtype() As Integer
    '    Get
    '        If ptrToPage.Cache.Item(SESSION_TRANSTYPE) Is Nothing Then
    '            ptrToPage.Cache.Add(SESSION_TRANSTYPE, value, Nothing, Date.MaxValue, New TimeSpan(0, 2, 0), _
    '                             System.Web.Caching.CacheItemPriority.Normal, Nothing)
    '        End If

    '        Return ptrToPage.Cache.Item(SESSION_TRANSTYPE)
    '    End Get
    '    Set(ByVal Value As Integer)
    '    End Set

    'End Property

    Public Shared ReadOnly Property GetApplicationPath() As String
        Get
            Return System.Web.HttpContext.Current.Request.ApplicationPath.ToString()
        End Get
    End Property

    'Public Shared ReadOnly Property GetAppPathParsed() As String
    '    Get
    '        If System.Web.HttpContext.Current.Cache.Item("AppPath") Is Nothing Then
    '            System.Web.HttpContext.Current.Cache.Insert("AppPath", GetApplicationPath.Trim.ToUpper.Replace("/", "").Replace(":", "_"))
    '        End If
    '        Return System.Web.HttpContext.Current.Cache.Item("AppPath")
    '    End Get
    'End Property

    Public Shared ReadOnly Property GetApplicationPhysicalPath() As String
        Get
            Return System.Web.HttpContext.Current.Request.PhysicalApplicationPath
        End Get
    End Property

    Public ReadOnly Property GetPtrToPage() As System.Web.HttpContext
        Get
            Return Me.ptrToPage
        End Get
    End Property

#End Region

    Public Shared ReadOnly Property UserCanEditForm() As Boolean
        Get
            Return (SessionUtilidades.GetAppSettingsValue("UserCanEditForm") <> "0")
        End Get
    End Property

#Region "Public Methods"

    Public Shared Function GetAppSettingsValue(ByVal strKey As String) As String
        If Not Array.IndexOf(ConfigurationManager.AppSettings.AllKeys(), strKey) >= 0 Then _
            Return String.Empty
        If Not ConfigurationManager.AppSettings(strKey) Is Nothing Then _
            Return ConfigurationManager.AppSettings(strKey) _
                Else _
                    Return String.Empty
    End Function

    Public Shared Function UsePopups() As Boolean
        If GetAppSettingsValue("UsePopups") Is Nothing Then Return False
        Return UCase(GetAppSettingsValue("UsePopups")) = "TRUE"
    End Function
#End Region

#Region "GET CONTACT INFORMATION (PHONE NUMBER)"
    Public Shared ReadOnly Property GetContactInformation() As String
        Get
            Try
                If Not System.Configuration.ConfigurationManager.AppSettings("contactPhone") Is Nothing Then
                    Return System.Configuration.ConfigurationManager.AppSettings("contactPhone")
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
#End Region

    'Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)

#Region "AJAX TIME"
    Public Shared Sub ProgressCount_Refresh()
        Dim iValue, iCount, iTime As Integer
        Dim strValue As String = GetAppSettingsValue(KEY_PROGRESS_COUNT)
        If strValue Is Nothing Then iValue = 3005
        If Not IsNumeric(strValue) Then iValue = 3005
        If iValue = 0 Then
            iValue = CInt(strValue)
        End If
        If iValue Mod 1000 = 0 Then
            iValue = 3005
        End If
        iCount = iValue Mod 1000
        iTime = iValue - iCount
        System.Web.HttpContext.Current.Session(SESSION_PROGRESS_COUNT_TIME) = iTime
        System.Web.HttpContext.Current.Session(SESSION_PROGRESS_COUNT) = iCount
    End Sub
#End Region

End Class
