Imports System.Data.OleDb
Imports System.Drawing.Drawing2D
Imports System.Threading

Public Class BtnOptions
    Dim DT As New DataTable
    Dim con As New OleDbConnection
    Dim cmd As OleDbCommand
    Private Sub BtnOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRoundedButton(Btn_Start, 15)
        SetRoundedButton(Btn_Stop, 15)
        SetRoundedButton(Btn_Cancel, 15)
        Btn_Stop.BackColor = Color.DodgerBlue
        Btn_Cancel.BackColor = Color.DodgerBlue
        Btn_Start.BackColor = Color.DodgerBlue
        Btn_Start.ForeColor = Color.White
        Btn_Stop.ForeColor = Color.White
        Btn_Cancel.ForeColor = Color.White
        'Chair_Opt.Visible = False
        'Start_Time.Visible = False
        'Stop_Time.Visible = False
        'Staffid.Text = BtnDataGrid_Frm.Label2

    End Sub
    Private Sub SetRoundedButton(ByVal button As Button, ByVal cornerRadius As Integer)
        button.FlatAppearance.BorderSize = 0
        Dim region As New Region(RoundedRectangle(New Rectangle(0, 0, button.Width, button.Height), cornerRadius))
        button.Region = region
    End Sub
    Private Function RoundedRectangle(ByVal rectangle As Rectangle, ByVal cornerRadius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = cornerRadius * 2
        Dim arcRectangle As New Rectangle(rectangle.Location, New Size(diameter, diameter))

        ' Top left corner
        path.AddArc(arcRectangle, 180, 90)

        ' Top side (excluding corners)
        path.AddLine(rectangle.Left + cornerRadius, rectangle.Top, rectangle.Right - cornerRadius, rectangle.Top)

        ' Top right corner
        arcRectangle.X = rectangle.Right - diameter
        path.AddArc(arcRectangle, 270, 90) ' Changed starting angle to 270

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

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Private Sub Btn_Start_Click(sender As Object, e As EventArgs) Handles Btn_Start.Click
        Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")

        B.BackColor = Color.Green
        '  Dim startTime As TimeSpan = currentTime.TimeOfDay
        Start_Time.Text = currentTime
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "update Chair set Status=2,StartTime='" & Start_Time.Text & "' where ID=" & Chair_Opt.Text & ""
            cmd.ExecuteNonQuery()
            'Chairs_working.RefreshChairsStatus()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Btn_Stop_Click(sender As Object, e As EventArgs) Handles Btn_Stop.Click
        Close_Workfrm.lbl_Chairid.Text = Chair_Opt.Text
        Dim result As DialogResult = MessageBox.Show("Do you want to close the work?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user clicked Yes
        If result = DialogResult.Yes Then
            Close_Workfrm.CloseWrk_ChairId.Text = Chair_Opt.Text
            Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")
            '  Dim endTime As TimeSpan = currentTime.TimeOfDay
            Stop_Time.Text = currentTime
            Try
                con.ConnectionString = ConString
                cmd = con.CreateCommand
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.CommandText = "update Chair set Status=0 ,EndTime='" & Stop_Time.Text & "' WHERE ID=" & Chair_Opt.Text & "" '"
                cmd.ExecuteNonQuery()
                con.Close()

                If con.State = ConnectionState.Closed Then con.Open()
                cmd = con.CreateCommand
                cmd.CommandText = "Update  StaffMaster set Work_Status=0 where Chair_ID =" & Chair_Opt.Text & ""
                cmd.ExecuteNonQuery()
                con.Close()
                Thread.Sleep(2000)
                'Chairs_working.RefreshChairsStatus()
                Me.Close()

                Close_Workfrm.MdiParent = Form1
                Close_Workfrm.Show()
                Close_Workfrm.BringToFront()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally

                con.Close()
            End Try
        End If
    End Sub
End Class
