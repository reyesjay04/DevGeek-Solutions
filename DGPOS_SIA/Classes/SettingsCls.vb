Imports DGPOS_COMMON
Public Class SettingsCls
    Property TerminalNumber As String
    Property SerialNumber As String
    Property FilePath As String
    Property SalesType As String
    Property HeaderFileName As String
    Property DetailsFileName As String
    Property ListOfSIASettings As List(Of String)
    Public Sub New()
        GetSettings()
    End Sub

    Private Sub GetSettings()
        serviceConfigName = "DG_SIASYS.config"
        Try

            ListOfSIASettings = ModPosCommon.ReadTextCategories("SIA Settings")
            TerminalNumber = ModPosCommon.GetItemValue("terminal_id", "0", ListOfSIASettings)
            SerialNumber = ModPosCommon.GetItemValue("serial_number", "4", ListOfSIASettings)
            FilePath = ModPosCommon.GetItemValue("file_path", "0", ListOfSIASettings)
            SalesType = ModPosCommon.GetItemValue("sales_type", "0", ListOfSIASettings)
            HeaderFileName = ModPosCommon.GetItemValue("daily_transaction_file_name", "transactions", ListOfSIASettings)
            DetailsFileName = ModPosCommon.GetItemValue("daily_transaction_details_file_name", "transactiondetails", ListOfSIASettings)

        Catch ex As Exception
        End Try
    End Sub

End Class
