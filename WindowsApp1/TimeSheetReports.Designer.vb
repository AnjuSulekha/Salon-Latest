<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TimeSheetReports
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
        Me.DT_Date = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Print = New System.Windows.Forms.Button()
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.TReport_ListView = New System.Windows.Forms.ListView()
        Me.Btn_show = New System.Windows.Forms.Button()
        Me.Cmb_StaffName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Total = New System.Windows.Forms.Label()
        Me.Txt_TotalAmount = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DT_Date
        '
        Me.DT_Date.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DT_Date.Location = New System.Drawing.Point(74, 28)
        Me.DT_Date.Name = "DT_Date"
        Me.DT_Date.Size = New System.Drawing.Size(100, 22)
        Me.DT_Date.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Total)
        Me.Panel1.Controls.Add(Me.Txt_TotalAmount)
        Me.Panel1.Controls.Add(Me.Btn_Print)
        Me.Panel1.Controls.Add(Me.Btn_Export)
        Me.Panel1.Controls.Add(Me.TReport_ListView)
        Me.Panel1.Controls.Add(Me.Btn_show)
        Me.Panel1.Controls.Add(Me.Cmb_StaffName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DT_Date)
        Me.Panel1.Location = New System.Drawing.Point(12, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 418)
        Me.Panel1.TabIndex = 2
        '
        'Btn_Print
        '
        Me.Btn_Print.BackColor = System.Drawing.Color.White
        Me.Btn_Print.FlatAppearance.BorderSize = 0
        Me.Btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Print.Location = New System.Drawing.Point(569, 24)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(83, 29)
        Me.Btn_Print.TabIndex = 8
        Me.Btn_Print.Text = "Print"
        Me.Btn_Print.UseVisualStyleBackColor = False
        '
        'Btn_Export
        '
        Me.Btn_Export.BackColor = System.Drawing.Color.White
        Me.Btn_Export.FlatAppearance.BorderSize = 0
        Me.Btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Export.Location = New System.Drawing.Point(480, 24)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(83, 29)
        Me.Btn_Export.TabIndex = 7
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = False
        '
        'TReport_ListView
        '
        Me.TReport_ListView.HideSelection = False
        Me.TReport_ListView.Location = New System.Drawing.Point(30, 59)
        Me.TReport_ListView.Name = "TReport_ListView"
        Me.TReport_ListView.Size = New System.Drawing.Size(622, 302)
        Me.TReport_ListView.TabIndex = 6
        Me.TReport_ListView.UseCompatibleStateImageBehavior = False
        '
        'Btn_show
        '
        Me.Btn_show.BackColor = System.Drawing.Color.White
        Me.Btn_show.FlatAppearance.BorderSize = 0
        Me.Btn_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_show.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_show.Location = New System.Drawing.Point(391, 24)
        Me.Btn_show.Name = "Btn_show"
        Me.Btn_show.Size = New System.Drawing.Size(83, 29)
        Me.Btn_show.TabIndex = 5
        Me.Btn_show.Text = "Show"
        Me.Btn_show.UseVisualStyleBackColor = False
        '
        'Cmb_StaffName
        '
        Me.Cmb_StaffName.FormattingEnabled = True
        Me.Cmb_StaffName.Location = New System.Drawing.Point(250, 28)
        Me.Cmb_StaffName.Name = "Cmb_StaffName"
        Me.Cmb_StaffName.Size = New System.Drawing.Size(121, 21)
        Me.Cmb_StaffName.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(207, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Staff"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date"
        '
        'Total
        '
        Me.Total.AutoSize = True
        Me.Total.Location = New System.Drawing.Point(460, 364)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(31, 13)
        Me.Total.TabIndex = 3
        Me.Total.Text = "Total"
        '
        'Txt_TotalAmount
        '
        Me.Txt_TotalAmount.Location = New System.Drawing.Point(494, 363)
        Me.Txt_TotalAmount.Name = "Txt_TotalAmount"
        Me.Txt_TotalAmount.Size = New System.Drawing.Size(158, 20)
        Me.Txt_TotalAmount.TabIndex = 4
        '
        'TimeSheetReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(701, 426)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TimeSheetReports"
        Me.Text = "TimeSheetReports"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DT_Date As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cmb_StaffName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_show As Button
    Friend WithEvents TReport_ListView As ListView
    Friend WithEvents Btn_Print As Button
    Friend WithEvents Btn_Export As Button
    Friend WithEvents Total As Label
    Friend WithEvents Txt_TotalAmount As TextBox
End Class
