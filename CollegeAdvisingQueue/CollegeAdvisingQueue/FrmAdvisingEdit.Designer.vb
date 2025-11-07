<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdvisingEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblStudent As System.Windows.Forms.Label
    Friend WithEvents cboStudent As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdviser As System.Windows.Forms.Label
    Friend WithEvents txtAdviser As System.Windows.Forms.TextBox
    Friend WithEvents lblQueueNumber As System.Windows.Forms.Label
    Friend WithEvents txtQueueNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPurpose As System.Windows.Forms.Label
    Friend WithEvents txtPurpose As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.cboStudent = New System.Windows.Forms.ComboBox()
        Me.lblAdviser = New System.Windows.Forms.Label()
        Me.txtAdviser = New System.Windows.Forms.TextBox()
        Me.lblQueueNumber = New System.Windows.Forms.Label()
        Me.txtQueueNumber = New System.Windows.Forms.TextBox()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = True
        Me.lblStudent.Location = New System.Drawing.Point(30, 30)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Size = New System.Drawing.Size(70, 20)
        Me.lblStudent.TabIndex = 0
        Me.lblStudent.Text = "Student:"
        '
        'cboStudent
        '
        Me.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStudent.FormattingEnabled = True
        Me.cboStudent.Location = New System.Drawing.Point(150, 27)
        Me.cboStudent.Name = "cboStudent"
        Me.cboStudent.Size = New System.Drawing.Size(300, 28)
        Me.cboStudent.TabIndex = 1
        '
        'lblAdviser
        '
        Me.lblAdviser.AutoSize = True
        Me.lblAdviser.Location = New System.Drawing.Point(30, 75)
        Me.lblAdviser.Name = "lblAdviser"
        Me.lblAdviser.Size = New System.Drawing.Size(65, 20)
        Me.lblAdviser.TabIndex = 2
        Me.lblAdviser.Text = "Adviser:"
        '
        'txtAdviser
        '
        Me.txtAdviser.Location = New System.Drawing.Point(150, 72)
        Me.txtAdviser.Name = "txtAdviser"
        Me.txtAdviser.Size = New System.Drawing.Size(300, 26)
        Me.txtAdviser.TabIndex = 3
        '
        'lblQueueNumber
        '
        Me.lblQueueNumber.AutoSize = True
        Me.lblQueueNumber.Location = New System.Drawing.Point(30, 120)
        Me.lblQueueNumber.Name = "lblQueueNumber"
        Me.lblQueueNumber.Size = New System.Drawing.Size(121, 20)
        Me.lblQueueNumber.TabIndex = 4
        Me.lblQueueNumber.Text = "Queue Number:"
        '
        'txtQueueNumber
        '
        Me.txtQueueNumber.Location = New System.Drawing.Point(150, 117)
        Me.txtQueueNumber.Name = "txtQueueNumber"
        Me.txtQueueNumber.Size = New System.Drawing.Size(300, 26)
        Me.txtQueueNumber.TabIndex = 5
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Location = New System.Drawing.Point(30, 165)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(72, 20)
        Me.lblPurpose.TabIndex = 6
        Me.lblPurpose.Text = "Purpose:"
        '
        'txtPurpose
        '
        Me.txtPurpose.Location = New System.Drawing.Point(150, 162)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(300, 26)
        Me.txtPurpose.TabIndex = 7
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(30, 210)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 20)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "Status:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Pending", "In Progress", "Done"})
        Me.cboStatus.Location = New System.Drawing.Point(150, 207)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(300, 28)
        Me.cboStatus.TabIndex = 9
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Location = New System.Drawing.Point(30, 255)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(77, 20)
        Me.lblRemarks.TabIndex = 10
        Me.lblRemarks.Text = "Remarks:"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(150, 252)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(300, 100)
        Me.txtRemarks.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(150, 370)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 35)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(280, 370)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 35)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmAdvisingEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 430)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.lblPurpose)
        Me.Controls.Add(Me.txtQueueNumber)
        Me.Controls.Add(Me.lblQueueNumber)
        Me.Controls.Add(Me.txtAdviser)
        Me.Controls.Add(Me.lblAdviser)
        Me.Controls.Add(Me.cboStudent)
        Me.Controls.Add(Me.lblStudent)
        Me.Name = "FrmAdvisingEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Advising Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
