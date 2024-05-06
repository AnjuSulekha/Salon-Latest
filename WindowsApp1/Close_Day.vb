Imports System.Drawing.Drawing2D

Public Class Close_Day
    Private Sub Close_Day_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lbl_Date.Text = Date.Today.ToString("dd-MM-yyyy")
        Lbl_Count.Visible = False
        Lbl_Amount.Visible = False
        Lbl_Cash.Visible = False
        Lbl_Card.Visible = False
        lblExpense.Visible = False
        DataGridView1.Columns.Add("column1", "No")
        DataGridView1.Columns.Add("column2", "Bill Count")
        DataGridView1.Columns.Add("column3", "Staff")
        DataGridView1.Columns.Add("column4", "Bill Amount")
        DataGridView1.GridColor = Color.White ' Set the color of the grid lines to match the background color
        DataGridView1.BorderStyle = BorderStyle.None ' Remove the border style
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None ' Remove the cell border style
        DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None ' Remove the row headers border style
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None ' Remove the column headers border style
        ' Assuming dataGridView1 is the name of your DataGridView control
        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        SetRoundedButton(Btn_Close, 5)
        Btn_Close.BackColor = Color.DodgerBlue
        Btn_Close.ForeColor = Color.White
    End Sub
    Private Function RoundedRectangle(ByVal rectangle As Rectangle, ByVal cornerRadius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = cornerRadius * 2
        Dim arcRectangle As New Rectangle(rectangle.Location, New Size(diameter, diameter))

        ' Top left corner
        path.AddArc(arcRectangle, 180, 100)

        ' Top side (excluding corners)
        path.AddLine(rectangle.Left + cornerRadius, rectangle.Top, rectangle.Right - cornerRadius, rectangle.Top)

        ' Top right corner
        arcRectangle.X = rectangle.Right - diameter
        path.AddArc(arcRectangle, 270, 10)

        ' Right side (excluding top and bottom corners)
        path.AddLine(rectangle.Right, rectangle.Top + cornerRadius, rectangle.Right, rectangle.Bottom - cornerRadius)

        ' Bottom right corner
        arcRectangle.Y = rectangle.Bottom - diameter
        path.AddArc(arcRectangle, 0, 90)

        ' Bottom side (excluding corners)
        path.AddLine(rectangle.Right - cornerRadius, rectangle.Bottom, rectangle.Left + cornerRadius, rectangle.Bottom)

        ' Bottom left corner
        arcRectangle.X = rectangle.Left
        path.AddArc(arcRectangle, 90, 90)

        ' Left side (excluding top and bottom corners)
        path.AddLine(rectangle.Left, rectangle.Bottom - cornerRadius, rectangle.Left, rectangle.Top + cornerRadius)

        path.CloseFigure()
        Return path
    End Function
    Private Sub SetRoundedButton(ByVal button As Button, ByVal cornerRadius As Integer)
        button.FlatAppearance.BorderSize = 0
        Dim region As New Region(RoundedRectangle(New Rectangle(0, 0, button.Width, button.Height), cornerRadius))
        button.Region = region

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class