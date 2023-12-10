Imports System.Data.OleDb
Imports System.Drawing.Printing
Public Class Form1
    Dim courseno As String
    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Dim con As New OleDbConnection
    Dim cid As String
    Dim sql As String
    Private Sub AddEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddEmployeeToolStripMenuItem.Click
        Me.Enabled = False
        Form2.Show()
    End Sub

    Private Sub AddCourseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddCourseToolStripMenuItem.Click
        Me.Enabled = False
        Form3.Show()
    End Sub
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Me.Enabled = False
        Form4.Show()
    End Sub
    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        Me.Enabled = False
        Form5.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Employee_detailsDataSet.Edu_quality' table. You can move, or remove it, as needed.
        Me.Edu_qualityTableAdapter.Fill(Me.Employee_detailsDataSet.Edu_quality)


        Timer1.Enabled = True
    End Sub
    Private Sub loaddata()
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        conn.Open()


        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As New OleDbDataAdapter

        da = New OleDbDataAdapter("select  t.Course_id, c.Course_name, c.Course_type, t.Time_period, t.Date from Edu_quality c , Employee_quality t where c.Course_id=t.course_id and NIC='" + txtnic.Text + "';", conn)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView
    End Sub
    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        print()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        conn.Open()
        Dim strsql As New OleDbCommand("DELETE FROM Employee_quality WHERE NIC='" & txtnic.Text & "' and course_id=" & cid & " ;", conn)

        MsgBox("Record Deleted!")

        Try
            strsql.ExecuteNonQuery()
            loaddata()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        conn.Open()


        command = "INSERT INTO Employee_quality VALUES ('" & cmbcname.SelectedIndex + 1 & "','" & txtnic.Text & "','" & txttime.Text & "','" & txtdate.Text & "');"
        Dim cmd As New OleDbCommand(command, conn)
        cmd.Parameters.Add(New OleDbParameter("Course_id", CType(cmbcname.SelectedIndex.ToString() + 1, String)))
        cmd.Parameters.Add(New OleDbParameter("NIC", CType(txtnic.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Time_period", CType(txttime.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Date", CType(txtdate.Text, String)))
        MsgBox("Record Saved")
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            loaddata()
            clear()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim conn As New OleDbConnection
        conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        conn.Open()


        Dim strsql As String
        strsql = "select V.Employee_name, B.Ac_office_name from Employee V , Ac_office B where V.Ac_office_id=B.Ac_office_id and NIC='" + txtnic.Text + "';"
        Dim cmd As New OleDbCommand(strsql, conn)
        Dim myreader As OleDbDataReader
        myreader = cmd.ExecuteReader
        myreader.Read()

        loaddata()

        lblename.Text = myreader("Employee_name")
        lblacoffice.Text = myreader("Ac_office_name")


        'Dim ds As New DataSet
        'Dim dt As New DataTable
        'ds.Tables.Add(dt)
        'Dim da As New OleDbDataAdapter

        'da = New OleDbDataAdapter("select c.Course_name, c.Course_type, t.Time_period, t.Date from Edu_quality c , Employee_quality t where c.Course_id=t.course_id and NIC='" + txtnic.Text + "';", conn)
        'da.Fill(dt)
        'DataGridView1.DataSource = dt.DefaultView

        conn.Close()
    End Sub
    Private Sub clear()
        txtdate.Clear()
        txtnic.Clear()
        txttime.Clear()
        cmbcname.SelectedIndex = 0
        lblename.Text = "Name"
        lblacoffice.Text = "Name"
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim selectedrow As DataGridViewRow
        selectedrow = DataGridView1.Rows(e.RowIndex)
        cid = selectedrow.Cells(0).Value
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim intResponse As Integer

        intResponse = MsgBox("Are you sure you want to quit?", vbYesNo + vbExclamation, "Quit")

        If intResponse = vbNo Then

            Me.Close()

        End If
    End Sub
    Private Sub print()
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        '' If PrintDialog1.ShowDialog() = 1 Then
        PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        Dim pagesetup As New PageSettings
        With pagesetup
            .Margins.Right = 50
            .Margins.Left = 50
            .Margins.Top = 50
            .Margins.Bottom = 50

        End With

        PrintDocument1.Print()

    End Sub
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Static intstart As Integer

        Dim fntText As Font = New Font("Times New Roman", 10)

        Dim txtHeight As Integer
        Dim primaryfont As Font = New Font("Algerian", 8)
        Dim primarynumbers As Font = New Font("Times New Roman", 12)
        Dim secfont As Font = New Font("Times New Roman", 10)
        Dim primaryregular As Font = New Font("Times New Roman", 12)
        Dim secondaryfont As Font = New Font("Times New Roman", 16)
        Dim thirdfont As Font = New Font("Times New Roman", 18, FontStyle.Bold)

        Dim topmargin = PrintDocument1.DefaultPageSettings.Margins.Top
        Dim leftmargin = PrintDocument1.DefaultPageSettings.Margins.Left
        Dim rightmargin = PrintDocument1.DefaultPageSettings.Margins.Right
        Dim bottommargin = PrintDocument1.DefaultPageSettings.Margins.Bottom

        txtHeight = PrintDocument1.DefaultPageSettings.PaperSize.Height - PrintDocument1.DefaultPageSettings.Margins.Top - PrintDocument1.DefaultPageSettings.Margins.Bottom - (e.PageBounds.Height - 1250)

        Dim LinesPerPage As Integer = CInt(Math.Round(txtHeight / (50)))
        Dim intLineNumber As Integer = 0

        e.Graphics.DrawString("Employee Details", secondaryfont, Brushes.Black, (Width / 2) - 280, topmargin - 20)

        e.Graphics.DrawString("NIC       : ", secfont, Brushes.Black, leftmargin, topmargin + 40)
        e.Graphics.DrawString(txtnic.Text, secfont, Brushes.Black, leftmargin + 130, topmargin + 40)
        e.Graphics.DrawString("Employee Name         : ", secfont, Brushes.Black, leftmargin, topmargin + 60)
        e.Graphics.DrawString(lblename.Text, secfont, Brushes.Black, leftmargin + 130, topmargin + 60)
        e.Graphics.DrawString("Ac Office Name         : ", secfont, Brushes.Black, leftmargin, topmargin + 80)
        e.Graphics.DrawString(lblacoffice.Text, secfont, Brushes.Black, leftmargin + 130, topmargin + 80)
        'e.Graphics.DrawString("ණයකරුගේ නම : ", secfont, Brushes.Black, leftmargin, topmargin + 100)
        'e.Graphics.DrawString(lblCreditorName.Text, secfont, Brushes.Black, leftmargin + 130, topmargin + 100)

        Dim x1 = topmargin + 120
        Dim x2 = topmargin + 190
        Dim x3 = topmargin + 160
        Dim y1 = leftmargin + 30
        Dim y2 = rightmargin + 30

        e.Graphics.DrawLine(Pens.Black, leftmargin, x1 + 1, e.PageBounds.Width - leftmargin, x1 + 2)

        'e.Graphics.DrawLine(Pens.Black, leftmargin, x1 + 2, e.PageBounds.Width - leftmargin, x1 + 2)
        e.Graphics.DrawLine(Pens.Black, leftmargin, x2 - 40, e.PageBounds.Width - leftmargin, x2 - 40)
        e.Graphics.DrawLine(Pens.Black, leftmargin, x1 + 2, leftmargin, x2 - 40)
        e.Graphics.DrawString("Course ID", secfont, Brushes.Black, leftmargin + 20, x1 + 7)
        e.Graphics.DrawLine(Pens.Black, leftmargin + 90, x1 + 2, leftmargin + 90, x2 - 40)
        e.Graphics.DrawString("Course Name", secfont, Brushes.Black, leftmargin + 100, x1 + 7)
        e.Graphics.DrawLine(Pens.Black, leftmargin + 270, x1 + 2, leftmargin + 270, x2 - 40)
        e.Graphics.DrawString("Course Type", secfont, Brushes.Black, leftmargin + 280, x1 + 7)
        e.Graphics.DrawLine(Pens.Black, leftmargin + 400, x1 + 2, leftmargin + 400, x2 - 40)
        e.Graphics.DrawString("Time Period", secfont, Brushes.Black, leftmargin + 430, x1 + 7)
        e.Graphics.DrawLine(Pens.Black, leftmargin + 540, x1 + 2, leftmargin + 540, x2 - 40)
        e.Graphics.DrawString("Date", secfont, Brushes.Black, leftmargin + 580, x1 + 7)
        e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - leftmargin, x1 + 2, e.PageBounds.Width - leftmargin, x2 - 40)

        Dim ptop = x3
        Dim numRow = DataGridView1.RowCount - 1

        For intcounter = intstart To numRow
            e.Graphics.DrawString(DataGridView1.Rows(intcounter).Cells(0).Value, fntText, Brushes.Black, leftmargin + 20, x3)
            e.Graphics.DrawString(DataGridView1.Rows(intcounter).Cells(1).Value, fntText, Brushes.Black, leftmargin + 100, x3)
            e.Graphics.DrawString(DataGridView1.Rows(intcounter).Cells(2).Value, fntText, Brushes.Black, leftmargin + 280, x3)
            e.Graphics.DrawString(DataGridView1.Rows(intcounter).Cells(3).Value, fntText, Brushes.Black, leftmargin + 430, x3)
            e.Graphics.DrawString(DataGridView1.Rows(intcounter).Cells(4).Value, fntText, Brushes.Black, leftmargin + 570, x3)


            intLineNumber += 1
            x3 += 30
            If intLineNumber > LinesPerPage - 1 Then
                intstart = intcounter + 1
                e.HasMorePages = True
                Exit For

            End If
        Next

        'e.Graphics.DrawString("ගෙවිය යුතු මුලු මුදල :", secfont, Brushes.Black, leftmargin, e.PageBounds.Height - 145)
        'e.Graphics.DrawString(lblPremium.Text, secfont, Brushes.Black, leftmargin + 200, e.PageBounds.Height - 145)
        'e.Graphics.DrawString("ගෙවිය යුතු ඉතිරි මුදල :", secfont, Brushes.Black, leftmargin, e.PageBounds.Height - 125)
        'e.Graphics.DrawString(lblBalance.Text, secfont, Brushes.Black, leftmargin + 200, e.PageBounds.Height - 125)




    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label8.Text = Date.Now.ToString("hh:mm:ss   dd-MM-yyyy")
    End Sub
End Class
