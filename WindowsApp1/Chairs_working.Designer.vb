<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Chairs_working
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel__Chair = New System.Windows.Forms.Panel()
        Me.Chair_ID = New System.Windows.Forms.Label()
        Me.Chair__ID = New System.Windows.Forms.Label()
        Me.Status = New System.Windows.Forms.Label()
        Me.Staff_ID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "All"
        '
        'Panel__Chair
        '
        Me.Panel__Chair.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel__Chair.Location = New System.Drawing.Point(18, 42)
        Me.Panel__Chair.Name = "Panel__Chair"
        Me.Panel__Chair.Size = New System.Drawing.Size(739, 330)
        Me.Panel__Chair.TabIndex = 0
        '
        'Chair_ID
        '
        Me.Chair_ID.AutoSize = True
        Me.Chair_ID.Location = New System.Drawing.Point(677, 13)
        Me.Chair_ID.Name = "Chair_ID"
        Me.Chair_ID.Size = New System.Drawing.Size(39, 13)
        Me.Chair_ID.TabIndex = 2
        Me.Chair_ID.Text = "Label2"
        '
        'Chair__ID
        '
        Me.Chair__ID.AutoSize = True
        Me.Chair__ID.Location = New System.Drawing.Point(606, 17)
        Me.Chair__ID.Name = "Chair__ID"
        Me.Chair__ID.Size = New System.Drawing.Size(39, 13)
        Me.Chair__ID.TabIndex = 3
        Me.Chair__ID.Text = "Label2"
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.Location = New System.Drawing.Point(462, 17)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(39, 13)
        Me.Status.TabIndex = 4
        Me.Status.Text = "Label2"
        '
        'Staff_ID
        '
        Me.Staff_ID.AutoSize = True
        Me.Staff_ID.Location = New System.Drawing.Point(525, 17)
        Me.Staff_ID.Name = "Staff_ID"
        Me.Staff_ID.Size = New System.Drawing.Size(39, 13)
        Me.Staff_ID.TabIndex = 5
        Me.Staff_ID.Text = "Label2"
        '
        'Chairs_working
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.Staff_ID)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Chair__ID)
        Me.Controls.Add(Me.Chair_ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel__Chair)
        Me.Name = "Chairs_working"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chairs_working"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel__Chair As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Chair_ID As Label
    Friend WithEvents Chair__ID As Label
    Friend WithEvents Status As Label
    Friend WithEvents Staff_ID As Label
End Class
