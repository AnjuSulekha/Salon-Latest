<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chair_Add
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel_AddChair = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Txt_ChairType = New System.Windows.Forms.TextBox()
        Me.Txt_ChairName = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lbl_ChairID = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_Update = New System.Windows.Forms.Label()
        Me.Exit_btn = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Edit_btn = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Panel_AddChair.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_AddChair
        '
        Me.Panel_AddChair.Controls.Add(Me.Button1)
        Me.Panel_AddChair.Controls.Add(Me.Txt_ChairType)
        Me.Panel_AddChair.Controls.Add(Me.Txt_ChairName)
        Me.Panel_AddChair.Controls.Add(Me.DataGridView1)
        Me.Panel_AddChair.Controls.Add(Me.lbl_ChairID)
        Me.Panel_AddChair.Controls.Add(Me.Label11)
        Me.Panel_AddChair.Controls.Add(Me.lbl_Update)
        Me.Panel_AddChair.Controls.Add(Me.Exit_btn)
        Me.Panel_AddChair.Controls.Add(Me.Button7)
        Me.Panel_AddChair.Controls.Add(Me.Panel10)
        Me.Panel_AddChair.Controls.Add(Me.Label1)
        Me.Panel_AddChair.Controls.Add(Me.Label10)
        Me.Panel_AddChair.Controls.Add(Me.Panel11)
        Me.Panel_AddChair.Controls.Add(Me.Edit_btn)
        Me.Panel_AddChair.Controls.Add(Me.Button12)
        Me.Panel_AddChair.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_AddChair.Location = New System.Drawing.Point(0, 0)
        Me.Panel_AddChair.Name = "Panel_AddChair"
        Me.Panel_AddChair.Size = New System.Drawing.Size(886, 450)
        Me.Panel_AddChair.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(265, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 27)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Txt_ChairType
        '
        Me.Txt_ChairType.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_ChairType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ChairType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ChairType.Location = New System.Drawing.Point(103, 122)
        Me.Txt_ChairType.Name = "Txt_ChairType"
        Me.Txt_ChairType.Size = New System.Drawing.Size(337, 22)
        Me.Txt_ChairType.TabIndex = 2
        '
        'Txt_ChairName
        '
        Me.Txt_ChairName.BackColor = System.Drawing.SystemColors.Control
        Me.Txt_ChairName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ChairName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ChairName.Location = New System.Drawing.Point(103, 96)
        Me.Txt_ChairName.Name = "Txt_ChairName"
        Me.Txt_ChairName.Size = New System.Drawing.Size(337, 22)
        Me.Txt_ChairName.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Silver
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(446, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 50
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(429, 218)
        Me.DataGridView1.TabIndex = 80
        '
        'lbl_ChairID
        '
        Me.lbl_ChairID.AutoSize = True
        Me.lbl_ChairID.Location = New System.Drawing.Point(173, 49)
        Me.lbl_ChairID.Name = "lbl_ChairID"
        Me.lbl_ChairID.Size = New System.Drawing.Size(39, 13)
        Me.lbl_ChairID.TabIndex = 69
        Me.lbl_ChairID.Text = "Label1"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 24)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Add Chair"
        '
        'lbl_Update
        '
        Me.lbl_Update.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Update.AutoSize = True
        Me.lbl_Update.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Update.Location = New System.Drawing.Point(11, 41)
        Me.lbl_Update.Name = "lbl_Update"
        Me.lbl_Update.Size = New System.Drawing.Size(132, 24)
        Me.lbl_Update.TabIndex = 68
        Me.lbl_Update.Text = "Update Chair"
        '
        'Exit_btn
        '
        Me.Exit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Exit_btn.FlatAppearance.BorderSize = 0
        Me.Exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Exit_btn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_btn.Location = New System.Drawing.Point(352, 172)
        Me.Exit_btn.Name = "Exit_btn"
        Me.Exit_btn.Size = New System.Drawing.Size(81, 27)
        Me.Exit_btn.TabIndex = 66
        Me.Exit_btn.Text = "Exit"
        Me.Exit_btn.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(6, 172)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(81, 27)
        Me.Button7.TabIndex = 65
        Me.Button7.Text = "Add Chair"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.SystemColors.Control
        Me.Panel10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel10.Location = New System.Drawing.Point(281, 49)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(13, 10)
        Me.Panel10.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Chair Name"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 16)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Chair Type"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.Control
        Me.Panel11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel11.Location = New System.Drawing.Point(265, 46)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(10, 13)
        Me.Panel11.TabIndex = 63
        '
        'Edit_btn
        '
        Me.Edit_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Edit_btn.FlatAppearance.BorderSize = 0
        Me.Edit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Edit_btn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Edit_btn.Location = New System.Drawing.Point(93, 172)
        Me.Edit_btn.Name = "Edit_btn"
        Me.Edit_btn.Size = New System.Drawing.Size(81, 27)
        Me.Edit_btn.TabIndex = 70
        Me.Edit_btn.Text = "Edit"
        Me.Edit_btn.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Button12.ForeColor = System.Drawing.Color.Black
        Me.Button12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button12.Location = New System.Drawing.Point(176, 172)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(81, 27)
        Me.Button12.TabIndex = 79
        Me.Button12.Text = "Delete"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Chair_Add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(886, 450)
        Me.Controls.Add(Me.Panel_AddChair)
        Me.Name = "Chair_Add"
        Me.Text = "Chair_Add"
        Me.Panel_AddChair.ResumeLayout(False)
        Me.Panel_AddChair.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel_AddChair As Panel
    Friend WithEvents lbl_ChairID As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbl_Update As Label
    Friend WithEvents Exit_btn As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Txt_ChairType As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Txt_ChairName As TextBox
    Friend WithEvents Edit_btn As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
End Class
