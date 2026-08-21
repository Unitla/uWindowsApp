Public Interface ILoginView

    ReadOnly Property Username As String

    ReadOnly Property Password As String

    Event LoginRequested As EventHandler

    Sub ShowLoginError(message As String)

    Sub LoginSucceeded()

End Interface