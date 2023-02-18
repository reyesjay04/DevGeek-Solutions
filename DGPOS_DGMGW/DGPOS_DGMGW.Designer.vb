<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DGPOS_DGMGW
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFromReportingDate = New System.Windows.Forms.DateTimePicker()
        Me.btnDiscount = New System.Windows.Forms.Button()
        Me.btnHourly = New System.Windows.Forms.Button()
        Me.btnDaily = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTerminalNumber = New System.Windows.Forms.TextBox()
        Me.txtRetailCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDateFormat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudRetaillength = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpBDEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpBDStart = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerateAll = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpToReportingDate = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.nudRetaillength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(383, 355)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtpToReportingDate)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnGenerateAll)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dtpFromReportingDate)
        Me.TabPage1.Controls.Add(Me.btnDiscount)
        Me.TabPage1.Controls.Add(Me.btnHourly)
        Me.TabPage1.Controls.Add(Me.btnDaily)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage1.Size = New System.Drawing.Size(375, 327)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generate"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SELECT TYPE OF REPORT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SELECT REPORTING DATE"
        '
        'dtpFromReportingDate
        '
        Me.dtpFromReportingDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtpFromReportingDate.CustomFormat = ""
        Me.dtpFromReportingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtpFromReportingDate.Location = New System.Drawing.Point(73, 48)
        Me.dtpFromReportingDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFromReportingDate.Name = "dtpFromReportingDate"
        Me.dtpFromReportingDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpFromReportingDate.Size = New System.Drawing.Size(267, 21)
        Me.dtpFromReportingDate.TabIndex = 1
        '
        'btnDiscount
        '
        Me.btnDiscount.Location = New System.Drawing.Point(30, 226)
        Me.btnDiscount.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnDiscount.Name = "btnDiscount"
        Me.btnDiscount.Size = New System.Drawing.Size(310, 36)
        Me.btnDiscount.TabIndex = 0
        Me.btnDiscount.Text = "Generate Discount Report"
        Me.btnDiscount.UseVisualStyleBackColor = True
        '
        'btnHourly
        '
        Me.btnHourly.Location = New System.Drawing.Point(30, 184)
        Me.btnHourly.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnHourly.Name = "btnHourly"
        Me.btnHourly.Size = New System.Drawing.Size(310, 36)
        Me.btnHourly.TabIndex = 0
        Me.btnHourly.Text = "Generate Hourly Sales"
        Me.btnHourly.UseVisualStyleBackColor = True
        '
        'btnDaily
        '
        Me.btnDaily.Location = New System.Drawing.Point(30, 141)
        Me.btnDaily.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnDaily.Name = "btnDaily"
        Me.btnDaily.Size = New System.Drawing.Size(310, 36)
        Me.btnDaily.TabIndex = 0
        Me.btnDaily.Text = "Generate Daily Sales"
        Me.btnDaily.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtTerminalNumber)
        Me.TabPage2.Controls.Add(Me.txtRetailCode)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtDateFormat)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.nudRetaillength)
        Me.TabPage2.Controls.Add(Me.btnSave)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtpBDEnd)
        Me.TabPage2.Controls.Add(Me.dtpBDStart)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TabPage2.Size = New System.Drawing.Size(375, 327)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Options"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 118)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 15)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Terminal No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 91)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Retail Code"
        '
        'txtTerminalNumber
        '
        Me.txtTerminalNumber.Location = New System.Drawing.Point(147, 115)
        Me.txtTerminalNumber.Name = "txtTerminalNumber"
        Me.txtTerminalNumber.Size = New System.Drawing.Size(199, 21)
        Me.txtTerminalNumber.TabIndex = 10
        '
        'txtRetailCode
        '
        Me.txtRetailCode.Location = New System.Drawing.Point(147, 88)
        Me.txtRetailCode.Name = "txtRetailCode"
        Me.txtRetailCode.Size = New System.Drawing.Size(199, 21)
        Me.txtRetailCode.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 64)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Date Format"
        '
        'txtDateFormat
        '
        Me.txtDateFormat.Location = New System.Drawing.Point(147, 61)
        Me.txtDateFormat.Name = "txtDateFormat"
        Me.txtDateFormat.Size = New System.Drawing.Size(199, 21)
        Me.txtDateFormat.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 148)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Retail Code Length"
        '
        'nudRetaillength
        '
        Me.nudRetaillength.Location = New System.Drawing.Point(221, 142)
        Me.nudRetaillength.Name = "nudRetaillength"
        Me.nudRetaillength.Size = New System.Drawing.Size(125, 21)
        Me.nudRetaillength.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(31, 182)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(315, 36)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 36)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Business Hours"
        '
        'dtpBDEnd
        '
        Me.dtpBDEnd.CalendarFont = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBDEnd.CustomFormat = "hh:59 tt"
        Me.dtpBDEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBDEnd.Location = New System.Drawing.Point(266, 34)
        Me.dtpBDEnd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpBDEnd.Name = "dtpBDEnd"
        Me.dtpBDEnd.ShowUpDown = True
        Me.dtpBDEnd.Size = New System.Drawing.Size(80, 21)
        Me.dtpBDEnd.TabIndex = 0
        '
        'dtpBDStart
        '
        Me.dtpBDStart.CalendarFont = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBDStart.CustomFormat = "hh:00 tt"
        Me.dtpBDStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBDStart.Location = New System.Drawing.Point(147, 34)
        Me.dtpBDStart.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpBDStart.Name = "dtpBDStart"
        Me.dtpBDStart.ShowUpDown = True
        Me.dtpBDStart.Size = New System.Drawing.Size(80, 21)
        Me.dtpBDStart.TabIndex = 0
        '
        'btnGenerateAll
        '
        Me.btnGenerateAll.Location = New System.Drawing.Point(30, 268)
        Me.btnGenerateAll.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnGenerateAll.Name = "btnGenerateAll"
        Me.btnGenerateAll.Size = New System.Drawing.Size(310, 36)
        Me.btnGenerateAll.TabIndex = 3
        Me.btnGenerateAll.Text = "Generate All"
        Me.btnGenerateAll.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "From:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "To:"
        '
        'dtpToReportingDate
        '
        Me.dtpToReportingDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtpToReportingDate.CustomFormat = ""
        Me.dtpToReportingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtpToReportingDate.Location = New System.Drawing.Point(73, 75)
        Me.dtpToReportingDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToReportingDate.Name = "dtpToReportingDate"
        Me.dtpToReportingDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpToReportingDate.Size = New System.Drawing.Size(267, 21)
        Me.dtpToReportingDate.TabIndex = 6
        '
        'DGPOS_DGMGW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(383, 355)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DGPOS_DGMGW"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Megawolrd Reporting Module"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.nudRetaillength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtpFromReportingDate As DateTimePicker
    Friend WithEvents btnDiscount As Button
    Friend WithEvents btnHourly As Button
    Friend WithEvents btnDaily As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpBDEnd As DateTimePicker
    Friend WithEvents dtpBDStart As DateTimePicker
    Friend WithEvents btnSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudRetaillength As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDateFormat As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTerminalNumber As TextBox
    Friend WithEvents txtRetailCode As TextBox
    Friend WithEvents btnGenerateAll As Button
    Friend WithEvents dtpToReportingDate As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
End Class
