<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Working
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
        Me.Panel__Chair = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chair__ID = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.Stop_Time = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel__Chair
        '
        Me.Panel__Chair.Location = New System.Drawing.Point(18, 42)
        Me.Panel__Chair.Name = "Panel__Chair"
        Me.Panel__Chair.Size = New System.Drawing.Size(739, 330)
        Me.Panel__Chair.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "In Woking"
        '
        'Chair__ID
        '
        Me.Chair__ID.AutoSize = True
        Me.Chair__ID.Location = New System.Drawing.Point(707, 23)
        Me.Chair__ID.Name = "Chair__ID"
        Me.Chair__ID.Size = New System.Drawing.Size(39, 13)
        Me.Chair__ID.TabIndex = 3
        Me.Chair__ID.Text = "Label2"
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(663, 23)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Status.TabIndex = 4
        Me.lbl_Status.Text = "Label2"
        '
        'Stop_Time
        '
        Me.Stop_Time.AutoSize = True
        Me.Stop_Time.Location = New System.Drawing.Point(613, 23)
        Me.Stop_Time.Name = "Stop_Time"
        Me.Stop_Time.Size = New System.Drawing.Size(39, 13)
        Me.Stop_Time.TabIndex = 5
        Me.Stop_Time.Text = "Label2"
        '
        'Working
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.Stop_Time)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.Chair__ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel__Chair)
        Me.Name = "Working"
        Me.Text = "Working"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel__Chair As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Chair__ID As Label
    Friend WithEvents lbl_Status As Label
    Friend WithEvents Stop_Time As Label
End Class
