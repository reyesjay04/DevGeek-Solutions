Imports System.Reflection

Public Class FieldTypeCls
    Property FieldName As String
    Property FieldValue As Object
    Property SetFieldValueType As FieldDataType
    Property FieldNumber As String

    Public Class BatchNumberSettings
        Property BusinessDate As Date
        Property NewBatchNumber As Integer
        Property FieldType As String
    End Class
    Enum FieldDataType
        isString
        isDouble
        isInteger
    End Enum
    Public Function GetSalesFieldDataType(ByVal _fieldName As String) As FieldDataType
        Dim fldDt As FieldDataType
        Try
            Dim a As New DailySalesCls
            Dim info() As PropertyInfo = a.GetType().GetProperties()

            Dim typeVal As String = ""

            For Each b As PropertyInfo In info
                If b.Name = _fieldName Then
                    typeVal = b.PropertyType.Name
                    Exit For
                End If
            Next

            Select Case typeVal
                Case "Double"
                    fldDt = FieldDataType.isDouble
                Case "Integer"
                    fldDt = FieldDataType.isInteger
                Case Else
                    fldDt = FieldDataType.isString
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return fldDt
    End Function

    Public Function GetHourlyFieldDataType(ByVal _fieldName As String, Optional _mainClass As String = Nothing) As FieldDataType
        Dim fldDt As FieldDataType
        Try
            Dim hourly As New HourlySalesCls
            Dim hourlyData As New HourlySalesCls.HourlySales

            Dim typeVal As String = ""

            If _mainClass Is Nothing Then
                Dim info() As PropertyInfo = hourly.GetType().GetProperties()
                For Each b As PropertyInfo In info
                    If b.Name = _fieldName Then
                        typeVal = b.PropertyType.Name
                        Exit For
                    End If
                Next
            Else
                Dim info() As PropertyInfo = hourlyData.GetType().GetProperties()
                For Each b As PropertyInfo In info
                    If b.Name = _fieldName Then
                        typeVal = b.PropertyType.Name
                        Exit For
                    End If
                Next
            End If

            Select Case typeVal
                Case "Double"
                    fldDt = FieldDataType.isDouble
                Case "Integer"
                    fldDt = FieldDataType.isInteger
                Case Else
                    fldDt = FieldDataType.isString
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return fldDt
    End Function

    Public Function GetDiscountFieldDataType(ByVal _fieldName As String) As FieldDataType
        Dim fldDt As FieldDataType
        Try
            Dim a As New DiscountDataCls
            Dim info() As PropertyInfo = a.GetType().GetProperties()

            Dim typeVal As String = ""

            For Each b As PropertyInfo In info
                If b.Name = _fieldName Then
                    typeVal = b.PropertyType.Name
                    Exit For
                End If
            Next

            Select Case typeVal
                Case "Double"
                    fldDt = FieldDataType.isDouble
                Case "Integer"
                    fldDt = FieldDataType.isInteger
                Case Else
                    fldDt = FieldDataType.isString
            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return fldDt
    End Function
    Public Function ConvertToDatatype() As String
        Dim strFormat As String = ""
        Select Case SetFieldValueType
            Case FieldDataType.isDouble
                Me.FieldValue = CType(Me.FieldValue, Double)
                strFormat = Me.FieldValue.ToString.Replace(".", "")
            Case FieldDataType.isInteger
                Me.FieldValue = CType(Me.FieldValue, Integer)
                strFormat = Me.FieldValue.ToString
            Case Else
                Me.FieldValue = CType(Me.FieldValue, String)
                strFormat = Me.FieldValue
        End Select
        Return strFormat
    End Function
    Public Function GenLineData() As String
        Dim str As String = ""
        Try
            str = Me.FieldNumber & ConvertToDatatype()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return str
    End Function
End Class
