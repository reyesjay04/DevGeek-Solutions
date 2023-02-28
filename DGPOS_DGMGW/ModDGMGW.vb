Imports System.IO
Imports MySql.Data.MySqlClient
Module ModDGMGW
    Property ProgramID As String = "DGPOS_DGMGW"
    Property SalesFileName As New SalesFileTypeCls
    Property RetailPartnerCode As String = "DGPOS1234" 'Default Value
    Property TerminalNumber As String = "00" 'Default Value
    Property BatchNumber As String = "2"
    Property RetailPartnerCodeLength As Integer = 4 'Default Value
    Property ConnectionString As String
    Property BaseExportPath As String
    Property UserType As String
    Property FromReportingDate As Date
    Property ToReportingDate As Date
    Property ShowDialogBox As Boolean
    Property Settings As SettingsCls
    Property BatchNumberSettings As FieldTypeCls.BatchNumberSettings
    Property StartDate As New Date
    Property EndDate As New Date
#Region "Daily Sales"
    Public Function GetDailySales(ByVal _businessdate As Date, ByVal _daily As DailySalesCls) As List(Of String)
        Dim dlSales As New List(Of String)

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString

        Try
            mConn.Open()
            Dim ZreadDate As String = Format(_businessdate, "yyyy-MM-dd")
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "SELECT * FROM `loc_zread_table` WHERE ZXdate = @ZreadDate"
                mCmd.Parameters.AddWithValue("@ZreadDate", ZreadDate)

                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read
                            With _daily

                                .RetailPartnerCode = RetailPartnerCode
                                .TerminalNumber = TerminalNumber
                                .BaseDate = CType(mReader("ZXdate"), Date)
                                .OldAccumulatedTotal = mReader("ZXBegBalance")
                                '.TotalCashSales = mReader("ZXCashTotal") - mReader("ZXCashlessTotal") - mReader("ZXGiftCardSum")
                                .TotalCashSales = mReader("ZXCashTotal")
                                .TotalCreditDebitCardSales = mReader("ZXCreditCard") + mReader("ZXDebitCard")
                                .TotalOtherPaymentSales = mReader("ZXCashlessTotal") + mReader("ZXGiftCard")

                                .TotalNetSalesAmount = mReader("ZXNetSales")
                                .NewAccumulatedTotal = mReader("ZXBegBalance") + .TotalNetSalesAmount

                                .TotalNonTaxableSalesAmount = mReader("ZXVatExemptSales")
                                .TotalSeniorAndPWDDiscount = CType(mReader("ZXSeniorCitizen"), Double) + CType(mReader("ZXPWD"), Double)
                                .TotalOtherDiscountAndFreeItems = CType(mReader("ZXTotalDiscounts"), Double) - .TotalSeniorAndPWDDiscount

                                .TotalRefundAmount = mReader("ZXReturnsRefund")
                                .TotalGrossSalesAmount = mReader("ZXGross")

                                .TotalTaxVatAmount = mReader("ZXVatAmount")
                                .TotalServiceChargeAmount = mReader("ZXRepExpense")

                                .TotalVoidAmount = .TotalRefundAmount
                                .TotalCustomerCount = mReader("ZXTotalTransactionCount")
                                .TotalControlNumber = 0
                                .TotalNumberOfSalesTransaction = mReader("ZXTotalTransactionCount")
                                .SalesType = "01"
                                .NetSalesAmount = .TotalNetSalesAmount

                                dlSales.Add(FieldTypeConstructor("RetailPartnerCode", .RetailPartnerCode, "01"))
                                dlSales.Add(FieldTypeConstructor("TerminalNumber", .TerminalNumber, "02"))
                                dlSales.Add(FieldTypeConstructor("BaseDate", Format(.BaseDate, Settings.BDFormat), "03"))
                                dlSales.Add(FieldTypeConstructor("OldAccumulatedTotal", .OldAccumulatedTotal, "04"))
                                dlSales.Add(FieldTypeConstructor("NewAccumulatedTotal", .NewAccumulatedTotal, "05"))
                                dlSales.Add(FieldTypeConstructor("TotalGrossSalesAmount", .TotalGrossSalesAmount, "06"))
                                dlSales.Add(FieldTypeConstructor("TotalNonTaxableSalesAmount", .TotalNonTaxableSalesAmount, "07"))
                                dlSales.Add(FieldTypeConstructor("TotalSeniorAndPWDDiscount", .TotalSeniorAndPWDDiscount, "08"))
                                dlSales.Add(FieldTypeConstructor("TotalOtherDiscountAndFreeItems", .TotalOtherDiscountAndFreeItems, "09"))
                                dlSales.Add(FieldTypeConstructor("TotalRefundAmount", .TotalRefundAmount, "10"))
                                dlSales.Add(FieldTypeConstructor("TotalTaxVatAmount", .TotalTaxVatAmount, "11"))
                                dlSales.Add(FieldTypeConstructor("TotalServiceChargeAmount", .TotalServiceChargeAmount, "12"))
                                dlSales.Add(FieldTypeConstructor("TotalNetSalesAmount", .TotalNetSalesAmount, "13"))
                                dlSales.Add(FieldTypeConstructor("TotalCashSales", .TotalCashSales, "14"))
                                dlSales.Add(FieldTypeConstructor("TotalCreditDebitCardSales", .TotalCreditDebitCardSales, "15"))
                                dlSales.Add(FieldTypeConstructor("TotalOtherPaymentSales", .TotalOtherPaymentSales, "16"))
                                dlSales.Add(FieldTypeConstructor("TotalVoidAmount", .TotalVoidAmount, "17"))
                                dlSales.Add(FieldTypeConstructor("TotalCustomerCount", .TotalCustomerCount, "18"))
                                dlSales.Add(FieldTypeConstructor("TotalControlNumber", .TotalControlNumber, "19"))
                                dlSales.Add(FieldTypeConstructor("TotalNumberOfSalesTransaction", .TotalNumberOfSalesTransaction, "20"))
                                dlSales.Add(FieldTypeConstructor("SalesType", .SalesType, "21"))
                                dlSales.Add(FieldTypeConstructor("NetSalesAmount", .NetSalesAmount, "22"))
                            End With
                        End While
                    Else
                        Exit Try
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dlSales
    End Function
#End Region

#Region "Hourly Sales"
    Public Function GetHourlySales(ByVal _baseDate As Date, ByVal _hourly As HourlySalesCls) As List(Of String)
        Dim hlSales As New List(Of String)
        Try
            With _hourly
                Dim ZReadDate As String = Format(_baseDate, "yyyy-MM-dd")
                .RetailPartnerCode = RetailPartnerCode
                .TerminalNumber = TerminalNumber
                .BaseDate = Format(_baseDate, Settings.BDFormat)
                .HourlyData = GetHourlyData(ZReadDate)

                hlSales.Add(FieldTypeConstructor("RetailPartnerCode", .RetailPartnerCode, "01"))
                hlSales.Add(FieldTypeConstructor("TerminalNumber", .TerminalNumber, "02"))
                hlSales.Add(FieldTypeConstructor("BaseDate", Format(_baseDate, Settings.BDFormat), "03"))

                For Each hourDt As HourlySalesCls.HourlySales In .HourlyData
                    hlSales.Add(FieldTypeConstructor("HourCode", hourDt.HourCode, "04", "HourlyData"))
                    hlSales.Add(FieldTypeConstructor("NetSalesAmount", hourDt.NetSalesAmount, "05", "HourlyData"))
                    hlSales.Add(FieldTypeConstructor("SalesTransaction", hourDt.SalesTransaction, "06", "HourlyData"))
                    hlSales.Add(FieldTypeConstructor("CustomerCount", hourDt.CustomerCount, "07", "HourlyData"))
                Next

                hlSales.Add(FieldTypeConstructor("TotalNetSales", .HourlyData.Sum(Function(x) x.NetSalesAmount), "08"))
                hlSales.Add(FieldTypeConstructor("TotalNumberOfSales", .HourlyData.Sum(Function(x) x.SalesTransaction), "09"))
                hlSales.Add(FieldTypeConstructor("TotalCustomerCount", .HourlyData.Sum(Function(x) x.CustomerCount), "10"))
            End With

        Catch ex As Exception

        End Try
        Return hlSales
    End Function

    Public Function GetHourlyData(ByVal _zreadDate As String) As List(Of HourlySalesCls.HourlySales)
        Dim hldata As New List(Of HourlySalesCls.HourlySales)
        Try

            Dim dtStart = StartDate
            Dim dtEnd = EndDate.AddHours(1)

            While dtStart < dtEnd
                Dim fromTime = Format(dtStart, "HH:01:00")
                Dim toTime = Format(dtStart.AddHours(1), "HH:00:59")
                Dim nwhldata As New HourlySalesCls.HourlySales

                With nwhldata
                    .HourCode = If(Format(dtStart, "HH").ToString = "00", "24", Format(dtStart, "HH").ToString)
                    If .HourCode = "23" Then
                        Console.Write(0)
                    End If
                    'SELECT COUNT(transaction_id) FROM loc_daily_transaction WHERE zreading = '2023-02-17' AND TIME(created_at) BETWEEN '23:01:00' AND ADDTIME('23:01:00','00:59:00') AND active = 1

                    .CustomerCount = CountColumn("transaction_id", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME(created_at) BETWEEN '{fromTime}' AND ADDTIME('{fromTime}','00:59:59')")
                    '.NetSalesAmount = SumColumn("amountdue", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME(created_at) BETWEEN '{fromTime}' AND '{toTime}'") + SumColumn("coupon_total", "loc_coupon_data lcd LEFT JOIN loc_daily_transaction lot ON lcd.transaction_number = lot.transaction_number", $"lcd.status = '1' AND lcd.zreading = '{_zreadDate}' AND TIME(lot.created_at) BETWEEN '{fromTime}' AND '{toTime}' AND lcd.coupon_type = 'Fix-1'")
                    .NetSalesAmount = SumColumn("netsales", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME(created_at) BETWEEN '{fromTime}' AND ADDTIME('{fromTime}','00:59:59')  AND active = 1")
                    .SalesTransaction = CountColumn("transaction_id", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME(created_at) BETWEEN '{fromTime}' AND ADDTIME('{fromTime}','00:59:59') ")
                End With

                dtStart = dtStart.AddHours(1)
                hldata.Add(nwhldata)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return hldata
    End Function

#End Region

#Region "Daily Discount Data"
    Public Function GetDailyDiscountData(ByVal _baseDate As Date, ByVal _discountData As List(Of DiscountDataCls)) As List(Of String)
        Dim discData As New List(Of String)

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString

        Try
            mConn.Open()

            Dim ZReadDate As String = Format(_baseDate, "yyyy-MM-dd")
            With _discountData
                Using mCmd = New MySqlCommand("", mConn)
                    mCmd.Parameters.Clear()
                    mCmd.CommandText = "SELECT tc.id as PromoCode, lcd.coupon_name as PromoDescription, lcd.coupon_total as PromoTotal FROM `loc_coupon_data` lcd 
                                    LEFT JOIN tbcoupon tc ON tc.ID = lcd.reference_id
                                    LEFT JOIN loc_daily_transaction ldt on ldt.transaction_number = lcd.transaction_number
                                    WHERE lcd.zreading = @ZReadDate AND ldt.active = 1 AND tc.id <> 3"
                    mCmd.Parameters.AddWithValue("@ZreadDate", ZReadDate)

                    Using mReader = mCmd.ExecuteReader
                        If mReader.HasRows Then
                            While mReader.Read
                                Dim nwDisc As New DiscountDataCls
                                nwDisc.PromoCode = If(Not IsDBNull(mReader("PromoCode")), mReader("PromoCode"), "N/A")
                                nwDisc.PromoDescription = mReader("PromoDescription")
                                nwDisc.PromoTotal = mReader("PromoTotal")
                                _discountData.Add(nwDisc)
                            End While
                        Else
                            Exit Try
                        End If
                        mReader.Close()
                    End Using
                    mCmd.Dispose()

                    For Each disc As DiscountDataCls In _discountData
                        discData.Add($"{disc.PromoCode},{disc.PromoDescription},{disc.PromoTotal}")
                    Next

                End Using
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        mConn.Close()
        Return discData
    End Function
#End Region

#Region "Global Functions"
    Public Function SumColumn(ByVal _field As String, ByVal _table As String, ByVal _condition As String) As Double
        Dim dbl As Double = 0

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString
        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = $"SELECT SUM({_field}) FROM {_table} WHERE {_condition}"
                Try
                    dbl = mCmd.ExecuteScalar
                Catch ex As Exception
                End Try
                mCmd.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mConn.Close()
        Return dbl
    End Function
    Public Function CountColumn(ByVal _field As String, ByVal _table As String, ByVal _condition As String) As Integer
        Dim dbl As Double = 0

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString
        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = $"SELECT COUNT({_field}) FROM {_table} WHERE {_condition}"
                dbl = mCmd.ExecuteScalar
                mCmd.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mConn.Close()
        Return dbl
    End Function
    Private Function FieldTypeConstructor(ByVal _fieldName As String, ByVal _fieldVal As Object, ByVal _fieldNo As String, Optional _mainClass As String = Nothing) As String

        Dim dailySales As New FieldTypeCls
        With dailySales
            .FieldName = _fieldName
            .FieldValue = _fieldVal
            .FieldNumber = _fieldNo
            Select Case SalesFileName.SalesFileType
                Case SalesFileTypeCls.SalesFormat.DailySales
                    .SetFieldValueType = .GetSalesFieldDataType(_fieldName)
                Case SalesFileTypeCls.SalesFormat.HourlySales
                    .SetFieldValueType = .GetHourlyFieldDataType(_fieldName, _mainClass)
                Case SalesFileTypeCls.SalesFormat.DiscountData
                    .SetFieldValueType = .GetDiscountFieldDataType(_fieldName)
            End Select
        End With

        Return dailySales.GenLineData
    End Function
    Public Function GetBatchNumber(ByVal _businessDate As Date) As Integer
        Dim btint As Integer = 0

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString

        Try
            Dim fileType As String = ""
            Select Case SalesFileName.SalesFileType
                Case SalesFileTypeCls.SalesFormat.DailySales
                    fileType = "S"
                Case SalesFileTypeCls.SalesFormat.HourlySales
                    fileType = "H"
                Case Else
                    fileType = "D"
            End Select

            mConn.Open()

            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "SELECT lms_batch_number FROM loc_mgw_settings WHERE DATE(lms_busdate) = @BusinessDate AND lms_type = @FileType"
                mCmd.Parameters.AddWithValue("@BusinessDate", Format(_businessDate, "yyyy-MM-dd"))
                mCmd.Parameters.AddWithValue("@FileType", fileType)
                Dim mScalar = mCmd.ExecuteScalar
                btint = If(Not IsDBNull(mScalar), mScalar, 0)
                mCmd.Dispose()
            End Using


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mConn.Close()
        Return btint
    End Function
    Public Sub InsertBatchNumber(ByVal _batchNumSettings As FieldTypeCls.BatchNumberSettings)
        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString
        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "INSERT INTO loc_mgw_settings (`lms_busdate`, `lms_batch_number`, `lms_type`) VALUES (@BusinessDate, @NewBatchNumber, @BatchType)"
                mCmd.Parameters.AddWithValue("@BusinessDate", _batchNumSettings.BusinessDate)
                mCmd.Parameters.AddWithValue("@NewBatchNumber", _batchNumSettings.NewBatchNumber)
                mCmd.Parameters.AddWithValue("@BatchType", _batchNumSettings.FieldType)
                mCmd.ExecuteNonQuery()
                mCmd.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mConn.Close()
    End Sub
    Public Sub UpdateBatchNumber(ByVal _batchNumSettings As FieldTypeCls.BatchNumberSettings)
        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString
        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "UPDATE loc_mgw_settings SET `lms_batch_number` = @NewBatchNumber WHERE DATE(`lms_busdate`) = @BusinessDate AND `lms_type` = @BatchType"
                mCmd.Parameters.AddWithValue("@BusinessDate", Format(_batchNumSettings.BusinessDate, "yyyy-MM-dd"))
                mCmd.Parameters.AddWithValue("@NewBatchNumber", _batchNumSettings.NewBatchNumber)
                mCmd.Parameters.AddWithValue("@BatchType", _batchNumSettings.FieldType)
                mCmd.ExecuteNonQuery()
                mCmd.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mConn.Close()
    End Sub

    Public Function ZreadDateExist() As Boolean

        Dim isAllDateAreValid As Boolean = True
        Dim CStartDate As Date = ModDGMGW.FromReportingDate
        Dim CEndDate As Date = ModDGMGW.ToReportingDate

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString

        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                For Each Day As DateTime In DateRange(CStartDate, CEndDate)
                    mCmd.Parameters.Clear()
                    mCmd.CommandText = "SELECT ZXdate FROM loc_zread_table WHERE ZXdate = @ZXdate"
                    mCmd.Parameters.AddWithValue("@ZXdate", Format(Day, "yyyy-MM-dd"))
                    Using mReader = mCmd.ExecuteReader
                        If mReader.HasRows Then
                            isAllDateAreValid = True
                        Else
                            isAllDateAreValid = False
                            Exit Try
                        End If
                        mReader.Dispose()
                    End Using
                Next
                mCmd.Dispose()
            End Using

        Catch ex As Exception
        End Try
        mConn.Close()
        Return isAllDateAreValid
    End Function
#End Region

#Region "Directory Creator"
    Public Function CheckProgramDirectory(ByRef _basedate As Date) As String
        Dim path As String = ""

        Dim program_export_path = ModDGMGW.BaseExportPath & ProgramID

        If Directory.Exists(program_export_path) Then
            path = CreateYearDir(_basedate, program_export_path)
        Else
            My.Computer.FileSystem.CreateDirectory(program_export_path)
            path = CreateYearDir(_basedate, program_export_path)
        End If
        path = If(path.EndsWith("\"), path, path & "\")
        Return path
    End Function

    Public Function CreateYearDir(ByRef _basedate As Date, ByRef program_export_path As String) As String
        Dim path As String = ""
        program_export_path = If(program_export_path.EndsWith("\"), program_export_path, program_export_path & "\")

        Dim year_dir_path As String = program_export_path & Format(_basedate, "yyyy")

        If Directory.Exists(year_dir_path) Then
            path = CreateDayDir(_basedate, year_dir_path)
        Else
            My.Computer.FileSystem.CreateDirectory(year_dir_path)
            path = CreateDayDir(_basedate, year_dir_path)
        End If
        Return path
    End Function


    Public Function CreateDayDir(ByRef _basedate As Date, ByRef year_dir_path As String) As String
        Dim path As String = ""
        year_dir_path = If(year_dir_path.EndsWith("\"), year_dir_path, year_dir_path & "\")

        Dim day_dir_path As String = year_dir_path & Format(_basedate, "dd MM yyyy")

        If Not Directory.Exists(day_dir_path) Then
            My.Computer.FileSystem.CreateDirectory(day_dir_path)
            path = day_dir_path
        Else
            path = day_dir_path
        End If

        path = If(path.EndsWith("\"), path, path & "\")
        Return path
    End Function
#End Region
    Public Function DateRange(Start As DateTime, Thru As DateTime) As IEnumerable(Of Date)
        Return Enumerable.Range(0, (Thru.Date - Start.Date).Days + 1).Select(Function(i) Start.AddDays(i))
    End Function
End Module
