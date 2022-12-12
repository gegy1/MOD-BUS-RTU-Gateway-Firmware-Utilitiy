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
        Me.KNXxmlFileTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SelectKNXProdXMLButton = New System.Windows.Forms.Button()
        Me.CreateKNXProdFileButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FirmwareFileTextBox = New System.Windows.Forms.TextBox()
        Me.SelectFirmwareButton = New System.Windows.Forms.Button()
        Me.FlashFirmwareButton = New System.Windows.Forms.Button()
        Me.LoadLatestButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.StautsTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 441)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(544, 29)
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
        Me.Cancel_Button.Location = New System.Drawing.Point(477, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(64, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Close"
        '
        'KNXxmlFileTextBox
        '
        Me.KNXxmlFileTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.KNXxmlFileTextBox.Location = New System.Drawing.Point(96, 5)
        Me.KNXxmlFileTextBox.Name = "KNXxmlFileTextBox"
        Me.KNXxmlFileTextBox.ReadOnly = True
        Me.KNXxmlFileTextBox.Size = New System.Drawing.Size(266, 20)
        Me.KNXxmlFileTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "KNXPROD Xml"
        '
        'SelectKNXProdXMLButton
        '
        Me.SelectKNXProdXMLButton.Location = New System.Drawing.Point(372, 3)
        Me.SelectKNXProdXMLButton.Name = "SelectKNXProdXMLButton"
        Me.SelectKNXProdXMLButton.Size = New System.Drawing.Size(28, 23)
        Me.SelectKNXProdXMLButton.TabIndex = 3
        Me.SelectKNXProdXMLButton.Text = "..."
        Me.SelectKNXProdXMLButton.UseVisualStyleBackColor = True
        '
        'CreateKNXProdFileButton
        '
        Me.CreateKNXProdFileButton.Location = New System.Drawing.Point(453, 3)
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
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.88889!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CreateKNXProdFileButton, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.KNXxmlFileTextBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.SelectKNXProdXMLButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FirmwareFileTextBox, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.SelectFirmwareButton, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FlashFirmwareButton, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LoadLatestButton, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(550, 98)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'FirmwareFileTextBox
        '
        Me.FirmwareFileTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.FirmwareFileTextBox.Location = New System.Drawing.Point(96, 35)
        Me.FirmwareFileTextBox.Name = "FirmwareFileTextBox"
        Me.FirmwareFileTextBox.ReadOnly = True
        Me.FirmwareFileTextBox.Size = New System.Drawing.Size(266, 20)
        Me.FirmwareFileTextBox.TabIndex = 1
        '
        'SelectFirmwareButton
        '
        Me.SelectFirmwareButton.Location = New System.Drawing.Point(372, 33)
        Me.SelectFirmwareButton.Name = "SelectFirmwareButton"
        Me.SelectFirmwareButton.Size = New System.Drawing.Size(28, 23)
        Me.SelectFirmwareButton.TabIndex = 3
        Me.SelectFirmwareButton.Text = "..."
        Me.SelectFirmwareButton.UseVisualStyleBackColor = True
        '
        'FlashFirmwareButton
        '
        Me.FlashFirmwareButton.Location = New System.Drawing.Point(453, 33)
        Me.FlashFirmwareButton.Name = "FlashFirmwareButton"
        Me.FlashFirmwareButton.Size = New System.Drawing.Size(91, 23)
        Me.FlashFirmwareButton.TabIndex = 4
        Me.FlashFirmwareButton.Text = "Flash Firmware"
        Me.FlashFirmwareButton.UseVisualStyleBackColor = True
        '
        'LoadLatestButton
        '
        Me.LoadLatestButton.Location = New System.Drawing.Point(453, 63)
        Me.LoadLatestButton.Name = "LoadLatestButton"
        Me.LoadLatestButton.Size = New System.Drawing.Size(91, 23)
        Me.LoadLatestButton.TabIndex = 5
        Me.LoadLatestButton.Text = "Load latest"
        Me.LoadLatestButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Firmware"
        '
        'StautsTextBox
        '
        Me.StautsTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StautsTextBox.Location = New System.Drawing.Point(3, 28)
        Me.StautsTextBox.Multiline = True
        Me.StautsTextBox.Name = "StautsTextBox"
        Me.StautsTextBox.ReadOnly = True
        Me.StautsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StautsTextBox.Size = New System.Drawing.Size(543, 288)
        Me.StautsTextBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Status"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.StautsTextBox, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(13, 116)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 294.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(549, 319)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(574, 482)
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
    Friend WithEvents KNXxmlFileTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SelectKNXProdXMLButton As Button
    Friend WithEvents CreateKNXProdFileButton As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents FirmwareFileTextBox As TextBox
    Friend WithEvents SelectFirmwareButton As Button
    Friend WithEvents FlashFirmwareButton As Button
    Friend WithEvents StautsTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LoadLatestButton As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
End Class
