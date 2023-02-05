Public Class tblCls
    Private Key As String

    Public Shared ReadOnly TblSysLog As New tblCls("loc_system_logs")
    Public Shared ReadOnly TblDailyTrx As New tblCls("loc_daily_transaction")
    Public Shared ReadOnly TblAudit As New tblCls("loc_audit_trail")
    Private Sub New(key As String)
        Me.Key = key
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Key
    End Function
End Class
