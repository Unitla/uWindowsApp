Public Class LoginPresenter

    Private ReadOnly _view As ILoginView
    Private ReadOnly _authenticationService As IAuthenticationService

    Public Sub New(
        view As ILoginView,
        authenticationService As IAuthenticationService)

        _view = view
        _authenticationService = authenticationService

        AddHandler _view.LoginRequested,
            AddressOf OnLoginRequested

    End Sub

    Private Sub OnLoginRequested()
        Dim result = _authenticationService.Authenticate(
            _view.Username,
            _view.Password)

        If Not result.IsSuccess Then
            _view.ShowLoginError(result.ErrorMessage)
            Return
        End If

        ' login successful
        MessageBox.Show($"Welcome, {result.User.Name}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        _view.LoginSucceeded()

    End Sub

End Class