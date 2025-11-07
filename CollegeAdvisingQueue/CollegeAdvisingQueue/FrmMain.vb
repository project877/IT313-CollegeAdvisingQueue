Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AdvisingQueueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvisingQueueToolStripMenuItem.Click
        Dim f As New FrmAdvisingList()
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub ManageStudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageStudentsToolStripMenuItem.Click
        ' This code MUST be here
        Dim f As New FrmStudentsList()
        f.MdiParent = Me
        f.Show()
    End Sub
End Class
