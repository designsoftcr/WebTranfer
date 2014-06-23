Imports System.Runtime.InteropServices

'<StructLayout(LayoutKind.Sequential)> _
<System.Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> _
Public Class NETRESOURCE
    Public dwScope As Integer
    Public dwType As Integer
    Public dwDisplayType As Integer
    Public dwUsage As Integer
    Public LocalName As String
    Public RemoteName As String
    Public Comment As String
    Public Provider As String
End Class 'NETRESOURCE
