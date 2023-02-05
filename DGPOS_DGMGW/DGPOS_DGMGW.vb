Imports System.IO
Imports DGPOS_COMMON

Public Class DG_DGMGW

    'The value of dtp2 and dtp3 depends on the MALL BUSINESS HOURS -- DEFAULT VALUE "12:00 AM" to "02:00 AM" the NEXT DAY
    'Save the settings file in config.ini
    'Create a catch block if config.ini is not found in the file path generate a new config.ini with the DEFAULT VALUE "12:00 AM" to "02:00 AM" the NEXT DAY
    'Save generated report logs in Audit Trail everytime a report is generated using this module
    'Read the Megaworld PDF file for the pattern and reference.
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ModDGMGW.UserType = "Admin"
        ModDGMGW.ConnectionString = "server=localhost;user id=posuser;password=posuser;database=pos;port=3306"
        ModDGMGW.ExportPath = ""
    End Sub
    Public Sub New(ByRef params As String)

        ' This call is required by the designer.
        InitializeComponent()

        Dim parameters = params.Split(",")
        For Each str As String In parameters
            Dim strSplit = str.Split("^")

            Select Case strSplit(0)
                Case "user_type"
                    ModDGMGW.UserType = strSplit(1)
                Case = "connection"
                    ModDGMGW.ConnectionString = strSplit(1)
                Case = "export_path"
                    ModDGMGW.ExportPath = If(strSplit(1).EndsWith("\"), strSplit(1), strSplit(1) & "\")
            End Select

        Next

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Property FileNameGenerated As String

    Private Sub DG_DGMW_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            LoadSettings()

            If ModDGMGW.UserType <> "Admin" Then
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
            End If

            If CheckYearDirectory() Then
                If Not CheckDayDirectory() Then
                    ModDGMGW.ExportPath = CreateDayDir() & "\"
                End If
            Else
                ModDGMGW.ExportPath = CreateYearDir() & "\"
                If Not CheckDayDirectory() Then
                    ModDGMGW.ExportPath = CreateDayDir() & "\"
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDaily_Click(sender As Object, e As EventArgs) Handles btnDaily.Click
        Try

            SalesFileName = New SalesFileTypeCls
            Dim DailySales As New DailySalesCls

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.DailySales

                Dim setBtNum = GetBatchNumber(dtpReportingDate.Value)
                Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                With BatchNumberSettings
                    .BusinessDate = dtpReportingDate.Value
                    .FieldType = "S"
                    .NewBatchNumber = ModDGMGW.BatchNumber
                End With

                Dim GeneratedDailySales = GenerateDailySales(dtpReportingDate.Value, DailySales)

                If GeneratedDailySales.Count > 0 Then
                    Using addInfo = File.CreateText(ModDGMGW.ExportPath & .GenerateFileName & ".txt")
                        For Each str As String In GeneratedDailySales
                            addInfo.WriteLine(str)
                        Next
                    End Using

                    If btNumExist Then
                        UpdateBatchNumber(BatchNumberSettings)
                    Else
                        InsertBatchNumber(BatchNumberSettings)
                    End If

                    Dim userMsg As String = InputBox(.GenerateFileName & ".txt", "File Location", ModDGMGW.ExportPath & .GenerateFileName & ".txt")
                Else
                    MsgBox("Sales data is not yet available. Please select other reporting date")
                End If


            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnHourly_Click(sender As Object, e As EventArgs) Handles btnHourly.Click
        Try

            SalesFileName = New SalesFileTypeCls
            Dim HourlySales As New HourlySalesCls

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.HourlySales

                Dim setBtNum = GetBatchNumber(dtpReportingDate.Value)
                Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                With BatchNumberSettings
                    .BusinessDate = dtpReportingDate.Value
                    .FieldType = "H"
                    .NewBatchNumber = ModDGMGW.BatchNumber
                End With

                Dim GeneratedHourlySales = GenerateHourlySales(dtpReportingDate.Value, HourlySales)

                Using addInfo = File.CreateText(ModDGMGW.ExportPath & .GenerateFileName & ".txt")
                    For Each str As String In GeneratedHourlySales
                        addInfo.WriteLine(str)
                    Next
                End Using

                If btNumExist Then
                    UpdateBatchNumber(BatchNumberSettings)
                Else
                    InsertBatchNumber(BatchNumberSettings)
                End If

                Dim userMsg As String = InputBox(.GenerateFileName & ".txt", "File Location", ModDGMGW.ExportPath & .GenerateFileName & ".txt")

            End With



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        Try

            SalesFileName = New SalesFileTypeCls
            Dim HourlySales As New List(Of DiscountDataCls)

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.DiscountData

                Dim setBtNum = GetBatchNumber(dtpReportingDate.Value)
                Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                With BatchNumberSettings
                    .BusinessDate = dtpReportingDate.Value
                    .FieldType = "D"
                    .NewBatchNumber = ModDGMGW.BatchNumber
                End With

                Dim GeneratedDiscountData = GenerateDailyDiscountData(dtpReportingDate.Value, HourlySales)

                Using addInfo = File.CreateText(ModDGMGW.ExportPath & .GenerateFileName & ".txt")
                    For Each str As String In GeneratedDiscountData
                        addInfo.WriteLine(str)
                    Next
                End Using

                If btNumExist Then
                    UpdateBatchNumber(BatchNumberSettings)
                Else
                    InsertBatchNumber(BatchNumberSettings)
                End If

                Dim userMsg As String = InputBox(.GenerateFileName & ".txt", "File Location", ModDGMGW.ExportPath & .GenerateFileName & ".txt")
            End With


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



#Region "Settings"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If dtpBDStart.Value > dtpBDEnd.Value Then
            MessageBox.Show("Opening time must be less than closing time", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SetItemValue("business_hour_start", Format(dtpBDStart.Value, "HH:01"))
        SetItemValue("business_hour_end", Format(dtpBDEnd.Value, "HH:00"))
        SetItemValue("retail_partner_code", Trim(txtRetailCode.Text))
        SetItemValue("terminal_number", Trim(txtTerminalNumber.Text))
        SetItemValue("business_date_format", Trim(txtDateFormat.Text))
        SetItemValue("retail_partnercode_length", Trim(nudRetaillength.Value))

        LoadSettings()

        MessageBox.Show("Complete!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadSettings()
        Try
            Settings = New SettingsCls

            txtDateFormat.Text = Settings.BDFormat
            txtRetailCode.Text = Settings.RetailCode
            nudRetaillength.Value = Settings.RetailLength
            txtTerminalNumber.Text = Settings.TerminalNo

            ModDGMGW.RetailPartnerCode = Settings.RetailCode
            ModDGMGW.TerminalNumber = Settings.TerminalNo
            ModDGMGW.RetailPartnerCodeLength = Settings.RetailLength

            Try
                dtpBDStart.Value = Settings.BDStart
                ModDGMGW.StartDate = Settings.BDStart
            Catch ex As Exception
            End Try

            Try
                dtpBDEnd.Value = Settings.BDEnd
                ModDGMGW.EndDate = Settings.BDEnd
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
End Class
