Public Class formMDIMain
    Private Sub Me_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Text = My.Application.Info.Title
    End Sub

    Private Sub CompareStructure_Click(sender As System.Object, e As System.EventArgs) Handles menuitemCompareStructure.Click
        formCompareStructure_Select.MdiParent = Me
        formCompareStructure_Select.Show()
    End Sub

    Private Sub CompareData_Click(sender As System.Object, e As System.EventArgs) Handles menuitemCompareData.Click
        formCompareData_Select.MdiParent = Me
        formCompareData_Select.Show()
    End Sub

    Private Sub CopyDatabaseStructure_Click(sender As Object, e As EventArgs) Handles buttonCopyDatabaseStructure.Click
        formCopy_Options.MdiParent = Me
        formCopy_Options.Show()
    End Sub

    Private Sub BrowseData_Click(sender As Object, e As EventArgs) Handles buttonBrowseData.Click
        formBrowseData.MdiParent = Me
        formBrowseData.Show()
    End Sub
End Class
