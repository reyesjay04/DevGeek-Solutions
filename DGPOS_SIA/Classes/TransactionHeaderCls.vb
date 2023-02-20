Public Class TransactionHeaderCls
    Enum HeaderEnum
        OrderNumber
        BusinessDay
        CheckOpen
        CheckClose
        SalesType
        TransactionType
        Void
        VoidAmount
        Refund
        RefundAmount
        GuestCount
        GuestCountSenior
        GuestCountPWD
        GrossSales
        NetSales
        TotalTax
        OtherLocalTax
        TotalServiceCharge
        TotalTip
        TotalDiscount
        LessTaxAmount
        TaxExempt
        RegularDiscName
        RegularOtherDiscountAmount
        EmployeeDiscountAmount
        SeniorDiscountAmount
        VIPDiscountAmount
        PWDDiscountAmount
        SportsDiscountAmount
        SmacDiscount
        OnlineDeals
        DiscountFieldName1
        DiscountFieldName2
        DiscountFieldName3
        DiscountFieldName4
        DiscountFieldName5
        DiscountFieldName6
        DiscountFieldAmount1
        DiscountFieldAmount2
        DiscountFieldAmount3
        DiscountFieldAmount4
        DiscountFieldAmount5
        DiscountFieldAmount6
        PaymentType1
        PaymentAmount1
        PaymentType2
        PaymentAmount2
        PaymentType3
        PaymentAmount3
        TotalCashSales
        TotalGiftCheque
        TotalDebit
        TotalEWallet
        TotalTenderSales
        TotalMasterCard
        TotalVisa
        TotalAmerican
        TotalDinerSales
        TotalJCB
        TotalOtherCreditCard
        TerminalNumber
        SerialNumber
    End Enum
    Property ColumnID As Integer
    Property ColumnName As String

    Public Sub New(ByVal _columnID As Integer, ByVal _columnName As String)
        Me.ColumnID = _columnID
        Me.ColumnName = _columnName
    End Sub
    Public Shared Function CreateTransactionColumn() As List(Of TransactionHeaderCls)
        Dim trxheader As New List(Of TransactionHeaderCls)
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.OrderNumber, "Order Num / Bill Num"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.BusinessDay, "Business Day"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.CheckOpen, "Check Open"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.CheckClose, "Check Close"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.SalesType, "Sales Type"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TransactionType, "Transaction Type"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.Void, "Void"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.VoidAmount, "Void Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.Refund, "Refund"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.RefundAmount, "Refund Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.GuestCount, "Guest Count"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.GuestCountSenior, "Guest Count (Senior)"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.GuestCountPWD, "Guest Count (PWD)"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.GrossSales, "Gross Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.NetSales, "Net Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalTax, "Total Tax"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.OtherLocalTax, "Other/Local Tax"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalServiceCharge, "Total Service Charge"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalTip, "Total Tip"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalDiscount, "Total Discount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.LessTaxAmount, "Less Tax Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TaxExempt, "Tax Exempt Sales"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.RegularDiscName, "Regular / Other Discount Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.RegularOtherDiscountAmount, "Regular / Other Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.EmployeeDiscountAmount, "Employee Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.SeniorDiscountAmount, "Senior Citizen Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.VIPDiscountAmount, "VIP Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PWDDiscountAmount, "PWD Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.SportsDiscountAmount, "National Coach / Athlete /  Medal of Valor Discount amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.SmacDiscount, "SMAC Discount Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.OnlineDeals, "Online Deals Discount Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName1, "Discount Field 1 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName2, "Discount Field 2 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName3, "Discount Field 3 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName4, "Discount Field 4 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName5, "Discount Field 5 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldName6, "Discount Field 6 Name"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount1, "Discount Field 1 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount2, "Discount Field 2 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount3, "Discount Field 3 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount4, "Discount Field 4 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount5, "Discount Field 5 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.DiscountFieldAmount6, "Discount Field 6 Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentType1, "Payment Type_1"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentAmount1, "Payment Amount_1"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentType2, "Payment Type_2"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentAmount2, "Payment Amount_2"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentType3, "Payment Type_3"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.PaymentAmount3, "Payment Amount_3"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalCashSales, "Total Cash Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalGiftCheque, "Total Gift Cheque / Gift Card Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalDebit, "Total Debit Card Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalEWallet, "Total E-wallet / Online Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalTenderSales, "Total Other Tender Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalMasterCard, "Total Mastercard Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalVisa, "Total Visa Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalAmerican, "Total American Express Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalDinerSales, "Total Diners Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalJCB, "Total JCB Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TotalOtherCreditCard, "Total Other Credit Card Sales Amount"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.TerminalNumber, "Terminal Number"))
        trxheader.Add(New TransactionHeaderCls(HeaderEnum.SerialNumber, "Serial Number"))
        Return trxheader
    End Function

End Class
