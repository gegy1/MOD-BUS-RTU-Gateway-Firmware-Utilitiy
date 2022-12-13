Imports System.ComponentModel
Imports System.IO

Public Class FirmwareObjectFactory
#Region "Singelton Pattern"
    Private Shared instance As FirmwareObjectFactory = Nothing

    Public Shared Function GetInstance() As FirmwareObjectFactory
        If instance Is Nothing Then
            instance = New FirmwareObjectFactory
        End If
        Return instance
    End Function

    Private Sub New()
        'Nothing to do here
    End Sub
#End Region

    Const workspaceName As String = "OpenKNX"
    Const lineSplitter As String = ";"
    Function LoadFirmwaresFromXML(fileName As String) As BindingList(Of Firmware)

    End Function
    Function LoadFirmwaresFromTxtFile(fileName As String) As BindingList(Of Firmware)
        Dim retVal As New BindingList(Of Firmware)
        If Not File.Exists(fileName) Then Return retVal
        For Each line As String In File.ReadLines(fileName)
            retVal.Add(GetFirmware(line, workspaceName))
        Next
        Return retVal
    End Function

    Function LoadFirmwaresFromWeb() As BindingList(Of Firmware)

    End Function
    Function SaveFirmwaressToXML(fileName As String, devices As BindingList(Of Firmware)) As Boolean

    End Function

    Private Function GetFirmware(dataLine As String, workspaceName As String) As Firmware
        Dim data As (repoName As String, displayName As String)
        data.repoName = dataLine.Split(lineSplitter)(0)
        data.displayName = dataLine.Split(lineSplitter)(1)
        Return New Firmware(dataLine, New GitRepo(data.repoName, workspaceName)) With {.DisplayName = data.displayName}
    End Function
End Class
