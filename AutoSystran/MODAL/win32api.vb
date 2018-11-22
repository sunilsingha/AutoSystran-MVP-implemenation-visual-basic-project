Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Text


Public Class win32api

    Private Const WM_SETTEXT As Long = &HC
    Private Const WM_click As Integer = 245
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_CHAR As Integer = &H102
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const VK_TAB As Integer = &H9
    Private Const VK_RETURN As Integer = &HD

    Private Const WM_GETTEXT As UInteger = &HD
    Private Const WM_GETTEXTLENGTH As UInteger = &HE

    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32

    Public Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA" (ByVal hWnd1 As Int32, ByVal hWnd2 As Int32, ByVal lpsz1 As String, ByVal lpsz2 As String) As Int32

    Public Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Int32) As Int32

    Public Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As Int32, ByVal nCmdShow As Int32) As Int32

    Public Declare Function SetWindowText Lib "user32.dll" Alias "SetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String) As Int32

    <DllImport("user32", SetLastError:=True)> _
    Private Shared Function EnumChildWindows( _
    ByVal hWndParent As IntPtr, _
    ByVal enumProcDelegate As EnumChildProcDelegate, _
    ByVal lParam As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA" (ByVal hwnd As Int32, ByVal lpClassName As String, ByVal nMaxCount As Int32) As Int32

    Public Declare Function EnumWindows Lib "user32.dll" (ByVal lpEnumFunc As Int32, ByVal lParam As Int32) As Int32

    Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As StringBuilder, ByVal cch As Int32) As Int32

    <DllImport("user32", SetLastError:=True)> _
    Public Shared Function SendMessage( _
    ByVal hWnd As IntPtr, _
    ByVal message As UInteger, _
    ByVal wParam As IntPtr, _
    ByVal lParam As String) As Integer
    End Function

    <DllImport("user32", SetLastError:=True)> _
    Public Shared Function SendMessage( _
    ByVal hWnd As IntPtr, _
    ByVal message As UInteger, _
    ByVal wParam As Integer, _
    ByVal lParam As StringBuilder) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Shared Function PostMessage(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.U4)> ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Boolean
    End Function

    Private Delegate Function EnumChildProcDelegate(ByVal hWnd As IntPtr, ByVal lParam As IntPtr) As Boolean

    Public Function GetParentHandle(ByVal WindowCaption As String) As Int32
        Dim Hwnd As Int32 = FindWindow(Nothing, WindowCaption)
        Return Hwnd
    End Function

    Public Function GetChildHandles(ByVal hParent As Int32) As Boolean
        Try
            handleCaption.Clear()
            handleList.Clear()
            Dim del As New EnumChildProcDelegate(AddressOf EnumChildProc)
            ' The return value is not used: 
            EnumChildWindows(hParent, del, IntPtr.Zero)
        Catch ex As Exception
            Throw New Exception("Error getting child handles!" & vbNewLine & ex.Message)
        End Try
        Return True
    End Function

    Private Function EnumChildProc(ByVal hWndChild As IntPtr, ByVal lParam As IntPtr) As Boolean
        Try
            Dim length As Integer = SendMessage(hWndChild, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero)
            Dim captionBuilder As New StringBuilder(length + 1)
            If length > 0 Then
                Dim result As Integer = SendMessage(hWndChild, WM_GETTEXT, captionBuilder.Capacity, captionBuilder)
            End If

            handleList.Add(hWndChild)
            handleCaption.Add(captionBuilder.ToString)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

    Public handleList As New ArrayList
    Public handleCaption As New ArrayList

End Class
