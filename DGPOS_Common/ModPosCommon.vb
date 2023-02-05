Imports System.IO
Imports MySql.Data.MySqlClient
Public Module ModPosCommon
    Property appPath As String = Application.StartupPath()
    Property serviceConfigPath As String = "\Config\"
    Property serviceConfigName As String = "service.config"
    Public Function ConvertB64ToString(str As String)
        Dim b As Byte() = Convert.FromBase64String(str)
        Dim byt2 = System.Text.Encoding.UTF8.GetString(b)
        Return byt2
    End Function

    Public Function RemoveCharacter(ByVal stringToCleanUp, ByVal characterToRemove)
        ' replace the target with nothing
        ' Replace() returns a new String and does not modify the current one
        Return stringToCleanUp.Replace(characterToRemove, "")
    End Function

    Public Function ReadTextCategories(ByVal readConfigOf As String) As List(Of String)
        Dim ListOfUnderCat As New List(Of String)
        Dim FullPath As String = appPath & serviceConfigPath & serviceConfigName
        Try
            Dim allLinesfrom As List(Of String) = File.ReadAllLines(FullPath).ToList

            Dim categoryIndex As Integer = 1
            For Each line As String In allLinesfrom
                If line.Contains($"[{readConfigOf}]") Then
                    Exit For
                End If
                categoryIndex += 1
            Next

            Dim getstartingIndex As Integer = 0
            For Each line As String In allLinesfrom
                getstartingIndex += 1
                If getstartingIndex > categoryIndex Then
                    If Not line.Contains("#") Or line.Contains("[") Then
                        If line <> "" Then
                            ListOfUnderCat.Add(line)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ListOfUnderCat
    End Function

    Public Function GetItemValue(ByVal ItemName As String, ByVal _defaultVal As String, ByVal listofCat As List(Of String))
        Dim returnCat As String = ""
        Dim getContent As String = ""
        Dim sepIndex As Integer = 1
        Try
            For Each u As String In listofCat
                If u.Contains(ItemName) Then
                    getContent = u
                    sepIndex += u.IndexOf("=")
                    Exit For
                End If
            Next

            If sepIndex = 1 Then
                returnCat = _defaultVal
            Else
                returnCat = getContent.Substring(sepIndex)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return returnCat
    End Function

    Public Sub SetItemValue(ByVal category As String, ByRef val As String)
        Dim ListOfUnderCat As New List(Of String)
        Dim FullPath As String = appPath & serviceConfigPath & serviceConfigName

        Try
            Dim allLinesfrom As List(Of String) = File.ReadAllLines(FullPath).ToList

            For Each line As String In allLinesfrom
                If line.Contains(category) And Not line.Contains(";") And Not line.Contains("[") Then
                    line = category & "=" & val
                End If
                ListOfUnderCat.Add(line)
            Next

            File.WriteAllLines(FullPath, ListOfUnderCat)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

End Module
