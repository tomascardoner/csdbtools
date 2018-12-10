<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formBrowseData
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.buttonDatasource = New System.Windows.Forms.Button()
        Me.textboxDatasource = New System.Windows.Forms.TextBox()
        Me.labelDatasource = New System.Windows.Forms.Label()
        Me.labelTable = New System.Windows.Forms.Label()
        Me.comboboxTable = New System.Windows.Forms.ComboBox()
        Me.datagridviewData = New System.Windows.Forms.DataGridView()
        Me.checkboxEditMode = New System.Windows.Forms.CheckBox()
        Me.buttonSaveChanges = New System.Windows.Forms.Button()
        CType(Me.datagridviewData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buttonDatasource
        '
        Me.buttonDatasource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDatasource.Location = New System.Drawing.Point(385, 12)
        Me.buttonDatasource.Name = "buttonDatasource"
        Me.buttonDatasource.Size = New System.Drawing.Size(20, 20)
        Me.buttonDatasource.TabIndex = 5
        Me.buttonDatasource.Text = "…"
        Me.buttonDatasource.UseVisualStyleBackColor = True
        '
        'textboxDatasource
        '
        Me.textboxDatasource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxDatasource.Location = New System.Drawing.Point(83, 12)
        Me.textboxDatasource.Name = "textboxDatasource"
        Me.textboxDatasource.Size = New System.Drawing.Size(302, 20)
        Me.textboxDatasource.TabIndex = 4
        '
        'labelDatasource
        '
        Me.labelDatasource.AutoSize = True
        Me.labelDatasource.Location = New System.Drawing.Point(12, 15)
        Me.labelDatasource.Name = "labelDatasource"
        Me.labelDatasource.Size = New System.Drawing.Size(70, 13)
        Me.labelDatasource.TabIndex = 3
        Me.labelDatasource.Text = "Data Source:"
        '
        'labelTable
        '
        Me.labelTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelTable.AutoSize = True
        Me.labelTable.Location = New System.Drawing.Point(419, 15)
        Me.labelTable.Name = "labelTable"
        Me.labelTable.Size = New System.Drawing.Size(71, 13)
        Me.labelTable.TabIndex = 6
        Me.labelTable.Text = "Table / View:"
        '
        'comboboxTable
        '
        Me.comboboxTable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboboxTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxTable.FormattingEnabled = True
        Me.comboboxTable.Location = New System.Drawing.Point(496, 12)
        Me.comboboxTable.Name = "comboboxTable"
        Me.comboboxTable.Size = New System.Drawing.Size(231, 21)
        Me.comboboxTable.TabIndex = 7
        '
        'datagridviewData
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.datagridviewData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridviewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewData.Location = New System.Drawing.Point(12, 66)
        Me.datagridviewData.MultiSelect = False
        Me.datagridviewData.Name = "datagridviewData"
        Me.datagridviewData.ReadOnly = True
        Me.datagridviewData.Size = New System.Drawing.Size(715, 326)
        Me.datagridviewData.TabIndex = 8
        '
        'checkboxEditMode
        '
        Me.checkboxEditMode.AutoSize = True
        Me.checkboxEditMode.Location = New System.Drawing.Point(12, 42)
        Me.checkboxEditMode.Name = "checkboxEditMode"
        Me.checkboxEditMode.Size = New System.Drawing.Size(74, 17)
        Me.checkboxEditMode.TabIndex = 9
        Me.checkboxEditMode.Text = "Edit Mode"
        Me.checkboxEditMode.UseVisualStyleBackColor = True
        '
        'buttonSaveChanges
        '
        Me.buttonSaveChanges.Location = New System.Drawing.Point(92, 38)
        Me.buttonSaveChanges.Name = "buttonSaveChanges"
        Me.buttonSaveChanges.Size = New System.Drawing.Size(90, 22)
        Me.buttonSaveChanges.TabIndex = 10
        Me.buttonSaveChanges.Text = "Save changes"
        Me.buttonSaveChanges.UseVisualStyleBackColor = True
        '
        'DBBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 404)
        Me.Controls.Add(Me.buttonSaveChanges)
        Me.Controls.Add(Me.checkboxEditMode)
        Me.Controls.Add(Me.datagridviewData)
        Me.Controls.Add(Me.comboboxTable)
        Me.Controls.Add(Me.labelTable)
        Me.Controls.Add(Me.buttonDatasource)
        Me.Controls.Add(Me.textboxDatasource)
        Me.Controls.Add(Me.labelDatasource)
        Me.Name = "DBBrowse"
        Me.Text = "Browse DB Data"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.datagridviewData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonDatasource As System.Windows.Forms.Button
    Friend WithEvents textboxDatasource As System.Windows.Forms.TextBox
    Friend WithEvents labelDatasource As System.Windows.Forms.Label
    Friend WithEvents labelTable As System.Windows.Forms.Label
    Friend WithEvents comboboxTable As System.Windows.Forms.ComboBox
    Friend WithEvents datagridviewData As System.Windows.Forms.DataGridView
    Friend WithEvents checkboxEditMode As System.Windows.Forms.CheckBox
    Friend WithEvents buttonSaveChanges As System.Windows.Forms.Button
End Class
