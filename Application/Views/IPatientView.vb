Imports uWindowsApp.Validators
Imports uWindowsApp.Entities

Public Interface IPatientView

    ReadOnly Property Mode As PatientViewMode

    Sub ShowValidationErrors(result As ValidationResult)

    Function GetPatientInput() As Patient

    Event SaveRequested As EventHandler

    Sub DisplayPatient(patient As Patient)
    Sub CloseView()

End Interface
