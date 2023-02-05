<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TransactionTypeInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransactionTypeInfo))
        Me.TextBoxFULLNAME = New System.Windows.Forms.TextBox()
        Me.TextBoxREFERENCE = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonKeyboard = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxFULLNAME
        '
        Me.TextBoxFULLNAME.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxFULLNAME.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TextBoxFULLNAME.Location = New System.Drawing.Point(8, 22)
        Me.TextBoxFULLNAME.Name = "TextBoxFULLNAME"
        Me.TextBoxFULLNAME.Size = New System.Drawing.Size(304, 14)
        Me.TextBoxFULLNAME.TabIndex = 0
        '
        'TextBoxREFERENCE
        '
        Me.TextBoxREFERENCE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxREFERENCE.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TextBoxREFERENCE.Location = New System.Drawing.Point(8, 64)
        Me.TextBoxREFERENCE.Name = "TextBoxREFERENCE"
        Me.TextBoxREFERENCE.Size = New System.Drawing.Size(304, 14)
        Me.TextBoxREFERENCE.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(8, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(233, 25)
        Me.Button2.TabIndex = 103
        Me.Button2.Text = "Submit"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Full Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(5, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Reference Number"
        '
        'ButtonKeyboard
        '
        Me.ButtonKeyboard.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonKeyboard.BackgroundImage = CType(resources.GetObject("ButtonKeyboard.BackgroundImage"), System.Drawing.Image)
        Me.ButtonKeyboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonKeyboard.FlatAppearance.BorderSize = 0
        Me.ButtonKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKeyboard.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.ButtonKeyboard.Location = New System.Drawing.Point(247, 88)
        Me.ButtonKeyboard.Name = "ButtonKeyboard"
        Me.ButtonKeyboard.Size = New System.Drawing.Size(65, 25)
        Me.ButtonKeyboard.TabIndex = 240
        Me.ButtonKeyboard.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label21.Location = New System.Drawing.Point(5, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(307, 13)
        Me.Label21.TabIndex = 264
        Me.Label21.Text = "__________________________________________________"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(5, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(307, 13)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "__________________________________________________"
        '
        'TransactionTypeInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(325, 126)
        Me.Controls.Add(Me.ButtonKeyboard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxFULLNAME)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBoxREFERENCE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label21)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TransactionTypeInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS | TRN. INFO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxFULLNAME As TextBox
    Friend WithEvents TextBoxREFERENCE As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonKeyboard As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents Label3 As Label
End Class
