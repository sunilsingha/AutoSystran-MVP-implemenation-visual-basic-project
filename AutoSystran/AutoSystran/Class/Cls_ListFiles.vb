Public Class Cls_ListFiles

    Protected m_FileName As String()
    Public Property FileName() As String()
        Get
            Return Me.m_FileName
        End Get
        Set(value As String())
            Me.m_FileName = value
        End Set
    End Property

    Protected m_FilePath As String()
    Public Property FilePath() As String()
        Get
            Return Me.m_FilePath
        End Get
        Set(value As String())
            Me.m_FilePath = value
        End Set
    End Property

    Public Sub GetFilesFromInputfolder(ByVal InputFolder As String)

        Dim fileNames = My.Computer.FileSystem.GetFiles(InputFolder, FileIO.SearchOption.SearchTopLevelOnly)
        Dim FName As String
        Dim Counter As Integer = 0

        For Each fileName As String In fileNames
            FName = Mid(fileName, InStrRev(fileName, "\") + 1, Len(fileName))
            If Right(FName, 4) = ".txt" Then
                ReDim Preserve m_FileName(Counter)
                ReDim Preserve m_FilePath(Counter)
                m_FileName(Counter) = FName
                m_FilePath(Counter) = fileName
                Counter = Counter + 1
            End If
        Next fileName

    End Sub

End Class
