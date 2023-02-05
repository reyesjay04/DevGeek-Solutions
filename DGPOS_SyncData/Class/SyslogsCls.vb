Imports MySql.Data.MySqlClient
Public Class SyslogsCls
    Property SysID As Integer
    Property SysDate As String
    Property SysGroupName As String
    Property SysSeverity As String
    Property SysCrewID As String
    Property SysDesc As String
    Property SysInfo As String
    Property SysStoreID As String
    Property parentFrm As SyncData

    Public Function FillSysLogs(ByVal ConnLocal As String) As List(Of SyslogsCls)
        Dim sysLogs As New List(Of SyslogsCls)

        Dim comText = $"SELECT * FROM {tblCls.TblAudit} WHERE synced = '{DefaultSyncVal}'"
        Using command As New MySqlCommand
            command.CommandText = comText
            command.Connection = ModConnection.GetLocalConn(ModSyncData.LocalConnStr)
            Using reader As MySqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    While reader.Read
                        Dim sysLogsN As New SyslogsCls
                        sysLogsN.SysID = reader("id")
                        sysLogsN.SysDate = reader("created_at")
                        sysLogsN.SysGroupName = reader("group_name")
                        sysLogsN.SysSeverity = reader("severity")
                        sysLogsN.SysCrewID = reader("crew_id")
                        sysLogsN.SysDesc = reader("description")
                        sysLogsN.SysInfo = reader("description")
                        sysLogsN.SysStoreID = ModSyncData.GlobalStoreID

                    End While
                End If
                reader.Dispose()
            End Using
            command.Dispose()
        End Using
        Return sysLogs
    End Function

End Class
