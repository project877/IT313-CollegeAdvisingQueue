Imports System.Data.OleDb

Public Class FrmAdvisingEdit

    ' This public variable is the "switch"
    ' 0 = Add Mode (default)
    ' Any other number = Edit Mode (this ID will be the one to edit)
    Public EditSessionID As Integer = 0

    Private Sub FrmAdvisingEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' This code runs as soon as the form opens

        ' Load the dropdowns first, regardless of mode
        LoadStudents()
        LoadStatuses()

        If EditSessionID > 0 Then
            ' --- EDIT MODE ---
            Me.Text = "Edit Advising Session"
            LoadSessionData()
        Else
            ' --- ADD MODE ---
            Me.Text = "Add to Advising Queue"
            ' Form is blank, ready for input
        End If
    End Sub

    ' Helper sub to fill the Students ComboBox
    Private Sub LoadStudents()
        Dim dtStudents = DB.GetTable("SELECT StudentID, FullName FROM Students ORDER BY FullName")

        ' DisplayMember: What the user SEES (the name)
        cboStudent.DisplayMember = "FullName"
        ' ValueMember: The hidden VALUE we use (the ID)
        cboStudent.ValueMember = "StudentID"

        ' Bind the data to the ComboBox
        cboStudent.DataSource = dtStudents
        cboStudent.SelectedIndex = -1 ' Start with no student selected
    End Sub

    ' Helper sub to fill the Status ComboBox
    Private Sub LoadStatuses()
        cboStatus.Items.Clear() ' Clear any designer-items
        cboStatus.Items.Add("Waiting")
        cboStatus.Items.Add("Serving")
        cboStatus.SelectedIndex = 0 ' Default to "Waiting"
    End Sub

    ' Helper sub to fill the form when in Edit Mode
    Private Sub LoadSessionData()
        ' 1. Create SQL to find ONE session by its PK
        Dim sql = "SELECT * FROM AdvisingSessions WHERE SessionID = ?"

        ' 2. Create the parameter list
        Dim prms As New List(Of OleDbParameter)
        prms.Add(New OleDbParameter("@ID", EditSessionID))

        ' 3. Get the data
        Dim dt As DataTable = DB.GetTable(sql, prms)

        ' 4. Check if we actually found a session
        If dt.Rows.Count > 0 Then
            ' 5. Get the first (and only) row
            Dim row = dt.Rows(0)

            ' 6. Fill all the controls with data from the row
            '    This line finds the student in the dropdown
            '    by its StudentID (the ValueMember)
            cboStudent.SelectedValue = CInt(row("StudentID"))

            txtAdviser.Text = row("Adviser").ToString()
            txtQueueNumber.Text = row("QueueNumber").ToString()
            txtPurpose.Text = row("Purpose").ToString()

            ' This line finds the matching string in the list
            cboStatus.SelectedItem = row("Status").ToString()

            txtRemarks.Text = row("Remarks").ToString()
        Else
            MessageBox.Show("Error: Could not find the selected session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close() ' Close the form
        End If
    End Sub


    ' --- BUTTON CLICK EVENTS ---

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' --- 1. VALIDATION (as per Rubric) ---
        If cboStudent.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            MessageBox.Show("Student and Purpose are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Stop processing
        End If

        ' Validate that Queue Number is a number
        Dim queueNum As Integer = 0
        If Not Integer.TryParse(txtQueueNumber.Text, queueNum) Then
            ' Allow blank queue number, default to 0
            If String.IsNullOrWhiteSpace(txtQueueNumber.Text) Then
                queueNum = 0
            Else
                MessageBox.Show("Queue Number must be a valid number (or blank).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        ' --- 2. CREATE PARAMETERS ---
        Dim prms As New List(Of OleDbParameter)
        ' Get the selected StudentID from the ComboBox's ValueMember
        prms.Add(New OleDbParameter("@StudentID", CInt(cboStudent.SelectedValue)))
        prms.Add(New OleDbParameter("@Adviser", txtAdviser.Text))
        prms.Add(New OleDbParameter("@QueueNumber", queueNum))
        prms.Add(New OleDbParameter("@Purpose", txtPurpose.Text))
        prms.Add(New OleDbParameter("@Status", cboStatus.SelectedItem.ToString()))
        prms.Add(New OleDbParameter("@Remarks", txtRemarks.Text))
        prms.Add(New OleDbParameter("@UpdatedAt", DateTime.Now))

        Dim sql As String = ""

        ' --- 3. CREATE SQL (Add vs Edit) ---
        If EditSessionID = 0 Then
            ' ADD MODE: We need to run an INSERT statement
            sql = "INSERT INTO AdvisingSessions (StudentID, Adviser, QueueNumber, Purpose, Status, Remarks, UpdatedAt, CreatedAt) " &
                  "VALUES (@StudentID, @Adviser, @QueueNumber, @Purpose, @Status, @Remarks, @UpdatedAt, @UpdatedAt)"
        Else
            ' EDIT MODE: We need to run an UPDATE statement
            sql = "UPDATE AdvisingSessions SET StudentID=@StudentID, Adviser=@Adviser, QueueNumber=@QueueNumber, " &
                  "Purpose=@Purpose, Status=@Status, Remarks=@Remarks, UpdatedAt=@UpdatedAt " &
                  "WHERE SessionID=@ID"

            ' We must add the ID parameter for the WHERE clause
            prms.Add(New OleDbParameter("@ID", EditSessionID))
        End If

        ' --- 4. EXECUTE THE QUERY ---
        If DB.Exec(sql, prms) > 0 Then
            MessageBox.Show("Session saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK ' This tells FrmAdvisingList to refresh
            Me.Close() ' Close this form
        Else
            MessageBox.Show("Failed to save session.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Set the result to Cancel
        Me.DialogResult = DialogResult.Cancel
        ' Close this form. FrmAdvisingList will not refresh.
        Me.Close()
    End Sub

End Class