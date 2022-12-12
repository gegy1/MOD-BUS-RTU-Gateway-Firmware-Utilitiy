
Public Class SetupPage


    Dim SettingsMgr As SettingsMgr = SettingsMgr.getInstance

    Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Me.PropertyGrid1.PropertySort = PropertySort.NoSort + PropertySort.Categorized
    End Sub

    Sub SaveData()
        SettingsMgr.SaveOptions()
    End Sub

    Private Sub SettingEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PropertyGrid1.SelectedObject = SettingsMgr.Settings
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim ofd As New SaveFileDialog With {
            .FileName = "settings.xml",
            .Filter = "Optionen|*.xml"
        }
        If ofd.ShowDialog() = DialogResult.OK Then
            SettingsMgr = SettingsMgr.getInstance()
            SettingsMgr.WriteToFile(ofd.FileName)
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim ofd As New OpenFileDialog
        Dim loadedSettings As ToolSettings
        ofd.FileName = "settings.xml"
        ofd.Filter = "Optionen|*.xml"
        If ofd.ShowDialog() = DialogResult.OK Then
            SettingsMgr = SettingsMgr.getInstance()
            loadedSettings = SettingsMgr.LoadFromFile(ofd.FileName)
            If Not loadedSettings Is Nothing Then
                SettingsMgr.Settings = loadedSettings
            End If
        End If
        SettingEditor_Load(Nothing, Nothing)
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If MsgBox("Realy reset settings?", vbYesNo) = MsgBoxResult.Yes Then
            SettingsMgr = SettingsMgr.getInstance()
            SettingsMgr.Settings = New ToolSettings
            Me.PropertyGrid1.Refresh()
        End If
    End Sub
End Class
