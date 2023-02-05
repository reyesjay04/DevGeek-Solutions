Imports MySql.Data.MySqlClient
Module ModConnection
    Property ConnStr As String
    Property ConnStr2 As String
    Property ConnPath As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Innovention\user.config" 'Default POS Config Path
    Property LocalConnectionString As String
    Property CloudConnectionString As String
    Property ValidLocalConn As Boolean = False
    Property ValidCloudConn As Boolean = False
    'TEST CONNECTION STRING IF VALID
    Public Sub LoadConnectionConfig()
        'Set connection string from config file
        GetConnectionConf()
        'Test local conn
        TestLocalConn()
        'Set connection string from database column
        GetCloudConfig()
        'Test cloud conn
        TestCloudConn()
    End Sub
    Private Sub TestLocalConn()
        Dim Conn As New MySqlConnection
        Conn.ConnectionString = LocalConnectionString
        Try
            Conn.Open()
            ValidLocalConn = True
        Catch ex As Exception
            ValidLocalConn = False
        End Try
    End Sub
    Private Sub TestCloudConn()
        Dim Conn As New MySqlConnection
        Conn.ConnectionString = CloudConnectionString
        Try
            Conn.Open()
            ValidCloudConn = True
        Catch ex As Exception
            ValidCloudConn = False
        End Try
    End Sub
    'SET CONNECTION STRING
    Private Sub GetConnectionConf()
        Try
            If System.IO.File.Exists(ConnPath) Then
                'The File exists 
                Dim CreateConnString As String = ""
                Dim filename As String = String.Empty
                Dim TextLine As String = ""
                Dim objReader As New System.IO.StreamReader(ConnPath)
                Dim lineCount As Integer
                Do While objReader.Peek() <> -1
                    TextLine = objReader.ReadLine()
                    If lineCount = 0 Then
                        ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "server="))
                        ConnStr2 = "server=" & ConnStr
                    End If
                    If lineCount = 1 Then
                        ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "user id="))
                        ConnStr2 += ";user id=" & ConnStr
                    End If
                    If lineCount = 2 Then
                        ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "password="))
                        ConnStr2 += ";password=" & ConnStr
                    End If
                    If lineCount = 3 Then
                        ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "database="))
                        ConnStr2 += ";database=" & ConnStr
                    End If
                    If lineCount = 4 Then
                        ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "port="))
                        ConnStr2 += ";port=" & ConnStr
                    End If
                    If lineCount = 5 Then
                        ConnStr2 += ";" & TextLine
                    End If
                    lineCount = lineCount + 1
                Loop
                LocalConnectionString = ConnStr2
                objReader.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetCloudConfig()
        Try
            If ValidLocalConn Then
                Dim ConnLocal = LocalHostConn()
                Dim Query = "SELECT C_Server, C_Username, C_Password, C_Database, C_Port FROM loc_settings WHERE settings_id = 1"
                Dim Com As New MySqlCommand(Query, ConnLocal)
                Using reader As MySqlDataReader = Com.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read
                            CloudConnectionString = "server=" & ConvertB64ToString(reader("C_Server")) &
                                "user id=" & ConvertB64ToString(reader("C_Username")) &
                                "password=" & ConvertB64ToString(reader("C_Password")) &
                                "database=" & ConvertB64ToString(reader("C_Database")) &
                                "port=" & ConvertB64ToString(reader("C_Port"))
                        End While
                    Else
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    'CONNECTION
    Public Function LocalHostConn() As MySqlConnection
        Dim Conn As New MySqlConnection
        Conn.ConnectionString = LocalConnectionString
        Try
            Conn.Open()
        Catch ex As Exception
            ValidLocalConn = False
            MsgBox(ex.ToString)
        End Try
        Return Conn
    End Function
    Public Function CloudHostConn() As MySqlConnection
        Dim Conn As New MySqlConnection
        Conn.ConnectionString = CloudConnectionString
        Try
            Conn.Open()
        Catch ex As Exception
            ValidCloudConn = False
            MsgBox(ex.ToString)
        End Try
        Return Conn
    End Function
End Module
