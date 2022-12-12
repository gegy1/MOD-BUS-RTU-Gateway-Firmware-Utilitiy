Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports Octokit

Public Class GitRepo
    Property RepositoryName As String
    Property WorkspaceName As String
    Const downloadFolderName As String = "download\"

    Sub New(repositoryName As String, workSpaceName As String)
        Me.RepositoryName = repositoryName
        Me.WorkspaceName = workSpaceName
    End Sub
    Async Function DownloadLatestCompiled() As Task(Of (ziparchive As String, version As String))
        Dim downloadTask As Task(Of (ziparchive As String, version As String)) = GitDownload()
        Return Await downloadTask
    End Function
    Private Async Function GitDownload() As Task(Of (ziparchive As String, version As String))
        Dim retVal As (ziparchive As String, version As String)
        Dim gitClient As New GitHubClient(New ProductHeaderValue(RepositoryName))
        Dim latestRelease As Release = Await gitClient.Repository.Release.GetLatest(WorkspaceName, RepositoryName)
        retVal.version = latestRelease.TagName
        Dim assests As List(Of ReleaseAsset) = latestRelease.Assets
        If assests Is Nothing Then Return Nothing : If assests.Count = 0 Then Return Nothing
        Dim download As Task(Of String) = DownloadFile(New Uri(assests.First.BrowserDownloadUrl), $"{Me.RepositoryName}.zip")
        retVal.ziparchive = Await download
        Return retVal
    End Function

    Private Async Function DownloadFile(uri As Uri, destinationFile As String) As Task(Of String)
        Dim t = Task.Run(Async Function()
                             Dim WebClient As New WebClient()
                             WebClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0")
                             Directory.CreateDirectory("download")
                             Await WebClient.DownloadFileTaskAsync(uri, downloadFolderName + destinationFile)
                             Return downloadFolderName + destinationFile
                         End Function)
        Dim ft As String = Await t
        Return ft
    End Function
End Class
