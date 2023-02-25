Public Class CustomerInfo
    Property MainForm As PaymentForm
    Public Sub New(_mainform As PaymentForm)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MainForm = _mainform
    End Sub
    Private Sub TextBoxCustName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCustTin.KeyPress, TextBoxCustName.KeyPress, TextBoxCustBusiness.KeyPress, TextBoxCustAddress.KeyPress
        If InStr(DisallowedCharactersCustom, e.KeyChar) > 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub CustomerInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If CUST_INFO_FILLED Then

        End If
    End Sub

    Private Sub ButtonCANCEL_Click(sender As Object, e As EventArgs) Handles ButtonCANCEL.Click
        Close()
        CUST_INFO_FILLED = False
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click

        CUST_INFO_FILLED = True
        CUST_INFO_NAME = Trim(TextBoxCustName.Text)
        CUST_INFO_TIN = Trim(TextBoxCustTin.Text)
        CUST_INFO_ADDRESS = Trim(TextBoxCustAddress.Text)
        CUST_INFO_BUSINESS = Trim(TextBoxCustBusiness.Text)

        MainForm.Button7.Text = "CLEAR"
        MainForm.Button7.BackColor = Color.Red
        MainForm.Button7.ForeColor = Color.White

        Me.Dispose()
    End Sub

    Private Sub ButtonKeyboard_Click(sender As Object, e As EventArgs) Handles ButtonKeyboard.Click
        ShowKeyboard()
    End Sub
End Class