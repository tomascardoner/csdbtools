<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompareDataBrowseDifferences
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
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.labelTable = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxTable = New System.Windows.Forms.ToolStripComboBox()
        Me.buttonTable_Previous = New System.Windows.Forms.ToolStripButton()
        Me.buttonTable_Next = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelTable, Me.buttonTable_Previous, Me.comboboxTable, Me.buttonTable_Next})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(987, 31)
        Me.toolstripMain.TabIndex = 0
        '
        'labelTable
        '
        Me.labelTable.Name = "labelTable"
        Me.labelTable.Size = New System.Drawing.Size(38, 22)
        Me.labelTable.Text = "Table:"
        '
        'comboboxTable
        '
        Me.comboboxTable.Name = "comboboxTable"
        Me.comboboxTable.Size = New System.Drawing.Size(300, 31)
        '
        'buttonTable_Previous
        '
        Me.buttonTable_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonTable_Previous.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonTable_Previous.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonTable_Previous.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonTable_Previous.Name = "buttonTable_Previous"
        Me.buttonTable_Previous.Size = New System.Drawing.Size(28, 28)
        Me.buttonTable_Previous.ToolTipText = "Previous table"
        '
        'buttonTable_Next
        '
        Me.buttonTable_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonTable_Next.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonTable_Next.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonTable_Next.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonTable_Next.Name = "buttonTable_Next"
        Me.buttonTable_Next.Size = New System.Drawing.Size(28, 28)
        Me.buttonTable_Next.ToolTipText = "Next table"
        '
        'formCompareData_BrowseDifferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 439)
        Me.Controls.Add(Me.toolstripMain)
        Me.Name = "formCompareData_BrowseDifferences"
        Me.Text = "Compare Data - Browse Differences"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents labelTable As System.Windows.Forms.ToolStripLabel
    Friend WithEvents buttonTable_Previous As System.Windows.Forms.ToolStripButton
    Friend WithEvents comboboxTable As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents buttonTable_Next As System.Windows.Forms.ToolStripButton
End Class
