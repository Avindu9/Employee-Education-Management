Imports System.Data.OleDb
Public Class Form3
    Dim pro As String
    Dim connstring As String
    Dim command As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Dim cid As String
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Form1.Enabled = True
        Me.Close()
    End Sub
    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Enabled = True
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pro = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")
        connstring = pro
        myconnection.ConnectionString = connstring
        myconnection.Open()

        dataview()
    End Sub
    Private Sub dataview()
        Dim ds As New DataSet
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        Dim da As New OleDbDataAdapter

        da = New OleDbDataAdapter("SELECT Course_id,Course_name, Course_type FROM Edu_quality;", myconnection)
        da.Fill(dt)
        dtview1.DataSource = dt.DefaultView
    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        command = "INSERT INTO Edu_quality VALUES ('" & txtcourseid.Text & "','" & txtcoursename.Text & "','" & txtcoursetype.Text & "');"
        Dim cmd As New OleDbCommand(command, myconnection)
        cmd.Parameters.Add(New OleDbParameter("Course_id", CType(txtcourseid.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Course_name", CType(txtcoursename.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("Course_type", CType(txtcoursetype.Text, String)))
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
    Private Sub clear()
        txtcourseid.Clear()
        txtcoursename.Clear()
        txtcoursetype.Clear()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim strsql As New OleDbCommand("DELETE FROM Edu_quality WHERE Course_id=" & cid & ";", myconnection)

        MsgBox("Record Deleted!")

        Try
            strsql.ExecuteNonQuery()
            dataview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtview1.CellClick
        Dim selectedrow As DataGridViewRow
        selectedrow = dtview1.Rows(e.RowIndex)
        cid = selectedrow.Cells(0).Value

    End Sub
End Class