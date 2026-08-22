
Public Class DevelopmentAuthenticationService
    Implements IAuthenticationService

    Private Const DevelopmentUsername As String = "admin"
    Private Const DevelopmentPassword As String = "test123"

    Public Function Authenticate(
        username As String,
        password As String) As LoginResult _
        Implements IAuthenticationService.Authenticate

        If username = DevelopmentUsername AndAlso
           password = DevelopmentPassword Then

            Dim user As New User With {
                .Id = 1,
                .Name = username
            }

            Return LoginResult.Success(user)

        End If

        Return LoginResult.Failure(
            "Invalid username or password.")

    End Function

End Class