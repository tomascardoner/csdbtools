Module CompareStructure

#Region "Declarations"
    'SCHEMA FOR DATABASE 1
    Private mdatatableTables1 As DataTable
    Private mdatatableViews1 As DataTable
    Private mdatatableColumns1 As DataTable
    Private mdatatablePrimaryKeys1 As DataTable
    Private mdatatableTableConstraints1 As DataTable
    Private mdatatableIndexes1 As DataTable

    'SCHEMA FOR DATABASE 2
    Private mdatatableTables2 As DataTable
    Private mdatatableViews2 As DataTable
    Private mdatatableColumns2 As DataTable
    Private mdatatablePrimaryKeys2 As DataTable
    Private mdatatableTableConstraints2 As DataTable
    Private mdatatableIndexes2 As DataTable

    'EXCLUSIONS: Use Pipe char (|) at start and end of every table name
    Friend Const EXCLUSION_TABLE_NAME As String = "|sysdiagrams|dtproperties|"
    Private Const EXCLUSION_TABLE_PROPERTY_NAME As String = "|DATE_CREATED|"
    Private Const EXCLUSION_COLUMN_NAME As String = "||"
    Private Const EXCLUSION_COLUMN_PROPERTY_NAME As String = "|CATALOG|DOMAIN_CATALOG|"
    Private Const EXCLUSION_PRIMARYKEY_PROPERTY_NAME As String = "||"
    Private Const EXCLUSION_TABLE_CONSTRAINT_NAME As String = "||"
    Private Const EXCLUSION_TABLE_CONSTRAINT_PROPERTY_NAME As String = "|TABLE_CATALOG|"
    Private Const EXCLUSION_INDEX_NAME As String = "||"
    Private Const EXCLUSION_INDEX_PROPERTY_NAME As String = "|INDEX_CATALOG|PAGES|CARDINALITY|FILL_FACTOR|"

    Friend Const TABLE_SCHEMA As String = "dbo"
    Friend Const TABLE_TYPE As String = "TABLE"
    Friend Const VIEW_TYPE As String = "VIEW"

    'FOLDERS NAMES
    Private Const TREENODE_FOLDER_TABLES As String = "Tables"
    Private Const TREENODE_FOLDER_PROGRAMMABILITY As String = "Programmability"
    Private Const TREENODE_FOLDER_COLUMNS As String = "Columns"
    Private Const TREENODE_FOLDER_KEYS As String = "Keys"
    Private Const TREENODE_FOLDER_CONSTRAINTS As String = "Constraints"
    Private Const TREENODE_FOLDER_INDEXES As String = "Indexes"
    Private Const TREENODE_FOLDER_FOREIGNKEYS As String = "Foreign Keys"
    Private Const TREENODE_FOLDER_STOREDPROCEDURES As String = "Stored Procedures"
    Private Const TREENODE_FOLDER_FUNCTIONS As String = "Functions"

    Private Const TREENODE_KEY_REPORT As String = "NOTFOUND"

    'ICONS
    Private Const ICON_NAME_DATABASE As String = "Database"
    Private Const ICON_NAME_FOLDER As String = "Folder"
    Private Const ICON_NAME_TABLE As String = "Table"
    Private Const ICON_NAME_TABLE_DIFFERENT As String = "Table - Different"
    Private Const ICON_NAME_TABLE_MISSING As String = "Table - Missing"
    Private Const ICON_NAME_COLUMN As String = "Column"
    Private Const ICON_NAME_COLUMN_DIFFERENT As String = "Column - Different"
    Private Const ICON_NAME_COLUMN_MISSING As String = "Column - Missing"
    Private Const ICON_NAME_PRIMARYKEY As String = "PrimaryKey"
    Private Const ICON_NAME_PRIMARYKEY_DIFFERENT As String = "PrimaryKey - Different"
    Private Const ICON_NAME_PRIMARYKEY_MISSING As String = "PrimaryKey - Missing"
    Private Const ICON_NAME_FOREIGNKEY As String = "ForeignKey"
    Private Const ICON_NAME_FOREIGNKEY_DIFFERENT As String = "ForeignKey - Different"
    Private Const ICON_NAME_FOREIGNKEY_MISSING As String = "ForeignKey - Missing"
    Private Const ICON_NAME_ALTERNATEKEY As String = "AlternateKey"
    Private Const ICON_NAME_ALTERNATEKEY_DIFFERENT As String = "AlternateKey - Different"
    Private Const ICON_NAME_ALTERNATEKEY_MISSING As String = "AlternateKey - Missing"
    Private Const ICON_NAME_CHECK As String = "Check"
    Private Const ICON_NAME_CHECK_DIFFERENT As String = "Check - Different"
    Private Const ICON_NAME_CHECK_MISSING As String = "Check - Missing"
    Private Const ICON_NAME_INDEX As String = "Index"
    Private Const ICON_NAME_INDEX_CLUSTERED As String = "Index - Clustered"
    Private Const ICON_NAME_INDEX_DIFFERENT As String = "Index - Different"
    Private Const ICON_NAME_INDEX_MISSING As String = "Index - Missing"
    Private Const ICON_NAME_REPORT As String = "Report"

    'COLUMNS NAMES
    Friend Const DATAROW_COLUMN_TABLE_NAME As String = "TABLE_NAME"
    Private Const DATAROW_COLUMN_COLUMN_NAME As String = "COLUMN_NAME"
    Private Const DATAROW_COLUMN_CONSTRAINT_NAME As String = "CONSTRAINT_NAME"
    Private Const DATAROW_COLUMN_CONSTRAINT_TYPE As String = "CONSTRAINT_TYPE"
    Private Const DATAROW_COLUMN_INDEX_NAME As String = "INDEX_NAME"
    Private Const DATAROW_COLUMN_INDEX_UNIQUE As String = "UNIQUE"
    Private Const DATAROW_COLUMN_INDEX_CLUSTERED As String = "CLUSTERED"

    'PROPERTIES NAMES
    Private Const COLUMN_PROPERTY_ORDINAL_POSITION As String = "ORDINAL_POSITION"

    'STRINGS
    Private Const STRING_TABLE_MISSING As String = "Table doesn't exists in Database {0}."
    Private Const STRING_COLUMN_MISSING As String = "Column doesn't exists in Database {0}."
    Private Const STRING_PRIMARYKEY_MISSING As String = "Primary Key doesn't exists in Database {0}."
    Private Const STRING_KEY_MISSING As String = "Key doesn't exists in Database {0}."
    Private Const STRING_CONSTRAINT_MISSING As String = "Constraint doesn't exists in Database {0}."
    Private Const STRING_INDEX_MISSING As String = "Index doesn't exists in Database {0}."
    Private Const STRING_PROPERTY_DIFFERENT As String = "Property {0} differs. Database1: {1} ◄ ▐▌ ► Database2: {2}"

#End Region

#Region "Read Schema"
    Friend Sub GetDatabaseSchema(ByVal IsDatabase1 As Boolean, ByRef treeviewDatabase As TreeView, ByRef connectionDatabase As OleDb.OleDbConnection)
        Dim treenodeFolderTables As TreeNode

        'PREPARE TREEVIEW
        treeviewDatabase.BeginUpdate()
        treeviewDatabase.Nodes.Clear()

        treenodeFolderTables = treeviewDatabase.Nodes.Add(TREENODE_FOLDER_TABLES, TREENODE_FOLDER_TABLES, ICON_NAME_FOLDER, ICON_NAME_FOLDER)

        If IsDatabase1 Then
            GetTables(mdatatableTables1, treenodeFolderTables, connectionDatabase)
            GetViews(mdatatableViews1, treenodeFolderTables, connectionDatabase)
            GetColumns(mdatatableColumns1, treenodeFolderTables, connectionDatabase)
            GetPrimaryKeys(mdatatablePrimaryKeys1, treenodeFolderTables, connectionDatabase)
            GetTableContraints(mdatatableTableConstraints1, treenodeFolderTables, connectionDatabase)
            GetIndexes(mdatatableIndexes1, treenodeFolderTables, connectionDatabase)
        Else
            GetTables(mdatatableTables2, treenodeFolderTables, connectionDatabase)
            GetViews(mdatatableViews2, treenodeFolderTables, connectionDatabase)
            GetColumns(mdatatableColumns2, treenodeFolderTables, connectionDatabase)
            GetPrimaryKeys(mdatatablePrimaryKeys2, treenodeFolderTables, connectionDatabase)
            GetTableContraints(mdatatableTableConstraints2, treenodeFolderTables, connectionDatabase)
            GetIndexes(mdatatableIndexes2, treenodeFolderTables, connectionDatabase)
        End If

        treeviewDatabase.EndUpdate()
    End Sub

    Friend Sub GetTables(ByRef datatableTables As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableTables = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, TABLE_SCHEMA, Nothing, TABLE_TYPE})
        For Each datarowTable As DataRow In datatableTables.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowTable(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                CreateNodeTable(treenodeFolderTables, datarowTable(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE, True)
            End If
        Next
    End Sub

    Friend Sub GetViews(ByRef datatableViews As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableViews = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, TABLE_SCHEMA, Nothing, VIEW_TYPE})
        For Each datarowTable As DataRow In datatableViews.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowTable(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                CreateNodeTable(treenodeFolderTables, datarowTable(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE, True)
            End If
        Next
    End Sub

    Friend Sub GetColumns(ByRef datatableColumns As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        Dim treenodeTable As TreeNode

        datatableColumns = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, TABLE_SCHEMA, Nothing, Nothing})

        For Each datarowColumn As DataRow In datatableColumns.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowColumn(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                treenodeTable = treenodeFolderTables.Nodes(datarowColumn(DATAROW_COLUMN_TABLE_NAME).ToString)
                CreateNodeColumn(treenodeTable.Nodes(TREENODE_FOLDER_COLUMNS), datarowColumn, ICON_NAME_COLUMN)
            End If
        Next
    End Sub

    Private Function GetDataTypeNameComplete_SQLServer(ByVal datarowColumnSchema As DataRow) As String
        Select Case CInt(datarowColumnSchema("DATA_TYPE"))
            Case 2
                GetDataTypeNameComplete_SQLServer = "smallint"
            Case 3
                GetDataTypeNameComplete_SQLServer = "int"
            Case 4
                GetDataTypeNameComplete_SQLServer = "real"
            Case 5
                GetDataTypeNameComplete_SQLServer = "float"
            Case 6
                GetDataTypeNameComplete_SQLServer = "smallmoney"
            Case 11
                GetDataTypeNameComplete_SQLServer = "bit"
            Case 17
                GetDataTypeNameComplete_SQLServer = "tinyint"
            Case 128
                GetDataTypeNameComplete_SQLServer = "image"
            Case 129
                GetDataTypeNameComplete_SQLServer = "varchar(" & datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH").ToString & ")"
            Case 130
                GetDataTypeNameComplete_SQLServer = "nvarchar"
            Case 131
                GetDataTypeNameComplete_SQLServer = "decimal(" & datarowColumnSchema("NUMERIC_PRECISION").ToString & "," & datarowColumnSchema("NUMERIC_SCALE").ToString & ")"
            Case 133
                GetDataTypeNameComplete_SQLServer = "date"
            Case 135
                GetDataTypeNameComplete_SQLServer = "smalldatetime"
            Case Else
                GetDataTypeNameComplete_SQLServer = CInt(datarowColumnSchema("DATA_TYPE"))
                Stop
        End Select
        GetDataTypeNameComplete_SQLServer = GetDataTypeNameComplete_SQLServer & ", " & IIf(datarowColumnSchema("IS_NULLABLE"), "null", "not null")
    End Function

    Private Function GetDataTypeNameComplete_Access(ByVal datarowColumnSchema As DataRow) As String
        GetDataTypeNameComplete_Access = ""
        Select Case CInt(datarowColumnSchema("DATA_TYPE"))
            Case 2
                GetDataTypeNameComplete_Access = "Integer"
            Case 3
                If datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH") Is Convert.DBNull Then
                    Select Case datarowColumnSchema("COLUMN_FLAGS")
                        Case 122
                            GetDataTypeNameComplete_Access = "Long"
                        Case 90
                            GetDataTypeNameComplete_Access = "Autonumber"
                        Case Else
                            GetDataTypeNameComplete_Access = "Long"
                    End Select
                End If
            Case 4
                GetDataTypeNameComplete_Access = "Single"
            Case 5
                GetDataTypeNameComplete_Access = "Double"
            Case 6
                GetDataTypeNameComplete_Access = "Money"
            Case 7
                GetDataTypeNameComplete_Access = "Byte"
            Case 11
                GetDataTypeNameComplete_Access = "Yes/No"
            Case 72
                GetDataTypeNameComplete_Access = "Byte"
            Case 128
                Select Case datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH")
                    Case 0
                        GetDataTypeNameComplete_Access = "OLE Object"
                    Case -1
                        GetDataTypeNameComplete_Access = "Memo"
                    Case Else
                        GetDataTypeNameComplete_Access = "varchar(" & datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH").ToString & ")"
                End Select
            Case 130
                Select Case datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH")
                    Case 0, -1
                        GetDataTypeNameComplete_Access = "Memo"
                    Case Else
                        GetDataTypeNameComplete_Access = "varchar(" & datarowColumnSchema("CHARACTER_MAXIMUM_LENGTH").ToString & ")"
                End Select
            Case 131
                GetDataTypeNameComplete_Access = "Decimal(" & datarowColumnSchema("NUMERIC_PRECISION") & "," & datarowColumnSchema("NUMERIC_SCALE") & ")"
            Case Else
                GetDataTypeNameComplete_Access = CInt(datarowColumnSchema("DATA_TYPE"))
                Stop
        End Select
        GetDataTypeNameComplete_Access = GetDataTypeNameComplete_Access & ", " & IIf(datarowColumnSchema("IS_NULLABLE"), "null", "not null")
    End Function

    Friend Sub GetPrimaryKeys(ByRef datatablePrimaryKeys As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatablePrimaryKeys = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Primary_Keys, New Object() {Nothing, TABLE_SCHEMA, Nothing})

        Dim treenodeTable As TreeNode
        Dim treenodeFolderColumns As TreeNode
        Dim treenodeColumn As TreeNode

        For Each datarowPrimaryKey As DataRow In datatablePrimaryKeys.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowPrimaryKey(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                treenodeTable = treenodeFolderTables.Nodes(datarowPrimaryKey(DATAROW_COLUMN_TABLE_NAME).ToString)
                treenodeFolderColumns = treenodeTable.Nodes(TREENODE_FOLDER_COLUMNS)
                treenodeColumn = treenodeFolderColumns.Nodes(datarowPrimaryKey(DATAROW_COLUMN_COLUMN_NAME).ToString)
                treenodeColumn.ImageKey = ICON_NAME_PRIMARYKEY
            End If
        Next
    End Sub

    Friend Sub GetTableContraints(ByRef datatableTableConstraints As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableTableConstraints = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Table_Constraints, New Object() {Nothing, Nothing, Nothing, Nothing, TABLE_SCHEMA, Nothing})

        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeTableConstraint As TreeNode

        For Each datarowTableConstraint As DataRow In datatableTableConstraints.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowTableConstraint(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                treenodeTable = treenodeFolderTables.Nodes(datarowTableConstraint(DATAROW_COLUMN_TABLE_NAME).ToString)
                If datarowTableConstraint(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                    treenodeFolder = treenodeTable.Nodes(TREENODE_FOLDER_KEYS)
                Else
                    treenodeFolder = treenodeTable.Nodes(TREENODE_FOLDER_CONSTRAINTS)
                End If
                treenodeTableConstraint = CreateNodeTableConstraint(treenodeFolder, datarowTableConstraint, ICON_NAME_ALTERNATEKEY, ICON_NAME_PRIMARYKEY, ICON_NAME_FOREIGNKEY, ICON_NAME_CHECK)
            End If
        Next
    End Sub

    Friend Sub GetIndexes(ByRef datatableIndexes As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableIndexes = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Indexes, New Object() {Nothing, TABLE_SCHEMA, Nothing, Nothing, Nothing})
        datatableIndexes.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME & ", " & DATAROW_COLUMN_INDEX_NAME

        Dim treenodeTable As TreeNode
        Dim treenodeFolderIndexes As TreeNode
        Dim treenodeIndex As TreeNode

        Dim IndexName As String = ""

        For Each datarowIndex As DataRow In datatableIndexes.DefaultView.ToTable.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                If IndexName <> datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString Then
                    IndexName = datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString

                    treenodeTable = treenodeFolderTables.Nodes(datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString)
                    treenodeFolderIndexes = treenodeTable.Nodes(TREENODE_FOLDER_INDEXES)
                    treenodeIndex = CreateNodeIndex(treenodeFolderIndexes, datarowIndex, ICON_NAME_INDEX_CLUSTERED, ICON_NAME_INDEX)
                End If
            End If
        Next
    End Sub

    Friend Sub GetForeignKeys(ByRef datatableForeignKeys As DataTable, ByRef treenodeFolderTables As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableForeignKeys = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Foreign_Keys, New Object() {Nothing, TABLE_SCHEMA, Nothing, Nothing, Nothing, Nothing})
        datatableForeignKeys.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME & ", " & DATAROW_COLUMN_INDEX_NAME

        Dim treenodeTable As TreeNode
        Dim treenodeFolderForeignKeys As TreeNode
        Dim treenodeForeignKey As TreeNode

        Dim IndexName As String = ""

        For Each datarowIndex As DataRow In datatableForeignKeys.DefaultView.ToTable.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                If IndexName <> datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString Then
                    IndexName = datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString

                    treenodeTable = treenodeFolderTables.Nodes(datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString)
                    treenodeFolderForeignKeys = treenodeTable.Nodes(TREENODE_FOLDER_INDEXES)
                    treenodeForeignKey = CreateNodeIndex(treenodeFolderForeignKeys, datarowIndex, ICON_NAME_INDEX_CLUSTERED, ICON_NAME_INDEX)
                End If
            End If
        Next
    End Sub

    Friend Sub GetProcedures(ByRef datatableProcedures As DataTable, ByRef treenodeFolderProgrammability As TreeNode, ByRef connectionDatabase As OleDb.OleDbConnection)
        datatableProcedures = connectionDatabase.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Procedures, New Object() {Nothing, TABLE_SCHEMA, Nothing, Nothing})
        datatableProcedures.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME & ", " & DATAROW_COLUMN_INDEX_NAME

        Dim treenodeFolderProcedures As TreeNode
        Dim treenodeTable As TreeNode

        Dim treenodeProcedure As TreeNode

        Dim IndexName As String = ""

        For Each datarowIndex As DataRow In datatableProcedures.DefaultView.ToTable.Rows
            If Not EXCLUSION_TABLE_NAME.Contains("|" & datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString & "|") Then
                If IndexName <> datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString Then
                    IndexName = datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString

                    treenodeTable = treenodeFolderProgrammability.Nodes(datarowIndex(DATAROW_COLUMN_TABLE_NAME).ToString)
                    treenodeFolderProcedures = treenodeTable.Nodes(TREENODE_FOLDER_INDEXES)
                    treenodeProcedure = CreateNodeIndex(treenodeFolderProcedures, datarowIndex, ICON_NAME_INDEX_CLUSTERED, ICON_NAME_INDEX)
                End If
            End If
        Next
    End Sub
#End Region

#Region "TreeView"
    Private Function CreateNodeTable(ByRef treenodeFolderTables As TreeNode, ByVal TableName As String, ByVal ImageKey As String, ByVal CreateFoldersNode As Boolean) As TreeNode
        Dim treenodeTable As TreeNode

        'If Table node doesn't exists, create it
        If treenodeFolderTables.Nodes.ContainsKey(TableName) Then
            treenodeTable = treenodeFolderTables.Nodes(TableName)
        Else
            treenodeTable = treenodeFolderTables.Nodes.Add(TableName, TableName, ImageKey, ImageKey)
        End If

        If CreateFoldersNode Then
            CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
            CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_KEYS, ICON_NAME_FOLDER)
            CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_CONSTRAINTS, ICON_NAME_FOLDER)
            CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_INDEXES, ICON_NAME_FOLDER)
        End If

        Return treenodeTable
    End Function

    Private Function CreateNodeTableSubFolder(ByRef treenodeTable As TreeNode, ByVal FolderName As String, ByVal ImageKey As String) As TreeNode
        Dim treenodeFolder As TreeNode

        'If node doesn't exists, create it
        If treenodeTable.Nodes.ContainsKey(FolderName) Then
            treenodeFolder = treenodeTable.Nodes(FolderName)
        Else
            treenodeFolder = treenodeTable.Nodes.Add(FolderName, FolderName, ImageKey, ImageKey)
        End If
        Return treenodeFolder
    End Function

    Private Function CreateNodeColumn(ByRef treenodeParent As TreeNode, ByVal ColumnName As String, ByVal ImageKey As String) As TreeNode
        Dim treenodeColumn As TreeNode

        'If Column node doesn't exists, create it
        If treenodeParent.Nodes.ContainsKey(ColumnName) Then
            treenodeColumn = treenodeParent.Nodes(ColumnName)
        Else
            treenodeColumn = treenodeParent.Nodes.Add(ColumnName, ColumnName, ImageKey, ImageKey)
        End If

        Return treenodeColumn
    End Function

    Private Function CreateNodeColumn(ByRef treenodeParent As TreeNode, ByRef datarowColumn As DataRow, ByVal ImageKey As String) As TreeNode
        Dim ColumnDisplayName As String
        Dim ColumnName As String
        Dim treenodeColumn As TreeNode

        ColumnName = datarowColumn(DATAROW_COLUMN_COLUMN_NAME).ToString
        ColumnDisplayName = ColumnName & " (" & GetDataTypeNameComplete_SQLServer(datarowColumn) & ")"

        treenodeColumn = CreateNodeColumn(treenodeParent, ColumnName, ImageKey)
        treenodeColumn.Text = ColumnDisplayName

        Return treenodeColumn
    End Function

    Private Function CreateNodeTableConstraint(ByRef treenodeParent As TreeNode, ByRef datarowTableConstraint As DataRow, ByVal ImageKeyUnique As String, ByVal ImageKeyPrimaryKey As String, ByVal ImageKeyForeign As String, ByVal ImageKeyCheck As String) As TreeNode
        Dim TableConstraintName As String

        TableConstraintName = datarowTableConstraint(DATAROW_COLUMN_CONSTRAINT_NAME).ToString

        Select Case datarowTableConstraint(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString
            Case "UNIQUE"
                Return treenodeParent.Nodes.Add(TableConstraintName, TableConstraintName, ImageKeyUnique, ImageKeyUnique)
            Case "PRIMARY KEY"
                Return treenodeParent.Nodes.Add(TableConstraintName, TableConstraintName, ImageKeyPrimaryKey, ImageKeyPrimaryKey)
            Case "FOREIGN KEY"
                Return treenodeParent.Nodes.Add(TableConstraintName, TableConstraintName, ImageKeyForeign, ImageKeyForeign)
            Case "CHECK"
                Return treenodeParent.Nodes.Add(TableConstraintName, TableConstraintName, ImageKeyCheck, ImageKeyCheck)
            Case Else
                Return treenodeParent.Nodes.Add(TableConstraintName, TableConstraintName)
        End Select
    End Function

    Private Function CreateNodeIndex(ByRef treenodeParent As TreeNode, ByRef datarowIndex As DataRow, ByVal ImageKeyIndexClustered As String, ByVal ImageKeyIndex As String) As TreeNode
        Dim IndexName As String

        IndexName = datarowIndex(DATAROW_COLUMN_INDEX_NAME).ToString

        If datarowIndex("CLUSTERED") Then
            Return treenodeParent.Nodes.Add(IndexName, IndexName & " (Clustered)", ImageKeyIndexClustered, ImageKeyIndexClustered)
        Else
            If datarowIndex("UNIQUE") Then
                Return treenodeParent.Nodes.Add(IndexName, IndexName & " (Unique, Non-Clustered)", ImageKeyIndex, ImageKeyIndex)
            Else
                Return treenodeParent.Nodes.Add(IndexName, IndexName & " (Non-Unique, Non-Clustered)", ImageKeyIndex, ImageKeyIndex)
            End If
        End If
    End Function
#End Region

#Region "Compare"
    Friend Sub CompareDatabases(ByRef treeviewDatabase1 As TreeView, ByRef treeviewDatabase2 As TreeView)
        Dim treenodeFolderTables1 As TreeNode
        Dim treenodeFolderTables2 As TreeNode
        Dim treenodeFolderTablesResult As TreeNode

        Cursor.Current = Cursors.WaitCursor

        formCompareStructure_Result.treeviewResults.ImageList = formMDIMain.imagelistDatabase
        formCompareStructure_Result.treeviewResults.BeginUpdate()

        'SORT DATA TABLES
        mdatatableTables1.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME
        mdatatableTables2.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME
        mdatatableViews1.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME
        mdatatableViews2.DefaultView.Sort = DATAROW_COLUMN_TABLE_NAME
        mdatatableColumns1.DefaultView.Sort = DATAROW_COLUMN_COLUMN_NAME
        mdatatableColumns2.DefaultView.Sort = DATAROW_COLUMN_COLUMN_NAME

        'CHECK TABLES AND VIEWS
        treenodeFolderTablesResult = formCompareStructure_Result.treeviewResults.Nodes.Add(TREENODE_FOLDER_TABLES, TREENODE_FOLDER_TABLES, ICON_NAME_FOLDER, ICON_NAME_FOLDER)
        treenodeFolderTables1 = treeviewDatabase1.Nodes(TREENODE_FOLDER_TABLES)
        treenodeFolderTables2 = treeviewDatabase2.Nodes(TREENODE_FOLDER_TABLES)

        'TABLES
        CompareTablesOrViews(treenodeFolderTablesResult, mdatatableTables1, mdatatableTables2)

        'VIEWS
        CompareTablesOrViews(treenodeFolderTablesResult, mdatatableViews1, mdatatableViews2)

        formCompareStructure_Result.treeviewResults.EndUpdate()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CompareTablesOrViews(ByRef treenodeFolderTablesResult As TreeNode, ByRef datatable1 As DataTable, ByRef datatable2 As DataTable)
        Dim datarowTable1 As DataRow = Nothing
        Dim datarowTable2 As DataRow = Nothing

        Dim treenodeTable As TreeNode

        Dim Table1Index As Integer = 0
        Dim Table1Count As Integer
        Dim Table2Index As Integer = 0
        Dim Table2Count As Integer

        Dim Table1Name As String = ""
        Dim Table2Name As String = ""

        Table1Count = datatable1.DefaultView.Count
        Table2Count = datatable2.DefaultView.Count

        Do While (Table1Index <= Table1Count - 1 Or Table2Index <= Table2Count - 1)
            If Table1Index <= Table1Count - 1 Then
                datarowTable1 = datatable1.DefaultView.Table.Rows(Table1Index)
                Table1Name = datarowTable1(DATAROW_COLUMN_TABLE_NAME).ToString
            Else
                Table1Name = StrDup(128, "Z")
            End If
            If Table2Index <= Table2Count - 1 Then
                datarowTable2 = datatable2.DefaultView.Table.Rows(Table2Index)
                Table2Name = datarowTable2(DATAROW_COLUMN_TABLE_NAME).ToString
            Else
                Table2Name = StrDup(128, "Z")
            End If

            If EXCLUSION_TABLE_NAME.Contains("|" & Table1Name & "|") Then
                Table1Index += 1
            ElseIf EXCLUSION_TABLE_NAME.Contains("|" & Table2Name & "|") Then
                Table2Index += 1
            Else
                Select Case Strings.StrComp(Table1Name, Table2Name, CompareMethod.Text)
                    Case -1
                        'LA TABLA O VISTA NO EXISTE EN LA BASE DE DATOS 2
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, Table1Name, ICON_NAME_TABLE_MISSING, False)
                        treenodeTable.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_TABLE_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Table1Index += 1
                    Case 0
                        'LA TABLA O VISTA EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS COLUMNAS, LOS PRIMARY KEYS Y LUEGO SIGO CON LA SIGUIENTE TABLA O VISTA
                        CompareTableOrViewProperties(treenodeFolderTablesResult, datarowTable1, datarowTable2)
                        CompareColumns(treenodeFolderTablesResult, Table1Name)
                        ComparePrimaryKeys(treenodeFolderTablesResult, Table1Name)
                        CompareTableConstraints(treenodeFolderTablesResult, Table1Name)
                        CompareIndexes(treenodeFolderTablesResult, Table1Name)
                        Table1Index += 1
                        Table2Index += 1
                    Case 1
                        'LA TABLA O VISTA NO EXISTE EN LA BASE DE DATOS 1
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, Table2Name, ICON_NAME_TABLE_MISSING, False)
                        treenodeTable.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_TABLE_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Table2Index += 1
                End Select
            End If
        Loop
    End Sub

    Private Sub CompareTableOrViewProperties(ByRef treenodeFolderTablesResult As TreeNode, ByRef datarowTable1 As DataRow, ByRef datarowTable2 As DataRow)
        Dim treenodeTable As TreeNode

        Dim TablePropertyIndex As Integer
        Dim TablePropertyCountMin As Integer

        Dim TableProperty1Name As String
        Dim TableProperty2Name As String
        Dim TableProperty1Value As String
        Dim TableProperty2Value As String

        'SUPONEMOS QUE AMBOS DATAROWS TIENEN LAS MISMAS PROPIEDADES
        'SI NO ES ASÍ, ES PORQUE USARON 2 PROVIDERS DISTINTOS
        'EN ESE CASO RECORRO TODAS LAS PROPIEDADES DEL QUE TIENE MENOS CANTIDAD
        'Y ADEMAS VERIFICO QUE COINCIDA EL NOMBRE DE LA PROPIEDAD, SI NO, LA IGNORO
        'QUEDA POR RESOLVER QUE PASA SI CAMBIA EL ORDEN DE LAS PROPIEDADES ENTRE DISTINTOS PROVIDERS (YA QUE LAS IGNORARÍA TODAS)
        TablePropertyCountMin = datarowTable1.ItemArray.Count
        If TablePropertyCountMin > datarowTable2.ItemArray.Count Then
            TablePropertyCountMin = datarowTable2.ItemArray.Count
        End If
        For TablePropertyIndex = 1 To TablePropertyCountMin - 1
            TableProperty1Name = mdatatableTables1.Columns(TablePropertyIndex).ColumnName
            TableProperty2Name = mdatatableTables2.Columns(TablePropertyIndex).ColumnName
            If TableProperty1Name = TableProperty2Name Then
                'COINCIDE EL NOMBRE DE LA PROPIEDAD, ENTONCES COMPARO (SI NO ES UN NOMBRE DE CATÁLOGO)
                If Not EXCLUSION_TABLE_PROPERTY_NAME.Contains("|" & TableProperty1Name & "|") Then

                    TableProperty1Value = datarowTable1(TablePropertyIndex).ToString.ToLower
                    TableProperty2Value = datarowTable2(TablePropertyIndex).ToString.ToLower

                    If TableProperty1Value <> TableProperty2Value Then
                        'LAS PROPIEDADES SON DIFERENTES
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, datarowTable1(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeTable.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_PROPERTY_DIFFERENT, TableProperty1Name, TableProperty1Value, TableProperty2Value), ICON_NAME_REPORT, ICON_NAME_REPORT)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub CompareColumns(ByRef treenodeFolderTablesResult As TreeNode, ByVal TableOrViewName As String)
        Dim datarowColumn1 As DataRow = Nothing
        Dim datarowColumn2 As DataRow = Nothing

        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeColumn As TreeNode

        Dim Column1Index As Integer = 0
        Dim Column1Count As Integer
        Dim Column2Index As Integer = 0
        Dim Column2Count As Integer

        Dim Column1Name As String = ""
        Dim Column2Name As String = ""

        mdatatableColumns1.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableOrViewName & "'"
        mdatatableColumns2.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableOrViewName & "'"

        Column1Count = mdatatableColumns1.DefaultView.ToTable.Rows.Count
        Column2Count = mdatatableColumns2.DefaultView.ToTable.Rows.Count

        Do While (Column1Index <= Column1Count - 1 Or Column2Index <= Column2Count - 1)
            If Column1Index <= Column1Count - 1 Then
                datarowColumn1 = mdatatableColumns1.DefaultView.ToTable.Rows(Column1Index)
                Column1Name = datarowColumn1(DATAROW_COLUMN_COLUMN_NAME).ToString
            Else
                Column1Name = StrDup(128, "Z")
            End If
            If Column2Index <= Column2Count - 1 Then
                datarowColumn2 = mdatatableColumns2.DefaultView.ToTable.Rows(Column2Index)
                Column2Name = datarowColumn2(DATAROW_COLUMN_COLUMN_NAME).ToString
            Else
                Column2Name = StrDup(128, "Z")
            End If

            If EXCLUSION_COLUMN_NAME.Contains("|" & Column1Name & "|") Then
                Column1Index += 1
            ElseIf EXCLUSION_COLUMN_NAME.Contains("|" & Column2Name & "|") Then
                Column2Index += 1
            Else
                Select Case Strings.StrComp(Column1Name, Column2Name, CompareMethod.Text)
                    Case -1
                        'LA COLUMNA NO EXISTE EN LA BASE DE DATOS 2
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableOrViewName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
                        treenodeColumn = CreateNodeColumn(treenodeFolder, datarowColumn1, ICON_NAME_COLUMN_MISSING)
                        treenodeColumn.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_COLUMN_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Column1Index += 1
                    Case 0
                        'LA COLUMNA EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS PROPIEDADES Y LUEGO SIGO CON LA SIGUIENTE COLUMNA
                        CompareColumnProperties(treenodeFolderTablesResult, datarowColumn1, datarowColumn2)
                        Column1Index += 1
                        Column2Index += 1
                    Case 1
                        'LA COLUMNA NO EXISTE EN LA BASE DE DATOS 1
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableOrViewName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
                        treenodeColumn = CreateNodeColumn(treenodeFolder, datarowColumn2, ICON_NAME_COLUMN_MISSING)
                        treenodeColumn.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_COLUMN_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Column2Index += 1
                End Select
            End If
        Loop
    End Sub

    Private Sub CompareColumnProperties(ByRef treenodeFolderTablesResult As TreeNode, ByRef datarowColumn1 As DataRow, ByRef datarowColumn2 As DataRow)
        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeColumn As TreeNode

        Dim ColumnPropertyIndex As Integer
        Dim ColumnPropertyCountMin As Integer

        Dim ColumnProperty1Name As String
        Dim ColumnProperty2Name As String
        Dim ColumnProperty1Value As String
        Dim ColumnProperty2Value As String

        'SUPONEMOS QUE AMBOS DATAROWS TIENEN LAS MISMAS PROPIEDADES
        'SI NO ES ASÍ, ES PORQUE USARON 2 PROVIDERS DISTINTOS
        'EN ESE CASO RECORRO TODAS LAS PROPIEDADES DEL QUE TIENE MENOS CANTIDAD
        'Y ADEMAS VERIFICO QUE COINCIDA EL NOMBRE DE LA PROPIEDAD, SI NO, LA IGNORO
        'QUEDA POR RESOLVER QUE PASA SI CAMBIA EL ORDEN DE LAS PROPIEDADES ENTRE DISTINTOS PROVIDERS (YA QUE LAS IGNORARÍA TODAS)
        ColumnPropertyCountMin = datarowColumn1.ItemArray.Count
        If ColumnPropertyCountMin > datarowColumn2.ItemArray.Count Then
            ColumnPropertyCountMin = datarowColumn2.ItemArray.Count
        End If
        For ColumnPropertyIndex = 1 To ColumnPropertyCountMin - 1
            ColumnProperty1Name = mdatatableColumns1.Columns(ColumnPropertyIndex).ColumnName
            ColumnProperty2Name = mdatatableColumns2.Columns(ColumnPropertyIndex).ColumnName
            If ColumnProperty1Name = ColumnProperty2Name Then
                'COINCIDE EL NOMBRE DE LA PROPIEDAD, ENTONCES COMPARO (SI NO ES UN NOMBRE DE CATÁLOGO)
                If Not EXCLUSION_COLUMN_PROPERTY_NAME.Contains("|" & ColumnProperty1Name & "|") Then

                    ColumnProperty1Value = datarowColumn1(ColumnPropertyIndex).ToString.ToLower
                    ColumnProperty2Value = datarowColumn2(ColumnPropertyIndex).ToString.ToLower

                    If ColumnProperty1Value <> ColumnProperty2Value Then
                        'LAS PROPIEDADES SON DIFERENTES
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, datarowColumn1(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
                        treenodeColumn = CreateNodeColumn(treenodeFolder, datarowColumn2, ICON_NAME_COLUMN_DIFFERENT)
                        treenodeColumn.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_PROPERTY_DIFFERENT, ColumnProperty1Name, ColumnProperty1Value, ColumnProperty2Value), ICON_NAME_REPORT, ICON_NAME_REPORT)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub ComparePrimaryKeys(ByRef treenodeFolderTablesResult As TreeNode, ByVal TableName As String)
        Dim datarowPrimaryKey1 As DataRow
        Dim datarowPrimaryKey2 As DataRow
        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeColumn As TreeNode

        Dim Column1Index As Integer = 0
        Dim Column1Count As Integer
        Dim Column2Index As Integer = 0
        Dim Column2Count As Integer

        Dim Column1Name As String = ""
        Dim Column2Name As String = ""

        mdatatablePrimaryKeys1.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"
        mdatatablePrimaryKeys2.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"

        Column1Count = mdatatablePrimaryKeys1.DefaultView.ToTable.Rows.Count
        Column2Count = mdatatablePrimaryKeys2.DefaultView.ToTable.Rows.Count

        Do While (Column1Index <= Column1Count - 1 Or Column2Index <= Column2Count - 1)
            If Column1Index <= Column1Count - 1 Then
                datarowPrimaryKey1 = mdatatablePrimaryKeys1.DefaultView.ToTable.Rows(Column1Index)
                Column1Name = datarowPrimaryKey1(DATAROW_COLUMN_COLUMN_NAME).ToString
            Else
                Column1Name = StrDup(128, "Z")
            End If
            If Column2Index <= Column2Count - 1 Then
                datarowPrimaryKey2 = mdatatablePrimaryKeys2.DefaultView.ToTable.Rows(Column2Index)
                Column2Name = datarowPrimaryKey2(DATAROW_COLUMN_COLUMN_NAME).ToString
            Else
                Column2Name = StrDup(128, "Z")
            End If
            If EXCLUSION_COLUMN_NAME.Contains("|" & Column1Name & "|") Then
                Column1Index += 1
            ElseIf EXCLUSION_COLUMN_NAME.Contains("|" & Column2Name & "|") Then
                Column2Index += 1
            Else
                Select Case Strings.StrComp(Column1Name, Column2Name, CompareMethod.Text)
                    Case -1
                        'LA COLUMNA DEL PRIMARY KEY NO EXISTE EN LA BASE DE DATOS 2
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
                        treenodeColumn = CreateNodeColumn(treenodeTable, Column1Name, ICON_NAME_PRIMARYKEY_MISSING)
                        treenodeColumn.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_PRIMARYKEY_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Column1Index += 1
                    Case 0
                        'LA COLUMNA DEL PRIMARY KEY EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS PROPIEDADES Y LUEGO SIGO CON LA SIGUIENTE COLUMNA
                        Column1Index += 1
                        Column2Index += 1
                    Case 1
                        'LA COLUMNA DEL PRIMARY KEY NO EXISTE EN LA BASE DE DATOS 1
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_COLUMNS, ICON_NAME_FOLDER)
                        treenodeColumn = CreateNodeColumn(treenodeTable, Column2Name, ICON_NAME_PRIMARYKEY_MISSING)
                        treenodeColumn.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_PRIMARYKEY_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Column2Index += 1
                End Select
            End If
        Loop
    End Sub

    Private Sub CompareTableConstraints(ByRef treenodeFolderTablesResult As TreeNode, ByVal TableName As String)
        Dim datarowTableConstraint1 As DataRow = Nothing
        Dim datarowTableConstraint2 As DataRow = Nothing

        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeTableConstraint As TreeNode

        Dim TableConstraint1Index As Integer = 0
        Dim TableConstraint1Count As Integer
        Dim TableConstraint2Index As Integer = 0
        Dim TableConstraint2Count As Integer

        Dim TableConstraint1Name As String = ""
        Dim TableConstraint2Name As String = ""

        mdatatableTableConstraints1.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"
        mdatatableTableConstraints2.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"

        TableConstraint1Count = mdatatableTableConstraints1.DefaultView.ToTable.Rows.Count
        TableConstraint2Count = mdatatableTableConstraints2.DefaultView.ToTable.Rows.Count

        Do While (TableConstraint1Index <= TableConstraint1Count - 1 Or TableConstraint2Index <= TableConstraint2Count - 1)
            If TableConstraint1Index <= TableConstraint1Count - 1 Then
                datarowTableConstraint1 = mdatatableTableConstraints1.DefaultView.ToTable.Rows(TableConstraint1Index)
                TableConstraint1Name = datarowTableConstraint1(DATAROW_COLUMN_CONSTRAINT_NAME).ToString
            Else
                TableConstraint1Name = StrDup(128, "Z")
            End If
            If TableConstraint2Index <= TableConstraint2Count - 1 Then
                datarowTableConstraint2 = mdatatableTableConstraints2.DefaultView.ToTable.Rows(TableConstraint2Index)
                TableConstraint2Name = datarowTableConstraint2(DATAROW_COLUMN_CONSTRAINT_NAME).ToString
            Else
                TableConstraint2Name = StrDup(128, "Z")
            End If
            If EXCLUSION_TABLE_CONSTRAINT_NAME.Contains("|" & TableConstraint1Name & "|") Then
                TableConstraint1Index += 1
            ElseIf EXCLUSION_TABLE_CONSTRAINT_NAME.Contains("|" & TableConstraint2Name & "|") Then
                TableConstraint2Index += 1
            Else
                Select Case Strings.StrComp(TableConstraint1Name, TableConstraint2Name, CompareMethod.Text)
                    Case -1
                        'EL KEY NO EXISTE EN LA BASE DE DATOS 2
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        If datarowTableConstraint1(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_KEYS, ICON_NAME_FOLDER)
                        Else
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_CONSTRAINTS, ICON_NAME_FOLDER)
                        End If
                        treenodeTableConstraint = CreateNodeTableConstraint(treenodeFolder, datarowTableConstraint1, ICON_NAME_ALTERNATEKEY_MISSING, ICON_NAME_PRIMARYKEY_MISSING, ICON_NAME_FOREIGNKEY_MISSING, ICON_NAME_CHECK_MISSING)
                        If datarowTableConstraint1(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                            treenodeTableConstraint.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_KEY_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Else
                            treenodeTableConstraint.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_CONSTRAINT_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        End If
                        TableConstraint1Index += 1
                    Case 0
                        'EL KEY EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS PROPIEDADES Y LUEGO SIGO CON LA SIGUIENTE TABLE CONSTRAINT
                        CompareTableConstraintsProperties(treenodeFolderTablesResult, datarowTableConstraint1, datarowTableConstraint2)
                        TableConstraint1Index += 1
                        TableConstraint2Index += 1
                    Case 1
                        'EL KEY NO EXISTE EN LA BASE DE DATOS 1
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        If datarowTableConstraint2(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_KEYS, ICON_NAME_FOLDER)
                        Else
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_CONSTRAINTS, ICON_NAME_FOLDER)
                        End If
                        treenodeTableConstraint = CreateNodeTableConstraint(treenodeFolder, datarowTableConstraint2, ICON_NAME_ALTERNATEKEY_MISSING, ICON_NAME_PRIMARYKEY_MISSING, ICON_NAME_FOREIGNKEY_MISSING, ICON_NAME_CHECK_MISSING)
                        If datarowTableConstraint2(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                            treenodeTableConstraint.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_KEY_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Else
                            treenodeTableConstraint.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_CONSTRAINT_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        End If
                        TableConstraint2Index += 1
                End Select
            End If
        Loop
    End Sub

    Private Sub CompareTableConstraintsProperties(ByRef treenodeFolderTablesResult As TreeNode, ByRef datarowTableConstraint1 As DataRow, ByRef datarowTableConstraint2 As DataRow)
        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeTableConstraint As TreeNode

        Dim TableConstraintPropertyIndex As Integer
        Dim TableConstraintPropertyCountMin As Integer

        Dim TableConstraintProperty1Name As String
        Dim TableConstraintProperty2Name As String
        Dim TableConstraintProperty1Value As String
        Dim TableConstraintProperty2Value As String

        'SUPONEMOS QUE AMBOS DATAROWS TIENEN LAS MISMAS PROPIEDADES
        'SI NO ES ASÍ, ES PORQUE USARON 2 PROVIDERS DISTINTOS
        'EN ESE CASO RECORRO TODAS LAS PROPIEDADES DEL QUE TIENE MENOS CANTIDAD
        'Y ADEMAS VERIFICO QUE COINCIDA EL NOMBRE DE LA PROPIEDAD, SI NO, LA IGNORO
        'QUEDA POR RESOLVER QUE PASA SI CAMBIA EL ORDEN DE LAS PROPIEDADES ENTRE DISTINTOS PROVIDERS (YA QUE LAS IGNORARÍA TODAS)
        TableConstraintPropertyCountMin = datarowTableConstraint1.ItemArray.Count
        If TableConstraintPropertyCountMin > datarowTableConstraint2.ItemArray.Count Then
            TableConstraintPropertyCountMin = datarowTableConstraint2.ItemArray.Count
        End If
        For TableConstraintPropertyIndex = 1 To TableConstraintPropertyCountMin - 1
            TableConstraintProperty1Name = mdatatableTableConstraints1.Columns(TableConstraintPropertyIndex).ColumnName
            TableConstraintProperty2Name = mdatatableTableConstraints2.Columns(TableConstraintPropertyIndex).ColumnName
            If TableConstraintProperty1Name = TableConstraintProperty2Name Then
                'COINCIDE EL NOMBRE DE LA PROPIEDAD, ENTONCES COMPARO (SI NO ES UN NOMBRE DE CATÁLOGO)
                If Not EXCLUSION_TABLE_CONSTRAINT_PROPERTY_NAME.Contains("|" & TableConstraintProperty1Name & "|") Then

                    TableConstraintProperty1Value = datarowTableConstraint1(TableConstraintPropertyIndex).ToString.ToLower
                    TableConstraintProperty2Value = datarowTableConstraint2(TableConstraintPropertyIndex).ToString.ToLower

                    If TableConstraintProperty1Value <> TableConstraintProperty2Value Then
                        'LAS PROPIEDADES SON DIFERENTES
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, datarowTableConstraint1(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE_DIFFERENT, False)
                        If datarowTableConstraint1(DATAROW_COLUMN_CONSTRAINT_TYPE).ToString <> "CHECK" Then
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_KEYS, ICON_NAME_FOLDER)
                        Else
                            treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_CONSTRAINTS, ICON_NAME_FOLDER)
                        End If
                        treenodeTableConstraint = CreateNodeTableConstraint(treenodeFolder, datarowTableConstraint1, ICON_NAME_ALTERNATEKEY_DIFFERENT, ICON_NAME_PRIMARYKEY_DIFFERENT, ICON_NAME_FOREIGNKEY_DIFFERENT, ICON_NAME_CHECK_DIFFERENT)
                        treenodeTableConstraint.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_PROPERTY_DIFFERENT, TableConstraintProperty1Name, TableConstraintProperty1Value, TableConstraintProperty2Value), ICON_NAME_REPORT, ICON_NAME_REPORT)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub CompareIndexes(ByRef treenodeFolderTablesResult As TreeNode, ByVal TableName As String)
        Dim datarowIndex1 As DataRow = Nothing
        Dim datarowIndex2 As DataRow = Nothing

        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeIndex As TreeNode

        Dim Index1Index As Integer = 0
        Dim Index1Count As Integer
        Dim Index2Index As Integer = 0
        Dim Index2Count As Integer

        Dim Index1Name As String = ""
        Dim Index2Name As String = ""

        mdatatableIndexes1.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"
        mdatatableIndexes2.DefaultView.RowFilter = DATAROW_COLUMN_TABLE_NAME & " = '" & TableName & "'"

        Index1Count = mdatatableIndexes1.DefaultView.ToTable.Rows.Count
        Index2Count = mdatatableIndexes2.DefaultView.ToTable.Rows.Count

        Do While (Index1Index <= Index1Count - 1 Or Index2Index <= Index2Count - 1)
            If Index1Index <= Index1Count - 1 Then
                datarowIndex1 = mdatatableIndexes1.DefaultView.ToTable.Rows(Index1Index)
                Index1Name = datarowIndex1(DATAROW_COLUMN_INDEX_NAME).ToString
            Else
                Index1Name = StrDup(128, "Z")
            End If
            If Index2Index <= Index2Count - 1 Then
                datarowIndex2 = mdatatableIndexes2.DefaultView.ToTable.Rows(Index2Index)
                Index2Name = datarowIndex2(DATAROW_COLUMN_INDEX_NAME).ToString
            Else
                Index2Name = StrDup(128, "Z")
            End If
            If EXCLUSION_INDEX_NAME.Contains("|" & Index1Name & "|") Then
                Index1Index += 1
            ElseIf EXCLUSION_INDEX_NAME.Contains("|" & Index2Name & "|") Then
                Index2Index += 1
            Else
                Select Case Strings.StrComp(Index1Name, Index2Name, CompareMethod.Text)
                    Case -1
                        'EL INDEX NO EXISTE EN LA BASE DE DATOS 2
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_INDEXES, ICON_NAME_FOLDER)
                        treenodeIndex = CreateNodeIndex(treenodeFolder, datarowIndex1, ICON_NAME_INDEX_MISSING, ICON_NAME_INDEX_MISSING)
                        treenodeIndex.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_INDEX_MISSING, 2), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Index1Index += 1
                    Case 0
                        'EL INDEX EXISTE EN LAS DOS BASES DE DATOS, CHEQUEO LAS PROPIEDADES Y LUEGO SIGO CON EL SIGUIENTE INDEX
                        CompareIndexesProperties(treenodeFolderTablesResult, datarowIndex1, datarowIndex2)
                        Index1Index += 1
                        Index2Index += 1
                    Case 1
                        'EL INDEX NO EXISTE EN LA BASE DE DATOS 1
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, TableName, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_INDEXES, ICON_NAME_FOLDER)
                        treenodeIndex = CreateNodeIndex(treenodeFolder, datarowIndex2, ICON_NAME_INDEX_MISSING, ICON_NAME_INDEX_MISSING)
                        treenodeIndex.Nodes.Add(TREENODE_KEY_REPORT, String.Format(STRING_INDEX_MISSING, 1), ICON_NAME_REPORT, ICON_NAME_REPORT)
                        Index2Index += 1
                End Select
            End If
        Loop
    End Sub

    Private Sub CompareIndexesProperties(ByRef treenodeFolderTablesResult As TreeNode, ByRef datarowIndex1 As DataRow, ByRef datarowIndex2 As DataRow)
        Dim treenodeTable As TreeNode
        Dim treenodeFolder As TreeNode
        Dim treenodeIndex As TreeNode

        Dim IndexPropertyIndex As Integer
        Dim IndexPropertyCountMin As Integer

        Dim IndexProperty1Name As String
        Dim IndexProperty2Name As String
        Dim IndexProperty1Value As String
        Dim IndexProperty2Value As String

        'SUPONEMOS QUE AMBOS DATAROWS TIENEN LAS MISMAS PROPIEDADES
        'SI NO ES ASÍ, ES PORQUE USARON 2 PROVIDERS DISTINTOS
        'EN ESE CASO RECORRO TODAS LAS PROPIEDADES DEL QUE TIENE MENOS CANTIDAD
        'Y ADEMAS VERIFICO QUE COINCIDA EL NOMBRE DE LA PROPIEDAD, SI NO, LA IGNORO
        'QUEDA POR RESOLVER QUE PASA SI CAMBIA EL ORDEN DE LAS PROPIEDADES ENTRE DISTINTOS PROVIDERS (YA QUE LAS IGNORARÍA TODAS)
        IndexPropertyCountMin = datarowIndex1.ItemArray.Count
        If IndexPropertyCountMin > datarowIndex2.ItemArray.Count Then
            IndexPropertyCountMin = datarowIndex2.ItemArray.Count
        End If
        For IndexPropertyIndex = 1 To IndexPropertyCountMin - 1
            IndexProperty1Name = mdatatableIndexes1.Columns(IndexPropertyIndex).ColumnName
            IndexProperty2Name = mdatatableIndexes2.Columns(IndexPropertyIndex).ColumnName
            If IndexProperty1Name = IndexProperty2Name Then
                'COINCIDE EL NOMBRE DE LA PROPIEDAD, ENTONCES COMPARO (SI NO ES UN NOMBRE DE CATÁLOGO)
                If Not EXCLUSION_INDEX_PROPERTY_NAME.Contains("|" & IndexProperty1Name & "|") Then

                    IndexProperty1Value = datarowIndex1(IndexPropertyIndex).ToString.ToLower
                    IndexProperty2Value = datarowIndex2(IndexPropertyIndex).ToString.ToLower

                    If IndexProperty1Value <> IndexProperty2Value Then
                        'LAS PROPIEDADES SON DIFERENTES
                        treenodeTable = CreateNodeTable(treenodeFolderTablesResult, datarowIndex1(DATAROW_COLUMN_TABLE_NAME).ToString, ICON_NAME_TABLE_DIFFERENT, False)
                        treenodeFolder = CreateNodeTableSubFolder(treenodeTable, TREENODE_FOLDER_INDEXES, ICON_NAME_FOLDER)
                        treenodeIndex = CreateNodeIndex(treenodeFolder, datarowIndex1, ICON_NAME_INDEX_DIFFERENT, ICON_NAME_INDEX_DIFFERENT)
                        treenodeIndex.Nodes.Add(TREENODE_KEY_REPORT, "Column: " & datarowIndex1(DATAROW_COLUMN_COLUMN_NAME).ToString & " --> " & String.Format(STRING_PROPERTY_DIFFERENT, IndexProperty1Name, IndexProperty1Value, IndexProperty2Value), ICON_NAME_REPORT, ICON_NAME_REPORT)
                    End If
                End If
            End If
        Next
    End Sub
#End Region

End Module