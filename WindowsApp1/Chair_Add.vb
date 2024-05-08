Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Excel
Public Class Chair_Add
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim DT As New DataTable
    Private Sub Chair_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_ChairID.Visible = False
        Exit_btn.BackColor = Color.DodgerBlue
        Exit_btn.ForeColor = Color.White
        Button7.BackColor = Color.DodgerBlue
        Button7.ForeColor = Color.White
        Edit_btn.BackColor = Color.DodgerBlue
        Edit_btn.ForeColor = Color.White
        Button12.BackColor = Color.DodgerBlue
        Button12.ForeColor = Color.White
        Button1.BackColor = Color.DodgerBlue
        Button1.ForeColor = Color.White
        Panel10.Visible = False
        Panel11.Visible = False
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        Me.Hide()
        ChairClear()
    End Sub
    Private Sub ChairClear()
        Txt_ChairType.Text = ""
        Txt_ChairName.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Try
            If String.IsNullOrWhiteSpace(Txt_ChairName.Text) Then
                MsgBox("Please enter Chair Name.")
                Txt_ChairName.Focus()
                Return ' Exit the event handler if Chair Name is empty
            End If

            If String.IsNullOrWhiteSpace(Txt_ChairType.Text) Then
                MsgBox("Please enter Chair Type.")
                Txt_ChairType.Focus()
                Return ' Exit the event handler if Chair Type is empty
            End If
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "insert into Chair (ChairName,ChairType,Status) values ('" & Txt_ChairName.Text & "','" & Txt_ChairType.Text & "',0)"
            cmd.ExecuteNonQuery()
            MsgBox("New Chair Addedd")
            ChairClear()
            Me.Hide()

            'Dim mainForm As Main_Form = Application.OpenForms().OfType(Of Main_Form).FirstOrDefault()
            con.Close()
            Chair_Main.RefreshData()
        Catch ex As Exception
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click

        Dim result As DialogResult = MessageBox.Show("Do you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the user's response
        If result = DialogResult.Yes Then
            Try
                con.ConnectionString = ConString
                cmd = con.CreateCommand
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.CommandText = "UPDATE Chair SET ChairName='" & Txt_ChairName.Text & "', ChairType='" & Txt_ChairType.Text & "' WHERE ID=" & lbl_ChairID.Text
                cmd.ExecuteNonQuery()
                MsgBox("Chair details updated")
                ChairClear()
                con.Close()
                Chair_Main.RefreshData()
                Front_Form.RefreshChair()
                Me.Hide()
            Catch ex As Exception
                MsgBox("An error occurred while updating the data: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Finally
                con.Close()
            End Try
        End If

    End Sub
    Public Sub LoadChairData()
        Try

            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            If lbl_ChairID.Text <> "" Then
                cmd.CommandText = "select * from Chair where ID=" & Val(Me.lbl_ChairID.Text) & ""
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    Me.Txt_ChairName.Text = dr("ChairName").ToString()
                    Me.Txt_ChairType.Text = dr("ChairType").ToString()

                    dr.Close()

                End If

            End If

        Catch ex As Exception
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the user's response
        If result = DialogResult.Yes Then
            Try
                ' Establish connection
                con.ConnectionString = ConString
                cmd = con.CreateCommand

                ' Check if connection is closed, then open it
                If con.State = ConnectionState.Closed Then con.Open()

                ' Prepare SQL command for deletion
                cmd.CommandText = "DELETE FROM Chair WHERE ID = @ID"

                ' Add parameters to the command (to prevent SQL injection)
                cmd.Parameters.AddWithValue("@ID", lbl_ChairID.Text)

                ' Execute the deletion command
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                ' Check if any rows were affected
                If rowsAffected > 0 Then
                    MsgBox("Chair deleted successfully")
                    ' Clear input fields after deletion
                    ChairClear()
                    con.Close()
                    RefreshData()
                Else
                    MsgBox("No data deleted. Chair ID not found.")
                End If

                ' Me.Hide()
            Catch ex As Exception
                ' Handle exceptions, if any
                MsgBox("An error occurred: " & ex.Message)
            Finally
                ' Close connection
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Close()
            End Try
        End If
    End Sub
    Public Sub RefreshData()
        ' Clear the DataGridView
        DataGridView1.DataSource = Nothing

        ' Re-fetch the data from the database and update the DataGridView
        DataGridAdd("")
    End Sub
    Private Sub DataGridAdd(SearchString As String)
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT ID,ChairName,ChairType,StaffName FROM Chair"
            If Trim(SearchString) <> "" Then
                cmd.CommandText &= " WHERE ID LIKE '%" & SearchString & "%'"
            End If
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            ' Create a DataTable
            Dim DT As New DataTable
            DT.Columns.Add("ID")
            DT.Columns.Add("ChairName")
            DT.Columns.Add("ChairType")
            DT.Columns.Add("StaffName")
            ' DT.Columns.Add("Edit", GetType(Image))
            While dr.Read()
                ' Add rows to the DataTable
                DT.Rows.Add(dr("ID"), dr("ChairName"), dr("ChairType"), dr("StaffName"))
            End While

            ', Tax, Details
            dr.Close()
            DataGridView1.DataSource = DT
            DataGridView1.Columns("ID").Visible = False
            DataGridView1.Columns("StaffName").Visible = False
            'DataGridView1.Dock = DockStyle.Fill
            '    DataGridView1.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub Tabmovement(ByVal Keycode As Integer)
        If Keycode = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub Txt_ChairName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ChairName.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub



    Private Sub Txt_ChairType_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ChairType.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    'Private Sub Chair_Add_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    '    Dim maxTextBoxPanelWidth As Integer = 700
    '    Dim minpanelwidth As Integer = 544
    '    If Me.WindowState = FormWindowState.Maximized Then
    '        Panel11.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Panel10.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Txt_ChairName.Width = Panel11.Width - (2 * Txt_ChairName.Left)
    '        Txt_ChairType.Width = Panel11.Width - (2 * Txt_ChairType.Left)
    '    Else
    '        Panel11.Width = Math.Min(minpanelwidth, Me.Width)
    '        Panel10.Width = Math.Min(minpanelwidth, Me.Width)

    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Chair_Add_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

    End Sub
End Class