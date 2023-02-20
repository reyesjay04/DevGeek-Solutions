Imports DGPOS_COMMON
Public Class DG_SIASYS

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ModSIA.UserType = "Admin"
        ModSIA.ConnectionString = "server=localhost;user id=posuser;password=posuser;database=pos;port=3306"
    End Sub
    Public Sub New(ByRef params As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim parameters = params.Split(",")
        For Each str As String In parameters
            Dim strSplit = str.Split("^")

            Select Case strSplit(0)
                Case "user_type"
                    ModSIA.UserType = strSplit(1)
                Case "connection"
                    ModSIA.ConnectionString = strSplit(1)
                Case "base_date"
                    ModSIA.BaseDate = CType(strSplit(1), Date)
                Case "transaction_number"
                    ModSIA.TransactionNumber = strSplit(1)
                Case "is_refund"
                    ModSIA.IsRefund = strSplit(1).Equals("Y")
            End Select
        Next
    End Sub

    Private Sub DGPOS_SIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadSIASettings()
        TransactionHeader = TransactionHeaderCls.CreateTransactionColumn
        TransactionDetails = TransactionDetailsCls.CreateTransactionDetailsColumn

        txtterminal.Text = Settings.TerminalNumber
        txtserialnumber.Text = Settings.SerialNumber
        txtfilepath.Text = Settings.FilePath
        txtsalestype.Text = Settings.SalesType
        txttrxheader.Text = Settings.HeaderFileName
        txttrxdetail.Text = Settings.DetailsFileName

    End Sub
    Private Sub txtfilepath_DoubleClick(sender As Object, e As EventArgs) Handles txtfilepath.DoubleClick
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtfilepath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        SetItemValue("terminal_id", Trim(txtterminal.Text))
        SetItemValue("serial_number", Trim(txtserialnumber.Text))
        SetItemValue("file_path", Trim(txtfilepath.Text))
        SetItemValue("sales_type", Trim(txtsalestype.Text))

        SetItemValue("daily_transaction_file_name", Trim(txttrxheader.Text))
        SetItemValue("daily_transaction_details_file_name", Trim(txttrxdetail.Text))

        LoadSIASettings()

        MessageBox.Show("Complete!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


#Region "Settings"
    Public Shared Sub LoadSIASettings()
        Try
            Settings = New SettingsCls

            ModSIA.TerminalNumber = Settings.TerminalNumber
            ModSIA.SerialNumber = Settings.SerialNumber
            ModSIA.FilePath = Settings.FilePath
            ModSIA.SalesType = Settings.SalesType
            ModSIA.HeaderFileName = Settings.HeaderFileName
            ModSIA.DetailsFileName = Settings.DetailsFileName

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Public Shared Sub GenerateCSVFiles()

        LoadSIASettings()
        TransactionHeader = TransactionHeaderCls.CreateTransactionColumn
        TransactionDetails = TransactionDetailsCls.CreateTransactionDetailsColumn
        CheckCSVFiles(ModSIA.BaseDate)

    End Sub

End Class
