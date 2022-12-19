Imports System.Xml.Serialization

Public Class Firmware
    Public Enum e_deviceClass
        OAM ' - OpenKNX Application Module
        OFM ' - OpenKNX Function Module
        OGM ' - OpenKNX Generic Module
        TAS ' - Taster
        SA '- Schaltaktor
        JA '- Jalousieaktor
        HA '- Heizungsaktor
        GW '- Gateway
        VIS '- Visualisierung
        _DIM '- 230V Dimmer
        LED '- LED-Controller
        BE '- Binäreingang
        SYS '- Systemgeräte IP USB SER
        SEN '- Sensor-Modul
        BM '- Bewegungsmelder
        PM '- Präsenzmelder
        VPM '- Virtueller Präsenzmelder
        LM '- Logik-Modul
        BEM '- Bewässerungsmodul
        NotSupported
    End Enum
    Property Name As String
    Property LatestVersion As String
    <XmlIgnore>
    Property GitRepo As GitRepo
    <XmlIgnore>
    Property DeviceClass As e_deviceClass
    Property PossibleHardware As List(Of Hardware) = New List(Of Hardware)
    Private displayNameValue As String = ""
    <XmlElement("FriendlyName")>
    Property DisplayName As String

    Sub New(name As String, repo As GitRepo)
        Me.Name = name
        Me.DisplayName = name
        Me.GitRepo = repo
    End Sub
    Sub New()

    End Sub
End Class
