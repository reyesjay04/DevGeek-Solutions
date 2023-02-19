Imports System.IO
Imports DGPOS_COMMON

Public Class DGPOS_DGMGW

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
        ModDGMGW.BaseExportPath = "C:\Users\jjrey\Documents\Innovention\"
        ModDGMGW.ShowDialogBox = True

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
                Case "connection"
                    ModDGMGW.ConnectionString = strSplit(1)
                Case "export_path"
                    ModDGMGW.BaseExportPath = If(strSplit(1).EndsWith("\"), strSplit(1), strSplit(1) & "\")
                Case "from_reporting_date"
                    ModDGMGW.FromReportingDate = CType(strSplit(1), Date)
                Case "to_reporting_date"
                    ModDGMGW.ToReportingDate = CType(strSplit(1), Date)
                Case "show_dialog_box"
                    ModDGMGW.ShowDialogBox = strSplit(1).Equals("Y")
            End Select

        Next

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Property FileNameGenerated As String

    Private Sub DG_DGMW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            LoadMGWSettings()

            txtDateFormat.Text = Settings.BDFormat
            txtRetailCode.Text = Settings.RetailCode
            nudRetaillength.Value = Settings.RetailLength
            txtTerminalNumber.Text = Settings.TerminalNo

            Try
                dtpBDStart.Value = Settings.BDStart
            Catch ex As Exception
            End Try

            Try
                dtpBDEnd.Value = Settings.BDEnd
            Catch ex As Exception
            End Try

            If ModDGMGW.UserType <> "Admin" Then
                TabControl1.TabPages.Remove(TabControl1.TabPages(1))
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDaily_Click(sender As Object, e As EventArgs) Handles btnDaily.Click
        ModDGMGW.FromReportingDate = dtpFromReportingDate.Value
        ModDGMGW.ToReportingDate = dtpToReportingDate.Value

        If ZreadDateExist() Then
            GenerateDailySales()
        Else
            If ShowDialogBox Then
                MsgBox("Sales data is not yet available. Please select other reporting date")
            End If
        End If

    End Sub

    Private Sub btnHourly_Click(sender As Object, e As EventArgs) Handles btnHourly.Click
        ModDGMGW.FromReportingDate = dtpFromReportingDate.Value
        ModDGMGW.ToReportingDate = dtpToReportingDate.Value
        GenerateHourlyData()
    End Sub

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        ModDGMGW.FromReportingDate = dtpFromReportingDate.Value
        ModDGMGW.ToReportingDate = dtpToReportingDate.Value
        GenerateDiscountData()
    End Sub
    Private Sub btnGenerateAll_Click(sender As Object, e As EventArgs) Handles btnGenerateAll.Click
        GenerateAll()
    End Sub
#Region "Generate Files"
    Public Shared Sub GenerateAll()

        If Not ShowDialogBox Then
            LoadMGWSettings()
        End If

        If ZreadDateExist() Then
            GenerateDailySales()
            GenerateHourlyData()
            GenerateDiscountData()
        Else
            If ShowDialogBox Then
                MsgBox("Sales data is not yet available. Please select other reporting date")
            End If
        End If

    End Sub
    Public Shared Sub GenerateDailySales()
        Try

            SalesFileName = New SalesFileTypeCls
            Dim DailySales As New DailySalesCls

            Dim SStartDate As Date = ModDGMGW.FromReportingDate
            Dim SEndDate As Date = ModDGMGW.ToReportingDate

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.DailySales

                For Each Day As DateTime In DateRange(SStartDate, SEndDate)
                    Dim setBtNum = GetBatchNumber(Day)
                    Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                    ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                    BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                    With BatchNumberSettings
                        .BusinessDate = Day
                        .FieldType = "S"
                        .NewBatchNumber = ModDGMGW.BatchNumber
                    End With

                    Dim GeneratedDailySales = GetDailySales(Day, DailySales)

                    Using addInfo = File.CreateText(CheckProgramDirectory(Day) & .GenerateFileName)
                        For Each str As String In GeneratedDailySales
                            addInfo.WriteLine(str)
                        Next
                    End Using

                    If btNumExist Then
                        UpdateBatchNumber(BatchNumberSettings)
                    Else
                        InsertBatchNumber(BatchNumberSettings)
                    End If

                    If ShowDialogBox Then
                        Dim userMsg As String = InputBox(.GenerateFileName, "File Location", CheckProgramDirectory(Day) & .GenerateFileName)
                    End If
                Next

            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Shared Sub GenerateHourlyData()
        Try

            SalesFileName = New SalesFileTypeCls
            Dim HourlySales As New HourlySalesCls

            Dim HStartDate As DateTime = ModDGMGW.FromReportingDate
            Dim HEndDate As DateTime = ModDGMGW.ToReportingDate

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.HourlySales

                For Each Day As DateTime In DateRange(HStartDate, HEndDate)
                    Dim setBtNum = GetBatchNumber(Day)
                    Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                    ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                    BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                    With BatchNumberSettings
                        .BusinessDate = Day
                        .FieldType = "H"
                        .NewBatchNumber = ModDGMGW.BatchNumber
                    End With

                    Dim GeneratedHourlySales = GetHourlySales(Day, HourlySales)

                    Using addInfo = File.CreateText(CheckProgramDirectory(Day) & .GenerateFileName)
                        For Each str As String In GeneratedHourlySales
                            addInfo.WriteLine(str)
                        Next
                    End Using

                    If btNumExist Then
                        UpdateBatchNumber(BatchNumberSettings)
                    Else
                        InsertBatchNumber(BatchNumberSettings)
                    End If

                    If ShowDialogBox Then
                        Dim userMsg As String = InputBox(.GenerateFileName, "File Location", CheckProgramDirectory(Day) & .GenerateFileName)
                    End If
                Next
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Shared Function DateRange(Start As DateTime, Thru As DateTime) As IEnumerable(Of Date)
        Return Enumerable.Range(0, (Thru.Date - Start.Date).Days + 1).Select(Function(i) Start.AddDays(i))
    End Function
    Public Shared Sub GenerateDiscountData()
        Try

            SalesFileName = New SalesFileTypeCls
            Dim HourlySales As New List(Of DiscountDataCls)

            Dim DStartDate As Date = ModDGMGW.FromReportingDate
            Dim DEndDate As Date = ModDGMGW.ToReportingDate

            With SalesFileName
                .SalesFileType = SalesFileTypeCls.SalesFormat.DiscountData

                For Each Day As DateTime In DateRange(DStartDate, DEndDate)
                    Dim setBtNum = GetBatchNumber(Day)
                    Dim btNumExist As Boolean = If(setBtNum = 0, False, True)

                    ModDGMGW.BatchNumber = If(setBtNum = 9, 9, setBtNum + 1).ToString

                    BatchNumberSettings = New FieldTypeCls.BatchNumberSettings

                    With BatchNumberSettings
                        .BusinessDate = Day
                        .FieldType = "D"
                        .NewBatchNumber = ModDGMGW.BatchNumber
                    End With

                    Dim GeneratedDiscountData = GetDailyDiscountData(Day, HourlySales)

                    If GeneratedDiscountData.Count > 0 Then
                        Using addInfo = File.CreateText(CheckProgramDirectory(Day) & .GenerateFileName)
                            For Each str As String In GeneratedDiscountData
                                addInfo.WriteLine(str)
                            Next
                        End Using

                        If btNumExist Then
                            UpdateBatchNumber(BatchNumberSettings)
                        Else
                            InsertBatchNumber(BatchNumberSettings)
                        End If

                        If ShowDialogBox Then
                            Dim userMsg As String = InputBox(.GenerateFileName, "File Location", CheckProgramDirectory(Day) & .GenerateFileName)
                        End If
                    End If
                Next
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Settings"
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If dtpBDStart.Value > dtpBDEnd.Value Then
            MessageBox.Show("Opening time must be less than closing time", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SetItemValue("business_hour_start", Format(dtpBDStart.Value, "HH:00"))
        SetItemValue("business_hour_end", Format(dtpBDEnd.Value, "HH:59"))
        SetItemValue("retail_partner_code", Trim(txtRetailCode.Text))
        SetItemValue("terminal_number", Trim(txtTerminalNumber.Text))
        SetItemValue("business_date_format", Trim(txtDateFormat.Text))
        SetItemValue("retail_partnercode_length", Trim(nudRetaillength.Value))

        LoadMGWSettings()

        MessageBox.Show("Complete!", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Shared Sub LoadMGWSettings()
        Try
            Settings = New SettingsCls

            ModDGMGW.RetailPartnerCode = Settings.RetailCode
            ModDGMGW.TerminalNumber = Settings.TerminalNo
            ModDGMGW.RetailPartnerCodeLength = Settings.RetailLength

            Try
                ModDGMGW.StartDate = Settings.BDStart
            Catch ex As Exception
            End Try

            Try
                ModDGMGW.EndDate = Settings.BDEnd
            Catch ex As Exception
            End Try



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region
End Class
