<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnTampil = New Button()
        dgvMahasiswa = New DataGridView()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        txtJurusan = New TextBox()
        lblNama = New Label()
        lblNIM = New Label()
        lblJurusan = New Label()
        btnTambah = New Button()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTampil
        ' 
        btnTampil.Location = New Point(183, 357)
        btnTampil.Name = "btnTampil"
        btnTampil.Size = New Size(112, 34)
        btnTampil.TabIndex = 0
        btnTampil.Text = "Tampil"
        btnTampil.UseVisualStyleBackColor = True
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(46, 66)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.RowHeadersWidth = 62
        dgvMahasiswa.Size = New Size(360, 225)
        dgvMahasiswa.TabIndex = 1
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(558, 95)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(150, 31)
        txtNama.TabIndex = 2
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(558, 158)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(150, 31)
        txtNIM.TabIndex = 3
        ' 
        ' txtJurusan
        ' 
        txtJurusan.Location = New Point(558, 228)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(150, 31)
        txtJurusan.TabIndex = 4
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(476, 101)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(68, 25)
        lblNama.TabIndex = 5
        lblNama.Text = "Nama: "
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(476, 164)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(55, 25)
        lblNIM.TabIndex = 6
        lblNIM.Text = "NIM: "
        ' 
        ' lblJurusan
        ' 
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(476, 236)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(80, 25)
        lblJurusan.TabIndex = 7
        lblJurusan.Text = "Jurusan: "
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(553, 316)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(112, 34)
        btnTambah.TabIndex = 8
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnTambah)
        Controls.Add(lblJurusan)
        Controls.Add(lblNIM)
        Controls.Add(lblNama)
        Controls.Add(txtJurusan)
        Controls.Add(txtNIM)
        Controls.Add(txtNama)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTampil)
        Name = "Form1"
        Text = "Form1"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampil As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents txtJurusan As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNIM As Label
    Friend WithEvents lblJurusan As Label
    Friend WithEvents btnTambah As Button

End Class
