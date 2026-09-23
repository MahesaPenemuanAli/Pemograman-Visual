Public Class Form1
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNIM.Text,
            txtNama.Text,
            txtJurusan.Text
        ) Then
            MessageBox.Show("Data berhasil ditambahkan")
        End If
        txtJurusan.Clear()
        txtNIM.Clear()
        txtNama.Clear()
    End Sub
End Class
