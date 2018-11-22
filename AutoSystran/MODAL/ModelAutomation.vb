Imports PRESENTER
Imports System.Text
Imports System.IO

Public Class ModelAutomation

    Implements iModel

    Const WM_SETTEXT As Long = &HC
    Const WM_click As Integer = 245
    Const WM_KEYUP As Integer = &H101
    Const WM_CHAR As Integer = &H102
    Const WM_KEYDOWN As Integer = &H100
    Const VK_TAB As Integer = &H9
    Const VK_RETURN As Integer = &HD


    Public Sub StartAutomation(FromLang As String, ToLanguage As String, sFile As String) Implements iModel.StartAutomation

        Try 'Start Systran process 
            Process.Start("C:\Program Files (x86)\Systran\Desktop\Systranfiletranslator.exe", sFile)
            System.Threading.Thread.Sleep(2000)
        Catch ex As System.ComponentModel.Win32Exception
            Throw New Exception("Systranfiletranslator.exe not found!")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Dim objwin32 As New win32api
        Dim handlelist As New ArrayList
        Dim handleCaption As New ArrayList
        Dim hwnd As Int32 = 0

        For i As Integer = 1 To 3 'Checking 3 times for parent handle if not found
            hwnd = objwin32.GetParentHandle("Save File As...")
            System.Threading.Thread.Sleep(2000)
            If hwnd <> 0 Then
                Exit For
            End If
        Next

        If hwnd = 0 Then 'If parent handle is still 0 then exit
            Throw New Exception("Cannot find Systran in active window list!")
        End If

        Dim bFoundLanguage As Boolean = False 'Check language is found, if not exit again

        Try
            '//////   Handle First Combobox Now   ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If objwin32.GetChildHandles(hwnd) Then
                handlelist = objwin32.handleList
                handleCaption = objwin32.handleCaption

                For i As Integer = 0 To handleCaption.Count - 1
                    If FindLanguageCaption(handleCaption.Item(i)) Then
                        bFoundLanguage = True
                        Dim data As New StringBuilder(65536)
                        Dim RS As IntPtr = win32api.SendMessage(handlelist(i), WM_SETTEXT, New IntPtr(data.Capacity), FromLang)
                        RS = win32api.SendMessage(handlelist(i), WM_KEYDOWN, VK_TAB, 0)
                        Exit For
                    End If
                Next

                If bFoundLanguage <> True Then
                    Throw New Exception("Didnt find language in systran combobox!")
                End If

                handlelist = Nothing
                handleCaption = Nothing

            End If
            
            '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     


            '//////   Handle Second Combobox Now   ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            If objwin32.GetChildHandles(hwnd) Then
                handlelist = objwin32.handleList
                handleCaption = objwin32.handleCaption

                For i As Integer = 0 To handleCaption.Count - 1
                    If FindLanguageCaption(handleCaption.Item(i)) Then
                        Dim data As New StringBuilder(65536)
                        Dim RS As IntPtr = win32api.SendMessage(handlelist(i), WM_SETTEXT, New IntPtr(data.Capacity), ToLanguage)
                        Exit For
                    End If
                Next

                If bFoundLanguage <> True Then
                    Throw New Exception("Didnt find language in systran combobox!")
                End If

                For i As Integer = 0 To handleCaption.Count - 1
                    If handleCaption.Item(i) = "Translate" Then
                        win32api.PostMessage(handlelist(i), WM_KEYDOWN, VK_RETURN, 0)
                        Exit For
                    End If
                Next

                handlelist = Nothing
                handleCaption = Nothing
            End If
            '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

            Threading.Thread.Sleep(2000)
            hwnd = objwin32.GetParentHandle("Confirm file replace") 'If file already translated then Overwrite
            If hwnd > 0 Then
                If objwin32.GetChildHandles(hwnd) Then
                    handlelist = objwin32.handleList
                    handleCaption = objwin32.handleCaption
                    For i As Integer = 0 To handleCaption.Count
                        If handleCaption(i) = "&Yes" Then
                            win32api.PostMessage(handlelist(i), WM_click, 0, IntPtr.Zero)
                            Exit For
                        End If
                    Next
                End If
            End If

            Threading.Thread.Sleep(3000)

            hwnd = objwin32.GetParentHandle("Translation") 'Loop until handle is 0, this ensures translation is done and saved.
            Do Until hwnd = 0
                hwnd = objwin32.GetParentHandle("Translation")
            Loop
        Catch ex As Exception
            Throw New Exception("Error in StartAutomation!" & vbNewLine & ex.Message)
        End Try

    End Sub


    Private Function FindLanguageCaption(ByVal lang As String) As Boolean
        Select Case LCase(lang)
            Case "chinese"
                Return True
            Case "german"
                Return True
            Case "japanese"
                Return True
            Case "spanish"
                Return True
            Case "english"
                Return True
            Case "french"
                Return True
            Case "portugese"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Sub StopAutomation() Implements iModel.StopAutomation
        Throw New Exception("Stopped by user forcefully!")
    End Sub

End Class
