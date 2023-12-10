Imports System.Data.OleDb
Public Class Form2
    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Dim NICid As String
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Form1.Enabled = True
        Me.Close()
    End Sub
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Enabled = True
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Employee_detailsDataSet.Ac_office' table. You can move, or remove it, as needed.
        Me.Ac_officeTableAdapter.Fill(Me.Employee_detailsDataSet.Ac_office)
        pro = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        connstring = pro
        myconnection.ConnectionString = connstring
        myconnection.Open()

        DataView()
    End Sub
    Private Sub dataview()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As New OleDbDataAdapter

        da = New OleDbDataAdapter("SELECT e.NIC, e.Employee_name, a.Ac_office_name from Employee e, Ac_office a where e.Ac_office_id=a.Ac_office_id;", myconnection)
        da.Fill(dt)
        dtview.DataSource = dt.DefaultView
    End Sub
    Private Sub clear()
        txtnic.Clear()
        txtname.Clear()
        cmbac.SelectedIndex = 0
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        Command = "INSERT INTO Employee VALUES ('" & txtnic.Text & "','" & txtname.Text & "','" & (cmbac.SelectedIndex + 1) & "');"
        Dim cmd As New OleDbCommand(Command, myconnection)
        cmd.Parameters.Add(New OleDbParameter("NIC", CType(txtnic.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Employee_name", CType(txtname.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Ac_office_id", CType((cmbac.SelectedIndex.ToString() + 1), String)))
        MsgBox("Record Saved")
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            DataView()
            clear()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim strsql As New OleDbCommand("DELETE FROM Employee WHERE NIC='" & NICid & "';", myconnection)

        MsgBox("Record Deleted!")

        Try
            strsql.ExecuteNonQuery()
            dataview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtview.CellClick
        Dim selectedrow As DataGridViewRow
        selectedrow = dtview.Rows(e.RowIndex)
        NICid = selectedrow.Cells(0).Value
    End Sub
End Class