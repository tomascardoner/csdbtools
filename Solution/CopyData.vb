Module CopyData

    Private SYSTEM_TABLES_PREFIX() As String = {"MSys"}
    Private REPLICATION_FIELDS() As String = {"Gen_Notas", "s_GUID", "Aen_Notas", "s_ColLineage", "s_Generation", "s_Lineage"}
    Private COLUMN_PROPERTIES_EXCLUDE() As String = {"Nullable", "Fixed Length", "Seed", "Increment"}

    Private Const TABLE_TYPE_TABLE As String = "TABLE"
    Private Const TABLE_TYPE_QUERY As String = "VIEW"
    Private Const TABLE_TYPE_ACCESS_TABLE As String = "ACCESS TABLE"
    Private Const TABLE_TYPE_SYSTEM_TABLE As String = "SYSTEM TABLE"

    Friend Function CopyDatabase(ByVal SourceDB As String, ByVal DestinationDB As String, ByVal IgnoreReplicationObjects As Boolean, ByVal IgnoreHiddenObjects As Boolean, ByVal IgnoreSystemObjects As Boolean, ByVal OptionCreateTables As Boolean, ByVal OptionCopyKeys As Boolean, ByVal OptionCopyIndexes As Boolean, ByVal OptionCopyData As Boolean, ByVal OptionCopyForeignKeys As Boolean) As Boolean
        Dim ErrorMessage As String = ""
        Dim StringToSearch As String
        Dim IgnoreTable As Boolean
        Dim OperationCompleted As Boolean

        Dim SourceConnectionADODB As ADODB.Connection
        Dim SourceConnectionOLEDB As OleDb.OleDbConnection
        Dim SourceCatalog As ADOX.Catalog
        Dim SourceTable As ADOX.Table

        Dim DestinationConnectionADODB As ADODB.Connection
        Dim DestinationConnectionOLEDB As OleDb.OleDbConnection
        Dim DestinationCatalog As ADOX.Catalog
        Dim DestinationTable As ADOX.Table

        Dim PropertyIndex As Integer

        '//// OPEN THE DATABASES ////
        Try
            ErrorMessage = "Error opening Source database."
            SourceConnectionADODB = New ADODB.Connection()
            SourceConnectionADODB.Open(SourceDB)
            SourceConnectionOLEDB = New OleDb.OleDbConnection(SourceDB)
            SourceCatalog = New ADOX.Catalog
            SourceCatalog.ActiveConnection = SourceConnectionADODB

            ErrorMessage = "Error opening Destination database."
            DestinationConnectionADODB = New ADODB.Connection()
            DestinationConnectionADODB.Open(DestinationDB)
            DestinationConnectionOLEDB = New OleDb.OleDbConnection(DestinationDB)
            DestinationCatalog = New ADOX.Catalog
            DestinationCatalog.ActiveConnection = DestinationConnectionADODB

        Catch ex As Exception
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        '//// ITERATE THROUGH EVERY TABLE TO COPY COLUMNS, KEYS ANDS INDEXES ////
        Try
            formCopy_Options.progressbarStatus.Maximum = SourceCatalog.Tables.Count

            For Each SourceTable In SourceCatalog.Tables()
                formCopy_Options.progressbarStatus.Value = formCopy_Options.progressbarStatus.Value + 1
                If SourceTable.Type = TABLE_TYPE_TABLE Then
                    ErrorMessage = String.Format("Error opening table '{0}'", SourceTable.Name)
                    formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Opening source..."

                    IgnoreTable = False
                    If IgnoreSystemObjects Then
                        For Each StringToSearch In SYSTEM_TABLES_PREFIX
                            If SourceTable.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                                IgnoreTable = True
                                Exit For
                            End If
                        Next StringToSearch
                    End If

                    If Not IgnoreTable Then
                        If OptionCreateTables Then
                            DestinationTable = New ADOX.Table()

                            'CREATE TABLE AND COPY PROPERTIES
                            With DestinationTable
                                formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Creating table..."
                                .Name = SourceTable.Name
                                Debug.Print("- TABLE: " & .Name)
                                .ParentCatalog = DestinationCatalog
                                For PropertyIndex = 0 To SourceTable.Properties.Count - 1
                                    '.Properties(PropertyIndex).Value = SourceTable.Properties(PropertyIndex).Value
                                Next PropertyIndex
                            End With

                            'CREATE COLUMNS AND COPY PROPERTIES
                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Creating columns..."
                            If Not CopyColumns(SourceConnectionADODB, SourceTable, DestinationCatalog, DestinationTable, IgnoreReplicationObjects) Then
                                Exit For
                            End If
                        Else
                            DestinationTable = DestinationCatalog.Tables(SourceTable.Name)
                        End If

                        'CREATE KEYS AND COPY PROPERTIES
                        If OptionCopyKeys Then
                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Creating keys..."
                            If Not CopyKeys(SourceConnectionADODB, SourceTable, DestinationCatalog, DestinationTable, IgnoreReplicationObjects) Then
                                Exit For
                            End If
                        End If

                        'CREATE INDEXES AND COPY PROPERTIES
                        If OptionCopyIndexes Then
                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Creating indexes..."
                            If Not CopyIndexes(SourceConnectionADODB, SourceTable, DestinationCatalog, DestinationTable, IgnoreReplicationObjects) Then
                                Exit For
                            End If
                        End If

                        'ADD THE TABLE TO THE DATABASE
                        If OptionCreateTables Then
                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Adding table to database..."
                            DestinationCatalog.Tables.Append(DestinationTable)
                        End If

                        'COPY DATA
                        If OptionCopyData Then
                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Copying data..."
                            If Not CopyData(SourceConnectionOLEDB, DestinationConnectionADODB, DestinationConnectionOLEDB, SourceTable.Name) Then
                                Exit For
                            End If
                        End If
                    End If
                End If

                OperationCompleted = True
            Next SourceTable

            If Not OperationCompleted Then
                SourceTable = Nothing
                SourceCatalog = Nothing
                SourceConnectionOLEDB.Close()
                SourceConnectionOLEDB = Nothing
                SourceConnectionADODB.Close()
                SourceConnectionADODB = Nothing

                DestinationTable = Nothing
                DestinationCatalog = Nothing
                DestinationConnectionOLEDB.Close()
                DestinationConnectionOLEDB = Nothing
                DestinationConnectionADODB.Close()
                DestinationConnectionADODB = Nothing

                Return False
            End If

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        '//// ITERATE EVERY TABLE TO COPY FOREIGN KEYS ////
        If OptionCopyForeignKeys Then
            Try
                OperationCompleted = False

                For Each SourceTable In SourceCatalog.Tables()
                    If SourceTable.Type = TABLE_TYPE_TABLE Then
                        ErrorMessage = String.Format("Error opening table '{0}'", SourceTable.Name)

                        IgnoreTable = False
                        If IgnoreSystemObjects Then
                            For Each StringToSearch In SYSTEM_TABLES_PREFIX
                                If SourceTable.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                                    IgnoreTable = True
                                    Exit For
                                End If
                            Next StringToSearch
                        End If

                        If Not IgnoreTable Then
                            DestinationTable = DestinationCatalog.Tables(SourceTable.Name)
                            Debug.Print("- TABLE: " & DestinationTable.Name)

                            formCopy_Options.labelStatus.Text = "TABLE '" & SourceTable.Name & "': Creating foreign keys..."
                            If Not CopyForeignKeys(SourceConnectionADODB, SourceTable, DestinationCatalog, DestinationTable, IgnoreReplicationObjects) Then
                                SourceTable = Nothing
                                SourceCatalog = Nothing
                                SourceConnectionOLEDB.Close()
                                SourceConnectionOLEDB = Nothing
                                SourceConnectionADODB.Close()
                                SourceConnectionADODB = Nothing

                                DestinationTable = Nothing
                                DestinationCatalog = Nothing
                                DestinationConnectionOLEDB.Close()
                                DestinationConnectionOLEDB = Nothing
                                DestinationConnectionADODB.Close()
                                DestinationConnectionADODB = Nothing
                                Return False
                            End If
                        End If
                    End If

                    OperationCompleted = True
                Next SourceTable

                If Not OperationCompleted Then
                    SourceTable = Nothing
                    SourceCatalog = Nothing
                    SourceConnectionOLEDB.Close()
                    SourceConnectionOLEDB = Nothing
                    SourceConnectionADODB.Close()
                    SourceConnectionADODB = Nothing

                    DestinationTable = Nothing
                    DestinationCatalog = Nothing
                    DestinationConnectionOLEDB.Close()
                    DestinationConnectionOLEDB = Nothing
                    DestinationConnectionADODB.Close()
                    DestinationConnectionADODB = Nothing

                    Return False
                End If

            Catch ex As Exception
                CS_Error.ProcessError(ex, ErrorMessage)
                SourceCatalog = Nothing
                SourceConnectionOLEDB.Close()
                SourceConnectionOLEDB = Nothing
                SourceConnectionADODB.Close()
                SourceConnectionADODB = Nothing

                DestinationCatalog = Nothing
                DestinationConnectionOLEDB.Close()
                DestinationConnectionOLEDB = Nothing
                DestinationConnectionADODB.Close()
                DestinationConnectionADODB = Nothing
                Return False
            End Try
        End If

        Return True
    End Function

    Private Function CopyColumns(ByRef SourceConnection As ADODB.Connection, ByRef SourceTable As ADOX.Table, ByRef DestinationCatalog As ADOX.Catalog, ByRef DestinationTable As ADOX.Table, ByVal IgnoreReplicationObjects As Boolean) As Boolean
        Dim ErrorMessage As String = ""
        Dim StringToSearch As String
        Dim IgnoreColumn As Boolean
        Dim IgnoreProperty As Boolean

        Dim SourceTableRecordset As ADODB.Recordset
        Dim SourceField As ADODB.Field
        Dim SourceColumn As ADOX.Column
        Dim DestinationColumn As ADOX.Column

        Dim PropertyIndex As Integer

        Try
            SourceTableRecordset = New ADODB.Recordset
            SourceTableRecordset.Open(SourceTable.Name, SourceConnection, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdTable)

            For Each SourceField In SourceTableRecordset.Fields
                SourceColumn = SourceTable.Columns(SourceField.Name)
                ErrorMessage = String.Format("Error copying column '{0}' from table '{1}'.", SourceColumn.Name, SourceTable.Name)

                IgnoreColumn = False
                If IgnoreReplicationObjects Then
                    For Each StringToSearch In REPLICATION_FIELDS
                        If SourceColumn.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                            IgnoreColumn = True
                            Exit For
                        End If
                    Next StringToSearch
                End If

                If Not IgnoreColumn Then
                    DestinationColumn = New ADOX.Column()

                    With DestinationColumn
                        .Name = SourceColumn.Name
                        Debug.Print("     - COLUMN: " & .Name)
                        .Type = SourceColumn.Type
                        .DefinedSize = SourceColumn.DefinedSize
                        .NumericScale = SourceColumn.NumericScale
                        .Precision = SourceColumn.Precision
                        '.Attributes = SourceColumn.Attributes
                        .ParentCatalog = DestinationCatalog

                        DestinationTable.Columns.Append(DestinationColumn)
                        For PropertyIndex = 0 To SourceColumn.Properties.Count - 1
                            IgnoreProperty = False
                            For Each StringToSearch In COLUMN_PROPERTIES_EXCLUDE
                                If SourceColumn.Properties(PropertyIndex).Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                                    IgnoreProperty = True
                                    Exit For
                                End If
                            Next StringToSearch

                            If Not IgnoreProperty Then
                                .Properties(PropertyIndex).Value = SourceColumn.Properties(PropertyIndex).Value
                                Debug.Print("         - PROPERTY: " & .Properties(PropertyIndex).Name & " - Value: " & .Properties(PropertyIndex).Value)
                            End If
                        Next PropertyIndex
                    End With
                End If
            Next SourceField

            SourceColumn = Nothing
            SourceField = Nothing
            SourceTableRecordset.Close()
            SourceTableRecordset = Nothing

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        Return True
    End Function

    Private Function CopyKeys(ByRef SourceConnection As ADODB.Connection, ByRef SourceTable As ADOX.Table, ByRef DestinationCatalog As ADOX.Catalog, ByRef DestinationTable As ADOX.Table, ByVal IgnoreReplicationObjects As Boolean) As Boolean
        Dim ErrorMessage As String = ""
        Dim IgnoreKey As Boolean

        Dim SourceKey As ADOX.Key
        Dim DestinationKey As ADOX.Key
        Dim ColumnIndex As Integer

        Try
            For Each SourceKey In SourceTable.Keys
                If SourceKey.Type <> ADOX.KeyTypeEnum.adKeyForeign Then
                    ErrorMessage = String.Format("Error copying key '{0}' from table '{1}'.", SourceKey.Name, SourceTable.Name)

                    IgnoreKey = False
                    If IgnoreReplicationObjects Then
                        For Each StringToSearch In REPLICATION_FIELDS
                            If SourceKey.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                                IgnoreKey = True
                                Exit For
                            End If
                        Next StringToSearch
                    End If

                    If Not IgnoreKey Then
                        DestinationKey = New ADOX.Key()

                        With DestinationKey
                            .Name = SourceKey.Name
                            Debug.Print("     - KEY: " & .Name)
                            .Type = SourceKey.Type
                            .RelatedTable = SourceKey.RelatedTable
                            .UpdateRule = SourceKey.UpdateRule
                            .DeleteRule = SourceKey.DeleteRule
                            For ColumnIndex = 0 To SourceKey.Columns.Count - 1
                                .Columns.Append(SourceKey.Columns(ColumnIndex).Name)
                                Debug.Print("         - COLUMN: " & SourceKey.Columns(ColumnIndex).Name)
                            Next ColumnIndex
                        End With

                        DestinationTable.Keys.Append(DestinationKey)
                    End If
                End If
            Next SourceKey

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        Return True
    End Function

    Private Function CopyIndexes(ByRef SourceConnection As ADODB.Connection, ByRef SourceTable As ADOX.Table, ByRef DestinationCatalog As ADOX.Catalog, ByRef DestinationTable As ADOX.Table, ByVal IgnoreReplicationObjects As Boolean) As Boolean
        Dim ErrorMessage As String = ""
        Dim IgnoreIndex As Boolean

        Dim SourceIndex As ADOX.Index
        Dim DestinationIndex As ADOX.Index
        Dim ColumnIndex As Integer

        Try
            For Each SourceIndex In SourceTable.Indexes
                ErrorMessage = String.Format("Error copying Index '{0}' from table '{1}'.", SourceIndex.Name, SourceTable.Name)

                IgnoreIndex = False
                If IgnoreReplicationObjects Then
                    For Each StringToSearch In REPLICATION_FIELDS
                        If SourceIndex.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                            IgnoreIndex = True
                            Exit For
                        End If
                    Next StringToSearch
                End If

                If Not IgnoreIndex Then
                    For Each Key As ADOX.Key In SourceTable.Keys
                        If Key.Name = SourceIndex.Name Then
                            IgnoreIndex = True
                            Exit For
                        End If
                    Next Key

                    If Not IgnoreIndex Then
                        DestinationIndex = New ADOX.Index()

                        With DestinationIndex
                            .Name = SourceIndex.Name
                            Debug.Print("     - KEY: " & .Name)
                            .PrimaryKey = SourceIndex.PrimaryKey
                            .Unique = SourceIndex.Unique
                            .IndexNulls = SourceIndex.IndexNulls
                            .Clustered = SourceIndex.Clustered
                            For ColumnIndex = 0 To SourceIndex.Columns.Count - 1
                                .Columns.Append(SourceIndex.Columns(ColumnIndex).Name)
                                Debug.Print("         - COLUMN: " & SourceIndex.Columns(ColumnIndex).Name)
                            Next ColumnIndex
                        End With

                        DestinationTable.Indexes.Append(DestinationIndex)
                    End If
                End If
            Next SourceIndex

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        Return True
    End Function

    Private Function CopyData(ByRef SourceConnectionOLEDB As OleDb.OleDbConnection, ByRef DestinationConnectionADODB As ADODB.Connection, ByRef DestinationConnectionOLEDB As OleDb.OleDbConnection, ByVal TableName As String) As Boolean
        Dim ErrorMessage As String = ""

        Dim DestinationTableRecordset As ADODB.Recordset
        Dim DestinationField As ADODB.Field

        Dim FieldsCommaSeparated As String = ""
        Dim ParametersCommaSeparated As String = ""

        Dim SourceCommandText As String = ""
        Dim SourceCommand As OleDb.OleDbCommand

        Dim DestinationCommandText As String = ""
        Dim DestinationCommand As OleDb.OleDbCommand

        Dim DataAdapter As OleDb.OleDbDataAdapter
        Dim DataSet As System.Data.DataSet

        Try
            DestinationTableRecordset = New ADODB.Recordset
            DestinationTableRecordset.Open(TableName, DestinationConnectionADODB, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdTable)

            For Each DestinationField In DestinationTableRecordset.Fields
                FieldsCommaSeparated = FieldsCommaSeparated & IIf(FieldsCommaSeparated.Length = 0, "", ", ") & DestinationField.Name
                ParametersCommaSeparated = ParametersCommaSeparated & IIf(ParametersCommaSeparated.Length = 0, "", ", ") & "@" & DestinationField.Name
            Next DestinationField

            SourceCommandText = "SELECT " & FieldsCommaSeparated & " FROM " & TableName
            DestinationCommandText = "INSERT INTO " & TableName & " (" & FieldsCommaSeparated & ") VALUES (" & ParametersCommaSeparated & ")"

            SourceCommand = New OleDb.OleDbCommand(SourceCommandText, SourceConnectionOLEDB)

            DestinationCommand = New OleDb.OleDbCommand(DestinationCommandText, DestinationConnectionOLEDB)

            For Each DestinationField In DestinationTableRecordset.Fields
                DestinationCommand.Parameters.Add(New OleDb.OleDbParameter("@" & DestinationField.Name, DestinationField.Type, DestinationField.DefinedSize, DestinationField.Name))
            Next DestinationField

            DataAdapter = New OleDb.OleDbDataAdapter
            DataAdapter.AcceptChangesDuringFill = False
            DataAdapter.SelectCommand = SourceCommand
            DataAdapter.InsertCommand = DestinationCommand

            DataSet = New System.Data.DataSet
            DataAdapter.Fill(DataSet, TableName)
            DataAdapter.Update(DataSet, TableName)

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        Return True
    End Function

    Private Function CopyForeignKeys(ByRef SourceConnection As ADODB.Connection, ByRef SourceTable As ADOX.Table, ByRef DestinationCatalog As ADOX.Catalog, ByRef DestinationTable As ADOX.Table, ByVal IgnoreReplicationObjects As Boolean) As Boolean
        Dim ErrorMessage As String = ""
        Dim IgnoreKey As Boolean

        Dim SourceKey As ADOX.Key
        Dim DestinationKey As ADOX.Key

        Dim SourceColumn As ADOX.Column
        Dim DestinationColumn As ADOX.Column

        Try
            For Each SourceKey In SourceTable.Keys
                If SourceKey.Type = ADOX.KeyTypeEnum.adKeyForeign Then
                    ErrorMessage = String.Format("Error copying foreign key '{0}' from table '{1}'.", SourceKey.Name, SourceTable.Name)

                    IgnoreKey = False
                    If IgnoreReplicationObjects Then
                        For Each StringToSearch In REPLICATION_FIELDS
                            If SourceKey.Name.ToUpper.Contains(StringToSearch.ToUpper) Then
                                IgnoreKey = True
                                Exit For
                            End If
                        Next StringToSearch
                    End If

                    If Not IgnoreKey Then
                        DestinationKey = New ADOX.Key()

                        With DestinationKey
                            .Name = SourceKey.Name
                            Debug.Print("     - FOREIGN KEY: " & .Name)
                            .Type = SourceKey.Type
                            .RelatedTable = SourceKey.RelatedTable
                            .UpdateRule = SourceKey.UpdateRule
                            .DeleteRule = SourceKey.DeleteRule
                            For Each SourceColumn In SourceKey.Columns
                                DestinationColumn = New ADOX.Column
                                DestinationColumn.Name = SourceColumn.Name
                                DestinationColumn.RelatedColumn = SourceColumn.RelatedColumn
                                .Columns.Append(DestinationColumn)
                                Debug.Print("         - COLUMN: " & DestinationColumn.Name)
                            Next SourceColumn
                        End With

                        DestinationTable.Keys.Append(DestinationKey)
                    End If
                End If
            Next SourceKey

        Catch ex As Exception When Not CS_Instance.IsRunningUnderIDE
            CS_Error.ProcessError(ex, ErrorMessage)
            Return False
        End Try

        Return True
    End Function
End Module
