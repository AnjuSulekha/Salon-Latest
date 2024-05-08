Imports System.Data.OleDb
Imports System.IO

Public Class Master_Add
    Public Property StaffID As String
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim dr As OleDbDataReader
    Dim destinationFilePath As String
    Dim DT As New DataTable
    Private Sub Master_Add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_Reg.BackColor = Color.DodgerBlue
        Btn_Reg.ForeColor = Color.White
        Btn_Exit.BackColor = Color.DodgerBlue
        Btn_Exit.ForeColor = Color.White
        Btn_Edit.BackColor = Color.DodgerBlue
        Btn_Edit.ForeColor = Color.White
        Button11.BackColor = Color.DodgerBlue

        Button11.ForeColor = Color.White

        Button1.BackColor = Color.DodgerBlue
        Button1.ForeColor = Color.White
        lbl_staff.Visible = False
        Btn_Edit.Visible = True
        Button11.Visible = True
        DataGridAddView("")
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Panel3.Visible = False

    End Sub
    Private Sub DataGridAddView(SearchString As String)
        Try
            con.ConnectionString = ConString
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = con.CreateCommand
            cmd.CommandText = "SELECT Img,StaffName,Mobile,StaffID FROM StaffMaster"
            If Trim(SearchString) <> "" Then
                cmd.CommandText &= " WHERE StaffID LIKE '%" & SearchString & "%'"
            End If
            Dim dr As OleDbDataReader = cmd.ExecuteReader

            ' Create a DataTable
            Dim DT As New DataTable
            DT.Columns.Add("Image", GetType(Image)) ' Add a column for the image
            DT.Columns.Add("StaffName")
            DT.Columns.Add("Mobile") '
            DT.Columns.Add("StaffID")
            ' DT.Columns.Add("Edit", GetType(Image))
            'Read Data And Load images
            While dr.Read()
                Dim imagePath As String = dr("Img").ToString()
                If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                    ' Load image only if the file path is not empty and the file exists
                    Dim img As Image = Image.FromFile(imagePath)
                    DT.Rows.Add(img, dr("StaffName"), dr("Mobile"), dr("StaffID"))
                Else
                    ' Handle invalid or missing file path
                    DT.Rows.Add(Nothing, dr("StaffName"), dr("Mobile"), dr("StaffID"))
                End If
            End While
            dr.Close()
            DataGridView2.DataSource = DT
            DataGridView2.Columns("StaffID").Visible = False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Public Sub RefreshStaffData()
        ' Clear the DataGridView
        DataGridView2.DataSource = Nothing

        ' Re-fetch the data from the database and update the DataGridView
        DataGridAddView("")
    End Sub
    'Private Sub Master_Add_Resize(sender As Object, e As EventArgs) Handles Me.Resize
    '    Dim maxTextBoxPanelWidth As Integer = 700
    '    Dim minpanelwidth As Integer = 337
    '    If Me.WindowState = FormWindowState.Maximized Then
    '        Panel3.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Panel4.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Panel5.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Panel6.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Panel7.Width = Math.Min(maxTextBoxPanelWidth, Me.Width)
    '        Txt_StaffName.Width = Panel3.Width - (2 * Txt_StaffName.Left)
    '        Txt_Addrs.Width = Panel4.Width - (2 * Txt_Addrs.Left)
    '        Txt_Email.Width = Panel5.Width - (2 * Txt_Email.Left)
    '        Txt_Mobile.Width = Panel6.Width - (2 * Txt_Mobile.Left)
    '        Txt_Salary.Width = Panel7.Width - (2 * Txt_Salary.Left)
    '        Txt_Addrs2.Width = Panel7.Width - (2 * Txt_Salary.Left)
    '        Txt_Addrs3.Width = Panel7.Width - (2 * Txt_Salary.Left)

    '    Else
    '        Panel3.Width = Math.Min(minpanelwidth, Me.Width)
    '        Panel4.Width = Math.Min(minpanelwidth, Me.Width)
    '        Panel5.Width = Math.Min(minpanelwidth, Me.Width)
    '        Panel6.Width = Math.Min(minpanelwidth, Me.Width)
    '        Panel7.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_StaffName.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Addrs.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Email.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Mobile.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Salary.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Addrs2.Width = Math.Min(minpanelwidth, Me.Width)
    '        Txt_Addrs3.Width = Math.Min(minpanelwidth, Me.Width)
    '    End If
    'End Sub

    Private Sub Btn_Reg_Click(sender As Object, e As EventArgs) Handles Btn_Reg.Click
        Try
            Dim location As String = Path.Combine(Application.StartupPath, "Image")
            If Not Directory.Exists(location) Then
                Directory.CreateDirectory(location)
            End If

            If PictureBox1.Image Is Nothing Then
                MsgBox("Profile Image Required.")
                Return
            ElseIf String.IsNullOrWhiteSpace(Txt_StaffName.Text) Then
                MsgBox("Staff Name is a required field.")
                Txt_StaffName.Focus()
                Return
            ElseIf String.IsNullOrWhiteSpace(Txt_Mobile.Text) Then
                MsgBox("Mobile Number is a required field.")
                Txt_Mobile.Focus()
                Return
            ElseIf Not ValidateEmailAddress(Txt_Email.Text) Then
                MsgBox("Invalid Email Format.")
                Txt_Email.Focus()
                Return
            ElseIf Not ValidateMobileNumber(Txt_Mobile.Text) Then
                MsgBox("Invalid Mobile Number Format.")
                Txt_Mobile.Focus()
                Return

            End If
            con.ConnectionString = ConString
            'con.Open()'
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.CommandText = "SELECT * FROM StaffMaster WHERE Mobile='" & Me.Txt_Mobile.Text & "'"
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                con.Close()
                MsgBox("Duplicate Data: Staff with the same mobile number already exist.")
            Else
                con.Close()

                '' Proceed with insertion
                'con.ConnectionString = ConString
                'cmd = con.CreateCommand


                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If

                Dim fileName As String = ".jpg"
                filePath = Path.Combine(location, Txt_StaffName.Text & fileName)

                If PictureBox1.Image IsNot Nothing Then
                    PictureBox1.Image.Save(filePath)
                End If

                cmd.CommandText = "INSERT INTO StaffMaster (StaffName, Address, Email, Mobile, Salary, DOB, DOJ, Img,Address1,Address2) VALUES ('" & Me.Txt_StaffName.Text & "','" & Me.Txt_Addrs.Text & "','" & Me.Txt_Email.Text & "','" & Me.Txt_Mobile.Text & "'," & Val(Me.Txt_Salary.Text) & ",#" & Format(Me.DT_DOJ.Value, "dd-MM-yyyy") & "#,#" & Format(Me.DT_DOB.Value, "dd-MM-yyyy") & "#,'" & filePath & "','" & Me.Txt_Addrs2.Text & "','" & Me.Txt_Addrs3.Text & "')"

                cmd.ExecuteNonQuery()

                MsgBox("New Staff " + UCase(Me.Txt_StaffName.Text) + " Added")
                CLEAR()
                con.Close()
                RefreshStaffData()

            End If
            ' Me.Hide()
        Catch ex As Exception
            MsgBox("Database error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Dim filePath As String
    Private Function ValidateEmailAddress(ByVal emailAddress As String) As Boolean
        ' Define a regular expression pattern for validating email addresses
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"

        ' Check if the email address matches the pattern
        Return System.Text.RegularExpressions.Regex.IsMatch(emailAddress, pattern)
    End Function
    Private Function ValidateMobileNumber(ByVal mobileNumber As String) As Boolean
        ' Define a regular expression pattern for validating mobile numbers
        Dim pattern As String = "^\d{10}$" ' This pattern validates a 10-digit number

        ' Check if the mobile number matches the pattern
        Return System.Text.RegularExpressions.Regex.IsMatch(mobileNumber, pattern)
    End Function
    Private Sub CLEAR()
        Txt_StaffName.Text = ""
        Txt_Addrs.Text = ""
        Txt_Email.Text = ""
        Txt_Mobile.Text = ""
        Txt_Salary.Text = ""
        DT_DOJ.Value = Date.Today
        DT_DOB.Value = Date.Today
        PictureBox1.Image = Nothing

    End Sub
    Private Sub Tabmovement(ByVal Keycode As Integer)
        If Keycode = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub Txt_StaffName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_StaffName.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub Txt_Addrs_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Addrs.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub Txt_Email_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Email.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub Txt_Mobile_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Mobile.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub Txt_Salary_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Salary.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub DT_DOJ_KeyDown(sender As Object, e As KeyEventArgs) Handles DT_DOJ.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
    Private Sub DT_DOB_KeyDown(sender As Object, e As KeyEventArgs) Handles DT_DOB.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Do you want to Edit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' Check the user's response
            If result = DialogResult.Yes Then
                con.ConnectionString = ConString
                cmd = con.CreateCommand
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.CommandText = "update StaffMaster set StaffName='" & Txt_StaffName.Text & "',Address	='" & Txt_Addrs.Text & "',Mobile	='" & Txt_Mobile.Text & "',Email='" & Txt_Email.Text & "',Salary='" & Txt_Salary.Text & "'  where StaffID	=" & lbl_staff.Text & ""
                cmd.ExecuteNonQuery()
                MsgBox("Staff details updated successfully")
                CLEAR()
                con.Close()
                RefreshStaffData()
                'Me.Hide()
            End If
            'Panel9.Visible = True
            'Panel9.BringToFront()
            'Panel9.Show()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Do you want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' Check the user's response
            If result = DialogResult.Yes Then
                ' Establish connection
                con.ConnectionString = ConString
                cmd = con.CreateCommand

                ' Check if connection is closed, then open it
                If con.State = ConnectionState.Closed Then con.Open()

                ' Prepare SQL command for deletion
                cmd.CommandText = "DELETE FROM StaffMaster WHERE StaffID = @StaffID"

                ' Add parameters to the command (to prevent SQL injection)
                cmd.Parameters.AddWithValue("@StaffID", lbl_staff.Text)

                ' Execute the deletion command
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                ' Check if any rows were affected
                If rowsAffected > 0 Then
                    MsgBox("Data deleted successfully")
                    ' Clear input fields after deletion
                    CLEAR()

                Else
                    MsgBox("No data deleted. StaffID not found.")
                End If
            End If

            con.Close()
            'Panel9.Visible = True
            'Panel9.BringToFront()
            'Panel9.Show()
            'Me.Hide()
            RefreshStaffData()
        Catch ex As Exception
            ' Handle exceptions, if any
            MsgBox("An error occurred: " & ex.Message)
        Finally
            ' Close connection
            con.Close()
        End Try
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        CLEAR()
        Me.Hide()
    End Sub
    Private previewPictureBox As PictureBox
    Dim open As New OpenFileDialog()
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Check if PictureBox1 contains an image
        If PictureBox1.Image IsNot Nothing Then
            ' Toggle visibility of the preview PictureBox
            If previewPictureBox Is Nothing Then
                ' Create the preview PictureBox if it doesn't exist
                previewPictureBox = New PictureBox()
                previewPictureBox.Size = New Size(200, 150)
                previewPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
                previewPictureBox.Location = New Point((Me.ClientSize.Width - previewPictureBox.Width) \ 2, (Me.ClientSize.Height - previewPictureBox.Height) \ 2)
                previewPictureBox.Image = PictureBox1.Image
                ' Add click event handler to close the preview
                AddHandler previewPictureBox.Click, AddressOf ClosePreview
                Me.Controls.Add(previewPictureBox) ' Add the preview PictureBox to the main form
                previewPictureBox.BringToFront() ' Ensure the preview PictureBox is in front of other controls
            End If
            ' Toggle visibility of the preview PictureBox
            previewPictureBox.Visible = Not previewPictureBox.Visible
        Else

            Dim p As PictureBox = TryCast(sender, PictureBox)
            If p IsNot Nothing Then
                open.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG"
                If open.ShowDialog() = DialogResult.OK Then
                    p.Image = Image.FromFile(open.FileName)
                    PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End If
        End If
    End Sub
    Private Sub ClosePreview(sender As Object, e As EventArgs)
        ' Close the preview PictureBox
        previewPictureBox.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ' Check if PictureBox2 contains an image
            If PictureBox1.Image IsNot Nothing Then
                ' Ask the user if they want to delete the image
                Dim result As DialogResult = MessageBox.Show("Do you want to delete the image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                ' If user confirms deletion
                If result = DialogResult.Yes Then
                    ' Proceed with image deletion
                    con.ConnectionString = ConString
                    cmd = con.CreateCommand

                    If con.State = ConnectionState.Closed Then con.Open()

                    cmd.CommandText = "UPDATE StaffMaster SET Img = NULL WHERE StaffID = @StaffID"
                    cmd.Parameters.AddWithValue("@StaffID", lbl_staff.Text)
                    cmd.ExecuteNonQuery()

                    MsgBox("Image deleted successfully")
                    PictureBox1.Image = Nothing
                End If
            Else
                MsgBox("There is no image to delete.", MessageBoxIcon.Information)
            End If
            Master_Form.RefreshStaffData()
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim location As String = Path.Combine(Application.StartupPath, "Image")
            ' Check if a new image is selected
            If open.ShowDialog() = DialogResult.OK Then
                Dim newImagePath As String = open.FileName

                ' Update the image path in the database
                con.ConnectionString = ConString
                cmd = con.CreateCommand
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.CommandText = "UPDATE StaffMaster SET Img = @Img WHERE StaffID = @StaffID"
                cmd.Parameters.AddWithValue("@Img", newImagePath)
                cmd.Parameters.AddWithValue("@StaffID", lbl_staff.Text)
                cmd.ExecuteNonQuery()

                ' Change the image in the PictureBox
                Dim newImage As Image = Image.FromFile(newImagePath)
                PictureBox1.Image = newImage
                ' Update the image in the preview PictureBox
                If previewPictureBox IsNot Nothing Then
                    previewPictureBox.Image = newImage
                End If

                MsgBox("Image updated successfully")
                Master_Form.RefreshStaffData()
            End If
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub LoadFormData(staffId As Integer)
        Try
            ' If lbl_staff.Text <> "" Then
            con.ConnectionString = ConString
            cmd = con.CreateCommand
            If con.State = ConnectionState.Closed Then con.Open()
            ' If lbl_staff.Text <> "" Then
            'cmd.CommandText = "select * from StaffMaster where StaffID=" & Val(Me.lbl_staff.Text) & ""

            cmd.CommandText = "SELECT * FROM StaffMaster WHERE StaffID = @StaffID"
            cmd.Parameters.AddWithValue("@StaffID", staffId)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                Me.Txt_StaffName.Text = dr("StaffName").ToString()
                Me.Txt_Addrs.Text = dr("Address").ToString()
                Me.Txt_Email.Text = dr("Email").ToString()
                Me.Txt_Mobile.Text = dr("Mobile").ToString()
                Me.Txt_Salary.Text = dr("Salary").ToString()
                'Me.DT_DOJ.Value = dr("DOJ").ToString()
                'Me.DT_DOB.Value = dr("DOB").ToString()
                If Not IsDBNull(dr("DOJ")) Then
                    Me.DT_DOJ.Value = Convert.ToDateTime(dr("DOJ"))
                Else
                    Me.DT_DOJ.Value = DateTime.Today
                End If

                If Not IsDBNull(dr("DOB")) Then
                    Me.DT_DOB.Value = Convert.ToDateTime(dr("DOB"))
                Else
                    Me.DT_DOB.Value = DateTime.Today
                End If
                'Me.DT_DOJ.Value = If(IsDBNull(dr("DOJ")), DateTime.MinValue, Convert.ToDateTime(dr("DOJ")))
                'Me.DT_DOB.Value = If(IsDBNull(dr("DOB")), DateTime.MinValue, Convert.ToDateTime(dr("DOB")))
                Dim imagePath As String = dr("Img").ToString()
                If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                    ' Load image only if the file path is not empty and the file exists
                    Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                    Me.PictureBox1.Image = Image.FromFile(imagePath)
                End If
                dr.Close()
            End If
            ' Else
            ' MsgBox("hi")
            ' End If
            ' End If
        Catch ex As Exception
            MsgBox("ERROR:" & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Master_Add_RegionChanged(sender As Object, e As EventArgs) Handles Me.RegionChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        'If DataGridView2.SelectedRows.Count > 0 Then
        '    LoadFormData()

        'End If
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim staffId As Integer = Convert.ToInt32(DataGridView2.Rows(e.RowIndex).Cells("StaffID").Value)
            lbl_staff.Text = staffId
            LoadFormData(staffId)
        End If
    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CLEAR()
    End Sub

    Private Sub Txt_Addrs2_TextChanged(sender As Object, e As EventArgs) Handles Txt_Addrs2.TextChanged

    End Sub

    Private Sub Txt_Addrs2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Addrs2.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub

    Private Sub Txt_Addrs3_TextChanged(sender As Object, e As EventArgs) Handles Txt_Addrs3.TextChanged

    End Sub

    Private Sub Txt_Addrs3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Addrs3.KeyDown
        Call Tabmovement(e.KeyCode)
    End Sub
End Class