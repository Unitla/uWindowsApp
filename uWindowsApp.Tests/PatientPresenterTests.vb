Imports System
Imports System.Threading.Tasks
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports uWindowsApp.Entities
Imports uWindowsApp.Validators
Imports uWindowsApp.Interfaces

<TestClass()>
Public Class PatientPresenterTests

    Private Class AlwaysFailValidator
        Inherits AbstractValidator(Of Patient)
        Public Sub New()
            AddRule(New FailingRule())
        End Sub

        Private Class FailingRule
            Implements IValidationRule(Of Patient)
            Public Function ValidateAsync(entity As Patient) As Task(Of String) Implements IValidationRule(Of Patient).ValidateAsync
                Return Task.FromResult("Some validation error")
            End Function
        End Class
    End Class

    Private Class AlwaysPassValidator
        Inherits AbstractValidator(Of Patient)
        Public Sub New()
            AddRule(New PassingRule())
        End Sub

        Private Class PassingRule
            Implements IValidationRule(Of Patient)
            Public Function ValidateAsync(entity As Patient) As Task(Of String) Implements IValidationRule(Of Patient).ValidateAsync
                Return Task.FromResult(CType(Nothing, String))
            End Function
        End Class
    End Class

    <TestMethod()>
    Public Async Function SaveRequested_WhenValidationFails_ShowsErrors() As Task
        Dim mockView = New Mock(Of IPatientView)()
        mockView.Setup(Function(v) v.GetPatientInput()).Returns(New Patient())
        mockView.SetupGet(Function(v) v.Mode).Returns(PatientViewMode.CREATE)

        Dim mockRepo = New Mock(Of IPatientRepository)()

        Dim presenter = New PatientPresenter(mockView.Object, mockRepo.Object, New AlwaysFailValidator())

        mockView.Raise(Sub(m) AddHandler m.SaveRequested, EventArgs.Empty)

        mockView.Verify(Sub(v) v.ShowValidationErrors(It.IsAny(Of ValidationResult)()), Times.Once())
    End Function

    <TestMethod()>
    Public Async Function SaveRequested_WhenValidationPasses_CallsRepositoryAdd() As Task
        Dim patient As New Patient With {.Name = "Jan"}
        Dim mockView = New Mock(Of IPatientView)()
        mockView.Setup(Function(v) v.GetPatientInput()).Returns(patient)
        mockView.SetupGet(Function(v) v.Mode).Returns(PatientViewMode.CREATE)

        Dim mockRepo = New Mock(Of IPatientRepository)()
        mockRepo.Setup(Function(r) r.Add(It.IsAny(Of Patient)())).Returns(Task.CompletedTask)

        Dim presenter = New PatientPresenter(mockView.Object, mockRepo.Object, New AlwaysPassValidator())

        mockView.Raise(Sub(m) AddHandler m.SaveRequested, EventArgs.Empty)

        ' give async handler a chance to run
        Await Task.Delay(50)

        mockRepo.Verify(Sub(r) r.Add(It.Is(Of Patient)(Function(p) p.Name = "Jan")), Times.Once())

    End Function

End Class