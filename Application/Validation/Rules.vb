Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports uWindowsApp.Entities
Imports uWindowsApp.Validators

Namespace Infrastructure.Validation.Rules

    ''' <summary>
    ''' Uniwersalna reguła sprawdzająca min/max długość tekstu.
    ''' </summary>
    Public Class StringLengthRule(Of T)
        Implements IValidationRule(Of T)

        Private ReadOnly _selector As Func(Of T, String)
        Private ReadOnly _propertyName As String
        Private ReadOnly _minLength As Integer
        Private ReadOnly _maxLength As Integer

        Public Sub New(selector As Func(Of T, String), propertyName As String, minLength As Integer, maxLength As Integer)
            _selector = selector
            _propertyName = propertyName
            _minLength = minLength
            _maxLength = maxLength
        End Sub

        Public Function ValidateAsync(entity As T) As Task(Of String) Implements IValidationRule(Of T).ValidateAsync
            Dim value As String = _selector(entity)
            Dim length As Integer = If(value IsNot Nothing, value.Trim().Length, 0)

            If length < _minLength OrElse length > _maxLength Then
                Return Task.FromResult($"{_propertyName} musi mieć długość od {_minLength} do {_maxLength} znaków.")
            End If

            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

    ''' <summary>
    ''' Walidator numeru PESEL.
    ''' </summary>
    Public Class ExternalPESELRule
        Implements IValidationRule(Of Patient)

        ' Usunięto słowo kluczowe Async, ponieważ metoda nie używa operacji 'Await'
        Public Function ValidateAsync(patient As Patient) As Task(Of String) Implements IValidationRule(Of Patient).ValidateAsync

            If String.IsNullOrWhiteSpace(patient.PESEL) Then
                Return Task.FromResult("PESEL nie może być pusty.")
            End If

            If patient.PESEL.Length <> 11 Then
                Return Task.FromResult("PESEL musi mieć dokładnie 11 znaków.")
            End If

            If Not Regex.IsMatch(patient.PESEL, "^[0-9]+$") Then
                Return Task.FromResult("PESEL może zawierać tylko cyfry.")
            End If

            ' Dekodowanie miesiąca i stulecia zgodnie ze standardem PESEL
            Dim rawMonth As Integer = Convert.ToInt32(patient.PESEL.Substring(2, 2))
            Dim day As Integer = Convert.ToInt32(patient.PESEL.Substring(4, 2))
            Dim year As Integer = Convert.ToInt32(patient.PESEL.Substring(0, 2))
            Dim month As Integer = rawMonth

            Select Case rawMonth
                Case 1 To 12
                    year += 1900
                Case 21 To 32
                    year += 2000
                    month -= 20
                Case 41 To 52
                    year += 2100
                    month -= 40
                Case 61 To 72
                    year += 2200
                    month -= 60
                Case 81 To 92
                    year += 1800
                    month -= 80
                Case Else
                    Return Task.FromResult("Nieprawidłowy miesiąc w numerze PESEL.")
            End Select

            Dim requiredDateFormat As String = "ddMMyyyy"
            Dim PESELDATE As String = $"{day:D2}{month:D2}{year:D4}"

            If Not DateTime.TryParseExact(PESELDATE, requiredDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, Nothing) Then
                Return Task.FromResult("Nieprawidłowa data w numerze PESEL.")
            End If

            ' Obliczanie sumy kontrolnej
            Dim weights As Integer() = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3}
            Dim sum As Integer = 0

            For i As Integer = 0 To 9
                sum += CInt(Char.GetNumericValue(patient.PESEL(i))) * weights(i)
            Next

            Dim checksum As Integer = (10 - (sum Mod 10)) Mod 10

            If checksum <> CInt(Char.GetNumericValue(patient.PESEL(10))) Then
                Return Task.FromResult("Nieprawidłowa suma kontrolna w numerze PESEL.")
            End If

            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

    Public Class EmailFormatRule
        Implements IValidationRule(Of Patient)
        Public Function ValidateAsync(patient As Patient) As Task(Of String) Implements IValidationRule(Of Patient).ValidateAsync

            If String.IsNullOrWhiteSpace(patient.Email) Then
                Return Task.FromResult("Email nie może być pusty.")
            End If

            Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"

            If Not Regex.IsMatch(patient.Email, emailPattern) Then
                Return Task.FromResult("Nieprawidłowy format adresu email.")
            End If

            Try
                Dim address = New MailAddress(patient.Email)
            Catch ex As FormatException
                Return Task.FromResult("Nieprawidłowy format adresu email.")
            End Try

            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

    Public Class StringOnlyNumericCharsRule(Of T)
        Implements IValidationRule(Of T)

        Private ReadOnly _selector As Func(Of T, String)
        Private ReadOnly _propertyName As String

        Public Sub New(selector As Func(Of T, String), propertyName As String)
            _selector = selector
            _propertyName = propertyName
        End Sub

        Public Function ValidateAsync(entity As T) As Task(Of String) Implements IValidationRule(Of T).ValidateAsync
            Dim textToValidate As String = _selector(entity)

            If String.IsNullOrEmpty(textToValidate) OrElse Not Regex.IsMatch(textToValidate, "^[0-9]+$") Then
                Return Task.FromResult($"{_propertyName} musi się składać tylko i wyłącznie z cyfr")
            End If
            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

    Public Class StringOnlyNumericCharsOrSpaceRule(Of T)
        Implements IValidationRule(Of T)

        Private ReadOnly _selector As Func(Of T, String)
        Private ReadOnly _propertyName As String

        Public Sub New(selector As Func(Of T, String), propertyName As String)
            _selector = selector
            _propertyName = propertyName
        End Sub

        Public Function ValidateAsync(entity As T) As Task(Of String) Implements IValidationRule(Of T).ValidateAsync
            Dim textToValidate As String = _selector(entity)

            If String.IsNullOrEmpty(textToValidate) OrElse Not Regex.IsMatch(textToValidate, "^[0-9 ]+$") Then
                Return Task.FromResult($"{_propertyName} musi się składać tylko i wyłącznie z cyfr i spacji")
            End If
            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

    Public Class StringAreaCodeCustomRule(Of T)
        Implements IValidationRule(Of T)

        Private ReadOnly _selector As Func(Of T, String)
        Private ReadOnly _propertyName As String

        Public Sub New(selector As Func(Of T, String), propertyName As String)
            _selector = selector
            _propertyName = propertyName
        End Sub

        Public Function ValidateAsync(entity As T) As Task(Of String) Implements IValidationRule(Of T).ValidateAsync
            Dim textToValidate As String = _selector(entity)

            If String.IsNullOrEmpty(textToValidate) OrElse Not Regex.IsMatch(textToValidate, "^\+[1-9]\d{0,3}$") Then
                Return Task.FromResult($"{_propertyName} musi być poprawnym kodem kierunkowym (np. +48)")
            End If
            Return Task.FromResult(CType(Nothing, String))
        End Function
    End Class

End Namespace