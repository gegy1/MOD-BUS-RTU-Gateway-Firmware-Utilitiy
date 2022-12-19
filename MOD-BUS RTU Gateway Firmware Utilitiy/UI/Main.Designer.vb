<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CreateKNXProdFileButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlashFirmwareButton = New System.Windows.Forms.Button()
        Me.FirmwaresComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.SettingsButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 465)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(550, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'SettingsButton
        '
        Me.SettingsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SettingsButton.Location = New System.Drawing.Point(3, 3)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(64, 23)
        Me.SettingsButton.TabIndex = 1
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.Visible = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(483, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(64, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(413, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Test"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CreateKNXProdFileButton
        '
        Me.CreateKNXProdFileButton.Location = New System.Drawing.Point(451, 3)
        Me.CreateKNXProdFileButton.Name = "CreateKNXProdFileButton"
        Me.CreateKNXProdFileButton.Size = New System.Drawing.Size(91, 23)
        Me.CreateKNXProdFileButton.TabIndex = 4
        Me.CreateKNXProdFileButton.Text = "Create knxprod"
        Me.CreateKNXProdFileButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.69453!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.305475!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CreateKNXProdFileButton, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FirmwaresComboBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlashFirmwareButton, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(551, 62)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Firmwares"
        '
        'FlashFirmwareButton
        '
        Me.FlashFirmwareButton.Location = New System.Drawing.Point(451, 33)
        Me.FlashFirmwareButton.Name = "FlashFirmwareButton"
        Me.FlashFirmwareButton.Size = New System.Drawing.Size(91, 23)
        Me.FlashFirmwareButton.TabIndex = 4
        Me.FlashFirmwareButton.Text = "Flash Firmware"
        Me.FlashFirmwareButton.UseVisualStyleBackColor = True
        '
        'FirmwaresComboBox
        '
        Me.FirmwaresComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FirmwaresComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FirmwaresComboBox.FormattingEnabled = True
        Me.FirmwaresComboBox.Location = New System.Drawing.Point(96, 4)
        Me.FirmwaresComboBox.Name = "FirmwaresComboBox"
        Me.FirmwaresComboBox.Size = New System.Drawing.Size(333, 21)
        Me.FirmwaresComboBox.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Information"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.StatusWebBrowser, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(12, 80)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 294.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(551, 379)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'StatusWebBrowser
        '
        Me.StatusWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusWebBrowser.Location = New System.Drawing.Point(3, 28)
        Me.StatusWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.StatusWebBrowser.Name = "StatusWebBrowser"
        Me.StatusWebBrowser.Size = New System.Drawing.Size(545, 348)
        Me.StatusWebBrowser.TabIndex = 8
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(575, 506)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MOD-BUS RTU Gateway Firmware Utilitiy (BETA)"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents SettingsButton As Button
    Friend WithEvents CreateKNXProdFileButton As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents FlashFirmwareButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents FirmwaresComboBox As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents StatusWebBrowser As WebBrowser
End Class
