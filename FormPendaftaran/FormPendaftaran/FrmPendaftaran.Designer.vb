<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPendaftaran
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
        components = New System.ComponentModel.Container()
        lblJudul = New Label()
        lblNim = New Label()
        txtNim = New TextBox()
        lblNama = New Label()
        txtNama = New TextBox()
        lblJurusan = New Label()
        cboJurusan = New ComboBox()
        lblAngkatan = New Label()
        txtAngkatan = New TextBox()
        lblIpk = New Label()
        txtIpk = New TextBox()
        btnSimpan = New Button()
        btnBersihkan = New Button()
        lblDaftar = New Label()
        lstMahasiswa = New ListBox()
        btnEkspor = New Button()
        lblStatus = New Label()
        errInput = New ErrorProvider(components)
        CType(errInput, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' lblJudul
        lblJudul.Location = New Point(24, 20)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(732, 32)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Pendaftaran Mahasiswa"
        lblJudul.AutoSize = False
        lblJudul.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        ' lblNim
        lblNim.Location = New Point(24, 81)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(76, 23)
        lblNim.TabIndex = 1
        lblNim.Text = "NIM"
        lblNim.AutoSize = False
        ' txtNim
        txtNim.Location = New Point(110, 78)
        txtNim.Name = "txtNim"
        txtNim.Size = New Size(226, 23)
        txtNim.TabIndex = 2
        txtNim.MaxLength = 9
        ' lblNama
        lblNama.Location = New Point(24, 127)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(76, 23)
        lblNama.TabIndex = 3
        lblNama.Text = "Nama"
        lblNama.AutoSize = False
        ' txtNama
        txtNama.Location = New Point(110, 124)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(226, 23)
        txtNama.TabIndex = 4
        txtNama.MaxLength = 100
        ' lblJurusan
        lblJurusan.Location = New Point(24, 173)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(76, 23)
        lblJurusan.TabIndex = 5
        lblJurusan.Text = "Jurusan"
        lblJurusan.AutoSize = False
        ' cboJurusan
        cboJurusan.Location = New Point(110, 170)
        cboJurusan.Name = "cboJurusan"
        cboJurusan.Size = New Size(226, 23)
        cboJurusan.TabIndex = 6
        cboJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusan.FormattingEnabled = True
        ' lblAngkatan
        lblAngkatan.Location = New Point(24, 219)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Size = New Size(76, 23)
        lblAngkatan.TabIndex = 7
        lblAngkatan.Text = "Angkatan"
        lblAngkatan.AutoSize = False
        ' txtAngkatan
        txtAngkatan.Location = New Point(110, 216)
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.Size = New Size(226, 23)
        txtAngkatan.TabIndex = 8
        txtAngkatan.MaxLength = 4
        ' lblIpk
        lblIpk.Location = New Point(24, 265)
        lblIpk.Name = "lblIpk"
        lblIpk.Size = New Size(76, 23)
        lblIpk.TabIndex = 9
        lblIpk.Text = "IPK"
        lblIpk.AutoSize = False
        ' txtIpk
        txtIpk.Location = New Point(110, 262)
        txtIpk.Name = "txtIpk"
        txtIpk.Size = New Size(226, 23)
        txtIpk.TabIndex = 10
        txtIpk.MaxLength = 4
        ' btnSimpan
        btnSimpan.Location = New Point(110, 310)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(106, 36)
        btnSimpan.TabIndex = 11
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' btnBersihkan
        btnBersihkan.Location = New Point(226, 310)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(110, 36)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        btnBersihkan.CausesValidation = False
        ' lblDaftar
        lblDaftar.Location = New Point(380, 59)
        lblDaftar.Name = "lblDaftar"
        lblDaftar.Size = New Size(376, 23)
        lblDaftar.TabIndex = 13
        lblDaftar.Text = "Data tersimpan"
        lblDaftar.AutoSize = False
        ' lstMahasiswa
        lstMahasiswa.Location = New Point(380, 86)
        lstMahasiswa.Name = "lstMahasiswa"
        lstMahasiswa.Size = New Size(376, 282)
        lstMahasiswa.TabIndex = 14
        lstMahasiswa.HorizontalScrollbar = True
        lstMahasiswa.IntegralHeight = False
        ' btnEkspor
        btnEkspor.Location = New Point(380, 380)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(146, 34)
        btnEkspor.TabIndex = 15
        btnEkspor.Text = "Ekspor ke CSV"
        btnEkspor.UseVisualStyleBackColor = True
        btnEkspor.CausesValidation = False
        ' lblStatus
        lblStatus.Location = New Point(24, 430)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(732, 28)
        lblStatus.TabIndex = 16
        lblStatus.Text = "Siap."
        lblStatus.AutoSize = False
        cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Manajemen Informatika", "Teknik Komputer"})
        errInput.ContainerControl = Me
        AcceptButton = btnSimpan
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(780, 470)
        Controls.Add(lblJudul)
        Controls.Add(lblNim)
        Controls.Add(txtNim)
        Controls.Add(lblNama)
        Controls.Add(txtNama)
        Controls.Add(lblJurusan)
        Controls.Add(cboJurusan)
        Controls.Add(lblAngkatan)
        Controls.Add(txtAngkatan)
        Controls.Add(lblIpk)
        Controls.Add(txtIpk)
        Controls.Add(btnSimpan)
        Controls.Add(btnBersihkan)
        Controls.Add(lblDaftar)
        Controls.Add(lstMahasiswa)
        Controls.Add(btnEkspor)
        Controls.Add(lblStatus)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmPendaftaran"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pendaftaran Mahasiswa"
        CType(errInput, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblNim As Label
    Friend WithEvents txtNim As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblJurusan As Label
    Friend WithEvents cboJurusan As ComboBox
    Friend WithEvents lblAngkatan As Label
    Friend WithEvents txtAngkatan As TextBox
    Friend WithEvents lblIpk As Label
    Friend WithEvents txtIpk As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblDaftar As Label
    Friend WithEvents lstMahasiswa As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errInput As ErrorProvider
End Class
