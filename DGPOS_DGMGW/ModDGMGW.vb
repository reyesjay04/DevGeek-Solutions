Imports System.IO
Imports MySql.Data.MySqlClient
Module ModDGMGW
    Property SalesFileName As New SalesFileTypeCls
    Property RetailPartnerCode As String = "DGPOS1234" 'Default Value
    Property TerminalNumber As String = "00" 'Default Value
    Property BatchNumber As String = "2"
    Property RetailPartnerCodeLength As Integer = 4 'Default Value
    Property ConnectionString As String
    Property ExportPath As String
    Property UserType As String
    Property Settings As SettingsCls
    Property BatchNumberSettings As FieldTypeCls.BatchNumberSettings
    Property StartDate As New Date
    Property EndDate As New Date
#Region "Daily Sales"
    Public Function GenerateDailySales(ByVal _baseDate As Date, ByVal _daily As DailySalesCls) As List(Of String)
        Dim dlSales As New List(Of String)

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ModDGMGW.ConnectionString

        Try
            mConn.Open()
            Dim ZReadDate As String = Format(_baseDate, "yyyy-MM-dd")
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "SELECT * FROM `loc_zread_table` WHERE ZXdate = @ZreadDate"
                mCmd.Parameters.AddWithValue("@ZreadDate", ZReadDate)
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read
                            With _daily

                                .RetailPartnerCode = RetailPartnerCode
                                .TerminalNumber = TerminalNumber
                                .BaseDate = Format(_baseDate, Settings.BDFormat)
                                .OldAccumulatedTotal = mReader("ZXBegBalance")
                                .TotalCashSales = mReader("ZXCashTotal") - mReader("ZXCashlessTotal")
                                .TotalCreditDebitCardSales = mReader("ZXCreditCard") + mReader("ZXDebitCard")
                                .TotalOtherPaymentSales = mReader("ZXCashlessTotal") + mReader("ZXGiftCardSum")

                                .TotalNetSalesAmount = mReader("ZXNetSales")
                                .NewAccumulatedTotal = mReader("ZXBegBalance") + .TotalNetSalesAmount

                                .TotalNonTaxableSalesAmount = mReader("ZXVatExemptSales")
                                .TotalSeniorAndPWDDiscount = mReader("ZXSeniorCitizen") + mReader("ZXPWD")
                                .TotalOtherDiscountAndFreeItems = mReader("ZXTotalDiscounts") - .TotalSeniorAndPWDDiscount

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
                                dlSales.Add(FieldTypeConstructor("BaseDate", Format(_baseDate, Settings.BDFormat), "03"))
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
    Public Function GenerateHourlySales(ByVal _baseDate As Date, ByVal _hourly As HourlySalesCls) As List(Of String)
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
                Dim fromTime = Format(dtStart, "HH:mm")
                Dim toTime = Format(dtStart.AddHours(1), "HH:00")
                Dim nwhldata As New HourlySalesCls.HourlySales

                With nwhldata
                    .HourCode = If(Format(dtStart, "HH").ToString = "00", "24", Format(dtStart, "HH").ToString)
                    .CustomerCount = CountColumn("transaction_id", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME_FORMAT(created_at, '%H:%i:%s') BETWEEN '{fromTime}' AND '{toTime}'")
                    .NetSalesAmount = SumColumn("amountdue", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME_FORMAT(created_at, '%H:%i:%s') BETWEEN '{fromTime}' AND '{toTime}'") + SumColumn("coupon_total", "loc_coupon_data lcd LEFT JOIN loc_daily_transaction lot ON lcd.transaction_number = lot.transaction_number", $"lcd.status = '1' AND lcd.zreading = '{_zreadDate}' AND TIME_FORMAT(lot.created_at, '%H:%i:%s') BETWEEN '{fromTime}' AND '{toTime}' AND lcd.coupon_type = 'Fix-1'")
                    .SalesTransaction = CountColumn("transaction_id", "loc_daily_transaction", $"zreading = '{_zreadDate}' AND TIME_FORMAT(created_at, '%H:%i:%s') BETWEEN '{fromTime}' AND '{toTime}' AND active = 1")
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
    Public Function GenerateDailyDiscountData(ByVal _baseDate As Date, ByVal _discountData As List(Of DiscountDataCls)) As List(Of String)
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
                                    WHERE lcd.zreading = @ZReadDate AND ldt.active = 1"
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
                Dim val = mCmd.ExecuteScalar
                dbl = If(Not IsDBNull(val), val, 0)
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

#End Region

#Region "Directory Creator"

    Public Function CheckYearDirectory() As Boolean
        Dim isExist As Boolean = False
        Try
            If Directory.Exists(ModDGMGW.ExportPath & Format(Now(), "yyyy")) Then
                isExist = True
                ModDGMGW.ExportPath = ModDGMGW.ExportPath & Format(Now(), "yyyy") & "\"
            Else
                isExist = False
            End If
        Catch ex As Exception
        End Try
        Return isExist
    End Function

    Public Function CreateYearDir() As String
        Dim path As String = ""
        Try
            path = ModDGMGW.ExportPath & Format(Now(), "yyyy")
            My.Computer.FileSystem.CreateDirectory(path)
        Catch ex As Exception
        End Try
        Return path
    End Function

    Public Function CheckDayDirectory() As Boolean
        Dim isExist As Boolean = False
        Try
            If Directory.Exists(ModDGMGW.ExportPath & Format(Now(), "dd")) Then
                isExist = True
                ModDGMGW.ExportPath = ModDGMGW.ExportPath & Format(Now(), "dd") & "\"
            Else
                isExist = False
            End If
        Catch ex As Exception

        End Try
        Return isExist
    End Function

    Public Function CreateDayDir() As String
        Dim path As String = ""
        Try
            path = ModDGMGW.ExportPath & Format(Now(), "dd MM yyyy")
            My.Computer.FileSystem.CreateDirectory(path)
        Catch ex As Exception
        End Try
        Return path
    End Function
#End Region
End Module
