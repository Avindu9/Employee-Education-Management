Public Class Form5
    Private Sub Form5_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thisDB As String = Application.StartupPath & "\Employee_details.accdb"

        Dim destination As String = Application.StartupPath & "\Employee_details" & Format(Now, "yyyy-MM-dd h m s") & ".accdb"

        FileCopy(thisDB, destination)
        MessageBox.Show("Backup Success")
    End Sub
End Class