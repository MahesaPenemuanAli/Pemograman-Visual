Option Strict On


Public Class FrmKasir
    Private ReadOnly daftarPesanan As New List(Of Pesanan)

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboLayanan.Items.Clear()
        For Each layanan As String In ModTarif.daftarLayanan
            cboLayanan.Items.Add(layanan)
        Next
        bsPesanan.DataSource = daftarPesanan
        dgvPesanan.DataSource = bsPesanan
        AturKolom()
        HitungTotal()
        BersihkanInput()
    End Sub

    Private Sub AturKolom()
        dgvPesanan.Columns("Harga").HeaderText = "Harga Satuan"
        dgvPesanan.Columns("Layanan").FillWeight = 190
        dgvPesanan.Columns("Jumlah").FillWeight = 70
        dgvPesanan.Columns("Harga").FillWeight = 100
        dgvPesanan.Columns("Diskon").FillWeight = 100
        dgvPesanan.Columns("Subtotal").FillWeight = 110
        dgvPesanan.Columns("Jumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        For Each namaKolom As String In {"Harga", "Diskon", "Subtotal"}
            With dgvPesanan.Columns(namaKolom).DefaultCellStyle
                .Format = "N0"
                .Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        Next
    End Sub

    Private Function ValidasiInput(ByRef jumlah As Integer) As Boolean
        errInput.Clear()
        Dim valid As Boolean = True
        If cboLayanan.SelectedIndex = -1 Then
            errInput.SetError(cboLayanan, "Pilih layanan terlebih dahulu.")
            valid = False
        End If
        ' TryParse menolak teks kosong, pecahan, dan angka di luar kapasitas Integer.
        If Not Integer.TryParse(txtJumlah.Text, jumlah) OrElse jumlah < 1 OrElse jumlah > 1000 Then
            errInput.SetError(txtJumlah, "Jumlah harus bilangan bulat antara 1 dan 1000 lembar.")
            valid = False
        End If
        Return valid
    End Function

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            Dim jumlah As Integer
            If Not ValidasiInput(jumlah) Then Return

            Dim layanan As String = cboLayanan.Text
            Dim pesananLama As Pesanan = Nothing
            For Each pesanan As Pesanan In daftarPesanan
                If pesanan.Layanan = layanan Then
                    pesananLama = pesanan
                    Exit For
                End If
            Next

            Dim jumlahGabungan As Integer = jumlah
            If pesananLama IsNot Nothing Then jumlahGabungan += pesananLama.Jumlah

            ' Validasi batas gabungan dilakukan sebelum data tersimpan diubah.
            If jumlahGabungan > 1000 Then
                errInput.SetError(txtJumlah, "Jumlah gabungan untuk layanan ini tidak boleh lebih dari 1000 lembar.")
                Return
            End If

            Dim harga As Decimal = ModTarif.HargaSatuan(layanan)
            Dim hargaAwal As Decimal = harga * jumlahGabungan
            Dim diskon As Decimal = 0D
            If jumlahGabungan >= 100 Then diskon = hargaAwal * 0.1D
            Dim subtotal As Decimal = hargaAwal - diskon

            If pesananLama Is Nothing Then
                daftarPesanan.Add(New Pesanan With {
                    .Layanan = layanan, .Jumlah = jumlahGabungan, .Harga = harga,
                    .Diskon = diskon, .Subtotal = subtotal
                })
            Else
                pesananLama.Jumlah = jumlahGabungan
                pesananLama.Harga = harga
                pesananLama.Diskon = diskon
                pesananLama.Subtotal = subtotal
            End If

            ' List dan perubahan property objek perlu diberitahukan ke grid.
            bsPesanan.ResetBindings(False)
            HitungTotal()
            BersihkanInput()
        Catch ex As Exception
            MessageBox.Show(Me, "Pesanan gagal diproses: " & ex.Message,
                            "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvPesanan_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvPesanan.CellFormatting
        Dim namaKolom As String = dgvPesanan.Columns(e.ColumnIndex).Name
        If namaKolom = "Harga" OrElse namaKolom = "Diskon" OrElse namaKolom = "Subtotal" Then
            If e.Value IsNot Nothing Then
                e.Value = CDec(e.Value).ToString("N0").Replace(",", ".")
                e.FormattingApplied = True
            End If
        End If
    End Sub
    Private Sub HitungTotal()
        Dim total As Decimal = 0D
        For Each pesanan As Pesanan In daftarPesanan
            total += pesanan.Subtotal
        Next
        lblTotal.Text = "Rp " & total.ToString("N0").Replace(",", ".")
    End Sub

    Private Sub BersihkanInput()
        cboLayanan.SelectedIndex = -1
        txtJumlah.Clear()
        errInput.Clear()
        cboLayanan.Focus()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Dim jawaban As DialogResult = MessageBox.Show(
            Me, "Hapus semua pesanan dan mulai transaksi baru?", "Transaksi Baru",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If jawaban = DialogResult.Yes Then
            daftarPesanan.Clear()
            bsPesanan.ResetBindings(False)
            HitungTotal()
            BersihkanInput()
        End If
    End Sub

    Private Sub bsPesanan_CurrentChanged(sender As Object, e As EventArgs) Handles bsPesanan.CurrentChanged

    End Sub

    Private Sub cboLayanan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLayanan.SelectedIndexChanged

    End Sub
End Class

