Imports uWindowsApp.Queries
Imports uWindowsApp.Entities

Public Interface IMainView

    Event SearchRequested As EventHandler

    Event NextPageRequested As EventHandler

    Event PreviousPageRequested As EventHandler

    Event AddPatientRequested As EventHandler

    Event EditRequested As EventHandler(Of PatientEventArgs)

    Event DeleteRequested As EventHandler(Of PatientEventArgs)

    Event LogoutRequested As EventHandler

    Event ViewLoaded As EventHandler

    ReadOnly Property SearchText As String

    ReadOnly Property SearchField As PatientSearchField

    Sub DisplayPatients(patients As IReadOnlyList(Of Patient))

    Sub UpdatePagination(
        currentPage As Integer,
        totalPages As Integer)

    Sub ShowMessage(message As String)

    Sub ShowError(message As String)

End Interface