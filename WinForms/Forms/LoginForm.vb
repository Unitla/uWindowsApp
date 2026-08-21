Public Class LoginForm
    Implements ILoginView

    Public Event LoginRequested As EventHandler Implements ILoginView.LoginRequested

    Public ReadOnly Property Username As String Implements ILoginView.Username
        Get
            Return EmailTextBox.Text
        End Get
    End Property

    Public ReadOnly Property Password As String Implements ILoginView.Password
        Get
            Return PasswordTextBox.Text
        End Get
    End Property

    Public Sub ShowLoginError(message As String) Implements ILoginView.ShowLoginError
        ErrorLabel.Text = message
    End Sub

    Public Sub LoginSucceeded() Implements ILoginView.LoginSucceeded
        ' Signal to the caller (Program.Main) that login succeeded by setting the dialog
        ' result. Program.Main is responsible for creating and showing the main form
        ' and wiring up the presenter so the DataGridView will be populated.
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(
        sender As Object,
        e As EventArgs) Handles LogInButton.Click

        RaiseEvent LoginRequested(Me, EventArgs.Empty)

    End Sub

End Class