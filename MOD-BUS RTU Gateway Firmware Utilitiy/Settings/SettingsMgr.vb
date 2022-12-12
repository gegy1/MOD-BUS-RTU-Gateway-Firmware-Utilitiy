Imports System.IO
Imports System.Xml.Serialization


Public Structure sqlConnectionInfo
    Dim server As String
    Dim dataBaseName As String
    Dim user As String
    Dim passwort As String
End Structure

Public Class SettingsMgr
    Private Const SettingsFile As String = "settings.xml"
    Private AppPath As String = My.Application.Info.DirectoryPath
    Private SettingsPath As String = Path.Combine(AppPath, SettingsFile)
    Private _settings As New ToolSettings
    Private Shared instance As SettingsMgr = Nothing
    Public Property Settings() As ToolSettings
        Get
            Return _settings
        End Get
        Set(ByVal value As ToolSettings)
            _settings = value
        End Set
    End Property


    Private Sub New()
        If instance Is Nothing Then
            If File.Exists(SettingsPath) Then
                _settings = LoadFromFile(SettingsPath)
            Else
                _settings = New ToolSettings
                SaveOptions()
            End If

            If _settings Is Nothing Then
                MessageBox.Show("Unable to load Options")
            End If
        End If
    End Sub

    Public Shared Function getInstance() As SettingsMgr
        If instance Is Nothing Then
            instance = New SettingsMgr()
        End If

        Return instance
    End Function

    Public Sub SaveOptions()
        If (_settings IsNot Nothing) Then
            If Not WriteToFile(SettingsPath) Then
                MessageBox.Show("Unable to save settings")
            End If
        End If

    End Sub


    Function LoadFromFile(ByVal path As String) As ToolSettings
        Dim serializer As XmlSerializer
        Dim fs As FileStream = Nothing

        Try
            serializer = New XmlSerializer(GetType(ToolSettings))
            fs = New FileStream(path, FileMode.Open, FileAccess.Read)
            Return CType(serializer.Deserialize(fs), ToolSettings)
        Catch e As Exception
            MsgBox("Fehler: " & e.Message)
            Debug.WriteLine("Exeption on deserializing Options \n" + e.ToString)
            Return Nothing
        Finally
            fs.Close()
            fs = Nothing
            serializer = Nothing
        End Try
    End Function


    Function WriteToFile(path As String) As Boolean
        Dim serializer As XmlSerializer
        Dim writer As StreamWriter = Nothing

        Try
            serializer = New XmlSerializer(GetType(ToolSettings))
            writer = New StreamWriter(path)
            serializer.Serialize(writer, _settings)
            Return True
        Catch e As Exception
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return False
        Finally
            writer.Close()
            writer = Nothing
            serializer = Nothing
        End Try
    End Function

End Class
