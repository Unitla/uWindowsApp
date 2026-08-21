Imports System.Threading.Tasks
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports uWindowsApp.Entities
Imports uWindowsApp.Validators

<TestClass()>
Public Class PatientValidatorTests

    <TestMethod()>
    Public Async Function Validate_ValidPatient_ReturnsValid() As Task
        Dim patient As New Patient With {
            .Name = "Jan",
            .Surname = "Kowalski",
            .Address = "Ulica 1",
            .PhoneNumber = "123456789",
            .AreaCode = "48",
            .Email = "jan.kowalski@example.com",
            .PESEL = "02270803628" ' valid example
        }

        Dim validator As New Validators.PatientValidator()
        Dim result = Await validator.ValidateAsync(patient)

        Assert.IsTrue(result.IsValid, String.Join(";", result.Errors))
    End Function

    <TestMethod()>
    Public Async Function Validate_InvalidPESEL_ReturnsError() As Task
        Dim patient As New Patient With {
            .Name = "Anna",
            .Surname = "Nowak",
            .Email = "anna.nowak@example.com",
            .PESEL = "" ' empty
        }

        Dim validator As New Validators.PatientValidator()
        Dim result = Await validator.ValidateAsync(patient)

        Assert.IsFalse(result.IsValid)
        Assert.IsTrue(result.Errors.Exists(Function(e) e.Contains("PESEL")))
    End Function

    <TestMethod()>
    Public Async Function Validate_InvalidEmailFormat_ReturnsError() As Task
        Dim patient As New Patient With {
            .Name = "Piotr",
            .Surname = "Zalewski",
            .Email = "not-an-email",
            .PESEL = "02270803628"
        }

        Dim validator As New Validators.PatientValidator()
        Dim result = Await validator.ValidateAsync(patient)

        Assert.IsFalse(result.IsValid)
        Assert.IsTrue(result.Errors.Exists(Function(e) e.ToLower().Contains("email")))
    End Function

End Class