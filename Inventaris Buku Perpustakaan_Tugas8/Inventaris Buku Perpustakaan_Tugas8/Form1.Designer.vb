Option Strict On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    ' Membersihkan komponen ketika form ditutup.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' Membuat dan mengatur semua kontrol serta komponen melalui Designer.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblPetunjuk = New Label()
        grpBuku = New GroupBox()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblPenulis = New Label()
        txtPenulis = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblTahun = New Label()
        txtTahun = New TextBox()
        lblStok = New Label()
        txtStok = New TextBox()
        btnTambah = New Button()
        btnBersihkan = New Button()
        lblStatus = New Label()
        grpPencarian = New GroupBox()
        lblCari = New Label()
        txtCari = New TextBox()
        lblFilterKategori = New Label()
        cboFilterKategori = New ComboBox()
        lblUrut = New Label()
        cboUrut = New ComboBox()
        chkStokHabis = New CheckBox()
        dgvBuku = New DataGridView()
        bsBuku = New BindingSource(components)
        lblJumlah = New Label()
        lblTotalStok = New Label()
        errBuku = New ErrorProvider(components)
        grpBuku.SuspendLayout()
        grpPencarian.SuspendLayout()
        CType(dgvBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(errBuku, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.Font = New Font("Segoe UI", 19F, FontStyle.Bold)
        lblJudulForm.ForeColor = Color.FromArgb(CByte(30), CByte(64), CByte(90))
        lblJudulForm.Location = New Point(34, 17)
        lblJudulForm.Margin = New Padding(4, 0, 4, 0)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(1143, 63)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Inventaris Buku Perpustakaan"
        ' 
        ' lblPetunjuk
        ' 
        lblPetunjuk.ForeColor = Color.DimGray
        lblPetunjuk.Location = New Point(37, 83)
        lblPetunjuk.Margin = New Padding(4, 0, 4, 0)
        lblPetunjuk.Name = "lblPetunjuk"
        lblPetunjuk.Size = New Size(1286, 33)
        lblPetunjuk.TabIndex = 1
        lblPetunjuk.Text = "Tambahkan buku, cari koleksi, dan lihat jumlah stok yang tersedia."
        ' 
        ' grpBuku
        ' 
        grpBuku.Controls.Add(lblKodeBuku)
        grpBuku.Controls.Add(txtKodeBuku)
        grpBuku.Controls.Add(lblJudul)
        grpBuku.Controls.Add(txtJudul)
        grpBuku.Controls.Add(lblPenulis)
        grpBuku.Controls.Add(txtPenulis)
        grpBuku.Controls.Add(lblKategori)
        grpBuku.Controls.Add(cboKategori)
        grpBuku.Controls.Add(lblTahun)
        grpBuku.Controls.Add(txtTahun)
        grpBuku.Controls.Add(lblStok)
        grpBuku.Controls.Add(txtStok)
        grpBuku.Controls.Add(btnTambah)
        grpBuku.Controls.Add(btnBersihkan)
        grpBuku.Controls.Add(lblStatus)
        grpBuku.Location = New Point(34, 127)
        grpBuku.Margin = New Padding(4, 5, 4, 5)
        grpBuku.Name = "grpBuku"
        grpBuku.Padding = New Padding(4, 5, 4, 5)
        grpBuku.Size = New Size(1474, 283)
        grpBuku.TabIndex = 0
        grpBuku.TabStop = False
        grpBuku.Text = "Data buku baru"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.Location = New Point(26, 33)
        lblKodeBuku.Margin = New Padding(4, 0, 4, 0)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(429, 30)
        lblKodeBuku.TabIndex = 0
        lblKodeBuku.Text = "Kode buku (BK + 4 digit)"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.CharacterCasing = CharacterCasing.Upper
        txtKodeBuku.Location = New Point(26, 67)
        txtKodeBuku.Margin = New Padding(4, 5, 4, 5)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(427, 31)
        txtKodeBuku.TabIndex = 0
        ' 
        ' lblJudul
        ' 
        lblJudul.Location = New Point(500, 33)
        lblJudul.Margin = New Padding(4, 0, 4, 0)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(429, 30)
        lblJudul.TabIndex = 1
        lblJudul.Text = "Judul buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(500, 67)
        txtJudul.Margin = New Padding(4, 5, 4, 5)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(427, 31)
        txtJudul.TabIndex = 1
        ' 
        ' lblPenulis
        ' 
        lblPenulis.Location = New Point(974, 33)
        lblPenulis.Margin = New Padding(4, 0, 4, 0)
        lblPenulis.Name = "lblPenulis"
        lblPenulis.Size = New Size(429, 30)
        lblPenulis.TabIndex = 2
        lblPenulis.Text = "Penulis"
        ' 
        ' txtPenulis
        ' 
        txtPenulis.Location = New Point(974, 67)
        txtPenulis.Margin = New Padding(4, 5, 4, 5)
        txtPenulis.Name = "txtPenulis"
        txtPenulis.Size = New Size(427, 31)
        txtPenulis.TabIndex = 2
        ' 
        ' lblKategori
        ' 
        lblKategori.Location = New Point(26, 122)
        lblKategori.Margin = New Padding(4, 0, 4, 0)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(429, 30)
        lblKategori.TabIndex = 3
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(26, 155)
        cboKategori.Margin = New Padding(4, 5, 4, 5)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(427, 33)
        cboKategori.TabIndex = 3
        ' 
        ' lblTahun
        ' 
        lblTahun.Location = New Point(500, 122)
        lblTahun.Margin = New Padding(4, 0, 4, 0)
        lblTahun.Name = "lblTahun"
        lblTahun.Size = New Size(429, 30)
        lblTahun.TabIndex = 4
        lblTahun.Text = "Tahun terbit"
        ' 
        ' txtTahun
        ' 
        txtTahun.Location = New Point(500, 155)
        txtTahun.Margin = New Padding(4, 5, 4, 5)
        txtTahun.Name = "txtTahun"
        txtTahun.Size = New Size(427, 31)
        txtTahun.TabIndex = 4
        ' 
        ' lblStok
        ' 
        lblStok.Location = New Point(974, 122)
        lblStok.Margin = New Padding(4, 0, 4, 0)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(429, 30)
        lblStok.TabIndex = 5
        lblStok.Text = "Jumlah stok (eksemplar)"
        ' 
        ' txtStok
        ' 
        txtStok.Location = New Point(974, 155)
        txtStok.Margin = New Padding(4, 5, 4, 5)
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(427, 31)
        txtStok.TabIndex = 5
        ' 
        ' btnTambah
        ' 
        btnTambah.BackColor = Color.FromArgb(CByte(30), CByte(80), CByte(115))
        btnTambah.FlatStyle = FlatStyle.Flat
        btnTambah.ForeColor = Color.White
        btnTambah.Location = New Point(26, 213)
        btnTambah.Margin = New Padding(4, 5, 4, 5)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(189, 55)
        btnTambah.TabIndex = 6
        btnTambah.Text = "Tambah Buku"
        btnTambah.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.CausesValidation = False
        btnBersihkan.Location = New Point(229, 213)
        btnBersihkan.Margin = New Padding(4, 5, 4, 5)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(171, 55)
        btnBersihkan.TabIndex = 7
        btnBersihkan.Text = "Bersihkan Isian"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.ForeColor = Color.FromArgb(CByte(65), CByte(80), CByte(90))
        lblStatus.Location = New Point(429, 213)
        lblStatus.Margin = New Padding(4, 0, 4, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(1000, 60)
        lblStatus.TabIndex = 8
        lblStatus.Text = "Lengkapi semua isian, lalu klik Tambah Buku."
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' grpPencarian
        ' 
        grpPencarian.Controls.Add(lblCari)
        grpPencarian.Controls.Add(txtCari)
        grpPencarian.Controls.Add(lblFilterKategori)
        grpPencarian.Controls.Add(cboFilterKategori)
        grpPencarian.Controls.Add(lblUrut)
        grpPencarian.Controls.Add(cboUrut)
        grpPencarian.Controls.Add(chkStokHabis)
        grpPencarian.Location = New Point(34, 430)
        grpPencarian.Margin = New Padding(4, 5, 4, 5)
        grpPencarian.Name = "grpPencarian"
        grpPencarian.Padding = New Padding(4, 5, 4, 5)
        grpPencarian.Size = New Size(1474, 130)
        grpPencarian.TabIndex = 1
        grpPencarian.TabStop = False
        grpPencarian.Text = "Pencarian dan tampilan"
        ' 
        ' lblCari
        ' 
        lblCari.Location = New Point(26, 40)
        lblCari.Margin = New Padding(4, 0, 4, 0)
        lblCari.Name = "lblCari"
        lblCari.Size = New Size(471, 30)
        lblCari.TabIndex = 0
        lblCari.Text = "Cari judul atau penulis"
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(26, 77)
        txtCari.Margin = New Padding(4, 5, 4, 5)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(470, 31)
        txtCari.TabIndex = 0
        ' 
        ' lblFilterKategori
        ' 
        lblFilterKategori.Location = New Point(529, 40)
        lblFilterKategori.Margin = New Padding(4, 0, 4, 0)
        lblFilterKategori.Name = "lblFilterKategori"
        lblFilterKategori.Size = New Size(257, 30)
        lblFilterKategori.TabIndex = 1
        lblFilterKategori.Text = "Filter kategori"
        ' 
        ' cboFilterKategori
        ' 
        cboFilterKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterKategori.Items.AddRange(New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboFilterKategori.Location = New Point(529, 77)
        cboFilterKategori.Margin = New Padding(4, 5, 4, 5)
        cboFilterKategori.Name = "cboFilterKategori"
        cboFilterKategori.Size = New Size(255, 33)
        cboFilterKategori.TabIndex = 1
        ' 
        ' lblUrut
        ' 
        lblUrut.Location = New Point(820, 40)
        lblUrut.Margin = New Padding(4, 0, 4, 0)
        lblUrut.Name = "lblUrut"
        lblUrut.Size = New Size(314, 30)
        lblUrut.TabIndex = 2
        lblUrut.Text = "Urutkan buku"
        ' 
        ' cboUrut
        ' 
        cboUrut.DropDownStyle = ComboBoxStyle.DropDownList
        cboUrut.Items.AddRange(New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"})
        cboUrut.Location = New Point(820, 77)
        cboUrut.Margin = New Padding(4, 5, 4, 5)
        cboUrut.Name = "cboUrut"
        cboUrut.Size = New Size(313, 33)
        cboUrut.TabIndex = 2
        ' 
        ' chkStokHabis
        ' 
        chkStokHabis.Location = New Point(1171, 80)
        chkStokHabis.Margin = New Padding(4, 5, 4, 5)
        chkStokHabis.Name = "chkStokHabis"
        chkStokHabis.Size = New Size(257, 38)
        chkStokHabis.TabIndex = 3
        chkStokHabis.Text = "Hanya stok habis"
        chkStokHabis.UseVisualStyleBackColor = True
        ' 
        ' dgvBuku
        ' 
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.AllowUserToDeleteRows = False
        dgvBuku.AllowUserToResizeRows = False
        dgvBuku.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvBuku.BackgroundColor = Color.White
        dgvBuku.ColumnHeadersHeight = 28
        dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvBuku.Location = New Point(34, 580)
        dgvBuku.Margin = New Padding(4, 5, 4, 5)
        dgvBuku.MultiSelect = False
        dgvBuku.Name = "dgvBuku"
        dgvBuku.ReadOnly = True
        dgvBuku.RowHeadersVisible = False
        dgvBuku.RowHeadersWidth = 62
        dgvBuku.RowTemplate.Height = 22
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.Size = New Size(1474, 350)
        dgvBuku.TabIndex = 2
        ' 
        ' lblJumlah
        ' 
        lblJumlah.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblJumlah.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblJumlah.ForeColor = Color.FromArgb(CByte(30), CByte(64), CByte(90))
        lblJumlah.Location = New Point(34, 960)
        lblJumlah.Margin = New Padding(4, 0, 4, 0)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(714, 40)
        lblJumlah.TabIndex = 3
        lblJumlah.Text = "Menampilkan 0 dari 0 buku"
        ' 
        ' lblTotalStok
        ' 
        lblTotalStok.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotalStok.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblTotalStok.ForeColor = Color.FromArgb(CByte(30), CByte(64), CByte(90))
        lblTotalStok.Location = New Point(980, 960)
        lblTotalStok.Margin = New Padding(4, 0, 4, 0)
        lblTotalStok.Name = "lblTotalStok"
        lblTotalStok.Size = New Size(529, 40)
        lblTotalStok.TabIndex = 4
        lblTotalStok.Text = "Total stok: 0 eksemplar"
        lblTotalStok.TextAlign = ContentAlignment.TopRight
        ' 
        ' errBuku
        ' 
        errBuku.BlinkStyle = ErrorBlinkStyle.NeverBlink
        errBuku.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(247), CByte(249), CByte(251))
        ClientSize = New Size(1543, 1013)
        Controls.Add(lblJudulForm)
        Controls.Add(lblPetunjuk)
        Controls.Add(grpBuku)
        Controls.Add(grpPencarian)
        Controls.Add(dgvBuku)
        Controls.Add(lblJumlah)
        Controls.Add(lblTotalStok)
        Margin = New Padding(4, 5, 4, 5)
        MinimumSize = New Size(1556, 1006)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "i"
        grpBuku.ResumeLayout(False)
        grpBuku.PerformLayout()
        grpPencarian.ResumeLayout(False)
        grpPencarian.PerformLayout()
        CType(dgvBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(errBuku, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblPetunjuk As Label
    Friend WithEvents grpBuku As GroupBox
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblPenulis As Label
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblTahun As Label
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents grpPencarian As GroupBox
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents lblFilterKategori As Label
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents lblUrut As Label
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents errBuku As ErrorProvider
End Class


