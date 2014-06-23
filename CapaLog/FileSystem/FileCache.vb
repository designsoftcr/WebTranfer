Option Strict On
Option Explicit On 

Imports System
Imports System.IO


Public Class FileCache

    ' ''Public Enum CacheUnit As Short
    ' ''    Seconds = 1
    ' ''    Minutes = 2
    ' ''    Hours = 3
    ' ''    Days = 4
    ' ''End Enum

    ' ''Public Function SetCacheContent(ByVal strCacheName As String, ByVal oContent As Object, Optional ByVal strAnchor As String = "CacheAnchor.txt", Optional ByVal boolUseAnchor As Boolean = True, Optional ByVal iUnitType As CacheUnit = CacheUnit.Days, Optional ByVal iUnits As Integer = 1, Optional ByVal boolUseAppSession As Boolean = False) As Boolean
    ' ''    If boolUseAppSession Then
    ' ''        ApplicationManagement.setProcessingObject(strCacheName, oContent)
    ' ''        Return True
    ' ''    End If
    ' ''    Dim fileDependency As System.Web.Caching.CacheDependency
    ' ''    Dim strAnchorFilePath As String

    ' ''    strCacheName = strCacheName & LngMisc.GetLang()
    ' ''    If String.Format("{0}", strCacheName) = "" Then Return False
    ' ''    Try
    ' ''        If boolUseAnchor Then
    ' ''            strAnchorFilePath = SessionManager.GetAppSettingsValue("SitesConfig") & strAnchor
    ' ''            fileDependency = New System.Web.Caching.CacheDependency(strAnchorFilePath)
    ' ''        Else
    ' ''            fileDependency = Nothing
    ' ''        End If
    ' ''        Select Case iUnitType
    ' ''            Case CacheUnit.Days
    ' ''                System.Web.HttpContext.Current.Cache.Insert( _
    ' ''                    strCacheName, _
    ' ''                    oContent, _
    ' ''                    fileDependency, _
    ' ''                    System.Web.HttpContext.Current.Cache.NoAbsoluteExpiration, _
    ' ''                    TimeSpan.FromDays(iUnits))
    ' ''            Case CacheUnit.Hours
    ' ''                System.Web.HttpContext.Current.Cache.Insert( _
    ' ''                    strCacheName, _
    ' ''                    oContent, _
    ' ''                    fileDependency, _
    ' ''                    System.Web.HttpContext.Current.Cache.NoAbsoluteExpiration, _
    ' ''                    TimeSpan.FromHours(iUnits))
    ' ''            Case CacheUnit.Minutes
    ' ''                System.Web.HttpContext.Current.Cache.Insert( _
    ' ''                    strCacheName, _
    ' ''                    oContent, _
    ' ''                    fileDependency, _
    ' ''                    System.Web.HttpContext.Current.Cache.NoAbsoluteExpiration, _
    ' ''                    TimeSpan.FromMinutes(iUnits))
    ' ''            Case CacheUnit.Seconds
    ' ''                System.Web.HttpContext.Current.Cache.Insert( _
    ' ''                    strCacheName, _
    ' ''                    oContent, _
    ' ''                    fileDependency, _
    ' ''                    System.Web.HttpContext.Current.Cache.NoAbsoluteExpiration, _
    ' ''                    TimeSpan.FromSeconds(iUnits))
    ' ''        End Select
    ' ''        Return True
    ' ''    Catch ex As Exception
    ' ''        CashierInterface.Log.appendToLog(CashierInterface.Log.LEVEL_WARN, vbCr & "cache error: " & strCacheName & vbCr & ex.ToString())
    ' ''        Return False
    ' ''    Finally
    ' ''        If Not fileDependency Is Nothing Then fileDependency.Dispose()
    ' ''        fileDependency = Nothing
    ' ''    End Try
    ' ''End Function

    ' ''Public Function GetCacheContent(ByVal strCacheName As String, Optional ByVal boolUseAppSession As Boolean = False) As Object
    ' ''    Try
    ' ''        'strCacheName = strCacheName & LngMisc.GetLang()
    ' ''        If boolUseAppSession Then
    ' ''            Return ApplicationManagement.GetProcessingObject(strCacheName)
    ' ''        End If
    ' ''        If String.Format("{0}", strCacheName) = "" Then Return Nothing
    ' ''        Return SessionManager.HttpContextPage.Cache(strCacheName)
    ' ''    Catch ex As Exception
    ' ''        CashierInterface.Log.appendToLog(CashierInterface.Log.LEVEL_WARN, "This resource is not available: " & strCacheName)
    ' ''    Finally
    ' ''        'do nothing
    ' ''    End Try
    ' ''    Return Nothing
    ' ''End Function


End Class
