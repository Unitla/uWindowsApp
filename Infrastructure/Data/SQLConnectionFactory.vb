Imports System.Configuration
Imports System.Data.SqlClient

Public Class SQLConnectionFactory
    Implements IDbConnectionFactory

    Private ReadOnly _connectionString As String
    Public Sub New()
        Dim settings = ConfigurationManager.ConnectionStrings("PatientDBConnectionString")

        If settings Is Nothing Then
            Throw New InvalidOperationException("Brak konfiguracyjnego ConnectionStringa 'PatientDBConnectionString' w App.config!")
        End If

        _connectionString = settings.ConnectionString
    End Sub
    Public Function CreateConnection() As IDbConnection Implements IDbConnectionFactory.CreateConnection
        Return New SqlConnection(_connectionString)
    End Function

End Class
