Imports Microsoft.VisualBasic.ApplicationServices

Public Class LoginResult

    Public ReadOnly Property IsSuccess As Boolean

    Public ReadOnly Property User As User

    Public ReadOnly Property ErrorMessage As String

    Private Sub New(
        isSuccess As Boolean,
        user As User,
        errorMessage As String)

        Me.IsSuccess = isSuccess
        Me.User = user
        Me.ErrorMessage = errorMessage

    End Sub

    Public Shared Function Success(user As User) As LoginResult

        Return New LoginResult(True, user, Nothing)

    End Function

    Public Shared Function Failure(
        message As String) As LoginResult

        Return New LoginResult(False, Nothing, message)

    End Function

End Class