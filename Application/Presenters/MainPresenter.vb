Imports Microsoft.VisualBasic.ApplicationServices
Imports uWindowsApp.Entities
Imports uWindowsApp.Validators
Imports uWindowsApp.Interfaces
Imports uWindowsApp.Queries

Public Class MainPresenter

    Private ReadOnly _view As IMainView
    Private ReadOnly _patientRepository As IPatientRepository
    Private ReadOnly _patientValidator As AbstractValidator(Of Patient)
    Private ReadOnly _patientViewFactory As IPatientViewFactory

    Private _currentPatients As IReadOnlyList(Of Patient) = Array.Empty(Of Patient)()

    Private _currentPage As Integer = 1
    Private Const PageSize As Integer = 20
    Private _currentSearchField As PatientSearchField = PatientSearchField.PESEL
    Private _currentSearchText As String = String.Empty
    Private _totalPages As Integer

    Public Sub New(
        view As IMainView,
        patientRepository As IPatientRepository,
        patientValidator As AbstractValidator(Of Patient),
        patientViewFactory As IPatientViewFactory)

        _view = view
        _patientRepository = patientRepository
        _patientValidator = patientValidator
        _patientViewFactory = patientViewFactory


        AddHandler _view.SearchRequested,
            AddressOf OnSearchRequested

        AddHandler _view.NextPageRequested,
            AddressOf OnNextPageRequested

        AddHandler _view.PreviousPageRequested,
            AddressOf OnPreviousPageRequested

        AddHandler _view.DeleteRequested,
            AddressOf OnDeleteRequested

        AddHandler _view.EditRequested,
            AddressOf OnEditRequested

        AddHandler _view.AddPatientRequested,
            AddressOf OnAddPatientRequested

        AddHandler _view.LogoutRequested,
            AddressOf OnLogoutRequested

        AddHandler _view.ViewLoaded,
            AddressOf OnViewLoaded

    End Sub

    Private Sub OnLogoutRequested(sender As Object, e As EventArgs)
        ' Restart the application so the composition root (Program.Main) will show the login form again.
        If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Restart()
        End If
    End Sub

    Private Async Sub OnAddPatientRequested(sender As Object, e As EventArgs)
        Dim view = _patientViewFactory.Create(PatientViewMode.CREATE)
        Dim presenter As New PatientPresenter(view, _patientRepository, _patientValidator)

        ' If the view implements a dialog show pattern, let it present itself.
        If TypeOf view Is System.Windows.Forms.Form Then
            DirectCast(view, System.Windows.Forms.Form).ShowDialog()
        End If

        Await LoadPatients()
    End Sub

    Private Async Sub OnSearchRequested(sender As Object, e As EventArgs)
        ' Update search criteria and reload patients from the repository
        _currentPage = 1
        _currentSearchField = _view.SearchField
        _currentSearchText = _view.SearchText

        Await LoadPatients()
    End Sub

    Private Async Sub OnEditRequested(sender As Object, e As PatientEventArgs)
        Dim patient = Await _patientRepository.GetById(e.PatientId)

        Dim view = _patientViewFactory.Create(PatientViewMode.EDIT)
        view.DisplayPatient(patient)

        Dim presenter As New PatientPresenter(view, _patientRepository, _patientValidator)

        If TypeOf view Is System.Windows.Forms.Form Then
            DirectCast(view, System.Windows.Forms.Form).ShowDialog()
        End If

        Await LoadPatients()
    End Sub

    Private Async Sub OnViewLoaded(sender As Object, e As EventArgs)
        Await LoadPatients()
    End Sub

    Private Async Function LoadPatients() As Task

        Dim criteria As New PatientSearchCriteria With {
            .Field = _currentSearchField,
            .SearchText = _currentSearchText,
            .PageNumber = _currentPage,
            .PageSize = PageSize
        }

        Dim result = Await _patientRepository.Search(criteria)

        _currentPatients = result.Items

        Dim totalPages =
            CInt(Math.Ceiling(
                result.TotalCount / CDbl(PageSize)))

        _view.DisplayPatients(_currentPatients)

        _view.UpdatePagination(
            result.PageNumber,
            totalPages)

    End Function

    Private Async Sub OnNextPageRequested(
    sender As Object,
    e As EventArgs)

        _currentPage += 1

        Await LoadPatients()
    End Sub

    Private Async Sub OnPreviousPageRequested(
    sender As Object,
    e As EventArgs)

        If _currentPage <= 1 Then
            Return
        End If

        _currentPage -= 1

        Await LoadPatients()

    End Sub

    Private Async Sub OnDeleteRequested(
    sender As Object,
    p As PatientEventArgs)

        Await _patientRepository.Delete(p.PatientId)

        Await LoadPatients()

    End Sub

End Class