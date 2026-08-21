Public Class PatientEventArgs
    Inherits EventArgs

    Public ReadOnly Property PatientId As Integer

    Public Sub New(patientId As Integer)
        Me._PatientId = patientId
    End Sub

End Class
