<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        tabMateri = New TabControl()
        tabInput = New TabPage()
        dgvMahasiswa = New DataGridView()
        pnlCari = New FlowLayoutPanel()
        lblCari = New Label()
        txtCari = New TextBox()
        cboFilterJurusan = New ComboBox()
        btnCari = New Button()
        btnResetPencarian = New Button()
        lblJumlah = New Label()
        pnlAksi = New FlowLayoutPanel()
        btnTambah = New Button()
        btnBersihkan = New Button()
        btnHapus = New Button()
        btnContoh = New Button()
        btnEkspor = New Button()
        tlpInput = New TableLayoutPanel()
        lblNIM = New Label()
        txtNIM = New TextBox()
        lblNama = New Label()
        txtNama = New TextBox()
        lblJurusan = New Label()
        cboJurusan = New ComboBox()
        lblAngkatan = New Label()
        txtAngkatan = New TextBox()
        lblTugas = New Label()
        txtTugas = New TextBox()
        lblUTS = New Label()
        txtUTS = New TextBox()
        lblUAS = New Label()
        txtUAS = New TextBox()
        tabArray = New TabPage()
        dgvArray = New DataGridView()
        lstHasilArray = New ListBox()
        pnlArray = New FlowLayoutPanel()
        btnTampilArray = New Button()
        tabRekap = New TabPage()
        dgvRekap = New DataGridView()
        lblStatistik = New Label()
        pnlRekap = New FlowLayoutPanel()
        btnMuatRekap = New Button()
        txtCariRekap = New TextBox()
        cboJurusanRekap = New ComboBox()
        btnFilterRekap = New Button()
        btnResetRekap = New Button()
        lblInfoRekap = New Label()
        tabKonversi = New TabPage()
        pnlKonversi = New FlowLayoutPanel()
        lblInfoKonversi = New Label()
        txtAngkaUji = New TextBox()
        btnUjiKonversi = New Button()
        lblHasilUji = New Label()
        lblStatus = New Label()
        bsMahasiswa = New BindingSource(components)
        bsRekap = New BindingSource(components)
        errInput = New ErrorProvider(components)
        tabMateri.SuspendLayout()
        tabInput.SuspendLayout()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        pnlCari.SuspendLayout()
        pnlAksi.SuspendLayout()
        tlpInput.SuspendLayout()
        tabArray.SuspendLayout()
        CType(dgvArray, ComponentModel.ISupportInitialize).BeginInit()
        pnlArray.SuspendLayout()
        tabRekap.SuspendLayout()
        CType(dgvRekap, ComponentModel.ISupportInitialize).BeginInit()
        pnlRekap.SuspendLayout()
        tabKonversi.SuspendLayout()
        pnlKonversi.SuspendLayout()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsRekap, ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tabMateri
        ' 
        tabMateri.Controls.Add(tabInput)
        tabMateri.Controls.Add(tabArray)
        tabMateri.Controls.Add(tabRekap)
        tabMateri.Controls.Add(tabKonversi)
        tabMateri.Dock = DockStyle.Fill
        tabMateri.Location = New Point(0, 0)
        tabMateri.Name = "tabMateri"
        tabMateri.SelectedIndex = 0
        tabMateri.Size = New Size(1164, 685)
        tabMateri.TabIndex = 0
        ' 
        ' tabInput
        ' 
        tabInput.BackColor = Color.WhiteSmoke
        tabInput.Controls.Add(dgvMahasiswa)
        tabInput.Controls.Add(pnlCari)
        tabInput.Controls.Add(pnlAksi)
        tabInput.Controls.Add(tlpInput)
        tabInput.Location = New Point(4, 37)
        tabInput.Name = "tabInput"
        tabInput.Padding = New Padding(12)
        tabInput.Size = New Size(1156, 644)
        tabInput.TabIndex = 0
        tabInput.Text = "1. Input dan Data"
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.BackgroundColor = Color.White
        dgvMahasiswa.ColumnHeadersHeight = 34
        dgvMahasiswa.Dock = DockStyle.Fill
        dgvMahasiswa.Location = New Point(12, 298)
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.RowHeadersVisible = False
        dgvMahasiswa.RowHeadersWidth = 62
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.Size = New Size(1132, 334)
        dgvMahasiswa.TabIndex = 0
        ' 
        ' pnlCari
        ' 
        pnlCari.AutoScroll = True
        pnlCari.Controls.Add(lblCari)
        pnlCari.Controls.Add(txtCari)
        pnlCari.Controls.Add(cboFilterJurusan)
        pnlCari.Controls.Add(btnCari)
        pnlCari.Controls.Add(btnResetPencarian)
        pnlCari.Controls.Add(lblJumlah)
        pnlCari.Dock = DockStyle.Top
        pnlCari.Location = New Point(12, 250)
        pnlCari.Name = "pnlCari"
        pnlCari.Size = New Size(1132, 48)
        pnlCari.TabIndex = 1
        pnlCari.WrapContents = False
        ' 
        ' lblCari
        ' 
        lblCari.AutoSize = True
        lblCari.Location = New Point(3, 0)
        lblCari.Name = "lblCari"
        lblCari.Padding = New Padding(0, 7, 0, 0)
        lblCari.Size = New Size(124, 35)
        lblCari.TabIndex = 0
        lblCari.Text = "NIM / Nama:"
        ' 
        ' txtCari
        ' 
        txtCari.Location = New Point(133, 3)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(190, 34)
        txtCari.TabIndex = 1
        ' 
        ' cboFilterJurusan
        ' 
        cboFilterJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterJurusan.Items.AddRange(New Object() {"Semua jurusan", "Teknik Informatika", "Sistem Informasi", "Teknik Komputer"})
        cboFilterJurusan.Location = New Point(329, 3)
        cboFilterJurusan.Name = "cboFilterJurusan"
        cboFilterJurusan.Size = New Size(170, 36)
        cboFilterJurusan.TabIndex = 2
        ' 
        ' btnCari
        ' 
        btnCari.AutoSize = True
        btnCari.Location = New Point(505, 3)
        btnCari.Name = "btnCari"
        btnCari.Padding = New Padding(8, 0, 8, 0)
        btnCari.Size = New Size(120, 38)
        btnCari.TabIndex = 3
        btnCari.Text = "Cari"
        ' 
        ' btnResetPencarian
        ' 
        btnResetPencarian.AutoSize = True
        btnResetPencarian.Location = New Point(631, 3)
        btnResetPencarian.Name = "btnResetPencarian"
        btnResetPencarian.Padding = New Padding(8, 0, 8, 0)
        btnResetPencarian.Size = New Size(174, 38)
        btnResetPencarian.TabIndex = 4
        btnResetPencarian.Text = "Reset pencarian"
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(811, 0)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Padding = New Padding(8)
        lblJumlah.Size = New Size(192, 44)
        lblJumlah.TabIndex = 5
        lblJumlah.Text = "0 dari 0 mahasiswa"
        ' 
        ' pnlAksi
        ' 
        pnlAksi.AutoScroll = True
        pnlAksi.Controls.Add(btnTambah)
        pnlAksi.Controls.Add(btnBersihkan)
        pnlAksi.Controls.Add(btnHapus)
        pnlAksi.Controls.Add(btnContoh)
        pnlAksi.Controls.Add(btnEkspor)
        pnlAksi.Dock = DockStyle.Top
        pnlAksi.Location = New Point(12, 202)
        pnlAksi.Name = "pnlAksi"
        pnlAksi.Size = New Size(1132, 48)
        pnlAksi.TabIndex = 2
        pnlAksi.WrapContents = False
        ' 
        ' btnTambah
        ' 
        btnTambah.AutoSize = True
        btnTambah.Location = New Point(3, 3)
        btnTambah.Name = "btnTambah"
        btnTambah.Padding = New Padding(8, 0, 8, 0)
        btnTambah.Size = New Size(120, 38)
        btnTambah.TabIndex = 0
        btnTambah.Text = "Tambah"
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.AutoSize = True
        btnBersihkan.Location = New Point(129, 3)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Padding = New Padding(8, 0, 8, 0)
        btnBersihkan.Size = New Size(121, 38)
        btnBersihkan.TabIndex = 1
        btnBersihkan.Text = "Bersihkan"
        ' 
        ' btnHapus
        ' 
        btnHapus.AutoSize = True
        btnHapus.Location = New Point(256, 3)
        btnHapus.Name = "btnHapus"
        btnHapus.Padding = New Padding(8, 0, 8, 0)
        btnHapus.Size = New Size(160, 38)
        btnHapus.TabIndex = 2
        btnHapus.Text = "Hapus terpilih"
        ' 
        ' btnContoh
        ' 
        btnContoh.AutoSize = True
        btnContoh.Location = New Point(422, 3)
        btnContoh.Name = "btnContoh"
        btnContoh.Padding = New Padding(8, 0, 8, 0)
        btnContoh.Size = New Size(139, 38)
        btnContoh.TabIndex = 3
        btnContoh.Text = "Isi 5 contoh"
        ' 
        ' btnEkspor
        ' 
        btnEkspor.AutoSize = True
        btnEkspor.Location = New Point(567, 3)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Padding = New Padding(8, 0, 8, 0)
        btnEkspor.Size = New Size(137, 38)
        btnEkspor.TabIndex = 4
        btnEkspor.Text = "Ekspor CSV"
        ' 
        ' tlpInput
        ' 
        tlpInput.ColumnCount = 4
        tlpInput.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 17.0F))
        tlpInput.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.0F))
        tlpInput.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 17.0F))
        tlpInput.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.0F))
        tlpInput.Controls.Add(lblNIM, 0, 0)
        tlpInput.Controls.Add(txtNIM, 1, 0)
        tlpInput.Controls.Add(lblNama, 2, 0)
        tlpInput.Controls.Add(txtNama, 3, 0)
        tlpInput.Controls.Add(lblJurusan, 0, 1)
        tlpInput.Controls.Add(cboJurusan, 1, 1)
        tlpInput.Controls.Add(lblAngkatan, 2, 1)
        tlpInput.Controls.Add(txtAngkatan, 3, 1)
        tlpInput.Controls.Add(lblTugas, 0, 2)
        tlpInput.Controls.Add(txtTugas, 1, 2)
        tlpInput.Controls.Add(lblUTS, 2, 2)
        tlpInput.Controls.Add(txtUTS, 3, 2)
        tlpInput.Controls.Add(lblUAS, 0, 3)
        tlpInput.Controls.Add(txtUAS, 1, 3)
        tlpInput.Dock = DockStyle.Top
        tlpInput.Location = New Point(12, 12)
        tlpInput.Name = "tlpInput"
        tlpInput.RowCount = 4
        tlpInput.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        tlpInput.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        tlpInput.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        tlpInput.RowStyles.Add(New RowStyle(SizeType.Percent, 25.0F))
        tlpInput.Size = New Size(1132, 190)
        tlpInput.TabIndex = 3
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(3, 0)
        lblNIM.Name = "lblNIM"
        lblNIM.Padding = New Padding(0, 6, 0, 0)
        lblNIM.Size = New Size(124, 34)
        lblNIM.TabIndex = 0
        lblNIM.Text = "NIM (9 digit)"
        ' 
        ' txtNIM
        ' 
        txtNIM.Dock = DockStyle.Fill
        txtNIM.Location = New Point(195, 3)
        txtNIM.Margin = New Padding(3, 3, 20, 3)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(350, 34)
        txtNIM.TabIndex = 1
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(568, 0)
        lblNama.Name = "lblNama"
        lblNama.Padding = New Padding(0, 6, 0, 0)
        lblNama.Size = New Size(64, 34)
        lblNama.TabIndex = 2
        lblNama.Text = "Nama"
        ' 
        ' txtNama
        ' 
        txtNama.Dock = DockStyle.Fill
        txtNama.Location = New Point(760, 3)
        txtNama.Margin = New Padding(3, 3, 20, 3)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(352, 34)
        txtNama.TabIndex = 3
        ' 
        ' lblJurusan
        ' 
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(3, 47)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Padding = New Padding(0, 6, 0, 0)
        lblJurusan.Size = New Size(77, 34)
        lblJurusan.TabIndex = 4
        lblJurusan.Text = "Jurusan"
        ' 
        ' cboJurusan
        ' 
        cboJurusan.Dock = DockStyle.Fill
        cboJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Teknik Komputer"})
        cboJurusan.Location = New Point(195, 50)
        cboJurusan.Margin = New Padding(3, 3, 20, 3)
        cboJurusan.Name = "cboJurusan"
        cboJurusan.Size = New Size(350, 36)
        cboJurusan.TabIndex = 5
        ' 
        ' lblAngkatan
        ' 
        lblAngkatan.AutoSize = True
        lblAngkatan.Location = New Point(568, 47)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Padding = New Padding(0, 6, 0, 0)
        lblAngkatan.Size = New Size(96, 34)
        lblAngkatan.TabIndex = 6
        lblAngkatan.Text = "Angkatan"
        ' 
        ' txtAngkatan
        ' 
        txtAngkatan.Dock = DockStyle.Fill
        txtAngkatan.Location = New Point(760, 50)
        txtAngkatan.Margin = New Padding(3, 3, 20, 3)
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.Size = New Size(352, 34)
        txtAngkatan.TabIndex = 7
        ' 
        ' lblTugas
        ' 
        lblTugas.AutoSize = True
        lblTugas.Location = New Point(3, 94)
        lblTugas.Name = "lblTugas"
        lblTugas.Padding = New Padding(0, 6, 0, 0)
        lblTugas.Size = New Size(118, 34)
        lblTugas.TabIndex = 8
        lblTugas.Text = "Tugas (30%)"
        ' 
        ' txtTugas
        ' 
        txtTugas.Dock = DockStyle.Fill
        txtTugas.Location = New Point(195, 97)
        txtTugas.Margin = New Padding(3, 3, 20, 3)
        txtTugas.Name = "txtTugas"
        txtTugas.Size = New Size(350, 34)
        txtTugas.TabIndex = 9
        ' 
        ' lblUTS
        ' 
        lblUTS.AutoSize = True
        lblUTS.Location = New Point(568, 94)
        lblUTS.Name = "lblUTS"
        lblUTS.Padding = New Padding(0, 6, 0, 0)
        lblUTS.Size = New Size(102, 34)
        lblUTS.TabIndex = 10
        lblUTS.Text = "UTS (30%)"
        ' 
        ' txtUTS
        ' 
        txtUTS.Dock = DockStyle.Fill
        txtUTS.Location = New Point(760, 97)
        txtUTS.Margin = New Padding(3, 3, 20, 3)
        txtUTS.Name = "txtUTS"
        txtUTS.Size = New Size(352, 34)
        txtUTS.TabIndex = 11
        ' 
        ' lblUAS
        ' 
        lblUAS.AutoSize = True
        lblUAS.Location = New Point(3, 141)
        lblUAS.Name = "lblUAS"
        lblUAS.Padding = New Padding(0, 6, 0, 0)
        lblUAS.Size = New Size(105, 34)
        lblUAS.TabIndex = 12
        lblUAS.Text = "UAS (40%)"
        ' 
        ' txtUAS
        ' 
        txtUAS.Dock = DockStyle.Fill
        txtUAS.Location = New Point(195, 144)
        txtUAS.Margin = New Padding(3, 3, 20, 3)
        txtUAS.Name = "txtUAS"
        txtUAS.Size = New Size(350, 34)
        txtUAS.TabIndex = 13
        ' 
        ' tabArray
        ' 
        tabArray.BackColor = Color.WhiteSmoke
        tabArray.Controls.Add(dgvArray)
        tabArray.Controls.Add(lstHasilArray)
        tabArray.Controls.Add(pnlArray)
        tabArray.Location = New Point(4, 37)
        tabArray.Name = "tabArray"
        tabArray.Padding = New Padding(12)
        tabArray.Size = New Size(192, 59)
        tabArray.TabIndex = 1
        tabArray.Text = "2. Latihan Array"
        ' 
        ' dgvArray
        ' 
        dgvArray.AllowUserToAddRows = False
        dgvArray.AllowUserToDeleteRows = False
        dgvArray.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvArray.BackgroundColor = Color.White
        dgvArray.ColumnHeadersHeight = 34
        dgvArray.Dock = DockStyle.Fill
        dgvArray.Location = New Point(12, 60)
        dgvArray.MultiSelect = False
        dgvArray.Name = "dgvArray"
        dgvArray.ReadOnly = True
        dgvArray.RowHeadersVisible = False
        dgvArray.RowHeadersWidth = 62
        dgvArray.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvArray.Size = New Size(168, 0)
        dgvArray.TabIndex = 0
        ' 
        ' lstHasilArray
        ' 
        lstHasilArray.Dock = DockStyle.Bottom
        lstHasilArray.Location = New Point(12, -97)
        lstHasilArray.Name = "lstHasilArray"
        lstHasilArray.Size = New Size(168, 144)
        lstHasilArray.TabIndex = 1
        ' 
        ' pnlArray
        ' 
        pnlArray.AutoScroll = True
        pnlArray.Controls.Add(btnTampilArray)
        pnlArray.Dock = DockStyle.Top
        pnlArray.Location = New Point(12, 12)
        pnlArray.Name = "pnlArray"
        pnlArray.Size = New Size(168, 48)
        pnlArray.TabIndex = 2
        pnlArray.WrapContents = False
        ' 
        ' btnTampilArray
        ' 
        btnTampilArray.AutoSize = True
        btnTampilArray.Location = New Point(3, 3)
        btnTampilArray.Name = "btnTampilArray"
        btnTampilArray.Padding = New Padding(8, 0, 8, 0)
        btnTampilArray.Size = New Size(276, 38)
        btnTampilArray.TabIndex = 0
        btnTampilArray.Text = "Tampilkan Array 1D dan 2D"
        ' 
        ' tabRekap
        ' 
        tabRekap.BackColor = Color.WhiteSmoke
        tabRekap.Controls.Add(dgvRekap)
        tabRekap.Controls.Add(lblStatistik)
        tabRekap.Controls.Add(pnlRekap)
        tabRekap.Controls.Add(lblInfoRekap)
        tabRekap.Location = New Point(4, 37)
        tabRekap.Name = "tabRekap"
        tabRekap.Padding = New Padding(12)
        tabRekap.Size = New Size(192, 59)
        tabRekap.TabIndex = 2
        tabRekap.Text = "3. Rekap DataTable"
        ' 
        ' dgvRekap
        ' 
        dgvRekap.AllowUserToAddRows = False
        dgvRekap.AllowUserToDeleteRows = False
        dgvRekap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRekap.BackgroundColor = Color.White
        dgvRekap.ColumnHeadersHeight = 34
        dgvRekap.Dock = DockStyle.Fill
        dgvRekap.Location = New Point(12, 102)
        dgvRekap.MultiSelect = False
        dgvRekap.Name = "dgvRekap"
        dgvRekap.ReadOnly = True
        dgvRekap.RowHeadersVisible = False
        dgvRekap.RowHeadersWidth = 62
        dgvRekap.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRekap.Size = New Size(168, 0)
        dgvRekap.TabIndex = 0
        ' 
        ' lblStatistik
        ' 
        lblStatistik.Dock = DockStyle.Bottom
        lblStatistik.Location = New Point(12, -18)
        lblStatistik.Name = "lblStatistik"
        lblStatistik.Padding = New Padding(8)
        lblStatistik.Size = New Size(168, 65)
        lblStatistik.TabIndex = 1
        lblStatistik.Text = "Tampil: 0 | Rata-rata: 0 | Tertinggi: 0 | Lulus: 0 | Tidak lulus: 0"
        ' 
        ' pnlRekap
        ' 
        pnlRekap.AutoScroll = True
        pnlRekap.Controls.Add(btnMuatRekap)
        pnlRekap.Controls.Add(txtCariRekap)
        pnlRekap.Controls.Add(cboJurusanRekap)
        pnlRekap.Controls.Add(btnFilterRekap)
        pnlRekap.Controls.Add(btnResetRekap)
        pnlRekap.Dock = DockStyle.Top
        pnlRekap.Location = New Point(12, 54)
        pnlRekap.Name = "pnlRekap"
        pnlRekap.Size = New Size(168, 48)
        pnlRekap.TabIndex = 2
        pnlRekap.WrapContents = False
        ' 
        ' btnMuatRekap
        ' 
        btnMuatRekap.AutoSize = True
        btnMuatRekap.Location = New Point(3, 3)
        btnMuatRekap.Name = "btnMuatRekap"
        btnMuatRekap.Padding = New Padding(8, 0, 8, 0)
        btnMuatRekap.Size = New Size(192, 38)
        btnMuatRekap.TabIndex = 0
        btnMuatRekap.Text = "Muat ulang rekap"
        ' 
        ' txtCariRekap
        ' 
        txtCariRekap.Location = New Point(201, 3)
        txtCariRekap.Name = "txtCariRekap"
        txtCariRekap.Size = New Size(180, 34)
        txtCariRekap.TabIndex = 1
        ' 
        ' cboJurusanRekap
        ' 
        cboJurusanRekap.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusanRekap.Items.AddRange(New Object() {"Semua jurusan", "Teknik Informatika", "Sistem Informasi", "Teknik Komputer"})
        cboJurusanRekap.Location = New Point(387, 3)
        cboJurusanRekap.Name = "cboJurusanRekap"
        cboJurusanRekap.Size = New Size(170, 36)
        cboJurusanRekap.TabIndex = 2
        ' 
        ' btnFilterRekap
        ' 
        btnFilterRekap.AutoSize = True
        btnFilterRekap.Location = New Point(563, 3)
        btnFilterRekap.Name = "btnFilterRekap"
        btnFilterRekap.Padding = New Padding(8, 0, 8, 0)
        btnFilterRekap.Size = New Size(120, 38)
        btnFilterRekap.TabIndex = 3
        btnFilterRekap.Text = "Filter"
        ' 
        ' btnResetRekap
        ' 
        btnResetRekap.AutoSize = True
        btnResetRekap.Location = New Point(689, 3)
        btnResetRekap.Name = "btnResetRekap"
        btnResetRekap.Padding = New Padding(8, 0, 8, 0)
        btnResetRekap.Size = New Size(120, 38)
        btnResetRekap.TabIndex = 4
        btnResetRekap.Text = "Reset"
        ' 
        ' lblInfoRekap
        ' 
        lblInfoRekap.Dock = DockStyle.Top
        lblInfoRekap.Location = New Point(12, 12)
        lblInfoRekap.Name = "lblInfoRekap"
        lblInfoRekap.Size = New Size(168, 42)
        lblInfoRekap.TabIndex = 3
        lblInfoRekap.Text = "Rekap adalah salinan data. Muat ulang setelah mengubah daftar utama. Klik header kolom untuk mengurutkan."
        ' 
        ' tabKonversi
        ' 
        tabKonversi.BackColor = Color.WhiteSmoke
        tabKonversi.Controls.Add(pnlKonversi)
        tabKonversi.Location = New Point(4, 37)
        tabKonversi.Name = "tabKonversi"
        tabKonversi.Padding = New Padding(12)
        tabKonversi.Size = New Size(192, 59)
        tabKonversi.TabIndex = 3
        tabKonversi.Text = "4. Uji Konversi"
        ' 
        ' pnlKonversi
        ' 
        pnlKonversi.Controls.Add(lblInfoKonversi)
        pnlKonversi.Controls.Add(txtAngkaUji)
        pnlKonversi.Controls.Add(btnUjiKonversi)
        pnlKonversi.Controls.Add(lblHasilUji)
        pnlKonversi.Dock = DockStyle.Fill
        pnlKonversi.FlowDirection = FlowDirection.TopDown
        pnlKonversi.Location = New Point(12, 12)
        pnlKonversi.Name = "pnlKonversi"
        pnlKonversi.Padding = New Padding(15)
        pnlKonversi.Size = New Size(168, 35)
        pnlKonversi.TabIndex = 0
        ' 
        ' lblInfoKonversi
        ' 
        lblInfoKonversi.AutoSize = True
        lblInfoKonversi.Location = New Point(18, 15)
        lblInfoKonversi.Name = "lblInfoKonversi"
        lblInfoKonversi.Size = New Size(132, 224)
        lblInfoKonversi.TabIndex = 0
        lblInfoKonversi.Text = "Latihan Integer.Parse dan Try–Catch–Finally. Coba: 25, abc, atau 999999999999999."
        ' 
        ' txtAngkaUji
        ' 
        txtAngkaUji.Location = New Point(156, 18)
        txtAngkaUji.Name = "txtAngkaUji"
        txtAngkaUji.Size = New Size(240, 34)
        txtAngkaUji.TabIndex = 1
        ' 
        ' btnUjiKonversi
        ' 
        btnUjiKonversi.AutoSize = True
        btnUjiKonversi.Location = New Point(402, 18)
        btnUjiKonversi.Name = "btnUjiKonversi"
        btnUjiKonversi.Padding = New Padding(8, 0, 8, 0)
        btnUjiKonversi.Size = New Size(140, 38)
        btnUjiKonversi.TabIndex = 2
        btnUjiKonversi.Text = "Uji konversi"
        ' 
        ' lblHasilUji
        ' 
        lblHasilUji.AutoSize = True
        lblHasilUji.Location = New Point(548, 15)
        lblHasilUji.MaximumSize = New Size(800, 0)
        lblHasilUji.Name = "lblHasilUji"
        lblHasilUji.Size = New Size(299, 28)
        lblHasilUji.TabIndex = 3
        lblHasilUji.Text = "Hasil konversi akan tampil di sini."
        ' 
        ' lblStatus
        ' 
        lblStatus.Dock = DockStyle.Bottom
        lblStatus.Location = New Point(0, 685)
        lblStatus.Name = "lblStatus"
        lblStatus.Padding = New Padding(10)
        lblStatus.Size = New Size(1164, 36)
        lblStatus.TabIndex = 1
        lblStatus.Text = "Siap. Data tersimpan sementara selama aplikasi berjalan."
        ' 
        ' errInput
        ' 
        errInput.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(11.0F, 28.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1164, 721)
        Controls.Add(tabMateri)
        Controls.Add(lblStatus)
        Font = New Font("Segoe UI", 10.0F)
        MinimumSize = New Size(960, 650)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Latihan Responsi • Pengelolaan Nilai Mahasiswa"
        tabMateri.ResumeLayout(False)
        tabInput.ResumeLayout(False)
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        pnlCari.ResumeLayout(False)
        pnlCari.PerformLayout()
        pnlAksi.ResumeLayout(False)
        pnlAksi.PerformLayout()
        tlpInput.ResumeLayout(False)
        tlpInput.PerformLayout()
        tabArray.ResumeLayout(False)
        CType(dgvArray, ComponentModel.ISupportInitialize).EndInit()
        pnlArray.ResumeLayout(False)
        pnlArray.PerformLayout()
        tabRekap.ResumeLayout(False)
        CType(dgvRekap, ComponentModel.ISupportInitialize).EndInit()
        pnlRekap.ResumeLayout(False)
        pnlRekap.PerformLayout()
        tabKonversi.ResumeLayout(False)
        pnlKonversi.ResumeLayout(False)
        pnlKonversi.PerformLayout()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(bsRekap, ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents tabMateri As TabControl
    Friend WithEvents lblStatus As Label
    Friend WithEvents tabInput As TabPage
    Friend WithEvents tabArray As TabPage
    Friend WithEvents tabRekap As TabPage
    Friend WithEvents tabKonversi As TabPage
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents dgvArray As DataGridView
    Friend WithEvents dgvRekap As DataGridView
    Friend WithEvents pnlCari As FlowLayoutPanel
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cboFilterJurusan As ComboBox
    Friend WithEvents btnCari As Button
    Friend WithEvents btnResetPencarian As Button
    Friend WithEvents lblJumlah As Label
    Friend WithEvents pnlAksi As FlowLayoutPanel
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnContoh As Button
    Friend WithEvents btnEkspor As Button
    Friend WithEvents tlpInput As TableLayoutPanel
    Friend WithEvents lblNIM As Label
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblJurusan As Label
    Friend WithEvents cboJurusan As ComboBox
    Friend WithEvents lblAngkatan As Label
    Friend WithEvents txtAngkatan As TextBox
    Friend WithEvents lblTugas As Label
    Friend WithEvents txtTugas As TextBox
    Friend WithEvents lblUTS As Label
    Friend WithEvents txtUTS As TextBox
    Friend WithEvents lblUAS As Label
    Friend WithEvents txtUAS As TextBox
    Friend WithEvents lstHasilArray As ListBox
    Friend WithEvents pnlArray As FlowLayoutPanel
    Friend WithEvents btnTampilArray As Button
    Friend WithEvents lblStatistik As Label
    Friend WithEvents pnlRekap As FlowLayoutPanel
    Friend WithEvents btnMuatRekap As Button
    Friend WithEvents txtCariRekap As TextBox
    Friend WithEvents cboJurusanRekap As ComboBox
    Friend WithEvents btnFilterRekap As Button
    Friend WithEvents btnResetRekap As Button
    Friend WithEvents lblInfoRekap As Label
    Friend WithEvents pnlKonversi As FlowLayoutPanel
    Friend WithEvents lblInfoKonversi As Label
    Friend WithEvents txtAngkaUji As TextBox
    Friend WithEvents btnUjiKonversi As Button
    Friend WithEvents lblHasilUji As Label
    Friend WithEvents bsMahasiswa As BindingSource
    Friend WithEvents bsRekap As BindingSource
    Friend WithEvents errInput As ErrorProvider
End Class
