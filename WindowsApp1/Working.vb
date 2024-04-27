'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Threading

Public Class Working
    Dim DT As New DataTable
    Dim con As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim IsCreated(99) As Boolean
    Dim ButtonWidh As Integer
    Dim ButtonHeight As Integer
    Dim ButtonPadding As Integer
    Private Sub Working_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'MakePictureBoxRound(PictureBox1)

            ' Clear any existing data from the DataTable
            DT.Clear()

            ' Fetch data from the Access database and populate the DataTable
            FetchDataFromDatabase()

            ButtonWidh = 100
            ButtonHeight = 60
            ButtonPadding = 15
            FunlistChairs()
            ' DataGridAdd("")
        Catch ex As Exception
            ' Handle any exceptions that may occur during the loading process
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Perform any cleanup or finalization tasks if necessary
        End Try

    End Sub

    Private Sub FetchDataFromDatabase()
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()

            cmd.CommandText = "SELECT ID,ChairName, ChairType, StaffName, Status FROM  Chair where Status=2"


            Using reader As OleDbDataReader = cmd.ExecuteReader()
                ' Check if the reader has rows
                If reader.HasRows Then
                    ' If DataTable columns are not yet added, add them dynamically based on the query
                    If DT.Columns.Count = 0 Then
                        For i As Integer = 0 To reader.FieldCount - 1
                            DT.Columns.Add(reader.GetName(i))
                        Next
                    End If

                    ' Loop through each row in the result set
                    While reader.Read()
                        ' Add a new row to the DataTable and populate it with data from the database
                        Dim newRow As DataRow = DT.NewRow()
                        For i As Integer = 0 To reader.FieldCount - 1
                            newRow(i) = reader(i)
                        Next
                        DT.Rows.Add(newRow)
                    End While
                End If
            End Using
        Catch ex As Exception
        Finally
            con.Close()
        End Try


    End Sub
    'Public Sub FetchDataFromDatabase()
    '    Try
    '        con.ConnectionString = ConString
    '        cmd = con.CreateCommand
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        cmd.CommandText = "SELECT ID,ChairName, ChairType, StaffName, Status FROM  Chair"


    '        Using reader As OleDbDataReader = cmd.ExecuteReader()
    '            ' Check if the reader has rows
    '            If reader.HasRows Then
    '                ' If DataTable columns are not yet added, add them dynamically based on the query
    '                If DT.Columns.Count = 0 Then
    '                    For i As Integer = 0 To reader.FieldCount - 1
    '                        DT.Columns.Add(reader.GetName(i))
    '                    Next
    '                End If

    '                ' Loop through each row in the result set
    '                While reader.Read()
    '                    ' Add a new row to the DataTable and populate it with data from the database
    '                    Dim newRow As DataRow = DT.NewRow()
    '                    For i As Integer = 0 To reader.FieldCount - 1
    '                        newRow(i) = reader(i)
    '                    Next
    '                    DT.Rows.Add(newRow)
    '                End While
    '            End If
    '        End Using
    '    Catch ex As Exception
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub


    'Old code
    'Private Sub Chairs_working_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    'MakePictureBoxRound(PictureBox1)
    '    DT.Columns.Add("Name")
    '    DT.Columns.Add("Status")
    '    DT.Columns.Add("EmpName")
    '    DT.Rows.Add("Chair1", "0", "")
    '    DT.Rows.Add("Chair2", "1", "")
    '    DT.Rows.Add("Chair3", "0", "")
    '    DT.Rows.Add("Chair4", "3", "")
    '    DT.Rows.Add("Chair5", "0", "")
    '    DT.Rows.Add("Chair6", "0", "")
    '    DT.Rows.Add("Chair7", "0", "")
    '    DT.Rows.Add("Chair8", "0", "")
    '    DT.Rows.Add("Chair9", "2", "")
    '    ButtonWidh = 150
    '    ButtonHeight = 120
    '    ButtonPadding = 10
    '    FunlistChairs()
    'End Sub
    'Private Sub FunlistChairs()
    '    Dim Ls As New List(Of Label)
    '    For i As Integer = 0 To DT.Rows.Count - 1
    '        Dim B As New Button
    '        Dim L As New Label
    '        Dim L1 As New Label
    '        Panel__Chair.Controls.Add(B)
    '        Panel__Chair.Controls.Add(L)
    '        Panel__Chair.Controls.Add(L1)
    '        B.Height = ButtonHeight
    '        B.Width = ButtonWidh
    '        B.Left = (i Mod 4) * (ButtonWidh + ButtonPadding)
    '        B.Top = (i \ 4) * (ButtonHeight + ButtonPadding)
    '        B.Text = DT.Rows(i).Item("ChairName").ToString
    '        ' B.Text = DT.Rows(i).Item("Status").ToString

    '        L.Width = B.Width
    '        L.Height = 15
    '        L.Left = B.Left + 5
    '        L.Top = B.Top + 5
    '        L.Text = ""
    '        L.Font = New Font("Arial", 8, FontStyle.Bold)
    '        L.AutoSize = True
    '        L.TextAlign = ContentAlignment.MiddleCenter
    '        L.BackColor = Color.Blue
    '        L.ForeColor = Color.White
    '        L.BringToFront()
    '        L1.AutoSize = True ' 120
    '        L1.Height = 15
    '        L1.Left = B.Left
    '        L1.Top = (B.Top + (B.Height - L1.Height)) - 5
    '        L1.Text = DT.Rows(i).Item("StaffName").ToString
    '        L1.Font = New Font("Arial", 8, FontStyle.Bold)
    '        L1.AutoSize = True
    '        L1.TextAlign = ContentAlignment.MiddleCenter
    '        L1.BackColor = Color.Red
    '        L1.ForeColor = Color.White
    '        L1.BringToFront()
    '        'Dim chairImage As Image = My.Resources.NewChair ' Replace "NewChair" with the name of your image resource
    '        'B.Image = chairImage
    '        'B.ImageAlign = ContentAlignment.MiddleCenter ' Set image alignment to center
    '        'B.TextImageRelation = TextImageRelation.ImageAboveText ' Display image above the text
    '        'B.BackColor = Color.Transparent ' Set the background color of the button as transparent
    '        'B.FlatStyle = FlatStyle.Flat ' Set flat style to prevent any default button borders
    '        'B.FlatAppearance.BorderSize = 0 ' Set the border size to 0 to remove any border

    '        If DT.Rows(i).Item("Status") = 1 Then
    '            B.BackColor = Color.Honeydew
    '            L.Text = "Active"
    '        ElseIf DT.Rows(i).Item("Status") = 2 Then
    '            B.BackColor = Color.Green
    '            L.Text = "Working"
    '        Else
    '            L.Text = "InActive"
    '            B.BackColor = Color.Gray
    '        End If
    '        ' Set tag property of the button to hold the index of the current row
    '        B.Tag = i
    '        ' Add label to the list
    '        Ls.Add(L)
    '        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
    '        Dim cornerRadius As Integer = 5 ' Adjust the radius to control the roundness of the corners
    '        Dim rect As New Rectangle(0, 0, B.Width, B.Height)

    '        ' Top-left corner
    '        path.AddArc(rect.Left, rect.Top, cornerRadius * 2, cornerRadius * 2, 180, 90)
    '        ' Top-right corner
    '        path.AddArc(rect.Right - cornerRadius * 2, rect.Top, cornerRadius * 2, cornerRadius * 2, 270, 90)
    '        ' Bottom-right corner
    '        path.AddArc(rect.Right - cornerRadius * 2, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90)
    '        ' Bottom-left corner
    '        path.AddArc(rect.Left, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90)
    '        path.CloseFigure()

    '        B.Region = New Region(path)


    '        AddHandler B.Click, AddressOf Button_Click
    '    Next
    'End Sub


    '' Constructor to accept reference to chri_staff form
    'Public Sub New(chairStaffForm As Chair_Staff)
    '    InitializeComponent()
    '    Me.chairStaffForm = Chair_Staff
    'End Sub
    Public Sub FunlistChairs()
        Dim Ls As New List(Of Label)
        For i As Integer = 0 To DT.Rows.Count - 1
            Dim B As New Button
            Dim L As New Label
            Dim L1 As New Label
            Panel__Chair.Controls.Add(B)
            Panel__Chair.Controls.Add(L)
            Panel__Chair.Controls.Add(L1)
            B.Height = ButtonHeight
            B.Width = ButtonWidh
            B.Left = (i Mod 4) * (ButtonWidh + ButtonPadding)
            B.Top = (i \ 4) * (ButtonHeight + ButtonPadding)
            B.Text = DT.Rows(i).Item("ChairName").ToString &
            Environment.NewLine & Environment.NewLine & "ID: " & DT.Rows(i).Item("ID").ToString
            ' B.Text = DT.Rows(i).Item("Status").ToString
            L.Width = B.Width
            L.Height = 15
            L.Left = B.Left + 5
            L.Top = B.Top + 5
            L.Text = ""
            L.Font = New Font("Arial", 8, FontStyle.Bold)
            L.AutoSize = True
            L.TextAlign = ContentAlignment.MiddleCenter
            L.BackColor = Color.Blue
            L.ForeColor = Color.White
            L.BringToFront()
            L1.AutoSize = True ' 120
            L1.Height = 15
            L1.Left = B.Left
            L1.Top = (B.Top + (B.Height - L1.Height)) - 5
            L1.Text = DT.Rows(i).Item("StaffName").ToString
            L1.Font = New Font("Arial", 8, FontStyle.Bold)
            L1.AutoSize = True
            L1.TextAlign = ContentAlignment.MiddleCenter
            L1.BackColor = Color.Red
            L1.ForeColor = Color.White
            L1.BringToFront()
            If DT.Rows(i).Item("Status") = 1 Then
                B.BackColor = Color.Honeydew
                L.Text = "Active"
            ElseIf DT.Rows(i).Item("Status") = 2 Then
                B.BackColor = Color.Green
                L.Text = "Working"
            Else
                L.Text = "InActive"
                B.BackColor = Color.Gray
            End If
            B.Tag = DT.Rows(i).Item("ID").ToString
            ' Set tag property of the button to hold the index of the current row
            B.Tag = i
            ' Add label to the list
            Ls.Add(L)
            Dim path As New System.Drawing.Drawing2D.GraphicsPath()
            Dim cornerRadius As Integer = 5 ' Adjust the radius to control the roundness of the corners
            Dim rect As New Rectangle(0, 0, B.Width, B.Height)
            ' Top-left corner
            path.AddArc(rect.Left, rect.Top, cornerRadius * 2, cornerRadius * 2, 180, 90)
            ' Top-right corner
            path.AddArc(rect.Right - cornerRadius * 2, rect.Top, cornerRadius * 2, cornerRadius * 2, 270, 90)
            ' Bottom-right corner
            path.AddArc(rect.Right - cornerRadius * 2, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90)
            ' Bottom-left corner
            path.AddArc(rect.Left, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90)
            path.CloseFigure()
            B.Region = New Region(path)
            AddHandler B.Click, AddressOf Button_Click
        Next
    End Sub
    'Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim result As DialogResult = MessageBox.Show("Do you want to close the work?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


    '    If result = DialogResult.Yes Then
    '        Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")
    '        '  Dim startTime As TimeSpan = currentTime.TimeOfDay
    '        Stop_Time.Text = currentTime
    '        Close_Workfrm.lbl_Chairid.Text = Chair__ID.Text
    '        Dim B As Button = sender
    '        IsCreated(B.Tag) = True
    '        Dim buttonText As String = B.Text
    '        Dim chairID As String = buttonText.Split(" ")(1).Trim()
    '        BtnOptions.Chair_Opt.Text = chairID
    '        Dim btn As Button = DirectCast(sender, Button)
    '        Dim parentCenterX As Integer = btn.Parent.Width \ 2
    '        Dim parentCenterY As Integer = btn.Parent.Height \ 2
    '        Dim btnDataGridCenterX As Integer = parentCenterX - (BtnDataGrid_Frm.Width \ 2)
    '        Dim btnDataGridCenterY As Integer = parentCenterY - (BtnDataGrid_Frm.Height \ 2)
    '        Try
    '            con.ConnectionString = ConString
    '            cmd = con.CreateCommand
    '            If con.State = ConnectionState.Closed Then con.Open()
    '            'cmd.CommandText = "update Chair set Status=0 ,EndTime='" & Stop_Time.Text & "' WHERE ID=chairID" '"
    '            'cmd.ExecuteNonQuery()
    '            'con.Close()
    '            cmd.CommandText = "update Chair set Status=0 ,EndTime=@EndTime WHERE ID=@ChairID"
    '            cmd.Parameters.AddWithValue("@EndTime", Stop_Time.Text)
    '            cmd.Parameters.AddWithValue("@ChairID", chairID)
    '            cmd.ExecuteNonQuery()
    '            con.Close()

    '            If con.State = ConnectionState.Closed Then con.Open()
    '            cmd = con.CreateCommand
    '            cmd.CommandText = "Update  StaffMaster set Work_Status=0 where Chair_ID =@Chair_ID"
    '            cmd.Parameters.AddWithValue("@Chair_ID", chairID)
    '            cmd.ExecuteNonQuery()
    '            con.Close()
    '            Thread.Sleep(2000)
    '            Me.Close()

    '            Close_Workfrm.MdiParent = Form1
    '            Close_Workfrm.Show()
    '            Close_Workfrm.BringToFront()

    '        Catch ex As Exception
    '            MessageBox.Show("Error: " & ex.Message)
    '        Finally

    '            con.Close()
    '        End Try
    '        'Close_Workfrm.TopLevel = False
    '        ''btn.Parent.Controls.Add(Close_Workfrm)
    '        'Close_Workfrm.Show()
    '        'Close_Workfrm.BringToFront()
    '    End If
    '    ' Dim B As Button = DirectCast(sender, Button)


    '    '
    '    'Dim chairID As String = buttonText.Split(" ")(1).Trim()
    '    ''BtnDataGrid_Frm.Id.Text = chairID
    '    ''BtnOptions.Chair_Opt.Text = chairID
    '    'Chair__ID.Text = chairID

    '    'Dim chairStatus As String = FetchChairStatus(chairID)
    '    'lbl_Status.Text = chairStatus

    '    ' Calculate the position to center BtnDataGrid_Frm

    '    ' Set the location of BtnDataGrid_Frm
    '    'If chairStatus = 0 Then
    '    '    BtnOptions.Hide()
    '    '    BtnDataGrid_Frm.TopLevel = False
    '    '    btn.Parent.Controls.Add(BtnDataGrid_Frm)
    '    '    BtnDataGrid_Frm.Show()
    '    '    BtnDataGrid_Frm.BringToFront()
    '    'ElseIf chairStatus <> 0 Then
    '    '    'If chairStatus = 1 Then
    '    '    '    B.BackColor = Color.Honeydew
    '    '    'ElseIf chairStatus = 2 Then
    '    '    '    B.BackColor = Color.Green
    '    '    'End If

    '    '    'BtnDataGrid_Frm.Hide()
    '    '    BtnOptions.TopLevel = False

    '    'End If
    'End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim result As DialogResult = MessageBox.Show("Do you want to close the work?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")
            Stop_Time.Text = currentTime
            Close_Workfrm.lbl_Chairid.Text = Chair__ID.Text
            Dim B As Button = sender
            IsCreated(B.Tag) = True
            Dim buttonText As String = B.Text
            Dim chairID As String = buttonText.Split(" ")(1).Trim()
            BtnOptions.Chair_Opt.Text = chairID
            Try
                Using con As New OleDbConnection(ConString)
                    con.Open()
                    Dim updateChairStatusQuery As String = "UPDATE Chair SET Status = 0, EndTime = @EndTime WHERE ID = @ChairID"
                    Using cmd As New OleDbCommand(updateChairStatusQuery, con)
                        cmd.Parameters.AddWithValue("@EndTime", Stop_Time.Text)
                        cmd.Parameters.AddWithValue("@ChairID", chairID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Dim updateStaffStatusQuery As String = "UPDATE StaffMaster SET Work_Status = 0 WHERE Chair_ID = @ChairID"
                    Using cmd As New OleDbCommand(updateStaffStatusQuery, con)
                        cmd.Parameters.AddWithValue("@ChairID", chairID)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                Thread.Sleep(2000)
                Close_Workfrm.CloseWrk_ChairId.Text = chairID
                Close_Workfrm.MdiParent = Form1
                Close_Workfrm.Show()
                Close_Workfrm.BringToFront()

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Function FetchChairStatus(ByVal chairID As String) As String
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT Status FROM Chair WHERE ID =" & Chair__ID.Text & " "
            dr = cmd.ExecuteReader()
            Dim status As String = ""
            If dr.Read() Then
                status = dr("Status").ToString()
                'status = .ToString()
            End If
            dr.Close()
            Return status
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Function
    Private Function IsFormOpen(formType As Type) As Boolean
        For Each form As Form In Application.OpenForms
            If form.GetType() = formType Then
                Return True
            End If
        Next
        Return False
    End Function
End Class