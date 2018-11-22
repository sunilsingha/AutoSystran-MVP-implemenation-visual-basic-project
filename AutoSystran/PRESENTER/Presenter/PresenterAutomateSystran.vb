Public Class PresenterAutomateSystran

    Dim _view As iView
    Dim _model As iModel

    Public Sub New(ByVal view As iView, ByVal model As iModel)
        _view = view
        _model = model
    End Sub

    Public Sub StartAutomation()
        _model.StartAutomation(_view.LangFrom, _view.LangTo, _view.InputFile)
    End Sub

    Public Sub StopeAutomation()
        _model.StopAutomation()
    End Sub

End Class
