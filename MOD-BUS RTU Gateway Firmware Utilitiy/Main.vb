Imports System.IO


Public Class Main

    Private versionString As String = $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build} (BETA)"
    WithEvents controller As Controller


    ReadOnly Property CreateKNXPRODButtonEnable As Boolean
        Get
            Return File.Exists(Me.KNXxmlFileTextBox.Text) And File.Exists("openknxproducer\openknxproducer.exe")
        End Get
    End Property

    ReadOnly Property FlashFirmwareButtonEnable As Boolean
        Get
            Return File.Exists(Me.FirmwareFileTextBox.Text)
        End Get
    End Property


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = $"{My.Application.Info.ProductName} {versionString}"
        controller = Controller.GetInstance
        Me.FirmwareFileTextBox.DataBindings.Add(controller.FirmwareFile.TextBinding)
        Me.KNXxmlFileTextBox.DataBindings.Add(controller.KNXProdFile.TextBinding)
        Me.FlashFirmwareButton.DataBindings.Add(controller.FirmwareFile.EnableBinding)
        Me.CreateKNXProdFileButton.DataBindings.Add(controller.KNXProdFile.EnableBinding)
        controller.LookForExistingFiles()
    End Sub

    Private Sub ClearStatusBox()
        Me.StautsTextBox.Clear()
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        controller.ShowSettings()
    End Sub

    Private Async Sub LoadLatestButton_Click(sender As Object, e As EventArgs) Handles LoadLatestButton.Click
        ClearStatusBox()
        Dim downloadFirmwareTask As Task(Of Boolean) = controller.DownloadFirmware()
        Dim downloadedOk As Boolean = Await downloadFirmwareTask
    End Sub


    Private Sub controller_UpdateStatusTextBox(message As String, Optional clear As Boolean = False) Handles controller.UpdateStatusMessage
        If clear Then Me.StautsTextBox.Clear()
        Me.BeginInvoke(Sub()
                           Me.StautsTextBox.AppendText(message + Environment.NewLine)
                       End Sub)
    End Sub

    Private Sub SelectKNXProdXMLButton_Click(sender As Object, e As EventArgs) Handles SelectKNXProdXMLButton.Click
        Dim openFileDialog As New OpenFileDialog With {.Multiselect = False, .Filter = "KNX xml (*.xml)|*.xml", .InitialDirectory = My.Application.Info.DirectoryPath + "\firmware"}
        If openFileDialog.ShowDialog = DialogResult.OK Then
            Controller.GetInstance.KNXProdFile.FileName = openFileDialog.FileName
        End If
    End Sub

    Private Sub SelectFirmwareButton_Click(sender As Object, e As EventArgs) Handles SelectFirmwareButton.Click
        Dim openFileDialog As New OpenFileDialog With {.Multiselect = False, .Filter = "Firmware file (*.bin)|*.bin", .InitialDirectory = My.Application.Info.DirectoryPath + "\firmware"}
        If openFileDialog.ShowDialog = DialogResult.OK Then
            Controller.GetInstance.FirmwareFile.FileName = openFileDialog.FileName
        End If
    End Sub

    Private Sub CreateKNXProdFileButton_Click(sender As Object, e As EventArgs) Handles CreateKNXProdFileButton.Click
        ClearStatusBox()
        controller.CreateKNXPRODFile()
    End Sub

    Private Sub FlashFirmwareButton_Click(sender As Object, e As EventArgs) Handles FlashFirmwareButton.Click
        ClearStatusBox()
        controller.FlashFirmware()
    End Sub
End Class
