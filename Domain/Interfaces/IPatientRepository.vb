
Imports uWindowsApp.Entities
Imports uWindowsApp.Queries

Namespace Interfaces

    Public Interface IPatientRepository

        Function Search(
        criteria As PatientSearchCriteria
    ) As Task(Of PagedResult(Of Patient))

        Function GetById(id As Integer) As Task(Of Patient)

        Function Add(patient As Patient) As Task

        Function Update(patient As Patient) As Task

        Function Delete(id As Integer) As Task

    End Interface

End Namespace