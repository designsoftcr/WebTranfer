Imports System.Data.SqlClient

Public Class Countries
    Public Const METHODS_COUNTRY As String = "CTRY"
#Region "Convert to Number"
    Public Shared ReadOnly Property GetCountryNum(ByVal strCountry As String) As String
        Get
            Select Case strCountry
                Case "AF", "AFG" : Return "004"
                Case "AL", "ALB" : Return "008"
                Case "DZ", "DZA" : Return "012"
                Case "AS", "ASM" : Return "016"
                Case "AD", "AND" : Return "020"
                Case "AO", "AGO" : Return "024"
                Case "AI", "AIA" : Return "660"
                Case "AQ", "ATA" : Return "010"
                Case "AG", "ATG" : Return "028"
                Case "AR", "ARG" : Return "032"
                Case "AM", "ARM" : Return "051"
                Case "AW", "ABW" : Return "533"
                Case "AU", "AUS" : Return "036"
                Case "AT", "AUT" : Return "040"
                Case "AZ", "AZE" : Return "031"
                Case "BS", "BHS" : Return "044"
                Case "BH", "BHR" : Return "048"
                Case "BD", "BGD" : Return "050"
                Case "BB", "BRB" : Return "052"
                Case "BY", "BLR" : Return "112"
                Case "BE", "BEL" : Return "056"
                Case "BZ", "BLZ" : Return "084"
                Case "BJ", "BEN" : Return "204"
                Case "BM", "BMU" : Return "060"
                Case "BT", "BTN" : Return "064"
                Case "BO", "BOL" : Return "068"
                Case "BA", "BIH" : Return "070"
                Case "BW", "BWA" : Return "072"
                Case "BV", "BVT" : Return "074"
                Case "BR", "BRA" : Return "076"
                Case "IO", "IOT" : Return "086"
                Case "BN", "BRN" : Return "096"
                Case "BG", "BGR" : Return "100"
                Case "BF", "BFA" : Return "854"
                Case "BI", "BDI" : Return "108"
                Case "KH", "KHM" : Return "116"
                Case "CM", "CMR" : Return "120"
                Case "CA", "CAN" : Return "124"
                Case "CV", "CPV" : Return "132"
                Case "KY", "CYM" : Return "136"
                Case "CF", "CAF" : Return "140"
                Case "TD", "TCD" : Return "148"
                Case "CL", "CHL" : Return "152"
                Case "CN", "CHN" : Return "156"
                Case "CX", "CXR" : Return "162"
                Case "CC", "CCK" : Return "166"
                Case "CO", "COL" : Return "170"
                Case "KM", "COM" : Return "174"
                Case "CG", "COG" : Return "178"
                Case "CD", "COD" : Return "180"
                Case "CK", "COK" : Return "184"
                Case "CR", "CRI" : Return "188"
                Case "CI", "CIV" : Return "384"
                Case "HR", "HRV" : Return "191"
                Case "CU", "CUB" : Return "192"
                Case "CY", "CYP" : Return "196"
                Case "CZ", "CZE" : Return "203"
                Case "DK", "DNK" : Return "208"
                Case "DJ", "DJI" : Return "262"
                Case "DM", "DMA" : Return "212"
                Case "DO", "DOM" : Return "214"
                Case "TP", "TMP" : Return "626"
                Case "EC", "ECU" : Return "218"
                Case "EG", "EGY" : Return "818"
                Case "SV", "SLV" : Return "222"
                Case "GQ", "GNQ" : Return "226"
                Case "ER", "ERI" : Return "232"
                Case "EE", "EST" : Return "233"
                Case "ET", "ETH" : Return "231"
                Case "FK", "FLK" : Return "238"
                Case "FO", "FRO" : Return "234"
                Case "FJ", "FJI" : Return "242"
                Case "FI", "FIN" : Return "246"
                Case "FR", "FRA" : Return "250"
                Case "FX", "FXX" : Return "249"
                Case "GF", "GUF" : Return "254"
                Case "PF", "PYF" : Return "258"
                Case "TF", "ATF" : Return "260"
                Case "GA", "GAB" : Return "266"
                Case "GM", "GMB" : Return "270"
                Case "GE", "GEO" : Return "268"
                Case "DE", "DEU" : Return "276"
                Case "GH", "GHA" : Return "288"
                Case "GI", "GIB" : Return "292"
                Case "GR", "GRC" : Return "300"
                Case "GL", "GRL" : Return "304"
                Case "GD", "GRD" : Return "308"
                Case "GP", "GLP" : Return "312"
                Case "GU", "GUM" : Return "316"
                Case "GT", "GTM" : Return "320"
                Case "GN", "GIN" : Return "324"
                Case "GW", "GNB" : Return "624"
                Case "GY", "GUY" : Return "328"
                Case "HT", "HTI" : Return "332"
                Case "HM", "HMD" : Return "334"
                Case "VA", "VAT" : Return "336"
                Case "HN", "HND" : Return "340"
                Case "HK", "HKG" : Return "344"
                Case "HU", "HUN" : Return "348"
                Case "IS", "ISL" : Return "352"
                Case "IN", "IND" : Return "356"
                Case "ID", "IDN" : Return "360"
                Case "IR", "IRN" : Return "364"
                Case "IQ", "IRQ" : Return "368"
                Case "IE", "IRL" : Return "372"
                Case "IL", "ISR" : Return "376"
                Case "IT", "ITA" : Return "380"
                Case "JM", "JAM" : Return "388"
                Case "JP", "JPN" : Return "392"
                Case "JO", "JOR" : Return "400"
                Case "KZ", "KAZ" : Return "398"
                Case "KE", "KEN" : Return "404"
                Case "KI", "KIR" : Return "296"
                Case "KP", "PRK" : Return "408"
                Case "KR", "KOR" : Return "410"
                Case "KW", "KWT" : Return "414"
                Case "KG", "KGZ" : Return "417"
                Case "LA", "LAO" : Return "418"
                Case "LV", "LVA" : Return "428"
                Case "LB", "LBN" : Return "422"
                Case "LS", "LSO" : Return "426"
                Case "LR", "LBR" : Return "430"
                Case "LY", "LBY" : Return "434"
                Case "LI", "LIE" : Return "438"
                Case "LT", "LTU" : Return "440"
                Case "LU", "LUX" : Return "442"
                Case "MO", "MAC" : Return "446"
                Case "MK", "MKD" : Return "807"
                Case "MG", "MDG" : Return "450"
                Case "MW", "MWI" : Return "454"
                Case "MY", "MYS" : Return "458"
                Case "MV", "MDV" : Return "462"
                Case "ML", "MLI" : Return "466"
                Case "MT", "MLT" : Return "470"
                Case "MH", "MHL" : Return "584"
                Case "MQ", "MTQ" : Return "474"
                Case "MR", "MRT" : Return "478"
                Case "MU", "MUS" : Return "480"
                Case "YT", "MYT" : Return "175"
                Case "MX", "MEX" : Return "484"
                Case "FM", "FSM" : Return "583"
                Case "MD", "MDA" : Return "498"
                Case "MC", "MCO" : Return "492"
                Case "MN", "MNG" : Return "496"
                Case "MS", "MSR" : Return "500"
                Case "MA", "MAR" : Return "504"
                Case "MZ", "MOZ" : Return "508"
                Case "MM", "MMR" : Return "104"
                Case "NA", "NAM" : Return "516"
                Case "NR", "NRU" : Return "520"
                Case "NP", "NPL" : Return "524"
                Case "NL", "NLD" : Return "528"
                Case "AN", "ANT" : Return "530"
                Case "NC", "NCL" : Return "540"
                Case "NZ", "NZL" : Return "554"
                Case "NI", "NIC" : Return "558"
                Case "NE", "NER" : Return "562"
                Case "NG", "NGA" : Return "566"
                Case "NU", "NIU" : Return "570"
                Case "NF", "NFK" : Return "574"
                Case "MP", "MNP" : Return "580"
                Case "NO", "NOR" : Return "578"
                Case "OM", "OMN" : Return "512"
                Case "PK", "PAK" : Return "586"
                Case "PW", "PLW" : Return "585"
                Case "PA", "PAN" : Return "591"
                Case "PG", "PNG" : Return "598"
                Case "PY", "PRY" : Return "600"
                Case "PE", "PER" : Return "604"
                Case "PH", "PHL" : Return "608"
                Case "PN", "PCN" : Return "612"
                Case "PL", "POL" : Return "616"
                Case "PT", "PRT" : Return "620"
                Case "PR", "PRI" : Return "630"
                Case "QA", "QAT" : Return "634"
                Case "RE", "REU" : Return "638"
                Case "RO", "ROM" : Return "642"
                Case "RU", "RUS" : Return "643"
                Case "RW", "RWA" : Return "646"
                Case "KN", "KNA" : Return "659"
                Case "LC", "LCA" : Return "662"
                Case "VC", "VCT" : Return "670"
                Case "WS", "WSM" : Return "882"
                Case "SM", "SMR" : Return "674"
                Case "ST", "STP" : Return "678"
                Case "SA", "SAU" : Return "682"
                Case "SN", "SEN" : Return "686"
                Case "SC", "SYC" : Return "690"
                Case "SL", "SLE" : Return "694"
                Case "SG", "SGP" : Return "702"
                Case "SK", "SVK" : Return "703"
                Case "SI", "SVN" : Return "705"
                Case "SB", "SLB" : Return "090"
                Case "SO", "SOM" : Return "706"
                Case "ZA", "ZAF" : Return "710"
                Case "GS", "SGS" : Return "239"
                Case "ES", "ESP" : Return "724"
                Case "LK", "LKA" : Return "144"
                Case "SH", "SHN" : Return "654"
                Case "PM", "SPM" : Return "666"
                Case "SD", "SDN" : Return "736"
                Case "SR", "SUR" : Return "740"
                Case "SJ", "SJM" : Return "744"
                Case "SZ", "SWZ" : Return "748"
                Case "SE", "SWE" : Return "752"
                Case "CH", "CHE" : Return "756"
                Case "SY", "SYR" : Return "760"
                Case "TW", "TWN" : Return "158"
                Case "TJ", "TJK" : Return "762"
                Case "TZ", "TZA" : Return "834"
                Case "TH", "THA" : Return "764"
                Case "TG", "TGO" : Return "768"
                Case "TK", "TKL" : Return "772"
                Case "TO", "TON" : Return "776"
                Case "TT", "TTO" : Return "780"
                Case "TN", "TUN" : Return "788"
                Case "TR", "TUR" : Return "792"
                Case "TM", "TKM" : Return "795"
                Case "TC", "TCA" : Return "796"
                Case "TV", "TUV" : Return "798"
                Case "UG", "UGA" : Return "800"
                Case "UA", "UKR" : Return "804"
                Case "AE", "ARE" : Return "784"
                Case "GB", "GBR" : Return "826"
                Case "US", "USA" : Return "840"
                Case "UM", "UMI" : Return "581"
                Case "UY", "URY" : Return "858"
                Case "UZ", "UZB" : Return "860"
                Case "VU", "VUT" : Return "548"
                Case "VE", "VEN" : Return "862"
                Case "VN", "VNM" : Return "704"
                Case "VG", "VGB" : Return "092"
                Case "VI", "VIR" : Return "850"
                Case "WF", "WLF" : Return "876"
                Case "EH", "ESH" : Return "732"
                Case "YE", "YEM" : Return "887"
                Case "YU", "YUG" : Return "891"
                Case "ZM", "ZMB" : Return "894"
                Case "ZW", "ZWE" : Return "716"
                Case Else
                    Return "826"
            End Select
        End Get
    End Property
#End Region
    Public Enum CountryCodeType As Integer
        CODE2LETTERS = 1
        CODE3LETTERS = 2
        CODENUMBER = 3
        CODENAME = 4
        CODEDBID = 5
        CODEDPHONE = 6
    End Enum
    Public Enum StateCodeType As Integer
        CODE2LETTERS = 1
        CODE3LETTERS = 2
        CODENUMBER = 3
        CODENAME = 4
        CODEDBID = 5
    End Enum

    Private strConnString As String

    Public Const GET_ACTIVE_INACTIVE_COUNTRIES = 0
    Public Const GET_ONLY_ACTIVE_COUNTRIES = 1
    Public Const NOTAPPLIES As String = "n/a"
    Public Const NOTFOUND As String = "--"
    Public Const DAT_FILE = "GeoIP.dat"

    
    Public Shared Function GetCountryName(Optional ByVal strIP As String = Nothing) As String
        Dim FilterCtryByIP As Boolean
        Dim _IPDataPath As String = System.Configuration.ConfigurationManager.AppSettings("SitesConfig")
        Dim _CountryLookup As CountryLookup
        Dim _CountryName As String
        Dim _UserIPAddress As String

        Try
            FilterCtryByIP = (System.Configuration.ConfigurationManager.AppSettings("FilterCtryByIP") = "TRUE")

            If SessionUtilidades.IsPublicInterface And Not FilterCtryByIP And SessionUtilidades.CheckCountryBanned Then
                Return String.Empty
            ElseIf SessionUtilidades.IsPublicInterface And Not SessionUtilidades.CheckCountryBanned Then
                Return NOTAPPLIES
            End If

            If _IPDataPath Is Nothing Then
                CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_INFO, "Configuration files path not specified")
                Return NOTAPPLIES
            Else
                _IPDataPath &= "GeoIP.dat"
            End If

            _CountryLookup = New CountryLookup(_IPDataPath)
            If strIP Is Nothing Then
                _UserIPAddress = SessionUtilidades.ReturnValidIpAddress
            Else
                _UserIPAddress = SessionUtilidades.ReturnValidIpAddress(strIP)
            End If
            '_UserIPAddress = "196.40.63.19"

            With _CountryLookup
                _CountryName = .LookupCountryCode(_UserIPAddress)
                If _CountryName = "--" Then _CountryName = NOTAPPLIES
                '_CountryName = "CR"
            End With

        Catch ex As Exception
            _CountryName = NOTAPPLIES
            CapaLog.Log.appendToLog(CapaLog.Log.LEVEL_DEBUG, vbCrLf & "Unable to open IP data file" & vbCrLf & ex.ToString())
        End Try
        Return _CountryName
    End Function
End Class




