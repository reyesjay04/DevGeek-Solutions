Module ModSyncData
    Property LocalConnStr As String
    Property CloudConnStr As String
    Property GlobalStoreID As Integer = 0
    Property GlobaluserID As String

    'Interface Variables
    Property StopWorker As Boolean = False
    'List of Class
    Property RefundList As New List(Of RefundCls)
    Property LogList As New List(Of SyslogsCls)
    Property SalesList As New List(Of SalesCls)

    Property listOfDefaultVal As List(Of String)
    Property DefaultSyncVal As String


End Module
