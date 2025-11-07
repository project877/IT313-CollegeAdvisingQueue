Imports System.Data.OleDb

Public Class FrmAdvisingList

    Private Sub FrmAdvisingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill the filter dropdown
        LoadFilterComboBox()
        ' Load the data grid when the form first opens
        LoadData()
    End Sub

    ' --- HELPER SUBS (for loading data) ---

    Private Sub LoadFilterComboBox()
        ' This sub fills the search box for status
        cboFilterStatus.Items.Clear()
        cboFilterStatus.Items.Add("All")
        cboFilterStatus.Items.Add("Waiting")
        cboFilterStatus.Items.Add("Serving")
        cboFilterStatus.Items.Add("Done")
        ' Set the default selection
        cboFilterStatus.SelectedItem = "All"
    End Sub

    ' This is the new, dynamic sub that builds a query
    Private Sub LoadData()
        ' --- 1. Start with the base SQL query ---
        Dim sql As String = "SELECT A.SessionID, S.FullName, S.StudentNo, A.Adviser, A.QueueNumber, A.Purpose, A.Status, A.CreatedAt " &
                            "FROM AdvisingSessions AS A " &
                            "INNER JOIN Students AS S ON A.StudentID = S.StudentID "

        ' --- 2. Create lists to hold our WHERE clauses and Parameters ---
        Dim whereClauses As New List(Of String)
        Dim prms As New List(Of OleDbParameter)

        ' --- 3. Dynamically add filters based on user input ---

        ' Filter by Name (using LIKE for partial match)
        If Not String.IsNullOrWhiteSpace(txtSearchName.Text) Then
            whereClauses.Add("S.FullName LIKE ?")
            prms.Add(New OleDbParameter("@FullName", "%" & txtSearchName.Text & "%"))
        End If

        ' Filter by Status (ignore if "All" is selected)
        If cboFilterStatus.SelectedIndex > -1 AndAlso cboFilterStatus.SelectedItem.ToString() <> "All" Then
            whereClauses.Add("A.Status = ?")
            prms.Add(New OleDbParameter("@Status", cboFilterStatus.SelectedItem.ToString()))
        End If

        ' --- 4. Combine the WHERE clauses ---
        If whereClauses.Count > 0 Then
            sql &= " WHERE " & String.Join(" AND ", whereClauses)
        End If

        ' --- 5. Add Sorting ---
        sql &= " ORDER BY A.Status, A.QueueNumber, A.CreatedAt"

        ' --- 6. Execute the final query ---
        dgvAdvisingQueue.DataSource = DB.GetTable(sql, prms)

        ' 7. Hide the ID column
        If dgvAdvisingQueue.Columns.Contains("SessionID") Then
            dgvAdvisingQueue.Columns("SessionID").Visible = False
        End If

        ' 8. Make columns fill the grid
        dgvAdvisingQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' --- SEARCH & FILTER BUTTONS ---

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Just re-run the LoadData sub, which will use the filter controls
        LoadData()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Reset the controls to their defaults
        txtSearchName.Clear()
        cboFilterStatus.SelectedItem = "All"

        ' Reload the data with cleared filters
        LoadData()
    End Sub

    ' --- CRUD BUTTONS ---

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Open the Edit form in "Add Mode"
        Using f As New FrmAdvisingEdit()
            If f.ShowDialog() = DialogResult.OK Then
                LoadData() ' Refresh the queue
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvAdvisingQueue.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a session to edit.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the ID from the hidden "SessionID" column
        Dim selectedID = CInt(dgvAdvisingQueue.CurrentRow.Cells("SessionID").Value)

        Using f As New FrmAdvisingEdit()
            f.EditSessionID = selectedID ' Switch to Edit Mode
            If f.ShowDialog() = DialogResult.OK Then
                LoadData() ' Refresh the queue
            End If
        End Using
    End Sub

    ' --- TRANSACTIONAL BUTTON (Phase 6) ---

    Private Sub btnMarkDone_Click(sender As Object, e As EventArgs) Handles btnMarkDone.Click
        If dgvAdvisingQueue.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a session to mark as done.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the key data we need
        Dim selectedSessionID = CInt(dgvAdvisingQueue.CurrentRow.Cells("SessionID").Value)
        Dim studentName = dgvAdvisingQueue.CurrentRow.Cells("FullName").Value.ToString()

        ' Confirm with the user
        Dim result = MessageBox.Show($"Are you sure you want to mark {studentName}'s session as 'Done'?",
                                    "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return
        End If

        ' --- TRANSACTION LOGIC BEGINS ---
        ' We must control the connection and transaction manually.
        ' 1. Get the connection string from our DB module
        Using cn As New OleDbConnection(DB.GetPublicConnectionString())
            cn.Open()

            ' 2. Start a new transaction
            Dim tx As OleDbTransaction = cn.BeginTransaction()

            Try
                ' --- STEP 1: Get the StudentID from the AdvisingSession ---
                ' We need this ID for Step 3
                Dim studentID As Integer = 0
                Dim sqlGetStudentId = "SELECT StudentID FROM AdvisingSessions WHERE SessionID = ?"

                Using cmdGetId As New OleDbCommand(sqlGetStudentId, cn, tx) ' Pass 'tx' to the command
                    cmdGetId.Parameters.Add(New OleDbParameter("@ID", selectedSessionID))
                    studentID = CInt(cmdGetId.ExecuteScalar()) ' Gets the first value returned
                End Using

                If studentID = 0 Then
                    Throw New Exception("Could not find the matching StudentID for this session.")
                End If

                ' --- STEP 2: Update the AdvisingSession status to 'Done' ---
                Dim sqlUpdateSession = "UPDATE AdvisingSessions SET Status=?, UpdatedAt=? WHERE SessionID = ?"
                Using cmdSession As New OleDbCommand(sqlUpdateSession, cn, tx) ' Pass 'tx'
                    cmdSession.Parameters.Add(New OleDbParameter("@Status", "Done"))
                    cmdSession.Parameters.Add(New OleDbParameter("@UpdatedAt", DateTime.Now))
                    cmdSession.Parameters.Add(New OleDbParameter("@ID", selectedSessionID))
                    cmdSession.ExecuteNonQuery()
                End Using

                ' --- STEP 3: Update the main Student's record (e.g., their timestamp) ---
                Dim sqlUpdateStudent = "UPDATE Students SET UpdatedAt=? WHERE StudentID = ?"
                Using cmdStudent As New OleDbCommand(sqlUpdateStudent, cn, tx) ' Pass 'tx'
                    cmdStudent.Parameters.Add(New OleDbParameter("@UpdatedAt", DateTime.Now))
                    cmdStudent.Parameters.Add(New OleDbParameter("@ID", studentID))
                    cmdStudent.ExecuteNonQuery()
                End Using

                ' --- 4. COMMIT ---
                ' If all 3 steps succeeded without error, make the changes permanent
                tx.Commit()

                MessageBox.Show("Session marked as Done and Student record updated.", "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData() ' Refresh the grid

            Catch ex As Exception
                ' --- 5. ROLLBACK ---
                ' If ANY step failed, undo everything
                tx.Rollback()
                MessageBox.Show($"Transaction failed. No changes were made.{vbCrLf}Error: {ex.Message}", "Transaction Rolled Back", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        ' --- TRANSACTION LOGIC ENDS ---
    End Sub

End Class