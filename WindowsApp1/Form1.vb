Imports System.Data.OleDb

Public Class Form1
    Dim DT As New DataTable
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim IsCreated(99) As Boolean
    Dim ButtonWidh As Integer
    Dim ButtonHeight As Integer
    Dim ButtonPadding As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Front_Form.Width = Me.Width - (FlowLayoutPanel1.Width + 20)
        Front_Form.Height = Me.Height - 50
        Front_Form.MdiParent = Me
        Front_Form.Show()
        MenuContainer.Height = 28
        Try
            DT.Clear()
            ' Fetch data from the Access database and populate the DataTable
            FetchDataFromDatabase()

            ButtonWidh = 100
            ButtonHeight = 60
            ButtonPadding = 5
            'FunlistChairs()
            'DataGridAdd("")

        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Private Sub FetchDataFromDatabase()
        Try
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()

            cmd.CommandText = "SELECT ChairName, ChairType, StaffName FROM  Chair"


            Using reader As OleDbDataReader = cmd.ExecuteReader()
                ' Check if the reader has rows
                If reader.HasRows Then
                    ' If DataTable columns are not yet added, add them dynamically based on the query
                    If DT.Columns.Count = 0 Then
                        For i As Integer = 0 To reader.FieldCount - 1
                            DT.Columns.Add(reader.GetName(i))
                        Next
                    End If

                    ' Loop through each row in the result set
                    While reader.Read()
                        ' Add a new row to the DataTable and populate it with data from the database
                        Dim newRow As DataRow = DT.NewRow()
                        For i As Integer = 0 To reader.FieldCount - 1
                            newRow(i) = reader(i)
                        Next
                        DT.Rows.Add(newRow)
                    End While
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            con.Close()
        End Try
    End Sub
    '    Public Sub FunlistChairs()
    '        Dim maxIndex As Integer = 0
    '        For Each ctrl As Control In Panel_Chairs.Controls
    '            If TypeOf ctrl Is Button Then
    '                Dim index As Integer
    '                If Integer.TryParse(ctrl.Name.Replace("Button", ""), index) Then
    '                    If index > maxIndex Then
    '                        maxIndex = index
    '                    End If
    '                End If
    '            End If
    '        Next
    '        For i As Integer = 0 To DT.Rows.Count - 1
    '            Dim B As New Button
    '            Dim L As New Label
    '            Dim L1 As New Label
    '            'B.Anchor = AnchorStyles.Right And AnchorStyles.Top And AnchorStyles.Left And AnchorStyles.Bottom

    '            Panel_Chairs.Controls.Add(B)
    '            Panel_Chairs.Controls.Add(L)
    '            Panel_Chairs.Controls.Add(L1)
    '            B.Height = ButtonHeight
    '            B.Width = ButtonWidh
    '            B.Left = (i Mod 4) * (ButtonWidh + ButtonPadding)
    '            B.Top = (i \ 4) * (ButtonHeight + ButtonPadding)
    '            B.Text = DT.Rows(i).Item("ChairName").ToString
    '            L.Width = B.Width
    '            L.Height = 15
    '            L.Left = B.Left + 5
    '            L.Top = B.Top + 5
    '            L.Text = ""
    '            L.Font = New Font("Arial", 8, FontStyle.Bold)
    '            L.AutoSize = True
    '            L.TextAlign = ContentAlignment.MiddleCenter
    '            L.BackColor = Color.Blue
    '            L.ForeColor = Color.White
    '            L.BringToFront()
    '            L1.AutoSize = True ' 120
    '            L1.Height = 15
    '            L1.Left = B.Left
    '            L1.Top = (B.Top + (B.Height - L1.Height)) - 5
    '            L1.Text = DT.Rows(i).Item("StaffName").ToString
    '            L1.Font = New Font("Arial", 8, FontStyle.Bold)
    '            L1.AutoSize = True
    '            L1.TextAlign = ContentAlignment.MiddleCenter
    '            L1.BackColor = Color.Red
    '            L1.ForeColor = Color.White
    '            L1.BringToFront()
    '            Dim chairImage As Image = My.Resources.NewChair ' Replace "ChairImage" with the name of your image resource
    '            B.Image = chairImage
    '            B.ImageAlign = ContentAlignment.TopCenter
    '            B.TextImageRelation = TextImageRelation.ImageAboveText
    '            'If DT.Rows(i).Item("Status") = 1 Then
    '            '    B.BackColor = Color.GreenYellow
    '            '    L.Text = "Active"
    '            'ElseIf DT.Rows(i).Item("Status") = 2 Then
    '            '    B.BackColor = Color.Orange
    '            '    L.Text = "Working"
    '            'Else
    '            '    L.Text = ""
    '            'End If
    '            AddHandler B.Click, AddressOf Button_Click
    '            ' Add button to the panel
    '            Panel_Chairs.Controls.Add(B)

    '            ' Increment maxIndex
    '            maxIndex += 1
    '        Next
    '    End Sub
    '    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim B As Button = sender
    '        IsCreated(B.Tag) = True
    '        ' B.BackColor = Color.Red
    '        Dim TakeEntryNo As String
    '        TakeEntryNo = Val(B.Text)
    '        'If B.BackColor = Color.LightSkyBlue Then
    '        'Else
    '        'End If
    'endpart:
    '    End Sub
    '    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    '        ' Calculate the maximum width for each panel
    '        Dim maxPanelWidth As Integer = (Me.ClientSize.Width - 55 * 4) / 4 ' Initial calculation for non-maximized state

    '        ' Check if the window is maximized
    '        If Me.WindowState = FormWindowState.Maximized Then
    '            ' Calculate new maxPanelWidth for maximized state
    '            maxPanelWidth = (Me.ClientSize.Width - 55 * 4) / 4 ' Adjust as needed for margins or spacing
    '        End If
    '        ' Set the size for each panel
    '        ' Assuming the height of all panels is 100
    '        Dim panelHeight As Integer = 100
    '        Panel_Total.Size = New Size(maxPanelWidth, panelHeight)
    '        Panel_Expense.Size = New Size(maxPanelWidth, panelHeight)
    '        Panel_Cash.Size = New Size(maxPanelWidth, panelHeight)
    '        Panel_Card.Size = New Size(maxPanelWidth, panelHeight)
    '        ' Set the location for each panel
    '        Dim panelSpacing As Integer = 5 ' Adjust as needed
    '        Panel_Total.Location = New Point((maxPanelWidth + panelSpacing) * 0, Panel_Total.Location.Y)
    '        Panel_Expense.Location = New Point((maxPanelWidth + panelSpacing) * 1, Panel_Expense.Location.Y)
    '        Panel_Cash.Location = New Point((maxPanelWidth + panelSpacing) * 2, Panel_Cash.Location.Y)
    '        Panel_Card.Location = New Point((maxPanelWidth + panelSpacing) * 3, Panel_Card.Location.Y)
    '    End Sub
    '    Private Sub DataGridAdd(SearchString As String)
    '        Try
    '            con.ConnectionString = ConString

    '            If con.State = ConnectionState.Closed Then con.Open()
    '            cmd = con.CreateCommand
    '            cmd.CommandText = "Select StaffName FROM StaffMaster"
    '            If Trim(SearchString) <> "" Then
    '                cmd.CommandText &= " WHERE StaffID Like '%" & SearchString & "%'"
    '            End If
    '            Dim dr As OleDbDataReader = cmd.ExecuteReader

    '            ' Create a DataTable
    '            Dim DT As New DataTable
    '            DT.Columns.Add("No.")
    '            DT.Columns.Add("StaffName")
    '            DT.Columns.Add("Amount")
    '            Dim No As Integer = 1 ' Initialize serial number

    '            While dr.Read()
    '                ' Add rows to the DataTable with Sl No
    '                DT.Rows.Add(No, dr("StaffName"))
    '                No += 1 ' Increment serial number for the next row
    '            End While
    '            dr.Close()
    '            DataGridView2.DataSource = DT
    '            DataGridView2.Columns("No.").Width = 50
    '        Catch ex As Exception
    '            MessageBox.Show("Error: " & ex.Message)
    '        Finally
    '            If con.State = ConnectionState.Open Then
    '                con.Close()
    '            End If
    '        End Try
    '    End Sub

    Dim menuexpand As Boolean = False

    Private Sub MenuTransition_Tick(sender As Object, e As EventArgs) Handles MenuTransition.Tick
        If menuexpand = False Then
            MenuContainer.Height += 10
            If MenuContainer.Height >= 114 Then
                MenuTransition.Stop()
                Btn_Explore.Enabled = True
                menuexpand = True
            End If
        Else
            MenuContainer.Height -= 10
            If MenuContainer.Height <= 28 Then
                MenuTransition.Stop()

                menuexpand = False
            End If
        End If
    End Sub
    Private Sub menu_Click(sender As Object, e As EventArgs) Handles menu.Click
        MenuTransition.Start()
    End Sub
    Private Sub OtherTransition_Tick(sender As Object, e As EventArgs) Handles OtherTransition.Tick

    End Sub
    Private Sub Btn_Explore_Click(sender As Object, e As EventArgs) Handles Btn_Explore.Click
        Explore.Start()
    End Sub
    Dim Explore_Expand As Boolean = False
    Private Sub Explore_Tick(sender As Object, e As EventArgs) Handles Explore.Tick
        If Explore_Expand = False Then
            Panel_Explore.Height += 10
            If Panel_Explore.Height >= 141 Then
                Explore.Stop()
                Explore_Expand = True

            End If
        Else
            Panel_Explore.Height -= 10
            If Panel_Explore.Height <= 28 Then
                Explore.Stop()
                Explore_Expand = False
            End If

        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MoreTransition.Start()
    End Sub
    Dim morexpand As Boolean = False
    Private Sub MoreTransition_Tick(sender As Object, e As EventArgs) Handles MoreTransition.Tick
        If morexpand = False Then
            More.Height += 10
            If More.Height >= 195 Then
                MoreTransition.Stop()
                morexpand = True

            End If
        Else
            More.Height -= 10
            If More.Height <= 28 Then
                MoreTransition.Stop()
                morexpand = False
            End If

        End If

    End Sub

    Private Sub Btn_Satff_Click(sender As Object, e As EventArgs) Handles Btn_Satff.Click
        Master_Form.MdiParent = Me
        Master_Form.Show()
        Master_Form.BringToFront()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Front_Form.Visible = True Then
            Front_Form.Width = Me.Width - (FlowLayoutPanel1.Width + 20)
            Front_Form.Height = Me.Height - 50
        End If
    End Sub

    Private Sub Btn_Chairs_Click(sender As Object, e As EventArgs) Handles Btn_Chairs.Click
        Chair_Main.MdiParent = Me
        Chair_Main.Show()
        Chair_Main.BringToFront()
    End Sub

    Private Sub Btn_Products_Click(sender As Object, e As EventArgs) Handles Btn_Products.Click
        Product_Main.MdiParent = Me
        Product_Main.Show()
        Product_Main.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check if the user clicked Yes
        If result = DialogResult.Yes Then
            ' Close the current form (Main_Form)



        End If

    End Sub

    Private Sub Btn_All_Click(sender As Object, e As EventArgs) Handles Btn_All.Click
        Chairs_working.MdiParent = Me
        Chairs_working.Show()
        Chairs_working.BringToFront()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Working.MdiParent = Me
        Working.Show()
        Working.BringToFront()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Active.MdiParent = Me
        Active.Show()
        Active.BringToFront()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Inactive.MdiParent = Me
        Inactive.Show()
        Inactive.BringToFront()
    End Sub

    Private Sub Btn_Timesheet_Click(sender As Object, e As EventArgs) Handles Btn_Timesheet.Click
        TimeSheetReports.MdiParent = Me
        TimeSheetReports.Show()
        TimeSheetReports.BringToFront()

    End Sub
End Class
