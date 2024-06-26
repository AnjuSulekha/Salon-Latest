﻿Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Org.BouncyCastle.Math.EC

Public Class Close_Workfrm
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim PVColSlno As Integer, PVColItemName As Integer, PVColQuantity As Integer, PVColAmount As Integer
    Private Sub Txt_Service_TextChanged(sender As Object, e As EventArgs) Handles Txt_Service.TextChanged
        FunCalculateAmount()
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub PVCols()
        'PVColSlno = 0
        PVColItemName = 0
        PVColQuantity = 1
        PVColAmount = 2

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
        LoadBill()
        'DT_CLOSE.Columns("Column1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DT_CLOSE.Columns("Column2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'DT_CLOSE.Columns("Column3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'DT_CLOSE.Columns("Column4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        lbl_Staffid.Visible = False
        lbl_Chairid.Visible = False
        CloseWrk_ChairId.Visible = False

        'Call PVCols()
        Try
            Me.Txt_Slno.Text = 1
            ' Call PlaceGrid(0)
            DT_CLOSE.Rows.Add(10)
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = " SELECT ItemName,Rate FROM Item_Master"
            dr = cmd.ExecuteReader()

            Dim TAKEOLD As String = Me.cmb_Itemname.Text
            Me.cmb_Itemname.Items.Clear()
            While dr.Read()
                Me.cmb_Itemname.Items.Add(dr.GetString(0))
            End While
            dr.Close()
            Me.cmb_Itemname.Text = TAKEOLD
            'If con.State = ConnectionState.Closed Then con.Open()
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT StaffID,StaffName, Img FROM StaffMaster WHERE Chair_ID = ?"
            cmd.Parameters.AddWithValue("@Chair_ID", CloseWrk_ChairId.Text)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim staffid As String = reader("StaffID").ToString()
                lbl_Staffid.Text = staffid
                Dim staffName As String = reader("StaffName").ToString()
                Txt_StaffName.Text = staffName
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
    'Private Sub PlaceGrid(ByVal rowindex As Integer)
    '    Dim RowHeight1 As Integer = DT_CLOSE.Rows(rowindex).Height
    '    Dim CellRectangle1 As System.Drawing.Rectangle = DT_CLOSE.GetCellDisplayRectangle(0, rowindex, False)
    '    '  Dim CellRectangle1 As Rectangle = DT_CLOSE.GetCellDisplayRectangle(0, rowindex, False) 'GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)  '
    '    'GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)  '
    '    CellRectangle1.X += DT_CLOSE.Left
    '    CellRectangle1.Y += DT_CLOSE.Top
    '    Txt_Slno.Width = CellRectangle1.Width - 5
    '    Txt_Slno.Left = CellRectangle1.X
    '    Txt_Slno.Top = CellRectangle1.Y
    '    ' MsgBox(CellRectangle1.X)

    '    CellRectangle1 = DT_CLOSE.GetCellDisplayRectangle(1, rowindex, False)
    '    CellRectangle1.X += DT_CLOSE.Left - 4
    '    CellRectangle1.Y += DT_CLOSE.Top
    '    cmb_Itemname.Width = CellRectangle1.Width - 5
    '    cmb_Itemname.Left = CellRectangle1.X
    '    cmb_Itemname.Top = CellRectangle1.Y
    '    If CellRectangle1.Width <= 5 Then
    '        cmb_Itemname.TabStop = False
    '    End If
    '    ' MsgBox(CellRectangle1.X)
    '    'CellRectangle1 = DT_CLOSE.GetCellDisplayRectangle(2, rowindex, False)
    '    'CellRectangle1.X += DT_CLOSE.Left - 8
    '    'CellRectangle1.Y += DT_CLOSE.Top
    '    'Txt_Rate.Width = CellRectangle1.Width - 3

    '    'Txt_Rate.Left = CellRectangle1.X
    '    'Txt_Rate.Top = CellRectangle1.Y
    '    'If CellRectangle1.Width <= 5 Then
    '    '    Txt_Rate.TabStop = False
    '    'End If
    '    CellRectangle1 = DT_CLOSE.GetCellDisplayRectangle(2, rowindex, False)
    '    CellRectangle1.X += DT_CLOSE.Left - 8
    '    CellRectangle1.Y += DT_CLOSE.Top
    '    Txt_QTY.Width = CellRectangle1.Width - 2
    '    Txt_QTY.Left = CellRectangle1.X
    '    Txt_QTY.Top = CellRectangle1.Y
    '    If CellRectangle1.Width <= 5 Then
    '        Txt_QTY.TabStop = False
    '    End If
    '    CellRectangle1 = DT_CLOSE.GetCellDisplayRectangle(3, rowindex, False)
    '    CellRectangle1.X += DT_CLOSE.Left - 9
    '    CellRectangle1.Y += DT_CLOSE.Top
    '    Txt_Amound.Width = CellRectangle1.Width - 5
    '    Txt_Amound.Left = CellRectangle1.X
    '    Txt_Amound.Top = CellRectangle1.Y
    '    If CellRectangle1.Width <= 5 Then
    '        Txt_Amound.TabStop = False
    '    End If
    'End Sub


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
        Dim dis As Integer = Val(Txt_Discount.Text)
        Txt_Bill.Text = Format(ans, "0.00")
        Dim ans1 As Integer = ans - dis '+ rate4
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
                Dim BILL_ID As Integer
                Dim BillNo As Integer
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
                Dim Item_Amount As String
                For Each row As DataGridViewRow In DT_CLOSE.Rows
                    itemName = row.Cells(0).Value.ToString() ' Assuming ItemName is in the first column (index 0)
                    rate = row.Cells(1).Value.ToString() ' Assuming Rate is in the second column (index 1)
                    quantity = row.Cells(2).Value.ToString() ' Assuming Quantity is in the third column (index 2)
                    Item_Amount = row.Cells(3).Value.ToString() ' Assuming Quantity is in the third column (index 2)

                Next

                Dim cmdText As String = "INSERT INTO Bill_inf (BillNo, StaffID, EntryDate,EntryTime , Amount, Cash,Card,Customer,Place,Mobile,EndTime,Staff_Name) 
                VALUES( @BillNo,@StaffID,@EntryDate,@EntryTime, @Amount, @Cash,@Card, @Customer, @Place,@Mobile,@EndTime,@Staff_Name)" ',, , , , ,,, , ,, , ,
                Using cmd As New OleDbCommand(cmdText, con)
                    cmd.Parameters.AddWithValue("@BillNo", Convert.ToInt32(Txt_billno.Text)) ' Convert if necessary
                    cmd.Parameters.AddWithValue("@StaffID", lbl_Staffid.Text)
                    cmd.Parameters.AddWithValue("@EntryDate", entryDate)
                    cmd.Parameters.AddWithValue("@EntryTime", Txt_Start.Text)
                    cmd.Parameters.AddWithValue("@Amount", Txt_Bill.Text)
                    cmd.Parameters.AddWithValue("@Cash", Txt_Cash.Text)
                    cmd.Parameters.AddWithValue("@Card", Txt_Bank.Text)
                    cmd.Parameters.AddWithValue("@Customer", txt_Cname.Text)
                    cmd.Parameters.AddWithValue("@Place", txt_Cplace.Text)
                    cmd.Parameters.AddWithValue("@Mobile", txt_Cmobile.Text)
                    cmd.Parameters.AddWithValue("@EndTime", Txt_End.Text)
                    cmd.Parameters.AddWithValue("@Staff_Name", Txt_StaffName.Text)
                    cmd.ExecuteNonQuery()
                End Using
                con.Close()
                If con.State = ConnectionState.Closed Then con.Open()
                cmd = con.CreateCommand
                cmd.CommandText = "select max(BID),max(BillNo) from Bill_inf"
                dr = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows = True Then
                    If Not dr.IsDBNull(0) AndAlso Not dr.IsDBNull(1) Then
                        ' If IsDBNull(dr.GetValue(0)) = False Then'
                        BILL_ID = dr.GetInt32(0)
                        BillNo = dr.GetInt32(1)

                    Else
                        BILL_ID = 1
                        BillNo = 1
                    End If
                    Else
                        dr.Close()
                    BILL_ID = 1
                    BillNo = 1
                End If
                dr.Close()
                con.Close()
                If con.State = ConnectionState.Closed Then con.Open()
                cmd = con.CreateCommand
                cmd.CommandText = "INSERT INTO Bill_Details (BID,BillNo,EntryDate,ItemName, Qty, Rate, Amount) 
                                  VALUES(@BID,@BillNo, @EntryDate, @ItemName, @Qty, @Rate, @Amount)"
                Using cmdDetails As New OleDbCommand(cmd.CommandText, con)
                    cmdDetails.Parameters.AddWithValue("@BID", BILL_ID)
                    cmdDetails.Parameters.AddWithValue("@BillNo", BillNo)
                    cmdDetails.Parameters.AddWithValue("@EntryDate", entryDate)
                    cmdDetails.Parameters.AddWithValue("@ItemName", itemName)
                    cmdDetails.Parameters.AddWithValue("@Qty", quantity)
                    cmdDetails.Parameters.AddWithValue("@Rate", rate)
                    cmdDetails.Parameters.AddWithValue("@Amount", Item_Amount)
                    cmdDetails.ExecuteNonQuery()
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


                '' Generate PDF
                'Dim fileName As String = "Bill.pdf"
                'Dim filePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName)

                'Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None)
                '    Using doc As New Document()
                '        Using writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
                '            doc.Open()

                '            ' Add bill details to the PDF
                '            doc.Add(New Paragraph("Bill Details"))
                '            doc.Add(New Paragraph($"Entry Date: {entryDate.ToString("yyyy-MM-dd")}"))
                '            doc.Add(New Paragraph($"Service Charge: {Txt_Service.Text}"))
                '            doc.Add(New Paragraph($"Bill Amount: {Txt_Bill.Text}"))
                '            doc.Add(New Paragraph($"Start Time: {Txt_Start.Text}"))
                '            doc.Add(New Paragraph($"End Time: {Txt_End.Text}"))

                '            ' Add items from DataGridView to the PDF
                '            'doc.Add(New Paragraph("Items:"))
                '            'For Each row As DataGridViewRow In DT_CLOSE.Rows
                '            '    Dim itemName As String = row.Cells(0).Value.ToString()
                '            '    Dim rate As String = row.Cells(1).Value.ToString()
                '            '    Dim quantity As String = row.Cells(2).Value.ToString()
                '            '    Dim amount As String = row.Cells(3).Value.ToString()
                '            '    doc.Add(New Paragraph($"Item: {itemName}, Rate: {rate}, Quantity: {quantity}, Amount: {amount}"))
                '            'Next
                '            doc.Close()
                '        End Using
                '    End Using
                'End Using

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
        txt_Cplace.Text = ""
        txt_Cname.Text = ""
        txt_Cmobile.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Txt_Discount_TextChanged(sender As Object, e As EventArgs) Handles Txt_Discount.TextChanged
        FunCalculateAmount()
    End Sub

    Private Sub lbl_WDuration_Click(sender As Object, e As EventArgs) Handles lbl_WDuration.Click

    End Sub
    Private Sub LoadBill()
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "Select Max(BillNo) from Bill_inf"
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                If IsDBNull(dr.GetValue(0)) = False Then
                    Me.Txt_billno.Text = Val(dr.GetValue(0)) + 1
                Else
                    Me.Txt_billno.Text = 1
                End If
            Else
                dr.Close()
                Me.Txt_billno.Text = 1
            End If
            dr.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Txt_Service_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Service.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Product_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Product.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Tax_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Tax.KeyDown
        Call Tabmovement(e.KeyCode)

    End Sub

    Private Sub Txt_Discount_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Discount.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Cash_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Cash.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Bank_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Bank.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles txt_Cname.TextChanged

    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cname.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles txt_Cplace.TextChanged

    End Sub

    Private Sub TextBox10_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cplace.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles txt_Cmobile.TextChanged

    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Cmobile.KeyDown
        Call Tabmovement(e.KeyCode)

    End Sub

    Private Sub Txt_billno_TextChanged(sender As Object, e As EventArgs) Handles Txt_billno.TextChanged

    End Sub

    Private Sub Txt_billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_billno.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_StaffName_TextChanged(sender As Object, e As EventArgs) Handles Txt_StaffName.TextChanged

    End Sub

    Private Sub Txt_StaffName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_StaffName.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Start_TextChanged(sender As Object, e As EventArgs) Handles Txt_Start.TextChanged

    End Sub

    Private Sub Txt_Start_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Start.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_End_TextChanged(sender As Object, e As EventArgs) Handles Txt_End.TextChanged

    End Sub

    Private Sub Txt_End_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_End.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    'Private Sub cmb_Itemname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.SelectedIndexChanged

    'End Sub

    Private Sub cmb_Itemname_KeyDown(sender As Object, e As KeyEventArgs) Handles cmb_Itemname.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_QTY_TextChanged(sender As Object, e As EventArgs) Handles Txt_QTY.TextChanged

    End Sub

    Private Sub Txt_QTY_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_QTY.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Amound_TextChanged(sender As Object, e As EventArgs) Handles Txt_Amound.TextChanged

    End Sub
    Private Sub funclear()
        cmb_Itemname.Text = ""
        Txt_QTY.Text = ""
        Txt_Amound.Text = ""
    End Sub
    'Private Sub Txt_Amound_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Amound.KeyDown
    '    If e.KeyCode = 13 Then
    '        Try
    '            If DT_CLOSE.Rows.Count <= (Me.Txt_Slno.Text) Then
    '                DT_CLOSE.Rows.Add()
    '            End If
    '            DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColSlno).Value = Txt_Slno.Text
    '            DT_CLOSE.Rows(Val(cmb_Itemname.Text) - 1).Cells(PVColItemName).Value = cmb_Itemname.Text
    '            DT_CLOSE.Rows(Val(Txt_QTY.Text) - 1).Cells(PVColQuantity).Value = Txt_QTY.Text
    '            DT_CLOSE.Rows(Val(Txt_Amound.Text) - 1).Cells(PVColAmount).Value = Txt_Amound.Text

    '            funclear()
    '            Txt_Slno.Text = Txt_Slno.Text + 1
    '            If Val(DT_CLOSE.Rows.Count) < Val(Me.Txt_Slno.Text) Then
    '                DT_CLOSE.Rows.Add()
    '            End If
    '            If Trim(DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(0).Value) <> "" Then
    '                Me.Txt_Slno.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColSlno).Value
    '                Me.cmb_Itemname.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColItemName).Value
    '                Me.Txt_QTY.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColQuantity).Value
    '                Me.Txt_Amound.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColAmount).Value
    '                'Me.txt_Disc.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColDisc).Value
    '                'Me.txt_Total.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColTotal).Value
    '                'Me.txt_Ref.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColRef).Value
    '                'Me.txt_Note.Text = DT_CLOSE.Rows(Val(Txt_Slno.Text) - 1).Cells(PVColNarration).Value
    '                Call PlaceGrid(Val(Me.Txt_Slno.Text) - 1)
    '                Me.cmb_Itemname.Focus()
    '            End If
    '            If Val(Me.Txt_Slno.Text) > 10 Then
    '                DT_CLOSE.FirstDisplayedScrollingRowIndex = Val(Me.Txt_Slno.Text) - 10
    '            End If
    '            Call PlaceGrid(Val(Txt_Slno.Text) - 1)
    '            'Me.txt_Code.Focus()

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub
    Private Sub Txt_Amound_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Amound.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim rowIndex As Integer = Val(Txt_Slno.Text) - 1
                ' Check if the row index is valid
                If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then
                    ' Update the corresponding DataGridView cell with textbox and combobox values
                    DT_CLOSE.Rows(rowIndex).Cells(PVColSlno).Value = Txt_Slno.Text
                    DT_CLOSE.Rows(rowIndex).Cells(PVColItemName).Value = cmb_Itemname.Text
                    DT_CLOSE.Rows(rowIndex).Cells(PVColQuantity).Value = Txt_QTY.Text
                    DT_CLOSE.Rows(rowIndex).Cells(PVColAmount).Value = Txt_Amound.Text

                    ' Increment Slno and clear input fields
                    Txt_Slno.Text = (Integer.Parse(Txt_Slno.Text) + 1).ToString()
                    funclear()

                    ' Scroll to the newly added row if necessary
                    If rowIndex > 10 Then
                        DT_CLOSE.FirstDisplayedScrollingRowIndex = rowIndex - 10
                    End If

                    ' Update the DataGridView
                    ' Call PlaceGrid(rowIndex)
                    'UpdateDT_CLOSEDataGridView()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub cmb_Itemname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.SelectedIndexChanged
        ' Get the selected item from the ComboBox
        Dim selectedItem As String = cmb_Itemname.SelectedItem.ToString()

        ' Determine the DataGridView cell where you want to populate the data
        ' For example, if you want to populate the next cell in the same row as the ComboBox
        Dim columnIndex As Integer = 1 ' Assuming the next cell is in the second column (index 1)
        ' Dim rowIndex As Integer = DT_CLOSE.CurrentRow.Index ' Assuming you're using the current row
        Dim rowIndex As Integer = -1
        If DT_CLOSE.CurrentRow IsNot Nothing Then
            rowIndex = DT_CLOSE.CurrentRow.Index
        End If

        ' Set the value of the DataGridView cell to the selected item's data
        DT_CLOSE.Rows(rowIndex).Cells(columnIndex).Value = selectedItem

        ' Optionally, you can fetch additional data related to the selected item and populate other cells
        ' For example, retrieve the amount for the selected item and populate another cell
        Dim amount As Decimal = GetAmountForItem(selectedItem)
        Dim amountColumnIndex As Integer = 2 ' Assuming the amount column index
        DT_CLOSE.Rows(rowIndex).Cells(amountColumnIndex).Value = amount
    End Sub
    Private Function GetAmountForItem(itemName As String) As Decimal
        Dim amount As Decimal = 0

        Try
            ' Assuming you have a database connection named 'con' and a command named 'cmd'
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            cmd.CommandText = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"
            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)
            Dim result = cmd.ExecuteScalar()

            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                amount = Convert.ToDecimal(result)
            End If
        Catch ex As Exception
            ' Handle any exceptions here (e.g., logging or displaying an error message)
            MessageBox.Show("Error retrieving amount: " & ex.Message)
        Finally
            con.Close()
        End Try

        Return amount
    End Function

    'Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
    '    Try
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

    '        Using cmd As New OleDbCommand(cmdText, con)
    '            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

    '            Dim rate As Object = cmd.ExecuteScalar()
    '            If rowIndex >= 0 Then
    '                DT_CLOSE.Rows(rowIndex).Cells("ItemNameColumn").Value = selectedItem
    '                DT_CLOSE.Rows(rowIndex).Cells("AmountColumn").Value = amount
    '            End If
    '            'If rate IsNot Nothing AndAlso Not DBNull.Value.Equals(rate) Then
    '            '    Me.Txt_Amound.Text = rate.ToString()
    '            'Else
    '            '    ' Handle case when rate is not found for the selected item
    '            '    Me.Txt_Amound.Text = "" ' Clear the text box or provide a default value
    '            'End If
    '        End Using

    '    Catch ex As Exception
    '        ' Handle exception, e.g., display error message
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub
    'Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
    '    Try
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

    '        Using cmd As New OleDbCommand(cmdText, con)
    '            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

    '            Dim rate As Object = cmd.ExecuteScalar()

    '            Dim rowIndex As Integer = -1
    '            If DT_CLOSE.CurrentRow IsNot Nothing Then
    '                rowIndex = DT_CLOSE.CurrentRow.Index
    '            End If

    '            If rate IsNot Nothing AndAlso Not DBNull.Value.Equals(rate) AndAlso rowIndex >= 0 Then
    '                DT_CLOSE.Rows(rowIndex).Cells("ItemName").Value = cmb_Itemname.Text
    '                DT_CLOSE.Rows(rowIndex).Cells("Amount").Value = rate
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        ' Handle exception, e.g., display error message
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub
    'Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
    '    Try
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

    '        Using cmd As New OleDbCommand(cmdText, con)
    '            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

    '            Dim rate As Object = cmd.ExecuteScalar()

    '            ' Check if there are any rows in the DataGridView
    '            If DT_CLOSE.Rows.Count > 0 Then
    '                Dim rowIndex As Integer = DT_CLOSE.CurrentRow.Index
    '                Dim columnName1 As String = "ItemName" ' Replace with the actual column name
    '                Dim columnName2 As String = "ItemName" ' Replace with the actual column name

    '                ' Check if the rowIndex is within the valid range
    '                If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then
    '                    ' Check if the column exists in the DataGridView
    '                    If DT_CLOSE.Columns.Contains(columnName1) Then
    '                        ' Update the DataGridView cell value
    '                        DT_CLOSE.Rows(rowIndex).Cells(columnName).Value = cmb_Itemname.Text
    '                        'Else
    '                        '    MessageBox.Show($"Column '{columnName}' not found in the DataGridView.")
    '                    End If
    '                End If
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        ' Handle exception, e.g., display error message
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub
    'jjj
    'Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
    '    Try
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

    '        Using cmd As New OleDbCommand(cmdText, con)
    '            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

    '            Dim rate As Object = cmd.ExecuteScalar()
    '            'MsgBox(rate)

    '            ' Check if there are any rows in the DataGridView
    '            If DT_CLOSE.Rows.Count > 0 Then
    '                Dim rowIndex As Integer = DT_CLOSE.CurrentRow.Index

    '                DT_CLOSE.Rows(rowIndex).Cells(PVColItemName).Value = cmb_Itemname.Text
    '                DT_CLOSE.Rows(rowIndex).Cells(PVColAmount).Value = rate

    '                ' Check if the rowIndex is within the valid range
    '                If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then
    '                    ' Check if the columns exist in the DataGridView
    '                    'If DT_CLOSE.Columns.Contains(itemNameColumn) Then
    '                    ' Update the DataGridView cell values
    '                    'DT_CLOSE.Rows(rowIndex).Cells(itemNameColumn).Value = cmb_Itemname.Text
    '                    '    DT_CLOSE.Rows(rowIndex).Cells(amountColumn).Value = rate.ToString()
    '                    '    MsgBox(rate)
    '                    'Else
    '                    '    MessageBox.Show($"Column not found in the DataGridView.")
    '                    'End If
    '                End If
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        ' Handle exception, e.g., display error message
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    'Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
    '    Try
    '        If con.State = ConnectionState.Closed Then con.Open()

    '        Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

    '        Using cmd As New OleDbCommand(cmdText, con)
    '            cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

    '            Dim rate As Object = cmd.ExecuteScalar()

    '            ' Check if there are any rows in the DataGridView
    '            If DT_CLOSE.Rows.Count > 0 Then
    '                Dim rowIndex As Integer = DT_CLOSE.CurrentRow.Index

    '                ' Check if the rowIndex is within the valid range
    '                If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then
    '                    ' Set the values directly to the correct columns
    '                    'DT_CLOSE.Rows(rowIndex).Cells(ItemName).Value = cmb_Itemname.Text
    '                    'DT_CLOSE.Rows(rowIndex).Cells(Amount).Value = 
    '                    Call PVCols()

    '                    PVColItemName = cmb_Itemname.Text
    '                    PVColAmount = rate
    '                End If
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        ' Handle exception, e.g., display error message
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub
    Private Sub cmb_Itemname_TextChanged(sender As Object, e As EventArgs) Handles cmb_Itemname.TextChanged
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim cmdText As String = "SELECT Rate FROM Item_Master WHERE ItemName = @ItemName"

            Using cmd As New OleDbCommand(cmdText, con)
                cmd.Parameters.AddWithValue("@ItemName", cmb_Itemname.Text)

                Dim rate As Object = cmd.ExecuteScalar()

                ' Check if there are any rows in the DataGridView
                If DT_CLOSE.Rows.Count > 0 Then
                    Dim rowIndex As Integer = DT_CLOSE.CurrentRow.Index

                    ' Check if the rowIndex is within the valid range
                    If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then
                        ' Set the values directly to the correct columns
                        Call PVCols()

                        Dim PVColItemName As Integer = PVColItemName
                        Dim PVColAmount As Integer = PVColAmount

                        DT_CLOSE.Rows(rowIndex).Cells(PVColItemName).Value = cmb_Itemname.Text
                        DT_CLOSE.Rows(rowIndex).Cells(PVColAmount).Value = rate
                    End If
                End If
            End Using

        Catch ex As Exception
            ' Handle exception, e.g., display error message
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    'Private Sub Txt_Amound_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Amound.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        Try
    '            ' Calculate the row index based on Txt_Slno
    '            Dim rowIndex As Integer = Val(Txt_Slno.Text) - 1

    '            ' Add a new row if the index exceeds the row count
    '            If rowIndex >= DT_CLOSE.Rows.Count Then
    '                DT_CLOSE.Rows.Add()
    '            End If

    '            ' Assign data to the cells in the DataGridView row
    '            DT_CLOSE.Rows(rowIndex).Cells(PVColSlno).Value = Txt_Slno.Text
    '            DT_CLOSE.Rows(rowIndex).Cells(PVColItemName).Value = cmb_Itemname.Text
    '            DT_CLOSE.Rows(rowIndex).Cells(PVColQuantity).Value = Txt_QTY.Text
    '            DT_CLOSE.Rows(rowIndex).Cells(PVColAmount).Value = Txt_Amound.Text

    '            ' Clear the text boxes
    '            funclear()

    '            ' Increment Txt_Slno
    '            Txt_Slno.Text = (Val(Txt_Slno.Text) + 1).ToString()

    '            ' Set focus to the next row's ItemName textbox
    '            If rowIndex + 1 < DT_CLOSE.Rows.Count Then
    '                cmb_Itemname.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColItemName).Value.ToString()
    '                Txt_QTY.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColQuantity).Value.ToString()
    '                Txt_Amound.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColAmount).Value.ToString()
    '                cmb_Itemname.Focus()
    '            End If

    '            ' Scroll DataGridView if necessary
    '            If Val(Txt_Slno.Text) > 10 Then
    '                DT_CLOSE.FirstDisplayedScrollingRowIndex = Val(Txt_Slno.Text) - 10
    '            End If

    '            ' Update DataGridView display
    '            PlaceGrid(Val(Txt_Slno.Text) - 1)

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub

    'Private Sub Txt_Amound_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Amound.KeyDown
    '    If e.KeyCode = Keys.Enter Then ' Check if Enter key is pressed
    '        Try
    '            Dim rowIndex As Integer = Val(Txt_Slno.Text) - 1 ' Calculate the row index

    '            If rowIndex >= 0 AndAlso rowIndex < DT_CLOSE.Rows.Count Then ' Check if the row index is valid
    '                ' Assign data from text boxes to corresponding cells in the DataGridView
    '                DT_CLOSE.Rows(rowIndex).Cells(PVColSlno).Value = Txt_Slno.Text
    '                DT_CLOSE.Rows(rowIndex).Cells(PVColItemName).Value = cmb_Itemname.Text
    '                DT_CLOSE.Rows(rowIndex).Cells(PVColQuantity).Value = Txt_QTY.Text
    '                DT_CLOSE.Rows(rowIndex).Cells(PVColAmount).Value = Txt_Amound.Text

    '                funclear() ' Clear the text boxes
    '                Txt_Slno.Text = (Val(Txt_Slno.Text) + 1).ToString() ' Increment Slno
    '                If rowIndex + 1 < DT_CLOSE.Rows.Count Then ' Check if next row exists
    '                    ' Set focus to next row's ItemName textbox
    '                    cmb_Itemname.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColItemName).Value.ToString()
    '                    Txt_QTY.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColQuantity).Value.ToString()
    '                    Txt_Amound.Text = DT_CLOSE.Rows(rowIndex + 1).Cells(PVColAmount).Value.ToString()
    '                    cmb_Itemname.Focus()
    '                End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End If
    'End Sub



End Class
'Dim cmdText As String = "INSERT INTO Bill_inf (BillNo, StaffID, entryDate, EntryTime, Amount, Cash, Card, Customer, Mobile, Place) 
'  VALUES(@BillNo, @StaffID, @EntryDate, @EntryTime, @Amount, @Cash, @Card, @Customer, @Mobile, @Place)"
'Using cmd As New OleDbCommand(cmdText, con)
'    cmd.Parameters.Add("@BillNo", OleDbType.Integer).Value = Convert.ToInt32(Txt_billno.Text)
'    ' cmd.Parameters.AddWithValue("@BillNo", Txt_billno.Text) 'EntryDate,@EntryDate,
'    cmd.Parameters.AddWithValue("@StaffID", lbl_Staffid.Text) 'EntryDate,@EntryDate,
'    cmd.Parameters.AddWithValue("@EntryDate", entryDate)
'    cmd.Parameters.AddWithValue("@EntryTime", Txt_Start.Text)
'    cmd.Parameters.AddWithValue("@Amount", Txt_Bill.Text)
'    cmd.Parameters.AddWithValue("@Cash", Txt_Cash.Text)
'    cmd.Parameters.AddWithValue("@Card", Txt_Bank.Text)
'    'cmd.Parameters.AddWithValue("@BankName", Txt_GrandTotal.Text) ,@BankName',BankName, Amount,, @Amount
'    cmd.Parameters.AddWithValue("@Customer", txt_Cname.Text)
'    cmd.Parameters.AddWithValue("@Mobile", txt_Cplace.Text)
'    cmd.Parameters.AddWithValue("@Place", txt_Cmobile.Text)
'    cmd.ExecuteNonQuery()
'End Using
'con.Close()