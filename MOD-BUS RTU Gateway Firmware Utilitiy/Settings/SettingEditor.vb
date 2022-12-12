
Public Class Settingseditor
    Property SetUpPropGrid As SetupPage
    Sub New(propertyGridForm As SetupPage)
        InitializeComponent()
        propertyGridForm.Dock = Windows.Forms.DockStyle.Fill
        Me.pnlPropertyGrid.Controls.Add(propertyGridForm)
        SetUpPropGrid = propertyGridForm
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.SetUpPropGrid.SaveData()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Settingseditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = $"Settings {My.Application.Info.AssemblyName} (Version {My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor})"
    End Sub
End Class