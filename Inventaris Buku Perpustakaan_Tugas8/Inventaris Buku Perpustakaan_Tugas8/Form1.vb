Option Strict On

Public Class Form1
    Private tabelBuku As DataTable

    ' Membuat tabel di memori beserta sepuluh buku contoh untuk empat kategori.
    Private Function BuatTabelBuku() As DataTable
        Dim tabel As New DataTable("Buku")
        tabel.Columns.Add("KodeBuku", GetType(String))
        tabel.Columns.Add("Judul", GetType(String))
        tabel.Columns.Add("Penulis", GetType(String))
        tabel.Columns.Add("Kategori", GetType(String))
        tabel.Columns.Add("Tahun", GetType(Integer))
        tabel.Columns.Add("Stok", GetType(Integer))
        tabel.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabel.Rows.Add("BK0002", "Bumi Manusia", "Pramoedya Ananta Toer", "Fiksi", 1980, 0)
        tabel.Rows.Add("BK0003", "Laut Bercerita", "Leila S. Chudori", "Fiksi", 2017, 5)
        tabel.Rows.Add("BK0004", "Filosofi Teras", "Henry Manampiring", "Nonfiksi", 2018, 6)
        tabel.Rows.Add("BK0005", "Atomic Habits", "James Clear", "Nonfiksi", 2018, 4)
        tabel.Rows.Add("BK0006", "Kamus Bahasa Indonesia", "Tim Penyusun Kamus", "Referensi", 2023, 3)
        tabel.Rows.Add("BK0007", "Ensiklopedia Sains", "Tim Redaksi Sains", "Referensi", 2020, 0)
        tabel.Rows.Add("BK0008", "Atlas Dunia", "Tim Kartografi", "Referensi", 2022, 7)
        tabel.Rows.Add("BK0009", "Majalah Sains Edisi 01", "Redaksi Sains", "Majalah", 2025, 2)
        tabel.Rows.Add("BK0010", "Majalah Literasi Edisi 02", "Redaksi Literasi", "Majalah", 2025, 5)
        Return tabel
    End Function

    ' Menghubungkan DataTable ke grid melalui BindingSource saat form dibuka.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabelBuku = BuatTabelBuku()
        bsBuku.DataSource = tabelBuku
        dgvBuku.DataSource = bsBuku
        AturKolom()
        TerapkanFilter()
    End Sub

    ' Merapikan kolom yang terbentuk otomatis setelah DataSource diisi.
    Private Sub AturKolom()
        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("Tahun").HeaderText = "Tahun Terbit"
        dgvBuku.Columns("KodeBuku").FillWeight = 85
        dgvBuku.Columns("Judul").FillWeight = 220
        dgvBuku.Columns("Penulis").FillWeight = 180
        dgvBuku.Columns("Kategori").FillWeight = 100
        dgvBuku.Columns("Tahun").FillWeight = 85
        dgvBuku.Columns("Stok").FillWeight = 60
        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' Memeriksa semua isian dan menandai kesalahan menggunakan ErrorProvider.
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim valid As Boolean = True
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        If Not KodeBukuValid(kode) Then
            errBuku.SetError(txtKodeBuku, "Kode harus BK diikuti 4 digit, contoh BK0011.")
            valid = False
        Else
            ' Periksa seluruh tabel, termasuk buku yang tidak tampil karena filter.
            For Each baris As DataRow In tabelBuku.Rows
                If baris("KodeBuku").ToString() = kode Then
                    errBuku.SetError(txtKodeBuku, "Kode buku sudah ada. Gunakan kode lain.")
                    valid = False
                    Exit For
                End If
            Next
        End If
        If txtJudul.Text.Trim() = "" Then
            errBuku.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If
        If txtPenulis.Text.Trim() = "" Then
            errBuku.SetError(txtPenulis, "Penulis wajib diisi.")
            valid = False
        End If
        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Pilih kategori buku.")
            valid = False
        End If
        Dim tahun As Integer
        If Not Integer.TryParse(txtTahun.Text, tahun) OrElse
           tahun < 1900 OrElse tahun > Date.Today.Year Then
            errBuku.SetError(txtTahun, "Tahun harus bilangan bulat 1900 sampai " & Date.Today.Year.ToString() & ".")
            valid = False
        End If
        Dim stok As Integer
        If Not Integer.TryParse(txtStok.Text, stok) OrElse stok < 0 Then
            errBuku.SetError(txtStok, "Stok harus bilangan bulat 0 atau lebih (maksimal 2147483647).")
            valid = False
        End If
        Return valid
    End Function

    ' Menambah satu DataRow; binding langsung memperbarui grid tanpa mengisi ulang.
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Buku belum ditambahkan. Periksa isian bertanda merah."
            Return
        End If
        Dim tahun As Integer
        Dim stok As Integer
        Integer.TryParse(txtTahun.Text, tahun)
        Integer.TryParse(txtStok.Text, stok)
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpperInvariant()
        tabelBuku.Rows.Add(kode, txtJudul.Text.Trim(), txtPenulis.Text.Trim(),
                           cboKategori.Text, tahun, stok)
        PerbaruiRingkasan()
        BersihkanForm()
        lblStatus.Text = "Buku " & kode & " berhasil ditambahkan. Tampilan mengikuti filter yang aktif."
    End Sub

    ' Mengosongkan isian dan ikon error agar siap menambah buku berikutnya.
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        cboKategori.SelectedIndex = -1
        txtTahun.Clear()
        txtStok.Clear()
        errBuku.Clear()
        txtKodeBuku.Focus()
    End Sub

    ' Membersihkan isian tanpa menghapus data atau mengubah pencarian.
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Isian dibersihkan. Silakan masukkan buku baru."
    End Sub

    ' Menggabungkan pencarian judul/penulis, kategori, dan stok dalam satu Filter.
    Private Sub TerapkanFilter()
        ' Event ComboBox dapat berjalan saat InitializeComponent, sebelum Load.
        If tabelBuku Is Nothing Then Return
        Dim filter As String = ""
        Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
        If kata <> "" Then
            filter = "(Judul LIKE '%" & kata & "%' OR Penulis LIKE '%" & kata & "%')"
        End If
        If cboFilterKategori.SelectedIndex > 0 Then
            If filter <> "" Then filter &= " AND "
            filter &= "Kategori = '" & cboFilterKategori.Text & "'"
        End If
        If chkStokHabis.Checked Then
            If filter <> "" Then filter &= " AND "
            filter &= "Stok = 0"
        End If
        If filter = "" Then
            bsBuku.RemoveFilter()
        Else
            bsBuku.Filter = filter
        End If
        PerbaruiRingkasan()
    End Sub

    ' Menghitung jumlah hasil dan total stok dari baris yang sedang tampil.
    Private Sub PerbaruiRingkasan()
        Dim totalStok As Long = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            totalStok += CInt(baris.Cells("Stok").Value)
        Next
        lblJumlah.Text = "Menampilkan " & bsBuku.Count.ToString() & " dari " & tabelBuku.Rows.Count.ToString() & " buku"
        lblTotalStok.Text = "Total stok: " & totalStok.ToString() & " eksemplar"
    End Sub

    ' Mencari langsung setiap kali teks pencarian berubah.
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        TerapkanFilter()
    End Sub

    ' Memperbarui hasil saat kategori pencarian diganti.
    Private Sub cboFilterKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterKategori.SelectedIndexChanged
        TerapkanFilter()
    End Sub

    ' Menambahkan atau melepas syarat stok nol tanpa menghapus syarat lain.
    Private Sub chkStokHabis_CheckedChanged(sender As Object, e As EventArgs) Handles chkStokHabis.CheckedChanged
        TerapkanFilter()
    End Sub

    ' Mengurutkan tampilan BindingSource sesuai pilihan tanpa mengubah DataTable.
    Private Sub cboUrut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUrut.SelectedIndexChanged
        If tabelBuku Is Nothing Then Return
        Select Case cboUrut.SelectedIndex
            Case 1
                bsBuku.Sort = "Judul ASC"
            Case 2
                bsBuku.Sort = "Tahun DESC"
            Case 3
                bsBuku.Sort = "Stok DESC"
            Case Else
                bsBuku.RemoveSort()
        End Select
    End Sub
End Class
