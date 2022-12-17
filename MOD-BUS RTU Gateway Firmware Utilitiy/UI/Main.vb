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
        Me.StatusWebBrowser.Navigate("about:blank")
        Do Until StatusWebBrowser.ReadyState = WebBrowserReadyState.Complete
            Application.DoEvents()
            System.Threading.Thread.Sleep(100)
        Loop
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
        'If clear Then Me.StatusWebBrowser.DocumentText = ""
        Me.BeginInvoke(Sub()
                           Dim document As HtmlDocument = Me.StatusWebBrowser.Document
                           Me.StatusWebBrowser.Document.Body.InnerHtml = document.Body.InnerHtml + message + "<br>"
                           'Me.StatusWebBrowser.DocumentText = Me.StatusWebBrowser.DocumentText + (message + "<br>")
                           Do Until StatusWebBrowser.ReadyState = WebBrowserReadyState.Complete
                               Application.DoEvents()
                               System.Threading.Thread.Sleep(100)
                           Loop
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim h1 As New Hardware With {.Name = "PiPico"}
        Dim h3 As New Hardware With {.Name = "OpenKNXREG"}
        Dim h2 As New Hardware With {.Name = "MOD-BUS Gateway"}
        Dim d1 As New Firmware With {.Name = "OAM-ModbusGateway", .LatestVersion = "1.0.2-release", .PossibleHardware = New Generic.List(Of Hardware)({h2})}
        Dim d2 As New Firmware With {.Name = "1TE-RP2040-SmartMF", .LatestVersion = "0.12.3-Beta", .PossibleHardware = New Generic.List(Of Hardware)({h1, h3})}
        'Dim d3 As New Firmware With {.Name = "BEM-GardenControl", .LatestVersion = "0.2-release"}
        'Dim d4 As New Firmware With {.Name = "OAM-EnoceanGateway", .LatestVersion = "1.4-release"}
        Dim list As New List(Of Firmware)
        list.Add(d1)
        list.Add(d2)

        Dim ser As New Seriallizer(Of Firmware)
        ser.SerializeListToFile(list, "devices.xml")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim firmwareRepoListFile As String = "repos.txt"
        With Me.FirmwaresComboBox
            .DataSource = FirmwareObjectFactory.GetInstance.LoadFirmwaresFromTxtFile(firmwareRepoListFile)
            .DisplayMember = "DisplayName"
        End With
    End Sub

    Private Sub FirmwaresComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FirmwaresComboBox.SelectedIndexChanged
        If Me.FirmwaresComboBox.SelectedItem Is Nothing Then Return
        Dim selectedFirmware As Firmware = TryCast(Me.FirmwaresComboBox.SelectedItem, Firmware)
        ClearStatusBox()
        'Me.StautsTextBox.AppendText(selectedFirmware.GitRepo.GetRepoInfoText)
        Me.StatusWebBrowser.DocumentText = selectedFirmware.GitRepo.GetRepoInfoText
    End Sub

    Private Sub StatusWebBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles StatusWebBrowser.Navigating
        If Not e.Url.ToString = ("about:blank") Then
            e.Cancel = True
            System.Diagnostics.Process.Start(e.Url.ToString)
        End If
    End Sub
End Class

