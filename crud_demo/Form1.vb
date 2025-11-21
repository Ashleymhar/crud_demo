Imports MySql.Data.MySqlClient


Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost; userid=root; password=root; database=crud_demo_db"

        Try
            conn.Open()
            MessageBox.Show("Connected")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

    End Sub

    Private Sub ButtonInsert_Click(sender As Object, e As EventArgs) Handles ButtonInsert.Click


        Dim query As String = "INSERT INTO students_tbl (name,age, email) VALUES (@Name, @Age, @Email)"
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Name", TextBoxName.Text)
                    cmd.Parameters.AddWithValue("@Age", CInt(TextBoxAge.Text))
                    cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Record Inserted Successfully")
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query As String = "SELECT * FROM crud_demo_db.students_tbl; "
        Try
            Using conn As New MySqlConnection("server=localhost; userid=root; password=root; database=crud_demo_db")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    Dim adapter As New MySqlDataAdapter(cmd) 'Get from 
                    Dim table As New DataTable() 'Table Object 
                    adapter.Fill(table) 'From adapter to table object
                    DataGridView1.DataSource = table 'Display to data grid view
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
