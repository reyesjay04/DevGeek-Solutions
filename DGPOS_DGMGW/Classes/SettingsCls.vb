Imports System.Globalization
Imports DGPOS_COMMON
Public Class SettingsCls
    Property RetailCode As String
    Property RetailLength As Integer
    Property TerminalNo As String
    Property BDFormat As String
    Property BDStart As Date
    Property BDEnd As Date
    Property ListOfMGWSettings As List(Of String)
    Public Sub New()
        GetSettings()
    End Sub

    Private Sub GetSettings()
        serviceConfigName = "DG_DGMGW.config"
        Try
            ListOfMGWSettings = ModPosCommon.ReadTextCategories("MGW Settings")
            BDFormat = ModPosCommon.GetItemValue("business_date_format", "MMddyyyy", ListOfMGWSettings)
            RetailLength = ModPosCommon.GetItemValue("retail_partnercode_length", "4", ListOfMGWSettings)
            RetailCode = ModPosCommon.GetItemValue("retail_partner_code", "0", ListOfMGWSettings)
            TerminalNo = ModPosCommon.GetItemValue("terminal_number", "0", ListOfMGWSettings)

            Dim time_start = ModPosCommon.GetItemValue("business_hour_start", "10:00", ListOfMGWSettings)
            Dim time_end = ModPosCommon.GetItemValue("business_hour_end", "11:00", ListOfMGWSettings)

            Try
                BDStart = Date.ParseExact(time_start, "HH:mm", CultureInfo.InvariantCulture)
            Catch ex As Exception
                BDStart = Now
            End Try

            Try
                BDEnd = Date.ParseExact(time_end, "HH:mm", CultureInfo.InvariantCulture)
                If BDStart > BDEnd Then
                    BDEnd = BDEnd.AddDays(1)
                End If
            Catch ex As Exception
                BDEnd = Now
            End Try

        Catch ex As Exception
        End Try
    End Sub

End Class
