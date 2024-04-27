'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Choose_Product
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim DT As New DataTable
    Private Sub Choose_Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridAdd("")
        Txt_QTY.Text = 0
        '  Txt_QTY.Visible = False

    End Sub
    Private Sub DataGridAdd(SearchString As String)
        Try

            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT ItemName,Rate FROM Item_Master"
            If Trim(SearchString) <> "" Then
                cmd.CommandText &= " WHERE ID LIKE '%" & SearchString & "%'"
            End If
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            ' Create a DataTable
            Dim DT As New DataTable
            DT.Columns.Add("ItemName")
            DT.Columns.Add("Rate")

            While dr.Read()
                ' Add rows to the DataTable
                DT.Rows.Add(dr("ItemName"), dr("Rate"))
            End While

            ', Tax, Details
            dr.Close()
            DT_Prodcut.DataSource = DT

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
    Private Sub DT_Prodcut_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DT_Prodcut.CellClick
        Txt_QTY.Text = 1
        Txt_QTY.Visible = True
        If DT_Prodcut.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DT_Prodcut.SelectedRows(0)
            Txt_Item.Text = selectedRow.Cells("ItemName").Value.ToString()
            Txt_Rate.Text = selectedRow.Cells("Rate").Value.ToString()

        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles Txt_QTY.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Close_Workfrm
            Dim data1 As String = Txt_Item.Text
            Dim data2 As String = Txt_Rate.Text
            Dim data3 As String = Txt_QTY.Text
            Dim amount As Double = Double.Parse(data2) * Double.Parse(data3)
            .DT_CLOSE.Rows.Add(data1, data2, data3, amount)
            .Txt_Product.Text = amount
            '.UpdateTotalBill(.Txt_Service.Text, amount, .Txt_Bill)
            '.Txt_Bill.Text = .Txt_Product.Text + .Txt_Service.Text
            .dataLoaded = True
            Me.Close()
            .BringToFront()
            .Show()
        End With

    End Sub

End Class