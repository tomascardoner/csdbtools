<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCompareData_Select
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
        Me.buttonDatabaseBrowse1 = New System.Windows.Forms.Button()
        Me.textboxDatabase1 = New System.Windows.Forms.TextBox()
        Me.labelDatabase1 = New System.Windows.Forms.Label()
        Me.buttonDatabaseBrowse2 = New System.Windows.Forms.Button()
        Me.textboxDatabase2 = New System.Windows.Forms.TextBox()
        Me.labelDatabase2 = New System.Windows.Forms.Label()
        Me.buttonConnect = New System.Windows.Forms.Button()
        Me.buttonCheckUncheckAll = New System.Windows.Forms.Button()
        Me.listviewTables = New System.Windows.Forms.ListView()
        Me.columnCheckboxes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnDatabase1TableName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnResult = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnDatabase2TableName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.buttonNext = New System.Windows.Forms.Button()
        Me.labelMaximumDiferrences = New System.Windows.Forms.Label()
        Me.comboboxMaximumDiferrences = New System.Windows.Forms.ComboBox()
        Me.groupboxVerificationMode = New System.Windows.Forms.GroupBox()
        Me.radiobuttonAllTables = New System.Windows.Forms.RadioButton()
        Me.radiobuttonOneTable = New System.Windows.Forms.RadioButton()
        Me.groupboxVerificationMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonDatabaseBrowse1
        '
        Me.buttonDatabaseBrowse1.Location = New System.Drawing.Point(412, 11)
        Me.buttonDatabaseBrowse1.Name = "buttonDatabaseBrowse1"
        Me.buttonDatabaseBrowse1.Size = New System.Drawing.Size(20, 22)
        Me.buttonDatabaseBrowse1.TabIndex = 6
        Me.buttonDatabaseBrowse1.Text = "…"
        Me.buttonDatabaseBrowse1.UseVisualStyleBackColor = True
        '
        'textboxDatabase1
        '
        Me.textboxDatabase1.Location = New System.Drawing.Point(83, 12)
        Me.textboxDatabase1.Name = "textboxDatabase1"
        Me.textboxDatabase1.Size = New System.Drawing.Size(328, 20)
        Me.textboxDatabase1.TabIndex = 5
        '
        'labelDatabase1
        '
        Me.labelDatabase1.AutoSize = True
        Me.labelDatabase1.Location = New System.Drawing.Point(12, 15)
        Me.labelDatabase1.Name = "labelDatabase1"
        Me.labelDatabase1.Size = New System.Drawing.Size(65, 13)
        Me.labelDatabase1.TabIndex = 4
        Me.labelDatabase1.Text = "Database 1:"
        '
        'buttonDatabaseBrowse2
        '
        Me.buttonDatabaseBrowse2.Location = New System.Drawing.Point(842, 11)
        Me.buttonDatabaseBrowse2.Name = "buttonDatabaseBrowse2"
        Me.buttonDatabaseBrowse2.Size = New System.Drawing.Size(20, 22)
        Me.buttonDatabaseBrowse2.TabIndex = 9
        Me.buttonDatabaseBrowse2.Text = "…"
        Me.buttonDatabaseBrowse2.UseVisualStyleBackColor = True
        '
        'textboxDatabase2
        '
        Me.textboxDatabase2.Location = New System.Drawing.Point(509, 12)
        Me.textboxDatabase2.Name = "textboxDatabase2"
        Me.textboxDatabase2.Size = New System.Drawing.Size(331, 20)
        Me.textboxDatabase2.TabIndex = 8
        '
        'labelDatabase2
        '
        Me.labelDatabase2.AutoSize = True
        Me.labelDatabase2.Location = New System.Drawing.Point(438, 15)
        Me.labelDatabase2.Name = "labelDatabase2"
        Me.labelDatabase2.Size = New System.Drawing.Size(65, 13)
        Me.labelDatabase2.TabIndex = 7
        Me.labelDatabase2.Text = "Database 2:"
        '
        'buttonConnect
        '
        Me.buttonConnect.Location = New System.Drawing.Point(868, 11)
        Me.buttonConnect.Name = "buttonConnect"
        Me.buttonConnect.Size = New System.Drawing.Size(74, 22)
        Me.buttonConnect.TabIndex = 0
        Me.buttonConnect.Text = "Connect"
        Me.buttonConnect.UseVisualStyleBackColor = True
        '
        'buttonCheckUncheckAll
        '
        Me.buttonCheckUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonCheckUncheckAll.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_CHECK_ALL_24
        Me.buttonCheckUncheckAll.Location = New System.Drawing.Point(12, 436)
        Me.buttonCheckUncheckAll.Name = "buttonCheckUncheckAll"
        Me.buttonCheckUncheckAll.Size = New System.Drawing.Size(35, 35)
        Me.buttonCheckUncheckAll.TabIndex = 2
        Me.buttonCheckUncheckAll.UseVisualStyleBackColor = True
        '
        'listviewTables
        '
        Me.listviewTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listviewTables.CheckBoxes = True
        Me.listviewTables.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnCheckboxes, Me.columnDatabase1TableName, Me.columnResult, Me.columnDatabase2TableName})
        Me.listviewTables.FullRowSelect = True
        Me.listviewTables.GridLines = True
        Me.listviewTables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listviewTables.HideSelection = False
        Me.listviewTables.Location = New System.Drawing.Point(12, 38)
        Me.listviewTables.MultiSelect = False
        Me.listviewTables.Name = "listviewTables"
        Me.listviewTables.ShowGroups = False
        Me.listviewTables.Size = New System.Drawing.Size(930, 392)
        Me.listviewTables.TabIndex = 1
        Me.listviewTables.UseCompatibleStateImageBehavior = False
        Me.listviewTables.View = System.Windows.Forms.View.Details
        '
        'columnCheckboxes
        '
        Me.columnCheckboxes.Text = ""
        Me.columnCheckboxes.Width = 30
        '
        'columnDatabase1TableName
        '
        Me.columnDatabase1TableName.Text = "Database 1"
        Me.columnDatabase1TableName.Width = 350
        '
        'columnResult
        '
        Me.columnResult.Text = "Result"
        Me.columnResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnResult.Width = 80
        '
        'columnDatabase2TableName
        '
        Me.columnDatabase2TableName.Text = "Database 2"
        Me.columnDatabase2TableName.Width = 350
        '
        'buttonNext
        '
        Me.buttonNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonNext.Image = Global.CS_DB_Tools.My.Resources.Resources.IMAGE_NEXT_24
        Me.buttonNext.Location = New System.Drawing.Point(854, 436)
        Me.buttonNext.Name = "buttonNext"
        Me.buttonNext.Size = New System.Drawing.Size(88, 35)
        Me.buttonNext.TabIndex = 3
        Me.buttonNext.Text = "Next"
        Me.buttonNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.buttonNext.UseVisualStyleBackColor = True
        '
        'labelMaximumDiferrences
        '
        Me.labelMaximumDiferrences.AutoSize = True
        Me.labelMaximumDiferrences.Location = New System.Drawing.Point(516, 447)
        Me.labelMaximumDiferrences.Name = "labelMaximumDiferrences"
        Me.labelMaximumDiferrences.Size = New System.Drawing.Size(141, 13)
        Me.labelMaximumDiferrences.TabIndex = 10
        Me.labelMaximumDiferrences.Text = "Maximum differences to find:"
        '
        'comboboxMaximumDiferrences
        '
        Me.comboboxMaximumDiferrences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMaximumDiferrences.FormattingEnabled = True
        Me.comboboxMaximumDiferrences.Items.AddRange(New Object() {"1", "5", "10", "20", "50", "100", "200"})
        Me.comboboxMaximumDiferrences.Location = New System.Drawing.Point(663, 444)
        Me.comboboxMaximumDiferrences.Name = "comboboxMaximumDiferrences"
        Me.comboboxMaximumDiferrences.Size = New System.Drawing.Size(56, 21)
        Me.comboboxMaximumDiferrences.TabIndex = 11
        '
        'groupboxVerificationMode
        '
        Me.groupboxVerificationMode.Controls.Add(Me.radiobuttonAllTables)
        Me.groupboxVerificationMode.Controls.Add(Me.radiobuttonOneTable)
        Me.groupboxVerificationMode.Location = New System.Drawing.Point(192, 434)
        Me.groupboxVerificationMode.Name = "groupboxVerificationMode"
        Me.groupboxVerificationMode.Size = New System.Drawing.Size(200, 44)
        Me.groupboxVerificationMode.TabIndex = 12
        Me.groupboxVerificationMode.TabStop = False
        Me.groupboxVerificationMode.Text = "Verification mode:"
        '
        'radiobuttonAllTables
        '
        Me.radiobuttonAllTables.AutoSize = True
        Me.radiobuttonAllTables.Location = New System.Drawing.Point(126, 20)
        Me.radiobuttonAllTables.Name = "radiobuttonAllTables"
        Me.radiobuttonAllTables.Size = New System.Drawing.Size(67, 17)
        Me.radiobuttonAllTables.TabIndex = 1
        Me.radiobuttonAllTables.Text = "All tables"
        Me.radiobuttonAllTables.UseVisualStyleBackColor = True
        '
        'radiobuttonOneTable
        '
        Me.radiobuttonOneTable.AutoSize = True
        Me.radiobuttonOneTable.Checked = True
        Me.radiobuttonOneTable.Location = New System.Drawing.Point(6, 19)
        Me.radiobuttonOneTable.Name = "radiobuttonOneTable"
        Me.radiobuttonOneTable.Size = New System.Drawing.Size(114, 17)
        Me.radiobuttonOneTable.TabIndex = 0
        Me.radiobuttonOneTable.TabStop = True
        Me.radiobuttonOneTable.Text = "One table at a time"
        Me.radiobuttonOneTable.UseVisualStyleBackColor = True
        '
        'formCompareData_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 483)
        Me.Controls.Add(Me.groupboxVerificationMode)
        Me.Controls.Add(Me.comboboxMaximumDiferrences)
        Me.Controls.Add(Me.labelMaximumDiferrences)
        Me.Controls.Add(Me.buttonNext)
        Me.Controls.Add(Me.listviewTables)
        Me.Controls.Add(Me.buttonDatabaseBrowse2)
        Me.Controls.Add(Me.buttonDatabaseBrowse1)
        Me.Controls.Add(Me.textboxDatabase2)
        Me.Controls.Add(Me.labelDatabase2)
        Me.Controls.Add(Me.textboxDatabase1)
        Me.Controls.Add(Me.labelDatabase1)
        Me.Controls.Add(Me.buttonCheckUncheckAll)
        Me.Controls.Add(Me.buttonConnect)
        Me.Name = "formCompareData_Select"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Compare Data"
        Me.groupboxVerificationMode.ResumeLayout(False)
        Me.groupboxVerificationMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelDatabase1 As System.Windows.Forms.Label
    Friend WithEvents labelDatabase2 As System.Windows.Forms.Label
    Friend WithEvents buttonDatabaseBrowse1 As System.Windows.Forms.Button
    Friend WithEvents buttonDatabaseBrowse2 As System.Windows.Forms.Button
    Friend WithEvents textboxDatabase2 As System.Windows.Forms.TextBox
    Friend WithEvents buttonConnect As System.Windows.Forms.Button
    Friend WithEvents buttonCheckUncheckAll As System.Windows.Forms.Button
    Friend WithEvents textboxDatabase1 As System.Windows.Forms.TextBox
    Friend WithEvents listviewTables As System.Windows.Forms.ListView
    Friend WithEvents columnDatabase1TableName As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnResult As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnDatabase2TableName As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnCheckboxes As System.Windows.Forms.ColumnHeader
    Friend WithEvents buttonNext As System.Windows.Forms.Button
    Friend WithEvents labelMaximumDiferrences As System.Windows.Forms.Label
    Friend WithEvents comboboxMaximumDiferrences As System.Windows.Forms.ComboBox
    Friend WithEvents groupboxVerificationMode As System.Windows.Forms.GroupBox
    Friend WithEvents radiobuttonAllTables As System.Windows.Forms.RadioButton
    Friend WithEvents radiobuttonOneTable As System.Windows.Forms.RadioButton
End Class
