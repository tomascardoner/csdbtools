Imports System.Data

Public Class formCompareStructure_Select
    Private Sub Me_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        textboxDatabase1.Text = CSM_Registry.LoadApplicationValue("Compare Structures", "ConnectionString1", "")
        textboxDatabase2.Text = CSM_Registry.LoadApplicationValue("Compare Structures", "ConnectionString2", "")

        treeviewDatabase1.ImageList = formMDIMain.imagelistDatabase
        treeviewDatabase1.SelectedImageIndex = Nothing
        treeviewDatabase1.SelectedImageKey = Nothing
        treeviewDatabase2.ImageList = formMDIMain.imagelistDatabase
    End Sub

    Private Sub DatabaseBrowse1_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabaseBrowse1.Click
        textboxDatabase1.Text = CS_Database_ADONET.AskForConnectionString(textboxDatabase1.Text)
    End Sub

    Private Sub DatabaseBrowse2_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabaseBrowse2.Click
        textboxDatabase2.Text = CS_Database_ADONET.AskForConnectionString(textboxDatabase2.Text)
    End Sub

    Private Sub Connect_Click(sender As System.Object, e As System.EventArgs) Handles buttonConnect.Click
        Dim ErrorMessage As String = ""

        If textboxDatabase1.Text = String.Empty Then
            MsgBox("You must select connection for Database 1.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            textboxDatabase1.Focus()
            Exit Sub
        End If
        If textboxDatabase2.Text = String.Empty Then
            MsgBox("You must select connection for Database 2.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            textboxDatabase2.Focus()
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        Try
            'DATABASE 1
            ErrorMessage = "Error connecting to Database 1."
            Dim connectionDatabase1 = New OleDb.OleDbConnection
            connectionDatabase1.ConnectionString = textboxDatabase1.Text
            connectionDatabase1.Open()
            CSM_Registry.SaveApplicationValue("Compare Structures", "ConnectionString1", textboxDatabase1.Text)

            ErrorMessage = "Error reading Database 1 schema."
            CompareStructure.GetDatabaseSchema(True, treeviewDatabase1, connectionDatabase1)
            buttonDatabase1SelectAll.PerformClick()

            ErrorMessage = "Error closing Database 1 connection."
            connectionDatabase1.Close()
            connectionDatabase1.Dispose()

            'DATABASE 2
            ErrorMessage = "Error connecting to Database 2."
            Dim connectionDatabase2 = New OleDb.OleDbConnection
            connectionDatabase2.ConnectionString = textboxDatabase2.Text
            connectionDatabase2.Open()
            CSM_Registry.SaveApplicationValue("Compare Structures", "ConnectionString2", textboxDatabase2.Text)

            ErrorMessage = "Error reading Database 2 schema."
            CompareStructure.GetDatabaseSchema(False, treeviewDatabase2, connectionDatabase2)
            buttonDatabase2SelectAll.PerformClick()

            ErrorMessage = "Error closing Database 2 connection."
            connectionDatabase2.Close()
            connectionDatabase2.Dispose()

        Catch ex As Exception
            CS_Error.ProcessError(ex, ErrorMessage)
            Exit Sub
        End Try

        Cursor.Current = Cursors.Default

        buttonConnect.Visible = False
        buttonCompare.Visible = True
    End Sub

    Private Sub treeviewDatabase_AfterCheck(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles treeviewDatabase1.AfterCheck, treeviewDatabase2.AfterCheck
        For Each treenodeChild As TreeNode In e.Node.Nodes
            treenodeChild.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub buttonDatabase1SelectAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabase1SelectAll.Click
        CheckTreeView(treeviewDatabase1, True)
    End Sub

    Private Sub buttonDatabase1UnselectAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabase1UnselectAll.Click
        CheckTreeView(treeviewDatabase1, False)
    End Sub

    Private Sub buttonDatabase2SelectAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabase2SelectAll.Click
        CheckTreeView(treeviewDatabase2, True)
    End Sub

    Private Sub buttonDatabase2UnselectAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabase2UnselectAll.Click
        CheckTreeView(treeviewDatabase2, False)
    End Sub

    Private Sub CheckTreeView(ByRef treeviewSource As TreeView, ByVal Checked As Boolean)
        treeviewSource.BeginUpdate()
        For Each node As TreeNode In treeviewSource.Nodes
            node.Checked = Checked
        Next
        treeviewSource.EndUpdate()
    End Sub

    Private Sub Compare_Click(sender As System.Object, e As System.EventArgs) Handles buttonCompare.Click
        CompareStructure.CompareDatabases(treeviewDatabase1, treeviewDatabase2)

        formCompareStructure_Result.MdiParent = formMDIMain
        formCompareStructure_Result.Show()

        Me.Close()
    End Sub
End Class