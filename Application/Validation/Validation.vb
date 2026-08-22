Imports System.Threading.Tasks

Namespace Validators

    ''' <summary>
    ''' Przechowuje wynik walidacji bez wyrzucania kosztownych wyjątków.
    ''' </summary>
    Public Class ValidationResult
        Public Property IsValid As Boolean = True
        Public Property Errors As New List(Of String)()

        Public Sub AddError(errorMessage As String)
            IsValid = False
            Errors.Add(errorMessage)
        End Sub
    End Class

    ''' <summary>
    ''' Interfejs reguły walidacyjnej dla dowolnego typu T (Open/Closed Principle).
    ''' </summary>
    Public Interface IValidationRule(Of T)
        Function ValidateAsync(entity As T) As Task(Of String) ' Zwraca Nothing jeśli brak błędu
    End Interface

    ''' <summary>
    ''' Klasa bazowa agregująca reguły dla konkretnego obiektu.
    ''' </summary>
    Public MustInherit Class AbstractValidator(Of T)
        Private ReadOnly _rules As New List(Of IValidationRule(Of T))()

        Protected Sub AddRule(rule As IValidationRule(Of T))
            _rules.Add(rule)
        End Sub

        Public Async Function ValidateAsync(entity As T) As Task(Of ValidationResult)
            Dim result As New ValidationResult()

            For Each rule In _rules
                Dim errorMessage As String = Await rule.ValidateAsync(entity)
                If Not String.IsNullOrEmpty(errorMessage) Then
                    result.AddError(errorMessage)
                End If
            Next

            Return result
        End Function
    End Class

End Namespace