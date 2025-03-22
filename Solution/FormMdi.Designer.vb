<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMdi
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMdi))
        Me.toostripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCompare = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemCompareStructure = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemCompareData = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonCopyDatabaseStructure = New System.Windows.Forms.ToolStripButton()
        Me.buttonBrowseData = New System.Windows.Forms.ToolStripButton()
        Me.imagelistDatabase = New System.Windows.Forms.ImageList(Me.components)
        Me.toostripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toostripMain
        '
        Me.toostripMain.AllowMerge = False
        Me.toostripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCompare, Me.buttonCopyDatabaseStructure, Me.buttonBrowseData})
        Me.toostripMain.Location = New System.Drawing.Point(0, 0)
        Me.toostripMain.Name = "toostripMain"
        Me.toostripMain.Size = New System.Drawing.Size(595, 55)
        Me.toostripMain.TabIndex = 1
        '
        'buttonCompare
        '
        Me.buttonCompare.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemCompareStructure, Me.menuitemCompareData})
        Me.buttonCompare.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_DATABASE_COMPARE_STRUCTURE
        Me.buttonCompare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCompare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCompare.Name = "buttonCompare"
        Me.buttonCompare.Size = New System.Drawing.Size(120, 52)
        Me.buttonCompare.Text = "Compare"
        '
        'menuitemCompareStructure
        '
        Me.menuitemCompareStructure.Name = "menuitemCompareStructure"
        Me.menuitemCompareStructure.Size = New System.Drawing.Size(152, 22)
        Me.menuitemCompareStructure.Text = "Structures"
        '
        'menuitemCompareData
        '
        Me.menuitemCompareData.Name = "menuitemCompareData"
        Me.menuitemCompareData.Size = New System.Drawing.Size(152, 22)
        Me.menuitemCompareData.Text = "Data"
        '
        'buttonCopyDatabaseStructure
        '
        Me.buttonCopyDatabaseStructure.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_DATABASE_COPY_STRUCTURE
        Me.buttonCopyDatabaseStructure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCopyDatabaseStructure.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCopyDatabaseStructure.Name = "buttonCopyDatabaseStructure"
        Me.buttonCopyDatabaseStructure.Size = New System.Drawing.Size(138, 52)
        Me.buttonCopyDatabaseStructure.Text = "Copy Database"
        '
        'buttonBrowseData
        '
        Me.buttonBrowseData.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_DATABASE_BROWSE_DATA
        Me.buttonBrowseData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonBrowseData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonBrowseData.Name = "buttonBrowseData"
        Me.buttonBrowseData.Size = New System.Drawing.Size(124, 52)
        Me.buttonBrowseData.Text = "Browse Data"
        '
        'imagelistDatabase
        '
        Me.imagelistDatabase.ImageStream = CType(resources.GetObject("imagelistDatabase.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imagelistDatabase.TransparentColor = System.Drawing.Color.Transparent
        Me.imagelistDatabase.Images.SetKeyName(0, "Database")
        Me.imagelistDatabase.Images.SetKeyName(1, "Folder")
        Me.imagelistDatabase.Images.SetKeyName(2, "Table")
        Me.imagelistDatabase.Images.SetKeyName(3, "Table - Different")
        Me.imagelistDatabase.Images.SetKeyName(4, "Table - Missing")
        Me.imagelistDatabase.Images.SetKeyName(5, "Column")
        Me.imagelistDatabase.Images.SetKeyName(6, "Column - Different")
        Me.imagelistDatabase.Images.SetKeyName(7, "Column - Missing")
        Me.imagelistDatabase.Images.SetKeyName(8, "PrimaryKey")
        Me.imagelistDatabase.Images.SetKeyName(9, "PrimaryKey - Different")
        Me.imagelistDatabase.Images.SetKeyName(10, "PrimaryKey - Missing")
        Me.imagelistDatabase.Images.SetKeyName(11, "ForeignKey")
        Me.imagelistDatabase.Images.SetKeyName(12, "ForeignKey - Different")
        Me.imagelistDatabase.Images.SetKeyName(13, "ForeignKey - Missing")
        Me.imagelistDatabase.Images.SetKeyName(14, "AlternateKey")
        Me.imagelistDatabase.Images.SetKeyName(15, "AlternateKey - Different")
        Me.imagelistDatabase.Images.SetKeyName(16, "AlternateKey - Missing")
        Me.imagelistDatabase.Images.SetKeyName(17, "Check")
        Me.imagelistDatabase.Images.SetKeyName(18, "Check - Different")
        Me.imagelistDatabase.Images.SetKeyName(19, "Check - Missing")
        Me.imagelistDatabase.Images.SetKeyName(20, "Index")
        Me.imagelistDatabase.Images.SetKeyName(21, "Index - Clustered")
        Me.imagelistDatabase.Images.SetKeyName(22, "Index - Different")
        Me.imagelistDatabase.Images.SetKeyName(23, "Index - Missing")
        Me.imagelistDatabase.Images.SetKeyName(24, "Report")
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 262)
        Me.Controls.Add(Me.toostripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.toostripMain.ResumeLayout(False)
        Me.toostripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toostripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents imagelistDatabase As System.Windows.Forms.ImageList
    Friend WithEvents buttonCopyDatabaseStructure As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonBrowseData As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCompare As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemCompareStructure As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemCompareData As System.Windows.Forms.ToolStripMenuItem

End Class
