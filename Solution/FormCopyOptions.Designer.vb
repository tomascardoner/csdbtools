<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCopyOptions
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
        Me.buttonSource = New System.Windows.Forms.Button()
        Me.textboxSource = New System.Windows.Forms.TextBox()
        Me.labelSource = New System.Windows.Forms.Label()
        Me.buttonDestination = New System.Windows.Forms.Button()
        Me.textboxDestination = New System.Windows.Forms.TextBox()
        Me.labelDestination = New System.Windows.Forms.Label()
        Me.checkboxExcludeReplicationObjects = New System.Windows.Forms.CheckBox()
        Me.checkboxExcludeHiddenObjects = New System.Windows.Forms.CheckBox()
        Me.checkboxExcludeSystemObjects = New System.Windows.Forms.CheckBox()
        Me.buttonStart = New System.Windows.Forms.Button()
        Me.checkboxCopyIndexes = New System.Windows.Forms.CheckBox()
        Me.checkboxCopyKeys = New System.Windows.Forms.CheckBox()
        Me.checkboxCopyData = New System.Windows.Forms.CheckBox()
        Me.checkboxCopyForeignKeys = New System.Windows.Forms.CheckBox()
        Me.progressbarStatus = New System.Windows.Forms.ProgressBar()
        Me.labelStatus = New System.Windows.Forms.Label()
        Me.checkboxCreateTables = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'buttonSource
        '
        Me.buttonSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonSource.Location = New System.Drawing.Point(387, 12)
        Me.buttonSource.Name = "buttonSource"
        Me.buttonSource.Size = New System.Drawing.Size(20, 20)
        Me.buttonSource.TabIndex = 2
        Me.buttonSource.Text = "…"
        Me.buttonSource.UseVisualStyleBackColor = True
        '
        'textboxSource
        '
        Me.textboxSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxSource.Location = New System.Drawing.Point(81, 12)
        Me.textboxSource.Name = "textboxSource"
        Me.textboxSource.Size = New System.Drawing.Size(306, 20)
        Me.textboxSource.TabIndex = 1
        '
        'labelSource
        '
        Me.labelSource.AutoSize = True
        Me.labelSource.Location = New System.Drawing.Point(12, 15)
        Me.labelSource.Name = "labelSource"
        Me.labelSource.Size = New System.Drawing.Size(44, 13)
        Me.labelSource.TabIndex = 0
        Me.labelSource.Text = "Source:"
        '
        'buttonDestination
        '
        Me.buttonDestination.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDestination.Location = New System.Drawing.Point(387, 38)
        Me.buttonDestination.Name = "buttonDestination"
        Me.buttonDestination.Size = New System.Drawing.Size(20, 20)
        Me.buttonDestination.TabIndex = 5
        Me.buttonDestination.Text = "…"
        Me.buttonDestination.UseVisualStyleBackColor = True
        '
        'textboxDestination
        '
        Me.textboxDestination.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxDestination.Location = New System.Drawing.Point(81, 38)
        Me.textboxDestination.Name = "textboxDestination"
        Me.textboxDestination.Size = New System.Drawing.Size(306, 20)
        Me.textboxDestination.TabIndex = 4
        '
        'labelDestination
        '
        Me.labelDestination.AutoSize = True
        Me.labelDestination.Location = New System.Drawing.Point(12, 41)
        Me.labelDestination.Name = "labelDestination"
        Me.labelDestination.Size = New System.Drawing.Size(63, 13)
        Me.labelDestination.TabIndex = 3
        Me.labelDestination.Text = "Destination:"
        '
        'checkboxExcludeReplicationObjects
        '
        Me.checkboxExcludeReplicationObjects.AutoSize = True
        Me.checkboxExcludeReplicationObjects.Checked = True
        Me.checkboxExcludeReplicationObjects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxExcludeReplicationObjects.Location = New System.Drawing.Point(15, 78)
        Me.checkboxExcludeReplicationObjects.Name = "checkboxExcludeReplicationObjects"
        Me.checkboxExcludeReplicationObjects.Size = New System.Drawing.Size(152, 17)
        Me.checkboxExcludeReplicationObjects.TabIndex = 6
        Me.checkboxExcludeReplicationObjects.Text = "Exclude replication objects"
        Me.checkboxExcludeReplicationObjects.UseVisualStyleBackColor = True
        '
        'checkboxExcludeHiddenObjects
        '
        Me.checkboxExcludeHiddenObjects.AutoSize = True
        Me.checkboxExcludeHiddenObjects.Checked = True
        Me.checkboxExcludeHiddenObjects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxExcludeHiddenObjects.Location = New System.Drawing.Point(15, 101)
        Me.checkboxExcludeHiddenObjects.Name = "checkboxExcludeHiddenObjects"
        Me.checkboxExcludeHiddenObjects.Size = New System.Drawing.Size(136, 17)
        Me.checkboxExcludeHiddenObjects.TabIndex = 7
        Me.checkboxExcludeHiddenObjects.Text = "Exclude hidden objects"
        Me.checkboxExcludeHiddenObjects.UseVisualStyleBackColor = True
        '
        'checkboxExcludeSystemObjects
        '
        Me.checkboxExcludeSystemObjects.AutoSize = True
        Me.checkboxExcludeSystemObjects.Checked = True
        Me.checkboxExcludeSystemObjects.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxExcludeSystemObjects.Location = New System.Drawing.Point(15, 124)
        Me.checkboxExcludeSystemObjects.Name = "checkboxExcludeSystemObjects"
        Me.checkboxExcludeSystemObjects.Size = New System.Drawing.Size(136, 17)
        Me.checkboxExcludeSystemObjects.TabIndex = 8
        Me.checkboxExcludeSystemObjects.Text = "Exclude system objects"
        Me.checkboxExcludeSystemObjects.UseVisualStyleBackColor = True
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(332, 143)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 14
        Me.buttonStart.Text = "Start..."
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'checkboxCopyIndexes
        '
        Me.checkboxCopyIndexes.AutoSize = True
        Me.checkboxCopyIndexes.Checked = True
        Me.checkboxCopyIndexes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxCopyIndexes.Location = New System.Drawing.Point(201, 124)
        Me.checkboxCopyIndexes.Name = "checkboxCopyIndexes"
        Me.checkboxCopyIndexes.Size = New System.Drawing.Size(90, 17)
        Me.checkboxCopyIndexes.TabIndex = 11
        Me.checkboxCopyIndexes.Text = "Copy Indexes"
        Me.checkboxCopyIndexes.UseVisualStyleBackColor = True
        '
        'checkboxCopyKeys
        '
        Me.checkboxCopyKeys.AutoSize = True
        Me.checkboxCopyKeys.Checked = True
        Me.checkboxCopyKeys.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxCopyKeys.Location = New System.Drawing.Point(201, 101)
        Me.checkboxCopyKeys.Name = "checkboxCopyKeys"
        Me.checkboxCopyKeys.Size = New System.Drawing.Size(76, 17)
        Me.checkboxCopyKeys.TabIndex = 10
        Me.checkboxCopyKeys.Text = "Copy Keys"
        Me.checkboxCopyKeys.UseVisualStyleBackColor = True
        '
        'checkboxCopyData
        '
        Me.checkboxCopyData.AutoSize = True
        Me.checkboxCopyData.Checked = True
        Me.checkboxCopyData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxCopyData.Location = New System.Drawing.Point(201, 147)
        Me.checkboxCopyData.Name = "checkboxCopyData"
        Me.checkboxCopyData.Size = New System.Drawing.Size(76, 17)
        Me.checkboxCopyData.TabIndex = 12
        Me.checkboxCopyData.Text = "Copy Data"
        Me.checkboxCopyData.UseVisualStyleBackColor = True
        '
        'checkboxCopyForeignKeys
        '
        Me.checkboxCopyForeignKeys.AutoSize = True
        Me.checkboxCopyForeignKeys.Checked = True
        Me.checkboxCopyForeignKeys.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxCopyForeignKeys.Location = New System.Drawing.Point(201, 170)
        Me.checkboxCopyForeignKeys.Name = "checkboxCopyForeignKeys"
        Me.checkboxCopyForeignKeys.Size = New System.Drawing.Size(114, 17)
        Me.checkboxCopyForeignKeys.TabIndex = 13
        Me.checkboxCopyForeignKeys.Text = "Copy Foreign Keys"
        Me.checkboxCopyForeignKeys.UseVisualStyleBackColor = True
        '
        'progressbarStatus
        '
        Me.progressbarStatus.Location = New System.Drawing.Point(15, 200)
        Me.progressbarStatus.Name = "progressbarStatus"
        Me.progressbarStatus.Size = New System.Drawing.Size(392, 23)
        Me.progressbarStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.progressbarStatus.TabIndex = 15
        Me.progressbarStatus.Visible = False
        '
        'labelStatus
        '
        Me.labelStatus.Location = New System.Drawing.Point(15, 230)
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(392, 18)
        Me.labelStatus.TabIndex = 16
        Me.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.labelStatus.Visible = False
        '
        'checkboxCreateTables
        '
        Me.checkboxCreateTables.AutoSize = True
        Me.checkboxCreateTables.Checked = True
        Me.checkboxCreateTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkboxCreateTables.Location = New System.Drawing.Point(201, 78)
        Me.checkboxCreateTables.Name = "checkboxCreateTables"
        Me.checkboxCreateTables.Size = New System.Drawing.Size(92, 17)
        Me.checkboxCreateTables.TabIndex = 9
        Me.checkboxCreateTables.Text = "Create Tables"
        Me.checkboxCreateTables.UseVisualStyleBackColor = True
        '
        'DBCopy_Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 259)
        Me.Controls.Add(Me.checkboxCreateTables)
        Me.Controls.Add(Me.labelStatus)
        Me.Controls.Add(Me.progressbarStatus)
        Me.Controls.Add(Me.checkboxCopyForeignKeys)
        Me.Controls.Add(Me.checkboxCopyData)
        Me.Controls.Add(Me.checkboxCopyKeys)
        Me.Controls.Add(Me.checkboxCopyIndexes)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.checkboxExcludeSystemObjects)
        Me.Controls.Add(Me.checkboxExcludeHiddenObjects)
        Me.Controls.Add(Me.checkboxExcludeReplicationObjects)
        Me.Controls.Add(Me.buttonDestination)
        Me.Controls.Add(Me.textboxDestination)
        Me.Controls.Add(Me.labelDestination)
        Me.Controls.Add(Me.buttonSource)
        Me.Controls.Add(Me.textboxSource)
        Me.Controls.Add(Me.labelSource)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "DBCopy_Options"
        Me.Text = "CopyStructure"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonSource As System.Windows.Forms.Button
    Friend WithEvents textboxSource As System.Windows.Forms.TextBox
    Friend WithEvents labelSource As System.Windows.Forms.Label
    Friend WithEvents buttonDestination As System.Windows.Forms.Button
    Friend WithEvents textboxDestination As System.Windows.Forms.TextBox
    Friend WithEvents labelDestination As System.Windows.Forms.Label
    Friend WithEvents checkboxExcludeReplicationObjects As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxExcludeHiddenObjects As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxExcludeSystemObjects As System.Windows.Forms.CheckBox
    Friend WithEvents buttonStart As System.Windows.Forms.Button
    Friend WithEvents checkboxCopyIndexes As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxCopyKeys As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxCopyData As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxCopyForeignKeys As System.Windows.Forms.CheckBox
    Friend WithEvents progressbarStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents labelStatus As System.Windows.Forms.Label
    Friend WithEvents checkboxCreateTables As System.Windows.Forms.CheckBox
End Class
