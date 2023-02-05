Public Class SalesFileTypeCls
    Property SalesFileType As New SalesFormat
    Enum SalesFormat
        DailySales
        HourlySales
        DiscountData
    End Enum

    Private Function GetSalesFormat() As String
        Dim strFormat As String = ""
        Select Case Me.SalesFileType
            Case SalesFormat.DailySales  ' For Daily Sales
                strFormat = "S"
            Case SalesFormat.HourlySales ' For Hourly Sales
                strFormat = "H"
            Case Else                    ' For Discount Data
                strFormat = "D"
        End Select
        Return strFormat
    End Function
    Private Function GetRetailPartnerCodeFormat() As String
        ' Get characters base on (strLen); 
        ' Example: RetailPartnerCode = DGPOS
        ' RetailPartnerCode.Substring(0, 2) = DG
        Dim strFormat As String = ""
        Try
            strFormat = RetailPartnerCode.Substring(0, RetailPartnerCodeLength)
        Catch ex As Exception
            strFormat = RetailPartnerCode
        End Try
        Return strFormat
    End Function

    Private Function GetMonthFormat() As String
        Dim strFormat As String = ""
        Dim getMonth = Today
        Select Case getMonth.Month
            Case 10
                strFormat = "A"
            Case 11
                strFormat = "B"
            Case 12
                strFormat = "C"
            Case Else
                strFormat = getMonth.Month
        End Select
        Return strFormat
    End Function

    Private Function GetDayFormat() As String
        Dim strFormat As String = ""
        strFormat = Format(Today, "dd")
        Return strFormat
    End Function

    Public Function GenerateFileName() As String
        Dim strFormat As String = ""

        'SNNNNTTB.X99
        'HNNNNTTB.X99
        'DNNNNTTB.X99

        strFormat = GetSalesFormat() & GetRetailPartnerCodeFormat() & TerminalNumber & BatchNumber & "." & GetMonthFormat() & GetDayFormat()

        Return strFormat
    End Function


End Class
