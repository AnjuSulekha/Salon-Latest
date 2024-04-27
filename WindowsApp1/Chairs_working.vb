'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Runtime.InteropServices

Public Class Chairs_working
    Dim DT As New DataTable
    Dim con As New OleDbConnection
    Dim cmd As OleDbCommand
    Dim IsCreated(99) As Boolean
    Dim ButtonWidh As Integer
    Dim ButtonHeight As Integer
    Dim ButtonPadding As Integer
    Dim dr As OleDbDataReader
    ' Dim L As New Label
    'Public L As New Label
    'Public B As New Button
    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Chair_ID.Visible = False
            Chair__ID.Visible = False
            Staff_ID.Visible = False
            Status.Visible = False
            ' DataGridAdd("")
        Catch ex As Exception
            ' Handle any exceptions that may occur during the loading process
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Perform any cleanup or finalization tasks if necessary
        End Try
    End Sub
    Public Sub FetchDataFromDatabase()
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()

            cmd.CommandText = "SELECT ID,ChairName, ChairType, StaffName, Status FROM  Chair"


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

    Dim workStatus As Integer
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim B As Button = sender
        IsCreated(B.Tag) = True
        Dim buttonText As String = B.Text
        Dim chairID As String = buttonText.Split(" ")(1).Trim()
        BtnDataGrid_Frm.Id.Text = chairID
        BtnOptions.Chair_Opt.Text = chairID
        Chair__ID.Text = chairID

        Dim chairStatus As String = FetchChairStatus(chairID)
        Status.Text = chairStatus
        Dim btn As Button = DirectCast(sender, Button)
        Dim parentCenterX As Integer = btn.Parent.Width \ 2
        Dim parentCenterY As Integer = btn.Parent.Height \ 2
        ' Calculate the position to center BtnDataGrid_Frm
        Dim btnDataGridCenterX As Integer = parentCenterX - (BtnDataGrid_Frm.Width \ 2)
        Dim btnDataGridCenterY As Integer = parentCenterY - (BtnDataGrid_Frm.Height \ 2)
        ' Set the location of BtnDataGrid_Frm
        If chairStatus = 0 Then
            BtnOptions.Hide()
            BtnDataGrid_Frm.TopLevel = False
            btn.Parent.Controls.Add(BtnDataGrid_Frm)
            BtnDataGrid_Frm.Show()
            BtnDataGrid_Frm.BringToFront()

        ElseIf chairStatus <> 0 Then
            'If chairStatus = 1 Then
            '    B.BackColor = Color.Honeydew
            'ElseIf chairStatus = 2 Then
            '    B.BackColor = Color.Green
            'End If

            BtnDataGrid_Frm.Hide()
            BtnOptions.TopLevel = False
            btn.Parent.Controls.Add(BtnOptions)
            BtnOptions.Show()
            BtnOptions.BringToFront()

        End If
    End Sub
    Public Sub RefreshChairs()
        ' Clear existing controls in the panel
        ClearChairControls()
        ' Regenerate chair buttons and labels
        FunlistChairs()
    End Sub

    Public Sub ClearChairControls()
        ' Clear existing controls in the panel
        Panel__Chair.Controls.Clear()
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
    Private Sub Chairs_working_Click(sender As Object, e As EventArgs) Handles Me.Click
        CloseBtnDataGridForm()
    End Sub
    Private Sub Chairs_working_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        CloseBtnDataGridForm()
    End Sub
    Private Sub CloseBtnDataGridForm()
        ' Check if BtnDataGrid_Frm is open
        If BtnDataGrid_Frm IsNot Nothing AndAlso Not BtnDataGrid_Frm.IsDisposed Then
            ' Close BtnDataGrid_Frm
            BtnDataGrid_Frm.Close()
        End If
    End Sub





    Public Sub RefreshChairsStatus()
        ' Clear existing chair data
        DT.Clear()
        ' Fetch updated chair data from the database
        FetchDataFromDatabase()
        ' Update UI to reflect the updated chair status
        UpdateChairsUI()
    End Sub

    Private Sub UpdateChairsUI()
        ' Loop through each button in the panel and update its status
        For Each ctrl As Control In Panel__Chair.Controls
            If TypeOf ctrl Is Button Then
                Dim chairButton As Button = DirectCast(ctrl, Button)
                Dim chairID As String = chairButton.Tag.ToString()
                Dim chairStatus As String = FetchChairStatus(chairID)
                UpdateChairButton(chairButton, chairStatus)
            End If
        Next
    End Sub

    Private Sub UpdateChairButton(chairButton As Button, chairStatus As String)
        ' Update the button color and status label based on the chair status
        If chairStatus = "1" Then
            chairButton.BackColor = Color.Honeydew
            chairButton.Controls("StatusLabel").Text = "Active"
        ElseIf chairStatus = "2" Then
            chairButton.BackColor = Color.Green
            chairButton.Controls("StatusLabel").Text = "Working"
        Else
            chairButton.BackColor = Color.Gray
            chairButton.Controls("StatusLabel").Text = "Inactive"
        End If
    End Sub





End Class