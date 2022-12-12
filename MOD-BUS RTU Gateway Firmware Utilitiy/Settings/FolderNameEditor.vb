Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms


Friend Class FolderNameEditor
    Inherits UITypeEditor
    Private ofbd As New FolderBrowserDialog
    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.Modal
    End Function
    Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        If value Is Nothing Then
            value = CStr("")
        End If
        ofbd.SelectedPath = value.ToString()

        If ofbd.ShowDialog() = DialogResult.OK Then
            Return ofbd.SelectedPath
        End If
        Return MyBase.EditValue(context, provider, value)
    End Function
End Class
