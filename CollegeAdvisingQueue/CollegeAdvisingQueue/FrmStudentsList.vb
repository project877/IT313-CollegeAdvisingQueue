Imports System.Data.OleDb

Public Class FrmStudentsList

    Private Sub FrmStudentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the data grid when the form first opens
        LoadData()
    End Sub

    ' This is our helper sub to get data from the DB and fill the grid
    Private Sub LoadData()
        ' 1. Define the SQL query
        Dim sql = "SELECT StudentID, StudentNo, FullName, Department, YearLevel FROM Students ORDER BY FullName"

        ' 2. Call our DB module's GetTable function
        dgvStudents.DataSource = DB.GetTable(sql)

        ' 3. Hide the ID column (the user doesn't need to see it)
        If dgvStudents.Columns.Contains("StudentID") Then
            dgvStudents.Columns("StudentID").Visible = False
        End If

        ' 4. Make columns fill the grid (optional, but looks nice)
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' --- BUTTON CLICK EVENTS ---

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' 1. Create a new instance of the FrmStudentEdit form
        '    The "Using" block ensures it's disposed of properly
        Using f As New FrmStudentEdit()
            ' 2. By default, its EditStudentID is 0, so it's in "Add Mode"

            ' 3. Use ShowDialog() to open it as a "modal" window.
            '    This "pauses" the list form until the edit form is closed.
            If f.ShowDialog() = DialogResult.OK Then
                ' 4. If the user clicked "Save" (which set DialogResult.OK),
                '    then we refresh the data in our grid.
                LoadData()
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' 1. Check if a row is actually selected in the grid
        If dgvStudents.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a student to edit.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Exit the sub
        End If

        ' 2. Get the StudentID from the hidden column of the selected row
        '    We CInt() to convert it from an Object to an Integer
        Dim selectedID = CInt(dgvStudents.CurrentRow.Cells("StudentID").Value)

        ' 3. Create the edit form
        Using f As New FrmStudentEdit()
            ' 4. THIS IS THE KEY: Set the public property to the ID.
            '    This tells the form to go into "Edit Mode".
            f.EditStudentID = selectedID

            ' 5. Open the form and refresh the grid if the user saves.
            If f.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' 1. Check if a row is selected
        If dgvStudents.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a student to delete.", "No Student Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Get the ID and Name for the confirmation message
        Dim selectedID = CInt(dgvStudents.CurrentRow.Cells("StudentID").Value)
        Dim selectedName = dgvStudents.CurrentRow.Cells("FullName").Value.ToString()

        ' 3. Ask the user to confirm the deletion
        Dim confirmMsg = $"Are you sure you want to delete {selectedName}?{vbCrLf}This action cannot be undone."
        Dim result = MessageBox.Show(confirmMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        ' 4. If the user clicks Yes, proceed with deletion
        If result = DialogResult.Yes Then
            ' 5. Create the SQL and Parameter list
            Dim sql = "DELETE FROM Students WHERE StudentID = ?"
            Dim prms As New List(Of OleDbParameter)
            prms.Add(New OleDbParameter("@ID", selectedID))

            ' 6. Call our DB.Exec function
            Dim rowsChanged = DB.Exec(sql, prms)

            If rowsChanged > 0 Then
                ' 7. Success! Refresh the grid
                MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            Else
                ' 8. Failure. This usually happens if a student is linked to
                '    an AdvisingSession (due to referential integrity)
                MessageBox.Show("Error deleting student. They may have advising sessions linked to them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

End Class