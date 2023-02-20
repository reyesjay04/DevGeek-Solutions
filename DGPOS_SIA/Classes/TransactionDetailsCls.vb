Public Class TransactionDetailsCls
    Enum DetailsEnum
        OrderNumber
        ItemID
        ItemName
        ItemParentCategory
        ItemCategory
        ItemSub
        ItemQty
        ItemPrice
        MenuPrice
        DiscountCode
        DiscountedAmount
        ModifierName1
        ModifierQuantity1
        ModifierName2
        ModifierQuantity2
        Void
        VoidAmount
        Refund
        RefundAmount
    End Enum
    Property ColumnID As Integer
    Property ColumnName As String

    Public Sub New(ByVal _columnID As Integer, ByVal _columnName As String)
        Me.ColumnID = _columnID
        Me.ColumnName = _columnName
    End Sub

    Public Shared Function CreateTransactionDetailsColumn() As List(Of TransactionDetailsCls)
        Dim trxDet As New List(Of TransactionDetailsCls)
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.OrderNumber, "Order Num / Bill Num"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemID, "Item ID"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemName, "Item Name"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemParentCategory, "Item Parent Category"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemCategory, "Item Category"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemSub, "Item Sub-Category"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemQty, "Item Quantity"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ItemPrice, "Transaction Item Price"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.MenuPrice, "Menu Item Price"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.DiscountCode, "Discount Code"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.DiscountedAmount, "Discount Amount"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ModifierName1, "Modifier (1) Name"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ModifierQuantity1, "Modifier (1) Quantity"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ModifierName2, "Modifier (2) Name"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.ModifierQuantity2, "Modifier (2) Quantity"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.Void, "Void"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.VoidAmount, "Void Amount"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.Refund, "Refund"))
        trxDet.Add(New TransactionDetailsCls(DetailsEnum.RefundAmount, "Refund Amount"))
        Return trxDet
    End Function

End Class
