Imports System.IO
Imports MySql.Data.MySqlClient

Module ModSIA
    Property TerminalNumber As String
    Property SerialNumber As String
    Property FilePath As String
    Property SalesType As String
    Property HeaderFileName As String
    Property DetailsFileName As String
    Property Settings As SettingsCls
    Property UserType As String
    Property ConnectionString As String
    Property BaseDate As Date
    Property TransactionNumber As String
    Property IsRefund As Boolean
    Property TransactionHeader As List(Of TransactionHeaderCls)
    Property TransactionDetails As List(Of TransactionDetailsCls)

    Property TransactionHeaderFileName As String
    Property TransactionDetailsFileName As String

#Region "Generate CSV File"

    Public Sub CreateTransactionDetails()

    End Sub

#End Region

#Region "Transaction Header/Detail"
    Public Sub CheckCSVFiles(ByRef _basedate As Date)
        FilePath = If(FilePath.EndsWith("\"), FilePath, FilePath & "\")

        TransactionHeaderFileName = $"{Format(_basedate, "MM")}_{Format(_basedate, "yyyy")}_{HeaderFileName}.csv"
        TransactionDetailsFileName = $"{Format(_basedate, "MM")}_{Format(_basedate, "yyyy")}_{DetailsFileName}.csv"

        If Not File.Exists(FilePath & TransactionDetailsFileName) Then
            Using addInfo = File.CreateText(FilePath & TransactionDetailsFileName)
                Dim append_header As String = ""
                For Each str As TransactionDetailsCls In TransactionDetails
                    If str Is TransactionDetails.Last Then
                        append_header &= str.ColumnName
                    Else
                        append_header &= str.ColumnName & ","
                    End If
                Next
                addInfo.Write(append_header & vbCrLf)
                For Each str As String In GenerateTransactionDetails()
                    addInfo.Write(str & vbCrLf)
                Next
            End Using
        Else
            Dim append_str = GenerateTransactionDetails()
            For Each str As String In append_str
                My.Computer.FileSystem.WriteAllText(FilePath & TransactionDetailsFileName, str & vbCrLf, True)
            Next
        End If

        If Not System.IO.File.Exists(FilePath & TransactionHeaderFileName) Then
            Using addInfo = File.CreateText(FilePath & TransactionHeaderFileName)
                Dim append_header As String = ""
                For Each str As TransactionHeaderCls In TransactionHeader
                    If str Is TransactionDetails.Last Then
                        append_header &= str.ColumnName
                    Else
                        append_header &= str.ColumnName & ","
                    End If
                Next
                addInfo.Write(append_header & vbCrLf)
                Dim Transaction = GenerateDailyTransaction()
                addInfo.Write(Transaction & vbCrLf)
            End Using
        Else
            Dim append_str = GenerateDailyTransaction()
            My.Computer.FileSystem.WriteAllText(FilePath & TransactionHeaderFileName, append_str & vbCrLf, True)
        End If
    End Sub
    Private Function GenerateTransactionDetails() As List(Of String)
        Dim nwtrxdet As New List(Of String)

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ConnectionString

        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "SELECT * FROM loc_daily_transaction_details WHERE transaction_number = @TrxNo AND zreading = @ZreadDate"
                mCmd.Parameters.AddWithValue("@TrxNo", TransactionNumber)
                mCmd.Parameters.AddWithValue("@ZreadDate", Format(BaseDate, "yyyy-MM-dd"))
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read

                            Dim discounts As String = ""
                            Dim discount_total As Double = mReader("seniordisc") + mReader("pwddisc") + mReader("athletedisc") + mReader("spdisc")

                            discounts = If(mReader("seniordisc") <> 0, "Senior Discount 20%::", "")
                            discounts &= If(mReader("pwddisc") <> 0, "PWD Discount 20%::", "")
                            discounts &= If(mReader("athletedisc") <> 0, "PWD Discount 20%::", "")
                            discounts &= If(mReader("spdisc") <> 0, "Sports Discount 20%::", "")

                            Try
                                discounts = discounts.Substring(0, discounts.Length - 2)
                            Catch ex As Exception
                                discounts = ""
                            End Try

                            Dim str = $"{mReader("transaction_number").ToString},{mReader("product_id").ToString},{mReader("product_name").ToString},{mReader("product_category").ToString},,,{mReader("quantity").ToString}"
                            str &= $",{If(ModSIA.IsRefund, "-" & mReader("total").ToString, mReader("total").ToString)},{If(ModSIA.IsRefund, "-" & mReader("price").ToString, mReader("price").ToString)},{discounts},{discount_total},,0,,0,,,{If(ModSIA.IsRefund, mReader("quantity").ToString, 0)},{If(ModSIA.IsRefund, mReader("total").ToString, 0)}"
                            nwtrxdet.Add(str)
                        End While
                    End If
                    mReader.Dispose()
                End Using
                mCmd.Dispose()
            End Using

        Catch ex As Exception
        End Try

        mConn.Close()
        Return nwtrxdet
    End Function

    Private Function GenerateDailyTransaction() As String
        Dim str As String = ""

        Dim mConn As New MySqlConnection
        mConn.ConnectionString = ConnectionString

        Try
            Dim nwtrx As New List(Of String)
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.Parameters.Clear()
                mCmd.CommandText = "SELECT ldt.*, SUM(ldtd.seniorqty) as SenQty, SUM(ldtd.pwdqty) as PWDQty, SUM(ldtd.seniordisc) as SenDisc, SUM(ldtd.pwddisc) as PWDDisc, 
                                    SUM(ldtd.athletedisc) as SportDisc
                                    FROM loc_daily_transaction ldt LEFT JOIN loc_daily_transaction_details ldtd ON ldtd.transaction_number = ldt.transaction_number 
                                    LEFT JOIN loc_coupon_data lcd ON lcd.transaction_number = ldt.transaction_number WHERE ldt.transaction_number = @TrxNo "
                mCmd.Parameters.AddWithValue("@TrxNo", TransactionNumber)
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read

                            nwtrx.Add(mReader("transaction_number").ToString)
                            nwtrx.Add(mReader("zreading").ToString)
                            nwtrx.Add(mReader("actual_trx_date").ToString)
                            nwtrx.Add(mReader("actual_trx_date").ToString)
                            nwtrx.Add(SalesType)
                            nwtrx.Add(mReader("transaction_type").ToString)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(If(ModSIA.IsRefund, mReader("quantity").ToString, 0))
                            nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("total").ToString, 0))

                            nwtrx.Add("") 'Guest Count - DONE
                            nwtrx.Add(mReader("SenQty").ToString)
                            nwtrx.Add(mReader("PWDQty").ToString)
                            nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("grosssales").ToString, mReader("grosssales").ToString))
                            nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("amountdue").ToString, mReader("amountdue").ToString)) 'Net Sales
                            nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("vatablesales").ToString, mReader("vatablesales").ToString))
                            nwtrx.Add(0) 'Other Local Tax
                            nwtrx.Add(0) 'Total Service Charge
                            nwtrx.Add(0) 'Total Tip
                            nwtrx.Add(mReader("totaldiscount").ToString)

                            nwtrx.Add(mReader("lessvat").ToString)
                            nwtrx.Add(mReader("vatexemptsales").ToString)
                            nwtrx.Add("") 'Discount Name 22 - DONE
                            nwtrx.Add("") 'Discount Amount 23 - DONE
                            nwtrx.Add(0)
                            nwtrx.Add(mReader("SenDisc").ToString)
                            nwtrx.Add(0) 'VIP
                            nwtrx.Add(mReader("PWDDisc").ToString)
                            nwtrx.Add(mReader("SportDisc").ToString)
                            nwtrx.Add(0) 'Smac

                            nwtrx.Add(0) 'Online Deals
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)

                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(0)
                            nwtrx.Add(mReader("transaction_type").ToString)
                            nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("amounttendered").ToString, mReader("amounttendered").ToString))
                            nwtrx.Add("") 'paymenttype2 
                            nwtrx.Add(0) 'paymentamount2 
                            nwtrx.Add("") 'paymenttype3 
                            nwtrx.Add(0) 'Payment Amount 3

                            'totalcashsales 
                            Select Case mReader("transaction_type").ToString
                                Case "Walk-In", "Registered"
                                    nwtrx.Add(If(ModSIA.IsRefund, "-" & mReader("amounttendered").ToString, mReader("amounttendered").ToString))
                                Case Else
                                    nwtrx.Add(0)
                            End Select

                            nwtrx.Add(0) 'totalgiftcheque 
                            nwtrx.Add(0) 'totaldebit 

                            'totalewallet 
                            Select Case mReader("transaction_type").ToString
                                Case "Walk-In", "Registered"
                                    nwtrx.Add("0.00")
                                Case Else
                                    nwtrx.Add(mReader("amounttendered").ToString)
                            End Select

                            nwtrx.Add(0) 'totaltendersales amount 
                            nwtrx.Add(0) 'totalmastercard  
                            nwtrx.Add(0) 'totalvisa  
                            nwtrx.Add(0) 'totalamerican  
                            nwtrx.Add(0) 'totaldinerssales  
                            nwtrx.Add(0) 'totaljcb 
                            nwtrx.Add(0) 'totalothercreditcard 

                            nwtrx.Add(TerminalNumber)
                            nwtrx.Add(SerialNumber)
                        End While
                    End If
                    mReader.Dispose()
                End Using
                mCmd.CommandText = "SELECT totalguest FROM loc_senior_details WHERE transaction_number = @TrxNo"
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read
                            nwtrx(10) = If(mReader("totalguest") > 0, mReader("totalguest"), 1)
                        End While
                    End If
                    mReader.Dispose()
                End Using

                mCmd.CommandText = "SELECT GROUP_CONCAT(CONCAT(reference_id, '=', coupon_name) SEPARATOR '::') AS DiscountName, GROUP_CONCAT(coupon_total SEPARATOR '::') as DiscountTotal FROM loc_coupon_data WHERE transaction_number = @TrxNo AND coupon_type <> 'Fix-1'"
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read
                            nwtrx(22) = mReader("DiscountName").ToString
                            nwtrx(23) = mReader("DiscountTotal").ToString
                        End While
                    End If
                    mReader.Dispose()
                End Using

                mCmd.CommandText = "SELECT coupon_total FROM loc_coupon_data WHERE transaction_number = @TrxNo AND coupon_type = 'Fix-1'"
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    If mReader.HasRows Then
                        While mReader.Read
                            nwtrx(50) = mReader("coupon_total").ToString
                        End While
                    End If
                    mReader.Dispose()
                End Using
                mCmd.Dispose()
            End Using

            For Each ap_str As String In nwtrx
                If ap_str Is nwtrx.Last Then
                    str &= ap_str
                Else
                    str &= ap_str & ","
                End If
            Next

        Catch ex As Exception
        End Try
        mConn.Close()
        Return str
    End Function

#End Region
End Module
