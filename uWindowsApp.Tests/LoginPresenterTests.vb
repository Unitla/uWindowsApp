Imports System
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports uWindowsApp
Imports uWindowsApp.Entities

<TestClass()>
Public Class LoginPresenterTests

    <TestMethod()>
    Public Sub OnLoginRequested_FailedAuthentication_ShowsError()
        Dim mockView = New Mock(Of ILoginView)()
        mockView.SetupGet(Function(v) v.Username).Returns("user")
        mockView.SetupGet(Function(v) v.Password).Returns("wrong")

        Dim failResult = LoginResult.Failure("Invalid credentials")
        Dim mockAuth = New Mock(Of IAuthenticationService)()
        mockAuth.Setup(Function(a) a.Authenticate(It.IsAny(Of String)(), It.IsAny(Of String)())).Returns(failResult)

        Dim presenter = New LoginPresenter(mockView.Object, mockAuth.Object)

        ' Raise the LoginRequested event on the mock view
        mockView.Raise(Sub(m) AddHandler m.LoginRequested, EventArgs.Empty)

        mockView.Verify(Sub(v) v.ShowLoginError(It.Is(Of String)(Function(s) s.Contains("Invalid"))), Times.Once())
    End Sub

    <TestMethod()>
    Public Sub OnLoginRequested_SuccessfulAuthentication_InvokesLoginSucceeded()
        Dim mockView = New Mock(Of ILoginView)()
        mockView.SetupGet(Function(v) v.Username).Returns("user")
        mockView.SetupGet(Function(v) v.Password).Returns("pass")

        Dim user = New User With {.Id = "1", .Name = "Test"}
        Dim success = LoginResult.Success(user)
        Dim mockAuth = New Mock(Of IAuthenticationService)()
        mockAuth.Setup(Function(a) a.Authenticate(It.IsAny(Of String)(), It.IsAny(Of String)())).Returns(success)

        Dim presenter = New LoginPresenter(mockView.Object, mockAuth.Object)

        mockView.Raise(Sub(m) AddHandler m.LoginRequested, EventArgs.Empty)

        mockView.Verify(Sub(v) v.LoginSucceeded(), Times.Once())
    End Sub

End Class
