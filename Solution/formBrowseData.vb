Public Class formBrowseData
    Private mConnection As System.Data.OleDb.OleDbConnection
    Private mDataAdapter As System.Data.OleDb.OleDbDataAdapter
    Private mDataSet As New System.Data.DataSet

    Private Sub Me_Load() Handles Me.Load
        textboxDatasource.Text = CSM_Registry.LoadApplicationValue("Browse Data", "ConnectionString", "")
        If textboxDatasource.Text.Length > 0 Then
            FillListTables()
        End If
    End Sub

    Private Sub buttonDatasource_Click(sender As Object, e As EventArgs) Handles buttonDatasource.Click
        textboxDatasource.Text = CS_Database_ADONET.AskForConnectionString(textboxDatasource.Text)

        If textboxDatasource.Text.Length > 0 Then
            FillListTables()
        End If
    End Sub

    Private Sub FillListTables()
        Const TABLE_TYPE_TABLE As String = "TABLE"
        Const TABLE_TYPE_QUERY As String = "VIEW"
        'Const TABLE_TYPE_ACCESS_TABLE As String = "ACCESS TABLE"
        'Const TABLE_TYPE_SYSTEM_TABLE As String = "SYSTEM TABLE"

        comboboxTable.Items.Clear()

        Try
            mConnection = New System.Data.OleDb.OleDbConnection
            mConnection.ConnectionString = textboxDatasource.Text
            mConnection.Open()

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error opening Datasource for retrieve Tables list.")
            Exit Sub
        End Try

        Try
            Dim Tables As System.Data.DataTable
            Tables = mConnection.GetSchema("Tables")

            For Each DataRowCurrent As System.Data.DataRow In Tables.Rows
                If DataRowCurrent(3) = TABLE_TYPE_TABLE Or DataRowCurrent(3) = TABLE_TYPE_QUERY Then
                    comboboxTable.Items.Add(DataRowCurrent(2))
                End If
            Next

            CSM_Registry.SaveApplicationValue("Browse Data", "ConnectionString", textboxDatasource.Text)
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error retrieving Tables list.")
        End Try
    End Sub

    Private Sub checkboxEditMode_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxEditMode.CheckedChanged
        datagridviewData.ReadOnly = Not checkboxEditMode.Checked
    End Sub

    Private Sub comboboxTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxTable.SelectedIndexChanged
        If comboboxTable.SelectedIndex > -1 Then

            Try
                mDataAdapter = New System.Data.OleDb.OleDbDataAdapter
                ' Construct the list of fields excluding replication ones
                Dim ListOfFields As String = ""
                ' Fill the data adapter only to obtain the list of fields
                mDataAdapter.SelectCommand = New OleDb.OleDbCommand(String.Format("SELECT * FROM {0}", comboboxTable.Text), mConnection)
                mDataSet = New System.Data.DataSet
                mDataAdapter.Fill(mDataSet)
                For Each ColumnCurrent As System.Data.DataColumn In mDataSet.Tables(0).Columns
                    If ColumnCurrent.ColumnName.StartsWith(CS_Database_ADONET.JET_REPLICATION_MEMOTYPE_COLUMNNAMEPREFIX) Then
                        Dim ColumnOriginatingIndex As Integer
                        ColumnOriginatingIndex = mDataSet.Tables(0).Columns.IndexOf(ColumnCurrent.ColumnName.Substring(CS_Database_ADONET.JET_REPLICATION_MEMOTYPE_COLUMNNAMEPREFIX.Length))
                        If ColumnOriginatingIndex > -1 Then
                            Dim ColumnOriginating As System.Data.DataColumn
                            ColumnOriginating = mDataSet.Tables(0).Columns(ColumnOriginatingIndex)
                            If ColumnOriginating.DataType.Name = "String" And ColumnOriginating.MaxLength = -1 Then
                                Continue For
                            End If
                        End If
                    End If
                    If CS_Database_ADONET.JET_REPLICATION_COLUMNS.Contains(ColumnCurrent.ColumnName) Then
                        Continue For
                    End If
                    ListOfFields &= IIf(ListOfFields.Length = 0, "", ", ") & ColumnCurrent.ColumnName
                Next

                ' Now fill the data adapter again with reduced list of fields
                mDataAdapter = New System.Data.OleDb.OleDbDataAdapter
                mDataAdapter.SelectCommand = New OleDb.OleDbCommand(String.Format("SELECT {1} FROM {0}", comboboxTable.Text, ListOfFields), mConnection)
                mDataSet = New System.Data.DataSet
                mDataAdapter.Fill(mDataSet)

                Dim CommandBuilderCurrent As New OleDb.OleDbCommandBuilder(mDataAdapter)
                CommandBuilderCurrent.SetAllValues = False

                Dim datatableCurrent As New System.Data.DataTable
                datatableCurrent = mDataSet.Tables(0)

                datagridviewData.DataSource = datatableCurrent
                datagridviewData.Refresh()

            Catch ex As Exception
                CS_Error.ProcessError(ex, String.Format("Error opening Table {0}.", comboboxTable.Text))
            End Try
        End If
    End Sub

    Private Sub buttonSaveChanges_Click() Handles buttonSaveChanges.Click
        Try
            If mDataSet.HasChanges Then
                mDataAdapter.Update(mDataSet)
                mDataSet.AcceptChanges()
            End If
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al actualizar los datos.")
        End Try
    End Sub

    Private Sub formDBBrowse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If mConnection.State = ConnectionState.Open Then
            mConnection.Close()
        End If
        mConnection.Dispose()
        mConnection = Nothing
        If Not mDataAdapter Is Nothing Then
            mDataAdapter.Dispose()
        End If
        mDataAdapter = Nothing
        mDataSet.Dispose()
        mDataSet = Nothing
    End Sub

    Private Sub datagridviewData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles datagridviewData.DataError
        e.ThrowException = False
    End Sub
End Class