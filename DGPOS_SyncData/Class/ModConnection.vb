Imports MySql.Data.MySqlClient
Module ModConnection


    Public Function GetLocalConn(ByVal ConStr As String) As MySqlConnection
        Dim openCon As New MySqlConnection
        Try
            openCon.ConnectionString = ConStr
            openCon.Open()
        Catch ex As Exception
        End Try
        Return openCon
    End Function

End Module
