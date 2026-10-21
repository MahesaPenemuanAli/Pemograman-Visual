<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDariArray
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
        dgvMahasiswa = New DataGridView()
        btnTampilkan = New Button()
        btnKosongkan = New Button()
        lblJumlah = New Label()
        colNim = New DataGridViewTextBoxColumn()
        colNama = New DataGridViewTextBoxColumn()
        colJurusan = New DataGridViewTextBoxColumn()
        colAngkatan = New DataGridViewTextBoxColumn()
        colIpk = New DataGridViewTextBoxColumn()
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        lblJudul.Name = "lblJudul"
        lblJudul.Location = New Point(20, 18)
        lblJudul.Size = New Size(700, 32)
        lblJudul.Text = "Data dari Array 2 Dimensi"
        lblJudul.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.Location = New Point(20, 65)
        dgvMahasiswa.Size = New Size(680, 265)
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.TabIndex = 1
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Location = New Point(20, 345)
        btnTampilkan.Size = New Size(110, 32)
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.TabIndex = 2
        btnKosongkan.Name = "btnKosongkan"
        btnKosongkan.Location = New Point(140, 345)
        btnKosongkan.Size = New Size(110, 32)
        btnKosongkan.Text = "Kosongkan"
        btnKosongkan.TabIndex = 3
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Location = New Point(470, 353)
        lblJumlah.Size = New Size(230, 25)
        lblJumlah.Text = "Jumlah data: 0"
        colNim.Name = "colNim"
        colNim.HeaderText = "NIM"
        colNama.Name = "colNama"
        colNama.HeaderText = "Nama"
        colJurusan.Name = "colJurusan"
        colJurusan.HeaderText = "Jurusan"
        colAngkatan.Name = "colAngkatan"
        colAngkatan.HeaderText = "Angkatan"
        colIpk.Name = "colIpk"
        colIpk.HeaderText = "IPK"
        dgvMahasiswa.Columns.AddRange(New DataGridViewColumn() {colNim, colNama, colJurusan, colAngkatan, colIpk})
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(720, 400)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        Name = "FrmDariArray"
        Text = "DataGridView dari Array"
        Controls.Add(lblJudul)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTampilkan)
        Controls.Add(btnKosongkan)
        Controls.Add(lblJumlah)
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents lblJumlah As Label
    Friend WithEvents colNim As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colJurusan As DataGridViewTextBoxColumn
    Friend WithEvents colAngkatan As DataGridViewTextBoxColumn
    Friend WithEvents colIpk As DataGridViewTextBoxColumn
End Class
