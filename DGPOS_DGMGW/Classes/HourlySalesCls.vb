Public Class HourlySalesCls
    Property RetailPartnerCode As String
    Property TerminalNumber As String
    Property BaseDate As String
    Property HourlyData As List(Of HourlySales)
    Public Class HourlySales
        Property HourCode As String
        Property NetSalesAmount As Double
        Property SalesTransaction As Integer
        Property CustomerCount As Integer
    End Class
    Property TotalNetSales As Double
    Property TotalNumberOfSales As Integer
    Property TotalCustomerCount As Integer
End Class
