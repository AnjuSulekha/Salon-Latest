Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class Close_Workfrm
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Private Sub Txt_Service_TextChanged(sender As Object, e As EventArgs) Handles Txt_Service.TextChanged
        FunCalculateAmount()
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub
    'Private Sub Close_Workfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    WorkCalculation()
    '    lbl_Chairid.Text = BtnOptions.Chair_Opt.Text
    '    DT_CLOSE.Columns.Add("Column1", "Item Name")
    '    DT_CLOSE.Columns.Add("Column2", "Rate")
    '    DT_CLOSE.Columns.Add("Column3", "Quantity")
    '    DT_CLOSE.Columns.Add("Column4", "Amount")
    '    'DT_CLOSE.Columns.Add("Column5", "Delete")
    '    DT_CLOSE.Columns("Column1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '    DT_CLOSE.Columns("Column2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '    DT_CLOSE.Columns("Column3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '    DT_CLOSE.Columns("Column4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '    Try
    '        con.ConnectionString = ConString
    '        cmd = con.CreateCommand
    '        If con.State = ConnectionState.Closed Then con.Open()
    '        cmd.CommandText = "select StaffName,Img from StaffMaster where Chair_ID=" & lbl_Chairid.Text & ""
    '        cmd.ExecuteNonQuery()
    '        con.Close()

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub Close_Workfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WorkCalculation()

        'DT_CLOSE.Columns.Add("Column1", "ItemName")
        'DT_CLOSE.Columns.Add("Column2", "Rate")
        'DT_CLOSE.Columns.Add("Column3", "Quantity")
        'DT_CLOSE.Columns.Add("Column4", "Amount")
        'DT_CLOSE.Columns.Add("Column5", "Delete")
        DT_CLOSE.Columns("Column1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DT_CLOSE.Columns("Column2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DT_CLOSE.Columns("Column3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DT_CLOSE.Columns("Column4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        lbl_Staffid.Visible = False
        lbl_Chairid.Visible = False
        CloseWrk_ChairId.Visible = False
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT StaffID,StaffName, Img FROM StaffMaster WHERE Chair_ID = ?"
            cmd.Parameters.AddWithValue("@Chair_ID", CloseWrk_ChairId.Text)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim staffid As String = reader("StaffID").ToString()
                lbl_Staffid.Text = staffid
                Dim staffName As String = reader("StaffName").ToString()
                lbl_StaffName.Text = staffName
                Dim imagePath As String = reader("Img").ToString() ' Corrected here

                ' Display the image in PictureBox
                If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                    ' Load image only if the file path is not empty and the file exists
                    Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    ' Me.PictureBox1.Image = Image.FromFile(imagePath)
                End If
            End If
            reader.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            ' Handle exception
        End Try

    End Sub

    Public Function WorkCalculation() As String
        Dim workDurationFormatted As String = ""

        Try
            Dim startTime As DateTime
            Dim endTime As DateTime
            Dim startTimeString As String = ""
            Dim endTimeString As String = ""

            con.ConnectionString = ConString
            cmd = con.CreateCommand

            If con.State = ConnectionState.Closed Then con.Open()

            cmd.CommandText = "SELECT StartTime, EndTime FROM Chair WHERE ID = " & CloseWrk_ChairId.Text
            dr = cmd.ExecuteReader()

            If dr.Read() Then
                startTimeString = dr("StartTime").ToString()
                endTimeString = dr("EndTime").ToString()

                ' Parse start and end times as DateTime objects
                startTime = DateTime.Parse(startTimeString)
                endTime = DateTime.Parse(endTimeString)

                ' Calculate work duration
                Dim workDuration As TimeSpan

                ' Ensure end time is after start time
                If endTime >= startTime Then
                    workDuration = endTime - startTime
                Else
                    ' If end time is before start time (e.g., if start time is 11:00 PM and end time is 01:00 AM)
                    ' Add 24 hours to end time and calculate the difference
                    workDuration = endTime.AddDays(1) - startTime
                End If

                ' Format the result
                Dim totalMinutes As Integer = CInt(workDuration.TotalMinutes)
                Dim hours As Integer = totalMinutes \ 60
                Dim minutes As Integer = totalMinutes Mod 60

                workDurationFormatted = String.Format("{0} hours and {1} minutes", hours, minutes)

                ' Display start and end times in text boxes (12-hour format)
                Txt_Start.Text = startTime.ToString("hh:mm tt") ' 12-hour format
                Txt_End.Text = endTime.ToString("hh:mm tt") ' 12-hour format
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error calculating work duration: " & ex.Message)
        Finally
            con.Close()
        End Try

        lbl_WDuration.Text = workDurationFormatted
        Return workDurationFormatted
    End Function


    Private Sub CloseWrk_ChairId_Click(sender As Object, e As EventArgs) Handles CloseWrk_ChairId.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Choose_Product.MdiParent = Form1
        Choose_Product.Show()
        Choose_Product.BringToFront()
    End Sub

    Private Sub DT_CLOSE_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DT_CLOSE.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DT_CLOSE.Rows.Clear()
    End Sub

    Private Sub Txt_Product_TextChanged(sender As Object, e As EventArgs) Handles Txt_Product.TextChanged
        FunCalculateAmount()

    End Sub
    Private Sub FunCalculateAmount()

        Dim qty2 As Integer = Val(Txt_Service.Text)
        Dim rate2 As Integer = Val(Txt_Product.Text)
        Dim rate4 As Integer = Val(Txt_Tax.Text)
        Dim ans As Integer = qty2 + rate2
        Txt_Bill.Text = Format(ans, "0.00")
        Dim ans1 As Integer = ans + rate4
        Txt_GrandTotal.Text = Format(ans1, "0.00")
        Dim bank As Integer = Val(Txt_Bank.Text)
        Dim ans2 As Integer = ans1 - bank
        Txt_Cash.Text = Format(ans2, "0.00")

    End Sub


    Private Sub Txt_GrandTotal_TextChanged(sender As Object, e As EventArgs) Handles Txt_GrandTotal.TextChanged
        FunCalculateAmount()
    End Sub

    Private Sub Txt_Bill_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bill.TextChanged

    End Sub

    Private Sub Txt_Tax_TextChanged(sender As Object, e As EventArgs) Handles Txt_Tax.TextChanged
        FunCalculateAmount()
    End Sub

    Private Sub Txt_Cash_TextChanged(sender As Object, e As EventArgs) Handles Txt_Cash.TextChanged
        FunCalculateAmount()

    End Sub

    Private Sub Txt_Bank_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bank.TextChanged
        FunCalculateAmount()
    End Sub

    Private Sub Tabmovement(ByVal Keycode As Integer)
        If Keycode = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Btn_SaveBill_Click(sender As Object, e As EventArgs) Handles Btn_SaveBill.Click
        Try
            Using con As New OleDbConnection(ConString)
                con.Open()
                Dim entryDate As DateTime = DateTime.Today
                '   Dim amount As Decimal = Decimal.Parse(Txt_GrandTotal.Text)
                ' lbl_Date.Text = entryDate.ToString("yyyy-MM-dd")
                If String.IsNullOrWhiteSpace(Txt_Service.Text) Then
                    MsgBox("Service Charge is Required.")
                    Txt_Service.Focus()
                    Return
                End If
                Dim itemName As String ' Assuming ItemName is in the first column (index 0)
                Dim rate As String  ' Assuming Rate is in the second column (index 1)
                Dim quantity As String
                For Each row As DataGridViewRow In DT_CLOSE.Rows
                    itemName = row.Cells(0).Value.ToString() ' Assuming ItemName is in the first column (index 0)
                    rate = row.Cells(1).Value.ToString() ' Assuming Rate is in the second column (index 1)
                    quantity = row.Cells(2).Value.ToString() ' Assuming Quantity is in the third column (index 2)
                Next
                Dim cmdText As String = "INSERT INTO Bill_Details (EntryDate,ItemName, Rate, Qty,Amount) VALUES (@EntryDate,@ItemName, @Rate, @Qty,@Amount)"
                Using cmd As New OleDbCommand(cmdText, con)
                    cmd.Parameters.AddWithValue("@EntryDate", entryDate) 'EntryDate,@EntryDate,
                    cmd.Parameters.AddWithValue("@ItemName", itemName)
                    cmd.Parameters.AddWithValue("@Rate", rate)
                    cmd.Parameters.AddWithValue("@Qty", quantity)
                    cmd.Parameters.AddWithValue("@Amount", Txt_GrandTotal.Text) ', Amount,, @Amount
                    cmd.ExecuteNonQuery()
                End Using

                con.Close()
                If con.State = ConnectionState.Closed Then con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "UPDATE StaffMaster SET Chair_ID = 0 WHERE StaffID = @StaffID"
                cmd.Parameters.AddWithValue("@StaffID", lbl_Staffid.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                If con.State = ConnectionState.Closed Then con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "UPDATE Chair SET StaffName=NULL WHERE ID=@ID"
                cmd.Parameters.AddWithValue("@ID", CloseWrk_ChairId.Text)
                cmd.ExecuteNonQuery()
                con.Close()
                ' Generate PDF
                Dim fileName As String = "Bill.pdf"
                Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)

                Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
                    Using doc As New Document()
                        Using writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                            doc.Open()

                            ' Add bill details to the PDF
                            doc.Add(New Paragraph("Bill Details"))
                            doc.Add(New Paragraph($"Entry Date: {entryDate.ToString("yyyy-MM-dd")}"))
                            doc.Add(New Paragraph($"Service Charge: {Txt_Service.Text}"))
                            doc.Add(New Paragraph($"Bill Amount: {Txt_Bill.Text}"))
                            doc.Add(New Paragraph($"Start Time: {Txt_Start.Text}"))
                            doc.Add(New Paragraph($"End Time: {Txt_End.Text}"))

                            ' Add items from DataGridView to the PDF
                            'doc.Add(New Paragraph("Items:"))
                            'For Each row As DataGridViewRow In DT_CLOSE.Rows
                            '    Dim itemName As String = row.Cells(0).Value.ToString()
                            '    Dim rate As String = row.Cells(1).Value.ToString()
                            '    Dim quantity As String = row.Cells(2).Value.ToString()
                            '    Dim amount As String = row.Cells(3).Value.ToString()
                            '    doc.Add(New Paragraph($"Item: {itemName}, Rate: {rate}, Quantity: {quantity}, Amount: {amount}"))
                            'Next
                            doc.Close()
                        End Using
                    End Using
                End Using

                clear()
                Me.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            ' Handle exception
        End Try
    End Sub

    'Private Sub DT_CLOSE_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DT_CLOSE.CellPainting
    '    If e.ColumnIndex = DT_CLOSE.Columns("Column5").Index AndAlso e.RowIndex >= 0 Then
    '        ' Get the delete icon image
    '        Dim deleteIcon As Image = My.Resources.trash ' Assuming "DeleteIcon" is the name of your delete icon resource

    '        ' Calculate the position to draw the icon
    '        Dim iconX As Integer = e.CellBounds.Left + (e.CellBounds.Width - deleteIcon.Width) / 2 ' Center horizontally
    '        Dim iconY As Integer = e.CellBounds.Top + (e.CellBounds.Height - deleteIcon.Height) / 2 ' Center vertically

    '        ' Draw the cell's background
    '        e.PaintBackground(e.CellBounds, False)

    '        ' Draw the icon to the center of the cell
    '        e.Graphics.DrawImage(deleteIcon, iconX, iconY)

    '        ' Suppress default painting of the cell content
    '        e.Handled = True
    '    End If
    'End Sub
    Public dataLoaded As Boolean = False

    'Private Sub DT_CLOSE_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DT_CLOSE.CellPainting
    '    ' Check if the cell being painted is in the "Delete" column, if the row index is valid, 
    '    ' and if data has been loaded into the DataGridView
    '    If dataLoaded = True Then


    '        If e.ColumnIndex = DT_CLOSE.Columns("Delete").Index AndAlso e.RowIndex >= 0 Then
    '            ' Get the delete icon image
    '            Dim deleteIcon As Image = My.Resources.trash ' Assuming "DeleteIcon" is the name of your delete icon resource

    '            ' Calculate the position to draw the icon
    '            Dim iconX As Integer = e.CellBounds.Left + (e.CellBounds.Width - deleteIcon.Width) / 2 ' Center horizontally
    '            Dim iconY As Integer = e.CellBounds.Top + (e.CellBounds.Height - deleteIcon.Height) / 2 ' Center vertically

    '            ' Draw the cell's background
    '            e.PaintBackground(e.CellBounds, False)

    '            ' Draw the icon to the center of the cell
    '            e.Graphics.DrawImage(deleteIcon, iconX, iconY)

    '            ' Suppress default painting of the cell content
    '            e.Handled = True
    '        End If
    '    End If
    'Private Sub DT_CLOSE_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DT_CLOSE.CellPainting
    '    ' Check if the cell being painted is in the "Delete" column and if the row index is valid
    '    If dataLoaded = True Then

    '        If e.RowIndex >= 0 AndAlso DT_CLOSE.Columns.Contains("Delete") Then
    '            Dim deleteColumnIndex As Integer = DT_CLOSE.Columns("Delete").Index
    '            If e.ColumnIndex = deleteColumnIndex Then
    '                ' Get the delete icon image
    '                Dim deleteIcon As Image = My.Resources.trash ' Assuming "DeleteIcon" is the name of your delete icon resource

    '                ' Calculate the position to draw the icon
    '                Dim iconX As Integer = e.CellBounds.Left + (e.CellBounds.Width - deleteIcon.Width) / 2 ' Center horizontally
    '                Dim iconY As Integer = e.CellBounds.Top + (e.CellBounds.Height - deleteIcon.Height) / 2 ' Center vertically

    '                ' Draw the cell's background
    '                e.PaintBackground(e.CellBounds, False)

    '                ' Draw the icon to the center of the cell
    '                e.Graphics.DrawImage(deleteIcon, iconX, iconY)

    '                ' Suppress default painting of the cell content
    '                e.Handled = True
    '            End If
    '        End If

    '    End If
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to Close the form", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            clear()
        Else
            Me.Show()
        End If

    End Sub
    Private Sub clear()
        Txt_Start.Text = ""
        Txt_End.Text = ""
        Txt_Service.Text = ""
        Txt_Bill.Text = ""
        Txt_GrandTotal.Text = ""
        Txt_Cash.Text = ""
        Txt_Bank.Text = ""
        Txt_Product.Text = ""
        Txt_Tax.Text = ""
        Txt_Discount.Text = ""
        TextBox10.Text = ""
        TextBox9.Text = ""
        TextBox11.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class