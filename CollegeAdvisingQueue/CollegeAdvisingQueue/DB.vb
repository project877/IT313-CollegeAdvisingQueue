Imports System.Data.OleDb
Imports System.IO

Module DB

    ' 1. This function builds the connection string.
    Private Function GetConnectionString() As String
        Const connTemplate As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Data\App.accdb;"
        Return connTemplate
    End Function

    ' 3. Use this function for all SELECT queries (getting data)
    Public Function GetTable(sql As String, Optional prms As List(Of OleDbParameter) = Nothing) As DataTable
        ' Initialize the DataTable we are going to return
        Dim dt As New DataTable()
        Try
            Using cn As New OleDbConnection(GetConnectionString())
                Using cmd As New OleDbCommand(sql, cn)
                    If prms IsNot Nothing Then
                        cmd.Parameters.AddRange(prms.ToArray())
                    End If
                    Using adp As New OleDbDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database Error (GetTable): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' --- CORRECTION ---
            ' We return the empty 'dt' to satisfy the code path.
            Return dt
        End Try

        ' This is the "success" path return
        Return dt
    End Function
    ' Add this NEW public function to DB.vb
    ' This lets our forms get the connection string for manual transactions
    Public Function GetPublicConnectionString() As String
        Return GetConnectionString()
    End Function

    ' 4. Use this function for all INSERT, UPDATE, or DELETE queries
    Public Function Exec(sql As String, Optional prms As List(Of OleDbParameter) = Nothing) As Integer
        Dim rowsAffected As Integer = 0
        Try
            Using cn As New OleDbConnection(GetConnectionString())
                Using cmd As New OleDbCommand(sql, cn)
                    If prms IsNot Nothing Then
                        cmd.Parameters.AddRange(prms.ToArray())
                    End If
                    cn.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database Error (Exec): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' --- CORRECTION ---
            ' We return 0 (for 0 rows affected) to signal failure
            Return 0
        End Try

        ' This is the "success" path return
        Return rowsAffected
    End Function

End Module