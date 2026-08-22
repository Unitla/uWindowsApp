Imports uWindowsApp.Validators
Imports uWindowsApp.Entities
Imports uWindowsApp.Interfaces

Public Class PatientPresenter
    Private ReadOnly _view As IPatientView
    Private ReadOnly _repository As IPatientRepository
    Private ReadOnly _validator As AbstractValidator(Of Patient)

    Public Sub New(view As IPatientView, repository As IPatientRepository, validator As AbstractValidator(Of Patient))
        _view = view
        _repository = repository
        _validator = validator
        AddHandler _view.SaveRequested, AddressOf OnSaveRequested
    End Sub

    Private Async Sub OnSaveRequested(sender As Object, e As EventArgs)
        Dim patient = _view.GetPatientInput()

        Dim result = Await _validator.ValidateAsync(patient)

        If Not result.IsValid Then
            _view.ShowValidationErrors(result)
            Return
        End If

        If _view.Mode = PatientViewMode.CREATE Then
            Await _repository.Add(patient)
        Else
            Await _repository.Update(patient)
        End If

        _view.CloseView()
    End Sub
End Class
