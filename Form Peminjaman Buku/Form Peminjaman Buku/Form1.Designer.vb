<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    ' Membersihkan komponen form ketika form ditutup.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' Menyiapkan seluruh kontrol dan properti yang dikelola Windows Forms Designer.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblNamaPeminjam = New Label()
        txtNamaPeminjam = New TextBox()
        lblLamaPinjam = New Label()
        txtLamaPinjam = New TextBox()
        btnPinjam = New Button()
        btnBersihkan = New Button()
        lblDaftarPeminjaman = New Label()
        lstPeminjaman = New ListBox()
        btnEkspor = New Button()
        lblStatus = New Label()
        errPinjam = New ErrorProvider(components)
        CType(errPinjam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblJudulForm.ForeColor = Color.FromArgb(CByte(32), CByte(64), CByte(96))
        lblJudulForm.Location = New Point(24, 20)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(325, 48)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Buku"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Location = New Point(24, 82)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(107, 28)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode buku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Location = New Point(191, 78)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(238, 34)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Location = New Point(24, 126)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(107, 28)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Location = New Point(190, 122)
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(704, 34)
        txtJudul.TabIndex = 4
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Location = New Point(24, 170)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(87, 28)
        lblKategori.TabIndex = 5
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(190, 166)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(238, 36)
        cboKategori.TabIndex = 6
        ' 
        ' lblNamaPeminjam
        ' 
        lblNamaPeminjam.AutoSize = True
        lblNamaPeminjam.Location = New Point(24, 214)
        lblNamaPeminjam.Name = "lblNamaPeminjam"
        lblNamaPeminjam.Size = New Size(156, 28)
        lblNamaPeminjam.TabIndex = 7
        lblNamaPeminjam.Text = "Nama peminjam"
        ' 
        ' txtNamaPeminjam
        ' 
        txtNamaPeminjam.Location = New Point(190, 210)
        txtNamaPeminjam.Name = "txtNamaPeminjam"
        txtNamaPeminjam.Size = New Size(704, 34)
        txtNamaPeminjam.TabIndex = 8
        ' 
        ' lblLamaPinjam
        ' 
        lblLamaPinjam.AutoSize = True
        lblLamaPinjam.Location = New Point(24, 258)
        lblLamaPinjam.Name = "lblLamaPinjam"
        lblLamaPinjam.Size = New Size(123, 28)
        lblLamaPinjam.TabIndex = 9
        lblLamaPinjam.Text = "Lama pinjam"
        ' 
        ' txtLamaPinjam
        ' 
        txtLamaPinjam.Location = New Point(190, 254)
        txtLamaPinjam.Name = "txtLamaPinjam"
        txtLamaPinjam.Size = New Size(96, 34)
        txtLamaPinjam.TabIndex = 10
        ' 
        ' btnPinjam
        ' 
        btnPinjam.BackColor = Color.FromArgb(CByte(32), CByte(90), CByte(145))
        btnPinjam.FlatStyle = FlatStyle.Flat
        btnPinjam.ForeColor = Color.White
        btnPinjam.Location = New Point(190, 300)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(114, 36)
        btnPinjam.TabIndex = 11
        btnPinjam.Text = "&Pinjam"
        btnPinjam.UseVisualStyleBackColor = False
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.CausesValidation = False
        btnBersihkan.Location = New Point(316, 300)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(114, 36)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "&Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' lblDaftarPeminjaman
        ' 
        lblDaftarPeminjaman.AutoSize = True
        lblDaftarPeminjaman.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDaftarPeminjaman.Location = New Point(24, 360)
        lblDaftarPeminjaman.Name = "lblDaftarPeminjaman"
        lblDaftarPeminjaman.Size = New Size(196, 28)
        lblDaftarPeminjaman.TabIndex = 13
        lblDaftarPeminjaman.Text = "Daftar peminjaman"
        ' 
        ' lstPeminjaman
        ' 
        lstPeminjaman.FormattingEnabled = True
        lstPeminjaman.HorizontalScrollbar = True
        lstPeminjaman.IntegralHeight = False
        lstPeminjaman.Location = New Point(24, 390)
        lstPeminjaman.Name = "lstPeminjaman"
        lstPeminjaman.Size = New Size(892, 142)
        lstPeminjaman.TabIndex = 14
        ' 
        ' btnEkspor
        ' 
        btnEkspor.CausesValidation = False
        btnEkspor.Location = New Point(784, 550)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(132, 36)
        btnEkspor.TabIndex = 15
        btnEkspor.Text = "&Ekspor CSV"
        btnEkspor.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.Location = New Point(24, 556)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(744, 26)
        lblStatus.TabIndex = 16
        lblStatus.Text = "Jumlah peminjaman: 0"
        ' 
        ' errPinjam
        ' 
        errPinjam.BlinkStyle = ErrorBlinkStyle.NeverBlink
        errPinjam.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AcceptButton = btnPinjam
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(940, 610)
        Controls.Add(lblJudulForm)
        Controls.Add(lblKodeBuku)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblJudul)
        Controls.Add(txtJudul)
        Controls.Add(lblKategori)
        Controls.Add(cboKategori)
        Controls.Add(lblNamaPeminjam)
        Controls.Add(txtNamaPeminjam)
        Controls.Add(lblLamaPinjam)
        Controls.Add(txtLamaPinjam)
        Controls.Add(btnPinjam)
        Controls.Add(btnBersihkan)
        Controls.Add(lblDaftarPeminjaman)
        Controls.Add(lstPeminjaman)
        Controls.Add(btnEkspor)
        Controls.Add(lblStatus)
        Font = New Font("Segoe UI", 10F)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "frmPeminjamanBuku"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Peminjaman Buku"
        CType(errPinjam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblNamaPeminjam As Label
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblDaftarPeminjaman As Label
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errPinjam As ErrorProvider
End Class
