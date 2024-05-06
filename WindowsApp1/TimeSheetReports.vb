Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Excel = Microsoft.Office.Interop.Excel

Public Class TimeSheetReports
    Dim CON As New OleDbConnection
    Dim CMD As New OleDbCommand
    Dim dt As New DataTable
    Dim dr As OleDbDataReader
    Private Sub TimeSheetReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DT_Date.Format = DateTimePickerFormat.Custom
        DT_Date.CustomFormat = "dd/MM/yyyy"
        SetRoundedButton(Btn_show, 5)
        SetRoundedButton(Btn_Export, 5)
        SetRoundedButton(Btn_Print, 5)
        Btn_show.BackColor = Color.DodgerBlue
        Btn_show.ForeColor = Color.White
        Btn_Export.BackColor = Color.DodgerBlue
        Btn_Export.ForeColor = Color.White
        Btn_Print.BackColor = Color.DodgerBlue
        Btn_Print.ForeColor = Color.White
        Try
            CON.ConnectionString = ConString
            CMD = CON.CreateCommand
            If CON.State = ConnectionState.Closed Then CON.Open()
            CMD.CommandText = "select StaffName from StaffMaster"
            dr = CMD.ExecuteReader()
            Cmb_StaffName.Items.Clear()
            While dr.Read()
                ' Add each item to the ComboBox
                Cmb_StaffName.Items.Add(dr("StaffName").ToString())
            End While
            dr.Close()
            CON.Close()
        Catch ex As Exception
            MsgBox("error message:" & ex.Message)
        Finally
            If CON.State = ConnectionState.Closed Then CON.Open()
        End Try

    End Sub

    Private Sub TimeSheetReports_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Left = (Me.Width - Panel1.Width) / 2
    End Sub
    Private Function RoundedRectangle(ByVal rectangle As Rectangle, ByVal cornerRadius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = cornerRadius * 2
        Dim arcRectangle As New Rectangle(rectangle.Location, New Size(diameter, diameter))

        ' Top left corner
        path.AddArc(arcRectangle, 180, 100)

        ' Top side (excluding corners)
        path.AddLine(rectangle.Left + cornerRadius, rectangle.Top, rectangle.Right - cornerRadius, rectangle.Top)

        ' Top right corner
        arcRectangle.X = rectangle.Right - diameter
        path.AddArc(arcRectangle, 270, 10)

        ' Right side (excluding top and bottom corners)
        path.AddLine(rectangle.Right, rectangle.Top + cornerRadius, rectangle.Right, rectangle.Bottom - cornerRadius)

        ' Bottom right corner
        arcRectangle.Y = rectangle.Bottom - diameter
        path.AddArc(arcRectangle, 0, 90)

        ' Bottom side (excluding corners)
        path.AddLine(rectangle.Right - cornerRadius, rectangle.Bottom, rectangle.Left + cornerRadius, rectangle.Bottom)

        ' Bottom left corner
        arcRectangle.X = rectangle.Left
        path.AddArc(arcRectangle, 90, 90)

        ' Left side (excluding top and bottom corners)
        path.AddLine(rectangle.Left, rectangle.Bottom - cornerRadius, rectangle.Left, rectangle.Top + cornerRadius)

        path.CloseFigure()
        Return path
    End Function
    Private Sub SetRoundedButton(ByVal button As System.Windows.Forms.Button, ByVal cornerRadius As Integer)
        button.FlatAppearance.BorderSize = 0
        Dim region As New Region(RoundedRectangle(New Rectangle(0, 0, button.Width, button.Height), cornerRadius))
        button.Region = region
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint_2(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    'Private Sub Btn_show_Click(sender As Object, e As EventArgs) Handles Btn_show.Click
    '    Try
    '        'CON.ConnectionString = ConString
    '        If CON.State = ConnectionState.Closed Then CON.Open()
    '        'CMD = CON.CreateCommand
    '        TReport_ListView.View = View.Details
    '        TReport_ListView.GridLines = True
    '        TReport_ListView.FullRowSelect = True
    '        TReport_ListView.Columns.Clear()
    '        TReport_ListView.Items.Clear()
    '        TReport_ListView.Columns.Add("Sl.No", 60)
    '        TReport_ListView.Columns.Add("BillNo", 100)
    '        TReport_ListView.Columns.Add("EntryTime", 100)
    '        TReport_ListView.Columns.Add("EndTime", 150)
    '        TReport_ListView.Columns.Add("Amount", 100)
    '        Dim arr(6) As String
    '        Dim itm As ListViewItem
    '        Dim SL As Double
    '        SL = 0
    '        CMD.CommandText = "select BillNo,EntryTime,EndTime,Amount from Bill_inf where Staff_Name='" & UCase(Trim(Me.Cmb_StaffName.Text)) & "'"
    '        'dr = CMD.ExecuteReader
    '        dr = CMD.ExecuteReader
    '        While dr.Read
    '            arr(0) = dr("BillNo").ToString
    '            arr(1) = dr("EntryDate").ToString
    '            arr(2) = dr("EntryTime").ToString
    '            arr(3) = dr("EndTime").ToString
    '            arr(4) = dr("Amount").ToString
    '            itm = New ListViewItem(arr)
    '            TReport_ListView.Items.Add(itm)
    '        End While
    '        dr.Close()
    '    Catch ex As Exception
    '        MsgBox("error:" & ex.Message)
    '    Finally
    '        If CON.State = ConnectionState.Open Then
    '            CON.Close()
    '        End If
    '        CON.Close()
    '    End Try
    'End Sub
    'Private Sub Btn_show_Click(sender As Object, e As EventArgs) Handles Btn_show.Click
    '    Try
    '        TReport_ListView.View = View.Details
    '        TReport_ListView.GridLines = True
    '        TReport_ListView.FullRowSelect = True
    '        TReport_ListView.Columns.Clear()
    '        TReport_ListView.Items.Clear()
    '        TReport_ListView.Columns.Add("Sl.No", 60)
    '        TReport_ListView.Columns.Add("BillNo", 100)
    '        TReport_ListView.Columns.Add("EntryTime", 100)
    '        TReport_ListView.Columns.Add("EndTime", 150)
    '        TReport_ListView.Columns.Add("Amount", 100)

    '        Dim arr(4) As String
    '        Dim itm As ListViewItem
    '        Dim SL As Integer = 0

    '        If CON.State = ConnectionState.Closed Then CON.Open()
    '        Using CMD As New OleDbCommand("SELECT BillNo, EntryTime, EndTime, Amount FROM Bill_inf WHERE Staff_Name = ? ", CON) 'and EntryDate=?"
    '            CMD.Parameters.AddWithValue("@Staff_Name", Cmb_StaffName.Text)
    '            '  CMD.Parameters.AddWithValue("@EntryDate", Me.DT_Date.Value.Date.ToString("MM-dd-yyyy"))


    '            ' Format(Me.DT_Date, "MM-dd-yyyy")) 'Format(Me., "MM-dd-yyyy"))
    '            Using dr As OleDbDataReader = CMD.ExecuteReader()
    '                While dr.Read()
    '                    SL += 1
    '                    arr(0) = SL.ToString()
    '                    arr(1) = dr("BillNo").ToString()
    '                    'arr(2) = dr("EntryTime").ToString("hh:mm tt")
    '                    'arr(3) = dr("EndTime").ToString("hh:mm tt")
    '                    arr(2) = CType(dr("EntryTime"), DateTime).TimeOfDay.ToString()
    '                    arr(3) = CType(dr("EndTime"), DateTime).TimeOfDay.ToString()
    '                    arr(4) = dr("Amount").ToString()
    '                    itm = New ListViewItem(arr)
    '                    TReport_ListView.Items.Add(itm)
    '                End While
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message)
    '    Finally
    '        If CON.State = ConnectionState.Open Then
    '            CON.Close()
    '        End If
    '    End Try
    'End Sub

    Private Sub Btn_show_Click(sender As Object, e As EventArgs) Handles Btn_show.Click
        Try
            TReport_ListView.View = View.Details
            TReport_ListView.GridLines = True
            TReport_ListView.FullRowSelect = True
            TReport_ListView.Columns.Clear()
            TReport_ListView.Items.Clear()
            TReport_ListView.Columns.Add("Sl.No") ', 60)
            TReport_ListView.Columns.Add("BillNo", 100) ', 100)
            TReport_ListView.Columns.Add("EntryTime", 150) ', 100)
            TReport_ListView.Columns.Add("EndTime", 150) ',
            TReport_ListView.Columns.Add("Amount", 160) ', 100)

            Dim arr(4) As String
            Dim itm As ListViewItem
            Dim SL As Integer = 0
            Dim totalAmount As Decimal = 0 ' Initialize total amount variable

            If CON.State = ConnectionState.Closed Then CON.Open()
            Using CMD As New OleDbCommand("SELECT BillNo, EntryTime, EndTime, Amount FROM Bill_inf WHERE Staff_Name ='" & Cmb_StaffName.Text & "' and EntryDate=#" & Me.DT_Date.Value.Date.ToString("MM-dd-yyyy") & "#", CON)
                ' CMD.Parameters.AddWithValue("@Staff_Name", Cmb_StaffName.Text)

                Using dr As OleDbDataReader = CMD.ExecuteReader()
                    While dr.Read()
                        SL += 1
                        arr(0) = SL.ToString()
                        arr(1) = dr("BillNo").ToString()
                        'arr(2) = dr("EntryTime").ToString("hh:mm tt")
                        'arr(3) = dr("EndTime").ToString("hh:mm tt")
                        arr(2) = CType(dr("EntryTime"), DateTime).TimeOfDay.ToString()
                        arr(3) = CType(dr("EndTime"), DateTime).TimeOfDay.ToString()
                        arr(4) = dr("Amount").ToString()
                        itm = New ListViewItem(arr)
                        TReport_ListView.Items.Add(itm)

                        ' Accumulate total amount
                        totalAmount += Convert.ToDecimal(dr("Amount"))
                    End While
                End Using
            End Using

            ' Display total amount
            Txt_TotalAmount.Text = Format(totalAmount, "0.00")

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If CON.State = ConnectionState.Open Then
                CON.Close()
            End If
        End Try
    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Call ExporttoListView(TReport_ListView)
    End Sub

    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click

    End Sub
End Class
'If CON.State = ConnectionState.Closed Then CON.Open()
'            TReport_ListView.View = View.Details
'TReport_ListView.GridLines = True
'TReport_ListView.FullRowSelect = True
'TReport_ListView.Columns.Clear()
'TReport_ListView.Items.Clear()
'TReport_ListView.Columns.Add("SNo", 60)
'TReport_ListView.Columns.Add("Bill No", 100)
'TReport_ListView.Columns.Add("Check-In", 100)
'TReport_ListView.Columns.Add("Check-Out", 100)
'TReport_ListView.Columns.Add("Amount", 100)