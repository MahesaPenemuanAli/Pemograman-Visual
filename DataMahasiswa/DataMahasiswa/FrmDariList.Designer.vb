<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDariList
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
        btnTambah = New Button()
        dgvMahasiswa = New DataGridView()
        lblJumlah = New Label()
        bsMahasiswa = New BindingSource(components)
        errInput = New ErrorProvider(components)
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(bsMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        lblJudul.Name = "lblJudul"
        lblJudul.Location = New Point(20, 18)
        lblJudul.Size = New Size(700, 32)
        lblJudul.Text = "List(Of Mahasiswa) + BindingSource"
        lblJudul.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        lblNim.Name = "lblNim"
        lblNim.Location = New Point(20, 65)
        lblNim.Size = New Size(80, 20)
        lblNim.Text = "NIM"
        txtNim.Name = "txtNim"
        txtNim.Location = New Point(20, 88)
        txtNim.Size = New Size(140, 23)
        txtNim.MaxLength = 9
        txtNim.TabIndex = 2
        lblNama.Name = "lblNama"
        lblNama.Location = New Point(190, 65)
        lblNama.Size = New Size(100, 20)
        lblNama.Text = "Nama"
        txtNama.Name = "txtNama"
        txtNama.Location = New Point(190, 88)
        txtNama.Size = New Size(240, 23)
        txtNama.TabIndex = 4
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Location = New Point(460, 65)
        lblJurusan.Size = New Size(120, 20)
        lblJurusan.Text = "Jurusan"
        cboJurusan.Name = "cboJurusan"
        cboJurusan.Location = New Point(460, 88)
        cboJurusan.Size = New Size(255, 23)
        cboJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Manajemen Informatika", "Teknik Komputer"})
        cboJurusan.TabIndex = 6
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Location = New Point(20, 125)
        lblAngkatan.Size = New Size(100, 20)
        lblAngkatan.Text = "Angkatan"
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.Location = New Point(20, 148)
        txtAngkatan.Size = New Size(140, 23)
        txtAngkatan.MaxLength = 4
        txtAngkatan.TabIndex = 8
        lblIpk.Name = "lblIpk"
        lblIpk.Location = New Point(190, 125)
        lblIpk.Size = New Size(100, 20)
        lblIpk.Text = "IPK"
        txtIpk.Name = "txtIpk"
        txtIpk.Location = New Point(190, 148)
        txtIpk.Size = New Size(100, 23)
        txtIpk.MaxLength = 4
        txtIpk.TabIndex = 10
        btnTambah.Name = "btnTambah"
        btnTambah.Location = New Point(460, 142)
        btnTambah.Size = New Size(110, 32)
        btnTambah.Text = "Tambah"
        btnTambah.TabIndex = 11
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.Location = New Point(20, 195)
        dgvMahasiswa.Size = New Size(720, 225)
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.TabIndex = 12
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Location = New Point(20, 435)
        lblJumlah.Size = New Size(400, 25)
        lblJumlah.Text = "Jumlah data: 0"
        errInput.ContainerControl = Me
        AcceptButton = btnTambah
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(760, 470)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        Name = "FrmDariList"
        Text = "Binding List(Of Mahasiswa)"
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
        Controls.Add(btnTambah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(lblJumlah)
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(bsMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnTambah As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
    Friend WithEvents errInput As ErrorProvider
End Class
