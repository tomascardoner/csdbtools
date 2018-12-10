Public Class formCompareStructure_Result
    Private Sub buttonTreeViewExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonTreeViewExpandAll.Click
        treeviewResults.ExpandAll()
    End Sub

    Private Sub buttonTreeViewCollapseAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonTreeViewCollapseAll.Click
        treeviewResults.CollapseAll()
    End Sub
End Class