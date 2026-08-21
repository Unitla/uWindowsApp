Imports uWindowsApp.Entities
Imports uWindowsApp.Queries

Public Class MainForm
    Implements IMainView

    Sub New()
        InitializeComponent()

        Dim editColumn As New DataGridViewButtonColumn()

        editColumn.Name = "Edit"
        editColumn.HeaderText = "Edytuj"
        editColumn.Text = "✏️"
        editColumn.UseColumnTextForButtonValue = True
        editColumn.Width = 30


        PatientDataGridView.Columns.Add(editColumn)

        Dim deleteColumn As New DataGridViewButtonColumn()

        deleteColumn.Name = "Delete"
        deleteColumn.HeaderText = "Usuń"
        deleteColumn.Text = "🗑"
        deleteColumn.UseColumnTextForButtonValue = True
        deleteColumn.Width = 30

        PatientDataGridView.Columns.Add(deleteColumn)

        RaiseEvent ViewLoaded(Me, EventArgs.Empty)
    End Sub

    Public ReadOnly Property SearchText As String Implements IMainView.SearchText
        Get
            Return SearchTextBox.Text
        End Get
    End Property

    Public ReadOnly Property SearchField As PatientSearchField Implements IMainView.SearchField
        Get
            If PESELRadioButton.Checked Then
                Return PatientSearchField.PESEL
            Else
                Return PatientSearchField.SURNAME
            End If
        End Get
    End Property

    Public Event SearchRequested As EventHandler Implements IMainView.SearchRequested
    Public Event NextPageRequested As EventHandler Implements IMainView.NextPageRequested
    Public Event PreviousPageRequested As EventHandler Implements IMainView.PreviousPageRequested
    Public Event AddPatientRequested As EventHandler Implements IMainView.AddPatientRequested
    Public Event EditRequested As EventHandler(Of PatientEventArgs) Implements IMainView.EditRequested
    Public Event DeleteRequested As EventHandler(Of PatientEventArgs) Implements IMainView.DeleteRequested
    Public Event LogoutRequested As EventHandler Implements IMainView.LogoutRequested
    Public Event ViewLoaded As EventHandler Implements IMainView.ViewLoaded


    Public Sub UpdatePagination(currentPage As Integer, totalPages As Integer) _
    Implements IMainView.UpdatePagination

        PageNumberLabel.Text = $"Page {currentPage} of {totalPages}"

        PreviousButton.Enabled = currentPage > 1
        NextButton.Enabled = currentPage < totalPages

    End Sub

    Public Sub ShowMessage(message As String) Implements IMainView.ShowMessage
        Throw New NotImplementedException()
    End Sub

    Public Sub ShowError(message As String) Implements IMainView.ShowError
        Throw New NotImplementedException()
    End Sub

    Public Sub DisplayPatients(patients As IReadOnlyList(Of Patient)) Implements IMainView.DisplayPatients
        ' Bind the patients list to the DataGridView using a BindingList so the grid stays data-bound.
        PatientDataGridView.DataSource = New System.ComponentModel.BindingList(Of Patient)(patients.ToList())
    End Sub


    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        RaiseEvent SearchRequested(
    Me,
    EventArgs.Empty)
    End Sub

    Private Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles PreviousButton.Click
        RaiseEvent PreviousPageRequested(Me, EventArgs.Empty)
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        RaiseEvent NextPageRequested(Me, EventArgs.Empty)
    End Sub

    Private Sub PatientDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PatientDataGridView.CellContentClick
        If e.RowIndex < 0 Then Return

        Dim selectedRow As DataGridViewRow = PatientDataGridView.Rows(e.RowIndex)

        If PatientDataGridView.Columns(e.ColumnIndex).Name = "Edit" Then
            Dim patient = TryCast(selectedRow.DataBoundItem, Patient)
            If patient IsNot Nothing Then
                RaiseEvent EditRequested(Me, New PatientEventArgs(patient.Id))
            End If
            Return
        End If

        If PatientDataGridView.Columns(e.ColumnIndex).Name = "Delete" Then
            Dim patient = TryCast(selectedRow.DataBoundItem, Patient)
            If patient IsNot Nothing Then
                RaiseEvent DeleteRequested(Me, New PatientEventArgs(patient.Id))
            End If
            Return
        End If

    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RaiseEvent ViewLoaded(Me, EventArgs.Empty)
    End Sub

    Private Sub AddPatientButton_Click(sender As Object, e As EventArgs) Handles AddPatientButton.Click
        RaiseEvent AddPatientRequested(Me, EventArgs.Empty)
    End Sub
End Class