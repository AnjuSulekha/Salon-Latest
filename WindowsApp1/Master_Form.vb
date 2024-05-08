'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.IO

Public Class Master_Form
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim destinationFilePath As String
    Dim DT As New DataTable
    Private Sub Master_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridAddView("")
    End Sub
    Private Sub DataGridAddView(SearchString As String)
        Try
            con.ConnectionString = ConString
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = con.CreateCommand
            cmd.CommandText = "SELECT Img,StaffName,Mobile,StaffID FROM StaffMaster"
            If Trim(SearchString) <> "" Then
                cmd.CommandText &= " WHERE StaffID LIKE '%" & SearchString & "%'"
            End If
            Dim dr As OleDbDataReader = cmd.ExecuteReader

            ' Create a DataTable
            Dim DT As New DataTable
            DT.Columns.Add("Image", GetType(Image)) ' Add a column for the image
            DT.Columns.Add("StaffName")
            DT.Columns.Add("Mobile") '
            DT.Columns.Add("StaffID")
            DT.Columns.Add("Edit", GetType(Image))
            'Read Data And Load images
            While dr.Read()
                Dim imagePath As String = dr("Img").ToString()
                If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                    ' Load image only if the file path is not empty and the file exists
                    Dim img As Image = Image.FromFile(imagePath)
                    DT.Rows.Add(img, dr("StaffName"), dr("Mobile"), dr("StaffID"))
                Else
                    ' Handle invalid or missing file path
                    DT.Rows.Add(Nothing, dr("StaffName"), dr("Mobile"), dr("StaffID"))
                End If
            End While
            dr.Close()
            DataGridView2.DataSource = DT
            DataGridView2.Columns("StaffID").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    'DATAGRIDVIEW EDIT ICON [STAFF]
    'Private Sub DataGridView2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
    '    ' Check if the cell being painted is in the "Edit" column
    '    If e.ColumnIndex = DataGridView2.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
    '        ' Get the edit icon image
    '        Dim editIcon As Image = My.Resources.Edit ' Assuming "EditIcon" is the name of your icon resource

    '        ' Calculate the position to draw the icon
    '        Dim iconX As Integer = e.CellBounds.Left + 2 ' Adjust the X position as needed
    '        Dim iconY As Integer = e.CellBounds.Top + (e.CellBounds.Height - editIcon.Height) / 2 ' Center vertically

    '        ' Draw the cell's background
    '        e.PaintBackground(e.CellBounds, False)

    '        ' Draw the icon to the left of the cell
    '        e.Graphics.DrawImage(editIcon, iconX, iconY)

    '        ' Suppress default painting of the cell content
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Master_Add.MdiParent = Form1
        Master_Add.BringToFront()
        Master_Add.Show()
        'Master_Add.Lbl_Reg.Visible = True
        'Master_Add.Lbl_Edit.Visible = False
        'Master_Add.Btn_Reg.Visible = True
        'Master_Add.Btn_Edit.Visible = False
        'Master_Add.Btn_Exit.Location = New Point(270, 376)

    End Sub
    Public Sub RefreshStaffData()
        ' Clear the DataGridView
        DataGridView2.DataSource = Nothing

        ' Re-fetch the data from the database and update the DataGridView
        DataGridAddView("")
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = DataGridView2.Columns("Edit").Index Then
                Dim ID = DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                ' This line seems problematic, see below for correction
                Dim staffid As String = DataGridView2.Rows(e.RowIndex).Cells("StaffID").Value.ToString() ' Assuming "StaffIDColumn" is the name of the column containing the staff ID
                '        ' .StaffID = staffid
                Master_Add.lbl_staff.Text = staffid
                Master_Add.MdiParent = Form1
                Master_Add.Show()
                Master_Add.BringToFront()
                'If Master_Add.Visible Then
                '    Master_Add.LoadFormData() ' Load data when the form becomes visible
                'End If
            End If
            Master_Add.Lbl_Reg.Visible = False
            Master_Add.Lbl_Edit.Visible = True
            Master_Add.Btn_Edit.Visible = True
            Master_Add.Btn_Reg.Visible = False
            Master_Add.Btn_Exit.Location = New Point(375, 376)
            Master_Add.Button11.Visible = True

        End If


    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_Click(sender As Object, e As EventArgs) Handles DataGridView2.Click

    End Sub
End Class