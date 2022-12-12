<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupPage
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.Location = New System.Drawing.Point(3, 3)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(578, 288)
        Me.PropertyGrid1.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(4, 298)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(131, 23)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "Export Options..."
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(141, 298)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(131, 23)
        Me.btnImport.TabIndex = 1
        Me.btnImport.Text = "Import Options..."
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(450, 298)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(131, 23)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "Reset Options"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'SetupPage
        '
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Name = "SetupPage"
        Me.Size = New System.Drawing.Size(584, 336)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PropertyGrid1 As Windows.Forms.PropertyGrid
    Friend WithEvents btnExport As Windows.Forms.Button
    Friend WithEvents btnImport As Windows.Forms.Button
    Friend WithEvents btnReset As Windows.Forms.Button
End Class
