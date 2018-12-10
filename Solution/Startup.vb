Module Startup
    Friend Const ERROR_CUSTOM_DIALOG As Boolean = True

    Public Sub Main()
        Application.EnableVisualStyles()

        formMDIMain.ShowDialog()
    End Sub
End Module
