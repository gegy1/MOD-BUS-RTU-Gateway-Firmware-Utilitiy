Imports System.IO
Imports System.Management

Public Class FirmwareFile
    Inherits BasicFile

    Public Enum e_HardwareType
        SAMD
        RP2040
    End Enum

    Public Event ReportStatus(message As String)
    Property HardwareType As e_HardwareType = e_HardwareType.SAMD
    Sub New(fileName As String)
        MyBase.New(fileName)
    End Sub

    Const deviceIDString As String = "USB\VID_2341"
    Sub FlashFirmware()
        If Not MsgBox("Make sure your device is connected to the PC by USB." + Environment.NewLine + "Continue flashing?", MsgBoxStyle.OkCancel + MsgBoxStyle.Information) = MsgBoxResult.Ok Then Return
        RaiseEvent ReportStatus("Flashing Firmware start...")
        Try
            Select Case HardwareType
                Case e_HardwareType.SAMD
                    FlashSAMD()
                Case e_HardwareType.RP2040
                    FlashRP2040()
            End Select
        Catch ex As Exception
            RaiseEvent ReportStatus("Error Flashing Firmware")
            RaiseEvent ReportStatus(ex.Message)
        End Try
    End Sub

    Private Sub FlashSAMD()
        If Not File.Exists("openknxproducer\bossac.exe") Then
            RaiseEvent ReportStatus("bossac.exe not found. Please download latest version.") : Return
        End If
        RaiseEvent ReportStatus("Searching for SAMD COM-Port...")
        Dim serialPort As Ports.SerialPort = GetComPort()
        If serialPort Is Nothing Then
            RaiseEvent ReportStatus("Device not found.")
            RaiseEvent ReportStatus("Please try to set the SAMD to bootloader mode and use alternative setup-methode.")
            RaiseEvent ReportStatus("To set the device into bootloader mode click reset button (right button) fastly two times.")
            RaiseEvent ReportStatus("The LED (on the board of the device) will start pulsing. Now the device is in bootloader mode")
            RaiseEvent ReportStatus("Then try to run the flash procedure again.")
            Return
        End If
        RaiseEvent ReportStatus($"Found device on {serialPort.PortName}.")
        'Taken from the original powershell script
        'This sets the device to bootloader mode 
        serialPort.Open()
        serialPort.Close()
        System.Threading.Thread.Sleep(5000)
        serialPort = GetComPort()
        RaiseEvent ReportStatus("Writing firmware to device...")
        If WriteFirmware(serialPort) Then
            RaiseEvent ReportStatus("Writing firmware to device... done!")
            RaiseEvent ReportStatus("You can now disconnect the device from USB Port")
        Else
            RaiseEvent ReportStatus("Could not flash firmware because of timeout in connecting to the device.")
            RaiseEvent ReportStatus("Is device in bootloader mode?")
        End If
    End Sub

    Private Sub FlashRP2040()
        Throw New NotImplementedException

        ''''''POWERShell Flash code''''''
        'Import-Module BitsTransfer

        '$firmwareName = $args[0]

        'Write-Host "Suche RP2040 im BOOTSEL-Modus (das kann einige Zeit dauern)..."
        '$device=$(Get-WmiObject Win32_LogicalDisk | Where-Object { $_.VolumeName -match "RPI-RP2" })
        'If (!$device)
        '{
        '    Write-Host "Keinen RP2040 im BOOTSEL-Modus gefunden."
        '    Write-Host "Alternative: Suche COM-Port fuer RP2040 (auch das kann etwas dauern)..."
        '    $portList = get-pnpdevice -class Ports
        '    If ($portList) {
        '        foreach($usbDevice in $portList) {
        '            If ($usbDevice.Present) {
        '                $isPico = $usbDevice.InstanceId.StartsWith("USB\VID_2E8A")
        '                # $isCom = $usbDevice.Name -match "USB.*\((COM\d{1,3})\)"
        '                $isCom = $usbDevice.Name -match "COM\d{1,3}"
        '                If ($isPico)
        '                {
        '                    # $port = $Matches[1]
        '                    $port = $Matches[0]
        '                    Write-Host "COM-Port Gefunden: $port"
        '                    break
        '                }
        '            }
        '        }
        '        If ($port)
        '        {
        '            Write-Host "Versuche den RP2040 ueber Port $port in den BOOTSEL-Modus zu versetzen..."
        '            $serial = New-Object System.IO.Ports.SerialPort $port,1200,None,8,1
        '            Try { $serial.Open()} Catch {}
        '            $serial.Close()
        '            # mode ${port}: BAUD=1200 parity=N data=8 Stop=1 | Out-Null
        '            Start-Sleep -s 1
        '            # ./rp2040load.exe -v -D firmware
        '            $device=$(Get-WmiObject Win32_LogicalDisk | Where-Object { $_.VolumeName -match "RPI-RP2" })
        '        }
        '    }
        '}
        'If ($device)
        '{
        '    Write-Host "RP2040 gefunden, installiere Firmware..."
        '    # There are different options how to copy a large file, but most of them have side effects

        '    # the following one prints very often errors AFTER the file was copied 
        '    # Start-BitsTransfer -Source data/$firmwareName -Destination $device.DeviceID.ToString() -Description "Installiere" -DisplayName "Installiere Firmware..."

        '    # the following has no progress bar
        '    # Copy-Item data/$firmwareName $device.DeviceID.ToString()

        '    # the following Is just Windows based, Not pure PowerShell
        '    # cmd /c copy /z data\$firmwareName $device.DeviceID.ToString()

        '    # the following Is just windows but looks best...
        '    $FOF_CREATEPROGRESSDLG = "&H0&"
        '    $currentDir = (Get-Item .).FullName
        '    $objShell = New-Object -ComObject "Shell.Application"
        '    $objFolder = $objShell.NameSpace($device.DeviceID.ToString()) 
        '    $objFolder.CopyHere("$currentDir\data\$firmwareName", $FOF_CREATEPROGRESSDLG)
        '    Write-Host Fertig!
        '    timeout / T 20 
        '}
        'Else
        '{
        '    Write-Host 
        '    Write-Host "Kein RP2040 gefunden!"
        '    Write-Host 
        '    Write-Host "Versuche bitte die manuelle Setup-Methode: Den RP2040 selber im BOOTSEL-Modus zu starten"
        '    Write-Host "Falls die Hardware eine Reset-Taste hat, dann erst die BOOTSEL-Taste drÃƒÂ¼cken und halten,"
        '    Write-Host "und dann zusaetzlich die Reset-Taste druecken. Dann beide Tasten loslassen."
        '    Write-Host "Ohne Reset-Taste das Geraet stromlos machen (USB-Stecker ziehen und vom KNX trennen),"
        '    Write-Host "Danach die BOOTSEL-Taste druecken und gleichzeitig USB mit dem Recner verbinden."
        '    Write-Host "Jetzt befindet sich das Geraet im BOOTSEL-Modus, die BOOTSEL-Taste kann jetzt losgelassen werden."
        '    Write-Host "Anschliessend das Skript erneut starten."
        '    timeout / T 60     
        '}

    End Sub

    Function GetComPort() As Ports.SerialPort
        Dim path As ManagementPath = New ManagementPath()
        path.Server = "."
        path.NamespacePath = "root\CIMV2"
        Dim scope As ManagementScope = New ManagementScope(path)
        Dim query As ObjectQuery = New ObjectQuery("SELECT * FROM Win32_SerialPort")
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, query)
        Dim queryCollection As ManagementObjectCollection = searcher.Get()
        Dim m As ManagementObject
        If queryCollection.Count = 0 Then Return Nothing
        Dim comPortName As String = ""
        For Each m In queryCollection
            If m("DeviceID") Is Nothing Or m("PNPDeviceID") Is Nothing Then Continue For
            Console.WriteLine($"Device Name : {m("Name")} DeviceID: {m("DeviceID")} PNPDeviceID: {m("PNPDeviceID")}")
            If m("PNPDeviceID").ToString.StartsWith(deviceIDString) Then
                comPortName = m("DeviceID").ToString
            End If
        Next
        If comPortName = "" Then Return Nothing
        Return New Ports.SerialPort(comPortName, 1200, Ports.Parity.None, 8, Ports.StopBits.One)
    End Function

    Function WriteFirmware(serialPort As Ports.SerialPort) As Boolean
        Dim pi As New ProcessStartInfo
        With pi
            .FileName = "openknxproducer\bossac.exe"
            .Arguments = $"--info --write --verify --reset --erase --port={serialPort.PortName} ""{Me.FileName}"""
            .RedirectStandardOutput = True
            .RedirectStandardError = True
            .RedirectStandardInput = True
            .UseShellExecute = False
            .WindowStyle = ProcessWindowStyle.Maximized
            .CreateNoWindow = True
        End With
        Dim p As New System.Diagnostics.Process With {.StartInfo = pi}
        AddHandler p.ErrorDataReceived, AddressOf Me.OutputHandler
        AddHandler p.OutputDataReceived, AddressOf Me.OutputHandler
        p.Start()
        p.BeginOutputReadLine()
        Dim regularProcessExit As Boolean
        regularProcessExit = p.WaitForExit(30000)
        Return regularProcessExit
    End Function

    Private Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        If Not String.IsNullOrEmpty(outLine.Data) Then
            If Not outLine.Data.StartsWith("[") Then
                RaiseEvent ReportStatus(outLine.Data)
            End If
        End If
    End Sub

End Class
