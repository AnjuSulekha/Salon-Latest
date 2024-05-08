'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Reflection.Emit

Public Class Product_Main
    Dim con As New OLEDBConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim DT As New DataTable
    Private Sub Product_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridProductAdd("")
    End Sub
    Private Sub DataGridProductAdd(SearchString As String)
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()

            cmd.CommandText = "SELECT ItemID,ItemName,Category,Rate,Tax,Details FROM Item_Master"
            If Trim(SearchString) <> "" Then
                cmd.CommandText &= " WHERE ItemID LIKE '%" & SearchString & "%'"
            End If
            Dim dr As OleDbDataReader = cmd.ExecuteReader

            ' Create a DataTable
            Dim DT As New DataTable
            DT.Columns.Add("ItemID")
            DT.Columns.Add("ItemName")
            DT.Columns.Add("Category")
            DT.Columns.Add("Rate")
            DT.Columns.Add("Edit", GetType(Image))
            '
            'DT.Columns.Add("Tax")
            'DT.Columns.Add("Details")
            'Read Data And Load images
            While dr.Read()
                Dim ItemID As String = dr("ItemID").ToString()
                Dim Item As String = dr("ItemName").ToString()
                Dim Itemcategory As String = dr("Category").ToString()
                Dim Rate As String = dr("Rate").ToString()
                ' Add rows to the DataTable
                DT.Rows.Add(ItemID, Item, Itemcategory, Rate)

            End While
            ', Tax, Details
            dr.Close()
            DataGridView3.DataSource = DT
            DataGridView3.Columns("ItemID").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Product_Add.MdiParent = Form1
        Product_Add.Show()
        Product_Add.BringToFront()

        'Product_Add.lbl_Nproduct.Visible = True
        'Product_Add.Btn_product.Visible = True
        'Product_Add.Button8.Visible = True
        'Product_Add.Button8.Location = New Point(278, 369)
        'Product_Add.Label18.Visible = False
        'Product_Add.DeleteProduct.Visible = False



    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView3_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView3.CellPainting
        ' Check if the cell being painted is in the "Edit" column
        If e.ColumnIndex = DataGridView3.Columns("Edit").Index AndAlso e.RowIndex >= 0 Then
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

    'Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick

    '    If e.RowIndex >= 0 Then
    '        If e.ColumnIndex = DataGridView3.Columns("Edit").Index Then
    '            Dim ID = DataGridView3.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
    '            Dim item = DataGridView3.Rows(e.RowIndex).Cells("ItemID").Value.ToString()
    '            lbl_id.Text = item
    '            Label18.Visible = True
    '            lbl_Nproduct.Visible = False
    '            Btn_product.Visible = False
    '            Button10.Visible = True
    '            Button8.Location = New Point(380, 369)
    '            DeleteProduct.Visible = True
    '            Product_AddPanel.Visible = True
    '            Product_AddPanel.BringToFront()
    '            Product_AddPanel.Show()
    '            If Product_AddPanel.Visible Then
    '                LoadProductData()
    '            End If
    '        End If
    '    End If

    'End Sub
    Public Sub RefreshProdutData()
        ' Clear the DataGridView
        DataGridView3.DataSource = Nothing

        ' Re-fetch the data from the database and update the DataGridView
        DataGridProductAdd("")
    End Sub

    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = DataGridView3.Columns("Edit").Index Then
                Dim ID = DataGridView3.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                Dim item = DataGridView3.Rows(e.RowIndex).Cells("ItemID").Value.ToString()
                Product_Add.lbl_id.Text = item

                Product_Add.Label18.Visible = True
                Product_Add.lbl_Nproduct.Visible = False
                Product_Add.Btn_product.Visible = False
                Product_Add.Button10.Visible = True
                Product_Add.DeleteProduct.Visible = True
                Product_Add.Button8.Location = New Point(381, 369)

                Product_Add.MdiParent = Form1
                Product_Add.Show()
                Product_Add.BringToFront()
                'Product_Add.LoadProductData()
                'Product_Add.Button8.Location = New Point(381, 369)
            End If
        End If
    End Sub
End Class