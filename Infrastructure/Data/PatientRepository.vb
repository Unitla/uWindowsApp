Imports System.Data.SqlClient
Imports System.Net
Imports Azure.Core.HttpHeader
Imports uWindowsApp.Entities
Imports uWindowsApp.Infrastructure.Data
Imports uWindowsApp.Interfaces
Imports uWindowsApp.Queries


Public Class PatientRepository
    Implements IPatientRepository

    Private ReadOnly _connectionFactory As IDbConnectionFactory

    Sub New(connectionFactory As IDbConnectionFactory)
        _connectionFactory = connectionFactory
    End Sub

    Public Async Function Add(patient As Patient) As Task Implements IPatientRepository.Add
        Dim query = "INSERT INTO Patients (Name, Surname, Email, PESEL, Address,PhoneNumber,AreaCode) VALUES (@Name, @Surname, @Email, @PESEL, @Address, @PhoneNumber, @AreaCode);"

        Using conn As IDbConnection = _connectionFactory.CreateConnection()
            conn.Open()
            Using command As New SqlCommand(query, CType(conn, SqlConnection))
                command.Parameters.AddWithValue("@Name", patient.Name)
                command.Parameters.AddWithValue("@Surname", patient.Surname)
                command.Parameters.AddWithValue("@Email", patient.Email)
                command.Parameters.AddWithValue("@PESEL", patient.PESEL)
                command.Parameters.AddWithValue("@Address", patient.Address)
                command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber)
                command.Parameters.AddWithValue("@AreaCode", patient.AreaCode)

                Await command.ExecuteNonQueryAsync()
            End Using
        End Using
    End Function

    Public Async Function Update(patient As Patient) As Task Implements IPatientRepository.Update
        Dim query = "UPDATE Patients SET Name = @Name, Surname = @Surname, Email = @Email, PESEL = @PESEL, Address = @Address, PhoneNumber = @PhoneNumber, AreaCode = @AreaCode WHERE Id = @Id;"

        Using conn As IDbConnection = _connectionFactory.CreateConnection()
            conn.Open()
            Using command As New SqlCommand(query, CType(conn, SqlConnection))
                command.Parameters.AddWithValue("@Name", patient.Name)
                command.Parameters.AddWithValue("@Surname", patient.Surname)
                command.Parameters.AddWithValue("@Email", patient.Email)
                command.Parameters.AddWithValue("@PESEL", patient.PESEL)
                command.Parameters.AddWithValue("@Address", patient.Address)
                command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber)
                command.Parameters.AddWithValue("@AreaCode", patient.AreaCode)
                command.Parameters.AddWithValue("@Id", patient.Id)
                Await command.ExecuteNonQueryAsync()

            End Using
        End Using


    End Function

    Public Async Function Delete(id As Integer) As Task Implements IPatientRepository.Delete
        Dim query = "DELETE FROM Patients WHERE Id = @Id;"
        Using conn As IDbConnection = _connectionFactory.CreateConnection()
            conn.Open()
            Using command As New SqlCommand(query, CType(conn, SqlConnection))
                command.Parameters.AddWithValue("@Id", id)
                Await command.ExecuteNonQueryAsync()
            End Using
        End Using
    End Function

    Public Async Function Search(criteria As PatientSearchCriteria) As Task(Of PagedResult(Of Patient)) Implements IPatientRepository.Search

        'Old Query version - not suitable for my SQL 2008 version
        ''Dim query = "SELECT Name, Surname, Email, PESEL, Address
        'FROM Patients
        'WHERE @Seachfield Like @Search
        'ORDER BY Surname
        'OFFSET @Offset ROWS
        'FETCH NEXT @PageSize ROWS ONLY;"

        Dim searchFieldSelected As String = String.Empty


        If criteria.Field = PatientSearchField.PESEL Then
            searchFieldSelected = "PESEL"
        Else
            searchFieldSelected = "Surname"
        End If

        Dim query = $"SELECT Id, Name, Surname, Email, PESEL, Address, PhoneNumber, AreaCode
            FROM (
                SELECT Id, Name, Surname, Email, PESEL, Address, PhoneNumber, AreaCode,
                       ROW_NUMBER() OVER (ORDER BY Surname) AS RowNum
                FROM Patients
                WHERE {searchFieldSelected} LIKE @Search
            ) AS Result
            WHERE RowNum > @Offset AND RowNum <= (@Offset + @PageSize);"

        Dim calculatedOffset As Integer = (criteria.PageNumber - 1) * criteria.PageSize

        Using conn As IDbConnection = _connectionFactory.CreateConnection()
            conn.Open()
            Using command As New SqlCommand(query, CType(conn, SqlConnection))
                command.Parameters.AddWithValue("@Search", $"%{criteria.SearchText}%")
                command.Parameters.AddWithValue("@Offset", calculatedOffset)
                command.Parameters.AddWithValue("@PageSize", criteria.PageSize)


                Dim patients As New List(Of Patient)()
                Using reader As SqlDataReader = Await command.ExecuteReaderAsync()
                    While Await reader.ReadAsync()
                        Dim patient As New Patient With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .Name = reader("Name").ToString(),
                            .Surname = reader("Surname").ToString(),
                            .Email = reader("Email").ToString(),
                            .PESEL = reader("PESEL").ToString(),
                            .Address = reader("Address").ToString(),
                            .PhoneNumber = reader("PhoneNumber").ToString(),
                            .AreaCode = reader("AreaCode").ToString()
                        }
                        patients.Add(patient)
                    End While
                End Using

                ' Get total count for pagination
                Dim totalCount As Integer = 0
                Using countCommand As New SqlCommand($"SELECT COUNT(*) FROM Patients WHERE {searchFieldSelected} LIKE @Search", CType(conn, SqlConnection))
                    countCommand.Parameters.AddWithValue("@Search", $"%{criteria.SearchText}%")
                    totalCount = Convert.ToInt32(Await countCommand.ExecuteScalarAsync())
                End Using

                Return New PagedResult(Of Patient)(patients, totalCount, criteria.PageNumber, criteria.PageSize)
            End Using
        End Using
    End Function

    Public Async Function GetById(id As Integer) As Task(Of Patient) Implements IPatientRepository.GetById
        Dim query = "Select id, Name, Surname, Email, PESEL, Address,PhoneNumber, AreaCode
                    FROM Patients
                    WHERE Id = @Id"
        Using conn As IDbConnection = _connectionFactory.CreateConnection()
            conn.Open()
            Using command As New SqlCommand(query, CType(conn, SqlConnection))
                command.Parameters.AddWithValue("@Id", id)

                Using reader As SqlDataReader = Await command.ExecuteReaderAsync()
                    If Await reader.ReadAsync Then
                        Return New Patient With {
                            .Id = Convert.ToInt32(reader("Id")),
                            .Name = reader("Name").ToString(),
                            .Surname = reader("Surname").ToString(),
                            .Email = reader("Email").ToString(),
                            .PESEL = reader("PESEL").ToString(),
                            .Address = reader("Address").ToString(),
                            .PhoneNumber = reader("PhoneNumber").ToString(),
                            .AreaCode = reader("AreaCode").ToString()
                        }
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function
End Class
