Imports System.Web

''' <summary>
'''     JavascriptUtilities deals with all the insertions of real time javascript generated needs.
''' </summary>
Public Class JavascriptUtilities

    ''' <summary>
    '''     Displays a javascript alert message to the user with the specified message.
    '''     This does not check for the validity of the script.
    ''' </summary>
    ''' <param name="script">The script to be registered</param>
    ''' <param name="ptrToPage">A pointer to the page where the script will be inserted.</param>
    Public Shared Sub RegisterThisScript(ByVal script As String, ByVal ptrToPage As Object)
        RegisterThisScript(Nothing, script, ptrToPage)
    End Sub

    Public Shared Sub RegisterThisScript(ByVal key As String, ByVal script As String, ByRef ptrToPage As Object)
        If key Is Nothing Then key = "specialScript"
        If key.Equals(String.Empty) Then key = "specialScript"
        CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).Page.GetType, key, "<SCRIPT LANGUAGE='Javascript'> " & _
                                                                script & _
                                                                "</script> ")
    End Sub

    ''' <summary>
    '''     Register a script at startup.
    ''' </summary>
    ''' <param name="script">The script to be registered</param>
    ''' <param name="ptrToPage">A pointer to the page where the script will be inserted.</param>
    Public Shared Sub RegisterThisScriptAtStartup(ByVal key As String, ByVal script As String, ByVal ptrToPage As Object)
        CType(ptrToPage, System.Web.UI.Page).ClientScript.RegisterStartupScript(CType(ptrToPage, System.Web.UI.Page).Page.GetType, key, "<SCRIPT LANGUAGE='Javascript'> " & _
                                                                       script & _
                                                                       "</script>")
    End Sub


    ''' <summary>
    '''     Displays a message using the javascript alert command.
    ''' </summary>
    ''' <param name="msg">The message to be displayed</param>
    ''' <param name="ptrToPage">A page object where the script will be inserted.</param>
    Public Shared Sub DisplayAMessageBox(ByVal msg As String, Optional ByVal ptrToPage As Object = Nothing, Optional ByVal RegisterAtBeginning As Boolean = True)
        msg = "'" & msg & "'"
        If SessionUtilidades.IsWebserviceInterface Then Exit Sub
        'If ptrToPage Is Nothing Then _
        '    ptrToPage = SessionManager.HttpContextPage
        If RegisterAtBeginning Then
            CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).Page.GetType, "textScript", _
                                                                           "<SCRIPT LANGUAGE='Javascript'> " & _
                                                                           "alert(" & msg & ");" & _
                                                                           "</script> ")
        Else
            CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).ClientScript.RegisterStartupScript(CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).Page.GetType, "textScript", _
                                                                           "<SCRIPT LANGUAGE='Javascript'> " & _
                                                                           "alert(" & msg & ");" & _
                                                                           "</script> ")
        End If
    End Sub

    ''' <summary>
    '''     Closes a browser window in the client machine.
    ''' </summary>
    ''' <param name="ptrToPage">A page object of the browser window to close.</param>
    Public Shared Sub CloseAnOpenWindow(ByVal ptrToPage As Object)
        CType(ptrToPage, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(ptrToPage, System.Web.UI.Page).GetType, "textScript", _
                                                                       "<SCRIPT LANGUAGE='Javascript'> " & _
                                                                       "window.close();" & _
                                                                       "</script> ")
    End Sub

    ''' <summary>
    '''     Opens a modal dialog window.
    '''     This should be used when the a confirmation is required by the user before proceeding
    '''     with the task.
    ''' </summary>
    ''' <param name="ptrToWindow"></param>
    Public Shared Sub OpenAModalDialogWindow(ByVal ptrToWindow As Object)
        'Opens a new window with a modal form.
        Dim Script As String

        Script = "<script language='javascript'> " & Chr(13) & _
                 "function openAModalWindow(newPage){" & Chr(13) & _
                    "window.showModalDialog(newPage,'','width=400; height=200; resizable=yes; scrollbars=yes; top=300; left=300');" & Chr(13) & _
                 "}" & Chr(13) & _
                 "</script>" & Chr(13)

        '        Script = Replace(Script, "ppp", newPage)

        If Not CType(ptrToWindow, System.Web.UI.Page).ClientScript.IsClientScriptBlockRegistered("ModalWindow") Then
            CType(ptrToWindow, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(ptrToWindow, System.Web.UI.Page).GetType, _
                                                                "ModalWindow", Script)
        End If
    End Sub

    ''' <summary>
    '''     Opens a PopUp in the Client machine.
    ''' </summary>
    ''' <param name="strScriptTitle">The script identifier</param>
    ''' <param name="NewPage">The name of the new page</param>
    ''' <param name="ptrToWindow">A page object where the popup creating code will be added.</param>
    ''' <param name="title">The popup title</param>
    ''' <param name="width">The Popup width</param>
    ''' <param name="height">The popup height</param>
    ''' <param name="top">The popup starting top position</param>
    ''' <param name="left">The popup starting Left Position</param>
    ''' <param name="scrollbars">True: Show scrollbars, False: Don't use scrollbars</param>
    ''' <param name="resizable">"True: Allows the popup to be resize by the user</param>
    ''' <param name="RedirectToThisPage">The address of the content that will be display in the popup</param>
    Public Shared Sub OpenAPopUpWindow(ByVal strScriptTitle As String, ByVal NewPage As String, ByVal ptrToWindow As Object, _
                                       Optional ByVal title As String = "", _
                                       Optional ByVal width As Integer = 100, _
                                       Optional ByVal height As Integer = 100, _
                                       Optional ByVal top As Integer = 0, _
                                       Optional ByVal left As Integer = 0, _
                                       Optional ByVal scrollbars As Boolean = False, _
                                       Optional ByVal resizable As Boolean = False, _
                                       Optional ByVal RedirectToThisPage As String = "")
        'Opens a new window with the specified values.
        Dim strScroll As String = "no"
        Dim strResize As String = "no"
        Dim script As String
        If RedirectToThisPage = String.Empty Then
            script = "<script language='javascript'> " & _
                     "details = window.open('ADDPAGE', 'ADDTITLE', 'height=h*#, width=w*#, top=t*#, left=l*#,scrollbars=S*#,resizable=R*#'); " & _
                     "details.focus(); " & _
                     "</script> "
        Else
            script = "<script language='javascript'> " & _
                     "details = window.open('ADDPAGE', 'ADDTITLE', 'height=h*#, width=w*#, top=t*#, left=l*#,scrollbars=S*#,resizable=R*#'); " & _
                     "details.focus(); " & _
                     "window.location='" & RedirectToThisPage & "';" & _
                     "</script> "
        End If

        If scrollbars Then strScroll = "yes"
        If resizable Then strResize = "yes"

        script = Replace(script, "ADDPAGE", NewPage.Replace("'", "\'")).Replace(Chr(10), "\n").Replace(Chr(13), "\n")
        script = Replace(script, "ADDTITLE", title)
        script = Replace(script, "h*#", CStr(height))
        script = Replace(script, "w*#", CStr(width))
        script = Replace(script, "t*#", CStr(top))
        script = Replace(script, "l*#", CStr(left))
        script = Replace(script, "S*#", strScroll)
        script = Replace(script, "R*#", strResize)

        If (Not CType(ptrToWindow, System.Web.UI.Page).ClientScript.IsClientScriptBlockRegistered(strScriptTitle)) Then
            CType(ptrToWindow, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(ptrToWindow, System.Web.UI.Page).GetType, _
                                                                                          strScriptTitle, script)
        End If

        'CType(ptrToWindow, System.Web.UI.Page).RegisterClientScriptBlock("textScript", script)
    End Sub

    Public Shared Sub JavascriptRedirectPopup(ByVal ptrToPage As Object, Optional ByVal widthWinPopUp As Integer = 900, Optional ByVal heightWinPopUp As Integer = 600)
        '/*  eventTarget has the URL to be redirected to.
        '    eventArguments contain a string that needs to be parsed.
        '	The First Element must be the RowNumber. The Remaining Elements are 
        '	The values that needs to be send. The ID in the control should be the same as the 
        '	variable that is being send. */

        Dim Script As String
        Script = "<script language='javascript'> " & _
                 "function goToNextReportPopup(eventTarget, eventArgument){" & _
                            "myString = new String(eventArgument);" & _
                            "myItems = myString.split('|');" & _
                            "myParameters = new String(); " & _
                            "myParameters2 = new String(); " & _
                            "iRowNumber = myItems[0];" & _
                            "for (i = 1; i < myItems.length ; i++){ " & _
                                "if (!(myItems[i].indexOf('=') > 0)) { " & _
                                    "myParameters += myItems[i] + '=' + document.getElementById(myItems[i] + iRowNumber).innerHTML + '&' ; " & _
                                "} else {" & _
                                    "myParameters2 += myItems[i] + '&';" & _
                                "}" & _
                            "} " & _
                         "details = window.open(eventTarget + '?' + myParameters + myParameters2 + '&IsPopup=1','_blank','width=" & widthWinPopUp & ",height=" & heightWinPopUp & ",scrollbars');" & _
                         "details.focus(); " & _
                         "}" & "</script> "

        If (Not CType(ptrToPage, System.Web.UI.Page).ClientScript.IsClientScriptBlockRegistered("redirectScript")) Then
            CType(ptrToPage, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(ptrToPage, System.Web.UI.Page).GetType, _
                                                                                        "redirectScript", Script)
        End If
    End Sub
    Public Shared Sub JavascriptRedirect(ByVal ptrToPage As Object)
        '/*  eventTarget has the URL to be redirected to.
        '    eventArguments contain a string that needs to be parsed.
        '	The First Element must be the RowNumber. The Remaining Elements are 
        '	The values that needs to be send. The ID in the control should be the same as the 
        '	variable that is being send. */

        Dim Script As String
        Script = "<script language='javascript'>" & _
                        "function goToNextReport(eventTarget, eventArgument){ " & _
                            "myString = new String(eventArgument);" & _
                            "myItems = myString.split('|');" & _
                            "myParameters = new String(); " & _
                            "myParameters2 = new String(); " & _
                            "iRowNumber = myItems[0];" & _
                            "for (i = 1; i < myItems.length ; i++){ " & _
                                "if (!(myItems[i].indexOf('=') > 0)) { " & _
                                    "myParameters += myItems[i] + '=' + document.getElementById(myItems[i] + iRowNumber).innerHTML + '&' ; " & _
                                "} else {" & _
                                    "myParameters2 += myItems[i] + '&';" & _
                                "}" & _
                            "} " & _
                            "window.location = eventTarget + '?' + myParameters + myParameters2; " & _
                        "}" & "</script>"

        If (Not CType(ptrToPage, System.Web.UI.Page).ClientScript.IsClientScriptBlockRegistered("redirectScript")) Then
            CType(ptrToPage, System.Web.UI.Page).ClientScript.RegisterClientScriptBlock(CType(ptrToPage, System.Web.UI.Page).GetType, "redirectScript", Script)
        End If
    End Sub

    ''' <summary>
    '''     Opens a dialog window where the user needs to confirm or deny before continuing
    ''' </summary>
    ''' <param name="strMessage">The message to be displayed in the box.</param>
    ''' <param name="strButtonName">The button name to be submitted so the page can be process again.</param>
    ''' <param name="ptrToPage">A pointer to the page that's going to receive the script.</param>
    Public Shared Sub ShowConfirmationMessage(ByVal strMessage As String, _
                                              ByVal strButtonName As String, _
                                              Optional ByVal getElementByID As Boolean = False, _
                                              Optional ByVal strResultsField As String = "txtResults")
        'A Message 
        Dim txtScript As New System.Text.StringBuilder

        If Not HttpContext.Current.Request.Browser.VBScript Then
            strResultsField = strResultsField.Replace(":", "_")
        End If

        txtScript.Append(vbCrLf & "<script language=""JavaScript"">" & vbCrLf)
        txtScript.Append("var theform;" & vbCrLf)
        txtScript.Append("theform = document.Form1;" & vbCrLf)
        txtScript.Append("theform.onsubmit=""""; " & vbCrLf)
        txtScript.Append("document.getElementById('" & strResultsField & "').value = ""No"";" & vbCrLf)
        txtScript.Append("if ( confirm(""" & strMessage & """) ) {" & vbCrLf)
        txtScript.Append("document.getElementById('" & strResultsField & "').value = ""Yes"";" & vbCrLf)
        txtScript.Append("}" & vbCrLf)
        If Not getElementByID Then
            txtScript.Append("theform." & strButtonName & ".click();" & vbCrLf)
        Else
            txtScript.Append("document.getElementById(""" & strButtonName & """).click();" & vbCr)
        End If
        txtScript.Append("</script>" & vbCrLf)

        'ptrToPage.RegisterStartupScript("MessageBoxScript", txtScript.ToString)
        CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).ClientScript.RegisterStartupScript(CType(SessionUtilidades.HttpContextPage.Handler, System.Web.UI.Page).GetType, "MessageBoxScript", _
                                                                                                txtScript.ToString)
    End Sub


    ''' <summary>
    '''     Registers a default Submit button. 
    '''     By default, when hitting enter, .NET will submit the first control it finds in the code.
    '''     This way the default button can be changed.     
    ''' </summary>
    ''' <param name="strButton_ClientID">The Client ID (Name) of the new default button</param>
    ''' <param name="ptrToPage">A reference to the page where the script will be inserted.</param>
    Public Shared Sub RegisterDefaultSubmitButton(ByVal strButton_ClientID As String, _
                                                  ByVal ptrToPage As System.Web.UI.Page)
        'This script catches the return or enter key and forces the page to submit the button
        'indicated by strButton_ClientID
        Dim strScript As String

        strScript = "<script language=""javascript""> " & vbCr & _
                    "   function catchEnter(){ " & vbCr & _
                    "       if(event.keyCode == 13){ " & vbCr & _
                    "           __doPostBack('" & strButton_ClientID & "',''); " & vbCr & _
                    "           return false; " & vbCr & _
                    "       } " & vbCr & _
                    "       else " & vbCr & _
                    "          return true;" & vbCr & _
                    "   } " & vbCr & _
                    "</script>"

        'strScript = strScript.Replace("BBBB", strButton_ClientID)
        ptrToPage.ClientScript.RegisterClientScriptBlock(ptrToPage.GetType, "DefaultButton", strScript)
    End Sub


    Public Shared Sub IsValidABA(ByVal strABA As String, _
                                                 ByVal ptrToPage As System.Web.UI.Page)

        Dim strScript As String
        strScript = "<script language=""javascript""> " & vbCr & _
            "   function validABA(Number) {" & vbCr & _
            "   if (Number.length != 9 ) return false; " & vbCr & _
            "   sum = 0;" & vbCr & _
            "   for (i = 0; i < Number.length; i += 3) {" & vbCr & _
            "   sum += parseInt(Number.charAt(i), 10) * 3 " & vbCr & _
            "   +parseInt(Number.charAt(i + 1), 10) * 7 " & vbCr & _
            "   + parseInt(Number.charAt(i + 2),10); " & vbCr & _
            "   } " & vbCr & _
            "   if (sum != 0 && sum % 10 == 0) return true; " & vbCr & _
            "   else return false; " & vbCr & _
            "   } " & vbCr & _
            "</script>"


        ptrToPage.ClientScript.RegisterClientScriptBlock(ptrToPage.GetType, "DefaultButton", strScript)
    End Sub

    Public Shared Sub DisableBtnSend(ByVal strBtnSend As String, _
                                    ByVal strBtnValidate As String, _
                                    ByVal ptrToPage As System.Web.UI.Page)

        Dim strScript As String

        strScript = "<script language=""javascript""> " & vbCr & _
    "   function DisableBtnSend() {" & vbCr & _
    "   if (document.getElementByID('ValidateControl:_btnValidate').disabled==true)" & vbCr & _
    "   document.getElementById('btnSend').disabled=false;" & vbCr & _
    "   } " & vbCr & _
    "</script>"

        '        strScript = "<script language=""javascript""> " & vbCr & _
        '"   function DisableBtnSend() {" & vbCr & _
        '"   document.getElementById('Button1').disabled=true;" & vbCr & _
        '"   document.getElementById('btnSend').disabled=true;" & vbCr & _
        '"   if (document.getElementByID('ValidateControl:_btnValidate').disabled==true)" & vbCr & _
        '"   document.getElementById('btnSend').disabled=false;" & vbCr & _
        '"   } " & vbCr & _
        '"</script>"


        ptrToPage.ClientScript.RegisterClientScriptBlock(ptrToPage.GetType, "disabledBtnSend", strScript)
    End Sub


    Public Shared Sub ScriptRequestFromDBMT( _
                                    ByVal ptrToPage As System.Web.UI.Page, _
                                    ByVal strScript As String)

        ptrToPage.ClientScript.RegisterClientScriptBlock(ptrToPage.GetType, "PaymetObjectFromDBMT", strScript)

    End Sub

End Class
