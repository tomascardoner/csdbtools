Module CompareData

    Friend Sub CompareTables(ByVal ConnectionString1 As String, ByVal ConnectionString2 As String, ByRef listTables As List(Of String), ByVal VerificationModeAll As Boolean, ByVal MaximumDifferences As Byte)
        Dim ErrorMessage As String = String.Empty
        Dim datatablePrimaryKeys1 As DataTable
        Dim datatablePrimaryKeys2 As DataTable

        Cursor.Current = Cursors.WaitCursor

        Try
            ' DATABASE 1 CONNECT
            ErrorMessage = "Error connecting to Database 1."
            Dim connectionDatabase1 = New OleDb.OleDbConnection With {
                .ConnectionString = ConnectionString1
            }
            connectionDatabase1.Open()

            ' DATABASE 2 CONNECT
            ErrorMessage = "Error connecting to Database 2."
            Dim connectionDatabase2 = New OleDb.OleDbConnection With {
                .ConnectionString = ConnectionString2
            }
            connectionDatabase2.Open()

            ' GETTING DATABASE 1 KEYS
            datatablePrimaryKeys1 = connectionDatabase1.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Primary_Keys, New Object() {Nothing, TABLE_SCHEMA, Nothing})

            ' GETTING DATABASE 2 KEYS
            datatablePrimaryKeys2 = connectionDatabase2.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Primary_Keys, New Object() {Nothing, TABLE_SCHEMA, Nothing})

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

    'Friend Sub PrimaryKeys(ByRef connectionDatabase As OleDb.OleDbConnection)
    '    mdatatablePrimaryKeys = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Primary_Keys, New Object() {Nothing, TABLE_SCHEMA, Nothing})

    '    For Each datarowPrimaryKey As DataRow In mdatatablePrimaryKeys.Rows
    '        If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowPrimaryKey(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
    '            treenodeTable = treenodeFolderTables.Nodes(datarowPrimaryKey(DATAROW_COLUMN_TABLE_NAME).ToString)
    '            treenodeFolderColumns = treenodeTable.Nodes(TREENODE_FOLDER_COLUMNS)
    '            treenodeColumn = treenodeFolderColumns.Nodes(datarowPrimaryKey(DATAROW_COLUMN_COLUMN_NAME).ToString)
    '        End If
    '    Next
    'End Sub

End Module
