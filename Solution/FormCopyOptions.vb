Public Class FormCopyOptions

    Private Sub buttonSource_Click(sender As Object, e As EventArgs) Handles buttonSource.Click
        textboxSource.Text = CS_Database_ADONET.AskForConnectionString(textboxSource.Text)
    End Sub

    Private Sub buttonDestination_Click(sender As Object, e As EventArgs) Handles buttonDestination.Click
        Call CS_Database_ADONET.AskForConnectionString(textboxDestination.Text)
    End Sub

    Private Sub buttonStart_Click(sender As Object, e As EventArgs) Handles buttonStart.Click
        CSM_Registry.SaveApplicationValue("Copy Database", "ConnectionString1", textboxSource.Text)
        CSM_Registry.SaveApplicationValue("Copy Database", "ConnectionString2", textboxDestination.Text)

        progressbarStatus.Value = 0
        progressbarStatus.Visible = True
        labelStatus.Visible = True
        Me.Enabled = False
        If CopyData.CopyDatabase(textboxSource.Text, textboxDestination.Text, checkboxExcludeReplicationObjects.Checked, checkboxExcludeHiddenObjects.Checked, checkboxExcludeSystemObjects.Checked, checkboxCreateTables.Checked, checkboxCopyKeys.Checked, checkboxCopyIndexes.Checked, checkboxCopyData.Checked, checkboxCopyForeignKeys.Checked) Then
            MsgBox("Database structure copied succesfully.", vbInformation, My.Application.Info.Title)
        End If
        Me.Enabled = True
        progressbarStatus.Visible = False
        labelStatus.Visible = False
    End Sub

    Private Sub DBCopy_Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textboxSource.Text = CSM_Registry.LoadApplicationValue("Copy Database", "ConnectionString1", "")
        textboxDestination.Text = CSM_Registry.LoadApplicationValue("Copy Database", "ConnectionString2", "")
    End Sub
End Class