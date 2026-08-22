
Imports uWindowsApp.Validators
Imports uWindowsApp.Entities

Public Class PatientForm
    Implements IPatientView

    Private _mode As PatientViewMode = PatientViewMode.CREATE
    Private _patientId As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(mode As PatientViewMode)
        Me.New()
        _mode = mode
        If _mode = PatientViewMode.CREATE Then
            Me.Text = "Create Patient"
        Else
            Me.Text = "Edit Patient"
        End If
    End Sub

    Public ReadOnly Property Mode As PatientViewMode Implements IPatientView.Mode
        Get
            Return _mode
        End Get
    End Property

    Public Event SaveRequested As EventHandler Implements IPatientView.SaveRequested

    Public Sub ShowValidationErrors(result As ValidationResult) Implements IPatientView.ShowValidationErrors
        If result Is Nothing OrElse result.IsValid Then
            Return
        End If

        Dim msg = String.Join(Environment.NewLine, result.Errors)
        MessageBox.Show(msg, "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Sub DisplayPatient(patient As Patient) Implements IPatientView.DisplayPatient
        If patient Is Nothing Then Return

        _patientId = patient.Id

        NameTextBox.Text = patient.Name
        SurnameTextBox.Text = patient.Surname
        EmailTextBox.Text = patient.Email
        PESELTextBox.Text = patient.PESEL
        AddressTextBox.Text = patient.Address
        PhoneNumberTextBox.Text = patient.PhoneNumber
        AreaCodeTextBox.Text = patient.AreaCode
    End Sub

    Public Sub CloseView() Implements IPatientView.CloseView
        Me.Close()
    End Sub

    Public Function GetPatientInput() As Patient Implements IPatientView.GetPatientInput
        Dim p As New Patient()
        p.Id = _patientId
        p.Name = NameTextBox.Text.Trim()
        p.Surname = SurnameTextBox.Text.Trim()
        p.Email = EmailTextBox.Text.Trim()
        p.PESEL = PESELTextBox.Text.Trim()
        p.Address = AddressTextBox.Text.Trim()
        p.PhoneNumber = PhoneNumberTextBox.Text.Trim()
        p.AreaCode = AreaCodeTextBox.Text.Trim()
        Return p
    End Function

    Public Sub OnSaveButtonClick(sender As Object, e As EventArgs) Handles SavePatientButton.Click
        RaiseEvent SaveRequested(Me, EventArgs.Empty)
    End Sub
End Class
