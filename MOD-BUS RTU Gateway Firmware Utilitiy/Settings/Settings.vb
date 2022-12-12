Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Serialization

Imports System.Reflection


'Settings Klasse, welche in Kombination mit dem SettingsMgr für Projekteinstellungen verwendet werden kann.
'Dazu die Properties anpassen, löschen oder neue hinzufügen. Die Properties können auch Gruppiert werden.
'
'Info von M$: https://msdn.microsoft.com/en-us/library/aa302326.aspx
'DescriptionAttribute.Sets the text for the property that Is displayed in the description help pane below the properties. This Is a useful way to provide help text for the active property (the property that has focus). Apply this attribute to the MaxRepeatRate property.
'CategoryAttribute.Sets the category that the Property Is under In the grid. This Is useful When you want a Property grouped by a category name. If a Property does Not have a category specified, then it will be assigned to the Misc category. Apply this attribute to all properties.
'BrowsableAttribute – Indicates whether the Property Is shown In the grid. This Is useful When you want To hide a Property from the grid. By Default, a Public Property Is always shown In the grid. Apply this attribute To the SettingsChanged Property.
'ReadOnlyAttribute – Indicates whether the Property Is read-only. This Is useful When you want To keep a Property from being editable In the grid. By Default, a Public Property With Get And Set accessor functions Is editable In the grid. Apply this attribute To the AppVersion Property.
'DefaultValueAttribute – Identifies the Property's default value. This is useful when you want to provide a default value for a property and later determine if the property's value is different than the default. Apply this attribute to all properties.
'DefaultPropertyAttribute – Identifies the Default Property For the Class. The Default Property For a Class gets the focus first When the Class Is selected In the grid. Apply this attribute To the AppSettings Class.


Public Class ToolSettings
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

#Region "Setting Variables"


#Region "10 - Settings"
    <DisplayName("Open KNX Folder"),
        Description("Folder where Open KNX producer files stored (bossac.exe, OpenKNXprosuder.exe)"),
        Category("Open KNX Producer"), Editor(GetType(FolderNameEditor), GetType(System.Drawing.Design.UITypeEditor))>
    Public Property AutomaticExportPathName As String = My.Application.Info.DirectoryPath + "\openknxproducer"
#End Region

    Protected Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub
    Private Sub UpdateBrowsableWhenChanged(attribute As String, changeValue As Object)
        Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(Me.[GetType]())(attribute)
        Dim attrib As BrowsableAttribute = CType(descriptor.Attributes(GetType(BrowsableAttribute)), BrowsableAttribute)
        If Not attrib Is Nothing Then
            Dim isBrow As FieldInfo = attrib.[GetType]().GetField("browsable", BindingFlags.NonPublic Or BindingFlags.Instance)
            isBrow.SetValue(attrib, changeValue)
        End If
    End Sub

#End Region


#Region "Constructor"
    Public Sub New()

    End Sub
#End Region


End Class
