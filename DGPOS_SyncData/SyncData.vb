Imports System.Threading
Imports SyncData
Imports POSCommon
Public Class SyncData
    Public Event GetCatchLog(ByVal str As String)
    Public Event GetPrgbarVal(ByVal prgVal As Integer)

    'Fetch Data Variables
    Property ThreadFetchData As Thread
    Property ThreadFetchDataList As List(Of Thread) = New List(Of Thread)

    Public Sub New(ByVal LocalStr As String, ByVal CloudStr As String, ByVal StoreID As Integer, ByVal UserID As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        LocalConnStr = LocalStr
        CloudConnStr = CloudStr
        GlobalStoreID = StoreID
        GlobaluserID = UserID
    End Sub

    Private Sub SyncData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            listOfDefaultVal = ModPosCommon.ReadTextCategories("# Default Value")
            DefaultSyncVal = ModPosCommon.GetItemValue("sync_column_val", listOfDefaultVal)
        Catch ex As Exception
            RaiseEvent GetCatchLog(ex.Message)
        End Try
    End Sub
    Private Sub SyncData_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        BgwFetchData.WorkerReportsProgress = True
        BgwFetchData.WorkerSupportsCancellation = True
        BgwFetchData.RunWorkerAsync()
    End Sub

    Private Sub frmSyncData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MsgBox("Closing")
        StopWorker = False
    End Sub


    Private Sub BgwFetchData_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgwFetchData.DoWork
        Try
            If Not StopWorker Then
                lbSyslog.Text = "Syncing Audit Trail"


                Dim sysLogs As New SyslogsCls
                ThreadFetchData = New Thread(Sub() LogList = sysLogs.FillSysLogs(LocalConnStr))
                ThreadFetchData.Start()
                ThreadFetchDataList.Add(ThreadFetchData)

                For Each t In ThreadFetchDataList
                    t.Join()
                    If (BgwFetchData.CancellationPending) Then
                        ' Indicate that the task was canceled.
                        StopWorker = True
                        e.Cancel = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            RaiseEvent GetCatchLog(ex.Message)
        End Try
    End Sub

    Private Sub BgwFetchData_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgwFetchData.RunWorkerCompleted

    End Sub
End Class
