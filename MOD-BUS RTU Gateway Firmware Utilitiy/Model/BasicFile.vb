Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.CompilerServices

Public MustInherit Class BasicFile
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    ReadOnly Property Id As Guid

    Private fileNameValue As String = ""
    <RefreshProperties(RefreshProperties.All)>
    Property FileName As String
        Get
            Return Me.fileNameValue
        End Get
        Set(value As String)
            If Not Me.fileNameValue = value Then
                Me.fileNameValue = value
                NotifyOfPropertyChange("FileNameOnly")
            End If
        End Set
    End Property

    ReadOnly Property Exists As Boolean
        Get
            Return File.Exists(Me.FileName)
        End Get
    End Property
    ReadOnly Property TextBinding As Binding
    ReadOnly Property EnableBinding As Binding

    ReadOnly Property FileNameOnly As String
        Get
            Return Path.GetFileName(FileName)
        End Get
    End Property
    Sub New(filename As String)
        Me.TextBinding = New Binding("Text", Me, "FileNameOnly", False, DataSourceUpdateMode.OnPropertyChanged)
        Me.EnableBinding = New Binding("Enabled", Me, "Exists", False, DataSourceUpdateMode.OnPropertyChanged)
        Me.FileName = filename
        Me.Id = Guid.NewGuid
    End Sub



    Private Sub NotifyOfPropertyChange(<CallerMemberName> Optional propertyName As String = Nothing)
        If propertyName Is Nothing Then
            Return
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
