Namespace Queries
    Public Class PagedResult(Of T)

        Public ReadOnly Property Items As IReadOnlyList(Of T)

        Public ReadOnly Property TotalCount As Integer

        Public ReadOnly Property PageNumber As Integer

        Public ReadOnly Property PageSize As Integer

        Public Sub New(
        items As IReadOnlyList(Of T),
        totalCount As Integer,
        pageNumber As Integer,
        pageSize As Integer)

            Me.Items = items
            Me.TotalCount = totalCount
            Me.PageNumber = pageNumber
            Me.PageSize = pageSize

        End Sub

    End Class
End Namespace