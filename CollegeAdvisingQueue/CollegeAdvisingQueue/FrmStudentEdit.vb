Imports System.Data.OleDb

Public Class FrmStudentEdit

    ' This public variable is the "switch"
    ' 0 = Add Mode (default)
    ' Any other number = Edit Mode (this ID will be the one to edit)
    Public EditStudentID As Integer = 0

    Private Sub FrmStudentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code runs as soon as the form opens

        If EditStudentID > 0 Then
            ' --- EDIT MODE ---
            Me.Text = "Edit Student"
            LoadStudentData()
        Else
            ' --- ADD MODE ---
            Me.Text = "Add New Student"
            ' Form is just blank, ready for input
        End If
    End Sub

    ' Helper sub to fill the form when in Edit Mode
    Private Sub LoadStudentData()
        ' 1. Create SQL to find ONE student by their PK
        Dim sql = "SELECT * FROM Students WHERE StudentID = ?"

        ' 2. Create the parameter list
        Dim prms As New List(Of OleDbParameter)
        prms.Add(New OleDbParameter("@ID", EditStudentID))

        ' 3. Get the data
        Dim dt As DataTable = DB.GetTable(sql, prms)

        ' 4. Check if we actually found a student
        If dt.Rows.Count > 0 Then
            ' 5. Get the first (and only) row
            Dim row = dt.Rows(0)

            ' 6. Fill the textboxes with data from the row
            txtStudentNo.Text = row("StudentNo").ToString()
            txtFullName.Text = row("FullName").ToString()
            txtDepartment.Text = row("Department").ToString()
            txtYearLevel.Text = row("YearLevel").ToString()
        Else
            ' This should not happen if we did it right, but it's good practice
            MessageBox.Show("Error: Could not find the selected student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Close the form
        End If
    End Sub

    ' --- BUTTON CLICK EVENTS ---

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- 1. VALIDATION ---
        If String.IsNullOrWhiteSpace(txtFullName.Text) OrElse String.IsNullOrWhiteSpace(txtDepartment.Text) Then
            MessageBox.Show("Full Name and Department are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. CREATE PARAMETERS ---
        Dim prms As New List(Of OleDbParameter)
        prms.Add(New OleDbParameter("@FullName", txtFullName.Text))
        prms.Add(New OleDbParameter("@Department", txtDepartment.Text))
        prms.Add(New OleDbParameter("@YearLevel", txtYearLevel.Text))
        prms.Add(New OleDbParameter("@StudentNo", txtStudentNo.Text))

        Dim sql As String = ""

        ' --- 3. CREATE SQL (Add vs Edit) ---
        If EditStudentID = 0 Then
            ' ADD MODE
            ' We do NOT insert CreatedAt or UpdatedAt.
            ' The database's "DEFAULT Now()" rule will handle CreatedAt.
            sql = "INSERT INTO Students (FullName, Department, YearLevel, StudentNo) " &
              "VALUES (@FullName, @Department, @YearLevel, @StudentNo)"
        Else
            ' EDIT MODE
            ' NOW we add the UpdatedAt parameter
            prms.Add(New OleDbParameter("@UpdatedAt", DateTime.Now))

            sql = "UPDATE Students SET FullName=@FullName, Department=@Department, YearLevel=@YearLevel, " &
              "StudentNo=@StudentNo, UpdatedAt=@UpdatedAt WHERE StudentID=@ID"

            ' Add the final ID parameter
            prms.Add(New OleDbParameter("@ID", EditStudentID))
        End If

        ' --- 4. EXECUTE THE QUERY ---
        Dim rowsChanged = DB.Exec(sql, prms)

        If rowsChanged > 0 Then
            MessageBox.Show("Student saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to save student. A student with this Student No. may already exist.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Set the result to Cancel
        Me.DialogResult = DialogResult.Cancel
        ' Close this form. FrmStudentsList will not refresh.
        Me.Close()
    End Sub

End Class