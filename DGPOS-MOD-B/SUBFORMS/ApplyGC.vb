Imports MySql.Data.MySqlClient

Public Class ApplyGC
    Property ConnectionString As String
    Property AmountPayable As Double
    Property MainForm As PaymentForm
    Public Sub New(ByVal _mainForm As PaymentForm, ByVal _connstr As String, ByVal _amountpayable As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConnectionString = _connstr
        AmountPayable = _amountpayable
        MainForm = _mainForm
    End Sub
    Private Sub GiftCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopMost = True
        ListOfGiftCheques = GetGiftCheques()
        LoadGiftCheques()
    End Sub
    Property ListOfGiftCheques As New List(Of GiftCheque)
    Public Class GiftCheque
        Property Code As Integer
        Property Name As String
        Property Description As String
        Property DiscountValue As String
        Property ReferenceVal As String
        Property Type As String
        Property BundleBase As String
        Property BundleValue As String
        Property BundlePromo As String
        Property BundlePromoValue As String
    End Class
    Private Sub LoadGiftCheques()
        Try
            For Each a As GiftCheque In ListOfGiftCheques

                Dim index = dgvGC.Rows.Add()
                Dim row = dgvGC.Rows(index)

                row.Cells(colID.Index).Value = a.Code
                row.Cells(colName.Index).Value = a.Name
                row.Cells(colDesc.Index).Value = a.Description
                row.Cells(colDiscVal.Index).Value = a.DiscountValue
                row.Cells(colRefVal.Index).Value = a.ReferenceVal
                row.Cells(colType.Index).Value = a.Type
                row.Cells(colBBase.Index).Value = a.BundleBase
                row.Cells(colBBVal.Index).Value = a.BundleValue
                row.Cells(colBP.Index).Value = a.BundlePromo
                row.Cells(colBPVal.Index).Value = a.BundlePromoValue

                row.Tag = a
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetGiftCheques() As List(Of GiftCheque)
        Dim nwlstgc As New List(Of GiftCheque)
        Dim mConn As New MySqlConnection

        mConn.ConnectionString = ConnectionString
        Try
            mConn.Open()
            Using mCmd = New MySqlCommand("", mConn)
                mCmd.CommandText = "SELECT * FROM tbcoupon WHERE Type = 'Fix-1' AND active = 1"
                mCmd.Prepare()

                Using mReader = mCmd.ExecuteReader
                    While mReader.Read
                        Dim nwgc As New GiftCheque With {
                            .Code = mReader("ID"),
                            .Name = mReader("Couponname_"),
                            .Description = mReader("Desc_"),
                            .DiscountValue = mReader("Discountvalue_"),
                            .ReferenceVal = mReader("Referencevalue_"),
                            .Type = mReader("Type"),
                            .BundleBase = mReader("Bundlebase_"),
                            .BundleValue = mReader("BBValue_"),
                            .BundlePromo = mReader("Bundlepromo_"),
                            .BundlePromoValue = mReader("BPValue_")
                        }
                        nwlstgc.Add(nwgc)
                    End While
                    mReader.Dispose()
                End Using

                mCmd.Dispose()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        mConn.Close()
        Return nwlstgc
    End Function

    Private Sub dgvGC_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGC.CellContentDoubleClick
        Try
            Dim row As DataGridViewRow = dgvGC.CurrentRow
            Dim rc = CType(row.Tag, GiftCheque)

            GCDetails = New ApplyGCCls
            With GCDetails

                If AmountPayable > CType(rc.DiscountValue, Double) Then
                    Dim AmountDue = Math.Round(AmountPayable - CType(rc.DiscountValue, Double), 2, MidpointRounding.AwayFromZero)
                    MainForm.TextBoxTOTALPAY.Text = NUMBERFORMAT(AmountDue)
                    .TotalCouponValue = CType(rc.DiscountValue, Double)
                Else
                    .TotalCouponValue = AmountPayable
                    MainForm.TextBoxTOTALPAY.Text = "0.00"
                End If
                .CouponDesc = rc.Description
                .CouponName = rc.Name
                .ID = rc.Code
                .DiscountValue = rc.DiscountValue
                .Type = rc.Type

            End With

            GCAPPLIED = True
            MainForm.ButtonGC.Text = "CLEAR"
            MainForm.ButtonGC.BackColor = Color.Red
            MainForm.ButtonGC.ForeColor = Color.White

            If DiscAppleid Then
                MainForm.TextBoxDiscType.Text = "DISC + GC"
            Else
                If PromoType = "Percentage(w/ vat)" Then
                    MainForm.TextBoxDiscType.Text = "DISC + GC"
                Else
                    MainForm.TextBoxDiscType.Text = "Fix-1"
                End If
            End If

            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class