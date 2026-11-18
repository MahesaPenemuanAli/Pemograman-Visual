Option Strict On
Imports System.Data
Imports System.IO
Imports System.Globalization

Public Class Form1
    Private tabelRekap As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboFilterJurusan.SelectedIndex = 0
        cboJurusanRekap.SelectedIndex = 0
        bsMahasiswa.DataSource = daftarMahasiswa
        dgvMahasiswa.DataSource = bsMahasiswa
        RapikanGrid(dgvMahasiswa)
        AddHandler bsRekap.ListChanged, Sub() PerbaruiStatistik()
        BersihkanForm()
        PerbaruiJumlah()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
    End Sub
    Private Sub btnResetPencarian_Click(sender As Object, e As EventArgs) Handles btnResetPencarian.Click
        ResetPencarian()
    End Sub
    Private Sub btnMuatRekap_Click(sender As Object, e As EventArgs) Handles btnMuatRekap.Click
        MuatRekap()
    End Sub
    Private Sub btnFilterRekap_Click(sender As Object, e As EventArgs) Handles btnFilterRekap.Click
        FilterRekap()
    End Sub
    Private Sub btnResetRekap_Click(sender As Object, e As EventArgs) Handles btnResetRekap.Click
        txtCariRekap.Clear()
        cboJurusanRekap.SelectedIndex = 0
        FilterRekap()
    End Sub
    Private Sub btnUjiKonversi_Click(sender As Object, e As EventArgs) Handles btnUjiKonversi.Click
        Try
            Dim angka = Integer.Parse(txtAngkaUji.Text)
            lblHasilUji.Text = "Berhasil: " & angka.ToString()
        Catch ex As FormatException
            lblHasilUji.Text = "Format salah. Masukkan bilangan bulat, misalnya 25."
        Catch ex As OverflowException
            lblHasilUji.Text = "Angka terlalu besar atau terlalu kecil untuk Integer."
        Finally
            lblStatus.Text = "Uji konversi selesai."
        End Try
    End Sub

    Private Function ValidasiInput() As Boolean
        errInput.Clear()
        Dim valid = True
        Dim periksa As Action(Of Control, Boolean, String) =
            Sub(kontrol, kondisi, pesan)
                If Not kondisi Then
                    errInput.SetError(kontrol, pesan)
                    valid = False
                End If
            End Sub
        Dim nim = txtNIM.Text.Trim()
        periksa(txtNIM, NIMValid(nim), "NIM harus tepat 9 digit angka.")
        If NIMValid(nim) Then periksa(txtNIM, Not daftarMahasiswa.Any(Function(m) m.NIM = nim), "NIM sudah terdaftar.")
        periksa(txtNama, txtNama.Text.Trim().Length >= 3, "Nama minimal 3 karakter.")
        periksa(cboJurusan, cboJurusan.SelectedIndex >= 0, "Pilih jurusan.")
        Dim angkatan As Integer
        periksa(txtAngkatan, Integer.TryParse(txtAngkatan.Text, angkatan) AndAlso angkatan >= 2015 AndAlso angkatan <= Date.Today.Year,
                "Angkatan harus 2015 sampai " & Date.Today.Year.ToString() & ".")
        For Each kontrol In {txtTugas, txtUTS, txtUAS}
            Dim nilai As Decimal
            periksa(kontrol, BacaDesimal(kontrol.Text, nilai) AndAlso nilai >= 0D AndAlso nilai <= 100D, "Nilai harus angka 0–100.")
        Next
        Return valid
    End Function
    Private Sub BersihkanForm()
        For Each teks In {txtNIM, txtNama, txtAngkatan, txtTugas, txtUTS, txtUAS}
            teks.Clear()
        Next
        cboJurusan.SelectedIndex = -1
        errInput.Clear()
        txtNIM.Focus()
    End Sub
    Private Function BuatMahasiswa(nim As String, nama As String, jurusan As String, angkatan As Integer, tugas As Decimal, uts As Decimal, uas As Decimal) As Mahasiswa
        Dim akhir = HitungNilaiAkhir(tugas, uts, uas)
        Return New Mahasiswa With {.NIM = nim, .Nama = nama, .Jurusan = jurusan, .Angkatan = angkatan,
            .Tugas = tugas, .UTS = uts, .UAS = uas, .NilaiAkhir = akhir, .Grade = TentukanGrade(akhir),
            .Status = If(akhir >= 65D, "Lulus", "Tidak Lulus")}
    End Function
    Private Sub Tambah(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Perbaiki input yang ditandai ikon merah."
            Return
        End If
        Dim tugas, uts, uas As Decimal
        BacaDesimal(txtTugas.Text, tugas)
        BacaDesimal(txtUTS.Text, uts)
        BacaDesimal(txtUAS.Text, uas)
        Dim m = BuatMahasiswa(txtNIM.Text.Trim(), txtNama.Text.Trim(), cboJurusan.Text, Integer.Parse(txtAngkatan.Text), tugas, uts, uas)
        bsMahasiswa.Add(m)
        lblStatus.Text = m.Nama & ": " & m.NilaiAkhir.ToString("N2") & " / " & m.Grade & " (" & PenjelasanGrade(m.Grade) & ") / " & m.Status
        PerbaruiJumlah()
        BersihkanForm()
    End Sub
    Private Sub PerbaruiJumlah()
        lblJumlah.Text = bsMahasiswa.Count.ToString() & " dari " & daftarMahasiswa.Count.ToString() & " mahasiswa"
    End Sub
    Private Sub Hapus(sender As Object, e As EventArgs) Handles btnHapus.Click
        If bsMahasiswa.Current Is Nothing Then
            lblStatus.Text = "Pilih mahasiswa yang akan dihapus."
            Return
        End If
        Dim m = DirectCast(bsMahasiswa.Current, Mahasiswa)
        If MessageBox.Show("Hapus " & m.Nama & "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        bsMahasiswa.RemoveCurrent()
        PerbaruiJumlah()
        lblStatus.Text = "Data " & m.Nama & " dihapus."
    End Sub
    Private Sub Cari(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim hasil As New List(Of Mahasiswa)
        For Each m In daftarMahasiswa
            Dim cocok = m.NIM.Contains(txtCari.Text.Trim(), StringComparison.OrdinalIgnoreCase) OrElse m.Nama.Contains(txtCari.Text.Trim(), StringComparison.OrdinalIgnoreCase)
            If cocok AndAlso (cboFilterJurusan.SelectedIndex = 0 OrElse m.Jurusan = cboFilterJurusan.Text) Then hasil.Add(m)
        Next
        bsMahasiswa.DataSource = hasil
        btnTambah.Enabled = False
        btnHapus.Enabled = False
        PerbaruiJumlah()
        lblStatus.Text = "Hasil pencarian. Reset pencarian untuk menambah atau menghapus."
    End Sub
    Private Sub ResetPencarian()
        bsMahasiswa.DataSource = daftarMahasiswa
        bsMahasiswa.ResetBindings(False)
        txtCari.Clear()
        cboFilterJurusan.SelectedIndex = 0
        btnTambah.Enabled = True
        btnHapus.Enabled = True
        PerbaruiJumlah()
        lblStatus.Text = "Semua data ditampilkan."
    End Sub
    Private Sub IsiContoh(sender As Object, e As EventArgs) Handles btnContoh.Click
        ResetPencarian()
        For i = 0 To contoh.GetLength(0) - 1
            Dim nim = contoh(i, 0)
            If daftarMahasiswa.Any(Function(m) m.NIM = nim) Then Continue For
            bsMahasiswa.Add(BuatMahasiswa(nim, contoh(i, 1), contoh(i, 2), 2024, 80D - i * 7D, 70D - i * 5D, 90D - i * 8D))
        Next
        PerbaruiJumlah()
        lblStatus.Text = "Data contoh ditambahkan. NIM yang sudah ada dilewati."
    End Sub
    Private Sub RapikanGrid(grid As DataGridView)
        For Each kolom As DataGridViewColumn In grid.Columns
            If {"Tugas", "UTS", "UAS", "NilaiAkhir"}.Contains(kolom.Name) Then
                kolom.DefaultCellStyle.Format = "N2"
                kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If kolom.Name = "NilaiAkhir" Then kolom.HeaderText = "Nilai Akhir"
        Next
    End Sub
    Private Sub TampilArray(sender As Object, e As EventArgs) Handles btnTampilArray.Click
        dgvArray.Rows.Clear()
        If dgvArray.Columns.Count = 0 Then
            dgvArray.Columns.Add("NIM", "NIM")
            dgvArray.Columns.Add("Nama", "Nama")
            dgvArray.Columns.Add("Jurusan", "Jurusan")
        End If
        For i = 0 To contoh.GetLength(0) - 1
            Dim baris = dgvArray.Rows.Add()
            For j = 0 To contoh.GetLength(1) - 1
                dgvArray.Rows(baris).Cells(j).Value = contoh(i, j)
            Next
        Next
        lstHasilArray.Items.Clear()
        For Each nama In komponenNilai
            lstHasilArray.Items.Add("Array 1D: " & nama)
        Next
        For i = contoh.GetLength(0) - 1 To 0 Step -1
            lstHasilArray.Items.Add("Urutan mundur: " & contoh(i, 1) & " / " & If(i Mod 2 = 0, "indeks genap", "indeks ganjil"))
        Next
    End Sub
    Private Sub MuatRekap()
        bsRekap.DataSource = Nothing
        If tabelRekap IsNot Nothing Then tabelRekap.Dispose()
        tabelRekap = New DataTable()
        For Each nama In {"NIM", "Nama", "Jurusan", "Grade", "Status"}
            tabelRekap.Columns.Add(nama, GetType(String))
        Next
        tabelRekap.Columns.Add("Angkatan", GetType(Integer))
        tabelRekap.Columns.Add("NilaiAkhir", GetType(Decimal))
        For Each m In daftarMahasiswa
            tabelRekap.Rows.Add(m.NIM, m.Nama, m.Jurusan, m.Grade, m.Status, m.Angkatan, m.NilaiAkhir)
        Next
        bsRekap.DataSource = tabelRekap
        dgvRekap.DataSource = bsRekap
        RapikanGrid(dgvRekap)
        FilterRekap()
    End Sub
    Private Sub FilterRekap()
        If tabelRekap Is Nothing Then Return
        Dim cari = AmankanFilter(txtCariRekap.Text.Trim())
        Dim ekspresi = "(Nama LIKE '%" & cari & "%' OR NIM LIKE '%" & cari & "%')"
        If cboJurusanRekap.SelectedIndex > 0 Then ekspresi &= " AND Jurusan = '" & AmankanFilter(cboJurusanRekap.Text) & "'"
        bsRekap.Filter = ekspresi
        PerbaruiStatistik()
    End Sub
    Private Sub PerbaruiStatistik()
        Dim nilai As New List(Of Decimal)
        For Each item As Object In bsRekap
            Dim row = TryCast(item, DataRowView)
            If row IsNot Nothing Then nilai.Add(CDec(row("NilaiAkhir")))
        Next
        Dim total As Decimal
        For Each n In nilai
            total += n
        Next
        Dim i = 0, lulus = 0
        While i < nilai.Count
            If nilai(i) >= 65D Then lulus += 1
            i += 1
        End While
        Dim tertinggi As Decimal
        If nilai.Count > 0 Then
            i = 0
            Do
                If nilai(i) > tertinggi Then tertinggi = nilai(i)
                i += 1
            Loop While i < nilai.Count
        End If
        Dim rata = If(nilai.Count > 0, total / Math.Max(1, nilai.Count), 0D)
        lblStatistik.Text = "Tampil: " & nilai.Count.ToString() & " | Rata-rata: " & rata.ToString("N2") &
            " | Tertinggi: " & tertinggi.ToString("N2") & " | Lulus: " & lulus.ToString() &
            " | Tidak lulus: " & (nilai.Count - lulus).ToString()
    End Sub
    Private Sub Ekspor(sender As Object, e As EventArgs) Handles btnEkspor.Click
        Using dialog As New SaveFileDialog With {.Filter = "CSV (*.csv)|*.csv", .FileName = "nilai-mahasiswa.csv", .DefaultExt = "csv", .AddExtension = True}
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            Dim tombolEkspor = DirectCast(sender, Button)
            tombolEkspor.Enabled = False
            Try
                Using penulis As New StreamWriter(dialog.FileName, False, New System.Text.UTF8Encoding(True))
                    penulis.WriteLine("NIM,Nama,Jurusan,Angkatan,Tugas,UTS,UAS,NilaiAkhir,Grade,Status")
                    For Each m In daftarMahasiswa
                        Dim kolom As String() = {m.NIM, m.Nama, m.Jurusan, m.Angkatan.ToString(),
                            m.Tugas.ToString(CultureInfo.InvariantCulture), m.UTS.ToString(CultureInfo.InvariantCulture),
                            m.UAS.ToString(CultureInfo.InvariantCulture), m.NilaiAkhir.ToString(CultureInfo.InvariantCulture), m.Grade, m.Status}
                        penulis.WriteLine(String.Join(",", kolom.Select(Function(s) KolomCSV(s))))
                    Next
                End Using
                lblStatus.Text = "Seluruh " & daftarMahasiswa.Count.ToString() & " data diekspor ke " & dialog.FileName
            Catch ex As UnauthorizedAccessException
                MessageBox.Show("Tidak dapat menulis di lokasi ini. Pilih folder lain.", "Ekspor gagal")
            Catch ex As IOException
                MessageBox.Show("File tidak dapat ditulis. Tutup file jika sedang digunakan, lalu coba lagi.", "Ekspor gagal")
            Finally
                tombolEkspor.Enabled = True
            End Try
        End Using
    End Sub
End Class

