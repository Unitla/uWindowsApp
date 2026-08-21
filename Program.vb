Imports System.Data.SqlClient
Imports uWindowsApp.Entities
Imports uWindowsApp.Interfaces
Imports uWindowsApp.Validators

Public Class Main
    Sub New()

    End Sub

    <STAThread>
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim authService As IAuthenticationService =
               New DevelopmentAuthenticationService()

        Dim loginForm As New LoginForm()

        Dim loginpresenter As New LoginPresenter(
    loginForm,
    authService)

        ' Show the login form as a modal dialog. If login succeeds (DialogResult.OK),
        ' start the main application form using Application.Run which creates the
        ' message loop for the main window.
        If loginForm.ShowDialog() = DialogResult.OK Then

            Dim mainform = New MainForm()
            Dim patientRepository As IPatientRepository = New PatientRepository(New SQLConnectionFactory())
            Dim patientValidator As AbstractValidator(Of Patient) = New PatientValidator()

            Dim patientViewFactory As IPatientViewFactory = New PatientViewFactory()

            Dim MainPresenter As New MainPresenter(mainform, patientRepository, patientValidator:=patientValidator, patientViewFactory:=patientViewFactory)
            mainform.ShowDialog()
        End If
    End Sub
End Class
