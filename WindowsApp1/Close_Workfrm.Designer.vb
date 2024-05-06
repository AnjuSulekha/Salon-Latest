<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Close_Workfrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Service = New System.Windows.Forms.TextBox()
        Me.Txt_Bill = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_GrandTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Cash = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_Product = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_WDuration = New System.Windows.Forms.Label()
        Me.Txt_End = New System.Windows.Forms.TextBox()
        Me.Txt_Start = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_Tax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_Cname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Cplace = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_Cmobile = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Txt_Bank = New System.Windows.Forms.TextBox()
        Me.Btn_SaveBill = New System.Windows.Forms.Button()
        Me.CloseWrk_ChairId = New System.Windows.Forms.Label()
        Me.DT_CLOSE = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lbl_Chairid = New System.Windows.Forms.Label()
        Me.lbl_StaffName = New System.Windows.Forms.Label()
        Me.lbl_Staffid = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Discount = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbl_Date = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BillNO = New System.Windows.Forms.Label()
        Me.Txt_billno = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Txt_StaffName = New System.Windows.Forms.TextBox()
        CType(Me.DT_CLOSE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Service Charge"
        '
        'Txt_Service
        '
        Me.Txt_Service.Location = New System.Drawing.Point(99, 191)
        Me.Txt_Service.Name = "Txt_Service"
        Me.Txt_Service.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Service.TabIndex = 1
        Me.Txt_Service.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Bill
        '
        Me.Txt_Bill.Location = New System.Drawing.Point(485, 192)
        Me.Txt_Bill.Name = "Txt_Bill"
        Me.Txt_Bill.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Bill.TabIndex = 100
        Me.Txt_Bill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(423, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Bill Amount"
        '
        'Txt_GrandTotal
        '
        Me.Txt_GrandTotal.Location = New System.Drawing.Point(485, 214)
        Me.Txt_GrandTotal.Name = "Txt_GrandTotal"
        Me.Txt_GrandTotal.Size = New System.Drawing.Size(117, 20)
        Me.Txt_GrandTotal.TabIndex = 102
        Me.Txt_GrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(417, 217)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Grand Total"
        '
        'Txt_Cash
        '
        Me.Txt_Cash.Location = New System.Drawing.Point(300, 236)
        Me.Txt_Cash.Name = "Txt_Cash"
        Me.Txt_Cash.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Cash.TabIndex = 5
        Me.Txt_Cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(257, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cash"
        '
        'Txt_Product
        '
        Me.Txt_Product.Location = New System.Drawing.Point(300, 191)
        Me.Txt_Product.Name = "Txt_Product"
        Me.Txt_Product.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Product.TabIndex = 2
        Me.Txt_Product.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(222, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Product Charge"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(417, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 28)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "ADD PRODUCT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(417, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Work Duration "
        '
        'lbl_WDuration
        '
        Me.lbl_WDuration.AutoSize = True
        Me.lbl_WDuration.Location = New System.Drawing.Point(502, 20)
        Me.lbl_WDuration.Name = "lbl_WDuration"
        Me.lbl_WDuration.Size = New System.Drawing.Size(39, 13)
        Me.lbl_WDuration.TabIndex = 99
        Me.lbl_WDuration.Text = "Label7"
        '
        'Txt_End
        '
        Me.Txt_End.Location = New System.Drawing.Point(294, 40)
        Me.Txt_End.Name = "Txt_End"
        Me.Txt_End.Size = New System.Drawing.Size(117, 20)
        Me.Txt_End.TabIndex = 17
        '
        'Txt_Start
        '
        Me.Txt_Start.Location = New System.Drawing.Point(77, 40)
        Me.Txt_Start.Name = "Txt_Start"
        Me.Txt_Start.Size = New System.Drawing.Size(141, 20)
        Me.Txt_Start.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(228, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "End Time "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Start Time "
        '
        'Txt_Tax
        '
        Me.Txt_Tax.Location = New System.Drawing.Point(99, 212)
        Me.Txt_Tax.Name = "Txt_Tax"
        Me.Txt_Tax.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Tax.TabIndex = 3
        Me.Txt_Tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Tax Amount"
        '
        'txt_Cname
        '
        Me.txt_Cname.Location = New System.Drawing.Point(99, 265)
        Me.txt_Cname.Name = "txt_Cname"
        Me.txt_Cname.Size = New System.Drawing.Size(191, 20)
        Me.txt_Cname.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 272)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Customer Name"
        '
        'txt_Cplace
        '
        Me.txt_Cplace.Location = New System.Drawing.Point(99, 287)
        Me.txt_Cplace.Name = "txt_Cplace"
        Me.txt_Cplace.Size = New System.Drawing.Size(191, 20)
        Me.txt_Cplace.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 291)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Place"
        '
        'txt_Cmobile
        '
        Me.txt_Cmobile.Location = New System.Drawing.Point(99, 310)
        Me.txt_Cmobile.Name = "txt_Cmobile"
        Me.txt_Cmobile.Size = New System.Drawing.Size(191, 20)
        Me.txt_Cmobile.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 319)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Number"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(446, 241)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Card"
        '
        'Txt_Bank
        '
        Me.Txt_Bank.Location = New System.Drawing.Point(485, 236)
        Me.Txt_Bank.Name = "Txt_Bank"
        Me.Txt_Bank.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Bank.TabIndex = 6
        Me.Txt_Bank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_SaveBill
        '
        Me.Btn_SaveBill.Location = New System.Drawing.Point(99, 353)
        Me.Btn_SaveBill.Name = "Btn_SaveBill"
        Me.Btn_SaveBill.Size = New System.Drawing.Size(75, 27)
        Me.Btn_SaveBill.TabIndex = 10
        Me.Btn_SaveBill.Text = "Save Bill"
        Me.Btn_SaveBill.UseVisualStyleBackColor = True
        '
        'CloseWrk_ChairId
        '
        Me.CloseWrk_ChairId.AutoSize = True
        Me.CloseWrk_ChairId.Location = New System.Drawing.Point(614, 259)
        Me.CloseWrk_ChairId.Name = "CloseWrk_ChairId"
        Me.CloseWrk_ChairId.Size = New System.Drawing.Size(45, 13)
        Me.CloseWrk_ChairId.TabIndex = 31
        Me.CloseWrk_ChairId.Text = "Label15"
        '
        'DT_CLOSE
        '
        Me.DT_CLOSE.AllowUserToAddRows = False
        Me.DT_CLOSE.AllowUserToDeleteRows = False
        Me.DT_CLOSE.AllowUserToResizeColumns = False
        Me.DT_CLOSE.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.DT_CLOSE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DT_CLOSE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DT_CLOSE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DT_CLOSE.BackgroundColor = System.Drawing.Color.Silver
        Me.DT_CLOSE.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DT_CLOSE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DT_CLOSE.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DT_CLOSE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DT_CLOSE.ColumnHeadersHeight = 40
        Me.DT_CLOSE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DT_CLOSE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DT_CLOSE.DefaultCellStyle = DataGridViewCellStyle11
        Me.DT_CLOSE.EnableHeadersVisualStyles = False
        Me.DT_CLOSE.Location = New System.Drawing.Point(12, 69)
        Me.DT_CLOSE.Name = "DT_CLOSE"
        Me.DT_CLOSE.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DT_CLOSE.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DT_CLOSE.RowHeadersVisible = False
        Me.DT_CLOSE.RowTemplate.Height = 50
        Me.DT_CLOSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DT_CLOSE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DT_CLOSE.Size = New System.Drawing.Size(617, 108)
        Me.DT_CLOSE.TabIndex = 32
        '
        'Column1
        '
        Me.Column1.HeaderText = "ItemName"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Rate"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Delete"
        Me.Column5.Name = "Column5"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(594, 308)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lbl_Chairid
        '
        Me.lbl_Chairid.AutoSize = True
        Me.lbl_Chairid.Location = New System.Drawing.Point(614, 282)
        Me.lbl_Chairid.Name = "lbl_Chairid"
        Me.lbl_Chairid.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Chairid.TabIndex = 34
        Me.lbl_Chairid.Text = "Label7"
        '
        'lbl_StaffName
        '
        Me.lbl_StaffName.AutoSize = True
        Me.lbl_StaffName.Location = New System.Drawing.Point(632, 199)
        Me.lbl_StaffName.Name = "lbl_StaffName"
        Me.lbl_StaffName.Size = New System.Drawing.Size(39, 13)
        Me.lbl_StaffName.TabIndex = 35
        Me.lbl_StaffName.Text = "Label7"
        '
        'lbl_Staffid
        '
        Me.lbl_Staffid.AutoSize = True
        Me.lbl_Staffid.Location = New System.Drawing.Point(620, 219)
        Me.lbl_Staffid.Name = "lbl_Staffid"
        Me.lbl_Staffid.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Staffid.TabIndex = 36
        Me.lbl_Staffid.Text = "Label7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(251, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Discount"
        '
        'Txt_Discount
        '
        Me.Txt_Discount.Location = New System.Drawing.Point(300, 213)
        Me.Txt_Discount.Name = "Txt_Discount"
        Me.Txt_Discount.Size = New System.Drawing.Size(117, 20)
        Me.Txt_Discount.TabIndex = 4
        Me.Txt_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(260, 353)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 27)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbl_Date
        '
        Me.lbl_Date.AutoSize = True
        Me.lbl_Date.Location = New System.Drawing.Point(614, 243)
        Me.lbl_Date.Name = "lbl_Date"
        Me.lbl_Date.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Date.TabIndex = 40
        Me.lbl_Date.Text = "Label15"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(180, 353)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 27)
        Me.Button4.TabIndex = 41
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(505, 261)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 70)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'BillNO
        '
        Me.BillNO.AutoSize = True
        Me.BillNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillNO.Location = New System.Drawing.Point(12, 15)
        Me.BillNO.Name = "BillNO"
        Me.BillNO.Size = New System.Drawing.Size(58, 20)
        Me.BillNO.TabIndex = 42
        Me.BillNO.Text = "Bill_No"
        '
        'Txt_billno
        '
        Me.Txt_billno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_billno.Location = New System.Drawing.Point(76, 15)
        Me.Txt_billno.Name = "Txt_billno"
        Me.Txt_billno.Size = New System.Drawing.Size(142, 22)
        Me.Txt_billno.TabIndex = 43
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(228, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Staff Name"
        '
        'Txt_StaffName
        '
        Me.Txt_StaffName.Location = New System.Drawing.Point(294, 17)
        Me.Txt_StaffName.Name = "Txt_StaffName"
        Me.Txt_StaffName.Size = New System.Drawing.Size(117, 20)
        Me.Txt_StaffName.TabIndex = 45
        '
        'Close_Workfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(671, 395)
        Me.Controls.Add(Me.lbl_WDuration)
        Me.Controls.Add(Me.Txt_StaffName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Txt_billno)
        Me.Controls.Add(Me.BillNO)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.lbl_Date)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Txt_Discount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_Staffid)
        Me.Controls.Add(Me.lbl_StaffName)
        Me.Controls.Add(Me.lbl_Chairid)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DT_CLOSE)
        Me.Controls.Add(Me.CloseWrk_ChairId)
        Me.Controls.Add(Me.Btn_SaveBill)
        Me.Controls.Add(Me.Txt_Bank)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_Cmobile)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_Cplace)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_Cname)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_Tax)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_End)
        Me.Controls.Add(Me.Txt_Start)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Txt_Product)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_Cash)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_GrandTotal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Bill)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Service)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Close_Workfrm"
        Me.Text = "Close_Workfrm"
        CType(Me.DT_CLOSE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Service As TextBox
    Friend WithEvents Txt_Bill As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_GrandTotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Cash As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_Product As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_WDuration As Label
    Friend WithEvents Txt_End As TextBox
    Friend WithEvents Txt_Start As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Txt_Tax As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_Cname As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_Cplace As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_Cmobile As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Txt_Bank As TextBox
    Friend WithEvents Btn_SaveBill As Button
    Friend WithEvents CloseWrk_ChairId As Label
    Friend WithEvents DT_CLOSE As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents lbl_Chairid As Label
    Friend WithEvents lbl_StaffName As Label
    Friend WithEvents lbl_Staffid As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Txt_Discount As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents lbl_Date As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents BillNO As Label
    Friend WithEvents Txt_billno As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Txt_StaffName As TextBox
End Class
