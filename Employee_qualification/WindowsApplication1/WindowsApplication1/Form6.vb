Imports System.Data.OleDb
Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please enter Required field!", "Authentication Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim conn As New OleDbConnection
            conn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Employee_details.accdb")

            Try
                Dim sql As String = "SELECT * FROM admin WHERE username = '" & TextBox1.Text & "' AND password = '" & TextBox2.Text & "' "
                Dim sqlcom As New System.Data.OleDb.OleDbCommand(sql)


                sqlcom.Connection = conn
                conn.Open()

                Dim sqlread As System.Data.OleDb.OleDbDataReader = sqlcom.ExecuteReader()
                If sqlread.Read() Then
                    Form1.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("username and password do not match!!", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox1.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show("failed to connect database..", "Database connection Error ", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim intResponse As Integer

        intResponse = MsgBox("Are you sure you want to quit?", vbYesNo + vbExclamation, "Quit")

        If intResponse = vbNo Then

            Me.Close()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please enter Required field!", "Authentication Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If

    End Sub
End Class