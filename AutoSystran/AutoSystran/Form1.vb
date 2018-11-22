Imports PRESENTER
Imports MODAL
Public Class Form_Main

    Implements PRESENTER.iView

    Protected m_Inputfile As String
    Public ReadOnly Property InputFile As String Implements iView.InputFile
        Get
            Return Me.m_Inputfile
        End Get
    End Property

    Protected m_LangFrom As String
    Public ReadOnly Property LangFrom As String Implements iView.LangFrom
        Get
            Return Me.m_LangFrom
        End Get
    End Property

    Protected m_langTo As String
    Public ReadOnly Property LangTo As String Implements iView.LangTo
        Get
            Return Me.m_langTo
        End Get
    End Property
    Private Sub CmbFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFrom.SelectedIndexChanged
        Me.m_LangFrom = CmbFrom.Text
    End Sub

    Private Sub CmbTo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTo.SelectedIndexChanged
        Me.m_langTo = CmbTo.Text
    End Sub

    Private objPresenter As PresenterAutomateSystran

    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbFrom.SelectedIndex = 0
        CmbTo.SelectedIndex = 0
        Dim model As ModelAutomation
        model = New ModelAutomation
        objPresenter = New PresenterAutomateSystran(Me, model)
    End Sub

    Private objListFile As New Cls_ListFiles

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Try
            Dim Bdialog As New FolderBrowserDialog
            Bdialog.Description = "Select Input Folder"
            If Bdialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                TxtBoxInputPath.Text = Bdialog.SelectedPath
                objListFile.GetFilesFromInputfolder(Bdialog.SelectedPath)
                Dim LastIndex As Integer = 0

                Try
                    LastIndex = objListFile.FilePath.Count
                Catch ex As System.ArgumentNullException
                    Throw New Exception("No text files found for translation!")
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

                MsgLog.Clear()

                MsgLog.AppendText("Number of Files Found - " & LastIndex & vbNewLine)
                MsgLog.AppendText("***************************************************" & vbNewLine)
                For i As Integer = 0 To LastIndex - 1
                    MsgLog.AppendText(objListFile.FileName(i) & vbNewLine)
                    MsgLog.SelectionStart = MsgLog.TextLength
                    MsgLog.ScrollToCaret()
                Next
                MsgLog.AppendText("***************************************************" & vbNewLine)

                BtnStart.Enabled = True
                BtnStop.Enabled = BtnStart.Enabled = True

            End If
        Catch ex As Exception
            BtnStart.Enabled = False
            BtnStop.Enabled = False
            MsgBox(ReadException(ex), MsgBoxStyle.Critical, "Auto Systran")
        End Try
        
    End Sub


    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        EnableDisableControls(False)
        Try
            If ValidateControls() <> True Then
                'do nothing
            End If
        Catch ex As Exception
            EnableDisableControls(True)
            MsgBox(ReadException(ex), MsgBoxStyle.Critical, "Auto Systran")
            Exit Sub
        End Try

        bStopBW = False

        If BW_Main.IsBusy <> True Then
            BW_Main.RunWorkerAsync()
        End If

    End Sub

    Private Function ValidateControls() As Boolean
        If CmbFrom.SelectedIndex = 0 Or CmbTo.SelectedIndex = 0 Then
            Throw New Exception("Please Select From and To language from the list!")
        End If

        If (CmbFrom.SelectedIndex = CmbTo.SelectedIndex) Then
            Throw New Exception("From and To language cannot be same!")
        End If
        Return True
    End Function


    Private bStopBW As Boolean
    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Try
            bStopBW = True
            objPresenter.StopeAutomation()
        Catch ex As Exception
            MsgBox(ReadException(ex), MsgBoxStyle.Critical, "Auto Systran")
        End Try

    End Sub

    Private Sub BW_Main_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW_Main.DoWork
        Try
            Dim LastIndex As Integer = objListFile.FileName.Count
            For i As Integer = 0 To LastIndex - 1
                If bStopBW Then
                    Exit For
                End If
                Me.m_Inputfile = objListFile.FilePath(i)
                objPresenter.StartAutomation()
                BW_Main.ReportProgress(i)
            Next

        Catch ex As Exception
            BW_Main.ReportProgress(99999)
            MsgBox(ReadException(ex), MsgBoxStyle.Critical, "Auto Systran")
        End Try
    End Sub

    Private Sub BW_Main_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BW_Main.ProgressChanged

        If e.ProgressPercentage = 99999 Then
            EnableDisableControls(True)
            Exit Sub
        End If

        MsgLog.AppendText(objListFile.FileName(e.ProgressPercentage) & " - Processed" & vbNewLine)
        MsgLog.SelectionStart = MsgLog.TextLength
        MsgLog.ScrollToCaret()

    End Sub

    Private Sub BW_Main_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW_Main.RunWorkerCompleted
        EnableDisableControls(True)
        BW_Main.CancelAsync()
    End Sub

    Private Sub EnableDisableControls(ByVal bEnable As Boolean)
        BtnBrowse.Enabled = bEnable
        BtnStart.Enabled = bEnable
        CmbFrom.Enabled = bEnable
        CmbTo.Enabled = bEnable
        TxtBoxInputPath.Enabled = bEnable
    End Sub

    Private Function ReadException(ByVal ex As Exception) As String 'Reads Error Message from Throw exception
        Dim msg As String = ex.Message
        If ex.InnerException IsNot Nothing Then
            msg = msg & vbCrLf & ReadException(ex.InnerException)
        End If
        Return msg
    End Function

End Class
