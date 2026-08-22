Imports uWindowsApp.Entities
Imports uWindowsApp.Infrastructure.Validation.Rules

Namespace Validators
    Public Class PatientValidator
        Inherits AbstractValidator(Of Patient)

        Public Sub New()
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.Name, "Imię", 2, 100))
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.Surname, "Nazwisko", 2, 100))
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.Address, "Adres", 5, 200))
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.PhoneNumber, "Numer telefonu", 9, 15))
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.AreaCode, "Numer kierunkowy", 2, 10))
            AddRule(New StringLengthRule(Of Patient)(Function(p) p.Email, "Email", 5, 100))
            AddRule(New ExternalPESELRule())
            AddRule(New EmailFormatRule())
            'AddRule(New StringOnlyNumericCharsRule(Of Patient)(Function(p) p.PESEL), "PESEL")
            'AddRule(New StringOnlyNumericCharsOrSpaceRule(Of Patient)(Function(p) p.PhoneNumber), "Numer telefonu")
            'AddRule(New StringAreaCodeCustomRule(Of Patient)(Function(p) p.AreaCode), "Numer kierunkowy")

        End Sub

    End Class
End Namespace
