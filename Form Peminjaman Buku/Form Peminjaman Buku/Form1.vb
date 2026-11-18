Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Private ReadOnly daftarKodeBuku As New List(Of String)
    ' Setiap array berisi enam kolom yang juga ditampilkan di ListBox.
    Private ReadOnly daftarPeminjaman As New List(Of String())
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "peminjaman.csv")

    ' Memeriksa semua isian sekaligus dan menandai setiap kesalahan.
    Private Function ValidasiInput() As Boolean
        errPinjam.Clear()
        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()

        If Not KodeBukuValid(kode) Then
            errPinjam.SetError(txtKodeBuku, "Kode harus BK diikuti 4 digit, contoh BK0012.")
            valid = False
        ElseIf daftarKodeBuku.Contains(kode) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            valid = False
        End If

        If txtJudul.Text.Trim() = "" Then
            errPinjam.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If

        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Pilih kategori buku.")
            valid = False
        End If

        If txtNamaPeminjam.Text.Trim().Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            valid = False
        End If

        Dim lamaPinjam As Integer
        If Not Integer.TryParse(txtLamaPinjam.Text, lamaPinjam) OrElse
           lamaPinjam < 1 OrElse lamaPinjam > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus bilangan bulat 1 sampai 14 hari.")
            valid = False
        End If
        Return valid
    End Function

    ' Mencatat peminjaman yang valid dan menghitung tanggal kembali.
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian bertanda merah. Jumlah peminjaman: " & lstPeminjaman.Items.Count
            Return
        End If

        Dim lamaPinjam As Integer
        Integer.TryParse(txtLamaPinjam.Text, lamaPinjam)
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        Dim tanggalKembali As String = Date.Today.AddDays(lamaPinjam).ToString("dd/MM/yyyy")
        Dim data As String() = {kode, txtJudul.Text.Trim(), cboKategori.Text,
                               txtNamaPeminjam.Text.Trim(), lamaPinjam.ToString(), tanggalKembali}
        lstPeminjaman.Items.Add(data(0) & " | " & data(1) & " | " & data(2) & " | " &
                               data(3) & " | " & data(4) & " hari | kembali " & data(5))
        daftarKodeBuku.Add(kode)
        daftarPeminjaman.Add(data)
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count
        BersihkanForm()
    End Sub

    ' Memeriksa format saat fokus meninggalkan kode tanpa mengunci fokus.
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If KodeBukuValid(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "")
        Else
            errPinjam.SetError(txtKodeBuku, "Kode harus BK diikuti 4 digit, contoh BK0012.")
        End If
    End Sub

    ' Mengosongkan isian dan ikon error tanpa menghapus daftar peminjaman.
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        txtKodeBuku.Focus()
        errPinjam.Clear()
    End Sub

    ' Mengembalikan form ke keadaan siap diisi.
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count
    End Sub

    ' Menampilkan petunjuk ketika ekspor gagal dan memperbarui status.
    Private Sub TampilkanGagalEkspor(pesan As String)
        lblStatus.Text = "Ekspor gagal. Jumlah peminjaman: " & lstPeminjaman.Items.Count
        MessageBox.Show(pesan, "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ' Mengekspor enam kolom ke CSV dan menutup StreamWriter di Finally.
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Daftar peminjaman masih kosong. Catat peminjaman terlebih dahulu.",
                            "Ekspor CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim penulis As StreamWriter = Nothing
        Dim berhasil As Boolean = False
        Dim pesanIo As String = "File peminjaman.csv sedang dipakai atau tidak dapat ditulis." &
            vbCrLf & "Tutup file di Excel atau program lain, periksa ruang penyimpanan dan folder Documents, lalu klik Ekspor lagi."
        Dim pesanAkses As String = "Akses menulis peminjaman.csv ditolak." & vbCrLf &
            "Periksa izin tulis folder Documents dan pastikan file tidak berstatus Read-only, lalu klik Ekspor lagi."

        Try
            penulis = New StreamWriter(lokasiEkspor)
            penulis.WriteLine("Kode Buku;Judul Buku;Kategori;Nama Peminjam;Lama Pinjam (hari);Tanggal Kembali")
            For Each data As String() In daftarPeminjaman
                Dim kolom As String() = New String(data.Length - 1) {}
                For indeks As Integer = 0 To data.Length - 1
                    kolom(indeks) = KolomCsv(data(indeks))
                Next
                penulis.WriteLine(String.Join(";", kolom))
            Next
            penulis.Flush()
            berhasil = True
        Catch ex As IOException
            TampilkanGagalEkspor(pesanIo)
        Catch ex As UnauthorizedAccessException
            TampilkanGagalEkspor(pesanAkses)
        Finally
            If penulis IsNot Nothing Then
                ' Penutupan juga dapat gagal jika media penyimpanan bermasalah.
                Try
                    penulis.Close()
                Catch ex As IOException
                    If berhasil Then TampilkanGagalEkspor(pesanIo)
                    berhasil = False
                Catch ex As UnauthorizedAccessException
                    If berhasil Then TampilkanGagalEkspor(pesanAkses)
                    berhasil = False
                End Try
            End If
        End Try

        If berhasil Then
            lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count & " | Ekspor berhasil."
            MessageBox.Show("Daftar peminjaman disimpan ke:" & vbCrLf & lokasiEkspor,
                            "Ekspor Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub lstPeminjaman_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPeminjaman.SelectedIndexChanged

    End Sub

    Private Sub lblKodeBuku_Click(sender As Object, e As EventArgs) Handles lblKodeBuku.Click

    End Sub

    Private Sub lblLamaPinjam_Click(sender As Object, e As EventArgs) Handles lblLamaPinjam.Click

    End Sub
End Class
