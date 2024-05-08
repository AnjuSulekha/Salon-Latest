'mports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Reflection.Emit
Public Class Chair_Main
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim DT As New DataTable
    Private Sub Chair_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            DT.Columns.Add("Edit", GetType(Image))
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
    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        ' Check if the cell being painted is in the "Edit" column
        If e.ColumnIndex = DataGridView1.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
            ' Get the edit icon image
            Dim editIcon As Image = My.Resources.Edit ' Assuming "EditIcon" is the name of your icon resource

            ' Calculate the position to draw the icon
            Dim iconX As Integer = e.CellBounds.Left + 2 ' Adjust the X position as needed
            Dim iconY As Integer = e.CellBounds.Top + (e.CellBounds.Height - editIcon.Height) / 2 ' Center vertically

            ' Draw the cell's background
            e.PaintBackground(e.CellBounds, False)

            ' Draw the icon to the left of the cell
            e.Graphics.DrawImage(editIcon, iconX, iconY)

            ' Suppress default painting of the cell content
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = DataGridView1.Columns("Edit").Index Then
                ' Check if the clicked cell is in the "Edit" column
                ' e.RowIndex >= 0 ensures that the click is not on the header row

                ' Retrieve data from the clicked cell
                Dim ID = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                ' This line seems problematic, see below for correction
                Dim Chairid As String = DataGridView1.Rows(e.RowIndex).Cells("ID").Value.ToString() ' Assuming "StaffIDColumn" is the name of the column containing the staff ID
                '        ' .StaffID = staffid
                Chair_Add.lbl_ChairID.Text = Chairid
                Chair_Add.MdiParent = Form1
                Chair_Add.Show()
                Chair_Add.BringToFront()
                'Chair_Add.lbl_Update.Visible = True
                'Chair_Add.Label11.Visible = False
                'Chair_Add.Button7.Visible = False
                'Chair_Add.Edit_btn.Visible = True
                'Chair_Add.Button7.Visible = False
                'Chair_Add.Button12.Visible = True
                'Chair_Add.Exit_btn.Location = New Point(395, 270)
                Chair_Add.LoadChairData()

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Chair_Add.MdiParent = Form1
        Chair_Add.Show()
        Chair_Add.BringToFront()
        Chair_Add.lbl_Update.Visible = False
        Chair_Add.lbl_ChairID.Visible = False
        Chair_Add.Button7.Visible = True
        Chair_Add.Label11.Visible = True
        Chair_Add.Button12.Visible = False
        Chair_Add.Exit_btn.Location = New Point(294, 270)

    End Sub
    Public Sub RefreshData()
        ' Clear the DataGridView
        DataGridView1.DataSource = Nothing

        ' Re-fetch the data from the database and update the DataGridView
        DataGridAdd("")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    End Sub
End Class