<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCompareStructure_Result
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.treeviewResults = New System.Windows.Forms.TreeView()
        Me.buttonTreeViewCollapseAll = New System.Windows.Forms.Button()
        Me.buttonTreeViewExpandAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'treeviewResults
        '
        Me.treeviewResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewResults.HideSelection = False
        Me.treeviewResults.Location = New System.Drawing.Point(4, 5)
        Me.treeviewResults.Name = "treeviewResults"
        Me.treeviewResults.Size = New System.Drawing.Size(315, 242)
        Me.treeviewResults.TabIndex = 3
        '
        'buttonTreeViewCollapseAll
        '
        Me.buttonTreeViewCollapseAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonTreeViewCollapseAll.Location = New System.Drawing.Point(84, 253)
        Me.buttonTreeViewCollapseAll.Name = "buttonTreeViewCollapseAll"
        Me.buttonTreeViewCollapseAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonTreeViewCollapseAll.TabIndex = 5
        Me.buttonTreeViewCollapseAll.Text = "Collapse all"
        Me.buttonTreeViewCollapseAll.UseVisualStyleBackColor = True
        '
        'buttonTreeViewExpandAll
        '
        Me.buttonTreeViewExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonTreeViewExpandAll.Location = New System.Drawing.Point(4, 253)
        Me.buttonTreeViewExpandAll.Name = "buttonTreeViewExpandAll"
        Me.buttonTreeViewExpandAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonTreeViewExpandAll.TabIndex = 4
        Me.buttonTreeViewExpandAll.Text = "Expand all"
        Me.buttonTreeViewExpandAll.UseVisualStyleBackColor = True
        '
        'DBCompareStructure_Result
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 279)
        Me.Controls.Add(Me.buttonTreeViewCollapseAll)
        Me.Controls.Add(Me.buttonTreeViewExpandAll)
        Me.Controls.Add(Me.treeviewResults)
        Me.Name = "DBCompareStructure_Result"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Database Comparison Result"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeviewResults As System.Windows.Forms.TreeView
    Friend WithEvents buttonTreeViewCollapseAll As System.Windows.Forms.Button
    Friend WithEvents buttonTreeViewExpandAll As System.Windows.Forms.Button
End Class
