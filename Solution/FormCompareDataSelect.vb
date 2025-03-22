Imports System.Data

Public Class FormCompareDataSelect
    Private Const RESULT_TABLE_BOTHSIDES As String = "=="
    Private Const RESULT_TABLE_LEFTSIDE As String = "<<"
    Private Const RESULT_TABLE_RIGHTSIDE As String = ">>"

    Private mConnectionString1 As String
    Private mConnectionString2 As String

    Private mSkip As Boolean = False

    Private Sub Me_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        textboxDatabase1.Text = CSM_Registry.LoadApplicationValue("Compare Data", "ConnectionString1", "")
        textboxDatabase2.Text = CSM_Registry.LoadApplicationValue("Compare Data", "ConnectionString2", "")

        comboboxMaximumDiferrences.SelectedIndex = 3
    End Sub

    Private Sub DatabaseBrowse1_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabaseBrowse1.Click
        textboxDatabase1.Text = CS_Database_ADONET.AskForConnectionString(textboxDatabase1.Text)
    End Sub

    Private Sub DatabaseBrowse2_Click(sender As System.Object, e As System.EventArgs) Handles buttonDatabaseBrowse2.Click
        textboxDatabase2.Text = CS_Database_ADONET.AskForConnectionString(textboxDatabase2.Text)
    End Sub

    Private Sub Connect_Click(sender As System.Object, e As System.EventArgs) Handles buttonConnect.Click
        Dim ErrorMessage As String = String.Empty

        If textboxDatabase1.Text = String.Empty Then
            MsgBox("You must select connection for Database 1.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            textboxDatabase1.Focus()
            Return
        End If
        If textboxDatabase2.Text = String.Empty Then
            MsgBox("You must select connection for Database 2.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            textboxDatabase2.Focus()
            Return
        End If

        Cursor.Current = Cursors.WaitCursor

        listviewTables.Items.Clear()

        Try
            ' DATABASE 1 CONNECT
            ErrorMessage = "Error connecting to Database 1."
            Dim connectionDatabase1 = New OleDb.OleDbConnection
            connectionDatabase1.ConnectionString = textboxDatabase1.Text
            connectionDatabase1.Open()
            mConnectionString1 = textboxDatabase1.Text
            CSM_Registry.SaveApplicationValue("Compare Data", "ConnectionString1", mConnectionString1)

            ' DATABASE 1 READ TABLES
            Dim datatableTables1 As DataTable
            ErrorMessage = "Error reading Database 1 tables."
            datatableTables1 = connectionDatabase1.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, TABLE_SCHEMA, Nothing, TABLE_TYPE})
            If datatableTables1.Rows.Count = 0 Then
                MsgBox("Database 1 doesn't contains tables.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Cursor.Current = Cursors.Default
                ErrorMessage = "Error closing Database 1 connection."
                connectionDatabase1.Close()
                connectionDatabase1.Dispose()
                Exit Sub
            End If

            ' DATABASE 2 CONNECT
            ErrorMessage = "Error connecting to Database 2."
            Dim connectionDatabase2 = New OleDb.OleDbConnection
            connectionDatabase2.ConnectionString = textboxDatabase2.Text
            connectionDatabase2.Open()
            mConnectionString2 = textboxDatabase2.Text
            CSM_Registry.SaveApplicationValue("Compare Data", "ConnectionString2", textboxDatabase2.Text)

            ' DATABASE 2 READ TABLES
            Dim datatableTables2 As DataTable
            ErrorMessage = "Error reading Database 2 tables."
            datatableTables2 = connectionDatabase2.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, TABLE_SCHEMA, Nothing, TABLE_TYPE})
            If datatableTables2.Rows.Count = 0 Then
                MsgBox("Database 2 doesn't contains tables.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Cursor.Current = Cursors.Default
                ErrorMessage = "Error closing Database 2 connection."
                connectionDatabase2.Close()
                connectionDatabase2.Dispose()
                Exit Sub
            End If

            ' COMPARE IF EVERY TABLE EXISTS IN BOTH DATABASES
            Dim ListViewItemCurrent As ListViewItem

            Dim datarowTable1 As DataRow
            Dim Table1Index As Integer = 0
            Dim Table1Count As Integer
            Dim Table1Name As String = ""

            Dim datarowTable2 As DataRow
            Dim Table2Index As Integer = 0
            Dim Table2Count As Integer
            Dim Table2Name As String = ""

            Table1Count = datatableTables1.DefaultView.Count
            Table2Count = datatableTables2.DefaultView.Count

            mSkip = True

            Do While (Table1Index <= Table1Count - 1 Or Table2Index <= Table2Count - 1)
                If Table1Index <= Table1Count - 1 Then
                    datarowTable1 = datatableTables1.DefaultView.Table.Rows(Table1Index)
                    Table1Name = datarowTable1(DATAROW_COLUMN_TABLE_NAME).ToString
                Else
                    Table1Name = StrDup(128, "Z")
                End If
                If Table2Index <= Table2Count - 1 Then
                    datarowTable2 = datatableTables2.DefaultView.Table.Rows(Table2Index)
                    Table2Name = datarowTable2(DATAROW_COLUMN_TABLE_NAME).ToString
                Else
                    Table2Name = StrDup(128, "Z")
                End If

                If EXCLUSION_TABLE_NAME.Contains("|" & Table1Name & "|") Then
                    Table1Index += 1
                ElseIf EXCLUSION_TABLE_NAME.Contains("|" & Table2Name & "|") Then
                    Table2Index += 1
                Else
                    ' Creo el ListViewItem
                    ListViewItemCurrent = New ListViewItem()
                    Select Case Strings.StrComp(Table1Name, Table2Name, CompareMethod.Text)
                        Case -1
                            ' LA TABLA O VISTA NO EXISTE EN LA BASE DE DATOS 2
                            ListViewItemCurrent.SubItems.Add(Table1Name)
                            ListViewItemCurrent.SubItems.Add(RESULT_TABLE_LEFTSIDE)
                            ListViewItemCurrent.SubItems.Add("")
                            ListViewItemCurrent.ForeColor = Color.Red
                            Table1Index += 1
                        Case 0
                            'LA TABLA O VISTA EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS COLUMNAS, LOS PRIMARY KEYS Y LUEGO SIGO CON LA SIGUIENTE TABLA O VISTA
                            ListViewItemCurrent.Checked = True
                            ListViewItemCurrent.SubItems.Add(Table1Name)
                            ListViewItemCurrent.SubItems.Add(RESULT_TABLE_BOTHSIDES)
                            ListViewItemCurrent.SubItems.Add(Table2Name)
                            ListViewItemCurrent.ForeColor = Color.Green
                            Table1Index += 1
                            Table2Index += 1
                        Case 1
                            'LA TABLA O VISTA NO EXISTE EN LA BASE DE DATOS 1
                            ListViewItemCurrent.SubItems.Add("")
                            ListViewItemCurrent.SubItems.Add(RESULT_TABLE_RIGHTSIDE)
                            ListViewItemCurrent.SubItems.Add(Table2Name)
                            ListViewItemCurrent.ForeColor = Color.Red
                            Table2Index += 1
                    End Select
                    listviewTables.Items.Add(ListViewItemCurrent)
                End If
            Loop

            mSkip = False

            ' DATABASE 1 CLOSE CONNECTION
            ErrorMessage = "Error closing Database 1 connection."
            connectionDatabase1.Close()
            connectionDatabase1.Dispose()

            ' DATABASE 2 CLOSE CONNECTION
            ErrorMessage = "Error closing Database 2 connection."
            connectionDatabase2.Close()
            connectionDatabase2.Dispose()

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, ErrorMessage)
            Exit Sub
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles listviewTables.ItemCheck
        Dim item As ListViewItem

        If Not mSkip Then
            item = listviewTables.Items(e.Index)
            If item.SubItems(2).Text <> RESULT_TABLE_BOTHSIDES Then
                e.NewValue = CheckState.Unchecked
            End If
        End If
    End Sub

    Private Sub CheckUncheckAll_Click(sender As System.Object, e As System.EventArgs) Handles buttonCheckUncheckAll.Click
        Static LastState As Boolean = True

        listviewTables.BeginUpdate()
        For Each item As ListViewItem In listviewTables.Items
            If item.SubItems(2).Text = RESULT_TABLE_BOTHSIDES Then
                item.Checked = Not LastState
            Else
                item.Checked = False
            End If
        Next
        listviewTables.EndUpdate()

        LastState = Not LastState
    End Sub

    Private Sub Next_Click(sender As Object, e As EventArgs) Handles buttonNext.Click
        Dim ListSelectedTables As List(Of String)

        If listviewTables.Items.Count = 0 Then
            MsgBox("There is no Table to compare data.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If
        If listviewTables.CheckedItems.Count = 0 Then
            MsgBox("There is no Tables checked to compare data.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If

        ListSelectedTables = New List(Of String)
        For Each item As ListViewItem In listviewTables.CheckedItems
            ListSelectedTables.Add(item.Name)
        Next

        CompareData.CompareTables(mConnectionString1, mConnectionString2, ListSelectedTables, radiobuttonAllTables.Checked, CByte(comboboxMaximumDiferrences.Text))

        ListSelectedTables = Nothing
        Me.Close()
    End Sub
End Class