Imports System.IO

Public Class KNXProdFile
    Inherits BasicFile

    Public Event ReportStatus(message As String)
    Sub New(fileName As String)
        MyBase.New(fileName)
    End Sub

    Sub CreateKNXProdFile()
        Dim openFileDialog As New SaveFileDialog With {
            .Filter = "KNX Product file (*.knxprod)|*.knxprod",
            .InitialDirectory = My.Application.Info.DirectoryPath + "\firmware",
            .FileName = "modbus-rtu.knxprod"}
        Dim exportFileName As String = ""
        If Not openFileDialog.ShowDialog = DialogResult.OK Then
            Return
        End If
        RaiseEvent ReportStatus("Creating KNX Product file")
        If Not File.Exists("openknxproducer\OpenKNXproducer.exe") Then
            RaiseEvent ReportStatus("OpenKNXproducer.exe not found. Please download latest OpenKNXproducer.exe.") : Return
        End If
        exportFileName = openFileDialog.FileName
        Dim pi As New ProcessStartInfo
        With pi
            .FileName = "openknxproducer\OpenKNXproducer.exe"
            .Arguments = $"knxprod --NoXsd --Output=""{exportFileName}"" ""{Me.FileName}"""
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .WindowStyle = ProcessWindowStyle.Hidden
            .CreateNoWindow = True
        End With
        Dim p As New System.Diagnostics.Process With {.StartInfo = pi}
        AddHandler p.OutputDataReceived, AddressOf Me.OutputHandler
        p.Start()
        p.BeginOutputReadLine()
        p.WaitForExit(30000)
        If Not File.Exists(exportFileName) Then RaiseEvent ReportStatus("Could not create KNX Product file")
    End Sub

    Private Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(outLine.Data) Then
            RaiseEvent ReportStatus(outLine.Data)
        End If
    End Sub


End Class
