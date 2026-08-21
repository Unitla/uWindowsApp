Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports uWindowsApp.Queries

<TestClass()>
Public Class DomainQueryTests

n    <TestMethod()> _
    Public Sub PagedResult_CalculatesProperties()
        Dim items = New List(Of Integer) From {1, 2, 3}
    Dim result = New PagedResult(Of Integer)(items, 10, 2, 3)

n        Assert.AreEqual(10, result.TotalCount)
        Assert.AreEqual(2, result.PageNumber)
        Assert.AreEqual(3, result.PageSize)
        Assert.AreEqual(items.Count, result.Items.Count)
    End Sub

nEnd Class