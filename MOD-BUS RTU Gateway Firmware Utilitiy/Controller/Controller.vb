Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression

Imports System.Runtime.CompilerServices
Imports Octokit

Public Class Controller

#Region "Singelton Pattern"
    Private Shared instance As Controller = Nothing

    Public Shared Function GetInstance() As Controller
        If instance Is Nothing Then
            instance = New Controller
        End If
        Return instance
    End Function

    Private Sub New()
        'Nothing to do here
    End Sub
#End Region

    Const firmwareDirectoryName As String = "firmware"
    Const openKNXproducerDirectoryName As String = "openknxproducer"
    Const downloadPath As String = "\download"

    'Repo data for getting the openKNX repos with released firmware
    Const metaDataWorkspaceName As String = "gegy1"
    Const metaDataRepoName As String = "MOD-BUS-RTU-Gateway-Firmware-Utilitiy"
    Const metaDataFileName As String = "/Metadata/FirmwareRepos.xml"

    Public Event UpdateStatusMessage(message As String)

    WithEvents firmwareFileValue As FirmwareFile = New FirmwareFile("")
    <RefreshProperties(RefreshProperties.All)>
    Property FirmwareFile As FirmwareFile
        Get
            Return firmwareFileValue
        End Get
        Set(value As FirmwareFile)
            firmwareFileValue = value
        End Set
    End Property

    WithEvents kNXProdFileValue As KNXProdFile = New KNXProdFile("")
    <RefreshProperties(RefreshProperties.All)>
    Property KNXProdFile As KNXProdFile
        Get
            Return kNXProdFileValue
        End Get
        Set(value As KNXProdFile)
            kNXProdFileValue = value
        End Set
    End Property

    Property AvailableFirmware As BindingList(Of Firmware) = New BindingList(Of Firmware)

    Sub ShowSettings()
        Dim mySetupPage As New SetupPage()
        Dim settings As New Settingseditor(mySetupPage)
        settings.ShowDialog()
    End Sub



    Private firmwareExtractFileNames As New List(Of String)({"data\firmware.bin", "data\ModbusGateway.xml"})
    Private producerExtractFileNames As New List(Of String)({"tools\bossac-LICENSE.txt", "tools\bossac.exe", "tools\OpenKNXproducer.exe"})
    Private firmwareFileNames As New List(Of String)({My.Application.Info.DirectoryPath + "\firmware\firmware.bin", My.Application.Info.DirectoryPath + "\firmware\ModbusGateway.xml"})


    Private Sub LoadAvilableFirmware()
        Dim metaDataRepo As New GitRepo(metaDataWorkspaceName, metaDataRepoName)
        metaDataRepo.GetSpecifiedFile(metaDataFileName)
    End Sub

    Sub LookForExistingFiles()
        If File.Exists(firmwareFileNames(0)) Then Me.FirmwareFile.FileName = firmwareFileNames(0)
        If File.Exists(firmwareFileNames(1)) Then Me.KNXProdFile.FileName = firmwareFileNames(1)
    End Sub
    Function ExtractingFirmware(zipDocuments As (firmwareZip As ZipDocument, producerZip As ZipDocument), firmwareFile As FirmwareFile, knxprodXML As KNXProdFile) As Boolean
        Dim retVal As Boolean

        Directory.CreateDirectory(firmwareDirectoryName)
        Directory.CreateDirectory(openKNXproducerDirectoryName)
        If ExtractSingleFile(zipDocuments.firmwareZip, firmwareDirectoryName, firmwareExtractFileNames) And
            ExtractSingleFile(zipDocuments.producerZip, openKNXproducerDirectoryName, producerExtractFileNames) Then
            firmwareFile.FileName = firmwareFileNames(0)
            knxprodXML.FileName = firmwareFileNames(1)
            retVal = True
        End If
        Return retVal
    End Function

    Function ExtractSingleFile(zipDocument As ZipDocument, destinationDirectory As String, filesToExtract As List(Of String)) As Boolean
        UpdateStatus($"Extracting {zipDocument.Name}...")
        If Not zipDocument.ExtractSpecifiedFiles(filesToExtract, destinationDirectory) Then
            UpdateStatus($"Extracting {zipDocument.Name}... error") : Return False
        End If
        UpdateStatus($"Extracting {zipDocument.Name}... done") : Return True
    End Function
    Async Function DownloadFirmware() As Task(Of Boolean)
        Dim zipDocuments As (firmwareZip As ZipDocument, producerZip As ZipDocument)
        With zipDocuments
            .firmwareZip = Nothing
            .producerZip = Nothing
        End With
        Dim firmwareZip As ZipDocument
        Dim producerZip As ZipDocument
        Try
            Dim modBusRepo As New GitRepo("OAM_ModbusGateway", "OpenKNX")
            Dim zipfirmwareDocumentTask As Task(Of ZipDocument) = Download(modBusRepo, "Downloading MOD-BUS Firmware...")
            firmwareZip = Await zipfirmwareDocumentTask
            If Not firmwareZip Is Nothing Then zipDocuments.firmwareZip = firmwareZip

            Dim openKnxProducerRepo As New GitRepo("OpenKNXproducer", "OpenKNX")
            Dim zipProducerDocumentTask As Task(Of ZipDocument) = Download(openKnxProducerRepo, "Downloading OpenKNXproducer...")
            producerZip = Await zipProducerDocumentTask
            If Not producerZip Is Nothing Then zipDocuments.producerZip = producerZip
        Catch ex As Exception
            UpdateStatus(ex.Message)
            Return False
        End Try
        Return ExtractingFirmware(zipDocuments, Me.FirmwareFile, Me.KNXProdFile)
    End Function

    Private Async Function Download(repo As GitRepo, statusMessage As String) As Task(Of ZipDocument)
        UpdateStatus(statusMessage)
        Dim downloadTask As Task(Of (ziparchive As String, version As String)) = repo.DownloadLatestCompiled()
        Dim zipArchive As (ziparchive As String, version As String) = Await downloadTask
        If Not zipArchive.ziparchive Is Nothing Then
            UpdateStatus($"{statusMessage} done (Loaded version: {zipArchive.version})")
            Return New ZipDocument(zipArchive.ziparchive, repo.RepositoryName + ".zip")
        Else
            UpdateStatus($"{statusMessage} error")
        End If
        Return Nothing
    End Function

    Sub CreateKNXPRODFile()
        Me.KNXProdFile.CreateKNXProdFile()
    End Sub

    Async Sub FlashFirmware()
        Await Task.Run(Sub() Me.FirmwareFile.FlashFirmware())
    End Sub

    Private Sub UpdateStatus(message As String)
        RaiseEvent UpdateStatusMessage(message)
    End Sub

    Private Sub FileStatus(message As String) Handles firmwareFileValue.ReportStatus, kNXProdFileValue.ReportStatus
        RaiseEvent UpdateStatusMessage(message)
    End Sub

End Class
