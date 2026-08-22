Imports Application.Views

Public Class PatientViewFactory
    Implements IPatientViewFactory

    Public Function Create(mode As PatientViewMode) As IPatientView Implements IPatientViewFactory.Create
        Return New PatientForm(mode)
    End Function

End Class
