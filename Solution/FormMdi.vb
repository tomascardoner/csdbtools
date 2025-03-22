Public Class FormMdi
    Private Sub Me_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Text = My.Application.Info.Title
    End Sub

    Private Sub CompareStructure_Click(sender As System.Object, e As System.EventArgs) Handles menuitemCompareStructure.Click
        FormCompareStructureSelect.MdiParent = Me
        FormCompareStructureSelect.Show()
    End Sub

    Private Sub CompareData_Click(sender As System.Object, e As System.EventArgs) Handles menuitemCompareData.Click
        FormCompareDataSelect.MdiParent = Me
        FormCompareDataSelect.Show()
    End Sub

    Private Sub CopyDatabaseStructure_Click(sender As Object, e As EventArgs) Handles buttonCopyDatabaseStructure.Click
        FormCopyOptions.MdiParent = Me
        FormCopyOptions.Show()
    End Sub

    Private Sub BrowseData_Click(sender As Object, e As EventArgs) Handles buttonBrowseData.Click
        FormBrowseData.MdiParent = Me
        FormBrowseData.Show()
    End Sub
End Class
