<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApplyGC
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvGC = New System.Windows.Forms.DataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBBase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBBVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.dgvGC)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 331)
        Me.GroupBox1.TabIndex = 210
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gift Cheque"
        '
        'dgvGC
        '
        Me.dgvGC.AllowUserToAddRows = False
        Me.dgvGC.AllowUserToDeleteRows = False
        Me.dgvGC.AllowUserToResizeColumns = False
        Me.dgvGC.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvGC.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGC.BackgroundColor = System.Drawing.Color.White
        Me.dgvGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colName, Me.colDesc, Me.colDiscVal, Me.colRefVal, Me.colType, Me.colBBase, Me.colBBVal, Me.colBP, Me.colBPVal, Me.Column11, Me.Column12})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGC.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvGC.EnableHeadersVisualStyles = False
        Me.dgvGC.Location = New System.Drawing.Point(3, 18)
        Me.dgvGC.Name = "dgvGC"
        Me.dgvGC.RowHeadersVisible = False
        Me.dgvGC.Size = New System.Drawing.Size(623, 310)
        Me.dgvGC.TabIndex = 207
        '
        'colID
        '
        Me.colID.HeaderText = "Column1"
        Me.colID.Name = "colID"
        Me.colID.Visible = False
        '
        'colName
        '
        Me.colName.HeaderText = "Name"
        Me.colName.Name = "colName"
        '
        'colDesc
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDesc.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDesc.HeaderText = "Description"
        Me.colDesc.Name = "colDesc"
        '
        'colDiscVal
        '
        Me.colDiscVal.HeaderText = "Column4"
        Me.colDiscVal.Name = "colDiscVal"
        Me.colDiscVal.Visible = False
        '
        'colRefVal
        '
        Me.colRefVal.HeaderText = "Column5"
        Me.colRefVal.Name = "colRefVal"
        Me.colRefVal.Visible = False
        '
        'colType
        '
        Me.colType.HeaderText = "Coupon Type"
        Me.colType.Name = "colType"
        Me.colType.Visible = False
        '
        'colBBase
        '
        Me.colBBase.HeaderText = "Column7"
        Me.colBBase.Name = "colBBase"
        Me.colBBase.Visible = False
        '
        'colBBVal
        '
        Me.colBBVal.HeaderText = "Column8"
        Me.colBBVal.Name = "colBBVal"
        Me.colBBVal.Visible = False
        '
        'colBP
        '
        Me.colBP.HeaderText = "Column9"
        Me.colBP.Name = "colBP"
        Me.colBP.Visible = False
        '
        'colBPVal
        '
        Me.colBPVal.HeaderText = "Column10"
        Me.colBPVal.Name = "colBPVal"
        Me.colBPVal.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "Column11"
        Me.Column11.Name = "Column11"
        Me.Column11.Visible = False
        '
        'Column12
        '
        Me.Column12.HeaderText = "Column12"
        Me.Column12.Name = "Column12"
        Me.Column12.Visible = False
        '
        'ApplyGC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(629, 331)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ApplyGC"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APPLY GIFT CHEQUE"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvGC As DataGridView
    Friend WithEvents colID As DataGridViewTextBoxColumn
    Friend WithEvents colName As DataGridViewTextBoxColumn
    Friend WithEvents colDesc As DataGridViewTextBoxColumn
    Friend WithEvents colDiscVal As DataGridViewTextBoxColumn
    Friend WithEvents colRefVal As DataGridViewTextBoxColumn
    Friend WithEvents colType As DataGridViewTextBoxColumn
    Friend WithEvents colBBase As DataGridViewTextBoxColumn
    Friend WithEvents colBBVal As DataGridViewTextBoxColumn
    Friend WithEvents colBP As DataGridViewTextBoxColumn
    Friend WithEvents colBPVal As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
End Class
