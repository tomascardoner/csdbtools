Module Startup
    Friend Const ERROR_CUSTOM_DIALOG As Boolean = True

    <STAThread()>
    Public Sub Main()
        Application.EnableVisualStyles()

        FormMdi.ShowDialog()
    End Sub
End Module
