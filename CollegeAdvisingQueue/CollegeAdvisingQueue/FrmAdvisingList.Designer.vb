<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdvisingList
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

    Friend WithEvents dgvAdvisingQueue As System.Windows.Forms.DataGridView
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnMarkDone As System.Windows.Forms.Button
    Friend WithEvents PanelSearch As System.Windows.Forms.Panel
    Friend WithEvents lblSearchName As System.Windows.Forms.Label
    Friend WithEvents txtSearchName As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboFilterStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvAdvisingQueue = New System.Windows.Forms.DataGridView()
        Me.PanelButtons = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnMarkDone = New System.Windows.Forms.Button()
        Me.PanelSearch = New System.Windows.Forms.Panel()
        Me.lblSearchName = New System.Windows.Forms.Label()
        Me.txtSearchName = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        CType(Me.dgvAdvisingQueue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButtons.SuspendLayout()
        Me.PanelSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvAdvisingQueue
        '
        Me.dgvAdvisingQueue.AllowUserToAddRows = False
        Me.dgvAdvisingQueue.AllowUserToDeleteRows = False
        Me.dgvAdvisingQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdvisingQueue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAdvisingQueue.Location = New System.Drawing.Point(0, 120)
        Me.dgvAdvisingQueue.MultiSelect = False
        Me.dgvAdvisingQueue.Name = "dgvAdvisingQueue"
        Me.dgvAdvisingQueue.ReadOnly = True
        Me.dgvAdvisingQueue.RowHeadersWidth = 62
        Me.dgvAdvisingQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdvisingQueue.Size = New System.Drawing.Size(800, 330)
        Me.dgvAdvisingQueue.TabIndex = 0
        '
        'PanelButtons
        '
        Me.PanelButtons.Controls.Add(Me.btnAdd)
        Me.PanelButtons.Controls.Add(Me.btnEdit)
        Me.PanelButtons.Controls.Add(Me.btnMarkDone)
        Me.PanelButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelButtons.Location = New System.Drawing.Point(0, 60)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(800, 60)
        Me.PanelButtons.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 15)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(150, 30)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add to Queue"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(168, 15)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(150, 30)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit Selected"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnMarkDone
        '
        Me.btnMarkDone.Location = New System.Drawing.Point(324, 15)
        Me.btnMarkDone.Name = "btnMarkDone"
        Me.btnMarkDone.Size = New System.Drawing.Size(150, 30)
        Me.btnMarkDone.TabIndex = 2
        Me.btnMarkDone.Text = "Mark as Done"
        Me.btnMarkDone.UseVisualStyleBackColor = True
        '
        'PanelSearch
        '
        Me.PanelSearch.Controls.Add(Me.lblSearchName)
        Me.PanelSearch.Controls.Add(Me.txtSearchName)
        Me.PanelSearch.Controls.Add(Me.lblStatus)
        Me.PanelSearch.Controls.Add(Me.cboFilterStatus)
        Me.PanelSearch.Controls.Add(Me.btnSearch)
        Me.PanelSearch.Controls.Add(Me.btnClear)
        Me.PanelSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSearch.Location = New System.Drawing.Point(0, 0)
        Me.PanelSearch.Name = "PanelSearch"
        Me.PanelSearch.Size = New System.Drawing.Size(800, 60)
        Me.PanelSearch.TabIndex = 2
        '
        'lblSearchName
        '
        Me.lblSearchName.AutoSize = True
        Me.lblSearchName.Location = New System.Drawing.Point(12, 20)
        Me.lblSearchName.Name = "lblSearchName"
        Me.lblSearchName.Size = New System.Drawing.Size(110, 20)
        Me.lblSearchName.TabIndex = 0
        Me.lblSearchName.Text = "Search Name:"
        '
        'txtSearchName
        '
        Me.txtSearchName.Location = New System.Drawing.Point(120, 17)
        Me.txtSearchName.Name = "txtSearchName"
        Me.txtSearchName.Size = New System.Drawing.Size(150, 26)
        Me.txtSearchName.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(280, 20)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(60, 20)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Status:"
        '
        'cboFilterStatus
        '
        Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterStatus.FormattingEnabled = True
        Me.cboFilterStatus.Items.AddRange(New Object() {"All", "Pending", "In Progress", "Done"})
        Me.cboFilterStatus.Location = New System.Drawing.Point(346, 17)
        Me.cboFilterStatus.Name = "cboFilterStatus"
        Me.cboFilterStatus.Size = New System.Drawing.Size(121, 28)
        Me.cboFilterStatus.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(480, 15)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(590, 15)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 30)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear Filters"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'FrmAdvisingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvAdvisingQueue)
        Me.Controls.Add(Me.PanelButtons)
        Me.Controls.Add(Me.PanelSearch)
        Me.Name = "FrmAdvisingList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advising Queue List"
        CType(Me.dgvAdvisingQueue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelSearch.ResumeLayout(False)
        Me.PanelSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class
