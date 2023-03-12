Imports System.ComponentModel

Public Class subreports
    Private Sub ButtonMGW_Click(sender As Object, e As EventArgs) Handles ButtonMGW.Click
        Try
            Dim ins As System.Reflection.Assembly
            ins = System.Reflection.Assembly.LoadFile(Application.StartupPath & "\DGPOS_DGMGW.dll")


            Dim params As String = "user_type^" & ClientRole & ",connection^" & LocalConnectionString & ",export_path^" & S_ExportPath & ",from_reporting_date^" & S_Zreading & ",to_reporting_date^" & S_Zreading & ",show_dialog_box^Y"

            Dim obj As Object = ins.CreateInstance("DGPOS_DGMGW.DGPOS_DGMGW", True, Nothing, Nothing, New String() {params}, Nothing, Nothing)
            Dim frm As Form = CType(obj, Form)
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub subreports_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Reports.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Enable_SIA_Functionality Then
            Try
                Dim params As String = "user_type^" & ClientRole & ",connection^" & LocalConnectionString & ",base_date^" & S_Zreading & ",transaction_number^" & S_TRANSACTION_NUMBER & ",is_refund^N"

                Dim ins As System.Reflection.Assembly
                ins = System.Reflection.Assembly.LoadFile(Application.StartupPath & "\DG_SIASYS.dll")

                Dim obj As Object = ins.CreateInstance("DG_SIASYS.DG_SIASYS", True, Nothing, Nothing, New String() {params}, Nothing, Nothing)
                Dim frm As Form = CType(obj, Form)
                frm.ShowDialog()

            Catch ex As Exception
            End Try
        End If
    End Sub
End Class