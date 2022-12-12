Imports System.IO
Imports System.IO.Compression

Public Class ZipDocument
    Property ZipArchiveFileName As String
    ReadOnly Property Name As String

    Sub New(zipFile As String, name As String)
        Me.ZipArchiveFileName = zipFile
        Me.Name = name
    End Sub

    Function ExtractSpecifiedFiles(fileNames As List(Of String), destinationDirectory As String) As Boolean
        Try
            Dim filesToExtract As New List(Of (zipEntry As ZipArchiveEntry, fileName As String))
            Using zipArchive = ZipFile.OpenRead(Me.ZipArchiveFileName)
                For Each fileName In fileNames
                    Dim fileToExtract As ZipArchiveEntry = zipArchive.Entries.FirstOrDefault(Function(e) e.FullName Like fileName)
                    If Not fileToExtract Is Nothing Then filesToExtract.Add((fileToExtract, Path.GetFileName(fileName)))
                Next
                Dim t = Task.Run(Sub()
                                     For Each fileToExtract In filesToExtract
                                         Using reader As New BinaryReader(fileToExtract.zipEntry.Open())
                                             System.IO.File.WriteAllBytes($"{destinationDirectory}\{fileToExtract.fileName}", ReadAllBytes(reader))
                                         End Using
                                     Next
                                 End Sub)
                t.Wait()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message) : Return False
        End Try
        Return True
    End Function


    Private Function ReadAllBytes(reader As BinaryReader) As Byte()
        Const bufferSize As Integer = 4096
        Using ms As New MemoryStream()
            Dim buffer(bufferSize) As Byte
            Dim count As Integer
            Do
                count = reader.Read(buffer, 0, buffer.Length)
                If count > 0 Then ms.Write(buffer, 0, count)
            Loop While count <> 0
            Return ms.ToArray()
        End Using
    End Function
End Class
