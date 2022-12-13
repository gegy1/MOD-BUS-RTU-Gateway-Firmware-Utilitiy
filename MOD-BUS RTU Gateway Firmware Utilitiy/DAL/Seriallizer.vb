Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

<ComVisible(False)>
Public Class Seriallizer(Of T)
    Property ShowMessages As Boolean = True

    Function SerializeObjToString(obj As T)
        Dim serializer As XmlSerializer
        Dim memStream As New MemoryStream
        Dim xmlWriter As New XmlTextWriter(memStream, Encoding.UTF8)
        Try
            serializer = New XmlSerializer(GetType(T))
            serializer.Serialize(xmlWriter, obj)
            Dim xml As String
            xml = Encoding.UTF8.GetString(memStream.GetBuffer)
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)))
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1))
            Return xml
        Catch e As Exception
            If ShowMessages Then
                MsgBox($"Error writing data to definition file: {e.Message}")
            End If
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return False
        Finally
            xmlWriter.Close()
            memStream.Close()
            xmlWriter = Nothing
            serializer = Nothing
            memStream = Nothing
        End Try
    End Function

    Function DeSerializeObjFromString(xml As String) As T
        Dim serializer As XmlSerializer
        Dim stringReader As New StringReader(xml)
        If xml = "" Then Return Nothing
        Try
            serializer = New XmlSerializer(GetType(T))
            Return CType(serializer.Deserialize(stringReader), T)
        Catch e As Exception
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return Nothing
        Finally
            stringReader.Close()
            stringReader = Nothing
            serializer = Nothing
        End Try
    End Function

    Function SerializeListToFile(list As List(Of T), fileName As String)
        Dim serializer As XmlSerializer
        Dim writer As StreamWriter = Nothing
        Try
            serializer = New XmlSerializer(GetType(List(Of T)))
            writer = New StreamWriter(fileName)
            serializer.Serialize(writer, list)
            Return True
        Catch e As Exception
            If ShowMessages Then
                MsgBox($"Error writing data to definition file: {e.Message}")
            End If
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return False
        Finally
            writer.Close()
            writer = Nothing
            serializer = Nothing
        End Try
    End Function

    Function DeSerializeListFromFile(fileName As String) As List(Of T)
        Dim serializer As XmlSerializer
        Dim fs As FileStream = Nothing
        If Not System.IO.File.Exists(fileName) Then Return New List(Of T)
        Try
            serializer = New XmlSerializer(GetType(List(Of T)))
            fs = New FileStream(fileName, FileMode.Open, FileAccess.Read)
            Return CType(serializer.Deserialize(fs), List(Of T))
        Catch e As Exception
            If ShowMessages Then
                MsgBox($"Error reading data from file: {e.Message}")
            End If
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return New List(Of T)
        Finally
            fs.Close()
            fs = Nothing
            serializer = Nothing
        End Try
    End Function

    Function SerializeObjToFile(obj As T, fileName As String)
        Dim serializer As XmlSerializer
        Dim writer As StreamWriter = Nothing
        Try
            serializer = New XmlSerializer(GetType(T))
            writer = New StreamWriter(fileName)
            serializer.Serialize(writer, obj)
            Return True
        Catch e As Exception
            If ShowMessages Then
                MsgBox($"Error writing data to definition file: {e.Message}")
            End If
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return False
        Finally
            writer.Close()
            writer = Nothing
            serializer = Nothing
        End Try
    End Function

    Function DeSerializeObjFromFile(fileName As String) As T
        Dim serializer As XmlSerializer
        Dim fs As FileStream = Nothing
        If Not System.IO.File.Exists(fileName) Then Return Nothing
        Try
            serializer = New XmlSerializer(GetType(T))
            fs = New FileStream(fileName, FileMode.Open, FileAccess.Read)
            Return CType(serializer.Deserialize(fs), T)
        Catch e As Exception
            Debug.WriteLine("Exeption on serializing Options \n" + e.ToString)
            Return Nothing
        Finally
            fs.Close()
            fs = Nothing
            serializer = Nothing
        End Try
    End Function
End Class
