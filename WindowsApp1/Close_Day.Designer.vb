<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Close_Day
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
        Me.SuspendLayout()
        '
        'Close_Day
        '
        Me.ClientSize = New System.Drawing.Size(687, 423)
        Me.Name = "Close_Day"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_Date As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Lbl_Count As Label
    Friend WithEvents Lbl_Amount As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Lbl_Cash As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Lbl_Card As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblExpense As Label
    Friend WithEvents Lbl_Expense As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Btn_Close As Button
End Class
