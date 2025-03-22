<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCompareStructureSelect
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
        Me.splitcontainerDatabase = New System.Windows.Forms.SplitContainer()
        Me.buttonDatabaseBrowse1 = New System.Windows.Forms.Button()
        Me.treeviewDatabase1 = New System.Windows.Forms.TreeView()
        Me.textboxDatabase1 = New System.Windows.Forms.TextBox()
        Me.labelDatabase1 = New System.Windows.Forms.Label()
        Me.buttonDatabaseBrowse2 = New System.Windows.Forms.Button()
        Me.textboxDatabase2 = New System.Windows.Forms.TextBox()
        Me.treeviewDatabase2 = New System.Windows.Forms.TreeView()
        Me.labelDatabase2 = New System.Windows.Forms.Label()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.buttonDatabase1SelectAll = New System.Windows.Forms.Button()
        Me.buttonDatabase1UnselectAll = New System.Windows.Forms.Button()
        Me.buttonDatabase2UnselectAll = New System.Windows.Forms.Button()
        Me.buttonDatabase2SelectAll = New System.Windows.Forms.Button()
        Me.buttonCompare = New System.Windows.Forms.Button()
        CType(Me.splitcontainerDatabase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitcontainerDatabase.Panel1.SuspendLayout()
        Me.splitcontainerDatabase.Panel2.SuspendLayout()
        Me.splitcontainerDatabase.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitcontainerDatabase
        '
        Me.splitcontainerDatabase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitcontainerDatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splitcontainerDatabase.Location = New System.Drawing.Point(0, 0)
        Me.splitcontainerDatabase.Name = "splitcontainerDatabase"
        '
        'splitcontainerDatabase.Panel1
        '
        Me.splitcontainerDatabase.Panel1.Controls.Add(Me.buttonDatabaseBrowse1)
        Me.splitcontainerDatabase.Panel1.Controls.Add(Me.treeviewDatabase1)
        Me.splitcontainerDatabase.Panel1.Controls.Add(Me.textboxDatabase1)
        Me.splitcontainerDatabase.Panel1.Controls.Add(Me.labelDatabase1)
        '
        'splitcontainerDatabase.Panel2
        '
        Me.splitcontainerDatabase.Panel2.Controls.Add(Me.buttonDatabaseBrowse2)
        Me.splitcontainerDatabase.Panel2.Controls.Add(Me.textboxDatabase2)
        Me.splitcontainerDatabase.Panel2.Controls.Add(Me.treeviewDatabase2)
        Me.splitcontainerDatabase.Panel2.Controls.Add(Me.labelDatabase2)
        Me.splitcontainerDatabase.Size = New System.Drawing.Size(867, 452)
        Me.splitcontainerDatabase.SplitterDistance = 431
        Me.splitcontainerDatabase.TabIndex = 0
        '
        'buttonDatabaseBrowse1
        '
        Me.buttonDatabaseBrowse1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDatabaseBrowse1.Location = New System.Drawing.Point(402, 6)
        Me.buttonDatabaseBrowse1.Name = "buttonDatabaseBrowse1"
        Me.buttonDatabaseBrowse1.Size = New System.Drawing.Size(20, 20)
        Me.buttonDatabaseBrowse1.TabIndex = 3
        Me.buttonDatabaseBrowse1.Text = "…"
        Me.buttonDatabaseBrowse1.UseVisualStyleBackColor = True
        '
        'treeviewDatabase1
        '
        Me.treeviewDatabase1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewDatabase1.CheckBoxes = True
        Me.treeviewDatabase1.HideSelection = False
        Me.treeviewDatabase1.Location = New System.Drawing.Point(3, 36)
        Me.treeviewDatabase1.Name = "treeviewDatabase1"
        Me.treeviewDatabase1.Size = New System.Drawing.Size(421, 412)
        Me.treeviewDatabase1.TabIndex = 2
        '
        'textboxDatabase1
        '
        Me.textboxDatabase1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxDatabase1.Location = New System.Drawing.Point(74, 6)
        Me.textboxDatabase1.Name = "textboxDatabase1"
        Me.textboxDatabase1.Size = New System.Drawing.Size(328, 20)
        Me.textboxDatabase1.TabIndex = 1
        '
        'labelDatabase1
        '
        Me.labelDatabase1.AutoSize = True
        Me.labelDatabase1.Location = New System.Drawing.Point(3, 9)
        Me.labelDatabase1.Name = "labelDatabase1"
        Me.labelDatabase1.Size = New System.Drawing.Size(65, 13)
        Me.labelDatabase1.TabIndex = 0
        Me.labelDatabase1.Text = "Database 1:"
        '
        'buttonDatabaseBrowse2
        '
        Me.buttonDatabaseBrowse2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDatabaseBrowse2.Location = New System.Drawing.Point(405, 6)
        Me.buttonDatabaseBrowse2.Name = "buttonDatabaseBrowse2"
        Me.buttonDatabaseBrowse2.Size = New System.Drawing.Size(20, 20)
        Me.buttonDatabaseBrowse2.TabIndex = 5
        Me.buttonDatabaseBrowse2.Text = "…"
        Me.buttonDatabaseBrowse2.UseVisualStyleBackColor = True
        '
        'textboxDatabase2
        '
        Me.textboxDatabase2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxDatabase2.Location = New System.Drawing.Point(74, 6)
        Me.textboxDatabase2.Name = "textboxDatabase2"
        Me.textboxDatabase2.Size = New System.Drawing.Size(331, 20)
        Me.textboxDatabase2.TabIndex = 4
        '
        'treeviewDatabase2
        '
        Me.treeviewDatabase2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewDatabase2.CheckBoxes = True
        Me.treeviewDatabase2.HideSelection = False
        Me.treeviewDatabase2.Location = New System.Drawing.Point(3, 36)
        Me.treeviewDatabase2.Name = "treeviewDatabase2"
        Me.treeviewDatabase2.Size = New System.Drawing.Size(424, 412)
        Me.treeviewDatabase2.TabIndex = 3
        '
        'labelDatabase2
        '
        Me.labelDatabase2.AutoSize = True
        Me.labelDatabase2.Location = New System.Drawing.Point(3, 9)
        Me.labelDatabase2.Name = "labelDatabase2"
        Me.labelDatabase2.Size = New System.Drawing.Size(65, 13)
        Me.labelDatabase2.TabIndex = 1
        Me.labelDatabase2.Text = "Database 2:"
        '
        'buttonConnect
        '
        Me.buttonConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonConnect.Location = New System.Drawing.Point(788, 456)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(74, 22)
        Me.buttonConnect.TabIndex = 1
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonDatabase1SelectAll
        '
        Me.buttonDatabase1SelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonDatabase1SelectAll.Location = New System.Drawing.Point(5, 456)
        Me.buttonDatabase1SelectAll.Name = "buttonDatabase1SelectAll"
        Me.buttonDatabase1SelectAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonDatabase1SelectAll.TabIndex = 2
        Me.buttonDatabase1SelectAll.Text = "Select all"
        Me.buttonDatabase1SelectAll.UseVisualStyleBackColor = True
        '
        'buttonDatabase1UnselectAll
        '
        Me.buttonDatabase1UnselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonDatabase1UnselectAll.Location = New System.Drawing.Point(85, 456)
        Me.buttonDatabase1UnselectAll.Name = "buttonDatabase1UnselectAll"
        Me.buttonDatabase1UnselectAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonDatabase1UnselectAll.TabIndex = 3
        Me.buttonDatabase1UnselectAll.Text = "Unselect all"
        Me.buttonDatabase1UnselectAll.UseVisualStyleBackColor = True
        '
        'buttonDatabase2UnselectAll
        '
        Me.buttonDatabase2UnselectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.buttonDatabase2UnselectAll.Location = New System.Drawing.Point(521, 456)
        Me.buttonDatabase2UnselectAll.Name = "buttonDatabase2UnselectAll"
        Me.buttonDatabase2UnselectAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonDatabase2UnselectAll.TabIndex = 5
        Me.buttonDatabase2UnselectAll.Text = "Unselect all"
        Me.buttonDatabase2UnselectAll.UseVisualStyleBackColor = True
        '
        'buttonDatabase2SelectAll
        '
        Me.buttonDatabase2SelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.buttonDatabase2SelectAll.Location = New System.Drawing.Point(441, 456)
        Me.buttonDatabase2SelectAll.Name = "buttonDatabase2SelectAll"
        Me.buttonDatabase2SelectAll.Size = New System.Drawing.Size(74, 22)
        Me.buttonDatabase2SelectAll.TabIndex = 4
        Me.buttonDatabase2SelectAll.Text = "Select all"
        Me.buttonDatabase2SelectAll.UseVisualStyleBackColor = True
        '
        'buttonCompare
        '
        Me.buttonCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCompare.Location = New System.Drawing.Point(788, 456)
        Me.buttonCompare.Name = "buttonCompare"
        Me.buttonCompare.Size = New System.Drawing.Size(74, 22)
        Me.buttonCompare.TabIndex = 6
        Me.buttonCompare.Text = "Compare"
        Me.buttonCompare.UseVisualStyleBackColor = True
        Me.buttonCompare.Visible = False
        '
        'DBCompareStructure_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 483)
        Me.Controls.Add(Me.buttonCompare)
        Me.Controls.Add(Me.buttonDatabase2UnselectAll)
        Me.Controls.Add(Me.buttonDatabase2SelectAll)
        Me.Controls.Add(Me.buttonDatabase1UnselectAll)
        Me.Controls.Add(Me.buttonDatabase1SelectAll)
        Me.Controls.Add(Me.buttonConnect)
        Me.Controls.Add(Me.splitcontainerDatabase)
        Me.Name = "DBCompareStructure_Select"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Compare Structures"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.splitcontainerDatabase.Panel1.ResumeLayout(False)
        Me.splitcontainerDatabase.Panel1.PerformLayout()
        Me.splitcontainerDatabase.Panel2.ResumeLayout(False)
        Me.splitcontainerDatabase.Panel2.PerformLayout()
        CType(Me.splitcontainerDatabase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitcontainerDatabase.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitcontainerDatabase As System.Windows.Forms.SplitContainer
    Friend WithEvents labelDatabase1 As System.Windows.Forms.Label
    Friend WithEvents labelDatabase2 As System.Windows.Forms.Label
    Friend WithEvents treeviewDatabase1 As System.Windows.Forms.TreeView
    Friend WithEvents treeviewDatabase2 As System.Windows.Forms.TreeView
    Friend WithEvents buttonDatabaseBrowse1 As System.Windows.Forms.Button
    Friend WithEvents buttonDatabaseBrowse2 As System.Windows.Forms.Button
    Friend WithEvents textboxDatabase2 As System.Windows.Forms.TextBox
    Friend WithEvents buttonConnect As System.Windows.Forms.Button
    Friend WithEvents buttonDatabase1SelectAll As System.Windows.Forms.Button
    Friend WithEvents buttonDatabase1UnselectAll As System.Windows.Forms.Button
    Friend WithEvents buttonDatabase2UnselectAll As System.Windows.Forms.Button
    Friend WithEvents buttonDatabase2SelectAll As System.Windows.Forms.Button
    Friend WithEvents textboxDatabase1 As System.Windows.Forms.TextBox
    Friend WithEvents buttonCompare As System.Windows.Forms.Button
End Class
