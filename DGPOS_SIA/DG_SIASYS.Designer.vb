<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DG_SIASYS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txttrxheader = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttrxdetail = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtsalestype = New System.Windows.Forms.TextBox()
        Me.txtfilepath = New System.Windows.Forms.TextBox()
        Me.txtserialnumber = New System.Windows.Forms.TextBox()
        Me.txtterminal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.txtsalestype)
        Me.TabPage2.Controls.Add(Me.txtfilepath)
        Me.TabPage2.Controls.Add(Me.txtserialnumber)
        Me.TabPage2.Controls.Add(Me.txtterminal)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage2.Size = New System.Drawing.Size(371, 330)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txttrxheader)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txttrxdetail)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 134)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Name"
        '
        'txttrxheader
        '
        Me.txttrxheader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrxheader.Location = New System.Drawing.Point(25, 51)
        Me.txttrxheader.Name = "txttrxheader"
        Me.txttrxheader.Size = New System.Drawing.Size(286, 21)
        Me.txttrxheader.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 75)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Transaction Details"
        '
        'txttrxdetail
        '
        Me.txttrxdetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrxdetail.Location = New System.Drawing.Point(25, 93)
        Me.txttrxdetail.Name = "txttrxdetail"
        Me.txttrxdetail.Size = New System.Drawing.Size(286, 21)
        Me.txttrxdetail.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Transaction Header"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "(Double click to browse path)"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(19, 284)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(338, 36)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtsalestype
        '
        Me.txtsalestype.Location = New System.Drawing.Point(121, 117)
        Me.txtsalestype.Name = "txtsalestype"
        Me.txtsalestype.Size = New System.Drawing.Size(236, 21)
        Me.txtsalestype.TabIndex = 16
        '
        'txtfilepath
        '
        Me.txtfilepath.Location = New System.Drawing.Point(121, 75)
        Me.txtfilepath.Name = "txtfilepath"
        Me.txtfilepath.ReadOnly = True
        Me.txtfilepath.Size = New System.Drawing.Size(236, 21)
        Me.txtfilepath.TabIndex = 15
        '
        'txtserialnumber
        '
        Me.txtserialnumber.Location = New System.Drawing.Point(121, 48)
        Me.txtserialnumber.Name = "txtserialnumber"
        Me.txtserialnumber.Size = New System.Drawing.Size(236, 21)
        Me.txtserialnumber.TabIndex = 14
        '
        'txtterminal
        '
        Me.txtterminal.Location = New System.Drawing.Point(121, 21)
        Me.txtterminal.Name = "txtterminal"
        Me.txtterminal.Size = New System.Drawing.Size(236, 21)
        Me.txtterminal.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 117)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Sales Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 75)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "File Path"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 48)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Serial Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 21)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Terminal ID"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(379, 358)
        Me.TabControl1.TabIndex = 1
        '
        'DG_SIASYS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 358)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(395, 397)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(395, 397)
        Me.Name = "DG_SIASYS"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIA SYSTEMS"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtsalestype As TextBox
    Friend WithEvents txtfilepath As TextBox
    Friend WithEvents txtserialnumber As TextBox
    Friend WithEvents txtterminal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txttrxdetail As TextBox
    Friend WithEvents txttrxheader As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
